using System.Drawing;

namespace Iocomp.Classes
{
	public class DrawExtent
	{
		private int m_MinX;

		private int m_MinY;

		private int m_MaxX;

		private int m_MaxY;

		private bool m_IsResetX;

		private bool m_IsResetY;

		public int MaxWidth
		{
			get
			{
				if (m_IsResetX)
				{
					return 0;
				}
				return m_MaxX - m_MinX;
			}
		}

		public int MaxHeight
		{
			get
			{
				if (m_IsResetY)
				{
					return 0;
				}
				return m_MaxY - m_MinY;
			}
		}

		public Rectangle Rectangle => Rectangle.FromLTRB(m_MinX, m_MinY, m_MaxX, m_MaxY);

		public DrawExtent()
		{
			Reset();
		}

		public void Reset()
		{
			m_IsResetX = true;
			m_IsResetY = true;
		}

		public void AddX(int value)
		{
			if (m_IsResetX)
			{
				m_MinX = value;
				m_MaxX = value;
				m_IsResetX = false;
			}
			if (value < m_MinX)
			{
				m_MinX = value;
			}
			if (value > m_MaxX)
			{
				m_MaxX = value;
			}
		}

		public void AddY(int value)
		{
			if (m_IsResetY)
			{
				m_MinY = value;
				m_MaxY = value;
				m_IsResetY = false;
			}
			if (value < m_MinY)
			{
				m_MinY = value;
			}
			if (value > m_MaxY)
			{
				m_MaxY = value;
			}
		}

		public void Add(Rectangle value)
		{
			AddX(value.Left);
			AddX(value.Right);
			AddY(value.Top);
			AddY(value.Bottom);
		}

		public void Add(Point value)
		{
			AddX(value.X);
			AddY(value.Y);
		}

		public void Add(Point point1, Point point2)
		{
			AddX(point1.X);
			AddY(point1.Y);
			AddX(point2.X);
			AddY(point2.Y);
		}

		public void Add(Point[] value)
		{
			for (int i = 0; i < value.Length; i++)
			{
				AddX(value[i].X);
				AddY(value[i].Y);
			}
		}

		public Point GetNewCenterPoint(Point centerPoint, Rectangle r)
		{
			int num = m_MinX - r.Left;
			int num2 = r.Right - m_MaxX;
			int num3 = m_MinY - r.Top;
			int num4 = r.Bottom - m_MaxY;
			int num5 = (num2 - num) / 2;
			int num6 = (num4 - num3) / 2;
			return new Point(centerPoint.X + num5, centerPoint.Y + num6);
		}
	}
}
