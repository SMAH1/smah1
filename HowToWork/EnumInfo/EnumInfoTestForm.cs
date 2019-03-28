using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HowToWork.EnumInfo
{
    public class MyEnumInfo : SMAH1.EnumInfoBase<WeekDay>
    {
        protected MyEnumInfo() { }
    }
    public class MyEnumInfo2 : SMAH1.EnumInfoBase<WeekDay2>
    {
        protected MyEnumInfo2() { }
    }

    public partial class EnumInfoTestForm : Form
    {
        public EnumInfoTestForm()
        {
            InitializeComponent();

            this.Font = new Font("Consolas", 11F);
        }

        private void EnumInfoTestForm_Load(object sender, EventArgs e)
        {
            WeekDay p1 = WeekDay.Sat;
            WeekDay p2 = WeekDay.Sat | WeekDay.Mon;
            Type type = typeof(WeekDay);

            AddText("-------- WeekDay2 ------------");

            AddText(p1.ToString());
            AddText(p2.ToString());
            AddText(typeof(WeekDay).ToString());

            AddText("Name : ");
            string[] feilds = Enum.GetNames(type);
            foreach (string s in feilds)
                AddText("   " + s);

            AddText("Value : ");
            Array a = Enum.GetValues(type);
            foreach (object o in a)
            {
                WeekDay i = (WeekDay)o;
                AddText("   " + i + " : " + i.GetType());
            }

            Type lstType = typeof(List<>).MakeGenericType(type);
            IList lst = (IList)Activator.CreateInstance(lstType);
            foreach (object o in a)
                lst.Add(o);
            AddText("" + lst.GetType() + " : " + lst.Count);

            //MyEnumInfo
            AddText("-------- WeekDay ------------");
            AddText("WeekDay : ");
            foreach (WeekDay ip in MyEnumInfo.GetFields())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ip.ToString().PadRight(5));
                while (sb.Length < 8) sb.Append(" ");
                for (int i = 0; i < MyEnumInfo.CountDescription; i++)
                {
                    sb.Append(MyEnumInfo.GetFieldDescription(ip, i));
                    while (sb.Length < 8 + 12 + 12 * i) sb.Append(" ");
                }
                AddText(sb.ToString());
            }


            AddText("-------- WeekDay (use flag to description) ------------");
            var descs = MyEnumInfo.GetFieldDescriptions(p2, 0);
            string[] array = new string[descs.Count];
            descs.CopyTo(array, 0);
            AddText("" + p2 + " => " + string.Join(" & ", array));

            //-----------------------------------
            AddText("-------- WeekDay2 ------------");
            //-----------------------------------
            WeekDay2 p3 = WeekDay2.Sat;
            Type type2 = p3.GetType();

            AddText("Name : ");
            string[] feild2s = Enum.GetNames(type2);
            foreach (string s in feild2s)
                AddText("   " + s);

            AddText("Value : ");
            Array a2 = Enum.GetValues(type2);
            foreach (object o in a2)
            {
                WeekDay2 i = (WeekDay2)o;
                AddText("   " + i + " : " + i.GetType());
            }

            //MyEnumInfo
            AddText("-------- WeekDay2 ------------");
            AddText("WeekDay2 : ");
            foreach (WeekDay2 ip in MyEnumInfo2.GetFields())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ip.ToString().PadRight(5));
                sb.Append("\t");
                for (int i = 0; i < MyEnumInfo2.CountDescription; i++)
                {
                    sb.Append(MyEnumInfo2.GetFieldDescription(ip, i));
                    sb.Append("\t");
                }
                AddText(sb.ToString());
            }


            txtInfo.SelectionStart = 0;
        }

        private void AddText(string text)
        {
            txtInfo.Text += text + Environment.NewLine;
        }
    }
}
