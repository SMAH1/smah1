using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SMAH1.Forms.Wait
{
    public partial class WaitProgressForm : Form
    {
        public delegate void VoidFunctionCallBack();
        public delegate void IntFunctionCallBack(int param);
        public delegate void StringFunctionCallBack(string param);
        public delegate void WaitFunctionCallBack(WaitProgressForm param);

        private Form parent = null;
        private WaitFunctionCallBack doworkFunction = null;
        private VoidFunctionCallBack endworkFunction = null;

        public WaitProgressForm(Form _parent, WaitFunctionCallBack _doworkFunction
                    , VoidFunctionCallBack _endworkFunction)
            : this(_parent, _doworkFunction, _endworkFunction, true)
        {
        }

        public WaitProgressForm(Form _parent, WaitFunctionCallBack _doworkFunction
                    , VoidFunctionCallBack _endworkFunction, bool cancelShow)
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

            if (cancelShow == false)
            {
                btnCancel.Visible = false;
                progressBar1.Size = lblMsg.Size;
            }
        }

        private void WaitForm_Load(object sender, EventArgs e)
        {
            parent.Enabled = false;
            this.CenterToParent();
            Thread thread = new Thread(new ThreadStart(DoWork));
            thread.Start();
        }

        void DoWork()
        {
            this.doworkFunction(this);
            EndWork();
        }

        void EndWork()
        {
            VoidFunctionCallBack d = new VoidFunctionCallBack(EndWork);
            if (this.InvokeRequired)
            {
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

        public void BeginOperation()
        {
            VoidFunctionCallBack d = new VoidFunctionCallBack(BeginOperation);
            if (this.InvokeRequired)
            {
                this.Invoke(d, new object[] { });
            }
            else
            {
                base.Show();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CancelWork?.Invoke(this, e);
        }

        #region Property
        /********************** Property ***************************/
        public int WidthDialog
        {
            get { return this.Size.Width; }
            set { SetWidth(value); }
        }

        public string Message
        {
            get { return lblMsg.Text; }
            set { SetText(value); }
        }

        public int Maximum
        {
            get { return progressBar1.Maximum; }
            set { SetMaximum(value); }
        }

        public int Value
        {
            get { return progressBar1.Value; }
            set { SetValue(value); }
        }

        public Image CancelImage
        {
            get { return btnCancel.Image; }
            set { btnCancel.Image = value; }
        }
        #endregion

        #region private property functions
        /********************** private ***************************/
        private void SetWidth(int newWidth)
        {
            if (this.InvokeRequired)
            {
                IntFunctionCallBack d = new IntFunctionCallBack(SetWidth);
                this.Invoke(d, new object[] { newWidth });
            }
            else
            {
                this.Size = new Size(newWidth, Size.Height);
                this.CenterToParent();
            }
        }

        private void SetMaximum(int max)
        {
            if (this.InvokeRequired)
            {
                IntFunctionCallBack d = new IntFunctionCallBack(SetMaximum);
                this.Invoke(d, new object[] { max });
            }
            else
            {
                progressBar1.Maximum = max;
            }
        }

        private void SetValue(int value)
        {
            if (this.InvokeRequired)
            {
                IntFunctionCallBack d = new IntFunctionCallBack(SetValue);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                progressBar1.Value = value;
            }
        }

        private void SetText(string str)
        {
            if (this.InvokeRequired)
            {
                StringFunctionCallBack d = new StringFunctionCallBack(SetText);
                this.Invoke(d, new object[] { str });
            }
            else
            {
                lblMsg.Text = str;
            }
        }
        #endregion

        #region Event
        /********************** private ***************************/
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public event EventHandler CancelWork = null;

        #endregion
    }
}
