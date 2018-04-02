using System.Drawing;

namespace Iocomp.Classes
{
	public sealed class ScaleDrawSegments
	{
		private Rectangle m_Rectangle;

		private int m_Size;

		private int m_Spacing;

		public Rectangle Rectangle
		{
			get
			{
				return m_Rectangle;
			}
			set
			{
				m_Rectangle = value;
			}
		}

		public int Size
		{
			get
			{
				return m_Size;
			}
			set
			{
				m_Size = value;
			}
		}

		public int Spacing
		{
			get
			{
				return m_Spacing;
			}
			set
			{
				m_Spacing = value;
			}
		}

		public int SpanPixels => Rectangle.Height;

		public void OffsetEnds(int value)
		{
			Rectangle.Inflate(0, -value);
		}

		public void SetStartRectangle(iRectangle r, int width, int height, bool reverse)
		{
			if (!reverse)
			{
				r.Rectangle = new Rectangle(r.Left, r.Bottom - height, width, height);
			}
			else
			{
				r.Rectangle = new Rectangle(r.Left, r.Top, width, height);
			}
		}

		public void ShiftRectangle(iRectangle r, int shift, bool reverse)
		{
			if (!reverse)
			{
				r.OffsetY(-shift);
			}
			else
			{
				r.OffsetY(shift);
			}
		}
	}
}
