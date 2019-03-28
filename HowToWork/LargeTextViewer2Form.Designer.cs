namespace HowToWork
{
    partial class LargeTextViewer2Form
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
            this.ltvRes = new SMAH1.Forms.Text.LargeTextViewer();
            this.ltv2 = new SMAH1.Forms.Text.LargeTextViewer();
            this.ltv1 = new SMAH1.Forms.Text.LargeTextViewer();
            this.btnScrollToEnd = new System.Windows.Forms.Button();
            this.btnScrollToSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ltvRes
            // 
            this.ltvRes.AutoScroll = true;
            this.ltvRes.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.ltvRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ltvRes.Location = new System.Drawing.Point(12, 361);
            this.ltvRes.Name = "ltvRes";
            this.ltvRes.SelectedBackColor = System.Drawing.Color.Transparent;
            this.ltvRes.Size = new System.Drawing.Size(732, 61);
            this.ltvRes.TabIndex = 2;
            // 
            // ltv2
            // 
            this.ltv2.AutoScroll = true;
            this.ltv2.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.ltv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ltv2.Location = new System.Drawing.Point(439, 12);
            this.ltv2.Name = "ltv2";
            this.ltv2.SelectedBackColor = System.Drawing.Color.Transparent;
            this.ltv2.Size = new System.Drawing.Size(422, 343);
            this.ltv2.TabIndex = 1;
            // 
            // ltv1
            // 
            this.ltv1.AutoScroll = true;
            this.ltv1.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.ltv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ltv1.Location = new System.Drawing.Point(9, 12);
            this.ltv1.Name = "ltv1";
            this.ltv1.SelectedBackColor = System.Drawing.Color.Transparent;
            this.ltv1.Size = new System.Drawing.Size(422, 343);
            this.ltv1.TabIndex = 0;
            // 
            // btnScrollToEnd
            // 
            this.btnScrollToEnd.Location = new System.Drawing.Point(750, 361);
            this.btnScrollToEnd.Name = "btnScrollToEnd";
            this.btnScrollToEnd.Size = new System.Drawing.Size(111, 28);
            this.btnScrollToEnd.TabIndex = 3;
            this.btnScrollToEnd.Text = "Scroll to end";
            this.btnScrollToEnd.UseVisualStyleBackColor = true;
            this.btnScrollToEnd.Click += new System.EventHandler(this.btnScrollToEnd_Click);
            // 
            // btnScrollToSelect
            // 
            this.btnScrollToSelect.Location = new System.Drawing.Point(750, 395);
            this.btnScrollToSelect.Name = "btnScrollToSelect";
            this.btnScrollToSelect.Size = new System.Drawing.Size(111, 28);
            this.btnScrollToSelect.TabIndex = 4;
            this.btnScrollToSelect.Text = "Scroll to select";
            this.btnScrollToSelect.UseVisualStyleBackColor = true;
            this.btnScrollToSelect.Click += new System.EventHandler(this.btnScrollToSelect_Click);
            // 
            // LargeTextViewer2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 434);
            this.Controls.Add(this.btnScrollToSelect);
            this.Controls.Add(this.btnScrollToEnd);
            this.Controls.Add(this.ltvRes);
            this.Controls.Add(this.ltv2);
            this.Controls.Add(this.ltv1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LargeTextViewer2Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bind two LargeTextViewer";
            this.Load += new System.EventHandler(this.LargeTextViewer2Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SMAH1.Forms.Text.LargeTextViewer ltv1;
        private SMAH1.Forms.Text.LargeTextViewer ltv2;
        private SMAH1.Forms.Text.LargeTextViewer ltvRes;
        private System.Windows.Forms.Button btnScrollToEnd;
        private System.Windows.Forms.Button btnScrollToSelect;
    }
}