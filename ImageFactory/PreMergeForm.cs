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
    public partial class PreMergeForm : Form
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
        /// 通道1CheckBox链表
        /// </summary>
        private List<CheckBox> checkBoxList1 = new List<CheckBox>();

        /// <summary>
        /// checkBoxList1选中的索引
        /// </summary>
        private int checkedIndex1 = 0;

        /// <summary>
        /// 通道2CheckBox链表
        /// </summary>
        private List<CheckBox> checkBoxList2 = new List<CheckBox>();

        /// <summary>
        /// checkBoxList2选中的索引
        /// </summary>
        private int checkedIndex2 = 0;

        /// <summary>
        /// 通道3CheckBox链表
        /// </summary>
        private List<CheckBox> checkBoxList3 = new List<CheckBox>();

        /// <summary>
        /// checkBoxList3选中的索引
        /// </summary>
        private int checkedIndex3 = 0;

        /// <summary>
        /// 确认按钮
        /// </summary>
        private Button okButton = new Button();

        /// <summary>
        /// 取消按钮
        /// </summary>
        private Button cancelButton = new Button();

        /// <summary>
        /// 通道1索引
        /// </summary>
        public int indexOfChannel1 = 0;

        /// <summary>
        /// 通道2索引
        /// </summary>
        public int indexOfChannel2 = 0;

        /// <summary>
        /// 通道3索引
        /// </summary>
        public int indexOfChannel3 = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="form">主窗口</param>
        /// <param name="tabControl">主窗口tableControl</param>
        public PreMergeForm(MainForm form, TabControl tabControl)
        {
            InitializeComponent();
            mainForm = form;
            nAllImage = tabControl.TabPages.Count;
            this.tabControl = tabControl;
        }

        private void PreMergeForm_Load(object sender, EventArgs e)
        {
            this.Text = "选择用于彩色合成的图片";
            int ox = 10;
            int oy = 10;
            this.Width =245;
            this.Height = oy + nAllImage * 30 + 100;
            this.Location = new Point((mainForm.Width - this.Width) / 2, (mainForm.Height - this.Height) / 2);
            for (int i = 0; i < nAllImage; i++)
            {
                CheckBox tempCheckBox1 = new CheckBox();
                tempCheckBox1.Text = tabControl.TabPages[i].Text;
                tempCheckBox1.Size = new Size(60, 20);
                tempCheckBox1.Location = new Point(ox, oy + 30 * i);
                tempCheckBox1.Click += TempCheckBox1_Click;
                tempCheckBox1.MouseEnter += TempCheckBox_MouseEnter;
                checkBoxList1.Add(tempCheckBox1);
                this.Controls.Add(tempCheckBox1);

                CheckBox tempCheckBox2 = new CheckBox();
                tempCheckBox2.Text = tabControl.TabPages[i].Text;
                tempCheckBox2.Size = new Size(60, 20);
                tempCheckBox2.Location = new Point(ox + 70, oy + 30 * i);
                tempCheckBox2.Click += TempCheckBox2_Click;
                tempCheckBox2.MouseEnter += TempCheckBox_MouseEnter;
                checkBoxList2.Add(tempCheckBox2);
                this.Controls.Add(tempCheckBox2);

                CheckBox tempCheckBox3 = new CheckBox();
                tempCheckBox3.Text = tabControl.TabPages[i].Text;
                tempCheckBox3.Size = new Size(60, 20);
                tempCheckBox3.Location = new Point(ox + 140, oy + 30 * i);
                tempCheckBox3.Click += TempCheckBox3_Click;
                tempCheckBox3.MouseEnter += TempCheckBox_MouseEnter;
                checkBoxList3.Add(tempCheckBox3);
                this.Controls.Add(tempCheckBox3);
            }
            checkBoxList1[0].Checked = true;
            checkedIndex1 = 0;
            checkBoxList2[1].Checked = true;
            checkedIndex2 = 1;
            checkBoxList3[2].Checked = true;
            checkedIndex3 = 2;

            okButton.Text = "确定";
            okButton.Size = new Size(50, 30);
            okButton.Location = new Point(40, this.Height - 90);
            okButton.Click += OkButton_Click;
            this.Controls.Add(okButton);

            cancelButton.Text = "取消";
            cancelButton.Size = new Size(50, 30);
            cancelButton.Location = new Point(this.Width - 115, this.Height - 90);
            cancelButton.Click += CancelButton_Click;
            this.Controls.Add(cancelButton);
        }

        private void TempCheckBox_MouseEnter(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip((Control)sender, ((CheckBox)sender).Text);
        }

        private void TempCheckBox3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkBoxList3.Count; i++)
            {
                if (checkBoxList3[i] == sender)
                {
                    checkBoxList3[i].Checked = true;
                    checkedIndex3 = i;
                }
                else
                {
                    checkBoxList3[i].Checked = false;
                }
            }
        }

        private void TempCheckBox2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkBoxList2.Count; i++)
            {
                if (checkBoxList2[i] == sender)
                {
                    checkBoxList2[i].Checked = true;
                    checkedIndex2 = i;
                }
                else
                {
                    checkBoxList2[i].Checked = false;
                }
            }
        }

        private void TempCheckBox1_Click(object sender, EventArgs e)
        {
            for (int i=0;i<checkBoxList1.Count;i++)
            {
                if(checkBoxList1[i] == sender)
                {
                    checkBoxList1[i].Checked = true;
                    checkedIndex1 = i;
                }
                else
                {
                    checkBoxList1[i].Checked = false;
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkBoxList1.Count; i++)
            {
                if (checkBoxList1[i].Checked)
                {
                    indexOfChannel1 = i;
                    break;
                }
            }
            for (int i = 0; i < checkBoxList2.Count; i++)
            {
                if (checkBoxList2[i].Checked)
                {
                    indexOfChannel2 = i;
                    break;
                }
            }
            for (int i = 0; i < checkBoxList3.Count; i++)
            {
                if (checkBoxList3[i].Checked)
                {
                    indexOfChannel3 = i;
                    break;
                }
            }
            if(indexOfChannel1 == indexOfChannel2 || indexOfChannel2 == indexOfChannel3 || indexOfChannel1 == indexOfChannel3)
            {
                mainForm.ShowRedLog("图片选择重复");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
