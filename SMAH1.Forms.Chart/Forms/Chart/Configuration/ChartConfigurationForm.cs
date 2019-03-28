using SMAH1.Forms.PropertyGridEx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SMAH1.Forms.Chart.Configuration
{
    public partial class ChartConfigurationForm : Form
    {
        #region field
        private PropertyGridMinExWithLoadSave propertyGrid;
        private Chart chart;
        private bool showLoadSave;
        private bool rtl;
        #endregion

        #region Property
        public BaseChartConfiguration CurrentChartConfiguration { get; private set; }

        public Image LoadIcon { get; set; }
        public Image SaveIcon { get; set; }

        public bool ShowLoadSaveToolStrip
        {
            get { return showLoadSave; }
            set
            {
                showLoadSave = value;
                propertyGrid.ShowLoadSave = value;
            }
        }
        #endregion

        #region Create & Control & Close
        public ChartConfigurationForm(Chart chart)
            : this(chart, true, true)
        {
        }

        public ChartConfigurationForm(Chart chart, bool showLoadSave, bool isPropertyGridExtended)
        {
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(ChartConfigurationForm_FormClosing);

            LoadIcon = null;
            SaveIcon = null;
            this.chart = chart;
            this.showLoadSave = showLoadSave;
            CurrentChartConfiguration = null;
            if (chart == null)
                throw new ArgumentNullException("'Chart' is null!");
            chart.ComponentChanged += new EventHandler(Chart_ComponentChanged);

            //PropertyGrid
            CreatePropertyGrid(isPropertyGridExtended);
        }

        void ChartConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If Not use this Code,Throw Exception in RebindComponent method when
            //          this.propertyGrid.SelectedObject = bcc;
            //
            chart.ComponentChanged -= new EventHandler(Chart_ComponentChanged);
        }

        private void CreatePropertyGrid(bool isPropertyGridExtended)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(ChartConfigurationForm));

                propertyGrid = new PropertyGridMinExWithLoadSave(showLoadSave, this, isPropertyGridExtended)
                {
                    Location = new Point(12, 12),
                    Name = "propertyGrid",
                    Size = new Size(193, 353),
                    TabIndex = 0,
                    Dock = DockStyle.Fill
                };
                if (LoadIcon != null)
                    propertyGrid.LoadImage = LoadIcon;
                else
                    propertyGrid.LoadImage = ((Image)(resources.GetObject("FileOpen")));
                if (SaveIcon != null)
                    propertyGrid.SaveImage = SaveIcon;
                else
                    propertyGrid.SaveImage = ((Image)(resources.GetObject("FileSave")));
                propertyGrid.ClickLoad += new EventHandler(ButtonLoad_Click);
                propertyGrid.ClickSave += new EventHandler(ButtonSave_Click);

                this.Controls.Add(propertyGrid);
            }
            catch { }
        }

        private void ChartConfigurationForm_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ChartConfigurationForm));

            if (LoadIcon != null)
                propertyGrid.LoadImage = LoadIcon;
            else
                propertyGrid.LoadImage = ((Image)(resources.GetObject("FileOpen")));
            if (SaveIcon != null)
                propertyGrid.SaveImage = SaveIcon;
            else
                propertyGrid.SaveImage = ((Image)(resources.GetObject("FileSave")));

            RebindComponent();
        }

        void Chart_ComponentChanged(object sender, EventArgs e)
        {
            RebindComponent();
        }
        #endregion

        #region Rebind
        private void RebindComponent()
        {
            rtl = false;

            if (chart.Component == null)
                CurrentChartConfiguration = new EmptyChartConfiguration(chart, this);
            else
                CurrentChartConfiguration = chart.Component.CreateChartConfiguration(this);

            CurrentChartConfiguration.RestoreDefaultItemsConfiguration();
            OnCurrentChartConfigurationChanged();

            List<PropertyNameDescription> pnd = CurrentChartConfiguration.GetChartConfigurationFormItems();
            if (pnd.Count > 0)
            {
                foreach (PropertyNameDescription p in pnd)
                {
                    if (p.IsAttribute)
                    {
                        if (String.Compare(p.Property, "Save", true) == 0)
                        {
                            propertyGrid.SaveText = p.Description;
                        }
                        else if (String.Compare(p.Property, "Load", true) == 0)
                        {
                            propertyGrid.LoadText = p.Description;
                        }
                        else if (String.Compare(p.Property, "Title", true) == 0)
                        {
                            this.Text = p.Description;
                        }
                        else if (String.Compare(p.Property, "Alphabetical", true) == 0)
                        {
                            if (propertyGrid.IsExtended)
                            {
                                ToolStripItem item = propertyGrid.ToolStrip.Items[1];
                                item.Text = item.ToolTipText = p.Description;
                            }
                        }
                        else if (String.Compare(p.Property, "Categorized", true) == 0)
                        {
                            if (propertyGrid.IsExtended)
                            {
                                ToolStripItem item = propertyGrid.ToolStrip.Items[0];
                                item.Text = item.ToolTipText = p.Description;
                            }
                        }
                        else if (String.Compare(p.Property, "rtl", true) == 0)
                        {
                            rtl = false;
                            bool.TryParse(p.Description, out rtl);
                            if (rtl)
                            {
                                this.RightToLeft = RightToLeft.Yes;
                                this.RightToLeftLayout = true;
                                propertyGrid.RightToLeft = RightToLeft.Yes;
                            }
                        }
                    }
                }
            }

            propertyGrid.SelectedObject = CurrentChartConfiguration;

            //For fix bug in mono for show
            //      Scroll and Color combobox caret
            propertyGrid.Size = new Size(propertyGrid.Size.Width + 1, propertyGrid.Size.Height);

            propertyGrid.Invalidate();
        }

        //For fix bug in mono for show
        //      [RefreshProperties(RefreshProperties.All)] not work
        public void RebindChartConfiguration()
        {
            propertyGrid.Refresh();
        }
        #endregion

        #region Load & Save
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog
            {
                Title = "Save configuration of chart",
                Filter = "All file(*.*)|*.*"
            };
            if (sf.ShowDialog() == DialogResult.OK)
            {
                chart.SaveConfigurationOfChart(sf.FileName);
            }
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog
            {
                Title = "Load configuration of chart",
                Filter = "All file(*.*)|*.*"
            };
            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    chart.LoadConfigurationOfChartFromFile(of.FileName);
                }
                catch { }
                RebindChartConfiguration();
            }
        }
        #endregion

        #region Change Component
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Chart")]
        [Description("Configuration of chart and component was changed.")]
        public event System.EventHandler CurrentChartConfigurationChanged;

        private void OnCurrentChartConfigurationChanged()
        {
            CurrentChartConfigurationChanged?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}
