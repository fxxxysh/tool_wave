using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Layout Dockable Class")]
	public abstract class PlotLayoutDockableAll : PlotLayoutDockableDataView
	{
		private PlotDockStyleAll m_DockStyle;

		private double m_FloatingAbsoluteX;

		private double m_FloatingAbsoluteY;

		private PlotFloatingReferenceStyle m_FloatingReferenceStyle;

		private AlignmentText m_FloatingAlignmentHorizontal;

		private AlignmentText m_FloatingAlignmentVertical;

		private PlotDockAutoSizeAlignment m_DockAutoSizeAlignment;

		private PlotDockStartStopStyleDockableAll m_DockStartStyle;

		private string m_DockStartDataViewName;

		private PlotDockStartStopStyleDockableAll m_DockStopStyle;

		private string m_DockStopDataViewName;

		private PlotDataView m_CachedDockStartDataView;

		private PlotDataView m_CachedDockStopDataView;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotDockStartStopStyleDockableAll DockStartStyle
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
		public PlotDockStartStopStyleDockableAll DockStopStyle
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
		public string DockStartDataViewName
		{
			get
			{
				return m_DockStartDataViewName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("DockStartDataViewName", value);
				if (DockStartDataViewName != value)
				{
					m_DockStartDataViewName = value;
					m_CachedDockStartDataView = null;
					m_CachedDockStartDataView = DockStartDataView;
					base.DoPropertyChange(this, "DockStartDataViewName");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string DockStopDataViewName
		{
			get
			{
				return m_DockStopDataViewName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("DockStopDataViewName", value);
				if (DockStopDataViewName != value)
				{
					m_DockStopDataViewName = value;
					m_CachedDockStopDataView = null;
					m_CachedDockStopDataView = DockStopDataView;
					base.DoPropertyChange(this, "DockStopDataViewName");
				}
			}
		}

		[Description("")]
		public PlotDataView DockStartDataView
		{
			get
			{
				if (m_CachedDockStartDataView != null)
				{
					return m_CachedDockStartDataView;
				}
				if (base.Plot == null)
				{
					return null;
				}
				m_CachedDockStartDataView = base.Plot.DataViews[m_DockStartDataViewName];
				return m_CachedDockStartDataView;
			}
		}

		[Description("")]
		public PlotDataView DockStopDataView
		{
			get
			{
				if (m_CachedDockStopDataView != null)
				{
					return m_CachedDockStopDataView;
				}
				if (base.Plot == null)
				{
					return null;
				}
				m_CachedDockStopDataView = base.Plot.DataViews[m_DockStopDataViewName];
				return m_CachedDockStopDataView;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		private AlignmentText FloatingAlignmentVertical
		{
			get
			{
				return m_FloatingAlignmentVertical;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		private AlignmentText FloatingAlignmentHorizontal
		{
			get
			{
				return m_FloatingAlignmentHorizontal;
			}
		}

		public PlotDockStyleAll DockStyle
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

		private double FloatingAbsoluteX
		{
			get
			{
				return m_FloatingAbsoluteX;
			}
			set
			{
				base.PropertyUpdateDefault("FloatingAbsoluteX", value);
				if (FloatingAbsoluteX != value)
				{
					m_FloatingAbsoluteX = value;
					base.DoPropertyChange(this, "FloatingAbsoluteX");
				}
			}
		}

		private double FloatingAbsoluteY
		{
			get
			{
				return m_FloatingAbsoluteY;
			}
			set
			{
				base.PropertyUpdateDefault("FloatingAbsoluteY", value);
				if (FloatingAbsoluteY != value)
				{
					m_FloatingAbsoluteY = value;
					base.DoPropertyChange(this, "FloatingAbsoluteY");
				}
			}
		}

		private PlotFloatingReferenceStyle FloatingReferenceStyle
		{
			get
			{
				return m_FloatingReferenceStyle;
			}
			set
			{
				base.PropertyUpdateDefault("FloatingReferenceStyle", value);
				if (FloatingReferenceStyle != value)
				{
					m_FloatingReferenceStyle = value;
					base.DoPropertyChange(this, "FloatingReferenceStyle");
				}
			}
		}

		public PlotDockAutoSizeAlignment DockAutoSizeAlignment
		{
			get
			{
				return m_DockAutoSizeAlignment;
			}
			set
			{
				base.PropertyUpdateDefault("DockAutoSizeAlignment", value);
				if (DockAutoSizeAlignment != value)
				{
					m_DockAutoSizeAlignment = value;
					base.DoPropertyChange(this, "DockAutoSizeAlignment");
				}
			}
		}

		public override bool DocksToDataView => DockStyle == PlotDockStyleAll.DataView;

		public override bool DocksToPlot => DockStyle == PlotDockStyleAll.Plot;

		protected override string GetPlugInTitle()
		{
			return "Layout";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLayoutDockableAllEditorPlugIn";
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_FloatingAlignmentVertical = new AlignmentText();
			base.AddSubClass(FloatingAlignmentVertical);
			m_FloatingAlignmentHorizontal = new AlignmentText();
			base.AddSubClass(FloatingAlignmentHorizontal);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			DockStyle = PlotDockStyleAll.Plot;
			DockSide = AlignmentQuadSide.Left;
			DockAutoSizeAlignment = PlotDockAutoSizeAlignment.Center;
			DockStartStyle = PlotDockStartStopStyleDockableAll.Percent;
			DockStopStyle = PlotDockStartStopStyleDockableAll.Percent;
			DockStartDataViewName = "Data-View 1";
			DockStopDataViewName = "Data-View 1";
			FloatingAbsoluteX = 0.0;
			FloatingAbsoluteY = 0.0;
			FloatingReferenceStyle = PlotFloatingReferenceStyle.Absolute;
			FloatingAlignmentHorizontal.Margin = 0.0;
			FloatingAlignmentHorizontal.Style = StringAlignment.Near;
			FloatingAlignmentVertical.Margin = 0.0;
			FloatingAlignmentVertical.Style = StringAlignment.Near;
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

		private bool ShouldSerializeDockStartDataViewName()
		{
			return base.PropertyShouldSerialize("DockStartDataViewName");
		}

		private void ResetDockStartDataViewName()
		{
			base.PropertyReset("DockStartDataViewName");
		}

		private bool ShouldSerializeDockStopDataViewName()
		{
			return base.PropertyShouldSerialize("DockStopDataViewName");
		}

		private void ResetDockStopDataViewName()
		{
			base.PropertyReset("DockStopDataViewName");
		}

		public override void ObjectRenamed(PlotObject value, string oldName)
		{
			base.ObjectRenamed(value, oldName);
			if (value is PlotDataView && oldName == m_DockStartDataViewName)
			{
				m_DockStartDataViewName = value.Name;
			}
			else if (value is PlotDataView && oldName == m_DockStopDataViewName)
			{
				m_DockStopDataViewName = value.Name;
			}
		}

		public override void ObjectRemoved(PlotObject value)
		{
			base.ObjectRemoved(value);
			if (value == m_CachedDockStartDataView)
			{
				m_CachedDockStartDataView = null;
			}
			else if (value == m_CachedDockStopDataView)
			{
				m_CachedDockStopDataView = null;
			}
		}

		public override void ObjectAdded(PlotObject value)
		{
			base.ObjectAdded(value);
			if (value is PlotDataView && value.Name == m_DockStartDataViewName)
			{
				m_CachedDockStartDataView = (value as PlotDataView);
			}
			else if (value is PlotDataView && value.Name == m_DockStopDataViewName)
			{
				m_CachedDockStopDataView = (value as PlotDataView);
			}
		}

		private bool ShouldSerializeFloatingAlignmentVertical()
		{
			return ((ISubClassBase)FloatingAlignmentVertical).ShouldSerialize();
		}

		private void ResetFloatingAlignmentVertical()
		{
			((ISubClassBase)FloatingAlignmentVertical).ResetToDefault();
		}

		private bool ShouldSerializeFloatingAlignmentHorizontal()
		{
			return ((ISubClassBase)FloatingAlignmentHorizontal).ShouldSerialize();
		}

		private void ResetFloatingAlignmentHorizontal()
		{
			((ISubClassBase)FloatingAlignmentHorizontal).ResetToDefault();
		}

		private bool ShouldSerializeDockStyle()
		{
			return base.PropertyShouldSerialize("DockStyle");
		}

		private void ResetDockStyle()
		{
			base.PropertyReset("DockStyle");
		}

		private bool ShouldSerializeFloatingAbsoluteX()
		{
			return base.PropertyShouldSerialize("FloatingAbsoluteX");
		}

		private void ResetFloatingAbsoluteX()
		{
			base.PropertyReset("FloatingAbsoluteX");
		}

		private bool ShouldSerializeFloatingAbsoluteY()
		{
			return base.PropertyShouldSerialize("FloatingAbsoluteY");
		}

		private void ResetFloatingAbsoluteY()
		{
			base.PropertyReset("FloatingAbsoluteY");
		}

		private bool ShouldSerializeFloatingReferenceStyle()
		{
			return base.PropertyShouldSerialize("FloatingReferenceStyle");
		}

		private void ResetFloatingReferenceStyle()
		{
			base.PropertyReset("FloatingReferenceStyle");
		}

		private bool ShouldSerializeDockAutoSizeAlignment()
		{
			return base.PropertyShouldSerialize("DockAutoSizeAlignment");
		}

		private void ResetDockAutoSizeAlignment()
		{
			base.PropertyReset("DockAutoSizeAlignment");
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (DockStyle == PlotDockStyleAll.DataView)
			{
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

		protected void CalculateBoundsAlignment(int requiredLength)
		{
			int num = base.Bounds.Left;
			int num2 = base.Bounds.Top;
			int right = base.Bounds.Right;
			int bottom = base.Bounds.Bottom;
			if (base.DockHorizontal)
			{
				if (DockAutoSizeAlignment == PlotDockAutoSizeAlignment.Near)
				{
					bottom = num2 + requiredLength;
				}
				else if (DockAutoSizeAlignment == PlotDockAutoSizeAlignment.Far)
				{
					num2 = base.Bounds.Bottom - requiredLength;
					bottom = base.Bounds.Bottom;
				}
				else if (DockAutoSizeAlignment == PlotDockAutoSizeAlignment.Center)
				{
					num2 = (base.Bounds.Top + base.Bounds.Bottom) / 2 - requiredLength / 2;
					bottom = num2 + requiredLength;
				}
			}
			else if (DockAutoSizeAlignment == PlotDockAutoSizeAlignment.Near)
			{
				right = num + requiredLength;
			}
			else if (DockAutoSizeAlignment == PlotDockAutoSizeAlignment.Far)
			{
				num = base.Bounds.Right - requiredLength;
				right = base.Bounds.Right;
			}
			else if (DockAutoSizeAlignment == PlotDockAutoSizeAlignment.Center)
			{
				num = (base.Bounds.Left + base.Bounds.Right) / 2 - requiredLength / 2;
				right = num + requiredLength;
			}
			base.BoundsAlignment = iRectangle.FromLTRB(num, num2, right, bottom);
		}
	}
}
