using System.Drawing;
using System.Windows.Forms;

namespace ImageFactory
{
    public partial class MainForm : Form
    {
        private delegate void delegateRefreshPictureBox(Image image);

        private void RefreshPictureBox(Image image)
        {
            activityPictureBox.Image = image;
            activityPictureBox.Refresh();
        }

        /// <summary>
        /// 显示图片,可用于子线程
        /// </summary>
        /// <param name="image">待显示图片</param>
        private void ShowImg(Image image)
        {
            delegateRefreshPictureBox r = new delegateRefreshPictureBox(RefreshPictureBox);
            Invoke(r, new object[] { image });
        }
    }
}
