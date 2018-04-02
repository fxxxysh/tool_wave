using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	public abstract class ScaleTickLabel : ScaleTickBase, IScaleTickLabel, IScaleTickBase
	{
		private string m_Text;

		private bool m_TextVisible;

		private int m_TextMargin;

		private Size m_TextSize;

		private Size m_TextMaxSize;

		private Size m_TextAlignmentSize;

		private StackingDimension m_StackingDimension;

		Size IScaleTickLabel.TextSize
		{
			get
			{
				return TextSize;
			}
			set
			{
				TextSize = value;
			}
		}

		Size IScaleTickLabel.TextMaxSize
		{
			get
			{
				return TextMaxSize;
			}
			set
			{
				TextMaxSize = value;
			}
		}

		Size IScaleTickLabel.TextAlignmentSize
		{
			get
			{
				return TextAlignmentSize;
			}
			set
			{
				TextAlignmentSize = value;
			}
		}

		StackingDimension IScaleTickLabel.StackingDimension
		{
			get
			{
				return StackingDimension;
			}
			set
			{
				StackingDimension = value;
			}
		}

		protected Size TextSize
		{
			get
			{
				if (!TextVisible)
				{
					return Size.Empty;
				}
				return m_TextSize;
			}
			set
			{
				m_TextSize = value;
			}
		}

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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
		public bool TextVisible
		{
			get
			{
				return m_TextVisible;
			}
			set
			{
				base.PropertyUpdateDefault("TextVisible", value);
				if (TextVisible != value)
				{
					m_TextVisible = value;
					base.DoPropertyChange(this, "TextVisible");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int TextMargin
		{
			get
			{
				return m_TextMargin;
			}
			set
			{
				base.PropertyUpdateDefault("TextMargin", value);
				if (TextMargin != value)
				{
					m_TextMargin = value;
					base.DoPropertyChange(this, "TextMargin");
				}
			}
		}

		protected Size TextMaxSize
		{
			get
			{
				return m_TextMaxSize;
			}
			set
			{
				m_TextMaxSize = value;
			}
		}

		protected Size TextAlignmentSize
		{
			get
			{
				return m_TextAlignmentSize;
			}
			set
			{
				m_TextAlignmentSize = value;
			}
		}

		protected StackingDimension StackingDimension
		{
			get
			{
				return m_StackingDimension;
			}
			set
			{
				m_StackingDimension = value;
			}
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

		private bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetText()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeTextVisible()
		{
			return base.PropertyShouldSerialize("TextVisible");
		}

		private void ResetTextVisible()
		{
			base.PropertyReset("TextVisible");
		}

		private bool ShouldSerializeTextMargin()
		{
			return base.PropertyShouldSerialize("TextMargin");
		}

		private void ResetTextMargin()
		{
			base.PropertyReset("TextMargin");
		}

		protected override int GetScaleWidth()
		{
			int num = base.Length;
			if (TextVisible)
			{
				num += TextMargin;
				num = ((StackingDimension != 0) ? (num + TextAlignmentSize.Height) : (num + TextAlignmentSize.Width));
			}
			return num;
		}

		protected override void Draw(PaintArgs p, DrawStringFormat format, int majorLength)
		{
			if (base.Value <= base.Display.Range.Max && base.Value >= base.Display.Range.Min)
			{
				base.Display.DrawTickLine(p, this);
			}
			if (TextVisible && Font != null)
			{
				base.Display.DrawTickLabel(p, this, format);
			}
		}
	}
}
