using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SaveLoadAttribute : System.Attribute
    {
        public string Name { get; } = "";

        public SaveLoadAttribute()
            : this("")
        {
        }

        public SaveLoadAttribute(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
