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
    public partial class GetOpertor : Form
    {
        /// <summary>
        /// 滤波算子
        /// </summary>
        public double[,] filter = new double[3, 3];

        /// <summary>
        /// 主窗口
        /// </summary>
        private MainForm mainForm;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="form">主窗口</param>
        /// <param name="filterValue">初始滤波算子</param>
        public GetOpertor(MainForm form, double[,] filterValue)
        {
            InitializeComponent();
            textBox00.Text = filterValue[0, 0].ToString();
            textBox01.Text = filterValue[0, 1].ToString();
            textBox02.Text = filterValue[0, 2].ToString();
            textBox10.Text = filterValue[1, 0].ToString();
            textBox11.Text = filterValue[1, 1].ToString();
            textBox12.Text = filterValue[1, 2].ToString();
            textBox20.Text = filterValue[2, 0].ToString();
            textBox21.Text = filterValue[2, 1].ToString();
            textBox22.Text = filterValue[2, 2].ToString();
            filter = filterValue;
            mainForm = form;
            StartPosition = FormStartPosition.Manual;
            int x = (mainForm.ClientRectangle.Right - this.ClientRectangle.Right) / 2 + mainForm.RectangleToScreen(mainForm.ClientRectangle).Left;
            int y = (mainForm.ClientRectangle.Bottom - this.ClientRectangle.Bottom) / 2 + mainForm.RectangleToScreen(mainForm.ClientRectangle).Top;
            this.Location = new Point(x, y);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                filter[0, 0] = Convert.ToDouble(textBox00.Text);
                filter[0, 1] = Convert.ToDouble(textBox01.Text);
                filter[0, 2] = Convert.ToDouble(textBox02.Text);
                filter[1, 0] = Convert.ToDouble(textBox10.Text);
                filter[1, 1] = Convert.ToDouble(textBox11.Text);
                filter[1, 2] = Convert.ToDouble(textBox12.Text);
                filter[2, 0] = Convert.ToDouble(textBox20.Text);
                filter[2, 1] = Convert.ToDouble(textBox21.Text);
                filter[2, 2] = Convert.ToDouble(textBox22.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void GetOpertor_Load(object sender, EventArgs e)
        {

        }

        private void textBox00_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
