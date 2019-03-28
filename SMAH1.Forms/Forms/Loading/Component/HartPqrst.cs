using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace SMAH1.Forms.Loading.Component
{
    [DesignerCategory("SMAH1")]
    [ToolboxItem(true)]
    [DesignTimeVisible(true)]
    public class LHartPqrst : BaseLoadingComponent
    {
        protected int step = 0;
        protected int x, y, w, h, dx;
        Bitmap bmp;

        protected Color colorLine = SystemColors.WindowText;
        protected Color colorGrid = SystemColors.ControlDark;
        protected bool hasGridField = true;

        public LHartPqrst()
        {
            step = 0;
            dx = 1;
        }

        [Category("Custom")]
        public Color Line
        {
            get { return colorLine; }
            set
            {
                colorLine = value;
                if (bmp != null) bmp.Dispose();
                bmp = null;
                Redraw();
            }
        }

        [Category("Custom")]
        public Color Grid
        {
            get { return colorGrid; }
            set
            {
                colorGrid = value;
                if (bmp != null) bmp.Dispose();
                bmp = null;
                Redraw();
            }
        }

        [Category("Custom")]
        public bool HasGrid
        {
            get { return hasGridField; }
            set
            {
                hasGridField = value;
                if (bmp != null) bmp.Dispose();
                bmp = null;
                Redraw();
            }
        }

        private void Redraw()
        {
            if (Parent != null)
                Parent.Refresh();
        }

        #region ILoadingComponent Members

        public override void StateChange(LoadingStateChange state)
        {
            CreateObjects();
        }

        public override void Tick()
        {
            step += 2;
            step %= 24;
            Redraw();
        }

        public override void Paint(Graphics gr)
        {
            if (Parent == null) return;
            if (bmp == null) CreateObjects();
            if (bmp == null) return;

            Brush brBack = new SolidBrush(Parent.BackColor);
            gr.FillRectangle(brBack, Parent.ClientRectangle);
            brBack.Dispose();

            gr.DrawImage(bmp, new Rectangle(x, y, w, h), new Rectangle(dx * step, 0, w, h), GraphicsUnit.Pixel);
        }
        #endregion

        private void CreateObjects()
        {
            if (Parent == null)
                return;

            w = Parent.ClientRectangle.Width - 4;
            h = Parent.ClientRectangle.Height - 4;

            if (w < 23 || h < 20) return;

            dx = Math.Min(w / 23, h / 20);

            w = dx * 23;
            h = dx * 20;

            x = Parent.ClientRectangle.X + (Parent.ClientRectangle.Width - w) / 2;
            y = Parent.ClientRectangle.Y + (Parent.ClientRectangle.Height - h) / 2;

            List<Point> lst1 = new List<Point>();
            List<Point> lst2 = new List<Point>();

            lst1.Add(new Point(0, 14 * dx));
            lst1.Add(new Point(3 * dx, 14 * dx));
            lst1.Add(new Point(4 * dx, 12 * dx));
            lst1.Add(new Point(5 * dx, 14 * dx));
            lst1.Add(new Point(6 * dx, 14 * dx));
            lst1.Add(new Point(7 * dx, 16 * dx));
            lst1.Add(new Point(9 * dx, 0 * dx));
            lst1.Add(new Point(9 * dx, 20 * dx));
            lst1.Add(new Point(10 * dx, 14 * dx));
            lst1.Add(new Point(12 * dx, 14 * dx));
            lst1.Add(new Point(16 * dx, 10 * dx));
            lst1.Add(new Point(19 * dx, 14 * dx));
            lst1.Add(new Point(21 * dx, 13 * dx));
            lst1.Add(new Point(23 * dx, 14 * dx));
            foreach (var pt in lst1)
                lst2.Add(new Point(pt.X + w, pt.Y));

            bmp = new Bitmap(w * 2, h);
            Pen penLine = new Pen(colorLine, dx / 2F)
            {
                LineJoin = LineJoin.Round
            };
            using (var g = Graphics.FromImage(bmp))
            {
                if (hasGridField)
                {
                    Pen penGrid = new Pen(colorGrid, 0.5F);
                    for (int i = 0; i < 23; i++)
                        g.DrawLine(penGrid, i * dx * 2, 0, i * dx * 2, h);
                    for (int i = 0; i < 11; i++)
                        g.DrawLine(penGrid, 0, i * dx * 2, w * 2, i * dx * 2);
                    penGrid.Dispose();
                }

                g.DrawLines(penLine, lst1.ToArray());
                g.DrawLines(penLine, lst2.ToArray());
            }
            penLine.Dispose();
        }
    }
}
