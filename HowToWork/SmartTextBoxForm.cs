using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class SmartTextBoxForm : Form
    {
        public SmartTextBoxForm()
        {
            InitializeComponent();

            lbl1.Text = "This box accept all string";
            lbl2.Text = "This box accept all string but not release focus is all characters compatible with regex '\\d*'";
        }

        private void BtnSet_Click(object sender, EventArgs e)
        {
            smartTextBox1.Text = textBox1.Text;
        }
    }
}
