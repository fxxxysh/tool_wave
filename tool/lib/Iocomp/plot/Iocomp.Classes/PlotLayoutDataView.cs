using Iocomp.Types;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Layout Data-View.")]
	public abstract class PlotLayoutDataView : PlotLayoutBase
	{
		private double m_DockDepthRatio;

		private PlotLayoutStackingGroup m_StackingGroup;

		private int m_StackingGroupIndex;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double DockDepthRatio
		{
			get
			{
				return m_DockDepthRatio;
			}
			set
			{
				base.PropertyUpdateDefault("DockDepthRatio", value);
				if (DockDepthRatio != value)
				{
					m_DockDepthRatio = value;
					base.DoPropertyChange(this, "DockDepthRatio");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int StackingGroupIndex
		{
			get
			{
				return m_StackingGroupIndex;
			}
			set
			{
				base.PropertyUpdateDefault("StackingGroupIndex", value);
				if (StackingGroupIndex != value)
				{
					m_StackingGroupIndex = value;
					base.DoPropertyChange(this, "StackingGroupIndex");
				}
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[RefreshProperties(RefreshProperties.All)]
		public PlotLayoutStackingGroup StackingGroup
		{
			get
			{
				return m_StackingGroup;
			}
			set
			{
				m_StackingGroup = value;
			}
		}

		public override bool DocksToDataView => false;

		public override bool DocksToPlot => true;

		protected override string GetPlugInTitle()
		{
			return "Layout";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLayoutDataViewEditorPlugIn";
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			DockSide = AlignmentQuadSide.Bottom;
			DockDepthRatio = 100.0;
			StackingGroupIndex = 0;
		}

		private bool ShouldSerializeDockDepthRatio()
		{
			return base.PropertyShouldSerialize("DockDepthRatio");
		}

		private void ResetDockDepthRatio()
		{
			base.PropertyReset("DockDepthRatio");
		}

		private bool ShouldSerializeStackingGroupIndex()
		{
			return base.PropertyShouldSerialize("StackingGroupIndex");
		}

		private void ResetStackingGroupIndex()
		{
			base.PropertyReset("StackingGroupIndex");
		}

		protected override void CalculateDepthPixels(PaintArgs p)
		{
			base.DockDepthPixels = 0;
		}

		protected override bool InternalHitTest(MouseEventArgs e)
		{
			if (!Visible)
			{
				return false;
			}
			if (!base.Enabled)
			{
				return false;
			}
			return base.BoundsClip.Contains(e.X, e.Y);
		}

		public bool IsDocked(PlotLayoutBase value)
		{
			PlotLayoutDockableDataView plotLayoutDockableDataView = value as PlotLayoutDockableDataView;
			if (plotLayoutDockableDataView == null)
			{
				return false;
			}
			if (!plotLayoutDockableDataView.DocksToDataView)
			{
				return false;
			}
			if (plotLayoutDockableDataView.DockDataViewName.ToUpper() != base.Name.ToUpper())
			{
				return false;
			}
			return true;
		}
	}
}
