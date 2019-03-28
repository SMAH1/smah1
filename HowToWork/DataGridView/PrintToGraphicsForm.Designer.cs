namespace HowToWork
{
    partial class PrintToGraphicsForm
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lstPage = new System.Windows.Forms.ListBox();
            this.pnlPage = new System.Windows.Forms.Panel();
            this.picPage = new System.Windows.Forms.PictureBox();
            this.txtHeight = new SMAH1.Forms.Text.TextBoxNumeric();
            this.txtWidth = new SMAH1.Forms.Text.TextBoxNumeric();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new SMAH1.Forms.DataGridViewComponent.DataGridViewRowNumberColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new SMAH1.Forms.DataGridViewComponent.DataGridViewProgressColumn();
            this.pnlPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Height";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(391, 222);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(102, 28);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(195, 222);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTitle.Size = new System.Drawing.Size(190, 42);
            this.txtTitle.TabIndex = 8;
            this.txtTitle.Text = "First Lone\r\nSecond Line";
            // 
            // lstPage
            // 
            this.lstPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstPage.FormattingEnabled = true;
            this.lstPage.Location = new System.Drawing.Point(15, 274);
            this.lstPage.Name = "lstPage";
            this.lstPage.Size = new System.Drawing.Size(120, 134);
            this.lstPage.TabIndex = 9;
            this.lstPage.SelectedIndexChanged += new System.EventHandler(this.lstPage_SelectedIndexChanged);
            // 
            // pnlPage
            // 
            this.pnlPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPage.AutoScroll = true;
            this.pnlPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPage.Controls.Add(this.picPage);
            this.pnlPage.Location = new System.Drawing.Point(141, 274);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Size = new System.Drawing.Size(352, 134);
            this.pnlPage.TabIndex = 10;
            // 
            // picPage
            // 
            this.picPage.Location = new System.Drawing.Point(0, 0);
            this.picPage.Name = "picPage";
            this.picPage.Size = new System.Drawing.Size(100, 50);
            this.picPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPage.TabIndex = 0;
            this.picPage.TabStop = false;
            // 
            // txtHeight
            // 
            this.txtHeight.DiscreteNumeric = true;
            this.txtHeight.Location = new System.Drawing.Point(56, 248);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Separator = ",";
            this.txtHeight.Size = new System.Drawing.Size(69, 20);
            this.txtHeight.TabIndex = 3;
            this.txtHeight.Text = "400";
            // 
            // txtWidth
            // 
            this.txtWidth.DiscreteNumeric = true;
            this.txtWidth.Location = new System.Drawing.Point(56, 222);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Separator = ",";
            this.txtWidth.Size = new System.Drawing.Size(69, 20);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.Text = "200";
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.ColumnStatus});
            this.dgv.Location = new System.Drawing.Point(12, 12);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(481, 204);
            this.dgv.TabIndex = 1;
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
            this.Column2.HeaderText = "Number";
            this.Column2.Name = "Column2";
            this.Column2.Width = 70;
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
            this.ColumnStatus.ProgressBarColorDefault = System.Drawing.SystemColors.Info;
            this.ColumnStatus.ProgressBarColorError = System.Drawing.Color.Red;
            this.ColumnStatus.ProgressBarColorFinish = System.Drawing.Color.Green;
            this.ColumnStatus.ProgressBarColorProcess = System.Drawing.SystemColors.ControlLight;
            this.ColumnStatus.ProgressBarColorQueue = System.Drawing.SystemColors.Info;
            this.ColumnStatus.ProgressBarColorSelection = System.Drawing.SystemColors.Highlight;
            // 
            // PrintToImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 426);
            this.Controls.Add(this.pnlPage);
            this.Controls.Add(this.lstPage);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.dgv);
            this.MinimizeBox = false;
            this.Name = "PrintToImageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print To Image";
            this.Load += new System.EventHandler(this.PrintToImageForm_Load);
            this.pnlPage.ResumeLayout(false);
            this.pnlPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private SMAH1.Forms.DataGridViewComponent.DataGridViewRowNumberColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private SMAH1.Forms.DataGridViewComponent.DataGridViewProgressColumn ColumnStatus;
        private SMAH1.Forms.Text.TextBoxNumeric txtWidth;
        private SMAH1.Forms.Text.TextBoxNumeric txtHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ListBox lstPage;
        private System.Windows.Forms.Panel pnlPage;
        private System.Windows.Forms.PictureBox picPage;
    }
}