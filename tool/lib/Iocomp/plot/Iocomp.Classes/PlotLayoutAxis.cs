using Iocomp.Types;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Layout Axis.")]
	public abstract class PlotLayoutAxis : PlotLayoutDockableDataView
	{
		private PlotDockStyleAxis m_DockStyle;

		private double m_DockStackingEndsMargin;

		private bool m_DockForceStacking;

		private PlotDockStartStopStyleDockableAxis m_DockStartStyle;

		private string m_DockStartAxisName;

		private PlotDockStartStopStyleDockableAxis m_DockStopStyle;

		private string m_DockStopAxisName;

		private PlotAxis m_CachedDockStartAxis;

		private PlotAxis m_CachedDockStopAxis;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotDockStyleAxis DockStyle
		{
			get
			{
				return m_DockStyle;
			}
			set
			{
				base.PropertyUpdateDefault("DockStyle", value);
				if (DockStyle != value)
				{
					m_DockStyle = value;
					base.DoPropertyChange(this, "DockStyle");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double DockStackingEndsMargin
		{
			get
			{
				return m_DockStackingEndsMargin;
			}
			set
			{
				base.PropertyUpdateDefault("DockStackingEndsMargin", value);
				if (DockStackingEndsMargin != value)
				{
					m_DockStackingEndsMargin = value;
					base.DoPropertyChange(this, "DockStackingEndsMargin");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool DockForceStacking
		{
			get
			{
				return m_DockForceStacking;
			}
			set
			{
				base.PropertyUpdateDefault("DockForceStacking", value);
				if (DockForceStacking != value)
				{
					m_DockForceStacking = value;
					base.DoPropertyChange(this, "DockForceStacking");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotDockStartStopStyleDockableAxis DockStartStyle
		{
			get
			{
				return m_DockStartStyle;
			}
			set
			{
				base.PropertyUpdateDefault("DockStartStyle", value);
				if (DockStartStyle != value)
				{
					m_DockStartStyle = value;
					base.DoPropertyChange(this, "DockStartStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotDockStartStopStyleDockableAxis DockStopStyle
		{
			get
			{
				return m_DockStopStyle;
			}
			set
			{
				base.PropertyUpdateDefault("DockStopStyle", value);
				if (DockStopStyle != value)
				{
					m_DockStopStyle = value;
					base.DoPropertyChange(this, "DockStopStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string DockStartAxisName
		{
			get
			{
				return m_DockStartAxisName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("DockStartAxisName", value);
				if (DockStartAxisName != value)
				{
					m_DockStartAxisName = value;
					m_CachedDockStartAxis = null;
					m_CachedDockStartAxis = DockStartAxis;
					base.DoPropertyChange(this, "DockStartAxisName");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string DockStopAxisName
		{
			get
			{
				return m_DockStopAxisName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("DockStopAxisName", value);
				if (DockStopAxisName != value)
				{
					m_DockStopAxisName = value;
					m_CachedDockStopAxis = null;
					m_CachedDockStopAxis = DockStopAxis;
					base.DoPropertyChange(this, "DockStopAxisName");
				}
			}
		}

		[Description("")]
		public PlotAxis DockStartAxis
		{
			get
			{
				if (m_CachedDockStartAxis != null)
				{
					return m_CachedDockStartAxis;
				}
				if (base.Plot == null)
				{
					return null;
				}
				m_CachedDockStartAxis = base.Plot.XAxes[m_DockStartAxisName];
				if (m_CachedDockStartAxis == null)
				{
					m_CachedDockStartAxis = base.Plot.YAxes[m_DockStartAxisName];
				}
				return m_CachedDockStartAxis;
			}
		}

		[Description("")]
		public PlotAxis DockStopAxis
		{
			get
			{
				if (m_CachedDockStopAxis != null)
				{
					return m_CachedDockStopAxis;
				}
				if (base.Plot == null)
				{
					return null;
				}
				m_CachedDockStopAxis = base.Plot.XAxes[m_DockStopAxisName];
				if (m_CachedDockStopAxis == null)
				{
					m_CachedDockStopAxis = base.Plot.YAxes[m_DockStopAxisName];
				}
				return m_CachedDockStopAxis;
			}
		}

		public override bool DocksToDataView => DockStyle == PlotDockStyleAxis.DataView;

		public override bool DocksToPlot => false;

		protected override string GetPlugInTitle()
		{
			return "Layout";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLayoutAxisEditorPlugIn";
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			DockStyle = PlotDockStyleAxis.DataView;
			DockStackingEndsMargin = 0.25;
			DockForceStacking = false;
			DockStartStyle = PlotDockStartStopStyleDockableAxis.Percent;
			DockStopStyle = PlotDockStartStopStyleDockableAxis.Percent;
			DockStartAxisName = "Axis 1";
			DockStopAxisName = "Axis 1";
		}

		private bool ShouldSerializeDockStyle()
		{
			return base.PropertyShouldSerialize("DockStyle");
		}

		private void ResetDockStyle()
		{
			base.PropertyReset("DockStyle");
		}

		private bool ShouldSerializeDockStackingEndsMargin()
		{
			return base.PropertyShouldSerialize("DockStackingEndsMargin");
		}

		private void ResetDockStackingEndsMargin()
		{
			base.PropertyReset("DockStackingEndsMargin");
		}

		private bool ShouldSerializeDockForceStacking()
		{
			return base.PropertyShouldSerialize("DockForceStacking");
		}

		private void ResetDockForceStacking()
		{
			base.PropertyReset("DockForceStacking");
		}

		private bool ShouldSerializeDockStartStyle()
		{
			return base.PropertyShouldSerialize("DockStartStyle");
		}

		private void ResetDockStartStyle()
		{
			base.PropertyReset("DockStartStyle");
		}

		private bool ShouldSerializeDockStopStyle()
		{
			return base.PropertyShouldSerialize("DockStopStyle");
		}

		private void ResetDockStopStyle()
		{
			base.PropertyReset("DockStopStyle");
		}

		private bool ShouldSerializeDockStartAxisName()
		{
			return base.PropertyShouldSerialize("DockStartAxisName");
		}

		private void ResetDockStartAxisName()
		{
			base.PropertyReset("DockStartAxisName");
		}

		private bool ShouldSerializeDockStopAxisName()
		{
			return base.PropertyShouldSerialize("DockStopAxisName");
		}

		private void ResetDockStopAxisName()
		{
			base.PropertyReset("DockStopAxisName");
		}

		public override void ObjectRenamed(PlotObject value, string oldName)
		{
			base.ObjectRenamed(value, oldName);
			if (value is PlotAxis && oldName == m_DockStartAxisName)
			{
				m_DockStartAxisName = value.Name;
			}
			else if (value is PlotAxis && oldName == m_DockStopAxisName)
			{
				m_DockStopAxisName = value.Name;
			}
		}

		public override void ObjectRemoved(PlotObject value)
		{
			base.ObjectRemoved(value);
			if (value == m_CachedDockStartAxis)
			{
				m_CachedDockStartAxis = null;
			}
			else if (value == m_CachedDockStopAxis)
			{
				m_CachedDockStopAxis = null;
			}
		}

		public override void ObjectAdded(PlotObject value)
		{
			base.ObjectAdded(value);
			if (value is PlotAxis && value.Name == m_DockStartAxisName)
			{
				m_CachedDockStartAxis = (value as PlotAxis);
			}
			else if (value is PlotAxis && value.Name == m_DockStopAxisName)
			{
				m_CachedDockStopAxis = (value as PlotAxis);
			}
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (base.DockDataView == null)
			{
				base.CanDraw = false;
			}
			else if (!base.DockDataView.Visible)
			{
				base.CanDraw = false;
			}
		}
	}
}
