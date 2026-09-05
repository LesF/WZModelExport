using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ModelExport
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();

			string piePath = Properties.Settings.Default.PathPies;
			string texPath = Properties.Settings.Default.PathTexpages;
			string wmitPath = Properties.Settings.Default.PathWMIT;
			string tempPath = Properties.Settings.Default.PathTemp;

			// Auto-detect local project Assets folder if configured paths don't exist
			if (string.IsNullOrEmpty(piePath) || !Directory.Exists(piePath))
			{
				string autoPie = TryFindAssetsFolder("components");
				if (!string.IsNullOrEmpty(autoPie))
					piePath = autoPie;
			}

			if (string.IsNullOrEmpty(texPath) || !Directory.Exists(texPath))
			{
				string autoTex = TryFindAssetsFolder("texpages");
				if (!string.IsNullOrEmpty(autoTex))
					texPath = autoTex;
			}

			if (string.IsNullOrEmpty(tempPath) || !Directory.Exists(tempPath))
			{
				string autoTemp = Path.Combine(Path.GetTempPath(), "WZModelExport");
				if (!Directory.Exists(autoTemp))
				{
					try { Directory.CreateDirectory(autoTemp); } catch { }
				}
				tempPath = autoTemp;
			}

			TxPathPIE.Text = piePath;
			TxPathTexpages.Text = texPath;
			TxPathWMIT.Text = wmitPath;
			TxPathTemp.Text = tempPath;
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

		private void BtnSave_Click(object sender, EventArgs e)
		{
			List<string> errs = new List<string>();

			string exeName = TxPathWMIT.Text.Trim();
			if (exeName.Length > 0 && !File.Exists(exeName))
				errs.Add("Invalid WMIT.exe path name");

			string pieDir = TxPathPIE.Text.Trim();
			if (pieDir.Length > 0 && !Directory.Exists(pieDir))
				errs.Add("Invalid PIE directory");

			string texDir = TxPathTexpages.Text.Trim();
			if (texDir.Length > 0 && !Directory.Exists(texDir))
				errs.Add("Invalid Textures directory");

			string tempDir = TxPathTemp.Text.Trim();
			if (tempDir.Length > 0 && !Directory.Exists(tempDir))
				errs.Add("Invalid temp file directory");

			if (errs.Count > 0)
			{
				MessageBox.Show(this, string.Join("\r\n", errs), "Please review settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				this.DialogResult = DialogResult.None;
				return;
			}

			Properties.Settings.Default.PathPies = TxPathPIE.Text;
			Properties.Settings.Default.PathTexpages = TxPathTexpages.Text;
			Properties.Settings.Default.PathWMIT = TxPathWMIT.Text;
			Properties.Settings.Default.PathTemp = TxPathTemp.Text;
			Properties.Settings.Default.Save();
			this.DialogResult = DialogResult.OK;
		}

		private void BrowseDir(TextBox TxPath, string Caption)
		{
			string startDir = "";
			if (TxPath.Text.Trim().Length > 0)
			{
				DirectoryInfo dir = new DirectoryInfo(TxPath.Text.Trim());
				if (dir.Exists)
					startDir = dir.FullName;
			}

			folderBrowserDialog1.SelectedPath = startDir;
			folderBrowserDialog1.Description = Caption;
			if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
				TxPath.Text = folderBrowserDialog1.SelectedPath;
		}

		private void BrowseFilePath(TextBox TxPath, string Caption, string Filter)
		{
			openFileDialog1.Filter = Filter;
			openFileDialog1.Title = Caption;
			openFileDialog1.InitialDirectory = TxPath.Text;
			openFileDialog1.FileName = TxPath.Text;
			openFileDialog1.CheckFileExists = true;
			if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				TxPath.Text = openFileDialog1.FileName;
			}
		}

		private void BtnPathWMIT_Click(object sender, EventArgs e)
		{
			BrowseFilePath(TxPathWMIT, "Full path to WMIT.exe", "Executable files (*.exe)|*.exe|All files (*.*)|*.*");
		}

		private void BtnPathPie_Click(object sender, EventArgs e)
		{
			BrowseDir(TxPathPIE, "Directory containing your Warzone 2100 PIE files");
		}

		private void BtnPathTexpages_Click(object sender, EventArgs e)
		{
			BrowseDir(TxPathTexpages, "Directory containing texture pages (.png)");
		}

		private void BtnPathTemp_Click(object sender, EventArgs e)
		{
			BrowseDir(TxPathTemp, "Temporary file directory");
		}
	}
}