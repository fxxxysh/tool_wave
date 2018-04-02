using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Channel Differential")]
	public class PlotChannelDifferential : PlotChannelConsecutive
	{
		private PlotPen m_Trace;

		private IPlotPen I_Trace;

		private PlotFill m_Fill;

		private IPlotFill I_Fill;

		private PlotMarker m_Markers;

		private IPlotMarker I_Markers;

		private double m_Reference;

		private bool m_Terminated;

		private bool m_UserCanMoveDataPoints;

		private PlotDataMoveStyle m_DataPointsMoveStyle;

		private PlotTraceFastDraw m_TraceFastDraw;

		private int m_MouseDownDataPointIndex;

		private PlotDataPointDifferential m_MouseDownDataPoint;

		private double m_MouseDownDataPointX;

		private double m_MouseDownDataPointY;

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
		public PlotFill Fill
		{
			get
			{
				return m_Fill;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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

		public PlotDataPointDifferential this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointDifferential;
			}
		}

		public event PlotChannelDataPointMovedEventHandler DataPointMoved;

		public event PlotChannelDataPointClickEventHandler DataPointClick;

		public event PlotChannelDataPointClickEventHandler DataPointDoubleClick;

		protected override string GetPlugInTitle()
		{
			return "Channel Differential";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelDifferentialEditorPlugIn";
		}

		public PlotChannelDifferential()
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
			m_TraceFastDraw = new PlotTraceFastDraw();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Differential";
			UserCanMoveDataPoints = false;
			DataPointsMoveStyle = PlotDataMoveStyle.XandY;
			Trace.Color = Color.Empty;
			Trace.Thickness = 1.0;
			Trace.Style = PlotPenStyle.Solid;
			Trace.Visible = true;
			Terminated = false;
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

		private bool ShouldSerializeTerminated()
		{
			return base.PropertyShouldSerialize("Terminated");
		}

		private void ResetTerminated()
		{
			base.PropertyReset("Terminated");
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
			return new PlotDataPointDifferential(this);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue)
		{
			base.CheckForValidNextX(x);
			PlotDataPointDifferential plotDataPointDifferential = (PlotDataPointDifferential)base.m_Data.AddNew();
			base.DataPointInitializing = true;
			try
			{
				plotDataPointDifferential.X = x;
				plotDataPointDifferential.Y = y;
				plotDataPointDifferential.Null = nullValue;
				plotDataPointDifferential.Empty = emptyValue;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			base.m_Data.UpdateMinMaxMean(plotDataPointDifferential);
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
						PlotDataPointDifferential plotDataPointDifferential = this[i];
						Point point = base.GetPoint(plotDataPointDifferential.X, plotDataPointDifferential.Y);
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

		protected override void DrawLegendMarker(PaintArgs p, Rectangle r)
		{
			I_Fill.Draw(p, r);
			I_Trace.DrawLine(p, r.Left, (r.Top + r.Bottom) / 2, r.Right, (r.Top + r.Bottom) / 2);
			I_Markers.DrawLegend(p, r);
		}

		private void DrawTrace(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			if (Count >= 2)
			{
				PlotDataPointDifferential plotDataPointDifferential = new PlotDataPointDifferential(this);
				((IPlotBrush)Fill.Brush).GetBrush(p, base.BoundsClip);
				m_TraceFastDraw.P = p;
				m_TraceFastDraw.XAxis = xAxis;
				m_TraceFastDraw.YAxis = yAxis;
				m_TraceFastDraw.Pen = ((IPlotPen)Trace).GetPen(p);
				m_TraceFastDraw.TraceVisible = Trace.Visible;
				m_TraceFastDraw.XYSwapped = base.XYSwapped;
				m_TraceFastDraw.FillVisible = (Fill.Visible && Fill.Brush.Visible);
				m_TraceFastDraw.FillBrush = ((IPlotBrush)Fill.Brush).GetBrush(p, base.BoundsClip);
				m_TraceFastDraw.FillRefPixel = yAxis.ValueToPixels(Reference);
				m_TraceFastDraw.Reset();
				m_TraceFastDraw.Reset();
				int num = -1;
				for (int i = IndexDrawStart; i <= IndexDrawStop; i++)
				{
					if (base.GetValid(i))
					{
						if (num == -1)
						{
							m_TraceFastDraw.AddDataPoint(this[i]);
							num = i;
						}
						else if (this[num].Y != this[i].Y)
						{
							base.DataPointInitializing = true;
							plotDataPointDifferential.X = this[i].X;
							plotDataPointDifferential.Y = this[num].Y;
							base.DataPointInitializing = false;
							m_TraceFastDraw.AddDataPoint(plotDataPointDifferential);
							m_TraceFastDraw.AddDataPoint(this[i]);
						}
						else
						{
							m_TraceFastDraw.AddDataPoint(this[i]);
						}
						num = i;
					}
					else if (!GetEmpty(i) && GetNull(i))
					{
						m_TraceFastDraw.AddDataPoint(this[i]);
						num = -1;
					}
				}
				if (num != -1 && !Terminated)
				{
					base.DataPointInitializing = true;
					if (base.DataDirection == DataDirection.Increasing)
					{
						plotDataPointDifferential.X = base.XAxis.Max;
					}
					else
					{
						plotDataPointDifferential.X = base.XAxis.Min;
					}
					plotDataPointDifferential.Y = this[num].Y;
					base.DataPointInitializing = false;
					m_TraceFastDraw.AddDataPoint(plotDataPointDifferential);
				}
				m_TraceFastDraw.DrawFlush();
			}
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			DrawTrace(p, xAxis, yAxis);
			DrawMarkers(p, xAxis, yAxis, Markers);
		}
	}
}
