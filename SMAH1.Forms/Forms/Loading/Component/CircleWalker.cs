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
    public class LCircleWalker : BaseLoadingComponent
    {
        private const int CIRCLE_DIAMOND = 20;

        protected int step = 0;
        List<Rectangle> rcs = new List<Rectangle>();

        protected Color colorLine = SystemColors.ControlDark;
        protected Color colorFill = SystemColors.ButtonHighlight;
        protected bool drawLine = true;
        protected Point center;

        public LCircleWalker()
        {
            step = (new Random()).Next(0, 11);
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
            step %= 12;
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

            Pen penLine = new Pen(colorLine, rcs[0].Width / 10F);
            Brush brFill = new SolidBrush(colorFill);

            int signAngle = step * 30;

            var smoothingMode = gr.SmoothingMode;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            gr.TranslateTransform(center.X, center.Y);
            gr.RotateTransform(signAngle);
            gr.TranslateTransform(-center.X, -center.Y);

            foreach (Rectangle rc in rcs)
            {
                gr.FillEllipse(brFill, rc);
                if (drawLine)
                    gr.DrawEllipse(penLine, rc);
            }

            gr.TranslateTransform(center.X, center.Y);
            gr.RotateTransform(-signAngle);
            gr.TranslateTransform(-center.X, -center.Y);

            gr.SmoothingMode = smoothingMode;

            penLine.Dispose();
            brFill.Dispose();
        }
        #endregion

        private void CreateObjects()
        {
            rcs.Clear();
            center = new Point(0, 0);

            if (Parent == null) return;

            int w = Parent.ClientRectangle.Width - 4;
            int h = Parent.ClientRectangle.Height - 4;

            if (w < CIRCLE_DIAMOND || h < CIRCLE_DIAMOND) return;

            w = h = Math.Min(w, h);
            var d = w / 5 - 2;
            var d2 = d / 2;
            var d3 = d / 3;
            var d4 = d / 4;

            int x = Parent.ClientRectangle.X + (Parent.ClientRectangle.Width - w) / 2;
            int y = Parent.ClientRectangle.Y + (Parent.ClientRectangle.Height - h) / 2;

            int wh2 = w / 2;    //== h/2
            x += wh2;
            y += wh2;

            wh2 -= d2;

            for (int i = 0; i < 12; i++)
            {
                var x1 = x + (int)(Math.Cos(DegreeToRadian(30 * i - 90)) * wh2);
                var y1 = y + (int)(Math.Sin(DegreeToRadian(30 * i - 90)) * wh2);

                if (i == 0)
                    rcs.Add(new Rectangle(x1 - d2, y1 - d2, d2 * 2, d2 * 2));
                else if (i == 11)
                    rcs.Add(new Rectangle(x1 - d3, y1 - d3, d3 * 2, d3 * 2));
                else
                    rcs.Add(new Rectangle(x1 - d4, y1 - d4, d4 * 2, d4 * 2));
            }

            center = new Point(x, y);
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
