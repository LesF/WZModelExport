using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using ModelExport.Export;
using ModelExport.Models;
using ModelExport.Services;

namespace ModelExport.Controls
{
	public partial class PieViewportControl : UserControl
	{
		private HelixViewport3D _viewport;
		private ModelVisual3D _modelVisual;
		private DefaultLights _defaultLights;

		private PieModel _currentModel;
		private string _currentTexturePath;
		private readonly GltfExportService _exportService = new GltfExportService();

		public event EventHandler<string> TextureChanged;

		public PieModel CurrentModel => _currentModel;
		public string CurrentTexturePath => _currentTexturePath;

		public PieViewportControl()
		{
			InitializeComponent();
			InitializeHelixViewport();
		}

		private void InitializeHelixViewport()
		{
			_viewport = new HelixViewport3D
			{
				ModelUpDirection = new Vector3D(0, 1, 0),
				ShowCoordinateSystem = true,
				ShowViewCube = true,
				ShowCameraInfo = false,
				ShowTriangleCountInfo = true,
				ZoomExtentsWhenLoaded = true,
				Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(30, 34, 42)),
				IsRotationEnabled = true,
				IsPanEnabled = true,
				IsZoomEnabled = true
			};

			_defaultLights = new DefaultLights();
			_viewport.Children.Add(_defaultLights);

			_modelVisual = new ModelVisual3D();
			_viewport.Children.Add(_modelVisual);

			elementHost1.Child = _viewport;
		}

		public void LoadModel(PieModel model, string texturePath)
		{
			_currentModel = model;
			_currentTexturePath = texturePath;

			// Populate level selector
			cmbLevel.SelectedIndexChanged -= CmbLevel_SelectedIndexChanged;
			cmbLevel.Items.Clear();

			if (_currentModel != null && _currentModel.Levels.Count > 1)
			{
				cmbLevel.Items.Add("All Levels");
				for (int i = 0; i < _currentModel.Levels.Count; i++)
				{
					cmbLevel.Items.Add($"Level {_currentModel.Levels[i].LevelNumber}");
				}
				cmbLevel.SelectedIndex = 1; // Default to Level 1
				lblLevel.Visible = true;
				cmbLevel.Visible = true;
			}
			else
			{
				lblLevel.Visible = false;
				cmbLevel.Visible = false;
			}
			cmbLevel.SelectedIndexChanged += CmbLevel_SelectedIndexChanged;

			UpdateTextureLabel();
			Rebuild3DScene();
		}

		public void SetTexture(string texturePath)
		{
			_currentTexturePath = texturePath;
			UpdateTextureLabel();
			Rebuild3DScene();
			TextureChanged?.Invoke(this, _currentTexturePath);
		}

		private void UpdateTextureLabel()
		{
			if (string.IsNullOrEmpty(_currentTexturePath) || !File.Exists(_currentTexturePath))
			{
				string texName = _currentModel?.PrimaryTextureName;
				lblTexture.Text = string.IsNullOrEmpty(texName) ? "Texture: (None)" : $"Texture: {texName} (Missing)";
				lblTexture.ForeColor = System.Drawing.Color.DarkOrange;
			}
			else
			{
				lblTexture.Text = $"Texture: {Path.GetFileName(_currentTexturePath)}";
				lblTexture.ForeColor = System.Drawing.Color.DarkGreen;
			}
		}

		private void Rebuild3DScene()
		{
			_modelVisual.Children.Clear();
			_modelVisual.Content = null;

			if (_currentModel == null || _currentModel.Levels.Count == 0)
				return;

			// Determine which levels to render
			List<PieLevel> levelsToRender = new List<PieLevel>();
			if (cmbLevel.Visible && cmbLevel.SelectedIndex > 0)
			{
				int levelIdx = cmbLevel.SelectedIndex - 1;
				if (levelIdx >= 0 && levelIdx < _currentModel.Levels.Count)
					levelsToRender.Add(_currentModel.Levels[levelIdx]);
			}
			else
			{
				levelsToRender.AddRange(_currentModel.Levels);
			}

			// Build mesh
			var meshBuilder = new MeshBuilder(false, true);

			foreach (var level in levelsToRender)
			{
				if (level.Points.Count == 0 || level.Polygons.Count == 0)
					continue;

				foreach (var poly in level.Polygons)
				{
					if (poly.VertexIndices == null || poly.VertexIndices.Length < 3)
						continue;

					int i0 = poly.VertexIndices[0];
					int i1 = poly.VertexIndices[1];
					int i2 = poly.VertexIndices[2];

					if (i0 < 0 || i0 >= level.Points.Count ||
						i1 < 0 || i1 >= level.Points.Count ||
						i2 < 0 || i2 >= level.Points.Count)
					{
						continue;
					}

					var p0 = level.Points[i0].ToPoint3D();
					var p1 = level.Points[i1].ToPoint3D();
					var p2 = level.Points[i2].ToPoint3D();

					var uv0 = new System.Windows.Point(poly.U[0], poly.V[0]);
					var uv1 = new System.Windows.Point(poly.U[1], poly.V[1]);
					var uv2 = new System.Windows.Point(poly.U[2], poly.V[2]);

					meshBuilder.AddTriangle(p0, p1, p2, uv0, uv1, uv2);
				}
			}

			var geometry = meshBuilder.ToMesh();

			// Prepare material
			Material material = CreateMaterial();

			var modelGroup = new Model3DGroup();
			var geomModel = new GeometryModel3D(geometry, material)
			{
				BackMaterial = material // Render double-sided so backfaces are visible
			};
			modelGroup.Children.Add(geomModel);

			_modelVisual.Content = modelGroup;

			// Add wireframe overlay if enabled
			if (btnWireframe.Checked)
			{
				var wireframe = new LinesVisual3D
				{
					Color = System.Windows.Media.Colors.Cyan,
					Thickness = 1
				};
				for (int i = 0; i < geometry.TriangleIndices.Count; i += 3)
				{
					var p0 = geometry.Positions[geometry.TriangleIndices[i]];
					var p1 = geometry.Positions[geometry.TriangleIndices[i + 1]];
					var p2 = geometry.Positions[geometry.TriangleIndices[i + 2]];
					wireframe.Points.Add(p0); wireframe.Points.Add(p1);
					wireframe.Points.Add(p1); wireframe.Points.Add(p2);
					wireframe.Points.Add(p2); wireframe.Points.Add(p0);
				}
				_modelVisual.Children.Add(wireframe);
			}

			// Auto zoom to fit
			_viewport.ZoomExtents();
		}

		private Material CreateMaterial()
		{
			if (!btnWireframe.Checked && !string.IsNullOrEmpty(_currentTexturePath) && File.Exists(_currentTexturePath))
			{
				try
				{
					var bitmap = new BitmapImage();
					bitmap.BeginInit();
					bitmap.CacheOption = BitmapCacheOption.OnLoad;
					bitmap.UriSource = new Uri(Path.GetFullPath(_currentTexturePath));
					bitmap.EndInit();
					bitmap.Freeze();

					var brush = new ImageBrush(bitmap)
					{
						TileMode = TileMode.Tile
					};
					return new DiffuseMaterial(brush);
				}
				catch
				{
					// Fallback if image fails to load
				}
			}

			// Fallback neutral blue-gray material
			var fallbackBrush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(100, 149, 237));
			return new DiffuseMaterial(fallbackBrush);
		}

		private void BtnResetView_Click(object sender, EventArgs e)
		{
			_viewport.ResetCamera();
			_viewport.ZoomExtents();
		}

		private void BtnWireframe_Click(object sender, EventArgs e)
		{
			Rebuild3DScene();
		}

		private void CmbLevel_SelectedIndexChanged(object sender, EventArgs e)
		{
			Rebuild3DScene();
		}

		private void BtnChangeTexture_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(_currentTexturePath))
			{
				try
				{
					string dir = Path.GetDirectoryName(_currentTexturePath);
					if (Directory.Exists(dir))
						openFileDialogTexture.InitialDirectory = dir;
					openFileDialogTexture.FileName = Path.GetFileName(_currentTexturePath);
				}
				catch { }
			}

			if (openFileDialogTexture.ShowDialog(this) == DialogResult.OK)
			{
				SetTexture(openFileDialogTexture.FileName);
			}
		}

		private void BtnExportGltf_Click(object sender, EventArgs e)
		{
			if (_currentModel == null)
			{
				MessageBox.Show(this, "Please select a PIE model first.", "No Model Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			var plan = _exportService.PrepareExportPlan(_currentModel, _currentTexturePath);
			using (var dlg = new GltfExportDialog(plan))
			{
				dlg.ShowDialog(this);
			}
		}
	}
}
