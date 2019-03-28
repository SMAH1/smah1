
using System;
using System.Collections.Generic;
using System.Web;
using System.Text;

namespace SMAH1
{
    public enum CreateWhereJoin
    {
        AND,
        OR
    }

    public class CreateWhere
    {
        private List<string> list;
        string perfix = "[";
        string postfix = "]";

        public CreateWhere()
        {
            list = new List<string>();
        }

        public override string ToString()
        {
            return ToString(CreateWhereJoin.AND);
        }

        public string ToString(CreateWhereJoin joinOption)
        {
            string joinString = "";
            switch (joinOption)
            {
                case CreateWhereJoin.AND:
                    joinString = " AND ";
                    break;
                case CreateWhereJoin.OR:
                    joinString = " OR ";
                    break;
            }

            return String.Join(joinString, list.ToArray());
        }

        public bool AddCrosh
        {
            get
            {
                if (perfix == "[")
                    return true;
                return false;
            }

            set
            {
                if (value)
                {
                    perfix = "[";
                    postfix = "]";
                }
                else
                {
                    perfix = "";
                    postfix = "";
                }
            }
        }

        public void AddWhere(string strWhere)
        {
            if (string.IsNullOrEmpty(strWhere))
                return;

            list.Add("(" + strWhere + ")");
        }

        public void AddStringEqual(string value, string fld)
        {
            if (string.IsNullOrEmpty(value))
                return;

            list.Add(perfix + fld + postfix + " LIKE '" + value + "'");
        }

        public void AddStringBegin(string value, string fld)
        {
            if (string.IsNullOrEmpty(value))
                return;

            list.Add(perfix + fld + postfix + " LIKE '" + value + "%'");
        }

        public void AddStringEnd(string value, string fld)
        {
            if (string.IsNullOrEmpty(value))
                return;

            list.Add(perfix + fld + postfix + " LIKE '%" + value + "'");
        }

        public void AddSubStringEqual(string value, string fld)
        {
            if (string.IsNullOrEmpty(value))
                return;

            list.Add(perfix + fld + postfix + " LIKE '%" + value + "%'");
        }

        public void AddStringEqualOrLessThan(string value, string fld)
        {
            list.Add(perfix + fld + postfix + " <= '" + value + "'");
        }

        public void AddStringEqualOrGreatThan(string value, string fld)
        {
            list.Add(perfix + fld + postfix + " >= '" + value + "'");
        }

        public void AddStringOnlyLessThan(string value, string fld)
        {
            list.Add(perfix + fld + postfix + " < '" + value + "'");
        }

        public void AddStringOnlyGreatThan(string value, string fld)
        {
            list.Add(perfix + fld + postfix + " > '" + value + "'");
        }

        public void AddNumberEqual(long value, string fld)
        {
            list.Add(perfix + fld + postfix + " = " + value);
        }

        public void AddNumberEqualOrLessThan(long value, string fld)
        {
            list.Add(perfix + fld + postfix + " <= " + value);
        }

        public void AddNumberEqualOrGreatThan(long value, string fld)
        {
            list.Add(perfix + fld + postfix + " >= " + value);
        }

        public void AddNumberOnlyLessThan(long value, string fld)
        {
            list.Add(perfix + fld + postfix + " < " + value);
        }

        public void AddNumberOnlyGreatThan(long value, string fld)
        {
            list.Add(perfix + fld + postfix + " > " + value);
        }

        public void AddNumberRangeWithEqual(long value1, long value2, string fld)
        {
            list.Add(perfix + fld + postfix + " >= " + value1);
            list.Add(perfix + fld + postfix + " <= " + value2);
        }

        public void AddNumberRangeWithoutEqual(long value1, long value2, string fld)
        {
            list.Add(perfix + fld + postfix + " > " + value1);
            list.Add(perfix + fld + postfix + " < " + value2);
        }

        public void AddBoolEqual(bool value, string fld)
        {
            list.Add(perfix + fld + postfix + " = " + value);
        }

        public void AddStringRangeWithEqual(string value1, string value2, string fld)
        {
            if (string.IsNullOrEmpty(value1) && string.IsNullOrEmpty(value2))
                return;

            if (!string.IsNullOrEmpty(value1))
            {
                list.Add(perfix + fld + postfix + " >= '" + value1 + "'");
            }

            if (!string.IsNullOrEmpty(value2))
            {
                list.Add(perfix + fld + postfix + " <= '" + value2 + "'");
            }
        }

        public void AddStringRangeWithoutEqual(string value1, string value2, string fld)
        {
            if (string.IsNullOrEmpty(value1) && string.IsNullOrEmpty(value2))
                return;

            if (!string.IsNullOrEmpty(value1))
            {
                list.Add(perfix + fld + postfix + " > '" + value1 + "'");
            }

            if (!string.IsNullOrEmpty(value2))
            {
                list.Add(perfix + fld + postfix + " < '" + value2 + "'");
            }
        }
    }
}
