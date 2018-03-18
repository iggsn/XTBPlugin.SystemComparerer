namespace CRMP.XTBPlugin.SystemComparer
{
    partial class SystemComparerPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbLoadMetadata = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTargetName = new System.Windows.Forms.Label();
            this.labelSourceName = new System.Windows.Forms.Label();
            this.buttonChangeTarget = new System.Windows.Forms.Button();
            this.buttonChangeSource = new System.Windows.Forms.Button();
            this.labelTarget = new System.Windows.Forms.Label();
            this.labelSource = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.systemComparerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemComparerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tbbLoadMetadata});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(907, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(86, 22);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbLoadMetadata
            // 
            this.tbbLoadMetadata.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbbLoadMetadata.Enabled = false;
            this.tbbLoadMetadata.Name = "tbbLoadMetadata";
            this.tbbLoadMetadata.Size = new System.Drawing.Size(90, 22);
            this.tbbLoadMetadata.Text = "Load Metadata";
            this.tbbLoadMetadata.Click += new System.EventHandler(this.tbbLoadMetadata_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelTargetName);
            this.groupBox1.Controls.Add(this.labelSourceName);
            this.groupBox1.Controls.Add(this.buttonChangeTarget);
            this.groupBox1.Controls.Add(this.buttonChangeSource);
            this.groupBox1.Controls.Add(this.labelTarget);
            this.groupBox1.Controls.Add(this.labelSource);
            this.groupBox1.Location = new System.Drawing.Point(3, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // labelTargetName
            // 
            this.labelTargetName.AutoSize = true;
            this.labelTargetName.Location = new System.Drawing.Point(134, 49);
            this.labelTargetName.Name = "labelTargetName";
            this.labelTargetName.Size = new System.Drawing.Size(76, 13);
            this.labelTargetName.TabIndex = 7;
            this.labelTargetName.Text = "not connected";
            // 
            // labelSourceName
            // 
            this.labelSourceName.AutoSize = true;
            this.labelSourceName.Location = new System.Drawing.Point(134, 20);
            this.labelSourceName.Name = "labelSourceName";
            this.labelSourceName.Size = new System.Drawing.Size(76, 13);
            this.labelSourceName.TabIndex = 6;
            this.labelSourceName.Text = "not connected";
            // 
            // buttonChangeTarget
            // 
            this.buttonChangeTarget.Location = new System.Drawing.Point(363, 44);
            this.buttonChangeTarget.Name = "buttonChangeTarget";
            this.buttonChangeTarget.Size = new System.Drawing.Size(122, 23);
            this.buttonChangeTarget.TabIndex = 5;
            this.buttonChangeTarget.Text = "Change Target";
            this.buttonChangeTarget.UseVisualStyleBackColor = true;
            this.buttonChangeTarget.Click += new System.EventHandler(this.buttonChangeTarget_Click);
            // 
            // buttonChangeSource
            // 
            this.buttonChangeSource.Location = new System.Drawing.Point(363, 15);
            this.buttonChangeSource.Name = "buttonChangeSource";
            this.buttonChangeSource.Size = new System.Drawing.Size(122, 23);
            this.buttonChangeSource.TabIndex = 4;
            this.buttonChangeSource.Text = "Change Source";
            this.buttonChangeSource.UseVisualStyleBackColor = true;
            this.buttonChangeSource.Click += new System.EventHandler(this.buttonSourceChange_Click);
            // 
            // labelTarget
            // 
            this.labelTarget.AutoSize = true;
            this.labelTarget.Location = new System.Drawing.Point(6, 49);
            this.labelTarget.Name = "labelTarget";
            this.labelTarget.Size = new System.Drawing.Size(103, 13);
            this.labelTarget.TabIndex = 1;
            this.labelTarget.Text = "Target Environment:";
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(7, 20);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(106, 13);
            this.labelSource.TabIndex = 0;
            this.labelSource.Text = "Source Environment:";
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(3, 135);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(901, 287);
            this.dataGrid1.TabIndex = 7;
            // 
            // systemComparerBindingSource
            // 
            this.systemComparerBindingSource.DataSource = typeof(CRMP.XTBPlugin.SystemComparer.Logic.SystemComparer);
            // 
            // SystemComparerPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "SystemComparerPluginControl";
            this.Size = new System.Drawing.Size(907, 425);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemComparerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tbbLoadMetadata;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonChangeTarget;
        private System.Windows.Forms.Button buttonChangeSource;
        private System.Windows.Forms.Label labelTarget;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelTargetName;
        private System.Windows.Forms.Label labelSourceName;
        private System.Windows.Forms.BindingSource systemComparerBindingSource;
        private System.Windows.Forms.DataGrid dataGrid1;
    }
}
