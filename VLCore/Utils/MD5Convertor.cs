using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace VLCore.Utils
{
    public static class MD5Convertor
    {
        public static string EncryptHexMD5(string strPwd)
        {
            return BitConverter.ToString(EncryptMD5(strPwd)).Replace("-", "").Replace(" ", "").Trim();
        }

        public static byte[] EncryptMD5(string strPwd)
        {
            MD5 md = new MD5CryptoServiceProvider();
            strPwd = BitConverter.ToString(md.ComputeHash(Encoding.Default.GetBytes(strPwd))).Replace("-", "");
            byte[] bytes = new byte[strPwd.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(strPwd.Substring(i * 2, 2), 0x10);
            }

            return bytes;
        }
    }
}
