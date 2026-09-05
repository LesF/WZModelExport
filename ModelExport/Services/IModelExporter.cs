using System.Collections.Generic;
using ModelExport.Models;

namespace ModelExport.Services
{
	/// <summary>
	/// Details and specifications for an export operation to another 3D format.
	/// </summary>
	public class ModelExportPlan
	{
		public string SourceModelName { get; set; } = string.Empty;
		public string SourceFilePath { get; set; } = string.Empty;
		public int SourcePieVersion { get; set; }
		public int VertexCount { get; set; }
		public int TriangleCount { get; set; }
		public int LevelCount { get; set; }
		public int ConnectorCount { get; set; }

		public string TextureName { get; set; } = string.Empty;
		public string TexturePath { get; set; } = string.Empty;
		public int TextureWidth { get; set; }
		public int TextureHeight { get; set; }

		public string TargetFormat { get; set; } = "glTF 2.0 / GLB";
		public string PlannedPipelineSummary { get; set; } = string.Empty;
		public List<string> PlannedSteps { get; } = new List<string>();
	}

	/// <summary>
	/// Abstraction for exporting Warzone 2100 PIE models to modern 3D formats (glTF, GLB, OBJ, STL).
	/// </summary>
	public interface IModelExporter
	{
		string FormatName { get; }
		string DefaultExtension { get; }
		string FileFilter { get; }

		ModelExportPlan PrepareExportPlan(PieModel model, string texturePath);
		void Export(PieModel model, string texturePath, string outputPath);
	}
}
