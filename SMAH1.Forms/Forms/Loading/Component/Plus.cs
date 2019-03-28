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
    public class LPlus : LBaseCircular
    {
        protected Color colorContent = SystemColors.ControlLight;
        protected Color colorEdge = SystemColors.ControlDark;
        protected float widthEdge = 2;
        protected bool showPinField = true;

        public LPlus() : this(false) { }

        public LPlus(bool bNotStartFromZeroAngle)
        {
            if (bNotStartFromZeroAngle)
                NotStartFromZeroAngle();
        }

        [Category("Custom")]
        public Color Content
        {
            get { return colorContent; }
            set { colorContent = value; Redraw(); }
        }

        [Category("Custom")]
        public Color Edge
        {
            get { return colorEdge; }
            set { colorEdge = value; Redraw(); }
        }

        [Category("Custom")]
        [DefaultValue(true)]
        public bool ShowPin
        {
            get { return showPinField; }
            set { showPinField = value; Redraw(); }
        }

        [Category("Custom")]
        [DefaultValue(2)]
        public float EdgeWidth
        {
            get { return widthEdge; }
            set
            {
                if (value > 0.5)
                {
                    widthEdge = value;
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

        protected override void AfterPaint(Graphics gr, PointF center)
        {
            if (Parent == null)
                return;

            if (showPinField)
            {
                float min = bmpBack.Size.Height;
                float min8 = min / 8;

                gr.TranslateTransform(center.X, center.Y);

                LinearGradientBrush lgb = new LinearGradientBrush(new RectangleF(-min8 / 2, -min8 / 2, min8, min8), colorEdge, colorContent, LinearGradientMode.Vertical);
                gr.FillEllipse(lgb, new RectangleF(-min8 / 2, -min8 / 2, min8, min8));
                lgb.Dispose();

                gr.TranslateTransform(-center.X, -center.Y);
            }
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

            FreeBitmap();
            if (min < 1)
                return;

            bmpBack = new Bitmap((int)min, (int)min);

            using (Graphics grBack = Graphics.FromImage(bmpBack))
            {
                Brush brContent = new SolidBrush(colorContent);
                Pen penEdge = new Pen(colorEdge, widthEdge);

                grBack.FillRectangle(Brushes.Transparent, 0, 0, min, min);

                grBack.TranslateTransform(min2, min2);

                float v1 = min2 - min8;
                float v2 = min8;
                PointF[] pf = {
                        new PointF(-v2,-v1),
                        new PointF(v2,-v1),
                        new PointF(v2,-v2),
                        new PointF(v1,-v2),
                        new PointF(v1,v2),
                        new PointF(v2,v2),
                        new PointF(v2,v1),
                        new PointF(-v2,v1),
                        new PointF(-v2,v2),
                        new PointF(-v1,v2),
                        new PointF(-v1,-v2),
                        new PointF(-v2,-v2)
                    };

                GraphicsPath gp = new GraphicsPath();
                gp.AddLines(pf);
                gp.CloseFigure();

                grBack.FillPath(brContent, gp);
                grBack.DrawPath(penEdge, gp);

                grBack.TranslateTransform(-min2, -min2);

                penEdge.Dispose();
                brContent.Dispose();
            }
        }
    }
}
