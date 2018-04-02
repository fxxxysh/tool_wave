using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public abstract class PlotAnnotationFillBase : PlotAnnotationBase
	{
		private PlotFill m_Fill;

		protected IPlotFill I_Fill;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotFill Fill
		{
			get
			{
				return m_Fill;
			}
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Fill = new PlotFill();
			base.AddSubClass(Fill);
			I_Fill = Fill;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Fill.Visible = true;
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
		}

		private bool ShouldSerializeFill()
		{
			return ((ISubClassBase)Fill).ShouldSerialize();
		}

		private void ResetFill()
		{
			((ISubClassBase)Fill).ResetToDefault();
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (!Fill.Visible)
			{
				base.CanDraw = false;
			}
			if (!Fill.Brush.Visible && !Fill.Pen.Visible)
			{
				base.CanDraw = false;
			}
		}
	}
}
