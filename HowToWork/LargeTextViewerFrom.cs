using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class LargeTextViewerForm : Form
    {
        Dictionary<ToolStripMenuItem, Color> dicColorMenuItem = new Dictionary<ToolStripMenuItem, Color>();

        public LargeTextViewerForm()
        {
            InitializeComponent();

            scrollToEndToolStripMenuItem.Checked = true;
            toolStripSplitButton1.Text = scrollToEndToolStripMenuItem.Text;

            strCountAppluForMenu = ddb.Text;
            ddb.Text = strCountAppluForMenu + "(" + count + ")";

            viText.Font = new Font("Consolas", 9.75F);

            viText.BackColor = SystemColors.Control;
        }

        private void ColorSelectBackGraoundSetup()
        {
            dicColorMenuItem.Add(transparentToolStripMenuItem, Color.Transparent);
            dicColorMenuItem.Add(khakiToolStripMenuItem, Color.Khaki);
            dicColorMenuItem.Add(windowsToolStripMenuItem, SystemColors.Window);
            dicColorMenuItem.Add(orangeToolStripMenuItem, Color.Orange);
            dicColorMenuItem.Add(sprinGreenToolStripMenuItem, Color.SpringGreen);

            foreach (var key in dicColorMenuItem.Keys)
                key.Click += new EventHandler(colorMenuItem_Click);

            colorMenuItem_Click(orangeToolStripMenuItem, new EventArgs());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (ToolStripItem item in ddb.DropDownItems)
                item.Click += new EventHandler(item_Click);
            ColorSelectBackGraoundSetup();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        #region Test
        string[] sa = new string[] {
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
            "1234567890",
            "این هم متن فارسی",
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz()!@#$%^&*+-*/",
            "filename = System.IO.Path.GetTempFileName();",
            "fs = File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);",
            "Color[] ca = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Lime, Color.Yellow, Color.SeaGreen };",
            "this.Size.Height - (this.HorizontalScroll.Visible ? SystemInformation.HorizontalScrollBarThumbWidth : 0) + 1",
        };
        Random r = new Random();

        int count = 1;
        string strCountAppluForMenu = "";

        void item_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            count = int.Parse(item.Text);
            ddb.Text = strCountAppluForMenu + "(" + count + ")";
        }

        private void addByLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viText.Redrawable = false;
            for (int i = 0; i < count; i++)
            {
                string s = sa[r.Next(0, sa.Length)];
                viText.AppendText(s + Environment.NewLine);
            }

            if (scrollToEndToolStripMenuItem.Checked)
                viText.ScrollToEnd();
            viText.Redrawable = true;
        }

        private void addByLineAndColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viText.Redrawable = false;
            Color[] ca = new Color[] {
                Color.Transparent,Color.Transparent,Color.Transparent,
                Color.Red,Color.Blue,Color.Green,
                Color.Lime,Color.Pink,Color.RoyalBlue,
            };
            for (int i = 0; i < count; i++)
            {
                string s = sa[r.Next(0, sa.Length)];
                viText.AppendText(s + Environment.NewLine, ca[r.Next(0, ca.Length)]);
            }

            if (scrollToEndToolStripMenuItem.Checked)
                viText.ScrollToEnd();
            viText.Redrawable = true;
        }

        private void addByLineAndForeBackColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viText.Redrawable = false;
            Color[] caFore = new Color[] {
                Color.Transparent,Color.Transparent,Color.Transparent,
                Color.Red,Color.Blue,Color.Green,
                Color.Lime,Color.Pink,Color.RoyalBlue,
            };
            Color[] caBack = new Color[] {
                Color.Transparent,Color.Transparent,Color.Transparent,
                Color.Yellow,Color.YellowGreen,Color.WhiteSmoke,
                SystemColors.ControlLight,SystemColors.ControlDark,SystemColors.Highlight,
                SystemColors.Info,SystemColors.InactiveCaption,
            };
            for (int i = 0; i < count; i++)
            {
                string s = sa[r.Next(0, sa.Length)];
                viText.AppendText(s + Environment.NewLine,
                    caFore[r.Next(0, caFore.Length)],
                    caBack[r.Next(0, caBack.Length)]
                    );
            }

            if (scrollToEndToolStripMenuItem.Checked)
                viText.ScrollToEnd();
            viText.Redrawable = true;
        }

        private void addContinuseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viText.Redrawable = false;
            for (int i = 0; i < count; i++)
            {
                string s = "";
                int k = r.Next(1, 10);
                for (int j = 0; j < k; j++)
                    s += j;
                viText.AppendText(s);
            }
            viText.Redrawable = true;
        }

        private void addLongContinuseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viText.Redrawable = false;
            char[] ca = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            for (int i = 0; i < count; i++)
            {
                string s = "";
                int k = r.Next(1, ca.Length);
                for (int j = 0; j < k; j++)
                    s += ca[j];
                s += " ";
                viText.AppendText(s);
            }
            viText.Redrawable = true;
        }

        private void addLongContinuseColoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viText.Redrawable = false;
            Color[] caFore = new Color[] {
                Color.Transparent,Color.Transparent,Color.Transparent,
                Color.Red,Color.Blue,Color.Green,
                Color.Lime,Color.Pink,Color.RoyalBlue,
            };
            Color[] caBack = new Color[] {
                Color.Transparent,Color.Transparent,Color.Transparent,
                Color.Yellow,Color.YellowGreen,Color.WhiteSmoke,
                SystemColors.ControlLight,SystemColors.ControlDark,SystemColors.Highlight,
                SystemColors.Info,SystemColors.InactiveCaption,
            };

            viText.Redrawable = false;
            char[] ca = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            for (int i = 0; i < count; i++)
            {
                string s = "";
                int k = r.Next(1, ca.Length);
                for (int j = 0; j < k; j++)
                    s += ca[j];
                s += " ";
                viText.AppendText(s, caFore[r.Next(0, caFore.Length)], caBack[r.Next(0, caBack.Length)]);
            }
            viText.Redrawable = true;
        }

        private void endLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viText.AppendText(Environment.NewLine);
        }

        private void endLineColoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color[] caBack = new Color[] {
                Color.Transparent,Color.Transparent,Color.Transparent,
                Color.Yellow,Color.YellowGreen,Color.WhiteSmoke,
                SystemColors.ControlLight,SystemColors.ControlDark,SystemColors.Highlight,
                SystemColors.Info,SystemColors.InactiveCaption,
            };

            viText.AppendText(Environment.NewLine, Color.Empty, caBack[r.Next(0, caBack.Length)]);
        }

        private void testDeafultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viText.Redrawable = false;
            string s1 = "012345679WERFGHFGHjeuiwhjf35rfb%$#^@*((skd375897389FGHjeuiwhjf35375897389FGHjeuiwhjf35375897389JKmnblkhdfkhs7389SJKHFJHASDFDFHsdfjkhsdjkfhuiyurfb%$#^@*((skdfhasjkghfuxcvbfhasdkgjdfjkl43488348563489187389SJKHFJHASDFDFHsdfjkhsdjkfhuiyurfb%$#^@*((skdfhasjkghfuxcvb7389SJKHFJHASDFDFHsdfjkhsdjkfhuiyurfb%$#^@*((skdfhasjkghuiwhjf35375rfb%$#^@*((skd897389FGHjeuiwhjf353758973rfb%$#^@*((skdrfb%$#^@*((skd89JKmnblkhdfkhs7389SJKHFJHASDFDfuxcvb7389SJKHFJHASDFDFHsdfjkhsdjkfhuiyurfb%$#^@*((skdfhasjkghfuxcvb7389SJKHFJHASDFDFHsdfjkhsdjkfhuiyurfb%$#^@*((skdfhasjkghfuxcvb9576345347000835734=-=-=-545648987/*/-44fhsjdfhsdfhg74dsbdfhsbdcvfhajkbxcvnbxznbvzxn";
            string s2 = "ABCDEFGHjeuiwhjf35375897389SJKHFJHASDFDFHhjf35rfb%$#^@*((skd375897389FGHjeuiwhjf35375897389FGHjeuiwhjf3537589738hjf35rfb%$#^@*((skd375897389FGHjeuiwhjf35375897389FGHjeuiwhjf3537589738hjf35rfb%$#^@*((skd375897389FGHjeuiwhjf35375897389FGHjeuiwhjf3537589738sdfjkhsdjkfhuiyurfb%$#^@*((skdfhasjkghfuxcvbgeugrf00022834WUIERI8743487xxxxxxxiyurfb%$#^@*((skdfhasjkghfuxcvbgeugrf00022834WUxxxxxxxx";
            string s3 = "AAA";
            viText.AppendText(s1, Color.Green);
            viText.AppendText(s2, Color.Red);
            viText.AppendText("BBB");
            viText.AppendText(s3 + Environment.NewLine, Color.Green);
            viText.AppendText(s1 + s2 + s3, Color.Blue);
            viText.Redrawable = true;
        }

        private void testDefault2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char[] ca = "0123456789ABCD0123456789ABCD0123456789ABCD0123456789ABCD0123456789ABCD".ToCharArray();
            for (int i = 0; i < ca.Length; i++)
            {
                string s = string.Format("{1}{2}{3}{4}{5}", Environment.NewLine, ca[i], ca[i], ca[i], ca[i], ca[i]);
                s = string.Format("{1}{2}{3}{4}{5}{0}", Environment.NewLine, s, s, s, s, s);
                viText.AppendText(s);
            }
        }

        private void testDefault3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char[] ca = "0123456789ABCD0123456789ABCD0123456789ABCD0123456789ABCD0123456789ABCD".ToCharArray();
            for (int i = 0; i < ca.Length; i++)
            {
                string s = string.Format("{1}{2}{3}{4}{5}", Environment.NewLine, ca[i], ca[i], ca[i], ca[i], ca[i]);
                s = string.Format("{1}{2}{3}{4}{5}", Environment.NewLine, s, s, s, s, s);
                s = string.Format("{1}{2}{3}{4}{5}{0}", Environment.NewLine, s, s, s, s, s);
                viText.AppendText(s);
            }
        }
        #endregion

        private void scrollToEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scrollToEndToolStripMenuItem.Checked = false;
            notScrollToEndToolStripMenuItem.Checked = false;

            scrollToEndToolStripMenuItem.Checked = true;
            toolStripSplitButton1.Text = scrollToEndToolStripMenuItem.Text;
        }

        private void notScrollToEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scrollToEndToolStripMenuItem.Checked = false;
            notScrollToEndToolStripMenuItem.Checked = false;

            notScrollToEndToolStripMenuItem.Checked = true;
            toolStripSplitButton1.Text = notScrollToEndToolStripMenuItem.Text;
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = viText.Font;
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                viText.Font = fd.Font;
            }
        }

        private void resetFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viText.Font = this.Font;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viText.Text = string.Empty;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Title = "";
            sv.Filter = "Text file|*.txt";
            if (sv.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                viText.SaveTextToFile(sv.FileName);
            }
        }

        private void colorMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var key in dicColorMenuItem.Keys)
                key.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;

            viText.SelectedBackColor = dicColorMenuItem[(ToolStripMenuItem)sender];
        }
    }
}
