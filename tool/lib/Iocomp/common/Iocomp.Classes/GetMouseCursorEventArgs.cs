using System;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public class GetMouseCursorEventArgs : EventArgs
	{
		private Cursor m_Cursor;

		public Cursor Cursor
		{
			get
			{
				return m_Cursor;
			}
			set
			{
				m_Cursor = value;
			}
		}

		public GetMouseCursorEventArgs(Cursor cursor)
		{
			m_Cursor = cursor;
		}
	}
}
