using Iocomp.Interfaces;
using Iocomp.Types;
using System;

namespace Iocomp.Classes
{
	public class PlotDataPointBar : PlotDataPointYDouble
	{
		private PlotFill m_Fill;

		private PlotChannelBar m_Channel;

		private double m_Width;

		public double Width
		{
			get
			{
				return m_Width;
			}
			set
			{
				if (m_Width != value)
				{
					m_Width = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public PlotFill Fill
		{
			get
			{
				if (m_Fill == null)
				{
					return m_Channel.Fill;
				}
				return m_Fill;
			}
			set
			{
				if (m_Fill != value)
				{
					if (m_Fill != null)
					{
						((ISubClassBase)m_Fill).AmbientOwner = null;
						((ISubClassBase)m_Fill).ComponentBase = null;
					}
					m_Fill = value;
					if (m_Fill != null)
					{
						((ISubClassBase)m_Fill).AmbientOwner = m_Channel;
						((ISubClassBase)m_Fill).ColorAmbientSource = AmbientColorSouce.Color;
						((ISubClassBase)m_Fill).ComponentBase = ((ISubClassBase)m_Channel).ComponentBase;
					}
					base.m_CH.DoDataChange();
				}
			}
		}

		public PlotDataPointBar(PlotChannelBase channel)
			: base(channel)
		{
			if (!(channel is PlotChannelBar))
			{
				throw new Exception("Invalid Channel type for PlotDataPointBar");
			}
			m_Channel = (channel as PlotChannelBar);
		}
	}
}
