using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFactory
{
    public partial class ClassifyForm : Form
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
        /// 图片链表
        /// </summary>
        private List<Bitmap> bitmapList = new List<Bitmap>();

        /// <summary>
        /// 位图数据链表
        /// </summary>
        List<BitmapData> bitmapDataList = new List<BitmapData>();

        /// <summary>
        /// 各个窗口颜色
        /// </summary>
        private List<Color> colorOfEachPage = new List<Color>();
        
        /// <summary>
        /// 图片宽度
        /// </summary>
        private int width;

        /// <summary>
        /// 图片高度
        /// </summary>
        private int height;
        /// <summary>
        /// 初始聚类数
        /// </summary>
        private int C = 5;

        /// <summary>
        /// 分类数
        /// </summary>
        private int K = 20;

        /// <summary>
        /// 一个类别至少应具有的样本数目
        /// </summary>
        private int ThetaN = 20000;

        /// <summary>
        /// 一个类别样本标准差阈值
        /// </summary>
        private double ThetaS = 50;

        /// <summary>
        /// 聚类中心之间距离的阈值，即归并系数
        /// </summary>
        private int ThetaC = 15;

        /// <summary>
        /// 在一次迭代中可以归并的类别的最多对数
        /// </summary>
        private int L = 2;

        /// <summary>
        /// 允许迭代的最多次数
        /// </summary>
        private int I = 10;

        /// <summary>
        /// 特征数
        /// </summary>
        private int featureNum = 6;

        /// <summary>
        /// 样本数
        /// </summary>
        private int sampleNum = 0;

        /// <summary>
        /// 迭代次数
        /// </summary>
        private int IterationCount = 0;

        /// <summary>
        /// 颜色列表
        /// </summary>
        private List<Color> colorList = new List<Color>();

        /// <summary>
        /// 样本链表
        /// </summary>
        private List<Sample> sampleList = new List<Sample>();

        /// <summary>
        /// 聚类中心链表
        /// </summary>
        private List<Sample> centerList = new List<Sample>();

        /// <summary>
        /// 聚类链表，每个表项为样本链表
        /// </summary>
        private List<List<Sample>> clusterList = new List<List<Sample>>();

        /// <summary>
        /// 每个类别的各样本到样本中心的平均距离
        /// </summary>
        private List<double> distanceOfEachCluster = new List<double>();

        /// <summary>
        /// 所有样本到其聚类中心的平均距离
        /// </summary>
        private double distanceOfAllSampleWithCluter = 0;

        /// <summary>
        /// 各样本中心的距离,distanceOfCenters[i,j]为中心i到中心j的距离,i<j
        /// </summary>
        private double[,] distanceOfCenters;


        /// <summary>
        /// 每个类别的各样本到与中心的标准差向量,每个向量的维度与特征数一致
        /// </summary>
        private List<double[]> standardDeviationOfEachCluster = new List<double[]>();

        /// <summary>
        /// 各类标准差向量的最大分量组成的向量
        /// </summary>
        private List<double> maxStardDeviation = new List<double>();

        /// <summary>
        /// 各类标准差向量的最大分量的索引组成的向量
        /// </summary>
        private List<int> indexOfMaxStardDeviation = new List<int>();

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
        /// 是否已经经过迭代
        /// </summary>
        private bool haveIteative = false;

        /// <summary>
        /// 鼠标左键按下的坐标
        /// </summary>
        private Point btndowPoint = new Point();

        /// <summary>
        /// 多类显示的窗口索引
        /// </summary>
        private List<int> multiClassIndexsInTableControl = new List<int>();

        /// <summary>
        /// 是否获得结果
        /// </summary>
        private bool haveGotResult = false;

        /// <summary>
        /// 活动颜色
        /// </summary>
        private Color activityColor = Color.Black;

        /// <summary>
        /// 主窗口
        /// </summary>
        private MainForm mainForm;

        public Image resultImage = new Bitmap(1,1);

        public ClassifyForm(MainForm form, List<Bitmap> images)
        {
            InitializeComponent();
            mainForm = form;
            bitmapList = images;
        }

        public ClassifyForm(MainForm form, List<string> fileNameList)
        {
            InitializeComponent();
            mainForm = form;
            for(int i=0;i<fileNameList.Count;i++)
            {
                bitmapList.Add((Bitmap)Image.FromFile(fileNameList[i]));
            }
        }

        private void ClassifyForm_Load(object sender, EventArgs e)
        {
            Cnum.Value = C;
            Knum.Value = K;
            ThetaNnum.Value = ThetaN;
            ThetaSnum.Value = (decimal)ThetaS;
            ThetaCnum.Value = ThetaC;
            Lnum.Value = L;
            Inum.Value = I;
            IterationButton.Text = "开始迭代";
            toolStripProgressBar1.Visible = false;
            sampleList = new List<Sample>();
            colorList = new List<Color>();
            centerList = new List<Sample>();
            clusterList = new List<List<Sample>>();
            distanceOfEachCluster = new List<double>();
            bitmapDataList = new List<BitmapData>();
            distanceOfAllSampleWithCluter = 0;
            standardDeviationOfEachCluster = new List<double[]>();
            maxStardDeviation = new List<double>();
            indexOfMaxStardDeviation = new List<int>();
            haveIteative = false;
            Thread thread = new Thread(new ThreadStart(ReadImg));
            //thread.IsBackground = true;
            threadList.Add(thread);
            thread.Start();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if(DialogResult.OK == dlg.ShowDialog())
            {
                colorButton.BackColor = dlg.Color;
                activityColor = dlg.Color;
                Rnum.Value = dlg.Color.R;
                Gnum.Value = dlg.Color.G;
                Bnum.Value = dlg.Color.B;
                changeColorButton_Click(null, null);
                ShowLog("应用颜色:R(" + activityColor.R + "),G(" + activityColor.G + "),B(" + activityColor.B + ").");
            }
        }

        private delegate void delegateAppendText(string str);

        private void AppendText(string str)
        {
            logText.AppendText(str);
            logText.Select(this.logText.TextLength, 0);
            logText.ScrollToCaret();
        }

        private delegate void delegateShowRedMessage(string str);

        private void ShowRedMessage(string str)
        {
            logText.SelectionColor = Color.Red;
            logText.SelectedText = str;
            logText.Select(this.logText.TextLength, 0);
            logText.ScrollToCaret();
        }

        /// <summary>
        /// 显示日志,可用于子线程
        /// </summary>
        /// <param name="str">日志内容</param>
        private void ShowLog(string str)
        {
            delegateAppendText at = new delegateAppendText(AppendText);
            Invoke(at, new object[] { "$" + DateTime.Now.ToLongTimeString().ToString() + ":" + str + "\r\n" });
        }

        /// <summary>
        /// 显示红色日志,可用于子线程
        /// </summary>
        /// <param name="str">日志内容</param>
        private void ShowRedLog(string str)
        {
            delegateShowRedMessage dmsg = new delegateShowRedMessage(ShowRedMessage);
            Invoke(dmsg, new object[] { "$" + DateTime.Now.ToLongTimeString().ToString() + ":" + str + "\r\n" });
        }

        /// <summary>
        /// 双击关闭tabpage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabContralDoubleClick(object sender, EventArgs e)
        {
            for(int i=0;i<multiClassIndexsInTableControl.Count;i++)
            {
                if (tabControl1.SelectedIndex == multiClassIndexsInTableControl[i])
                {
                    ShowRedLog("该页暂不可关闭！");
                    return;
                }
            }
            if(multiClassIndexsInTableControl.Count > 0)
            {
                if (tabControl1.SelectedIndex < multiClassIndexsInTableControl[0])
                {
                    for (int i = 0; i < multiClassIndexsInTableControl.Count; i++)
                        multiClassIndexsInTableControl[i]--;
                }
            }
            if (tabControl1.SelectedIndex > 0)
            {
                tabControl1.SelectedIndex -= 1;
                pictureBoxList.RemoveAt(tabControl1.SelectedIndex + 1);
                panelList.RemoveAt(tabControl1.SelectedIndex + 1);
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex + 1);
                colorOfEachPage.RemoveAt(tabControl1.SelectedIndex + 1);
            }
            else
            {
                colorOfEachPage.RemoveAt(tabControl1.SelectedIndex);
                pictureBoxList.RemoveAt(tabControl1.SelectedIndex);
                panelList.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
            }

        }
        private delegate void delegateChangeButtonAndNumColor(Color color);

        private void dChangeButtonAndNumColor(Color color)
        {
            colorButton.BackColor = color;
            Rnum.Value = color.R;
            Gnum.Value = color.G;
            Bnum.Value = color.B;
        }

        /// <summary>
        /// 改变colorButton和RGB的值，可用于子线程
        /// </summary>
        /// <param name="color">颜色</param>
        private void ChangeButtonAndNumColor(Color color)
        {
            delegateChangeButtonAndNumColor d = new delegateChangeButtonAndNumColor(dChangeButtonAndNumColor);
            Invoke(d, new object[] { color });
        }

        private delegate void delegateCreateTabPage(string name, Image image);

        private void dCreateTabPage(string name, Image image)
        {
            int w = tabControl1.Width;
            int h = tabControl1.Height;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Width = w;
            pictureBox.Height = h;
            pictureBox.BackColor = Color.Black;
            pictureBox.MouseDown += Panel_MouseDown;
            pictureBox.MouseMove += Panel_MouseMove;
            pictureBox.MouseUp += Panel_MouseUp;
            pictureBox.MouseLeave += Panel_MouseLeave;

            Panel panel = new Panel();
            panel.Width = w;
            panel.Height = h;
            panel.Location = new Point(0, 0);
            panel.BackColor = Color.Black;
            panel.Controls.Add(pictureBox);
            panel.BorderStyle = BorderStyle.Fixed3D;
            panel.MouseWheel += pictureBox1_MouseWheel;
            
            colorOfEachPage.Add(Color.Black);
            activityColor = Color.Black;
            Rnum.Value = activityColor.R;
            Gnum.Value = activityColor.G;
            Bnum.Value = activityColor.B;

            TabPage tabPage = new TabPage(name);
            tabPage.BackColor = Color.Black;
            tabPage.Click += TabPage_Click;
            tabPage.Controls.Add(panel);
            panelList.Add(panel);
            pictureBoxList.Add(pictureBox);
            tabControl1.TabPages.Add(tabPage);


            activityPanel = panel;
            activityPictureBox = pictureBox;
            tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
        }

        private void TabPage_Click(object sender, EventArgs e)
        {
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            isbtndown = false;
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            isbtndown = false;
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isbtndown)
                activityPictureBox.Location = new Point(activityPictureBox.Location.X + (e.X - btndowPoint.X), activityPictureBox.Location.Y + (e.Y - btndowPoint.Y));
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            isbtndown = true;
            btndowPoint = new Point(e.X, e.Y);
        }

        private void btnzoomout_Click(object sender, EventArgs e)
        {
            int interval = 200;
            activityPictureBox.Size = new Size(activityPictureBox.Width + interval, activityPictureBox.Height + interval);
            activityPictureBox.Location = new Point((int)(activityPictureBox.Location.X - ((activityPanel.Width / 2.0 - activityPictureBox.Location.X) / ((double)activityPictureBox.Width - interval) * interval)), (int)(activityPictureBox.Location.Y - ((activityPanel.Height / 2.0 - activityPictureBox.Location.Y) / ((double)activityPictureBox.Height - interval) * interval)));
        }

        private void btnzoomin_Click(object sender, EventArgs e)
        {
            int interval = 200;
            if (activityPictureBox.Width - interval < activityPanel.Width || activityPictureBox.Height - interval < activityPanel.Height)
            {
                activityPictureBox.Size = activityPanel.Size;
                activityPictureBox.Location = new Point((activityPanel.Width - activityPictureBox.Width) / 2, (activityPanel.Height - activityPictureBox.Height) / 2);
            }
            else
            {
                activityPictureBox.Size = new Size(activityPictureBox.Width - interval, activityPictureBox.Height - interval);
                activityPictureBox.Location = new Point((int)(activityPictureBox.Location.X + ((activityPanel.Width / 2.0 - activityPictureBox.Location.X) / ((double)activityPictureBox.Width + interval) * interval)), (int)(activityPictureBox.Location.Y + ((activityPanel.Height / 2.0 - activityPictureBox.Location.Y) / ((double)activityPictureBox.Height + interval) * interval)));
            }
        }

        private void btnre_Click(object sender, EventArgs e)
        {
            activityPictureBox.Size = activityPanel.Size;
            activityPictureBox.Location = new Point((activityPanel.Width - activityPictureBox.Width) / 2, (activityPanel.Height - activityPictureBox.Height) / 2);
        }

        /// <summary>
        /// 创建tabpage，允许子线程访问
        /// </summary>
        /// <param name="name">tabpage名字</param>
        /// <param name="image">显示图片</param>
        private void CreateTabPage(string name, Image image)
        {
            try
            {
                delegateCreateTabPage at = new delegateCreateTabPage(dCreateTabPage);
                Invoke(at, new object[] { name, image });
            }
            catch(Exception ex)
            {
                mainForm.ShowRedLog(ex.Message);
            }
        }

        private void tabControlIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 0)
                return;
            activityPictureBox = pictureBoxList[tabControl1.SelectedIndex];
            activityPanel = panelList[tabControl1.SelectedIndex];
            activityColor = colorOfEachPage[tabControl1.SelectedIndex];
            ChangeButtonAndNumColor(activityColor);
        }

        void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            int interval = 200;
            if (e.Delta > 0)
            {//放大图片
                activityPictureBox.Size = new Size(activityPictureBox.Width + interval, activityPictureBox.Height + interval);
                activityPictureBox.Location = new Point((int)(activityPictureBox.Location.X - ((e.X - activityPictureBox.Location.X) / ((double)activityPictureBox.Width - interval) * interval)), (int)(activityPictureBox.Location.Y - ((e.Y - activityPictureBox.Location.Y) / ((double)activityPictureBox.Height - interval) * interval)));
            }
            else
            { //缩小图片
                if (activityPictureBox.Width - interval < activityPanel.Width || activityPictureBox.Height - interval < activityPanel.Height)
                {
                    activityPictureBox.Size = activityPanel.Size;
                    activityPictureBox.Location = new Point((activityPanel.Width - activityPictureBox.Width) / 2, (activityPanel.Height - activityPictureBox.Height) / 2);
                }
                else
                {
                    activityPictureBox.Size = new Size(activityPictureBox.Width - interval, activityPictureBox.Height - interval);
                    activityPictureBox.Location = new Point((int)(activityPictureBox.Location.X + ((e.X - activityPictureBox.Location.X) / ((double)activityPictureBox.Width + interval) * interval)), (int)(activityPictureBox.Location.Y + ((e.Y - activityPictureBox.Location.Y) / ((double)activityPictureBox.Height + interval) * interval)));
                }
            }
        }
        /// <summary>
        /// 计算入口函数
        /// </summary>
        private void Launch()
        {
            ShowProgress(true);
            ShowInTooStrip("影像分类...");

            haveGotResult = true;

            begin = DateTime.Now;
            if(!haveIteative)
            {
                ISODataAlgorithm();
                haveIteative = true;
            }
            else
            {
                Iteration();
            }

            if(!haveGotResult)
            {
                ShowProgress(false);
                ShowInTooStrip("");
                ShowRedLog("计算终止");
                return;
            }

            int n = 0;
            for (int i = 0; i < clusterList.Count; i++)
            {
                n += clusterList[i].Count;
            }

            ShowLog("样本分类完毕(" + n + "/" + sampleNum + "),共" + clusterList.Count + "类.有" + (sampleNum - n) + "个样本未分类.耗时：" + GetTimeInterval(begin, DateTime.Now));
            ShowInTooStrip("显示图片...");
            
            ShowResult();
            ShowProgress(false);
            ShowInTooStrip("");
        }

        /// <summary>
        /// 读取影像文件
        /// </summary>
        private void ReadImg()
        {
            ShowProgress(true);
            ShowInTooStrip("生成样本...");
            List<IntPtr> intPrList = new List<IntPtr>();
            List<byte[]> imgValueList = new List<byte[]>();

            featureNum = bitmapList.Count;

            width = bitmapList[0].Width;
            height = bitmapList[0].Height;
            
            Bitmap Result = new Bitmap(width, height);

            Rectangle rect = new Rectangle(0, 0, width, height);
            
            int img_bytes = width * height;
            for (int i = 0; i < featureNum; i++)
            {
                bitmapDataList.Add(bitmapList[i].LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb));
                intPrList.Add(bitmapDataList[i].Scan0);
                img_bytes = bitmapDataList[0].Stride * height;
                imgValueList.Add(new byte[img_bytes]);
                System.Runtime.InteropServices.Marshal.Copy(intPrList[i], imgValueList[i], 0, img_bytes);
            }

            //操作
            sampleNum = height * width;
            int stride = bitmapDataList[0].Stride;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < 3 * width; j += 3)
                {
                    Sample tempSample = new Sample(featureNum);
                    tempSample.x = j;
                    tempSample.y = i;
                    for (int k = 0; k < featureNum; k++)
                    {
                        tempSample.mFeatures[k] = imgValueList[k][i * stride + j];
                    }
                    sampleList.Add(tempSample);
                }
            }

            for (int k = 0; k < featureNum; k++)
            {
                System.Runtime.InteropServices.Marshal.Copy(imgValueList[k], 0, intPrList[k], img_bytes);
                bitmapList[k].UnlockBits(bitmapDataList[k]);
            }

            begin = DateTime.Now;
            ShowLog("样本生成完毕.样本数:" + sampleNum + ".维度数:" + featureNum + ".耗时：" + GetTimeInterval(begin, DateTime.Now));
            ShowProgress(false);
            ShowInTooStrip("");
        }

        /// <summary>
        /// ISODATA算法
        /// </summary>
        private void ISODataAlgorithm()
        {
            //构造初始聚类中心
            for (int i = 0; i < C; i++)
            {
                centerList.Add(sampleList[i]);
            }
            Iteration();
        }

        /// <summary>
        /// 迭代处理
        /// </summary>
        private void Iteration()
        {
            while (true)
            {
                IterationCount++;

                //判断C是否有效
                if (C <= 0)
                {
                    ShowRedLog("C值在运算过程中出现无效值，请检查参数设置是否合理！");
                    //reLoadButton_Click(null, null);
                    haveGotResult = false;
                    return;
                }

                //更新聚类
                clusterList.Clear();
                for (int i = 0; i < C; i++)
                {
                    clusterList.Add(new List<Sample>());
                }

                //将样本按最小距离分类
                for (int i = 0; i < sampleNum; i++)
                {
                    double[] distance = new double[C];
                    for (int j = 0; j < C; j++)
                    {
                        distance[j] = GetDistanceWithCenter(sampleList[i], centerList[j]);
                    }
                    double min = 0;
                    int index = 0;
                    GetMinValueAndIndex(distance, ref min, ref index);
                    clusterList[index].Add(sampleList[i]);
                }

                //去除样本较少的聚类
                for (int i = 0; i < C; i++)
                {
                    if (clusterList[i].Count < ThetaN)
                    {
                        C = C - 1;
                        clusterList.RemoveAt(i);
                        i--;
                    }
                }

                //修正各聚类中心值
                centerList.Clear();
                for (int i = 0; i < C; i++)
                {
                    centerList.Add(GetClusterCenter(clusterList[i]));
                }

                //对于每一个聚类域，计算其所有样本到其中心的平均距离
                for (int i = 0; i < C; i++)
                {
                    distanceOfEachCluster.Add(GetAverageDistanceWithCenter(clusterList[i], centerList[i]));
                }

                //计算所有样本到其聚类中心的平均距离
                int numOfAllCluster = 0;
                for (int i = 0; i < C; i++)
                {
                    numOfAllCluster += clusterList[i].Count;
                    distanceOfAllSampleWithCluter += distanceOfEachCluster[i] * clusterList[i].Count;
                }
                distanceOfAllSampleWithCluter /= numOfAllCluster;

                //进行分裂或合并
                if (IterationCount >= I)
                {
                    //达到迭代次数
                    break;
                }
                else if (C <= K / 2)
                {
                    if (!DivideCluster())
                        CombineClusers();
                }
                else if ((C >= 2 * K) || (IterationCount % 2 == 0))
                {
                    CombineClusers();
                }
                else
                {
                    DivideCluster();
                }
            }
        }

        /// <summary>
        /// 得到聚类中心
        /// </summary>
        /// <param name="cluster">某个聚类</param>
        /// <returns>聚类中心</returns>
        private Sample GetClusterCenter(List<Sample> cluster)
        {
            int clusterNum = cluster.Count;
            Sample center = new Sample(featureNum);
            for (int i = 0; i < featureNum; i++)
            {
                for (int j = 0; j < clusterNum; j++)
                {
                    center.mFeatures[i] += cluster[j].mFeatures[i];
                }
                center.mFeatures[i] /= clusterNum;
            }
            return center;
        }

        /// <summary>
        /// 得到样本到中心的距离
        /// </summary>
        /// <param name="sample">样本</param>
        /// <param name="center">聚类中心</param>
        /// <returns>样本到中心的距离</returns>
        private double GetDistanceWithCenter(Sample sample, Sample center)
        {
            double distance = 0;
            for (int i = 0; i < featureNum; i++)
            {
                distance += ((sample.mFeatures[i] - center.mFeatures[i]) * (sample.mFeatures[i] - center.mFeatures[i]));
            }
            distance = Math.Sqrt(distance);
            return distance;
        }

        /// <summary>
        /// 得到某个聚类中样本集到中心的平均距离
        /// </summary>
        /// <param name="cluster">聚类</param>
        /// <param name="center">聚类中心</param>
        /// <returns>样本集到中心的平均距离</returns>
        private double GetAverageDistanceWithCenter(List<Sample> cluster, Sample center)
        {
            int clusterNum = cluster.Count;
            double distance = 0;
            for (int i = 0; i < clusterNum; i++)
            {
                distance += GetDistanceWithCenter(cluster[i], center);
            }
            distance /= clusterNum;
            return distance;
        }

        /// <summary>
        /// 得到该类别各样本与样本中心的标准差向量
        /// </summary>
        /// <param name="cluster">聚类</param>
        /// <param name="center">聚类中心</param>
        /// <returns>该类别各样本与样本中心的标准差向量</returns>
        private double[] GetStandardDeviationWithCenter(List<Sample> cluster, Sample center)
        {
            int clusterNum = cluster.Count;
            double[] standardDeviation = new double[featureNum];
            for (int i = 0; i < featureNum; i++)
            {
                for (int j = 0; j < clusterNum; j++)
                {
                    standardDeviation[i] += (cluster[j].mFeatures[i] - center.mFeatures[i]) * (cluster[j].mFeatures[i] - center.mFeatures[i]);
                }
                standardDeviation[i] = Math.Sqrt(standardDeviation[i] / clusterNum);
            }

            return standardDeviation;
        }

        /// <summary>
        /// 获取数组中的最小值和其索引
        /// </summary>
        /// <param name="array">数组集合</param>
        /// <param name="minValue">用于承接最小值</param>
        /// <param name="index">用于承接最小值的索引</param>
        private void GetMinValueAndIndex(double[] array, ref double minValue, ref int index)
        {
            minValue = array[0];
            index = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                    index = i;
                }
            }
        }

        /// <summary>
        /// 获取数组中的最大值和其索引
        /// </summary>
        /// <param name="array">数组集合</param>
        /// <param name="maxValue">用于承接最大值</param>
        /// <param name="index">用于承接最大值的索引</param>
        private void GetMaxValueAndIndex(double[] array, ref double maxValue, ref int index)
        {
            maxValue = array[0];
            index = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                    index = i;
                }
            }
        }

        /// <summary>
        /// 将数组从小到大排序(冒泡法)
        /// </summary>
        /// <param name="array">待排序数组</param>
        private void SortFromMinToMax(ref List<int> array)
        {
            int n = array.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// 将数组从大到小排序(冒泡法)
        /// </summary>
        /// <param name="array">待排序数组</param>
        private void SortFromMaxToMin(ref List<int> array)
        {
            int n = array.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (array[i] < array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// 分裂运算
        /// </summary>
        /// <returns>是否完成分裂</returns>
        private bool DivideCluster()
        {
            bool haveDivided = false;
            //计算各聚类的标准差向量并记录其各分量的最大值和索引
            for (int i = 0; i < C; i++)
            {
                standardDeviationOfEachCluster.Add(new double[featureNum]);
                maxStardDeviation.Add(0);
                indexOfMaxStardDeviation.Add(0);
            }
            for (int i = 0; i < C; i++)
            {
                standardDeviationOfEachCluster[i] = GetStandardDeviationWithCenter(clusterList[i], centerList[i]);
                int index = 0;
                double max = 0;
                GetMaxValueAndIndex(standardDeviationOfEachCluster[i], ref max, ref index);
                maxStardDeviation[i] = max;
                indexOfMaxStardDeviation[i] = index;
            }
            //符合条件则执行分裂操作
            int c = C;
            for (int i = 0; i < c; i++)
            {
                if ((maxStardDeviation[i] > ThetaS) && ((distanceOfEachCluster[i] > distanceOfAllSampleWithCluter) || (C <= K / 2)))
                {
                    Sample oldCenter = centerList[i];
                    centerList.Remove(centerList[i]);
                    Sample center1 = new Sample(featureNum);
                    Sample center2 = new Sample(featureNum);
                    double sd = maxStardDeviation[i];
                    double m = 0.5;
                    double r = sd * m;
                    for (int j = 0; j < featureNum; j++)
                    {
                        if (j != indexOfMaxStardDeviation[i])
                        {
                            center1.mFeatures[j] = oldCenter.mFeatures[j];
                            center2.mFeatures[j] = oldCenter.mFeatures[j];
                        }
                        else
                        {
                            center1.mFeatures[j] = oldCenter.mFeatures[j] + r;
                            center2.mFeatures[j] = oldCenter.mFeatures[j] - r;
                        }
                    }
                    centerList.Add(center1);
                    centerList.Add(center2);
                    C = C + 1;
                    haveDivided = true;
                }
            }

            return haveDivided;
        }

        /// <summary>
        /// 合并运算
        /// </summary>
        /// <returns>是否合乎合并条件</returns>
        private bool CombineClusers()
        {
            List<double> overflowDistance = new List<double>();
            List<int> indexOfCenter1 = new List<int>();
            List<int> indexOfCenter2 = new List<int>();
            distanceOfCenters = new double[C, C];

            for (int i = 0; i < C; i++)
            {
                for (int j = i + 1; j < C; j++)
                {
                    distanceOfCenters[i, j] = GetDistanceWithCenter(centerList[i], centerList[j]);
                    if (distanceOfCenters[i, j] < ThetaC)
                    {
                        overflowDistance.Add(distanceOfCenters[i, j]);
                        indexOfCenter1.Add(i);
                        indexOfCenter2.Add(j);
                    }
                }
            }

            if (overflowDistance.Count == 0)
                return false;

            //对超出阈值的距离进行冒泡法排序
            int n = overflowDistance.Count;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (overflowDistance[j] > overflowDistance[j + 1])
                    {
                        double temp = overflowDistance[j];
                        overflowDistance[j] = overflowDistance[j + 1];
                        overflowDistance[j + 1] = temp;

                        int temp1 = indexOfCenter1[j];
                        indexOfCenter1[j] = indexOfCenter1[j + 1];
                        indexOfCenter1[j + 1] = temp1;

                        int temp2 = indexOfCenter2[j];
                        indexOfCenter2[j] = indexOfCenter2[j + 1];
                        indexOfCenter2[j + 1] = temp2;
                    }
                }
            }

            int combinedNum = 0;
            List<int> haveCombinedIndex = new List<int>();

            for (int i = 0; i < n; i++)
            {
                bool haveCombined = false;
                //判断是否已经合并
                for (int j = 0; j < haveCombinedIndex.Count; j++)
                {
                    if (indexOfCenter1[i] == haveCombinedIndex[j] || indexOfCenter2[i] == haveCombinedIndex[j])
                    {
                        haveCombined = true;
                        break;
                    }
                }

                if ((!haveCombined) && (combinedNum < L))
                {
                    Sample newCenter = new Sample(featureNum);
                    Sample center1 = centerList[indexOfCenter1[i]];
                    Sample center2 = centerList[indexOfCenter2[i]];
                    int N1 = clusterList[indexOfCenter1[i]].Count;
                    int N2 = clusterList[indexOfCenter2[i]].Count;
                    haveCombinedIndex.Add(indexOfCenter1[i]);
                    haveCombinedIndex.Add(indexOfCenter2[i]);

                    for (int j = 0; j < featureNum; j++)
                    {
                        newCenter.mFeatures[j] = (center1.mFeatures[j] * N1 + center2.mFeatures[j] * N2) / (N1 + N2);
                    }
                    centerList.Add(newCenter);
                    C = C - 1;
                    combinedNum++;
                }
            }
            SortFromMaxToMin(ref haveCombinedIndex);
            for (int i = 0; i < haveCombinedIndex.Count; i++)
            {
                centerList.RemoveAt(haveCombinedIndex[i]);
                clusterList.RemoveAt(haveCombinedIndex[i]);
            }
            return true;
        }

        /// <summary>
        /// 显示结果
        /// </summary>
        private void ShowResult()
        {
            //10个基础颜色
            colorList.Clear();
            colorList.Add(Color.Green);
            colorList.Add(Color.Red);
            colorList.Add(Color.LightYellow);
            colorList.Add(Color.LimeGreen);
            colorList.Add(Color.Blue);
            colorList.Add(Color.Plum);
            colorList.Add(Color.Salmon);
            colorList.Add(Color.Purple);
            colorList.Add(Color.YellowGreen);
            colorList.Add(Color.Turquoise);
            int val = 0;
            if (clusterList.Count <= 10)
                val = 255;
            else if (clusterList.Count <= 18)
                val = 120;
            else if (clusterList.Count <= 37)
                val = 100;
            else if (clusterList.Count <= 74)
                val = 60;
            //24个等距颜色
            for (int i = 40; i < 255; i += val)
            {
                for (int j = 40; j < 255; j += val)
                {
                    for (int k = 40; k < 255; k += val)
                    {
                        colorList.Add(Color.FromArgb(i, j, k));
                    }
                }
            }
            Bitmap result = new Bitmap(width, height);
            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData resultData = result.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            System.IntPtr resultPtr = resultData.Scan0;
            int img_bytes = resultData.Stride * height;
            byte[] resultValues = new byte[img_bytes];
            System.Runtime.InteropServices.Marshal.Copy(resultPtr, resultValues, 0, img_bytes);

            for (int i = 0; i < clusterList.Count; i++)
            {
                for (int j = 0; j < clusterList[i].Count; j++)
                {
                    if (i > 10)
                    {
                        resultValues[clusterList[i][j].y * resultData.Stride + clusterList[i][j].x] = colorList[(int)((i - 10) / (double)clusterList.Count * colorList.Count)].B;
                        resultValues[clusterList[i][j].y * resultData.Stride + clusterList[i][j].x + 1] = colorList[(int)((i - 10) / (double)clusterList.Count * colorList.Count)].G;
                        resultValues[clusterList[i][j].y * resultData.Stride + clusterList[i][j].x + 2] = colorList[(int)((i - 10) / (double)clusterList.Count * colorList.Count)].R;
                    }
                    else
                    {
                        resultValues[clusterList[i][j].y * resultData.Stride + clusterList[i][j].x] = colorList[i].B;
                        resultValues[clusterList[i][j].y * resultData.Stride + clusterList[i][j].x + 1] = colorList[i].G;
                        resultValues[clusterList[i][j].y * resultData.Stride + clusterList[i][j].x + 2] = colorList[i].R;
                    }
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(resultValues, 0, resultPtr, img_bytes);
            result.UnlockBits(resultData);
            CreateTabPage(IterationCount + "次迭代", result);
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="image">待保存图片</param>
        /// <param name="path">路径</param>
        private void SaveImage(Image image, string path)
        {
            image.Save(path);
        }

        /// <summary>
        /// 获取真彩色或假彩色图片
        /// </summary>
        /// <param name="channel1">通道1</param>
        /// <param name="channel2">通道2</param>
        /// <param name="channel3">通道3</param>
        /// <param name="threeChannel">合成之后的图片</param>
        /// <returns>是否成功</returns>
        private bool GetThreeChannelImage(Bitmap channel1, Bitmap channel2, Bitmap channel3, ref Bitmap threeChannel)
        {
            if (channel1.Width != channel2.Width || channel1.Width != channel3.Width || channel1.Height != channel2.Height || channel1.Height != channel3.Height)
            {
                ShowRedLog("图片大小不符！");
                return false;
            }
            int width = channel1.Width;
            int height = channel1.Height;

            threeChannel = new Bitmap(width, height);

            Rectangle rect = new Rectangle(0, 0, width, height);
            //将Bitmap锁定到系统内存中,获得BitmapData
            BitmapData imgBmData1 = channel1.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData imgBmData2 = channel2.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData imgBmData3 = channel3.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData imgBmDatathreeChannel = threeChannel.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            //位图中第一个像素数据的地址。它也可以看成是位图中的第一个扫描行
            System.IntPtr imgPtr1 = imgBmData1.Scan0;
            System.IntPtr imgPtr2 = imgBmData2.Scan0;
            System.IntPtr imgPtr3 = imgBmData3.Scan0;
            System.IntPtr imgPtrthreeChannel = imgBmDatathreeChannel.Scan0;

            int img_bytes = imgBmData1.Stride * height;

            byte[] imgValues1 = new byte[img_bytes];
            byte[] imgValues2 = new byte[img_bytes];
            byte[] imgValues3 = new byte[img_bytes];
            byte[] imgValues4 = new byte[img_bytes];
            byte[] imgValues5 = new byte[img_bytes];
            byte[] imgValues6 = new byte[img_bytes];
            byte[] imgValuesthreeChannel = new byte[img_bytes];
            byte[] imgValuesResult = new byte[img_bytes];

            //复制GRB信息到byte数组
            System.Runtime.InteropServices.Marshal.Copy(imgPtr1, imgValues1, 0, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgPtr2, imgValues2, 0, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgPtr3, imgValues3, 0, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgPtrthreeChannel, imgValuesthreeChannel, 0, img_bytes);

            //操作
            int stride = imgBmData1.Stride;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < 3 * width; j += 3)
                {
                    imgValuesthreeChannel[i * stride + j] = imgValues3[i * stride + j];
                    imgValuesthreeChannel[i * stride + j + 1] = imgValues2[i * stride + j + 1];
                    imgValuesthreeChannel[i * stride + j + 2] = imgValues1[i * stride + j + 2];
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(imgValues1, 0, imgPtr1, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgValues2, 0, imgPtr2, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgValues3, 0, imgPtr3, img_bytes);
            System.Runtime.InteropServices.Marshal.Copy(imgValuesthreeChannel, 0, imgPtrthreeChannel, img_bytes);

            //解锁位图
            channel1.UnlockBits(imgBmData1);
            channel2.UnlockBits(imgBmData2);
            channel3.UnlockBits(imgBmData3);
            threeChannel.UnlockBits(imgBmDatathreeChannel);

            return true;
        }

        /// <summary>
        /// 获取时间间隔
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private string GetTimeInterval(DateTime begin, DateTime end)
        {
            string time = "";
            int Second = (end.Hour - begin.Hour) * 3600 + (end.Minute - begin.Minute) * 60 + (end.Second - begin.Second);
            int h, min, s;
            h = (int)(Second / 3600.0);
            min = (Second - h * 3600) / 60;
            s = Second - h * 3600 - min * 60;
            if (h != 0)
                time += h + "小时";
            time += min + "分";
            time += s + "秒";
            return time;
        }

        private delegate void delegateShowInTooStrip(string str);

        private void dShowInTooStrip(string str)
        {
            toolStripStatusLabel1.Text = str;
        }

        /// <summary>
        /// 显示在toolstrip,可用于子线程
        /// </summary>
        /// <param name="str">内容</param>
        private void ShowInTooStrip(string str)
        {
            delegateShowInTooStrip d = new delegateShowInTooStrip(dShowInTooStrip);
            Invoke(d, new object[] { str });
        }

        private delegate void delegateShowProgress(bool show);

        private void dShowProgress(bool show)
        {
            IterationButton.Enabled = !show;
            Cnum.Enabled = !show;
            Knum.Enabled = !show;
            ThetaNnum.Enabled = !show;
            ThetaCnum.Enabled = !show;
            ThetaSnum.Enabled = !show;
            Lnum.Enabled = !show;
            Inum.Enabled = !show;
            okButton.Enabled = !show;
            cancelButton.Enabled = !show;
            Rnum.Enabled = !show;
            Gnum.Enabled = !show;
            Bnum.Enabled = !show;
            colorButton.Enabled = !show;
            reLoadButton.Enabled = !show;
            changeColorButton.Enabled = !show;
            multiClassButton.Enabled = !show;
            mergeButton.Enabled = !show;
            toolStripProgressBar1.Visible = show;

            if (show)
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
            }
        }

        /// <summary>
        /// 显示、取消进度条
        /// </summary>
        /// <param name="show">是否显示</param>
        private void ShowProgress(bool show)
        {
            delegateShowProgress d = new delegateShowProgress(dShowProgress);
            Invoke(d, new object[] { show });
        }

        private void IterationButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(Inum.Value <= IterationCount)
                {
                    ShowRedLog("迭代次数不能小于已迭代次数！");
                    return;
                }
                Thread thread = new Thread(new ThreadStart(Launch));
                //thread.IsBackground = true;
                threadList.Add(thread);
                if(!haveIteative)
                {
                    C = (int)Cnum.Value;
                    IterationButton.Text = "继续迭代";
                }
                K = (int)Knum.Value;
                ThetaN = (int)ThetaNnum.Value;
                ThetaS = (int)ThetaSnum.Value;
                ThetaC = (int)ThetaCnum.Value;
                L = (int)Lnum.Value;
                I = (int)Inum.Value;
                thread.Start();
            }
            catch (Exception ex)
            {
                ShowRedLog(ex.Message);
            }
        }

        /// <summary>
        /// 更新颜色列表
        /// </summary>
        private void UpdateColorList()
        {
            //10个基础颜色
            colorList.Add(Color.Green);
            colorList.Add(Color.Red);
            colorList.Add(Color.LightYellow);
            colorList.Add(Color.LimeGreen);
            colorList.Add(Color.Blue);
            colorList.Add(Color.Plum);
            colorList.Add(Color.Salmon);
            colorList.Add(Color.Purple);
            colorList.Add(Color.YellowGreen);
            colorList.Add(Color.Turquoise);
            int val = 0;
            if (clusterList.Count <= 10)
                val = 255;
            else if (clusterList.Count <= 18)
                val = 120;
            else if (clusterList.Count <= 37)
                val = 100;
            else if (clusterList.Count <= 74)
                val = 60;
            //24个等距颜色
            for (int i = 40; i < 255; i += val)
            {
                for (int j = 40; j < 255; j += val)
                {
                    for (int k = 40; k < 255; k += val)
                    {
                        colorList.Add(Color.FromArgb(i, j, k));
                    }
                }
            }
        }

        /// <summary>
        /// 显示单类图像
        /// </summary>
        /// <param name="cluster">类别</param>
        /// <param name="color">绘画颜色</param>
        /// <returns></returns>
        private Bitmap GetClusterImage(List<Sample> cluster, Color color)
        {
            Bitmap result = new Bitmap(width, height);
            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData resultData = result.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            System.IntPtr resultPtr = resultData.Scan0;
            int img_bytes = resultData.Stride * height;
            byte[] resultValues = new byte[img_bytes];
            System.Runtime.InteropServices.Marshal.Copy(resultPtr, resultValues, 0, img_bytes);

            for (int j = 0; j < cluster.Count; j++)
            {
                resultValues[cluster[j].y * resultData.Stride + cluster[j].x] = color.B;
                resultValues[cluster[j].y * resultData.Stride + cluster[j].x + 1] = color.G;
                resultValues[cluster[j].y * resultData.Stride + cluster[j].x + 2] = color.R;
            }

            System.Runtime.InteropServices.Marshal.Copy(resultValues, 0, resultPtr, img_bytes);
            result.UnlockBits(resultData);

            return result;
        }

        /// <summary>
        /// 显示多类图像
        /// </summary>
        /// <param name="clusterList">类别链表</param>
        /// <param name="color">显示颜色链表</param>
        /// <returns></returns>
        private Bitmap GetClustersImage(List<List<Sample>> clusterList, List<Color> colors)
        {
            Bitmap result = new Bitmap(width, height);
            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData resultData = result.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            System.IntPtr resultPtr = resultData.Scan0;
            int img_bytes = resultData.Stride * height;
            byte[] resultValues = new byte[img_bytes];
            System.Runtime.InteropServices.Marshal.Copy(resultPtr, resultValues, 0, img_bytes);

            for (int i = 0; i < clusterList.Count; i++)
            {
                for (int j = 0; j < clusterList[i].Count; j++)
                {
                    if (i > 10)
                    {
                        resultValues[clusterList[i][j].y * resultData.Stride + clusterList[i][j].x] = colors[i].B;
                        resultValues[clusterList[i][j].y * resultData.Stride + clusterList[i][j].x + 1] = colors[i].G;
                        resultValues[clusterList[i][j].y * resultData.Stride + clusterList[i][j].x + 2] = colors[i].R;
                    }
                    else
                    {
                        resultValues[clusterList[i][j].y * resultData.Stride + clusterList[i][j].x] = colors[i].B;
                        resultValues[clusterList[i][j].y * resultData.Stride + clusterList[i][j].x + 1] = colors[i].G;
                        resultValues[clusterList[i][j].y * resultData.Stride + clusterList[i][j].x + 2] = colors[i].R;
                    }
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(resultValues, 0, resultPtr, img_bytes);
            result.UnlockBits(resultData);

            return result;
        }

        private void ShowMutiClassImages()
        {
            if (clusterList.Count == 0)
            {
                ShowRedLog("尚未分类");
                return;
            }
            for(int i= multiClassIndexsInTableControl.Count - 1; i >= 0;i--)
            {
                colorOfEachPage.RemoveAt(multiClassIndexsInTableControl[i]);
                pictureBoxList.RemoveAt(multiClassIndexsInTableControl[i]);
                panelList.RemoveAt(multiClassIndexsInTableControl[i]);
                tabControl1.TabPages.RemoveAt(multiClassIndexsInTableControl[i]);
            }
            multiClassIndexsInTableControl.Clear();
            UpdateColorList();
            for (int i = 0; i < clusterList.Count; i++)
            {
                CreateTabPage(IterationCount + "次迭代,第" + (i + 1) + "类", GetClusterImage(clusterList[i], colorList[i]));
                multiClassIndexsInTableControl.Add(tabControl1.TabPages.Count - 1);
                colorOfEachPage[tabControl1.TabPages.Count - 1] = colorList[i];
            }
            activityColor = colorList[clusterList.Count - 1];
            ChangeButtonAndNumColor(activityColor);
        }

        private void multiClassButton_Click(object sender, EventArgs e)
        {
            ShowMutiClassImages();
        }

        private void RGBNumChanged(object sender, EventArgs e)
        {
        }

        private void mergeButton_Click(object sender, EventArgs e)
        {
            if (multiClassIndexsInTableControl.Count == 0)
            {
                ShowRedLog("尚未分类");
                return;
            }
            List<Color> tempColorList = new List<Color>();
            for(int i=0;i< multiClassIndexsInTableControl.Count;i++)
            {
                tempColorList.Add(colorOfEachPage[multiClassIndexsInTableControl[i]]);
            }
            CreateTabPage(IterationCount + "次迭代,多类合并", GetClustersImage(clusterList, tempColorList));
        }

        private void changeColorButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == -1)
            {
                ShowRedLog("无应用页面");
                return;
            }
            for (int i = 0; i < multiClassIndexsInTableControl.Count; i++)
            {
                if (tabControl1.SelectedIndex == multiClassIndexsInTableControl[i])
                {
                    pictureBoxList[tabControl1.SelectedIndex].Image = GetClusterImage(clusterList[i], activityColor);
                    colorOfEachPage[tabControl1.SelectedIndex] = activityColor;
                }
            }
        }

        private void reLoadButton_Click(object sender, EventArgs e)
        {
            IterationCount = 0;
            C = (int)Cnum.Value;
            K = (int)Knum.Value;
            ThetaN = (int)ThetaNnum.Value;
            ThetaS = (int)ThetaSnum.Value;
            ThetaC = (int)ThetaCnum.Value;
            L = (int)Lnum.Value;
            I = (int)Inum.Value;
            ClassifyForm_Load(null, null);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != -1)
            {
                mainForm.CreateTabPage(tabControl1.TabPages[tabControl1.SelectedIndex].Text, activityPictureBox.Image);
                ShowLog("传输图片");
            }
            else
            {
                ShowRedLog("无图片传输至其他窗口！");
                return;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nFormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < threadList.Count; i++)
            {
                if (threadList[i].ThreadState == ThreadState.Running)
                {
                    if (DialogResult.Yes != MessageBox.Show("有子线程正在运行,强制退出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        //MessageBox.Show("有子线程正在运行,请等待线程运行结束", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            
            for (int i = 0; i < threadList.Count; i++)
            {
                if (threadList[i].ThreadState == ThreadState.Running)
                {
                    threadList[i].Abort();
                }
            }
            this.Dispose();
            if (this.DialogResult != DialogResult.OK)
                this.DialogResult = DialogResult.Cancel;
        }

        private void 保存本页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBoxList.Count == 0)
            {
                MessageBox.Show("无可保存的文件！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "bmp|*.bmp|jpg|*.jpg|jpeg|*.jpeg|png|*.png|all|*.*";
            //savefile.FilterIndex = 2;
            savefile.RestoreDirectory = true;
            savefile.FileName = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                activityPictureBox.Image.Save(savefile.FileName);
                ShowLog("文件保存成功！");
            }
        }

        private void nSizeChanged(object sender, EventArgs e)
        {
            for(int i=0;i<panelList.Count;i++)
            {
                panelList[i].Size = tabControl1.Size;
                pictureBoxList[i].Size = tabControl1.Size;
                pictureBoxList[i].Refresh();
            }
        }

        private void MouseEnterShowToolTip(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            if(sender == labelC )
            {
                toolTip.SetToolTip((Control)sender, "初始类别数");
            }
            else if(sender == labelK)
            {
                toolTip.SetToolTip((Control)sender, "期望类别数");
            }
            else if (sender == labelTheTaN)
            {
                toolTip.SetToolTip((Control)sender, "一个类别至少应具有的样本数目");
            }
            else if(sender == labelTheTaS)
            {
                toolTip.SetToolTip((Control)sender, "一个类别样本标准差阈值");
            }
            else if (sender == labelThetaC)
            {
                toolTip.SetToolTip((Control)sender, "聚类中心之间距离的阈值，即归并系数");
            }
            else if (sender == labelL)
            {
                toolTip.SetToolTip((Control)sender, "在一次迭代中可以归并的类别的最多对数");
            }
            else if (sender == labelI)
            {
                toolTip.SetToolTip((Control)sender, "允许迭代的最多次数");
            }
            else if (sender == colorButton)
            {
                toolTip.SetToolTip((Control)sender, "选择颜色");
            }
            else if (sender == reLoadButton)
            {
                toolTip.SetToolTip((Control)sender, "初始化参数并重新加载样本");
            }
            else if (sender == multiClassButton)
            {
                toolTip.SetToolTip((Control)sender, "将最新生成的分类图像分视图显示");
            }
            else if (sender == mergeButton)
            {
                toolTip.SetToolTip((Control)sender, "将最新产生的分视图显示的图片合成");
            }
            else if (sender == okButton)
            {
                toolTip.SetToolTip((Control)sender, "将本页结果传输至主窗口");
            }
            else
            {
                toolTip.SetToolTip((Control)sender, ((Control)sender).Text);
            }
        }

        private void NumKeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
            {
                activityColor = Color.FromArgb((int)Rnum.Value, (int)Gnum.Value, (int)Bnum.Value);
                colorButton.BackColor = activityColor;
                for (int i = 0; i < multiClassIndexsInTableControl.Count; i++)
                {
                    if (tabControl1.SelectedIndex == multiClassIndexsInTableControl[i])
                    {
                        pictureBoxList[tabControl1.SelectedIndex].Image = GetClusterImage(clusterList[i], activityColor);
                        colorOfEachPage[tabControl1.SelectedIndex] = activityColor;
                    }
                }
            }
        }
    }
}
