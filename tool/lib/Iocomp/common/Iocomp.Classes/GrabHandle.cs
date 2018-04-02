using System.Drawing;

namespace Iocomp.Classes
{
	public class GrabHandle
	{
		private Rectangle m_Rectangle;

		private bool m_Enabled;

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

		public bool Enabled
		{
			get
			{
				return m_Enabled;
			}
			set
			{
				m_Enabled = value;
			}
		}
	}
}
