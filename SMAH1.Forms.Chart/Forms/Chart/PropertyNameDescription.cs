using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Chart
{
    public struct PropertyNameDescription
    {
        public string Property { get; }
        public string Name { get; }
        public string Description { get; }
        public bool Visible { get; }
        public bool IsAttribute { get; }

        public PropertyNameDescription(
                string property,
                string name,
                string description,
                bool visible,       //Not use in isAttribute
                bool isAttribute
            )
        {
            Property = property;
            Name = name;
            Description = description;
            Visible = visible;
            IsAttribute = isAttribute;
        }
    }
}
