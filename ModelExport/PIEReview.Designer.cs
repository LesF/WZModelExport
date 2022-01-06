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
			this.contextMenuStripLV = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.MenuItemViewInWMIT = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemViewAsOBJ = new System.Windows.Forms.ToolStripMenuItem();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.panel2 = new System.Windows.Forms.Panel();
			this.TxPieContent = new System.Windows.Forms.TextBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.ToolStripTxFilter = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripBtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.ToolStripBtnSettings = new System.Windows.Forms.ToolStripButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ToolStripTagFilter = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.columnHeadTags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.MenuItemEditTags = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.contextMenuStripLV.SuspendLayout();
			this.panel2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
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
			this.LvPieFiles.Location = new System.Drawing.Point(0, 27);
			this.LvPieFiles.Name = "LvPieFiles";
			this.LvPieFiles.Size = new System.Drawing.Size(728, 471);
			this.LvPieFiles.TabIndex = 0;
			this.LvPieFiles.UseCompatibleStateImageBehavior = false;
			this.LvPieFiles.View = System.Windows.Forms.View.Details;
			this.LvPieFiles.ItemActivate += new System.EventHandler(this.LvPieFiles_ItemActivate);
			this.LvPieFiles.Click += new System.EventHandler(this.LvPieFiles_Click);
			// 
			// columnHeadName
			// 
			this.columnHeadName.Text = "Name";
			this.columnHeadName.Width = 160;
			// 
			// columnHeaderTexture
			// 
			this.columnHeaderTexture.Text = "Texture";
			this.columnHeaderTexture.Width = 250;
			// 
			// columnHeadSize
			// 
			this.columnHeadSize.Text = "Size";
			this.columnHeadSize.Width = 100;
			// 
			// columnHeadType
			// 
			this.columnHeadType.Text = "Type";
			this.columnHeadType.Width = 120;
			// 
			// contextMenuStripLV
			// 
			this.contextMenuStripLV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemViewInWMIT,
            this.MenuItemViewAsOBJ,
            this.toolStripSeparator2,
            this.MenuItemEditTags});
			this.contextMenuStripLV.Name = "contextMenuStripLV";
			this.contextMenuStripLV.Size = new System.Drawing.Size(181, 98);
			this.contextMenuStripLV.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripLV_ItemClicked);
			// 
			// MenuItemViewInWMIT
			// 
			this.MenuItemViewInWMIT.Name = "MenuItemViewInWMIT";
			this.MenuItemViewInWMIT.Size = new System.Drawing.Size(180, 22);
			this.MenuItemViewInWMIT.Text = "View in WMIT";
			// 
			// MenuItemViewAsOBJ
			// 
			this.MenuItemViewAsOBJ.Name = "MenuItemViewAsOBJ";
			this.MenuItemViewAsOBJ.Size = new System.Drawing.Size(180, 22);
			this.MenuItemViewAsOBJ.Text = "View as OBJ";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.PowderBlue;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.TxPieContent);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 498);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(728, 174);
			this.panel2.TabIndex = 3;
			// 
			// TxPieContent
			// 
			this.TxPieContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TxPieContent.Location = new System.Drawing.Point(0, 0);
			this.TxPieContent.Multiline = true;
			this.TxPieContent.Name = "TxPieContent";
			this.TxPieContent.ReadOnly = true;
			this.TxPieContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TxPieContent.Size = new System.Drawing.Size(726, 172);
			this.TxPieContent.TabIndex = 0;
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
            this.ToolStripBtnSettings});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(726, 25);
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
			this.panel1.Size = new System.Drawing.Size(728, 27);
			this.panel1.TabIndex = 2;
			// 
			// ToolStripTagFilter
			// 
			this.ToolStripTagFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ToolStripTagFilter.Name = "ToolStripTagFilter";
			this.ToolStripTagFilter.Size = new System.Drawing.Size(121, 25);
			this.ToolStripTagFilter.ToolTipText = "Add tags to PIE files for custom grouping";
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(28, 22);
			this.toolStripLabel2.Text = "Tag:";
			// 
			// columnHeadTags
			// 
			this.columnHeadTags.Text = "Tags";
			this.columnHeadTags.Width = 120;
			// 
			// MenuItemEditTags
			// 
			this.MenuItemEditTags.Name = "MenuItemEditTags";
			this.MenuItemEditTags.Size = new System.Drawing.Size(180, 22);
			this.MenuItemEditTags.Text = "Edit tags";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
			// 
			// PIEReview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(728, 672);
			this.Controls.Add(this.LvPieFiles);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "PIEReview";
			this.Text = "Model Details";
			this.contextMenuStripLV.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView LvPieFiles;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.ColumnHeader columnHeadName;
		private System.Windows.Forms.ColumnHeader columnHeadType;
		private System.Windows.Forms.ColumnHeader columnHeaderTexture;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ColumnHeader columnHeadSize;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripLV;
		private System.Windows.Forms.ToolStripMenuItem MenuItemViewInWMIT;
		private System.Windows.Forms.ToolStripMenuItem MenuItemViewAsOBJ;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox ToolStripTxFilter;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton ToolStripBtnRefresh;
		private System.Windows.Forms.ToolStripButton ToolStripBtnSettings;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox TxPieContent;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripComboBox ToolStripTagFilter;
		private System.Windows.Forms.ColumnHeader columnHeadTags;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem MenuItemEditTags;
	}
}

