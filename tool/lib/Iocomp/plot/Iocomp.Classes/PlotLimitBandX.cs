using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Limit Band X.")]
	public class PlotLimitBandX : PlotLimitBandBase
	{
		private double m_XStart;

		private double m_XStop;

		private Rectangle m_HitRectStart;

		private Rectangle m_HitRectStop;

		private Rectangle m_HitRectInner;

		private double m_MouseDownPos;

		private double m_MouseDownStart;

		private double m_MouseDownStop;

		private PlotLimitBandHitArea m_MouseDownHitArea;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double XStart
		{
			get
			{
				return m_XStart;
			}
			set
			{
				base.PropertyUpdateDefault("XStart", value);
				if (XStart != value)
				{
					m_XStart = value;
					base.DoPropertyChange(this, "XStart");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double XStop
		{
			get
			{
				return m_XStop;
			}
			set
			{
				base.PropertyUpdateDefault("XStop", value);
				if (XStop != value)
				{
					m_XStop = value;
					base.DoPropertyChange(this, "XStop");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Limit Band-X";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLimitBandXEditorPlugIn";
		}

		public PlotLimitBandX()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "BandX";
			XStart = 40.0;
			XStop = 60.0;
		}

		private bool ShouldSerializeXStart()
		{
			return base.PropertyShouldSerialize("XStart");
		}

		private void ResetXStart()
		{
			base.PropertyReset("XStart");
		}

		private bool ShouldSerializeXStop()
		{
			return base.PropertyShouldSerialize("XStop");
		}

		private void ResetXStop()
		{
			base.PropertyReset("XStop");
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
				m_MouseDownStart = XStart;
				m_MouseDownStop = XStop;
				m_MouseDownPos = base.XAxis.PixelsToValue(e);
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			if (base.IsMouseActive)
			{
				if (m_MouseDownHitArea == PlotLimitBandHitArea.Start)
				{
					XStart = m_MouseDownStart + (base.XAxis.PixelsToValue(e) - m_MouseDownPos);
				}
				else if (m_MouseDownHitArea == PlotLimitBandHitArea.Stop)
				{
					XStop = m_MouseDownStop + (base.XAxis.PixelsToValue(e) - m_MouseDownPos);
				}
				else if (m_MouseDownHitArea == PlotLimitBandHitArea.Band)
				{
					XStart = m_MouseDownStart + (base.XAxis.PixelsToValue(e) - m_MouseDownPos);
					XStop = m_MouseDownStop + (base.XAxis.PixelsToValue(e) - m_MouseDownPos);
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
					XStop -= base.XAxis.Span * 0.001;
				}
				else if (e.KeyCode == Keys.Down)
				{
					XStop -= base.XAxis.Span * 0.001;
				}
				else if (e.KeyCode == Keys.Right)
				{
					XStop += base.XAxis.Span * 0.001;
				}
				else if (e.KeyCode == Keys.Up)
				{
					XStop += base.XAxis.Span * 0.001;
				}
				else if (e.KeyCode == Keys.Prior)
				{
					XStop += base.XAxis.ScaleDisplay.MajorIncrement;
				}
				else if (e.KeyCode == Keys.Next)
				{
					XStop -= base.XAxis.ScaleDisplay.MajorIncrement;
				}
				else if (e.KeyCode == Keys.Home)
				{
					XStop = base.XAxis.Min;
				}
				else if (e.KeyCode == Keys.End)
				{
					XStop = base.XAxis.Max;
				}
			}
			else if (e.KeyCode == Keys.Left)
			{
				XStart -= base.XAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Down)
			{
				XStart -= base.XAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Right)
			{
				XStart += base.XAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Up)
			{
				XStart += base.XAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Prior)
			{
				XStart += base.XAxis.ScaleDisplay.MajorIncrement;
			}
			else if (e.KeyCode == Keys.Next)
			{
				XStart -= base.XAxis.ScaleDisplay.MajorIncrement;
			}
			else if (e.KeyCode == Keys.Home)
			{
				XStart = base.XAxis.Min;
			}
			else if (e.KeyCode == Keys.End)
			{
				XStart = base.XAxis.Max;
			}
		}

		protected override void InternalOnMouseWheel(MouseEventArgs e)
		{
			if (Control.ModifierKeys == Keys.Control)
			{
				XStop += base.XAxis.ScaleRange.Span * 0.001 * (double)e.Delta / (double)Math.Abs(e.Delta);
			}
			else
			{
				XStart += base.XAxis.ScaleRange.Span * 0.001 * (double)e.Delta / (double)Math.Abs(e.Delta);
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
				return Cursors.SizeNS;
			}
			return Cursors.SizeWE;
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			Pen pen = ((IPlotPen)base.Fill.Pen).GetPen(p);
			int dataViewYPixelsMin = base.GetDataViewYPixelsMin();
			int dataViewYPixelsMax = base.GetDataViewYPixelsMax();
			int num = xAxis.ValueToPixels(XStart);
			int num2 = dataViewYPixelsMax;
			int num3 = num;
			int num4 = dataViewYPixelsMin;
			int num5 = xAxis.ValueToPixels(XStop);
			int num6 = dataViewYPixelsMax;
			int num7 = num5;
			int num8 = dataViewYPixelsMin;
			Rectangle rectangle = iRectangle.FromLTRB(base.XYSwapped, num, num4, num5, num2);
			m_HitRectStart = iRectangle.FromLTRB(base.XYSwapped, num - base.HitRegionSize, num2, num + base.HitRegionSize, num4);
			m_HitRectStop = iRectangle.FromLTRB(base.XYSwapped, num5 - base.HitRegionSize, num6, num5 + base.HitRegionSize, num8);
			m_HitRectInner = rectangle;
			m_HitRectInner.Inflate(-base.HitRegionSize, 0);
			if (base.Fill.Brush.Visible)
			{
				Brush brush = ((IPlotBrush)base.Fill.Brush).GetBrush(p, rectangle);
				p.Graphics.FillRectangle(brush, rectangle);
			}
			if (base.Fill.Pen.Visible)
			{
				if (base.XYSwapped)
				{
					p.Graphics.DrawLine(pen, num2, num, num4, num3);
					p.Graphics.DrawLine(pen, num6, num5, num8, num7);
				}
				else
				{
					p.Graphics.DrawLine(pen, num, num2, num3, num4);
					p.Graphics.DrawLine(pen, num5, num6, num7, num8);
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
