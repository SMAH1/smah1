namespace HowToWork
{
    partial class Chart3Form
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
            this.lblNearest = new System.Windows.Forms.Label();
            this.chbxRTL = new System.Windows.Forms.CheckBox();
            this.chbxManyCol = new System.Windows.Forms.CheckBox();
            this.chbxColScal = new System.Windows.Forms.CheckBox();
            this.chbxSecond = new System.Windows.Forms.CheckBox();
            this.chbxManager = new System.Windows.Forms.CheckBox();
            this.chart3 = new SMAH1.Forms.Chart.Chart();
            this.line3 = new SMAH1.Forms.Chart.Component.LineComponent.Line();
            this.chart2 = new SMAH1.Forms.Chart.Chart();
            this.line2 = new SMAH1.Forms.Chart.Component.LineComponent.Line();
            this.chart1 = new SMAH1.Forms.Chart.Chart();
            this.line1 = new SMAH1.Forms.Chart.Component.LineComponent.Line();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblNearest);
            this.splitContainer1.Panel1.Controls.Add(this.chbxRTL);
            this.splitContainer1.Panel1.Controls.Add(this.chbxManyCol);
            this.splitContainer1.Panel1.Controls.Add(this.chbxColScal);
            this.splitContainer1.Panel1.Controls.Add(this.chbxSecond);
            this.splitContainer1.Panel1.Controls.Add(this.chbxManager);
            this.splitContainer1.Panel1.Controls.Add(this.chart3);
            this.splitContainer1.Panel1.Controls.Add(this.chart2);
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelConfigurationForm);
            this.splitContainer1.Size = new System.Drawing.Size(880, 462);
            this.splitContainer1.SplitterDistance = 660;
            this.splitContainer1.TabIndex = 13;
            // 
            // lblNearest
            // 
            this.lblNearest.Location = new System.Drawing.Point(329, 397);
            this.lblNearest.Name = "lblNearest";
            this.lblNearest.Size = new System.Drawing.Size(310, 44);
            this.lblNearest.TabIndex = 8;
            this.lblNearest.Text = "Near";
            this.lblNearest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chbxRTL
            // 
            this.chbxRTL.AutoSize = true;
            this.chbxRTL.Location = new System.Drawing.Point(427, 353);
            this.chbxRTL.Name = "chbxRTL";
            this.chbxRTL.Size = new System.Drawing.Size(80, 17);
            this.chbxRTL.TabIndex = 7;
            this.chbxRTL.Text = "Right to left";
            this.chbxRTL.UseVisualStyleBackColor = true;
            this.chbxRTL.CheckedChanged += new System.EventHandler(this.chbxRTL_CheckedChanged);
            // 
            // chbxManyCol
            // 
            this.chbxManyCol.AutoSize = true;
            this.chbxManyCol.Location = new System.Drawing.Point(427, 330);
            this.chbxManyCol.Name = "chbxManyCol";
            this.chbxManyCol.Size = new System.Drawing.Size(89, 17);
            this.chbxManyCol.TabIndex = 6;
            this.chbxManyCol.Text = "Many column";
            this.chbxManyCol.UseVisualStyleBackColor = true;
            this.chbxManyCol.CheckedChanged += new System.EventHandler(this.chbxManyCol_CheckedChanged);
            // 
            // chbxColScal
            // 
            this.chbxColScal.AutoSize = true;
            this.chbxColScal.Location = new System.Drawing.Point(427, 307);
            this.chbxColScal.Name = "chbxColScal";
            this.chbxColScal.Size = new System.Drawing.Size(99, 17);
            this.chbxColScal.TabIndex = 5;
            this.chbxColScal.Text = "Column Scaling";
            this.chbxColScal.UseVisualStyleBackColor = true;
            this.chbxColScal.CheckedChanged += new System.EventHandler(this.chbxColScal_CheckedChanged);
            // 
            // chbxSecond
            // 
            this.chbxSecond.AutoSize = true;
            this.chbxSecond.Location = new System.Drawing.Point(427, 284);
            this.chbxSecond.Name = "chbxSecond";
            this.chbxSecond.Size = new System.Drawing.Size(87, 17);
            this.chbxSecond.TabIndex = 4;
            this.chbxSecond.Text = "Second data";
            this.chbxSecond.UseVisualStyleBackColor = true;
            this.chbxSecond.CheckedChanged += new System.EventHandler(this.chbxSecond_CheckedChanged);
            // 
            // chbxManager
            // 
            this.chbxManager.AutoSize = true;
            this.chbxManager.Location = new System.Drawing.Point(427, 261);
            this.chbxManager.Name = "chbxManager";
            this.chbxManager.Size = new System.Drawing.Size(120, 17);
            this.chbxManager.TabIndex = 3;
            this.chbxManager.Text = "With chart Manager";
            this.chbxManager.UseVisualStyleBackColor = true;
            this.chbxManager.CheckedChanged += new System.EventHandler(this.chbxManager_CheckedChanged);
            // 
            // chart3
            // 
            this.chart3.BackColor = System.Drawing.SystemColors.Control;
            this.chart3.CausesValidation = false;
            this.chart3.Colors = new System.Drawing.Color[] {
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
            this.chart3.Component = this.line3;
            this.chart3.FontLegend = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chart3.FontTitle = new System.Drawing.Font("Arial", 20F);
            this.chart3.LegendHorizontalSpace = -10;
            this.chart3.LegendShow = true;
            this.chart3.LegendVerticalSpace = -10;
            this.chart3.Location = new System.Drawing.Point(3, 225);
            this.chart3.Name = "chart3";
            this.chart3.Padding = new System.Windows.Forms.Padding(5);
            this.chart3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chart3.ShowText = SMAH1.Forms.Chart.ShowTextMode.Top;
            this.chart3.Size = new System.Drawing.Size(310, 216);
            this.chart3.SpaceAfterText = 3;
            this.chart3.SpaceBottom = 5;
            this.chart3.SpaceLeft = 5;
            this.chart3.SpaceRight = 5;
            this.chart3.SpaceTop = 5;
            this.chart3.TabIndex = 2;
            this.chart3.Text = "TITLE";
            // 
            // line3
            // 
            this.line3.AxileNameVisible = SMAH1.Forms.Chart.Component.Axile.AxileName.None;
            this.line3.DiagonalPoint = 5;
            this.line3.GridColor = System.Drawing.SystemColors.WindowText;
            this.line3.PointKind = SMAH1.Forms.Chart.Component.LineComponent.PointType.Square;
            this.line3.SecondDataMember = null;
            this.line3.SecondDataMemberIndependentZero = false;
            this.line3.SizingModeLabel = SMAH1.Forms.Chart.Component.Axile.SizingModeLabel.Fit;
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.SystemColors.Control;
            this.chart2.CausesValidation = false;
            this.chart2.Colors = new System.Drawing.Color[] {
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
            this.chart2.Component = this.line2;
            this.chart2.FontLegend = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chart2.FontTitle = new System.Drawing.Font("Arial", 20F);
            this.chart2.LegendHorizontalSpace = -10;
            this.chart2.LegendShow = true;
            this.chart2.LegendVerticalSpace = -10;
            this.chart2.Location = new System.Drawing.Point(329, 3);
            this.chart2.Name = "chart2";
            this.chart2.Padding = new System.Windows.Forms.Padding(5);
            this.chart2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chart2.ShowText = SMAH1.Forms.Chart.ShowTextMode.Top;
            this.chart2.Size = new System.Drawing.Size(310, 216);
            this.chart2.SpaceAfterText = 3;
            this.chart2.SpaceBottom = 5;
            this.chart2.SpaceLeft = 5;
            this.chart2.SpaceRight = 5;
            this.chart2.SpaceTop = 5;
            this.chart2.TabIndex = 1;
            this.chart2.Text = "TITLE";
            // 
            // line2
            // 
            this.line2.AxileNameVisible = SMAH1.Forms.Chart.Component.Axile.AxileName.None;
            this.line2.DiagonalPoint = 5;
            this.line2.GridColor = System.Drawing.SystemColors.WindowText;
            this.line2.PointKind = SMAH1.Forms.Chart.Component.LineComponent.PointType.Square;
            this.line2.SecondDataMember = null;
            this.line2.SecondDataMemberIndependentZero = false;
            this.line2.SizingModeLabel = SMAH1.Forms.Chart.Component.Axile.SizingModeLabel.Fit;
            // 
            // chart1
            // 
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
            this.chart1.Size = new System.Drawing.Size(310, 216);
            this.chart1.SpaceAfterText = 3;
            this.chart1.SpaceBottom = 5;
            this.chart1.SpaceLeft = 5;
            this.chart1.SpaceRight = 5;
            this.chart1.SpaceTop = 5;
            this.chart1.TabIndex = 0;
            this.chart1.Text = "TITLE";
            this.chart1.MouseLeave += new System.EventHandler(this.chart1_MouseLeave);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // line1
            // 
            this.line1.AxileNameVisible = SMAH1.Forms.Chart.Component.Axile.AxileName.None;
            this.line1.DiagonalPoint = 5;
            this.line1.GridColor = System.Drawing.SystemColors.WindowText;
            this.line1.PointKind = SMAH1.Forms.Chart.Component.LineComponent.PointType.Square;
            this.line1.SecondDataMember = null;
            this.line1.SecondDataMemberIndependentZero = false;
            this.line1.SizingModeLabel = SMAH1.Forms.Chart.Component.Axile.SizingModeLabel.Fit;
            this.line1.MouseEnterAxisArea += new System.EventHandler(this.line1_MouseEnterAxisArea);
            this.line1.MouseLeaveAxisArea += new System.EventHandler(this.line1_MouseLeaveAxisArea);
            // 
            // panelConfigurationForm
            // 
            this.panelConfigurationForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConfigurationForm.Location = new System.Drawing.Point(0, 0);
            this.panelConfigurationForm.Name = "panelConfigurationForm";
            this.panelConfigurationForm.Size = new System.Drawing.Size(216, 462);
            this.panelConfigurationForm.TabIndex = 6;
            // 
            // Chart3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 462);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "Chart3Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Line chart with X Scale and Axile space Coordinating";
            this.Load += new System.EventHandler(this.ChartForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SMAH1.Forms.Chart.Chart chart1;
        private SMAH1.Forms.Chart.Component.LineComponent.Line line1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelConfigurationForm;
        private SMAH1.Forms.Chart.Chart chart3;
        private SMAH1.Forms.Chart.Chart chart2;
        private SMAH1.Forms.Chart.Component.LineComponent.Line line3;
        private SMAH1.Forms.Chart.Component.LineComponent.Line line2;
        private System.Windows.Forms.CheckBox chbxManager;
        private System.Windows.Forms.CheckBox chbxSecond;
        private System.Windows.Forms.CheckBox chbxColScal;
        private System.Windows.Forms.CheckBox chbxManyCol;
        private System.Windows.Forms.CheckBox chbxRTL;
        private System.Windows.Forms.Label lblNearest;
    }
}