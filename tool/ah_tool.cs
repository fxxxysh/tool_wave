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

using tool.modules;
using tool.frame;

namespace tool
{
    public partial class ah_tool : Form
    {
        protocol _protocol;
        serial_port _serial;

        public void lable_func(String str)
        {
            label_test.Text = str;
        }

        public ah_tool()
        {
            InitializeComponent();

            Thread th_start = new Thread(start);
            th_start.Priority = ThreadPriority.BelowNormal;
            th_start.Start();
        }

        public void mount_serial()
        {
            //this.com_switch.Click = 
        }

        // 主函数
        public void start()
        {
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

        private void com_switch_Click(object sender, EventArgs e)
        {

        }

        private void com_port_DropDown(object sender, EventArgs e)
        {

        }
    }
}
