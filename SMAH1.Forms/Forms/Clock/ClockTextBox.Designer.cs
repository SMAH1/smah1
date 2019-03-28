namespace SMAH1.Forms.Clock
{
    partial class ClockTextBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ClockTextBox
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.MinimumSize = new System.Drawing.Size(50, 21);
            this.Size = new System.Drawing.Size(195, 21);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ClockTextBox_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ClockTextBox_KeyPress);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ClockTextBox_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
