using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Controls the border layout properties.")]
	public class BorderControl : SubClassBase, IBorderControl
	{
		private BorderStyleControl m_Style;

		private int m_Margin;

		private int m_ThicknessDesired;

		private Color m_Color;

		[Browsable(false)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Offset
		{
			get
			{
				return Margin + ThicknessActual;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Represents the actual thickness of the border.\n\nNote: If the style is None, 0 is returned. If the style is Raised or Sunken, ThicknessDesired is returned          All remaining styles will return 2.")]
		public int ThicknessActual
		{
			get
			{
				if (m_Style == BorderStyleControl.None)
				{
					return 0;
				}
				if (m_Style == BorderStyleControl.Raised)
				{
					return m_ThicknessDesired;
				}
				if (m_Style == BorderStyleControl.Sunken)
				{
					return m_ThicknessDesired;
				}
				if (m_Style == BorderStyleControl.RoundedSides)
				{
					return m_ThicknessDesired;
				}
				return 2;
			}
		}

		[Description("Specifies the border style.")]
		[RefreshProperties(RefreshProperties.All)]
		public BorderStyleControl Style
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
					int thicknessActual = ThicknessActual;
					m_Style = value;
					base.DoAutoSizeSpecialOffset(ThicknessActual - thicknessActual);
					base.DoPropertyChange(this, "Style");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the border's desired thickness.")]
		public int ThicknessDesired
		{
			get
			{
				return m_ThicknessDesired;
			}
			set
			{
				base.PropertyUpdateDefault("ThicknessDesired", value);
				if (value < 2)
				{
					base.ThrowStreamingSafeException("ThicknessDesired value must be 2 or greater.");
				}
				if (value < 2)
				{
					value = 2;
				}
				if (ThicknessDesired != value)
				{
					int thicknessActual = ThicknessActual;
					m_ThicknessDesired = value;
					base.DoAutoSizeSpecialOffset(ThicknessActual - thicknessActual);
					base.DoPropertyChange(this, "ThicknessDesired");
				}
			}
		}

		[Description("Specifies the size of the border margin in pixels around the control.")]
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
				if (value < 0)
				{
					base.ThrowStreamingSafeException("Margin value must be 0 or greater.");
				}
				if (value < 0)
				{
					value = 0;
				}
				if (Margin != value)
				{
					int margin = m_Margin;
					m_Margin = value;
					base.DoAutoSizeSpecialOffset(m_Margin - margin);
					base.DoPropertyChange(this, "Margin");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the color of the border.")]
		public new Color Color
		{
			get
			{
				if (base.GettingDefault)
				{
					return m_Color;
				}
				if (m_Color == Color.Empty && ControlBase != null && ControlBase._Parent != null)
				{
					return ControlBase._Parent.BackColor;
				}
				return m_Color;
			}
			set
			{
				base.PropertyUpdateDefault("Color", value);
				if (Color != value)
				{
					m_Color = value;
					base.DoPropertyChange(this, "Color");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Border";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.BorderControlEditorPlugIn";
		}

		void IBorderControl.Draw(PaintArgs p, Rectangle r)
		{
			Draw(p, r);
		}

		void IBorderControl.Draw(PaintArgs p, Rectangle r, BorderStyleControl style, int thicknessDesired, Color color)
		{
			Draw(p, r, style, thicknessDesired, color);
		}

		public BorderControl()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private bool ShouldSerializeThicknessDesired()
		{
			return base.PropertyShouldSerialize("ThicknessDesired");
		}

		private void ResetThicknessDesired()
		{
			base.PropertyReset("ThicknessDesired");
		}

		private bool ShouldSerializeMargin()
		{
			return base.PropertyShouldSerialize("Margin");
		}

		private void ResetMargin()
		{
			base.PropertyReset("Margin");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		protected void Draw(PaintArgs p, Rectangle r)
		{
			Draw(p, r, Style, ThicknessDesired, Color);
		}

		protected void Draw(PaintArgs p, Rectangle r, BorderStyleControl style, int thickness, Color color)
		{
			switch (style)
			{
			case BorderStyleControl.None:
				return;
			case BorderStyleControl.RoundedSides:
				BorderSpecial.DrawRoundedSides(p, r, BevelStyle.Raised, thickness, color);
				return;
			case BorderStyleControl.Raised:
				if (thickness <= 2)
				{
					break;
				}
				BorderSpecial.DrawRectangle(p, r, BevelStyle.Raised, thickness, color);
				return;
			}
			if (style == BorderStyleControl.Sunken && thickness > 2)
			{
				BorderSpecial.DrawRectangle(p, r, BevelStyle.Sunken, thickness, color);
			}
			else
			{
				switch (style)
				{
				case BorderStyleControl.Raised:
					BorderSimple.Draw(p, r, BorderStyleSimple.Raised, color);
					break;
				case BorderStyleControl.Sunken:
					BorderSimple.Draw(p, r, BorderStyleSimple.Sunken, color);
					break;
				case BorderStyleControl.Bump:
					BorderSimple.Draw(p, r, BorderStyleSimple.Bump, color);
					break;
				case BorderStyleControl.Etched:
					BorderSimple.Draw(p, r, BorderStyleSimple.Etched, color);
					break;
				case BorderStyleControl.Flat:
					BorderSimple.Draw(p, r, BorderStyleSimple.Flat, color);
					break;
				case BorderStyleControl.RaisedInner:
					BorderSimple.Draw(p, r, BorderStyleSimple.RaisedInner, color);
					break;
				case BorderStyleControl.RaisedOuter:
					BorderSimple.Draw(p, r, BorderStyleSimple.RaisedOuter, color);
					break;
				case BorderStyleControl.SunkenInner:
					BorderSimple.Draw(p, r, BorderStyleSimple.SunkenInner, color);
					break;
				case BorderStyleControl.SunkenOuter:
					BorderSimple.Draw(p, r, BorderStyleSimple.SunkenOuter, color);
					break;
				}
			}
		}
	}
}
