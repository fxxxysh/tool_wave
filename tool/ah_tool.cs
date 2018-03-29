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

namespace tool
{
    public partial class ah_tool : Form
    {
        public void lable_func(String str)
        {
            label_test.Text = str;
        }

        public ah_tool()
        {
            InitializeComponent();
            start();
        }

        // 主函数
        public void start()
        {
            // 解析任务
            protocol _protocol = new protocol();
            _protocol.action(this);
            
            Thread th1 = new Thread(_protocol.task);
            th1.Priority = ThreadPriority.AboveNormal;
            th1.Start();
        }

        // 窗口关闭
        private void ah_tool_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
