using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public class AnnotationText : AnnotationBase
	{
		private string m_Text;

		private bool m_FixedSize;

		private Font m_DrawFont;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
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

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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
		[Category("Iocomp")]
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

		protected override string GetPlugInTitle()
		{
			return "Annotation Text";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AnnotationTextEditorPlugIn";
		}

		public AnnotationText()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
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

		protected override void DrawCustom(PaintArgs p)
		{
			int num = Scale.ConvertHeightUnitsToPixels(Height);
			int height = Font.Height;
			float num2 = FixedSize ? Font.Size : ((float)num / (float)height * Font.Size);
			if (!(num2 <= 0f))
			{
				Font font;
				if (Font.Size != num2)
				{
					if (m_DrawFont == null || m_DrawFont.Size != num2)
					{
						m_DrawFont = new Font(Font.Name, num2, Font.Style);
					}
					font = m_DrawFont;
				}
				else
				{
					font = Font;
				}
				Size size = p.Graphics.MeasureString(Text, font, false);
				Rectangle r = new Rectangle(Scale.ConvertUnitsToPixelsX(X) - size.Width / 2, Scale.ConvertUnitsToPixelsY(Y) - size.Height / 2, size.Width + 1, size.Height + 1);
				base.ClickRegion = ToClickRegion(r);
				base.UpdateGrabHandles(r);
				if (Text.Length != 0)
				{
					p.Graphics.DrawString(Text, font, p.Graphics.Brush(ForeColor), r);
				}
			}
		}

		public override string ToString()
		{
			return "Annotation Text";
		}
	}
}
