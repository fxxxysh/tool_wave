using Iocomp.Interfaces;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Description("Plot Fill.")]
	public class PlotFill : SubClassBase, IPlotFill
	{
		private PlotBrush m_Brush;

		protected IPlotBrush I_Brush;

		private PlotPen m_Pen;

		protected IPlotPen I_Pen;

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
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotBrush Brush
		{
			get
			{
				return m_Brush;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotPen Pen
		{
			get
			{
				return m_Pen;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Plot Fill";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotFillEditorPlugIn";
		}

		void IPlotFill.DrawEllipse(PaintArgs p, Rectangle r)
		{
			DrawEllipse(p, r);
		}

		void IPlotFill.DrawPie(PaintArgs p, Rectangle r, double startAngle, double sweepAngle)
		{
			DrawPie(p, r, startAngle, sweepAngle);
		}

		void IPlotFill.Draw(PaintArgs p, Rectangle r)
		{
			Draw(p, r);
		}

		void IPlotFill.Draw(PaintArgs p, Point[] points)
		{
			Draw(p, points);
		}

		void IPlotFill.Draw(PaintArgs p, Point[] points, Rectangle boundsRect)
		{
			Draw(p, points, boundsRect);
		}

		void IPlotFill.DrawBiFill(PaintArgs p, Point[] points, Rectangle boundsRect)
		{
			DrawBiFill(p, points, boundsRect);
		}

		public PlotFill()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Brush = new PlotBrush();
			base.AddSubClass(Brush);
			I_Brush = Brush;
			m_Pen = new PlotPen();
			base.AddSubClass(Pen);
			I_Pen = Pen;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Visible = true;
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeBrush()
		{
			return ((ISubClassBase)Brush).ShouldSerialize();
		}

		private void ResetBrush()
		{
			((ISubClassBase)Brush).ResetToDefault();
		}

		private bool ShouldSerializePen()
		{
			return ((ISubClassBase)Pen).ShouldSerialize();
		}

		private void ResetPen()
		{
			((ISubClassBase)Pen).ResetToDefault();
		}

		private void DrawEllipse(PaintArgs p, Rectangle r)
		{
			if (Visible)
			{
				GraphicsState gstate = p.Graphics.Save();
				p.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				if (Brush.Visible)
				{
					p.Graphics.FillEllipse(I_Brush.GetBrush(p, r), r);
				}
				if (Pen.Visible)
				{
					p.Graphics.DrawEllipse(I_Pen.GetPen(p), r);
				}
				p.Graphics.Restore(gstate);
			}
		}

		private void DrawPie(PaintArgs p, Rectangle r, double startAngle, double sweepAngle)
		{
			if (Visible)
			{
				GraphicsState gstate = p.Graphics.Save();
				p.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				if (Brush.Visible)
				{
					p.Graphics.FillPie(I_Brush.GetBrush(p, r), r, (float)startAngle, (float)sweepAngle);
				}
				if (Pen.Visible)
				{
					p.Graphics.DrawPie(I_Pen.GetPen(p), r, (float)startAngle, (float)sweepAngle);
				}
				p.Graphics.Restore(gstate);
			}
		}

		protected virtual void Draw(PaintArgs p, Rectangle r)
		{
			if (Visible && r.Height > 0 && r.Width > 0)
			{
				GraphicsState gstate = p.Graphics.Save();
				p.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				if (Brush.Visible)
				{
					p.Graphics.FillRectangle(I_Brush.GetBrush(p, r), r);
				}
				if (Pen.Visible)
				{
					p.Graphics.DrawRectangle(I_Pen.GetPen(p), r);
				}
				p.Graphics.Restore(gstate);
			}
		}

		private void Draw(PaintArgs p, Point[] points)
		{
			if (Visible)
			{
				GraphicsState gstate = p.Graphics.Save();
				p.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				if (Brush.Visible)
				{
					p.Graphics.FillPolygon(I_Brush.GetBrush(p, points), points);
				}
				if (Pen.Visible)
				{
					p.Graphics.DrawPolygon(I_Pen.GetPen(p), points);
				}
				p.Graphics.Restore(gstate);
			}
		}

		private void Draw(PaintArgs p, Point[] points, Rectangle boundRect)
		{
			if (Visible && boundRect.Height > 0 && boundRect.Width > 0)
			{
				GraphicsState gstate = p.Graphics.Save();
				p.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				if (Brush.Visible)
				{
					p.Graphics.FillPolygon(I_Brush.GetBrush(p, boundRect), points);
				}
				if (Pen.Visible)
				{
					p.Graphics.DrawPolygon(I_Pen.GetPen(p), points);
				}
				p.Graphics.Restore(gstate);
			}
		}

		private void DrawBiFill(PaintArgs p, Point[] points, Rectangle boundRect)
		{
			if (Visible && boundRect.Height > 0 && boundRect.Width > 0)
			{
				GraphicsState gstate = p.Graphics.Save();
				p.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				if (Brush.Visible)
				{
					p.Graphics.FillPolygon(I_Brush.GetBrush(p, boundRect), points);
				}
				if (Pen.Visible)
				{
					p.Graphics.DrawLines(I_Pen.GetPen(p), points);
				}
				p.Graphics.Restore(gstate);
			}
		}
	}
}
