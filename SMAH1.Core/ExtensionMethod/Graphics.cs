using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

#if NETFULL
namespace SMAH1.ExtensionMethod
{
    public static class GraphicsExtensionMethod
    {
        public static GraphicsPath CreateRoundedRectangle(this Rectangle rcBounds, int nCornerRadius)
        {
            GraphicsPath gfxPath = new GraphicsPath();

            gfxPath.AddArc(
                rcBounds.X,
                rcBounds.Y,
                nCornerRadius, nCornerRadius,
                180, 90);

            gfxPath.AddArc(
                rcBounds.X + rcBounds.Width - nCornerRadius,
                rcBounds.Y,
                nCornerRadius, nCornerRadius,
                270, 90);

            gfxPath.AddArc(
                rcBounds.X + rcBounds.Width - nCornerRadius,
                rcBounds.Y + rcBounds.Height - nCornerRadius,
                nCornerRadius, nCornerRadius,
                0, 90);

            gfxPath.AddArc(
                rcBounds.X,
                rcBounds.Y + rcBounds.Height - nCornerRadius,
                nCornerRadius, nCornerRadius,
                90, 90);

            gfxPath.CloseAllFigures();

            return gfxPath;
        }

        public static Icon ToIcon(this Image img, int size)
        {
            Bitmap square = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(square);

            int x, y, w, h;

            float ratio = (float)img.Width / (float)img.Height;

            if (ratio > 1)
            {
                // Width is bigger
                w = size;
                h = (int)(size / ratio);
                x = 0;

                // center the image
                y = (size - h) / 2;
            }
            else
            {
                // Height is bigger
                w = (int)(size * ratio);
                h = size;
                y = 0;

                // center the image
                x = (size - w) / 2;
            }

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(img, x, y, w, h);
            g.Flush();

            return Icon.FromHandle(square.GetHicon());
        }

        public static Bitmap Grayscale(this Image original)
        {
            Bitmap output = new Bitmap(original.Width, original.Height);
            using (Graphics g = Graphics.FromImage(output))
            {
                //create the grayscale ColorMatrix
                ColorMatrix matrix = new ColorMatrix(
                   new float[][]
                      {
                         new float[] {0.5f,0.5f,0.5f,0,0},
                         new float[] {0.5f,0.5f,0.5f,0,0},
                         new float[] {0.5f,0.5f,0.5f,0,0},
                         new float[] {0, 0, 0, 1, 0},
                         new float[] {0, 0, 0, 0, 1}
                      });

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix);

                g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                   0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
            }
            return output;
        }
    }
}
#endif
