using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public class PlotAnnotationText : PlotAnnotationBase
	{
		private string m_Text;

		private bool m_FixedSize;

		private Font m_DrawFont;

		private TextLayoutFull m_TextLayout;

		private ITextLayoutFull I_TextLayout;

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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TextLayoutFull TextLayout
		{
			get
			{
				return m_TextLayout;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Annotation Text";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotAnnotationTextEditorPlugIn";
		}

		public PlotAnnotationText()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_TextLayout = new TextLayoutFull();
			base.AddSubClass(TextLayout);
			I_TextLayout = TextLayout;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Text";
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
			Text = "Text";
			FixedSize = false;
			TextLayout.Trimming = StringTrimming.None;
			TextLayout.LineLimit = false;
			TextLayout.MeasureTrailingSpaces = false;
			TextLayout.NoWrap = false;
			TextLayout.NoClip = false;
			TextLayout.AlignmentHorizontal.Style = StringAlignment.Center;
			TextLayout.AlignmentHorizontal.Margin = 0.0;
			TextLayout.AlignmentVertical.Style = StringAlignment.Center;
			TextLayout.AlignmentVertical.Margin = 0.0;
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

		private bool ShouldSerializeTextLayout()
		{
			return ((ISubClassBase)TextLayout).ShouldSerialize();
		}

		private void ResetTextLayout()
		{
			((ISubClassBase)TextLayout).ResetToDefault();
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
				Point pt = base.XYSwapped ? new Point(base.YPixels, base.XPixels) : new Point(base.XPixels, base.YPixels);
				Rectangle rectangle = I_TextLayout.GetRectangle(Text, pt, font, p.Graphics);
				if (!base.BoundsClip.IntersectsWith(rectangle))
				{
					base.ClickRegion = null;
				}
				else
				{
					DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
					genericTypographic.Alignment = TextLayout.AlignmentHorizontal.Style;
					genericTypographic.LineAlignment = TextLayout.AlignmentVertical.Style;
					p.Graphics.DrawString(Text, font, p.Graphics.Brush(ForeColor), rectangle, genericTypographic);
					base.ClickRegion = ToClickRegion(rectangle);
					base.UpdateGrabHandles(rectangle);
				}
			}
		}
	}
}
