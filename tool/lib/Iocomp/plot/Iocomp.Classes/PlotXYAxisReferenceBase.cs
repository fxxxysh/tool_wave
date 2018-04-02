using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Base Class for all Plot Objects Reference to a X & Y Axis.")]
	public abstract class PlotXYAxisReferenceBase : PlotObject
	{
		private string m_XAxisName;

		private string m_YAxisName;

		private PlotClippingStyle m_ClippingStyle;

		protected bool m_XYSwapped;

		private PlotXAxis m_CachedXAxis;

		private PlotYAxis m_CachedYAxis;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string XAxisName
		{
			get
			{
				if (m_XAxisName == null)
				{
					return Const.EmptyString;
				}
				return m_XAxisName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("XAxisName", value);
				if (XAxisName != value)
				{
					m_XAxisName = value;
					m_CachedXAxis = null;
					m_CachedXAxis = XAxis;
					base.DoPropertyChange(this, "XAxisName");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string YAxisName
		{
			get
			{
				if (m_YAxisName == null)
				{
					return Const.EmptyString;
				}
				return m_YAxisName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("YAxisName", value);
				if (YAxisName != value)
				{
					m_YAxisName = value;
					m_CachedYAxis = null;
					m_CachedYAxis = YAxis;
					base.DoPropertyChange(this, "YAxisName");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotClippingStyle ClippingStyle
		{
			get
			{
				return m_ClippingStyle;
			}
			set
			{
				base.PropertyUpdateDefault("ClippingStyle", value);
				if (ClippingStyle != value)
				{
					m_ClippingStyle = value;
					base.DoPropertyChange(this, "ClippingStyle");
				}
			}
		}

		[Description("")]
		public PlotXAxis XAxis
		{
			get
			{
				if (m_CachedXAxis != null)
				{
					return m_CachedXAxis;
				}
				if (base.Plot == null)
				{
					return null;
				}
				m_CachedXAxis = base.Plot.XAxes[XAxisName];
				return m_CachedXAxis;
			}
		}

		[Description("")]
		public PlotYAxis YAxis
		{
			get
			{
				if (m_CachedYAxis != null)
				{
					return m_CachedYAxis;
				}
				if (base.Plot == null)
				{
					return null;
				}
				m_CachedYAxis = base.Plot.YAxes[YAxisName];
				return m_CachedYAxis;
			}
		}

		[Description("")]
		public bool XYSwapped
		{
			get
			{
				return m_XYSwapped;
			}
		}

		protected override bool HitTestEnabled
		{
			get
			{
				if (base.Plot == null)
				{
					return false;
				}
				if (base.Plot.ToolBarAdapter.DataViewMouseMode != 0)
				{
					return false;
				}
				return true;
			}
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			XAxisName = "X-Axis 1";
			YAxisName = "Y-Axis 1";
			ClippingStyle = PlotClippingStyle.Axes;
		}

		private bool ShouldSerializeXAxisName()
		{
			return base.PropertyShouldSerialize("XAxisName");
		}

		private void ResetXAxisName()
		{
			base.PropertyReset("XAxisName");
		}

		private bool ShouldSerializeYAxisName()
		{
			return base.PropertyShouldSerialize("YAxisName");
		}

		private void ResetYAxisName()
		{
			base.PropertyReset("YAxisName");
		}

		private bool ShouldSerializeClippingStyle()
		{
			return base.PropertyShouldSerialize("ClippingStyle");
		}

		private void ResetClippingStyle()
		{
			base.PropertyReset("ClippingStyle");
		}

		public override void ObjectRenamed(PlotObject value, string oldName)
		{
			base.ObjectRenamed(value, oldName);
			if (value is PlotXAxis && oldName == m_XAxisName)
			{
				m_XAxisName = value.Name;
			}
			else if (value is PlotYAxis && oldName == m_YAxisName)
			{
				m_YAxisName = value.Name;
			}
		}

		public override void ObjectRemoved(PlotObject value)
		{
			base.ObjectRemoved(value);
			if (value == m_CachedXAxis)
			{
				m_CachedXAxis = null;
			}
			else if (value == m_CachedYAxis)
			{
				m_CachedYAxis = null;
			}
		}

		public override void ObjectAdded(PlotObject value)
		{
			base.ObjectAdded(value);
			if (value is PlotXAxis && value.Name == m_XAxisName)
			{
				m_CachedXAxis = (value as PlotXAxis);
			}
			else if (value is PlotYAxis && value.Name == m_YAxisName)
			{
				m_CachedYAxis = (value as PlotYAxis);
			}
		}

		[Description("")]
		public Point GetPoint(double x, double y)
		{
			if (XAxis != null && YAxis != null)
			{
				if (!XYSwapped)
				{
					return new Point(XAxis.ScaleDisplay.ValueToPixels(x), YAxis.ScaleDisplay.ValueToPixels(y));
				}
				return new Point(YAxis.ScaleDisplay.ValueToPixels(y), XAxis.ScaleDisplay.ValueToPixels(x));
			}
			return Point.Empty;
		}

		[Description("")]
		public int GetDataViewYPixelsMin()
		{
			if (YAxis == null)
			{
				return 0;
			}
			return YAxis.DataViewPixelsMin;
		}

		[Description("")]
		public int GetDataViewYPixelsMax()
		{
			if (YAxis == null)
			{
				return 0;
			}
			return YAxis.DataViewPixelsMax;
		}

		[Description("")]
		public int GetDataViewXPixelsMin()
		{
			if (XAxis == null)
			{
				return 0;
			}
			return XAxis.DataViewPixelsMin;
		}

		[Description("")]
		public int GetDataViewXPixelsMax()
		{
			if (XAxis == null)
			{
				return 0;
			}
			return XAxis.DataViewPixelsMax;
		}

		[Description("")]
		public Point GetPixelPoint(int x, int y)
		{
			if (!XYSwapped)
			{
				return new Point(x, y);
			}
			return new Point(y, x);
		}

		[Description("")]
		public Rectangle GetRectangleLTWH(double left, double top, double width, double height)
		{
			if (XAxis != null && YAxis != null)
			{
				if (!XYSwapped)
				{
					return iRectangle.FromLTWH(XAxis.ScaleDisplay.ValueToPixels(left), YAxis.ScaleDisplay.ValueToPixels(top), XAxis.ScaleDisplay.ValueToSpanPixels(width), YAxis.ScaleDisplay.ValueToSpanPixels(height));
				}
				return iRectangle.FromLTWH(YAxis.ScaleDisplay.ValueToPixels(top), XAxis.ScaleDisplay.ValueToPixels(left), YAxis.ScaleDisplay.ValueToSpanPixels(height), XAxis.ScaleDisplay.ValueToSpanPixels(width));
			}
			return Rectangle.Empty;
		}

		[Description("")]
		public Rectangle GetRectangleLTRB(double left, double top, double right, double bottom)
		{
			if (XAxis != null && YAxis != null)
			{
				if (!XYSwapped)
				{
					return iRectangle.FromLTRB(XAxis.ScaleDisplay.ValueToPixels(left), YAxis.ScaleDisplay.ValueToPixels(top), XAxis.ScaleDisplay.ValueToPixels(right), YAxis.ScaleDisplay.ValueToPixels(bottom));
				}
				return iRectangle.FromLTRB(YAxis.ScaleDisplay.ValueToPixels(top), XAxis.ScaleDisplay.ValueToPixels(left), YAxis.ScaleDisplay.ValueToPixels(bottom), XAxis.ScaleDisplay.ValueToPixels(right));
			}
			return Rectangle.Empty;
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (XAxis == null)
			{
				base.CanDraw = false;
			}
			else if (YAxis == null)
			{
				base.CanDraw = false;
			}
			else if (XAxis.DockOrientation == YAxis.DockOrientation)
			{
				base.CanDraw = false;
			}
			else if (XAxis.DockDataView == null)
			{
				base.CanDraw = false;
			}
			else if (YAxis.DockDataView == null)
			{
				base.CanDraw = false;
			}
			else if (!XAxis.DockDataView.Visible)
			{
				base.CanDraw = false;
			}
			else if (!YAxis.DockDataView.Visible)
			{
				base.CanDraw = false;
			}
		}

		protected override void UpdateBoundsClip(PaintArgs p)
		{
			if (XAxis != null && YAxis != null)
			{
				m_XYSwapped = XAxis.DockHorizontal;
				int top = YAxis.ScaleDisplay.PixelsMin;
				int bottom = YAxis.ScaleDisplay.PixelsMax;
				int left = XAxis.ScaleDisplay.PixelsMin;
				int right = XAxis.ScaleDisplay.PixelsMax;
				if (ClippingStyle == PlotClippingStyle.DataView)
				{
					PlotDataView dockDataView = m_CachedYAxis.DockDataView;
					if (dockDataView != null)
					{
						if (!XYSwapped)
						{
							top = dockDataView.BoundsClip.Top;
							bottom = dockDataView.BoundsClip.Bottom;
						}
						else
						{
							top = dockDataView.BoundsClip.Left;
							bottom = dockDataView.BoundsClip.Right;
						}
					}
					dockDataView = XAxis.DockDataView;
					if (dockDataView != null)
					{
						if (!XYSwapped)
						{
							left = dockDataView.BoundsClip.Left;
							right = dockDataView.BoundsClip.Right;
						}
						else
						{
							left = dockDataView.BoundsClip.Top;
							right = dockDataView.BoundsClip.Bottom;
						}
					}
				}
				base.BoundsClip = iRectangle.FromLTRB(m_XYSwapped, left, top, right, bottom);
			}
		}

		protected void SetClipRect(PaintArgs p)
		{
			if (base.BoundsClip != Rectangle.Empty)
			{
				Rectangle boundsClip = base.BoundsClip;
				Rectangle clip = new Rectangle(boundsClip.Left, boundsClip.Top, boundsClip.Width + 1, boundsClip.Height + 1);
				p.Graphics.SetClip(clip);
			}
		}

		protected override void Draw(PaintArgs p)
		{
			SetClipRect(p);
			Draw(p, XAxis, YAxis);
		}

		protected override void DrawFocusRectangles(PaintArgs p)
		{
			if (base.BoundsClip != Rectangle.Empty)
			{
				p.Graphics.SetClip(base.BoundsClip);
			}
			DrawFocusRectangles(p, XAxis, YAxis);
		}

		protected virtual void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
		}

		protected virtual void DrawFocusRectangles(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
		}
	}
}
