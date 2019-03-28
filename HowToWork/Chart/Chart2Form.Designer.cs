namespace HowToWork
{
    partial class Chart2Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.chbxInvalidCol = new System.Windows.Forms.CheckBox();
            this.chbxIndependentZero = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.chart1 = new SMAH1.Forms.Chart.Chart();
            this.bar1 = new SMAH1.Forms.Chart.Component.BarComponent.Bar();
            this.panelConfigurationForm = new System.Windows.Forms.Panel();
            this.line1 = new SMAH1.Forms.Chart.Component.LineComponent.Line();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
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
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chbxInvalidCol);
            this.splitContainer1.Panel1.Controls.Add(this.chbxIndependentZero);
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.lblValue);
            this.splitContainer1.Panel1.Controls.Add(this.lblItem);
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            this.splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelConfigurationForm);
            this.splitContainer1.Panel2.Controls.Add(this.cbxChart);
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(694, 438);
            this.splitContainer1.SplitterDistance = 451;
            this.splitContainer1.TabIndex = 13;
            // 
            // chbxInvalidCol
            // 
            this.chbxInvalidCol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbxInvalidCol.AutoSize = true;
            this.chbxInvalidCol.Location = new System.Drawing.Point(219, 267);
            this.chbxInvalidCol.Name = "chbxInvalidCol";
            this.chbxInvalidCol.Size = new System.Drawing.Size(93, 17);
            this.chbxInvalidCol.TabIndex = 13;
            this.chbxInvalidCol.Text = "invalid column";
            this.chbxInvalidCol.UseVisualStyleBackColor = true;
            // 
            // chbxIndependentZero
            // 
            this.chbxIndependentZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbxIndependentZero.AutoSize = true;
            this.chbxIndependentZero.Location = new System.Drawing.Point(318, 267);
            this.chbxIndependentZero.Name = "chbxIndependentZero";
            this.chbxIndependentZero.Size = new System.Drawing.Size(111, 17);
            this.chbxIndependentZero.TabIndex = 12;
            this.chbxIndependentZero.Text = "Independent Zero";
            this.chbxIndependentZero.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(3, 285);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgv1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgv2);
            this.splitContainer2.Size = new System.Drawing.Size(445, 150);
            this.splitContainer2.SplitterDistance = 148;
            this.splitContainer2.TabIndex = 11;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.Location = new System.Drawing.Point(0, 0);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(148, 150);
            this.dgv1.TabIndex = 3;
            this.dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEndEdit);
            // 
            // dgv2
            // 
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            this.dgv2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv2.Location = new System.Drawing.Point(0, 0);
            this.dgv2.Name = "dgv2";
            this.dgv2.RowHeadersVisible = false;
            this.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv2.Size = new System.Drawing.Size(293, 150);
            this.dgv2.TabIndex = 10;
            this.dgv2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEndEdit);
            // 
            // lblValue
            // 
            this.lblValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(12, 269);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(35, 13);
            this.lblValue.TabIndex = 9;
            this.lblValue.Text = "label2";
            // 
            // lblItem
            // 
            this.lblItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(135, 269);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(35, 13);
            this.lblItem.TabIndex = 8;
            this.lblItem.Text = "label1";
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
        System.Drawing.Color.Fuchsia,
        System.Drawing.Color.Red,
        System.Drawing.Color.Blue,
        System.Drawing.Color.Pink,
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.Gold,
        System.Drawing.Color.Yellow};
            this.chart1.Component = this.bar1;
            this.chart1.FontLegend = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chart1.FontTitle = new System.Drawing.Font("Arial", 20F);
            this.chart1.LegendAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.chart1.LegendHorizontalSpace = 5;
            this.chart1.LegendShow = true;
            this.chart1.LegendSpaceReserve = SMAH1.Forms.Chart.LegendSpaceReserve.Horizontal;
            this.chart1.LegendVerticalSpace = -10;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Padding = new System.Windows.Forms.Padding(30, 5, 10, 5);
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chart1.ShowText = SMAH1.Forms.Chart.ShowTextMode.Top;
            this.chart1.Size = new System.Drawing.Size(448, 263);
            this.chart1.SpaceAfterText = 3;
            this.chart1.SpaceBottom = 5;
            this.chart1.SpaceLeft = 30;
            this.chart1.SpaceTop = 5;
            this.chart1.TabIndex = 0;
            this.chart1.Text = "Two Data";
            // 
            // bar1
            // 
            this.bar1.AxileNameVisible = SMAH1.Forms.Chart.Component.Axile.AxileName.EndAxile;
            this.bar1.BorderOfBarColor = System.Drawing.SystemColors.Highlight;
            this.bar1.CountOfGrid = 6;
            this.bar1.FontAxileName = null;
            this.bar1.GapBarOfColumn = 3;
            this.bar1.GapColumns = 44;
            this.bar1.GridColor = System.Drawing.SystemColors.WindowText;
            this.bar1.GridDashStyle = SMAH1.Forms.Chart.Component.Axile.GridDashStyle.DashSpace;
            this.bar1.HorizontalGrid = SMAH1.Forms.Chart.Component.Axile.HorizontalGridMode.FrontOfData;
            this.bar1.SecondDataMember = null;
            this.bar1.SecondDataMemberIndependentZero = false;
            this.bar1.SizingModeValue = SMAH1.Forms.Chart.Component.Axile.SizingModeValue.Round;
            this.bar1.VerticalScale = 1.4F;
            this.bar1.WidthAxisLine = 1;
            this.bar1.WidthBar = 15;
            this.bar1.WidthBorderOfBarLine = 1;
            this.bar1.XAxileLocation = SMAH1.Forms.Chart.Component.Axile.XAxileLocation.Bottom;
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
            this.line1.AxileNameVisible = SMAH1.Forms.Chart.Component.Axile.AxileName.EndAxile;
            this.line1.DiagonalPoint = 5;
            this.line1.FontAxileName = null;
            this.line1.GridColor = System.Drawing.SystemColors.WindowText;
            this.line1.GridDashStyle = SMAH1.Forms.Chart.Component.Axile.GridDashStyle.DashDotDot;
            this.line1.HorizontalGrid = SMAH1.Forms.Chart.Component.Axile.HorizontalGridMode.BackOfData;
            this.line1.PointKind = SMAH1.Forms.Chart.Component.LineComponent.PointType.Square;
            this.line1.SecondDataMember = null;
            this.line1.SecondDataMemberIndependentZero = false;
            this.line1.SizingModeLabel = SMAH1.Forms.Chart.Component.Axile.SizingModeLabel.Fit;
            this.line1.XAxileLocation = SMAH1.Forms.Chart.Component.Axile.XAxileLocation.Bottom;
            // 
            // Chart2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 462);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "Chart2Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chart Form With 2 Data";
            this.Load += new System.EventHandler(this.ChartForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
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
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.ToolStripMenuItem setLoadSaveIconToPRopertyGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartEnableToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.CheckBox chbxIndependentZero;
        private System.Windows.Forms.CheckBox chbxInvalidCol;
    }
}