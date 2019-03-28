using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace SMAH1.Forms.Loading.Component
{
    [DesignerCategory("SMAH1")]
    [ToolboxItem(true)]
    [DesignTimeVisible(true)]
    public class LCircularMinimalist : BaseLoadingComponent
    {
        protected int rotate = 0;
        protected const int stepRotate = 20;

        protected Color colorLine = SystemColors.ControlDark;

        public LCircularMinimalist()
        {
            rotate = 0;
        }

        [Category("Custom")]
        public Color Line
        {
            get { return colorLine; }
            set { colorLine = value; Redraw(); }
        }

        private void Redraw()
        {
            if (Parent != null)
                Parent.Refresh();
        }

        #region ILoadingComponent Members

        public override void Tick()
        {
            rotate += stepRotate;
            if (rotate == 360)
                rotate = 0;
            Redraw();
        }

        public override void Paint(Graphics gr)
        {
            if (Parent == null) return;

            Brush brBack = new SolidBrush(Parent.BackColor);
            Brush brLine = new SolidBrush(colorLine);

            int w = Parent.ClientRectangle.Width - 4;
            int h = Parent.ClientRectangle.Height - 4;

            gr.FillRectangle(brBack, Parent.ClientRectangle);

            if (w < 10 || h < 10) return;

            var smoothingMode = gr.SmoothingMode;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            w = h = Math.Min(w * 2 / 3, h * 2 / 3);
            int radiusInternal = w * 2 / 3;

            int x = Parent.ClientRectangle.X + (Parent.ClientRectangle.Width - w) / 2;
            int y = Parent.ClientRectangle.Y + (Parent.ClientRectangle.Height - h) / 2;

            int pinnacle = w / 4;
            int thickness = w / 8;

            Pen penLine = new Pen(colorLine, thickness / 2F)
            {
                LineJoin = LineJoin.Round
            };

            int[] transform = new int[] { x + w / 2, y + h / 2, 45 };

            gr.TranslateTransform(transform[0], transform[1]);
            gr.RotateTransform(-transform[2]);
            gr.TranslateTransform(-transform[0], -transform[1]);

            gr.FillEllipse(brLine, x, y, w, h);
            gr.FillPolygon(brLine, new Point[] { new Point(x - pinnacle, y + h / 2), new Point(x + w / 2, y + h / 2 - pinnacle), new Point(x + w / 2, y + h / 2 + pinnacle) });

            x += thickness;
            y += thickness;
            w -= 2 * thickness;
            h -= 2 * thickness;

            gr.FillEllipse(brBack, x, y, w, h);
            gr.FillPolygon(brBack, new Point[] { new Point(x - pinnacle + thickness, y + h / 2), new Point(x + w / 2, y + h / 2 - pinnacle), new Point(x + w / 2, y + h / 2 + pinnacle) });

            x += thickness*2;
            y += thickness*2;
            w -= 4 * thickness;
            h -= 4 * thickness;

            gr.DrawArc(penLine, x, y, w, h, rotate, 90);
            gr.DrawArc(penLine, x, y, w, h, rotate + 180, 90);

            gr.TranslateTransform(transform[0], transform[1]);
            gr.RotateTransform(transform[2]);
            gr.TranslateTransform(-transform[0], -transform[1]);

            gr.SmoothingMode = smoothingMode;

            brBack.Dispose();
            brLine.Dispose();
            penLine.Dispose();
        }
        #endregion
    }
}
