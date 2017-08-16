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
    public partial class SplashScreen : Form
    {
        /// <summary>  
            /// 启动画面本身  
            /// </summary>  
        static SplashScreen instance;

        /// <summary>  
            /// 显示的图片  
            /// </summary>  
        Bitmap bitmap;

        public static SplashScreen Instance
        {
            get
            {
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public SplashScreen()
        {
            InitializeComponent();
            this.Visible = true;
            // 设置窗体的类型  
            /*const string showInfo = "正在努力的加载程序，请稍后...";
            this.Visible = true;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
            bitmap = new Bitmap(Properties.Resources.picture);
            //ClientSize = bitmap.Size;

            using (Font font = new Font("Consoles", 10))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawString(showInfo, font, Brushes.White, 130, 100);
                }
            }

            BackgroundImage = bitmap;*/
        }

        public static void ShowSplashScreen()
        {
            instance = new SplashScreen();
            instance.Show();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
