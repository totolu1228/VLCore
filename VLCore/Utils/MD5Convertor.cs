using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace VLCore.Utils
{
    /// <summary>
    /// md5 convertor
    /// </summary>
    public static class MD5Convertor
    {
        /// <summary>
        /// encrypt hex md5
        /// </summary>
        public static string EncryptHexMD5(string str)
        {
            return BitConverter.ToString(EncryptMD5(str)).Replace("-", "").Replace(" ", "").Trim();
        }

        /// <summary>
        /// encrypt md5
        /// </summary>
        public static byte[] EncryptMD5(string str)
        {
            MD5 md = new MD5CryptoServiceProvider();
            str = BitConverter.ToString(md.ComputeHash(Encoding.Default.GetBytes(str))).Replace("-", "");
            byte[] bytes = new byte[str.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(str.Substring(i * 2, 2), 0x10);
            }

            return bytes;
        }
    }
}
