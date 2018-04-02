using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Limit Line Y.")]
	public class PlotLimitLineY : PlotLimitLineBase
	{
		private double m_YReference;

		private double m_MouseDownPos;

		private double m_MouseDownReference;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double YReference
		{
			get
			{
				return m_YReference;
			}
			set
			{
				base.PropertyUpdateDefault("YReference", value);
				if (YReference != value)
				{
					m_YReference = value;
					base.DoPropertyChange(this, "YReference");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Limit Line-Y";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLimitLineYEditorPlugIn";
		}

		public PlotLimitLineY()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "LineY";
			YReference = 50.0;
		}

		private bool ShouldSerializeYReference()
		{
			return base.PropertyShouldSerialize("YReference");
		}

		private void ResetYReference()
		{
			base.PropertyReset("YReference");
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (shouldFocus)
			{
				base.Focus();
			}
			if (base.UserCanMove)
			{
				base.IsMouseActive = true;
				int value = (!base.XYSwapped) ? e.Y : e.X;
				m_MouseDownReference = YReference;
				m_MouseDownPos = base.YAxis.PixelsToValue(value);
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			if (base.IsMouseActive)
			{
				YReference = m_MouseDownReference + (base.YAxis.PixelsToValue(e) - m_MouseDownPos);
			}
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			base.IsMouseActive = false;
		}

		protected override void InternalOnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left)
			{
				YReference -= base.YAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Down)
			{
				YReference -= base.YAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Right)
			{
				YReference += base.YAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Up)
			{
				YReference += base.YAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Prior)
			{
				YReference += base.YAxis.ScaleDisplay.MajorIncrement;
			}
			else if (e.KeyCode == Keys.Next)
			{
				YReference -= base.YAxis.ScaleDisplay.MajorIncrement;
			}
			else if (e.KeyCode == Keys.Home)
			{
				YReference = base.YAxis.Min;
			}
			else if (e.KeyCode == Keys.End)
			{
				YReference = base.YAxis.Max;
			}
		}

		protected override void InternalOnMouseWheel(MouseEventArgs e)
		{
			YReference += base.YAxis.ScaleRange.Span * 0.001 * (double)e.Delta / (double)Math.Abs(e.Delta);
		}

		protected override Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			if (!base.UserCanMove)
			{
				return Cursors.Default;
			}
			return Cursors.Hand;
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			Pen pen = ((IPlotPen)base.Line).GetPen(p);
			int num = yAxis.ValueToPixels(YReference);
			int dataViewXPixelsMin = base.GetDataViewXPixelsMin();
			int dataViewXPixelsMax = base.GetDataViewXPixelsMax();
			if (base.XYSwapped)
			{
				p.Graphics.DrawLine(pen, num, dataViewXPixelsMin, num, dataViewXPixelsMax);
			}
			else
			{
				p.Graphics.DrawLine(pen, dataViewXPixelsMin, num, dataViewXPixelsMax, num);
			}
			base.Bounds = iRectangle.FromLTRB(base.XYSwapped, dataViewXPixelsMin, num - base.HitRegionSize, dataViewXPixelsMax, num + base.HitRegionSize);
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
