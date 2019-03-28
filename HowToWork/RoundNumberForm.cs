using SMAH1.ExtensionMethod;
using System;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class RoundNumberForm : Form
    {
        public RoundNumberForm()
        {
            InitializeComponent();
        }

        private void RoundNumberForm_Load(object sender, EventArgs e)
        {
            double[] ad = new double[] { 1, 1.1, 1.3,
                2, 3, 5, 7, 9.5,
                10, 20, 20.05, 35, 45, 51, 59, 67, 70, 90,
                -1.1,-2.5,-5,-10,-10.002,-15,-20,-21,-23,-51,-90,
                0.006,0.1,0.15,0.16,0.2,0.3,0.459,0.5,0.51,0.6,0.723,0.9,
                -0.006,-0.1,-0.15,-0.16,-0.2,-0.3,-0.459,-0.5,-0.51,-0.6,-0.723,-0.9
            };

            foreach (double d in ad)
                dgv.Rows.Add(d, d.RoundNumber());
        }
    }
}
