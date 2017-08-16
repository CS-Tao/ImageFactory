using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabControlTemplate
{
    class TabControlTemplate : TabControl
    {
        /// <summary>
        /// 标签页列表
        /// </summary>
        private List<TabPage> tabPageList
        {
            get;
        }

        /// <summary>
        /// 处于活动状态的TabPage
        /// </summary>
        private TabPage activityPage
        {
            get;
        }

        /// <summary>
        /// 面板列表
        /// </summary>
        private List<Panel> panelList
        {
            get;
        }

        /// <summary>
        /// 处于活动状态的Panel
        /// </summary>
        private Panel activityPanel
        {
            get;
        }

        /// <summary>
        /// 控件列表
        /// </summary>
        private List<Control> controlList
        {
            get;
        }

        /// <summary>
        /// 处于活动状态的Control
        /// </summary>
        private Control activityControl
        {
            get;
        }

        /// <summary>
        /// 记录鼠标左键状态
        /// </summary>
        private bool isbtndown = false;

        /// <summary>
        /// 鼠标左键按下的坐标
        /// </summary>
        private Point btndowPoint = new Point();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent">显示窗口</param>
        /// <param name="control">主要包含控件类型</param>
        public TabControlTemplate(Form parent, Control control)
        {
            //变量初始化
            tabPageList = new List<TabPage>();
            activityPage = new TabPage();
            panelList = new List<Panel>();
            activityPanel = new Panel();
            controlList = new List<Control>();
            activityControl = new Control();
        }
    }
}
