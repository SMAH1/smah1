using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMAH1.Character;
using SMAH1.ExtensionMethod;

namespace HowToWork.Character
{
    public partial class NumeralSystemReplacerForm : Form
    {
        public NumeralSystemReplacerForm()
        {
            InitializeComponent();
        }

        private void NumeralSystemReplacerForm_Load(object sender, EventArgs e)
        {
            cbx.DataSource = SMAH1.EnumInfoBase<NumeralSystemSign>.GetFields().ToList();
            cbx.SelectedIndex = 0;

            var defSel = new NumeralSystemSign[] {NumeralSystemSign.ChineseSimple, NumeralSystemSign.Odia, NumeralSystemSign.Bengali, NumeralSystemSign.Khmer,
                                NumeralSystemSign.Persian, NumeralSystemSign.Arabic, NumeralSystemSign.Thai};

            chbx.SuspendLayout();
            chbx.BeginItemsChange();
            foreach (var f in SMAH1.EnumInfoBase<NumeralSystemSign>.GetFields())
                chbx.Items.Add(f, defSel.Contains(f));
            chbx.EndItemsChange();
            chbx.ResumeLayout();

            txtInput.Text = "四୯٨୧١二۴០៩৪୩1٤۲๐៧৯๖۹๔";
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void chbx_CheckedChanged(object sender, SMAH1.Forms.Clickable.CheckedListBox.CheckeBoxEventArgs e)
        {
            UpdateData();
        }

        private void cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            List<NumeralSystemSign> lst = new List<NumeralSystemSign>();

            var sts = chbx.Items.GetStateOfAll();
            for (int i = 0; i < sts.Count; i++)
            {
                if (sts[i] == CheckState.Checked)
                    lst.Add((NumeralSystemSign)chbx.Items[i]);
            }

            if (lst.Count == 0)
                lst.Add(NumeralSystemSign.Default);

            txtOutput.Text = txtInput.Text.NumeralSystemReplacer((NumeralSystemSign)cbx.SelectedItem, lst.ToArray());
        }
    }
}
