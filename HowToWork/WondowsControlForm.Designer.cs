namespace HowToWork
{
    partial class WondowsControlForm
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
            this.cbxNumberType = new System.Windows.Forms.ComboBox();
            this.chbxBtnArrow = new System.Windows.Forms.CheckBox();
            this.cbxButtonArrowType = new System.Windows.Forms.ComboBox();
            this.lbl3State = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblHourSelected = new System.Windows.Forms.Label();
            this.hourSelector1 = new SMAH1.Forms.Clock.HourSelector();
            this.radioButtonImage2 = new SMAH1.Forms.Clickable.RadioButtonImage();
            this.radioButtonImage1 = new SMAH1.Forms.Clickable.RadioButtonImage();
            this.chbxText = new SMAH1.Forms.Clickable.CheckBox3State();
            this.buttonWithArrow4 = new SMAH1.Forms.Clickable.ButtonDirection();
            this.buttonWithArrow3 = new SMAH1.Forms.Clickable.ButtonDirection();
            this.buttonWithArrow2 = new SMAH1.Forms.Clickable.ButtonDirection();
            this.buttonWithArrow1 = new SMAH1.Forms.Clickable.ButtonDirection();
            this.txtNumFormat = new SMAH1.Forms.Text.TextBoxNumeric();
            this.numButtonDIrectionPadding = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numButtonDIrectionPadding)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxNumberType
            // 
            this.cbxNumberType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNumberType.FormattingEnabled = true;
            this.cbxNumberType.Location = new System.Drawing.Point(193, 12);
            this.cbxNumberType.Name = "cbxNumberType";
            this.cbxNumberType.Size = new System.Drawing.Size(146, 21);
            this.cbxNumberType.TabIndex = 1;
            this.cbxNumberType.SelectedIndexChanged += new System.EventHandler(this.cbxNumberType_SelectedIndexChanged);
            // 
            // chbxBtnArrow
            // 
            this.chbxBtnArrow.AutoSize = true;
            this.chbxBtnArrow.Location = new System.Drawing.Point(12, 102);
            this.chbxBtnArrow.Name = "chbxBtnArrow";
            this.chbxBtnArrow.Size = new System.Drawing.Size(59, 17);
            this.chbxBtnArrow.TabIndex = 6;
            this.chbxBtnArrow.Text = "Enable";
            this.chbxBtnArrow.UseVisualStyleBackColor = true;
            this.chbxBtnArrow.CheckedChanged += new System.EventHandler(this.chbxBtnArrow_CheckedChanged);
            // 
            // cbxButtonArrowType
            // 
            this.cbxButtonArrowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxButtonArrowType.FormattingEnabled = true;
            this.cbxButtonArrowType.Location = new System.Drawing.Point(258, 71);
            this.cbxButtonArrowType.Name = "cbxButtonArrowType";
            this.cbxButtonArrowType.Size = new System.Drawing.Size(83, 21);
            this.cbxButtonArrowType.TabIndex = 7;
            this.cbxButtonArrowType.SelectedIndexChanged += new System.EventHandler(this.cbxButtonArrowType_SelectedIndexChanged);
            // 
            // lbl3State
            // 
            this.lbl3State.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl3State.Location = new System.Drawing.Point(152, 170);
            this.lbl3State.Name = "lbl3State";
            this.lbl3State.Size = new System.Drawing.Size(64, 17);
            this.lbl3State.TabIndex = 9;
            this.lbl3State.Text = "lbl3State";
            this.lbl3State.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonImage2);
            this.groupBox1.Controls.Add(this.radioButtonImage1);
            this.groupBox1.Location = new System.Drawing.Point(240, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 57);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Radio Buttons";
            // 
            // lblHourSelected
            // 
            this.lblHourSelected.Location = new System.Drawing.Point(14, 370);
            this.lblHourSelected.Name = "lblHourSelected";
            this.lblHourSelected.Size = new System.Drawing.Size(325, 23);
            this.lblHourSelected.TabIndex = 13;
            this.lblHourSelected.Text = "Hour Selected";
            this.lblHourSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hourSelector1
            // 
            this.hourSelector1.BackColor = System.Drawing.SystemColors.Control;
            this.hourSelector1.Location = new System.Drawing.Point(12, 228);
            this.hourSelector1.MinimumSize = new System.Drawing.Size(148, 139);
            this.hourSelector1.Name = "hourSelector1";
            this.hourSelector1.Size = new System.Drawing.Size(327, 139);
            this.hourSelector1.TabIndex = 12;
            this.hourSelector1.StateClockChange += new SMAH1.Forms.Clock.HourSelector.StateClockChangeEvent(this.hourSelector1_StateClockChange);
            // 
            // radioButtonImage2
            // 
            this.radioButtonImage2.AutoSize = true;
            this.radioButtonImage2.Image = global::HowToWork.Properties.Resources.Save16X16;
            this.radioButtonImage2.Location = new System.Drawing.Point(53, 19);
            this.radioButtonImage2.Name = "radioButtonImage2";
            this.radioButtonImage2.Size = new System.Drawing.Size(26, 26);
            this.radioButtonImage2.TabIndex = 11;
            this.radioButtonImage2.TabStop = true;
            this.radioButtonImage2.Text = "radioButtonImage2";
            this.radioButtonImage2.UseVisualStyleBackColor = true;
            // 
            // radioButtonImage1
            // 
            this.radioButtonImage1.AutoSize = true;
            this.radioButtonImage1.Image = global::HowToWork.Properties.Resources.Open16X16;
            this.radioButtonImage1.Location = new System.Drawing.Point(21, 19);
            this.radioButtonImage1.Name = "radioButtonImage1";
            this.radioButtonImage1.Size = new System.Drawing.Size(26, 26);
            this.radioButtonImage1.TabIndex = 10;
            this.radioButtonImage1.TabStop = true;
            this.radioButtonImage1.Text = "radioButtonImage1";
            this.radioButtonImage1.UseVisualStyleBackColor = true;
            // 
            // chbxText
            // 
            this.chbxText.AutoCheck = false;
            this.chbxText.AutoSize = true;
            this.chbxText.Location = new System.Drawing.Point(17, 172);
            this.chbxText.Name = "chbxText";
            this.chbxText.Size = new System.Drawing.Size(112, 17);
            this.chbxText.TabIndex = 8;
            this.chbxText.Text = "3 State CheckBox";
            this.chbxText.UseVisualStyleBackColor = true;
            this.chbxText.CheckStateChanged += new System.EventHandler(this.chbxText_CheckStateChanged);
            // 
            // buttonWithArrow4
            // 
            this.buttonWithArrow4.Direction = SMAH1.Forms.Clickable.ButtonDirection.ArrowDirection.Right;
            this.buttonWithArrow4.Location = new System.Drawing.Point(135, 67);
            this.buttonWithArrow4.Name = "buttonWithArrow4";
            this.buttonWithArrow4.Size = new System.Drawing.Size(35, 26);
            this.buttonWithArrow4.TabIndex = 5;
            this.buttonWithArrow4.Type = SMAH1.Forms.Clickable.ButtonDirection.ArrowType.Triangle;
            this.buttonWithArrow4.UseVisualStyleBackColor = true;
            // 
            // buttonWithArrow3
            // 
            this.buttonWithArrow3.Direction = SMAH1.Forms.Clickable.ButtonDirection.ArrowDirection.Left;
            this.buttonWithArrow3.Location = new System.Drawing.Point(94, 67);
            this.buttonWithArrow3.Name = "buttonWithArrow3";
            this.buttonWithArrow3.Size = new System.Drawing.Size(35, 26);
            this.buttonWithArrow3.TabIndex = 4;
            this.buttonWithArrow3.Type = SMAH1.Forms.Clickable.ButtonDirection.ArrowType.Triangle;
            this.buttonWithArrow3.UseVisualStyleBackColor = true;
            // 
            // buttonWithArrow2
            // 
            this.buttonWithArrow2.Direction = SMAH1.Forms.Clickable.ButtonDirection.ArrowDirection.Down;
            this.buttonWithArrow2.Location = new System.Drawing.Point(53, 67);
            this.buttonWithArrow2.Name = "buttonWithArrow2";
            this.buttonWithArrow2.Size = new System.Drawing.Size(35, 26);
            this.buttonWithArrow2.TabIndex = 3;
            this.buttonWithArrow2.Type = SMAH1.Forms.Clickable.ButtonDirection.ArrowType.Triangle;
            this.buttonWithArrow2.UseVisualStyleBackColor = true;
            // 
            // buttonWithArrow1
            // 
            this.buttonWithArrow1.Location = new System.Drawing.Point(12, 67);
            this.buttonWithArrow1.Name = "buttonWithArrow1";
            this.buttonWithArrow1.Size = new System.Drawing.Size(35, 26);
            this.buttonWithArrow1.TabIndex = 2;
            this.buttonWithArrow1.Type = SMAH1.Forms.Clickable.ButtonDirection.ArrowType.Triangle;
            this.buttonWithArrow1.UseVisualStyleBackColor = true;
            // 
            // txtNumFormat
            // 
            this.txtNumFormat.Location = new System.Drawing.Point(12, 12);
            this.txtNumFormat.Name = "txtNumFormat";
            this.txtNumFormat.Separator = ",";
            this.txtNumFormat.Size = new System.Drawing.Size(175, 20);
            this.txtNumFormat.TabIndex = 0;
            this.txtNumFormat.Text = "0";
            // 
            // numButtonDIrectionPadding
            // 
            this.numButtonDIrectionPadding.Location = new System.Drawing.Point(77, 99);
            this.numButtonDIrectionPadding.Name = "numButtonDIrectionPadding";
            this.numButtonDIrectionPadding.Size = new System.Drawing.Size(93, 20);
            this.numButtonDIrectionPadding.TabIndex = 14;
            this.numButtonDIrectionPadding.ValueChanged += new System.EventHandler(this.numButtonDIrectionPadding_ValueChanged);
            // 
            // WondowsControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 405);
            this.Controls.Add(this.numButtonDIrectionPadding);
            this.Controls.Add(this.lblHourSelected);
            this.Controls.Add(this.hourSelector1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl3State);
            this.Controls.Add(this.chbxText);
            this.Controls.Add(this.cbxButtonArrowType);
            this.Controls.Add(this.chbxBtnArrow);
            this.Controls.Add(this.buttonWithArrow4);
            this.Controls.Add(this.buttonWithArrow3);
            this.Controls.Add(this.buttonWithArrow2);
            this.Controls.Add(this.buttonWithArrow1);
            this.Controls.Add(this.cbxNumberType);
            this.Controls.Add(this.txtNumFormat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WondowsControlForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Wondows Control";
            this.Load += new System.EventHandler(this.WondowsControlForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numButtonDIrectionPadding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SMAH1.Forms.Text.TextBoxNumeric txtNumFormat;
        private System.Windows.Forms.ComboBox cbxNumberType;
        private SMAH1.Forms.Clickable.ButtonDirection buttonWithArrow1;
        private SMAH1.Forms.Clickable.ButtonDirection buttonWithArrow2;
        private SMAH1.Forms.Clickable.ButtonDirection buttonWithArrow3;
        private SMAH1.Forms.Clickable.ButtonDirection buttonWithArrow4;
        private System.Windows.Forms.CheckBox chbxBtnArrow;
        private System.Windows.Forms.ComboBox cbxButtonArrowType;
        private SMAH1.Forms.Clickable.CheckBox3State chbxText;
        private System.Windows.Forms.Label lbl3State;
        private SMAH1.Forms.Clickable.RadioButtonImage radioButtonImage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private SMAH1.Forms.Clickable.RadioButtonImage radioButtonImage2;
        private SMAH1.Forms.Clock.HourSelector hourSelector1;
        private System.Windows.Forms.Label lblHourSelected;
        private System.Windows.Forms.NumericUpDown numButtonDIrectionPadding;
    }
}