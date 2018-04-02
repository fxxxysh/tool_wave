using Iocomp.Types;
using System;

namespace Iocomp.Classes
{
	public class ValueStringEventArgs : EventArgs
	{
		private string m_ValueOld;

		private string m_ValueNew;

		private bool m_Cancel;

		private EventSource m_Source;

		public string ValueOld => m_ValueOld;

		public string ValueNew
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

		public ValueStringEventArgs(string valueOld, string valueNew, bool cancel, EventSource source)
		{
			m_ValueOld = valueOld;
			m_ValueNew = valueNew;
			m_Cancel = cancel;
			m_Source = source;
		}
	}
}
