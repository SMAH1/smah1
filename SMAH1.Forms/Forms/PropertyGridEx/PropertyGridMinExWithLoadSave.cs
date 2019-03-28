using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace SMAH1.Forms.PropertyGridEx
{
    public class PropertyGridMinExWithLoadSave : PropertyGridMinEx
    {
        ToolStripButton buttonSave;
        ToolStripButton buttonLoad;
        ToolStripMenuItem menuSave;
        ToolStripMenuItem menuLoad;
        ContextMenuStrip cmenu;

        public PropertyGridMinExWithLoadSave(bool showLoadSave, Form parent)
            : this(showLoadSave, parent, true)
        {
        }

        public PropertyGridMinExWithLoadSave(bool showLoadSave, Form parent, bool extended)
            : base(extended)
        {
            if (isExtendedField)
            {
                ButtonOfToolStripOfPropertyGrid(showLoadSave);
                if (parent == null)
                    throw new ArgumentNullException("'parent' must be value");
                parent.Load += new EventHandler(Parent_Load);
            }
            else
            {
                MenuOfToolStripOfPropertyGrid(showLoadSave);
            }
        }

        public override RightToLeft RightToLeft
        {
            get { return base.RightToLeft; }
            set
            {
                base.RightToLeft = value;
                if (isExtendedField && platformField == PlatformDetect.Mono)
                {//Fix Mono Bug
                    foreach (ToolStripItem item in ToolStrip.Items)
                        item.DisplayStyle = ToolStripItemDisplayStyle.Image;
                }
            }
        }

        #region Save & Load
        public bool ShowLoadSave
        {
            set
            {
                if (isExtendedField)
                    buttonLoad.Visible = buttonSave.Visible = value;
                else
                {
                    if (value)
                        this.ContextMenuStrip = cmenu;
                    else
                        this.ContextMenuStrip = null;
                }
            }
        }

        public string LoadText
        {
            get
            {
                if (isExtendedField)
                    return buttonLoad.Text;
                return menuLoad.Text;
            }
            set
            {
                if (isExtendedField)
                    buttonLoad.Text = buttonLoad.ToolTipText = value;
                else
                    menuLoad.Text = value;
            }
        }

        public Image LoadImage
        {
            get
            {
                if (isExtendedField)
                    return buttonLoad.Image;
                return menuLoad.Image;
            }
            set
            {
                if (isExtendedField)
                    buttonLoad.Image = value;
                else
                    menuLoad.Image = value;
            }
        }

        public event EventHandler ClickLoad
        {
            add
            {
                if (isExtendedField)
                    buttonLoad.Click += value;
                else
                    menuLoad.Click += value;
            }
            remove
            {
                if (isExtendedField)
                    buttonLoad.Click -= value;
                else
                    menuLoad.Click -= value;
            }
        }

        public string SaveText
        {
            get
            {
                if (isExtendedField)
                    return buttonSave.Text;
                return menuSave.Text;
            }
            set
            {
                if (isExtendedField)
                    buttonSave.Text = buttonSave.ToolTipText = value;
                else
                    menuSave.Text = value;
            }
        }

        public Image SaveImage
        {
            get
            {
                if (isExtendedField)
                    return buttonSave.Image;
                return menuSave.Image;
            }
            set
            {
                if (isExtendedField)
                    buttonSave.Image = value;
                else
                    menuSave.Image = value;
            }
        }

        public event EventHandler ClickSave
        {
            add
            {
                if (isExtendedField)
                    buttonSave.Click += value;
                else
                    menuSave.Click += value;
            }
            remove
            {
                if (isExtendedField)
                    buttonSave.Click -= value;
                else
                    menuSave.Click -= value;
            }
        }

        private void ButtonOfToolStripOfPropertyGrid(bool showLoadSave)
        {
            buttonLoad = new ToolStripButton();
            buttonSave = new ToolStripButton();

            buttonLoad.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonLoad.ImageTransparentColor = Color.Magenta;
            buttonLoad.Name = "ButtonLoad";
            buttonLoad.Size = new Size(23, 22);
            buttonLoad.Text = "Load";

            buttonSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            buttonSave.ImageTransparentColor = Color.Magenta;
            buttonSave.Name = "ButtonSave";
            buttonSave.Size = new System.Drawing.Size(23, 22);
            buttonSave.Text = "Save";

            buttonLoad.Visible = buttonSave.Visible = showLoadSave;
        }

        private void MenuOfToolStripOfPropertyGrid(bool showLoadSave)
        {
            cmenu = new ContextMenuStrip();
            menuLoad = new ToolStripMenuItem("&Load");
            cmenu.Items.Add(menuLoad);
            menuSave = new ToolStripMenuItem("&Save");
            cmenu.Items.Add(menuSave);

            if (showLoadSave)
                this.ContextMenuStrip = cmenu;
        }
        #endregion

        void Parent_Load(object sender, EventArgs e)
        {
            ConfigToolStrip();
            SetNewImageOfBackPropertyGrid();
        }

        protected void ConfigToolStrip()
        {
            this.ToolStrip.Items.AddRange(new ToolStripItem[] {
                    buttonLoad,
                    buttonSave});
            if (platformField == PlatformDetect.DotNet)
            {
                this.ToolStrip.Items.RemoveAt(4);  // Remove the Property Pages button
            }
            if (platformField == PlatformDetect.Mono)
            {
                this.ToolStrip.Items.RemoveAt(3);  // Remove the Property Pages button

                this.ToolStrip.ItemAdded += new ToolStripItemEventHandler(HandlePropToolStripItemAddeded);
            }
            this.Resize += new System.EventHandler(This_Resize);

            ToolStripProfessionalRenderer renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColorsRender())
            {
                RoundedEdges = false
            };
            this.ToolStrip.Renderer = renderer;

            Control con = this.PropertyGridView;
        }

        void HandlePropToolStripItemAddeded(object sender, ToolStripItemEventArgs e)
        {//Fix Bug Mono
            string s = "Property Pages";
            if (e.Item.Name == s || e.Item.ToolTipText == s)
            {
                this.ToolStrip.Items.AddRange(new ToolStripItem[] {
                    buttonLoad,
                    buttonSave});
                this.ToolStrip.Items.RemoveAt(3);  // Remove the Property Pages button

                foreach (ToolStripItem im in this.ToolStrip.Items)
                    im.DisplayStyle = ToolStripItemDisplayStyle.Image;

                ToolStripProfessionalRenderer renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColorsRender())
                {
                    RoundedEdges = false
                };
                this.ToolStrip.Renderer = renderer;

                //Control con = this.PropertyGridView;
            }
        }

        private void This_Resize(object sender, EventArgs e)
        {
            SetNewImageOfBackPropertyGrid();
        }

        private void SetNewImageOfBackPropertyGrid()
        {
            Control con = this.DocComment;
            if (con.Width > 0 && con.Height > 0)
            {
                Color c1 = BackColor;
                Color c2 = Color.FromArgb(64,
                        (c1.R < 192 ? c1.R + 64 : c1.R - 192),
                        (c1.G < 192 ? c1.G + 64 : c1.G - 192),
                        (c1.B < 192 ? c1.B + 64 : c1.B - 192)
                        );

                if (RightToLeft == RightToLeft.Yes)
                {
                    Color c = c1;
                    c1 = c2;
                    c2 = c;
                }

                LinearGradientBrush gradBrush;
                gradBrush = new LinearGradientBrush(new Rectangle(0, 0, con.Width, 2),
                    c1, c2, LinearGradientMode.Horizontal);
                Bitmap bmp = new Bitmap(con.Width, 2);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.FillRectangle(gradBrush, new Rectangle(0, 0, con.Width, 2));
                    if (platformField == PlatformDetect.DotNet)
                    {
                        con.BackgroundImage = bmp;
                        con.BackgroundImageLayout = ImageLayout.Tile;
                        this.DocCommentDescription.BackColor = Color.Transparent;
                        this.DocCommentTitle.BackColor = Color.Transparent;
                    }
                    if (platformField == PlatformDetect.Mono)
                    {
                        con = DocCommentDescription;
                        con.BackgroundImage = bmp;
                        con.BackgroundImageLayout = ImageLayout.Tile;
                        con = DocCommentTitle;
                        con.BackgroundImage = bmp;
                        con.BackgroundImageLayout = ImageLayout.Tile;
                    }
                }
                gradBrush.Dispose();
            }
        }
    }

    internal class CustomProfessionalColorsRender : ProfessionalColorTable
    {
        public override Color ToolStripGradientBegin
        { get { return SystemColors.Control; } }

        public override Color ToolStripGradientMiddle
        { get { return SystemColors.ControlLight; } }

        public override Color ToolStripGradientEnd
        { get { return SystemColors.ControlDark; } }
    }
}
