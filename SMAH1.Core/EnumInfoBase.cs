using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using SMAH1.Attributes;
using System.Collections.ObjectModel;

namespace SMAH1
{
    internal static class EnumInfoBaseStatic
    {
        internal static object lockObject = new object();
    }

    //Don't static this class!
    public abstract class EnumInfoBase<T>
    {
        public EnumInfoBase() { }

        private static IList enumField = null;
        private static List<List<string>> enumDesc = null;

        private static void Create()
        {
            lock (EnumInfoBaseStatic.lockObject)
            {
                if (enumField != null)
                    return;

                Type enumType = typeof(T);

                if (!enumType.IsEnum)
                    throw new ArgumentException("must be Enumration!");

                int i;
                CountDescription = 0;
                int currentField = 0;

                Type lstType = typeof(List<>).MakeGenericType(enumType);
                enumField = (IList)Activator.CreateInstance(lstType);
                Array ae = Enum.GetValues(enumType);
                foreach (object o in ae)
                    enumField.Add(o);

                CountDescription = 0;
                enumDesc = new List<List<string>>();

                //Only use when resize enumDesc for fill older feild
                List<string> lstDescField = new List<string>(0);

                currentField = -1;
                foreach (object o in ae)
                {
                    currentField++;
                    FieldInfo field = enumType.GetField(o.ToString());

                    bool bAdd = false;

                    //Add to lstlst
                    DescriptionsAttribute descriptions = (DescriptionsAttribute)System.Attribute.GetCustomAttribute(field, typeof(DescriptionsAttribute), false);
                    if (descriptions != null)
                    {
                        if (descriptions.Descriptions.Count > CountDescription)
                        {
                            for (i = CountDescription; i < descriptions.Descriptions.Count; i++)
                            {
                                List<string> al = new List<string>();
                                for (int j = 0; j < currentField; j++)
                                    al.Add(lstDescField[j]);
                                enumDesc.Add(al);
                            }
                            CountDescription = descriptions.Descriptions.Count;
                        }
                        if (descriptions.Descriptions.Count != 0)
                        {
                            bAdd = true;
                            for (i = 0; i < CountDescription; i++)
                            {
                                if (i < descriptions.Descriptions.Count)
                                    enumDesc[i].Add(descriptions.Descriptions[i]);
                                else
                                    enumDesc[i].Add(descriptions.Descriptions[descriptions.Descriptions.Count - 1]);
                            }
                            lstDescField.Add(
                                descriptions.Descriptions[descriptions.Descriptions.Count - 1]
                                );
                        }
                    }

                    if (!bAdd)
                    {
                        //Add to lstDescField
                        DescriptionAttribute description = (DescriptionAttribute)System.Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute), false);
                        if (description != null)
                        {
                            lstDescField.Add(description.Description);
                        }
                        else
                        {
                            lstDescField.Add(o.ToString());
                        }

                        string s = lstDescField[currentField];
                        for (i = 0; i < CountDescription; i++)
                            enumDesc[i].Add(s);
                    }
                }

                if (CountDescription == 0)
                {
                    //Default Value
                    CountDescription = 1;
                    List<string> al = new List<string>();
                    enumDesc.Add(al);

                    currentField = -1;
                    foreach (object o in ae)
                    {
                        currentField++;
                        FieldInfo field = enumType.GetField(o.ToString());
                        DescriptionAttribute description = (DescriptionAttribute)System.Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute), false);
                        if (description != null)
                        {
                            lstDescField.Add(description.Description);
                        }
                        else
                        {
                            lstDescField.Add(o.ToString());
                        }

                        string s = lstDescField[currentField];
                        for (i = 0; i < CountDescription; i++)
                            enumDesc[i].Add(s);
                    }
                }
            }
        }

        /// <summary>
        /// Count of description for each field
        /// </summary>
        public static int CountDescription { get; private set; }

        /// <summary>
        /// Get list of field 
        /// </summary>
        /// <returns></returns>
        public static ReadOnlyCollection<T> GetFields()
        {
            Create();
            return ((List<T>)enumField).AsReadOnly();
        }

        /// <summary>
        /// Get description of given index for all fields
        /// </summary>
        /// <param name="i">Description Index (Zero base)</param>
        /// <returns></returns>
        public static ReadOnlyCollection<string> GetFieldsDescription(int i)
        {
            Create();
            if (i >= enumDesc.Count)
                i = enumDesc.Count - 1;
            return enumDesc[i].AsReadOnly();
        }

        /// <summary>
        /// Get description of given index for field
        /// </summary>
        /// <param name="value">field</param>
        /// <param name="i">Description Index (Zero base)</param>
        /// <returns></returns>
        public static string GetFieldDescription(T value, int i)
        {
            Create();
            if (i >= enumDesc.Count)
                i = enumDesc.Count - 1;
            int j = enumField.IndexOf(value);
            return enumDesc[i][j];
        }

        /// <summary>
        /// Get description of given index for field.If enum is flag, return list of all combined field.
        /// </summary>
        /// <param name="value">field</param>
        /// <param name="i">Description Index (Zero base)</param>
        /// <returns></returns>
        public static ReadOnlyCollection<string> GetFieldDescriptions(T value, int i)
        {
            Create();
            if (i >= enumDesc.Count)
                i = enumDesc.Count - 1;

            List<string> ret = new List<string>();

            bool isFlag = false;
            FlagsAttribute[] attFlag =
                (FlagsAttribute[])value.GetType().GetCustomAttributes(
                typeof(FlagsAttribute),
                false);
            if (attFlag != null && attFlag.Length > 0)
                isFlag = true;

            if (isFlag)
            {
                var n = System.Convert.ToUInt64(value);
                foreach (var a in enumField)
                {
                    var m = System.Convert.ToUInt64(a);
                    if ((m & n) > 0)
                    {
                        int j = enumField.IndexOf(a);
                        ret.Add(enumDesc[i][j]);
                    }
                }
            }
            else
            {
                int j = enumField.IndexOf(value);
                ret.Add(enumDesc[i][j]);
            }

            return ret.AsReadOnly();
        }
    }
}
