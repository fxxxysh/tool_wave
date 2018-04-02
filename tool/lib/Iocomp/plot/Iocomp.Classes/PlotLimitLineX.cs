using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Limit Line X.")]
	public class PlotLimitLineX : PlotLimitLineBase
	{
		private double m_XReference;

		private double m_MouseDownPos;

		private double m_MouseDownReference;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double XReference
		{
			get
			{
				return m_XReference;
			}
			set
			{
				base.PropertyUpdateDefault("XReference", value);
				if (XReference != value)
				{
					m_XReference = value;
					base.DoPropertyChange(this, "XReference");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Limit Line-X";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLimitLineXEditorPlugIn";
		}

		public PlotLimitLineX()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "LineX";
			XReference = 50.0;
		}

		private bool ShouldSerializeXReference()
		{
			return base.PropertyShouldSerialize("XReference");
		}

		private void ResetXReference()
		{
			base.PropertyReset("XReference");
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
				m_MouseDownReference = XReference;
				m_MouseDownPos = base.XAxis.PixelsToValue(e);
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			if (base.IsMouseActive)
			{
				XReference = m_MouseDownReference + (base.XAxis.PixelsToValue(e) - m_MouseDownPos);
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
				XReference -= base.XAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Down)
			{
				XReference -= base.XAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Right)
			{
				XReference += base.XAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Up)
			{
				XReference += base.XAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Prior)
			{
				XReference += base.XAxis.ScaleDisplay.MajorIncrement;
			}
			else if (e.KeyCode == Keys.Next)
			{
				XReference -= base.XAxis.ScaleDisplay.MajorIncrement;
			}
			else if (e.KeyCode == Keys.Home)
			{
				XReference = base.XAxis.Min;
			}
			else if (e.KeyCode == Keys.End)
			{
				XReference = base.XAxis.Max;
			}
		}

		protected override void InternalOnMouseWheel(MouseEventArgs e)
		{
			XReference += base.XAxis.ScaleRange.Span * 0.001 * (double)e.Delta / (double)Math.Abs(e.Delta);
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
			int num = xAxis.ValueToPixels(XReference);
			int dataViewYPixelsMin = base.GetDataViewYPixelsMin();
			int dataViewYPixelsMax = base.GetDataViewYPixelsMax();
			if (base.XYSwapped)
			{
				p.Graphics.DrawLine(pen, dataViewYPixelsMin, num, dataViewYPixelsMax, num);
			}
			else
			{
				p.Graphics.DrawLine(pen, num, dataViewYPixelsMin, num, dataViewYPixelsMax);
			}
			base.Bounds = iRectangle.FromLTRB(base.XYSwapped, num - base.HitRegionSize, dataViewYPixelsMin, num + base.HitRegionSize, dataViewYPixelsMax);
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
