namespace HowToWork.Export
{
    partial class XlsExportFrom
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtXlsFile = new System.Windows.Forms.TextBox();
            this.btnXlsBrowse = new System.Windows.Forms.Button();
            this.chbOpen = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "File";
            // 
            // txtXlsFile
            // 
            this.txtXlsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXlsFile.Location = new System.Drawing.Point(69, 12);
            this.txtXlsFile.Name = "txtXlsFile";
            this.txtXlsFile.Size = new System.Drawing.Size(183, 20);
            this.txtXlsFile.TabIndex = 1;
            this.txtXlsFile.TextChanged += new System.EventHandler(this.TxtXlsFile_TextChanged);
            // 
            // btnXlsBrowse
            // 
            this.btnXlsBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXlsBrowse.Location = new System.Drawing.Point(258, 10);
            this.btnXlsBrowse.Name = "btnXlsBrowse";
            this.btnXlsBrowse.Size = new System.Drawing.Size(27, 23);
            this.btnXlsBrowse.TabIndex = 2;
            this.btnXlsBrowse.Text = "...";
            this.btnXlsBrowse.UseVisualStyleBackColor = true;
            this.btnXlsBrowse.Click += new System.EventHandler(this.BtnXlsBrowse_Click);
            // 
            // chbOpen
            // 
            this.chbOpen.AutoSize = true;
            this.chbOpen.Checked = true;
            this.chbOpen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOpen.Location = new System.Drawing.Point(14, 38);
            this.chbOpen.Name = "chbOpen";
            this.chbOpen.Size = new System.Drawing.Size(109, 17);
            this.chbOpen.TabIndex = 3;
            this.chbOpen.Text = "Open after create";
            this.chbOpen.UseVisualStyleBackColor = true;
            // 
            // XlsExportFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 66);
            this.Controls.Add(this.chbOpen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtXlsFile);
            this.Controls.Add(this.btnXlsBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "XlsExportFrom";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel 2003";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtXlsFile;
        private System.Windows.Forms.Button btnXlsBrowse;
        private System.Windows.Forms.CheckBox chbOpen;
    }
}