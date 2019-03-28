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
    public class LFillPoint : LBaseCircular
    {
        protected bool showTextField = true;
        protected Random rnd;
        protected int couter;

        public LFillPoint()
        {
            rnd = new Random();
            rotateAngle = 1;
            couter = 0;
        }

        [Category("Custom")]
        [DefaultValue(true)]
        public bool ShowText
        {
            get { return showTextField; }
            set { showTextField = value; Redraw(); }
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

        public override void Start()
        {
            CreateBitmap();
        }

        protected override void BeforPaint(Graphics gr, PointF center)
        {
            if (Parent == null)
                return;

            if (couter == 0)
            {
                int min = bmpBack.Size.Width;
                int min2 = min / 2;
                int n = min2 - 12;

                if (n > 1)
                {
                    int r = rnd.Next(0, n);
                    int teta = rnd.Next(0, 360);

                    int cx = (int)(r * (float)Math.Cos(teta));
                    int cy = (int)(r * (float)Math.Sin(teta));

                    n = rnd.Next(5, min2 - r);

                    cx += min2;
                    cy += min2;

                    cx -= n;
                    cy -= n;

                    Byte[] b = new Byte[4];
                    rnd.NextBytes(b);
                    for (int i = 0; i < b.Length; i++)
                    {
                        if (b[i] < 32)
                            b[i] = 32;
                        if (b[i] > 223)
                            b[i] = 223;
                    }
                    Color c = Color.FromArgb(b[0], b[1], b[2], b[3]);

                    using (Graphics grBack = Graphics.FromImage(bmpBack))
                    {
                        Brush br = new SolidBrush(c);
                        grBack.FillEllipse(br, cx, cy, n * 2, n * 2);
                        br.Dispose();
                    }
                }
            }
            couter++;
            couter %= 5;
        }

        protected override void AfterPaint(Graphics gr, PointF center)
        {
            if (Parent == null)
                return;

            if (showTextField)
                Parent.DrawText(gr);
            int min = bmpBack.Size.Width;
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

            FreeBitmap();
            if (min < 1)
                return;

            bmpBack = new Bitmap((int)min, (int)min);

            using (Graphics grBack = Graphics.FromImage(bmpBack))
            {
                var smoothingMode = grBack.SmoothingMode;
                grBack.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                grBack.FillRectangle(Brushes.Transparent, 0, 0, min, min);
                grBack.SmoothingMode = smoothingMode;
            }
        }
    }
}
