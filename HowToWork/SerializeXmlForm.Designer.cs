namespace HowToWork
{
    partial class SerializeXmlForm
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
            this.btnTxt2Pg = new System.Windows.Forms.Button();
            this.pg = new System.Windows.Forms.PropertyGrid();
            this.txt = new System.Windows.Forms.TextBox();
            this.btnPg2Txt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTxt2Pg
            // 
            this.btnTxt2Pg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTxt2Pg.Location = new System.Drawing.Point(468, 163);
            this.btnTxt2Pg.Name = "btnTxt2Pg";
            this.btnTxt2Pg.Size = new System.Drawing.Size(75, 23);
            this.btnTxt2Pg.TabIndex = 1;
            this.btnTxt2Pg.Text = "=>";
            this.btnTxt2Pg.UseVisualStyleBackColor = true;
            this.btnTxt2Pg.Click += new System.EventHandler(this.btnTxt2Pg_Click);
            // 
            // pg
            // 
            this.pg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pg.Location = new System.Drawing.Point(549, 12);
            this.pg.Name = "pg";
            this.pg.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pg.Size = new System.Drawing.Size(373, 477);
            this.pg.TabIndex = 3;
            this.pg.ToolbarVisible = false;
            // 
            // txt
            // 
            this.txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt.Location = new System.Drawing.Point(12, 12);
            this.txt.Multiline = true;
            this.txt.Name = "txt";
            this.txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt.Size = new System.Drawing.Size(450, 477);
            this.txt.TabIndex = 0;
            this.txt.WordWrap = false;
            // 
            // btnPg2Txt
            // 
            this.btnPg2Txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPg2Txt.Location = new System.Drawing.Point(468, 291);
            this.btnPg2Txt.Name = "btnPg2Txt";
            this.btnPg2Txt.Size = new System.Drawing.Size(75, 23);
            this.btnPg2Txt.TabIndex = 2;
            this.btnPg2Txt.Text = "<=";
            this.btnPg2Txt.UseVisualStyleBackColor = true;
            this.btnPg2Txt.Click += new System.EventHandler(this.btnPg2Txt_Click);
            // 
            // SerializeXmlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 501);
            this.Controls.Add(this.btnPg2Txt);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.pg);
            this.Controls.Add(this.btnTxt2Pg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SerializeXmlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Serialize by Custom Xml";
            this.Load += new System.EventHandler(this.SerializeXmlForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTxt2Pg;
        private System.Windows.Forms.PropertyGrid pg;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.Button btnPg2Txt;
    }
}