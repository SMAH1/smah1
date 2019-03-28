using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SMAH1.Forms.Loading
{
    public interface ILoadingComponent
    {
        LoadingCtrl Parent { get; set; }
        void Initialize();
        void Start();
        void Stop();
        void StateChange(LoadingStateChange state);
        void Tick();
        void Paint(Graphics gr);
    }
}
