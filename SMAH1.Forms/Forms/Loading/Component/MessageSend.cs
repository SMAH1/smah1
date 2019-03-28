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
    public class LMessageSend : BaseLoadingComponent
    {
        protected int step = 0;
        protected List<Point> pts;
        protected int d = 0;

        protected Color colorDefault = SystemColors.ControlDark;
        protected Color colorHighlight = SystemColors.Highlight;
        protected bool minimalField = false;

        int start = 0;
        int finish = 0;
        Random rnd;

        public LMessageSend()
        {
            pts = new List<Point>();
            step = 0;

            start = 0;
            rnd = new Random();
            NewFinish();
        }

        [Category("Custom")]
        public Color Default
        {
            get { return colorDefault; }
            set { colorDefault = value; Redraw(); }
        }

        [Category("Custom")]
        public Color Highlight
        {
            get { return colorHighlight; }
            set { colorHighlight = value; Redraw(); }
        }

        [Category("Custom")]
        public bool Minimal
        {
            get { return minimalField; }
            set { minimalField = value; step = 0; start = 0; pts.Clear(); NewFinish(); Redraw(); }
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
            step %= 4;
            Redraw();
        }

        public override void Paint(Graphics gr)
        {
            if (Parent == null) return;
            if (pts.Count == 0) CreateObjects();

            if (step >= pts.Count) step = 0; 

            Brush brBack = new SolidBrush(Parent.BackColor);
            gr.FillRectangle(brBack, Parent.ClientRectangle);
            brBack.Dispose();

            Brush brDefault = new SolidBrush(colorDefault);
            Pen penDefault = new Pen(colorDefault, 1F);
            Brush brHighlight = new SolidBrush(colorHighlight);
            Pen penHighlight = new Pen(colorHighlight, 2F);

            penDefault.DashStyle = DashStyle.Dash;

            var d2 = d / 2;
            foreach (var pt in pts)
                gr.FillEllipse(brDefault, pt.X - d2, pt.Y - d2, d, d);
            for (int i = 0; i < pts.Count - 1; i++)
                for (int j = i + 1; j < pts.Count; j++)
                    gr.DrawLine(penDefault, pts[i], pts[j]);

            Point p;

            switch (step)
            {
                case 0:
                    p = pts[start];
                    gr.FillEllipse(brHighlight, p.X - d2, p.Y - d2, d, d);
                    break;
                case 1:
                    p = pts[start];
                    gr.FillEllipse(brHighlight, p.X - d2, p.Y - d2, d, d);
                    gr.DrawLine(penHighlight, p.X, p.Y, (p.X + pts[finish].X) / 2, (p.Y + pts[finish].Y) / 2);
                    break;
                case 2:
                    gr.DrawLine(penHighlight, pts[start], pts[finish]);
                    break;
                case 3:
                    p = pts[finish];
                    gr.FillEllipse(brHighlight, p.X - d2, p.Y - d2, d, d);
                    gr.DrawLine(penHighlight, p.X, p.Y, (p.X + pts[start].X) / 2, (p.Y + pts[start].Y) / 2);

                    start = finish;
                    NewFinish();
                    break;
            }


            brDefault.Dispose();
            penDefault.Dispose();
            brHighlight.Dispose();
            penHighlight.Dispose();
        }
        #endregion

        private void CreateObjects()
        {
            pts.Clear();

            if (Parent == null)
                return;

            int w = Parent.ClientRectangle.Width - 4;
            int h = Parent.ClientRectangle.Height - 4;

            if (w < 10 || h < 10) return;

            w = w * 7 / 10;
            h = h * 7 / 10;

            int x = Parent.ClientRectangle.X + (Parent.ClientRectangle.Width - w) / 2;
            int y = Parent.ClientRectangle.Y + (Parent.ClientRectangle.Height - h) / 2;
            int cx = x + w / 2;
            int cy = y + h / 2;
            d = Math.Min(w / 6, h / 6);

            pts.Add(new Point(cx, cy - h / 2));
            pts.Add(new Point(cx + w / 2, cy));
            pts.Add(new Point(cx, cy + h / 2));
            pts.Add(new Point(cx - w / 2, cy));

            if (!minimalField)
            {
                pts.Add(new Point(cx - w / 2, cy - h / 2));
                pts.Add(new Point(cx - w / 2, cy + h / 2));
                pts.Add(new Point(cx + w / 2, cy - h / 2));
                pts.Add(new Point(cx + w / 2, cy + h / 2));
            }
        }

        private void NewFinish()
        {
            if (minimalField)
            {
                finish = start;
                while (finish == start)
                    finish = rnd.Next(1000) % 4;
            }
            else
            {
                int i = start;
                while (i == start || i == finish)
                    i = rnd.Next(1000) % 8;
                finish = i;
            }
        }
    }
}
