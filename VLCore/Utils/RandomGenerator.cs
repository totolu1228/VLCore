using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VLCore.Utils
{
    /// <summary>
    /// random generator
    /// </summary>
    public static class RandomGenerator
    {
        /// <summary>
        /// generate random
        /// </summary>
        /// <returns><see cref="Random"/></returns>
        public static Random Generate()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iRoot = BitConverter.ToInt32(buffer, 0);
            Random rd = new Random(iRoot);
            return new Random(iRoot);
        }

        /// <summary>
        /// generate random int
        /// </summary>
        public static int Generate(int maxValue)
        {
            Random rd = Generate();
            return rd.Next(maxValue);
        }
    }
}
