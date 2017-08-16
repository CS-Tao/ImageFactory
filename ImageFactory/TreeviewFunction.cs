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
        /// <summary>  
        /// IconIndexs类 对应ImageList中5张图片的序列  
        /// </summary>  
        private class IconIndexes
        {
            public const int MyComputer = 0;      //我的电脑  
            public const int ClosedFolder = 1;    //文件夹关闭  
            public const int OpenFolder = 2;      //文件夹打开  
            public const int FixedDrive = 3;      //磁盘盘符  
            public const int Upan = 4;      //磁盘盘符  
            public const int MyDocuments = 5;     //桌面  
            public const int TXTFile = 6;     //文本文件
            public const int ImgFile = 7;     //图像文件
            public const int MusicFile = 8;     //音频文件
            public const int VideoFile = 9;     //视频文件
            public const int File = 10;     //普通文件
        }

        /// <summary>  
        /// 在结点展开后发生 展开子结点  
        /// </summary>  
        private void directoryTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();
        }

        /// <summary>  
        /// 在将要展开结点时发生 加载子结点  
        /// </summary>  
        private void directoryTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.ImageIndex == IconIndexes.ClosedFolder || e.Node.ImageIndex == IconIndexes.MyComputer || e.Node.ImageIndex == IconIndexes.MyDocuments || e.Node.ImageIndex == IconIndexes.FixedDrive || e.Node.ImageIndex == IconIndexes.Upan || e.Node.ImageIndex == IconIndexes.OpenFolder)
                TreeAdd(e.Node);
        }

        /// <summary>  
        /// 自定义类TreeViewItems 调用其Add(TreeNode e)方法加载子目录  
        /// </summary>  
            public void TreeAdd(TreeNode e)
            {
                //try..catch异常处理  
                try
                {
                    //判断"我的电脑"Tag 上面加载的该结点没指定其路径  
                    if (e.Tag.ToString() != "我的电脑")
                    {
                        e.Nodes.Clear();                               //清除空节点再加载子节点  
                        TreeNode tNode = e;                            //获取选中\展开\折叠结点  
                        string path = tNode.Name;                      //路径    

                        //获取"我的文档"路径  
                        if (e.Tag.ToString() == "桌面")
                        {
                            path = Environment.GetFolderPath           //获取计算机我的文档文件夹  
                                                    (Environment.SpecialFolder.Desktop);
                        }
                        
                        if(tNode.ImageIndex == IconIndexes.ClosedFolder)
                            tNode.ImageIndex = IconIndexes.OpenFolder;       //获取节点显示图片 
                        

                        //获取指定目录中的子目录名称并加载结点  
                        string[] dics = Directory.GetDirectories(path);
                        foreach (string dic in dics)
                        {
                            TreeNode subNode = new TreeNode(new DirectoryInfo(dic).Name); //实例化  
                            subNode.Name = new DirectoryInfo(dic).FullName;               //完整目录  
                            subNode.Tag = subNode.Name;
                            subNode.ImageIndex = IconIndexes.ClosedFolder;       //获取节点显示图片  
                            subNode.SelectedImageIndex = IconIndexes.ClosedFolder; //选择节点显示图片  
                            tNode.Nodes.Add(subNode);
                            subNode.Nodes.Add("");                               //加载空节点 实现+号  
                        }
                        
                        //获取指定目录中的文件名称并加载结点  
                        string[] files = Directory.GetFiles(path);
                        foreach (string dic in files)
                        {
                            TreeNode subNode = new TreeNode(new DirectoryInfo(dic).Name); //实例化  
                            subNode.Name = new DirectoryInfo(dic).FullName;               //完整目录  
                            subNode.Tag = subNode.Name;
                            if (subNode.Name.EndsWith(".txt"))
                            {
                                subNode.ImageIndex = IconIndexes.TXTFile;       //获取节点显示图片  
                                subNode.SelectedImageIndex = IconIndexes.TXTFile; //选择节点显示图片  
                            }
                            else if (subNode.Name.EndsWith(".bmp") || subNode.Name.EndsWith(".tif") || subNode.Name.EndsWith(".jpg") || subNode.Name.EndsWith(".jpeg") || subNode.Name.EndsWith(".png") || subNode.Name.EndsWith(".BMP") || subNode.Name.EndsWith(".TIF") || subNode.Name.EndsWith(".JPG") || subNode.Name.EndsWith(".JPEG") || subNode.Name.EndsWith(".PNG"))
                            {
                                subNode.ImageIndex = IconIndexes.ImgFile;       //获取节点显示图片  
                                subNode.SelectedImageIndex = IconIndexes.ImgFile; //选择节点显示图片  
                            }
                            else if (subNode.Name.EndsWith(".mp3") || subNode.Name.EndsWith(".wav"))
                            {
                                subNode.ImageIndex = IconIndexes.MusicFile;       //获取节点显示图片  
                                subNode.SelectedImageIndex = IconIndexes.MusicFile; //选择节点显示图片  
                            }
                            else if (subNode.Name.EndsWith(".mp4") || subNode.Name.EndsWith(".rmvb") || subNode.Name.EndsWith(".kmv") || subNode.Name.EndsWith(".avi"))
                            {
                                subNode.ImageIndex = IconIndexes.VideoFile;       //获取节点显示图片  
                                subNode.SelectedImageIndex = IconIndexes.VideoFile; //选择节点显示图片  
                            }
                            else
                            {
                                subNode.ImageIndex = IconIndexes.File;       //获取节点显示图片  
                                subNode.SelectedImageIndex = IconIndexes.File; //选择节点显示图片
                            }
                            tNode.Nodes.Add(subNode);
                            //subNode.Nodes.Add("");                               //加载空节点 实现+号  
                        }
                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    InitTreeview();
                }
            
        }

        private void directoryTree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageIndex == IconIndexes.OpenFolder)
                e.Node.ImageIndex = IconIndexes.ClosedFolder;       //获取节点显示图片
            if(e.Node.ImageIndex != IconIndexes.MyComputer)
            {
                e.Node.Nodes.Clear();
                e.Node.Nodes.Add("");
            }
        }

        private void TreeDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode Node = treeView1.GetNodeAt(e.X, e.Y);
            if (Node.Nodes.Count == 0)
            {
                if (Node.ImageIndex == IconIndexes.ImgFile)
                {
                    CreateTabPage(Path.GetFileName(Node.Name), Image.FromFile(Node.Name));
                    ShowLog("打开文件：" + Path.GetFileName(Node.Name));
                }
                else if (Node.ImageIndex == IconIndexes.TXTFile)
                {
                    StreamReader sr = new StreamReader(Node.Name, Encoding.UTF8);
                    string content = "【" + Path.GetFileName(Node.Name) + "】内容：\r\n" + sr.ReadToEnd() + "\r\n【" + Path.GetFileName(Node.Name) + "】内容结束";
                    ShowLog(content);
                    sr.Close();
                }
                else
                {
                    ShowRedLog("本软件不支持打开该文件");
                }
            }
        }

        private void InitTreeview()
        {
            //实例化TreeNode类 TreeNode(string text,int imageIndex,int selectImageIndex)         
            this.treeView1.Nodes.Clear();
            rootNode = new TreeNode("我的电脑",
        IconIndexes.MyComputer, IconIndexes.MyComputer);  //载入显示 选择显示  
            rootNode.Tag = "我的电脑";                            //树节点数据  
            rootNode.Text = "我的电脑";                           //树节点标签内容  
            this.treeView1.Nodes.Add(rootNode);               //树中添加根目录  

            //显示MyDocuments(我的文档)结点  
            var deskTop = Environment.GetFolderPath           //获取计算机我的文档文件夹  
                (Environment.SpecialFolder.Desktop);
            TreeNode DocNode = new TreeNode(deskTop);
            DocNode.Tag = "桌面";                            //设置结点名称  
            DocNode.Text = "桌面";
            DocNode.ImageIndex = IconIndexes.MyDocuments;         //设置获取结点显示图片  
            DocNode.SelectedImageIndex = IconIndexes.MyDocuments; //设置选择显示图片  
            rootNode.Nodes.Add(DocNode);                          //rootNode目录下加载节点  
            DocNode.Nodes.Add("");

            //循环遍历计算机所有逻辑驱动器名称(盘符)  
            foreach (string drive in Environment.GetLogicalDrives())
            {
                //实例化DriveInfo对象 命名空间System.IO  
                var dir = new DriveInfo(drive);
                switch (dir.DriveType)           //判断驱动器类型  
                {
                    case DriveType.Fixed:        //仅取固定磁盘盘符 Removable-U盘   
                        {
                            //Split仅获取盘符字母  
                            TreeNode tNode = new TreeNode(dir.Name.Split(':')[0]);
                            tNode.Name = dir.Name;
                            tNode.Tag = tNode.Name;
                            tNode.ImageIndex = IconIndexes.FixedDrive;         //获取结点显示图片  
                            tNode.SelectedImageIndex = IconIndexes.FixedDrive; //选择显示图片  
                            rootNode.Nodes.Add(tNode);                    //加载驱动节点  
                            tNode.Nodes.Add("");
                            break;
                        }
                    case DriveType.Removable:
                        {
                            //Split仅获取盘符字母  
                            TreeNode tNode = new TreeNode(dir.Name.Split(':')[0]);
                            tNode.Name = dir.Name;
                            tNode.Tag = tNode.Name;
                            tNode.ImageIndex = IconIndexes.Upan;         //获取结点显示图片  
                            tNode.SelectedImageIndex = IconIndexes.Upan ; //选择显示图片  
                            rootNode.Nodes.Add(tNode);                    //加载驱动节点  
                            tNode.Nodes.Add("");
                            break;
                        }
                }
            }
            rootNode.Expand();                  //展开树状视图 
        }
    }
}
