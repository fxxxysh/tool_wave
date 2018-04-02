using System;
using System.Drawing.Printing;

namespace Iocomp.Classes
{
	public class PrintEventArgs : EventArgs
	{
		private PrintDocument m_PrintDocument;

		public PrintDocument PrintDocument => m_PrintDocument;

		public PrintEventArgs(PrintDocument value)
		{
			m_PrintDocument = value;
		}
	}
}
