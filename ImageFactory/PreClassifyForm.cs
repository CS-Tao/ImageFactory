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
    public partial class PreClassifyForm : Form
    {
        /// <summary>
        ///  主窗口
        /// </summary>
        private MainForm mainForm;

        /// <summary>
        /// 主窗口图片数
        /// </summary>
        private int nAllImage;

        /// <summary>
        /// 主窗口的tabtabControl
        /// </summary>
        private TabControl tabControl;

        /// <summary>
        /// CheckBox链表
        /// </summary>
        private List<CheckBox> checkBosList = new List<CheckBox>();

        /// <summary>
        /// 确认按钮
        /// </summary>
        private Button okButton = new Button();

        /// <summary>
        /// 取消按钮
        /// </summary>
        private Button cancelButton = new Button();

        /// <summary>
        /// 已选择的索引
        /// </summary>
        public List<int> indexOfSelectedList = new List<int>();

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="form">主窗口</param>
        /// <param name="tabControl">主窗口tableControl</param>
        public PreClassifyForm(MainForm form, TabControl tabControl)
        {
            InitializeComponent();
            mainForm = form;
            nAllImage = tabControl.TabPages.Count;
            this.tabControl = tabControl;
        }

        private void PreClassify_Load(object sender, EventArgs e)
        {
            int ox = 10;
            int oy = 10;
            this.Width = 300;
            this.Height = oy + nAllImage * 30 + 100;
            this.Location = new Point((mainForm.Width - this.Width) / 2, (mainForm.Height - this.Height) / 2);
            for (int i=0;i<nAllImage;i++)
            {
                CheckBox tempCheckBox = new CheckBox();
                tempCheckBox.Text = tabControl.TabPages[i].Text;
                tempCheckBox.Size = new Size(200, 20);
                tempCheckBox.Location = new Point(ox, oy + 30 * i);
                tempCheckBox.Checked = true;
                checkBosList.Add(tempCheckBox);
                this.Controls.Add(tempCheckBox);

            }
            okButton.Text = "确定";
            okButton.Size = new Size(50, 30);
            okButton.Location = new Point(60, this.Height - 90);
            okButton.Click += OkButton_Click;
            this.Controls.Add(okButton);

            cancelButton.Text = "取消";
            cancelButton.Size = new Size(50, 30);
            cancelButton.Location = new Point(this.Width - 120, this.Height - 90);
            cancelButton.Click += CancelButton_Click;
            this.Controls.Add(cancelButton);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkBosList.Count; i++)
            {
                if (checkBosList[i].Checked)
                    indexOfSelectedList.Add(i);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK)
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
