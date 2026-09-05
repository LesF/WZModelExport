using System;
using System.Text;
using System.Windows.Forms;
using ModelExport.Services;

namespace ModelExport.Export
{
	public partial class GltfExportDialog : Form
	{
		private readonly ModelExportPlan _plan;

		public GltfExportDialog(ModelExportPlan plan)
		{
			InitializeComponent();
			_plan = plan ?? throw new ArgumentNullException(nameof(plan));
			PopulateData();
		}

		private void PopulateData()
		{
			lblModelNameVal.Text = _plan.SourceModelName;
			lblVersionVal.Text = $"PIE {_plan.SourcePieVersion}";
			lblMeshStatsVal.Text = $"{_plan.VertexCount} vertices, {_plan.TriangleCount} triangles, {_plan.LevelCount} level(s), {_plan.ConnectorCount} connector(s)";

			lblTextureNameVal.Text = !string.IsNullOrEmpty(_plan.TextureName) ? _plan.TextureName : "(None)";
			if (_plan.TextureWidth > 0 && _plan.TextureHeight > 0)
				lblTextureDimVal.Text = $"{_plan.TextureWidth} x {_plan.TextureHeight} px";
			else
				lblTextureDimVal.Text = "Unknown / Unresolved";

			lblTexturePathVal.Text = !string.IsNullOrEmpty(_plan.TexturePath) ? _plan.TexturePath : "(Texture file not located)";

			var sb = new StringBuilder();
			sb.AppendLine(_plan.PlannedPipelineSummary);
			sb.AppendLine();
			sb.AppendLine("Planned Implementation Pipeline:");
			foreach (var step in _plan.PlannedSteps)
			{
				sb.AppendLine(step);
			}
			txtPipeline.Text = sb.ToString();
		}

		private void BtnCopy_Click(object sender, EventArgs e)
		{
			var sb = new StringBuilder();
			sb.AppendLine("=== glTF 2.0 / GLB Export Specifications ===");
			sb.AppendLine($"Source Model: {_plan.SourceModelName} (PIE {_plan.SourcePieVersion})");
			sb.AppendLine($"Vertices: {_plan.VertexCount}");
			sb.AppendLine($"Triangles: {_plan.TriangleCount}");
			sb.AppendLine($"Levels: {_plan.LevelCount}");
			sb.AppendLine($"Connectors: {_plan.ConnectorCount}");
			sb.AppendLine($"Texture: {_plan.TextureName} ({_plan.TextureWidth}x{_plan.TextureHeight})");
			sb.AppendLine($"Texture Path: {_plan.TexturePath}");
			sb.AppendLine();
			sb.AppendLine("Pipeline Steps:");
			foreach (var step in _plan.PlannedSteps)
			{
				sb.AppendLine(step);
			}

			try
			{
				Clipboard.SetText(sb.ToString());
				MessageBox.Show(this, "Export specifications copied to clipboard!", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, $"Failed to copy to clipboard: {ex.Message}", "Clipboard Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}
}
