using System.Drawing;

namespace Iocomp.Classes
{
	public sealed class DrawStringFormat
	{
		private StringTrimming m_Trimming;

		private StringAlignment m_LineAlignment;

		private StringAlignment m_Alignment;

		private StringFormatFlags m_FormatFlags;

		private bool m_Typographic;

		public StringFormat StringFormat
		{
			get
			{
				StringFormat stringFormat = (!Typographic) ? new StringFormat(StringFormat.GenericDefault) : new StringFormat(StringFormat.GenericTypographic);
				stringFormat.FormatFlags = FormatFlags;
				stringFormat.Alignment = Alignment;
				stringFormat.LineAlignment = LineAlignment;
				stringFormat.Trimming = Trimming;
				return stringFormat;
			}
		}

		public static DrawStringFormat GenericDefault
		{
			get
			{
				DrawStringFormat drawStringFormat = new DrawStringFormat();
				drawStringFormat.Typographic = false;
				return drawStringFormat;
			}
		}

		public static DrawStringFormat GenericTypographic
		{
			get
			{
				DrawStringFormat drawStringFormat = new DrawStringFormat();
				drawStringFormat.Typographic = true;
				return drawStringFormat;
			}
		}

		public StringTrimming Trimming
		{
			get
			{
				return m_Trimming;
			}
			set
			{
				m_Trimming = value;
			}
		}

		public StringAlignment LineAlignment
		{
			get
			{
				return m_LineAlignment;
			}
			set
			{
				m_LineAlignment = value;
			}
		}

		public StringAlignment Alignment
		{
			get
			{
				return m_Alignment;
			}
			set
			{
				m_Alignment = value;
			}
		}

		public StringFormatFlags FormatFlags
		{
			get
			{
				return m_FormatFlags;
			}
			set
			{
				m_FormatFlags = value;
			}
		}

		public bool Typographic
		{
			get
			{
				return m_Typographic;
			}
			set
			{
				m_Typographic = value;
			}
		}
	}
}
