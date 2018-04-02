using Iocomp.Types;
using System;

namespace Iocomp.Classes
{
	public class ValueIntegerEventArgs : EventArgs
	{
		private int m_ValueOld;

		private int m_ValueNew;

		private bool m_Cancel;

		private EventSource m_Source;

		public int ValueOld => m_ValueOld;

		public int ValueNew
		{
			get
			{
				return m_ValueNew;
			}
			set
			{
				m_ValueNew = value;
			}
		}

		public bool Cancel
		{
			get
			{
				return m_Cancel;
			}
			set
			{
				m_Cancel = value;
			}
		}

		public EventSource Source => m_Source;

		public ValueIntegerEventArgs(int valueOld, int valueNew, bool cancel, EventSource source)
		{
			m_ValueOld = valueOld;
			m_ValueNew = valueNew;
			m_Cancel = cancel;
			m_Source = source;
		}
	}
}
