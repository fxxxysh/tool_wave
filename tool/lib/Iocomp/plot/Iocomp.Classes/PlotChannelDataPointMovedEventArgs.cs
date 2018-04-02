using System;

namespace Iocomp.Classes
{
	public class PlotChannelDataPointMovedEventArgs : EventArgs
	{
		private PlotChannelBase m_Channel;

		private int m_Index;

		private double m_OldX;

		private double m_OldY;

		private double m_NewX;

		private double m_NewY;

		public PlotChannelBase Channel => m_Channel;

		public int Index => m_Index;

		public double OldX => m_OldX;

		public double OldY => m_OldY;

		public double NewX => m_NewX;

		public double NewY => m_NewY;

		public PlotChannelDataPointMovedEventArgs(PlotChannelBase channel, int index, double oldX, double oldY, double newX, double newY)
		{
			m_Channel = channel;
			m_Index = index;
			m_OldX = oldX;
			m_OldY = oldY;
			m_NewX = newX;
			m_NewY = newY;
		}
	}
}
