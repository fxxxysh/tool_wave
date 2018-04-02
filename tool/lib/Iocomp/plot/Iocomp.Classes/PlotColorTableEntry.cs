using System.Drawing;

namespace Iocomp.Classes
{
	public class PlotColorTableEntry
	{
		private Color m_Color;

		private int m_Count;

		public Color Color
		{
			get
			{
				return m_Color;
			}
			set
			{
				m_Color = value;
			}
		}

		public int Count
		{
			get
			{
				return m_Count;
			}
			set
			{
				m_Count = value;
			}
		}

		public PlotColorTableEntry(Color color)
		{
			m_Color = color;
		}
	}
}
