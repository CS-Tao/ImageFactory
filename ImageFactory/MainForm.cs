using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFactory
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            SplashScreen.ShowSplashScreen();

            System.Threading.Thread.Sleep(1000);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //环境参数
            try
            {
                for (int i = 1; i < Environment.GetCommandLineArgs().Length; i++)
                {
                    Bitmap bitMap = new Bitmap(Environment.GetCommandLineArgs()[i]);
                    CreateTabPage(Path.GetFileName(Environment.GetCommandLineArgs()[i]), bitMap);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
            toolStripProgressBar1.Visible = false;
            this.toolStripStatusLabel1.Text = "系统当前时间：" + DateTime.Now.ToString();
            this.timer1.Interval = 1000;
            this.timer1.Start();

            InitTreeview();
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.Yes != MessageBox.Show("确认退出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                e.Cancel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "系统当前时间：" + DateTime.Now.ToString("");

            //关闭启动画面
            if (SplashScreen.Instance != null)
            {
                SplashScreen.Instance.Invoke(new MethodInvoker(SplashScreen.Instance.Dispose));
                SplashScreen.Instance = null;
            }
        }

        private void SplitterMoved(object sender, SplitterEventArgs e)
        {
            for (int i = 0; i < panelList.Count; i++)
            {
                panelList[i].Size = tabControl1.Size;
                pictureBoxList[i].Size = tabControl1.Size;
                pictureBoxList[i].Refresh();
            }
        }

        private void MainFormSizeChanged(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                treeView1.Width = 200;
                logText.Height = 100;
            }
            else if(this.WindowState == FormWindowState.Normal)
            {
                treeView1.Width = 150;
                logText.Height = 80;
            }
            for (int i = 0; i < panelList.Count; i++)
            {
                panelList[i].Size = tabControl1.Size;
                pictureBoxList[i].Size = tabControl1.Size;
                pictureBoxList[i].Refresh();
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Filter = "all|*.*|bmp|*.bmp|tif|*.tif|jpg|*.jpg|jpeg|*.jpeg|png|*.png";
            if (DialogResult.OK == dlg.ShowDialog())
            {
                for (int i = 0; i < dlg.FileNames.Length; i++)
                {
                    try
                    {
                        CreateTabPage(Path.GetFileName(dlg.FileNames[i]), new Bitmap(dlg.FileNames[i]));
                        ShowLog("打开文件：" + Path.GetFileName(dlg.FileNames[i]));
                    }
                    catch(Exception ex)
                    {
                        ShowRedLog("无法打开文件:" + dlg.FileNames[i]);
                    }
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(pictureBoxList.Count == 0)
            {
                ShowRedLog("无可保存的文件！");
                return;
            }
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "bmp|*.bmp|tif|*.tif|jpg|*.jpg|jpeg|*.jpeg|png|*.png|all|*.*";
            //savefile.FilterIndex = 2;
            savefile.RestoreDirectory = true;
            savefile.FileName = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                activityPictureBox.Image.Save(savefile.FileName);
                ShowLog("文件保存成功！");
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToolStripMenuItem_Click(null, null);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 影像分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 0)
            {
                ShowRedLog("无可供处理的图片！");
                return;
            }
            if (tabControl1.TabPages.Count > 10)
            {
                ShowRedLog("使用此功能前，请将打开的图片数减少到10以下！");
                return;
            }

            PreClassifyForm preClassifyForm = new PreClassifyForm(this, tabControl1);
            if(DialogResult.OK == preClassifyForm.ShowDialog())
            {
                if(preClassifyForm.indexOfSelectedList.Count == 0)
                {
                    ShowRedLog("未选择图片！");
                    return;
                }
                List<Bitmap> tempBitmapList = new List<Bitmap>();
                int w = ((Bitmap)pictureBoxList[preClassifyForm.indexOfSelectedList[0]].Image).Width;
                int h = ((Bitmap)pictureBoxList[preClassifyForm.indexOfSelectedList[0]].Image).Height;
                for (int i = 0; i < preClassifyForm.indexOfSelectedList.Count; i++)
                {
                    if(((Bitmap)pictureBoxList[preClassifyForm.indexOfSelectedList[i]].Image).Width != w || ((Bitmap)pictureBoxList[preClassifyForm.indexOfSelectedList[i]].Image).Height != h)
                    {
                        ShowRedLog("图片大小不一致！");
                        return;
                    }
                    tempBitmapList.Add(new Bitmap(pictureBoxList[preClassifyForm.indexOfSelectedList[i]].Image));
                }

                ClassifyForm classifyForm = new ClassifyForm(this, tempBitmapList);
                classifyForm.Show();
            }

        }

        private void MaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void MinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string helpStr = "暂无帮助";
            MessageBox.Show(helpStr, "帮助", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 关于本软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string helpStr = "Software：ImageFactory\r\nVersion：1.0.0.0\r\nCopyright ©  2017 CS·Tao RS WHU. All Rights Reserved.";
            MessageBox.Show(helpStr, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private delegate void delegateShowProgress(bool show);

        private void dShowProgress(bool show)
        {
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

        private void ImageCutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(pictureBoxList.Count == 0)
            {
                ShowRedLog("无供裁剪的图片");
                return;
            }
            GetTwoPointForm dlg = new GetTwoPointForm(this, cutX1, cutX2, cutY1, cutY2, activityPictureBox.Image.Width, activityPictureBox.Image.Height);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            if (dlg.cutX1 >= dlg.cutX2 || dlg.cutY1 >= dlg.cutY2)
            {
                ShowRedLog("参数错误");
                return;
            }
            cutX1 = dlg.cutX1;
            cutX2 = dlg.cutX2;
            cutY1 = dlg.cutY1;
            cutY2 = dlg.cutY2;
            string name = tabControl1.TabPages[tabControl1.SelectedIndex].Text + "[(" + cutX1 + "," + cutY1 + "),(" + cutX2 + "," + cutX2 + ")]";
            CreateTabPage(name, CutImage(new Bitmap(activityPictureBox.Image), cutX1,cutY1,cutX2,cutY2));
            ShowLog("图片裁剪完毕");
        }

        private void 图像模糊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBoxList.Count == 0)
            {
                ShowRedLog("无可供处理的图片！");
                return;
            }
            GetDoubleForm getDoubleForm = new GetDoubleForm(this, GuassScale, 10, 0);
            if (DialogResult.OK != getDoubleForm.ShowDialog())
                return;
            CreateTabPage("模糊处理(" + tabControl1.TabPages[tabControl1.SelectedIndex].Text + ")", GuassBlur(new Bitmap(activityPictureBox.Image), /* new double[,] { { 0.0947416, 0.118318, 0.0947416 }, { 0.118318, 0.147761, 0.1118318 }, { 0.0947416, 0.118318, 0.0947416 } }*/ getDoubleForm.num));
            ShowLog("模糊处理完毕");
        }

        private void 图像锐化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBoxList.Count == 0)
            {
                ShowRedLog("无可供处理的图片！");
                return;
            }
            CreateTabPage("锐化处理(" + tabControl1.TabPages[tabControl1.SelectedIndex].Text + ")", ImageFilter33(GetGrayImage(new Bitmap(activityPictureBox.Image)), new double[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } }));
            ShowLog("锐化处理完毕");
        }

        private void 边缘检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBoxList.Count == 0)
            {
                ShowRedLog("无可供处理的图片！");
                return;
            }
            GetIntForm getIntForm = new GetIntForm(this, edgeSenseThreshod, 10000, 10);
            if(getIntForm.ShowDialog() == DialogResult.OK)
            {
                edgeSenseThreshod = getIntForm.num;
                CreateTabPage("边缘检测(" + tabControl1.TabPages[tabControl1.SelectedIndex].Text + ")", EdgeSense(new Bitmap(activityPictureBox.Image), edgeSenseThreshod));
                ShowLog("边缘检测完成,阈值:" + edgeSenseThreshod);
            }
            
        }

        private void 多通道转单通道ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBoxList.Count == 0)
            {
                ShowRedLog("无可供处理的图片！");
                return;
            }
            CreateTabPage("灰度图(" + tabControl1.TabPages[tabControl1.SelectedIndex].Text + ")", GetGrayImage(new Bitmap(activityPictureBox.Image)));
            ShowLog("灰度图生成完毕");
        }

        private void 合成RGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count < 3)
            {
                ShowRedLog("使用此功能前，请将打开的图片数增加到3以上！");
                return;
            }
            if (tabControl1.TabPages.Count > 10)
            {
                ShowRedLog("使用此功能前，请将打开的图片数减少到10以下！");
                return;
            }

            PreMergeForm preMergeForm  = new PreMergeForm(this, tabControl1);
            if (DialogResult.OK == preMergeForm.ShowDialog())
            {
                List<Bitmap> tempBitmapList = new List<Bitmap>();
                int w = ((Bitmap)pictureBoxList[preMergeForm.indexOfChannel1].Image).Width;
                int h = ((Bitmap)pictureBoxList[preMergeForm.indexOfChannel1].Image).Height;
                if(((Bitmap)pictureBoxList[preMergeForm.indexOfChannel2].Image).Width != w || ((Bitmap)pictureBoxList[preMergeForm.indexOfChannel3].Image).Width != w || ((Bitmap)pictureBoxList[preMergeForm.indexOfChannel2].Image).Height != h || ((Bitmap)pictureBoxList[preMergeForm.indexOfChannel3].Image).Height != h)
                {
                    ShowRedLog("图片大小不符合要求");
                }
                CreateTabPage("彩色合成(" + tabControl1.TabPages[preMergeForm.indexOfChannel1].Text + "," + tabControl1.TabPages[preMergeForm.indexOfChannel2].Text + "," + tabControl1.TabPages[preMergeForm.indexOfChannel3].Text + ")", GetThreeChannelImage(new Bitmap(pictureBoxList[preMergeForm.indexOfChannel1].Image), new Bitmap(pictureBoxList[preMergeForm.indexOfChannel2].Image), new Bitmap(pictureBoxList[preMergeForm.indexOfChannel3].Image)));
                ShowLog("彩色图合成完毕");
            }
        }

        private void 图像滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBoxList.Count == 0)
            {
                ShowRedLog("无可供处理的图片！");
                return;
            }
            GetOpertor dlg = new GetOpertor(this, filter);
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            filter = dlg.filter;
            CreateTabPage("滤波(" + tabControl1.TabPages[tabControl1.SelectedIndex].Text + ")", ImageFilter33(new Bitmap(activityPictureBox.Image), filter));
            ShowLog("滤波完成");
        }

        private void PropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBoxList.Count == 0)
            {
                ShowRedLog("无可供显示属性的图片！");
                return;
            }
            MessageBox.Show("图片名称：" + tabControl1.TabPages[tabControl1.SelectedIndex].Text + "\r\n\r\n图片大小：" + activityPictureBox.Image.Width + "*" + activityPictureBox.Image.Height, "属性", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 关闭本页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBoxList.Count == 0)
            {
                ShowRedLog("无可关闭的窗口！");
                return;
            }
            pictureBoxList.RemoveAt(tabControl1.SelectedIndex);
            panelList.RemoveAt(tabControl1.SelectedIndex);
            tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
        }

        private void 关闭所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBoxList.Count == 0)
            {
                ShowRedLog("无可关闭的窗口！");
                return;
            }
            for (int i = panelList.Count - 1;i >= 0;i--)
            {
                pictureBoxList.RemoveAt(i);
                panelList.RemoveAt(i);
                tabControl1.TabPages.RemoveAt(i);
            }
        }

        private void NewVisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenToolStripMenuItem_Click(null, null);
        }

        private void 锁定窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.FormBorderStyle == FormBorderStyle.Sizable)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                splitter1.Enabled = false;
                splitter2.Enabled = false;
                锁定窗口ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.L)));
                锁定窗口ToolStripMenuItem.Text = "解锁窗口";
                ShowLog("窗口已锁定");
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.MaximizeBox = true;
                this.MinimizeBox = true;
                splitter1.Enabled = true;
                splitter2.Enabled = true;
                锁定窗口ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
                锁定窗口ToolStripMenuItem.Text = "锁定窗口";
                ShowLog("窗口已解锁");
            }
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 清空日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logText.Clear();
            MessageBox.Show("日志已清空！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitTreeview();
        }

        private void tabcontrolDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void tabcontrolDragDrop(object sender, DragEventArgs e)
        {
            string[] filePath = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in filePath)
            {
                try
                {
                    CreateTabPage(Path.GetFileName(file), new Bitmap(file));
                    ShowLog("打开文件：" + Path.GetFileName(file));
                }
                catch (Exception ex)
                {
                    ShowRedLog("无法打开:" + file);
                }
            }
        }

        private void toolnewfile_Click(object sender, EventArgs e)
        {
            OpenToolStripMenuItem_Click(null, null);
        }

        private void toolopenfile_Click(object sender, EventArgs e)
        {
            //GetFeaturePoints((Bitmap)activityPictureBox.Image);
            OpenToolStripMenuItem_Click(null, null);
        }

        private void toolsavefile_Click(object sender, EventArgs e)
        {
            SaveToolStripMenuItem_Click(null, null);
        }

        private void toolsavefileas_Click(object sender, EventArgs e)
        {
            SaveToolStripMenuItem_Click(null, null);
        }

        private void toolmergeColor_Click(object sender, EventArgs e)
        {
            合成RGBToolStripMenuItem_Click(null, null);
        }

        private void toolgray_Click(object sender, EventArgs e)
        {
            多通道转单通道ToolStripMenuItem_Click(null, null);
        }

        private void toolSfilter_Click(object sender, EventArgs e)
        {
            图像滤波ToolStripMenuItem_Click(null, null);
        }

        private void toolmohu_Click(object sender, EventArgs e)
        {
            图像模糊ToolStripMenuItem_Click(null, null);
        }

        private void toolSharp_Click(object sender, EventArgs e)
        {
            图像锐化ToolStripMenuItem_Click(null, null);
        }

        private void tooledge_Click(object sender, EventArgs e)
        {
            边缘检测ToolStripMenuItem_Click(null, null);
        }

        private void toolclassfiy_Click(object sender, EventArgs e)
        {
            影像分类ToolStripMenuItem_Click(null, null);
        }

        private void 切换窗口样式ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CloseOtherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBoxList.Count == 0)
            {
                ShowRedLog("无可关闭的窗口！");
                return;
            }
            TabPage tempPage = tabControl1.TabPages[tabControl1.SelectedIndex];
            for (int i = panelList.Count - 1; i >= 0; i--)
            {
                if(tabControl1.TabPages[i] != tempPage)
                {
                    pictureBoxList.RemoveAt(i);
                    panelList.RemoveAt(i);
                    tabControl1.TabPages.RemoveAt(i);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
