namespace HowToWork
{
    partial class SmartTextBoxForm
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
            this.btnSet = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.smartTextBox1 = new SMAH1.Forms.Text.SmartTextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(101, 20);
            this.textBox1.TabIndex = 11;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(118, 12);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(70, 23);
            this.btnSet.TabIndex = 10;
            this.btnSet.Text = "==>";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.BtnSet_Click);
            // 
            // lbl1
            // 
            this.lbl1.Location = new System.Drawing.Point(8, 46);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(104, 149);
            this.lbl1.TabIndex = 12;
            this.lbl1.Text = "label1";
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(191, 46);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(104, 149);
            this.lbl2.TabIndex = 13;
            this.lbl2.Text = "label2";
            // 
            // smartTextBox1
            // 
            this.smartTextBox1.Location = new System.Drawing.Point(194, 12);
            this.smartTextBox1.Name = "smartTextBox1";
            this.smartTextBox1.Regex = "\\d*";
            this.smartTextBox1.Size = new System.Drawing.Size(101, 20);
            this.smartTextBox1.TabIndex = 9;
            // 
            // SmartTextBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 204);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.smartTextBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SmartTextBoxForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartTextBox Test Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSet;
        private SMAH1.Forms.Text.SmartTextBox smartTextBox1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
    }
}