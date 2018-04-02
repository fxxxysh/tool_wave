using Iocomp.Interfaces;
using Iocomp.Types;
using System;

namespace Iocomp.Classes
{
	public class PlotDataPointTraceXY : PlotDataPointYDouble
	{
		private PlotPen m_Trace;

		private PlotMarker m_Marker;

		private PlotChannelTraceXY m_Channel;

		public PlotPen Trace
		{
			get
			{
				if (m_Trace == null)
				{
					return m_Channel.Trace;
				}
				return m_Trace;
			}
			set
			{
				if (m_Trace != value)
				{
					if (m_Trace != null)
					{
						((ISubClassBase)m_Trace).AmbientOwner = null;
						((ISubClassBase)m_Trace).ComponentBase = null;
					}
					m_Trace = value;
					if (m_Trace != null)
					{
						((ISubClassBase)m_Trace).AmbientOwner = m_Channel;
						((ISubClassBase)m_Trace).ColorAmbientSource = AmbientColorSouce.Color;
						((ISubClassBase)m_Trace).ComponentBase = ((ISubClassBase)m_Channel).ComponentBase;
					}
					base.m_CH.DoDataChange();
				}
			}
		}

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

		public PlotDataPointTraceXY(PlotChannelBase channel)
			: base(channel)
		{
			if (!(channel is PlotChannelTraceXY))
			{
				throw new Exception("Invalid Channel type for PlotDataPointTraceXY");
			}
			m_Channel = (channel as PlotChannelTraceXY);
		}
	}
}
