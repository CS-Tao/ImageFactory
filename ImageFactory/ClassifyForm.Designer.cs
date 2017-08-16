namespace ImageFactory
{
    partial class ClassifyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassifyForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存本页ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelK = new System.Windows.Forms.Label();
            this.Knum = new System.Windows.Forms.NumericUpDown();
            this.ThetaNnum = new System.Windows.Forms.NumericUpDown();
            this.labelTheTaN = new System.Windows.Forms.Label();
            this.ThetaSnum = new System.Windows.Forms.NumericUpDown();
            this.labelTheTaS = new System.Windows.Forms.Label();
            this.ThetaCnum = new System.Windows.Forms.NumericUpDown();
            this.labelThetaC = new System.Windows.Forms.Label();
            this.Lnum = new System.Windows.Forms.NumericUpDown();
            this.labelL = new System.Windows.Forms.Label();
            this.Inum = new System.Windows.Forms.NumericUpDown();
            this.labelI = new System.Windows.Forms.Label();
            this.IterationButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Rnum = new System.Windows.Forms.NumericUpDown();
            this.Bnum = new System.Windows.Forms.NumericUpDown();
            this.Gnum = new System.Windows.Forms.NumericUpDown();
            this.colorButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.logText = new System.Windows.Forms.RichTextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.Cnum = new System.Windows.Forms.NumericUpDown();
            this.labelC = new System.Windows.Forms.Label();
            this.multiClassButton = new System.Windows.Forms.Button();
            this.mergeButton = new System.Windows.Forms.Button();
            this.changeColorButton = new System.Windows.Forms.Button();
            this.reLoadButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Knum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThetaNnum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThetaSnum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThetaCnum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lnum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Inum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rnum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bnum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gnum)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cnum)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(52, 25);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存本页ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 保存本页ToolStripMenuItem
            // 
            this.保存本页ToolStripMenuItem.Name = "保存本页ToolStripMenuItem";
            this.保存本页ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存本页ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.保存本页ToolStripMenuItem.Text = "保存本页";
            this.保存本页ToolStripMenuItem.Click += new System.EventHandler(this.保存本页ToolStripMenuItem_Click);
            // 
            // labelK
            // 
            this.labelK.AutoSize = true;
            this.labelK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelK.Location = new System.Drawing.Point(118, 7);
            this.labelK.Margin = new System.Windows.Forms.Padding(0);
            this.labelK.Name = "labelK";
            this.labelK.Size = new System.Drawing.Size(21, 14);
            this.labelK.TabIndex = 1;
            this.labelK.Text = "K:";
            this.labelK.MouseEnter += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // Knum
            // 
            this.Knum.Location = new System.Drawing.Point(143, 4);
            this.Knum.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.Knum.Name = "Knum";
            this.Knum.Size = new System.Drawing.Size(34, 21);
            this.Knum.TabIndex = 2;
            this.Knum.DoubleClick += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // ThetaNnum
            // 
            this.ThetaNnum.Location = new System.Drawing.Point(242, 4);
            this.ThetaNnum.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.ThetaNnum.Name = "ThetaNnum";
            this.ThetaNnum.Size = new System.Drawing.Size(34, 21);
            this.ThetaNnum.TabIndex = 3;
            this.ThetaNnum.DoubleClick += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // labelTheTaN
            // 
            this.labelTheTaN.AutoSize = true;
            this.labelTheTaN.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTheTaN.Location = new System.Drawing.Point(182, 7);
            this.labelTheTaN.Margin = new System.Windows.Forms.Padding(0);
            this.labelTheTaN.Name = "labelTheTaN";
            this.labelTheTaN.Size = new System.Drawing.Size(56, 14);
            this.labelTheTaN.TabIndex = 3;
            this.labelTheTaN.Text = "ThetaN:";
            this.labelTheTaN.MouseEnter += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // ThetaSnum
            // 
            this.ThetaSnum.Location = new System.Drawing.Point(342, 4);
            this.ThetaSnum.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.ThetaSnum.Name = "ThetaSnum";
            this.ThetaSnum.Size = new System.Drawing.Size(34, 21);
            this.ThetaSnum.TabIndex = 4;
            this.ThetaSnum.DoubleClick += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // labelTheTaS
            // 
            this.labelTheTaS.AutoSize = true;
            this.labelTheTaS.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTheTaS.Location = new System.Drawing.Point(282, 7);
            this.labelTheTaS.Margin = new System.Windows.Forms.Padding(0);
            this.labelTheTaS.Name = "labelTheTaS";
            this.labelTheTaS.Size = new System.Drawing.Size(56, 14);
            this.labelTheTaS.TabIndex = 5;
            this.labelTheTaS.Text = "ThetaS:";
            this.labelTheTaS.MouseEnter += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // ThetaCnum
            // 
            this.ThetaCnum.Location = new System.Drawing.Point(441, 4);
            this.ThetaCnum.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.ThetaCnum.Name = "ThetaCnum";
            this.ThetaCnum.Size = new System.Drawing.Size(34, 21);
            this.ThetaCnum.TabIndex = 5;
            this.ThetaCnum.DoubleClick += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // labelThetaC
            // 
            this.labelThetaC.AutoSize = true;
            this.labelThetaC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelThetaC.Location = new System.Drawing.Point(381, 7);
            this.labelThetaC.Margin = new System.Windows.Forms.Padding(0);
            this.labelThetaC.Name = "labelThetaC";
            this.labelThetaC.Size = new System.Drawing.Size(56, 14);
            this.labelThetaC.TabIndex = 7;
            this.labelThetaC.Text = "ThetaC:";
            this.labelThetaC.MouseEnter += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // Lnum
            // 
            this.Lnum.Location = new System.Drawing.Point(505, 4);
            this.Lnum.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.Lnum.Name = "Lnum";
            this.Lnum.Size = new System.Drawing.Size(34, 21);
            this.Lnum.TabIndex = 6;
            this.Lnum.DoubleClick += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // labelL
            // 
            this.labelL.AutoSize = true;
            this.labelL.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelL.Location = new System.Drawing.Point(480, 7);
            this.labelL.Margin = new System.Windows.Forms.Padding(0);
            this.labelL.Name = "labelL";
            this.labelL.Size = new System.Drawing.Size(21, 14);
            this.labelL.TabIndex = 9;
            this.labelL.Text = "L:";
            this.labelL.MouseEnter += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // Inum
            // 
            this.Inum.Location = new System.Drawing.Point(569, 4);
            this.Inum.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.Inum.Name = "Inum";
            this.Inum.Size = new System.Drawing.Size(34, 21);
            this.Inum.TabIndex = 7;
            this.Inum.DoubleClick += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // labelI
            // 
            this.labelI.AutoSize = true;
            this.labelI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelI.Location = new System.Drawing.Point(544, 7);
            this.labelI.Margin = new System.Windows.Forms.Padding(0);
            this.labelI.Name = "labelI";
            this.labelI.Size = new System.Drawing.Size(21, 14);
            this.labelI.TabIndex = 11;
            this.labelI.Text = "I:";
            this.labelI.MouseEnter += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // IterationButton
            // 
            this.IterationButton.Location = new System.Drawing.Point(627, 4);
            this.IterationButton.Name = "IterationButton";
            this.IterationButton.Size = new System.Drawing.Size(75, 21);
            this.IterationButton.TabIndex = 8;
            this.IterationButton.Text = "开始迭代";
            this.IterationButton.UseVisualStyleBackColor = true;
            this.IterationButton.Click += new System.EventHandler(this.IterationButton_Click);
            this.IterationButton.MouseEnter += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 29);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(747, 390);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControlIndexChanged);
            this.tabControl1.DoubleClick += new System.EventHandler(this.TabContralDoubleClick);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(475, 431);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 14);
            this.label8.TabIndex = 17;
            this.label8.Text = "R:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(628, 431);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 18;
            this.label7.Text = "B:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(552, 431);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 14);
            this.label9.TabIndex = 19;
            this.label9.Text = "G:";
            // 
            // Rnum
            // 
            this.Rnum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Rnum.Location = new System.Drawing.Point(497, 428);
            this.Rnum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Rnum.Name = "Rnum";
            this.Rnum.Size = new System.Drawing.Size(50, 21);
            this.Rnum.TabIndex = 10;
            this.Rnum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumKeyPress);
            // 
            // Bnum
            // 
            this.Bnum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Bnum.Location = new System.Drawing.Point(652, 428);
            this.Bnum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Bnum.Name = "Bnum";
            this.Bnum.Size = new System.Drawing.Size(50, 21);
            this.Bnum.TabIndex = 12;
            this.Bnum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumKeyPress);
            // 
            // Gnum
            // 
            this.Gnum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Gnum.Location = new System.Drawing.Point(575, 428);
            this.Gnum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Gnum.Name = "Gnum";
            this.Gnum.Size = new System.Drawing.Size(50, 21);
            this.Gnum.TabIndex = 11;
            this.Gnum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumKeyPress);
            // 
            // colorButton
            // 
            this.colorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.colorButton.BackColor = System.Drawing.Color.Black;
            this.colorButton.Location = new System.Drawing.Point(717, 428);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(21, 21);
            this.colorButton.TabIndex = 13;
            this.colorButton.UseVisualStyleBackColor = false;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            this.colorButton.MouseEnter += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 516);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(744, 22);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(150, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(577, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // logText
            // 
            this.logText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logText.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.logText.Location = new System.Drawing.Point(0, 428);
            this.logText.Name = "logText";
            this.logText.ReadOnly = true;
            this.logText.Size = new System.Drawing.Size(469, 85);
            this.logText.TabIndex = 26;
            this.logText.TabStop = false;
            this.logText.Text = "";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(652, 460);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 16;
            this.okButton.Text = "传输";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            this.okButton.MouseEnter += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(652, 490);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 19;
            this.cancelButton.Text = "退出";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            this.cancelButton.MouseEnter += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // Cnum
            // 
            this.Cnum.Location = new System.Drawing.Point(78, 4);
            this.Cnum.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.Cnum.Name = "Cnum";
            this.Cnum.Size = new System.Drawing.Size(34, 21);
            this.Cnum.TabIndex = 1;
            this.Cnum.DoubleClick += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelC.Location = new System.Drawing.Point(53, 7);
            this.labelC.Margin = new System.Windows.Forms.Padding(0);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(21, 14);
            this.labelC.TabIndex = 29;
            this.labelC.Text = "C:";
            this.labelC.MouseEnter += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // multiClassButton
            // 
            this.multiClassButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.multiClassButton.Location = new System.Drawing.Point(490, 489);
            this.multiClassButton.Name = "multiClassButton";
            this.multiClassButton.Size = new System.Drawing.Size(75, 23);
            this.multiClassButton.TabIndex = 17;
            this.multiClassButton.Text = "分类显示";
            this.multiClassButton.UseVisualStyleBackColor = true;
            this.multiClassButton.Click += new System.EventHandler(this.multiClassButton_Click);
            this.multiClassButton.MouseEnter += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // mergeButton
            // 
            this.mergeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mergeButton.Location = new System.Drawing.Point(571, 489);
            this.mergeButton.Name = "mergeButton";
            this.mergeButton.Size = new System.Drawing.Size(75, 23);
            this.mergeButton.TabIndex = 18;
            this.mergeButton.Text = "多类合并";
            this.mergeButton.UseVisualStyleBackColor = true;
            this.mergeButton.Click += new System.EventHandler(this.mergeButton_Click);
            this.mergeButton.MouseEnter += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // changeColorButton
            // 
            this.changeColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.changeColorButton.Location = new System.Drawing.Point(571, 460);
            this.changeColorButton.Name = "changeColorButton";
            this.changeColorButton.Size = new System.Drawing.Size(75, 23);
            this.changeColorButton.TabIndex = 15;
            this.changeColorButton.Text = "应用颜色";
            this.changeColorButton.UseVisualStyleBackColor = true;
            this.changeColorButton.Click += new System.EventHandler(this.changeColorButton_Click);
            this.changeColorButton.MouseEnter += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // reLoadButton
            // 
            this.reLoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reLoadButton.Location = new System.Drawing.Point(490, 461);
            this.reLoadButton.Name = "reLoadButton";
            this.reLoadButton.Size = new System.Drawing.Size(75, 23);
            this.reLoadButton.TabIndex = 14;
            this.reLoadButton.Text = "重新加载";
            this.reLoadButton.UseVisualStyleBackColor = true;
            this.reLoadButton.Click += new System.EventHandler(this.reLoadButton_Click);
            this.reLoadButton.MouseEnter += new System.EventHandler(this.MouseEnterShowToolTip);
            // 
            // ClassifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 538);
            this.Controls.Add(this.reLoadButton);
            this.Controls.Add(this.changeColorButton);
            this.Controls.Add(this.mergeButton);
            this.Controls.Add(this.multiClassButton);
            this.Controls.Add(this.Cnum);
            this.Controls.Add(this.labelC);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.logText);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.Gnum);
            this.Controls.Add(this.Bnum);
            this.Controls.Add(this.Rnum);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.IterationButton);
            this.Controls.Add(this.Inum);
            this.Controls.Add(this.labelI);
            this.Controls.Add(this.Lnum);
            this.Controls.Add(this.labelL);
            this.Controls.Add(this.ThetaCnum);
            this.Controls.Add(this.labelThetaC);
            this.Controls.Add(this.ThetaSnum);
            this.Controls.Add(this.labelTheTaS);
            this.Controls.Add(this.ThetaNnum);
            this.Controls.Add(this.labelTheTaN);
            this.Controls.Add(this.Knum);
            this.Controls.Add(this.labelK);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClassifyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "影像分类";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.nFormClosing);
            this.Load += new System.EventHandler(this.ClassifyForm_Load);
            this.SizeChanged += new System.EventHandler(this.nSizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Knum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThetaNnum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThetaSnum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThetaCnum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lnum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Inum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rnum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bnum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gnum)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cnum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存本页ToolStripMenuItem;
        private System.Windows.Forms.Label labelK;
        private System.Windows.Forms.NumericUpDown Knum;
        private System.Windows.Forms.NumericUpDown ThetaNnum;
        private System.Windows.Forms.Label labelTheTaN;
        private System.Windows.Forms.NumericUpDown ThetaSnum;
        private System.Windows.Forms.Label labelTheTaS;
        private System.Windows.Forms.NumericUpDown ThetaCnum;
        private System.Windows.Forms.Label labelThetaC;
        private System.Windows.Forms.NumericUpDown Lnum;
        private System.Windows.Forms.Label labelL;
        private System.Windows.Forms.NumericUpDown Inum;
        private System.Windows.Forms.Label labelI;
        private System.Windows.Forms.Button IterationButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown Rnum;
        private System.Windows.Forms.NumericUpDown Bnum;
        private System.Windows.Forms.NumericUpDown Gnum;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.RichTextBox logText;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown Cnum;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.Button multiClassButton;
        private System.Windows.Forms.Button mergeButton;
        private System.Windows.Forms.Button changeColorButton;
        private System.Windows.Forms.Button reLoadButton;
    }
}