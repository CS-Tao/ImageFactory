namespace ImageFactory
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.关闭本页ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseOtherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭所有ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewVisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.合成RGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.多通道转单通道ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像模糊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像锐化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.边缘检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.影像分类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ImageCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.锁定窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.切换窗口样式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于本软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logText = new System.Windows.Forms.RichTextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.directoryIcons = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolnewfile = new System.Windows.Forms.ToolStripButton();
            this.toolopenfile = new System.Windows.Forms.ToolStripButton();
            this.toolsavefile = new System.Windows.Forms.ToolStripButton();
            this.toolsavefileas = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolmergeColor = new System.Windows.Forms.ToolStripButton();
            this.toolgray = new System.Windows.Forms.ToolStripButton();
            this.toolSfilter = new System.Windows.Forms.ToolStripButton();
            this.toolmohu = new System.Windows.Forms.ToolStripButton();
            this.toolSharp = new System.Windows.Forms.ToolStripButton();
            this.tooledge = new System.Windows.Forms.ToolStripButton();
            this.toolclassfiy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.VisionToolStripMenuItem,
            this.ToolToolStripMenuItem,
            this.WindowToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(784, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.toolStripSeparator1,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.toolStripSeparator5,
            this.关闭本页ToolStripMenuItem,
            this.CloseOtherToolStripMenuItem,
            this.关闭所有ToolStripMenuItem,
            this.toolStripSeparator2,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.FileToolStripMenuItem.Text = "文件";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.OpenToolStripMenuItem.Text = "打开";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.SaveToolStripMenuItem.Text = "保存";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.SaveAsToolStripMenuItem.Text = "另存为";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(190, 6);
            // 
            // 关闭本页ToolStripMenuItem
            // 
            this.关闭本页ToolStripMenuItem.Name = "关闭本页ToolStripMenuItem";
            this.关闭本页ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.关闭本页ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.关闭本页ToolStripMenuItem.Text = "关闭本页";
            this.关闭本页ToolStripMenuItem.Click += new System.EventHandler(this.关闭本页ToolStripMenuItem_Click);
            // 
            // CloseOtherToolStripMenuItem
            // 
            this.CloseOtherToolStripMenuItem.Name = "CloseOtherToolStripMenuItem";
            this.CloseOtherToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.CloseOtherToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.CloseOtherToolStripMenuItem.Text = "关闭其他页";
            this.CloseOtherToolStripMenuItem.Click += new System.EventHandler(this.CloseOtherToolStripMenuItem_Click);
            // 
            // 关闭所有ToolStripMenuItem
            // 
            this.关闭所有ToolStripMenuItem.Name = "关闭所有ToolStripMenuItem";
            this.关闭所有ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.关闭所有ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.关闭所有ToolStripMenuItem.Text = "关闭所有";
            this.关闭所有ToolStripMenuItem.Click += new System.EventHandler(this.关闭所有ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.ExitToolStripMenuItem.Text = "退出";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PropertyToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.EditToolStripMenuItem.Text = "编辑";
            // 
            // PropertyToolStripMenuItem
            // 
            this.PropertyToolStripMenuItem.Name = "PropertyToolStripMenuItem";
            this.PropertyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.PropertyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.PropertyToolStripMenuItem.Text = "属性";
            this.PropertyToolStripMenuItem.Click += new System.EventHandler(this.PropertyToolStripMenuItem_Click);
            // 
            // VisionToolStripMenuItem
            // 
            this.VisionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewVisionToolStripMenuItem,
            this.toolStripSeparator3,
            this.MaxToolStripMenuItem,
            this.MinToolStripMenuItem,
            this.清空日志ToolStripMenuItem,
            this.更新ToolStripMenuItem});
            this.VisionToolStripMenuItem.Name = "VisionToolStripMenuItem";
            this.VisionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.VisionToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.VisionToolStripMenuItem.Text = "视图";
            // 
            // NewVisionToolStripMenuItem
            // 
            this.NewVisionToolStripMenuItem.Name = "NewVisionToolStripMenuItem";
            this.NewVisionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.NewVisionToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.NewVisionToolStripMenuItem.Text = "打开新视图";
            this.NewVisionToolStripMenuItem.Click += new System.EventHandler(this.NewVisionToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(227, 6);
            // 
            // MaxToolStripMenuItem
            // 
            this.MaxToolStripMenuItem.Name = "MaxToolStripMenuItem";
            this.MaxToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.MaxToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.MaxToolStripMenuItem.Text = "最大化";
            this.MaxToolStripMenuItem.Click += new System.EventHandler(this.MaxToolStripMenuItem_Click);
            // 
            // MinToolStripMenuItem
            // 
            this.MinToolStripMenuItem.Name = "MinToolStripMenuItem";
            this.MinToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.MinToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.MinToolStripMenuItem.Text = "最小化";
            this.MinToolStripMenuItem.Click += new System.EventHandler(this.MinToolStripMenuItem_Click);
            // 
            // 清空日志ToolStripMenuItem
            // 
            this.清空日志ToolStripMenuItem.Name = "清空日志ToolStripMenuItem";
            this.清空日志ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.清空日志ToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.清空日志ToolStripMenuItem.Text = "清空日志";
            this.清空日志ToolStripMenuItem.Click += new System.EventHandler(this.清空日志ToolStripMenuItem_Click);
            // 
            // 更新ToolStripMenuItem
            // 
            this.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem";
            this.更新ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.更新ToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.更新ToolStripMenuItem.Text = "更新文件资源管理器";
            this.更新ToolStripMenuItem.Click += new System.EventHandler(this.更新ToolStripMenuItem_Click);
            // 
            // ToolToolStripMenuItem
            // 
            this.ToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImageProcessToolStripMenuItem,
            this.toolStripSeparator4,
            this.ImageCutToolStripMenuItem});
            this.ToolToolStripMenuItem.Name = "ToolToolStripMenuItem";
            this.ToolToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.ToolToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.ToolToolStripMenuItem.Text = "工具";
            // 
            // ImageProcessToolStripMenuItem
            // 
            this.ImageProcessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.合成RGBToolStripMenuItem,
            this.多通道转单通道ToolStripMenuItem,
            this.图像滤波ToolStripMenuItem,
            this.图像模糊ToolStripMenuItem,
            this.图像锐化ToolStripMenuItem,
            this.边缘检测ToolStripMenuItem,
            this.影像分类ToolStripMenuItem});
            this.ImageProcessToolStripMenuItem.Name = "ImageProcessToolStripMenuItem";
            this.ImageProcessToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.ImageProcessToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.ImageProcessToolStripMenuItem.Text = "图像处理";
            // 
            // 合成RGBToolStripMenuItem
            // 
            this.合成RGBToolStripMenuItem.Name = "合成RGBToolStripMenuItem";
            this.合成RGBToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.合成RGBToolStripMenuItem.Text = "生成彩色图";
            this.合成RGBToolStripMenuItem.Click += new System.EventHandler(this.合成RGBToolStripMenuItem_Click);
            // 
            // 多通道转单通道ToolStripMenuItem
            // 
            this.多通道转单通道ToolStripMenuItem.Name = "多通道转单通道ToolStripMenuItem";
            this.多通道转单通道ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.多通道转单通道ToolStripMenuItem.Text = "生成灰度图";
            this.多通道转单通道ToolStripMenuItem.Click += new System.EventHandler(this.多通道转单通道ToolStripMenuItem_Click);
            // 
            // 图像滤波ToolStripMenuItem
            // 
            this.图像滤波ToolStripMenuItem.Name = "图像滤波ToolStripMenuItem";
            this.图像滤波ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.图像滤波ToolStripMenuItem.Text = "图像滤波";
            this.图像滤波ToolStripMenuItem.Click += new System.EventHandler(this.图像滤波ToolStripMenuItem_Click);
            // 
            // 图像模糊ToolStripMenuItem
            // 
            this.图像模糊ToolStripMenuItem.Name = "图像模糊ToolStripMenuItem";
            this.图像模糊ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.图像模糊ToolStripMenuItem.Text = "图像模糊";
            this.图像模糊ToolStripMenuItem.Click += new System.EventHandler(this.图像模糊ToolStripMenuItem_Click);
            // 
            // 图像锐化ToolStripMenuItem
            // 
            this.图像锐化ToolStripMenuItem.Name = "图像锐化ToolStripMenuItem";
            this.图像锐化ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.图像锐化ToolStripMenuItem.Text = "图像锐化";
            this.图像锐化ToolStripMenuItem.Click += new System.EventHandler(this.图像锐化ToolStripMenuItem_Click);
            // 
            // 边缘检测ToolStripMenuItem
            // 
            this.边缘检测ToolStripMenuItem.Name = "边缘检测ToolStripMenuItem";
            this.边缘检测ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.边缘检测ToolStripMenuItem.Text = "边缘检测";
            this.边缘检测ToolStripMenuItem.Click += new System.EventHandler(this.边缘检测ToolStripMenuItem_Click);
            // 
            // 影像分类ToolStripMenuItem
            // 
            this.影像分类ToolStripMenuItem.Name = "影像分类ToolStripMenuItem";
            this.影像分类ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.影像分类ToolStripMenuItem.Text = "影像分类";
            this.影像分类ToolStripMenuItem.Click += new System.EventHandler(this.影像分类ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(200, 6);
            // 
            // ImageCutToolStripMenuItem
            // 
            this.ImageCutToolStripMenuItem.Name = "ImageCutToolStripMenuItem";
            this.ImageCutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.ImageCutToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.ImageCutToolStripMenuItem.Text = "图片裁剪";
            this.ImageCutToolStripMenuItem.Click += new System.EventHandler(this.ImageCutToolStripMenuItem_Click);
            // 
            // WindowToolStripMenuItem
            // 
            this.WindowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.锁定窗口ToolStripMenuItem,
            this.切换窗口样式ToolStripMenuItem});
            this.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem";
            this.WindowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.W)));
            this.WindowToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.WindowToolStripMenuItem.Text = "窗口";
            // 
            // 锁定窗口ToolStripMenuItem
            // 
            this.锁定窗口ToolStripMenuItem.Name = "锁定窗口ToolStripMenuItem";
            this.锁定窗口ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.锁定窗口ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.锁定窗口ToolStripMenuItem.Text = "锁定窗口";
            this.锁定窗口ToolStripMenuItem.Click += new System.EventHandler(this.锁定窗口ToolStripMenuItem_Click);
            // 
            // 切换窗口样式ToolStripMenuItem
            // 
            this.切换窗口样式ToolStripMenuItem.Name = "切换窗口样式ToolStripMenuItem";
            this.切换窗口样式ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.切换窗口样式ToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.切换窗口样式ToolStripMenuItem.Text = "切换窗口样式";
            this.切换窗口样式ToolStripMenuItem.Click += new System.EventHandler(this.切换窗口样式ToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看帮助ToolStripMenuItem,
            this.关于本软件ToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.HelpToolStripMenuItem.Text = "帮助";
            // 
            // 查看帮助ToolStripMenuItem
            // 
            this.查看帮助ToolStripMenuItem.Name = "查看帮助ToolStripMenuItem";
            this.查看帮助ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.查看帮助ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.查看帮助ToolStripMenuItem.Text = "查看帮助";
            this.查看帮助ToolStripMenuItem.Click += new System.EventHandler(this.查看帮助ToolStripMenuItem_Click);
            // 
            // 关于本软件ToolStripMenuItem
            // 
            this.关于本软件ToolStripMenuItem.Name = "关于本软件ToolStripMenuItem";
            this.关于本软件ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.关于本软件ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.关于本软件ToolStripMenuItem.Text = "关于本软件";
            this.关于本软件ToolStripMenuItem.Click += new System.EventHandler(this.关于本软件ToolStripMenuItem_Click);
            // 
            // logText
            // 
            this.logText.BackColor = System.Drawing.SystemColors.Window;
            this.logText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logText.Location = new System.Drawing.Point(150, 459);
            this.logText.Margin = new System.Windows.Forms.Padding(0);
            this.logText.Name = "logText";
            this.logText.ReadOnly = true;
            this.logText.Size = new System.Drawing.Size(634, 80);
            this.logText.TabIndex = 5;
            this.logText.Text = "";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Window;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.directoryIcons;
            this.treeView1.Indent = 20;
            this.treeView1.Location = new System.Drawing.Point(0, 50);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(150, 489);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.directoryTree_AfterCollapse);
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.directoryTree_BeforeExpand);
            this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.directoryTree_AfterExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TreeDoubleClick);
            // 
            // directoryIcons
            // 
            this.directoryIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("directoryIcons.ImageStream")));
            this.directoryIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.directoryIcons.Images.SetKeyName(0, "Computer.ico");
            this.directoryIcons.Images.SetKeyName(1, "Close Folder.ico");
            this.directoryIcons.Images.SetKeyName(2, "Open Folder.ico");
            this.directoryIcons.Images.SetKeyName(3, "fixed Drive.ico");
            this.directoryIcons.Images.SetKeyName(4, "Upan.ico");
            this.directoryIcons.Images.SetKeyName(5, "DeskTop.ico");
            this.directoryIcons.Images.SetKeyName(6, "TXT.ico");
            this.directoryIcons.Images.SetKeyName(7, "Image.ico");
            this.directoryIcons.Images.SetKeyName(8, "Music.ico");
            this.directoryIcons.Images.SetKeyName(9, "Video.ico");
            this.directoryIcons.Images.SetKeyName(10, "file.ico");
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(150, 456);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(634, 3);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitterMoved);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(150, 50);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 406);
            this.splitter2.TabIndex = 6;
            this.splitter2.TabStop = false;
            this.splitter2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitterMoved);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(33, 17);
            this.toolStripStatusLabel1.Text = "time";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(150, 16);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(584, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(153, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(631, 406);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControlIndexChanged);
            this.tabControl1.DragDrop += new System.Windows.Forms.DragEventHandler(this.tabcontrolDragDrop);
            this.tabControl1.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabcontrolDragEnter);
            this.tabControl1.DoubleClick += new System.EventHandler(this.TabContralDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolnewfile,
            this.toolopenfile,
            this.toolsavefile,
            this.toolsavefileas,
            this.toolStripSeparator6,
            this.toolStripSeparator7,
            this.toolmergeColor,
            this.toolgray,
            this.toolSfilter,
            this.toolmohu,
            this.toolSharp,
            this.tooledge,
            this.toolclassfiy,
            this.toolStripSeparator8,
            this.toolStripSeparator9});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolnewfile
            // 
            this.toolnewfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolnewfile.Image = ((System.Drawing.Image)(resources.GetObject("toolnewfile.Image")));
            this.toolnewfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolnewfile.Name = "toolnewfile";
            this.toolnewfile.Size = new System.Drawing.Size(23, 22);
            this.toolnewfile.Text = "toolStripButton3";
            this.toolnewfile.ToolTipText = "新建页面";
            this.toolnewfile.Click += new System.EventHandler(this.toolnewfile_Click);
            // 
            // toolopenfile
            // 
            this.toolopenfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolopenfile.Image = ((System.Drawing.Image)(resources.GetObject("toolopenfile.Image")));
            this.toolopenfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolopenfile.Name = "toolopenfile";
            this.toolopenfile.Size = new System.Drawing.Size(23, 22);
            this.toolopenfile.Text = "toolStripButton2";
            this.toolopenfile.ToolTipText = "打开图片";
            this.toolopenfile.Click += new System.EventHandler(this.toolopenfile_Click);
            // 
            // toolsavefile
            // 
            this.toolsavefile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolsavefile.Image = ((System.Drawing.Image)(resources.GetObject("toolsavefile.Image")));
            this.toolsavefile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsavefile.Name = "toolsavefile";
            this.toolsavefile.Size = new System.Drawing.Size(23, 22);
            this.toolsavefile.Text = "toolStripButton4";
            this.toolsavefile.ToolTipText = "保存本页";
            this.toolsavefile.Click += new System.EventHandler(this.toolsavefile_Click);
            // 
            // toolsavefileas
            // 
            this.toolsavefileas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolsavefileas.Image = ((System.Drawing.Image)(resources.GetObject("toolsavefileas.Image")));
            this.toolsavefileas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsavefileas.Name = "toolsavefileas";
            this.toolsavefileas.Size = new System.Drawing.Size(23, 22);
            this.toolsavefileas.Text = "toolStripButton1";
            this.toolsavefileas.ToolTipText = "将本页另存为";
            this.toolsavefileas.Click += new System.EventHandler(this.toolsavefileas_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolmergeColor
            // 
            this.toolmergeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolmergeColor.Image = ((System.Drawing.Image)(resources.GetObject("toolmergeColor.Image")));
            this.toolmergeColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolmergeColor.Name = "toolmergeColor";
            this.toolmergeColor.Size = new System.Drawing.Size(23, 22);
            this.toolmergeColor.Text = "toolStripButton1";
            this.toolmergeColor.ToolTipText = "彩色合成";
            this.toolmergeColor.Click += new System.EventHandler(this.toolmergeColor_Click);
            // 
            // toolgray
            // 
            this.toolgray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolgray.Image = ((System.Drawing.Image)(resources.GetObject("toolgray.Image")));
            this.toolgray.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolgray.Name = "toolgray";
            this.toolgray.Size = new System.Drawing.Size(23, 22);
            this.toolgray.Text = "toolStripButton2";
            this.toolgray.ToolTipText = "灰度化";
            this.toolgray.Click += new System.EventHandler(this.toolgray_Click);
            // 
            // toolSfilter
            // 
            this.toolSfilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSfilter.Image = ((System.Drawing.Image)(resources.GetObject("toolSfilter.Image")));
            this.toolSfilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSfilter.Name = "toolSfilter";
            this.toolSfilter.Size = new System.Drawing.Size(23, 22);
            this.toolSfilter.Text = "toolStripButton3";
            this.toolSfilter.ToolTipText = "滤波";
            this.toolSfilter.Click += new System.EventHandler(this.toolSfilter_Click);
            // 
            // toolmohu
            // 
            this.toolmohu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolmohu.Image = ((System.Drawing.Image)(resources.GetObject("toolmohu.Image")));
            this.toolmohu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolmohu.Name = "toolmohu";
            this.toolmohu.Size = new System.Drawing.Size(23, 22);
            this.toolmohu.Text = "toolStripButton5";
            this.toolmohu.ToolTipText = "图像模糊";
            this.toolmohu.Click += new System.EventHandler(this.toolmohu_Click);
            // 
            // toolSharp
            // 
            this.toolSharp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSharp.Image = ((System.Drawing.Image)(resources.GetObject("toolSharp.Image")));
            this.toolSharp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSharp.Name = "toolSharp";
            this.toolSharp.Size = new System.Drawing.Size(23, 22);
            this.toolSharp.Text = "toolStripButton4";
            this.toolSharp.ToolTipText = "图像锐化";
            this.toolSharp.Click += new System.EventHandler(this.toolSharp_Click);
            // 
            // tooledge
            // 
            this.tooledge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tooledge.Image = ((System.Drawing.Image)(resources.GetObject("tooledge.Image")));
            this.tooledge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tooledge.Name = "tooledge";
            this.tooledge.Size = new System.Drawing.Size(23, 22);
            this.tooledge.Text = "toolStripButton6";
            this.tooledge.ToolTipText = "边缘检测";
            this.tooledge.Click += new System.EventHandler(this.tooledge_Click);
            // 
            // toolclassfiy
            // 
            this.toolclassfiy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolclassfiy.Image = ((System.Drawing.Image)(resources.GetObject("toolclassfiy.Image")));
            this.toolclassfiy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolclassfiy.Name = "toolclassfiy";
            this.toolclassfiy.Size = new System.Drawing.Size(23, 22);
            this.toolclassfiy.Text = "toolStripButton1";
            this.toolclassfiy.ToolTipText = "影像分类";
            this.toolclassfiy.Click += new System.EventHandler(this.toolclassfiy_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.logText);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageFactory";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainFormSizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.RichTextBox logText;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PropertyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewVisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像模糊ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像锐化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 边缘检测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageCutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于本软件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 影像分类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 多通道转单通道ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 合成RGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像滤波ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 关闭本页ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭所有ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 锁定窗口ToolStripMenuItem;
        private System.Windows.Forms.ImageList directoryIcons;
        private System.Windows.Forms.ToolStripMenuItem 清空日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolnewfile;
        private System.Windows.Forms.ToolStripButton toolopenfile;
        private System.Windows.Forms.ToolStripButton toolsavefile;
        private System.Windows.Forms.ToolStripButton toolsavefileas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolmergeColor;
        private System.Windows.Forms.ToolStripButton toolgray;
        private System.Windows.Forms.ToolStripButton toolSfilter;
        private System.Windows.Forms.ToolStripButton toolmohu;
        private System.Windows.Forms.ToolStripButton toolSharp;
        private System.Windows.Forms.ToolStripButton tooledge;
        private System.Windows.Forms.ToolStripButton toolclassfiy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem 切换窗口样式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseOtherToolStripMenuItem;
    }
}

