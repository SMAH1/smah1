using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SMAH1.Forms.Loading.Component;

namespace SMAH1.Forms.Wait
{
    public partial class WaitPleaseForm : Form
    {
        public delegate void FunctionCallBack();

        private Form parent = null;
        private FunctionCallBack doworkFunction = null;
        private FunctionCallBack endworkFunction = null;
        IntPtr handle;

        public WaitPleaseForm(Form _parent, FunctionCallBack _doworkFunction
                    , FunctionCallBack _endworkFunction)
        {
            InitializeComponent();
            doworkFunction = _doworkFunction;
            endworkFunction = _endworkFunction;
            parent = _parent;

            if (parent == null)
                throw new ArgumentNullException("Form must be define");
            if (doworkFunction == null)
                throw new ArgumentNullException("Work function must be define");

            this.Owner = parent;
        }

        private void PleaseWiatForm_Load(object sender, EventArgs e)
        {
            loadingCtrl1.Font =
                new Font(loadingCtrl1.Font.FontFamily, loadingCtrl1.Font.Size * 2);
            Random r = new Random();
            int sel = r.Next(1000) % 18;
            switch (sel)
            {
                case 0: loadingCtrl1.Component = new LClock(true); break;
                case 1: loadingCtrl1.Component = new LFan(true); break;
                case 2: loadingCtrl1.Component = new LFillPoint(); break;
                case 3: loadingCtrl1.Component = new LPlus(true); break;
                case 4: loadingCtrl1.Component = new LTextNose(); break;
                case 5: loadingCtrl1.Component = new LCircularRibbons(); break;
                case 6: loadingCtrl1.Component = new LCircleInterrupted(true); break;
                case 7: loadingCtrl1.Component = new LCageOfBird(true); break;
                case 8: loadingCtrl1.Component = new LHourglass(); break;
                case 9: loadingCtrl1.Component = new LHartPqrst() { HasGrid = false }; break;
                case 10: loadingCtrl1.Component = new LHartPqrst2(); break;
                case 11: loadingCtrl1.Component = new LMessageSend(); break;
                case 12: loadingCtrl1.Component = new LLineSlide(); break;
                case 13: loadingCtrl1.Component = new LPiscina() { Continues = true, ShowLine = false }; break;
                case 14: loadingCtrl1.Component = new LCircularMinimalist(); break;
                case 15: loadingCtrl1.Component = new LCircleWalker(); break;
                case 16: loadingCtrl1.Component = new LYingYang() { ShowLine = false }; break;
                default: loadingCtrl1.Component = new LProtest(true); break;
            }
            parent.Enabled = false;
            this.CenterToParent();
            handle = this.Handle; // Forces creation of the handle (BeginInvoke work correct!)
            Thread thread = new Thread(new ThreadStart(DoWork));
            thread.Start();
        }

        void DoWork()
        {
            this.doworkFunction();
            EndWork();
        }

        void EndWork()
        {
            if (this.InvokeRequired)
            {
                FunctionCallBack d = new FunctionCallBack(EndWork);
                this.BeginInvoke(d, new object[] { });
            }
            else
            {
                parent.Enabled = true;
                this.Close();
                this.Visible = false;   //Fix mono BUG
                this.Dispose();         //Fix mono BUG
                if (endworkFunction != null)
                    this.endworkFunction();
            }
        }
    }
}
