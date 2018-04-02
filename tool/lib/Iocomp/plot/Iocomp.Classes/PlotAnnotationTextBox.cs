using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public class PlotAnnotationTextBox : PlotAnnotationFillBase
	{
		private string m_Text;

		private bool m_FixedSize;

		private double m_OuterMargin;

		private Font m_DrawFont;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public new Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool FixedSize
		{
			get
			{
				return m_FixedSize;
			}
			set
			{
				base.PropertyUpdateDefault("FixedSize", value);
				if (FixedSize != value)
				{
					m_FixedSize = value;
					base.DoPropertyChange(this, "FixedSize");
				}
				if (m_FixedSize)
				{
					base.GrabHandle1.Enabled = false;
					base.GrabHandle5.Enabled = false;
				}
				else
				{
					base.GrabHandle1.Enabled = true;
					base.GrabHandle5.Enabled = true;
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string Text
		{
			get
			{
				return m_Text;
			}
			set
			{
				base.PropertyUpdateDefault("Text", value);
				if (Text != value)
				{
					m_Text = value;
					base.DoPropertyChange(this, "Text");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double OuterMargin
		{
			get
			{
				return m_OuterMargin;
			}
			set
			{
				base.PropertyUpdateDefault("OuterMargin", value);
				if (OuterMargin != value)
				{
					m_OuterMargin = value;
					base.DoPropertyChange(this, "OuterMargin");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Annotation TextBox";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotAnnotationTextBoxEditorPlugIn";
		}

		public PlotAnnotationTextBox()
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
			base.NameShort = "TextBox";
			base.GrabHandle0.Enabled = true;
			base.GrabHandle1.Enabled = true;
			base.GrabHandle2.Enabled = true;
			base.GrabHandle3.Enabled = true;
			base.GrabHandle4.Enabled = true;
			base.GrabHandle5.Enabled = true;
			base.GrabHandle6.Enabled = true;
			base.GrabHandle7.Enabled = true;
			ForeColor = Color.Empty;
			Font = null;
			Text = "TextBox";
			FixedSize = false;
			OuterMargin = 0.5;
		}

		private bool ShouldSerializeFont()
		{
			return base.PropertyShouldSerialize("Font");
		}

		private void ResetFont()
		{
			base.PropertyReset("Font");
		}

		private bool ShouldSerializeForeColor()
		{
			return base.PropertyShouldSerialize("ForeColor");
		}

		private void ResetForeColor()
		{
			base.PropertyReset("ForeColor");
		}

		private bool ShouldSerializeFixedSize()
		{
			return base.PropertyShouldSerialize("FixedSize");
		}

		private void ResetFixedSize()
		{
			base.PropertyReset("FixedSize");
		}

		private bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetText()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeOuterMargin()
		{
			return base.PropertyShouldSerialize("OuterMargin");
		}

		private void ResetOuterMargin()
		{
			base.PropertyReset("OuterMargin");
		}

		protected override void DrawCustom(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			float num7;
			if (!FixedSize)
			{
				float num;
				float num2;
				if (!base.XYSwapped)
				{
					num = (float)base.WidthPixels;
					num2 = (float)base.HeightPixels;
				}
				else
				{
					num = (float)base.HeightPixels;
					num2 = (float)base.WidthPixels;
				}
				float num3 = (float)p.Graphics.MeasureString(Text, Font).Width;
				float num4 = (float)Font.Height;
				float num5 = num / num3;
				float num6 = num2 / num4;
				num7 = ((!(num6 < num5)) ? (num / num3 * Font.Size) : (num2 / num4 * Font.Size));
			}
			else
			{
				num7 = Font.Size;
			}
			if (!(num7 <= 0f))
			{
				Font font;
				if (Font.Size != num7)
				{
					if (m_DrawFont == null || m_DrawFont.Size != num7)
					{
						m_DrawFont = new Font(Font.Name, num7, Font.Style);
					}
					font = m_DrawFont;
				}
				else
				{
					font = Font;
				}
				Point point = base.XYSwapped ? new Point(base.YPixels, base.XPixels) : new Point(base.XPixels, base.YPixels);
				Size size = p.Graphics.MeasureString(Text, font, true);
				Rectangle rectangle = new Rectangle(point.X - size.Width / 2, point.Y - size.Height / 2, size.Width, size.Height);
				int num8 = (int)Math.Round((double)p.Graphics.MeasureString("0", font, true).Width * OuterMargin);
				Rectangle rectangle2 = rectangle;
				rectangle2.Inflate(num8, num8);
				if (!base.BoundsClip.IntersectsWith(rectangle2))
				{
					base.ClickRegion = null;
				}
				else
				{
					base.I_Fill.Draw(p, rectangle2);
					DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
					genericTypographic.Alignment = StringAlignment.Center;
					genericTypographic.LineAlignment = StringAlignment.Center;
					p.Graphics.DrawString(Text, font, p.Graphics.Brush(ForeColor), rectangle, genericTypographic);
					base.ClickRegion = ToClickRegion(rectangle2);
					base.UpdateGrabHandles(rectangle2);
				}
			}
		}
	}
}
