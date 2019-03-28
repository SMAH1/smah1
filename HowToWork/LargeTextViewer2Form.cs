using SMAH1.Forms.Text;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class LargeTextViewer2Form : Form
    {
        public LargeTextViewer2Form()
        {
            InitializeComponent();
        }

        string[] sa = new string[] {
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            "1234567890",
            "این هم متن فارسی",
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz()!@#$%^&*+-*/",
            "filename = System.IO.Path.GetTempFileName();",
            "fs = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);",
            "Color[] ca = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Lime, Color.Yellow, Color.SeaGreen };",
            "this.Size.Height - (this.HorizontalScroll.Visible ? SystemInformation.HorizontalScrollBarThumbWidth : 0) + 1",
            "ABCDEFGH 1234567890 ABCDEFGH 1234567890 ABCDEFGH 1234567890 ABCDEFGH 1234567890 ABCDEFGH 1234567890 ABCDEFGH 1234567890 ABCDEFGH 1234567890 ABCDEFGH 1234567890 ",
        };

        private void LargeTextViewer2Form_Load(object sender, EventArgs e)
        {
            FillData();

            ltv1.SelectedIndexChanged += new EventHandler(ltv_SelectedIndexChanged);
            ltv2.SelectedIndexChanged += new EventHandler(ltv_SelectedIndexChanged);

            ltv1.ViewportChanged += new EventHandler(ltv_ViewportChanged);
            ltv2.ViewportChanged += new EventHandler(ltv_ViewportChanged);
        }

        bool ignoreSelectIndexChange = false;
        void ltv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ignoreSelectIndexChange)
            {
                ignoreSelectIndexChange = true;
                LargeTextViewer ltv = (LargeTextViewer)sender;
                if (ltv == ltv1)
                    ltv2.SelectedIndex = ltv.SelectedIndex;
                else
                    ltv1.SelectedIndex = ltv.SelectedIndex;
                ignoreSelectIndexChange = false;

                string[] sa1 = ltv1.GetLines(ltv.SelectedIndex, 1);
                string[] sa2 = ltv2.GetLines(ltv.SelectedIndex, 1);

                ltvRes.Text = sa1[0] + Environment.NewLine + sa2[0];
            }
        }

        bool ignoreViewportChanged = false;
        void ltv_ViewportChanged(object sender, EventArgs e)
        {
            if (!ignoreViewportChanged)
            {
                ignoreViewportChanged = true;
                LargeTextViewer ltv = (LargeTextViewer)sender;
                if (ltv == ltv1)
                    ltv2.UpdateViewportFrom(ltv1);
                else
                    ltv1.UpdateViewportFrom(ltv2);
                ignoreViewportChanged = false;
            }
        }

        private void FillData()
        {
            ltv1.Redrawable = false;
            ltv2.Redrawable = false;

            ltv1.Font =
            ltv2.Font =
            ltvRes.Font =
                new Font("Consolas", 9.75F);

            ltv1.SelectedBackColor =
            ltv2.SelectedBackColor =
                SystemColors.Highlight;

            Random r = new Random();

            Color[] caFore = new Color[] {
                Color.Transparent,
                Color.Red,Color.Yellow,Color.Green,
                Color.Pink,
            };
            Color[] caBack = new Color[] {
                Color.Transparent,
                Color.White,Color.WhiteSmoke,Color.MistyRose,
                Color.LightCyan,Color.LightYellow,Color.FloralWhite,
            };

            for (int i = 0; i < 100; i++)
            {
                string s = sa[r.Next(0, sa.Length)];

                ltv1.AppendText(s + Environment.NewLine,
                    caFore[i % caFore.Length],
                    caBack[i % caBack.Length]
                    );
                ltv2.AppendText(s + Environment.NewLine,
                    caFore[i % caFore.Length],
                    caBack[i % caBack.Length]
                    );
            }

            ltv1.ScrollToEnd();
            ltv2.ScrollToEnd();

            ltv1.Redrawable = true;
            ltv2.Redrawable = true;
        }

        private void btnScrollToEnd_Click(object sender, EventArgs e)
        {
            ltv1.ScrollToEnd();
        }

        private void btnScrollToSelect_Click(object sender, EventArgs e)
        {
            ltv1.ScrollToSelected();
        }
    }
}
