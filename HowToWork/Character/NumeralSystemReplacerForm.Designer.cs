namespace HowToWork.Character
{
    partial class NumeralSystemReplacerForm
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
            this.cbx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chbx = new SMAH1.Forms.Clickable.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // cbx
            // 
            this.cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx.FormattingEnabled = true;
            this.cbx.Location = new System.Drawing.Point(48, 286);
            this.cbx.Name = "cbx";
            this.cbx.Size = new System.Drawing.Size(201, 21);
            this.cbx.TabIndex = 4;
            this.cbx.SelectedIndexChanged += new System.EventHandler(this.cbx_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Input";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(329, 12);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(202, 138);
            this.txtInput.TabIndex = 6;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(329, 171);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(202, 138);
            this.txtOutput.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Output";
            // 
            // chbx
            // 
            this.chbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chbx.Location = new System.Drawing.Point(48, 12);
            this.chbx.Name = "chbx";
            this.chbx.Size = new System.Drawing.Size(201, 268);
            this.chbx.TabIndex = 1;
            this.chbx.CheckedChanged += new SMAH1.Forms.Clickable.CheckedListBox.CheckedChangedEventHandler(this.chbx_CheckedChanged);
            // 
            // NumeralSystemReplacerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 321);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NumeralSystemReplacerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Numeral System Replacer";
            this.Load += new System.EventHandler(this.NumeralSystemReplacerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SMAH1.Forms.Clickable.CheckedListBox chbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label4;
    }
}