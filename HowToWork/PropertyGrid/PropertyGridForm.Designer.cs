namespace HowToWork
{
    partial class PropertyGridForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripSystemRenderer toolStripSystemRenderer1 = new System.Windows.Forms.ToolStripSystemRenderer();
            this.label1 = new System.Windows.Forms.Label();
            this.txt = new System.Windows.Forms.TextBox();
            this.pg = new SMAH1.Forms.PropertyGridEx.PropertyGridMinEx();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add button in PropertyGrid\r\nUse custom component for edit values";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(15, 369);
            this.txt.Multiline = true;
            this.txt.Name = "txt";
            this.txt.ReadOnly = true;
            this.txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt.Size = new System.Drawing.Size(247, 137);
            this.txt.TabIndex = 1;
            this.txt.WordWrap = false;
            // 
            // pg
            // 
            // 
            // 
            // 
            this.pg.DocCommentDescription.AutoEllipsis = true;
            this.pg.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.pg.DocCommentDescription.Location = new System.Drawing.Point(3, 18);
            this.pg.DocCommentDescription.Name = "";
            this.pg.DocCommentDescription.Size = new System.Drawing.Size(244, 37);
            this.pg.DocCommentDescription.TabIndex = 1;
            this.pg.DocCommentImage = null;
            // 
            // 
            // 
            this.pg.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.pg.DocCommentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.pg.DocCommentTitle.Location = new System.Drawing.Point(3, 3);
            this.pg.DocCommentTitle.Name = "";
            this.pg.DocCommentTitle.Size = new System.Drawing.Size(244, 15);
            this.pg.DocCommentTitle.TabIndex = 0;
            this.pg.DocCommentTitle.UseMnemonic = false;
            this.pg.Location = new System.Drawing.Point(12, 75);
            this.pg.Name = "pg";
            this.pg.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pg.Size = new System.Drawing.Size(250, 288);
            this.pg.TabIndex = 2;
            // 
            // 
            // 
            this.pg.ToolStrip.AccessibleName = "ToolBar";
            this.pg.ToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.pg.ToolStrip.AllowMerge = false;
            this.pg.ToolStrip.AutoSize = false;
            this.pg.ToolStrip.CanOverflow = false;
            this.pg.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.pg.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.pg.ToolStrip.Location = new System.Drawing.Point(0, 1);
            this.pg.ToolStrip.Name = "";
            this.pg.ToolStrip.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.pg.ToolStrip.Size = new System.Drawing.Size(250, 25);
            this.pg.ToolStrip.TabIndex = 1;
            this.pg.ToolStrip.TabStop = true;
            this.pg.ToolStrip.Text = "PropertyGridToolBar";
            this.pg.ToolStripRendererEx = toolStripSystemRenderer1;
            // 
            // PropertyGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 518);
            this.Controls.Add(this.pg);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertyGridForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Property Grid";
            this.Load += new System.EventHandler(this.PropertyGridComponentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt;
        private SMAH1.Forms.PropertyGridEx.PropertyGridMinEx pg;
    }
}