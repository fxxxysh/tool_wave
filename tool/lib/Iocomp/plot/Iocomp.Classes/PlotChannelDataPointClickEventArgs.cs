using System;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public class PlotChannelDataPointClickEventArgs : EventArgs
	{
		private PlotChannelBase m_Channel;

		private MouseButtons m_Button;

		private int m_Index;

		public PlotChannelBase Channel => m_Channel;

		public int Index => m_Index;

		public MouseButtons Button => m_Button;

		public PlotChannelDataPointClickEventArgs(PlotChannelBase channel, MouseButtons button, int index)
		{
			m_Channel = channel;
			m_Button = button;
			m_Index = index;
		}
	}
}
