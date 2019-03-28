using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Log
{
    public class Items : List<Item>
    {
        public void Add(string name, string value)
        {
            Add(new Item(name, value));
        }

        public bool Contains(string name)
        {
            foreach (Item item in this)
                if (string.Compare(item.Name, name) == 0)
                    return true;
            return false;
        }

        public string this[string name]
        {
            get
            {
                foreach (Item item in this)
                    if (string.Compare(item.Name, name) == 0)
                        return item.Value;

                throw new Exception("Not found");
            }
            set
            {
                foreach (Item item in this)
                    if (string.Compare(item.Name, name) == 0)
                    {
                        item.Value = value;
                        return;
                    }

                Add(name, value);
            }
        }
    }
}
