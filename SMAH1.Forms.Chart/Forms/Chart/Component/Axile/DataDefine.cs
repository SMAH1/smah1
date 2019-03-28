using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Chart.Component.Axile
{
    public class DataDefine
    {
        private BindingData.BindingDataLinearMap dataMember = null;
        private float fVerticalScale;   //Use when sizingModeValue = Auto
        private float fVerticalMax;     //Use when sizingModeValue = Fix
        private float fVerticalMin;     //Use when sizingModeValue = Fix

        public DataDefine(SMAH1.BindingData.IBindingData dataMember)
        {
            if (dataMember == null)
                throw new ArgumentNullException("'dataMember' is null");

            this.dataMember = SMAH1.BindingData.Bind.FromBindingDataLinearMap(dataMember);
            MaxInTopOfChart = MinInBottomOfChart = 0;
            PerfixValue = string.Empty;
            PostfixValue = string.Empty;
            PerfixLabel = string.Empty;
            PostfixLabel = string.Empty;
            SizingModeValue = SizingModeValue.Auto;
            fVerticalScale = 1.05F;
            fVerticalMax = 1F;
            fVerticalMin = 0F;
        }

        public BindingData.BindingDataLinearMap DataMember
        {
            get { return dataMember; }
            internal set
            {
                dataMember = value ?? throw new ArgumentNullException("'value' is null");
            }
        }

        internal double MaxInTopOfChart { get; set; }
        internal double MinInBottomOfChart { get; set; }

        public string PerfixValue { get; set; }
        public string PostfixValue { get; set; }
        public string PerfixLabel { get; set; }
        public string PostfixLabel { get; set; }

        public SizingModeValue SizingModeValue { get; set; }
        public float VerticalScale
        {
            get { return fVerticalScale; }
            set
            {
                if (value < 1F)
                    fVerticalScale = 1F;
                else if (value > 10F)
                    fVerticalScale = 10F;
                else
                    fVerticalScale = value;
            }
        }
        public float ValueMax
        {
            get { return fVerticalMax; }
            set
            {
                if (value > fVerticalMin && value >= 0)
                    fVerticalMax = value;
                else
                {
                    fVerticalMax = fVerticalMin + 1;
                }
            }
        }
        public float ValueMin
        {
            get { return fVerticalMin; }
            set
            {
                if (value < fVerticalMax && value <= 0)
                    fVerticalMin = value;
                else
                {
                    fVerticalMin = fVerticalMax - 1;
                }
            }
        }
    }
}
