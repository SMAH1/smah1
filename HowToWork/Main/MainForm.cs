using SMAH1.Forms.Wait;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class MainForm : Form
    {
        FlowLayoutPanel panel = null;

        public MainForm()
        {
            InitializeComponent();

            panel = new FlowLayoutPanel();
            panel.Name = this.Name + "_panel";
            panel.BackColor = Color.Transparent;
            panel.Dock = DockStyle.Fill;
            panel.WrapContents = true;
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.DockPadding.Top = 10;
            panel.DockPadding.Bottom = 10;
            panel.DockPadding.Left = 10;
            panel.DockPadding.Right = 10;
            panel.AutoScroll = true;
            this.Controls.Add(panel);

            panel.SizeChanged += Panel_SizeChanged;

            int lineindex = 0;

            AddButton(new ButtonHelperClass("btnRoundNumber", "Round Number", "HowToWork.RoundNumberForm"));
            AddButton(new ButtonHelperClass("btnEnNum2FaNum", "En Num <==> Fa Num", "HowToWork.FaNumberForm"));
            AddButton(new ButtonHelperClass("btnEnumInfo", "Enum Info", "HowToWork.EnumInfo.EnumInfoTestForm"));
            AddButton(new ButtonHelperClass("btnSerializeXml", "Serialize Xml Helper", "HowToWork.SerializeXmlForm"));
            AddLine(lineindex); lineindex++;
            AddButton(new ButtonHelperClass("btnLoading", "Loading ...", "HowToWork.LoadingTestForm"));
            AddButton(new ButtonHelperClass("btnWaitPlease", "Wait Please", btnWaitPlease_Click));
            AddButton(new ButtonHelperClass("btnWaitProgress", "Wait Progress", btnWaitProgress_Click));
            AddLine(lineindex); lineindex++;
            AddButton(new ButtonHelperClass("btnExport", "Export DataTable", "HowToWork.ExportForm"));
            AddButton(new ButtonHelperClass("btnDVG", "DataGridView", "HowToWork.DataGridViewForm"));
            AddButton(new ButtonHelperClass("btnPrintToGraphics", "DGV Print to Graphics", "HowToWork.PrintToGraphicsForm"));
            AddLine(lineindex); lineindex++;
            AddButton(new ButtonHelperClass("btnSLT", "Text By Format", "HowToWork.SingleLineTextForm"));
            AddLine(lineindex); lineindex++;
            AddButton(new ButtonHelperClass("btnChart1", "Chart 1", "HowToWork.Chart1Form"));
            AddButton(new ButtonHelperClass("btnChart2", "Chart 2", "HowToWork.Chart2Form"));
            AddButton(new ButtonHelperClass("btnChart3", "Chart 3 (Line X Scale)", "HowToWork.Chart3Form"));
            AddButton(new ButtonHelperClass("btnChart4", "Chart 4 (Multi chart)", "HowToWork.Chart4Form"));
            AddButton(new ButtonHelperClass("btnChart5", "Chart 5", "HowToWork.Chart5Form"));
            AddLine(lineindex); lineindex++;
            AddButton(new ButtonHelperClass("btnWondowsControl", "Wondows Control", "HowToWork.WondowsControlForm"));
            AddButton(new ButtonHelperClass("btnSpliteButton", "Splite Button", "HowToWork.SpliteButtonTestForm"));
            AddButton(new ButtonHelperClass("btnPersianDate", "Persian Date", "HowToWork.DateForm"));
            AddButton(new ButtonHelperClass("btnDatePickerTestForm", "Persian DatePicker", "HowToWork.DatePickerTestForm"));
            AddButton(new ButtonHelperClass("btnClockTestForm", "Clock Controls", "HowToWork.ClockTestForm"));
            AddButton(new ButtonHelperClass("btnSmartTextBoxForm", "SmartTextBox", "HowToWork.SmartTextBoxForm"));
            AddButton(new ButtonHelperClass("btnCheckedListBoxTest", "CheckedListBox", "HowToWork.CheckedListBoxTestForm"));
            AddButton(new ButtonHelperClass("btnPropertyGrid", "PropertyGrid", "HowToWork.PropertyGridForm"));
            AddLine(lineindex); lineindex++;
            AddButton(new ButtonHelperClass("btnLargeTextViewer1", "Large Text Viewer", "HowToWork.LargeTextViewerForm"));
            AddButton(new ButtonHelperClass("btnLargeTextViewer2", "Large Text Viewer Bind", "HowToWork.LargeTextViewer2Form"));

        }

        private void Panel_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control c in panel.Controls)
            {
                if (c is Label)
                {
                    c.Size = new Size((panel.Size.Width - 20) * 95 / 100, 2);
                }
            }
        }

        private void AddLine(int index)
        {
            panel.SetFlowBreak(panel.Controls[panel.Controls.Count - 1], true);

            Label lbl = new Label();
            lbl.Name = "lblLineBreakindex";
            lbl.Size = new Size((panel.Size.Width - 20) * 95 / 100, 2);
            lbl.TabIndex = panel.Controls.Count;
            lbl.Text = "";
            lbl.Margin = new Padding(5);
            lbl.AutoSize = false;
            lbl.BackColor = SystemColors.ControlDarkDark;

            panel.Controls.Add(lbl);

            panel.SetFlowBreak(panel.Controls[panel.Controls.Count - 1], true);
        }

        private void AddButton(ButtonHelperClass btnInfo)
        {
            Button btn = new Button();
            btn.Name = btnInfo.ButtonName;
            btn.Size = new Size(130, 32);
            btn.TabIndex = panel.Controls.Count;
            btn.Text = btnInfo.ButtonText;
            btn.Margin = new Padding(5, 3, 15, 3);
            btn.UseVisualStyleBackColor = true;
            btn.Click += (btnInfo.Click != null ?
                btnInfo.Click :
                new System.EventHandler(this.button_Click));
            btn.Tag = btnInfo;

            panel.Controls.Add(btn);
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {//For run in mono
                Button btn = (Button)sender;
                ButtonHelperClass btnInfo = (ButtonHelperClass)btn.Tag;

                Type frmType = Type.GetType(btnInfo.ClassName);
                if (frmType != null)
                {
                    System.Reflection.ConstructorInfo oConstructorInfo = frmType.GetConstructor(System.Type.EmptyTypes);
                    Form frm = (Form)oConstructorInfo.Invoke(null);
                    ShowForm(frm);
                }
                else
                {
                    btnInfo.Click(sender, e);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.StackTrace + Environment.NewLine + exc.Message);
            }
        }

        private void ShowForm(Form frm)
        {
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowInTaskbar = true;
            frm.ShowIcon = false;
            this.Visible = false;
            try
            {//For run in mono
                frm.ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.StackTrace + Environment.NewLine + exc.Message);
            }
            this.Visible = true;
        }

        private void btnWaitPlease_Click(object sender, EventArgs e)
        {
            WaitPleaseForm f = new WaitPleaseForm(
                this, BeginWaitPlease, EndWaitPlease);
            f.Show();
        }

        private void btnWaitProgress_Click(object sender, EventArgs e)
        {
            WaitProgressForm wait = new WaitProgressForm(this, BeginWaitProgress, EndWaitProgress, true);
            wait.WidthDialog = this.Size.Width - 10;
            wait.Maximum = 30;
            wait.Value = 0;
            wait.CancelWork += new EventHandler(CancelWorkWaitProgress);
            wait.BeginOperation();
        }

        /*************** Helper ****************/
        private void BeginWaitPlease()
        {
            Thread.Sleep(3000);
        }
        private void EndWaitPlease()
        {
            //Do you work
        }
        bool cancelWaitProgress = false;
        private void BeginWaitProgress(WaitProgressForm wait)
        {
            cancelWaitProgress = false;
            wait.Message = "Initalize";
            for (int i = 0; i < 30 && !cancelWaitProgress; i++)
            {
                if (i == 5)
                    wait.Message = "i >= 5";
                if (i == 23)
                    wait.Maximum = 20;
                wait.Value = i;
                Thread.Sleep(200);
            }
            cancelWaitProgress = true;
        }
        private void CancelWorkWaitProgress(object sender, EventArgs e)
        {
            cancelWaitProgress = true;
        }
        private void EndWaitProgress()
        {
            if (!cancelWaitProgress)
                cancelWaitProgress = true;
        }
    }
}
