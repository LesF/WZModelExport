namespace ModelExport
{
	partial class SettingsForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.TxPathWMIT = new System.Windows.Forms.TextBox();
			this.BtnPathWMIT = new System.Windows.Forms.Button();
			this.BtnPathPie = new System.Windows.Forms.Button();
			this.TxPathPIE = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.BtnPathTemp = new System.Windows.Forms.Button();
			this.TxPathTemp = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.TxNote = new System.Windows.Forms.TextBox();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.BtnSave = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "WMIT.exe path";
			// 
			// TxPathWMIT
			// 
			this.TxPathWMIT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxPathWMIT.Location = new System.Drawing.Point(99, 12);
			this.TxPathWMIT.Name = "TxPathWMIT";
			this.TxPathWMIT.Size = new System.Drawing.Size(461, 20);
			this.TxPathWMIT.TabIndex = 1;
			// 
			// BtnPathWMIT
			// 
			this.BtnPathWMIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnPathWMIT.Location = new System.Drawing.Point(566, 12);
			this.BtnPathWMIT.Name = "BtnPathWMIT";
			this.BtnPathWMIT.Size = new System.Drawing.Size(52, 20);
			this.BtnPathWMIT.TabIndex = 2;
			this.BtnPathWMIT.Text = "Browse";
			this.BtnPathWMIT.UseVisualStyleBackColor = true;
			this.BtnPathWMIT.Click += new System.EventHandler(this.BtnPathWMIT_Click);
			// 
			// BtnPathPie
			// 
			this.BtnPathPie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnPathPie.Location = new System.Drawing.Point(566, 38);
			this.BtnPathPie.Name = "BtnPathPie";
			this.BtnPathPie.Size = new System.Drawing.Size(52, 20);
			this.BtnPathPie.TabIndex = 5;
			this.BtnPathPie.Text = "Browse";
			this.BtnPathPie.UseVisualStyleBackColor = true;
			this.BtnPathPie.Click += new System.EventHandler(this.BtnPathPie_Click);
			// 
			// TxPathPIE
			// 
			this.TxPathPIE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxPathPIE.Location = new System.Drawing.Point(99, 38);
			this.TxPathPIE.Name = "TxPathPIE";
			this.TxPathPIE.Size = new System.Drawing.Size(461, 20);
			this.TxPathPIE.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "PIE directory";
			// 
			// BtnPathTemp
			// 
			this.BtnPathTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnPathTemp.Location = new System.Drawing.Point(566, 68);
			this.BtnPathTemp.Name = "BtnPathTemp";
			this.BtnPathTemp.Size = new System.Drawing.Size(52, 20);
			this.BtnPathTemp.TabIndex = 8;
			this.BtnPathTemp.Text = "Browse";
			this.BtnPathTemp.UseVisualStyleBackColor = true;
			this.BtnPathTemp.Click += new System.EventHandler(this.BtnPathTemp_Click);
			// 
			// TxPathTemp
			// 
			this.TxPathTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxPathTemp.Location = new System.Drawing.Point(99, 68);
			this.TxPathTemp.Name = "TxPathTemp";
			this.TxPathTemp.Size = new System.Drawing.Size(461, 20);
			this.TxPathTemp.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Temp files path";
			// 
			// TxNote
			// 
			this.TxNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxNote.Location = new System.Drawing.Point(15, 108);
			this.TxNote.Multiline = true;
			this.TxNote.Name = "TxNote";
			this.TxNote.ReadOnly = true;
			this.TxNote.Size = new System.Drawing.Size(603, 57);
			this.TxNote.TabIndex = 9;
			this.TxNote.Text = "If WMIT.exe fails to convert a PIE to an OBJ file, check that you are running the" +
    " latest build of WMIT.\r\n\r\nOBJ viewing depends on your default application for op" +
    "ening .OBJ files.\r\n\r\n";
			// 
			// BtnCancel
			// 
			this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnCancel.Location = new System.Drawing.Point(543, 171);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(75, 23);
			this.BtnCancel.TabIndex = 11;
			this.BtnCancel.Text = "&Cancel";
			this.BtnCancel.UseVisualStyleBackColor = true;
			// 
			// BtnSave
			// 
			this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.BtnSave.Location = new System.Drawing.Point(452, 171);
			this.BtnSave.Name = "BtnSave";
			this.BtnSave.Size = new System.Drawing.Size(75, 23);
			this.BtnSave.TabIndex = 10;
			this.BtnSave.Text = "&Save";
			this.BtnSave.UseVisualStyleBackColor = true;
			this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// SettingsForm
			// 
			this.AcceptButton = this.BtnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.BtnCancel;
			this.ClientSize = new System.Drawing.Size(630, 206);
			this.Controls.Add(this.BtnSave);
			this.Controls.Add(this.BtnCancel);
			this.Controls.Add(this.TxNote);
			this.Controls.Add(this.BtnPathTemp);
			this.Controls.Add(this.TxPathTemp);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.BtnPathPie);
			this.Controls.Add(this.TxPathPIE);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.BtnPathWMIT);
			this.Controls.Add(this.TxPathWMIT);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new System.Drawing.Size(536, 236);
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox TxPathWMIT;
		private System.Windows.Forms.Button BtnPathWMIT;
		private System.Windows.Forms.Button BtnPathPie;
		private System.Windows.Forms.TextBox TxPathPIE;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button BtnPathTemp;
		private System.Windows.Forms.TextBox TxPathTemp;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox TxNote;
		private System.Windows.Forms.Button BtnCancel;
		private System.Windows.Forms.Button BtnSave;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}