using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SMAH1.Forms.Loading;

namespace HowToWork
{
    public partial class CheckedListBoxTestForm : Form
    {
        string[] sa = null;

        public CheckedListBoxTestForm()
        {
            InitializeComponent();

            sa = new string[] {
                "First",
                "Second",
                "Three",
                "I",
                "You",
                "He",
                "She",
                "Hello",
                "Car",
                "Door",
            };
        }

        private void CheckedListBoxTestForm_Load(object sender, EventArgs e)
        {
            pg.SelectedObject = chbx;

            chbx.SuspendLayout();
            chbx.BeginItemsChange();
            for (int i = 0; i < sa.Length; i++)
            {
                if (i < 3)
                {
                    chbx.Items.Add(sa[i],
                        i == 0 ? CheckState.Checked : (i == 1 ? CheckState.Indeterminate : CheckState.Unchecked)
                        );
                }
                else
                {
                    chbx.Items.Add(sa[i]);
                }
            }
            chbx.GroupItemsCount.Add(3);
            chbx.GroupItemsCount.Add(4);
            chbx.GroupItemsCount.Add(1);
            chbx.EndItemsChange();
            chbx.ResumeLayout();
        }

        private void AppendLine(string text)
        {
            txt.AppendText(text);
            txt.AppendText(Environment.NewLine);
        }

        Random rnd = new Random();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
            int index = rnd.Next(0, chars.Length - 1);
            chbx.Items.Add(chars[index]);

            AppendLine("Add '" + chars[index] + "'");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
            int index1 = rnd.Next(0, chars.Length - 1);
            int index2 = rnd.Next(0, chbx.Items.Count - 1);
            chbx.Items.InsertAt(index2, chars[index1]);

            AppendLine("InsertAt '" + chars[index1] + "' At " + index2);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int index2 = rnd.Next(0, chbx.Items.Count - 1);
            chbx.Items.RemoveAt(index2);

            AppendLine("RemoveAt " + index2);
        }

        private void chbx_CheckedChanged(object sender, SMAH1.Forms.Clickable.CheckedListBox.CheckeBoxEventArgs e)
        {
            AppendLine("CheckedChanged : " + e.Index);
            AppendLine("     " + chbx.Items[e.Index] + " : " + chbx.ItemChecked[e.Index] + " : " + chbx.ItemCheckState[e.Index]);
        }

        private void chbx_CheckStateChanged(object sender, SMAH1.Forms.Clickable.CheckedListBox.CheckeBoxEventArgs e)
        {
            AppendLine("CheckStateChanged : " + e.Index);
            AppendLine("     " + chbx.Items[e.Index] + " : " + chbx.ItemChecked[e.Index] + " : " + chbx.ItemCheckState[e.Index]);
        }
    }
}
