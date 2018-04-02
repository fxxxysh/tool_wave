using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Iocomp.Classes
{
	[Description("Contains the properties to format the text.")]
	public class TextFormatInteger : SubClassBase
	{
		private TextFormatIntegerStyle m_Style;

		private int m_FixedLength;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public TextFormatIntegerStyle Style
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
					base.DoPropertyChange(this, "Style");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int FixedLength
		{
			get
			{
				return m_FixedLength;
			}
			set
			{
				base.PropertyUpdateDefault("FixedLength", value);
				if (FixedLength != value)
				{
					m_FixedLength = value;
					base.DoPropertyChange(this, "FixedLength");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Text Format";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.TextFormatIntegerEditorPlugIn";
		}

		public TextFormatInteger()
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

		private bool ShouldSerializeFixedLength()
		{
			return base.PropertyShouldSerialize("FixedLength");
		}

		private void ResetFixedLength()
		{
			base.PropertyReset("FixedLength");
		}

		public static string ToString(long value, TextFormatIntegerStyle style, int fixedLength, LeadingStyle leadingStyle)
		{
			long value2 = (style != 0) ? value : Math.Abs(value);
			string text;
			switch (style)
			{
			case TextFormatIntegerStyle.Binary:
				text = Convert2.ToString(value2, 2);
				break;
			case TextFormatIntegerStyle.Octal:
				text = Convert2.ToString(value2, 8);
				break;
			case TextFormatIntegerStyle.Integer:
				text = Convert2.ToString(value2, 10);
				break;
			case TextFormatIntegerStyle.Hexadecimal:
				text = Convert2.ToString(value2, 16);
				break;
			default:
				return "Not-Supported";
			}
			text = text.ToUpper(CultureInfo.CurrentCulture);
			if (fixedLength != 0)
			{
				string value3;
				if (value < 0)
				{
					switch (style)
					{
					case TextFormatIntegerStyle.Binary:
						value3 = "1";
						break;
					case TextFormatIntegerStyle.Octal:
						value3 = "7";
						break;
					case TextFormatIntegerStyle.Integer:
						value3 = "0";
						break;
					case TextFormatIntegerStyle.Hexadecimal:
						value3 = "F";
						break;
					default:
						value3 = "0";
						break;
					}
				}
				else
				{
					value3 = ((leadingStyle != LeadingStyle.Zeros) ? " " : "0");
				}
				if (text.Length > fixedLength)
				{
					text = text.Substring(text.Length - fixedLength, fixedLength);
				}
				StringBuilder stringBuilder = new StringBuilder(text);
				for (int i = 0; i < fixedLength - text.Length; i++)
				{
					stringBuilder.Insert(0, value3);
				}
				text = stringBuilder.ToString();
			}
			if (style == TextFormatIntegerStyle.Integer && value < 0)
			{
				text = '-' + text;
			}
			return text;
		}

		public static long ToLong(string s, TextFormatIntegerStyle style)
		{
			if (s.Length == 0)
			{
				return 0L;
			}
			switch (style)
			{
			case TextFormatIntegerStyle.Binary:
				return (int)Convert.ToInt64(s, 2);
			case TextFormatIntegerStyle.Octal:
				return (int)Convert.ToInt64(s, 8);
			case TextFormatIntegerStyle.Integer:
				return (int)Convert.ToInt64(s, 10);
			case TextFormatIntegerStyle.Hexadecimal:
				return (int)Convert.ToInt64(s, 16);
			default:
				return 0L;
			}
		}

		public string GetText(long value)
		{
			return ToString(value, Style, FixedLength, LeadingStyle.Zeros);
		}

		public long GetValue(string s)
		{
			return ToLong(s, Style);
		}
	}
}
