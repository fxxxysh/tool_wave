using System;
using System.Drawing;

namespace Iocomp.Classes
{
	public class iRectangle
	{
		private int m_Left;

		private int m_Top;

		private int m_Width;

		private int m_Height;

		public int Left
		{
			get
			{
				return m_Left;
			}
			set
			{
				m_Left = value;
			}
		}

		public int Top
		{
			get
			{
				return m_Top;
			}
			set
			{
				m_Top = value;
			}
		}

		public int Width
		{
			get
			{
				return m_Width;
			}
			set
			{
				m_Width = value;
			}
		}

		public int Height
		{
			get
			{
				return m_Height;
			}
			set
			{
				m_Height = value;
			}
		}

		public int WidthHalf => m_Width / 2;

		public int HeightHalf => m_Height / 2;

		public int Right
		{
			get
			{
				return m_Left + m_Width;
			}
			set
			{
				m_Width = value - m_Left;
			}
		}

		public int Bottom
		{
			get
			{
				return m_Top + m_Height;
			}
			set
			{
				m_Height = value - m_Top;
			}
		}

		public Point TopLeft => new Point(Left, Top);

		public Point BottomLeft => new Point(Left, Bottom);

		public Point TopRight => new Point(Right, Top);

		public Point BottomRight => new Point(Right, Bottom);

		public Point CenterPoint => new Point(m_Left + m_Width / 2, m_Top + m_Height / 2);

		public int CenterX => m_Left + m_Width / 2;

		public int CenterY => m_Top + m_Height / 2;

		public Size Size
		{
			get
			{
				return new Size(m_Width, m_Height);
			}
			set
			{
				m_Width = value.Width;
				m_Height = value.Height;
			}
		}

		public Rectangle Rectangle
		{
			get
			{
				return new Rectangle(m_Left, m_Top, m_Width, m_Height);
			}
			set
			{
				m_Left = value.Left;
				m_Top = value.Top;
				m_Width = value.Width;
				m_Height = value.Height;
			}
		}

		public Rectangle PenRectangle => new Rectangle(m_Left, m_Top, m_Width - 1, m_Height - 1);

		public iRectangle()
		{
		}

		public iRectangle(Rectangle r)
		{
			m_Left = r.Left;
			m_Top = r.Top;
			m_Width = r.Width;
			m_Height = r.Height;
		}

		public iRectangle(int left, int top, int width, int height)
		{
			m_Left = left;
			m_Top = top;
			m_Width = width;
			m_Height = height;
		}

		public void Offset(int x, int y)
		{
			m_Left += x;
			m_Top += y;
		}

		public void OffsetX(int x)
		{
			m_Left += x;
		}

		public void OffsetY(int y)
		{
			m_Top += y;
		}

		public void Inflate(int x, int y)
		{
			m_Left -= x;
			m_Width += 2 * x;
			m_Top -= y;
			m_Height += 2 * y;
		}

		public void InflateX(int x)
		{
			m_Left -= x;
			m_Width += 2 * x;
		}

		public void InflateY(int y)
		{
			m_Top -= y;
			m_Height += 2 * y;
		}

		public void MoveLeft(int x)
		{
			m_Left += x;
			m_Width -= x;
		}

		public void MoveRight(int x)
		{
			m_Width += x;
		}

		public void MoveTop(int y)
		{
			m_Top += y;
			m_Height -= y;
		}

		public void MoveBottom(int y)
		{
			m_Height += y;
		}

		public static Rectangle FromLTWH(int left, int top, int width, int height)
		{
			return new Rectangle(left, top, width, height);
		}

		public static Rectangle FromLTWH(bool swap, int left, int top, int width, int height)
		{
			if (swap)
			{
				int num = left;
				left = top;
				top = num;
				num = width;
				width = height;
				height = num;
			}
			return FromLTWH(left, top, width, height);
		}

		public static Rectangle FromLTRB(int left, int top, int right, int bottom)
		{
			if (left > right)
			{
				int num = left;
				left = right;
				right = num;
			}
			if (top > bottom)
			{
				int num = top;
				top = bottom;
				bottom = num;
			}
			return Rectangle.FromLTRB(left, top, right, bottom);
		}

		public static Rectangle FromLTRB(bool swap, int left, int top, int right, int bottom)
		{
			if (swap)
			{
				int num = left;
				left = top;
				top = num;
				num = right;
				right = bottom;
				bottom = num;
			}
			return FromLTRB(left, top, right, bottom);
		}

		public static Rectangle FromLTRB(bool swap, double left, double top, double right, double bottom)
		{
			if (swap)
			{
				double num = left;
				left = top;
				top = num;
				num = right;
				right = bottom;
				bottom = num;
			}
			return FromLTRB((int)left, (int)top, (int)right, (int)bottom);
		}

		public static Rectangle FromLTRB(double left, double top, double right, double bottom)
		{
			if (left > right)
			{
				double num = left;
				left = right;
				right = num;
			}
			if (top > bottom)
			{
				double num = top;
				top = bottom;
				bottom = num;
			}
			return Rectangle.FromLTRB((int)Math.Round(left), (int)Math.Round(top), (int)Math.Round(right), (int)Math.Round(bottom));
		}

		public static Rectangle ToPenRectangle(Rectangle r)
		{
			return new Rectangle(r.Left, r.Top, r.Width - 1, r.Height - 1);
		}

		public static Point CenterPoint2(Rectangle r)
		{
			return new Point((r.Left + r.Right) / 2, (r.Top + r.Bottom) / 2);
		}

		public static int Radius(Rectangle r)
		{
			return (r.Right - r.Left) / 2;
		}
	}
}
