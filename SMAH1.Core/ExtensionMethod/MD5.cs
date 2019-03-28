using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SMAH1.ExtensionMethod
{
    public static class MD5ExtensionMethod
    {
        public static string MD5(this string data)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = Encoding.UTF8.GetBytes(data);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes).Replace("-", "").ToLower();
        }
    }
}
