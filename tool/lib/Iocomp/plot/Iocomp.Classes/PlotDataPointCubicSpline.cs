using Iocomp.Interfaces;
using Iocomp.Types;
using System;

namespace Iocomp.Classes
{
	public class PlotDataPointCubicSpline : PlotDataPointYDouble
	{
		private PlotMarker m_Marker;

		private PlotChannelCubicSpline m_Channel;

		private double m_Y2;

		private double m_U;

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

		public double Y2
		{
			get
			{
				return m_Y2;
			}
			set
			{
				m_Y2 = value;
			}
		}

		public double U
		{
			get
			{
				return m_U;
			}
			set
			{
				m_U = value;
			}
		}

		public PlotDataPointCubicSpline(PlotChannelBase channel)
			: base(channel)
		{
			if (!(channel is PlotChannelCubicSpline))
			{
				throw new Exception("Invalid Channel type for PlotDataPointCubicSpline");
			}
			m_Channel = (channel as PlotChannelCubicSpline);
		}
	}
}
