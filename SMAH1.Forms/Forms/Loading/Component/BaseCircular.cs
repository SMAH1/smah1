using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SMAH1.Forms.Loading.Component
{
    public abstract class LBaseCircular : BaseLoadingComponent
    {
        protected int curRotate = 0;
        protected int rotateAngle = 30;

        protected Bitmap bmpBack = null;

        public LBaseCircular()
        {
            curRotate = 0;
        }

        protected void FreeBitmap()
        {
            if (bmpBack != null)
                bmpBack.Dispose();
            bmpBack = null;
        }

        protected void NotStartFromZeroAngle()
        {
            if (rotateAngle != 0)
            {
                int i = 360 / rotateAngle;
                Random r = new Random();
                curRotate = (r.Next(i) * rotateAngle) % 360;
            }
        }

        protected abstract void InternalTick();
        protected abstract void CreateBitmap();

        protected virtual void BeforPaint(Graphics gr, PointF center)
        { }
        protected virtual void AfterPaint(Graphics gr, PointF center)
        { }

        public override void Tick()
        {
            curRotate += rotateAngle;
            if (curRotate >= 360)
                curRotate = 0;
            InternalTick();
            if (Parent != null)
                Parent.Refresh();
        }

        public override void Paint(Graphics gr)
        {
            if (Parent == null)
                return;

            if (bmpBack == null)
                CreateBitmap();

            Brush brBack = new SolidBrush(Parent.BackColor);
            gr.FillRectangle(brBack, Parent.ClientRectangle);
            brBack.Dispose();

            if (bmpBack != null)
            {
                float minW2 = bmpBack.Size.Width / 2F;
                float minH2 = bmpBack.Size.Height / 2F;

                float cx = Parent.ClientRectangle.Width / 2F;
                float cy = Parent.ClientRectangle.Height / 2F;

                PointF center = new PointF(cx, cy);
                BeforPaint(gr, center);
                gr.TranslateTransform(cx, cy);

                gr.RotateTransform(curRotate);
                gr.DrawImage(bmpBack, -minW2, -minH2);
                gr.RotateTransform(-curRotate);

                gr.TranslateTransform(-cx, -cy);
                AfterPaint(gr, center);
            }
        }
    }
}
