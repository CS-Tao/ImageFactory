using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFactory
{
    class Sample
    {
        /// <summary>
        /// 像素横坐标
        /// </summary>
        public int x;

        /// <summary>
        /// 像素纵坐标
        /// </summary>
        public int y;

        /// <summary>
        /// 特征数
        /// </summary>
        public int mFeatureNum;

        /// <summary>
        /// 特征数组
        /// </summary>
        public double[] mFeatures;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="n">特征数</param>
        public Sample(int n)
        {
            mFeatureNum = n;
            mFeatures = new double[mFeatureNum];
        }
    }
}
