namespace HowToWork
{
    partial class DataGridViewForm
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new SMAH1.Forms.DataGridViewComponent.DataGridViewRowNumberColumn();
            this.Column6 = new SMAH1.Forms.DataGridViewComponent.DataGridViewRowNumberColumn();
            this.Column2 = new SMAH1.Forms.DataGridViewComponent.DataGridViewNumTextBoxColumn();
            this.Column5 = new SMAH1.Forms.DataGridViewComponent.DataGridViewNumTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new SMAH1.Forms.DataGridViewComponent.DataGridViewProgressColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(567, 72);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column4,
            this.ColumnStatus});
            this.dgv.Location = new System.Drawing.Point(12, 12);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(567, 260);
            this.dgv.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Row";
            this.Column1.Name = "Column1";
            this.Column1.NumeralSign = SMAH1.Character.NumeralSystemSign.Default;
            this.Column1.ReadOnly = true;
            this.Column1.Start = 1;
            this.Column1.Width = 50;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Row2";
            this.Column6.Name = "Column6";
            this.Column6.NumeralSign = SMAH1.Character.NumeralSystemSign.Persian;
            this.Column6.ReadOnly = true;
            this.Column6.Start = 101;
            this.Column6.Width = 50;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Number";
            this.Column2.DecimalPlaces = 0;
            this.Column2.HeaderText = "Num.1";
            this.Column2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 60;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Number2";
            this.Column5.DecimalPlaces = 1;
            this.Column5.HeaderText = "Num.2";
            this.Column5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Column5.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.Column5.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 60;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Name";
            this.Column3.HeaderText = "Name";
            this.Column3.Name = "Column3";
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Family";
            this.Column4.HeaderText = "Family";
            this.Column4.Name = "Column4";
            this.Column4.Width = 120;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.DataPropertyName = "Status";
            this.ColumnStatus.HeaderText = "Status";
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ProgressBarColorDefault = System.Drawing.SystemColors.ControlLight;
            this.ColumnStatus.ProgressBarColorError = System.Drawing.Color.Red;
            this.ColumnStatus.ProgressBarColorFinish = System.Drawing.Color.Green;
            this.ColumnStatus.ProgressBarColorProcess = System.Drawing.SystemColors.ControlLight;
            this.ColumnStatus.ProgressBarColorQueue = System.Drawing.SystemColors.InactiveCaption;
            this.ColumnStatus.ProgressBarColorSelection = System.Drawing.SystemColors.HotTrack;
            // 
            // DataGridViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 356);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(510, 330);
            this.Name = "DataGridViewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DataGridView";
            this.Load += new System.EventHandler(this.DataGridViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
        private SMAH1.Forms.DataGridViewComponent.DataGridViewRowNumberColumn Column1;
        private SMAH1.Forms.DataGridViewComponent.DataGridViewRowNumberColumn Column6;
        private SMAH1.Forms.DataGridViewComponent.DataGridViewNumTextBoxColumn Column2;
        private SMAH1.Forms.DataGridViewComponent.DataGridViewNumTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private SMAH1.Forms.DataGridViewComponent.DataGridViewProgressColumn ColumnStatus;
    }
}