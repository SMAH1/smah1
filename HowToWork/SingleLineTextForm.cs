using SMAH1.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class SingleLineTextForm : Form
    {
        public SingleLineTextForm()
        {
            InitializeComponent();
        }

        private void SingleLineTextForm_Paint(object sender, PaintEventArgs e)
        {
            Draw(
                e,
                e.ClipRectangle.X + 20,
                e.ClipRectangle.Y + 40,
                chbxFixedHeight.Checked
                );
        }

        private void Draw(PaintEventArgs e, float x, float y, bool fixedHeight)
        {
            SingleLineText slt = new SingleLineText("");
            slt.Add("One x_1$ Two^2$", '$', '_', '^');
            slt.Add("خیاط", SingleLineText.TextFromBaseLine.Normal, true);
            slt.Add("One x_1$ Two^2$ ", '$', '_', '^');

            SingleLineText slt2 = new SingleLineText("");
            slt2.Add("خیاط", SingleLineText.TextFromBaseLine.Normal, true);

            SingleLineText slt3 = new SingleLineText("");
            slt3.Add("Ali", SingleLineText.TextFromBaseLine.Normal, false);

            Font f = new Font("Tahoma", 16);

            SizeF sz = slt.MeasureString(e.Graphics, f, fixedHeight);
            slt.DrawString(e.Graphics, f, Brushes.Black, x, y, fixedHeight);
            if (chbxAreaLine.Checked)
                e.Graphics.DrawRectangle(Pens.Red, x, y, sz.Width, sz.Height);
            y += sz.Height;

            sz = slt2.MeasureString(e.Graphics, f, fixedHeight);
            slt2.DrawString(e.Graphics, f, Brushes.Black, x, y, fixedHeight);
            if (chbxAreaLine.Checked)
                e.Graphics.DrawRectangle(Pens.Red, x, y, sz.Width, sz.Height);
            y += sz.Height;

            sz = slt3.MeasureString(e.Graphics, f, fixedHeight);
            slt3.DrawString(e.Graphics, f, Brushes.Black, x, y, fixedHeight);
            if (chbxAreaLine.Checked)
                e.Graphics.DrawRectangle(Pens.Red, x, y, sz.Width, sz.Height);
            y += sz.Height;
        }

        private void chbx_CheckedChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
