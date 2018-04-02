using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Iocomp.Classes
{
	[Description("Contains the properties that control the appearance for the indicator.")]
	public abstract class IndicatorText : Indicator
	{
		private string m_Text;

		private Color m_TextColorActive;

		private Color m_TextColorInactive;

		[Description("Specifies the text displayed on the indicator.")]
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
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Editor("System.Windows.Forms.Design.StringArrayEditor,System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
		public string[] TextLines
		{
			get
			{
				return Text.Split('\n');
			}
			set
			{
				StringBuilder stringBuilder = new StringBuilder(value.Length);
				for (int i = 0; i < value.Length; i++)
				{
					if (i < value.Length - 1)
					{
						stringBuilder.Append(value[i] + "\n");
					}
					else
					{
						stringBuilder.Append(value[i]);
					}
				}
				Text = stringBuilder.ToString();
			}
		}

		[Description("Specifies the color of the text displayed on the indicator when it is active.")]
		[RefreshProperties(RefreshProperties.All)]
		public Color TextColorActive
		{
			get
			{
				return m_TextColorActive;
			}
			set
			{
				base.PropertyUpdateDefault("TextColorActive", value);
				if (TextColorActive != value)
				{
					m_TextColorActive = value;
					base.DoPropertyChange(this, "TextColorActive");
				}
			}
		}

		[Description("Specifies the color of the text displayed on the indicator when it is inactive.")]
		[RefreshProperties(RefreshProperties.All)]
		public Color TextColorInactive
		{
			get
			{
				return m_TextColorInactive;
			}
			set
			{
				base.PropertyUpdateDefault("TextColorInactive", value);
				if (TextColorInactive != value)
				{
					m_TextColorInactive = value;
					base.DoPropertyChange(this, "TextColorInactive");
				}
			}
		}

		private bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetText()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeTextLines()
		{
			return base.PropertyShouldSerialize("TextLines");
		}

		private void ResetTextLines()
		{
			base.PropertyReset("TextLines");
		}

		private bool ShouldSerializeTextColorActive()
		{
			return base.PropertyShouldSerialize("TextColorActive");
		}

		private void ResetTextColorActive()
		{
			base.PropertyReset("TextColorActive");
		}

		private bool ShouldSerializeTextColorInactive()
		{
			return base.PropertyShouldSerialize("TextColorInactive");
		}

		private void ResetTextColorInactive()
		{
			base.PropertyReset("TextColorInactive");
		}
	}
}
