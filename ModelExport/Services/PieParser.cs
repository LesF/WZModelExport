using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ModelExport.Models;

namespace ModelExport.Services
{
	/// <summary>
	/// Parser for Warzone 2100 PIE model files (supports PIE 2, PIE 3, and PIE 4).
	/// </summary>
	public class PieParser
	{
		private enum ParseState
		{
			Header,
			ReadingPoints,
			ReadingPolygons,
			ReadingConnectors
		}

		public PieModel ParseFile(string filePath)
		{
			if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
				throw new FileNotFoundException("PIE file not found", filePath);

			using (var reader = File.OpenText(filePath))
			{
				var model = Parse(reader);
				model.FilePath = filePath;
				return model;
			}
		}

		public PieModel ParseText(string pieText, string filePath = "")
		{
			using (var reader = new StringReader(pieText))
			{
				var model = Parse(reader);
				model.FilePath = filePath;
				return model;
			}
		}

		public PieModel Parse(TextReader reader)
		{
			var model = new PieModel();
			PieLevel currentLevel = null;

			ParseState state = ParseState.Header;
			int remainingCount = 0;

			string line;
			while ((line = reader.ReadLine()) != null)
			{
				string trimmed = line.Trim();
				if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("#"))
					continue;

				string[] tokens = trimmed.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
				if (tokens.Length == 0)
					continue;

				string firstToken = tokens[0].ToUpperInvariant();

				// Check for section headers
				if (firstToken == "PIE")
				{
					if (tokens.Length > 1 && int.TryParse(tokens[1], out int ver))
						model.Version = ver;
					state = ParseState.Header;
					continue;
				}

				if (firstToken == "TYPE")
				{
					if (tokens.Length > 1)
					{
						string typeStr = tokens[1];
						if (typeStr.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
							int.TryParse(typeStr.Substring(2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int hexVal);
						else
							int.TryParse(typeStr, NumberStyles.Integer, CultureInfo.InvariantCulture, out int decVal);
					}
					state = ParseState.Header;
					continue;
				}

				if (firstToken == "TEXTURE")
				{
					var tex = new PieTextureDecl();
					if (tokens.Length > 1 && int.TryParse(tokens[1], out int id))
						tex.Id = id;
					if (tokens.Length > 2)
						tex.FileName = tokens[2];
					if (tokens.Length > 4)
					{
						int.TryParse(tokens[3], NumberStyles.Integer, CultureInfo.InvariantCulture, out int w);
						int.TryParse(tokens[4], NumberStyles.Integer, CultureInfo.InvariantCulture, out int h);
						tex.Width = w;
						tex.Height = h;
					}
					model.Textures.Add(tex);
					state = ParseState.Header;
					continue;
				}

				if (firstToken == "LEVELS")
				{
					state = ParseState.Header;
					continue;
				}

				if (firstToken == "LEVEL")
				{
					int levelNum = 1;
					if (tokens.Length > 1)
						int.TryParse(tokens[1], out levelNum);

					currentLevel = new PieLevel { LevelNumber = levelNum };
					model.Levels.Add(currentLevel);
					state = ParseState.Header;
					continue;
				}

				if (firstToken == "POINTS")
				{
					EnsureLevel(model, ref currentLevel);
					if (tokens.Length > 1 && int.TryParse(tokens[1], out int count))
					{
						remainingCount = count;
						state = ParseState.ReadingPoints;
					}
					continue;
				}

				if (firstToken == "POLYGONS")
				{
					EnsureLevel(model, ref currentLevel);
					if (tokens.Length > 1 && int.TryParse(tokens[1], out int count))
					{
						remainingCount = count;
						state = ParseState.ReadingPolygons;
					}
					continue;
				}

				if (firstToken == "CONNECTORS")
				{
					if (tokens.Length > 1 && int.TryParse(tokens[1], out int count))
					{
						remainingCount = count;
						state = ParseState.ReadingConnectors;
					}
					continue;
				}

				// Data lines according to state
				switch (state)
				{
					case ParseState.ReadingPoints:
						if (remainingCount > 0 && tokens.Length >= 3)
						{
							if (double.TryParse(tokens[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double x) &&
								double.TryParse(tokens[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double y) &&
								double.TryParse(tokens[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double z))
							{
								currentLevel?.Points.Add(new PiePoint(x, y, z));
							}
							remainingCount--;
							if (remainingCount <= 0)
								state = ParseState.Header;
						}
						break;

					case ParseState.ReadingPolygons:
						if (remainingCount > 0 && tokens.Length >= 5)
						{
							ParsePolygonLine(model, currentLevel, tokens);
							remainingCount--;
							if (remainingCount <= 0)
								state = ParseState.Header;
						}
						break;

					case ParseState.ReadingConnectors:
						if (remainingCount > 0 && tokens.Length >= 3)
						{
							if (double.TryParse(tokens[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double cx) &&
								double.TryParse(tokens[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double cy) &&
								double.TryParse(tokens[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double cz))
							{
								var cp = new PiePoint(cx, cy, cz);
								if (currentLevel != null)
									currentLevel.Connectors.Add(cp);
								else
									model.Connectors.Add(cp);
							}
							remainingCount--;
							if (remainingCount <= 0)
								state = ParseState.Header;
						}
						break;
				}
			}

			// If no levels were encountered at all, add empty level 1
			if (model.Levels.Count == 0)
			{
				model.Levels.Add(new PieLevel { LevelNumber = 1 });
			}

			return model;
		}

		private static void EnsureLevel(PieModel model, ref PieLevel currentLevel)
		{
			if (currentLevel == null)
			{
				currentLevel = new PieLevel { LevelNumber = model.Levels.Count + 1 };
				model.Levels.Add(currentLevel);
			}
		}

		private static void ParsePolygonLine(PieModel model, PieLevel currentLevel, string[] tokens)
		{
			if (currentLevel == null || tokens.Length < 5)
				return;

			var poly = new PiePolygon();

			// tokens[0] is flags
			int.TryParse(tokens[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out int flags);
			poly.Flags = flags;

			// tokens[1] is vertex count (should be 3)
			int.TryParse(tokens[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out int numVerts);
			if (numVerts < 3)
				numVerts = 3;

			// tokens[2, 3, 4] are vertex indices
			poly.VertexIndices = new int[numVerts];
			for (int v = 0; v < numVerts; v++)
			{
				if (2 + v < tokens.Length)
					int.TryParse(tokens[2 + v], NumberStyles.Integer, CultureInfo.InvariantCulture, out poly.VertexIndices[v]);
			}

			// Determine texture width & height for normalization in PIE 2
			int texW = 256;
			int texH = 256;
			if (model.Textures.Count > 0)
			{
				if (model.Textures[0].Width > 0) texW = model.Textures[0].Width;
				if (model.Textures[0].Height > 0) texH = model.Textures[0].Height;
			}

			// UV coordinates are always the last numVerts * 2 tokens on the line
			int uvCount = numVerts * 2;
			poly.U = new double[numVerts];
			poly.V = new double[numVerts];

			if (tokens.Length >= 2 + numVerts + uvCount)
			{
				int uvStartIndex = tokens.Length - uvCount;

				// If animated texture flag (0x4000) is present and extra tokens exist
				if ((flags & 0x4000) != 0 && uvStartIndex >= 2 + numVerts + 4)
				{
					int animIdx = 2 + numVerts;
					int.TryParse(tokens[animIdx], NumberStyles.Integer, CultureInfo.InvariantCulture, out int frames);
					int.TryParse(tokens[animIdx + 1], NumberStyles.Integer, CultureInfo.InvariantCulture, out int rate);
					int.TryParse(tokens[animIdx + 2], NumberStyles.Integer, CultureInfo.InvariantCulture, out int fw);
					int.TryParse(tokens[animIdx + 3], NumberStyles.Integer, CultureInfo.InvariantCulture, out int fh);
					poly.AnimationFrames = frames;
					poly.PlaybackRate = rate;
					poly.FrameWidth = fw;
					poly.FrameHeight = fh;
				}

				for (int i = 0; i < numVerts; i++)
				{
					double.TryParse(tokens[uvStartIndex + i * 2], NumberStyles.Float, CultureInfo.InvariantCulture, out double u);
					double.TryParse(tokens[uvStartIndex + i * 2 + 1], NumberStyles.Float, CultureInfo.InvariantCulture, out double v);

					if (model.Version == 2 && texW > 0 && texH > 0)
					{
						u /= texW;
						v /= texH;
					}

					poly.U[i] = u;
					poly.V[i] = v;
				}
			}

			currentLevel.Polygons.Add(poly);
		}
	}
}
