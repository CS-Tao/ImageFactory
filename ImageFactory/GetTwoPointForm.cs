using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFactory
{
    public partial class GetTwoPointForm : Form
    {
        /// <summary>
        /// 图片裁剪x1
        /// </summary>
        public int cutX1 = 0;

        /// <summary>
        /// 图片裁剪y1
        /// </summary>
        public int cutY1 = 0;

        /// <summary>
        /// 图片裁剪x2
        /// </summary>
        public int cutX2 = 0;

        /// <summary>
        /// 图片裁剪y2
        /// </summary>
        public int cutY2 = 0;

        /// <summary>
        /// 主窗口
        /// </summary>
        private MainForm mainForm;

        /// <summary>
        /// x最大值
        /// </summary>
        private int maxW;

        /// <summary>
        /// y最大值
        /// </summary>
        private int maxH;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="form">主窗口</param>
        /// <param name="X1">左上角横坐标</param>
        /// <param name="Y1">左上角纵坐标</param>
        /// <param name="X2">右下角横坐标</param>
        /// <param name="Y2">右下角纵坐标</param>
        /// <param name="maxWidth">横坐标最大值</param>
        /// <param name="maxHeight">纵坐标最大值</param>
        public GetTwoPointForm(MainForm form, int X1,int Y1, int X2,int Y2, int maxWidth, int maxHeight)
        {
            InitializeComponent();
            mainForm = form;
            cutX1 = X1;
            cutX2 = X2;
            cutY1 = Y1;
            cutY2 = Y2;
            maxH = maxHeight;
            maxW = maxWidth;
            x1Num.Maximum = maxWidth;
            x2Num.Maximum = maxWidth;
            y1Num.Maximum = maxHeight;
            y2Num.Maximum = maxHeight;
        }

        private void eformClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cutX1 = (int)x1Num.Value;
            cutY1 = (int)y1Num.Value;
            cutX2 = (int)x2Num.Value;
            cutY2 = (int)y2Num.Value;
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void GetTwoPointForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point((mainForm.Width - this.Width) / 2, (mainForm.Height - this.Height) / 2);
        }
    }
}
