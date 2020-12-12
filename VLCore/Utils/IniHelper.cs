using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace VLCore.Utils
{
    public static class IniHelper
    {
        [DllImport("kernel32")]  //返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]  //返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        public static string Read(string Section, string Key, string Default, string Dir)
        {
            if (File.Exists(Dir))
            {
                StringBuilder builder = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, Default, builder, 1024, Dir);
                return builder.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public static bool Write(string Section, string Key, string Value, string Dir)
        {
            if (File.Exists(Dir))
            {
                long OpStation = WritePrivateProfileString(Section, Key, Value, Dir);
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
