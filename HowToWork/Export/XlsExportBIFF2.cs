using System;
using System.IO;
using System.Text;

//use : http://www.codeproject.com/KB/office/biffcsharp.aspx
//SMAH1 : Add Codepage support

namespace HowToWork.Export
{
    /// <summary>
    /// Create (export) Excel file without using Excel
    /// </summary>
    public class XlsExportBIFF2
    {
        private BinaryWriter stream;
        private readonly Codepage codepage = Codepage.ASCII;

        private readonly byte[] aryStart = { 0x09, 0x08, 0x08, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x00, 0x00 };
        private readonly byte[] aryEnd = { 0x0A, 0x00, 0x00, 0x00 };
        private readonly byte[] aryInt = { 0x7E, 0x02, 0x0A, 0x00 };
        private readonly byte[] aryDouble = { 0x03, 0x02, 0x0E, 0x00 };
        private readonly byte[] aryString = { 0x04, 0x02 };
        private readonly byte[] aryEmptyStart = { 0x01, 0x02, 0x06, 0x00 };
        private readonly byte[] aryEmptyEnd = { 0x17, 0x00 };
        private readonly byte[] aryZero = { 0x00, 0x00 };

        #region Codepage

        public enum Codepage //: ushort
        {
            ASCII = 367,
            IBM_PC_CP_437_US = 437,
            IBM_PC_CP_720_OEM_Arabic = 720,
            IBM_PC_CP_737_Greek = 737,
            IBM_PC_CP_775_Baltic = 775,
            IBM_PC_CP_850_Latin_I = 850,
            IBM_PC_CP_852_Latin_II_Central_European = 852,
            IBM_PC_CP_855_Cyrillic = 855,
            IBM_PC_CP_857_Turkish = 857,
            IBM_PC_CP_858_Multilingual_Latin_I_with_Euro = 858,
            IBM_PC_CP_860_Portuguese = 860,
            IBM_PC_CP_861_Icelandic = 861,
            IBM_PC_CP_862_Hebrew = 862,
            IBM_PC_CP_863_Canadian_French = 863,
            IBM_PC_CP_864_Arabic = 864,
            IBM_PC_CP_865_Nordic = 865,
            IBM_PC_CP_866_Cyrillic_Russian = 866,
            IBM_PC_CP_869_Greek_Modern = 869,
            Windows_CP_874_Thai = 874,
            Windows_CP_932_Japanese_Shift_JIS = 932,
            Windows_CP_936_Chinese_Simplified_GBK = 936,
            Windows_CP_949_Korean_Wansung = 949,
            Windows_CP_950_Chinese_Traditional_BIG5 = 950,
            Windows_CP_1250_Latin_II_Central_European = 1250,
            Windows_CP_1251_Cyrillic = 1251,
            Windows_CP_1252_Latin_I = 1252,
            Windows_CP_1253_Greek = 1253,
            Windows_CP_1254_Turkish = 1254,
            Windows_CP_1255_Hebrew = 1255,
            Windows_CP_1256_Arabic = 1256,
            Windows_CP_1257_Baltic = 1257,
            Windows_CP_1258_Vietnamese = 1258,
            Windows_CP_1361_Korean_Johab = 1361
            //UTF16 = 1200 Not support in BIFF2
        }

        private int WriteCodePage()
        {
            if (codepage != Codepage.ASCII)
            {
                stream.Write(new byte[] { 0x42, 0x00 });
                stream.Write(new byte[] { 0x02, 0x00 });
                stream.Write((ushort)codepage);

                return 6;
            }
            return 0;
        }
        #endregion

        /// <summary>
        /// Constructor of class from stream
        /// </summary>
        /// <param name="stream">Stream that send data whom</param>
        public XlsExportBIFF2(Stream stream) : this(stream, Codepage.ASCII) { }

        /// <summary>
        /// Constructor of class from stream
        /// </summary>
        /// <param name="stream">Stream that send data whom</param>
        /// <param name="stream">Codepage for save string</param>
        public XlsExportBIFF2(Stream stream, Codepage codepage)
        {
            if (stream == null)
                throw new ArgumentNullException("'stream' is null!");
            this.stream = new BinaryWriter(stream);
            this.codepage = codepage;
        }

        /// <summary>
        /// Send header bytes of excel file
        /// </summary>
        public void WriteBegin()
        {
            stream.Write(aryStart);
            WriteCodePage();
        }

        /// <summary>
        /// Send final bytes of excel file
        /// </summary>
        public void WriteEnd()
        {
            stream.Write(aryEnd);
            stream.Flush();
        }

        /// <summary>
        /// Write int value in cell
        /// </summary>
        /// <param name="row">Row number of cell</param>
        /// <param name="col">Column number of cell</param>
        /// <param name="value">Value for write to cell</param>
        public void WriteCell(int row, int col, int value)
        {
            stream.Write(aryInt);
            stream.Write((ushort)row);
            stream.Write((ushort)col);
            stream.Write(aryZero);
            value = ((value << 2) | 2);
            stream.Write(value);
        }

        /// <summary>
        /// Write double value in cell
        /// </summary>
        /// <param name="row">Row number of cell</param>
        /// <param name="col">Column number of cell</param>
        /// <param name="value">Value for write to cell</param>
        public void WriteCell(int row, int col, double value)
        {
            stream.Write(aryDouble);
            stream.Write((ushort)row);
            stream.Write((ushort)col);
            stream.Write(aryZero);
            stream.Write(value);
        }

        /// <summary>
        /// Write empty cell
        /// </summary>
        /// <param name="row">Row number of cell</param>
        /// <param name="col">Column number of cell</param>
        public void WriteCell(int row, int col)
        {
            stream.Write(aryEmptyStart);
            stream.Write((ushort)row);
            stream.Write((ushort)col);
            stream.Write(aryEmptyEnd);
        }

        /// <summary>
        /// Write string in cell
        /// </summary>
        /// <param name="row">Row number of cell</param>
        /// <param name="col">Column number of cell</param>
        /// <param name="value">String for write to cell</param>
        public void WriteCell(int row, int col, string value)
        {
            Encoding cp = Encoding.ASCII;
            if (codepage != Codepage.ASCII)
                cp = Encoding.GetEncoding((int)(ushort)codepage);
            byte[] plainText = cp.GetBytes(value);

            stream.Write(aryString);
            stream.Write((ushort)(plainText.Length + 8));
            stream.Write((ushort)row);
            stream.Write((ushort)col);
            stream.Write(aryZero);
            stream.Write((ushort)plainText.Length);
            stream.Write(plainText);
        }
    }
}
