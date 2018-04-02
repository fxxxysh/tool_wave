using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Channel Bi-Fill")]
	public class PlotChannelBiFill : PlotChannelConsecutive
	{
		private double m_Reference;

		private bool m_UserCanMoveDataPoints;

		private PlotDataMoveStyle m_DataPointsMoveStyle;

		private PlotFill m_FillHigh;

		private IPlotFill I_FillHigh;

		private PlotFill m_FillLow;

		private IPlotFill I_FillLow;

		private PlotMarker m_Markers;

		private IPlotMarker I_Markers;

		private PlotPen m_Trace;

		private IPlotPen I_Trace;

		private PlotTraceFastDraw m_TraceFastDraw;

		private int m_MouseDownDataPointIndex;

		private PlotDataPointBiFill m_MouseDownDataPoint;

		private double m_MouseDownDataPointX;

		private double m_MouseDownDataPointY;

		private double m_MouseDownPosX;

		private double m_MouseDownPosY;

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

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[RefreshProperties(RefreshProperties.All)]
		public PlotFill FillLow
		{
			get
			{
				return m_FillLow;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotFill FillHigh
		{
			get
			{
				return m_FillHigh;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotPen Trace
		{
			get
			{
				return m_Trace;
			}
		}

		public PlotDataPointBiFill this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointBiFill;
			}
		}

		public event PlotChannelDataPointMovedEventHandler DataPointMoved;

		public event PlotChannelDataPointClickEventHandler DataPointClick;

		public event PlotChannelDataPointClickEventHandler DataPointDoubleClick;

		protected override string GetPlugInTitle()
		{
			return "Channel Bi-Fill";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelBiFillEditorPlugIn";
		}

		public PlotChannelBiFill()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_FillHigh = new PlotFill();
			base.AddSubClass(FillHigh);
			I_FillHigh = FillHigh;
			m_FillLow = new PlotFill();
			base.AddSubClass(FillLow);
			I_FillLow = FillLow;
			m_Markers = new PlotMarker();
			base.AddSubClass(Markers);
			I_Markers = Markers;
			m_Trace = new PlotPen();
			base.AddSubClass(Trace);
			I_Trace = Trace;
			((ISubClassBase)Trace).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)FillHigh.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)FillHigh.Brush).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)FillLow.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)FillLow.Brush).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)Markers.Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)Markers.Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
			m_TraceFastDraw = new PlotTraceFastDraw();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "BiFill";
			UserCanMoveDataPoints = false;
			DataPointsMoveStyle = PlotDataMoveStyle.XandY;
			Reference = 0.0;
			FillHigh.Visible = true;
			FillHigh.Brush.Visible = true;
			FillHigh.Brush.Style = PlotBrushStyle.Solid;
			FillHigh.Brush.SolidColor = Color.Empty;
			FillHigh.Brush.GradientStartColor = Color.Blue;
			FillHigh.Brush.GradientStopColor = Color.Aqua;
			FillHigh.Brush.HatchForeColor = Color.Empty;
			FillHigh.Brush.HatchBackColor = Color.Empty;
			FillHigh.Pen.Visible = true;
			FillHigh.Pen.Color = Color.Empty;
			FillHigh.Pen.Thickness = 1.0;
			FillHigh.Pen.Style = PlotPenStyle.Solid;
			FillLow.Visible = true;
			FillLow.Brush.Visible = true;
			FillLow.Brush.Style = PlotBrushStyle.Solid;
			FillLow.Brush.SolidColor = Color.Empty;
			FillLow.Brush.GradientStartColor = Color.Blue;
			FillLow.Brush.GradientStopColor = Color.Aqua;
			FillLow.Brush.HatchForeColor = Color.Empty;
			FillLow.Brush.HatchBackColor = Color.Empty;
			FillLow.Pen.Visible = true;
			FillLow.Pen.Color = Color.Empty;
			FillLow.Pen.Thickness = 1.0;
			FillLow.Pen.Style = PlotPenStyle.Solid;
			Markers.Visible = false;
			Markers.Style = PlotMarkerStyle.Circle;
			Markers.Size = 3;
			Markers.Fill.Pen.Visible = true;
			Markers.Fill.Pen.Style = PlotPenStyle.Solid;
			Markers.Fill.Pen.Color = Color.Empty;
			Markers.Fill.Pen.Thickness = 1.0;
			Markers.Font = null;
			Markers.ForeColor = Color.Empty;
			Markers.Text = "";
			Markers.Fill.Brush.Visible = true;
			Markers.Fill.Brush.Style = PlotBrushStyle.Solid;
			Markers.Fill.Brush.SolidColor = Color.Empty;
			Markers.Fill.Brush.GradientStartColor = Color.Blue;
			Markers.Fill.Brush.GradientStopColor = Color.Aqua;
			Markers.Fill.Brush.HatchForeColor = Color.Empty;
			Markers.Fill.Brush.HatchBackColor = Color.Empty;
			Trace.Visible = false;
			Trace.Color = Color.Empty;
			Trace.Thickness = 1.0;
			Trace.Style = PlotPenStyle.Solid;
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

		private bool ShouldSerializeDataPointsMoveStyle()
		{
			return base.PropertyShouldSerialize("DataPointsMoveStyle");
		}

		private void ResetDataPointsMoveStyle()
		{
			base.PropertyReset("DataPointsMoveStyle");
		}

		private bool ShouldSerializeFillLow()
		{
			return ((ISubClassBase)FillLow).ShouldSerialize();
		}

		private void ResetFillLow()
		{
			((ISubClassBase)FillLow).ResetToDefault();
		}

		private bool ShouldSerializeFillHigh()
		{
			return ((ISubClassBase)FillHigh).ShouldSerialize();
		}

		private void ResetFillHigh()
		{
			((ISubClassBase)FillHigh).ResetToDefault();
		}

		private bool ShouldSerializeTrace()
		{
			return ((ISubClassBase)Trace).ShouldSerialize();
		}

		private void ResetTrace()
		{
			((ISubClassBase)Trace).ResetToDefault();
		}

		protected override PlotDataPointBase CreateDataPoint()
		{
			return new PlotDataPointBiFill(this);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue)
		{
			base.CheckForValidNextX(x);
			PlotDataPointBiFill plotDataPointBiFill = (PlotDataPointBiFill)base.m_Data.AddNew();
			base.DataPointInitializing = true;
			try
			{
				plotDataPointBiFill.X = x;
				plotDataPointBiFill.Y = y;
				plotDataPointBiFill.Null = nullValue;
				plotDataPointBiFill.Empty = emptyValue;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			base.m_Data.UpdateMinMaxMean(plotDataPointBiFill);
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
						PlotDataPointBiFill plotDataPointBiFill = this[i];
						Point point = base.GetPoint(plotDataPointBiFill.X, plotDataPointBiFill.Y);
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

		protected override void LoadDesignTimeData(PlotXAxis xAxis, PlotYAxis yAxis, Random random, double yMin, double ySpan)
		{
			for (double num = xAxis.Min; num < xAxis.Max; num += ySpan / 5.0)
			{
				AddXY(num, Reference - ySpan / 2.0 + random.NextDouble() * ySpan);
			}
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (Markers.Visible && Markers.Fill.Pen.Visible)
			{
				return;
			}
			if (Markers.Visible && Markers.Fill.Brush.Visible)
			{
				return;
			}
			if (FillLow.Visible && FillLow.Pen.Visible)
			{
				return;
			}
			if (FillLow.Visible && FillLow.Brush.Visible)
			{
				return;
			}
			if (FillHigh.Visible && FillHigh.Pen.Visible)
			{
				return;
			}
			if (FillHigh.Visible && FillHigh.Brush.Visible)
			{
				return;
			}
			base.CanDraw = false;
		}

		protected override void DrawLegendMarker(PaintArgs p, Rectangle r)
		{
			Rectangle r2 = new Rectangle(r.Left, r.Top, r.Width, r.Height / 2);
			I_FillHigh.Draw(p, r2);
			r2 = new Rectangle(r.Left, r.Top + r.Height / 2, r.Width, r.Height - r.Height / 2);
			I_FillLow.Draw(p, r2);
			p.Graphics.DrawRectangle(p.Graphics.Pen(Color.Silver), r);
		}

		protected void DrawFill(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			if (!FillHigh.Visible && !FillLow.Visible)
			{
				return;
			}
			if (Count >= 2)
			{
				Point[] array = new Point[base.DrawPointCount + 2];
				int num = base.YAxis.ScaleDisplay.ValueToPixels(Reference);
				int num2 = num;
				int num3 = num;
				int num4 = xAxis.ScaleDisplay.ValueToPixels(GetX(IndexDrawStart));
				int num5 = xAxis.ScaleDisplay.ValueToPixels(GetX(IndexDrawStop));
				if (base.XYSwapped)
				{
					array[0] = new Point(num, num4);
				}
				else
				{
					array[0] = new Point(num4, num);
				}
				for (int i = IndexDrawStart; i <= IndexDrawStop; i++)
				{
					int num6 = xAxis.ScaleDisplay.ValueToPixels(GetX(i));
					int num7 = yAxis.ScaleDisplay.ValueToPixels(GetY(i));
					num2 = Math.Min(num2, num7);
					num3 = Math.Max(num3, num7);
					if (base.XYSwapped)
					{
						array[i - IndexDrawStart + 1] = new Point(num7, num6);
					}
					else
					{
						array[i - IndexDrawStart + 1] = new Point(num6, num7);
					}
				}
				if (base.XYSwapped)
				{
					array[array.Length - 1] = new Point(num, num5);
				}
				else
				{
					array[array.Length - 1] = new Point(num5, num);
				}
				Rectangle boundRect = iRectangle.FromLTRB(base.XYSwapped, num4, num2, num5, num3);
				Rectangle rect = iRectangle.FromLTRB(base.XYSwapped, xAxis.ScaleDisplay.PixelsMin, yAxis.ScaleDisplay.PixelsMax, base.XAxis.ScaleDisplay.PixelsMax, num);
				Region clip = new Region(rect);
				p.Graphics.Clip = clip;
				I_FillHigh.DrawBiFill(p, array, boundRect);
				rect = iRectangle.FromLTRB(base.XYSwapped, xAxis.ScaleDisplay.PixelsMin, yAxis.ScaleDisplay.PixelsMin, base.XAxis.ScaleDisplay.PixelsMax, num);
				clip = new Region(rect);
				p.Graphics.Clip = clip;
				I_FillLow.DrawBiFill(p, array, boundRect);
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
			DrawFill(p, xAxis, yAxis);
			base.SetClipRect(p);
			if (Trace.Visible)
			{
				DrawTrace(p, xAxis, yAxis);
			}
			DrawMarkers(p, xAxis, yAxis, Markers);
		}
	}
}
