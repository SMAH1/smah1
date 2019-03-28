using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SMAH1.Serialize
{
    public static class FontSerialize
    {
        public static string SerializeFont(Font font)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, font);
                    return Convert.ToBase64String(stream.ToArray());
                }
            }
            catch { }
            return null;
        }
        public static Font DeserializeFont(string font)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(font)))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (Font)formatter.Deserialize(stream);
                }
            }
            catch { }
            return null;
        }
    }
}
