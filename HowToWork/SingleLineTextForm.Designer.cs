namespace HowToWork
{
    partial class SingleLineTextForm
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
            this.chbxAreaLine = new System.Windows.Forms.CheckBox();
            this.chbxFixedHeight = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chbxAreaLine
            // 
            this.chbxAreaLine.AutoSize = true;
            this.chbxAreaLine.Checked = true;
            this.chbxAreaLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxAreaLine.Location = new System.Drawing.Point(12, 12);
            this.chbxAreaLine.Name = "chbxAreaLine";
            this.chbxAreaLine.Size = new System.Drawing.Size(94, 17);
            this.chbxAreaLine.TabIndex = 0;
            this.chbxAreaLine.Text = "Draw area line";
            this.chbxAreaLine.UseVisualStyleBackColor = true;
            this.chbxAreaLine.CheckedChanged += new System.EventHandler(this.chbx_CheckedChanged);
            // 
            // chbxFixedHeight
            // 
            this.chbxFixedHeight.AutoSize = true;
            this.chbxFixedHeight.Checked = true;
            this.chbxFixedHeight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxFixedHeight.Location = new System.Drawing.Point(160, 12);
            this.chbxFixedHeight.Name = "chbxFixedHeight";
            this.chbxFixedHeight.Size = new System.Drawing.Size(85, 17);
            this.chbxFixedHeight.TabIndex = 1;
            this.chbxFixedHeight.Text = "Fixed Height";
            this.chbxFixedHeight.UseVisualStyleBackColor = true;
            this.chbxFixedHeight.CheckedChanged += new System.EventHandler(this.chbx_CheckedChanged);
            // 
            // SingleLineTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 216);
            this.Controls.Add(this.chbxFixedHeight);
            this.Controls.Add(this.chbxAreaLine);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SingleLineTextForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Text Formated";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SingleLineTextForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbxAreaLine;
        private System.Windows.Forms.CheckBox chbxFixedHeight;
    }
}