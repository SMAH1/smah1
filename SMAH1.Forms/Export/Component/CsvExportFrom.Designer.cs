namespace SMAH1.Export.Component
{
    partial class CsvExportFrom
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtCsvFile = new System.Windows.Forms.TextBox();
            this.btnCsvBrowse = new System.Windows.Forms.Button();
            this.cbxDelimiter = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Delimiter";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "File";
            // 
            // txtCsvFile
            // 
            this.txtCsvFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCsvFile.Location = new System.Drawing.Point(69, 12);
            this.txtCsvFile.Name = "txtCsvFile";
            this.txtCsvFile.Size = new System.Drawing.Size(183, 20);
            this.txtCsvFile.TabIndex = 1;
            this.txtCsvFile.TextChanged += new System.EventHandler(this.TxtCsvFile_TextChanged);
            // 
            // btnCsvBrowse
            // 
            this.btnCsvBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCsvBrowse.Location = new System.Drawing.Point(258, 9);
            this.btnCsvBrowse.Name = "btnCsvBrowse";
            this.btnCsvBrowse.Size = new System.Drawing.Size(27, 23);
            this.btnCsvBrowse.TabIndex = 2;
            this.btnCsvBrowse.Text = "...";
            this.btnCsvBrowse.UseVisualStyleBackColor = true;
            this.btnCsvBrowse.Click += new System.EventHandler(this.BtnCsvBrowse_Click);
            // 
            // cbxDelimiter
            // 
            this.cbxDelimiter.FormattingEnabled = true;
            this.cbxDelimiter.Location = new System.Drawing.Point(69, 38);
            this.cbxDelimiter.Name = "cbxDelimiter";
            this.cbxDelimiter.Size = new System.Drawing.Size(70, 21);
            this.cbxDelimiter.TabIndex = 4;
            this.cbxDelimiter.SelectedIndexChanged += new System.EventHandler(this.CbxDelimiter_SelectedIndexChanged);
            this.cbxDelimiter.TextChanged += new System.EventHandler(this.CbxDelimiter_TextChanged);
            // 
            // CsvExportFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 74);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCsvFile);
            this.Controls.Add(this.btnCsvBrowse);
            this.Controls.Add(this.cbxDelimiter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CsvExportFrom";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CSV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCsvFile;
        private System.Windows.Forms.Button btnCsvBrowse;
        private System.Windows.Forms.ComboBox cbxDelimiter;
    }
}