using System;

namespace Iocomp.Classes
{
	public class PropertyChangedEventArgs : EventArgs
	{
		private string m_Name;

		public string Name => m_Name;

		public PropertyChangedEventArgs(string name)
		{
			m_Name = name;
		}
	}
}
