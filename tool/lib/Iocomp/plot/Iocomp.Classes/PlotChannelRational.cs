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
	public class PlotChannelRational : PlotChannelConsecutive
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

		private PlotDataPointRational m_MouseDownDataPoint;

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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
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

		public PlotDataPointRational this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointRational;
			}
		}

		public event PlotChannelDataPointMovedEventHandler DataPointMoved;

		public event PlotChannelDataPointClickEventHandler DataPointClick;

		public event PlotChannelDataPointClickEventHandler DataPointDoubleClick;

		protected override string GetPlugInTitle()
		{
			return "Channel Rational";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelRationalEditorPlugIn";
		}

		public PlotChannelRational()
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
			base.NameShort = "Rational";
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
			return new PlotDataPointRational(this);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue)
		{
			base.CheckForValidNextX(x);
			PlotDataPointRational plotDataPointRational = base.m_Data.AddNew() as PlotDataPointRational;
			base.DataPointInitializing = true;
			try
			{
				plotDataPointRational.X = x;
				plotDataPointRational.Y = y;
				plotDataPointRational.Null = nullValue;
				plotDataPointRational.Empty = emptyValue;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			base.m_Data.UpdateMinMaxMean(plotDataPointRational);
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

		private double GetC(int index)
		{
			return this[index].C;
		}

		private double GetD(int index)
		{
			return this[index].D;
		}

		private void SetC(int index, double value)
		{
			this[index].C = value;
		}

		private void SetD(int index, double value)
		{
			this[index].D = value;
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
						PlotDataPointRational plotDataPointRational = this[i];
						Point point = base.GetPoint(plotDataPointRational.X, plotDataPointRational.Y);
						int num = (!DrawCustomDataPointAttributes) ? Markers.Size : plotDataPointRational.Marker.Size;
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

		private void RationalInterpolation(int n, double x, out double y, out double dy)
		{
			int num = 0;
			dy = 0.0;
			double num2 = Math.Abs(x - GetX(0));
			for (int i = 0; i < n; i++)
			{
				double num3 = Math.Abs(x - GetX(i));
				if (num3 == 0.0)
				{
					y = GetY(i);
					dy = 0.0;
					return;
				}
				if (num3 < num2)
				{
					num = i;
					num2 = num3;
				}
				SetC(i, GetY(i));
				SetD(i, GetY(i) + 1E-25);
			}
			y = GetY(num);
			num--;
			for (int j = 1; j < n; j++)
			{
				for (int k = 0; k < n - j; k++)
				{
					double num4 = GetC(k + 1) - GetD(k);
					double num3 = GetX(k + j) - x;
					double num5 = (GetX(k) - x) * GetD(k) / num3;
					double num6 = num5 - GetC(k + 1);
					if (num6 == 0.0)
					{
						throw new Exception("Rational Interpolation Error - Pause in Routine Data");
					}
					num6 = num4 / num6;
					SetD(k, GetC(k + 1) * num6);
					SetC(k, num5 * num6);
				}
				if (2 * num < n - j - 1)
				{
					dy = GetC(num + 1);
				}
				else
				{
					dy = GetD(num);
					num--;
				}
				y += dy;
			}
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
					PlotDataPointRational plotDataPointRational = this[i];
					if (!plotDataPointRational.Null && !plotDataPointRational.Empty)
					{
						int num = xAxis.ScaleDisplay.ValueToPixels(plotDataPointRational.X);
						int num2 = yAxis.ScaleDisplay.ValueToPixels(plotDataPointRational.Y);
						if (DrawCustomDataPointAttributes)
						{
							if (base.XYSwapped)
							{
								((IPlotMarker)plotDataPointRational.Marker).Draw(p, num2, num);
							}
							else
							{
								((IPlotMarker)plotDataPointRational.Marker).Draw(p, num, num2);
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

		protected void DrawTraceCustomAttributes(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			PlotDataPointRational plotDataPointRational = new PlotDataPointRational(this);
			PlotDataPointRational plotDataPointRational2 = new PlotDataPointRational(this);
			double num = GetX(0);
			double num2 = GetX(Count - 1);
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
			RationalInterpolation(Count, num5, out double num6, out double num7);
			double x = num5;
			double y = num6;
			for (int i = num3; i <= num4; i++)
			{
				num5 = base.XAxis.PixelsToValue(i);
				RationalInterpolation(Count, num5, out num6, out num7);
				int num8 = i - m_XPixelMin;
				if (num8 >= 0 && num8 < m_PixelYValues.Length)
				{
					m_PixelYValues[i - m_XPixelMin] = num6;
				}
				double num9 = num5;
				double num10 = num6;
				base.DataPointInitializing = true;
				plotDataPointRational.X = x;
				plotDataPointRational.Y = y;
				plotDataPointRational2.X = num9;
				plotDataPointRational2.Y = num10;
				base.DataPointInitializing = false;
				DrawLine(p, xAxis, yAxis, I_Trace.GetPen(p), plotDataPointRational, plotDataPointRational2, brush);
				x = num9;
				y = num10;
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
				DrawTraceCustomAttributes(p, xAxis, yAxis);
			}
			DrawMarkers(p, xAxis, yAxis, Markers);
		}
	}
}
