using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Controls the scale display layout properties.")]
	public sealed class ScaleDisplayDiscreetAngular : ScaleDisplayDiscreet, IScaleDisplayDiscreetAngular, IScaleDisplayDiscreet
	{
		private StringAlignmentDiscreetAngular m_TextAlignment;

		private int m_CallOutLength;

		private ScaleRangeDiscreetAngular m_ScaleRange;

		ScaleRangeDiscreetAngular IScaleDisplayDiscreetAngular.ScaleRange
		{
			get
			{
				return ScaleRange;
			}
			set
			{
				ScaleRange = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public StringAlignmentDiscreetAngular TextAlignment
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int CallOutLength
		{
			get
			{
				return m_CallOutLength;
			}
			set
			{
				base.PropertyUpdateDefault("CallOutLength", value);
				if (CallOutLength != value)
				{
					m_CallOutLength = value;
					base.DoPropertyChange(this, "CallOutLength");
				}
			}
		}

		private ScaleRangeDiscreetAngular ScaleRange
		{
			get
			{
				return m_ScaleRange;
			}
			set
			{
				m_ScaleRange = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Scale Display";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleDisplayDiscreetAngularEditorPlugIn";
		}

		public ScaleDisplayDiscreetAngular()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeTextAlignment()
		{
			return base.PropertyShouldSerialize("TextAlignment");
		}

		private void ResetTextAlignment()
		{
			base.PropertyReset("TextAlignment");
		}

		private bool ShouldSerializeCallOutLength()
		{
			return base.PropertyShouldSerialize("CallOutLength");
		}

		private void ResetCallOutLength()
		{
			base.PropertyReset("CallOutLength");
		}

		private void CalculateLabelCenter(ScaleDiscreetItem item, Size textSize, double angle, int radius, Point centerPoint)
		{
			int num = radius + base.TextMargin + (int)Math.Abs(Math2.Cos(angle) * (double)textSize.Width / 2.0) + (int)Math.Abs(Math2.Sin(angle) * (double)textSize.Height / 2.0);
			Point point = Math2.ToRotatedPoint(angle, (double)num, centerPoint);
			item.TextRectangle = new Rectangle(point.X - textSize.Width / 2, point.Y - textSize.Height / 2, textSize.Width + 1, textSize.Height + 1);
		}

		private void CalculateLabelCallout(ScaleDiscreetItem item, Size textSize, double angle, int radius, Point centerPoint)
		{
			int num = radius + base.TextMargin;
			item.LinePoint1 = Math2.ToRotatedPoint(angle, (double)num, centerPoint);
			if (angle == 0.0)
			{
				num += (int)(1.414 * (double)CallOutLength);
				item.LinePoint2 = Math2.ToRotatedPoint(angle, (double)num, centerPoint);
				item.TextRectangle = Math2.TextRectangleAngular(textSize, item.LinePoint2, base.TextMargin, angle);
			}
			else if (angle == 180.0)
			{
				num += (int)(1.414 * (double)CallOutLength);
				item.LinePoint2 = Math2.ToRotatedPoint(angle, (double)num, centerPoint);
				item.TextRectangle = Math2.TextRectangleAngular(textSize, item.LinePoint2, base.TextMargin, angle);
			}
			else if (angle == 90.0)
			{
				num += (int)(1.414 * (double)CallOutLength);
				item.LinePoint2 = Math2.ToRotatedPoint(angle, (double)num, centerPoint);
				item.TextRectangle = Math2.TextRectangleAngular(textSize, item.LinePoint2, base.TextMargin, angle);
			}
			else if (angle == 270.0)
			{
				num += (int)(1.414 * (double)CallOutLength);
				item.LinePoint2 = Math2.ToRotatedPoint(angle, (double)num, centerPoint);
				item.TextRectangle = Math2.TextRectangleAngular(textSize, item.LinePoint2, base.TextMargin, angle);
			}
			else if (angle > 90.0 && angle < 270.0)
			{
				num += CallOutLength;
				item.LinePoint2 = Math2.ToRotatedPoint(angle, (double)num, centerPoint);
				item.LinePoint3 = Math2.ToRotatedPoint(180.0, (double)CallOutLength, item.LinePoint2);
				item.TextRectangle = Math2.TextRectangleAngular(textSize, item.LinePoint3, base.TextMargin, angle);
			}
			else
			{
				num += CallOutLength;
				item.LinePoint2 = Math2.ToRotatedPoint(angle, (double)num, centerPoint);
				item.LinePoint3 = Math2.ToRotatedPoint(0.0, (double)CallOutLength, item.LinePoint2);
				item.TextRectangle = Math2.TextRectangleAngular(textSize, item.LinePoint3, base.TextMargin, angle);
			}
		}

		private void CalculateLabelJustified(ScaleDiscreetItem item, Size textSize, double angle, int radius, Point centerPoint)
		{
			int num = radius + base.TextMargin;
			Point point = Math2.ToRotatedPoint(angle, (double)num, centerPoint);
			item.TextRectangle = Math2.TextRectangleAngular(textSize, point, base.TextMargin, angle);
		}

		protected override void Calculate(PaintArgs p, ScaleDiscreetItemCollection items, Point centerPoint, int activeIndex, int pointerExtent)
		{
			if (base.Visible)
			{
				DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
				genericTypographic.LineAlignment = StringAlignment.Near;
				genericTypographic.Alignment = StringAlignment.Near;
				for (int i = 0; i < items.Count; i++)
				{
					Font font = (i != activeIndex) ? base.TextInactiveFont : base.TextActiveFont;
					Size textSize = p.Graphics.MeasureString(items[i].Text, font, true);
					double angle = ScaleRange.ValueToAngle(i, items.Count);
					int num = pointerExtent + base.Margin;
					if (base.Markers.Style != MarkerStyleLabel.None)
					{
						items[i].MarkerPoint = Math2.ToRotatedPoint(angle, (double)(num + base.Markers.Size), centerPoint);
						num += 2 * base.Markers.Size;
					}
					items[i].LinePoint1 = Point.Empty;
					items[i].LinePoint2 = Point.Empty;
					items[i].LinePoint3 = Point.Empty;
					if (TextAlignment == StringAlignmentDiscreetAngular.Center)
					{
						CalculateLabelCenter(items[i], textSize, angle, num, centerPoint);
					}
					else if (TextAlignment == StringAlignmentDiscreetAngular.CallOut)
					{
						CalculateLabelCallout(items[i], textSize, angle, num, centerPoint);
					}
					else if (TextAlignment == StringAlignmentDiscreetAngular.Justified)
					{
						CalculateLabelJustified(items[i], textSize, angle, num, centerPoint);
					}
				}
			}
		}

		protected override void Draw(PaintArgs p, ScaleDiscreetItemCollection items, Point centerPoint, int activeIndex, Color backColor)
		{
			if (base.Visible)
			{
				DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
				genericTypographic.LineAlignment = StringAlignment.Near;
				genericTypographic.Alignment = StringAlignment.Near;
				genericTypographic.FormatFlags |= StringFormatFlags.NoClip;
				for (int i = 0; i < items.Count; i++)
				{
					Font font;
					Color color;
					if (i == activeIndex)
					{
						font = base.TextActiveFont;
						color = base.TextActiveForeColor;
					}
					else
					{
						font = base.TextInactiveFont;
						color = base.TextInactiveForeColor;
					}
					if (base.Markers.Style != MarkerStyleLabel.None)
					{
						((IScaleDiscreetMarker)base.Markers).Draw(p, items[i].MarkerPoint, backColor);
					}
					if (!items[i].LinePoint1.IsEmpty && !items[i].LinePoint2.IsEmpty)
					{
						p.Graphics.DrawLine(p.Graphics.Pen(Color.Black), items[i].LinePoint1, items[i].LinePoint2);
					}
					if (!items[i].LinePoint2.IsEmpty && !items[i].LinePoint3.IsEmpty)
					{
						p.Graphics.DrawLine(p.Graphics.Pen(Color.Black), items[i].LinePoint2, items[i].LinePoint3);
					}
					p.Graphics.DrawString(items[i].Text, font, p.Graphics.Brush(color), items[i].TextRectangle, genericTypographic);
				}
			}
		}
	}
}
