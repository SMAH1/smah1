namespace SMAH1.Forms.Clickable
{
    partial class CheckedListBox
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
            this.pnlLabelsExternal = new System.Windows.Forms.Panel();
            this.pnlLabelsInternal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLabelsExternal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLabelsExternal
            // 
            this.pnlLabelsExternal.AutoScroll = true;
            this.pnlLabelsExternal.Controls.Add(this.pnlLabelsInternal);
            this.pnlLabelsExternal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLabelsExternal.Location = new System.Drawing.Point(0, 0);
            this.pnlLabelsExternal.Name = "pnlLabelsExternal";
            this.pnlLabelsExternal.Size = new System.Drawing.Size(157, 169);
            this.pnlLabelsExternal.TabIndex = 25;
            // 
            // pnlLabelsInternal
            // 
            this.pnlLabelsInternal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlLabelsInternal.ColumnCount = 1;
            this.pnlLabelsInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlLabelsInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlLabelsInternal.Location = new System.Drawing.Point(1, 1);
            this.pnlLabelsInternal.Margin = new System.Windows.Forms.Padding(1);
            this.pnlLabelsInternal.Name = "pnlLabelsInternal";
            this.pnlLabelsInternal.RowCount = 1;
            this.pnlLabelsInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlLabelsInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlLabelsInternal.Size = new System.Drawing.Size(136, 143);
            this.pnlLabelsInternal.TabIndex = 23;
            // 
            // CheckedListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLabelsExternal);
            this.Name = "CheckedListBox";
            this.Size = new System.Drawing.Size(157, 169);
            this.pnlLabelsExternal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLabelsExternal;
        private System.Windows.Forms.TableLayoutPanel pnlLabelsInternal;
    }
}
