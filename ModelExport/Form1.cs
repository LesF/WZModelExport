using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ModelExport
{
	public partial class Form1 : Form
	{
		private string mSavedToOBJ;

		public Form1()
		{
			InitializeComponent();
			if (string.IsNullOrEmpty(Properties.Settings.Default.PathPies)
				|| !Directory.Exists(Properties.Settings.Default.PathPies))
			{
				UpdateSettings();
			}
			else
			{
				ReloadPieDirectory();
			}
		}

		private bool UpdateSettings()
		{
			SettingsForm settingsDialog = new SettingsForm();
			return settingsDialog.ShowDialog(this) == DialogResult.OK;
		}

		private void ToolStripBtnRefresh_Click(object sender, EventArgs e)
		{
			ReloadPieDirectory();
		}

		private void ToolStripBtnSettings_Click(object sender, EventArgs e)
		{
			if (UpdateSettings())
				ReloadPieDirectory();
		}

		private void ReloadPieDirectory()
		{
			LvPieFiles.Items.Clear();

			DirectoryInfo dir = new DirectoryInfo(Properties.Settings.Default.PathPies);
			if (!dir.Exists)
			{
				TxPieContent.Text = $"Pie directory not found, check settings\r\n({Properties.Settings.Default.PathPies})";
				return;
			}

			FileInfo[] files = dir.GetFiles("*.pie", SearchOption.TopDirectoryOnly);
			LvPieFiles.BeginUpdate();
			string row;
			StreamReader rdr;
			string[] metadata;
			string filter = ToolStripTxFilter.Text.Trim();
			foreach (FileInfo pieFile in files)
			{
				rdr = pieFile.OpenText();
				metadata = new string[]{ pieFile.Name, "", "", "" };
				for (int idx = 0; idx < 5; idx++)
				{
					row = rdr.ReadLine();
					string[] elementArr = row.Split(new char[] { ' ' });
					switch (elementArr[0].ToUpper())
					{
						case "PIE":
							if (metadata[3].Length > 0)
								metadata[3] += ",";
							metadata[3] += row;
							break;
						case "TYPE":
							if (metadata[3].Length > 0)
								metadata[3] += ",";
							metadata[3] += row;
							break;
						case "TEXTURE":
							metadata[1] = elementArr[2];
							if (elementArr.Length > 4)
								metadata[2] = string.Format("{0} {1}", elementArr[3], elementArr[4]);
							break;
					}
				}
				rdr.Close();

				bool includeIt = true;
				if (filter.Length > 0)
				{
					includeIt = false;
					for (int i = 0; i < metadata.Length; i++)
						if (metadata[i].IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1)
						{
							includeIt = true;
							break;
						}
				}
				if (includeIt)
				{
					ListViewItem itm = new ListViewItem(metadata);
					itm.Tag = pieFile.FullName;
					LvPieFiles.Items.Add(itm);
				}
			}
			LvPieFiles.EndUpdate();
			if (LvPieFiles.Items.Count > 0)
			{
				// Update users PathPies setting with this path
				Properties.Settings.Default.PathPies = dir.FullName;
				Properties.Settings.Default.Save();
			}
		}

		private void LvPieFiles_ItemActivate(object sender, EventArgs e)
		{
			if (LvPieFiles.SelectedItems.Count < 1) return;

			ListViewItem selection = LvPieFiles.SelectedItems[0];
			string PiePath = (string)selection.Tag;
			if (PiePath.Length > 0 && File.Exists(PiePath))
				OpenWMIT(PiePath);
		}

		private void LvPieFiles_Click(object sender, EventArgs e)
		{
			if (LvPieFiles.SelectedItems.Count < 1) return;

			ListViewItem selection = LvPieFiles.SelectedItems[0];
			string PiePath = (string)selection.Tag;
			if (PiePath.Length > 0 && File.Exists(PiePath))
				LoadPieView(PiePath);
		}

		private void LoadPieView(string piePath)
		{
			FileInfo fileInfo = new FileInfo(piePath);
			if (fileInfo.Exists)
			{
				StreamReader rdr = fileInfo.OpenText();
				string thePie = rdr.ReadToEnd();
				if (thePie.IndexOf("\r") > -1)
					thePie = thePie.Replace("\r\n", "\n");
				string[] lines = thePie.Split(new char[] { '\n' });
				TxPieContent.Text = string.Join("\r\n", lines);
			}
			else
			{
				TxPieContent.Text = $"Not found ({piePath})";
			}
		}

		private void OpenWMIT(string PiePath)
		{
			if (string.IsNullOrEmpty(Properties.Settings.Default.PathWMIT) || !File.Exists(Properties.Settings.Default.PathWMIT))
			{
				MessageBox.Show(this, "Please set the WMIT.exe path in settings", "WMIT.exe path is required");
				return;
			}
			if (!File.Exists(PiePath))
			{
				MessageBox.Show(this, $"Invalid file path:\r\n{PiePath}", "PIE File Not Found");
				return;
			}

			/* TODO  Determine what is needed and what is redundant...
			 * -- Option to open PIE in WMIT for viewing						- depends on config path
			 * -- Option to convert PIE to OBJ and save to specified file		- redundant as save-as option in WMIT is preferred, and doesn't require a temporary file
			 * -- Option to convert PIE to OBJ then open it in preferred app?	- depends on default .obj handler, check what exceptions apply
			 * 
			 * WMIT Usage:
			 *		<no parameters> (opens GUI application)
			 *		--help (shows this message)
			 *		[filename] (opens a file in GUI)
			 *		[input] [output] (converts between formats PIE and OBJ. Deprecated WZM format is supported as input.)
			 *		
			 * Note: WMIT 0.6.10 saved as WZM instead of OBJ, 0.7.0 works as expected.
			 * TODO Find way to specify texture when loading pie in WMIT (why doesn't it find the texture from the pie?)
			 */

			Process WMITProcess = new Process();
			try
			{
				WMITProcess.StartInfo.UseShellExecute = false;
				WMITProcess.StartInfo.FileName = Properties.Settings.Default.PathWMIT;
				WMITProcess.StartInfo.Arguments = PiePath;
				WMITProcess.EnableRaisingEvents = true;
				//WMITProcess.Exited += ArchiveProcess_Exited;
				WMITProcess.Start();
				//WMITProcess.WaitForExit(300000);
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
			string PiePath = (string)selection.Tag;
			if (PiePath.Length < 1 || !File.Exists(PiePath))
				return;

			string action = e.ClickedItem.Name;
			switch (action)
			{
				case "MenuItemViewInWMIT":
					OpenWMIT(PiePath);
					break;

				case "MenuItemViewAsOBJ":
					SaveToOBJ(PiePath, true);
					break;

				case "MenuItemSaveToOBJ":
					SaveToOBJ(PiePath, false);
					break;

				default:
					break;
			}
		}

		/*
		private void SaveToOBJ(string PiePath, bool ViewAfter)
		{
			FileInfo fileInfo = new FileInfo(PiePath);
			if (string.IsNullOrEmpty(PiePath) || !fileInfo.Exists)
				return;     // TODO tell the user
			string PieName = fileInfo.Name;
			if (!PieName.EndsWith(".pie", StringComparison.OrdinalIgnoreCase))
				return;
			if (string.IsNullOrEmpty(Properties.Settings.Default.PathTemp) || !Directory.Exists(Properties.Settings.Default.PathTemp))
				return;     // TODO tell the user

			mSavedToOBJ = Path.Combine(Properties.Settings.Default.PathTemp,
				PieName.Substring(0, PieName.Length - 3) + "obj");
			// TODO append suffix to find a unique name?			
			if (File.Exists(mSavedToOBJ))
				File.Delete(mSavedToOBJ);

			Process WMITProcess = new Process();
			try
			{
				// Do we need to be in that directory? Probably not.
				Directory.SetCurrentDirectory(Properties.Settings.Default.PathTemp);

				WMITProcess.StartInfo.UseShellExecute = false;
				WMITProcess.StartInfo.FileName = Properties.Settings.Default.PathWMIT;
				WMITProcess.StartInfo.Arguments = $"\"{PiePath}\" \"{mSavedToOBJ}\"";
				WMITProcess.EnableRaisingEvents = true;
				if (ViewAfter)
					WMITProcess.Exited += ExportProcess_Exited;
				WMITProcess.Start();
				if (ViewAfter)
					WMITProcess.WaitForExit(5000);
			}
			catch (Exception exc)
			{
				MessageBox.Show(this, $"Process creation failed\r\n{exc.Message}", "WMIT Call Failed");
			}
		}

		private void ExportProcess_Exited(object sender, System.EventArgs e)
		{
			if (sender is Process process)
			{
				int exitCode = process.ExitCode;
				// TODO take action based on exit code?  Assume 0 = No error 
				ViewOBJ(mSavedToOBJ);
			}
		}
		*/

		/// <summary>
		/// Use default handler for .obj files to open in preferred app
		/// </summary>
		/// <param name="OBJPath">Full path to .obj file</param>
		private void ViewOBJ(string OBJPath)
		{
			FileInfo fileInfo = new FileInfo(OBJPath);
			if (!fileInfo.Exists)
			{
				MessageBox.Show(this, $"Invalid file path:\r\n{OBJPath}", "OBJ File Not Found");
				return;
			}

			/* TODO assess exceptions and preventions if user has no default .obj handler
			 * 
			 */

			Process OBJViewer = new Process();
			try
			{
				Directory.SetCurrentDirectory(fileInfo.DirectoryName);

				OBJViewer.StartInfo.UseShellExecute = true;
				OBJViewer.StartInfo.FileName = OBJPath;
				//OBJViewer.EnableRaisingEvents = true;
				OBJViewer.Start();
			}
			catch (Exception exc)
			{
				MessageBox.Show(this, $"Process creation failed\r\n{exc.Message}", "OBJ View Failed");
			}
		}
	}
}
