using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Channel Digital")]
	public class PlotChannelDigital : PlotChannelConsecutive
	{
		private PlotPen m_Trace;

		private IPlotPen I_Trace;

		private PlotMarker m_Markers;

		private IPlotMarker I_Markers;

		private PlotBrush m_Fill;

		private IPlotBrush I_Fill;

		private PlotDigitalReferenceStyle m_ReferenceStyle;

		private double m_ReferenceHigh;

		private double m_ReferenceLow;

		private bool m_Terminated;

		private bool m_UserCanMoveDataPoints;

		private PlotDataMoveStyle m_DataPointsMoveStyle;

		private int m_MouseDownDataPointIndex;

		private PlotDataPointDigital m_MouseDownDataPoint;

		private double m_MouseDownDataPointX;

		private bool m_MouseDownDataPointY;

		private double m_MouseDownPosX;

		private double m_MouseDownPosY;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotPen Trace
		{
			get
			{
				return m_Trace;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotBrush Fill
		{
			get
			{
				return m_Fill;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotMarker Markers
		{
			get
			{
				return m_Markers;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool Terminated
		{
			get
			{
				return m_Terminated;
			}
			set
			{
				base.PropertyUpdateDefault("Terminated", value);
				if (Terminated != value)
				{
					m_Terminated = value;
					base.DoPropertyChange(this, "Terminated");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotDigitalReferenceStyle ReferenceStyle
		{
			get
			{
				return m_ReferenceStyle;
			}
			set
			{
				base.PropertyUpdateDefault("ReferenceStyle", value);
				if (ReferenceStyle != value)
				{
					m_ReferenceStyle = value;
					base.DoPropertyChange(this, "ReferenceStyle");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double ReferenceHigh
		{
			get
			{
				return m_ReferenceHigh;
			}
			set
			{
				base.PropertyUpdateDefault("ReferenceHigh", value);
				if (ReferenceHigh != value)
				{
					m_ReferenceHigh = value;
					base.DoPropertyChange(this, "ReferenceHigh");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double ReferenceLow
		{
			get
			{
				return m_ReferenceLow;
			}
			set
			{
				base.PropertyUpdateDefault("ReferenceLow", value);
				if (ReferenceLow != value)
				{
					m_ReferenceLow = value;
					base.DoPropertyChange(this, "ReferenceLow");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool UserCanMoveDataPoints
		{
			get
			{
				return m_UserCanMoveDataPoints;
			}
			set
			{
				base.PropertyUpdateDefault("UserCanMoveDataPoints", value);
				if (UserCanMoveDataPoints != value)
				{
					m_UserCanMoveDataPoints = value;
					base.DoPropertyChange(this, "UserCanMoveDataPoints");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotDataMoveStyle DataPointsMoveStyle
		{
			get
			{
				return m_DataPointsMoveStyle;
			}
			set
			{
				base.PropertyUpdateDefault("DataPointsMoveStyle", value);
				if (DataPointsMoveStyle != value)
				{
					m_DataPointsMoveStyle = value;
					base.DoPropertyChange(this, "DataPointsMoveStyle");
				}
			}
		}

		public PlotDataPointDigital this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointDigital;
			}
		}

		public override double YMinScale => GetYValueAxisValue(base.YMin);

		public override double YMaxScale => GetYValueAxisValue(base.YMax);

		public event PlotChannelDataPointMovedEventHandler DataPointMoved;

		public event PlotChannelDataPointClickEventHandler DataPointClick;

		public event PlotChannelDataPointClickEventHandler DataPointDoubleClick;

		protected override string GetPlugInTitle()
		{
			return "Channel Digital";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelDigitalEditorPlugIn";
		}

		public PlotChannelDigital()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Trace = new PlotPen();
			base.AddSubClass(Trace);
			I_Trace = Trace;
			m_Fill = new PlotBrush();
			base.AddSubClass(Fill);
			I_Fill = Fill;
			m_Markers = new PlotMarker();
			base.AddSubClass(Markers);
			I_Markers = Markers;
			((ISubClassBase)Trace).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)Fill).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)Markers.Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)Markers.Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Digital";
			UserCanMoveDataPoints = false;
			DataPointsMoveStyle = PlotDataMoveStyle.XandY;
			ReferenceStyle = PlotDigitalReferenceStyle.Units;
			ReferenceHigh = 90.0;
			ReferenceLow = 10.0;
			Terminated = true;
			Trace.Color = Color.Empty;
			Trace.Thickness = 1.0;
			Trace.Style = PlotPenStyle.Solid;
			Trace.Visible = true;
			Fill.Visible = false;
			Fill.Style = PlotBrushStyle.Solid;
			Fill.SolidColor = Color.Empty;
			Fill.GradientStartColor = Color.Blue;
			Fill.GradientStopColor = Color.Aqua;
			Fill.HatchForeColor = Color.Empty;
			Fill.HatchBackColor = Color.Empty;
			Markers.Visible = false;
			Markers.Style = PlotMarkerStyle.Circle;
			Markers.Size = 3;
			Markers.Font = null;
			Markers.ForeColor = Color.Empty;
			Markers.Text = "";
			Markers.Fill.Pen.Visible = true;
			Markers.Fill.Pen.Style = PlotPenStyle.Solid;
			Markers.Fill.Pen.Color = Color.Empty;
			Markers.Fill.Pen.Thickness = 1.0;
			Markers.Fill.Brush.Visible = true;
			Markers.Fill.Brush.Style = PlotBrushStyle.Solid;
			Markers.Fill.Brush.SolidColor = Color.Empty;
			Markers.Fill.Brush.GradientStartColor = Color.Blue;
			Markers.Fill.Brush.GradientStopColor = Color.Aqua;
			Markers.Fill.Brush.HatchForeColor = Color.Empty;
			Markers.Fill.Brush.HatchBackColor = Color.Empty;
		}

		private bool ShouldSerializeTrace()
		{
			return ((ISubClassBase)Trace).ShouldSerialize();
		}

		private void ResetTrace()
		{
			((ISubClassBase)Trace).ResetToDefault();
		}

		private bool ShouldSerializeFill()
		{
			return ((ISubClassBase)Fill).ShouldSerialize();
		}

		private void ResetFill()
		{
			((ISubClassBase)Fill).ResetToDefault();
		}

		private bool ShouldSerializeMarkers()
		{
			return ((ISubClassBase)Markers).ShouldSerialize();
		}

		private void ResetMarkers()
		{
			((ISubClassBase)Markers).ResetToDefault();
		}

		private bool ShouldSerializeTerminated()
		{
			return base.PropertyShouldSerialize("Terminated");
		}

		private void ResetTerminated()
		{
			base.PropertyReset("Terminated");
		}

		private bool ShouldSerializeReferenceStyle()
		{
			return base.PropertyShouldSerialize("ReferenceStyle");
		}

		private void ResetReferenceStyle()
		{
			base.PropertyReset("ReferenceStyle");
		}

		private bool ShouldSerializeReferenceHigh()
		{
			return base.PropertyShouldSerialize("ReferenceHigh");
		}

		private void ResetReferenceHigh()
		{
			base.PropertyReset("ReferenceHigh");
		}

		private bool ShouldSerializeReferenceLow()
		{
			return base.PropertyShouldSerialize("ReferenceLow");
		}

		private void ResetReferenceLow()
		{
			base.PropertyReset("ReferenceLow");
		}

		private bool ShouldSerializeUserCanMoveDataPoints()
		{
			return base.PropertyShouldSerialize("UserCanMoveDataPoints");
		}

		private void ResetUserCanMoveDataPoints()
		{
			base.PropertyReset("UserCanMoveDataPoints");
		}

		private bool ShouldSerializeDataPointsMoveStyle()
		{
			return base.PropertyShouldSerialize("DataPointsMoveStyle");
		}

		private void ResetDataPointsMoveStyle()
		{
			base.PropertyReset("DataPointsMoveStyle");
		}

		protected override PlotDataPointBase CreateDataPoint()
		{
			return new PlotDataPointDigital(this);
		}

		public int AddXY(double x, bool y)
		{
			if (y)
			{
				return AddXY(x, 1.0);
			}
			return AddXY(x, 0.0);
		}

		public int AddXY(DateTime x, bool y)
		{
			if (y)
			{
				return AddXY(Math2.DateTimeToDouble(x), 1.0);
			}
			return AddXY(Math2.DateTimeToDouble(x), 0.0);
		}

		private int AddXY(double x, bool y, bool nullValue, bool emptyValue)
		{
			base.CheckForValidNextX(x);
			double value = (!y) ? ReferenceLow : ReferenceHigh;
			PlotDataPointDigital plotDataPointDigital = (PlotDataPointDigital)base.m_Data.AddNew();
			base.DataPointInitializing = true;
			try
			{
				plotDataPointDigital.X = x;
				plotDataPointDigital.Y = y;
				plotDataPointDigital.Null = nullValue;
				plotDataPointDigital.Empty = emptyValue;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			if (y)
			{
				base.m_Data.UpdateMinMaxMean(x, 1.0, emptyValue, nullValue);
			}
			else
			{
				base.m_Data.UpdateMinMaxMean(x, 0.0, emptyValue, nullValue);
			}
			if (base.SendXAxisTrackingData)
			{
				PlotXAxis xAxis = base.XAxis;
				xAxis?.Tracking.NewData(x);
			}
			if (!nullValue && !emptyValue && base.SendYAxisTrackingData)
			{
				PlotYAxis yAxis = base.YAxis;
				yAxis?.Tracking.NewData(value);
			}
			DoDataChange();
			return base.m_Data.LastNewDataPointIndex;
		}

		public override int AddXY(double x, double y)
		{
			return AddXY(x, y != 0.0, false, false);
		}

		public override int AddEmpty(double x)
		{
			return AddXY(x, false, false, true);
		}

		public override int AddNull(double x)
		{
			return AddXY(x, false, true, false);
		}

		public override double GetX(int index)
		{
			return this[index].X;
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

		public override void SetNull(int index, bool value)
		{
			this[index].Null = value;
		}

		public override void SetEmpty(int index, bool value)
		{
			this[index].Empty = value;
		}

		public override double GetY(int index)
		{
			if ((base.m_Data[index] as PlotDataPointDigital).Y)
			{
				return 1.0;
			}
			return 0.0;
		}

		public double GetY(bool value)
		{
			if (value)
			{
				return ReferenceHigh;
			}
			return ReferenceLow;
		}

		public override void SetY(int index, double value)
		{
			if (value != 0.0)
			{
				(base.m_Data[index] as PlotDataPointDigital).Y = true;
			}
			else
			{
				(base.m_Data[index] as PlotDataPointDigital).Y = false;
			}
			DoDataChange();
		}

		public override double GetYValueAxisValue(double yValue)
		{
			if (yValue == 0.0)
			{
				return ReferenceLow;
			}
			return ReferenceHigh;
		}

		public override string GetYValueText(double value)
		{
			if (value == 0.0)
			{
				return "Low";
			}
			return "High";
		}

		public override PlotChannelInterpolationResult GetYInterpolated(double targetX, out double yValue)
		{
			yValue = 0.0;
			if (Count == 0)
			{
				return PlotChannelInterpolationResult.NoData;
			}
			if (Count == 1 && GetX(0) != targetX)
			{
				return PlotChannelInterpolationResult.Void;
			}
			if (targetX < base.XFirst)
			{
				return PlotChannelInterpolationResult.Void;
			}
			if (targetX > base.XLast)
			{
				return PlotChannelInterpolationResult.Void;
			}
			if (Count == 1 && GetX(0) == targetX)
			{
				if (GetNull(0))
				{
					return PlotChannelInterpolationResult.Null;
				}
				if (GetEmpty(0))
				{
					return PlotChannelInterpolationResult.NoData;
				}
				yValue = GetY(0);
				return PlotChannelInterpolationResult.Valid;
			}
			int num = CalculateXValueNearestIndex(targetX);
			double x = GetX(num);
			if (num == -1)
			{
				return PlotChannelInterpolationResult.Invalid;
			}
			if (x == targetX)
			{
				if (GetNull(num))
				{
					return PlotChannelInterpolationResult.Null;
				}
				if (!GetEmpty(num))
				{
					yValue = GetY(num);
					return PlotChannelInterpolationResult.Valid;
				}
			}
			int num2;
			if (x <= targetX)
			{
				if (num >= base.IndexLast)
				{
					return PlotChannelInterpolationResult.Invalid;
				}
				num2 = num;
				int num3 = num + 1;
				while (GetEmpty(num2))
				{
					num2--;
					if (num2 < base.IndexFirst)
					{
						return PlotChannelInterpolationResult.Void;
					}
				}
				if (GetNull(num2))
				{
					return PlotChannelInterpolationResult.Null;
				}
				while (GetEmpty(num3))
				{
					num3++;
					if (num3 > base.IndexLast)
					{
						return PlotChannelInterpolationResult.Void;
					}
				}
				if (GetNull(num3))
				{
					return PlotChannelInterpolationResult.Null;
				}
			}
			else
			{
				if (num == base.IndexFirst)
				{
					return PlotChannelInterpolationResult.Invalid;
				}
				num2 = num - 1;
				int num3 = num;
				while (GetEmpty(num2))
				{
					num2--;
					if (num2 < base.IndexFirst)
					{
						return PlotChannelInterpolationResult.Void;
					}
				}
				if (GetNull(num2))
				{
					return PlotChannelInterpolationResult.Null;
				}
				while (GetEmpty(num3))
				{
					num3++;
					if (num3 > base.IndexLast)
					{
						return PlotChannelInterpolationResult.Void;
					}
				}
				if (GetNull(num3))
				{
					return PlotChannelInterpolationResult.Null;
				}
			}
			yValue = GetY(num2);
			return PlotChannelInterpolationResult.Valid;
		}

		protected override void LoadDesignTimeData(PlotXAxis xAxis, PlotYAxis yAxis, Random random, double yMin, double ySpan)
		{
			for (double num = xAxis.Min; num < xAxis.Max; num += xAxis.Span / 100.0)
			{
				AddXY(num, random.NextDouble() > 0.5);
			}
		}

		[Description("")]
		public Point GetPoint(double x, bool y)
		{
			if (y)
			{
				return base.GetPoint(x, ReferenceHigh);
			}
			return base.GetPoint(x, ReferenceLow);
		}

		protected override bool InternalHitTest(MouseEventArgs e)
		{
			if (base.LegendRectangle.Contains(e.X, e.Y))
			{
				return true;
			}
			m_MouseDownDataPointIndex = -1;
			if (IndexDrawStart == -1)
			{
				return false;
			}
			if (IndexDrawStop == -1)
			{
				return false;
			}
			if (Markers.Visible)
			{
				PlotXAxis xAxis = base.XAxis;
				PlotYAxis yAxis = base.YAxis;
				if (xAxis != null && yAxis != null)
				{
					for (int i = IndexDrawStart; i <= IndexDrawStop; i++)
					{
						PlotDataPointDigital plotDataPointDigital = this[i];
						Point point = GetPoint(plotDataPointDigital.X, plotDataPointDigital.Y);
						if (new Rectangle(point.X - Markers.Size, point.Y - Markers.Size, Markers.Size * 2, Markers.Size * 2).Contains(e.X, e.Y))
						{
							m_MouseDownDataPointIndex = i;
							return true;
						}
					}
				}
			}
			return false;
		}

		protected override Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			if (m_MouseDownDataPointIndex == -1)
			{
				return Cursors.Default;
			}
			return Cursors.Hand;
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (shouldFocus)
			{
				base.Focus();
			}
			if (UserCanMoveDataPoints && m_MouseDownDataPointIndex != -1)
			{
				base.IsMouseActive = true;
				m_MouseDownDataPoint = this[m_MouseDownDataPointIndex];
				m_MouseDownDataPointX = m_MouseDownDataPoint.X;
				m_MouseDownDataPointY = m_MouseDownDataPoint.Y;
				m_MouseDownPosX = base.XAxis.PixelsToValue(e);
				m_MouseDownPosY = base.YAxis.PixelsToValue(e);
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			if (base.IsMouseActive)
			{
				double num = m_MouseDownDataPointX + (base.XAxis.PixelsToValue(e) - m_MouseDownPosX);
				bool y = base.YAxis.PixelsToValue(e) > (ReferenceHigh + ReferenceLow) / 2.0 && true;
				double num2 = -1E+300;
				double num3 = 1E+300;
				if (base.DataDirection == DataDirection.Increasing)
				{
					if (m_MouseDownDataPointIndex > 0)
					{
						num2 = this[m_MouseDownDataPointIndex - 1].X * 1.00000000000001;
					}
					if (m_MouseDownDataPointIndex < Count - 1)
					{
						num3 = this[m_MouseDownDataPointIndex + 1].X * 0.99999999999999;
					}
				}
				else
				{
					if (m_MouseDownDataPointIndex > 0)
					{
						num3 = this[m_MouseDownDataPointIndex - 1].X * 0.99999999999999;
					}
					if (m_MouseDownDataPointIndex < Count - 1)
					{
						num2 = this[m_MouseDownDataPointIndex + 1].X * 1.00000000000001;
					}
				}
				if (num > num3)
				{
					num = num3;
				}
				if (num < num2)
				{
					num = num2;
				}
				if (DataPointsMoveStyle == PlotDataMoveStyle.XandY || DataPointsMoveStyle == PlotDataMoveStyle.XOnly)
				{
					m_MouseDownDataPoint.X = num;
				}
				if (DataPointsMoveStyle != 0 && DataPointsMoveStyle != PlotDataMoveStyle.YOnly)
				{
					return;
				}
				m_MouseDownDataPoint.Y = y;
			}
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			base.IsMouseActive = false;
			if (UserCanMoveDataPoints && this.DataPointMoved != null && m_MouseDownDataPointIndex != -1)
			{
				double x = this[m_MouseDownDataPointIndex].X;
				bool y = this[m_MouseDownDataPointIndex].Y;
				if (m_MouseDownDataPointX != x || m_MouseDownDataPointY != y)
				{
					PlotChannelDataPointMovedEventArgs e2 = new PlotChannelDataPointMovedEventArgs(this, m_MouseDownDataPointIndex, m_MouseDownDataPointX, GetY(m_MouseDownDataPointY), x, GetY(y));
					this.DataPointMoved(this, e2);
				}
			}
			if (this.DataPointClick != null)
			{
				PlotChannelDataPointClickEventArgs e3 = new PlotChannelDataPointClickEventArgs(this, e.Button, m_MouseDownDataPointIndex);
				this.DataPointClick(this, e3);
			}
		}

		protected override void InternalOnDoubleClick(MouseEventArgs e)
		{
			if (this.DataPointDoubleClick != null)
			{
				PlotChannelDataPointClickEventArgs e2 = new PlotChannelDataPointClickEventArgs(this, e.Button, m_MouseDownDataPointIndex);
				this.DataPointDoubleClick(this, e2);
			}
		}

		protected override void DrawLegendMarker(PaintArgs p, Rectangle r)
		{
			if (Fill.Visible)
			{
				p.Graphics.FillRectangle(I_Fill.GetBrush(p, r), r);
			}
			I_Trace.DrawLine(p, r.Left, (r.Top + r.Bottom) / 2, r.Right, (r.Top + r.Bottom) / 2);
			I_Markers.DrawLegend(p, r);
		}

		protected void DrawTrace(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			int num = -1;
			int num2 = 0;
			int num3 = 0;
			int[] array = new int[2];
			Pen pen = ((IPlotPen)Trace).GetPen(p);
			if (ReferenceStyle == PlotDigitalReferenceStyle.Units)
			{
				array[1] = base.YAxis.ScaleDisplay.ValueToPixels(ReferenceHigh);
				array[0] = base.YAxis.ScaleDisplay.ValueToPixels(ReferenceLow);
			}
			else
			{
				array[1] = base.YAxis.ScaleDisplay.PercentToPixels(ReferenceHigh);
				array[0] = base.YAxis.ScaleDisplay.PercentToPixels(ReferenceLow);
			}
			for (int i = IndexDrawStart; i <= IndexDrawStop; i++)
			{
				if (base.GetValid(i))
				{
					if (num != -1)
					{
						int num4 = xAxis.ScaleDisplay.ValueToPixels(GetX(num));
						num2 = xAxis.ScaleDisplay.ValueToPixels(GetX(i));
						int num5 = (!this[num].Y) ? array[0] : array[1];
						num3 = ((!this[i].Y) ? array[0] : array[1]);
						if (num5 == num3)
						{
							if (base.XYSwapped)
							{
								p.Graphics.DrawLine(pen, num5, num4, num3, num2);
							}
							else
							{
								p.Graphics.DrawLine(pen, num4, num5, num2, num3);
							}
						}
						else if (base.XYSwapped)
						{
							p.Graphics.DrawLine(pen, num5, num4, num5, num2);
							p.Graphics.DrawLine(pen, num5, num2, num3, num2);
						}
						else
						{
							p.Graphics.DrawLine(pen, num4, num5, num2, num5);
							p.Graphics.DrawLine(pen, num2, num5, num2, num3);
						}
						num = i;
						if (Fill.Visible && num5 != array[0])
						{
							Rectangle rectangle = Rectangle.FromLTRB(num4, num5, num2, array[0]);
							p.Graphics.FillRectangle(I_Fill.GetBrush(p, rectangle), rectangle);
						}
					}
					else
					{
						num = i;
					}
				}
				else if (!GetEmpty(i) && GetNull(i))
				{
					num = -1;
				}
			}
			if (num != -1 && !Terminated)
			{
				if (base.XYSwapped)
				{
					p.Graphics.DrawLine(pen, num3, num2, num3, xAxis.ScaleDisplay.PixelsMax);
				}
				else
				{
					p.Graphics.DrawLine(pen, num2, num3, xAxis.ScaleDisplay.PixelsMax, num3);
				}
			}
		}

		protected override void DrawMarkers(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis, PlotMarker markers)
		{
			if (markers.Visible)
			{
				Brush brush = ((IPlotBrush)markers.Fill.Brush).GetBrush(p, Rectangle.Empty);
				Pen pen = ((IPlotPen)markers.Fill.Pen).GetPen(p);
				for (int i = IndexDrawStart; i <= IndexDrawStop; i++)
				{
					if (!GetNull(i) && !GetEmpty(i))
					{
						int num = xAxis.ScaleDisplay.ValueToPixels(GetX(i));
						int num2 = (GetY(i) != 0.0) ? yAxis.ScaleDisplay.ValueToPixels(ReferenceHigh) : yAxis.ScaleDisplay.ValueToPixels(ReferenceLow);
						if (base.XYSwapped)
						{
							((IPlotMarker)markers).Draw(p, num2, num, brush, pen);
						}
						else
						{
							((IPlotMarker)markers).Draw(p, num, num2, brush, pen);
						}
					}
				}
			}
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			if (Trace.Visible && Count > 1)
			{
				DrawTrace(p, xAxis, yAxis);
			}
			DrawMarkers(p, xAxis, yAxis, Markers);
		}
	}
}
