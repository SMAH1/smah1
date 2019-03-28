using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;

namespace SMAH1.Forms.Loading
{
    [DesignerCategory("SMAH1")]
    public class LoadingCtrl : Control
    {
        private Timer timer;
        private ContentAlignment textAlign;
        private ILoadingComponent component = null;

        public LoadingCtrl()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);

            timer = new Timer
            {
                Enabled = false,
                Interval = 100
            };
            timer.Tick += new EventHandler(TimerTick);
            base.TabStop = false;
            textAlign = ContentAlignment.MiddleCenter;
            component = null;
        }

        void TimerTick(object sender, EventArgs e)
        {
            if (component != null)
                component.Tick();
        }

        #region override
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            StateChange(LoadingStateChange.Size);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (!DesignMode)
            {
                timer.Enabled = this.Enabled;
                if (component != null)
                {
                    if (this.Enabled)
                        component.Start();
                    else
                        component.Stop();
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; StateChange(LoadingStateChange.ForeColor); }
        }

        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; StateChange(LoadingStateChange.BackColor); }
        }

        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; StateChange(LoadingStateChange.Font); }
        }

        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; StateChange(LoadingStateChange.Text); }
        }

        public override Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set { base.BackgroundImage = value; StateChange(LoadingStateChange.BackgroundImage); }
        }

        public override ImageLayout BackgroundImageLayout
        {
            get { return base.BackgroundImageLayout; }
            set { base.BackgroundImageLayout = value; StateChange(LoadingStateChange.BackgroundImageLayout); }
        }

        public override RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set { base.RightToLeft = value; StateChange(LoadingStateChange.RightToLeft); }
        }

        [Category("Animation")]
        [DefaultValue(true)]
        public new bool Enabled
        {
            get { return base.Enabled; }
            set { base.Enabled = value; }
        }

        [DefaultValue(false)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool TabStop
        {
            get { return false; }
            set { base.TabStop = false; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Point AutoScrollOffset { get; set; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AutoSize { get; set; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AllowDrop { get; set; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override BindingContext BindingContext { get; set; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool CausesValidation { get; set; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ImeMode ImeMode { get; set; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Margin { get; set; }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding { get; set; }

        #endregion

        #region Add properties
        [Category("Animation")]
        [DefaultValue(100)]
        public int Interval
        {
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }

        [Category("Animation")]
        [DefaultValue(null)]
        public ILoadingComponent Component
        {
            get { return component; }
            set
            {
                if (component != value)
                {
                    if (component != null)
                    {
                        ILoadingComponent old = component;

                        //Sequence of two commands below is important
                        component = null;
                        old.Parent = null;
                    }
                    component = value;
                    if (component != null)
                    {
                        component.Parent = this;
                        if (!DesignMode)
                        {
                            timer.Enabled = this.Enabled;
                            if (this.Enabled)
                                component.Start();
                        }
                    }
                    Refresh();
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(ContentAlignment.MiddleCenter)]
        public ContentAlignment TextAlign
        {
            get { return textAlign; }
            set { textAlign = value; StateChange(LoadingStateChange.TextAlign); }
        }
        #endregion

        public void StateChange(LoadingStateChange state)
        {
            if (component != null)
                component.StateChange(state);
            else
                Refresh();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Bitmap bmp = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            using (Graphics grBmp = Graphics.FromImage(bmp))
            {
                if (component != null)
                    component.Paint(grBmp);
                else
                {
                    Brush brBack = new SolidBrush(BackColor);
                    grBmp.FillRectangle(brBack, ClientRectangle);
                    brBack.Dispose();

                    DrawBackgroundImage(grBmp);
                    DrawText(grBmp);
                }
            }
            pevent.Graphics.DrawImage(bmp, 0, 0);
        }

        #region Helper Draw
        public void DrawBackgroundImage(Graphics g)
        {
            DrawBackgroundImage(g, ClientRectangle, BackgroundImageLayout);
        }

        public void DrawBackgroundImage(Graphics g, Rectangle rcDraw, ImageLayout layout)
        {
            if (BackgroundImage == null)
                return;

            Image img = BackgroundImage;

            switch (layout)
            {
                case ImageLayout.None:
                    //g.DrawImage(img,0,0) Not work correctly for sum image
                    if (RightToLeft == RightToLeft.Yes)
                        g.DrawImage(img,
                            new Rectangle(rcDraw.Width - img.Width, rcDraw.Y, img.Width, img.Height),
                            0, 0, img.Width, img.Height,
                            GraphicsUnit.Pixel);
                    else
                        g.DrawImage(img,
                            new Rectangle(rcDraw.X, rcDraw.Y, img.Width, img.Height),
                            0, 0, img.Width, img.Height,
                            GraphicsUnit.Pixel);
                    break;
                case ImageLayout.Center:
                    float x = rcDraw.Width - img.Width;
                    float y = rcDraw.Height - img.Height;
                    x /= 2;
                    y /= 2;
                    //g.DrawImage(img,0,0) Not work correctly for sum image
                    g.DrawImage(img,
                        new Rectangle((int)x + rcDraw.X, (int)y + rcDraw.Y, img.Width, img.Height),
                        0, 0, img.Width, img.Height,
                        GraphicsUnit.Pixel);
                    break;
                case ImageLayout.Stretch:
                    g.DrawImage(img, rcDraw,
                        0, 0, img.Width, img.Height,
                        GraphicsUnit.Pixel);
                    break;
                case ImageLayout.Tile:
                    TextureBrush brTexture = new TextureBrush(img);
                    g.FillRectangle(brTexture, rcDraw);
                    brTexture.Dispose();
                    break;
                case ImageLayout.Zoom:
                    Size size = img.Size;
                    Rectangle rc = rcDraw;
                    float f = Math.Min((float)rcDraw.Width / (float)size.Width,
                        (float)rcDraw.Height / (float)size.Height);
                    rc.Width = (int)((float)size.Width * f);
                    rc.Height = (int)((float)size.Height * f);
                    rc.X = rcDraw.X + (rcDraw.Width - rc.Width) / 2;
                    rc.Y = rcDraw.Y + (rcDraw.Height - rc.Height) / 2;
                    g.DrawImage(img, rc,
                        0, 0, img.Width, img.Height,
                        GraphicsUnit.Pixel);
                    break;
            }
        }

        public void DrawText(Graphics g)
        {
            DrawText(g, Text, Font, ForeColor, TextAlign, ClientRectangle);
        }

        public void DrawText(Graphics g, string message)
        {
            DrawText(g, message, Font, ForeColor, TextAlign, ClientRectangle);
        }

        public void DrawText(Graphics g, RectangleF rect)
        {
            DrawText(g, Text, Font, ForeColor, TextAlign, rect);
        }

        public void DrawText(Graphics g, string message, Font font, Color color, ContentAlignment align, RectangleF rect)
        {
            StringFormat sf = new StringFormat();

            if ((align & (ContentAlignment.TopRight | ContentAlignment.MiddleRight | ContentAlignment.BottomRight)) != 0)
                sf.Alignment = StringAlignment.Far;
            else if ((align & (ContentAlignment.TopCenter | ContentAlignment.MiddleCenter | ContentAlignment.BottomCenter)) != 0)
                sf.Alignment = StringAlignment.Center;
            else
                sf.Alignment = StringAlignment.Near;

            if ((align & (ContentAlignment.BottomLeft | ContentAlignment.BottomCenter | ContentAlignment.BottomRight)) != 0)
                sf.LineAlignment = StringAlignment.Far;
            else if ((align & (ContentAlignment.MiddleLeft | ContentAlignment.MiddleCenter | ContentAlignment.MiddleRight)) != 0)
                sf.LineAlignment = StringAlignment.Center;
            else
                sf.LineAlignment = StringAlignment.Near;

            if (RightToLeft == RightToLeft.Yes)
                sf.FormatFlags |= StringFormatFlags.DirectionRightToLeft;

            Brush br = new SolidBrush(color);
            g.DrawString(message, font, br, rect, sf);
            br.Dispose();
        }
        #endregion
    }
}
