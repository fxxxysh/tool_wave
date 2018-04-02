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
using Iocomp.Instrumentation.Plotting;
using Iocomp.Classes;

using tool.frame;

namespace tool
{
    public partial class ah_tool : Form
    {
        public serial_port _serial; //串口
        public wave_form _wave; //波形窗口
        public List<Label> _list;

        public List<Label> _label
        {
            get { return _list; }
        }

        public Plot _plot
        {
            get { return wave_plot; }
            set { wave_plot = value; }
        }

        public PlotToolBarStandard _plotTool
        {
            get { return plotToolBar; }
            set { plotToolBar = value; }
        }

        public PlotToolBarButton _track
        {
            get { return plotToolBarButton1; }
            set { plotToolBarButton1 = value; }
        }
        
        public ToolStripComboBox _com_port
        {
            get { return com_port; }
            set { com_port = value; }
        }

        public ToolStripComboBox _com_baudrate
        {
            get { return com_baudrate; }
            set { com_baudrate = value; }
        }

        public ToolStripButton _com_switch
        {
            get { return com_switch; }
            set { com_switch = value; }
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

            Thread th_start = new Thread(start)
            { Priority = ThreadPriority.BelowNormal, IsBackground = true };
            th_start.Start();
        }
     
        private void mount()
        {
            _serial = new serial_port(this);
            _wave = new wave_form(this);

            _list = new List<Label>();
            _list.Add(label1);
            _list.Add(label2);
            _list.Add(label3);
            _list.Add(label4);
            _list.Add(label5);
            _list.Add(label6);
            _list.Add(label7);
            _list.Add(label8);
        }

        // 主函数
        public void start()
        {
            while (this.IsHandleCreated != true)
            {
                Thread.Sleep(10);
            }
            mount();
            Thread.CurrentThread.Abort();
        }

        // 窗口关闭
        private void ah_tool_FormClosing(object sender, FormClosingEventArgs e)
        {
            //System.Environment.Exit(0);
        }
    }
}
