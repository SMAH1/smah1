namespace HowToWork
{
    partial class Chart4Form
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
            this.pnl = new System.Windows.Forms.Panel();
            this.chbxOtherData = new System.Windows.Forms.CheckBox();
            this.chbxColScl = new System.Windows.Forms.CheckBox();
            this.btnExpImg = new SMAH1.Forms.Clickable.SplitButton();
            this.SuspendLayout();
            // 
            // pnl
            // 
            this.pnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl.AutoScroll = true;
            this.pnl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnl.Location = new System.Drawing.Point(0, 0);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(800, 415);
            this.pnl.TabIndex = 0;
            // 
            // chbxOtherData
            // 
            this.chbxOtherData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbxOtherData.AutoSize = true;
            this.chbxOtherData.Location = new System.Drawing.Point(12, 428);
            this.chbxOtherData.Name = "chbxOtherData";
            this.chbxOtherData.Size = new System.Drawing.Size(76, 17);
            this.chbxOtherData.TabIndex = 2;
            this.chbxOtherData.Text = "Other data";
            this.chbxOtherData.UseVisualStyleBackColor = true;
            this.chbxOtherData.CheckedChanged += new System.EventHandler(this.chbxOtherData_CheckedChanged);
            // 
            // chbxColScl
            // 
            this.chbxColScl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbxColScl.AutoSize = true;
            this.chbxColScl.Location = new System.Drawing.Point(105, 428);
            this.chbxColScl.Name = "chbxColScl";
            this.chbxColScl.Size = new System.Drawing.Size(97, 17);
            this.chbxColScl.TabIndex = 3;
            this.chbxColScl.Text = "Column scaling";
            this.chbxColScl.UseVisualStyleBackColor = true;
            this.chbxColScl.CheckedChanged += new System.EventHandler(this.chbxColScl_CheckedChanged);
            // 
            // btnExpImg
            // 
            this.btnExpImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpImg.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExpImg.ImageKey = "Normal";
            this.btnExpImg.Location = new System.Drawing.Point(685, 421);
            this.btnExpImg.Name = "btnExpImg";
            this.btnExpImg.Size = new System.Drawing.Size(103, 29);
            this.btnExpImg.TabIndex = 5;
            this.btnExpImg.Text = "Export Image   ";
            this.btnExpImg.UseVisualStyleBackColor = true;
            this.btnExpImg.ButtonClick += new System.EventHandler(this.btnExpImg_ButtonClick);
            // 
            // Chart4Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 462);
            this.Controls.Add(this.btnExpImg);
            this.Controls.Add(this.chbxColScl);
            this.Controls.Add(this.chbxOtherData);
            this.Controls.Add(this.pnl);
            this.MinimizeBox = false;
            this.Name = "Chart4Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Line chart with X Scale and Axile space Coordinating";
            this.Load += new System.EventHandler(this.ChartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.CheckBox chbxOtherData;
        private System.Windows.Forms.CheckBox chbxColScl;
        private SMAH1.Forms.Clickable.SplitButton btnExpImg;

    }
}