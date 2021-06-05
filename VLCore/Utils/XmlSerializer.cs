using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VLCore.Utils
{
    /// <summary>
    /// xml serializer
    /// </summary>
    public static class XmlSerializer
    {
        /// <summary>
        /// serialize xml
        /// </summary>
        public static void Serialize<T>(string path, T obj)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path))
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                xs.Serialize(writer, obj);
            }
        }

        /// <summary>
        /// deserialize xml
        /// </summary>
        public static T Deserialize<T>(string path)
        {
            if (!System.IO.File.Exists(path))
                return default(T);

            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                T ret = (T)xs.Deserialize(reader);
                return ret;
            }
        }
    }
}
