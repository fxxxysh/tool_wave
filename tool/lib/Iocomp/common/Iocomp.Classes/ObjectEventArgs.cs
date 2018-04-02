using System;

namespace Iocomp.Classes
{
	public class ObjectEventArgs : EventArgs
	{
		private object m_Object;

		public object Object => m_Object;

		public ObjectEventArgs(object value)
		{
			m_Object = value;
		}
	}
}
