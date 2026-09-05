namespace ModelExport.Controls
{
	partial class PieViewportControl
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnResetView = new System.Windows.Forms.ToolStripButton();
			this.btnWireframe = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.lblLevel = new System.Windows.Forms.ToolStripLabel();
			this.cmbLevel = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.lblTexture = new System.Windows.Forms.ToolStripLabel();
			this.btnChangeTexture = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnExportGltf = new System.Windows.Forms.ToolStripButton();
			this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
			this.openFileDialogTexture = new System.Windows.Forms.OpenFileDialog();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnResetView,
            this.btnWireframe,
            this.toolStripSeparator1,
            this.lblLevel,
            this.cmbLevel,
            this.toolStripSeparator2,
            this.lblTexture,
            this.btnChangeTexture,
            this.toolStripSeparator3,
            this.btnExportGltf});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(700, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnResetView
			// 
			this.btnResetView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnResetView.Name = "btnResetView";
			this.btnResetView.Size = new System.Drawing.Size(65, 22);
			this.btnResetView.Text = "Reset View";
			this.btnResetView.ToolTipText = "Reset camera position and zoom to fit";
			this.btnResetView.Click += new System.EventHandler(this.BtnResetView_Click);
			// 
			// btnWireframe
			// 
			this.btnWireframe.CheckOnClick = true;
			this.btnWireframe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnWireframe.Name = "btnWireframe";
			this.btnWireframe.Size = new System.Drawing.Size(66, 22);
			this.btnWireframe.Text = "Wireframe";
			this.btnWireframe.ToolTipText = "Toggle wireframe display";
			this.btnWireframe.Click += new System.EventHandler(this.BtnWireframe_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// lblLevel
			// 
			this.lblLevel.Name = "lblLevel";
			this.lblLevel.Size = new System.Drawing.Size(37, 22);
			this.lblLevel.Text = "Level:";
			// 
			// cmbLevel
			// 
			this.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLevel.Name = "cmbLevel";
			this.cmbLevel.Size = new System.Drawing.Size(80, 25);
			this.cmbLevel.SelectedIndexChanged += new System.EventHandler(this.CmbLevel_SelectedIndexChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// lblTexture
			// 
			this.lblTexture.Name = "lblTexture";
			this.lblTexture.Size = new System.Drawing.Size(89, 22);
			this.lblTexture.Text = "Texture: (None)";
			// 
			// btnChangeTexture
			// 
			this.btnChangeTexture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnChangeTexture.Name = "btnChangeTexture";
			this.btnChangeTexture.Size = new System.Drawing.Size(103, 22);
			this.btnChangeTexture.Text = "Change Texture...";
			this.btnChangeTexture.ToolTipText = "Select an alternate texture file to map onto this model";
			this.btnChangeTexture.Click += new System.EventHandler(this.BtnChangeTexture_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// btnExportGltf
			// 
			this.btnExportGltf.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnExportGltf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnExportGltf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.btnExportGltf.ForeColor = System.Drawing.Color.DarkBlue;
			this.btnExportGltf.Name = "btnExportGltf";
			this.btnExportGltf.Size = new System.Drawing.Size(130, 22);
			this.btnExportGltf.Text = "Export to glTF/GLB...";
			this.btnExportGltf.ToolTipText = "View transformation roadmap and export specifications";
			this.btnExportGltf.Click += new System.EventHandler(this.BtnExportGltf_Click);
			// 
			// elementHost1
			// 
			this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.elementHost1.Location = new System.Drawing.Point(0, 25);
			this.elementHost1.Name = "elementHost1";
			this.elementHost1.Size = new System.Drawing.Size(700, 425);
			this.elementHost1.TabIndex = 1;
			this.elementHost1.Text = "elementHost1";
			this.elementHost1.Child = null;
			// 
			// openFileDialogTexture
			// 
			this.openFileDialogTexture.Filter = "PNG Image (*.png)|*.png|All Image Files (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp|All Files (*.*)|*.*";
			this.openFileDialogTexture.Title = "Select Model Texture Image";
			// 
			// PieViewportControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.elementHost1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "PieViewportControl";
			this.Size = new System.Drawing.Size(700, 450);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnResetView;
		private System.Windows.Forms.ToolStripButton btnWireframe;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel lblLevel;
		private System.Windows.Forms.ToolStripComboBox cmbLevel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel lblTexture;
		private System.Windows.Forms.ToolStripButton btnChangeTexture;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton btnExportGltf;
		private System.Windows.Forms.Integration.ElementHost elementHost1;
		private System.Windows.Forms.OpenFileDialog openFileDialogTexture;
	}
}
