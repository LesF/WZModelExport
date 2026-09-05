namespace ModelExport
{
	partial class PIEReview
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PIEReview));
			this.LvPieFiles = new System.Windows.Forms.ListView();
			this.columnHeadName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderTexture = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeadSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeadType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeadTags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.contextMenuStripLV = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.MenuItemViewInWMIT = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemViewAsOBJ = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemExportGltf = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuItemEditTags = new System.Windows.Forms.ToolStripMenuItem();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.ToolStripTxFilter = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.ToolStripTagFilter = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripBtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.ToolStripBtnExportGltf = new System.Windows.Forms.ToolStripButton();
			this.ToolStripBtnSettings = new System.Windows.Forms.ToolStripButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.splitContainerRight = new System.Windows.Forms.SplitContainer();
			this.pieViewportControl1 = new ModelExport.Controls.PieViewportControl();
			this.tabControlDetails = new System.Windows.Forms.TabControl();
			this.tabModelInfo = new System.Windows.Forms.TabPage();
			this.txModelInfo = new System.Windows.Forms.TextBox();
			this.tabPieContent = new System.Windows.Forms.TabPage();
			this.TxPieContent = new System.Windows.Forms.TextBox();
			this.contextMenuStripLV.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.Panel2.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
			this.splitContainerRight.Panel1.SuspendLayout();
			this.splitContainerRight.Panel2.SuspendLayout();
			this.splitContainerRight.SuspendLayout();
			this.tabControlDetails.SuspendLayout();
			this.tabModelInfo.SuspendLayout();
			this.tabPieContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// LvPieFiles
			// 
			this.LvPieFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeadName,
            this.columnHeaderTexture,
            this.columnHeadSize,
            this.columnHeadType,
            this.columnHeadTags});
			this.LvPieFiles.ContextMenuStrip = this.contextMenuStripLV;
			this.LvPieFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LvPieFiles.FullRowSelect = true;
			this.LvPieFiles.GridLines = true;
			this.LvPieFiles.HideSelection = false;
			this.LvPieFiles.Location = new System.Drawing.Point(0, 0);
			this.LvPieFiles.Name = "LvPieFiles";
			this.LvPieFiles.Size = new System.Drawing.Size(430, 673);
			this.LvPieFiles.TabIndex = 0;
			this.LvPieFiles.UseCompatibleStateImageBehavior = false;
			this.LvPieFiles.View = System.Windows.Forms.View.Details;
			this.LvPieFiles.ItemActivate += new System.EventHandler(this.LvPieFiles_ItemActivate);
			this.LvPieFiles.SelectedIndexChanged += new System.EventHandler(this.LvPieFiles_SelectedIndexChanged);
			this.LvPieFiles.Click += new System.EventHandler(this.LvPieFiles_Click);
			// 
			// columnHeadName
			// 
			this.columnHeadName.Text = "Name";
			this.columnHeadName.Width = 140;
			// 
			// columnHeaderTexture
			// 
			this.columnHeaderTexture.Text = "Texture";
			this.columnHeaderTexture.Width = 160;
			// 
			// columnHeadSize
			// 
			this.columnHeadSize.Text = "Size";
			this.columnHeadSize.Width = 60;
			// 
			// columnHeadType
			// 
			this.columnHeadType.Text = "Type";
			this.columnHeadType.Width = 70;
			// 
			// columnHeadTags
			// 
			this.columnHeadTags.Text = "Tags";
			this.columnHeadTags.Width = 100;
			// 
			// contextMenuStripLV
			// 
			this.contextMenuStripLV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemViewInWMIT,
            this.MenuItemViewAsOBJ,
            this.MenuItemExportGltf,
            this.toolStripSeparator2,
            this.MenuItemEditTags});
			this.contextMenuStripLV.Name = "contextMenuStripLV";
			this.contextMenuStripLV.Size = new System.Drawing.Size(188, 98);
			this.contextMenuStripLV.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripLV_ItemClicked);
			// 
			// MenuItemViewInWMIT
			// 
			this.MenuItemViewInWMIT.Name = "MenuItemViewInWMIT";
			this.MenuItemViewInWMIT.Size = new System.Drawing.Size(187, 22);
			this.MenuItemViewInWMIT.Text = "View in WMIT";
			// 
			// MenuItemViewAsOBJ
			// 
			this.MenuItemViewAsOBJ.Name = "MenuItemViewAsOBJ";
			this.MenuItemViewAsOBJ.Size = new System.Drawing.Size(187, 22);
			this.MenuItemViewAsOBJ.Text = "View as OBJ";
			// 
			// MenuItemExportGltf
			// 
			this.MenuItemExportGltf.Name = "MenuItemExportGltf";
			this.MenuItemExportGltf.Size = new System.Drawing.Size(187, 22);
			this.MenuItemExportGltf.Text = "Export to glTF/GLB...";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
			// 
			// MenuItemEditTags
			// 
			this.MenuItemEditTags.Name = "MenuItemEditTags";
			this.MenuItemEditTags.Size = new System.Drawing.Size(187, 22);
			this.MenuItemEditTags.Text = "Edit tags";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ToolStripTxFilter,
            this.toolStripLabel2,
            this.ToolStripTagFilter,
            this.toolStripSeparator1,
            this.ToolStripBtnRefresh,
            this.ToolStripBtnExportGltf,
            this.ToolStripBtnSettings});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(1082, 25);
			this.toolStrip1.TabIndex = 4;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(52, 22);
			this.toolStripLabel1.Text = "Filter by:";
			// 
			// ToolStripTxFilter
			// 
			this.ToolStripTxFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.ToolStripTxFilter.Name = "ToolStripTxFilter";
			this.ToolStripTxFilter.Size = new System.Drawing.Size(120, 25);
			this.ToolStripTxFilter.TextChanged += new System.EventHandler(this.ToolStripTxFilter_TextChanged);
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(28, 22);
			this.toolStripLabel2.Text = "Tag:";
			// 
			// ToolStripTagFilter
			// 
			this.ToolStripTagFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ToolStripTagFilter.Name = "ToolStripTagFilter";
			this.ToolStripTagFilter.Size = new System.Drawing.Size(121, 25);
			this.ToolStripTagFilter.ToolTipText = "Add tags to PIE files for custom grouping";
			this.ToolStripTagFilter.SelectedIndexChanged += new System.EventHandler(this.ToolStripTagFilter_SelectedIndexChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// ToolStripBtnRefresh
			// 
			this.ToolStripBtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ToolStripBtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnRefresh.Image")));
			this.ToolStripBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolStripBtnRefresh.Name = "ToolStripBtnRefresh";
			this.ToolStripBtnRefresh.Size = new System.Drawing.Size(71, 22);
			this.ToolStripBtnRefresh.Text = "Refresh List";
			this.ToolStripBtnRefresh.Click += new System.EventHandler(this.ToolStripBtnRefresh_Click);
			// 
			// ToolStripBtnExportGltf
			// 
			this.ToolStripBtnExportGltf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ToolStripBtnExportGltf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.ToolStripBtnExportGltf.ForeColor = System.Drawing.Color.DarkBlue;
			this.ToolStripBtnExportGltf.Name = "ToolStripBtnExportGltf";
			this.ToolStripBtnExportGltf.Size = new System.Drawing.Size(126, 22);
			this.ToolStripBtnExportGltf.Text = "Export to glTF/GLB...";
			this.ToolStripBtnExportGltf.Click += new System.EventHandler(this.ToolStripBtnExportGltf_Click);
			// 
			// ToolStripBtnSettings
			// 
			this.ToolStripBtnSettings.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.ToolStripBtnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ToolStripBtnSettings.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnSettings.Image")));
			this.ToolStripBtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolStripBtnSettings.Name = "ToolStripBtnSettings";
			this.ToolStripBtnSettings.Size = new System.Drawing.Size(53, 22);
			this.ToolStripBtnSettings.Text = "Settings";
			this.ToolStripBtnSettings.ToolTipText = "Application settings";
			this.ToolStripBtnSettings.Click += new System.EventHandler(this.ToolStripBtnSettings_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.PowderBlue;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.toolStrip1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1084, 27);
			this.panel1.TabIndex = 2;
			// 
			// splitContainerMain
			// 
			this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainerMain.Location = new System.Drawing.Point(0, 27);
			this.splitContainerMain.Name = "splitContainerMain";
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.LvPieFiles);
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.Controls.Add(this.splitContainerRight);
			this.splitContainerMain.Size = new System.Drawing.Size(1084, 673);
			this.splitContainerMain.SplitterDistance = 430;
			this.splitContainerMain.TabIndex = 3;
			// 
			// splitContainerRight
			// 
			this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerRight.Location = new System.Drawing.Point(0, 0);
			this.splitContainerRight.Name = "splitContainerRight";
			this.splitContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerRight.Panel1
			// 
			this.splitContainerRight.Panel1.Controls.Add(this.pieViewportControl1);
			// 
			// splitContainerRight.Panel2
			// 
			this.splitContainerRight.Panel2.Controls.Add(this.tabControlDetails);
			this.splitContainerRight.Size = new System.Drawing.Size(650, 673);
			this.splitContainerRight.SplitterDistance = 450;
			this.splitContainerRight.TabIndex = 0;
			// 
			// pieViewportControl1
			// 
			this.pieViewportControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pieViewportControl1.Location = new System.Drawing.Point(0, 0);
			this.pieViewportControl1.Name = "pieViewportControl1";
			this.pieViewportControl1.Size = new System.Drawing.Size(650, 450);
			this.pieViewportControl1.TabIndex = 0;
			// 
			// tabControlDetails
			// 
			this.tabControlDetails.Controls.Add(this.tabModelInfo);
			this.tabControlDetails.Controls.Add(this.tabPieContent);
			this.tabControlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlDetails.Location = new System.Drawing.Point(0, 0);
			this.tabControlDetails.Name = "tabControlDetails";
			this.tabControlDetails.SelectedIndex = 0;
			this.tabControlDetails.Size = new System.Drawing.Size(650, 219);
			this.tabControlDetails.TabIndex = 0;
			// 
			// tabModelInfo
			// 
			this.tabModelInfo.Controls.Add(this.txModelInfo);
			this.tabModelInfo.Location = new System.Drawing.Point(4, 22);
			this.tabModelInfo.Name = "tabModelInfo";
			this.tabModelInfo.Padding = new System.Windows.Forms.Padding(3);
			this.tabModelInfo.Size = new System.Drawing.Size(642, 193);
			this.tabModelInfo.TabIndex = 0;
			this.tabModelInfo.Text = "Model & Texture Info";
			this.tabModelInfo.UseVisualStyleBackColor = true;
			// 
			// txModelInfo
			// 
			this.txModelInfo.BackColor = System.Drawing.Color.White;
			this.txModelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txModelInfo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txModelInfo.Location = new System.Drawing.Point(3, 3);
			this.txModelInfo.Multiline = true;
			this.txModelInfo.Name = "txModelInfo";
			this.txModelInfo.ReadOnly = true;
			this.txModelInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txModelInfo.Size = new System.Drawing.Size(636, 187);
			this.txModelInfo.TabIndex = 0;
			// 
			// tabPieContent
			// 
			this.tabPieContent.Controls.Add(this.TxPieContent);
			this.tabPieContent.Location = new System.Drawing.Point(4, 22);
			this.tabPieContent.Name = "tabPieContent";
			this.tabPieContent.Padding = new System.Windows.Forms.Padding(3);
			this.tabPieContent.Size = new System.Drawing.Size(642, 193);
			this.tabPieContent.TabIndex = 1;
			this.tabPieContent.Text = "Raw PIE Content";
			this.tabPieContent.UseVisualStyleBackColor = true;
			// 
			// TxPieContent
			// 
			this.TxPieContent.BackColor = System.Drawing.Color.White;
			this.TxPieContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TxPieContent.Font = new System.Drawing.Font("Consolas", 8.25F);
			this.TxPieContent.Location = new System.Drawing.Point(3, 3);
			this.TxPieContent.Multiline = true;
			this.TxPieContent.Name = "TxPieContent";
			this.TxPieContent.ReadOnly = true;
			this.TxPieContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TxPieContent.Size = new System.Drawing.Size(636, 187);
			this.TxPieContent.TabIndex = 0;
			// 
			// PIEReview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1084, 700);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.panel1);
			this.MinimumSize = new System.Drawing.Size(800, 500);
			this.Name = "PIEReview";
			this.Text = "Warzone 2100 Model Browser & 3D Viewer";
			this.contextMenuStripLV.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.splitContainerMain.Panel1.ResumeLayout(false);
			this.splitContainerMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
			this.splitContainerMain.ResumeLayout(false);
			this.splitContainerRight.Panel1.ResumeLayout(false);
			this.splitContainerRight.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
			this.splitContainerRight.ResumeLayout(false);
			this.tabControlDetails.ResumeLayout(false);
			this.tabModelInfo.ResumeLayout(false);
			this.tabModelInfo.PerformLayout();
			this.tabPieContent.ResumeLayout(false);
			this.tabPieContent.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView LvPieFiles;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.ColumnHeader columnHeadName;
		private System.Windows.Forms.ColumnHeader columnHeadType;
		private System.Windows.Forms.ColumnHeader columnHeaderTexture;
		private System.Windows.Forms.ColumnHeader columnHeadSize;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripLV;
		private System.Windows.Forms.ToolStripMenuItem MenuItemViewInWMIT;
		private System.Windows.Forms.ToolStripMenuItem MenuItemViewAsOBJ;
		private System.Windows.Forms.ToolStripMenuItem MenuItemExportGltf;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox ToolStripTxFilter;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton ToolStripBtnRefresh;
		private System.Windows.Forms.ToolStripButton ToolStripBtnSettings;
		private System.Windows.Forms.ToolStripButton ToolStripBtnExportGltf;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox TxPieContent;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripComboBox ToolStripTagFilter;
		private System.Windows.Forms.ColumnHeader columnHeadTags;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem MenuItemEditTags;
		private System.Windows.Forms.SplitContainer splitContainerMain;
		private System.Windows.Forms.SplitContainer splitContainerRight;
		private ModelExport.Controls.PieViewportControl pieViewportControl1;
		private System.Windows.Forms.TabControl tabControlDetails;
		private System.Windows.Forms.TabPage tabModelInfo;
		private System.Windows.Forms.TabPage tabPieContent;
		private System.Windows.Forms.TextBox txModelInfo;
	}
}
