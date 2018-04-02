using System;

namespace Iocomp.Classes
{
	public class ObjectMoveIndexEventArgs : EventArgs
	{
		private object m_Instance;

		private int m_OldIndex;

		private int m_NewIndex;

		public object Instance => m_Instance;

		public int OldIndex => m_OldIndex;

		public int NewIndex => m_NewIndex;

		public ObjectMoveIndexEventArgs(object instance, int oldIndex, int newIndex)
		{
			m_Instance = instance;
			m_OldIndex = oldIndex;
			m_NewIndex = newIndex;
		}
	}
}
