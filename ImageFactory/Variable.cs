using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ImageFactory
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 子线程列表
        /// </summary>
        private List<Thread> threadList = new List<Thread>();

        /// <summary>
        /// panel列表
        /// </summary>
        private List<Panel> panelList = new List<Panel>();

        /// <summary>
        /// 正在活动的Panel
        /// </summary>
        private Panel activityPanel = new Panel();

        /// <summary>
        /// PictureBox列表
        /// </summary>
        private List<PictureBox> pictureBoxList = new List<PictureBox>();

        /// <summary>
        /// 正在活动的PictureBox
        /// </summary>
        private PictureBox activityPictureBox = new PictureBox();

        /// <summary>
        /// 图片宽度
        /// </summary>
        private int width;

        /// <summary>
        /// 图片高度
        /// </summary>
        private int height;
        /// <summary>
        /// 计时开始时间
        /// </summary>
        private DateTime begin;

        /// <summary>
        /// 计时结束时间
        /// </summary>
        private DateTime end;

        /// <summary>
        /// 记录鼠标左键状态
        /// </summary>
        private bool isbtndown = false;

        /// <summary>
        /// 鼠标左键按下的坐标
        /// </summary>
        private Point btndowPoint = new Point();

        /// <summary>
        /// 图片裁剪x1
        /// </summary>
        private int cutX1 = 0;

        /// <summary>
        /// 图片裁剪y1
        /// </summary>
        private int cutY1 = 0;

        /// <summary>
        /// 图片裁剪x2
        /// </summary>
        private int cutX2 = 0;

        /// <summary>
        /// 图片裁剪y2
        /// </summary>
        private int cutY2 = 0;

        /// <summary>
        /// 滤波算子
        /// </summary>
        private double[,] filter = new double[3, 3];

        /// <summary>
        /// 边缘检测阈值
        /// </summary>
        private int edgeSenseThreshod = 200;

        /// <summary>
        /// 高斯模糊尺度
        /// </summary>
        private double GuassScale = 1.6;

        /// <summary>
        /// 文件资源管理器根节点
        /// </summary>
        private TreeNode rootNode;
    }
}
