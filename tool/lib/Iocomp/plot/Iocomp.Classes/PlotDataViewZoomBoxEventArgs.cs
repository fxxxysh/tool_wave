using System;
using System.Drawing;

namespace Iocomp.Classes
{
	public class PlotDataViewZoomBoxEventArgs : EventArgs
	{
		private Rectangle m_Rectangle;

		private bool m_Cancel;

		private PlotDataView m_DataView;

		public PlotDataView DataView => m_DataView;

		public Rectangle Rectangle => m_Rectangle;

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

		public PlotDataViewZoomBoxEventArgs(PlotDataView dataView, Rectangle r)
		{
			m_DataView = dataView;
			m_Rectangle = r;
			m_Cancel = false;
		}
	}
}
