using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Limit Line Base.")]
	public abstract class PlotLimitLineBase : PlotLimitBase
	{
		private PlotPen m_Line;

		private IPlotPen I_Line;

		private int m_HitRegionSize;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotPen Line
		{
			get
			{
				return m_Line;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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
			m_Line = new PlotPen();
			base.AddSubClass(Line);
			I_Line = Line;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Line.Color = Color.Empty;
			Line.Thickness = 1.0;
			Line.Style = PlotPenStyle.Solid;
			Line.Visible = true;
			HitRegionSize = 5;
			((ISubClassBase)Line).ColorAmbientSource = AmbientColorSouce.Color;
		}

		private bool ShouldSerializeLine()
		{
			return ((ISubClassBase)Line).ShouldSerialize();
		}

		private void ResetLine()
		{
			((ISubClassBase)Line).ResetToDefault();
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
			if (!Line.Visible)
			{
				base.CanDraw = false;
			}
		}
	}
}
