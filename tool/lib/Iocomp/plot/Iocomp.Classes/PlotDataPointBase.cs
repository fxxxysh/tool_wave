using System;

namespace Iocomp.Classes
{
	public abstract class PlotDataPointBase
	{
		protected PlotChannelBase m_CH;

		private double m_X;

		private bool m_Null;

		private bool m_Empty;

		public double X
		{
			get
			{
				return m_X;
			}
			set
			{
				if (m_X != value)
				{
					m_X = value;
					m_CH.DoDataChange();
				}
			}
		}

		public bool Null
		{
			get
			{
				return m_Null;
			}
			set
			{
				if (m_Null != value)
				{
					m_Null = value;
					m_CH.DoDataChange();
				}
			}
		}

		public bool Empty
		{
			get
			{
				return m_Empty;
			}
			set
			{
				if (m_Empty != value)
				{
					m_Empty = value;
					m_CH.DoDataChange();
				}
			}
		}

		public PlotDataPointBase(PlotChannelBase channel)
		{
			if (channel == null)
			{
				throw new Exception("Channel must be specified");
			}
			m_CH = channel;
		}
	}
}
