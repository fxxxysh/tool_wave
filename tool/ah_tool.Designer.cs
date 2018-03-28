namespace tool
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
            Iocomp.Classes.PlotChannelTrace plotChannelTrace1 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace2 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace3 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace4 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace5 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace6 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace7 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace8 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace9 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace10 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotDataCursorXY plotDataCursorXY1 = new Iocomp.Classes.PlotDataCursorXY();
            Iocomp.Classes.PlotDataView plotDataView1 = new Iocomp.Classes.PlotDataView();
            Iocomp.Classes.PlotLabelBasic plotLabelBasic1 = new Iocomp.Classes.PlotLabelBasic();
            Iocomp.Classes.PlotLegendBasic plotLegendBasic1 = new Iocomp.Classes.PlotLegendBasic();
            Iocomp.Classes.PlotXAxis plotXAxis1 = new Iocomp.Classes.PlotXAxis();
            Iocomp.Classes.PlotYAxis plotYAxis1 = new Iocomp.Classes.PlotYAxis();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ah_tool));
            this.wave_plot = new Iocomp.Instrumentation.Plotting.Plot();
            this.TabControl_func = new CCWin.SkinControl.SkinTabControl();
            this.TabPage_wave = new CCWin.SkinControl.SkinTabPage();
            this.TabPage_device = new CCWin.SkinControl.SkinTabPage();
            this.TabPage_data = new CCWin.SkinControl.SkinTabPage();
            this.TabControl_func.SuspendLayout();
            this.TabPage_wave.SuspendLayout();
            this.SuspendLayout();
            // 
            // wave_plot
            // 
            this.wave_plot.LoadingBegin();
            this.wave_plot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            plotChannelTrace1.Color = System.Drawing.Color.Red;
            plotChannelTrace1.Name = "Channel 1";
            plotChannelTrace1.TitleText = "CH1";
            plotChannelTrace2.Color = System.Drawing.Color.Blue;
            plotChannelTrace2.Name = "Channel 2";
            plotChannelTrace2.TitleText = "CH2";
            plotChannelTrace3.Color = System.Drawing.Color.Lime;
            plotChannelTrace3.Name = "Channel 3";
            plotChannelTrace3.TitleText = "CH3";
            plotChannelTrace4.Color = System.Drawing.Color.Yellow;
            plotChannelTrace4.Name = "Channel 4";
            plotChannelTrace4.TitleText = "CH4";
            plotChannelTrace5.Color = System.Drawing.Color.Aqua;
            plotChannelTrace5.Name = "Channel 5";
            plotChannelTrace5.TitleText = "CH5";
            plotChannelTrace6.Color = System.Drawing.Color.White;
            plotChannelTrace6.Name = "Channel 6";
            plotChannelTrace6.TitleText = "CH6";
            plotChannelTrace7.Color = System.Drawing.Color.Red;
            plotChannelTrace7.Name = "Channel 7";
            plotChannelTrace7.TitleText = "CH7";
            plotChannelTrace8.Color = System.Drawing.Color.Blue;
            plotChannelTrace8.Name = "Channel 8";
            plotChannelTrace8.TitleText = "CH8";
            plotChannelTrace9.Color = System.Drawing.Color.Lime;
            plotChannelTrace9.Name = "Channel 9";
            plotChannelTrace9.TitleText = "CH9";
            plotChannelTrace10.Color = System.Drawing.Color.Yellow;
            plotChannelTrace10.Name = "Channel 10";
            plotChannelTrace10.TitleText = "CH10";
            this.wave_plot.Channels.Add(plotChannelTrace1);
            this.wave_plot.Channels.Add(plotChannelTrace2);
            this.wave_plot.Channels.Add(plotChannelTrace3);
            this.wave_plot.Channels.Add(plotChannelTrace4);
            this.wave_plot.Channels.Add(plotChannelTrace5);
            this.wave_plot.Channels.Add(plotChannelTrace6);
            this.wave_plot.Channels.Add(plotChannelTrace7);
            this.wave_plot.Channels.Add(plotChannelTrace8);
            this.wave_plot.Channels.Add(plotChannelTrace9);
            this.wave_plot.Channels.Add(plotChannelTrace10);
            this.wave_plot.ContextMenusEnabled = false;
            plotDataCursorXY1.Hint.Fill.Pen.Color = System.Drawing.SystemColors.InfoText;
            plotDataCursorXY1.Name = "Data-Cursor 1";
            plotDataCursorXY1.TitleText = "Data-Cursor 1";
            this.wave_plot.DataCursors.Add(plotDataCursorXY1);
            plotDataView1.Name = "Data-View 1";
            plotDataView1.TitleText = "Data-View 1";
            this.wave_plot.DataViews.Add(plotDataView1);
            plotLabelBasic1.DockOrder = 0;
            plotLabelBasic1.Name = "Label 1";
            plotLabelBasic1.TitleText = "Label 1";
            plotLabelBasic1.Visible = false;
            this.wave_plot.Labels.Add(plotLabelBasic1);
            plotLegendBasic1.DockAutoSizeAlignment = Iocomp.Types.PlotDockAutoSizeAlignment.Far;
            plotLegendBasic1.DockMargin = 0;
            plotLegendBasic1.DockOrder = 0;
            plotLegendBasic1.Name = "Legend 1";
            plotLegendBasic1.TitleText = "Legend 1";
            this.wave_plot.Legends.Add(plotLegendBasic1);
            this.wave_plot.Location = new System.Drawing.Point(0, 0);
            this.wave_plot.Name = "wave_plot";
            this.wave_plot.Size = new System.Drawing.Size(1012, 524);
            this.wave_plot.TabIndex = 0;
            plotXAxis1.DockOrder = 0;
            plotXAxis1.Name = "X-Axis 1";
            plotXAxis1.Title.Text = "X-Axis 1";
            this.wave_plot.XAxes.Add(plotXAxis1);
            plotYAxis1.DockOrder = 0;
            plotYAxis1.Name = "Y-Axis 1";
            plotYAxis1.Title.Text = "Y-Axis 1";
            this.wave_plot.YAxes.Add(plotYAxis1);
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
            this.TabControl_func.Controls.Add(this.TabPage_device);
            this.TabControl_func.Controls.Add(this.TabPage_data);
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
            this.TabControl_func.PageHoverTxtColor = System.Drawing.Color.DeepSkyBlue;
            this.TabControl_func.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Top;
            this.TabControl_func.PageNorml = null;
            this.TabControl_func.PageNormlTxtColor = System.Drawing.Color.White;
            this.TabControl_func.PagePalace = true;
            this.TabControl_func.SelectedIndex = 0;
            this.TabControl_func.Size = new System.Drawing.Size(1015, 566);
            this.TabControl_func.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl_func.TabIndex = 246;
            // 
            // TabPage_wave
            // 
            this.TabPage_wave.BackColor = System.Drawing.Color.SlateGray;
            this.TabPage_wave.Controls.Add(this.wave_plot);
            this.TabPage_wave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPage_wave.Location = new System.Drawing.Point(0, 42);
            this.TabPage_wave.Name = "TabPage_wave";
            this.TabPage_wave.Size = new System.Drawing.Size(1015, 524);
            this.TabPage_wave.TabIndex = 0;
            this.TabPage_wave.TabItemImage = null;
            this.TabPage_wave.Text = "波形";
            // 
            // TabPage_device
            // 
            this.TabPage_device.BackColor = System.Drawing.Color.SlateGray;
            this.TabPage_device.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPage_device.Location = new System.Drawing.Point(0, 42);
            this.TabPage_device.Name = "TabPage_device";
            this.TabPage_device.Size = new System.Drawing.Size(900, 524);
            this.TabPage_device.TabIndex = 2;
            this.TabPage_device.TabItemImage = null;
            this.TabPage_device.Text = "设备";
            // 
            // TabPage_data
            // 
            this.TabPage_data.BackColor = System.Drawing.Color.SlateGray;
            this.TabPage_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPage_data.Location = new System.Drawing.Point(0, 42);
            this.TabPage_data.Name = "TabPage_data";
            this.TabPage_data.Size = new System.Drawing.Size(900, 524);
            this.TabPage_data.TabIndex = 1;
            this.TabPage_data.TabItemImage = null;
            this.TabPage_data.Text = "数据";
            // 
            // ah_tool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(57)))), ((int)(((byte)(64)))));
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.TabControl_func);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ah_tool";
            this.Text = "TOOL";
            this.TabControl_func.ResumeLayout(false);
            this.TabPage_wave.ResumeLayout(false);
            this.TabPage_wave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Iocomp.Instrumentation.Plotting.Plot wave_plot;
        private CCWin.SkinControl.SkinTabControl TabControl_func;
        private CCWin.SkinControl.SkinTabPage TabPage_wave;
        private CCWin.SkinControl.SkinTabPage TabPage_data;
        private CCWin.SkinControl.SkinTabPage TabPage_device;
    }
}

