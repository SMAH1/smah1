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
    public class LHartPqrst2 : BaseLoadingComponent
    {
        protected int step = 0;
        protected int x, y, w, h, dx;
        List<Point> lstPoints = null;
        Region rgnSignal = null;

        protected Color colorLine = SystemColors.WindowText;

        public LHartPqrst2()
        {
            step = 0;
            dx = 1;
            lstPoints = new List<Point>();
        }

        [Category("Custom")]
        public Color Line
        {
            get { return colorLine; }
            set
            {
                colorLine = value;
                lstPoints.Clear();
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
            step %= 30;
            Redraw();
        }

        public override void Paint(Graphics gr)
        {
            if (Parent == null) return;
            if (lstPoints.Count == 0) CreateObjects();
            if (lstPoints.Count == 0) return;

            Brush brBack = new SolidBrush(Parent.BackColor);

            gr.FillRectangle(brBack, Parent.ClientRectangle);
            gr.TranslateTransform(x, y);

            if (step <= 24)
            {
                using (LinearGradientBrush brGradient = new LinearGradientBrush(
                    new Point(0, 0), new Point(w, 0), colorLine, Parent.BackColor))
                {
                    var x2 = (float)step / 24;
                    var x1 = x2 - .15f;
                    var x3 = x2 + .15f;

                    if (x1 < 0) x1 = 0F;
                    if (x3 >= 1F) x3 = 1F;

                    Blend blend = new Blend
                    {
                        Factors = new float[] { .0f, .0f, 1f, .0f, 0f },
                        Positions = new float[] { .0f, x1, x2, x3, 1f }
                    };
                    brGradient.Blend = blend;

                    var clip = gr.Clip;
                    gr.Clip = rgnSignal;
                    gr.FillRectangle(brGradient, 0, 0, w, h);
                    gr.Clip = clip;
                }
            }
            else
            {
                using (Brush brLine = new SolidBrush(colorLine))
                {
                    var clip = gr.Clip;
                    gr.Clip = rgnSignal;
                    gr.FillRectangle(brLine, 0, 0, w, h);
                    gr.Clip = clip;
                }
            }
            gr.TranslateTransform(-x, -y);

            brBack.Dispose();
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

            lstPoints.Clear();

            lstPoints.Add(new Point(0, 14 * dx));
            lstPoints.Add(new Point(3 * dx, 14 * dx));
            lstPoints.Add(new Point(4 * dx, 12 * dx));
            lstPoints.Add(new Point(5 * dx, 14 * dx));
            lstPoints.Add(new Point(6 * dx, 14 * dx));
            lstPoints.Add(new Point(7 * dx, 16 * dx));
            lstPoints.Add(new Point(9 * dx, 0 * dx));
            lstPoints.Add(new Point(9 * dx, 20 * dx));
            lstPoints.Add(new Point(10 * dx, 14 * dx));
            lstPoints.Add(new Point(12 * dx, 14 * dx));
            lstPoints.Add(new Point(16 * dx, 10 * dx));
            lstPoints.Add(new Point(19 * dx, 14 * dx));
            lstPoints.Add(new Point(21 * dx, 13 * dx));
            lstPoints.Add(new Point(23 * dx, 14 * dx));

            GraphicsPath gp = new GraphicsPath();

            int dx2 = dx / 4;

            gp.StartFigure();
            gp.AddLines(lstPoints.ToArray());

            Pen penLine = new Pen(colorLine, dx / 1.2F)
            {
                LineJoin = LineJoin.Round
            };
            gp.Widen(penLine);

            if (rgnSignal != null) rgnSignal.Dispose();
            rgnSignal = new Region(gp);

            penLine.Dispose();
        }
    }
}
