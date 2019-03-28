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
    public class LFan : LBaseCircular
    {
        protected Color colorDefault = SystemColors.WindowText;
        protected Color colorProgress = SystemColors.Info;
        protected int shapeAngle = 20;

        public LFan() : this(false) { }

        public LFan(bool bNotStartFromZeroAngle)
        {
            shapeAngle = 20;
            rotateAngle = 30;

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
            float minX3 = min * 3;
            float minX3_2 = minX3 / 2;

            FreeBitmap();
            if (min < 1)
                return;

            bmpBack = new Bitmap((int)minX3, (int)minX3);

            using (Graphics grBack = Graphics.FromImage(bmpBack))
            {
                Brush brDefault = new SolidBrush(colorDefault);
                Brush brProgress = new SolidBrush(colorProgress);

                grBack.FillRectangle(Brushes.Transparent, 0, 0, (int)minX3, (int)minX3);

                grBack.TranslateTransform(minX3_2, minX3_2);

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
                    grBmp.FillPath(brDefault, gp1);
                }
                int j = 0;
                for (int i = 0; i < 360; i += rotateAngle)
                {
                    j += rotateAngle;
                    grBack.DrawImage(bmp2, 0, 0);
                    grBack.RotateTransform(rotateAngle);
                }

                using (Graphics grBmp = Graphics.FromImage(bmp2))
                {
                    grBmp.SetClip(rgn, CombineMode.Replace);
                    grBmp.FillPath(brProgress, gp1);
                }
                grBack.DrawImage(bmp2, 0, 0);
                grBack.RotateTransform(180);
                grBack.DrawImage(bmp2, 0, 0);
                grBack.RotateTransform(-180);

                grBack.RotateTransform(-j);

                grBack.TranslateTransform(-minX3_2, -minX3_2);

                bmp2.Dispose();
                brDefault.Dispose();
                brProgress.Dispose();
            }
        }
    }
}
