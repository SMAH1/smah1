using SMAH1.ExtensionMethod;
using SMAH1.Forms.Clickable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SMAH1.Forms.Clock
{
    public partial class ClockTextBox : TextBox
    {
        #region Variable

        private ButtonDirection btnUp;
        private ButtonDirection btnDown;
        private TimeLayout timeLayout;
        private BaseClockTextBoxComponent currentValue = null;
        private BaseClockTextBoxComponent[] numbers = null;

        #endregion

        #region Properties

        [Browsable(true)]
        [Category("Appearance")]
        public TimeLayout TimeStatus
        {
            get { return timeLayout; }
            set { timeLayout = value; UpdateLayoutValue(); }
        }

        #endregion

        #region Constructor & Creature

        public ClockTextBox()
        {
            InitializeComponent();
            CreateButton();
            SizeChanged += new EventHandler(ClockTextBox_SizeChanged);
            RightToLeftChanged += new EventHandler(ClockTextBox_RightToLeftChanged);

            timeLayout = TimeLayout.Hour;

            UpdateLayoutValue();
            FindCurrentNumber();
            currentValue = numbers[0];
            this.Select(currentValue.Location, currentValue.Length);

            this.MouseWheel += ClockTextBox_MouseWheel;
        }

        private void CreateButton()
        {
            // 
            // btnUp
            // 
            btnUp = new ButtonDirection();
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUp.Name = "btnUp";
            this.btnUp.TabIndex = 2;
            this.btnUp.Direction = ButtonDirection.ArrowDirection.Up;
            this.btnUp.Type = ButtonDirection.ArrowType.Triangle;
            this.btnUp.BackColor = SystemColors.Control;
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnUp_MouseDown);
            this.btnUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUp.Padding = new Padding(0);
            this.btnUp.Margin = new Padding(0);

            // 
            // btnDown
            // 
            btnDown = new ButtonDirection();
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDown.Name = "btnDown";
            this.btnDown.TabIndex = 3;
            this.btnDown.Direction = ButtonDirection.ArrowDirection.Down;
            this.btnDown.Type = ButtonDirection.ArrowType.Triangle;
            this.btnDown.Text = "";
            this.btnDown.BackColor = SystemColors.Control;
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnDown_MouseDown);
            this.btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDown.Padding = new Padding(0);
            this.btnDown.Margin = new Padding(0);

            this.Controls.Add(btnUp);
            this.Controls.Add(btnDown);

            SetButtomLocation();
        }

        #endregion

        #region Override

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            currentValue = numbers[0];
            this.Select(currentValue.Location, currentValue.Length);
        }

        public override string Text
        {
            get { return base.Text; }
            set { base.Text = value; UpdateFormatText(); }
        }

        #endregion

        #region Event Capture

        private void ClockTextBox_SizeChanged(object sender, EventArgs e)
        {
            SetButtomLocation();
        }

        private void ClockTextBox_RightToLeftChanged(object sender, EventArgs e)
        {
            SetButtomLocation();
        }

        private void BtnUp_MouseDown(object sender, MouseEventArgs e)
        {
            IncreaseNumber();
        }

        private void BtnDown_MouseDown(object sender, MouseEventArgs e)
        {
            DecreaseNumber();
        }

        private void ClockTextBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                IncreaseNumber();
            else if (e.Delta < 0)
                DecreaseNumber();
        }

        private void ClockTextBox_MouseUp(object sender, MouseEventArgs e)
        {
            int fcn = FindCurrentNumber();
            currentValue = numbers[fcn];
            this.Select(currentValue.Location, currentValue.Length);
        }

        private void ClockTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                IncreaseNumber();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                DecreaseNumber();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                FindNextCurrentNumber();
                e.SuppressKeyPress = true;
                currentValue.ClearKeyPressed();
            }
            else if (e.KeyCode == Keys.Left)
            {
                FindPreviousCurrentNumber();
                e.SuppressKeyPress = true;
                currentValue.ClearKeyPressed();
            }
            this.Select(currentValue.Location, currentValue.Length);
        }

        private void ClockTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (char.IsNumber(e.KeyChar))
            {
                string keyRes = currentValue.KeyPressed(e.KeyChar);
                if (!string.IsNullOrEmpty(keyRes))
                    SetNewSelection(Convert.ToInt32(keyRes));
            }
        }

        #endregion

        #region Method

        private void SetButtomLocation()
        {
            int h = this.Size.Height / 2;
            h -= 3;

            int w = this.Size.Width / 10;
            w = Math.Max(w, h * 3);

            this.btnUp.Size = new System.Drawing.Size(w, h);
            this.btnDown.Size = new System.Drawing.Size(w, h);
            bool bR2L = this.IsRTL();
            if (!bR2L)
            {
                this.btnUp.Location = new System.Drawing.Point((this.Width - (w + 5)), 0);
                this.btnDown.Location = new System.Drawing.Point((this.Width - (w + 5)), h + 2);
            }
            else if (bR2L)
            {
                this.btnUp.Location = new System.Drawing.Point(1, 0);
                this.btnDown.Location = new System.Drawing.Point(1, h + 2);
            }
        }

        private void SetNewSelection(int selection)
        {
            int selStart = this.SelectionStart;
            string text = "";
            text = string.Format(currentValue.Format, selection);
            string sRes = this.Text.Substring(0, this.SelectionStart) + text + this.Text.Substring(this.SelectionStart + this.SelectionLength);
            this.Text = sRes;
            this.Select(selStart, text.Length);
        }

        private void IncreaseNumber()
        {
            if (this.SelectionLength > 0)
            {
                int selection = Convert.ToInt32(this.SelectedText);
                if (currentValue.Max == selection)
                    selection = currentValue.Min - 1;
                selection++;
                SetNewSelection(selection);
                currentValue.ClearKeyPressed();
            }
        }

        private void DecreaseNumber()
        {
            if (this.SelectionLength > 0)
            {
                int selection = Convert.ToInt32(this.SelectedText);
                if (currentValue.Min == selection)
                    selection = currentValue.Max + 1;
                selection--;
                SetNewSelection(selection);
                currentValue.ClearKeyPressed();
            }
        }

        private int FindCurrentNumber()
        {
            int selStart = this.SelectionStart;
            int ret = 0;
            for (int i = 0; i < numbers.Length; i++)
                if (selStart >= numbers[i].Location && selStart <= (numbers[i].Location + numbers[i].Length))
                {
                    ret = i;
                    break;
                }
            return ret;
        }

        private void FindPreviousCurrentNumber()
        {
            int fcn = FindCurrentNumber();
            fcn += numbers.Length;
            fcn--;
            fcn %= numbers.Length;
            currentValue = numbers[fcn];
        }

        private void FindNextCurrentNumber()
        {
            int fcn = FindCurrentNumber();
            fcn += numbers.Length;
            fcn++;
            fcn %= numbers.Length;
            currentValue = numbers[fcn];
        }

        private void UpdateLayoutValue()
        {
            DateTime dt = DateTime.Now;
            if (timeLayout == TimeLayout.Hour)
            {
                numbers = new BaseClockTextBoxComponent[]{
                        new HourClockTextBoxComponent(){ Location = 0 }
                    };
            }
            else if (timeLayout == TimeLayout.Minute)
            {
                numbers = new BaseClockTextBoxComponent[]{
                        new MinuteClockTextBoxComponent(){ Location = 0 }
                    };
            }
            else if (timeLayout == TimeLayout.HourMinute)
            {
                numbers = new BaseClockTextBoxComponent[]{
                        new HourClockTextBoxComponent(){ Location = 0 },
                        new MinuteClockTextBoxComponent(){ Location = 3 }
                    };
            }
            else if (timeLayout == TimeLayout.HourMinuteSecond)
            {
                numbers = new BaseClockTextBoxComponent[]{
                        new HourClockTextBoxComponent(){ Location = 0 },
                        new MinuteClockTextBoxComponent(){ Location = 3 },
                        new SecondClockTextBoxComponent(){ Location = 6 }
                    };
            }
            else if (timeLayout == TimeLayout.HourMinuteSecondMillisecond)
            {
                numbers = new BaseClockTextBoxComponent[]{
                        new HourClockTextBoxComponent(){ Location = 0 },
                        new MinuteClockTextBoxComponent(){ Location = 3 },
                        new SecondClockTextBoxComponent(){ Location = 6 },
                        new MillisecondClockTextBoxComponent(){ Location = 9 }
                    };
            }
            UpdateFormatText();
        }

        private void UpdateFormatText()
        {
            string text = base.Text;
            var lst = text.Split(':').ToList();
            while (lst.Count < numbers.Length)
                lst.Add(string.Empty);

            List<string> ret = new List<string>();
            for (int i = 0; i < numbers.Length; i++)
                ret.Add(numbers[i].FormatText(lst[i]));

            base.Text = string.Join(":", ret.ToArray());
        }

        #endregion
    }
}
