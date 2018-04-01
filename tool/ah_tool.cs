using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Messaging;
using System.IO.Ports;
using System.Text.RegularExpressions;
using tool.modules;
using tool.frame;

namespace tool
{
    public partial class ah_tool : Form
    {
        public protocol _protocol; //解析
        public serial_port _serial; //串口

        public void lable_func(String str)
        {
            label_test.Text = str;
        }

        // 防止界面切换闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public ah_tool()
        {
            InitializeComponent();

            Thread th_start = new Thread(start);
            th_start.Priority = ThreadPriority.BelowNormal;
            th_start.Start();
        }

        // 挂载串口
        private void mount_serial()
        {
            _serial = new serial_port(this, com_port, com_baudrate, com_switch);
        }

        // 主函数
        public void start()
        {
            mount_serial();

            // 解析任务
            _protocol = new protocol();
            _protocol.action(this);

            // 等待窗口响应完成
            if (this.IsHandleCreated == true)
            {
                Thread th1 = new Thread(_protocol.task);
                th1.Priority = ThreadPriority.AboveNormal;
                th1.Start();
            }
        }

        // 窗口关闭
        private void ah_tool_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
