namespace HowToWork
{
    partial class DatePickerTestForm
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
            this.btnSetUp = new System.Windows.Forms.Button();
            this.lblDate12 = new System.Windows.Forms.Label();
            this.lblDate11 = new System.Windows.Forms.Label();
            this.button4btnChkOpt = new System.Windows.Forms.Button();
            this.lblDate22 = new System.Windows.Forms.Label();
            this.lblDate21 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.btnTryParse = new System.Windows.Forms.Button();
            this.chbxAllowEmpty = new System.Windows.Forms.CheckBox();
            this.datePickerComplete1 = new SMAH1.Forms.Text.Persian.DatePickerComplete();
            this.datePicker3 = new SMAH1.Forms.Text.Persian.DatePicker();
            this.datePicker2 = new SMAH1.Forms.Text.Persian.DatePicker();
            this.datePicker1 = new SMAH1.Forms.Text.Persian.DatePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSetUp
            // 
            this.btnSetUp.Location = new System.Drawing.Point(119, 12);
            this.btnSetUp.Name = "btnSetUp";
            this.btnSetUp.Size = new System.Drawing.Size(89, 23);
            this.btnSetUp.TabIndex = 28;
            this.btnSetUp.Text = "<==";
            this.btnSetUp.UseVisualStyleBackColor = true;
            this.btnSetUp.Click += new System.EventHandler(this.BtnSetUp_Click);
            // 
            // lblDate12
            // 
            this.lblDate12.AutoSize = true;
            this.lblDate12.Location = new System.Drawing.Point(12, 73);
            this.lblDate12.Name = "lblDate12";
            this.lblDate12.Size = new System.Drawing.Size(35, 13);
            this.lblDate12.TabIndex = 30;
            this.lblDate12.Text = "label2";
            // 
            // lblDate11
            // 
            this.lblDate11.AutoSize = true;
            this.lblDate11.Location = new System.Drawing.Point(12, 55);
            this.lblDate11.Name = "lblDate11";
            this.lblDate11.Size = new System.Drawing.Size(35, 13);
            this.lblDate11.TabIndex = 29;
            this.lblDate11.Text = "label1";
            // 
            // button4btnChkOpt
            // 
            this.button4btnChkOpt.Location = new System.Drawing.Point(119, 41);
            this.button4btnChkOpt.Name = "button4btnChkOpt";
            this.button4btnChkOpt.Size = new System.Drawing.Size(89, 23);
            this.button4btnChkOpt.TabIndex = 32;
            this.button4btnChkOpt.Text = "Check Equal";
            this.button4btnChkOpt.UseVisualStyleBackColor = true;
            this.button4btnChkOpt.Click += new System.EventHandler(this.Button4btnChkOpt_Click);
            // 
            // lblDate22
            // 
            this.lblDate22.AutoSize = true;
            this.lblDate22.Location = new System.Drawing.Point(168, 252);
            this.lblDate22.Name = "lblDate22";
            this.lblDate22.Size = new System.Drawing.Size(35, 13);
            this.lblDate22.TabIndex = 35;
            this.lblDate22.Text = "label2";
            // 
            // lblDate21
            // 
            this.lblDate21.AutoSize = true;
            this.lblDate21.Location = new System.Drawing.Point(168, 234);
            this.lblDate21.Name = "lblDate21";
            this.lblDate21.Size = new System.Drawing.Size(35, 13);
            this.lblDate21.TabIndex = 34;
            this.lblDate21.Text = "label1";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(12, 309);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(101, 20);
            this.txtDate.TabIndex = 36;
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(119, 291);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(89, 23);
            this.btnParse.TabIndex = 37;
            this.btnParse.Text = "Parse ==>";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.BtnParse_Click);
            // 
            // btnTryParse
            // 
            this.btnTryParse.Location = new System.Drawing.Point(119, 320);
            this.btnTryParse.Name = "btnTryParse";
            this.btnTryParse.Size = new System.Drawing.Size(89, 23);
            this.btnTryParse.TabIndex = 38;
            this.btnTryParse.Text = "TryParse ==>";
            this.btnTryParse.UseVisualStyleBackColor = true;
            this.btnTryParse.Click += new System.EventHandler(this.BtnTryParse_Click);
            // 
            // chbxAllowEmpty
            // 
            this.chbxAllowEmpty.AutoSize = true;
            this.chbxAllowEmpty.Checked = true;
            this.chbxAllowEmpty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxAllowEmpty.Location = new System.Drawing.Point(168, 115);
            this.chbxAllowEmpty.Name = "chbxAllowEmpty";
            this.chbxAllowEmpty.Size = new System.Drawing.Size(83, 17);
            this.chbxAllowEmpty.TabIndex = 39;
            this.chbxAllowEmpty.Text = "Allow Empty";
            this.chbxAllowEmpty.UseVisualStyleBackColor = true;
            this.chbxAllowEmpty.CheckedChanged += new System.EventHandler(this.ChbxAllowEmpty_CheckedChanged);
            // 
            // datePickerComplete1
            // 
            this.datePickerComplete1.AllowEmpty = false;
            this.datePickerComplete1.BackColor = System.Drawing.SystemColors.Window;
            this.datePickerComplete1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.datePickerComplete1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.datePickerComplete1.Location = new System.Drawing.Point(12, 115);
            this.datePickerComplete1.MaximumSize = new System.Drawing.Size(150, 150);
            this.datePickerComplete1.MinimumSize = new System.Drawing.Size(150, 150);
            this.datePickerComplete1.Name = "datePickerComplete1";
            this.datePickerComplete1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.datePickerComplete1.Size = new System.Drawing.Size(150, 150);
            this.datePickerComplete1.TabIndex = 33;
            this.datePickerComplete1.ChangeDate += new System.EventHandler(this.DatePickerComplete1_ChangeDate);
            // 
            // datePicker3
            // 
            this.datePicker3.BackColor = System.Drawing.Color.Transparent;
            this.datePicker3.Location = new System.Drawing.Point(214, 306);
            this.datePicker3.MaximumSize = new System.Drawing.Size(9999, 20);
            this.datePicker3.MinimumSize = new System.Drawing.Size(20, 20);
            this.datePicker3.Name = "datePicker3";
            this.datePicker3.Size = new System.Drawing.Size(101, 20);
            this.datePicker3.TabIndex = 27;
            // 
            // datePicker2
            // 
            this.datePicker2.BackColor = System.Drawing.Color.Transparent;
            this.datePicker2.Location = new System.Drawing.Point(214, 26);
            this.datePicker2.MaximumSize = new System.Drawing.Size(9999, 20);
            this.datePicker2.MinimumSize = new System.Drawing.Size(20, 20);
            this.datePicker2.Name = "datePicker2";
            this.datePicker2.Size = new System.Drawing.Size(101, 20);
            this.datePicker2.TabIndex = 26;
            // 
            // datePicker1
            // 
            this.datePicker1.BackColor = System.Drawing.Color.Transparent;
            this.datePicker1.Location = new System.Drawing.Point(12, 26);
            this.datePicker1.MaximumSize = new System.Drawing.Size(9999, 20);
            this.datePicker1.MinimumSize = new System.Drawing.Size(20, 20);
            this.datePicker1.Name = "datePicker1";
            this.datePicker1.Size = new System.Drawing.Size(101, 20);
            this.datePicker1.TabIndex = 25;
            this.datePicker1.SelectDate += new System.EventHandler(this.DatePicker1_SelectDate);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(13, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 3);
            this.label1.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(13, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 3);
            this.label2.TabIndex = 41;
            // 
            // DatePickerTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 363);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chbxAllowEmpty);
            this.Controls.Add(this.btnTryParse);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lblDate22);
            this.Controls.Add(this.lblDate21);
            this.Controls.Add(this.datePickerComplete1);
            this.Controls.Add(this.button4btnChkOpt);
            this.Controls.Add(this.lblDate12);
            this.Controls.Add(this.lblDate11);
            this.Controls.Add(this.btnSetUp);
            this.Controls.Add(this.datePicker3);
            this.Controls.Add(this.datePicker2);
            this.Controls.Add(this.datePicker1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DatePickerTestForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DatePicker Test";
            this.Load += new System.EventHandler(this.DatePickerTestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private SMAH1.Forms.Text.Persian.DatePicker datePicker1;
        private SMAH1.Forms.Text.Persian.DatePicker datePicker2;
        private SMAH1.Forms.Text.Persian.DatePicker datePicker3;
        private System.Windows.Forms.Button btnSetUp;
        private System.Windows.Forms.Label lblDate12;
        private System.Windows.Forms.Label lblDate11;
        private System.Windows.Forms.Button button4btnChkOpt;
        private SMAH1.Forms.Text.Persian.DatePickerComplete datePickerComplete1;
        private System.Windows.Forms.Label lblDate22;
        private System.Windows.Forms.Label lblDate21;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Button btnTryParse;
        private System.Windows.Forms.CheckBox chbxAllowEmpty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}