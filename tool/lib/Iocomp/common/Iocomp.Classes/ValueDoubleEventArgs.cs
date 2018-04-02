using Iocomp.Types;
using System;

namespace Iocomp.Classes
{
	public class ValueDoubleEventArgs : EventArgs
	{
		private double m_ValueOld;

		private double m_ValueNew;

		private bool m_Cancel;

		private EventSource m_Source;

		public double ValueOld => m_ValueOld;

		public double ValueNew
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

		public ValueDoubleEventArgs(double valueOld, double valueNew, bool cancel, EventSource source)
		{
			m_ValueOld = valueOld;
			m_ValueNew = valueNew;
			m_Cancel = cancel;
			m_Source = source;
		}
	}
}
