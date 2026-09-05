using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using ModelExport.Export;
using ModelExport.Models;
using ModelExport.Services;

namespace ModelExport
{
	/// <summary>
	/// Main startup form. WZ2100 PIE model search, tag management, and embedded 3D viewer.
	/// </summary>
	public partial class PIEReview : Form
	{
		private string mSavedToOBJ;
		private Dictionary<string, PIEMetadata> mPIEMetadata = new Dictionary<string, PIEMetadata>();
		private string mTempPath;
		private string mDataStore;

		private readonly PieParser _pieParser = new PieParser();
		private readonly TextureResolver _textureResolver = new TextureResolver();
		private readonly GltfExportService _gltfExportService = new GltfExportService();

		private PieModel _selectedPieModel;
		private string _selectedTexturePath;

		public PIEReview()
		{
			InitializeComponent();

			pieViewportControl1.TextureChanged += PieViewportControl1_TextureChanged;

			EnsureDefaultPaths();

			if (string.IsNullOrEmpty(Properties.Settings.Default.PathPies)
				|| !Directory.Exists(Properties.Settings.Default.PathPies))
			{
				UpdateSettings();
			}
			else
			{
				LoadMetadata();
				ReloadPieDirectory();
			}
		}

		private void EnsureDefaultPaths()
		{
			// Check if PathPies is missing or points to non-existent location
			string currentPies = Properties.Settings.Default.PathPies;
			if (string.IsNullOrEmpty(currentPies) || !Directory.Exists(currentPies))
			{
				string autoPie = TryFindAssetsFolder("components");
				if (!string.IsNullOrEmpty(autoPie))
				{
					Properties.Settings.Default.PathPies = autoPie;
				}
			}

			string currentTex = Properties.Settings.Default.PathTexpages;
			if (string.IsNullOrEmpty(currentTex) || !Directory.Exists(currentTex))
			{
				string autoTex = TryFindAssetsFolder("texpages");
				if (!string.IsNullOrEmpty(autoTex))
				{
					Properties.Settings.Default.PathTexpages = autoTex;
				}
			}

			string currentTemp = Properties.Settings.Default.PathTemp;
			if (string.IsNullOrEmpty(currentTemp) || !Directory.Exists(currentTemp))
			{
				string autoTemp = Path.Combine(Path.GetTempPath(), "WZModelExport");
				if (!Directory.Exists(autoTemp))
				{
					try { Directory.CreateDirectory(autoTemp); } catch { }
				}
				Properties.Settings.Default.PathTemp = autoTemp;
			}

			Properties.Settings.Default.Save();
		}

		private static string TryFindAssetsFolder(string subfolder)
		{
			string baseDir = AppDomain.CurrentDomain.BaseDirectory;
			string[] candidates = new string[]
			{
				Path.Combine(baseDir, "Assets", "base", subfolder),
				Path.Combine(baseDir, "..", "..", "Assets", "base", subfolder),
				Path.Combine(baseDir, "..", "..", "..", "Assets", "base", subfolder),
				Path.Combine(baseDir, "..", "..", "ModelExport", "Assets", "base", subfolder)
			};

			foreach (var c in candidates)
			{
				if (Directory.Exists(c))
					return Path.GetFullPath(c);
			}

			return string.Empty;
		}

		private bool UpdateSettings()
		{
			using (var settingsDialog = new SettingsForm())
			{
				if (settingsDialog.ShowDialog(this) == DialogResult.OK)
				{
					LoadMetadata();
					ReloadPieDirectory();
					return true;
				}
			}
			return false;
		}

		private void ToolStripBtnRefresh_Click(object sender, EventArgs e)
		{
			ReloadPieDirectory();
		}

		private void ToolStripBtnSettings_Click(object sender, EventArgs e)
		{
			UpdateSettings();
		}

		private void ToolStripTxFilter_TextChanged(object sender, EventArgs e)
		{
			ReloadPieDirectory();
		}

		private void ToolStripTagFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			ReloadPieDirectory();
		}

		/// <summary>
		/// Populate the PIE list view. Subdirectories are searched recursively.
		/// </summary>
		private void ReloadPieDirectory()
		{
			LvPieFiles.Items.Clear();

			string pathPies = Properties.Settings.Default.PathPies;
			if (string.IsNullOrEmpty(pathPies) || !Directory.Exists(pathPies))
			{
				TxPieContent.Text = $"Pie directory not found, check settings\r\n({pathPies})";
				txModelInfo.Text = "Please configure a valid PIE models folder in Settings.";
				return;
			}

			DirectoryInfo dir = new DirectoryInfo(pathPies);
			FileInfo[] files;
			try
			{
				files = dir.GetFiles("*.pie", SearchOption.AllDirectories);
			}
			catch (Exception ex)
			{
				TxPieContent.Text = $"Error scanning directory: {ex.Message}";
				return;
			}

			LvPieFiles.BeginUpdate();
			string filter = ToolStripTxFilter.Text.Trim();

			foreach (FileInfo pieFile in files)
			{
				string textureName = "";
				string textureSize = "";
				string pieType = "";

				try
				{
					using (var rdr = pieFile.OpenText())
					{
						for (int idx = 0; idx < 5; idx++)
						{
							string row = rdr.ReadLine();
							if (row == null) break;
							string[] elementArr = row.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
							if (elementArr.Length == 0) continue;

							switch (elementArr[0].ToUpperInvariant())
							{
								case "PIE":
									if (pieType.Length > 0) pieType += ", ";
									pieType += row.Trim();
									break;
								case "TYPE":
									if (pieType.Length > 0) pieType += ", ";
									pieType += row.Trim();
									break;
								case "TEXTURE":
									if (elementArr.Length > 2)
										textureName = elementArr[2];
									if (elementArr.Length > 4)
										textureSize = $"{elementArr[3]}x{elementArr[4]}";
									break;
							}
						}
					}
				}
				catch { }

				string dataKey = pieFile.Name.ToLower();
				string tags = "";
				if (mPIEMetadata != null && mPIEMetadata.ContainsKey(dataKey))
					tags = string.Join(",", mPIEMetadata[dataKey].Tags);

				// Relative path display if inside subfolder (e.g. bodies\drhbod09.pie)
				string displayName = pieFile.Name;
				try
				{
					if (pieFile.FullName.StartsWith(dir.FullName, StringComparison.OrdinalIgnoreCase))
					{
						string rel = pieFile.FullName.Substring(dir.FullName.Length).TrimStart('\\', '/');
						if (!string.IsNullOrEmpty(rel))
							displayName = rel;
					}
				}
				catch { }

				string[] metadata = new string[] { displayName, textureName, textureSize, pieType, tags };

				bool includeIt = true;
				if (ToolStripTagFilter.SelectedIndex > 0)
				{
					string tagFilter = ToolStripTagFilter.SelectedItem.ToString();
					includeIt = mPIEMetadata != null && mPIEMetadata.ContainsKey(dataKey) && mPIEMetadata[dataKey].Tags.Contains(tagFilter);
				}

				if (includeIt && filter.Length > 0)
				{
					includeIt = false;
					for (int i = 0; i < metadata.Length; i++)
					{
						if (metadata[i].IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1)
						{
							includeIt = true;
							break;
						}
					}
				}

				if (includeIt)
				{
					ListViewItem itm = new ListViewItem(metadata)
					{
						Tag = pieFile.FullName
					};
					LvPieFiles.Items.Add(itm);
				}
			}

			LvPieFiles.EndUpdate();

			if (LvPieFiles.Items.Count > 0 && LvPieFiles.SelectedItems.Count == 0)
			{
				LvPieFiles.Items[0].Selected = true;
			}
		}

		private void LvPieFiles_ItemActivate(object sender, EventArgs e)
		{
			if (LvPieFiles.SelectedItems.Count < 1) return;

			ListViewItem selection = LvPieFiles.SelectedItems[0];
			string piePath = (string)selection.Tag;
			if (!string.IsNullOrEmpty(piePath) && File.Exists(piePath))
				OpenWMIT(piePath);
		}

		private void LvPieFiles_Click(object sender, EventArgs e)
		{
			SelectCurrentItem();
		}

		private void LvPieFiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectCurrentItem();
		}

		private void SelectCurrentItem()
		{
			if (LvPieFiles.SelectedItems.Count < 1)
				return;

			ListViewItem selection = LvPieFiles.SelectedItems[0];
			string piePath = (string)selection.Tag;
			if (!string.IsNullOrEmpty(piePath) && File.Exists(piePath))
			{
				LoadPieView(piePath);
			}
		}

		private void LoadPieView(string piePath)
		{
			try
			{
				// 1. Raw text view
				string thePie = File.ReadAllText(piePath);
				TxPieContent.Text = thePie;

				// 2. Parse PIE model
				_selectedPieModel = _pieParser.ParseFile(piePath);

				// 3. Resolve texture
				string primaryTex = _selectedPieModel.PrimaryTextureName;
				var texResult = _textureResolver.ResolveTexture(primaryTex, piePath);
				_selectedTexturePath = texResult.FullPath;

				// 4. Update embedded 3D Viewport
				pieViewportControl1.LoadModel(_selectedPieModel, _selectedTexturePath);

				// 5. Update Model & Texture Info tab
				UpdateModelInfoTab(texResult);
			}
			catch (Exception ex)
			{
				TxPieContent.Text = $"Error loading PIE file ({piePath}):\r\n{ex.Message}";
				txModelInfo.Text = $"Failed to parse model:\r\n{ex.Message}";
			}
		}

		private void UpdateModelInfoTab(TextureResolutionResult texResult)
		{
			if (_selectedPieModel == null) return;

			var sb = new StringBuilder();
			sb.AppendLine("=== Warzone 2100 Model Information ===");
			sb.AppendLine($"File Name:       {_selectedPieModel.FileName}");
			sb.AppendLine($"Full Path:       {_selectedPieModel.FilePath}");
			sb.AppendLine($"PIE Version:     PIE {_selectedPieModel.Version}");
			sb.AppendLine($"Type Flags:      {_selectedPieModel.TypeFlags}");
			sb.AppendLine($"Total Vertices:  {_selectedPieModel.TotalVertexCount}");
			sb.AppendLine($"Total Triangles: {_selectedPieModel.TotalPolygonCount}");
			sb.AppendLine($"Levels Count:    {_selectedPieModel.LevelCount}");
			sb.AppendLine($"Connectors:      {_selectedPieModel.Connectors.Count}");
			sb.AppendLine();

			sb.AppendLine("=== Associated Texture ===");
			sb.AppendLine($"Declared Name:   {(!string.IsNullOrEmpty(_selectedPieModel.PrimaryTextureName) ? _selectedPieModel.PrimaryTextureName : "(None)")}");
			if (texResult != null && texResult.IsFound)
			{
				sb.AppendLine($"Status:          Found");
				sb.AppendLine($"Resolution:      {texResult.Width} x {texResult.Height} px");
				sb.AppendLine($"Resolved Path:   {texResult.FullPath}");
				sb.AppendLine($"Note:            {texResult.StatusMessage}");
			}
			else
			{
				sb.AppendLine($"Status:          MISSING / NOT FOUND");
				sb.AppendLine($"Search Note:     {texResult?.StatusMessage ?? "Texture file could not be located."}");
			}
			sb.AppendLine();

			string dataKey = _selectedPieModel.FileName.ToLowerInvariant();
			if (mPIEMetadata != null && mPIEMetadata.ContainsKey(dataKey))
			{
				sb.AppendLine("=== Tags ===");
				sb.AppendLine(string.Join(", ", mPIEMetadata[dataKey].Tags));
			}

			txModelInfo.Text = sb.ToString();
		}

		private void PieViewportControl1_TextureChanged(object sender, string newTexturePath)
		{
			_selectedTexturePath = newTexturePath;
			var texResult = new TextureResolutionResult
			{
				FullPath = newTexturePath,
				TextureName = Path.GetFileName(newTexturePath),
				StatusMessage = "Manually selected by user"
			};
			if (File.Exists(newTexturePath))
			{
				try
				{
					using (var img = System.Drawing.Image.FromFile(newTexturePath))
					{
						texResult.Width = img.Width;
						texResult.Height = img.Height;
					}
				}
				catch { }
			}
			UpdateModelInfoTab(texResult);
		}

		private void ToolStripBtnExportGltf_Click(object sender, EventArgs e)
		{
			ShowGltfExportDialog();
		}

		private void ShowGltfExportDialog()
		{
			if (_selectedPieModel == null)
			{
				MessageBox.Show(this, "Please select a PIE model first.", "No Model Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			var plan = _gltfExportService.PrepareExportPlan(_selectedPieModel, _selectedTexturePath);
			using (var dlg = new GltfExportDialog(plan))
			{
				dlg.ShowDialog(this);
			}
		}

		private void OpenWMIT(string piePath)
		{
			if (string.IsNullOrEmpty(Properties.Settings.Default.PathWMIT) || !File.Exists(Properties.Settings.Default.PathWMIT))
			{
				MessageBox.Show(this, "Please set the WMIT.exe path in settings", "WMIT.exe path is required");
				return;
			}
			if (!File.Exists(piePath))
			{
				MessageBox.Show(this, $"Invalid file path:\r\n{piePath}", "PIE File Not Found");
				return;
			}

			Process WMITProcess = new Process();
			try
			{
				WMITProcess.StartInfo.UseShellExecute = false;
				WMITProcess.StartInfo.FileName = Properties.Settings.Default.PathWMIT;
				WMITProcess.StartInfo.Arguments = piePath;
				WMITProcess.EnableRaisingEvents = true;
				WMITProcess.Start();
			}
			catch (Exception exc)
			{
				MessageBox.Show(this, $"Process creation failed\r\n{exc.Message}", "WMIT Call Failed");
			}
		}

		private void contextMenuStripLV_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (LvPieFiles.SelectedItems.Count < 1)
				return;

			ListViewItem selection = LvPieFiles.SelectedItems[0];
			string piePath = (string)selection.Tag;
			if (string.IsNullOrEmpty(piePath) || !File.Exists(piePath))
				return;

			string action = e.ClickedItem.Name;
			switch (action)
			{
				case "MenuItemViewInWMIT":
					OpenWMIT(piePath);
					break;

				case "MenuItemViewAsOBJ":
					SaveToOBJ(piePath, true);
					break;

				case "MenuItemExportGltf":
					ShowGltfExportDialog();
					break;

				case "MenuItemEditTags":
					EditMetadata(selection);
					break;

				default:
					break;
			}
		}

		private void SaveToOBJ(string piePath, bool viewAfter)
		{
			FileInfo fileInfo = new FileInfo(piePath);
			if (string.IsNullOrEmpty(piePath) || !fileInfo.Exists)
				return;
			string pieName = fileInfo.Name;
			if (!pieName.EndsWith(".pie", StringComparison.OrdinalIgnoreCase))
				return;
			if (string.IsNullOrEmpty(Properties.Settings.Default.PathTemp) || !Directory.Exists(Properties.Settings.Default.PathTemp))
				return;

			mSavedToOBJ = Path.Combine(Properties.Settings.Default.PathTemp,
				pieName.Substring(0, pieName.Length - 3) + "obj");

			if (File.Exists(mSavedToOBJ))
				File.Delete(mSavedToOBJ);

			Process WMITProcess = new Process();
			try
			{
				Directory.SetCurrentDirectory(Properties.Settings.Default.PathTemp);

				WMITProcess.StartInfo.UseShellExecute = false;
				WMITProcess.StartInfo.FileName = Properties.Settings.Default.PathWMIT;
				WMITProcess.StartInfo.Arguments = $"\"{piePath}\" \"{mSavedToOBJ}\"";
				WMITProcess.EnableRaisingEvents = true;
				if (viewAfter)
					WMITProcess.Exited += ExportProcess_Exited;
				WMITProcess.Start();
				if (viewAfter)
					WMITProcess.WaitForExit(5000);
			}
			catch (Exception exc)
			{
				MessageBox.Show(this, $"Process creation failed\r\n{exc.Message}", "WMIT Call Failed");
			}
		}

		private void ExportProcess_Exited(object sender, EventArgs e)
		{
			ViewOBJ(mSavedToOBJ);
		}

		private void ViewOBJ(string objPath)
		{
			FileInfo fileInfo = new FileInfo(objPath);
			if (!fileInfo.Exists)
			{
				MessageBox.Show(this, $"Invalid file path:\r\n{objPath}", "OBJ File Not Found");
				return;
			}

			Process OBJViewer = new Process();
			try
			{
				Directory.SetCurrentDirectory(fileInfo.DirectoryName);
				OBJViewer.StartInfo.UseShellExecute = true;
				OBJViewer.StartInfo.FileName = objPath;
				OBJViewer.Start();
			}
			catch (Exception exc)
			{
				MessageBox.Show(this, $"Process creation failed\r\n{exc.Message}", "OBJ View Failed");
			}
		}

		private void LoadMetadata()
		{
			mPIEMetadata = new Dictionary<string, PIEMetadata>();
			mTempPath = Properties.Settings.Default.PathTemp;
			if (Directory.Exists(mTempPath))
			{
				mDataStore = Path.Combine(mTempPath, "Data");
				if (!Directory.Exists(mDataStore))
					Directory.CreateDirectory(mDataStore);
				mDataStore = Path.Combine(mDataStore, "PIEData.json");

				if (File.Exists(mDataStore))
				{
					string jsonData = File.ReadAllText(mDataStore);
					mPIEMetadata = new JavaScriptSerializer().Deserialize<Dictionary<string, PIEMetadata>>(jsonData);
					if (mPIEMetadata == null)
						mPIEMetadata = new Dictionary<string, PIEMetadata>();
					PopulateTagFilter();
				}
			}
		}

		private void PopulateTagFilter()
		{
			List<string> list = new List<string>();
			if (mPIEMetadata != null)
			{
				foreach (string key in mPIEMetadata.Keys)
				{
					foreach (string tag in mPIEMetadata[key].Tags)
					{
						if (tag.Length > 0 && !list.Contains(tag))
							list.Add(tag);
					}
				}
			}
			list.Sort();
			ToolStripTagFilter.Items.Clear();
			ToolStripTagFilter.Items.Add("<all>");
			foreach (string tag in list)
				ToolStripTagFilter.Items.Add(tag);
			ToolStripTagFilter.SelectedIndex = 0;
		}

		private void EditMetadata(ListViewItem pieItem)
		{
			string piePath = pieItem.Tag as string;
			FileInfo fileInfo = new FileInfo(piePath);
			if (fileInfo.Exists)
			{
				PIETagsEdit editDialog = new PIETagsEdit();
				string dataKey = fileInfo.Name.ToLower();
				editDialog.LoadPIE(dataKey, mPIEMetadata);
				if (editDialog.ShowDialog(this) == DialogResult.OK)
				{
					string jsonData = new JavaScriptSerializer().Serialize(mPIEMetadata);
					File.WriteAllText(mDataStore, jsonData);

					if (mPIEMetadata.ContainsKey(dataKey))
						pieItem.SubItems[4].Text = string.Join(",", mPIEMetadata[dataKey].Tags);
					else
						pieItem.SubItems[4].Text = "";

					PopulateTagFilter();
				}
			}
		}
	}
}
