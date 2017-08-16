using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFactory
{
    class CFeaturePoint
    {
        /// <summary>
        /// 横坐标
        /// </summary>
        public int x;

        /// <summary>
        /// 纵坐标
        /// </summary>
        public int y;

        public CFeaturePoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
