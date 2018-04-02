using Iocomp.Classes;
using Iocomp.Design;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Windows.Forms;
using ToolboxBitmaps;

namespace Iocomp.Instrumentation.Plotting
{
	[ToolboxBitmap(typeof(Access), "PlotToolBar.bmp")]
	[Description("Plot ToolBar Standard")]
	[DesignerSerializer(typeof(LoadBeginEndSerializerPlotToolBarStandard), typeof(CodeDomSerializer))]
	[ToolboxItem(true)]
	[DefaultEvent("ButtonClick")]
	[DesignerCategory("code")]
	[Designer(typeof(PlotToolBarStandardDesigner))]
	public class PlotToolBarStandard : ToolBar, ISetDesignerDefaults
	{
		private Plot m_Plot;

		private ContextMenu m_MenuResume;

		private ContextMenu m_MenuCopy;

		protected override Size DefaultSize => new Size(500, 42);

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public Plot Plot
		{
			get
			{
				return m_Plot;
			}
			set
			{
				if (value != m_Plot)
				{
					if (m_Plot != null)
					{
						m_Plot.ToolBarAdapter.Changed -= ToolBarAdapter_Changed;
					}
					m_Plot = value;
					if (m_Plot != null)
					{
						m_Plot.ToolBarAdapter.Changed += ToolBarAdapter_Changed;
						ToolBarAdapter_Changed(null, null);
					}
				}
			}
		}

		void ISetDesignerDefaults.DoDefaults(IDesignerHost host)
		{
			DoDefaults(host);
		}

		public PlotToolBarStandard()
		{
			base.Appearance = ToolBarAppearance.Flat;
		}

		public virtual void LoadingBegin()
		{
		}

		public virtual void LoadingEnd()
		{
			if (m_Plot != null)
			{
				ToolBarAdapter_Changed(null, null);
			}
			m_MenuResume = new ContextMenu();
			MenuItem menuItem = new MenuItem();
			menuItem.Click += ResumeAll_Click;
			menuItem.Text = "Resume All";
			m_MenuResume.MenuItems.Add(menuItem);
			menuItem = new MenuItem();
			menuItem.Click += ResumeSelected_Click;
			menuItem.Text = "Resume Selected";
			m_MenuResume.MenuItems.Add(menuItem);
			m_MenuCopy = new ContextMenu();
			m_MenuCopy.MenuItems.Add(new MenuItem("Copy Picture", CopyPicture_Click));
			m_MenuCopy.MenuItems.Add(new MenuItem("Copy Data", CopyData_Click));
		}

		private void ResumeAll_Click(object sender, EventArgs e)
		{
			Plot.ToolBarAdapter.DoButtonClickTrackingResumeAll();
		}

		private void ResumeSelected_Click(object sender, EventArgs e)
		{
			Plot.ToolBarAdapter.DoButtonClickTrackingResumeSelected();
		}

		private void CopyPicture_Click(object sender, EventArgs e)
		{
			Plot.ToolBarAdapter.DoButtonClickCopyPicture();
		}

		private void CopyData_Click(object sender, EventArgs e)
		{
			Plot.ToolBarAdapter.DoButtonClickCopyData();
		}

		private PlotToolBarButton CreateButton(IDesignerHost host, PlotToolBarCommandStyle command)
		{
			PlotToolBarButton plotToolBarButton = (PlotToolBarButton)host.CreateComponent(typeof(PlotToolBarButton));
			plotToolBarButton.Command = command;
			base.Buttons.Add(plotToolBarButton);
			return plotToolBarButton;
		}

		[Description("")]
		public void SetupButton(PlotToolBarButton value)
		{
			if (value.Command == PlotToolBarCommandStyle.TrackingResume)
			{
				value.DropDownMenu = m_MenuResume;
				value.Style = ToolBarButtonStyle.DropDownButton;
			}
			else if (value.Command == PlotToolBarCommandStyle.Copy)
			{
				value.DropDownMenu = m_MenuCopy;
				value.Style = ToolBarButtonStyle.DropDownButton;
			}
		}

		private void DoDefaults(IDesignerHost host)
		{
			CreateButton(host, PlotToolBarCommandStyle.TrackingResume);
			CreateButton(host, PlotToolBarCommandStyle.TrackingPause);
			CreateButton(host, PlotToolBarCommandStyle.Separator);
			CreateButton(host, PlotToolBarCommandStyle.AxesScroll);
			CreateButton(host, PlotToolBarCommandStyle.AxesZoom);
			CreateButton(host, PlotToolBarCommandStyle.Separator);
			CreateButton(host, PlotToolBarCommandStyle.ZoomOut);
			CreateButton(host, PlotToolBarCommandStyle.ZoomIn);
			CreateButton(host, PlotToolBarCommandStyle.Separator);
			CreateButton(host, PlotToolBarCommandStyle.Select);
			CreateButton(host, PlotToolBarCommandStyle.ZoomBox);
			CreateButton(host, PlotToolBarCommandStyle.DataCursor);
			CreateButton(host, PlotToolBarCommandStyle.Separator);
			CreateButton(host, PlotToolBarCommandStyle.Edit);
			CreateButton(host, PlotToolBarCommandStyle.Separator);
			CreateButton(host, PlotToolBarCommandStyle.Copy);
			CreateButton(host, PlotToolBarCommandStyle.Save);
			CreateButton(host, PlotToolBarCommandStyle.Separator);
			CreateButton(host, PlotToolBarCommandStyle.Print);
			CreateButton(host, PlotToolBarCommandStyle.Preview);
			CreateButton(host, PlotToolBarCommandStyle.PageSetup);
		}

		protected override void OnButtonClick(ToolBarButtonClickEventArgs e)
		{
			base.OnButtonClick(e);
			if (e.Button != null && Plot != null && e.Button is PlotToolBarButton)
			{
				switch ((e.Button as PlotToolBarButton).Command)
				{
				case PlotToolBarCommandStyle.TrackingResume:
					Plot.ToolBarAdapter.DoButtonClickTrackingResumeAll();
					break;
				case PlotToolBarCommandStyle.TrackingPause:
					Plot.ToolBarAdapter.DoButtonClickTrackingPause();
					break;
				case PlotToolBarCommandStyle.AxesScroll:
					Plot.ToolBarAdapter.DoButtonClickAxesScroll();
					break;
				case PlotToolBarCommandStyle.AxesZoom:
					Plot.ToolBarAdapter.DoButtonClickAxesZoom();
					break;
				case PlotToolBarCommandStyle.ZoomIn:
					Plot.ToolBarAdapter.DoButtonClickZoomIn();
					break;
				case PlotToolBarCommandStyle.ZoomOut:
					Plot.ToolBarAdapter.DoButtonClickZoomOut();
					break;
				case PlotToolBarCommandStyle.Select:
					Plot.ToolBarAdapter.DoButtonClickSelect();
					break;
				case PlotToolBarCommandStyle.ZoomBox:
					Plot.ToolBarAdapter.DoButtonClickZoomBox();
					break;
				case PlotToolBarCommandStyle.DataCursor:
					Plot.ToolBarAdapter.DoButtonClickDataCursor();
					break;
				case PlotToolBarCommandStyle.Save:
					Plot.ToolBarAdapter.DoButtonClickSave();
					break;
				case PlotToolBarCommandStyle.Edit:
					Plot.ToolBarAdapter.DoButtonClickEdit();
					break;
				case PlotToolBarCommandStyle.Copy:
					Plot.ToolBarAdapter.DoButtonClickCopy();
					break;
				case PlotToolBarCommandStyle.Print:
					Plot.ToolBarAdapter.DoButtonClickPrint();
					break;
				case PlotToolBarCommandStyle.Preview:
					Plot.ToolBarAdapter.DoButtonClickPrintPreview();
					break;
				case PlotToolBarCommandStyle.PageSetup:
					Plot.ToolBarAdapter.DoButtonClickPrintPageSetup();
					break;
				}
			}
		}

		private void ToolBarAdapter_Changed(object sender, EventArgs e)
		{
			if (Plot != null)
			{
				PlotToolBarAdapter toolBarAdapter = Plot.ToolBarAdapter;
				for (int i = 0; i < base.Buttons.Count; i++)
				{
					PlotToolBarButton plotToolBarButton = base.Buttons[i] as PlotToolBarButton;
					if (plotToolBarButton != null)
					{
						PlotToolBarCommandStyle command = plotToolBarButton.Command;
						if (command == PlotToolBarCommandStyle.TrackingResume)
						{
							plotToolBarButton.Enabled = toolBarAdapter.AxesTrackingAnyDisabled;
						}
						if (command == PlotToolBarCommandStyle.TrackingPause)
						{
							plotToolBarButton.Enabled = toolBarAdapter.AxesTrackingAnyEnabled;
						}
						if (command == PlotToolBarCommandStyle.AxesScroll)
						{
							plotToolBarButton.Pushed = (toolBarAdapter.AxisMouseMode == PlotAxisMouseMode.Scroll);
						}
						if (command == PlotToolBarCommandStyle.AxesZoom)
						{
							plotToolBarButton.Pushed = (toolBarAdapter.AxisMouseMode == PlotAxisMouseMode.Zoom);
						}
						if (command == PlotToolBarCommandStyle.Select)
						{
							plotToolBarButton.Pushed = (toolBarAdapter.DataViewMouseMode == PlotDataViewMouseMode.Select);
						}
						if (command == PlotToolBarCommandStyle.ZoomBox)
						{
							plotToolBarButton.Pushed = (toolBarAdapter.DataViewMouseMode == PlotDataViewMouseMode.ZoomBox);
						}
						if (command == PlotToolBarCommandStyle.DataCursor)
						{
							plotToolBarButton.Pushed = (toolBarAdapter.DataViewMouseMode == PlotDataViewMouseMode.DataCursor);
						}
					}
				}
			}
		}
	}
}
