using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VLCore.Utils
{
    public static class RandomGenerator
    {
        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <returns><see cref="Random"/></returns>
        public static Random Generate()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iRoot = BitConverter.ToInt32(buffer, 0);
            Random rdmNum = new Random(iRoot);
            return new Random(iRoot);
        }
    }
}
