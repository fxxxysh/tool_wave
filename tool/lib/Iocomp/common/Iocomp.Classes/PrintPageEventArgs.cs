using System;
using System.Drawing.Printing;

namespace Iocomp.Classes
{
	public class PrintPageEventArgs : EventArgs
	{
		private PrintDocument m_PrintDocument;

		private int m_PageNumber;

		private bool m_HasMorePages;

		public PrintDocument PrintDocument => m_PrintDocument;

		public int PageNumber => m_PageNumber;

		public bool HasMorePages
		{
			get
			{
				return m_HasMorePages;
			}
			set
			{
				m_HasMorePages = value;
			}
		}

		public PrintPageEventArgs(PrintDocument value, int pageNumber)
		{
			m_PrintDocument = value;
			m_PageNumber = pageNumber;
		}
	}
}
