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
    public class LHourglass : BaseLoadingComponent
    {
        protected int step = 0;
        protected List<Point> ptsMain;
        Point center;
        protected List<Point> ptsLevel;

        protected Color colorLine = SystemColors.WindowText;
        protected Color colorFill = SystemColors.Highlight;

        public LHourglass()
        {
            ptsMain = new List<Point>();
            ptsLevel = new List<Point>();
            step = 1;
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
            set { colorFill = value; Redraw(); }
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
            if (step == 9) step = 1;
            Redraw();
        }

        public override void Paint(Graphics gr)
        {
            if (Parent == null) return;
            if (ptsMain.Count == 0) CreateObjects();
            if (ptsMain.Count == 0) return;

            Brush brBack = new SolidBrush(Parent.BackColor);
            gr.FillRectangle(brBack, Parent.ClientRectangle);
            brBack.Dispose();

            var smoothingMode = gr.SmoothingMode;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (step > 5)
            {
                gr.TranslateTransform(center.X, center.Y);
                switch (step)
                {
                    case 6: gr.RotateTransform(45); break;
                    case 7: gr.RotateTransform(90); break;
                    case 8: gr.RotateTransform(135); break;
                }
                gr.TranslateTransform(-center.X, -center.Y);
            }

            Pen penLine = new Pen(colorLine, 3F);
            //gr.DrawLines(penLine, ptsMain.ToArray());
            gr.DrawCurve(penLine, ptsMain.ToArray());
            penLine.Dispose();

            Brush brFill = new SolidBrush(colorFill);
            Pen penFill = new Pen(colorFill, 3F)
            {
                DashStyle = DashStyle.Dot
            };
            switch (step)
            {
                case 1:
                    gr.FillPolygon(brFill, 
                        new Point[]{
                            center,
                            ptsLevel[0],
                            ptsLevel[1],
                        });
                    break;
                case 2:
                    gr.FillPolygon(brFill,
                        new Point[]{
                            center,
                            ptsLevel[2],
                            ptsLevel[3],
                        });
                    gr.FillPolygon(brFill,
                        new Point[]{
                            ptsLevel[10],
                            ptsLevel[8],
                            ptsLevel[9],
                        });
                    gr.DrawLine(penFill, center, ptsLevel[10]);
                    break;
                case 3:
                    gr.FillPolygon(brFill,
                        new Point[]{
                            center,
                            ptsLevel[4],
                            ptsLevel[5],
                        });
                    gr.FillPolygon(brFill,
                        new Point[]{
                            ptsLevel[11],
                            ptsLevel[8],
                            ptsLevel[9],
                        });
                    gr.DrawLine(penFill, center, ptsLevel[11]);
                    break;
                case 4:
                    gr.FillPolygon(brFill,
                        new Point[]{
                            center,
                            ptsLevel[6],
                            ptsLevel[7],
                        });
                    gr.FillPolygon(brFill,
                        new Point[]{
                            ptsLevel[12],
                            ptsLevel[8],
                            ptsLevel[9],
                        });
                    gr.DrawLine(penFill, center, ptsLevel[12]);
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                    gr.FillPolygon(brFill,
                        new Point[]{
                            center,
                            ptsLevel[8],
                            ptsLevel[9],
                        });
                    break;
            }
            brFill.Dispose();
            penFill.Dispose();

            if (step > 5)
            {
                gr.TranslateTransform(center.X, center.Y);
                switch (step)
                {
                    case 6: gr.RotateTransform(-45); break;
                    case 7: gr.RotateTransform(-90); break;
                    case 8: gr.RotateTransform(-135); break;
                }
                gr.TranslateTransform(-center.X, -center.Y);
            }

            gr.SmoothingMode = smoothingMode;
        }
        #endregion

        private void CreateObjects()
        {
            ptsMain.Clear();
            ptsLevel.Clear();

            if (Parent == null)
                return;

            if (Parent.ClientRectangle.Width < 5 ||
                Parent.ClientRectangle.Height < 5)
                return;

            int w = Parent.ClientRectangle.Width * 7 / 10;
            int h = Parent.ClientRectangle.Height * 7 / 10;

            w = h = Math.Min(w, h);

            int x = Parent.ClientRectangle.X + (Parent.ClientRectangle.Width - w) / 2;
            int y = Parent.ClientRectangle.Y + (Parent.ClientRectangle.Height - h) / 2;
            int cx = x + w / 2;
            int cy = y + h / 2;
            int dx = w / 20;
            int dy = (h - 4) / 8;

            if (dx < 1) dx = 1;

            ptsMain.Add(new Point(x + w, y + h));
            ptsMain.Add(new Point(x, y + h));
            ptsMain.Add(new Point(cx - dx, cy));
            ptsMain.Add(new Point(x, y));
            ptsMain.Add(new Point(x + w, y));
            ptsMain.Add(new Point(cx + dx, cy));
            ptsMain.Add(new Point(x + w, y + h));
            ptsMain.Add(new Point(x, y + h));

            center = new Point(cx, cy);

            var xx = 2;
            var m = h / (float)w;

            //Level of triangel of TOP
            ptsLevel.Add(new Point(x + xx, y + 2));
            ptsLevel.Add(new Point(x + w - xx, y + 2));

            xx = (int)(2 + m * dy * 1);
            ptsLevel.Add(new Point(x + xx, y + 2 + dy));
            ptsLevel.Add(new Point(x + w - xx, y + 2 + dy));

            xx = (int)(2 + m * dy * 2);
            ptsLevel.Add(new Point(x + xx, y + 2 + dy * 2));
            ptsLevel.Add(new Point(x + w - xx, y + 2 + dy * 2));

            xx = (int)(2 + m * dy * 3);
            ptsLevel.Add(new Point(x + xx, y + 2 + dy * 3));
            ptsLevel.Add(new Point(x + w - xx, y + 2 + dy * 3));


            //bottomest level of triangel of BOTTOM
            ptsLevel.Add(new Point(ptsLevel[0].X, y + h - 2));
            ptsLevel.Add(new Point(ptsLevel[1].X, y + h - 2));


            //Center of other level in triangel of BOTTOM
            ptsLevel.Add(new Point(cx, y + h - 2 - dy));
            ptsLevel.Add(new Point(cx, y + h - 2 - dy * 2));
            ptsLevel.Add(new Point(cx, y + h - 2 - dy * 3));
        }
    }
}
