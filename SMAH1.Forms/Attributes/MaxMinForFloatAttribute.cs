using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxMinForFloatAttribute : System.Attribute
    {
        public float Max { get; } = 0;
        public float Min { get; } = 0;
        public int DecimalPlaces { get; } = 0;
        public float Increment { get; } = 0;

        public MaxMinForFloatAttribute(
            float min, float max, int decimalPlaces, float increment)
        {
            Max = max;
            Min = min;
            DecimalPlaces = decimalPlaces;
            Increment = increment;
        }
    }
}
