namespace ModelExport.Export
{
	partial class GltfExportDialog
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
			this.panelHeader = new System.Windows.Forms.Panel();
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblSubtitle = new System.Windows.Forms.Label();
			this.grpSource = new System.Windows.Forms.GroupBox();
			this.lblModelNameVal = new System.Windows.Forms.Label();
			this.lblModelName = new System.Windows.Forms.Label();
			this.lblVersionVal = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.lblMeshStatsVal = new System.Windows.Forms.Label();
			this.lblMeshStats = new System.Windows.Forms.Label();
			this.grpTexture = new System.Windows.Forms.GroupBox();
			this.lblTextureNameVal = new System.Windows.Forms.Label();
			this.lblTextureName = new System.Windows.Forms.Label();
			this.lblTextureDimVal = new System.Windows.Forms.Label();
			this.lblTextureDim = new System.Windows.Forms.Label();
			this.lblTexturePathVal = new System.Windows.Forms.Label();
			this.lblTexturePath = new System.Windows.Forms.Label();
			this.grpTarget = new System.Windows.Forms.GroupBox();
			this.txtPipeline = new System.Windows.Forms.TextBox();
			this.panelTodo = new System.Windows.Forms.Panel();
			this.lblTodoHeader = new System.Windows.Forms.Label();
			this.lblTodoText = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnCopy = new System.Windows.Forms.Button();
			this.panelHeader.SuspendLayout();
			this.grpSource.SuspendLayout();
			this.grpTexture.SuspendLayout();
			this.grpTarget.SuspendLayout();
			this.panelTodo.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelHeader
			// 
			this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
			this.panelHeader.Controls.Add(this.lblSubtitle);
			this.panelHeader.Controls.Add(this.lblTitle);
			this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelHeader.Location = new System.Drawing.Point(0, 0);
			this.panelHeader.Name = "panelHeader";
			this.panelHeader.Size = new System.Drawing.Size(620, 64);
			this.panelHeader.TabIndex = 0;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(14, 12);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(262, 21);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Export to glTF 2.0 / GLB Roadmap";
			// 
			// lblSubtitle
			// 
			this.lblSubtitle.AutoSize = true;
			this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
			this.lblSubtitle.ForeColor = System.Drawing.Color.LightGray;
			this.lblSubtitle.Location = new System.Drawing.Point(15, 36);
			this.lblSubtitle.Name = "lblSubtitle";
			this.lblSubtitle.Size = new System.Drawing.Size(437, 15);
			this.lblSubtitle.TabIndex = 1;
			this.lblSubtitle.Text = "Warzone 2100 PIE + PNG Texture to modern 3D format transformation specification";
			// 
			// grpSource
			// 
			this.grpSource.Controls.Add(this.lblMeshStatsVal);
			this.grpSource.Controls.Add(this.lblMeshStats);
			this.grpSource.Controls.Add(this.lblVersionVal);
			this.grpSource.Controls.Add(this.lblVersion);
			this.grpSource.Controls.Add(this.lblModelNameVal);
			this.grpSource.Controls.Add(this.lblModelName);
			this.grpSource.Location = new System.Drawing.Point(18, 76);
			this.grpSource.Name = "grpSource";
			this.grpSource.Size = new System.Drawing.Size(584, 88);
			this.grpSource.TabIndex = 1;
			this.grpSource.TabStop = false;
			this.grpSource.Text = "Source Model";
			// 
			// lblModelName
			// 
			this.lblModelName.AutoSize = true;
			this.lblModelName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblModelName.Location = new System.Drawing.Point(16, 22);
			this.lblModelName.Name = "lblModelName";
			this.lblModelName.Size = new System.Drawing.Size(41, 13);
			this.lblModelName.TabIndex = 0;
			this.lblModelName.Text = "Model:";
			// 
			// lblModelNameVal
			// 
			this.lblModelNameVal.AutoSize = true;
			this.lblModelNameVal.Location = new System.Drawing.Point(90, 22);
			this.lblModelNameVal.Name = "lblModelNameVal";
			this.lblModelNameVal.Size = new System.Drawing.Size(10, 13);
			this.lblModelNameVal.TabIndex = 1;
			this.lblModelNameVal.Text = "-";
			// 
			// lblVersion
			// 
			this.lblVersion.AutoSize = true;
			this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblVersion.Location = new System.Drawing.Point(16, 42);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(48, 13);
			this.lblVersion.TabIndex = 2;
			this.lblVersion.Text = "Version:";
			// 
			// lblVersionVal
			// 
			this.lblVersionVal.AutoSize = true;
			this.lblVersionVal.Location = new System.Drawing.Point(90, 42);
			this.lblVersionVal.Name = "lblVersionVal";
			this.lblVersionVal.Size = new System.Drawing.Size(10, 13);
			this.lblVersionVal.TabIndex = 3;
			this.lblVersionVal.Text = "-";
			// 
			// lblMeshStats
			// 
			this.lblMeshStats.AutoSize = true;
			this.lblMeshStats.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblMeshStats.Location = new System.Drawing.Point(16, 62);
			this.lblMeshStats.Name = "lblMeshStats";
			this.lblMeshStats.Size = new System.Drawing.Size(65, 13);
			this.lblMeshStats.TabIndex = 4;
			this.lblMeshStats.Text = "Mesh Stats:";
			// 
			// lblMeshStatsVal
			// 
			this.lblMeshStatsVal.AutoSize = true;
			this.lblMeshStatsVal.Location = new System.Drawing.Point(90, 62);
			this.lblMeshStatsVal.Name = "lblMeshStatsVal";
			this.lblMeshStatsVal.Size = new System.Drawing.Size(10, 13);
			this.lblMeshStatsVal.TabIndex = 5;
			this.lblMeshStatsVal.Text = "-";
			// 
			// grpTexture
			// 
			this.grpTexture.Controls.Add(this.lblTexturePathVal);
			this.grpTexture.Controls.Add(this.lblTexturePath);
			this.grpTexture.Controls.Add(this.lblTextureDimVal);
			this.grpTexture.Controls.Add(this.lblTextureDim);
			this.grpTexture.Controls.Add(this.lblTextureNameVal);
			this.grpTexture.Controls.Add(this.lblTextureName);
			this.grpTexture.Location = new System.Drawing.Point(18, 172);
			this.grpTexture.Name = "grpTexture";
			this.grpTexture.Size = new System.Drawing.Size(584, 88);
			this.grpTexture.TabIndex = 2;
			this.grpTexture.TabStop = false;
			this.grpTexture.Text = "Associated Texture";
			// 
			// lblTextureName
			// 
			this.lblTextureName.AutoSize = true;
			this.lblTextureName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblTextureName.Location = new System.Drawing.Point(16, 22);
			this.lblTextureName.Name = "lblTextureName";
			this.lblTextureName.Size = new System.Drawing.Size(49, 13);
			this.lblTextureName.TabIndex = 0;
			this.lblTextureName.Text = "Texture:";
			// 
			// lblTextureNameVal
			// 
			this.lblTextureNameVal.AutoSize = true;
			this.lblTextureNameVal.Location = new System.Drawing.Point(90, 22);
			this.lblTextureNameVal.Name = "lblTextureNameVal";
			this.lblTextureNameVal.Size = new System.Drawing.Size(10, 13);
			this.lblTextureNameVal.TabIndex = 1;
			this.lblTextureNameVal.Text = "-";
			// 
			// lblTextureDim
			// 
			this.lblTextureDim.AutoSize = true;
			this.lblTextureDim.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblTextureDim.Location = new System.Drawing.Point(16, 42);
			this.lblTextureDim.Name = "lblTextureDim";
			this.lblTextureDim.Size = new System.Drawing.Size(70, 13);
			this.lblTextureDim.TabIndex = 2;
			this.lblTextureDim.Text = "Dimensions:";
			// 
			// lblTextureDimVal
			// 
			this.lblTextureDimVal.AutoSize = true;
			this.lblTextureDimVal.Location = new System.Drawing.Point(90, 42);
			this.lblTextureDimVal.Name = "lblTextureDimVal";
			this.lblTextureDimVal.Size = new System.Drawing.Size(10, 13);
			this.lblTextureDimVal.TabIndex = 3;
			this.lblTextureDimVal.Text = "-";
			// 
			// lblTexturePath
			// 
			this.lblTexturePath.AutoSize = true;
			this.lblTexturePath.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblTexturePath.Location = new System.Drawing.Point(16, 62);
			this.lblTexturePath.Name = "lblTexturePath";
			this.lblTexturePath.Size = new System.Drawing.Size(34, 13);
			this.lblTexturePath.TabIndex = 4;
			this.lblTexturePath.Text = "Path:";
			// 
			// lblTexturePathVal
			// 
			this.lblTexturePathVal.AutoEllipsis = true;
			this.lblTexturePathVal.Location = new System.Drawing.Point(90, 62);
			this.lblTexturePathVal.Name = "lblTexturePathVal";
			this.lblTexturePathVal.Size = new System.Drawing.Size(480, 16);
			this.lblTexturePathVal.TabIndex = 5;
			this.lblTexturePathVal.Text = "-";
			// 
			// grpTarget
			// 
			this.grpTarget.Controls.Add(this.txtPipeline);
			this.grpTarget.Location = new System.Drawing.Point(18, 268);
			this.grpTarget.Name = "grpTarget";
			this.grpTarget.Size = new System.Drawing.Size(584, 132);
			this.grpTarget.TabIndex = 3;
			this.grpTarget.TabStop = false;
			this.grpTarget.Text = "Planned Transformation Pipeline";
			// 
			// txtPipeline
			// 
			this.txtPipeline.BackColor = System.Drawing.Color.White;
			this.txtPipeline.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtPipeline.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPipeline.Location = new System.Drawing.Point(3, 16);
			this.txtPipeline.Multiline = true;
			this.txtPipeline.Name = "txtPipeline";
			this.txtPipeline.ReadOnly = true;
			this.txtPipeline.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtPipeline.Size = new System.Drawing.Size(578, 113);
			this.txtPipeline.TabIndex = 0;
			// 
			// panelTodo
			// 
			this.panelTodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
			this.panelTodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelTodo.Controls.Add(this.lblTodoText);
			this.panelTodo.Controls.Add(this.lblTodoHeader);
			this.panelTodo.Location = new System.Drawing.Point(18, 410);
			this.panelTodo.Name = "panelTodo";
			this.panelTodo.Size = new System.Drawing.Size(584, 76);
			this.panelTodo.TabIndex = 4;
			// 
			// lblTodoHeader
			// 
			this.lblTodoHeader.AutoSize = true;
			this.lblTodoHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTodoHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
			this.lblTodoHeader.Location = new System.Drawing.Point(10, 8);
			this.lblTodoHeader.Name = "lblTodoHeader";
			this.lblTodoHeader.Size = new System.Drawing.Size(262, 15);
			this.lblTodoHeader.TabIndex = 0;
			this.lblTodoHeader.Text = "TODO: glTF / GLB Serializer Roadmap Status";
			// 
			// lblTodoText
			// 
			this.lblTodoText.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTodoText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(50)))), ((int)(((byte)(0)))));
			this.lblTodoText.Location = new System.Drawing.Point(10, 27);
			this.lblTodoText.Name = "lblTodoText";
			this.lblTodoText.Size = new System.Drawing.Size(560, 42);
			this.lblTodoText.TabIndex = 1;
			this.lblTodoText.Text = "The intermediate mesh and export interfaces (IModelExporter, GltfExportService) are established. The binary GLB chunk generator and accessor buffer packer will be fully implemented in the next planned phase.";
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnClose.Location = new System.Drawing.Point(517, 498);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(85, 26);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(18, 498);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(160, 26);
			this.btnCopy.TabIndex = 6;
			this.btnCopy.Text = "Copy Specifications";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
			// 
			// GltfExportDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(620, 534);
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.panelTodo);
			this.Controls.Add(this.grpTarget);
			this.Controls.Add(this.grpTexture);
			this.Controls.Add(this.grpSource);
			this.Controls.Add(this.panelHeader);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GltfExportDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Export to glTF / GLB";
			this.panelHeader.ResumeLayout(false);
			this.panelHeader.PerformLayout();
			this.grpSource.ResumeLayout(false);
			this.grpSource.PerformLayout();
			this.grpTexture.ResumeLayout(false);
			this.grpTexture.PerformLayout();
			this.grpTarget.ResumeLayout(false);
			this.grpTarget.PerformLayout();
			this.panelTodo.ResumeLayout(false);
			this.panelTodo.PerformLayout();
			this.ResumeLayout(false);

		}

		private System.Windows.Forms.Panel panelHeader;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblSubtitle;
		private System.Windows.Forms.GroupBox grpSource;
		private System.Windows.Forms.Label lblModelName;
		private System.Windows.Forms.Label lblModelNameVal;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Label lblVersionVal;
		private System.Windows.Forms.Label lblMeshStats;
		private System.Windows.Forms.Label lblMeshStatsVal;
		private System.Windows.Forms.GroupBox grpTexture;
		private System.Windows.Forms.Label lblTextureName;
		private System.Windows.Forms.Label lblTextureNameVal;
		private System.Windows.Forms.Label lblTextureDim;
		private System.Windows.Forms.Label lblTextureDimVal;
		private System.Windows.Forms.Label lblTexturePath;
		private System.Windows.Forms.Label lblTexturePathVal;
		private System.Windows.Forms.GroupBox grpTarget;
		private System.Windows.Forms.TextBox txtPipeline;
		private System.Windows.Forms.Panel panelTodo;
		private System.Windows.Forms.Label lblTodoHeader;
		private System.Windows.Forms.Label lblTodoText;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnCopy;
	}
}
