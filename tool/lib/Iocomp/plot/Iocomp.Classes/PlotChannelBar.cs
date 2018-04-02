using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Channel Bar")]
	public class PlotChannelBar : PlotChannelConsecutive
	{
		private double m_Reference;

		private double m_Width;

		private MagnitudeStyle m_WidthStyle;

		private bool m_DrawCustomDataPointAttributes;

		private PlotFill m_Fill;

		protected IPlotFill I_Fill;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double Width
		{
			get
			{
				return m_Width;
			}
			set
			{
				base.PropertyUpdateDefault("Width", value);
				if (Width != value)
				{
					m_Width = value;
					base.DoPropertyChange(this, "Width");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public MagnitudeStyle WidthStyle
		{
			get
			{
				return m_WidthStyle;
			}
			set
			{
				base.PropertyUpdateDefault("WidthStyle", value);
				if (WidthStyle != value)
				{
					m_WidthStyle = value;
					base.DoPropertyChange(this, "WidthStyle");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Reference
		{
			get
			{
				return m_Reference;
			}
			set
			{
				base.PropertyUpdateDefault("Reference", value);
				if (Reference != value)
				{
					m_Reference = value;
					base.DoPropertyChange(this, "Reference");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool DrawCustomDataPointAttributes
		{
			get
			{
				return m_DrawCustomDataPointAttributes;
			}
			set
			{
				base.PropertyUpdateDefault("DrawCustomDataPointAttributes", value);
				if (DrawCustomDataPointAttributes != value)
				{
					m_DrawCustomDataPointAttributes = value;
					base.DoPropertyChange(this, "DrawCustomDataPointAttributes");
				}
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill Fill
		{
			get
			{
				return m_Fill;
			}
		}

		public PlotDataPointBar this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointBar;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Channel Bar";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelBarEditorPlugIn";
		}

		public PlotChannelBar()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Fill = new PlotFill();
			base.AddSubClass(Fill);
			I_Fill = Fill;
			((ISubClassBase)Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Bar";
			Width = 5.0;
			WidthStyle = MagnitudeStyle.Value;
			Reference = 0.0;
			DrawCustomDataPointAttributes = false;
			Fill.Visible = true;
			Fill.Brush.Visible = true;
			Fill.Brush.Style = PlotBrushStyle.Solid;
			Fill.Brush.SolidColor = Color.Empty;
			Fill.Brush.GradientStartColor = Color.Blue;
			Fill.Brush.GradientStopColor = Color.Aqua;
			Fill.Brush.HatchForeColor = Color.Empty;
			Fill.Brush.HatchBackColor = Color.Empty;
			Fill.Pen.Visible = true;
			Fill.Pen.Color = Color.Empty;
			Fill.Pen.Thickness = 1.0;
			Fill.Pen.Style = PlotPenStyle.Solid;
		}

		private bool ShouldSerializeWidth()
		{
			return base.PropertyShouldSerialize("Width");
		}

		private void ResetWidth()
		{
			base.PropertyReset("Width");
		}

		private bool ShouldSerializeWidthStyle()
		{
			return base.PropertyShouldSerialize("WidthStyle");
		}

		private void ResetWidthStyle()
		{
			base.PropertyReset("WidthStyle");
		}

		private bool ShouldSerializeReference()
		{
			return base.PropertyShouldSerialize("Reference");
		}

		private void ResetReference()
		{
			base.PropertyReset("Reference");
		}

		private bool ShouldSerializeDrawCustomDataPointAttributes()
		{
			return base.PropertyShouldSerialize("DrawCustomDataPointAttributes");
		}

		private void ResetDrawCustomDataPointAttributes()
		{
			base.PropertyReset("DrawCustomDataPointAttributes");
		}

		private bool ShouldSerializeFill()
		{
			return ((ISubClassBase)Fill).ShouldSerialize();
		}

		private void ResetFill()
		{
			((ISubClassBase)Fill).ResetToDefault();
		}

		protected override PlotDataPointBase CreateDataPoint()
		{
			return new PlotDataPointBar(this);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue, double width)
		{
			base.CheckForValidNextX(x);
			PlotDataPointBar plotDataPointBar = (PlotDataPointBar)base.m_Data.AddNew();
			base.DataPointInitializing = true;
			try
			{
				plotDataPointBar.X = x;
				plotDataPointBar.Y = y;
				plotDataPointBar.Null = nullValue;
				plotDataPointBar.Empty = emptyValue;
				plotDataPointBar.Width = width;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			base.m_Data.UpdateMinMaxMean(plotDataPointBar);
			if (base.SendXAxisTrackingData)
			{
				PlotAxis xAxis = base.XAxis;
				if (xAxis != null)
				{
					base.XAxis.Tracking.NewData(x - Width / 2.0);
					base.XAxis.Tracking.NewData(x + Width / 2.0);
				}
			}
			if (!nullValue && !emptyValue && base.SendYAxisTrackingData)
			{
				PlotAxis yAxis = base.YAxis;
				if (yAxis != null)
				{
					base.YAxis.Tracking.NewData(y);
					base.YAxis.Tracking.NewData(Reference);
				}
			}
			DoDataChange();
			return base.m_Data.LastNewDataPointIndex;
		}

		public int AddXY(double x, double y, double width)
		{
			return AddXY(x, y, false, false, width);
		}

		public int AddXY(DateTime x, double y, double width)
		{
			return AddXY(Math2.DateTimeToDouble(x), y, false, false, width);
		}

		public override int AddXY(double x, double y)
		{
			return AddXY(x, y, false, false, Width);
		}

		public override int AddEmpty(double x)
		{
			return AddXY(x, 0.0, false, true, Width);
		}

		public override int AddNull(double x)
		{
			return AddXY(x, 0.0, true, false, Width);
		}

		public override double GetX(int index)
		{
			return this[index].X;
		}

		public override double GetY(int index)
		{
			return this[index].Y;
		}

		public override bool GetNull(int index)
		{
			return this[index].Null;
		}

		public override bool GetEmpty(int index)
		{
			return this[index].Empty;
		}

		public override void SetX(int index, double value)
		{
			this[index].X = value;
		}

		public override void SetY(int index, double value)
		{
			this[index].Y = value;
		}

		public override void SetNull(int index, bool value)
		{
			this[index].Null = value;
		}

		public override void SetEmpty(int index, bool value)
		{
			this[index].Empty = value;
		}

		protected override void LoadDesignTimeData(PlotXAxis xAxis, PlotYAxis yAxis, Random random, double yMin, double ySpan)
		{
			for (double num = xAxis.Min; num < xAxis.Max; num += Width * 3.0)
			{
				AddXY(num, yMin + random.NextDouble() * ySpan);
			}
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (!Fill.Visible)
			{
				base.CanDraw = false;
			}
			if (!Fill.Brush.Visible && !Fill.Pen.Visible)
			{
				base.CanDraw = false;
			}
		}

		protected override void DrawLegendMarker(PaintArgs p, Rectangle r)
		{
			int width = (int)Math.Round((double)r.Width * 0.6);
			Size size = new Size(width, r.Height);
			Point point = iRectangle.CenterPoint2(r);
			Point location = new Point(point.X - size.Width / 2, point.Y - size.Height / 2);
			I_Fill.Draw(p, new Rectangle(location, size));
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			for (int i = IndexDrawStart; i <= IndexDrawStop; i++)
			{
				PlotDataPointBar plotDataPointBar = this[i];
				if (!plotDataPointBar.Empty && !plotDataPointBar.Null)
				{
					Rectangle r;
					Point point;
					if (WidthStyle == MagnitudeStyle.Value)
					{
						int num;
						int num2;
						if (DrawCustomDataPointAttributes)
						{
							num = xAxis.ScaleDisplay.ValueToPixels(plotDataPointBar.X - plotDataPointBar.Width / 2.0);
							num2 = xAxis.ScaleDisplay.ValueToPixels(plotDataPointBar.X + plotDataPointBar.Width / 2.0);
						}
						else
						{
							num = xAxis.ScaleDisplay.ValueToPixels(plotDataPointBar.X - Width / 2.0);
							num2 = xAxis.ScaleDisplay.ValueToPixels(plotDataPointBar.X + Width / 2.0);
						}
						int top = yAxis.ScaleDisplay.ValueToPixels(plotDataPointBar.Y);
						int bottom = yAxis.ScaleDisplay.ValueToPixels(Reference);
						if (num == num2)
						{
							num2++;
						}
						r = iRectangle.FromLTRB(base.XYSwapped, num, top, num2, bottom);
					}
					else if (WidthStyle == MagnitudeStyle.Pixel)
					{
						point = base.GetPoint(plotDataPointBar.X, plotDataPointBar.Y);
						int num3 = (int)(Width / 2.0);
						int bottom2 = yAxis.ScaleDisplay.ValueToPixels(Reference);
						r = iRectangle.FromLTRB(base.XYSwapped, point.X - num3, point.Y, point.X + num3, bottom2);
					}
					else
					{
						point = base.GetPoint(plotDataPointBar.X, plotDataPointBar.Y);
						int num3 = xAxis.ScaleDisplay.PercentToSpanPixels(Width) / 2;
						int bottom2 = yAxis.ScaleDisplay.ValueToPixels(Reference);
						int num = point.X - num3;
						int num2 = point.X + num3;
						if (num == num2)
						{
							num2++;
						}
						r = iRectangle.FromLTRB(base.XYSwapped, num, point.Y, num2, bottom2);
					}
					if (DrawCustomDataPointAttributes)
					{
						((IPlotFill)plotDataPointBar.Fill).Draw(p, r);
					}
					else
					{
						I_Fill.Draw(p, r);
					}
				}
			}
		}
	}
}
