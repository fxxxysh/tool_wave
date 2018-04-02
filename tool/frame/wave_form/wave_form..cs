﻿using System;
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

        public wave_form(ah_tool hander)
        {
            _hander = hander;

            mode_init();
            event_init();
        }

        void event_init()
        {
            _hander._plotTool.MouseUp += new MouseEventHandler(plotTool_MouseUp);
            _hander._plotTool.ButtonClick += new ToolBarButtonClickEventHandler(plotTool_ButtonClick);
            _hander._plot.MouseCaptureChanged += new EventHandler(plot_MouseCaptureChanged);
        }

        void mode_init()
        {
            Thread th = new Thread(task)
            { Priority = ThreadPriority.AboveNormal, IsBackground = true };
            th.Start();
        }

        struct wave_axes_s
        {
            public double x_min;
            public double y_min;
            public double x_span;
            public double y_span;
        };

        public PlotChannelTrace plot_channels(int channel)
        {
            return (PlotChannelTrace)_hander._plot.Channels[channel];
        }

        public void plot_markers(bool state)
        {
            for (int channel = 0; channel < 10; channel++)
            {
                plot_channels(channel).Markers.Visible = state;
            }
        }

        public void task()
        {
            Thread.Sleep(1000);
            Action<int, String> write = (ind,str) => { _hander._label[ind].Text = str; };
            string[] lab_str = new string[10] { "", "", "", "", "", "", "", "", "", "" };

            while (true)
            {
                if (_hander._plot.XAxes[0].Span < 500)
                {
                    plot_markers(true);
                }
                else
                {
                    plot_markers(false);
                }


                lab_str[0] = "123";// _hander._plot.DataCursors.Channel[0].Pointer1Position.ToString();
                lab_str[1] = _hander._plot.DataCursors.Channel[0].Pointer2Position.ToString();
                lab_str[2] = _hander._plot.DataCursors.Channel[0].Pointer1.ToString();
                lab_str[3] = _hander._plot.DataCursors.Channel[0].Pointer2.ToString();
                lab_str[4] = plot_channels(0).GetY(0).ToString();
                //string st4 = _hander._plot.DataCursors.XY[0]. .ToString();

                //int cursorX = 0;// int.Parse(_hander._plot.DataCursors.Channels[0].Hint.Text.Split(',')[0]);

                for (int ind = 0; ind < 8; ind++)
                {
                    _hander.Invoke(write,ind, lab_str[ind]);
                }
               
               // _hander.Invoke(write, 1, cursorX.ToString());
                //tablex = plot_channels(0).DataCollection.X
                get_wave_axes();
                Thread.Sleep(100);
            }
        }

        wave_axes_s axes = new wave_axes_s();
        bool axes_sign = false;

        void get_wave_axes()
        {
            if (axes_sign == false)
            {
                axes.x_min = _hander._plot.XAxes[0].Min;
                axes.y_min = _hander._plot.YAxes[0].Min;
                axes.x_span = _hander._plot.XAxes[0].Span;
                axes.y_span = _hander._plot.YAxes[0].Span;
            }
        }

        void set_wave_axes()
        {
            _hander._plot.XAxes[0].Min = axes.x_min;
            _hander._plot.YAxes[0].Min = axes.y_min;
            _hander._plot.XAxes[0].Span = axes.x_span;
            _hander._plot.YAxes[0].Span = axes.y_span;
        }

        private void plot_MouseCaptureChanged(object sender, EventArgs e)
        {
            bool type = false;
            if (_hander._plot.XAxes[0].Span < 500)
            {
                type = true;
            }

            for (int i = 0; i < 10; i++)
            {
                //_hander._plot.Channels[0].MarkersVisible = bl_val;
                //_hander._plot.c
            }
        }

        private void plotTool_MouseUp(object sender, MouseEventArgs e)
        {
            if (axes_sign == true)
            {
                axes_sign = false;
                set_wave_axes();
            }
        }

        private void plotTool_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            if (e.Button == _hander._track)
            {
                axes_sign = true;

            }
        }
    }
}
