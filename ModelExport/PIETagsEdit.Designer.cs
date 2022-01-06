namespace ModelExport
{
	partial class PIETagsEdit
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.PnlHead = new System.Windows.Forms.Panel();
			this.LbPIETagsTitle = new System.Windows.Forms.Label();
			this.LbFilename = new System.Windows.Forms.Label();
			this.PnlFoot = new System.Windows.Forms.Panel();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.BtnSave = new System.Windows.Forms.Button();
			this.TxTags = new System.Windows.Forms.TextBox();
			this.PnlHead.SuspendLayout();
			this.PnlFoot.SuspendLayout();
			this.SuspendLayout();
			// 
			// PnlHead
			// 
			this.PnlHead.Controls.Add(this.LbPIETagsTitle);
			this.PnlHead.Controls.Add(this.LbFilename);
			this.PnlHead.Dock = System.Windows.Forms.DockStyle.Top;
			this.PnlHead.Location = new System.Drawing.Point(0, 0);
			this.PnlHead.Name = "PnlHead";
			this.PnlHead.Size = new System.Drawing.Size(240, 49);
			this.PnlHead.TabIndex = 0;
			// 
			// LbPIETagsTitle
			// 
			this.LbPIETagsTitle.AutoSize = true;
			this.LbPIETagsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LbPIETagsTitle.Location = new System.Drawing.Point(12, 31);
			this.LbPIETagsTitle.Name = "LbPIETagsTitle";
			this.LbPIETagsTitle.Size = new System.Drawing.Size(35, 13);
			this.LbPIETagsTitle.TabIndex = 2;
			this.LbPIETagsTitle.Text = "Tags";
			// 
			// LbFilename
			// 
			this.LbFilename.AutoSize = true;
			this.LbFilename.Location = new System.Drawing.Point(12, 9);
			this.LbFilename.Name = "LbFilename";
			this.LbFilename.Size = new System.Drawing.Size(72, 13);
			this.LbFilename.TabIndex = 0;
			this.LbFilename.Text = "(PIE filename)";
			// 
			// PnlFoot
			// 
			this.PnlFoot.Controls.Add(this.BtnCancel);
			this.PnlFoot.Controls.Add(this.BtnSave);
			this.PnlFoot.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.PnlFoot.Location = new System.Drawing.Point(0, 214);
			this.PnlFoot.Name = "PnlFoot";
			this.PnlFoot.Size = new System.Drawing.Size(240, 36);
			this.PnlFoot.TabIndex = 1;
			// 
			// BtnCancel
			// 
			this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnCancel.Location = new System.Drawing.Point(167, 6);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(61, 23);
			this.BtnCancel.TabIndex = 1;
			this.BtnCancel.Text = "Cancel";
			this.BtnCancel.UseVisualStyleBackColor = true;
			// 
			// BtnSave
			// 
			this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnSave.Location = new System.Drawing.Point(93, 6);
			this.BtnSave.Name = "BtnSave";
			this.BtnSave.Size = new System.Drawing.Size(55, 23);
			this.BtnSave.TabIndex = 0;
			this.BtnSave.Text = "Save";
			this.BtnSave.UseVisualStyleBackColor = true;
			this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// TxTags
			// 
			this.TxTags.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.TxTags.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TxTags.Location = new System.Drawing.Point(0, 49);
			this.TxTags.Multiline = true;
			this.TxTags.Name = "TxTags";
			this.TxTags.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TxTags.Size = new System.Drawing.Size(240, 165);
			this.TxTags.TabIndex = 2;
			// 
			// PIETagsEdit
			// 
			this.AcceptButton = this.BtnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.BtnCancel;
			this.ClientSize = new System.Drawing.Size(240, 250);
			this.ControlBox = false;
			this.Controls.Add(this.TxTags);
			this.Controls.Add(this.PnlFoot);
			this.Controls.Add(this.PnlHead);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.HelpButton = true;
			this.MinimumSize = new System.Drawing.Size(210, 200);
			this.Name = "PIETagsEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit PIE Tags";
			this.PnlHead.ResumeLayout(false);
			this.PnlHead.PerformLayout();
			this.PnlFoot.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel PnlHead;
		private System.Windows.Forms.Panel PnlFoot;
		private System.Windows.Forms.TextBox TxTags;
		private System.Windows.Forms.Label LbPIETagsTitle;
		private System.Windows.Forms.Label LbFilename;
		private System.Windows.Forms.Button BtnCancel;
		private System.Windows.Forms.Button BtnSave;
	}
}