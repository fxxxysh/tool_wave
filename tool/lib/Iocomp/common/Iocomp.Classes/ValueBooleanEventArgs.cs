using Iocomp.Types;
using System;

namespace Iocomp.Classes
{
	public class ValueBooleanEventArgs : EventArgs
	{
		private bool m_ValueOld;

		private bool m_ValueNew;

		private bool m_Cancel;

		private EventSource m_Source;

		public bool ValueOld => m_ValueOld;

		public bool ValueNew
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

		public ValueBooleanEventArgs(bool valueOld, bool valueNew, bool cancel, EventSource source)
		{
			m_ValueOld = valueOld;
			m_ValueNew = valueNew;
			m_Cancel = cancel;
			m_Source = source;
		}
	}
}
