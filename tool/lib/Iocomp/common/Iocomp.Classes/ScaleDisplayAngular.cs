using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Description("Controls the scale display angular layout properties.")]
	public sealed class ScaleDisplayAngular : ScaleDisplay, IScaleDisplayAngular, IScaleDisplay
	{
		private DrawExtent m_DrawExtent;

		private StringAlignmentAngular m_TextAlignment;

		private int m_Radius;

		private int m_Margin;

		private int m_HubRadius;

		private Point m_CenterPoint;

		private int m_MaxRequiredWidth;

		private int m_MaxRequiredHeight;

		int IScaleDisplayAngular.Radius
		{
			get
			{
				return Radius;
			}
			set
			{
				Radius = value;
			}
		}

		int IScaleDisplayAngular.HubRadius
		{
			get
			{
				return HubRadius;
			}
			set
			{
				HubRadius = value;
			}
		}

		Point IScaleDisplayAngular.CenterPoint
		{
			get
			{
				return CenterPoint;
			}
			set
			{
				CenterPoint = value;
			}
		}

		Size IScaleDisplayAngular.RequiredSize
		{
			get
			{
				return new Size(m_MaxRequiredWidth, m_MaxRequiredHeight);
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public StringAlignmentAngular TextAlignment
		{
			get
			{
				return m_TextAlignment;
			}
			set
			{
				base.PropertyUpdateDefault("TextAlignment", value);
				if (TextAlignment != value)
				{
					m_TextAlignment = value;
					base.DoPropertyChange(this, "TextAlignment");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int Margin
		{
			get
			{
				return m_Margin;
			}
			set
			{
				base.PropertyUpdateDefault("Margin", value);
				if (Margin != value)
				{
					m_Margin = value;
					base.DoPropertyChange(this, "Margin");
				}
			}
		}

		private int Radius
		{
			get
			{
				return m_Radius;
			}
			set
			{
				m_Radius = value;
			}
		}

		private int HubRadius
		{
			get
			{
				return m_HubRadius;
			}
			set
			{
				m_HubRadius = value;
			}
		}

		private Point CenterPoint
		{
			get
			{
				return m_CenterPoint;
			}
			set
			{
				m_CenterPoint = value;
			}
		}

		private IScaleRangeAngular I_Range => base.ScaleRange as IScaleRangeAngular;

		public override int PixelsSpan => (int)(6.2831853071795862 * (double)Radius / 360.0 * (base.ScaleRange as IScaleRangeAngular).AngleSpan);

		protected override string GetPlugInTitle()
		{
			return "Scale Display";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleDisplayAngularEditorPlugIn";
		}

		Point IScaleDisplayAngular.GetScalePoint(double value, float radius)
		{
			return GetScalePoint(value, (double)radius);
		}

		public ScaleDisplayAngular()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			m_DrawExtent = new DrawExtent();
			base.CreateObjects();
		}

		private bool ShouldSerializeTextAlignment()
		{
			return base.PropertyShouldSerialize("TextAlignment");
		}

		private void ResetTextAlignment()
		{
			base.PropertyReset("TextAlignment");
		}

		private bool ShouldSerializeMargin()
		{
			return base.PropertyShouldSerialize("Margin");
		}

		private void ResetMargin()
		{
			base.PropertyReset("Margin");
		}

		protected override int GetMaxTicks()
		{
			Size size = base.TickInfo.Painter.Graphics.MeasureString("0", base.TickMajor.Font, true);
			double num = base.TickInfo.MinTextSpacing * (double)size.Height;
			string text = base.TextFormatting.GetText(base.ScaleRange.Min);
			double num2 = (double)base.TickInfo.Painter.Graphics.MeasureString(text, base.TickMajor.Font, true).Height;
			base.TickInfo.LabelMaxWidth = (int)Math.Round(num2 + num);
			int num3 = base.TickInfo.PixelSpanCalculation / base.TickInfo.LabelMaxWidth;
			if (num3 < 1)
			{
				return 1;
			}
			return num3;
		}

		protected override bool GetValueOnScale(double value)
		{
			return Math2.InRangeDelta(value, base.ScaleRange.Min, base.ScaleRange.Max);
		}

		private Point GetScalePoint(double value, double radius)
		{
			double angle = I_Range.ValueToAngle(value);
			return Math2.ToRotatedPoint(angle, radius, CenterPoint);
		}

		private Point GetTickPoint(IScaleTickBase tick, float radius)
		{
			double angle = I_Range.ValueToAngle(tick.Value);
			double num;
			switch ((!(tick is ScaleTickMinor)) ? ((tick is ScaleTickMid) ? (tick as ScaleTickMid).Alignment : AlignmentStyle.Near) : (tick as ScaleTickMinor).Alignment)
			{
			case AlignmentStyle.Center:
				num = (double)((float)(base.TickMajor.Length - tick.Length) / 2f);
				break;
			case AlignmentStyle.Far:
				num = (double)(base.TickMajor.Length - tick.Length);
				break;
			default:
				num = 0.0;
				break;
			}
			return Math2.ToRotatedPoint(angle, (double)(radius + (float)Margin) + num, CenterPoint);
		}

		protected override Point GetTickPoint(IScaleTickBase tick)
		{
			return GetTickPoint(tick, (float)Radius);
		}

		protected override Point[] GetTickLine(IScaleTickBase tick)
		{
			return new Point[2]
			{
				GetTickPoint(tick, (float)Radius),
				GetTickPoint(tick, (float)(Radius + tick.Length))
			};
		}

		private double GetTextAngle(IScaleTickLabel tick)
		{
			if (TextAlignment != StringAlignmentAngular.RadialOuter && TextAlignment != StringAlignmentAngular.RadialInner)
			{
				return 0.0;
			}
			return I_Range.ValueToAngle(tick.Value);
		}

		private Rectangle GetTextRect(PaintArgs p, IScaleTickLabel tick)
		{
			double num = Math2.AngleNormalized(I_Range.ValueToAngle(tick.Value));
			float num2 = (float)tick.TextSize.Width;
			float num3 = (float)tick.TextSize.Height;
			Size size = p.Graphics.MeasureString(base.TickMajor.Font);
			Point point = default(Point);
			Rectangle result = default(Rectangle);
			if (TextAlignment == StringAlignmentAngular.Center)
			{
				float num4 = (float)(Radius + Margin + base.TickMajor.Length + tick.TextMargin + tick.TextMaxSize.Width / 2);
				point = new Point((int)(Math2.Cos(num) * (double)num4 + (double)CenterPoint.X), (int)(Math2.Sin(num) * (double)num4 + (double)CenterPoint.Y));
				result = new Rectangle((int)((float)point.X - num2 / 2f), (int)((float)point.Y - num3 / 2f), (int)num2, (int)num3);
				goto IL_0479;
			}
			if (TextAlignment == StringAlignmentAngular.Justified)
			{
				float num5 = (float)Math.Sqrt((double)(size.Width * size.Width + size.Height * size.Height)) / 2f;
				float num4 = (float)(Radius + base.TickMajor.Length + tick.TextMargin) + num5;
				point = new Point((int)(Math2.Cos(num) * (double)num4 + (double)CenterPoint.X), (int)(Math2.Sin(num) * (double)num4 + (double)CenterPoint.Y));
				result = new Rectangle((int)((float)point.X - num2 / 2f), (int)((float)point.Y - num3 / 2f), (int)num2, (int)num3);
				if (num == 0.0)
				{
					result.Offset((int)(num2 / 2f - (float)(size.Width / 2)), 0);
				}
				else if (num == 180.0)
				{
					result.Offset((int)((0f - num2) / 2f + (float)(size.Width / 2)), 0);
				}
				else if (num > 0.0 && num < 90.0)
				{
					result.Offset((int)(num2 / 2f - (float)(size.Width / 2)), 0);
				}
				else if (num > 90.0 && num < 270.0)
				{
					result.Offset((int)((0f - num2) / 2f + (float)(size.Width / 2)), 0);
				}
				else if (num > 270.0 && num < 360.0)
				{
					result.Offset((int)(num2 / 2f - (float)(size.Width / 2)), 0);
				}
				goto IL_0479;
			}
			Point point2 = default(Point);
			if (TextAlignment == StringAlignmentAngular.RadialOuter)
			{
				float num6 = (float)(Radius + base.TickMajor.Length + tick.TextMargin + tick.TextSize.Width / 2);
				point2 = new Point((int)(Math2.Cos(num) * (double)num6 + (double)CenterPoint.X), (int)(Math2.Sin(num) * (double)num6 + (double)CenterPoint.Y));
				result = new Rectangle(point2.X - tick.TextSize.Width / 2, point2.Y - tick.TextSize.Height / 2, tick.TextSize.Width, tick.TextSize.Height);
				goto IL_0479;
			}
			if (TextAlignment == StringAlignmentAngular.RadialInner)
			{
				float num6 = (float)(Radius - tick.TextMargin - tick.TextMaxSize.Width / 2);
				point2 = new Point((int)(Math2.Cos(num) * (double)num6 + (double)CenterPoint.X), (int)(Math2.Sin(num) * (double)num6 + (double)CenterPoint.Y));
				result = new Rectangle(point2.X - tick.TextMaxSize.Width / 2, point2.Y - tick.TextMaxSize.Height / 2, tick.TextMaxSize.Width, tick.TextMaxSize.Height);
				goto IL_0479;
			}
			result = Rectangle.Empty;
			return result;
			IL_0479:
			return result;
		}

		protected override void DrawTickLine(PaintArgs p, IScaleTickBase tick)
		{
			Point[] tickLine = GetTickLine(tick);
			p.Graphics.DrawLine(p.Graphics.Pen(tick.Color, (float)tick.Thickness), tickLine[0], tickLine[1]);
		}

		protected override void DrawTickLabel(PaintArgs p, IScaleTickLabel tick, DrawStringFormat format)
		{
			if (TextAlignment == StringAlignmentAngular.Center)
			{
				DrawTickLabelHorizontalCenter(p, tick, format);
			}
			else if (TextAlignment == StringAlignmentAngular.Justified)
			{
				DrawTickLabelHorizontalJustified(p, tick, format);
			}
			else if (TextAlignment == StringAlignmentAngular.RadialOuter)
			{
				DrawTickLabelRotatedOuter(p, tick, format);
			}
			else if (TextAlignment == StringAlignmentAngular.RadialInner)
			{
				DrawTickLabelRotatedInner(p, tick, format);
			}
		}

		private void DrawTickLabelRotatedOuter(PaintArgs p, IScaleTickLabel tick, DrawStringFormat format)
		{
			double num = I_Range.ValueToAngle(tick.Value);
			Rectangle textRect = GetTextRect(p, tick);
			Point point = Math2.ToCenterPoint(textRect);
			GraphicsState gstate = p.Graphics.Save();
			p.Graphics.TranslateTransform((float)point.X, (float)point.Y);
			p.Graphics.RotateTransform(180f + (float)num);
			p.Graphics.TranslateTransform((float)(-point.X), (float)(-point.Y));
			p.Graphics.DrawString(tick.Text, tick.Font, p.Graphics.Brush(tick.ForeColor), textRect, format);
			p.Graphics.Restore(gstate);
		}

		private void DrawTickLabelRotatedInner(PaintArgs p, IScaleTickLabel tick, DrawStringFormat format)
		{
			format.Alignment = StringAlignment.Far;
			double num = I_Range.ValueToAngle(tick.Value);
			Rectangle textRect = GetTextRect(p, tick);
			Point point = Math2.ToCenterPoint(textRect);
			GraphicsState gstate = p.Graphics.Save();
			p.Graphics.TranslateTransform((float)point.X, (float)point.Y);
			p.Graphics.RotateTransform(180f + (float)num);
			p.Graphics.TranslateTransform((float)(-point.X), (float)(-point.Y));
			p.Graphics.DrawString(tick.Text, tick.Font, p.Graphics.Brush(tick.ForeColor), textRect, format);
			p.Graphics.Restore(gstate);
		}

		private void DrawTickLabelHorizontalJustified(PaintArgs p, IScaleTickLabel tick, DrawStringFormat format)
		{
			p.Graphics.DrawString(tick.Text, tick.Font, p.Graphics.Brush(tick.ForeColor), GetTextRect(p, tick), format);
		}

		private void DrawTickLabelHorizontalCenter(PaintArgs p, IScaleTickLabel tick, DrawStringFormat format)
		{
			p.Graphics.DrawString(tick.Text, tick.Font, p.Graphics.Brush(tick.ForeColor), GetTextRect(p, tick), format);
		}

		protected override void DrawInternal(PaintArgs p, DrawStringFormat stringFormat)
		{
			foreach (IScaleTickBase tick in base.TickList)
			{
				if ((Range as ScaleRangeAngular).AngleSpan == 360.0)
				{
					if (base.TickList[base.TickList.Count - 1] != tick)
					{
						tick.Draw(p, stringFormat, base.TickMajor.Length);
					}
				}
				else
				{
					tick.Draw(p, stringFormat, base.TickMajor.Length);
				}
			}
			float num = (float)I_Range.ValueToAngle(base.ScaleRange.Min);
			float num2 = (float)I_Range.ValueToAngle(base.ScaleRange.Max);
			Rectangle rect = default(Rectangle);
			if (base.LineInnerVisible)
			{
				int num3 = Radius + Margin;
				rect = new Rectangle(CenterPoint.X - num3, CenterPoint.Y - num3, 2 * num3, 2 * num3);
				p.Graphics.DrawArc(p.Graphics.Pen(base.TickMajor.Color, (float)base.LineThickness), rect, num, num2 - num);
			}
			if (base.LineOuterVisible)
			{
				int num3 = Radius + Margin + base.TickMajor.Length;
				rect = new Rectangle(CenterPoint.X - num3, CenterPoint.Y - num3, 2 * num3, 2 * num3);
				p.Graphics.DrawArc(p.Graphics.Pen(base.TickMajor.Color, (float)base.LineThickness), rect, num, num2 - num);
			}
		}

		protected override void UpdateScaleExtents(PaintArgs p)
		{
			Rectangle drawRectangle = p.DrawRectangle;
			Rectangle value = new Rectangle(CenterPoint.X - HubRadius, CenterPoint.Y - HubRadius, 2 * HubRadius, 2 * HubRadius);
			m_DrawExtent.Reset();
			m_DrawExtent.Add(CenterPoint);
			m_DrawExtent.Add(value);
			for (int i = 0; i < base.TickList.Count; i++)
			{
				Point[] tickLine = GetTickLine(base.TickList[i] as IScaleTickBase);
				m_DrawExtent.Add(tickLine[0], tickLine[1]);
				if (base.TickList[i] is IScaleTickLabel)
				{
					IScaleTickLabel scaleTickLabel = base.TickList[i] as IScaleTickLabel;
					if (scaleTickLabel.TextVisible)
					{
						Rectangle textRect = GetTextRect(p, scaleTickLabel);
						double textAngle = GetTextAngle(scaleTickLabel);
						Point[] array = Math2.ToRotatedPoints(textAngle, textRect);
						for (int j = 0; j < array.Length; j++)
						{
							m_DrawExtent.Add(array[j]);
						}
					}
				}
			}
			m_MaxRequiredWidth = m_DrawExtent.MaxWidth + 4;
			m_MaxRequiredHeight = m_DrawExtent.MaxHeight + 4;
			CenterPoint = m_DrawExtent.GetNewCenterPoint(CenterPoint, drawRectangle);
		}

		protected override void ScaleInitializeTickInfo()
		{
		}
	}
}
