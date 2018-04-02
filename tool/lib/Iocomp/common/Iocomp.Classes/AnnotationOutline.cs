using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Serializable]
	public abstract class AnnotationOutline : AnnotationBase
	{
		private Color m_OutlineColor;

		private AnnotationOutlineStyle m_OutlineStyle;

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public Color OutlineColor
		{
			get
			{
				return m_OutlineColor;
			}
			set
			{
				base.PropertyUpdateDefault("OutlineColor", value);
				if (OutlineColor != value)
				{
					m_OutlineColor = value;
					base.DoPropertyChange(this, "OutlineColor");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public AnnotationOutlineStyle OutlineStyle
		{
			get
			{
				return m_OutlineStyle;
			}
			set
			{
				base.PropertyUpdateDefault("OutlineStyle", value);
				if (OutlineStyle != value)
				{
					m_OutlineStyle = value;
					base.DoPropertyChange(this, "OutlineStyle");
				}
			}
		}

		protected DashStyle DashStyle
		{
			get
			{
				if (OutlineStyle == AnnotationOutlineStyle.Solid)
				{
					return DashStyle.Solid;
				}
				if (OutlineStyle == AnnotationOutlineStyle.Dash)
				{
					return DashStyle.Dash;
				}
				if (OutlineStyle == AnnotationOutlineStyle.DashDot)
				{
					return DashStyle.DashDot;
				}
				if (OutlineStyle == AnnotationOutlineStyle.DashDotDot)
				{
					return DashStyle.DashDotDot;
				}
				if (OutlineStyle == AnnotationOutlineStyle.Dot)
				{
					return DashStyle.Dot;
				}
				return DashStyle.Solid;
			}
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			OutlineColor = Color.Black;
			OutlineStyle = AnnotationOutlineStyle.Solid;
		}

		private bool ShouldSerializeOutlineColor()
		{
			return base.PropertyShouldSerialize("OutlineColor");
		}

		private void ResetOutlineColor()
		{
			base.PropertyReset("OutlineColor");
		}

		private bool ShouldSerializeOutlineStyle()
		{
			return base.PropertyShouldSerialize("OutlineStyle");
		}

		private void ResetOutlineStyle()
		{
			base.PropertyReset("OutlineStyle");
		}

		protected abstract void DrawOutline(PaintArgs p, Rectangle r, Point[] points);

		protected override void DrawCustom(PaintArgs p)
		{
			Rectangle r = new Rectangle(Scale.ConvertUnitsToPixelsX(base.Left), Scale.ConvertUnitsToPixelsY(base.Top), Scale.ConvertWidthUnitsToPixels(Width), Scale.ConvertHeightUnitsToPixels(Height));
			base.ClickRegion = ToClickRegion(r);
			base.UpdateGrabHandles(r);
			if (r.Height != 0 && r.Width != 0 && OutlineStyle != AnnotationOutlineStyle.Clear)
			{
				DrawOutline(p, r, null);
			}
		}
	}
}
