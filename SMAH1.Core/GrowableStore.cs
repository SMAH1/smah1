using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SMAH1
{
    public class GrowableStore<T>
    {
        public delegate byte[] ConvertorCallBack(T data);

        public int Growup { get; }
        public T FillDefault { get; }

        List<T[]> lstData = new List<T[]>();
        public int Length { get; private set; } = 0;

        int maxLength = 0;

        public GrowableStore(int growup, T fillDefault)
        {
            if (growup < 1)
                growup = 1;
            Growup = growup;
            FillDefault = fillDefault;
        }

        public void Clear()
        {
            Length = 0;
            maxLength = 0;
            lstData.Clear();
        }

        public void WriteAppend(T[] datas)
        {
            WriteOver(Length, datas, datas.Length);
        }

        public void WriteAppend(T[] datas, int len)
        {
            WriteOver(Length, datas, len);
        }

        public void WriteOver(int address, T[] datas, int len)
        {
            int i, j, group, index;
            T[] bsGroup = null;

            if (datas == null)
                throw new ArgumentNullException("datas");

            if (datas.Length < len)
                throw new ArgumentException("'len' > 'datas.Length'");

            if (len == 0)
                return;

            while (maxLength < address + len)
            {
                var bs = new T[Growup];
                for (i = 0; i < Growup; i++)
                {
                    bs[i] = FillDefault;
                }

                lstData.Add(bs);
                maxLength += Growup;
            }

            group = address / Growup;
            index = address % Growup;
            bsGroup = lstData[group];
            for (i = address, j = 0; i < address + len; i++, j++)
            {
                bsGroup[index] = datas[j];
                index++;

                if (index == Growup)
                {
                    group++;
                    index = 0;
                    if (group < lstData.Count)
                        bsGroup = lstData[group];
                }
            }

            j = address + len;
            if (Length < j)
                Length = j;
        }

        public void SaveTo(string filename, ConvertorCallBack func)
        {
            int i, j, k, n;
            T[] ar = null;

            if (func == null)
            {
                func = delegate(T data)
                {
                    return Encoding.ASCII.GetBytes(data.ToString());
                };
            }

            if (File.Exists(filename))
                File.Delete(filename);

            FileStream fs = new FileStream(filename, FileMode.CreateNew);
            BinaryWriter w = new BinaryWriter(fs);

            k = (Length / Growup) * Growup;
            for (i = 0, j = 0; i < k; i += Growup, j++)
            {
                ar = lstData[j];
                for (n = 0; n < Growup; n++)
                    w.Write(func(ar[n]));
            }

            if (i < Length)
            {
                k = Length - i;
                ar = lstData[j];
                for (n = 0; n < k; n++)
                    w.Write(func(ar[n]));
            }

            w.Close();
            fs.Close();
        }

        public int Get(int startFrom, T[] dest, int destStart, int len)
        {
            int i, j, k;

            if (dest == null)
                throw new ArgumentNullException("dest is null");
            if (dest.Length < len + destStart)
                throw new ArgumentException("dest is small");
            if (len <= 0)
                throw new ArgumentException("len is invalid");

            for (i = 0; i < len; i++)
                dest[destStart + i] = FillDefault;

            if (startFrom >= Length)
                return 0;

            T[] curData = null;
            int curIndex = -1;
            k = 0;
            for (i = 0; i < len; i++)
            {
                k = i + startFrom;
                if (k < Length)
                {
                    j = k / Growup;
                    k %= Growup;

                    if (curIndex != j)
                    {
                        curIndex = j;
                        curData = lstData[j];
                    }

                    dest[i] = curData[k];
                }
                else
                    break;
            }

            if (i == len)
                return len;
            return k - startFrom;
        }

        public T Get(int index)
        {
            if (index >= Length)
                return FillDefault;

            return lstData[index / Growup][index % Growup];
        }

        public T GetLast()
        {
            if (Length == 0)
                return FillDefault;
            return lstData[lstData.Count - 1][(Length - 1) % Growup];
        }
    }
}
