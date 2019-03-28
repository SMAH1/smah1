using SMAH1.Attributes;
using SMAH1.Forms.PropertyGridComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class PropertyGridForm : Form
    {
        #region class
        public class InternalData
        {
            public InternalData()
            {
                Colors1 = new Color[0];
                IntValue1 = 0;
                FloatValue1 = 0F;
                Colors2 = new Color[0];
                IntValue2 = 0;
                FloatValue2 = 0F;
            }

            [Category("Default Editor")]
            public Color[] Colors1 { get; set; }

            [Category("Default Editor")]
            public int IntValue1 { get; set; }

            [Category("Default Editor")]
            public float FloatValue1 { get; set; }

            [Category("Custom Editor")]
            [Editor(typeof(ColorArrayEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public Color[] Colors2 { get; set; }

            int intValue2 = 2;
            [Category("Custom Editor")]
            [Editor(typeof(NumericIntUpDownEditor), typeof(System.Drawing.Design.UITypeEditor))]
            [MaxMinForInt(2, 20)]
            public int IntValue2 { get { return intValue2; } set { intValue2 = value; OnChanged(); } }

            float floatValue2 = 2F;
            [Category("Custom Editor")]
            [Editor(typeof(NumericFloatUpDownEditor), typeof(System.Drawing.Design.UITypeEditor))]
            [MaxMinForFloat(1, 20, 1, 0.1F)]
            public float FloatValue2 { get { return floatValue2; } set { floatValue2 = value; OnChanged(); } }

            public event EventHandler Changed;
            protected virtual void OnChanged()
            {
                Changed?.Invoke(this, new EventArgs());
            }
        }
        #endregion

        InternalData data;
        ToolStripButton buttonLoad;
        ToolStripButton buttonSave;

        public PropertyGridForm()
        {
            InitializeComponent();

            data = new InternalData()
            {
                Colors1 = new Color[] { Color.Green, Color.SeaGreen, Color.SpringGreen, Color.Lime },
                IntValue1 = 10,
                FloatValue1 = 10.1F,
                Colors2 = new Color[] { Color.Green, Color.SeaGreen, Color.SpringGreen, Color.Lime },
                IntValue2 = 10,
                FloatValue2 = 10.1F
            };

            data.Changed += Data_Changed;
            UpdateMessageText();

            buttonLoad = new ToolStripButton();
            buttonSave = new ToolStripButton();

            buttonLoad.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonLoad.ImageTransparentColor = Color.Magenta;
            buttonLoad.Name = "ButtonLoad";
            buttonLoad.Size = new Size(23, 22);
            buttonLoad.Text = "Load";
            buttonLoad.Image = global::HowToWork.Properties.Resources.Open16X16;
            buttonLoad.Click += ButtonLoad_Click;

            buttonSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonSave.ImageTransparentColor = Color.Magenta;
            buttonSave.Name = "ButtonSave";
            buttonSave.Size = new System.Drawing.Size(23, 22);
            buttonSave.Text = "Save";
            buttonSave.Image = global::HowToWork.Properties.Resources.Save16X16;
            buttonSave.Click += ButtonSave_Click;

            buttonLoad.Visible = buttonSave.Visible = true;

            pg.ToolStrip.Items.Clear();

            pg.ToolStrip.Items.AddRange(new ToolStripItem[] {
                    buttonLoad,
                    buttonSave});
        }

        private void Data_Changed(object sender, EventArgs e)
        {
            UpdateMessageText();
        }

        private void PropertyGridComponentForm_Load(object sender, EventArgs e)
        {
            pg.SelectedObject = data;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SAVE Click!");
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Load Click!");
        }

        private void UpdateMessageText()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("IntValue2: " + data.IntValue2);
            sb.AppendLine("FloatValue2: " + data.FloatValue2);
            txt.Text = sb.ToString();
        }
    }
}
