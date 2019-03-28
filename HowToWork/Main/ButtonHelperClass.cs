using System;
using System.Collections.Generic;
using System.Text;

namespace HowToWork
{
    public class ButtonHelperClass
    {
        public string ButtonName;
        public string ButtonText;
        public string ClassName;
        public EventHandler Click;

        public ButtonHelperClass(string buttonName, string buttonText, string className)
        {
            ButtonName = buttonName;
            ButtonText = buttonText;
            ClassName = className;
            Click = null;
        }

        public ButtonHelperClass(string buttonName, string buttonText, EventHandler buttonEvent)
        {
            ButtonName = buttonName;
            ButtonText = buttonText;
            ClassName = string.Empty;
            Click = buttonEvent;
        }
    }
}
