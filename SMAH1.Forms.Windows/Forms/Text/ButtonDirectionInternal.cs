using System.Windows.Forms;

namespace SMAH1.Forms.Text
{
    internal class ButtonDirectionInternal : SMAH1.Forms.Clickable.ButtonDirection
    {
        public ButtonDirectionInternal() : base()
        {
            this.SetStyle(ControlStyles.Selectable, false);

            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
        }
    }
}
