using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxMinForIntAttribute : System.Attribute
    {
        public int Max { get; } = 0;
        public int Min { get; } = 0;

        public MaxMinForIntAttribute(int min, int max)
        {
            Max = max;
            Min = min;
        }
    }
}
