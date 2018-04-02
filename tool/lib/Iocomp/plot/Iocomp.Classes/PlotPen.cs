using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Description("Plot Pen.")]
	public class PlotPen : SubClassBase, IPlotPen
	{
		private double m_Thickness;

		private PlotPenStyle m_Style;

		private DashStyle m_StyleGDI;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool Visible
		{
			get
			{
				return VisibleInternal;
			}
			set
			{
				VisibleInternal = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public new Color Color
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.Color = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("The Thickness property specifies the size or thickness of the trace line.")]
		public double Thickness
		{
			get
			{
				return m_Thickness;
			}
			set
			{
				base.PropertyUpdateDefault("Thickness", value);
				if (Thickness != value)
				{
					m_Thickness = value;
					base.DoPropertyChange(this, "Thickness");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotPenStyle Style
		{
			get
			{
				return m_Style;
			}
			set
			{
				base.PropertyUpdateDefault("Style", value);
				if (Style != value)
				{
					m_Style = value;
					if (m_Style == PlotPenStyle.Solid)
					{
						m_StyleGDI = DashStyle.Solid;
					}
					else if (m_Style == PlotPenStyle.Dash)
					{
						m_StyleGDI = DashStyle.Dash;
					}
					else if (m_Style == PlotPenStyle.DashDot)
					{
						m_StyleGDI = DashStyle.DashDot;
					}
					else if (m_Style == PlotPenStyle.DashDotDot)
					{
						m_StyleGDI = DashStyle.DashDotDot;
					}
					else if (m_Style == PlotPenStyle.Dot)
					{
						m_StyleGDI = DashStyle.Dot;
					}
					base.DoPropertyChange(this, "Style");
				}
			}
		}

		[Description("")]
		public DashStyle StyleGDI
		{
			get
			{
				return m_StyleGDI;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Plot Pen";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotPenEditorPlugIn";
		}

		Pen IPlotPen.GetPen(PaintArgs p)
		{
			return GetPen(p);
		}

		void IPlotPen.DrawLine(PaintArgs p, int x1, int y1, int x2, int y2)
		{
			DrawLine(p, x1, y1, x2, y2);
		}

		void IPlotPen.DrawLine(PaintArgs p, Point pt1, Point pt2)
		{
			DrawLine(p, pt1, pt2);
		}

		void IPlotPen.DrawArc(PaintArgs p, Rectangle r, double startAngle, double sweepAngle)
		{
			DrawArc(p, r, startAngle, sweepAngle);
		}

		public PlotPen()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.ColorAmbientSource = AmbientColorSouce.ForeColor;
			Visible = true;
			Color = Color.Empty;
			Thickness = 1.0;
			Style = PlotPenStyle.Solid;
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeThickness()
		{
			return base.PropertyShouldSerialize("Thickness");
		}

		private void ResetThickness()
		{
			base.PropertyReset("Thickness");
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private Pen GetPen(PaintArgs p)
		{
			return p.Graphics.Pen(Color, StyleGDI, (float)Thickness);
		}

		private void DrawLine(PaintArgs p, int x1, int y1, int x2, int y2)
		{
			if (Visible)
			{
				p.Graphics.DrawLine(GetPen(p), x1, y1, x2, y2);
			}
		}

		private void DrawLine(PaintArgs p, Point pt1, Point pt2)
		{
			if (Visible)
			{
				p.Graphics.DrawLine(GetPen(p), pt1, pt2);
			}
		}

		private void DrawArc(PaintArgs p, Rectangle r, double startAngle, double sweepAngle)
		{
			if (Visible)
			{
				p.Graphics.DrawArc(GetPen(p), r, (float)startAngle, (float)sweepAngle);
			}
		}
	}
}
