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
    public class LClock : BaseLoadingComponent
    {
        protected Color colorSign = SystemColors.InactiveCaptionText;
        protected Color colorNeedle = SystemColors.ActiveCaption;
        protected int signAngle = 20;
        protected int rotate = 0;

        public LClock() : this(false) { }

        public LClock(bool bNotStartFromZeroAngle)
        {
            signAngle = 6;
            rotate = 0;

            if (bNotStartFromZeroAngle)
                NotStartFromZeroAngle();
        }

        protected void NotStartFromZeroAngle()
        {
            int i = 360 / signAngle;
            Random r = new Random();
            rotate = (r.Next(i) * signAngle) % 360;
        }

        [Category("Custom")]
        public Color Sign
        {
            get { return colorSign; }
            set { colorSign = value; Redraw(); }
        }

        [Category("Custom")]
        public Color Needle
        {
            get { return colorNeedle; }
            set { colorNeedle = value; Redraw(); }
        }

        private void Redraw()
        {
            if (Parent != null)
                Parent.Refresh();
        }

        #region ILoadingComponent Members

        public override void Tick()
        {
            rotate += signAngle;
            if (rotate >= 360)
            {
                rotate = 0;
            }
            Redraw();
        }

        public override void Paint(Graphics gr)
        {
            if (Parent == null)
                return;

            float w = Parent.ClientRectangle.Width / 2F;
            float h = Parent.ClientRectangle.Height / 2F;

            if (w > 2 && h > 2)
            {
                Brush brBack = new SolidBrush(Parent.BackColor);
                Pen pSign = new Pen(colorSign);
                Pen pNeedle = new Pen(colorNeedle, 4);

                gr.FillRectangle(brBack, Parent.ClientRectangle);

                var smoothingMode = gr.SmoothingMode;
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                gr.TranslateTransform(w, h);

                float min2 = Math.Min(w, h);
                float min = min2 * 2;
                float min4 = min2 / 2;
                float min8 = min4 / 2;
                float min16 = min8 / 2;

                int j = 0;
                for (int i = 0; i < 360; i += signAngle)
                {
                    if (i % 30 == 0)
                        gr.DrawLine(pSign, min2 - min8, 0, min2, 0);
                    else
                        gr.DrawLine(pSign, min2 - min16, 0, min2, 0);

                    if (i == rotate)
                    {
                        gr.DrawLine(pNeedle, 0, 0, min4 + min8, 0);
                    }

                    gr.RotateTransform(signAngle);
                    j += signAngle;
                }
                gr.RotateTransform(-j);

                gr.TranslateTransform(-w, -h);

                gr.SmoothingMode = smoothingMode;

                pSign.Dispose();
                pNeedle.Dispose();
                brBack.Dispose();
            }
        }
        #endregion
    }
}
