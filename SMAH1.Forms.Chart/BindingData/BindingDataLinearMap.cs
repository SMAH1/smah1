using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SMAH1.BindingData
{
    public class BindingDataLinearMap : BindingDataBase
    {
        private IBindingData data = null;
        private double scale;
        private double offset;

        internal protected IBindingData Data { get { return data; } }
        internal protected double Scale { get { return scale; } set { scale = value; } }
        internal protected double Offset { get { return offset; } set { offset = value; } }

        internal protected BindingDataLinearMap(IBindingData bindData)
            : this(bindData, 1, 0)
        { }

        internal protected BindingDataLinearMap(IBindingData bindData,
                double scale, double offset
                )
        {
            data = bindData;
            this.scale = scale;
            this.offset = offset;
            Name = data.Name;
        }

        public double Map(double d)
        {
            d *= scale;
            d += offset;
            return d;
        }

        public double InverseMap(double d)
        {
            if (scale == 0)
                throw new Exception("Scale is Zero!");

            return (d - offset) / scale;
        }

        #region BindingDataBase Members
        public override int ColumnCount { get { return data.ColumnCount; } }
        public override int RowCount { get { return data.RowCount; } }
        public override string ColumnName(int index) { return data.ColumnName(index); }
        public override object ValueObject(int indexRow, int indexColumn) { return data.ValueObject(indexRow, indexColumn); }
        public override bool Valid(int indexRow, int indexColumn) { return data.Valid(indexRow, indexColumn); }

        public override double ValueDouble(int indexRow, int indexColumn)
        {
            double d = base.ValueDouble(indexRow, indexColumn);
            return Map(d);
        }
        #endregion
    }
}
