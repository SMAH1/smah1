using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace SMAH1.Print
{
    public class SimplePrinterBitmap
    {
        public delegate Image PaintBitmapFunction(Size size);

        public SimplePrinterBitmap()
            : this(null)
        {
        }

        public SimplePrinterBitmap(PaintBitmapFunction function)
        {
            Image = null;
            PaintBitmap = function;

            Document = new PrintDocument();
            Document.PrintPage += new PrintPageEventHandler(this.OnPrintPage);
        }

        public Image Image { get; set; }
        public PaintBitmapFunction PaintBitmap { get; set; }
        public PrintDocument Document { get; }
        public bool FitToArea { get; set; }

        public bool ShowOptions()
        {
            bool ret = false;

            DialogResult res;
            PrintDialog pdlg;

            pdlg = new PrintDialog
            {
                Document = Document,
                UseEXDialog = true
            };

            res = pdlg.ShowDialog();
            if (res == DialogResult.OK || res == DialogResult.Yes)
            {
                ret = true;
            }
            pdlg.Dispose();
            pdlg = null;

            return ret;
        }

        public bool Print()
        {
            if (Image == null && PaintBitmap == null)
                return false;

            Document.Print();

            return true;
        }

        private void OnPrintPage(object sender, PrintPageEventArgs e)
        {
            Image img = this.Image;

            if (img == null && PaintBitmap != null)
                img = PaintBitmap(new Size(
                    e.MarginBounds.Size.Width, e.MarginBounds.Size.Height));

            if (img != null)
            {
                if (FitToArea)
                {
                    e.Graphics.DrawImage(
                        img,
                        e.MarginBounds,
                        new Rectangle(
                        0,
                        0,
                        img.Width,
                        img.Height),
                        GraphicsUnit.Pixel);
                }
                else
                {
                    e.Graphics.DrawImageUnscaled(
                        img,
                        e.MarginBounds.Left,
                        e.MarginBounds.Top);
                }
            }

            e.HasMorePages = false;
            if (this.Image == null && img != null)
            {
                img.Dispose();
                img = null;
            }
        }
    }
}
