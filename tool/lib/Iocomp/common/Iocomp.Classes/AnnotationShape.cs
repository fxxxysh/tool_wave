using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Serializable]
	public abstract class AnnotationShape : AnnotationOutline
	{
		private Color m_GradientStartColor;

		private Color m_GradientStopColor;

		private Color m_HatchBackColor;

		private Color m_HatchForeColor;

		private Color m_FillColor;

		private AnnotationFillStyle m_FillStyle;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public Color GradientStartColor
		{
			get
			{
				return m_GradientStartColor;
			}
			set
			{
				base.PropertyUpdateDefault("GradientStartColor", value);
				if (GradientStartColor != value)
				{
					m_GradientStartColor = value;
					base.DoPropertyChange(this, "GradientStartColor");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Category("Iocomp")]
		public Color GradientStopColor
		{
			get
			{
				return m_GradientStopColor;
			}
			set
			{
				base.PropertyUpdateDefault("GradientStopColor", value);
				if (GradientStopColor != value)
				{
					m_GradientStopColor = value;
					base.DoPropertyChange(this, "GradientStopColor");
				}
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public Color HatchBackColor
		{
			get
			{
				return m_HatchBackColor;
			}
			set
			{
				base.PropertyUpdateDefault("HatchBackColor", value);
				if (HatchBackColor != value)
				{
					m_HatchBackColor = value;
					base.DoPropertyChange(this, "HatchBackColor");
				}
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color HatchForeColor
		{
			get
			{
				return m_HatchForeColor;
			}
			set
			{
				base.PropertyUpdateDefault("HatchForeColor", value);
				if (HatchForeColor != value)
				{
					m_HatchForeColor = value;
					base.DoPropertyChange(this, "HatchForeColor");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public Color FillColor
		{
			get
			{
				return m_FillColor;
			}
			set
			{
				base.PropertyUpdateDefault("FillColor", value);
				if (FillColor != value)
				{
					m_FillColor = value;
					base.DoPropertyChange(this, "FillColor");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Category("Iocomp")]
		public AnnotationFillStyle FillStyle
		{
			get
			{
				return m_FillStyle;
			}
			set
			{
				base.PropertyUpdateDefault("FillStyle", value);
				if (FillStyle != value)
				{
					m_FillStyle = value;
					base.DoPropertyChange(this, "FillStyle");
				}
			}
		}

		protected float ModeAngle
		{
			get
			{
				if (FillStyle == AnnotationFillStyle.GradientHorizontal)
				{
					return 0f;
				}
				if (FillStyle == AnnotationFillStyle.GradientForwardDiagonal)
				{
					return 45f;
				}
				if (FillStyle == AnnotationFillStyle.GradientVertical)
				{
					return 90f;
				}
				return 135f;
			}
		}

		protected HatchStyle HatchStyle
		{
			get
			{
				if (FillStyle == AnnotationFillStyle.HatchBackwardDiagonal)
				{
					return HatchStyle.BackwardDiagonal;
				}
				if (FillStyle == AnnotationFillStyle.HatchCross)
				{
					return HatchStyle.Cross;
				}
				if (FillStyle == AnnotationFillStyle.HatchDarkDownwardDiagonal)
				{
					return HatchStyle.DarkDownwardDiagonal;
				}
				if (FillStyle == AnnotationFillStyle.HatchDarkHorizontal)
				{
					return HatchStyle.DarkHorizontal;
				}
				if (FillStyle == AnnotationFillStyle.HatchDarkUpwardDiagonal)
				{
					return HatchStyle.DarkUpwardDiagonal;
				}
				if (FillStyle == AnnotationFillStyle.HatchDarkVertical)
				{
					return HatchStyle.DarkVertical;
				}
				if (FillStyle == AnnotationFillStyle.HatchDashedDownwardDiagonal)
				{
					return HatchStyle.DashedDownwardDiagonal;
				}
				if (FillStyle == AnnotationFillStyle.HatchDashedHorizontal)
				{
					return HatchStyle.DashedHorizontal;
				}
				if (FillStyle == AnnotationFillStyle.HatchDashedUpwardDiagonal)
				{
					return HatchStyle.DashedUpwardDiagonal;
				}
				if (FillStyle == AnnotationFillStyle.HatchDashedVertical)
				{
					return HatchStyle.DashedVertical;
				}
				if (FillStyle == AnnotationFillStyle.HatchDiagonalBrick)
				{
					return HatchStyle.DiagonalBrick;
				}
				if (FillStyle == AnnotationFillStyle.HatchDiagonalCross)
				{
					return HatchStyle.DiagonalCross;
				}
				if (FillStyle == AnnotationFillStyle.HatchDivot)
				{
					return HatchStyle.Divot;
				}
				if (FillStyle == AnnotationFillStyle.HatchDottedDiamond)
				{
					return HatchStyle.DottedDiamond;
				}
				if (FillStyle == AnnotationFillStyle.HatchDottedGrid)
				{
					return HatchStyle.DottedGrid;
				}
				if (FillStyle == AnnotationFillStyle.HatchForwardDiagonal)
				{
					return HatchStyle.ForwardDiagonal;
				}
				if (FillStyle == AnnotationFillStyle.HatchHorizontal)
				{
					return HatchStyle.Horizontal;
				}
				if (FillStyle == AnnotationFillStyle.HatchHorizontalBrick)
				{
					return HatchStyle.HorizontalBrick;
				}
				if (FillStyle == AnnotationFillStyle.HatchLargeCheckerBoard)
				{
					return HatchStyle.LargeCheckerBoard;
				}
				if (FillStyle == AnnotationFillStyle.HatchLargeConfetti)
				{
					return HatchStyle.LargeConfetti;
				}
				if (FillStyle == AnnotationFillStyle.HatchLargeGrid)
				{
					return HatchStyle.Cross;
				}
				if (FillStyle == AnnotationFillStyle.HatchLightDownwardDiagonal)
				{
					return HatchStyle.LightDownwardDiagonal;
				}
				if (FillStyle == AnnotationFillStyle.HatchLightHorizontal)
				{
					return HatchStyle.LightHorizontal;
				}
				if (FillStyle == AnnotationFillStyle.HatchLightUpwardDiagonal)
				{
					return HatchStyle.LightUpwardDiagonal;
				}
				if (FillStyle == AnnotationFillStyle.HatchLightVertical)
				{
					return HatchStyle.LightVertical;
				}
				if (FillStyle == AnnotationFillStyle.HatchMax)
				{
					return HatchStyle.Cross;
				}
				if (FillStyle == AnnotationFillStyle.HatchMin)
				{
					return HatchStyle.Horizontal;
				}
				if (FillStyle == AnnotationFillStyle.HatchNarrowHorizontal)
				{
					return HatchStyle.NarrowHorizontal;
				}
				if (FillStyle == AnnotationFillStyle.HatchNarrowVertical)
				{
					return HatchStyle.NarrowVertical;
				}
				if (FillStyle == AnnotationFillStyle.HatchOutlinedDiamond)
				{
					return HatchStyle.OutlinedDiamond;
				}
				if (FillStyle == AnnotationFillStyle.HatchPercent05)
				{
					return HatchStyle.Percent05;
				}
				if (FillStyle == AnnotationFillStyle.HatchPercent10)
				{
					return HatchStyle.Percent10;
				}
				if (FillStyle == AnnotationFillStyle.HatchPercent20)
				{
					return HatchStyle.Percent20;
				}
				if (FillStyle == AnnotationFillStyle.HatchPercent25)
				{
					return HatchStyle.Percent25;
				}
				if (FillStyle == AnnotationFillStyle.HatchPercent30)
				{
					return HatchStyle.Percent30;
				}
				if (FillStyle == AnnotationFillStyle.HatchPercent40)
				{
					return HatchStyle.Percent40;
				}
				if (FillStyle == AnnotationFillStyle.HatchPercent50)
				{
					return HatchStyle.Percent50;
				}
				if (FillStyle == AnnotationFillStyle.HatchPercent60)
				{
					return HatchStyle.Percent60;
				}
				if (FillStyle == AnnotationFillStyle.HatchPercent70)
				{
					return HatchStyle.Percent70;
				}
				if (FillStyle == AnnotationFillStyle.HatchPercent75)
				{
					return HatchStyle.Percent75;
				}
				if (FillStyle == AnnotationFillStyle.HatchPercent80)
				{
					return HatchStyle.Percent80;
				}
				if (FillStyle == AnnotationFillStyle.HatchPercent90)
				{
					return HatchStyle.Percent90;
				}
				if (FillStyle == AnnotationFillStyle.HatchPlaid)
				{
					return HatchStyle.Plaid;
				}
				if (FillStyle == AnnotationFillStyle.HatchShingle)
				{
					return HatchStyle.Shingle;
				}
				if (FillStyle == AnnotationFillStyle.HatchSmallCheckerBoard)
				{
					return HatchStyle.SmallCheckerBoard;
				}
				if (FillStyle == AnnotationFillStyle.HatchSmallConfetti)
				{
					return HatchStyle.SmallConfetti;
				}
				if (FillStyle == AnnotationFillStyle.HatchSmallGrid)
				{
					return HatchStyle.SmallGrid;
				}
				if (FillStyle == AnnotationFillStyle.HatchSolidDiamond)
				{
					return HatchStyle.SolidDiamond;
				}
				if (FillStyle == AnnotationFillStyle.HatchSphere)
				{
					return HatchStyle.Sphere;
				}
				if (FillStyle == AnnotationFillStyle.HatchTrellis)
				{
					return HatchStyle.Trellis;
				}
				if (FillStyle == AnnotationFillStyle.HatchVertical)
				{
					return HatchStyle.Vertical;
				}
				if (FillStyle == AnnotationFillStyle.HatchWave)
				{
					return HatchStyle.Wave;
				}
				if (FillStyle == AnnotationFillStyle.HatchWeave)
				{
					return HatchStyle.Weave;
				}
				if (FillStyle == AnnotationFillStyle.HatchWideDownwardDiagonal)
				{
					return HatchStyle.WideDownwardDiagonal;
				}
				if (FillStyle == AnnotationFillStyle.HatchWideUpwardDiagonal)
				{
					return HatchStyle.WideUpwardDiagonal;
				}
				return HatchStyle.ZigZag;
			}
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			GradientStartColor = Color.Black;
			GradientStopColor = Color.Black;
			HatchBackColor = Color.White;
			HatchForeColor = Color.Black;
			FillColor = Color.Yellow;
			FillStyle = AnnotationFillStyle.Solid;
		}

		private bool ShouldSerializeGradientStartColor()
		{
			return base.PropertyShouldSerialize("GradientStartColor");
		}

		private void ResetGradientStartColor()
		{
			base.PropertyReset("GradientStartColor");
		}

		private bool ShouldSerializeGradientStopColor()
		{
			return base.PropertyShouldSerialize("GradientStopColor");
		}

		private void ResetGradientStopColor()
		{
			base.PropertyReset("GradientStopColor");
		}

		private bool ShouldSerializeHatchBackColor()
		{
			return base.PropertyShouldSerialize("HatchBackColor");
		}

		private void ResetHatchBackColor()
		{
			base.PropertyReset("HatchBackColor");
		}

		private bool ShouldSerializeHatchForeColor()
		{
			return base.PropertyShouldSerialize("HatchForeColor");
		}

		private void ResetHatchForeColor()
		{
			base.PropertyReset("HatchForeColor");
		}

		private bool ShouldSerializeFillColor()
		{
			return base.PropertyShouldSerialize("FillColor");
		}

		private void ResetFillColor()
		{
			base.PropertyReset("FillColor");
		}

		private bool ShouldSerializeFillStyle()
		{
			return base.PropertyShouldSerialize("FillStyle");
		}

		private void ResetFillStyle()
		{
			base.PropertyReset("FillStyle");
		}

		protected void DrawFill(PaintArgs p, Rectangle r, Point[] points)
		{
			if (FillStyle == AnnotationFillStyle.Solid)
			{
				DrawFillSolid(p, r, points);
			}
			else if (FillStyle == AnnotationFillStyle.Clear)
			{
				DrawFillSolid(p, r, points);
			}
			else if (FillStyle == AnnotationFillStyle.GradientBackwardDiagonal)
			{
				DrawFillGradient(p, r, points);
			}
			else if (FillStyle == AnnotationFillStyle.GradientForwardDiagonal)
			{
				DrawFillGradient(p, r, points);
			}
			else if (FillStyle == AnnotationFillStyle.GradientHorizontal)
			{
				DrawFillGradient(p, r, points);
			}
			else if (FillStyle == AnnotationFillStyle.GradientVertical)
			{
				DrawFillGradient(p, r, points);
			}
			else
			{
				DrawFillHatch(p, r, points);
			}
		}

		protected abstract void DrawFillSolid(PaintArgs p, Rectangle r, Point[] points);

		protected abstract void DrawFillGradient(PaintArgs p, Rectangle r, Point[] points);

		protected abstract void DrawFillHatch(PaintArgs p, Rectangle r, Point[] points);

		protected override void DrawCustom(PaintArgs p)
		{
			Rectangle rectangle = new Rectangle(Scale.ConvertUnitsToPixelsX(base.Left), Scale.ConvertUnitsToPixelsY(base.Top), Scale.ConvertWidthUnitsToPixels(Width), Scale.ConvertHeightUnitsToPixels(Height));
			base.ClickRegion = new Region(rectangle);
			base.UpdateGrabHandles(rectangle);
			if (rectangle.Height != 0 && rectangle.Width != 0)
			{
				if (FillStyle != AnnotationFillStyle.Clear)
				{
					DrawFill(p, rectangle, null);
				}
				rectangle = new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width - 1, rectangle.Height - 1);
				if (rectangle.Height != 0 && rectangle.Width != 0 && base.OutlineStyle != AnnotationOutlineStyle.Clear)
				{
					DrawOutline(p, rectangle, null);
				}
			}
		}
	}
}
