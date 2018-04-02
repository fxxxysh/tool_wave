using System;

namespace Iocomp.Classes
{
	public class PlotObjectRenamedEventArgs : EventArgs
	{
		private PlotObject m_Object;

		private string m_OldName;

		public PlotObject Object => m_Object;

		public string OldName => m_OldName;

		public PlotObjectRenamedEventArgs(PlotObject value, string oldName)
		{
			m_Object = value;
			m_OldName = oldName;
		}
	}
}
