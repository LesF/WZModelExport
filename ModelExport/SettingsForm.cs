using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelExport
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();

			TxPathPIE.Text = Properties.Settings.Default.PathPies;
			TxPathWMIT.Text = Properties.Settings.Default.PathWMIT;
			TxPathTemp.Text = Properties.Settings.Default.PathTemp;
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			List<string> errs = new List<string>();

			string exeName = TxPathWMIT.Text.Trim();
			if (exeName.Length > 0 && !File.Exists(exeName))
				errs.Add("Invalid WMIT.exe path name");
			string dirName = TxPathPIE.Text.Trim();
			if (dirName.Length > 0 && !Directory.Exists(dirName))
				errs.Add("Invalid Pie directory");
			dirName = TxPathTemp.Text.Trim();
			if (dirName.Length > 0 && !Directory.Exists(dirName))
				errs.Add("Invalid temp file directory");

			if (errs.Count > 0)
			{
				MessageBox.Show(this, string.Join("\r\n", errs), "Please review settings");
				this.DialogResult = DialogResult.None;
				return;
			}

			Properties.Settings.Default.PathPies = TxPathPIE.Text;
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
			BrowseFilePath(TxPathWMIT, "Full path to WMIT.exe", "exe|*.exe");
		}

		private void BtnPathPie_Click(object sender, EventArgs e)
		{
			BrowseDir(TxPathPIE, "Directory containing your Pie files");
		}

		private void BtnPathTemp_Click(object sender, EventArgs e)
		{
			BrowseDir(TxPathTemp, "Temporary file directory");
		}
	}
}