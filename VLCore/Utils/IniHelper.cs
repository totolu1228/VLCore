using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace VLCore.Utils
{
    /// <summary>
    /// ini helper
    /// </summary>
    public static class IniHelper
    {
        [DllImport("kernel32")]  //返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]  //返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        /// <summary>
        /// read ini
        /// </summary>
        public static string Read(string section, string key, string value, string dir)
        {
            if (File.Exists(dir))
            {
                StringBuilder builder = new StringBuilder(1024);
                GetPrivateProfileString(section, key, value, builder, 1024, dir);
                return builder.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// write ini
        /// </summary>
        public static bool Write(string section, string key, string value, string dir)
        {
            if (File.Exists(dir))
            {
                long OpStation = WritePrivateProfileString(section, key, value, dir);
                if (OpStation == 0)
                    return false;
                else
                    return true;
            }
            else
            {
                return false;
            }
        }
    }
}
