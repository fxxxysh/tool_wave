using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Classes;
using System.Windows.Forms;

namespace tool.frame
{
    public class wave_form
    {
        public ah_tool _hander;
        private Plot _plot;

        struct wave_axes_s
        {
            public double x_min;
            public double y_min;
            public double x_max;
            public double y_max;
            public double x_span;
            public double y_span;
        };

        bool track_sign = false;
        bool cursor_sign = false;

        public wave_form(ah_tool hander)
        {
            _hander = hander;

            mode_init();
            event_init();
        }

        void event_init()
        {
            _hander._plotTool.MouseUp += new MouseEventHandler(plotTool_MouseUp);
            _hander. _plotTool.ButtonClick += new ToolBarButtonClickEventHandler(plotTool_ButtonClick);
            _plot.MouseCaptureChanged += new EventHandler(plot_MouseCaptureChanged);
        }

        void mode_init()
        {
            _plot = _hander._plot;

            Thread th = new Thread(task)
            { Priority = ThreadPriority.AboveNormal, IsBackground = true };
            th.Start();
        }

        public PlotChannelTrace plot_channels(int channel)
        {
            return (PlotChannelTrace)_plot.Channels[channel];
        }

        public void plot_markers(bool state)
        {
            for (int channel = 0; channel < 10; channel++)
            {
                plot_channels(channel).Markers.Visible = state;
            }
        }

        void plot_zoom()
        {
            if ((_plot.XAxes[0].Span < 350) || (_plot.YAxes[0].Span < 350))
            {
                plot_markers(true);
            }
            else
            {
                plot_markers(false);
            }
        }

        void plot_track()
        {
            if (cursor_sign)
            {
                int width_l = 50;
                int width_r = 17;
                double width = (_plot.Width - (width_l + width_r)); //L 46, R123

                if (width < 1)
                {
                    width = 1;
                }

                _hander.Invoke(new Action(() => 
                {
                    //_plot.DataCursors.Channels[0].PositionX = (_plot.PointToClient(Control.MousePosition).X - width_l) / width;
                }));
            }
        }

        void test_set_label() 
        {
            Action<int, String> write = (ind, str) => { _hander._label[ind].Text = str; };
            string[] lab_str = new string[10];

            lab_str[0] = _plot.DataCursors.Channels[0].PositionX.ToString();
        

            _hander.Invoke(new Action(() => lab_str[1] = _plot.PointToClient(Control.MousePosition).X.ToString()));

            //_plot.DataCursors.Channel[0].Pointer2Position.ToString();
            //lab_str[2] = _plot.DataCursors.Channel[0].Pointer1.ToString();
            //lab_str[3] = _plot.DataCursors.Channel[0].Pointer2.ToString();
            //lab_str[4] = plot_channels(0).GetY(0).ToString();
            //string st4 = _plot.DataCursors.XY[0]. .ToString();

            //int cursorX = 0;// int.Parse(_plot.DataCursors.Channels[0].Hint.Text.Split(',')[0]);

            for (int ind = 0; ind < 8; ind++)
            {
                _hander.Invoke(write,ind, lab_str[ind]);
            }

            // Invoke(write, 1, cursorX.ToString());
            //tablex = plot_channels(0).DataCollection.X
        }

        public void task()
        {
            int loop = 0;
            Thread.Sleep(1000);

            while (true)
            {
                loop = (loop + 1) % 100;

                if (loop % 10 == 0)
                {
                    get_wave_axes();
                    plot_zoom();
                }
           
                plot_track();

                test_set_label();

                Thread.Sleep(10);
            }
        }

        wave_axes_s axes = new wave_axes_s();
        bool axes_sign = false;

        void get_wave_axes()
        {
            if (axes_sign == false)
            {
                axes.x_min = _plot.XAxes[0].Min;
                axes.y_min = _plot.YAxes[0].Min;
                axes.x_max = _plot.XAxes[0].Max;
                axes.y_max = _plot.YAxes[0].Max;
                axes.x_span = _plot.XAxes[0].Span;
                axes.y_span = _plot.YAxes[0].Span;
            }
        }

        void set_wave_axes()
        {
            _plot.XAxes[0].Min = axes.x_min;
            _plot.YAxes[0].Min = axes.y_min;
            _plot.XAxes[0].Span = axes.x_span;
            _plot.YAxes[0].Span = axes.y_span;
        }

        private void plot_MouseCaptureChanged(object sender, EventArgs e)
        {
            bool type = false;
            if (_plot.XAxes[0].Span < 500)
            {
                type = true;
            }

            for (int i = 0; i < 10; i++)
            {
                //_plot.Channels[0].MarkersVisible = bl_val;
                //_plot.c
            }
        }

        private void plotTool_MouseUp(object sender, MouseEventArgs e)
        {
            if (track_sign == true)
            {
                track_sign = false;
                set_wave_axes();
            }
        }

        private void plotTool_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            if (e.Button == _hander._click_start_track)
            {
                track_sign = true;
            }

            if (e.Button == _hander._click_cursor)
            {
                if (cursor_sign)
                {
                    cursor_sign = false;
                }
                else
                {
                    cursor_sign = true;
                }
            }
        }
    }
}
