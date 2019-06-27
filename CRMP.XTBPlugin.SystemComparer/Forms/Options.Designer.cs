namespace CRMP.XTBPlugin.SystemComparer.Forms
{
    partial class Options
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
            this.groupBoxStatistics = new System.Windows.Forms.GroupBox();
            this.checkBoxSendExceptions = new System.Windows.Forms.CheckBox();
            this.checkBoxAllowStatistics = new System.Windows.Forms.CheckBox();
            this.labelStatistics = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBoxStatistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxStatistics
            // 
            this.groupBoxStatistics.Controls.Add(this.checkBoxSendExceptions);
            this.groupBoxStatistics.Controls.Add(this.checkBoxAllowStatistics);
            this.groupBoxStatistics.Controls.Add(this.labelStatistics);
            this.groupBoxStatistics.Location = new System.Drawing.Point(13, 13);
            this.groupBoxStatistics.Name = "groupBoxStatistics";
            this.groupBoxStatistics.Size = new System.Drawing.Size(404, 129);
            this.groupBoxStatistics.TabIndex = 0;
            this.groupBoxStatistics.TabStop = false;
            this.groupBoxStatistics.Text = "Statistics";
            // 
            // checkBoxSendExceptions
            // 
            this.checkBoxSendExceptions.AutoSize = true;
            this.checkBoxSendExceptions.Location = new System.Drawing.Point(6, 106);
            this.checkBoxSendExceptions.Name = "checkBoxSendExceptions";
            this.checkBoxSendExceptions.Size = new System.Drawing.Size(206, 17);
            this.checkBoxSendExceptions.TabIndex = 2;
            this.checkBoxSendExceptions.Text = "Send Exceptions (Application Insights)";
            this.checkBoxSendExceptions.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllowStatistics
            // 
            this.checkBoxAllowStatistics.AutoSize = true;
            this.checkBoxAllowStatistics.Location = new System.Drawing.Point(6, 83);
            this.checkBoxAllowStatistics.Name = "checkBoxAllowStatistics";
            this.checkBoxAllowStatistics.Size = new System.Drawing.Size(196, 17);
            this.checkBoxAllowStatistics.TabIndex = 1;
            this.checkBoxAllowStatistics.Text = "Allow Statistics (Application Insights)";
            this.checkBoxAllowStatistics.UseVisualStyleBackColor = true;
            // 
            // labelStatistics
            // 
            this.labelStatistics.AutoSize = true;
            this.labelStatistics.Location = new System.Drawing.Point(6, 16);
            this.labelStatistics.Name = "labelStatistics";
            this.labelStatistics.Size = new System.Drawing.Size(321, 52);
            this.labelStatistics.TabIndex = 0;
            this.labelStatistics.Text = "The plugin collects ONLY anonymous usage statistics.\r\nNo information related to y" +
    "our CRM / Organization will be retreived.\r\n\r\nThis will help us to improve the mo" +
    "st used features and stability.";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(342, 148);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(261, 148);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 183);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxStatistics);
            this.Name = "Options";
            this.Text = "Options";
            this.groupBoxStatistics.ResumeLayout(false);
            this.groupBoxStatistics.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxStatistics;
        private System.Windows.Forms.CheckBox checkBoxAllowStatistics;
        private System.Windows.Forms.Label labelStatistics;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.CheckBox checkBoxSendExceptions;
    }
}