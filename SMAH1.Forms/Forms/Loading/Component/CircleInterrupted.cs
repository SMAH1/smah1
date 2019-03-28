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
    public class LCircleInterrupted : BaseLoadingComponent
    {
        protected int rotate = 0;
        protected int shapeRotateField = 20;
        protected int spaceRotateField = 10;

        protected Color colorLight = Color.Green;
        protected Color colorBetween = Color.GreenYellow;
        protected Color colorDark = Color.LimeGreen;

        protected Brush brLightBase;
        protected Brush brBetweenBase;
        protected Brush brDarkBase;

        protected Brush br1;
        protected Brush br3;

        public LCircleInterrupted() : this(false)
        {
        }

        public LCircleInterrupted(bool bNotStartFromZeroAngle)
        {
            brLightBase = new SolidBrush(colorLight);
            brBetweenBase = new SolidBrush(colorBetween);
            brDarkBase = new SolidBrush(colorDark);

            br1 = brLightBase;
            br3 = brDarkBase;

            rotate = 0;

            if (bNotStartFromZeroAngle)
                NotStartFromZeroAngle();
        }

        protected void NotStartFromZeroAngle()
        {
            int j = shapeRotateField + spaceRotateField;
            int i = 360 / j;
            Random r = new Random();
            rotate = (r.Next(i) * j) % 360;
        }

        [Category("Custom")]
        public Color Light
        {
            get { return colorLight; }
            set
            {
                colorLight = value;
                Brush br = brLightBase;
                brLightBase = new SolidBrush(colorLight);
                if (br == br1)
                    br1 = brLightBase;
                else
                    br3 = brLightBase;
                br.Dispose();
                Redraw();
            }
        }

        [Category("Custom")]
        public Color Between
        {
            get { return colorBetween; }
            set
            {
                colorBetween = value;
                brBetweenBase.Dispose();
                brBetweenBase = new SolidBrush(colorBetween);
                Redraw();
            }
        }

        [Category("Custom")]
        public Color Dark
        {
            get { return colorDark; }
            set
            {
                colorDark = value;
                Brush br = brDarkBase;
                brDarkBase = new SolidBrush(colorDark);
                if (br == br1)
                    br1 = brDarkBase;
                else
                    br3 = brDarkBase;
                br.Dispose();
                Redraw();
            }
        }

        [Category("Custom")]
        [DefaultValue(20)]
        public int ShapeRotate
        {
            get { return shapeRotateField; }
            set
            {
                if (shapeRotateField > 0 && shapeRotateField < 60)
                    shapeRotateField = value;
                Redraw();
            }
        }

        [Category("Custom")]
        [DefaultValue(10)]
        public int SpaceRotate
        {
            get { return spaceRotateField; }
            set
            {
                if (spaceRotateField > 0 && spaceRotateField < 60)
                    spaceRotateField = value;
                Redraw();
            }
        }

        private void Redraw()
        {
            if (Parent != null)
                Parent.Refresh();
        }

        #region ILoadingComponent Members
        public override void Tick()
        {
            rotate += shapeRotateField;
            rotate += spaceRotateField;
            if (rotate >= 360)
            {
                Brush br = br1;
                br1 = br3;
                br3 = br;
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
                gr.FillRectangle(brBack, Parent.ClientRectangle);

                var smoothingMode = gr.SmoothingMode;
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                gr.TranslateTransform(w, h);

                float min2 = Math.Min(w, h);
                float min = min2 * 2;
                float min4 = min2 / 2;
                float min8 = min4 / 2;
                float min16 = min8 / 2;

                float f1 = min - min4;
                float f2 = f1 / 2;

                for (int i = 0; i < 360; i += shapeRotateField + spaceRotateField)
                {
                    Brush br = null;
                    if (i < rotate)
                        br = br1;
                    else if (i == rotate)
                        br = brBetweenBase;
                    else
                        br = br3;
                    gr.FillPie(br, -min2, -min2, min, min, i - 1, shapeRotateField + 1);
                }
                gr.FillEllipse(brBack, -f2, -f2, f1, f1);

                gr.TranslateTransform(-w, -h);
                brBack.Dispose();

                gr.SmoothingMode = smoothingMode;
            }
        }
        #endregion
    }
}
