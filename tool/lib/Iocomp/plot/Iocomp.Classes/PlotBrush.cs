using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Description("Plot Brush.")]
	public class PlotBrush : SubClassBase, IPlotBrush
	{
		private Color m_GradientStartColor;

		private Color m_GradientStopColor;

		private PlotBrushStyle m_Style;

		private HatchStyle m_StyleGDI;

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
		public Color SolidColor
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.PropertyUpdateDefault("SolidColor", value);
				base.Color = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public Color HatchBackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.PropertyUpdateDefault("HatchBackColor", value);
				base.BackColor = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color HatchForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.PropertyUpdateDefault("HatchForeColor", value);
				base.ForeColor = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotBrushStyle Style
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
					if (m_Style == PlotBrushStyle.HatchBackwardDiagonal)
					{
						m_StyleGDI = HatchStyle.BackwardDiagonal;
					}
					else if (m_Style == PlotBrushStyle.HatchCross)
					{
						m_StyleGDI = HatchStyle.Cross;
					}
					else if (m_Style == PlotBrushStyle.HatchDarkDownwardDiagonal)
					{
						m_StyleGDI = HatchStyle.DarkDownwardDiagonal;
					}
					else if (m_Style == PlotBrushStyle.HatchDarkHorizontal)
					{
						m_StyleGDI = HatchStyle.DarkHorizontal;
					}
					else if (m_Style == PlotBrushStyle.HatchDarkUpwardDiagonal)
					{
						m_StyleGDI = HatchStyle.DarkUpwardDiagonal;
					}
					else if (m_Style == PlotBrushStyle.HatchDarkVertical)
					{
						m_StyleGDI = HatchStyle.DarkVertical;
					}
					else if (m_Style == PlotBrushStyle.HatchDashedDownwardDiagonal)
					{
						m_StyleGDI = HatchStyle.DashedDownwardDiagonal;
					}
					else if (m_Style == PlotBrushStyle.HatchDashedHorizontal)
					{
						m_StyleGDI = HatchStyle.DashedHorizontal;
					}
					else if (m_Style == PlotBrushStyle.HatchDashedUpwardDiagonal)
					{
						m_StyleGDI = HatchStyle.DashedUpwardDiagonal;
					}
					else if (m_Style == PlotBrushStyle.HatchDashedVertical)
					{
						m_StyleGDI = HatchStyle.DashedVertical;
					}
					else if (m_Style == PlotBrushStyle.HatchDiagonalBrick)
					{
						m_StyleGDI = HatchStyle.DiagonalBrick;
					}
					else if (m_Style == PlotBrushStyle.HatchDiagonalCross)
					{
						m_StyleGDI = HatchStyle.DiagonalCross;
					}
					else if (m_Style == PlotBrushStyle.HatchDivot)
					{
						m_StyleGDI = HatchStyle.Divot;
					}
					else if (m_Style == PlotBrushStyle.HatchDottedDiamond)
					{
						m_StyleGDI = HatchStyle.DottedDiamond;
					}
					else if (m_Style == PlotBrushStyle.HatchDottedGrid)
					{
						m_StyleGDI = HatchStyle.DottedGrid;
					}
					else if (m_Style == PlotBrushStyle.HatchForwardDiagonal)
					{
						m_StyleGDI = HatchStyle.ForwardDiagonal;
					}
					else if (m_Style == PlotBrushStyle.HatchHorizontal)
					{
						m_StyleGDI = HatchStyle.Horizontal;
					}
					else if (m_Style == PlotBrushStyle.HatchHorizontalBrick)
					{
						m_StyleGDI = HatchStyle.HorizontalBrick;
					}
					else if (m_Style == PlotBrushStyle.HatchLargeCheckerBoard)
					{
						m_StyleGDI = HatchStyle.LargeCheckerBoard;
					}
					else if (m_Style == PlotBrushStyle.HatchLargeConfetti)
					{
						m_StyleGDI = HatchStyle.LargeConfetti;
					}
					else if (m_Style == PlotBrushStyle.HatchLargeGrid)
					{
						m_StyleGDI = HatchStyle.Cross;
					}
					else if (m_Style == PlotBrushStyle.HatchLightDownwardDiagonal)
					{
						m_StyleGDI = HatchStyle.LightDownwardDiagonal;
					}
					else if (m_Style == PlotBrushStyle.HatchLightHorizontal)
					{
						m_StyleGDI = HatchStyle.LightHorizontal;
					}
					else if (m_Style == PlotBrushStyle.HatchLightUpwardDiagonal)
					{
						m_StyleGDI = HatchStyle.LightUpwardDiagonal;
					}
					else if (m_Style == PlotBrushStyle.HatchLightVertical)
					{
						m_StyleGDI = HatchStyle.LightVertical;
					}
					else if (m_Style == PlotBrushStyle.HatchMax)
					{
						m_StyleGDI = HatchStyle.Cross;
					}
					else if (m_Style == PlotBrushStyle.HatchMin)
					{
						m_StyleGDI = HatchStyle.Horizontal;
					}
					else if (m_Style == PlotBrushStyle.HatchNarrowHorizontal)
					{
						m_StyleGDI = HatchStyle.NarrowHorizontal;
					}
					else if (m_Style == PlotBrushStyle.HatchNarrowVertical)
					{
						m_StyleGDI = HatchStyle.NarrowVertical;
					}
					else if (m_Style == PlotBrushStyle.HatchOutlinedDiamond)
					{
						m_StyleGDI = HatchStyle.OutlinedDiamond;
					}
					else if (m_Style == PlotBrushStyle.HatchPercent05)
					{
						m_StyleGDI = HatchStyle.Percent05;
					}
					else if (m_Style == PlotBrushStyle.HatchPercent10)
					{
						m_StyleGDI = HatchStyle.Percent10;
					}
					else if (m_Style == PlotBrushStyle.HatchPercent20)
					{
						m_StyleGDI = HatchStyle.Percent20;
					}
					else if (m_Style == PlotBrushStyle.HatchPercent25)
					{
						m_StyleGDI = HatchStyle.Percent25;
					}
					else if (m_Style == PlotBrushStyle.HatchPercent30)
					{
						m_StyleGDI = HatchStyle.Percent30;
					}
					else if (m_Style == PlotBrushStyle.HatchPercent40)
					{
						m_StyleGDI = HatchStyle.Percent40;
					}
					else if (m_Style == PlotBrushStyle.HatchPercent50)
					{
						m_StyleGDI = HatchStyle.Percent50;
					}
					else if (m_Style == PlotBrushStyle.HatchPercent60)
					{
						m_StyleGDI = HatchStyle.Percent60;
					}
					else if (m_Style == PlotBrushStyle.HatchPercent70)
					{
						m_StyleGDI = HatchStyle.Percent70;
					}
					else if (m_Style == PlotBrushStyle.HatchPercent75)
					{
						m_StyleGDI = HatchStyle.Percent75;
					}
					else if (m_Style == PlotBrushStyle.HatchPercent80)
					{
						m_StyleGDI = HatchStyle.Percent80;
					}
					else if (m_Style == PlotBrushStyle.HatchPercent90)
					{
						m_StyleGDI = HatchStyle.Percent90;
					}
					else if (m_Style == PlotBrushStyle.HatchPlaid)
					{
						m_StyleGDI = HatchStyle.Plaid;
					}
					else if (m_Style == PlotBrushStyle.HatchShingle)
					{
						m_StyleGDI = HatchStyle.Shingle;
					}
					else if (m_Style == PlotBrushStyle.HatchSmallCheckerBoard)
					{
						m_StyleGDI = HatchStyle.SmallCheckerBoard;
					}
					else if (m_Style == PlotBrushStyle.HatchSmallConfetti)
					{
						m_StyleGDI = HatchStyle.SmallConfetti;
					}
					else if (m_Style == PlotBrushStyle.HatchSmallGrid)
					{
						m_StyleGDI = HatchStyle.SmallGrid;
					}
					else if (m_Style == PlotBrushStyle.HatchSolidDiamond)
					{
						m_StyleGDI = HatchStyle.SolidDiamond;
					}
					else if (m_Style == PlotBrushStyle.HatchSphere)
					{
						m_StyleGDI = HatchStyle.Sphere;
					}
					else if (m_Style == PlotBrushStyle.HatchTrellis)
					{
						m_StyleGDI = HatchStyle.Trellis;
					}
					else if (m_Style == PlotBrushStyle.HatchVertical)
					{
						m_StyleGDI = HatchStyle.Vertical;
					}
					else if (m_Style == PlotBrushStyle.HatchWave)
					{
						m_StyleGDI = HatchStyle.Wave;
					}
					else if (m_Style == PlotBrushStyle.HatchWeave)
					{
						m_StyleGDI = HatchStyle.Weave;
					}
					else if (m_Style == PlotBrushStyle.HatchWideDownwardDiagonal)
					{
						m_StyleGDI = HatchStyle.WideDownwardDiagonal;
					}
					else if (m_Style == PlotBrushStyle.HatchWideUpwardDiagonal)
					{
						m_StyleGDI = HatchStyle.WideUpwardDiagonal;
					}
					else
					{
						m_StyleGDI = HatchStyle.ZigZag;
					}
					base.DoPropertyChange(this, "Style");
				}
			}
		}

		private HatchStyle StyleGDI => m_StyleGDI;

		private float ModeAngle
		{
			get
			{
				if (Style == PlotBrushStyle.GradientHorizontal)
				{
					return 0f;
				}
				if (Style == PlotBrushStyle.GradientForwardDiagonal)
				{
					return 45f;
				}
				if (Style == PlotBrushStyle.GradientVertical)
				{
					return 90f;
				}
				return 135f;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Plot Brush";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotBrushEditorPlugIn";
		}

		Brush IPlotBrush.GetBrush(PaintArgs p, Rectangle rectangle)
		{
			return GetBrush(p, rectangle);
		}

		Brush IPlotBrush.GetBrush(PaintArgs p, Point[] points)
		{
			return GetBrush(p, points);
		}

		public PlotBrush()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.ColorAmbientSource = AmbientColorSouce.BackColor;
			Visible = true;
			Style = PlotBrushStyle.Solid;
			SolidColor = Color.Empty;
			GradientStartColor = Color.Blue;
			GradientStopColor = Color.Aqua;
			HatchBackColor = Color.Empty;
			HatchForeColor = Color.Empty;
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeSolidColor()
		{
			return base.PropertyShouldSerialize("SolidColor");
		}

		private void ResetSolidColor()
		{
			base.PropertyReset("SolidColor");
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

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private Brush GetBrush(PaintArgs p, Rectangle rectangle)
		{
			if (Style == PlotBrushStyle.Solid)
			{
				return p.Graphics.Brush(SolidColor);
			}
			if (Style == PlotBrushStyle.GradientBackwardDiagonal && rectangle.IsEmpty)
			{
				return null;
			}
			if (Style == PlotBrushStyle.GradientForwardDiagonal && rectangle.IsEmpty)
			{
				return null;
			}
			if (Style == PlotBrushStyle.GradientHorizontal && rectangle.IsEmpty)
			{
				return null;
			}
			if (Style == PlotBrushStyle.GradientVertical && rectangle.IsEmpty)
			{
				return null;
			}
			if (Style == PlotBrushStyle.GradientVertical && rectangle.Width <= 0)
			{
				return null;
			}
			if (Style == PlotBrushStyle.GradientVertical && rectangle.Height <= 0)
			{
				return null;
			}
			if (Style == PlotBrushStyle.GradientBackwardDiagonal)
			{
				return new LinearGradientBrush(rectangle, GradientStartColor, GradientStopColor, ModeAngle);
			}
			if (Style == PlotBrushStyle.GradientForwardDiagonal)
			{
				return new LinearGradientBrush(rectangle, GradientStartColor, GradientStopColor, ModeAngle);
			}
			if (Style == PlotBrushStyle.GradientHorizontal)
			{
				return new LinearGradientBrush(rectangle, GradientStartColor, GradientStopColor, ModeAngle);
			}
			if (Style == PlotBrushStyle.GradientVertical)
			{
				return new LinearGradientBrush(rectangle, GradientStartColor, GradientStopColor, ModeAngle);
			}
			return p.Graphics.Brush(StyleGDI, HatchForeColor, HatchBackColor);
		}

		private Brush GetBrush(PaintArgs p, Point[] points)
		{
			int num = 2147483647;
			int num2 = 2147483647;
			int num3 = -2147483648;
			int num4 = -2147483648;
			for (int i = 0; i < points.Length; i++)
			{
				num = Math.Min(num, points[i].X);
				num2 = Math.Min(num2, points[i].Y);
				num3 = Math.Max(num3, points[i].X);
				num4 = Math.Max(num4, points[i].Y);
			}
			return GetBrush(p, Rectangle.FromLTRB(num, num2, num3, num4));
		}
	}
}
