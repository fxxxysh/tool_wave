using Iocomp.Design;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Types;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[DefaultEvent("")]
	[DesignerSerializer(typeof(LoadBeginEndSerializerPlotToolBarButton), typeof(CodeDomSerializer))]
	[ToolboxItem(false)]
	[Description("Plot ToolBar Button.")]
	[DesignerCategory("code")]
	public class PlotToolBarButton : ToolBarButton
	{
		private PlotToolBarCommandStyle m_Command;

		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(PlotToolBarCommandStyle.TrackingResume)]
		public PlotToolBarCommandStyle Command
		{
			get
			{
				return m_Command;
			}
			set
			{
				if (m_Command != value)
				{
					m_Command = value;
					if (Command == PlotToolBarCommandStyle.Separator)
					{
						base.ImageIndex = -1;
						base.ToolTipText = "";
						base.Style = ToolBarButtonStyle.Separator;
						base.Enabled = false;
					}
					else if (Command == PlotToolBarCommandStyle.TrackingResume)
					{
						base.ImageIndex = 0;
						base.ToolTipText = "Tracking Resume";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (Command == PlotToolBarCommandStyle.TrackingPause)
					{
						base.ImageIndex = 1;
						base.ToolTipText = "Tracking Pause";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (Command == PlotToolBarCommandStyle.AxesScroll)
					{
						base.ImageIndex = 2;
						base.ToolTipText = "Axes Scroll";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (Command == PlotToolBarCommandStyle.AxesZoom)
					{
						base.ImageIndex = 3;
						base.ToolTipText = "Axes Zoom";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (Command == PlotToolBarCommandStyle.ZoomOut)
					{
						base.ImageIndex = 4;
						base.ToolTipText = "Zoom-Out";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (Command == PlotToolBarCommandStyle.ZoomIn)
					{
						base.ImageIndex = 5;
						base.ToolTipText = "Zoom-In";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (Command == PlotToolBarCommandStyle.Select)
					{
						base.ImageIndex = 6;
						base.ToolTipText = "Select";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (Command == PlotToolBarCommandStyle.ZoomBox)
					{
						base.ImageIndex = 7;
						base.ToolTipText = "Zoom-Box";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (Command == PlotToolBarCommandStyle.DataCursor)
					{
						base.ImageIndex = 8;
						base.ToolTipText = "Data-Cursor";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (Command == PlotToolBarCommandStyle.Edit)
					{
						base.ImageIndex = 9;
						base.ToolTipText = "Edit";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (Command == PlotToolBarCommandStyle.Copy)
					{
						base.ImageIndex = 10;
						base.ToolTipText = "Copy to Clipboard";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (Command == PlotToolBarCommandStyle.Save)
					{
						base.ImageIndex = 11;
						base.ToolTipText = "Save";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (Command == PlotToolBarCommandStyle.Print)
					{
						base.ImageIndex = 12;
						base.ToolTipText = "Print";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (Command == PlotToolBarCommandStyle.Preview)
					{
						base.ImageIndex = 13;
						base.ToolTipText = "Preview";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (Command == PlotToolBarCommandStyle.PageSetup)
					{
						base.ImageIndex = 14;
						base.ToolTipText = "Page Setup";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (Command == PlotToolBarCommandStyle.None)
					{
						base.Enabled = true;
					}
				}
			}
		}

		public PlotToolBarButton()
		{
			Command = PlotToolBarCommandStyle.TrackingResume;
			base.Style = ToolBarButtonStyle.PushButton;
			base.ToolTipText = "Tracking Resume";
		}

		public virtual void LoadingBegin()
		{
		}

		public virtual void LoadingEnd()
		{
			UpdateToolBar();
		}

		private void UpdateToolBar()
		{
			if (base.Parent is PlotToolBarStandard)
			{
				(base.Parent as PlotToolBarStandard).SetupButton(this);
			}
		}
	}
}
