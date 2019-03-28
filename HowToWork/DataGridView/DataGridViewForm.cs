using SMAH1.Forms.DataGridViewComponent;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class DataGridViewForm : Form
    {
        public DataGridViewForm()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
        }

        private void DataGridViewForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Test");
            dt.Columns.Add("Number", typeof(Int32));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Family", typeof(String));
            dt.Columns.Add("Status", typeof(Int32));

            dt.Rows.Add(1, "علی", "Mohamadi", DataGridViewProgressCellState.Queue);
            dt.Rows.Add(5, "Sara", "Sarvi", DataGridViewProgressCellState.Process);
            dt.Rows.Add(4, "محسن", "Saba", DataGridViewProgressCellState.Finish);
            dt.Rows.Add(10, "Rahim", "vahed", 0);
            dt.Rows.Add(10, "Behzad", "Khaki", 25);
            dt.Rows.Add(9, "Mina", "mashhadi", 50);
            dt.Rows.Add(6, "Zahra", "Tavassoly", 75);
            dt.Rows.Add(20, "گلی", "Torki", DataGridViewProgressCellState.Error);

            dgv.DataSource = dt;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Use atuo-increasment in column 1");
            sb.AppendLine("Use number editor in column 2");
            sb.AppendLine("Use progress state in column last");

            label1.Text = sb.ToString();
        }
    }
}
