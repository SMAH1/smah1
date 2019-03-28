namespace HowToWork
{
    partial class LoadingTestForm
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
            this.cbxLoading = new System.Windows.Forms.ComboBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.loading1 = new SMAH1.Forms.Loading.LoadingCtrl();
            this.fan1 = new SMAH1.Forms.Loading.Component.LFan();
            this.plus1 = new SMAH1.Forms.Loading.Component.LPlus();
            this.clock1 = new SMAH1.Forms.Loading.Component.LClock();
            this.circleInterrupted1 = new SMAH1.Forms.Loading.Component.LCircleInterrupted();
            this.circularRibbons1 = new SMAH1.Forms.Loading.Component.LCircularRibbons();
            this.textNose1 = new SMAH1.Forms.Loading.Component.LTextNose();
            this.protest1 = new SMAH1.Forms.Loading.Component.LProtest();
            this.cageOfBird1 = new SMAH1.Forms.Loading.Component.LCageOfBird();
            this.fillPoint1 = new SMAH1.Forms.Loading.Component.LFillPoint();
            this.hourglass1 = new SMAH1.Forms.Loading.Component.LHourglass();
            this.hartPqrst1 = new SMAH1.Forms.Loading.Component.LHartPqrst();
            this.messageSend1 = new SMAH1.Forms.Loading.Component.LMessageSend();
            this.lineSlide1 = new SMAH1.Forms.Loading.Component.LLineSlide();
            this.piscina1 = new SMAH1.Forms.Loading.Component.LPiscina();
            this.hartPqrst2 = new SMAH1.Forms.Loading.Component.LHartPqrst2();
            this.circularminimalist1 = new SMAH1.Forms.Loading.Component.LCircularMinimalist();
            this.circleWalker1 = new SMAH1.Forms.Loading.Component.LCircleWalker();
            this.yingYang = new SMAH1.Forms.Loading.Component.LYingYang();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxLoading
            // 
            this.cbxLoading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxLoading.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLoading.FormattingEnabled = true;
            this.cbxLoading.Location = new System.Drawing.Point(12, 12);
            this.cbxLoading.Name = "cbxLoading";
            this.cbxLoading.Size = new System.Drawing.Size(215, 21);
            this.cbxLoading.TabIndex = 4;
            this.cbxLoading.SelectedIndexChanged += new System.EventHandler(this.cbxLoading_SelectedIndexChanged);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(233, 39);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid1.Size = new System.Drawing.Size(238, 143);
            this.propertyGrid1.TabIndex = 5;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Interval";
            // 
            // numInterval
            // 
            this.numInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numInterval.Location = new System.Drawing.Point(298, 13);
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(44, 20);
            this.numInterval.TabIndex = 7;
            this.numInterval.ValueChanged += new System.EventHandler(this.numInterval_ValueChanged);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartStop.Location = new System.Drawing.Point(348, 10);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(61, 23);
            this.btnStartStop.TabIndex = 8;
            this.btnStartStop.Text = "button1";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(410, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(61, 23);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // loading1
            // 
            this.loading1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loading1.BackgroundImage = global::HowToWork.Properties.Resources.FIL63813;
            this.loading1.CausesValidation = false;
            this.loading1.Component = this.fan1;
            this.loading1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.loading1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.loading1.Interval = 80;
            this.loading1.Location = new System.Drawing.Point(12, 39);
            this.loading1.Name = "loading1";
            this.loading1.Size = new System.Drawing.Size(215, 143);
            this.loading1.TabIndex = 3;
            this.loading1.Text = "loading123";
            // 
            // fan1
            // 
            this.fan1.Default = System.Drawing.SystemColors.InactiveCaption;
            this.fan1.Parent = this.loading1;
            this.fan1.Progress = System.Drawing.SystemColors.ActiveCaption;
            // 
            // plus1
            // 
            this.plus1.Content = System.Drawing.SystemColors.ControlLight;
            this.plus1.Edge = System.Drawing.SystemColors.ControlDark;
            this.plus1.EdgeWidth = 5F;
            // 
            // clock1
            // 
            this.clock1.Needle = System.Drawing.Color.Red;
            this.clock1.Sign = System.Drawing.Color.Blue;
            // 
            // circleInterrupted1
            // 
            this.circleInterrupted1.Between = System.Drawing.Color.Yellow;
            this.circleInterrupted1.Dark = System.Drawing.Color.Black;
            this.circleInterrupted1.Light = System.Drawing.Color.White;
            this.circleInterrupted1.ShapeRotate = 30;
            this.circleInterrupted1.SpaceRotate = 15;
            // 
            // circularRibbons1
            // 
            this.circularRibbons1.Inner = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.circularRibbons1.Outer = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            // 
            // textNose1
            // 
            this.textNose1.Step = 3;
            // 
            // protest1
            // 
            this.protest1.Angle = 8;
            this.protest1.Default = System.Drawing.SystemColors.GradientActiveCaption;
            this.protest1.Progress = System.Drawing.SystemColors.GradientInactiveCaption;
            // 
            // cageOfBird1
            // 
            this.cageOfBird1.Bird = System.Drawing.SystemColors.WindowText;
            this.cageOfBird1.Cage = System.Drawing.SystemColors.GradientInactiveCaption;
            // 
            // hourglass1
            // 
            this.hourglass1.Fill = System.Drawing.SystemColors.ControlDark;
            this.hourglass1.Line = System.Drawing.SystemColors.ControlDarkDark;
            // 
            // hartPqrst1
            // 
            this.hartPqrst1.Grid = System.Drawing.SystemColors.ControlDark;
            this.hartPqrst1.HasGrid = true;
            this.hartPqrst1.Line = System.Drawing.SystemColors.MenuHighlight;
            // 
            // messageSend1
            // 
            this.messageSend1.Default = System.Drawing.SystemColors.ControlLight;
            this.messageSend1.Highlight = System.Drawing.SystemColors.Highlight;
            this.messageSend1.Minimal = false;
            // 
            // lineSlide1
            // 
            this.lineSlide1.Fill = System.Drawing.SystemColors.Highlight;
            this.lineSlide1.Line = System.Drawing.SystemColors.ControlDark;
            // 
            // piscina1
            // 
            this.piscina1.Continues = false;
            this.piscina1.Fill = System.Drawing.SystemColors.Highlight;
            this.piscina1.Line = System.Drawing.SystemColors.ControlDark;
            this.piscina1.ShowLine = false;
            // 
            // hartPqrst2
            // 
            this.hartPqrst2.Line = System.Drawing.SystemColors.MenuHighlight;
            // 
            // circularminimalist1
            // 
            this.circularminimalist1.Line = System.Drawing.SystemColors.ControlDark;
            // 
            // circleWalker1
            // 
            this.circleWalker1.Fill = System.Drawing.SystemColors.Highlight;
            this.circleWalker1.Line = System.Drawing.SystemColors.ButtonHighlight;
            this.circleWalker1.ShowLine = true;
            // 
            // yingYang
            // 
            this.yingYang.Color1 = System.Drawing.Color.Black;
            this.yingYang.Color2 = System.Drawing.Color.White;
            this.yingYang.Line = System.Drawing.Color.Black;
            this.yingYang.ShowLine = true;
            // 
            // LoadingTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 194);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.numInterval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.cbxLoading);
            this.Controls.Add(this.loading1);
            this.MinimizeBox = false;
            this.Name = "LoadingTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading Test";
            this.Load += new System.EventHandler(this.LoadingTestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SMAH1.Forms.Loading.LoadingCtrl loading1;
        private SMAH1.Forms.Loading.Component.LFan fan1;
        private SMAH1.Forms.Loading.Component.LCageOfBird cageOfBird1;
        private System.Windows.Forms.ComboBox cbxLoading;
        private SMAH1.Forms.Loading.Component.LProtest protest1;
        private SMAH1.Forms.Loading.Component.LPlus plus1;
        private SMAH1.Forms.Loading.Component.LTextNose textNose1;
        private SMAH1.Forms.Loading.Component.LCircularRibbons circularRibbons1;
        private SMAH1.Forms.Loading.Component.LCircleInterrupted circleInterrupted1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private SMAH1.Forms.Loading.Component.LClock clock1;
        private SMAH1.Forms.Loading.Component.LFillPoint fillPoint1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnBack;
        private SMAH1.Forms.Loading.Component.LHourglass hourglass1;
        private SMAH1.Forms.Loading.Component.LHartPqrst hartPqrst1;
        private SMAH1.Forms.Loading.Component.LMessageSend messageSend1;
        private SMAH1.Forms.Loading.Component.LLineSlide lineSlide1;
        private SMAH1.Forms.Loading.Component.LPiscina piscina1;
        private SMAH1.Forms.Loading.Component.LHartPqrst2 hartPqrst2;
        private SMAH1.Forms.Loading.Component.LCircularMinimalist circularminimalist1;
        private SMAH1.Forms.Loading.Component.LCircleWalker circleWalker1;
        private SMAH1.Forms.Loading.Component.LYingYang yingYang;

    }
}

