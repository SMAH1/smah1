using SMAH1.Serialize;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HowToWork
{
    public partial class SerializeXmlForm : Form
    {
        #region internal class

        [XmlRoot("Data")]
        public class InternalObject
        {
            #region Basic
            [Category("Basic")]
            public string Name { get; set; }

            [Category("Basic")]
            public int Age { get; set; }
            #endregion

            #region Color
            [Category("Color")]
            [XmlElement(Type = typeof(XmlColor))]
            public Color Color1 { get; set; }

            [Category("Color")]
            [XmlElement(Type = typeof(XmlColor))]
            public Color Color2 { get; set; }

            [Category("Color")]
            [XmlElement(Type = typeof(XmlColor))]
            public Color Color3 { get; set; }

            [Category("Color")]
            [XmlElement(Type = typeof(XmlColor))]
            public Color Color4 { get; set; }
            #endregion

            #region Font
            [Category("Font")]
            [XmlIgnore()]
            public Font Font1 { get; set; }

            [Category("Font")]
            [XmlIgnore()]
            public Font Font2 { get; set; }

            [Category("Font")]
            [XmlIgnore()]
            public Font Font3 { get; set; }

            [Category("Font")]
            [XmlIgnore()]
            public Font Font4 { get; set; }

            [Browsable(false)]
            [XmlElement("Font1")]
            public string Font1Hidden
            {
                get { return XmlFontSerializationHelper.Serialize(Font1); }
                set { Font1 = XmlFontSerializationHelper.Deserialize(value); }
            }

            [Browsable(false)]
            [XmlElement("Font2")]
            public string Font2Hidden
            {
                get { return XmlFontSerializationHelper.Serialize(Font2); }
                set { Font2 = XmlFontSerializationHelper.Deserialize(value); }
            }

            [Browsable(false)]
            [XmlElement("Font3")]
            public string Font3Hidden
            {
                get { return XmlFontSerializationHelper.Serialize(Font3); }
                set { Font3 = XmlFontSerializationHelper.Deserialize(value); }
            }

            [Browsable(false)]
            [XmlElement("Font4")]
            public string Font4Hidden
            {
                get { return XmlFontSerializationHelper.Serialize(Font4); }
                set { Font4 = XmlFontSerializationHelper.Deserialize(value); }
            }
            #endregion
        }
        #endregion

        InternalObject data = null;

        public SerializeXmlForm()
        {
            InitializeComponent();

            data = new InternalObject()
            {
                Name = "SMAH1",
                Age = 40,

                Color1 = Color.FromArgb(128, 200, 100, 50),
                Color2 = Color.SeaGreen,
                Color3 = SystemColors.Info,
                Color4 = Color.FromArgb(64, 255, 255, 255),

                Font1 = SystemFonts.CaptionFont,
                Font2 = SystemFonts.DefaultFont,
                Font3 = new Font("Arial", 15),
                Font4 = new Font("Arial", 20, FontStyle.Italic | FontStyle.Bold),
            };
        }

        private void SerializeXmlForm_Load(object sender, EventArgs e)
        {
            pg.SelectedObject = data;
            btnPg2Txt.PerformClick();
        }

        private void btnTxt2Pg_Click(object sender, EventArgs e)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    StreamWriter sw = new StreamWriter(ms, Encoding.UTF8);
                    sw.Write(txt.Text);
                    sw.Flush();

                    ms.Position = 0;

                    XmlSerializer serializer = new XmlSerializer(typeof(InternalObject));
                    InternalObject data = (InternalObject)serializer.Deserialize(ms);

                    this.data = data;
                    pg.SelectedObject = data;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPg2Txt_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(InternalObject));
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.Serialize(ms, data);

                    ms.Position = 0;

                    StreamReader sr = new StreamReader(ms, Encoding.UTF8);
                    txt.Text = sr.ReadToEnd();
                }

                txt.SelectionStart = 0;
                txt.SelectionLength = 0;
            }
            catch (Exception exp)
            {
                txt.Text = "";
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
