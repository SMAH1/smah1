namespace HowToWork
{
    partial class SpliteButtonTestForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AlwaysDropDown = new System.Windows.Forms.CheckBox();
            this.AlwaysHoverChange = new System.Windows.Forms.CheckBox();
            this.PersistDropDownName = new System.Windows.Forms.CheckBox();
            this.splitButton1 = new SMAH1.Forms.Clickable.SplitButton();
            this.chbxRTL = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 129);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 262);
            this.textBox1.TabIndex = 2;
            // 
            // AlwaysDropDown
            // 
            this.AlwaysDropDown.AutoSize = true;
            this.AlwaysDropDown.Location = new System.Drawing.Point(12, 12);
            this.AlwaysDropDown.Name = "AlwaysDropDown";
            this.AlwaysDropDown.Size = new System.Drawing.Size(110, 17);
            this.AlwaysDropDown.TabIndex = 4;
            this.AlwaysDropDown.Text = "AlwaysDropDown";
            this.AlwaysDropDown.UseVisualStyleBackColor = true;
            this.AlwaysDropDown.CheckedChanged += new System.EventHandler(this.AlwaysDropDown_CheckedChanged);
            // 
            // AlwaysHoverChange
            // 
            this.AlwaysHoverChange.AutoSize = true;
            this.AlwaysHoverChange.Location = new System.Drawing.Point(12, 36);
            this.AlwaysHoverChange.Name = "AlwaysHoverChange";
            this.AlwaysHoverChange.Size = new System.Drawing.Size(125, 17);
            this.AlwaysHoverChange.TabIndex = 5;
            this.AlwaysHoverChange.Text = "AlwaysHoverChange";
            this.AlwaysHoverChange.UseVisualStyleBackColor = true;
            this.AlwaysHoverChange.CheckedChanged += new System.EventHandler(this.AlwaysHoverChange_CheckedChanged);
            // 
            // PersistDropDownName
            // 
            this.PersistDropDownName.AutoSize = true;
            this.PersistDropDownName.Location = new System.Drawing.Point(12, 60);
            this.PersistDropDownName.Name = "PersistDropDownName";
            this.PersistDropDownName.Size = new System.Drawing.Size(136, 17);
            this.PersistDropDownName.TabIndex = 6;
            this.PersistDropDownName.Text = "PersistDropDownName";
            this.PersistDropDownName.UseVisualStyleBackColor = true;
            this.PersistDropDownName.CheckedChanged += new System.EventHandler(this.PersistDropDownName_CheckedChanged);
            // 
            // splitButton1
            // 
            this.splitButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.splitButton1.ImageKey = "Normal";
            this.splitButton1.Location = new System.Drawing.Point(12, 397);
            this.splitButton1.Name = "splitButton1";
            this.splitButton1.Size = new System.Drawing.Size(268, 29);
            this.splitButton1.TabIndex = 0;
            this.splitButton1.Text = "splitButton1";
            this.splitButton1.UseVisualStyleBackColor = true;
            this.splitButton1.ButtonClick += new System.EventHandler(this.splitButton1_ButtonClick);
            this.splitButton1.Click += new System.EventHandler(this.splitButton1_Click);
            this.splitButton1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitButton1_MouseDown);
            this.splitButton1.MouseEnter += new System.EventHandler(this.splitButton1_MouseEnter);
            this.splitButton1.MouseLeave += new System.EventHandler(this.splitButton1_MouseLeave);
            this.splitButton1.MouseHover += new System.EventHandler(this.splitButton1_MouseHover);
            this.splitButton1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitButton1_MouseUp);
            // 
            // chbxRTL
            // 
            this.chbxRTL.AutoSize = true;
            this.chbxRTL.Location = new System.Drawing.Point(12, 83);
            this.chbxRTL.Name = "chbxRTL";
            this.chbxRTL.Size = new System.Drawing.Size(88, 17);
            this.chbxRTL.TabIndex = 7;
            this.chbxRTL.Text = "Right To Left";
            this.chbxRTL.UseVisualStyleBackColor = true;
            this.chbxRTL.CheckedChanged += new System.EventHandler(this.chbxRTL_CheckedChanged);
            // 
            // SpliteButtonTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 438);
            this.Controls.Add(this.chbxRTL);
            this.Controls.Add(this.PersistDropDownName);
            this.Controls.Add(this.AlwaysHoverChange);
            this.Controls.Add(this.AlwaysDropDown);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.splitButton1);
            this.Name = "SpliteButtonTestForm";
            this.Text = "SplitButton Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SMAH1.Forms.Clickable.SplitButton splitButton1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox AlwaysDropDown;
        private System.Windows.Forms.CheckBox AlwaysHoverChange;
        private System.Windows.Forms.CheckBox PersistDropDownName;
        private System.Windows.Forms.CheckBox chbxRTL;
    }
}

