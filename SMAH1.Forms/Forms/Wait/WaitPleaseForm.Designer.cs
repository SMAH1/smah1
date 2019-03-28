namespace SMAH1.Forms.Wait
{
    partial class WaitPleaseForm
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
            this.loadingCtrl1 = new SMAH1.Forms.Loading.LoadingCtrl();
            this.SuspendLayout();
            // 
            // loadingCtrl1
            // 
            this.loadingCtrl1.CausesValidation = false;
            this.loadingCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadingCtrl1.Location = new System.Drawing.Point(0, 0);
            this.loadingCtrl1.Name = "loadingCtrl1";
            this.loadingCtrl1.Size = new System.Drawing.Size(135, 136);
            this.loadingCtrl1.TabIndex = 0;
            this.loadingCtrl1.Text = "Please Wait ...";
            // 
            // WaitPleaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(135, 136);
            this.Controls.Add(this.loadingCtrl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaitPleaseForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.PleaseWiatForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SMAH1.Forms.Loading.LoadingCtrl loadingCtrl1;

    }
}