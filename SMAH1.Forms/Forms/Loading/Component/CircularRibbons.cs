using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace SMAH1.Forms.Loading.Component
{
    [DesignerCategory("SMAH1")]
    [ToolboxItem(true)]
    [DesignTimeVisible(true)]
    public class LCircularRibbons : BaseLoadingComponent
    {
        protected int rotateRibbon1 = 0;
        protected const int stepRibbon1 = 15;
        protected int rotateRibbon2 = 0;
        protected const int stepRibbon2 = 10;

        protected Color colorOuter = SystemColors.Highlight;
        protected Color colorInner = SystemColors.ActiveCaption;

        public LCircularRibbons()
        {
            rotateRibbon1 = 0;
            rotateRibbon2 = 0;
        }

        [Category("Custom")]
        public Color Outer
        {
            get { return colorOuter; }
            set { colorOuter = value; Redraw(); }
        }

        [Category("Custom")]
        public Color Inner
        {
            get { return colorInner; }
            set { colorInner = value; Redraw(); }
        }

        private void Redraw()
        {
            if (Parent != null)
                Parent.Refresh();
        }

        #region ILoadingComponent Members

        public override void Tick()
        {
            rotateRibbon1 += stepRibbon1;
            if (rotateRibbon1 == 360)
            {
                rotateRibbon1 = 0;
            }
            rotateRibbon2 += stepRibbon2;
            if (rotateRibbon2 == 360)
            {
                rotateRibbon2 = 0;
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
                Brush brOuter = new SolidBrush(Color.FromArgb(128, colorOuter));
                Brush brInner = new SolidBrush(Color.FromArgb(128, colorInner));

                gr.FillRectangle(brBack, Parent.ClientRectangle);

                gr.TranslateTransform(w, h);

                float min2 = Math.Min(w, h);
                float min = min2 * 2;
                float min4 = min2 / 2;
                float min8 = min4 / 2;
                float min16 = min8 / 2;

                gr.FillPie(brOuter, -min2, -min2, min, min, rotateRibbon1, 180);
                gr.FillPie(brBack, -min4 - min8, -min4 - min8, min2 + 2 * min8, min2 + 2 * min8, rotateRibbon1 - 5, 190);
                gr.FillPie(brOuter, -min2, -min2, min, min, -rotateRibbon1, 180);
                gr.FillPie(brBack, -min4 - min8, -min4 - min8, min2 + 2 * min8, min2 + 2 * min8, -rotateRibbon1 - 5, 190);

                gr.FillPie(brInner, -min4, -min4, min2, min2, rotateRibbon2, 180);
                gr.FillPie(brBack, -min8 - min16, -min8 - min16, min4 + 2 * min16, min4 + 2 * min16, rotateRibbon2, 180);
                gr.FillPie(brInner, -min4, -min4, min2, min2, -rotateRibbon2, 180);
                gr.FillPie(brBack, -min8 - min16, -min8 - min16, min4 + 2 * min16, min4 + 2 * min16, -rotateRibbon2, 180);

                gr.TranslateTransform(-w, -h);

                brOuter.Dispose();
                brInner.Dispose();
                brBack.Dispose();
            }
        }
        #endregion
    }
}
