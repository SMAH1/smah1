using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace SMAH1.Forms.Loading
{
    [DesignerCategory("SMAH1")]
    [ToolboxItem(true)]
    [DesignTimeVisible(true)]
    public abstract class BaseLoadingComponent : System.ComponentModel.Component, ILoadingComponent
    {
        private LoadingCtrl parent;

        public BaseLoadingComponent()
        {
            parent = null;
        }

        [Browsable(false)]
        [DefaultValue(null)]
        public LoadingCtrl Parent
        {
            get { return parent; }
            set
            {
                if (parent != value)
                {
                    if (parent != null)
                        parent.Component = null;
                    parent = value;
                    if (parent != null)
                        parent.Component = this;
                }
            }
        }

        #region ILoadingComponent Members
        public virtual void Initialize() { }
        public virtual void Start() { }
        public virtual void Stop() { }
        public virtual void StateChange(LoadingStateChange state) { }
        public virtual void Tick() { }
        public virtual void Paint(Graphics gr) { }
        #endregion
    }
}
