using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotChannelDataCollection
	{
		private IPlotChannelBase I_Channel;

		private ArrayList m_Data;

		private bool m_XValueNotValidWhenEmptyOrNull;

		private int m_XMeanCount;

		private int m_YMeanCount;

		private double m_XMeanSum;

		private double m_YMeanSum;

		private double m_XMin;

		private double m_XMax;

		private double m_XMean;

		private double m_XStandardDeviation;

		private double m_YMin;

		private double m_YMax;

		private double m_YMean;

		private double m_YStandardDeviation;

		private int m_RingBufferCount;

		private bool m_RingBufferEnabled;

		private int m_RingHeadIndex;

		private int m_RingTailIndex;

		private int m_LastNewDataPointIndex;

		public bool XValueNotValidWhenEmptyOrNull
		{
			get
			{
				return m_XValueNotValidWhenEmptyOrNull;
			}
			set
			{
				m_XValueNotValidWhenEmptyOrNull = value;
			}
		}

		public double XMin => m_XMin;

		public double XMax => m_XMax;

		public double XMean => m_XMean;

		public double XStandardDeviation => m_XStandardDeviation;

		public double YMin => m_YMin;

		public double YMax => m_YMax;

		public double YMean => m_YMean;

		public double YStandardDeviation => m_YStandardDeviation;

		public int RingBufferCount
		{
			get
			{
				return m_RingBufferCount;
			}
			set
			{
				if (RingBufferCount != value)
				{
					m_RingBufferCount = value;
					if (m_RingBufferCount != 0)
					{
						if (m_Data.Count > m_RingBufferCount)
						{
							m_Data.RemoveRange(m_RingBufferCount, m_Data.Count - m_RingBufferCount);
						}
						if (m_RingTailIndex == -1)
						{
							if (m_RingHeadIndex > m_Data.Count - 1)
							{
								m_RingHeadIndex = m_Data.Count - 1;
							}
						}
						else
						{
							m_RingHeadIndex = -1;
							m_RingTailIndex = -1;
						}
					}
					else if (m_RingTailIndex != -1)
					{
						m_Data.Clear();
					}
					if (I_Channel != null)
					{
						I_Channel.DoDataChange();
					}
				}
				m_RingBufferEnabled = (RingBufferCount != 0);
			}
		}

		private bool RingBufferEnabled => m_RingBufferEnabled;

		private bool RingBufferFull => RingBufferCount == m_Data.Count;

		public int Capacity
		{
			get
			{
				return m_Data.Capacity;
			}
			set
			{
				m_Data.Capacity = value;
			}
		}

		public int LastNewDataPointIndex => m_LastNewDataPointIndex;

		public int Count
		{
			get
			{
				if (RingBufferEnabled && m_RingTailIndex == -1)
				{
					return m_RingHeadIndex - m_RingTailIndex;
				}
				return m_Data.Count;
			}
		}

		public PlotDataPointBase this[int index]
		{
			get
			{
				if (RingBufferEnabled)
				{
					if (m_RingTailIndex == -1)
					{
						return (PlotDataPointBase)m_Data[index];
					}
					int num = index + m_RingTailIndex;
					if (num > m_Data.Count - 1)
					{
						num -= m_Data.Count;
					}
					return (PlotDataPointBase)m_Data[num];
				}
				return (PlotDataPointBase)m_Data[index];
			}
		}

		public PlotChannelDataCollection(PlotChannelBase value)
		{
			I_Channel = value;
			m_Data = new ArrayList();
			m_RingHeadIndex = -1;
			m_RingTailIndex = -1;
		}

		public void Clear()
		{
			if (RingBufferEnabled)
			{
				m_RingHeadIndex = -1;
				m_RingTailIndex = -1;
			}
			else
			{
				m_Data.Clear();
			}
			if (I_Channel != null)
			{
				I_Channel.DoDataChange();
			}
		}

		public void RemoveAt(int index)
		{
			if (!RingBufferEnabled)
			{
				m_Data.RemoveAt(index);
			}
		}

		public void RemoveRange(int index, int count)
		{
			if (!RingBufferEnabled)
			{
				m_Data.RemoveRange(index, count);
			}
		}

		public void ClearMinMeanMax()
		{
			m_XMeanCount = 0;
			m_XMeanSum = 0.0;
			m_YMeanCount = 0;
			m_YMeanSum = 0.0;
			m_XMin = double.PositiveInfinity;
			m_XMax = double.NegativeInfinity;
			m_YMin = double.PositiveInfinity;
			m_YMax = double.NegativeInfinity;
			m_XMean = 0.0;
			m_YMean = 0.0;
			m_XStandardDeviation = 0.0;
			m_YStandardDeviation = 0.0;
		}

		public void UpdateMinMaxMean(PlotDataPointYDouble dataPoint)
		{
			if ((dataPoint.Empty || dataPoint.Null) && XValueNotValidWhenEmptyOrNull)
			{
				return;
			}
			m_XMeanCount++;
			m_XMeanSum += dataPoint.X;
			m_XMean = m_XMeanSum / (double)m_XMeanCount;
			m_XMin = Math.Min(m_XMin, dataPoint.X);
			m_XMax = Math.Max(m_XMax, dataPoint.X);
			if (!dataPoint.Empty && !dataPoint.Null)
			{
				m_YMeanCount++;
				m_YMeanSum += dataPoint.Y;
				m_YMean = m_YMeanSum / (double)m_YMeanCount;
				m_YMin = Math.Min(m_YMin, dataPoint.Y);
				m_YMax = Math.Max(m_YMax, dataPoint.Y);
			}
		}

		public void UpdateMinMaxMean(double x, double y, bool isNull, bool isEmpty)
		{
			if ((isEmpty || isNull) && XValueNotValidWhenEmptyOrNull)
			{
				return;
			}
			m_XMeanCount++;
			m_XMeanSum += x;
			m_XMean = m_XMeanSum / (double)m_XMeanCount;
			m_XMin = Math.Min(m_XMin, x);
			m_XMax = Math.Max(m_XMax, x);
			if (!isEmpty && !isNull)
			{
				m_YMeanCount++;
				m_YMeanSum += y;
				m_YMean = m_YMeanSum / (double)m_YMeanCount;
				m_YMin = Math.Min(m_YMin, y);
				m_YMax = Math.Max(m_YMax, y);
			}
		}

		public void UpdateStandardDeviations()
		{
			m_XStandardDeviation = 0.0;
			m_YStandardDeviation = 0.0;
			if (Count != 0)
			{
				PlotDataPointYDouble plotDataPointYDouble = this[0] as PlotDataPointYDouble;
				if (plotDataPointYDouble != null)
				{
					double num = 0.0;
					double num2 = 0.0;
					int num3 = 0;
					int num4 = 0;
					for (int i = 0; i < Count; i++)
					{
						plotDataPointYDouble = (this[i] as PlotDataPointYDouble);
						if (!plotDataPointYDouble.Empty && !plotDataPointYDouble.Null)
						{
							goto IL_0083;
						}
						if (!XValueNotValidWhenEmptyOrNull)
						{
							goto IL_0083;
						}
						continue;
						IL_0083:
						num += (XMean - plotDataPointYDouble.X) * (XMean - plotDataPointYDouble.X);
						num3++;
						if (!plotDataPointYDouble.Empty && !plotDataPointYDouble.Null)
						{
							num2 += (YMean - plotDataPointYDouble.Y) * (YMean - plotDataPointYDouble.Y);
							num4++;
						}
					}
					num /= (double)num3;
					num2 /= (double)num4;
					m_XStandardDeviation = Math.Sqrt(num);
					m_YStandardDeviation = Math.Sqrt(num2);
				}
			}
		}

		public PlotDataPointBase AddNew()
		{
			if (I_Channel == null)
			{
				return null;
			}
			PlotDataPointBase plotDataPointBase;
			if (RingBufferEnabled)
			{
				if (RingBufferFull || Count < m_Data.Count)
				{
					m_RingHeadIndex++;
					if (m_RingHeadIndex > m_Data.Count - 1)
					{
						m_RingHeadIndex = 0;
						m_RingTailIndex = 0;
					}
					if (m_RingTailIndex != -1)
					{
						m_RingTailIndex = m_RingHeadIndex + 1;
						if (m_RingTailIndex > m_Data.Count - 1)
						{
							m_RingTailIndex = 0;
						}
					}
					plotDataPointBase = (PlotDataPointBase)m_Data[m_RingHeadIndex];
					m_LastNewDataPointIndex = m_RingHeadIndex;
				}
				else
				{
					plotDataPointBase = I_Channel.CreateDataPoint();
					m_LastNewDataPointIndex = m_Data.Add(plotDataPointBase);
					m_RingHeadIndex = m_LastNewDataPointIndex;
				}
			}
			else
			{
				plotDataPointBase = I_Channel.CreateDataPoint();
				m_LastNewDataPointIndex = m_Data.Add(plotDataPointBase);
			}
			return plotDataPointBase;
		}

		public PlotDataPointBase AddNew(int Index)
		{
			if (I_Channel == null)
			{
				return null;
			}
			if (RingBufferEnabled)
			{
				throw new Exception("Calling AddNew and specifying the Index is not allowed when the ring-buffer is enabled.");
			}
			PlotDataPointBase plotDataPointBase = I_Channel.CreateDataPoint();
			m_Data.Insert(Index, plotDataPointBase);
			m_LastNewDataPointIndex = m_Data.Count - 1;
			return plotDataPointBase;
		}
	}
}
