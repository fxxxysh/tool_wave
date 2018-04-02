using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Channel Trace XY")]
	public class PlotChannelTraceXY : PlotChannelXYBase
	{
		private PlotPen m_Trace;

		private IPlotPen I_Trace;

		private PlotMarker m_Markers;

		private IPlotMarker I_Markers;

		private bool m_UserCanMoveDataPoints;

		private bool m_DrawCustomDataPointAttributes;

		private PlotDataMoveStyle m_DataPointsMoveStyle;

		private int m_MouseDownDataPointIndex;

		private PlotDataPointTraceXY m_MouseDownDataPoint;

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
		public PlotMarker Markers
		{
			get
			{
				return m_Markers;
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

		public PlotDataPointTraceXY this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointTraceXY;
			}
		}

		public event PlotChannelDataPointMovedEventHandler DataPointMoved;

		public event PlotChannelDataPointClickEventHandler DataPointClick;

		public event PlotChannelDataPointClickEventHandler DataPointDoubleClick;

		protected override string GetPlugInTitle()
		{
			return "Channel Trace XY";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelTraceXYEditorPlugIn";
		}

		public PlotChannelTraceXY()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Trace = new PlotPen();
			base.AddSubClass(Trace);
			I_Trace = Trace;
			m_Markers = new PlotMarker();
			base.AddSubClass(Markers);
			I_Markers = Markers;
			((ISubClassBase)Trace).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)Markers.Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)Markers.Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "TraceXY";
			base.DataCollection.XValueNotValidWhenEmptyOrNull = true;
			UserCanMoveDataPoints = false;
			DrawCustomDataPointAttributes = false;
			DataPointsMoveStyle = PlotDataMoveStyle.XandY;
			Trace.Color = Color.Empty;
			Trace.Thickness = 1.0;
			Trace.Style = PlotPenStyle.Solid;
			Trace.Visible = false;
			Markers.Visible = true;
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

		private bool ShouldSerializeMarkers()
		{
			return ((ISubClassBase)Markers).ShouldSerialize();
		}

		private void ResetMarkers()
		{
			((ISubClassBase)Markers).ResetToDefault();
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
			return new PlotDataPointTraceXY(this);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue)
		{
			PlotDataPointTraceXY plotDataPointTraceXY = (PlotDataPointTraceXY)base.m_Data.AddNew();
			base.DataPointInitializing = true;
			try
			{
				plotDataPointTraceXY.X = x;
				plotDataPointTraceXY.Y = y;
				plotDataPointTraceXY.Null = nullValue;
				plotDataPointTraceXY.Empty = emptyValue;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			base.m_Data.UpdateMinMaxMean(plotDataPointTraceXY);
			if (!nullValue && !emptyValue && base.SendXAxisTrackingData)
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
						PlotDataPointTraceXY plotDataPointTraceXY = this[i];
						Point point = base.GetPoint(plotDataPointTraceXY.X, plotDataPointTraceXY.Y);
						int num = (!DrawCustomDataPointAttributes) ? Markers.Size : plotDataPointTraceXY.Marker.Size;
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
				double x = m_MouseDownDataPointX + (base.XAxis.PixelsToValue(e) - m_MouseDownPosX);
				double y = m_MouseDownDataPointY + (base.YAxis.PixelsToValue(e) - m_MouseDownPosY);
				if (DataPointsMoveStyle == PlotDataMoveStyle.XandY || DataPointsMoveStyle == PlotDataMoveStyle.XOnly)
				{
					m_MouseDownDataPoint.X = x;
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

		private void DrawLine(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis, Pen pen, PlotDataPointTraceXY point1, PlotDataPointTraceXY point2)
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
		}

		private void DrawTrace(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			PlotDataPointTraceXY plotDataPointTraceXY = null;
			PlotDataPointTraceXY plotDataPointTraceXY2 = null;
			((IPlotPen)Trace).GetPen(p);
			for (int i = IndexDrawStart; i <= IndexDrawStop; i++)
			{
				PlotDataPointTraceXY plotDataPointTraceXY3 = this[i];
				if (plotDataPointTraceXY3.Null)
				{
					plotDataPointTraceXY = null;
					plotDataPointTraceXY2 = null;
				}
				else if (!plotDataPointTraceXY3.Empty)
				{
					if (plotDataPointTraceXY == null)
					{
						plotDataPointTraceXY = plotDataPointTraceXY3;
					}
					else
					{
						plotDataPointTraceXY2 = plotDataPointTraceXY3;
						if (plotDataPointTraceXY2.Trace.Visible)
						{
							DrawLine(p, xAxis, yAxis, ((IPlotPen)plotDataPointTraceXY2.Trace).GetPen(p), plotDataPointTraceXY, plotDataPointTraceXY2);
						}
						plotDataPointTraceXY = plotDataPointTraceXY2;
					}
				}
			}
		}

		protected override void DrawMarkers(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis, PlotMarker markers)
		{
			if (markers.Visible)
			{
				for (int i = IndexDrawStart; i <= IndexDrawStop; i++)
				{
					PlotDataPointTraceXY plotDataPointTraceXY = this[i];
					if (!plotDataPointTraceXY.Null && !plotDataPointTraceXY.Empty)
					{
						int num = xAxis.ScaleDisplay.ValueToPixels(plotDataPointTraceXY.X);
						int num2 = yAxis.ScaleDisplay.ValueToPixels(plotDataPointTraceXY.Y);
						if (base.XYSwapped)
						{
							((IPlotMarker)plotDataPointTraceXY.Marker).Draw(p, num2, num);
						}
						else
						{
							((IPlotMarker)plotDataPointTraceXY.Marker).Draw(p, num, num2);
						}
					}
				}
			}
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (Count == 0)
			{
				base.CanDraw = false;
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
