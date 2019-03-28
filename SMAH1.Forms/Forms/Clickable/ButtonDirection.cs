using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SMAH1.Forms.Clickable
{
    public class ButtonDirection : Button
    {
        ArrowDirection direction;
        ArrowType type;
        public ButtonDirection()
            : base()
        {
            direction = ArrowDirection.Up;
            type = ArrowType.Vector;

            this.Paint += new PaintEventHandler(ButtonDirectionPaint);
        }

        void ButtonDirectionPaint(object sender, PaintEventArgs e)
        {
            // e.ClipRectangle is only viewer area (if area hide by other form or control)
            Rectangle rc = this.ClientRectangle;

            //Apply Padding
            rc = new Rectangle(
                rc.Left + Padding.Left,
                rc.Top + Padding.Top,
                rc.Right - Padding.Horizontal,
                rc.Bottom - Padding.Vertical
                );

            Brush br = new SolidBrush(this.Enabled ? this.ForeColor : SystemColors.ControlDark);
            GraphicsPath path = new GraphicsPath();
            path.StartFigure(); // Start the first figure.
            PointF[] points = null;

            if (type == ArrowType.Vector)
                points = DirectionToLineVector(rc);
            else if (type == ArrowType.Triangle)
                points = DirectionToLineTriangle(rc);

            path.AddLines(points);
            path.CloseFigure(); // Second figure is closed.
            e.Graphics.FillPath(br, path);

            path.Dispose();
            br.Dispose();
        }

        private PointF[] DirectionToLineVector(Rectangle rc)
        {
            float w2 = rc.Width / 2.0F;
            float w4 = rc.Width / 4.0F;
            float h2 = rc.Height / 2.0F;
            float h4 = rc.Height / 4.0F;

            PointF[] points = null;

            switch (direction)
            {
                case ButtonDirection.ArrowDirection.Up:
                    points = new PointF[]{
                           new PointF(rc.X + w2, rc.Y),
                           new PointF(rc.X + rc.Width, rc.Y + h2),
                           new PointF(rc.X + w2 + w4, rc.Y + h2),
                           new PointF(rc.X + w2 + w4, rc.Y + rc.Height),
                           new PointF(rc.X + w4, rc.Y + rc.Height),
                           new PointF(rc.X + w4, rc.Y + h2),
                           new PointF(rc.X, rc.Y + h2)
                        };
                    break;
                case ButtonDirection.ArrowDirection.Down:
                    points = new PointF[]{
                           new PointF(rc.X + w2, rc.Y + rc.Height),
                           new PointF(rc.X + rc.Width, rc.Y + h2),
                           new PointF(rc.X + w2 + w4, rc.Y + h2),
                           new PointF(rc.X + w2 + w4, rc.Y),
                           new PointF(rc.X + w4, rc.Y),
                           new PointF(rc.X + w4, rc.Y + h2),
                           new PointF(rc.X, rc.Y + h2)
                        };
                    break;
                case ButtonDirection.ArrowDirection.Left:
                    points = new PointF[]{
                           new PointF(rc.X, rc.Y + h2),
                           new PointF(rc.X + w2, rc.Y + rc.Height),
                           new PointF(rc.X + w2, rc.Y + h2 + h4),
                           new PointF(rc.X + rc.Width, rc.Y + h2 + h4),
                           new PointF(rc.X + rc.Width, rc.Y + h4),
                           new PointF(rc.X + w2, rc.Y + h4),
                           new PointF(rc.X + w2, rc.Y)
                        };
                    break;
                case ButtonDirection.ArrowDirection.Right:
                    points = new PointF[]{
                           new PointF(rc.X + rc.Width, rc.Y + h2),
                           new PointF(rc.X + w2 , rc.Y + rc.Height),
                           new PointF(rc.X + w2, rc.Y + h2 + h4),
                           new PointF(rc.X, rc.Y + h2 + h4),
                           new PointF(rc.X, rc.Y + h4),
                           new PointF(rc.X + w2, rc.Y + h4),
                           new PointF(rc.X + w2, rc.Y)
                        };
                    break;
            }
            return points;
        }

        private PointF[] DirectionToLineTriangle(Rectangle rc)
        {
            float w5 = rc.Width / 5.0F;
            float w2 = rc.Width / 2.0F;
            float h5 = rc.Height / 5.0F;
            float h2 = rc.Height / 2.0F;

            w5 = h5 = 0;

            PointF[] points = null;

            switch (direction)
            {
                case ButtonDirection.ArrowDirection.Up:
                    points = new PointF[]{
                           new PointF(rc.X + w2, rc.Y + h5),
                           new PointF(rc.X + w5, rc.Y + rc.Height - h5),
                           new PointF(rc.X + rc.Width - w5, rc.Y + rc.Height - h5)
                        };
                    break;
                case ButtonDirection.ArrowDirection.Down:
                    points = new PointF[]{
                           new PointF(rc.X + w2, rc.Y + rc.Height - h5),
                           new PointF(rc.X + w5, rc.Y + h5),
                           new PointF(rc.X + rc.Width - w5, rc.Y + h5)
                        };
                    break;
                case ButtonDirection.ArrowDirection.Left:
                    points = new PointF[]{
                           new PointF(rc.X + w5, rc.Y + h2),
                           new PointF(rc.X + rc.Width - w5, rc.Y + h5),
                           new PointF(rc.X + rc.Width - w5, rc.Y + rc.Height - h5)
                        };
                    break;
                case ButtonDirection.ArrowDirection.Right:
                    points = new PointF[]{
                           new PointF(rc.X + rc.Width - w5, rc.Y + h2),
                           new PointF(rc.X + w5, rc.Y + h5),
                           new PointF(rc.X + w5, rc.Y + rc.Height - h5)
                        };
                    break;
            }
            return points;
        }

        [Category("Layout")]
        [DefaultValue(ArrowDirection.Up)]
        public ArrowDirection Direction
        {
            get { return direction; }
            set { direction = value; Refresh(); }
        }

        [Category("Layout")]
        [DefaultValue(ArrowType.Vector)]
        public ArrowType Type
        {
            get { return type; }
            set { type = value; Refresh(); }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public override string Text
        {
            get { return string.Empty; }
            set { }
        }

        public enum ArrowDirection
        {
            Up,
            Down,
            Left,
            Right
        }

        public enum ArrowType
        {
            Vector,
            Triangle
        }
    }
}
