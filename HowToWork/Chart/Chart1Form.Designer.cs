namespace HowToWork
{
    partial class Chart1Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbxChart = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save1000x1000ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.printDIrectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prpertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWithoutComponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.showConfigXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveCurrentComponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCurrentComponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.setCurrentComponentConfigurationToDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDefaultCurrentComponentConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.setCostumConfigurationPropertyForBarComponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setCostumConfigurationPropertyForCurrentBarComponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setTitleMultiLineWithFormatedTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setLoadSaveIconToPRopertyGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartEnableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblNearset = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.chart1 = new SMAH1.Forms.Chart.Chart();
            this.bar1 = new SMAH1.Forms.Chart.Component.BarComponent.Bar();
            this.panelConfigurationForm = new System.Windows.Forms.Panel();
            this.line1 = new SMAH1.Forms.Chart.Component.LineComponent.Line();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxChart
            // 
            this.cbxChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxChart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChart.FormattingEnabled = true;
            this.cbxChart.Location = new System.Drawing.Point(0, 0);
            this.cbxChart.Name = "cbxChart";
            this.cbxChart.Size = new System.Drawing.Size(239, 21);
            this.cbxChart.TabIndex = 5;
            this.cbxChart.SelectedIndexChanged += new System.EventHandler(this.cbxChart_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem,
            this.prpertyToolStripMenuItem,
            this.otherToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(694, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.save1000x1000ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.printDIrectToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save Default";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // save1000x1000ToolStripMenuItem
            // 
            this.save1000x1000ToolStripMenuItem.Name = "save1000x1000ToolStripMenuItem";
            this.save1000x1000ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.save1000x1000ToolStripMenuItem.Text = "Save 1000x1000";
            this.save1000x1000ToolStripMenuItem.Click += new System.EventHandler(this.save1000x1000ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // printDIrectToolStripMenuItem
            // 
            this.printDIrectToolStripMenuItem.Name = "printDIrectToolStripMenuItem";
            this.printDIrectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.printDIrectToolStripMenuItem.Text = "Print";
            this.printDIrectToolStripMenuItem.Click += new System.EventHandler(this.printDirectToolStripMenuItem_Click);
            // 
            // prpertyToolStripMenuItem
            // 
            this.prpertyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem1,
            this.saveWithoutComponentToolStripMenuItem,
            this.toolStripMenuItem2,
            this.showConfigXMLToolStripMenuItem,
            this.toolStripMenuItem3,
            this.saveCurrentComponentToolStripMenuItem,
            this.loadCurrentComponentToolStripMenuItem,
            this.toolStripMenuItem4,
            this.setCurrentComponentConfigurationToDefaultToolStripMenuItem,
            this.clearDefaultCurrentComponentConfigurationToolStripMenuItem,
            this.toolStripMenuItem5,
            this.setCostumConfigurationPropertyForBarComponentToolStripMenuItem,
            this.setCostumConfigurationPropertyForCurrentBarComponentToolStripMenuItem});
            this.prpertyToolStripMenuItem.Name = "prpertyToolStripMenuItem";
            this.prpertyToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.prpertyToolStripMenuItem.Text = "Config";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(400, 22);
            this.saveToolStripMenuItem1.Text = "Save with Component";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // saveWithoutComponentToolStripMenuItem
            // 
            this.saveWithoutComponentToolStripMenuItem.Name = "saveWithoutComponentToolStripMenuItem";
            this.saveWithoutComponentToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.saveWithoutComponentToolStripMenuItem.Text = "Save without Component";
            this.saveWithoutComponentToolStripMenuItem.Click += new System.EventHandler(this.saveWithoutComponentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(397, 6);
            // 
            // showConfigXMLToolStripMenuItem
            // 
            this.showConfigXMLToolStripMenuItem.Name = "showConfigXMLToolStripMenuItem";
            this.showConfigXMLToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.showConfigXMLToolStripMenuItem.Text = "Show Config XML (chart and component)";
            this.showConfigXMLToolStripMenuItem.Click += new System.EventHandler(this.showConfigXMLToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(397, 6);
            // 
            // saveCurrentComponentToolStripMenuItem
            // 
            this.saveCurrentComponentToolStripMenuItem.Name = "saveCurrentComponentToolStripMenuItem";
            this.saveCurrentComponentToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.saveCurrentComponentToolStripMenuItem.Text = "Save Current Component";
            this.saveCurrentComponentToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentComponentToolStripMenuItem_Click);
            // 
            // loadCurrentComponentToolStripMenuItem
            // 
            this.loadCurrentComponentToolStripMenuItem.Name = "loadCurrentComponentToolStripMenuItem";
            this.loadCurrentComponentToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.loadCurrentComponentToolStripMenuItem.Text = "Load Current Component";
            this.loadCurrentComponentToolStripMenuItem.Click += new System.EventHandler(this.loadCurrentComponentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(397, 6);
            // 
            // setCurrentComponentConfigurationToDefaultToolStripMenuItem
            // 
            this.setCurrentComponentConfigurationToDefaultToolStripMenuItem.Name = "setCurrentComponentConfigurationToDefaultToolStripMenuItem";
            this.setCurrentComponentConfigurationToDefaultToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.setCurrentComponentConfigurationToDefaultToolStripMenuItem.Text = "Set Current component Configuration to default";
            this.setCurrentComponentConfigurationToDefaultToolStripMenuItem.Click += new System.EventHandler(this.setCurrentComponentConfigurationToDefaultToolStripMenuItem_Click);
            // 
            // clearDefaultCurrentComponentConfigurationToolStripMenuItem
            // 
            this.clearDefaultCurrentComponentConfigurationToolStripMenuItem.Name = "clearDefaultCurrentComponentConfigurationToolStripMenuItem";
            this.clearDefaultCurrentComponentConfigurationToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.clearDefaultCurrentComponentConfigurationToolStripMenuItem.Text = "Clear default Current component Configuration";
            this.clearDefaultCurrentComponentConfigurationToolStripMenuItem.Click += new System.EventHandler(this.clearDefaultCurrentComponentConfigurationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(397, 6);
            // 
            // setCostumConfigurationPropertyForBarComponentToolStripMenuItem
            // 
            this.setCostumConfigurationPropertyForBarComponentToolStripMenuItem.Name = "setCostumConfigurationPropertyForBarComponentToolStripMenuItem";
            this.setCostumConfigurationPropertyForBarComponentToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.setCostumConfigurationPropertyForBarComponentToolStripMenuItem.Text = "Set default costum configuration property for Bar component";
            this.setCostumConfigurationPropertyForBarComponentToolStripMenuItem.Click += new System.EventHandler(this.setCostumConfigurationPropertyForBarComponentToolStripMenuItem_Click);
            // 
            // setCostumConfigurationPropertyForCurrentBarComponentToolStripMenuItem
            // 
            this.setCostumConfigurationPropertyForCurrentBarComponentToolStripMenuItem.Name = "setCostumConfigurationPropertyForCurrentBarComponentToolStripMenuItem";
            this.setCostumConfigurationPropertyForCurrentBarComponentToolStripMenuItem.Size = new System.Drawing.Size(400, 22);
            this.setCostumConfigurationPropertyForCurrentBarComponentToolStripMenuItem.Text = "Set costum configuration property for current Bar component";
            this.setCostumConfigurationPropertyForCurrentBarComponentToolStripMenuItem.Click += new System.EventHandler(this.setCostumConfigurationPropertyForCurrentBarComponentToolStripMenuItem_Click);
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setTitleMultiLineWithFormatedTextToolStripMenuItem,
            this.setLoadSaveIconToPRopertyGridToolStripMenuItem,
            this.chartEnableToolStripMenuItem});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.otherToolStripMenuItem.Text = "Other";
            // 
            // setTitleMultiLineWithFormatedTextToolStripMenuItem
            // 
            this.setTitleMultiLineWithFormatedTextToolStripMenuItem.Name = "setTitleMultiLineWithFormatedTextToolStripMenuItem";
            this.setTitleMultiLineWithFormatedTextToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.setTitleMultiLineWithFormatedTextToolStripMenuItem.Text = "Set title multi line with Formated text";
            this.setTitleMultiLineWithFormatedTextToolStripMenuItem.Click += new System.EventHandler(this.setTitleMultiLineWithFormatedTextToolStripMenuItem_Click);
            // 
            // setLoadSaveIconToPRopertyGridToolStripMenuItem
            // 
            this.setLoadSaveIconToPRopertyGridToolStripMenuItem.Name = "setLoadSaveIconToPRopertyGridToolStripMenuItem";
            this.setLoadSaveIconToPRopertyGridToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.setLoadSaveIconToPRopertyGridToolStripMenuItem.Text = "Set Load Save Icon to Property Grid";
            this.setLoadSaveIconToPRopertyGridToolStripMenuItem.Click += new System.EventHandler(this.setLoadSaveIconToPRopertyGridToolStripMenuItem_Click);
            // 
            // chartEnableToolStripMenuItem
            // 
            this.chartEnableToolStripMenuItem.Name = "chartEnableToolStripMenuItem";
            this.chartEnableToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.chartEnableToolStripMenuItem.Text = "Chart Enable";
            this.chartEnableToolStripMenuItem.Click += new System.EventHandler(this.chartEnableToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblNearset);
            this.splitContainer1.Panel1.Controls.Add(this.lblValue);
            this.splitContainer1.Panel1.Controls.Add(this.lblItem);
            this.splitContainer1.Panel1.Controls.Add(this.dgv);
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelConfigurationForm);
            this.splitContainer1.Panel2.Controls.Add(this.cbxChart);
            this.splitContainer1.Size = new System.Drawing.Size(694, 438);
            this.splitContainer1.SplitterDistance = 451;
            this.splitContainer1.TabIndex = 13;
            // 
            // lblNearset
            // 
            this.lblNearset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNearset.AutoSize = true;
            this.lblNearset.Location = new System.Drawing.Point(273, 292);
            this.lblNearset.Name = "lblNearset";
            this.lblNearset.Size = new System.Drawing.Size(35, 13);
            this.lblNearset.TabIndex = 10;
            this.lblNearset.Text = "label1";
            // 
            // lblValue
            // 
            this.lblValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(12, 292);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(35, 13);
            this.lblValue.TabIndex = 9;
            this.lblValue.Text = "label2";
            // 
            // lblItem
            // 
            this.lblItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(141, 292);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(35, 13);
            this.lblItem.TabIndex = 8;
            this.lblItem.Text = "label1";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(3, 311);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(445, 124);
            this.dgv.TabIndex = 3;
            this.dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEndEdit);
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
            this.chart1.Component = this.bar1;
            this.chart1.FontLegend = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chart1.FontTitle = new System.Drawing.Font("Arial", 20F);
            this.chart1.LegendHorizontalSpace = -10;
            this.chart1.LegendShow = true;
            this.chart1.LegendVerticalSpace = -10;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Padding = new System.Windows.Forms.Padding(5);
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chart1.ShowText = SMAH1.Forms.Chart.ShowTextMode.Top;
            this.chart1.Size = new System.Drawing.Size(448, 283);
            this.chart1.SpaceAfterText = 3;
            this.chart1.SpaceBottom = 5;
            this.chart1.SpaceLeft = 5;
            this.chart1.SpaceRight = 5;
            this.chart1.SpaceTop = 5;
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1ewrwe";
            this.chart1.MouseLeave += new System.EventHandler(this.chart1_MouseLeave);
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // bar1
            // 
            this.bar1.AxileNameVisible = SMAH1.Forms.Chart.Component.Axile.AxileName.None;
            this.bar1.BorderOfBarColor = System.Drawing.SystemColors.Highlight;
            this.bar1.CountOfGrid = 6;
            this.bar1.FontAxileName = null;
            this.bar1.GapBarOfColumn = 5;
            this.bar1.GapColumns = 30;
            this.bar1.GridColor = System.Drawing.SystemColors.WindowText;
            this.bar1.HorizontalGrid = SMAH1.Forms.Chart.Component.Axile.HorizontalGridMode.FrontOfData;
            this.bar1.SecondDataMember = null;
            this.bar1.SecondDataMemberIndependentZero = false;
            this.bar1.SizingModeValue = SMAH1.Forms.Chart.Component.Axile.SizingModeValue.Round;
            this.bar1.VerticalScale = 1.4F;
            this.bar1.WidthAxisLine = 1;
            this.bar1.WidthBar = 20;
            this.bar1.WidthBorderOfBarLine = 1;
            // 
            // panelConfigurationForm
            // 
            this.panelConfigurationForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConfigurationForm.Location = new System.Drawing.Point(0, 21);
            this.panelConfigurationForm.Name = "panelConfigurationForm";
            this.panelConfigurationForm.Size = new System.Drawing.Size(239, 417);
            this.panelConfigurationForm.TabIndex = 6;
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
            // Chart1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 462);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "Chart1Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chart Form";
            this.Load += new System.EventHandler(this.ChartForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SMAH1.Forms.Chart.Chart chart1;
        private SMAH1.Forms.Chart.Component.BarComponent.Bar bar1;
        private SMAH1.Forms.Chart.Component.LineComponent.Line line1;
        private System.Windows.Forms.ComboBox cbxChart;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem save1000x1000ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prpertyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem printDIrectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveWithoutComponentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem showConfigXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentComponentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCurrentComponentToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelConfigurationForm;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem setCurrentComponentConfigurationToDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearDefaultCurrentComponentConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem setCostumConfigurationPropertyForBarComponentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setCostumConfigurationPropertyForCurrentBarComponentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setTitleMultiLineWithFormatedTextToolStripMenuItem;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ToolStripMenuItem setLoadSaveIconToPRopertyGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartEnableToolStripMenuItem;
        private System.Windows.Forms.Label lblNearset;
    }
}