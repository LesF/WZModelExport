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
	/// <summary>
	/// Simple one-per-line tag editor, as implemented for 1st simple JSON ser/deserialize tests.
	/// Excluded for now: Notes per PIE file, or define a project and group notes under that?
	/// Data entity is required. Activate via a filepath, get what we need here as text, provide the rest to a 3D renderer?
	/// TODO 
	/// - make it operate on a common PIE entity
	/// - include notes text editor - link to a project entity
	/// - simple text editor for notes, is any other metadata config appropriate here?
	/// - determine all GUI features that may be useful here, current goal is tag names, then notes. Other import/export options to be determined
	/// 
	/// Common disclaimer: This is train-of-thought nonsense, don't use this as a guide.
	/// When I understand the requirements I might start the understand the solution.
	/// </summary>
	public partial class PIETagsEdit : Form
	{
		/* TODO make an entity for a PIE file
		 * Make a collection of these accessible, with an update option
		 */
		private Dictionary<string, PIEMetadata> mPIEMetadata;
		private string mDataKey;

		public PIETagsEdit()
		{
			InitializeComponent();
		}

		public void LoadPIE(string Filename, Dictionary<string, PIEMetadata> DataStore)
		{
			mPIEMetadata = DataStore;
			LbFilename.Text = Filename;
			mDataKey = Filename.ToLower();
			if (mPIEMetadata.ContainsKey(mDataKey))
			{
				TxTags.Text = String.Join("\r\n", mPIEMetadata[mDataKey].Tags);
			}
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			List<string> list = new List<string>();
			string allTags = TxTags.Text.ToLower().Replace("\r", "\n").Replace(",", "\n");
			string[] tags = allTags.Split(new char[] { '\n' });
			foreach (string tag in tags)
			{
				string t = tag.Trim().Replace(" ", "_");
				if (t.Length > 0 && !list.Contains(t))
					list.Add(t);
			}
			list.Sort();
			if (mPIEMetadata.ContainsKey(mDataKey))
				mPIEMetadata[mDataKey].Tags = list.ToArray();
			else
				mPIEMetadata.Add(mDataKey,  new PIEMetadata(){ Tags = list.ToArray(), Notes = "" });

			DialogResult = DialogResult.OK;	
		}
	}
}
