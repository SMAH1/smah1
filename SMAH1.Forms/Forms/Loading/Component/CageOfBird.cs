using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;

namespace SMAH1.Forms.Loading.Component
{
    [DesignerCategory("SMAH1")]
    [ToolboxItem(true)]
    [DesignTimeVisible(true)]
    public class LCageOfBird : LBaseCircular
    {
        protected Color colorCage = SystemColors.GradientInactiveCaption;
        protected Color colorBird = SystemColors.WindowText;
        protected int shapeAngle = 20;

        public LCageOfBird() : this(false)
        {
        }

        public LCageOfBird(bool bNotStartFromZeroAngle)
        {
            shapeAngle = 20;
            rotateAngle = 30;

            if (bNotStartFromZeroAngle)
                NotStartFromZeroAngle();
        }

        [Category("Custom")]
        public Color Cage
        {
            get { return colorCage; }
            set { colorCage = value; Redraw(); }
        }

        [Category("Custom")]
        public Color Bird
        {
            get { return colorBird; }
            set { colorBird = value; Redraw(); }
        }

        protected void Redraw()
        {
            FreeBitmap();
            if (Parent != null)
                Parent.Refresh();
        }

        protected override void InternalTick()
        { }

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
                ctrl.ClientRectangle.Width / 3F,
                ctrl.ClientRectangle.Height / 3F);
            float min2 = min / 2;
            float min4 = min2 / 2;
            float min8 = min4 / 2;
            float minX3 = min * 3;
            float minX3_2 = minX3 / 2;

            FreeBitmap();
            if (min < 1)
                return;

            bmpBack = new Bitmap((int)minX3, (int)minX3);

            using (Graphics grBack = Graphics.FromImage(bmpBack))
            {
                Brush brCage = new SolidBrush(colorCage);
                Brush brBird = new SolidBrush(colorBird);
                Pen penCage = new Pen(colorCage, 2);

                grBack.FillRectangle(Brushes.Transparent, 0, 0, (int)minX3, (int)minX3);

                grBack.TranslateTransform(minX3_2, minX3_2);

                //Draw Bird
                LinearGradientBrush gradBrush = new LinearGradientBrush(
                    new RectangleF(0, 0, min2 + min4, min2 + min4),
                    colorBird, ctrl.BackColor,
                    LinearGradientMode.Horizontal);
                grBack.TranslateTransform(min2, min2);
                grBack.RotateTransform(320);
                grBack.TranslateTransform(-min4, 0);
                grBack.FillPolygon(brBird, new PointF[] {
                        new PointF(-min4,0),
                        new PointF(min4,-min4),
                        new PointF(0,0),
                        new PointF(min4,min4)
                    });
                grBack.FillPolygon(gradBrush, new PointF[] {
                        new PointF(min4,-min8),
                        new PointF(min4,min8),
                        new PointF(min2+min4,0)
                    });
                gradBrush.Dispose();
                grBack.TranslateTransform(min4, 0);
                grBack.RotateTransform(-320);
                grBack.TranslateTransform(-min2, -min2);

                //Draw Cage
                RectangleF rcf = new RectangleF(0, 0, min, min);
                GraphicsPath gp1 = new GraphicsPath();
                gp1.AddEllipse(rcf);

                double teta = (Math.PI * shapeAngle / 180F);
                double x = min2;
                double y = min2;
                float xp = (float)((x * Math.Cos(teta)) - (y * Math.Sin(teta)));
                float yp = (float)((x * Math.Sin(teta)) + (y * Math.Cos(teta)));
                xp -= min2;
                yp -= min2;

                float diagonal = Math.Abs(xp);

                rcf = new RectangleF(xp, yp, min, min);
                GraphicsPath gp2 = new GraphicsPath();
                gp2.AddEllipse(rcf);

                Region rgn = new Region(gp1);
                rgn.Union(gp2);
                rgn.Xor(gp2);

                Bitmap bmp2 = new Bitmap((int)min, (int)min);
                using (Graphics grBmp = Graphics.FromImage(bmp2))
                {
                    grBmp.SetClip(rgn, CombineMode.Replace);
                    grBmp.FillPath(brCage, gp1);
                }
                int j = 0;
                for (int i = 0; i < 360; i += rotateAngle)
                {
                    j += rotateAngle;
                    grBack.DrawImage(bmp2, 0, 0);
                    grBack.RotateTransform(rotateAngle);
                }
                grBack.RotateTransform(-j);

                float f = diagonal * 2;
                grBack.DrawEllipse(penCage, -diagonal, -diagonal, f, f);
                f = min + diagonal;
                grBack.DrawEllipse(penCage, -f, -f, f * 2, f * 2);

                grBack.TranslateTransform(-minX3_2, -minX3_2);

                bmp2.Dispose();
                brCage.Dispose();
                brBird.Dispose();
                penCage.Dispose();
            }
        }
    }
}
