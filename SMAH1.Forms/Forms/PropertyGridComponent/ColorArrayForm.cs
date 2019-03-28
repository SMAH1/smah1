using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Design;
using SMAH1.Attributes;

namespace SMAH1.Forms.PropertyGridComponent
{
    public partial class ColorArrayForm : Form
    {
        public ColorArrayForm(Color[] colors, string title, IColorArrayEditorCaller caller)
        {
            InitializeComponent();

            if (colors != null)
                foreach (Color c in colors)
                {
                    ColorArrayItem it = new ColorArrayItem(c, this);
                    lsb.Items.Add(it);
                }
            this.Text = title;

            if (caller != null)
            {
                lsb.BackColor = caller.BackColorForColorArrayEditor;
                lsb.ForeColor = caller.ForeColorForColorArrayEditor;

                foreach (Control con in this.Controls)
                {
                    if (con is Button)
                        con.Text = caller.GetButtonText(con.Text);
                }
            }

            btnRemove.Enabled = (lsb.SelectedItems.Count > 0 &&
                lsb.Items.Count > 0);
        }

        private void Lsb_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Set the DrawMode property to draw fixed sized items.
            lsb.DrawMode = DrawMode.OwnerDrawFixed;

            StringFormat stringFormat = StringFormat.GenericDefault;
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.Trimming = StringTrimming.None;
            stringFormat.FormatFlags = StringFormatFlags.NoWrap | StringFormatFlags.LineLimit;

            if (e.Index > -1)
            {
                ColorArrayItem item = (ColorArrayItem)lsb.Items[e.Index];
                item.DrawItem(e, stringFormat);
            }

            stringFormat.Dispose();

            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        private void Lsb_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = (lsb.SelectedItems.Count > 0 &
                lsb.Items.Count > 1);

            if (lsb.SelectedIndex > -1)
            {
                pg.SelectedObject = lsb.Items[lsb.SelectedIndex];

                //For fix bug in mono for show
                //      Scroll and Color combobox caret
                pg.Size = new Size(pg.Size.Width + 1, pg.Size.Height);
                pg.Size = new Size(pg.Size.Width - 1, pg.Size.Height);
            }
            else
                pg.SelectedObject = null;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lsb.SelectedItems.Count > 0)
            {
                int sel = lsb.SelectedIndex;
                lsb.Items.RemoveAt(lsb.SelectedIndex);
                if (lsb.Items.Count > 0)
                    if (sel < lsb.Items.Count)
                        lsb.SelectedIndex = sel;
                    else
                    {
                        sel--;
                        if (sel < lsb.Items.Count)
                            lsb.SelectedIndex = sel;
                    }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            lsb.Items.Add(new ColorArrayItem(Color.White, this));
        }

        internal void ReSelectedObject(ColorArrayItem cai)
        {
            int sel = lsb.SelectedIndex;
            if (sel != -1)
            {
                Rectangle rc = lsb.GetItemRectangle(sel);
                lsb.Invalidate(rc);
            }
        }

        internal object GetColorArray()
        {
            Color[] ca = new Color[lsb.Items.Count];
            int i = 0;
            foreach (object o in lsb.Items)
            {
                ca[i] = ((ColorArrayItem)o).Color;
                i++;
            }
            return ca;
        }
    }

    #region ColorArrayEditor

    #endregion

    #region ColorArrayItem
    
    #endregion
}
