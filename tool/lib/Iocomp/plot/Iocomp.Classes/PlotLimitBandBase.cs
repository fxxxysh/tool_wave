using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Limit Band Base.")]
	public abstract class PlotLimitBandBase : PlotLimitBase
	{
		private PlotFill m_Fill;

		protected IPlotFill I_Fill;

		private int m_HitRegionSize;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill Fill
		{
			get
			{
				return m_Fill;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int HitRegionSize
		{
			get
			{
				return m_HitRegionSize;
			}
			set
			{
				base.PropertyUpdateDefault("HitRegionSize", value);
				if (HitRegionSize != value)
				{
					m_HitRegionSize = value;
					base.DoPropertyChange(this, "HitRegionSize");
				}
			}
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Fill = new PlotFill();
			base.AddSubClass(Fill);
			I_Fill = Fill;
			((ISubClassBase)Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
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
			HitRegionSize = 5;
		}

		private bool ShouldSerializeFill()
		{
			return ((ISubClassBase)Fill).ShouldSerialize();
		}

		private void ResetFill()
		{
			((ISubClassBase)Fill).ResetToDefault();
		}

		private bool ShouldSerializeHitRegionSize()
		{
			return base.PropertyShouldSerialize("HitRegionSize");
		}

		private void ResetHitRegionSize()
		{
			base.PropertyReset("HitRegionSize");
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
