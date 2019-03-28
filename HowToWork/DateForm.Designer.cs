namespace HowToWork
{
    partial class DateForm
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
            this.btnAddDay = new System.Windows.Forms.Button();
            this.btnAddMonth = new System.Windows.Forms.Button();
            this.btnAddYear = new System.Windows.Forms.Button();
            this.btnAddWeek = new System.Windows.Forms.Button();
            this.txtDayNameEn = new System.Windows.Forms.TextBox();
            this.txtDayNameFa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblF1 = new System.Windows.Forms.Label();
            this.gbFormat = new System.Windows.Forms.GroupBox();
            this.lblRR = new System.Windows.Forms.Label();
            this.cbxFD = new System.Windows.Forms.ComboBox();
            this.cbxFM = new System.Windows.Forms.ComboBox();
            this.cbxFY = new System.Windows.Forms.ComboBox();
            this.lblR5 = new System.Windows.Forms.Label();
            this.lblF5 = new System.Windows.Forms.Label();
            this.lblR4 = new System.Windows.Forms.Label();
            this.lblF4 = new System.Windows.Forms.Label();
            this.lblR3 = new System.Windows.Forms.Label();
            this.lblF3 = new System.Windows.Forms.Label();
            this.lblR2 = new System.Windows.Forms.Label();
            this.lblF2 = new System.Windows.Forms.Label();
            this.lblR1 = new System.Windows.Forms.Label();
            this.btnToDate = new SMAH1.Forms.Clickable.ButtonDirection();
            this.btnToInt = new SMAH1.Forms.Clickable.ButtonDirection();
            this.txtNumAdd = new SMAH1.Forms.Text.TextBoxNumeric();
            this.txtNum = new SMAH1.Forms.Text.TextBoxNumeric();
            this.txtDate = new SMAH1.Forms.Text.Persian.TextBoxPersianDate();
            this.gbFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddDay
            // 
            this.btnAddDay.Location = new System.Drawing.Point(125, 307);
            this.btnAddDay.Name = "btnAddDay";
            this.btnAddDay.Size = new System.Drawing.Size(55, 23);
            this.btnAddDay.TabIndex = 8;
            this.btnAddDay.Text = "Day";
            this.btnAddDay.UseVisualStyleBackColor = true;
            this.btnAddDay.Click += new System.EventHandler(this.btnAddDay_Click);
            // 
            // btnAddMonth
            // 
            this.btnAddMonth.Location = new System.Drawing.Point(186, 278);
            this.btnAddMonth.Name = "btnAddMonth";
            this.btnAddMonth.Size = new System.Drawing.Size(55, 23);
            this.btnAddMonth.TabIndex = 7;
            this.btnAddMonth.Text = "Month";
            this.btnAddMonth.UseVisualStyleBackColor = true;
            this.btnAddMonth.Click += new System.EventHandler(this.btnAddMonth_Click);
            // 
            // btnAddYear
            // 
            this.btnAddYear.Location = new System.Drawing.Point(125, 278);
            this.btnAddYear.Name = "btnAddYear";
            this.btnAddYear.Size = new System.Drawing.Size(55, 23);
            this.btnAddYear.TabIndex = 6;
            this.btnAddYear.Text = "Year";
            this.btnAddYear.UseVisualStyleBackColor = true;
            this.btnAddYear.Click += new System.EventHandler(this.btnAddYear_Click);
            // 
            // btnAddWeek
            // 
            this.btnAddWeek.Location = new System.Drawing.Point(186, 308);
            this.btnAddWeek.Name = "btnAddWeek";
            this.btnAddWeek.Size = new System.Drawing.Size(55, 23);
            this.btnAddWeek.TabIndex = 5;
            this.btnAddWeek.Text = "Week";
            this.btnAddWeek.UseVisualStyleBackColor = true;
            this.btnAddWeek.Click += new System.EventHandler(this.btnAddWeek_Click);
            // 
            // txtDayNameEn
            // 
            this.txtDayNameEn.Location = new System.Drawing.Point(133, 39);
            this.txtDayNameEn.Name = "txtDayNameEn";
            this.txtDayNameEn.ReadOnly = true;
            this.txtDayNameEn.Size = new System.Drawing.Size(79, 20);
            this.txtDayNameEn.TabIndex = 9;
            // 
            // txtDayNameFa
            // 
            this.txtDayNameFa.Location = new System.Drawing.Point(48, 39);
            this.txtDayNameFa.Name = "txtDayNameFa";
            this.txtDayNameFa.ReadOnly = true;
            this.txtDayNameFa.Size = new System.Drawing.Size(79, 20);
            this.txtDayNameFa.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 297);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Add";
            // 
            // lblF1
            // 
            this.lblF1.Location = new System.Drawing.Point(12, 21);
            this.lblF1.Name = "lblF1";
            this.lblF1.Size = new System.Drawing.Size(80, 15);
            this.lblF1.TabIndex = 15;
            this.lblF1.Text = "YYYY/MM/DD";
            // 
            // gbFormat
            // 
            this.gbFormat.Controls.Add(this.lblRR);
            this.gbFormat.Controls.Add(this.cbxFD);
            this.gbFormat.Controls.Add(this.cbxFM);
            this.gbFormat.Controls.Add(this.cbxFY);
            this.gbFormat.Controls.Add(this.lblR5);
            this.gbFormat.Controls.Add(this.lblF5);
            this.gbFormat.Controls.Add(this.lblR4);
            this.gbFormat.Controls.Add(this.lblF4);
            this.gbFormat.Controls.Add(this.lblR3);
            this.gbFormat.Controls.Add(this.lblF3);
            this.gbFormat.Controls.Add(this.lblR2);
            this.gbFormat.Controls.Add(this.lblF2);
            this.gbFormat.Controls.Add(this.lblR1);
            this.gbFormat.Controls.Add(this.lblF1);
            this.gbFormat.Location = new System.Drawing.Point(12, 77);
            this.gbFormat.Name = "gbFormat";
            this.gbFormat.Size = new System.Drawing.Size(236, 188);
            this.gbFormat.TabIndex = 17;
            this.gbFormat.TabStop = false;
            this.gbFormat.Text = "ToString Formating";
            // 
            // lblRR
            // 
            this.lblRR.Location = new System.Drawing.Point(9, 151);
            this.lblRR.Name = "lblRR";
            this.lblRR.Size = new System.Drawing.Size(203, 15);
            this.lblRR.TabIndex = 28;
            this.lblRR.Text = "label2";
            this.lblRR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxFD
            // 
            this.cbxFD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFD.FormattingEnabled = true;
            this.cbxFD.Items.AddRange(new object[] {
            "DD",
            "D",
            "WW",
            "W"});
            this.cbxFD.Location = new System.Drawing.Point(150, 124);
            this.cbxFD.Name = "cbxFD";
            this.cbxFD.Size = new System.Drawing.Size(66, 21);
            this.cbxFD.TabIndex = 27;
            this.cbxFD.SelectedIndexChanged += new System.EventHandler(this.cbxFD_SelectedIndexChanged);
            // 
            // cbxFM
            // 
            this.cbxFM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFM.FormattingEnabled = true;
            this.cbxFM.Items.AddRange(new object[] {
            "MM",
            "M",
            "NN",
            "N"});
            this.cbxFM.Location = new System.Drawing.Point(78, 124);
            this.cbxFM.Name = "cbxFM";
            this.cbxFM.Size = new System.Drawing.Size(66, 21);
            this.cbxFM.TabIndex = 26;
            this.cbxFM.SelectedIndexChanged += new System.EventHandler(this.cbxFM_SelectedIndexChanged);
            // 
            // cbxFY
            // 
            this.cbxFY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFY.FormattingEnabled = true;
            this.cbxFY.Items.AddRange(new object[] {
            "YYYY",
            "YY",
            "Y"});
            this.cbxFY.Location = new System.Drawing.Point(6, 124);
            this.cbxFY.Name = "cbxFY";
            this.cbxFY.Size = new System.Drawing.Size(66, 21);
            this.cbxFY.TabIndex = 25;
            this.cbxFY.SelectedIndexChanged += new System.EventHandler(this.cbxFY_SelectedIndexChanged);
            // 
            // lblR5
            // 
            this.lblR5.Location = new System.Drawing.Point(98, 81);
            this.lblR5.Name = "lblR5";
            this.lblR5.Size = new System.Drawing.Size(130, 15);
            this.lblR5.TabIndex = 24;
            this.lblR5.Text = "label2";
            // 
            // lblF5
            // 
            this.lblF5.Location = new System.Drawing.Point(12, 81);
            this.lblF5.Name = "lblF5";
            this.lblF5.Size = new System.Drawing.Size(80, 15);
            this.lblF5.TabIndex = 23;
            this.lblF5.Text = "YY/N/W";
            // 
            // lblR4
            // 
            this.lblR4.Location = new System.Drawing.Point(98, 66);
            this.lblR4.Name = "lblR4";
            this.lblR4.Size = new System.Drawing.Size(130, 15);
            this.lblR4.TabIndex = 22;
            this.lblR4.Text = "label2";
            // 
            // lblF4
            // 
            this.lblF4.Location = new System.Drawing.Point(12, 66);
            this.lblF4.Name = "lblF4";
            this.lblF4.Size = new System.Drawing.Size(80, 15);
            this.lblF4.TabIndex = 21;
            this.lblF4.Text = "YYYY/NN/WW";
            // 
            // lblR3
            // 
            this.lblR3.Location = new System.Drawing.Point(98, 51);
            this.lblR3.Name = "lblR3";
            this.lblR3.Size = new System.Drawing.Size(130, 15);
            this.lblR3.TabIndex = 20;
            this.lblR3.Text = "label2";
            // 
            // lblF3
            // 
            this.lblF3.Location = new System.Drawing.Point(12, 51);
            this.lblF3.Name = "lblF3";
            this.lblF3.Size = new System.Drawing.Size(80, 15);
            this.lblF3.TabIndex = 19;
            this.lblF3.Text = "YY/M/D";
            // 
            // lblR2
            // 
            this.lblR2.Location = new System.Drawing.Point(98, 36);
            this.lblR2.Name = "lblR2";
            this.lblR2.Size = new System.Drawing.Size(130, 15);
            this.lblR2.TabIndex = 18;
            this.lblR2.Text = "label2";
            // 
            // lblF2
            // 
            this.lblF2.Location = new System.Drawing.Point(12, 36);
            this.lblF2.Name = "lblF2";
            this.lblF2.Size = new System.Drawing.Size(80, 15);
            this.lblF2.TabIndex = 17;
            this.lblF2.Text = "YY/MM/DD";
            // 
            // lblR1
            // 
            this.lblR1.Location = new System.Drawing.Point(98, 21);
            this.lblR1.Name = "lblR1";
            this.lblR1.Size = new System.Drawing.Size(130, 15);
            this.lblR1.TabIndex = 16;
            this.lblR1.Text = "label2";
            // 
            // btnToDate
            // 
            this.btnToDate.Direction = SMAH1.Forms.Clickable.ButtonDirection.ArrowDirection.Left;
            this.btnToDate.Location = new System.Drawing.Point(144, 10);
            this.btnToDate.Name = "btnToDate";
            this.btnToDate.Padding = new System.Windows.Forms.Padding(3);
            this.btnToDate.Size = new System.Drawing.Size(21, 23);
            this.btnToDate.TabIndex = 13;
            this.btnToDate.UseVisualStyleBackColor = true;
            this.btnToDate.Click += new System.EventHandler(this.btnToDate_Click);
            // 
            // btnToInt
            // 
            this.btnToInt.Direction = SMAH1.Forms.Clickable.ButtonDirection.ArrowDirection.Right;
            this.btnToInt.Location = new System.Drawing.Point(97, 10);
            this.btnToInt.Name = "btnToInt";
            this.btnToInt.Padding = new System.Windows.Forms.Padding(3);
            this.btnToInt.Size = new System.Drawing.Size(21, 23);
            this.btnToInt.TabIndex = 12;
            this.btnToInt.UseVisualStyleBackColor = true;
            this.btnToInt.Click += new System.EventHandler(this.btnToInt_Click);
            // 
            // txtNumAdd
            // 
            this.txtNumAdd.Location = new System.Drawing.Point(44, 294);
            this.txtNumAdd.Name = "txtNumAdd";
            this.txtNumAdd.Separator = ",";
            this.txtNumAdd.Size = new System.Drawing.Size(75, 20);
            this.txtNumAdd.TabIndex = 4;
            this.txtNumAdd.Text = "0";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(171, 12);
            this.txtNum.Name = "txtNum";
            this.txtNum.Separator = ",";
            this.txtNum.Size = new System.Drawing.Size(79, 20);
            this.txtNum.TabIndex = 3;
            this.txtNum.Text = "0";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(12, 12);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(79, 20);
            this.txtDate.TabIndex = 0;
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            // 
            // DateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 344);
            this.Controls.Add(this.gbFormat);
            this.Controls.Add(this.btnToDate);
            this.Controls.Add(this.btnToInt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDayNameFa);
            this.Controls.Add(this.txtDayNameEn);
            this.Controls.Add(this.btnAddWeek);
            this.Controls.Add(this.btnAddYear);
            this.Controls.Add(this.btnAddMonth);
            this.Controls.Add(this.btnAddDay);
            this.Controls.Add(this.txtNumAdd);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.txtDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DateForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DateForm";
            this.Load += new System.EventHandler(this.DateForm_Load);
            this.gbFormat.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SMAH1.Forms.Text.Persian.TextBoxPersianDate txtDate;
        private SMAH1.Forms.Text.TextBoxNumeric txtNum;
        private SMAH1.Forms.Text.TextBoxNumeric txtNumAdd;
        private System.Windows.Forms.Button btnAddDay;
        private System.Windows.Forms.Button btnAddMonth;
        private System.Windows.Forms.Button btnAddYear;
        private System.Windows.Forms.Button btnAddWeek;
        private System.Windows.Forms.TextBox txtDayNameEn;
        private System.Windows.Forms.TextBox txtDayNameFa;
        private System.Windows.Forms.Label label1;
        private SMAH1.Forms.Clickable.ButtonDirection btnToInt;
        private SMAH1.Forms.Clickable.ButtonDirection btnToDate;
        private System.Windows.Forms.Label lblF1;
        private System.Windows.Forms.GroupBox gbFormat;
        private System.Windows.Forms.Label lblR1;
        private System.Windows.Forms.Label lblR5;
        private System.Windows.Forms.Label lblF5;
        private System.Windows.Forms.Label lblR4;
        private System.Windows.Forms.Label lblF4;
        private System.Windows.Forms.Label lblR3;
        private System.Windows.Forms.Label lblF3;
        private System.Windows.Forms.Label lblR2;
        private System.Windows.Forms.Label lblF2;
        private System.Windows.Forms.Label lblRR;
        private System.Windows.Forms.ComboBox cbxFD;
        private System.Windows.Forms.ComboBox cbxFM;
        private System.Windows.Forms.ComboBox cbxFY;
    }
}