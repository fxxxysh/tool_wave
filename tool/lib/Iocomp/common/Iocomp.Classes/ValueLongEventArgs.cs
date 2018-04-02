using Iocomp.Types;
using System;

namespace Iocomp.Classes
{
	public class ValueLongEventArgs : EventArgs
	{
		private long m_ValueOld;

		private long m_ValueNew;

		private bool m_Cancel;

		private EventSource m_Source;

		public long ValueOld => m_ValueOld;

		public long ValueNew
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

		public ValueLongEventArgs(long valueOld, long valueNew, bool cancel, EventSource source)
		{
			m_ValueOld = valueOld;
			m_ValueNew = valueNew;
			m_Cancel = cancel;
			m_Source = source;
		}
	}
}
