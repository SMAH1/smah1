namespace HowToWork
{
    partial class Chart5Form
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chart1 = new SMAH1.Forms.Chart.Chart();
            this.line1 = new SMAH1.Forms.Chart.Component.LineComponent.Line();
            this.chbxSecond = new System.Windows.Forms.CheckBox();
            this.chbxColScal = new System.Windows.Forms.CheckBox();
            this.panelConfigurationForm = new System.Windows.Forms.Panel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chbxSecond);
            this.splitContainer1.Panel2.Controls.Add(this.chbxColScal);
            this.splitContainer1.Panel2.Controls.Add(this.panelConfigurationForm);
            this.splitContainer1.Size = new System.Drawing.Size(880, 462);
            this.splitContainer1.SplitterDistance = 660;
            this.splitContainer1.TabIndex = 13;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.SystemColors.Control;
            this.chart1.CausesValidation = false;
            this.chart1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.Green,
        System.Drawing.Color.GhostWhite,
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue,
        System.Drawing.Color.SeaGreen,
        System.Drawing.Color.Gray,
        System.Drawing.Color.Pink,
        System.Drawing.Color.RoyalBlue,
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.Gold,
        System.Drawing.Color.LightPink,
        System.Drawing.Color.LightBlue,
        System.Drawing.Color.Lime,
        System.Drawing.Color.Yellow,
        System.Drawing.Color.Magenta,
        System.Drawing.Color.Khaki};
            this.chart1.Component = this.line1;
            this.chart1.FontLegend = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chart1.FontTitle = new System.Drawing.Font("Arial", 20F);
            this.chart1.LegendHorizontalSpace = -10;
            this.chart1.LegendShow = true;
            this.chart1.LegendVerticalSpace = -10;
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            this.chart1.Padding = new System.Windows.Forms.Padding(5);
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chart1.ShowText = SMAH1.Forms.Chart.ShowTextMode.Top;
            this.chart1.Size = new System.Drawing.Size(654, 447);
            this.chart1.SpaceAfterText = 3;
            this.chart1.SpaceBottom = 5;
            this.chart1.SpaceLeft = 5;
            this.chart1.SpaceRight = 5;
            this.chart1.SpaceTop = 5;
            this.chart1.TabIndex = 0;
            this.chart1.Text = "TITLE";
            // 
            // line1
            // 
            this.line1.AxileNameVisible = SMAH1.Forms.Chart.Component.Axile.AxileName.None;
            this.line1.DiagonalPoint = 5;
            this.line1.FontAxileName = null;
            this.line1.GridColor = System.Drawing.SystemColors.WindowText;
            this.line1.PointKind = SMAH1.Forms.Chart.Component.LineComponent.PointType.Square;
            this.line1.SecondDataMember = null;
            this.line1.SecondDataMemberIndependentZero = false;
            this.line1.SizingModeLabel = SMAH1.Forms.Chart.Component.Axile.SizingModeLabel.Fit;
            // 
            // chbxSecond
            // 
            this.chbxSecond.AutoSize = true;
            this.chbxSecond.Location = new System.Drawing.Point(62, 35);
            this.chbxSecond.Name = "chbxSecond";
            this.chbxSecond.Size = new System.Drawing.Size(113, 17);
            this.chbxSecond.TabIndex = 8;
            this.chbxSecond.Text = "Only show second";
            this.chbxSecond.UseVisualStyleBackColor = true;
            this.chbxSecond.CheckedChanged += new System.EventHandler(this.chbxSecond_CheckedChanged);
            // 
            // chbxColScal
            // 
            this.chbxColScal.AutoSize = true;
            this.chbxColScal.Location = new System.Drawing.Point(62, 12);
            this.chbxColScal.Name = "chbxColScal";
            this.chbxColScal.Size = new System.Drawing.Size(99, 17);
            this.chbxColScal.TabIndex = 9;
            this.chbxColScal.Text = "Column Scaling";
            this.chbxColScal.UseVisualStyleBackColor = true;
            this.chbxColScal.CheckedChanged += new System.EventHandler(this.chbxColScal_CheckedChanged);
            // 
            // panelConfigurationForm
            // 
            this.panelConfigurationForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelConfigurationForm.Location = new System.Drawing.Point(0, 58);
            this.panelConfigurationForm.Name = "panelConfigurationForm";
            this.panelConfigurationForm.Size = new System.Drawing.Size(216, 404);
            this.panelConfigurationForm.TabIndex = 6;
            // 
            // Chart5Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 462);
            this.Controls.Add(this.splitContainer1);
            this.MinimizeBox = false;
            this.Name = "Chart5Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Line chart with show X-Axil label in milisecond or second";
            this.Load += new System.EventHandler(this.ChartForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SMAH1.Forms.Chart.Chart chart1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelConfigurationForm;
        private SMAH1.Forms.Chart.Component.LineComponent.Line line1;
        private System.Windows.Forms.CheckBox chbxSecond;
        private System.Windows.Forms.CheckBox chbxColScal;
    }
}