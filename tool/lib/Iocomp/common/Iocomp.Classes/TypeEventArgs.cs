using System;

namespace Iocomp.Classes
{
	public class TypeEventArgs : EventArgs
	{
		private Type m_Type;

		public Type Type => m_Type;

		public TypeEventArgs(Type value)
		{
			m_Type = value;
		}
	}
}
