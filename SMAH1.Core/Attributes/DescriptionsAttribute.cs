using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SMAH1.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class DescriptionsAttribute : System.Attribute
    {
        protected DescriptionsAttribute(params string[] descriptions)//Warning CS3015: CLS compliant attributes and array parameters
        {
            var array = new List<string>();
            array.AddRange(descriptions);

            this.Descriptions = array.AsReadOnly();
        }

        public DescriptionsAttribute(string description1) : this(new[] { description1 }) { }
        public DescriptionsAttribute(string description1, string description2) : this(new[] { description1, description2 }) { }
        public DescriptionsAttribute(string description1, string description2, string description3) : this(new[] { description1, description2, description3 }) { }
        public DescriptionsAttribute(string description1, string description2, string description3, string description4) : this(new[] { description1, description2, description3, description4 }) { }

        public ReadOnlyCollection<string> Descriptions { get; }

        public override string ToString()
        {
            string[] collection = new string[Descriptions.Count];
            Descriptions.CopyTo(collection, 0);

            return string.Join(",", collection);
        }
    }
}
