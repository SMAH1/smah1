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
    public class LYingYang : BaseLoadingComponent
    {
        private const int CIRCLE_DIAMOND = 10;

        protected int step = 0;

        protected Color color1Field = Color.Black;
        protected Color color2Field = Color.White;
        protected bool drawLine = true;
        protected Color colorLine = Color.Black;

        protected int width = -1;
        protected Point location = new Point(-1, -1);

        public LYingYang()
        {
            step = (new Random()).Next(0, 36);
        }

        [Category("Custom")]
        public Color Line
        {
            get { return colorLine; }
            set { colorLine = value; Redraw(); }
        }

        [Category("Custom")]
        public Color Color1
        {
            get { return color1Field; }
            set { color1Field = value; Redraw(); }
        }

        [Category("Custom")]
        public Color Color2
        {
            get { return color2Field; }
            set { color2Field = value; Redraw(); }
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
            step %= 36;
            Redraw();
        }

        public override void Paint(Graphics gr)
        {
            if (Parent == null) return;
            if (width < 0) CreateObjects();

            Brush brBack = new SolidBrush(Parent.BackColor);
            gr.FillRectangle(brBack, Parent.ClientRectangle);
            brBack.Dispose();

            if (width == 0) return;

            Pen penLine = null;
            if (drawLine)
                penLine = new Pen(colorLine, 1F);
            Brush br1 = new SolidBrush(color1Field);
            Brush br2 = new SolidBrush(color2Field);

            int signAngle = step * 30;

            int w2 = width / 2;
            int x = location.X + w2;
            int y = location.Y + w2;

            var smoothingMode = gr.SmoothingMode;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            gr.TranslateTransform(x, y);
            gr.RotateTransform(signAngle);
            gr.TranslateTransform(-x, -y);

            DrawTaijitu(gr, location, width, br1, br2, penLine);

            gr.TranslateTransform(x, y);
            gr.RotateTransform(-signAngle);
            gr.TranslateTransform(-x, -y);

            gr.SmoothingMode = smoothingMode;

            if (penLine != null)
                penLine.Dispose();
            br1.Dispose();
            br2.Dispose();
        }
        #endregion

        private void CreateObjects()
        {
            location = new Point(0, 0);
            width = 0;

            if (Parent == null) return;

            int w = Parent.ClientRectangle.Width - 4;
            int h = Parent.ClientRectangle.Height - 4;

            if (w < CIRCLE_DIAMOND || h < CIRCLE_DIAMOND) return;

            w = h = Math.Min(w, h);

            int x = Parent.ClientRectangle.X + (Parent.ClientRectangle.Width - w) / 2;
            int y = Parent.ClientRectangle.Y + (Parent.ClientRectangle.Height - h) / 2;

            location = new Point(x, y);
            width = w;
        }

        private void DrawTaijitu(Graphics g, Point pt, int width, Brush br1, Brush br2, Pen pen)
        {
            g.FillPie(br1, pt.X, pt.Y, width, width, 90, 180);
            g.FillPie(br2, pt.X, pt.Y, width, width, 270, 180);
            float headSize = Convert.ToSingle(width * 0.5);
            float headXPosition = Convert.ToSingle(pt.X + (width * 0.25));
            g.FillEllipse(br1, headXPosition, Convert.ToSingle(pt.Y), headSize, headSize);
            g.FillEllipse(br2, headXPosition, Convert.ToSingle(pt.Y + (width * 0.5)), headSize, headSize);
            float headBlobSize = Convert.ToSingle(width * 0.125);
            float headBlobXPosition = Convert.ToSingle(pt.X + (width * 0.4375));
            g.FillEllipse(br2, headBlobXPosition, Convert.ToSingle(pt.Y + (width * 0.1875)), headBlobSize, headBlobSize);
            g.FillEllipse(br1, headBlobXPosition, Convert.ToSingle(pt.Y + (width * 0.6875)), headBlobSize, headBlobSize);
            if (pen != null) g.DrawEllipse(pen, pt.X, pt.Y, width, width);
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
