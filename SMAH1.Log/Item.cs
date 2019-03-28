using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Log
{
    public class Item
    {
        private string name = string.Empty;
        private string val = string.Empty;

        public Item(string name, string val)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("name null or empty");

            this.name = name;
            this.val = val;
        }

        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        public string Value
        {
            get { return val; }
            set { val = value; }
        }
    }
}
