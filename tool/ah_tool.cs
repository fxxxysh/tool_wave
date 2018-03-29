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

//using tool.modules;

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
            main();

            lable_func("123");
        }

        // 主函数
        public void main()
        {
            protocol _protocol = new protocol();
            _protocol.reg(this);

            Thread th1 = new Thread(_protocol.protocol_main);
            th1.Priority = ThreadPriority.AboveNormal;
            //Thread
            th1.Start();
        }

        // 窗口关闭
        private void ah_tool_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }

    class protocol
    {
        private ah_tool lable;//声明一个事件

        public void reg(ah_tool handler)
        {
            lable = handler;
        }

        public void protocol_main()
        {
            int cnt = 0;

            //ah_tool wave = new ah_tool();

            //Del del3 = delegate (string name)
            //{ lable_func(str); };

            while (true)
            {
                cnt++;

                //this.Invoke(new Action(() => {
                //    label_test.Text = "关闭";
                //}));

                if (cnt > 3)
                {
                    lable.Invoke(new Action(() =>
                    {
                        lable.lable_func(cnt.ToString());
                    }));
                }

                
                //lable(delegate cnt.ToString());
                Thread.Sleep(1000);
            }
        }
    }
}
