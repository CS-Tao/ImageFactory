using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFactory
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 双击关闭tabpage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabContralDoubleClick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex > 0)
            {
                tabControl1.SelectedIndex -= 1;
                pictureBoxList.RemoveAt(tabControl1.SelectedIndex + 1);
                panelList.RemoveAt(tabControl1.SelectedIndex + 1);
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex + 1);
            }
            else
            {
                pictureBoxList.RemoveAt(tabControl1.SelectedIndex);
                panelList.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
            }
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

            TabPage tabPage = new TabPage(name);
            tabPage.BackColor = Color.Black;
            tabPage.Controls.Add(panel);
            panelList.Add(panel);
            pictureBoxList.Add(pictureBox);
            tabControl1.TabPages.Add(tabPage);

            activityPanel = panel;
            activityPictureBox = pictureBox;
            tabControl1.SelectedIndex = tabControl1.TabPages.Count - 1;
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
        public void CreateTabPage(string name, Image image)
        {
            delegateCreateTabPage at = new delegateCreateTabPage(dCreateTabPage);
            Invoke(at, new object[] { name, image });
        }

        private void tabControlIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count == 0)
                return;
            activityPictureBox = pictureBoxList[tabControl1.SelectedIndex];
            activityPanel = panelList[tabControl1.SelectedIndex];
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

    }
}
