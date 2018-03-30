using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text.RegularExpressions;
namespace tool.frame
{
    public class serial_port
    {
        private SerialPort _serialPort; //串口控件

        public bool receiving = false;

        public serial_port(ah_tool handler)
        {
            init();
        }

        void init()
        {
            _serialPort = new SerialPort();

            _serialPort.Encoding = Encoding.Default;//能够发送中文
            _serialPort.DataBits = 8; //数据位
            _serialPort.Parity = Parity.None; //无校验
            _serialPort.StopBits = StopBits.One; //停止位
        }

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

        public string[] up_port_list()
        {
            string[] device_ports = WMI.MulGetHardwareInfo(WMI.HardwareEnum.Win32_PnPEntity, "Name");

            int cnt = 0;
            foreach (string ports in device_ports)
            {
                Regex regex = new Regex(@"\(.*?\)", RegexOptions.IgnoreCase);
                MatchCollection matches = regex.Matches(ports);

                string name = ports.Split('(')[0];
                string com = matches[0].Value.Trim('(', ')').Split('-')[0];

                device_ports[cnt++] = com + " "+ name.Substring(0, 4) + "...";
            }
            return device_ports;
            //return SerialPort.GetPortNames();
        }
    }
}
