using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

/*
 * in this develop use article and code of:
 *      CodeProject : Add Custom Properties to a PropertyGrid
 *      Address : http://www.codeproject.com/KB/vb/PropertyGridEx.aspx
 *      Author : Danilo Corallo
 */

namespace SMAH1.Forms.PropertyGridEx
{
    public class PropertyGridMinEx : PropertyGrid
    {
        public enum PlatformDetect
        {
            None = 0,
            DotNet = 1,
            Mono = 2
        }

        #region Field

        // Internal PropertyGrid Controls
        protected Control oPropertyGridView;
        protected Control oDocComment;
        protected ToolStrip oToolStrip;

        // Internal PropertyGrid Fields
        protected Label lblDocCommentTitle;
        protected Label lblDocCommentDescription;

        protected readonly PlatformDetect platformField;
        protected readonly bool isExtendedField;
        #endregion

        public PropertyGridMinEx()
            : this(true)
        {
        }

        public PropertyGridMinEx(bool extended)
            : base()
        {
            if (extended)
            {
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);

                Type typePG = typeof(PropertyGrid);
                try
                {//For .NET
                    // Attach internal controls
                    oPropertyGridView = (Control)typePG.InvokeMember("gridView", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance, null, this, null);
                    oToolStrip = (ToolStrip)typePG.InvokeMember("toolStrip", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance, null, this, null);
                    oDocComment = (Control)typePG.InvokeMember("doccomment", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance, null, this, null);

                    // Attach DocComment internal fields
                    if (oDocComment != null)
                    {
                        lblDocCommentTitle = (Label)oDocComment.GetType().InvokeMember("m_labelTitle", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance, null, oDocComment, null);
                        lblDocCommentDescription = (Label)oDocComment.GetType().InvokeMember("m_labelDesc", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance, null, oDocComment, null);
                    }
                    platformField = PlatformDetect.DotNet;
                    if (oPropertyGridView == null
                                || oToolStrip == null || oDocComment == null)
                        isExtendedField = false;
                    else
                        isExtendedField = true;
                }
                catch
                {
                    try
                    {//For Mono
                        BindingFlags bf = BindingFlags.NonPublic |
                                            BindingFlags.GetField |
                                            BindingFlags.Instance;
                        oPropertyGridView = (Control)typePG.InvokeMember(
                            "property_grid_view", bf, null, this, null);
                        oToolStrip = (ToolStrip)typePG.InvokeMember(
                            "toolbar", bf, null, this, null);
                        oDocComment = (Control)typePG.InvokeMember(
                            "help_panel", bf, null, this, null);
                        lblDocCommentTitle = (Label)typePG.InvokeMember(
                            "help_title_label", bf, null, this, null);
                        lblDocCommentDescription = (Label)typePG.InvokeMember(
                            "help_description_label", bf, null, this, null);
                        platformField = PlatformDetect.Mono;
                        if (oPropertyGridView == null
                                    || oToolStrip == null || oDocComment == null
                                    || lblDocCommentTitle == null
                                    || lblDocCommentDescription == null)
                            isExtendedField = false;
                        else
                            isExtendedField = true;
                    }
                    catch
                    {//Can not create
                        oDocComment = oPropertyGridView = null;
                        lblDocCommentTitle = lblDocCommentDescription = null;
                        oToolStrip = null;
                        isExtendedField = false;
                    }
                }
            }
            else
            {
                platformField = PlatformDetect.None;
                isExtendedField = false;
            }
        }

        #region Property
        [Browsable(false)]
        public PlatformDetect Platform
        {
            get { return platformField; }
        }

        [Browsable(false)]
        public virtual bool IsExtended
        {
            get { return isExtendedField; }
        }

        [Browsable(false)]
        public Control PropertyGridView
        {
            get { return oPropertyGridView; }
        }

        [
            Category("Appearance"),
            DisplayName("Toolstrip"),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
            DescriptionAttribute("Toolbar object"),
            Browsable(true)
        ]
        public ToolStrip ToolStrip
        {
            get
            {
                return oToolStrip;
            }
        }

        [
            Category("Appearance"),
            DisplayName("Help"),
            DescriptionAttribute("DocComment object. Represent the comments area of the PropertyGrid."),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
            Browsable(false)
        ]
        public Control DocComment
        {
            get
            {
                return (Control)oDocComment;
            }
        }

        [
            Category("Appearance"),
            DisplayName("HelpTitle"),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
            DescriptionAttribute("Help Title Label."),
            Browsable(true)
        ]
        public Label DocCommentTitle
        {
            get
            {
                return lblDocCommentTitle;
            }
        }

        [
            Category("Appearance"),
            DisplayName("HelpDescription"),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
            DescriptionAttribute("Help Description Label."),
            Browsable(true)
        ]
        public Label DocCommentDescription
        {
            get
            {
                return lblDocCommentDescription;
            }
        }

        [
            Category("Appearance"),
            DescriptionAttribute("Help Image Background.")
        ]
        public Image DocCommentImage
        {
            get
            {
                return oDocComment.BackgroundImage;
            }
            set
            {
                oDocComment.BackgroundImage = value;
            }
        }
        #endregion

        #region ToolStripRenderMode
        public ToolStripRenderer ToolStripRendererEx
        {
            get { return (isExtendedField ? oToolStrip.Renderer : null); }
            set
            {
                if (isExtendedField)
                    oToolStrip.Renderer = value;
            }
        }

        public void SetFlatToolbar()
        {
            ToolStripRendererEx = new ToolStripSystemRenderer();
        }
        #endregion
    }
}
