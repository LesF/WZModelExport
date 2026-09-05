using System;
using System.Drawing;
using System.IO;

namespace ModelExport.Services
{
	public class TextureResolutionResult
	{
		public bool IsFound => !string.IsNullOrEmpty(FullPath) && File.Exists(FullPath);
		public string TextureName { get; set; } = string.Empty;
		public string FullPath { get; set; } = string.Empty;
		public int Width { get; set; }
		public int Height { get; set; }
		public string StatusMessage { get; set; } = string.Empty;
	}

	/// <summary>
	/// Service for locating and resolving texture images corresponding to PIE models.
	/// </summary>
	public class TextureResolver
	{
		public TextureResolutionResult ResolveTexture(string textureFileName, string pieFilePath)
		{
			var result = new TextureResolutionResult
			{
				TextureName = textureFileName
			};

			if (string.IsNullOrEmpty(textureFileName))
			{
				result.StatusMessage = "No texture specified in model.";
				return result;
			}

			// 1. Check configured PathTexpages setting
			string configuredPath = Properties.Settings.Default.PathTexpages;
			if (!string.IsNullOrEmpty(configuredPath) && Directory.Exists(configuredPath))
			{
				string candidate = Path.Combine(configuredPath, textureFileName);
				if (File.Exists(candidate))
				{
					return PopulateResult(result, candidate, "Resolved from configured texpages folder");
				}

				// Check subdirectories of configured path
				try
				{
					string[] found = Directory.GetFiles(configuredPath, textureFileName, SearchOption.AllDirectories);
					if (found.Length > 0)
						return PopulateResult(result, found[0], "Resolved from configured texpages subfolder");
				}
				catch { }
			}

			// 2. Check relative to PIE file directory
			if (!string.IsNullOrEmpty(pieFilePath) && File.Exists(pieFilePath))
			{
				string pieDir = Path.GetDirectoryName(pieFilePath);

				// Same directory
				string sameDir = Path.Combine(pieDir, textureFileName);
				if (File.Exists(sameDir))
					return PopulateResult(result, sameDir, "Resolved from model directory");

				// Relative ..\texpages, ..\..\texpages, ..\..\..\texpages
				string current = pieDir;
				for (int i = 0; i < 4; i++)
				{
					string texpagesCandidate = Path.Combine(current, "texpages", textureFileName);
					if (File.Exists(texpagesCandidate))
						return PopulateResult(result, texpagesCandidate, "Resolved relative to model folder");

					var parent = Directory.GetParent(current);
					if (parent == null) break;
					current = parent.FullName;
				}
			}

			// 3. Check relative to App Domain BaseDirectory
			string baseDir = AppDomain.CurrentDomain.BaseDirectory;
			string[] assetRelativePaths = new string[]
			{
				Path.Combine(baseDir, "Assets", "base", "texpages", textureFileName),
				Path.Combine(baseDir, "..", "..", "Assets", "base", "texpages", textureFileName),
				Path.Combine(baseDir, "..", "..", "..", "Assets", "base", "texpages", textureFileName)
			};

			foreach (var path in assetRelativePaths)
			{
				if (File.Exists(path))
					return PopulateResult(result, Path.GetFullPath(path), "Resolved from local Assets folder");
			}

			result.StatusMessage = $"Texture file '{textureFileName}' not found. Please review Settings or browse manually.";
			return result;
		}

		private static TextureResolutionResult PopulateResult(TextureResolutionResult res, string path, string status)
		{
			res.FullPath = Path.GetFullPath(path);
			res.StatusMessage = status;
			try
			{
				using (var img = Image.FromFile(res.FullPath))
				{
					res.Width = img.Width;
					res.Height = img.Height;
				}
			}
			catch
			{
				// Ignore if reading dimensions fails
			}
			return res;
		}
	}
}
