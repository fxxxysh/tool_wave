using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Channel Sweep Interval")]
	public class PlotChannelSweepInterval : PlotChannelConsecutive
	{
		private PlotPen m_Trace;

		private IPlotPen I_Trace;

		private PlotMarker m_Markers;

		private IPlotMarker I_Markers;

		private PlotPen m_RetraceLine;

		private IPlotPen I_RetraceLine;

		private bool m_UserCanMoveDataPoints;

		private PlotDataMoveStyle m_DataPointsMoveStyle;

		private int m_SweepCount;

		private double m_SweepXStart;

		private double m_SweepXInterval;

		private int m_SweepLeadingBreakCount;

		private int m_SweepIndex;

		private double m_SweepYDefaultValue;

		private bool m_SweepYDefaultNull;

		private int m_LastAddIndex;

		private bool m_ClearOnRetrace;

		private PlotTraceFastDraw m_TraceFastDraw;

		private int m_MouseDownDataPointIndex;

		private PlotDataPointSweepInterval m_MouseDownDataPoint;

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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotPen RetraceLine
		{
			get
			{
				return m_RetraceLine;
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int SweepCount
		{
			get
			{
				return m_SweepCount;
			}
			set
			{
				base.PropertyUpdateDefault("SweepCount", value);
				if (SweepCount != value)
				{
					m_SweepCount = value;
					ResetDataArray();
					base.DoPropertyChange(this, "SweepCount");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double SweepXStart
		{
			get
			{
				return m_SweepXStart;
			}
			set
			{
				base.PropertyUpdateDefault("SweepXStart", value);
				if (SweepXStart != value)
				{
					m_SweepXStart = value;
					ResetDataArray();
					base.DoPropertyChange(this, "SweepXStart");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double SweepXInterval
		{
			get
			{
				return m_SweepXInterval;
			}
			set
			{
				base.PropertyUpdateDefault("SweepXInterval", value);
				if (SweepXInterval != value)
				{
					m_SweepXInterval = value;
					ResetDataArray();
					base.DoPropertyChange(this, "SweepXInterval");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double SweepYDefaultValue
		{
			get
			{
				return m_SweepYDefaultValue;
			}
			set
			{
				base.PropertyUpdateDefault("SweepYDefaultValue", value);
				if (SweepYDefaultValue != value)
				{
					m_SweepYDefaultValue = value;
					ResetDataArray();
					base.DoPropertyChange(this, "SweepYDefaultValue");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool SweepYDefaultNull
		{
			get
			{
				return m_SweepYDefaultNull;
			}
			set
			{
				base.PropertyUpdateDefault("SweepYDefaultNull", value);
				if (SweepYDefaultNull != value)
				{
					m_SweepYDefaultNull = value;
					ResetDataArray();
					base.DoPropertyChange(this, "SweepYDefaultNull");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int SweepLeadingBreakCount
		{
			get
			{
				return m_SweepLeadingBreakCount;
			}
			set
			{
				base.PropertyUpdateDefault("SweepLeadingBreakCount", value);
				if (SweepLeadingBreakCount != value)
				{
					m_SweepLeadingBreakCount = value;
					base.DoPropertyChange(this, "SweepLeadingBreakCount");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ClearOnRetrace
		{
			get
			{
				return m_ClearOnRetrace;
			}
			set
			{
				base.PropertyUpdateDefault("ClearOnRetrace", value);
				if (ClearOnRetrace != value)
				{
					m_ClearOnRetrace = value;
					base.DoPropertyChange(this, "ClearOnRetrace");
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

		public PlotDataPointSweepInterval this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointSweepInterval;
			}
		}

		public int SweepIndex => m_SweepIndex;

		public override int Capacity
		{
			get
			{
				return base.m_Data.Capacity;
			}
			set
			{
			}
		}

		public event PlotChannelDataPointMovedEventHandler DataPointMoved;

		public event PlotChannelDataPointClickEventHandler DataPointClick;

		public event PlotChannelDataPointClickEventHandler DataPointDoubleClick;

		protected override string GetPlugInTitle()
		{
			return "Channel Sweep Interval";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelSweepIntervalEditorPlugIn";
		}

		public PlotChannelSweepInterval()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Trace = new PlotPen();
			base.AddSubClass(Trace);
			I_Trace = Trace;
			m_RetraceLine = new PlotPen();
			base.AddSubClass(RetraceLine);
			I_RetraceLine = Trace;
			m_Markers = new PlotMarker();
			base.AddSubClass(Markers);
			I_Markers = Markers;
			((ISubClassBase)Trace).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)RetraceLine).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)Markers.Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)Markers.Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
			m_TraceFastDraw = new PlotTraceFastDraw();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Sweep-Interval";
			UserCanMoveDataPoints = false;
			DataPointsMoveStyle = PlotDataMoveStyle.XandY;
			SweepCount = 100;
			SweepXStart = 0.0;
			SweepXInterval = 1.0;
			SweepYDefaultValue = 50.0;
			SweepYDefaultNull = false;
			ResetDataArray();
			SweepLeadingBreakCount = 0;
			Trace.Visible = true;
			Trace.Color = Color.Empty;
			Trace.Thickness = 1.0;
			Trace.Style = PlotPenStyle.Solid;
			RetraceLine.Visible = true;
			RetraceLine.Color = Color.Yellow;
			RetraceLine.Thickness = 1.0;
			RetraceLine.Style = PlotPenStyle.Solid;
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

		private bool ShouldSerializeRetraceLine()
		{
			return ((ISubClassBase)RetraceLine).ShouldSerialize();
		}

		private void ResetRetraceLine()
		{
			((ISubClassBase)RetraceLine).ResetToDefault();
		}

		private bool ShouldSerializeMarkers()
		{
			return ((ISubClassBase)Markers).ShouldSerialize();
		}

		private void ResetMarkers()
		{
			((ISubClassBase)Markers).ResetToDefault();
		}

		private bool ShouldSerializeSweepCount()
		{
			return base.PropertyShouldSerialize("SweepCount");
		}

		private void ResetSweepCount()
		{
			base.PropertyReset("SweepCount");
		}

		private bool ShouldSerializeSweepXStart()
		{
			return base.PropertyShouldSerialize("SweepXStart");
		}

		private void ResetSweepXStart()
		{
			base.PropertyReset("SweepXStart");
		}

		private bool ShouldSerializeSweepXInterval()
		{
			return base.PropertyShouldSerialize("SweepXInterval");
		}

		private void ResetSweepXInterval()
		{
			base.PropertyReset("SweepXInterval");
		}

		private bool ShouldSerializeSweepYDefaultValue()
		{
			return base.PropertyShouldSerialize("SweepYDefaultValue");
		}

		private void ResetSweepYDefaultValue()
		{
			base.PropertyReset("SweepYDefaultValue");
		}

		private bool ShouldSerializeSweepYDefaultNull()
		{
			return base.PropertyShouldSerialize("SweepYDefaultNull");
		}

		private void ResetSweepYDefaultNull()
		{
			base.PropertyReset("SweepYDefaultNull");
		}

		private bool ShouldSerializeSweepLeadingBreakCount()
		{
			return base.PropertyShouldSerialize("SweepLeadingBreakCount");
		}

		private void ResetSweepLeadingBreakCount()
		{
			base.PropertyReset("SweepLeadingBreakCount");
		}

		private bool ShouldSerializeClearOnRetrace()
		{
			return base.PropertyShouldSerialize("ClearOnRetrace");
		}

		private void ResetClearOnRetrace()
		{
			base.PropertyReset("ClearOnRetrace");
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

		private void ResetDataArray()
		{
			base.m_Data.Clear();
			base.m_Data.ClearMinMeanMax();
			m_SweepIndex = 0;
			m_LastAddIndex = -1;
			for (int i = 0; i < SweepCount; i++)
			{
				PlotDataPointSweepInterval plotDataPointSweepInterval = (PlotDataPointSweepInterval)base.m_Data.AddNew();
				plotDataPointSweepInterval.X = SweepXStart + (double)i * SweepXInterval;
				plotDataPointSweepInterval.Y = SweepYDefaultValue;
				plotDataPointSweepInterval.Null = SweepYDefaultNull;
				plotDataPointSweepInterval.Empty = SweepYDefaultNull;
			}
			DoDataChange();
		}

		public void ClearDisplay()
		{
			m_SweepIndex = 0;
			m_LastAddIndex = -1;
			for (int i = 0; i < SweepCount; i++)
			{
				PlotDataPointSweepInterval plotDataPointSweepInterval = base.m_Data[i] as PlotDataPointSweepInterval;
				plotDataPointSweepInterval.X = SweepXStart + (double)i * SweepXInterval;
				plotDataPointSweepInterval.Y = SweepYDefaultValue;
				plotDataPointSweepInterval.Null = SweepYDefaultNull;
				plotDataPointSweepInterval.Empty = SweepYDefaultNull;
			}
			DoDataChange();
		}

		protected override PlotDataPointBase CreateDataPoint()
		{
			return new PlotDataPointSweepInterval(this);
		}

		private bool ShouldSerializeCapacity()
		{
			return false;
		}

		private void ResetCapacity()
		{
		}

		public override void Clear()
		{
			ResetDataArray();
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override void NewOPCData(double data, DateTime timeStamp)
		{
			Add(data);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue)
		{
			m_SweepIndex++;
			if (m_SweepIndex >= SweepCount)
			{
				m_SweepIndex = 0;
				if (ClearOnRetrace)
				{
					ClearDisplay();
				}
			}
			int sweepIndex = m_SweepIndex;
			m_LastAddIndex = m_SweepIndex;
			PlotDataPointSweepInterval plotDataPointSweepInterval = this[sweepIndex];
			base.DataPointInitializing = true;
			try
			{
				plotDataPointSweepInterval.Y = y;
				plotDataPointSweepInterval.Null = nullValue;
				plotDataPointSweepInterval.Empty = emptyValue;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			if (SweepLeadingBreakCount != 0)
			{
				for (int i = 0; i < SweepLeadingBreakCount; i++)
				{
					int num = sweepIndex + i + 1;
					if (num > SweepCount - 1)
					{
						num -= SweepCount;
					}
					this[num].Null = true;
				}
			}
			base.m_Data.UpdateMinMaxMean(plotDataPointSweepInterval);
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
			return sweepIndex;
		}

		public int Add(double y)
		{
			return AddXY(0.0, y, false, false);
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
						PlotDataPointSweepInterval plotDataPointSweepInterval = this[i];
						Point point = base.GetPoint(plotDataPointSweepInterval.X, plotDataPointSweepInterval.Y);
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
			I_Trace.DrawLine(p, r.Left, (r.Top + r.Bottom) / 2, r.Right, (r.Top + r.Bottom) / 2);
			I_Markers.DrawLegend(p, r);
		}

		private void DrawRetraceLine(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			if (RetraceLine.Visible && Count >= 1 && m_LastAddIndex != -1)
			{
				PlotDataPointSweepInterval plotDataPointSweepInterval = this[m_LastAddIndex];
				Pen pen = ((IPlotPen)RetraceLine).GetPen(p);
				int num = xAxis.ScaleDisplay.ValueToPixels(plotDataPointSweepInterval.X);
				int pixelsMin = yAxis.ScaleDisplay.PixelsMin;
				int num2 = xAxis.ScaleDisplay.ValueToPixels(plotDataPointSweepInterval.X);
				int pixelsMax = yAxis.ScaleDisplay.PixelsMax;
				if (base.XYSwapped)
				{
					p.Graphics.DrawLine(pen, pixelsMin, num, pixelsMax, num2);
				}
				else
				{
					p.Graphics.DrawLine(pen, num, pixelsMin, num2, pixelsMax);
				}
			}
		}

		private void DrawTrace(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			m_TraceFastDraw.P = p;
			m_TraceFastDraw.XAxis = xAxis;
			m_TraceFastDraw.YAxis = yAxis;
			m_TraceFastDraw.Pen = ((IPlotPen)Trace).GetPen(p);
			m_TraceFastDraw.TraceVisible = Trace.Visible;
			m_TraceFastDraw.XYSwapped = base.XYSwapped;
			m_TraceFastDraw.Reset();
			for (int i = IndexDrawStart; i <= IndexDrawStop; i++)
			{
				m_TraceFastDraw.AddDataPoint(this[i]);
			}
			m_TraceFastDraw.DrawFlush();
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			if (Trace.Visible && Count > 1)
			{
				DrawTrace(p, xAxis, yAxis);
			}
			DrawMarkers(p, xAxis, yAxis, Markers);
			DrawRetraceLine(p, xAxis, yAxis);
		}
	}
}
