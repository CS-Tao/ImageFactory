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
    public partial class GetDoubleForm : Form
    {
        /// <summary>
        /// 选择的数字
        /// </summary>
        public double num = 0;

        /// <summary>
        /// 数字选择器的最大值
        /// </summary>
        private int maxNum = 0;

        /// <summary>
        /// 数字选择器的最小值
        /// </summary>
        private int minNum = 0;

        /// <summary>
        /// 主窗口
        /// </summary>
        private MainForm mainForm;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="form">主窗口</param>
        /// <param name="n">初始数字</param>
        /// <param name="max">最大值</param>
        /// <param name="min">最小值</param>
        public GetDoubleForm(MainForm form, double n ,int max, int min)
        {
            InitializeComponent();
            mainForm = form;
            num = n;
            maxNum = max;
            minNum = min;
            minNum = min;
            maxNum = max;
            textBox1.Text = n.ToString();
        }

        private void GetIntForm_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            int x = (mainForm.ClientRectangle.Right - this.ClientRectangle.Right) / 2 + mainForm.RectangleToScreen(mainForm.ClientRectangle).Left;
            int y = (mainForm.ClientRectangle.Bottom - this.ClientRectangle.Bottom) / 2 + mainForm.RectangleToScreen(mainForm.ClientRectangle).Top;
            this.Location = new Point(x, y);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                num = Convert.ToDouble(textBox1.Text);
            }
            catch(Exception ex)
            {
                mainForm.ShowRedLog("数值格式有误");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
