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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemComparerPluginControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbLoadMetadata = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbOptions = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTargetName = new System.Windows.Forms.Label();
            this.labelSourceName = new System.Windows.Forms.Label();
            this.buttonChangeTarget = new System.Windows.Forms.Button();
            this.buttonChangeSource = new System.Windows.Forms.Button();
            this.labelTarget = new System.Windows.Forms.Label();
            this.labelSource = new System.Windows.Forms.Label();
            this.comparisonListView = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.unchangedColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.changedColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notInSourceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.notInTargetColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DifferenceList = new System.Windows.Forms.ImageList(this.components);
            this.TreeImagesList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainerOverview = new System.Windows.Forms.SplitContainer();
            this.splitContainerCompare = new System.Windows.Forms.SplitContainer();
            this.webBrowserSource = new System.Windows.Forms.WebBrowser();
            this.webBrowserTarget = new System.Windows.Forms.WebBrowser();
            this.systemComparerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkboxIgnoreDevProd = new System.Windows.Forms.CheckBox();
            this.checkboxViews = new System.Windows.Forms.CheckBox();
            this.checkboxForms = new System.Windows.Forms.CheckBox();
            this.checkboxAllAttributes = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkboxListHideEqual = new System.Windows.Forms.CheckBox();
            this.toolStripMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOverview)).BeginInit();
            this.splitContainerOverview.Panel1.SuspendLayout();
            this.splitContainerOverview.Panel2.SuspendLayout();
            this.splitContainerOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCompare)).BeginInit();
            this.splitContainerCompare.Panel1.SuspendLayout();
            this.splitContainerCompare.Panel2.SuspendLayout();
            this.splitContainerCompare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.systemComparerBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tbbLoadMetadata,
            this.toolStripSeparator1,
            this.tbbOptions});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1276, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = global::CRMP.XTBPlugin.SystemComparer.Properties.Resources.icons8_fenster_schließen_24;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(28, 28);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tbbLoadMetadata
            // 
            this.tbbLoadMetadata.Enabled = false;
            this.tbbLoadMetadata.Image = global::CRMP.XTBPlugin.SystemComparer.Properties.Resources.icons8_aus_der_cloud_laden_24;
            this.tbbLoadMetadata.Name = "tbbLoadMetadata";
            this.tbbLoadMetadata.Size = new System.Drawing.Size(114, 28);
            this.tbbLoadMetadata.Text = "Load Metadata";
            this.tbbLoadMetadata.Click += new System.EventHandler(this.tbbLoadMetadata_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tbbOptions
            // 
            this.tbbOptions.Image = global::CRMP.XTBPlugin.SystemComparer.Properties.Resources.icons8_support_24;
            this.tbbOptions.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tbbOptions.Name = "tbbOptions";
            this.tbbOptions.Size = new System.Drawing.Size(77, 28);
            this.tbbOptions.Text = "Options";
            this.tbbOptions.ToolTipText = "Shows Options Menu";
            this.tbbOptions.Click += new System.EventHandler(this.tbbOptions_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelTargetName);
            this.groupBox1.Controls.Add(this.labelSourceName);
            this.groupBox1.Controls.Add(this.buttonChangeTarget);
            this.groupBox1.Controls.Add(this.buttonChangeSource);
            this.groupBox1.Controls.Add(this.labelTarget);
            this.groupBox1.Controls.Add(this.labelSource);
            this.groupBox1.Location = new System.Drawing.Point(3, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 94);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // labelTargetName
            // 
            this.labelTargetName.AutoSize = true;
            this.labelTargetName.Location = new System.Drawing.Point(134, 54);
            this.labelTargetName.Name = "labelTargetName";
            this.labelTargetName.Size = new System.Drawing.Size(76, 13);
            this.labelTargetName.TabIndex = 7;
            this.labelTargetName.Text = "not connected";
            // 
            // labelSourceName
            // 
            this.labelSourceName.AutoSize = true;
            this.labelSourceName.Location = new System.Drawing.Point(134, 25);
            this.labelSourceName.Name = "labelSourceName";
            this.labelSourceName.Size = new System.Drawing.Size(76, 13);
            this.labelSourceName.TabIndex = 6;
            this.labelSourceName.Text = "not connected";
            // 
            // buttonChangeTarget
            // 
            this.buttonChangeTarget.Location = new System.Drawing.Point(363, 49);
            this.buttonChangeTarget.Name = "buttonChangeTarget";
            this.buttonChangeTarget.Size = new System.Drawing.Size(122, 23);
            this.buttonChangeTarget.TabIndex = 5;
            this.buttonChangeTarget.Text = "Change Target";
            this.buttonChangeTarget.UseVisualStyleBackColor = true;
            this.buttonChangeTarget.Click += new System.EventHandler(this.buttonChangeTarget_Click);
            // 
            // buttonChangeSource
            // 
            this.buttonChangeSource.Location = new System.Drawing.Point(363, 20);
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
            this.labelTarget.Location = new System.Drawing.Point(6, 54);
            this.labelTarget.Name = "labelTarget";
            this.labelTarget.Size = new System.Drawing.Size(103, 13);
            this.labelTarget.TabIndex = 1;
            this.labelTarget.Text = "Target Environment:";
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(7, 25);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(106, 13);
            this.labelSource.TabIndex = 0;
            this.labelSource.Text = "Source Environment:";
            // 
            // comparisonListView
            // 
            this.comparisonListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comparisonListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.typeColumnHeader,
            this.unchangedColumnHeader,
            this.changedColumnHeader,
            this.notInSourceColumnHeader,
            this.notInTargetColumnHeader});
            this.comparisonListView.FullRowSelect = true;
            this.comparisonListView.GridLines = true;
            this.comparisonListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.comparisonListView.HideSelection = false;
            this.comparisonListView.Location = new System.Drawing.Point(3, 0);
            this.comparisonListView.Name = "comparisonListView";
            this.comparisonListView.Size = new System.Drawing.Size(1264, 274);
            this.comparisonListView.SmallImageList = this.DifferenceList;
            this.comparisonListView.StateImageList = this.TreeImagesList;
            this.comparisonListView.TabIndex = 0;
            this.comparisonListView.UseCompatibleStateImageBehavior = false;
            this.comparisonListView.View = System.Windows.Forms.View.Details;
            this.comparisonListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.comparisonListView_ItemSelectionChanged);
            this.comparisonListView.Click += new System.EventHandler(this.comparisonListView_Click);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 300;
            // 
            // typeColumnHeader
            // 
            this.typeColumnHeader.Text = "Type";
            this.typeColumnHeader.Width = 150;
            // 
            // unchangedColumnHeader
            // 
            this.unchangedColumnHeader.Text = "UnChanged";
            this.unchangedColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.unchangedColumnHeader.Width = 100;
            // 
            // changedColumnHeader
            // 
            this.changedColumnHeader.Text = "Changed";
            this.changedColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.changedColumnHeader.Width = 100;
            // 
            // notInSourceColumnHeader
            // 
            this.notInSourceColumnHeader.Text = "Not in Source";
            this.notInSourceColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.notInSourceColumnHeader.Width = 120;
            // 
            // notInTargetColumnHeader
            // 
            this.notInTargetColumnHeader.Text = "Not in Target";
            this.notInTargetColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.notInTargetColumnHeader.Width = 100;
            // 
            // DifferenceList
            // 
            this.DifferenceList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("DifferenceList.ImageStream")));
            this.DifferenceList.TransparentColor = System.Drawing.Color.Transparent;
            this.DifferenceList.Images.SetKeyName(0, "green.png");
            this.DifferenceList.Images.SetKeyName(1, "yellow.png");
            this.DifferenceList.Images.SetKeyName(2, "notinsource.png");
            this.DifferenceList.Images.SetKeyName(3, "notintarget.png");
            // 
            // TreeImagesList
            // 
            this.TreeImagesList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImagesList.ImageStream")));
            this.TreeImagesList.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeImagesList.Images.SetKeyName(0, "maximize.png");
            this.TreeImagesList.Images.SetKeyName(1, "minimize.png");
            // 
            // splitContainerOverview
            // 
            this.splitContainerOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerOverview.Location = new System.Drawing.Point(3, 134);
            this.splitContainerOverview.Name = "splitContainerOverview";
            this.splitContainerOverview.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerOverview.Panel1
            // 
            this.splitContainerOverview.Panel1.Controls.Add(this.comparisonListView);
            // 
            // splitContainerOverview.Panel2
            // 
            this.splitContainerOverview.Panel2.Controls.Add(this.splitContainerCompare);
            this.splitContainerOverview.Size = new System.Drawing.Size(1270, 463);
            this.splitContainerOverview.SplitterDistance = 277;
            this.splitContainerOverview.TabIndex = 6;
            // 
            // splitContainerCompare
            // 
            this.splitContainerCompare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCompare.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCompare.Name = "splitContainerCompare";
            // 
            // splitContainerCompare.Panel1
            // 
            this.splitContainerCompare.Panel1.Controls.Add(this.webBrowserSource);
            // 
            // splitContainerCompare.Panel2
            // 
            this.splitContainerCompare.Panel2.Controls.Add(this.webBrowserTarget);
            this.splitContainerCompare.Size = new System.Drawing.Size(1270, 182);
            this.splitContainerCompare.SplitterDistance = 639;
            this.splitContainerCompare.TabIndex = 0;
            // 
            // webBrowserSource
            // 
            this.webBrowserSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserSource.Location = new System.Drawing.Point(0, 0);
            this.webBrowserSource.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserSource.Name = "webBrowserSource";
            this.webBrowserSource.Size = new System.Drawing.Size(639, 182);
            this.webBrowserSource.TabIndex = 0;
            // 
            // webBrowserTarget
            // 
            this.webBrowserTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserTarget.Location = new System.Drawing.Point(0, 0);
            this.webBrowserTarget.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserTarget.Name = "webBrowserTarget";
            this.webBrowserTarget.Size = new System.Drawing.Size(627, 182);
            this.webBrowserTarget.TabIndex = 0;
            // 
            // systemComparerBindingSource
            // 
            this.systemComparerBindingSource.DataSource = typeof(CRMP.XTBPlugin.SystemComparer.Logic.SystemComparer);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkboxIgnoreDevProd);
            this.groupBox2.Controls.Add(this.checkboxViews);
            this.groupBox2.Controls.Add(this.checkboxForms);
            this.groupBox2.Controls.Add(this.checkboxAllAttributes);
            this.groupBox2.Location = new System.Drawing.Point(500, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 94);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // checkboxIgnoreDevProd
            // 
            this.checkboxIgnoreDevProd.Location = new System.Drawing.Point(223, 19);
            this.checkboxIgnoreDevProd.Name = "checkboxIgnoreDevProd";
            this.checkboxIgnoreDevProd.Size = new System.Drawing.Size(151, 17);
            this.checkboxIgnoreDevProd.TabIndex = 1;
            this.checkboxIgnoreDevProd.Text = "Compare Dev to Prod";
            this.checkboxIgnoreDevProd.UseVisualStyleBackColor = true;
            this.checkboxIgnoreDevProd.Click += new System.EventHandler(this.checkboxAnyConfiguration_Click);
            // 
            // checkboxViews
            // 
            this.checkboxViews.AutoSize = true;
            this.checkboxViews.Location = new System.Drawing.Point(6, 65);
            this.checkboxViews.Name = "checkboxViews";
            this.checkboxViews.Size = new System.Drawing.Size(122, 17);
            this.checkboxViews.TabIndex = 2;
            this.checkboxViews.Text = "Include Views (beta)";
            this.checkboxViews.UseVisualStyleBackColor = true;
            this.checkboxViews.Click += new System.EventHandler(this.checkboxAnyConfiguration_Click);
            // 
            // checkboxForms
            // 
            this.checkboxForms.AutoSize = true;
            this.checkboxForms.Location = new System.Drawing.Point(6, 42);
            this.checkboxForms.Name = "checkboxForms";
            this.checkboxForms.Size = new System.Drawing.Size(122, 17);
            this.checkboxForms.TabIndex = 1;
            this.checkboxForms.Text = "Include Forms (beta)";
            this.checkboxForms.UseVisualStyleBackColor = true;
            this.checkboxForms.Click += new System.EventHandler(this.checkboxAnyConfiguration_Click);
            // 
            // checkboxAllAttributes
            // 
            this.checkboxAllAttributes.Location = new System.Drawing.Point(6, 19);
            this.checkboxAllAttributes.Name = "checkboxAllAttributes";
            this.checkboxAllAttributes.Size = new System.Drawing.Size(151, 17);
            this.checkboxAllAttributes.TabIndex = 0;
            this.checkboxAllAttributes.Text = "Include All Metadata";
            this.checkboxAllAttributes.UseVisualStyleBackColor = true;
            this.checkboxAllAttributes.Click += new System.EventHandler(this.checkboxAnyConfiguration_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkboxListHideEqual);
            this.groupBox3.Location = new System.Drawing.Point(886, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(380, 94);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "List Settings";
            // 
            // checkboxListHideEqual
            // 
            this.checkboxListHideEqual.Location = new System.Drawing.Point(6, 19);
            this.checkboxListHideEqual.Name = "checkboxListHideEqual";
            this.checkboxListHideEqual.Size = new System.Drawing.Size(151, 17);
            this.checkboxListHideEqual.TabIndex = 0;
            this.checkboxListHideEqual.Text = "Hide equal items";
            this.checkboxListHideEqual.UseVisualStyleBackColor = true;
            this.checkboxListHideEqual.Click += new System.EventHandler(this.checkboxAnyConfiguration_Click);
            // 
            // SystemComparerPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.splitContainerOverview);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "SystemComparerPluginControl";
            this.Size = new System.Drawing.Size(1276, 600);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainerOverview.Panel1.ResumeLayout(false);
            this.splitContainerOverview.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerOverview)).EndInit();
            this.splitContainerOverview.ResumeLayout(false);
            this.splitContainerCompare.Panel1.ResumeLayout(false);
            this.splitContainerCompare.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCompare)).EndInit();
            this.splitContainerCompare.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.systemComparerBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
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
        private System.Windows.Forms.ListView comparisonListView;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ImageList TreeImagesList;
        private System.Windows.Forms.ImageList DifferenceList;
        private System.Windows.Forms.ColumnHeader unchangedColumnHeader;
        private System.Windows.Forms.ColumnHeader changedColumnHeader;
        private System.Windows.Forms.ColumnHeader notInSourceColumnHeader;
        private System.Windows.Forms.ColumnHeader notInTargetColumnHeader;
        private System.Windows.Forms.SplitContainer splitContainerOverview;
        private System.Windows.Forms.SplitContainer splitContainerCompare;
        private System.Windows.Forms.ColumnHeader typeColumnHeader;
        private System.Windows.Forms.WebBrowser webBrowserSource;
        private System.Windows.Forms.WebBrowser webBrowserTarget;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbbOptions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkboxViews;
        private System.Windows.Forms.CheckBox checkboxForms;
        private System.Windows.Forms.CheckBox checkboxAllAttributes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkboxListHideEqual;
        private System.Windows.Forms.CheckBox checkboxIgnoreDevProd;
    }
}
