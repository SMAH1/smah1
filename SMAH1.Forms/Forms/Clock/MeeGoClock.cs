using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SMAH1.Forms.Clock
{
    public partial class MeeGoClock : UserControl
    {
        #region Variable

        DateTime dt;
        bool ignoreRedraw;

        //Draw
        Point center;
        int radiusClock;
        int radiusCenter;
        int radiusMinuteCounter;
        int radiusHourCounter;
        int radiusSecondCounter;
        int widthHelper;
        int heightHelper;

        //Property

        Color startGradientClockCircleClr;
        Color endGradientClockCircleClr;
        Color clockCircleClr;

        Color startGradientCenterCircleClr;
        Color endGradientCenterCircleClr;
        Color centerCircleClr;

        Color startGradientHourCircleClr;
        Color endGradientHourCircleClr;
        Color hourCircleClr;
        Color hourNumberClr;

        Color startGradientMinuteCircleClr;
        Color endGradientMinuteCircleClr;
        Color minuteCircleClr;
        Color minuteNumberClr;

        Color startGradientSecondCircleClr;
        Color endGradientSecondCircleClr;
        Color secondCircleClr;

        float clockCircleTh;
        float centerCircleTh;
        float hourTh;
        float minuteTh;
        float secondTh;

        #endregion

        #region Properties

        [Category("Appearance")] public Color ClockCircleStartGradientColor { get { return startGradientClockCircleClr; } set { startGradientClockCircleClr = value; Redraw(); } }
        [Category("Appearance")] public Color ClockCircleEndGradientColor { get { return endGradientClockCircleClr; } set { endGradientClockCircleClr = value; Redraw(); } }
        [Category("Appearance")] public Color ClockCircleEdgeColor { get { return clockCircleClr; } set { clockCircleClr = value; Redraw(); } }

        [Category("Appearance")] public Color CenterCircleStartGradientColor { get { return startGradientCenterCircleClr; } set { startGradientCenterCircleClr = value; Redraw(); } }
        [Category("Appearance")] public Color CenterCircleEndGradientColor { get { return endGradientCenterCircleClr; } set { endGradientCenterCircleClr = value; Redraw(); } }
        [Category("Appearance")] public Color CenterCircleEdgeColor { get { return centerCircleClr; } set { centerCircleClr = value; Redraw(); } }

        [Category("Appearance")] public Color HourCircleStartGradientColor { get { return startGradientHourCircleClr; } set { startGradientHourCircleClr = value; Redraw(); } }
        [Category("Appearance")] public Color HourCircleEndGradientColor { get { return endGradientHourCircleClr; } set { endGradientHourCircleClr = value; Redraw(); } }
        [Category("Appearance")] public Color HourCircleEdgeColor { get { return hourCircleClr; } set { hourCircleClr = value; Redraw(); } }
        [Category("Appearance")] public Color HourForeColor { get { return hourNumberClr; } set { hourNumberClr = value; Redraw(); } }

        [Category("Appearance")] public Color MinuteCircleStartGradientColor { get { return startGradientMinuteCircleClr; } set { startGradientMinuteCircleClr = value; Redraw(); } }
        [Category("Appearance")] public Color MinuteCircleEndGradientColor { get { return endGradientMinuteCircleClr; } set { endGradientMinuteCircleClr = value; Redraw(); } }
        [Category("Appearance")] public Color MinuteCircleEdgeColor { get { return minuteCircleClr; } set { minuteCircleClr = value; Redraw(); } }
        [Category("Appearance")] public Color MinuteForeColor { get { return minuteNumberClr; } set { minuteNumberClr = value; Redraw(); } }

        [Category("Appearance")] public Color SecondCircleStartGradientColor { get { return startGradientSecondCircleClr; } set { startGradientSecondCircleClr = value; Redraw(); } }
        [Category("Appearance")] public Color SecondCircleEndGradientColor { get { return endGradientSecondCircleClr; } set { endGradientSecondCircleClr = value; Redraw(); } }
        [Category("Appearance")] public Color SecondCircleEdgeColor { get { return secondCircleClr; } set { secondCircleClr = value; Redraw(); } }

        [Category("Appearance")] public float ClockEdgeThickness { get { return clockCircleTh; } set { clockCircleTh = value; Redraw(); } }
        [Category("Appearance")] public float CenterEdgeThickness { get { return centerCircleTh; } set { centerCircleTh = value; Redraw(); } }
        [Category("Appearance")] public float HourEdgeThickness { get { return hourTh; } set { hourTh = value; Redraw(); } }
        [Category("Appearance")] public float MinuteEdgeThickness { get { return minuteTh; } set { minuteTh = value; Redraw(); } }
        [Category("Appearance")] public float SecondEdgeThickness { get { return secondTh; } set { secondTh = value; Redraw(); } }

        public override Font Font { get { return base.Font; } set { base.Font = value; Redraw(); } }

        #endregion

        #region Constructor

        public MeeGoClock()
        {
            InitializeComponent();

            ignoreRedraw = true;

            ClockCircleStartGradientColor = Color.FromArgb(255, 255, 255, 255);
            ClockCircleEndGradientColor = Color.FromArgb(255, 213, 213, 213);
            ClockCircleEdgeColor = Color.WhiteSmoke;
            CenterCircleStartGradientColor = Color.FromArgb(200, 213, 213, 213);
            CenterCircleEndGradientColor = Color.FromArgb(255, 0, 0, 0);
            CenterCircleEdgeColor = Color.Gray;
            HourCircleStartGradientColor = Color.FromArgb(255, 255, 255, 255);
            HourCircleEndGradientColor = Color.FromArgb(255, 213, 213, 213);
            HourCircleEdgeColor = Color.WhiteSmoke;
            HourForeColor = Color.Black;
            MinuteCircleStartGradientColor = Color.FromArgb(255, 56, 23, 8);
            MinuteCircleEndGradientColor = Color.FromArgb(255, 42, 23, 14);
            MinuteCircleEdgeColor = Color.FromArgb(255, 184, 127, 100);
            MinuteForeColor = Color.White;
            SecondCircleStartGradientColor = Color.Red;
            SecondCircleEndGradientColor = Color.Red;
            SecondCircleEdgeColor = Color.Red;

            ClockEdgeThickness = 1;
            CenterEdgeThickness = 2;
            HourEdgeThickness = 1;
            MinuteEdgeThickness = 1;
            SecondEdgeThickness = 1;

            ignoreRedraw = false;
            Redraw();

            this.DoubleBuffered = true;
        }

        #endregion

        #region Capture Event

        private void Timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void MeeGoClock_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                timer.Enabled = true;
        }

        #endregion

        #region Method

        private void Redraw()
        {
            if (!ignoreRedraw)
                Invalidate();
        }

        private void PrintClockCircle(Graphics gr)
        {
            LinearGradientBrush linGrBrush = new LinearGradientBrush(
               new Point(widthHelper, 0),
               new Point(widthHelper, this.Height),
               ClockCircleStartGradientColor,
               ClockCircleEndGradientColor);

            Pen pen = new Pen(linGrBrush);
            Rectangle rect = new Rectangle(center.X - radiusClock, center.Y - radiusClock, radiusClock * 2, radiusClock * 2);
            gr.FillEllipse(linGrBrush, rect);

            pen.Dispose();

            pen = new Pen(ClockCircleEdgeColor, ClockEdgeThickness);
            gr.DrawEllipse(pen, rect);

            linGrBrush.Dispose();
            pen.Dispose();
        }

        private void PrintCenterCircle(Graphics gr)
        {
            Brush br = new LinearGradientBrush(
               new Point(widthHelper, 0),
               new Point(widthHelper, this.Height),
               CenterCircleStartGradientColor,
               CenterCircleEndGradientColor);

            Pen pen = new Pen(br);
            Rectangle rect = new Rectangle(center.X - radiusCenter, center.Y - radiusCenter, radiusCenter * 2, radiusCenter * 2);
            gr.FillEllipse(br, rect);

            pen.Dispose();

            pen = new Pen(CenterCircleEdgeColor, CenterEdgeThickness);
            rect = new Rectangle((center.X - radiusCenter) + 1, (center.Y - radiusCenter) + 1, (radiusCenter * 2) - 2, (radiusCenter * 2) - 2);
            gr.DrawEllipse(pen, rect);

            br.Dispose();
            pen.Dispose();
        }

        private void PrintHourCircle(Graphics gr, int hour)
        {
            Point hourCenter = CenterOfHourCounter(hour);
            Brush br = new LinearGradientBrush(
               new Point(hourCenter.X, hourCenter.Y - radiusHourCounter),
               new Point(hourCenter.X, hourCenter.Y + radiusHourCounter),
               HourCircleStartGradientColor,
               HourCircleEndGradientColor);

            Pen pen = new Pen(br);
            Rectangle rect = new Rectangle(hourCenter.X - radiusHourCounter, hourCenter.Y - radiusHourCounter, radiusHourCounter * 2, radiusHourCounter * 2);
            gr.FillEllipse(br, rect);

            pen.Dispose();

            pen = new Pen(HourCircleEdgeColor, HourEdgeThickness);
            gr.DrawEllipse(pen, rect);

            br.Dispose();
            pen.Dispose();

            br = new SolidBrush(HourForeColor);

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            gr.DrawString(hour.ToString(), this.Font, br, rect, sf);

            br.Dispose();
        }

        private void PrintMinuteCircle(Graphics gr, int minute)
        {
            Point minuteCenter = CenterOfMinuteCounter(minute);
            Brush br = new LinearGradientBrush(
               new Point(minuteCenter.X, minuteCenter.Y - radiusHourCounter),
               new Point(minuteCenter.X, minuteCenter.Y + radiusHourCounter),
               MinuteCircleStartGradientColor,
               MinuteCircleEndGradientColor);

            Pen pen = new Pen(br);
            Rectangle rect = new Rectangle(minuteCenter.X - radiusMinuteCounter, minuteCenter.Y - radiusMinuteCounter, radiusMinuteCounter * 2, radiusMinuteCounter * 2);
            gr.FillEllipse(br, rect);

            pen.Dispose();

            pen = new Pen(MinuteCircleEdgeColor, MinuteEdgeThickness);
            gr.DrawEllipse(pen, rect);

            br.Dispose();
            pen.Dispose();

            br = new SolidBrush(MinuteForeColor);

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            gr.DrawString(minute.ToString(), this.Font, br, rect, sf);

            br.Dispose();
        }

        private void PrintSecondCircle(Graphics gr, int second)
        {
            Point secondCenter = CenterOfSecondCounter(second);
            Brush br = new LinearGradientBrush(
               new Point(secondCenter.X, secondCenter.Y - radiusHourCounter),
               new Point(secondCenter.X, secondCenter.Y + radiusHourCounter),
               SecondCircleStartGradientColor,
               SecondCircleEndGradientColor);

            Pen pen = new Pen(br);
            Rectangle rect = new Rectangle(secondCenter.X - radiusSecondCounter, secondCenter.Y - radiusSecondCounter, radiusSecondCounter * 2, radiusSecondCounter * 2);
            gr.FillEllipse(br, rect);

            pen.Dispose();

            pen = new Pen(SecondCircleEdgeColor, SecondEdgeThickness);
            gr.DrawEllipse(pen, rect);

            br.Dispose();
            pen.Dispose();
        }

        private Point CenterOfHourCounter(int hour)
        {
            Point ret = new Point();
            double t = (Math.PI * (90 - (30 * hour))) / 180;

            ret.X = Convert.ToInt32((radiusCenter - radiusHourCounter - 2) * (Math.Cos(t)));
            ret.Y = Convert.ToInt32((radiusCenter - radiusHourCounter - 2) * (Math.Sin(t)));

            if (hour >= 12)
                hour -= 12;

            if (hour > 0 && hour <= 3)
            {
                ret.X = center.X + ret.X;
                ret.Y = center.Y - ret.Y;
            }
            else if (hour > 3 && hour <= 6)
            {
                ret.X = center.X + ret.X;
                ret.Y = center.Y + (ret.Y * (-1));
            }
            else if (hour > 6 && hour <= 9)
            {
                ret.X = center.X - (ret.X * (-1));
                ret.Y = center.Y + (ret.Y * (-1));
            }
            else if ((hour > 9 && hour <= 11) || hour == 0)
            {
                ret.X = center.X + ret.X;
                ret.Y = center.Y - ret.Y;
            }

            return ret;
        }

        private Point CenterOfMinuteCounter(int minute)
        {
            Point ret = new Point();
            double t = (Math.PI * (90 - (6 * minute))) / 180;

            ret.X = Convert.ToInt32((radiusClock - radiusMinuteCounter - 1) * (Math.Cos(t)));
            ret.Y = Convert.ToInt32((radiusClock - radiusMinuteCounter - 1) * (Math.Sin(t)));

            if (minute > 0 && minute <= 15)
            {
                ret.X = center.X + ret.X;
                ret.Y = center.Y - ret.Y;
            }
            else if (minute > 15 && minute <= 30)
            {
                ret.X = center.X + ret.X;
                ret.Y = center.Y + (ret.Y * (-1));
            }
            else if (minute > 30 && minute <= 45)
            {
                ret.X = center.X - (ret.X * (-1));
                ret.Y = center.Y + (ret.Y * (-1));
            }
            else if ((minute > 45 && minute <= 59) || minute == 0)
            {
                ret.X = center.X + ret.X;
                ret.Y = center.Y - ret.Y;
            }

            return ret;
        }

        private Point CenterOfSecondCounter(int second)
        {
            Point ret = new Point();
            double t = (Math.PI * (90 - (6 * second))) / 180;

            ret.X = Convert.ToInt32((radiusCenter + radiusSecondCounter) * (Math.Cos(t)));
            ret.Y = Convert.ToInt32((radiusCenter + radiusSecondCounter) * (Math.Sin(t)));

            if (second > 0 && second <= 15)
            {
                ret.X = center.X + ret.X;
                ret.Y = center.Y - ret.Y;
            }
            else if (second > 15 && second <= 30)
            {
                ret.X = center.X + ret.X;
                ret.Y = center.Y + (ret.Y * (-1));
            }
            else if (second > 30 && second <= 45)
            {
                ret.X = center.X - (ret.X * (-1));
                ret.Y = center.Y + (ret.Y * (-1));
            }
            else if ((second > 45 && second <= 59) || second == 0)
            {
                ret.X = center.X + ret.X;
                ret.Y = center.Y - ret.Y;
            }

            return ret;
        }

        #endregion

        #region Override

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush br = new SolidBrush(this.BackColor);
            e.Graphics.FillRectangle(br, new Rectangle(0, 0, this.Width, this.Height));
            br.Dispose();

            widthHelper = this.Width / 2;
            heightHelper = this.Height / 2;
            center = new Point(widthHelper, heightHelper);
            radiusClock = Math.Min(widthHelper, heightHelper);
            radiusCenter = (radiusClock / 3) * 2;
            radiusMinuteCounter = this.Width / 15;
            radiusHourCounter = this.Width / 15;
            radiusSecondCounter = this.Width / 100;

            if (DesignMode)
                dt = new DateTime(1, 1, 1, 09, 33, 30);
            else
                dt = DateTime.Now;

            var sm = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            PrintClockCircle(e.Graphics);
            PrintCenterCircle(e.Graphics);
            PrintHourCircle(e.Graphics, dt.Hour);
            PrintMinuteCircle(e.Graphics, dt.Minute);
            PrintSecondCircle(e.Graphics, dt.Second);

            e.Graphics.SmoothingMode = sm;

            base.OnPaint(e);
        }

        #endregion
    }
}