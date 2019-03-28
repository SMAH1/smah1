using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Design;
using SMAH1.Attributes;

namespace SMAH1.Forms.PropertyGridComponent
{
    internal class ColorArrayItem
    {
        Color color;
        ColorArrayForm parent;

        internal ColorArrayItem(Color c, ColorArrayForm _parent)
        {
            color = c;
            parent = _parent;
            if (parent == null)
                throw new ArgumentNullException("_parent can not null!");
        }

        [Category("Color Picker")]
        public Color Color
        {
            get { return color; }
            set { color = value; parent.ReSelectedObject(this); }
        }

        [Category("Color RGB")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(byte.MinValue, byte.MaxValue)]
        public byte R
        {
            get { return color.R; }
            set
            {
                color = Color.FromArgb(255, value, color.G, color.B);
                parent.ReSelectedObject(this);
            }
        }

        [Category("Color RGB")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(byte.MinValue, byte.MaxValue)]
        public byte G
        {
            get { return color.G; }
            set
            {
                color = Color.FromArgb(255, color.R, value, color.B);
                parent.ReSelectedObject(this);
            }
        }

        [Category("Color RGB")]
        [Editor(typeof(NumericIntUpDownEditor), typeof(UITypeEditor))]
        [MaxMinForInt(byte.MinValue, byte.MaxValue)]
        public byte B
        {
            get { return color.B; }
            set
            {
                color = Color.FromArgb(255, color.R, color.G, value);
                parent.ReSelectedObject(this);
            }
        }

        internal void DrawItem(DrawItemEventArgs e, StringFormat stringFormat)
        {
            Brush br = new SolidBrush(e.BackColor);
            e.Graphics.FillRectangle(br, e.Bounds);
            br.Dispose();

            Rectangle rc = new Rectangle(e.Bounds.Location, e.Bounds.Size);
            rc.Width /= 3;
            rc.Inflate(-5, 0);
            br = new SolidBrush(color);
            e.Graphics.FillRectangle(br, rc);
            br.Dispose();

            rc = new Rectangle(
                e.Bounds.Location.X + e.Bounds.Size.Width / 3,
                e.Bounds.Location.Y,
                e.Bounds.Size.Width / 2,
                e.Bounds.Size.Height
                );
            br = new SolidBrush(e.ForeColor);
            e.Graphics.DrawString(
                color.Name, e.Font, br,
                rc, stringFormat);
            br.Dispose();
        }

        public override string ToString()
        {
            return color.Name;
        }
    }
}
