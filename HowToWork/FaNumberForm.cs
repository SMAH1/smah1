using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SMAH1.ExtensionMethod.Persian;

namespace HowToWork
{
    public partial class FaNumberForm : Form
    {
        public FaNumberForm()
        {
            InitializeComponent();
        }

        private void btnToFa_Click(object sender, EventArgs e)
        {
            txtNumFa.Text = txtNumEn.Text.ConvertEnDigitToFaDigit();
        }
    }
}
