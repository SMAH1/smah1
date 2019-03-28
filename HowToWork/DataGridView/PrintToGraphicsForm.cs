using SMAH1.Forms.DataGridViewComponent;
using SMAH1.Print;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HowToWork
{
    public partial class PrintToGraphicsForm : Form
    {
        #region class Page
        class Page
        {
            string name;
            Image image;

            public string Name { get { return name; } }
            public Image Image { get { return image; } }

            public override string ToString()
            {
                return Name;
            }

            public Page(string name, Image image)
            {
                this.name = name;
                this.image = image;

                if (image == null)
                    throw new ArgumentNullException("image");
            }
        }
        #endregion

        DataTable dt = null;

        public PrintToGraphicsForm()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
        }

        private void PrintToImageForm_Load(object sender, EventArgs e)
        {
            dt = new DataTable("Test");
            dt.Columns.Add("Number", typeof(Int32));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Family", typeof(String));
            dt.Columns.Add("Status", typeof(Int32));

            dt.Rows.Add(1, "Ali", "Mohamadi", DataGridViewProgressCellState.Queue);
            dt.Rows.Add(5, "Sara", "Sarvi", DataGridViewProgressCellState.Process);
            dt.Rows.Add(4, "Mohsen", "Saba", DataGridViewProgressCellState.Finish);
            dt.Rows.Add(10, "Rahim", "vahed", 0);
            dt.Rows.Add(10, "Behzad", "Khaki", 25);
            dt.Rows.Add(9, "Mina", "mashhadi", 50);
            dt.Rows.Add(6, "Zahra", "Tavassoly", 75);
            dt.Rows.Add(20, "Rostam", "Torki", DataGridViewProgressCellState.Error);

            dgv.DataSource = dt;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string sTitle = txtTitle.Text.Trim();

            PrintToGraphics prn = new PrintToGraphics(dt, this.Font,
                int.Parse(txtWidth.Text), int.Parse(txtHeight.Text), 10, 20, false,
                (sTitle.Length > 0),
                null, Color.Black, false, new Padding(3), 1f);

            lstPage.Items.Clear();
            lstPage.SelectedIndex = -1;

            bool bDraw = true;
            bool bFirstPage = true;
            int num = 0;
            while (bDraw)
            {
                num++;
                Bitmap bmp = new Bitmap(int.Parse(txtWidth.Text), int.Parse(txtHeight.Text),
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    if (bFirstPage)
                    {
                        bDraw = prn.Draw(gr, 10, 10, sTitle, true);
                        bFirstPage = false;
                    }
                    else
                    {
                        bDraw = prn.Draw(gr, 0, 0, string.Empty, false);
                    }
                    lstPage.Items.Add(new Page("Page " + num, bmp));
                }
            }

            if (lstPage.Items.Count > 0)
                lstPage.SelectedIndex = 0;
        }

        private void lstPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPage.SelectedIndex == -1)
            {
                picPage.Image = null;
                picPage.Size = new Size(1, 1);
            }
            else
            {
                Image img = ((Page)lstPage.SelectedItem).Image;
                picPage.Image = img;
            }
        }
    }
}
