namespace HowToWork
{
    partial class ExportForm
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
            this.btnExportSimple = new System.Windows.Forms.Button();
            this.chbxWithColName = new System.Windows.Forms.CheckBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnExportCustom = new System.Windows.Forms.Button();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.Column1 = new SMAH1.Forms.DataGridViewComponent.DataGridViewRowNumberColumn();
            this.Column2 = new SMAH1.Forms.DataGridViewComponent.DataGridViewNumTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportSimple
            // 
            this.btnExportSimple.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportSimple.Location = new System.Drawing.Point(12, 351);
            this.btnExportSimple.Name = "btnExportSimple";
            this.btnExportSimple.Size = new System.Drawing.Size(732, 28);
            this.btnExportSimple.TabIndex = 1;
            this.btnExportSimple.Text = "Export Simple Form";
            this.btnExportSimple.UseVisualStyleBackColor = true;
            this.btnExportSimple.Click += new System.EventHandler(this.BtnExportSimple_Click);
            // 
            // chbxWithColName
            // 
            this.chbxWithColName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbxWithColName.AutoSize = true;
            this.chbxWithColName.Checked = true;
            this.chbxWithColName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxWithColName.Location = new System.Drawing.Point(12, 294);
            this.chbxWithColName.Name = "chbxWithColName";
            this.chbxWithColName.Size = new System.Drawing.Size(144, 17);
            this.chbxWithColName.TabIndex = 2;
            this.chbxWithColName.Text = "Export with column name";
            this.chbxWithColName.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgv.Location = new System.Drawing.Point(12, 12);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(732, 276);
            this.dgv.TabIndex = 0;
            // 
            // btnExportCustom
            // 
            this.btnExportCustom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportCustom.Location = new System.Drawing.Point(12, 385);
            this.btnExportCustom.Name = "btnExportCustom";
            this.btnExportCustom.Size = new System.Drawing.Size(732, 28);
            this.btnExportCustom.TabIndex = 3;
            this.btnExportCustom.Text = "Export Custom Form";
            this.btnExportCustom.UseVisualStyleBackColor = true;
            this.btnExportCustom.Click += new System.EventHandler(this.btnExportCustom_Click);
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportCSV.Location = new System.Drawing.Point(12, 317);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(732, 28);
            this.btnExportCSV.TabIndex = 4;
            this.btnExportCSV.Text = "Export CSV";
            this.btnExportCSV.UseVisualStyleBackColor = true;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Row";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Number";
            this.Column2.DecimalPlaces = 0;
            this.Column2.HeaderText = "Number";
            this.Column2.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.Column2.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Name";
            this.Column3.HeaderText = "Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Family";
            this.Column4.HeaderText = "Family";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "DateTime";
            this.Column5.HeaderText = "DateTime";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 130;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Value";
            this.Column6.HeaderText = "Value";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 70;
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 428);
            this.Controls.Add(this.btnExportCSV);
            this.Controls.Add(this.btnExportCustom);
            this.Controls.Add(this.chbxWithColName);
            this.Controls.Add(this.btnExportSimple);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(510, 330);
            this.Name = "ExportForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export";
            this.Load += new System.EventHandler(this.ExportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnExportSimple;
        private System.Windows.Forms.CheckBox chbxWithColName;
        private System.Windows.Forms.Button btnExportCustom;
        private System.Windows.Forms.Button btnExportCSV;
        private SMAH1.Forms.DataGridViewComponent.DataGridViewRowNumberColumn Column1;
        private SMAH1.Forms.DataGridViewComponent.DataGridViewNumTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}