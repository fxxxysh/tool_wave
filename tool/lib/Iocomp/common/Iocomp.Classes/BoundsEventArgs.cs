using System;
using System.Drawing;

namespace Iocomp.Classes
{
	public class BoundsEventArgs : EventArgs
	{
		private Rectangle m_Rectangle;

		public Rectangle Rectangle => m_Rectangle;

		public BoundsEventArgs(Rectangle value)
		{
			m_Rectangle = value;
		}
	}
}
