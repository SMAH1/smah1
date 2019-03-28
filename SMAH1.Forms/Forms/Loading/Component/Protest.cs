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
    public class LProtest : LBaseCircular
    {
        protected Color colorDefault = SystemColors.GradientActiveCaption;
        protected Color colorProgress = SystemColors.GradientInactiveCaption;
        protected int angleField = 15;
        protected int shapeAngle = 20;

        public LProtest() : this(false) { }

        public LProtest(bool bNotStartFromZeroAngle)
        {
            shapeAngle = 20;
            rotateAngle = 20;

            if (bNotStartFromZeroAngle)
                NotStartFromZeroAngle();
        }

        [Category("Custom")]
        public Color Default
        {
            get { return colorDefault; }
            set { colorDefault = value; Redraw(); }
        }

        [Category("Custom")]
        public Color Progress
        {
            get { return colorProgress; }
            set { colorProgress = value; Redraw(); }
        }

        [Category("Custom")]
        public int Angle
        {
            get { return angleField; }
            set
            {
                if (value > 0 && value < shapeAngle)
                {
                    angleField = value;
                    Redraw();
                }
            }
        }

        protected void Redraw()
        {
            FreeBitmap();
            if (Parent != null)
                Parent.Refresh();
        }

        protected override void InternalTick() { }

        public override void Initialize()
        {
            CreateBitmap();
        }

        public override void StateChange(LoadingStateChange state)
        {
            CreateBitmap();
        }

        protected override void CreateBitmap()
        {
            if (Parent == null)
            {
                FreeBitmap();
                return;
            }

            LoadingCtrl ctrl = Parent;
            float min = Math.Min(
                ctrl.ClientRectangle.Width,
                ctrl.ClientRectangle.Height);
            float min2 = min / 2;
            float min4 = min2 / 2;
            float min8 = min4 / 2;
            float min_tra = min / 3;
            float min_tra2 = min_tra / 2;
            float min_tra4 = min_tra2 / 2;
            float min_tra8 = min_tra4 / 2;

            FreeBitmap();
            if (min < 1)
                return;

            bmpBack = new Bitmap((int)min, (int)min);

            using (Graphics grBack = Graphics.FromImage(bmpBack))
            {
                Brush brDefault = new SolidBrush(colorDefault);
                Brush brProgress = new SolidBrush(colorProgress);

                grBack.TranslateTransform(min2, min2);

                float q = min_tra2;
                float tra48 = min_tra4 + min_tra8;
                PointF[] points = new PointF[] {
                        new PointF(0+q,0+q),
                        RotatePoint(min_tra2,tra48+q,tra48+q,-angleField),
                        RotatePoint(min_tra2,tra48+q,tra48+q,angleField)
                    };

                Bitmap bmpDefault = new Bitmap((int)min_tra, (int)min_tra);
                using (Graphics grBmp = Graphics.FromImage(bmpDefault))
                {
                    grBmp.FillPolygon(brDefault, points);
                }

                Bitmap bmpProgress = new Bitmap((int)min_tra, (int)min_tra);
                using (Graphics grBmp = Graphics.FromImage(bmpProgress))
                {
                    grBmp.FillPolygon(brProgress, points);
                }

                int j = 0;
                int k = 0;
                for (int i = 0; i < 360; i += rotateAngle, j++)
                {
                    if (j < 5)
                    {
                        float f = (2 - Math.Abs(2 - j)) * min_tra8;
                        grBack.TranslateTransform(-f, -f);
                        grBack.DrawImage(bmpProgress, 0, 0);
                        grBack.TranslateTransform(f, f);
                    }
                    else
                        grBack.DrawImage(bmpDefault, 0, 0);
                    grBack.RotateTransform(rotateAngle);
                    k += rotateAngle;
                }

                grBack.RotateTransform(-k);
                grBack.TranslateTransform(-min2, -min2);

                bmpDefault.Dispose();
                bmpProgress.Dispose();
                brProgress.Dispose();
                brDefault.Dispose();
            }
        }

        private PointF RotatePoint(float xyBase, float x, float y, float angle)
        {
            double teta = (Math.PI * angle / 180F);
            x -= xyBase;
            y -= xyBase;
            float xp = (float)((x * Math.Cos(teta)) - (y * Math.Sin(teta)));
            float yp = (float)((x * Math.Sin(teta)) + (y * Math.Cos(teta)));
            xp += xyBase;
            yp += xyBase;
            return new PointF(xp, yp);
        }
    }
}
