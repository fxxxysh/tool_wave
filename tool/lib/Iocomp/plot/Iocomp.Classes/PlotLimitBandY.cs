using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Limit Band Y.")]
	public class PlotLimitBandY : PlotLimitBandBase
	{
		private double m_YStart;

		private double m_YStop;

		private Rectangle m_HitRectStart;

		private Rectangle m_HitRectStop;

		private Rectangle m_HitRectInner;

		private double m_MouseDownPos;

		private double m_MouseDownStart;

		private double m_MouseDownStop;

		private PlotLimitBandHitArea m_MouseDownHitArea;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double YStart
		{
			get
			{
				return m_YStart;
			}
			set
			{
				base.PropertyUpdateDefault("YStart", value);
				if (YStart != value)
				{
					m_YStart = value;
					base.DoPropertyChange(this, "YStart");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double YStop
		{
			get
			{
				return m_YStop;
			}
			set
			{
				base.PropertyUpdateDefault("YStop", value);
				if (YStop != value)
				{
					m_YStop = value;
					base.DoPropertyChange(this, "YStop");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Limit Band-Y";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLimitBandYEditorPlugIn";
		}

		public PlotLimitBandY()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "BandY";
			YStart = 40.0;
			YStop = 60.0;
		}

		private bool ShouldSerializeYStart()
		{
			return base.PropertyShouldSerialize("YStart");
		}

		private void ResetYStart()
		{
			base.PropertyReset("YStart");
		}

		private bool ShouldSerializeYStop()
		{
			return base.PropertyShouldSerialize("YStop");
		}

		private void ResetYStop()
		{
			base.PropertyReset("YStop");
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (shouldFocus)
			{
				base.Focus();
			}
			if (base.UserCanMove)
			{
				if (m_HitRectStart.Contains(e.X, e.Y))
				{
					m_MouseDownHitArea = PlotLimitBandHitArea.Start;
				}
				else if (m_HitRectStop.Contains(e.X, e.Y))
				{
					m_MouseDownHitArea = PlotLimitBandHitArea.Stop;
				}
				else
				{
					m_MouseDownHitArea = PlotLimitBandHitArea.Band;
				}
				base.IsMouseActive = true;
				m_MouseDownStart = YStart;
				m_MouseDownStop = YStop;
				m_MouseDownPos = base.YAxis.PixelsToValue(e);
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			if (base.IsMouseActive)
			{
				if (m_MouseDownHitArea == PlotLimitBandHitArea.Start)
				{
					YStart = m_MouseDownStart + (base.YAxis.PixelsToValue(e) - m_MouseDownPos);
				}
				else if (m_MouseDownHitArea == PlotLimitBandHitArea.Stop)
				{
					YStop = m_MouseDownStop + (base.YAxis.PixelsToValue(e) - m_MouseDownPos);
				}
				else if (m_MouseDownHitArea == PlotLimitBandHitArea.Band)
				{
					YStart = m_MouseDownStart + (base.YAxis.PixelsToValue(e) - m_MouseDownPos);
					YStop = m_MouseDownStop + (base.YAxis.PixelsToValue(e) - m_MouseDownPos);
				}
			}
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			base.IsMouseActive = false;
		}

		protected override void InternalOnKeyDown(KeyEventArgs e)
		{
			if (e.Control)
			{
				if (e.KeyCode == Keys.Left)
				{
					YStop -= base.YAxis.Span * 0.001;
				}
				else if (e.KeyCode == Keys.Down)
				{
					YStop -= base.YAxis.Span * 0.001;
				}
				else if (e.KeyCode == Keys.Right)
				{
					YStop += base.YAxis.Span * 0.001;
				}
				else if (e.KeyCode == Keys.Up)
				{
					YStop += base.YAxis.Span * 0.001;
				}
				else if (e.KeyCode == Keys.Prior)
				{
					YStop += base.YAxis.ScaleDisplay.MajorIncrement;
				}
				else if (e.KeyCode == Keys.Next)
				{
					YStop -= base.YAxis.ScaleDisplay.MajorIncrement;
				}
				else if (e.KeyCode == Keys.Home)
				{
					YStop = base.YAxis.Min;
				}
				else if (e.KeyCode == Keys.End)
				{
					YStop = base.YAxis.Max;
				}
			}
			else if (e.KeyCode == Keys.Left)
			{
				YStart -= base.YAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Down)
			{
				YStart -= base.YAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Right)
			{
				YStart += base.YAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Up)
			{
				YStart += base.YAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Prior)
			{
				YStart += base.YAxis.ScaleDisplay.MajorIncrement;
			}
			else if (e.KeyCode == Keys.Next)
			{
				YStart -= base.YAxis.ScaleDisplay.MajorIncrement;
			}
			else if (e.KeyCode == Keys.Home)
			{
				YStart = base.YAxis.Min;
			}
			else if (e.KeyCode == Keys.End)
			{
				YStart = base.YAxis.Max;
			}
		}

		protected override void InternalOnMouseWheel(MouseEventArgs e)
		{
			if (Control.ModifierKeys == Keys.Control)
			{
				YStop += base.YAxis.ScaleRange.Span * 0.001 * (double)e.Delta / (double)Math.Abs(e.Delta);
			}
			else
			{
				YStart += base.YAxis.ScaleRange.Span * 0.001 * (double)e.Delta / (double)Math.Abs(e.Delta);
			}
		}

		protected override Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			if (!base.UserCanMove)
			{
				return Cursors.Default;
			}
			if (!m_HitRectStart.Contains(e.X, e.Y) && !m_HitRectStop.Contains(e.X, e.Y))
			{
				return Cursors.Hand;
			}
			if (base.XYSwapped)
			{
				return Cursors.SizeWE;
			}
			return Cursors.SizeNS;
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			Pen pen = ((IPlotPen)base.Fill.Pen).GetPen(p);
			int dataViewXPixelsMin = base.GetDataViewXPixelsMin();
			int dataViewXPixelsMax = base.GetDataViewXPixelsMax();
			int num = yAxis.ValueToPixels(YStart);
			int num2 = dataViewXPixelsMax;
			int num3 = num;
			int num4 = dataViewXPixelsMin;
			int num5 = yAxis.ValueToPixels(YStop);
			int num6 = dataViewXPixelsMax;
			int num7 = num5;
			int num8 = dataViewXPixelsMin;
			Rectangle rectangle = iRectangle.FromLTRB(base.XYSwapped, num2, num5, num8, num);
			m_HitRectStart = iRectangle.FromLTRB(base.XYSwapped, num2, num - base.HitRegionSize, num4, num3 + base.HitRegionSize);
			m_HitRectStop = iRectangle.FromLTRB(base.XYSwapped, num6, num5 - base.HitRegionSize, num8, num7 + base.HitRegionSize);
			m_HitRectInner = rectangle;
			m_HitRectInner.Inflate(0, -base.HitRegionSize);
			if (base.Fill.Brush.Visible)
			{
				Brush brush = ((IPlotBrush)base.Fill.Brush).GetBrush(p, rectangle);
				p.Graphics.FillRectangle(brush, rectangle);
			}
			if (base.Fill.Pen.Visible)
			{
				if (base.XYSwapped)
				{
					p.Graphics.DrawLine(pen, num, num2, num3, num4);
					p.Graphics.DrawLine(pen, num5, num6, num7, num8);
				}
				else
				{
					p.Graphics.DrawLine(pen, num2, num, num4, num3);
					p.Graphics.DrawLine(pen, num6, num5, num8, num7);
				}
			}
			base.Bounds = Rectangle.Union(m_HitRectStart, m_HitRectStop);
		}

		protected override void DrawFocusRectangles(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			if (base.Focused)
			{
				p.Graphics.DrawFocusRectangle(base.Bounds, base.BackColor);
			}
		}
	}
}
