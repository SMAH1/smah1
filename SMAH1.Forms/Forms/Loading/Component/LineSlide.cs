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
    public class LLineSlide : BaseLoadingComponent
    {
        private const int RIBBON_WIDTH = 10;
        private const int RIBBON_HEIGHT = 10;
        private const int CIRCLE_DIAMOND = 20;

        protected int dx = 1;
        protected int step = 0;
        protected int stepMax = 0;
        protected Point startField;
        protected int ribbonWidth = 0;
        protected GraphicsPath path;
        protected Region rgn;

        protected Color colorLine = SystemColors.ControlDark;
        protected Color colorFill = SystemColors.Highlight;

        public LLineSlide()
        {
            startField = new Point();
            step = 0;
            stepMax = 0;
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
            if (stepMax == 0)
            {
                step = 0;
                dx = 1;
            }
            else
            {
                step += dx;
                if (step < 0)
                {
                    dx = 1;
                    step = 0;
                }
                else if (step >= stepMax)
                {
                    dx = -1;
                    step = stepMax - 1;
                }
            }
            Redraw();
        }

        public override void Paint(Graphics gr)
        {
            if (Parent == null) return;
            if (stepMax == 0) CreateObjects();

            Brush brBack = new SolidBrush(Parent.BackColor);
            gr.FillRectangle(brBack, Parent.ClientRectangle);
            brBack.Dispose();

            if (stepMax == 0) return;

            Pen penLine = new Pen(colorLine, 2F);
            Brush brFill = new SolidBrush(colorFill);

            var smoothingMode = gr.SmoothingMode;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            gr.DrawPath(penLine, path);

            if (step > stepMax) step = stepMax;

            var rc = new Rectangle(startField.X - ribbonWidth, startField.Y, ribbonWidth, CIRCLE_DIAMOND);

            var oldRegion = gr.Clip;
            gr.Clip = rgn;
            rc.Offset(ribbonWidth * step, 0);
            gr.FillRectangle(brFill, rc);
            gr.Clip = oldRegion;

            gr.SmoothingMode = smoothingMode;

            penLine.Dispose();
            brFill.Dispose();
        }
        #endregion

        private void CreateObjects()
        {
            stepMax = 0;

            if (Parent == null) return;

            int w = Parent.ClientRectangle.Width - 4;
            int h = Parent.ClientRectangle.Height - 4;

            if (w < CIRCLE_DIAMOND || h < CIRCLE_DIAMOND) return;

            w = w * 7 / 10;
            h = CIRCLE_DIAMOND;

            ribbonWidth = Math.Max(RIBBON_WIDTH, w / 7);

            int x = Parent.ClientRectangle.X + (Parent.ClientRectangle.Width - w) / 2;
            int y = Parent.ClientRectangle.Y + (Parent.ClientRectangle.Height - h) / 2;

            stepMax = (w + 3 * ribbonWidth - 1) / ribbonWidth;

            path = new GraphicsPath();

            path.AddArc(x, y, CIRCLE_DIAMOND, CIRCLE_DIAMOND, 90, 180);
            path.AddArc(x + w - CIRCLE_DIAMOND, y, CIRCLE_DIAMOND, CIRCLE_DIAMOND, 270, 180);
            path.CloseFigure();

            rgn = new Region(path);

            startField = new Point(x, y);
        }
    }
}
