using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media.Media3D;

namespace ModelExport.Models
{
	/// <summary>
	/// Represents a texture declaration in a PIE model file.
	/// Usually: TEXTURE <id> <filename> [<width> <height>]
	/// </summary>
	public class PieTextureDecl
	{
		public int Id { get; set; }
		public string FileName { get; set; } = string.Empty;
		public int Width { get; set; }
		public int Height { get; set; }

		public override string ToString()
		{
			if (Width > 0 && Height > 0)
				return $"{FileName} ({Width}x{Height})";
			return FileName;
		}
	}

	/// <summary>
	/// Represents a 3D vertex position in PIE coordinates.
	/// In WZ2100: X is left/right, Y is height (up), Z is depth/forward.
	/// </summary>
	public struct PiePoint
	{
		public double X { get; set; }
		public double Y { get; set; }
		public double Z { get; set; }

		public PiePoint(double x, double y, double z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public Point3D ToPoint3D() => new Point3D(X, Y, Z);

		public override string ToString() => $"({X:F2}, {Y:F2}, {Z:F2})";
	}

	/// <summary>
	/// Represents a textured polygon (typically a triangle) in a PIE model.
	/// </summary>
	public class PiePolygon
	{
		public int Flags { get; set; }
		public int[] VertexIndices { get; set; } = new int[3];
		public double[] U { get; set; } = new double[3];
		public double[] V { get; set; } = new double[3];

		public int AnimationFrames { get; set; }
		public int PlaybackRate { get; set; }
		public int FrameWidth { get; set; }
		public int FrameHeight { get; set; }

		public bool HasAnimation => (Flags & 0x4000) != 0;
	}

	/// <summary>
	/// Represents one mesh level / animation frame in a PIE model.
	/// </summary>
	public class PieLevel
	{
		public int LevelNumber { get; set; }
		public List<PiePoint> Points { get; } = new List<PiePoint>();
		public List<PiePolygon> Polygons { get; } = new List<PiePolygon>();
		public List<PiePoint> Connectors { get; } = new List<PiePoint>();
	}

	/// <summary>
	/// Complete parsed Warzone 2100 PIE model.
	/// </summary>
	public class PieModel
	{
		public string FilePath { get; set; } = string.Empty;
		public string FileName => Path.GetFileName(FilePath);
		public int Version { get; set; } = 2;
		public int TypeFlags { get; set; }
		public List<PieTextureDecl> Textures { get; } = new List<PieTextureDecl>();
		public List<PieLevel> Levels { get; } = new List<PieLevel>();
		public List<PiePoint> Connectors { get; } = new List<PiePoint>();

		public string PrimaryTextureName => Textures.Count > 0 ? Textures[0].FileName : string.Empty;

		public int TotalVertexCount => Levels.Sum(l => l.Points.Count);
		public int TotalPolygonCount => Levels.Sum(l => l.Polygons.Count);
		public int LevelCount => Levels.Count;
	}
}
