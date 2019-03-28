namespace HowToWork
{
    partial class FaNumberForm
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
            this.btnToFa = new System.Windows.Forms.Button();
            this.txtNumEn = new SMAH1.Forms.Text.TextBoxNumeric();
            this.txtNumFa = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnToFa
            // 
            this.btnToFa.Location = new System.Drawing.Point(118, 14);
            this.btnToFa.Name = "btnToFa";
            this.btnToFa.Size = new System.Drawing.Size(36, 23);
            this.btnToFa.TabIndex = 5;
            this.btnToFa.Text = "==>";
            this.btnToFa.UseVisualStyleBackColor = true;
            this.btnToFa.Click += new System.EventHandler(this.btnToFa_Click);
            // 
            // txtNumEn
            // 
            this.txtNumEn.DiscreteNumeric = true;
            this.txtNumEn.Location = new System.Drawing.Point(12, 16);
            this.txtNumEn.Name = "txtNumEn";
            this.txtNumEn.Separator = ",";
            this.txtNumEn.Size = new System.Drawing.Size(100, 20);
            this.txtNumEn.TabIndex = 7;
            this.txtNumEn.Text = "120345";
            // 
            // txtNumFa
            // 
            this.txtNumFa.Location = new System.Drawing.Point(160, 16);
            this.txtNumFa.Name = "txtNumFa";
            this.txtNumFa.ReadOnly = true;
            this.txtNumFa.Size = new System.Drawing.Size(100, 20);
            this.txtNumFa.TabIndex = 8;
            // 
            // FaNumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 51);
            this.Controls.Add(this.txtNumFa);
            this.Controls.Add(this.btnToFa);
            this.Controls.Add(this.txtNumEn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FaNumberForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FaNumberForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToFa;
        private SMAH1.Forms.Text.TextBoxNumeric txtNumEn;
        private System.Windows.Forms.TextBox txtNumFa;
    }
}