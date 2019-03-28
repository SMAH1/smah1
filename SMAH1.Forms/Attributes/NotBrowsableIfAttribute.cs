using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SMAH1.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NotBrowsableIfAttribute : System.Attribute
    {
        public ReadOnlyCollection<string> Properties { get; }
        public ReadOnlyCollection<object> Values { get; }

        protected NotBrowsableIfAttribute(string[] properties, object[] values)//Warning CS3015: CLS compliant attributes and array parameters
        {
            //Properties
            var arrayProperties = new List<string>();
            arrayProperties.AddRange(properties);

            this.Properties = arrayProperties.AsReadOnly();

            //Values
            var arrayValues = new List<object>();
            arrayValues.AddRange(values);

            while (arrayValues.Count < arrayProperties.Count)
                arrayValues.Add(null);

            while (arrayValues.Count > arrayProperties.Count)
                arrayValues.RemoveAt(arrayProperties.Count);

            this.Values = arrayValues.AsReadOnly();
        }

        public NotBrowsableIfAttribute(string prop1, object value1) : this(new[] { prop1 }, new[] { value1 }) { }
        public NotBrowsableIfAttribute(string prop1, string prop2, object value1, object value2) : this(new[] { prop1, prop2 }, new[] { value1, value2 }) { }
        public NotBrowsableIfAttribute(string prop1, string prop2, string prop3, object value1, object value2, object value3) : this(new[] { prop1, prop2, prop3 }, new[] { value1, value2, value3 }) { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Properties.Count > 0)
            {
                string[] collectionProperties = new string[Properties.Count];
                Properties.CopyTo(collectionProperties, 0);

                sb.Append(string.Join(", ", collectionProperties));
            }
            sb.Append(" : ");
            if (Values.Count > 0)
            {
                foreach (object o in Values)
                    if (o == null)
                        sb.Append(", null");
                    else
                        sb.Append(", " + o);
            }
            return sb.ToString();
        }
    }
}
