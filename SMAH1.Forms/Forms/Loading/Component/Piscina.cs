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
    public class LPiscina : BaseLoadingComponent
    {
        private const int CIRCLE_DIAMOND = 20;

        protected int step = 0;
        List<Rectangle> rcs = new List<Rectangle>();
        List<Brush> brs = new List<Brush>();

        protected Color colorLine = SystemColors.ControlDark;
        protected Color colorFill = SystemColors.Highlight;
        protected bool drawLine = false;
        protected bool continuesField = false;

        public LPiscina()
        {
            step = (new Random()).Next(0, 6) * 6;
        }

        [Category("Custom")]
        public Color Line
        {
            get { return colorLine; }
            set { colorLine = value; Redraw(); }
        }

        [Category("Custom")]
        public Color Fill
        {
            get { return colorFill; }
            set { colorFill = value; rcs.Clear(); Redraw(); }
        }

        [Category("Custom")]
        public bool ShowLine
        {
            get { return drawLine; }
            set { drawLine = value; Redraw(); }
        }

        [Category("Custom")]
        public bool Continues
        {
            get { return continuesField; }
            set { continuesField = value; rcs.Clear(); Redraw(); }
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
            step++;
            step %= 36;
            Redraw();
        }

        public override void Paint(Graphics gr)
        {
            if (Parent == null) return;
            if (rcs.Count == 0) CreateObjects();

            Brush brBack = new SolidBrush(Parent.BackColor);
            gr.FillRectangle(brBack, Parent.ClientRectangle);
            brBack.Dispose();

            if (rcs.Count == 0) return;

            var smoothingMode = gr.SmoothingMode;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen penLine = new Pen(colorLine, 1F);

            if (drawLine)
            {
                foreach (Rectangle rc in rcs)
                    gr.DrawEllipse(penLine, rc);
            }

            int inx1, inx2, fill;

            if (continuesField)
            {
                inx1 = step % 6;
                fill = 0;
                for (int i = 0; i < 4; i++)
                {
                    gr.FillEllipse(brs[fill], rcs[inx1]);

                    inx1++;
                    inx1 %= 6;
                    fill++;
                }
            }
            else
            {
                inx1 = step / 6;
                inx2 = (inx1 + 1) % 6;
                fill = step % 6;

                gr.FillEllipse(brs[6 - 1 - fill], rcs[inx1]);
                gr.FillEllipse(brs[fill], rcs[inx2]);
            }

            penLine.Dispose();

            gr.SmoothingMode = smoothingMode;
        }
        #endregion

        private void CreateObjects()
        {
            rcs.Clear();
            foreach (var br in brs)
                br.Dispose();
            brs.Clear();

            if (Parent == null) return;

            int w = Parent.ClientRectangle.Width - 4;
            int h = Parent.ClientRectangle.Height - 4;

            if (w < CIRCLE_DIAMOND || h < CIRCLE_DIAMOND) return;

            w = h = Math.Min(w, h);
            var d = w / 3 - 2;
            var d2 = d / 2;

            int x = Parent.ClientRectangle.X + (Parent.ClientRectangle.Width - w) / 2;
            int y = Parent.ClientRectangle.Y + (Parent.ClientRectangle.Height - h) / 2;

            x += w / 2;
            y += h / 2;

            for (int i = 0; i < 6; i++)
            {
                var x1 = x + (int)(Math.Cos(DegreeToRadian(60 * i + 30)) * d);
                var y1 = y + (int)(Math.Sin(DegreeToRadian(60 * i + 30)) * d);

                rcs.Add(new Rectangle(x1 - d2, y1 - d2, d, d));
            }

            if (continuesField)
            {
                for (int i = 0; i < 4; i++)
                    brs.Add(new SolidBrush(Color.FromArgb(i * 55 + 35, colorFill)));
            }
            else
            {
                for (int i = 0; i < 6; i++)
                    brs.Add(new SolidBrush(Color.FromArgb(i * 40 + 39, colorFill)));
            }
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
