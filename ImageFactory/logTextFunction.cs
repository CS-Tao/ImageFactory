using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageFactory
{
    public partial class MainForm : Form
    {
        private delegate void delegateAppendText(string str);

        private void AppendText(string str)
        {
            logText.AppendText(str);
            logText.Select(this.logText.TextLength, 0);
            logText.ScrollToCaret();
        }

        private delegate void delegateShowRedMessage(string str);

        private void ShowRedMessage(string str)
        {
            logText.SelectionColor = Color.Red;
            logText.SelectedText = str;
            logText.Select(this.logText.TextLength, 0);
            logText.ScrollToCaret();
        }

        /// <summary>
        /// 显示日志,可用于子线程
        /// </summary>
        /// <param name="str">日志内容</param>
        private void ShowLog(string str)
        {
            delegateAppendText at = new delegateAppendText(AppendText);
            Invoke(at, new object[] { "$" + DateTime.Now.ToLongTimeString().ToString() + ":" + str + "\r\n" });
        }

        /// <summary>
        /// 显示红色日志,可用于子线程
        /// </summary>
        /// <param name="str">日志内容</param>
        public void ShowRedLog(string str)
        {
            delegateShowRedMessage dmsg = new delegateShowRedMessage(ShowRedMessage);
            Invoke(dmsg, new object[] { "$" + DateTime.Now.ToLongTimeString().ToString() + ":" + str + "\r\n" });
        }

        private delegate void delegateShowInTooStrip(string str);

        private void dShowInTooStrip(string str)
        {
            toolStripStatusLabel2.Text = str;
        }

        /// <summary>
        /// 显示在toolstrip,可用于子线程
        /// </summary>
        /// <param name="str">内容</param>
        private void ShowInTooStrip(string str)
        {
            delegateShowInTooStrip d = new delegateShowInTooStrip(dShowInTooStrip);
            Invoke(d, new object[] { str });
        }
    }
}
