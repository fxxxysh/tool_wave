using System;

namespace Iocomp.Classes
{
	public class PlotDataCursorCustomizeHintTextEventArgs : EventArgs
	{
		private string m_Text;

		private PlotDataCursorBase m_DataCursor;

		public PlotDataCursorBase DataCursor => m_DataCursor;

		public string Text
		{
			get
			{
				return m_Text;
			}
			set
			{
				m_Text = value;
			}
		}

		public PlotDataCursorCustomizeHintTextEventArgs(PlotDataCursorBase dataCursor, string text)
		{
			m_DataCursor = dataCursor;
			m_Text = text;
		}
	}
}
