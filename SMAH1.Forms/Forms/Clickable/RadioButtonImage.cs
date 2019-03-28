using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace SMAH1.Forms.Clickable
{
    public class RadioButtonImage : RadioButton
    {
        const int MARGIN = 5;

        public override Size GetPreferredSize(Size proposedSize)
        {
            if (this.Image != null)
                return this.Image.Size + new Size(MARGIN * 2, MARGIN * 2);

            return new Size(16 + 2 * MARGIN, 16 + 2 * MARGIN);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            e.Graphics.FillRectangle(SystemBrushes.Control, new Rectangle(0, 0, this.Width, this.Height));

            if (this.Checked)
            {
                ControlPaint.DrawBorder3D(e.Graphics, 0, 0, this.Width, this.Height, Border3DStyle.Sunken);
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, this.Width, this.Height), this.ForeColor, ButtonBorderStyle.Solid);
            }

            if (this.Image != null)
            {
                int x = (this.Width - this.Image.Width) / 2;
                int y = (this.Height - this.Image.Height) / 2;
                e.Graphics.DrawImage(this.Image,
                    new Rectangle(x, y, this.Image.Width, this.Image.Height),
                    new Rectangle(0, 0, this.Image.Width, this.Image.Height),
                    GraphicsUnit.Pixel);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
        }
    }
}
