namespace SMAH1.Forms.Text.Persian
{
    partial class DatePicker
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
            this.components = new System.ComponentModel.Container();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmEmpty = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowDate = new System.Windows.Forms.Button();
            this.txtShowDate = new System.Windows.Forms.TextBox();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // cms
            // 
            this.cms.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCopy,
            this.tsmPaste,
            this.toolStripSeparator1,
            this.tsmEmpty});
            this.cms.Name = "cms";
            this.cms.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cms.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cms.ShowImageMargin = false;
            this.cms.Size = new System.Drawing.Size(97, 76);
            this.cms.Opening += new System.ComponentModel.CancelEventHandler(this.Cms_Opening);
            // 
            // tsmCopy
            // 
            this.tsmCopy.Name = "tsmCopy";
            this.tsmCopy.Size = new System.Drawing.Size(96, 22);
            this.tsmCopy.Text = "کپی";
            this.tsmCopy.Click += new System.EventHandler(this.TsmCopy_Click);
            // 
            // tsmPaste
            // 
            this.tsmPaste.Name = "tsmPaste";
            this.tsmPaste.Size = new System.Drawing.Size(96, 22);
            this.tsmPaste.Text = "چسباندن";
            this.tsmPaste.Click += new System.EventHandler(this.TsmPaste_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(93, 6);
            // 
            // tsmEmpty
            // 
            this.tsmEmpty.Name = "tsmEmpty";
            this.tsmEmpty.Size = new System.Drawing.Size(96, 22);
            this.tsmEmpty.Text = "خالی";
            this.tsmEmpty.Click += new System.EventHandler(this.TsmEmpty_Click);
            // 
            // btnShowDate
            // 
            this.btnShowDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShowDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnShowDate.Location = new System.Drawing.Point(0, 0);
            this.btnShowDate.Name = "btnShowDate";
            this.btnShowDate.Size = new System.Drawing.Size(20, 20);
            this.btnShowDate.TabIndex = 1;
            this.btnShowDate.Text = "...";
            this.btnShowDate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnShowDate.UseVisualStyleBackColor = true;
            this.btnShowDate.Click += new System.EventHandler(this.BtnShowDate_Click);
            // 
            // txtShowDate
            // 
            this.txtShowDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShowDate.Location = new System.Drawing.Point(20, 0);
            this.txtShowDate.Name = "txtShowDate";
            this.txtShowDate.Size = new System.Drawing.Size(80, 20);
            this.txtShowDate.TabIndex = 2;
            this.txtShowDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtShowDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtShowDate_KeyDown);
            this.txtShowDate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TxtShowDate_MouseUp);
            // 
            // DatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtShowDate);
            this.Controls.Add(this.btnShowDate);
            this.MaximumSize = new System.Drawing.Size(9999, 20);
            this.MinimumSize = new System.Drawing.Size(20, 20);
            this.Name = "DatePicker";
            this.Size = new System.Drawing.Size(100, 20);
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShowDate;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem tsmCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmEmpty;
        private System.Windows.Forms.TextBox txtShowDate;
    }
}
