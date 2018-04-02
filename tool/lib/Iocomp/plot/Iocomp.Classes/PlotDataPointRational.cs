using Iocomp.Interfaces;
using Iocomp.Types;
using System;

namespace Iocomp.Classes
{
	public class PlotDataPointRational : PlotDataPointYDouble
	{
		private PlotMarker m_Marker;

		private PlotChannelRational m_Channel;

		private double m_C;

		private double m_D;

		public PlotMarker Marker
		{
			get
			{
				if (m_Marker == null)
				{
					return m_Channel.Markers;
				}
				return m_Marker;
			}
			set
			{
				if (m_Marker != value)
				{
					if (m_Marker != null)
					{
						((ISubClassBase)m_Marker).ComponentBase = null;
						((ISubClassBase)m_Marker.Fill.Pen).AmbientOwner = null;
						((ISubClassBase)m_Marker.Fill.Brush).AmbientOwner = null;
					}
					m_Marker = value;
					if (m_Marker != null)
					{
						((ISubClassBase)m_Marker).ComponentBase = ((ISubClassBase)m_Channel).ComponentBase;
						((ISubClassBase)m_Marker.Fill.Pen).AmbientOwner = m_Channel;
						((ISubClassBase)m_Marker.Fill.Brush).AmbientOwner = m_Channel;
						((ISubClassBase)m_Marker.Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
						((ISubClassBase)m_Marker.Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
					}
					m_Channel.DoDataChange();
				}
			}
		}

		public double C
		{
			get
			{
				return m_C;
			}
			set
			{
				m_C = value;
			}
		}

		public double D
		{
			get
			{
				return m_D;
			}
			set
			{
				m_D = value;
			}
		}

		public PlotDataPointRational(PlotChannelBase channel)
			: base(channel)
		{
			if (!(channel is PlotChannelRational))
			{
				throw new Exception("Invalid Channel type for PlotDataPointRational");
			}
			m_Channel = (channel as PlotChannelRational);
		}
	}
}
