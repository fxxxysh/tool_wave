using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace tool.frame
{
    public partial class serial_port
    {
        public void parse_task()
        {
            test_add_data();
            while (true)
            {
                if (_serialPort.IsOpen == true)
                {
                    test_add_data();
                }
                Thread.Sleep(10);
            }
        }

        public void refresh_task()
        {
            while (true)
            {
                //com_port_DropDown(null, null);
                Thread.Sleep(500);
            }
        }

        int plot_x = 0;
        int cnt = 0;
        void test_add_data()
        {
            cnt++;
            for (int x = 0; x < 10; x++)
            {
                _plot.Channels[x].AddXY(plot_x, 100 * Math.Sin((cnt % 360) * 6.28 / 360) + x * 100);
            }
            plot_x++;
        }

        int[] data_y = new int[100];
        int[] data_x1 = new int[100];
        void test_add_arry()
        {
            for (int x_cnt = 0; x_cnt < 100; x_cnt++)
            {
                cnt++;

                for (int x = 0; x < 10; x++)
                {
                    data_y[x_cnt] = cnt % 100 + x * 10;
                }
                data_x1[x_cnt] = data_x1[99] + 1 + x_cnt;
            }

            for (int x = 0; x < 10; x++)
            {
                _plot.Channels[x].AddDataArray(data_x1, data_y);
            }
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

            if (device_ports != null)
            {
                //_hander.Invoke(new Action(() => { set_serial_port(device_ports); }));
                set_serial_port(device_ports);
            }
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
    }
}
