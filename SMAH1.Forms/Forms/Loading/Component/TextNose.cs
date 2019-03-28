using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace SMAH1.Forms.Loading.Component
{
    [DesignerCategory("SMAH1")]
    [ToolboxItem(true)]
    [DesignTimeVisible(true)]
    public class LTextNose : BaseLoadingComponent
    {
        protected int objCurHeight = 0;
        protected int objStep = 3;
        protected int objCurStep = 3;
        protected SizeF objTextSize;
        protected PointF objDrawText;
        protected GraphicsPath objGpText;

        protected bool objValid = false;

        public LTextNose()
        {
            objCurHeight = objStep = 3;
            objValid = false;
        }

        protected void Invalid()
        {
            objValid = false;
        }

        [Category("Custom")]
        public int Step
        {
            get { return objStep; }
            set
            {
                if (value > 0)
                {
                    objCurStep = objStep = value;
                    objCurHeight = objStep;
                }
                Invalid();
            }
        }

        private void Redraw()
        {
            if (Parent != null)
                Parent.Refresh();
        }

        #region ILoadingComponent Members

        public override void StateChange(LoadingStateChange state)
        {
            CreateObjects();
        }

        public override void Tick()
        {
            objCurHeight += objCurStep;
            if (objCurHeight >= objTextSize.Height || objCurHeight <= 0)
            {
                objCurStep *= -1;
                objCurHeight += objCurStep;
            }
            Redraw();
        }

        public override void Paint(Graphics gr)
        {
            if (Parent == null)
                return;

            if (!objValid)
                CreateObjects();

            if (objValid)
            {
                Brush brBack = new SolidBrush(Parent.BackColor);
                gr.FillRectangle(brBack, Parent.ClientRectangle);
                brBack.Dispose();

                LinearGradientBrush gradBrush = new LinearGradientBrush(
                    new Rectangle(0, 0, 60, objCurHeight),
                    Parent.ForeColor, Parent.BackColor,
                    LinearGradientMode.Vertical);
                gr.TranslateTransform(objDrawText.X, objDrawText.Y);
                gr.FillPath(gradBrush, objGpText);
                gr.TranslateTransform(-objDrawText.X, -objDrawText.Y);
                gradBrush.Dispose();
            }
        }
        #endregion

        private void CreateObjects()
        {
            if (Parent == null)
                return;

            if (Parent.ClientRectangle.Width < 2 ||
                Parent.ClientRectangle.Height < 2)
                return;

            Font font = Parent.Font;

            Graphics gr = Parent.CreateGraphics();
            objTextSize = gr.MeasureString(Parent.Text, font);
            objGpText = new GraphicsPath();
            float emSize = gr.DpiY * font.Size / 72;
            objGpText.AddString(
                Parent.Text,
                font.FontFamily,
                (int)font.Style,
                emSize,
                new Point(0, 0),
                StringFormat.GenericDefault);
            gr.Dispose();

            objDrawText = new PointF(
                (Parent.ClientRectangle.Width - objTextSize.Width) / 2,
                (Parent.ClientRectangle.Height - objTextSize.Height) / 2
                );
            objValid = true;
        }
    }
}
