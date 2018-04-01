using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;

using System.Drawing;

namespace tool.frame
{
    public class serial_port
    {
        private Panel _lost_focus;

        public ah_tool _hander;
        private SerialPort _serialPort; //串口控件

        public ToolStripComboBox _com_port;
        public ToolStripComboBox _com_baudrate;
        public ToolStripButton _com_switch;

        public bool receiving = false;

        public serial_port(ah_tool hander,
            ToolStripComboBox com_port,
            ToolStripComboBox com_baudrate,
            ToolStripButton com_switch)
        {
            _hander = hander;
            _com_port = com_port;
            _com_baudrate = com_baudrate;
            _com_switch = com_switch;

            _lost_focus = new Panel();
            _hander.Invoke(new Action(() => { _hander.Controls.Add(_lost_focus); }));

            init();
        }

        void init()
        {
            _com_switch.Click += new System.EventHandler(com_switch_Click);
            _com_port.DropDown += new System.EventHandler(com_port_DropDown);
            _com_port.DropDownClosed += new System.EventHandler(com_port_DropDownClosed);

            _serialPort = new SerialPort();

            _serialPort.Encoding = Encoding.Default;//能够发送中文
            _serialPort.DataBits = 8; //数据位
            _serialPort.Parity = Parity.None; //无校验
            _serialPort.StopBits = StopBits.One; //停止位
        }

        // 串口开关
        private void com_switch_Click(object sender, EventArgs e)
        {
            bool status;
            string baudrate = _com_baudrate.Text;
            string port_name = _com_port.Text;

            //_com_port.Text = "COM1";
            //Regex regex = new Regex(@"\(.*?\)", RegexOptions.IgnoreCase);
            //MatchCollection matches = regex.Matches(port_name);
            //string port = matches[0].Value.Trim('(', ')').Split('-')[0];

            string port = port_name.Split(' ')[0];
            status = operate_port(port, baudrate);
            set_serial_status(status);
        }

        // 串口端口列表更新
        private void com_port_DropDown(object sender, EventArgs e)
        {
            string[] device_ports = get_port_list();       
            set_serial_port(device_ports);
        }

        private void com_port_DropDownClosed(object sender, EventArgs e)
        {
            //this._com_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //this._com_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;

            //string port_name = _com_port.Text;
            //string port = port_name.Split(' ')[0];
            //_com_port.Text = port;

            _lost_focus.Focus();
        }

        // 设置串口端口列表
        public void set_serial_port(string[] device_ports)
        {
            bool current_port_sign = false;
            string current_port = _com_port.Text;

            if (device_ports.Length != 0)
            {
                _com_port.Items.Clear();
                _com_port.Items.Add("AUTO");

                foreach (string ports in device_ports)
                {
                    _com_port.Items.Add(ports);

                    if (current_port == ports)
                    {
                        current_port_sign = true;
                    }

                    _com_port.Text = device_ports[0];
                }

                if (current_port_sign)
                {
                    _com_port.Text = current_port;
                }
            }
        }

        // 设置串口状态
        public void set_serial_status(bool sw)
        {
            if (sw)
            {
                _com_switch.Image = Properties.Resources.port_open;
            }
            else
            {
                _com_switch.Image = Properties.Resources.port_close;
            }
        }

        // 串口开关操作
        public bool operate_port(string port, string baudrate)
        {
            bool status = false;
            if (_serialPort.IsOpen != true)
            {
                try
                {
                    _serialPort.PortName = port;
                    _serialPort.BaudRate = int.Parse(baudrate);
                    _serialPort.Open();
                    status = true;
                }
                catch
                {
                    MessageBox.Show(_serialPort.PortName + "被占用！");
                    status = false;
                }
            }
            else
            {
                while (receiving == true)
                {
                    Application.DoEvents();
                }
                _serialPort.Close();
                status = false;
            }
            return status;
        }

        // 更新串口端口列表
        string last_prot;
        string[] last_device_ports;
        public string[] get_port_list()
        {
            string[] device_ports = SerialPort.GetPortNames();
            string now_port = null;

            foreach (string ports in device_ports)
            {
                now_port += ports;
            }

            if (last_prot != now_port)
            {
                last_prot = now_port;

                device_ports = WMI.MulGetHardwareInfo(WMI.HardwareEnum.Win32_PnPEntity, "Name");
                int cnt = 0;
                foreach (string ports in device_ports)
                {
                    Regex regex = new Regex(@"\(.*?\)", RegexOptions.IgnoreCase);
                    MatchCollection matches = regex.Matches(ports);

                    string name = ports.Split('(')[0];
                    string com = matches[0].Value.Trim('(', ')').Split('-')[0];

                    device_ports[cnt++] = com + " " + name;//.Substring(0, 4) + "...";
                }

                last_device_ports = device_ports;
            }
            return last_device_ports;
        }
    }
}
