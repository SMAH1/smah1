using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;

namespace SMAH1.Forms.Clock
{
    [DefaultEvent("StateClockChange")]
    [DefaultProperty("ZeroBase")]
    public partial class HourSelector : UserControl
    {
        private class Item
        {
            public readonly int Row;        //Base 0
            public readonly int Column;     //Base 0
            public bool Check;

            public Item(string _text, int r, int c, bool ch)
            {
                Row = r;
                Column = c;
                Check = ch;
                Text = _text;
            }

            public string Text { get; set; }
        }

        int spaceLR = 7;
        int spaceTop = 7;
        int spaceBettween = 4;
        int widthOfCheck = 0;
        int heightOfCheck = 0;
        Bitmap bmpControl;
        Item[,] clocks;
        Rectangle rcAllButton;
        Rectangle rcAnyButton;
        bool zeroBase = true;

        public HourSelector()
        {
            InitializeComponent();
            bmpControl = null;

            CountClockChecked = 0;

            clocks = new Item[6, 4];
            bool check = true;
            for (int i = 0; i < 24; i++)
            {
                Item item = new Item(
                    String.Format("{0:D2}", i),
                    i % 6, i / 6, check
                    );
                clocks[i % 6, i / 6] = item;
                if (item.Check)
                    CountClockChecked++;
                if (DesignMode)
                    check = !check;
            }
        }

        #region Override
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint(e);
            base.OnPaint(e);
        }

        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            RedrawControl();
            base.OnSizeChanged(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = value; RedrawControl(); }
        }

        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; RedrawControl(); }
        }

        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; RedrawControl(); }
        }
        #endregion

        public void RedrawControl()
        {
            if (bmpControl != null)
            {
                bmpControl.Dispose();
                bmpControl = null;
            }

            this.Refresh();
        }

        #region Paint Control
        private void ControlPaint(PaintEventArgs e)
        {
            if (bmpControl == null)
            {
                DrawControl(ref bmpControl);
            }

            if (bmpControl != null)
            {
                e.Graphics.DrawImage(
                    bmpControl, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
            }
        }

        private void SetCheckUncheckColor(ref Color colorUncheck, ref Color colorCheck)
        {
            if (BackColor == SystemColors.ControlLight)
            {
                colorUncheck = SystemColors.Control;
                colorCheck = SystemColors.ControlDark;
            }
            else if (BackColor == SystemColors.ControlDark)
            {
                colorUncheck = SystemColors.ControlLight;
                colorCheck = SystemColors.Control;
            }
            else
            {
                colorUncheck = SystemColors.ControlLight;
                colorCheck = SystemColors.ControlDark;
            }
        }

        private void DrawControl(ref Bitmap bmp)
        {
            Color colorUncheck = SystemColors.ControlLight;
            Color colorCheck = SystemColors.ControlDark;

            SetCheckUncheckColor(ref colorUncheck, ref colorCheck);

            bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                Pen penBorder = new Pen(ForeColor);
                Brush brushErase = new SolidBrush(BackColor);
                gr.FillRectangle(brushErase, ClientRectangle);
                Rectangle rc = new Rectangle(ClientRectangle.Location, ClientRectangle.Size);
                rc.Inflate(-1, -1);

                brushErase.Dispose();

                widthOfCheck = (this.ClientSize.Width - 2 * spaceLR - 3 * spaceBettween) / 4;
                heightOfCheck = (this.ClientSize.Height - 2 * spaceTop - 6 * spaceBettween) / 7;

                Brush brushCheck = new SolidBrush(colorCheck);
                Brush brushUncheck = new SolidBrush(colorUncheck);
                Brush brushTitle = new SolidBrush(ForeColor);

                StringFormat stringFormat = StringFormat.GenericDefault;
                stringFormat.LineAlignment = StringAlignment.Center;
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.Trimming = StringTrimming.None;
                stringFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;

                Rectangle rcItem;
                Rectangle rc2;
                foreach (Item item in clocks)
                {
                    rcItem = new Rectangle(
                        spaceLR + item.Column * (widthOfCheck + spaceBettween),
                        spaceTop + item.Row * (heightOfCheck + spaceBettween),
                        widthOfCheck, heightOfCheck);

                    if (item.Check)
                        gr.FillRectangle(brushCheck, rcItem);
                    else
                        gr.FillRectangle(brushUncheck, rcItem);

                    rc2 = new Rectangle(rcItem.Location, rcItem.Size);
                    rc2.Offset(0, 1);
                    gr.DrawString(item.Text, Font, brushTitle,
                        rc2, stringFormat);

                    gr.DrawRectangle(penBorder, rcItem);
                }

                Rectangle rcCount = new Rectangle();

                //All button
                rcAllButton = new Rectangle(
                    spaceLR + spaceBettween * 2,
                    spaceTop + 6 * (heightOfCheck + spaceBettween),
                    widthOfCheck, heightOfCheck);
                gr.FillRectangle(brushUncheck, rcAllButton);
                rc2 = new Rectangle(rcAllButton.Location, rcAllButton.Size);
                rc2.Offset(0, 1);
                gr.DrawString("All", Font, brushTitle,
                    rc2, stringFormat);
                gr.DrawRectangle(penBorder, rcAllButton);

                rcCount = rcAllButton;

                //Any button
                rcAnyButton = new Rectangle(
                    this.ClientSize.Width - spaceLR - spaceBettween * 2 - widthOfCheck,
                    spaceTop + 6 * (heightOfCheck + spaceBettween),
                    widthOfCheck, heightOfCheck);
                gr.FillRectangle(brushUncheck, rcAnyButton);
                rc2 = new Rectangle(rcAnyButton.Location, rcAnyButton.Size);
                rc2.Offset(0, 1);
                gr.DrawString("Any", Font, brushTitle,
                    rc2, stringFormat);
                gr.DrawRectangle(penBorder, rcAnyButton);

                rcCount.X += rcAnyButton.Width;
                rcCount.Width = rcAnyButton.X - rcCount.X;
                gr.DrawString(CountClockChecked.ToString(), Font, brushTitle,
                    rcCount, stringFormat);

                gr.DrawRectangle(penBorder, rc);
                penBorder.Dispose();
                brushTitle.Dispose();
                brushCheck.Dispose();
                brushUncheck.Dispose();
            }
        }
        #endregion

        private void ClockSelector_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.Location.Y - spaceTop;
            if ((x % (heightOfCheck + spaceBettween)) > heightOfCheck)
                return;
            x /= (heightOfCheck + spaceBettween);
            if (x > 7)
                return;
            if (x == 6)
            {//All & Any button
                if (rcAllButton.Contains(e.Location))
                {
                    for (int i = 0; i < 6; i++)
                        for (int j = 0; j < 4; j++)
                            clocks[i, j].Check = true;
                    CountClockChecked = 24;

                    OnStateClockChange();
                    RedrawControl();
                }
                else if (rcAnyButton.Contains(e.Location))
                {
                    for (int i = 0; i < 6; i++)
                        for (int j = 0; j < 4; j++)
                            clocks[i, j].Check = false;
                    CountClockChecked = 0;

                    OnStateClockChange();
                    RedrawControl();
                }
            }
            else
            {
                int y = e.Location.X - spaceLR;
                if ((y % (widthOfCheck + spaceBettween)) > widthOfCheck)
                    return;
                y /= (widthOfCheck + spaceBettween);
                if (y > 3)
                    return;

                clocks[x, y].Check = !clocks[x, y].Check;
                if (clocks[x, y].Check)
                    CountClockChecked++;
                else
                    CountClockChecked--;

                OnStateClockChange();
                RedrawControl();
            }
        }

        private void ClockSelector_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int x = e.Location.Y - spaceTop;
            if ((x % (heightOfCheck + spaceBettween)) > heightOfCheck)
                return;
            x /= (heightOfCheck + spaceBettween);
            if (x > 5)
                return;

            int y = e.Location.X - spaceLR;
            if ((y % (widthOfCheck + spaceBettween)) > widthOfCheck)
                return;
            y /= (widthOfCheck + spaceBettween);
            if (y > 3)
                return;

            bool bCkeck = clocks[x, y].Check;
            for (int i = 0; i < 6; i++)
                clocks[i, y].Check = bCkeck;

            CountClockChecked = 0;
            foreach (Item item in clocks)
                if (item.Check)
                    CountClockChecked++;

            OnStateClockChange();
            RedrawControl();
        }

        /************************* public ************************/

        /// <summary>
        /// Count of clock that is checked.
        /// </summary>
        [Browsable(false)]
        public int CountClockChecked { get; private set; } = 0;

        /// <summary>
        /// Clock is 00..23 or 01..24
        /// </summary>
        [DefaultValue(true)]
        [Description("Clock is 00..23 or 01..24")]
        public bool ZeroBase
        {
            get { return zeroBase; }
            set
            {
                zeroBase = value;
                for (int i = 0; i < 24; i++)
                {
                    Item item = clocks[i % 6, i / 6];
                    item.Text = String.Format("{0:D2}", (zeroBase ? i : i + 1));
                }
                RedrawControl();
            }
        }

        /// <summary>
        /// Return array of string of clock checked (with ZeroBase applay).
        /// </summary>
        /// <returns>array of string (length is count of clock that is checked)</returns>
        public string[] GetClockCheckedString()
        {
            List<string> lst = new List<string>();
            for (int j = 0; j < 4; j++)
                for (int i = 0; i < 6; i++)
                    if (clocks[i, j].Check)
                        lst.Add(clocks[i, j].Text);
            return lst.ToArray();
        }

        /// <summary>
        /// Return array (with length 24) of clock state : True for checked
        /// </summary>
        /// <returns>array of bool (with length 24)</returns>
        public bool[] GetClockCheckState()
        {
            bool[] bClock = new bool[24];
            for (int j = 0; j < 4; j++)
                for (int i = 0; i < 6; i++)
                    bClock[j * 6 + i] = clocks[i, j].Check;
            return bClock;
        }

        /// <summary>
        /// Set checked clock
        /// </summary>
        /// <param name="bClock">array (with length 24) of clock state : True for checked</param>
        public void SetClockCheckState(bool[] bClock)
        {
            if (bClock.Length != 24)
                throw new ArgumentException("Length of 'bClock' must be 24 (clocks length)");
            for (int j = 0; j < 4; j++)
                for (int i = 0; i < 6; i++)
                    clocks[i, j].Check = bClock[j * 6 + i];
            RedrawControl();
        }

        #region Custom Events
        public delegate void StateClockChangeEvent(object sender, EventArgs e);

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Fire when clock(s) change.")]
        public event StateClockChangeEvent StateClockChange;

        private void OnStateClockChange()
        {
            StateClockChange?.Invoke(this, new EventArgs());
        }
        #endregion
    }
}
