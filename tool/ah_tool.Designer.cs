﻿namespace tool
{
    partial class ah_tool
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace91 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace92 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace93 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace94 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace95 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace96 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace97 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace98 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace99 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace100 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotDataCursorChannels plotDataCursorChannels10 = new Iocomp.Classes.PlotDataCursorChannels();
            Iocomp.Classes.PlotDataCursorXY plotDataCursorXY10 = new Iocomp.Classes.PlotDataCursorXY();
            Iocomp.Classes.PlotDataView plotDataView10 = new Iocomp.Classes.PlotDataView();
            Iocomp.Classes.PlotLabelBasic plotLabelBasic10 = new Iocomp.Classes.PlotLabelBasic();
            Iocomp.Classes.PlotLegendBasic plotLegendBasic10 = new Iocomp.Classes.PlotLegendBasic();
            Iocomp.Classes.PlotXAxis plotXAxis10 = new Iocomp.Classes.PlotXAxis();
            Iocomp.Classes.PlotYAxis plotYAxis10 = new Iocomp.Classes.PlotYAxis();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ah_tool));
            this.wave_plot = new Iocomp.Instrumentation.Plotting.Plot();
            this.TabControl_func = new CCWin.SkinControl.SkinTabControl();
            this.TabPage_wave = new CCWin.SkinControl.SkinTabPage();
            this.wave_main_panel = new System.Windows.Forms.Panel();
            this.label_test = new System.Windows.Forms.Label();
            this.plotToolBar = new Iocomp.Instrumentation.Plotting.PlotToolBarStandard();
            this.plotToolBarButton1 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton2 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton3 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton4 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton5 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton6 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton7 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton8 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton9 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton10 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton11 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton12 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton13 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton14 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton15 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton16 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton17 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton18 = new Iocomp.Classes.PlotToolBarButton();
            this.ToolBar_image = new System.Windows.Forms.ImageList(this.components);
            this.TabPage_data = new CCWin.SkinControl.SkinTabPage();
            this.TabPage_device = new CCWin.SkinControl.SkinTabPage();
            this.com_toolStrip = new System.Windows.Forms.ToolStrip();
            this.com_port = new System.Windows.Forms.ToolStripComboBox();
            this.com_baudrate = new System.Windows.Forms.ToolStripComboBox();
            this.com_switch = new System.Windows.Forms.ToolStripButton();
            this.com_panel = new System.Windows.Forms.Panel();
            this.TabControl_func.SuspendLayout();
            this.TabPage_wave.SuspendLayout();
            this.wave_main_panel.SuspendLayout();
            this.com_toolStrip.SuspendLayout();
            this.com_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // wave_plot
            // 
            this.wave_plot.LoadingBegin();
            this.wave_plot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wave_plot.AutoSize = false;
            this.wave_plot.Border.Margin = 1;
            this.wave_plot.Border.Style = Iocomp.Types.BorderStyleControl.None;
            plotChannelTrace91.Color = System.Drawing.Color.Red;
            plotChannelTrace91.Name = "Channel 1";
            plotChannelTrace91.TitleText = "CH1";
            plotChannelTrace92.Color = System.Drawing.Color.Blue;
            plotChannelTrace92.Name = "Channel 2";
            plotChannelTrace92.TitleText = "CH2";
            plotChannelTrace93.Color = System.Drawing.Color.Lime;
            plotChannelTrace93.Name = "Channel 3";
            plotChannelTrace93.TitleText = "CH3";
            plotChannelTrace94.Color = System.Drawing.Color.Yellow;
            plotChannelTrace94.Name = "Channel 4";
            plotChannelTrace94.TitleText = "CH4";
            plotChannelTrace95.Color = System.Drawing.Color.Aqua;
            plotChannelTrace95.Name = "Channel 5";
            plotChannelTrace95.TitleText = "CH5";
            plotChannelTrace96.Color = System.Drawing.Color.White;
            plotChannelTrace96.Name = "Channel 6";
            plotChannelTrace96.TitleText = "CH6";
            plotChannelTrace97.Color = System.Drawing.Color.Purple;
            plotChannelTrace97.Name = "Channel 7";
            plotChannelTrace97.TitleText = "CH7";
            plotChannelTrace98.Color = System.Drawing.Color.DeepSkyBlue;
            plotChannelTrace98.Name = "Channel 8";
            plotChannelTrace98.TitleText = "CH8";
            plotChannelTrace99.Color = System.Drawing.Color.LightSeaGreen;
            plotChannelTrace99.Name = "Channel 9";
            plotChannelTrace99.TitleText = "CH9";
            plotChannelTrace100.Color = System.Drawing.Color.OliveDrab;
            plotChannelTrace100.Name = "Channel 10";
            plotChannelTrace100.TitleText = "CH110";
            this.wave_plot.Channels.Add(plotChannelTrace91);
            this.wave_plot.Channels.Add(plotChannelTrace92);
            this.wave_plot.Channels.Add(plotChannelTrace93);
            this.wave_plot.Channels.Add(plotChannelTrace94);
            this.wave_plot.Channels.Add(plotChannelTrace95);
            this.wave_plot.Channels.Add(plotChannelTrace96);
            this.wave_plot.Channels.Add(plotChannelTrace97);
            this.wave_plot.Channels.Add(plotChannelTrace98);
            this.wave_plot.Channels.Add(plotChannelTrace99);
            this.wave_plot.Channels.Add(plotChannelTrace100);
            plotDataCursorChannels10.Hint.Fill.Pen.Color = System.Drawing.SystemColors.InfoText;
            plotDataCursorChannels10.Name = "Data-Cursor 2";
            plotDataCursorChannels10.TitleText = "Data-Cursor 2";
            plotDataCursorXY10.Hint.Fill.Pen.Color = System.Drawing.SystemColors.InfoText;
            plotDataCursorXY10.Name = "Data-Cursor 3";
            plotDataCursorXY10.TitleText = "Data-Cursor 3";
            this.wave_plot.DataCursors.Add(plotDataCursorChannels10);
            this.wave_plot.DataCursors.Add(plotDataCursorXY10);
            plotDataView10.DockMargin = 0;
            plotDataView10.Name = "Data-View 1";
            plotDataView10.TitleText = "Data-View 1";
            this.wave_plot.DataViews.Add(plotDataView10);
            this.wave_plot.DefaultGridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.wave_plot.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wave_plot.ForeColor = System.Drawing.Color.WhiteSmoke;
            plotLabelBasic10.DockOrder = 0;
            plotLabelBasic10.Enabled = false;
            plotLabelBasic10.Name = "Label 1";
            plotLabelBasic10.TitleText = "Label 1";
            plotLabelBasic10.Visible = false;
            this.wave_plot.Labels.Add(plotLabelBasic10);
            plotLegendBasic10.CanFocus = false;
            plotLegendBasic10.DockAutoSizeAlignment = Iocomp.Types.PlotDockAutoSizeAlignment.Center;
            plotLegendBasic10.DockDataViewName = "";
            plotLegendBasic10.DockMargin = 0;
            plotLegendBasic10.DockOrder = 0;
            plotLegendBasic10.DockSide = Iocomp.Types.AlignmentQuadSide.Bottom;
            plotLegendBasic10.Name = "Legend 1";
            plotLegendBasic10.Spacing = 4D;
            plotLegendBasic10.TitleMargin = 0.5D;
            plotLegendBasic10.TitleText = "Legend 1";
            this.wave_plot.Legends.Add(plotLegendBasic10);
            this.wave_plot.Location = new System.Drawing.Point(0, 28);
            this.wave_plot.Margin = new System.Windows.Forms.Padding(0);
            this.wave_plot.Name = "wave_plot";
            this.wave_plot.Size = new System.Drawing.Size(1015, 368);
            this.wave_plot.TabIndex = 0;
            plotXAxis10.DockOrder = 0;
            plotXAxis10.Name = "X-Axis 1";
            plotXAxis10.ScaleDisplay.Margin = 0;
            plotXAxis10.ScaleDisplay.TextFormatting.Precision = 0;
            plotXAxis10.ScaleDisplay.TextWidthMinValue = 0D;
            plotXAxis10.ScaleDisplay.TickMajor.Length = 6;
            plotXAxis10.ScaleRange.Span = 5000D;
            plotXAxis10.Title.Text = "X-Axis 1";
            plotXAxis10.Tracking.Enabled = false;
            this.wave_plot.XAxes.Add(plotXAxis10);
            plotYAxis10.DockOrder = 0;
            plotYAxis10.Name = "Y-Axis 1";
            plotYAxis10.ScaleDisplay.Margin = 0;
            plotYAxis10.ScaleDisplay.TextFormatting.Precision = 0;
            plotYAxis10.ScaleDisplay.TextWidthMinValue = 0D;
            plotYAxis10.ScaleDisplay.TickMajor.Length = 6;
            plotYAxis10.ScaleRange.Min = 500D;
            plotYAxis10.ScaleRange.Span = 1000D;
            plotYAxis10.Title.Text = "Y-Axis 1";
            this.wave_plot.YAxes.Add(plotYAxis10);
            this.wave_plot.LoadingEnd();
            // 
            // TabControl_func
            // 
            this.TabControl_func.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl_func.AnimatorType = CCWin.SkinControl.AnimationType.HorizSlide;
            this.TabControl_func.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.TabControl_func.Controls.Add(this.TabPage_wave);
            this.TabControl_func.Controls.Add(this.TabPage_data);
            this.TabControl_func.Controls.Add(this.TabPage_device);
            this.TabControl_func.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TabControl_func.HeadBack = null;
            this.TabControl_func.ImgTxtOffset = new System.Drawing.Point(0, 0);
            this.TabControl_func.ItemSize = new System.Drawing.Size(50, 42);
            this.TabControl_func.Location = new System.Drawing.Point(-1, -1);
            this.TabControl_func.Margin = new System.Windows.Forms.Padding(0);
            this.TabControl_func.Multiline = true;
            this.TabControl_func.Name = "TabControl_func";
            this.TabControl_func.PageArrowDown = null;
            this.TabControl_func.PageArrowHover = null;
            this.TabControl_func.PageBaseColor = System.Drawing.Color.Red;
            this.TabControl_func.PageBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TabControl_func.PageCloseHover = null;
            this.TabControl_func.PageCloseNormal = null;
            this.TabControl_func.PageDown = global::tool.Properties.Resources.button_down;
            this.TabControl_func.PageHover = null;
            this.TabControl_func.PageHoverTxtColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(202)))), ((int)(((byte)(99)))));
            this.TabControl_func.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Top;
            this.TabControl_func.PageNorml = null;
            this.TabControl_func.PageNormlTxtColor = System.Drawing.Color.White;
            this.TabControl_func.PagePalace = true;
            this.TabControl_func.SelectedIndex = 0;
            this.TabControl_func.Size = new System.Drawing.Size(1015, 564);
            this.TabControl_func.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl_func.TabIndex = 246;
            // 
            // TabPage_wave
            // 
            this.TabPage_wave.BackColor = System.Drawing.Color.SlateGray;
            this.TabPage_wave.Controls.Add(this.wave_main_panel);
            this.TabPage_wave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPage_wave.Location = new System.Drawing.Point(0, 42);
            this.TabPage_wave.Name = "TabPage_wave";
            this.TabPage_wave.Size = new System.Drawing.Size(1015, 522);
            this.TabPage_wave.TabIndex = 0;
            this.TabPage_wave.TabItemImage = null;
            this.TabPage_wave.Text = "波形";
            // 
            // wave_main_panel
            // 
            this.wave_main_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wave_main_panel.BackColor = System.Drawing.Color.Gainsboro;
            this.wave_main_panel.Controls.Add(this.label_test);
            this.wave_main_panel.Controls.Add(this.plotToolBar);
            this.wave_main_panel.Controls.Add(this.wave_plot);
            this.wave_main_panel.Location = new System.Drawing.Point(0, 0);
            this.wave_main_panel.Margin = new System.Windows.Forms.Padding(0);
            this.wave_main_panel.Name = "wave_main_panel";
            this.wave_main_panel.Size = new System.Drawing.Size(1015, 498);
            this.wave_main_panel.TabIndex = 1;
            // 
            // label_test
            // 
            this.label_test.AutoSize = true;
            this.label_test.Location = new System.Drawing.Point(66, 431);
            this.label_test.Name = "label_test";
            this.label_test.Size = new System.Drawing.Size(72, 20);
            this.label_test.TabIndex = 2;
            this.label_test.Text = "label_test";
            // 
            // plotToolBar
            // 
            this.plotToolBar.LoadingBegin();
            this.plotToolBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.plotToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.plotToolBarButton1,
            this.plotToolBarButton2,
            this.plotToolBarButton3,
            this.plotToolBarButton4,
            this.plotToolBarButton5,
            this.plotToolBarButton6,
            this.plotToolBarButton7,
            this.plotToolBarButton8,
            this.plotToolBarButton9,
            this.plotToolBarButton10,
            this.plotToolBarButton11,
            this.plotToolBarButton12,
            this.plotToolBarButton13,
            this.plotToolBarButton14,
            this.plotToolBarButton15,
            this.plotToolBarButton16,
            this.plotToolBarButton17,
            this.plotToolBarButton18});
            this.plotToolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.plotToolBar.DropDownArrows = true;
            this.plotToolBar.ImageList = this.ToolBar_image;
            this.plotToolBar.Location = new System.Drawing.Point(0, 0);
            this.plotToolBar.Margin = new System.Windows.Forms.Padding(0);
            this.plotToolBar.Name = "plotToolBar";
            this.plotToolBar.Plot = this.wave_plot;
            this.plotToolBar.ShowToolTips = true;
            this.plotToolBar.Size = new System.Drawing.Size(1012, 28);
            this.plotToolBar.TabIndex = 1;
            this.plotToolBar.LoadingEnd();
            // 
            // plotToolBarButton1
            // 
            this.plotToolBarButton1.LoadingBegin();
            this.plotToolBarButton1.ImageIndex = 0;
            this.plotToolBarButton1.Name = "plotToolBarButton1";
            this.plotToolBarButton1.ToolTipText = "Tracking Resume";
            this.plotToolBarButton1.LoadingEnd();
            // 
            // plotToolBarButton2
            // 
            this.plotToolBarButton2.LoadingBegin();
            this.plotToolBarButton2.Command = Iocomp.Types.PlotToolBarCommandStyle.TrackingPause;
            this.plotToolBarButton2.ImageIndex = 1;
            this.plotToolBarButton2.Name = "plotToolBarButton2";
            this.plotToolBarButton2.ToolTipText = "Tracking Pause";
            this.plotToolBarButton2.LoadingEnd();
            // 
            // plotToolBarButton3
            // 
            this.plotToolBarButton3.LoadingBegin();
            this.plotToolBarButton3.Command = Iocomp.Types.PlotToolBarCommandStyle.Separator;
            this.plotToolBarButton3.Enabled = false;
            this.plotToolBarButton3.Name = "plotToolBarButton3";
            this.plotToolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.plotToolBarButton3.LoadingEnd();
            // 
            // plotToolBarButton4
            // 
            this.plotToolBarButton4.LoadingBegin();
            this.plotToolBarButton4.Command = Iocomp.Types.PlotToolBarCommandStyle.AxesScroll;
            this.plotToolBarButton4.ImageIndex = 2;
            this.plotToolBarButton4.Name = "plotToolBarButton4";
            this.plotToolBarButton4.Pushed = true;
            this.plotToolBarButton4.ToolTipText = "Axes Scroll";
            this.plotToolBarButton4.LoadingEnd();
            // 
            // plotToolBarButton5
            // 
            this.plotToolBarButton5.LoadingBegin();
            this.plotToolBarButton5.Command = Iocomp.Types.PlotToolBarCommandStyle.AxesZoom;
            this.plotToolBarButton5.ImageIndex = 3;
            this.plotToolBarButton5.Name = "plotToolBarButton5";
            this.plotToolBarButton5.ToolTipText = "Axes Zoom";
            this.plotToolBarButton5.LoadingEnd();
            // 
            // plotToolBarButton6
            // 
            this.plotToolBarButton6.LoadingBegin();
            this.plotToolBarButton6.Command = Iocomp.Types.PlotToolBarCommandStyle.Separator;
            this.plotToolBarButton6.Enabled = false;
            this.plotToolBarButton6.Name = "plotToolBarButton6";
            this.plotToolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.plotToolBarButton6.LoadingEnd();
            // 
            // plotToolBarButton7
            // 
            this.plotToolBarButton7.LoadingBegin();
            this.plotToolBarButton7.Command = Iocomp.Types.PlotToolBarCommandStyle.ZoomOut;
            this.plotToolBarButton7.ImageIndex = 4;
            this.plotToolBarButton7.Name = "plotToolBarButton7";
            this.plotToolBarButton7.ToolTipText = "Zoom-Out";
            this.plotToolBarButton7.LoadingEnd();
            // 
            // plotToolBarButton8
            // 
            this.plotToolBarButton8.LoadingBegin();
            this.plotToolBarButton8.Command = Iocomp.Types.PlotToolBarCommandStyle.ZoomIn;
            this.plotToolBarButton8.ImageIndex = 5;
            this.plotToolBarButton8.Name = "plotToolBarButton8";
            this.plotToolBarButton8.ToolTipText = "Zoom-In";
            this.plotToolBarButton8.LoadingEnd();
            // 
            // plotToolBarButton9
            // 
            this.plotToolBarButton9.LoadingBegin();
            this.plotToolBarButton9.Command = Iocomp.Types.PlotToolBarCommandStyle.Separator;
            this.plotToolBarButton9.Enabled = false;
            this.plotToolBarButton9.Name = "plotToolBarButton9";
            this.plotToolBarButton9.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.plotToolBarButton9.LoadingEnd();
            // 
            // plotToolBarButton10
            // 
            this.plotToolBarButton10.LoadingBegin();
            this.plotToolBarButton10.Command = Iocomp.Types.PlotToolBarCommandStyle.Select;
            this.plotToolBarButton10.ImageIndex = 6;
            this.plotToolBarButton10.Name = "plotToolBarButton10";
            this.plotToolBarButton10.Pushed = true;
            this.plotToolBarButton10.ToolTipText = "Select";
            this.plotToolBarButton10.LoadingEnd();
            // 
            // plotToolBarButton11
            // 
            this.plotToolBarButton11.LoadingBegin();
            this.plotToolBarButton11.Command = Iocomp.Types.PlotToolBarCommandStyle.ZoomBox;
            this.plotToolBarButton11.ImageIndex = 7;
            this.plotToolBarButton11.Name = "plotToolBarButton11";
            this.plotToolBarButton11.ToolTipText = "Zoom-Box";
            this.plotToolBarButton11.LoadingEnd();
            // 
            // plotToolBarButton12
            // 
            this.plotToolBarButton12.LoadingBegin();
            this.plotToolBarButton12.Command = Iocomp.Types.PlotToolBarCommandStyle.DataCursor;
            this.plotToolBarButton12.ImageIndex = 8;
            this.plotToolBarButton12.Name = "plotToolBarButton12";
            this.plotToolBarButton12.ToolTipText = "Data-Cursor";
            this.plotToolBarButton12.LoadingEnd();
            // 
            // plotToolBarButton13
            // 
            this.plotToolBarButton13.LoadingBegin();
            this.plotToolBarButton13.Command = Iocomp.Types.PlotToolBarCommandStyle.Separator;
            this.plotToolBarButton13.Enabled = false;
            this.plotToolBarButton13.Name = "plotToolBarButton13";
            this.plotToolBarButton13.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.plotToolBarButton13.LoadingEnd();
            // 
            // plotToolBarButton14
            // 
            this.plotToolBarButton14.LoadingBegin();
            this.plotToolBarButton14.Command = Iocomp.Types.PlotToolBarCommandStyle.Edit;
            this.plotToolBarButton14.ImageIndex = 9;
            this.plotToolBarButton14.Name = "plotToolBarButton14";
            this.plotToolBarButton14.ToolTipText = "Edit";
            this.plotToolBarButton14.LoadingEnd();
            // 
            // plotToolBarButton15
            // 
            this.plotToolBarButton15.LoadingBegin();
            this.plotToolBarButton15.Command = Iocomp.Types.PlotToolBarCommandStyle.Separator;
            this.plotToolBarButton15.Enabled = false;
            this.plotToolBarButton15.Name = "plotToolBarButton15";
            this.plotToolBarButton15.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.plotToolBarButton15.LoadingEnd();
            // 
            // plotToolBarButton16
            // 
            this.plotToolBarButton16.LoadingBegin();
            this.plotToolBarButton16.Command = Iocomp.Types.PlotToolBarCommandStyle.Copy;
            this.plotToolBarButton16.ImageIndex = 10;
            this.plotToolBarButton16.Name = "plotToolBarButton16";
            this.plotToolBarButton16.ToolTipText = "Copy to Clipboard";
            this.plotToolBarButton16.LoadingEnd();
            // 
            // plotToolBarButton17
            // 
            this.plotToolBarButton17.LoadingBegin();
            this.plotToolBarButton17.Command = Iocomp.Types.PlotToolBarCommandStyle.Save;
            this.plotToolBarButton17.ImageIndex = 11;
            this.plotToolBarButton17.Name = "plotToolBarButton17";
            this.plotToolBarButton17.ToolTipText = "Save";
            this.plotToolBarButton17.LoadingEnd();
            // 
            // plotToolBarButton18
            // 
            this.plotToolBarButton18.LoadingBegin();
            this.plotToolBarButton18.Command = Iocomp.Types.PlotToolBarCommandStyle.Separator;
            this.plotToolBarButton18.Enabled = false;
            this.plotToolBarButton18.Name = "plotToolBarButton18";
            this.plotToolBarButton18.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.plotToolBarButton18.LoadingEnd();
            // 
            // ToolBar_image
            // 
            this.ToolBar_image.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ToolBar_image.ImageStream")));
            this.ToolBar_image.TransparentColor = System.Drawing.Color.Transparent;
            this.ToolBar_image.Images.SetKeyName(0, "");
            this.ToolBar_image.Images.SetKeyName(1, "");
            this.ToolBar_image.Images.SetKeyName(2, "");
            this.ToolBar_image.Images.SetKeyName(3, "");
            this.ToolBar_image.Images.SetKeyName(4, "");
            this.ToolBar_image.Images.SetKeyName(5, "");
            this.ToolBar_image.Images.SetKeyName(6, "");
            this.ToolBar_image.Images.SetKeyName(7, "");
            this.ToolBar_image.Images.SetKeyName(8, "");
            this.ToolBar_image.Images.SetKeyName(9, "");
            this.ToolBar_image.Images.SetKeyName(10, "");
            this.ToolBar_image.Images.SetKeyName(11, "");
            this.ToolBar_image.Images.SetKeyName(12, "");
            this.ToolBar_image.Images.SetKeyName(13, "");
            // 
            // TabPage_data
            // 
            this.TabPage_data.BackColor = System.Drawing.Color.SlateGray;
            this.TabPage_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPage_data.Location = new System.Drawing.Point(0, 42);
            this.TabPage_data.Name = "TabPage_data";
            this.TabPage_data.Size = new System.Drawing.Size(1015, 522);
            this.TabPage_data.TabIndex = 1;
            this.TabPage_data.TabItemImage = null;
            this.TabPage_data.Text = "数据";
            // 
            // TabPage_device
            // 
            this.TabPage_device.BackColor = System.Drawing.Color.SlateGray;
            this.TabPage_device.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPage_device.Location = new System.Drawing.Point(0, 42);
            this.TabPage_device.Name = "TabPage_device";
            this.TabPage_device.Size = new System.Drawing.Size(1015, 522);
            this.TabPage_device.TabIndex = 2;
            this.TabPage_device.TabItemImage = null;
            this.TabPage_device.Text = "设备";
            // 
            // com_toolStrip
            // 
            this.com_toolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.com_toolStrip.BackColor = System.Drawing.Color.Transparent;
            this.com_toolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.com_toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.com_toolStrip.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.com_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.com_toolStrip.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.com_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.com_port,
            this.com_baudrate,
            this.com_switch});
            this.com_toolStrip.Location = new System.Drawing.Point(421, 2);
            this.com_toolStrip.Name = "com_toolStrip";
            this.com_toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.com_toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.com_toolStrip.Size = new System.Drawing.Size(257, 42);
            this.com_toolStrip.TabIndex = 4;
            this.com_toolStrip.Text = "com_toolStrip";
            // 
            // com_port
            // 
            this.com_port.BackColor = System.Drawing.Color.White;
            this.com_port.DropDownWidth = 200;
            this.com_port.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.com_port.ForeColor = System.Drawing.Color.Black;
            this.com_port.Margin = new System.Windows.Forms.Padding(0, 1, 20, 2);
            this.com_port.MaxLength = 200;
            this.com_port.Name = "com_port";
            this.com_port.Size = new System.Drawing.Size(100, 39);
            this.com_port.Sorted = true;
            this.com_port.Text = "AUTO";
            this.com_port.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // com_baudrate
            // 
            this.com_baudrate.BackColor = System.Drawing.Color.White;
            this.com_baudrate.ForeColor = System.Drawing.Color.Black;
            this.com_baudrate.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000",
            "153600",
            "230400",
            "250000",
            "256000",
            "460800",
            "500000",
            "576000",
            "625000"});
            this.com_baudrate.Margin = new System.Windows.Forms.Padding(0, 1, 20, 2);
            this.com_baudrate.Name = "com_baudrate";
            this.com_baudrate.Size = new System.Drawing.Size(75, 39);
            this.com_baudrate.Text = "115200";
            this.com_baudrate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // com_switch
            // 
            this.com_switch.AutoToolTip = false;
            this.com_switch.BackColor = System.Drawing.Color.Transparent;
            this.com_switch.CheckOnClick = true;
            this.com_switch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.com_switch.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.com_switch.Image = ((System.Drawing.Image)(resources.GetObject("com_switch.Image")));
            this.com_switch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.com_switch.Name = "com_switch";
            this.com_switch.Size = new System.Drawing.Size(39, 39);
            this.com_switch.Text = "端口";
            // 
            // com_panel
            // 
            this.com_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.com_panel.BackColor = System.Drawing.Color.Transparent;
            this.com_panel.Controls.Add(this.com_toolStrip);
            this.com_panel.Location = new System.Drawing.Point(299, -1);
            this.com_panel.Margin = new System.Windows.Forms.Padding(0);
            this.com_panel.Name = "com_panel";
            this.com_panel.Size = new System.Drawing.Size(709, 42);
            this.com_panel.TabIndex = 5;
            // 
            // ah_tool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(57)))), ((int)(((byte)(64)))));
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.com_panel);
            this.Controls.Add(this.TabControl_func);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ah_tool";
            this.Text = "TOOL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ah_tool_FormClosing);
            this.TabControl_func.ResumeLayout(false);
            this.TabPage_wave.ResumeLayout(false);
            this.wave_main_panel.ResumeLayout(false);
            this.wave_main_panel.PerformLayout();
            this.com_toolStrip.ResumeLayout(false);
            this.com_toolStrip.PerformLayout();
            this.com_panel.ResumeLayout(false);
            this.com_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Iocomp.Instrumentation.Plotting.Plot wave_plot;
        private CCWin.SkinControl.SkinTabControl TabControl_func;
        private CCWin.SkinControl.SkinTabPage TabPage_wave;
        private CCWin.SkinControl.SkinTabPage TabPage_data;
        private CCWin.SkinControl.SkinTabPage TabPage_device;
        private System.Windows.Forms.ToolStrip com_toolStrip;
        private System.Windows.Forms.ToolStripComboBox com_port;
        private System.Windows.Forms.ToolStripComboBox com_baudrate;
        private System.Windows.Forms.ToolStripButton com_switch;
        private System.Windows.Forms.Panel com_panel;
        private System.Windows.Forms.Panel wave_main_panel;
        private Iocomp.Instrumentation.Plotting.PlotToolBarStandard plotToolBar;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton1;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton2;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton3;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton4;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton5;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton6;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton7;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton8;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton9;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton10;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton11;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton12;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton13;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton14;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton15;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton16;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton17;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton18;
        private System.Windows.Forms.ImageList ToolBar_image;
        private System.Windows.Forms.Label label_test;
    }
}

