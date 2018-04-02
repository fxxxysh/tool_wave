using Iocomp.Interfaces;
using System;

namespace Iocomp.Classes
{
	public class LostFocusEventArgs : EventArgs
	{
		private IUIInput m_NewFocusObject;

		private bool m_Cancel;

		public object NewFocusObject => m_NewFocusObject;

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

		public LostFocusEventArgs(IUIInput newFocusObject)
		{
			m_NewFocusObject = newFocusObject;
		}
	}
}
