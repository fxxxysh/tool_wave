using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Channel Trace")]
	public class PlotChannelCubicSpline : PlotChannelConsecutive
	{
		private enum FastDrawStatus
		{
			None,
			Min,
			Max
		}

		private PlotPen m_Trace;

		private IPlotPen I_Trace;

		private PlotMarker m_Markers;

		private IPlotMarker I_Markers;

		private PlotFill m_Fill;

		private IPlotFill I_Fill;

		private double m_Reference;

		private bool m_UserCanMoveDataPoints;

		private bool m_DrawCustomDataPointAttributes;

		private PlotDataMoveStyle m_DataPointsMoveStyle;

		private int m_FillRefPixel;

		private Point[] m_FillPoints;

		private double[] m_PixelYValues;

		private int m_XPixelMin;

		private int m_XPixelMax;

		private int m_MouseDownDataPointIndex;

		private PlotDataPointCubicSpline m_MouseDownDataPoint;

		private double m_MouseDownDataPointX;

		private double m_MouseDownDataPointY;

		private double m_MouseDownPosX;

		private double m_MouseDownPosY;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotPen Trace
		{
			get
			{
				return m_Trace;
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		public PlotDataPointCubicSpline this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointCubicSpline;
			}
		}

		public event PlotChannelDataPointMovedEventHandler DataPointMoved;

		public event PlotChannelDataPointClickEventHandler DataPointClick;

		public event PlotChannelDataPointClickEventHandler DataPointDoubleClick;

		protected override string GetPlugInTitle()
		{
			return "Channel Cubic-Spline";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelCubicSplineEditorPlugIn";
		}

		public PlotChannelCubicSpline()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Trace = new PlotPen();
			base.AddSubClass(Trace);
			I_Trace = Trace;
			m_Fill = new PlotFill();
			base.AddSubClass(Fill);
			I_Fill = Fill;
			m_Markers = new PlotMarker();
			base.AddSubClass(Markers);
			I_Markers = Markers;
			((ISubClassBase)Trace).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)Markers.Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)Markers.Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Cubic-Spline";
			UserCanMoveDataPoints = false;
			DrawCustomDataPointAttributes = false;
			DataPointsMoveStyle = PlotDataMoveStyle.XandY;
			Trace.Color = Color.Empty;
			Trace.Thickness = 1.0;
			Trace.Style = PlotPenStyle.Solid;
			Trace.Visible = true;
			Reference = 0.0;
			Fill.Visible = false;
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

		private bool ShouldSerializeReference()
		{
			return base.PropertyShouldSerialize("Reference");
		}

		private void ResetReference()
		{
			base.PropertyReset("Reference");
		}

		private bool ShouldSerializeUserCanMoveDataPoints()
		{
			return base.PropertyShouldSerialize("UserCanMoveDataPoints");
		}

		private void ResetUserCanMoveDataPoints()
		{
			base.PropertyReset("UserCanMoveDataPoints");
		}

		private bool ShouldSerializeDrawCustomDataPointAttributes()
		{
			return base.PropertyShouldSerialize("DrawCustomDataPointAttributes");
		}

		private void ResetDrawCustomDataPointAttributes()
		{
			base.PropertyReset("DrawCustomDataPointAttributes");
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
			return new PlotDataPointCubicSpline(this);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue)
		{
			base.CheckForValidNextX(x);
			PlotDataPointCubicSpline plotDataPointCubicSpline = base.m_Data.AddNew() as PlotDataPointCubicSpline;
			base.DataPointInitializing = true;
			try
			{
				plotDataPointCubicSpline.X = x;
				plotDataPointCubicSpline.Y = y;
				plotDataPointCubicSpline.Null = nullValue;
				plotDataPointCubicSpline.Empty = emptyValue;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			base.m_Data.UpdateMinMaxMean(plotDataPointCubicSpline);
			if (base.SendXAxisTrackingData)
			{
				PlotXAxis xAxis = base.XAxis;
				xAxis?.Tracking.NewData(x);
			}
			if (!nullValue && !emptyValue && base.SendYAxisTrackingData)
			{
				PlotYAxis yAxis = base.YAxis;
				yAxis?.Tracking.NewData(y);
			}
			DoDataChange();
			return base.m_Data.LastNewDataPointIndex;
		}

		public override int AddXY(double x, double y)
		{
			return AddXY(x, y, false, false);
		}

		public override int AddEmpty(double x)
		{
			return AddXY(x, 0.0, false, true);
		}

		public override int AddNull(double x)
		{
			return AddXY(x, 0.0, true, false);
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

		private double GetY2(int index)
		{
			return this[index].Y2;
		}

		private double GetU(int index)
		{
			return this[index].U;
		}

		private void SetY2(int index, double value)
		{
			this[index].Y2 = value;
		}

		private void SetU(int index, double value)
		{
			this[index].U = value;
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
						PlotDataPointCubicSpline plotDataPointCubicSpline = this[i];
						Point point = base.GetPoint(plotDataPointCubicSpline.X, plotDataPointCubicSpline.Y);
						int num = (!DrawCustomDataPointAttributes) ? Markers.Size : plotDataPointCubicSpline.Marker.Size;
						if (new Rectangle(point.X - num, point.Y - num, num * 2, num * 2).Contains(e.X, e.Y))
						{
							m_MouseDownDataPointIndex = i;
							return true;
						}
					}
				}
			}
			return false;
		}

		public override PlotChannelInterpolationResult GetYInterpolated(double targetX, out double yValue)
		{
			yValue = 0.0;
			if (Count == 0)
			{
				return PlotChannelInterpolationResult.NoData;
			}
			if (targetX < base.XMin)
			{
				return PlotChannelInterpolationResult.NoData;
			}
			if (targetX > base.XMax)
			{
				return PlotChannelInterpolationResult.NoData;
			}
			int num = base.XAxis.ValueToPixels(targetX);
			yValue = m_PixelYValues[num - m_XPixelMin];
			if (yValue <= 1E+300)
			{
				return PlotChannelInterpolationResult.Valid;
			}
			return PlotChannelInterpolationResult.Null;
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
				double y = m_MouseDownDataPointY + (base.YAxis.PixelsToValue(e) - m_MouseDownPosY);
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
				double y = this[m_MouseDownDataPointIndex].Y;
				if (m_MouseDownDataPointX != x || m_MouseDownDataPointY != y)
				{
					PlotChannelDataPointMovedEventArgs e2 = new PlotChannelDataPointMovedEventArgs(this, m_MouseDownDataPointIndex, m_MouseDownDataPointX, m_MouseDownDataPointY, x, y);
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

		private void SplineCalculations(int n, int index1st, int index2nd, int indexLast, int index2ndLast)
		{
			double num = (GetY(index2nd) - GetY(index1st)) / (GetX(index2nd) - GetX(index1st));
			double num2 = (GetY(indexLast) - GetY(index2ndLast)) / (GetX(indexLast) - GetX(index2ndLast));
			if (num > 9.9E+29)
			{
				SetY2(index1st, 0.0);
				SetU(index1st, 0.0);
			}
			else
			{
				SetY2(index1st, -0.5);
				SetU(index1st, 3.0 / (GetX(index2nd) - GetX(index1st)) * ((GetY(index2nd) - GetY(index1st)) / (GetX(index2nd) - GetX(index1st)) - num));
			}
			for (int i = index2nd; i < indexLast; i++)
			{
				double num3 = (GetX(i) - GetX(i - 1)) / (GetX(i + 1) - GetX(i - 1));
				double num4 = num3 * GetY2(i - 1) + 2.0;
				SetY2(i, (num3 - 1.0) / num4);
				SetU(i, (GetY(i + 1) - GetY(i)) / (GetX(i + 1) - GetX(i)) - (GetY(i) - GetY(i - 1)) / (GetX(i) - GetX(i - 1)));
				SetU(i, (6.0 * GetU(i) / (GetX(i + 1) - GetX(i - 1)) - num3 * GetU(i - 1)) / num4);
			}
			double num5;
			double num6;
			if (num2 > 9.9E+29)
			{
				num5 = 0.0;
				num6 = 0.0;
			}
			else
			{
				num5 = 0.5;
				num6 = 3.0 / (GetX(indexLast) - GetX(index2ndLast)) * (num2 - (GetY(indexLast) - GetY(index2ndLast)) / (GetX(indexLast) - GetX(index2ndLast)));
			}
			SetY2(indexLast, (num6 - num5 * GetU(index2ndLast)) / (num5 * GetY2(index2ndLast) + 1.0));
			for (int num7 = index2ndLast; num7 >= index1st; num7--)
			{
				SetY2(num7, GetY2(num7) * GetY2(num7 + 1) + GetU(num7));
			}
		}

		private void SplineInterpolation(int indexFirst, int indexLast, double x, out double y)
		{
			int num = indexFirst;
			int num2 = indexLast;
			y = 0.0;
			while (true)
			{
				if (num2 - num > 1)
				{
					int num3 = (num2 + num) / 2;
					if (GetX(num3) > x)
					{
						num2 = num3;
					}
					else
					{
						num = num3;
					}
					double num4 = GetX(num2) - GetX(num);
					if (num4 != 0.0)
					{
						double num5 = (GetX(num2) - x) / num4;
						double num6 = (x - GetX(num)) / num4;
						y = num5 * GetY(num) + num6 * GetY(num2) + ((num5 * num5 * num5 - num5) * GetY2(num) + (num6 * num6 * num6 - num6) * GetY2(num2)) * (num4 * num4) / 6.0;
						continue;
					}
					break;
				}
				return;
			}
			throw new Exception("Splint Error - xa's must be distinct");
		}

		protected override void DrawLegendMarker(PaintArgs p, Rectangle r)
		{
			I_Fill.Draw(p, r);
			I_Trace.DrawLine(p, r.Left, (r.Top + r.Bottom) / 2, r.Right, (r.Top + r.Bottom) / 2);
			I_Markers.DrawLegend(p, r);
		}

		protected override void DrawMarkers(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis, PlotMarker markers)
		{
			if (markers.Visible)
			{
				for (int i = IndexDrawStart; i <= IndexDrawStop; i++)
				{
					PlotDataPointCubicSpline plotDataPointCubicSpline = this[i];
					if (!plotDataPointCubicSpline.Null && !plotDataPointCubicSpline.Empty)
					{
						int num = xAxis.ScaleDisplay.ValueToPixels(plotDataPointCubicSpline.X);
						int num2 = yAxis.ScaleDisplay.ValueToPixels(plotDataPointCubicSpline.Y);
						if (DrawCustomDataPointAttributes)
						{
							if (base.XYSwapped)
							{
								((IPlotMarker)plotDataPointCubicSpline.Marker).Draw(p, num2, num);
							}
							else
							{
								((IPlotMarker)plotDataPointCubicSpline.Marker).Draw(p, num, num2);
							}
						}
						else if (base.XYSwapped)
						{
							I_Markers.Draw(p, num2, num);
						}
						else
						{
							I_Markers.Draw(p, num, num2);
						}
					}
				}
			}
		}

		protected void DrawLine(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis, Pen pen, PlotDataPointYDouble point1, PlotDataPointYDouble point2, Brush fillBrush)
		{
			int num = xAxis.ScaleDisplay.ValueToPixels(point1.X);
			int num2 = yAxis.ScaleDisplay.ValueToPixels(point1.Y);
			int num3 = xAxis.ScaleDisplay.ValueToPixels(point2.X);
			int num4 = yAxis.ScaleDisplay.ValueToPixels(point2.Y);
			if (base.XYSwapped)
			{
				p.Graphics.DrawLine(pen, num2, num, num4, num3);
			}
			else
			{
				p.Graphics.DrawLine(pen, num, num2, num3, num4);
			}
			if (Fill.Visible && Fill.Brush.Visible)
			{
				if (m_FillPoints == null)
				{
					m_FillPoints = new Point[4];
				}
				if (base.XYSwapped)
				{
					m_FillPoints[0].X = m_FillRefPixel;
					m_FillPoints[0].Y = num;
				}
				else
				{
					m_FillPoints[0].X = num;
					m_FillPoints[0].Y = m_FillRefPixel;
				}
				if (base.XYSwapped)
				{
					m_FillPoints[1].X = num2;
					m_FillPoints[1].Y = num;
				}
				else
				{
					m_FillPoints[1].X = num;
					m_FillPoints[1].Y = num2;
				}
				if (base.XYSwapped)
				{
					m_FillPoints[2].X = num4;
					m_FillPoints[2].Y = num3;
				}
				else
				{
					m_FillPoints[2].X = num3;
					m_FillPoints[2].Y = num4;
				}
				if (base.XYSwapped)
				{
					m_FillPoints[3].X = m_FillRefPixel;
					m_FillPoints[3].Y = num3;
				}
				else
				{
					m_FillPoints[3].X = num3;
					m_FillPoints[3].Y = m_FillRefPixel;
				}
				p.Graphics.FillPolygon(fillBrush, m_FillPoints);
			}
		}

		protected void DrawTraceCustomAttributes(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis, int indexStart, int indexStop)
		{
			PlotDataPointCubicSpline plotDataPointCubicSpline = new PlotDataPointCubicSpline(this);
			PlotDataPointCubicSpline plotDataPointCubicSpline2 = new PlotDataPointCubicSpline(this);
			double num = GetX(indexStart);
			double num2 = GetX(indexStop);
			if (num < xAxis.Min)
			{
				num = base.XAxis.Min;
			}
			if (num2 > xAxis.Max)
			{
				num2 = base.XAxis.Max;
			}
			int num3 = xAxis.ValueToPixels(num);
			int num4 = xAxis.ValueToPixels(num2);
			if (num3 > num4)
			{
				Math2.Switch(ref num3, ref num4);
			}
			Brush brush = ((IPlotBrush)Fill.Brush).GetBrush(p, base.BoundsClip);
			double num5 = xAxis.PixelsToValue(num3);
			SplineInterpolation(indexStart, base.IndexLast, num5, out double num6);
			double x = num5;
			double y = num6;
			for (int i = num3; i <= num4; i++)
			{
				num5 = base.XAxis.PixelsToValue(i);
				SplineInterpolation(indexStart, base.IndexLast, num5, out num6);
				int num7 = i - m_XPixelMin;
				if (num7 >= 0 && num7 < m_PixelYValues.Length)
				{
					m_PixelYValues[i - m_XPixelMin] = num6;
				}
				double num8 = num5;
				double num9 = num6;
				base.DataPointInitializing = true;
				plotDataPointCubicSpline.X = x;
				plotDataPointCubicSpline.Y = y;
				plotDataPointCubicSpline2.X = num8;
				plotDataPointCubicSpline2.Y = num9;
				base.DataPointInitializing = false;
				DrawLine(p, xAxis, yAxis, I_Trace.GetPen(p), plotDataPointCubicSpline, plotDataPointCubicSpline2, brush);
				x = num8;
				y = num9;
			}
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			m_FillRefPixel = yAxis.ValueToPixels(Reference);
			m_XPixelMin = xAxis.ValueToPixels(xAxis.Min);
			m_XPixelMax = xAxis.ValueToPixels(xAxis.Max);
			if (m_XPixelMax < m_XPixelMin)
			{
				Math2.Switch(ref m_XPixelMax, ref m_XPixelMin);
			}
			int num = m_XPixelMax - m_XPixelMin;
			if (num < 1)
			{
				m_PixelYValues = null;
			}
			else
			{
				if (m_PixelYValues == null)
				{
					m_PixelYValues = new double[num];
				}
				if (m_PixelYValues.Length != num)
				{
					m_PixelYValues = new double[num];
				}
			}
			if (m_PixelYValues != null)
			{
				for (int i = 0; i < m_PixelYValues.Length; i++)
				{
					m_PixelYValues[i] = 1E+305;
				}
			}
			if (Trace.Visible && Count > 1)
			{
				int j = 0;
				int num2 = 0;
				int num3 = 0;
				for (; j < Count; j++)
				{
					if (this[j].Null)
					{
						if (num3 - num2 > 1)
						{
							SplineCalculations(num3 - num2 + 1, num2, num2 + 1, num3, num3 - 1);
							DrawTraceCustomAttributes(p, xAxis, yAxis, num2, num3);
							num2 = j + 1;
							num3 = num2;
						}
					}
					else
					{
						num3 = j;
					}
				}
				if (num3 - num2 > 1)
				{
					SplineCalculations(num3 - num2 + 1, num2, num2 + 1, num3, num3 - 1);
					DrawTraceCustomAttributes(p, xAxis, yAxis, num2, num3);
				}
			}
			DrawMarkers(p, xAxis, yAxis, Markers);
		}
	}
}
