namespace SMAH1.Export
{
    partial class ExportDataForm
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
            this.lbxExport = new System.Windows.Forms.ListBox();
            this.pnlExport = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.cbxExportData = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbxExport
            // 
            this.lbxExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxExport.FormattingEnabled = true;
            this.lbxExport.Location = new System.Drawing.Point(12, 12);
            this.lbxExport.Name = "lbxExport";
            this.lbxExport.Size = new System.Drawing.Size(120, 147);
            this.lbxExport.TabIndex = 0;
            this.lbxExport.SelectedIndexChanged += new System.EventHandler(this.LbxExport_SelectedIndexChanged);
            // 
            // pnlExport
            // 
            this.pnlExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlExport.BackColor = System.Drawing.SystemColors.Control;
            this.pnlExport.Location = new System.Drawing.Point(138, 39);
            this.pnlExport.Name = "pnlExport";
            this.pnlExport.Size = new System.Drawing.Size(164, 87);
            this.pnlExport.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(136, 132);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.Location = new System.Drawing.Point(222, 132);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(80, 28);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // cbxExportData
            // 
            this.cbxExportData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxExportData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxExportData.FormattingEnabled = true;
            this.cbxExportData.Location = new System.Drawing.Point(138, 12);
            this.cbxExportData.Name = "cbxExportData";
            this.cbxExportData.Size = new System.Drawing.Size(164, 21);
            this.cbxExportData.TabIndex = 15;
            this.cbxExportData.SelectedIndexChanged += new System.EventHandler(this.CbxExportData_SelectedIndexChanged);
            // 
            // ExportDataForm
            // 
            this.ClientSize = new System.Drawing.Size(314, 172);
            this.Controls.Add(this.cbxExportData);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.pnlExport);
            this.Controls.Add(this.lbxExport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(320, 204);
            this.Name = "ExportDataForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export Data";
            this.Load += new System.EventHandler(this.BtnExport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxExport;
        private System.Windows.Forms.Panel pnlExport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cbxExportData;

    }
}