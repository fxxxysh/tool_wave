using System;
using System.Drawing;

namespace Iocomp.Classes
{
	public class PlotTraceFastDraw
	{
		private PlotXAxis m_XAxis;

		private PlotYAxis m_YAxis;

		private PaintArgs m_P;

		private Pen m_Pen;

		private int m_PixelXLast;

		private int m_PixelXNext;

		private int m_PixelYMin;

		private int m_PixelYMax;

		private int m_PixelYLast;

		private bool m_Empty;

		private bool m_HighLowCached;

		private bool m_HorizontalCached;

		private bool m_TraceVisible;

		private bool m_XYSwapped;

		private bool m_FillVisible;

		private Brush m_FillBrush;

		private int m_FillRefPixel;

		private Point[] m_Points;

		public PlotXAxis XAxis
		{
			get
			{
				return m_XAxis;
			}
			set
			{
				m_XAxis = value;
			}
		}

		public PlotYAxis YAxis
		{
			get
			{
				return m_YAxis;
			}
			set
			{
				m_YAxis = value;
			}
		}

		public PaintArgs P
		{
			get
			{
				return m_P;
			}
			set
			{
				m_P = value;
			}
		}

		public Pen Pen
		{
			get
			{
				return m_Pen;
			}
			set
			{
				m_Pen = value;
			}
		}

		public bool TraceVisible
		{
			get
			{
				return m_TraceVisible;
			}
			set
			{
				m_TraceVisible = value;
			}
		}

		public bool XYSwapped
		{
			get
			{
				return m_XYSwapped;
			}
			set
			{
				m_XYSwapped = value;
			}
		}

		public bool FillVisible
		{
			get
			{
				return m_FillVisible;
			}
			set
			{
				m_FillVisible = value;
			}
		}

		public Brush FillBrush
		{
			get
			{
				return m_FillBrush;
			}
			set
			{
				m_FillBrush = value;
			}
		}

		public int FillRefPixel
		{
			get
			{
				return m_FillRefPixel;
			}
			set
			{
				m_FillRefPixel = value;
			}
		}

		public void CleanupHighLowCached()
		{
			if (TraceVisible)
			{
				if (m_PixelYMax != m_PixelYMin)
				{
					if (XYSwapped)
					{
						P.Graphics.DrawLine(m_Pen, m_PixelYMin, m_PixelXLast, m_PixelYMax, m_PixelXLast);
					}
					else
					{
						P.Graphics.DrawLine(m_Pen, m_PixelXLast, m_PixelYMin, m_PixelXLast, m_PixelYMax);
					}
				}
				m_HighLowCached = false;
			}
		}

		public void CleanupHorizontalCached()
		{
			if (TraceVisible)
			{
				if (XYSwapped)
				{
					P.Graphics.DrawLine(m_Pen, m_PixelYLast, m_PixelXLast, m_PixelYLast, m_PixelXNext);
				}
				else
				{
					P.Graphics.DrawLine(m_Pen, m_PixelXLast, m_PixelYLast, m_PixelXNext, m_PixelYLast);
				}
				if (FillVisible)
				{
					if (m_Points == null)
					{
						m_Points = new Point[4];
					}
					if (XYSwapped)
					{
						m_Points[0].X = m_FillRefPixel;
						m_Points[0].Y = m_PixelXLast;
					}
					else
					{
						m_Points[0].X = m_PixelXLast;
						m_Points[0].Y = m_FillRefPixel;
					}
					if (XYSwapped)
					{
						m_Points[1].X = m_PixelYLast;
						m_Points[1].Y = m_PixelXLast;
					}
					else
					{
						m_Points[1].X = m_PixelXLast;
						m_Points[1].Y = m_PixelYLast;
					}
					if (XYSwapped)
					{
						m_Points[2].X = m_PixelYLast;
						m_Points[2].Y = m_PixelXNext;
					}
					else
					{
						m_Points[2].X = m_PixelXNext;
						m_Points[2].Y = m_PixelYLast;
					}
					if (XYSwapped)
					{
						m_Points[3].X = m_FillRefPixel;
						m_Points[3].Y = m_PixelXNext;
					}
					else
					{
						m_Points[3].X = m_PixelXNext;
						m_Points[3].Y = m_FillRefPixel;
					}
					P.Graphics.FillPolygon(FillBrush, m_Points);
				}
				m_PixelXLast = m_PixelXNext;
				m_HorizontalCached = false;
			}
		}

		public void AddDataPoint(PlotDataPointYDouble dataPoint)
		{
			if (!dataPoint.Empty)
			{
				if (dataPoint.Null)
				{
					DrawFlush();
				}
				else
				{
					int num = m_XAxis.ScaleDisplay.ValueToPixels(dataPoint.X);
					int num2 = m_YAxis.ScaleDisplay.ValueToPixels(dataPoint.Y);
					if (m_Empty)
					{
						m_PixelXLast = num;
						m_PixelYMin = num2;
						m_PixelYMax = num2;
						m_PixelYLast = num2;
						m_Empty = false;
					}
					else if (num == m_PixelXLast && num2 != m_PixelYLast)
					{
						m_PixelYMin = Math.Min(m_PixelYMin, num2);
						m_PixelYMax = Math.Max(m_PixelYMax, num2);
						m_PixelYLast = num2;
						m_HighLowCached = true;
					}
					else
					{
						if (m_HighLowCached)
						{
							CleanupHighLowCached();
						}
						if (m_PixelYLast == num2)
						{
							m_PixelXNext = num;
							m_HorizontalCached = true;
						}
						else
						{
							if (m_HorizontalCached)
							{
								CleanupHorizontalCached();
							}
							if (TraceVisible)
							{
								if (XYSwapped)
								{
									P.Graphics.DrawLine(m_Pen, m_PixelYLast, m_PixelXLast, num2, num);
								}
								else
								{
									P.Graphics.DrawLine(m_Pen, m_PixelXLast, m_PixelYLast, num, num2);
								}
							}
							if (FillVisible)
							{
								if (m_Points == null)
								{
									m_Points = new Point[4];
								}
								if (XYSwapped)
								{
									m_Points[0].X = m_FillRefPixel;
									m_Points[0].Y = m_PixelXLast;
									m_Points[1].X = m_PixelYLast;
									m_Points[1].Y = m_PixelXLast;
									m_Points[2].X = num2;
									m_Points[2].Y = num;
									m_Points[3].X = m_FillRefPixel;
									m_Points[3].Y = num;
								}
								else
								{
									m_Points[0].X = m_PixelXLast;
									m_Points[0].Y = m_FillRefPixel;
									m_Points[1].X = m_PixelXLast;
									m_Points[1].Y = m_PixelYLast;
									m_Points[2].X = num;
									m_Points[2].Y = num2;
									m_Points[3].X = num;
									m_Points[3].Y = m_FillRefPixel;
								}
								P.Graphics.FillPolygon(FillBrush, m_Points);
							}
							m_PixelXLast = num;
							m_PixelYMin = num2;
							m_PixelYMax = num2;
							m_PixelYLast = num2;
						}
					}
				}
			}
		}

		public void Reset()
		{
			m_Empty = true;
			m_HighLowCached = false;
			m_HorizontalCached = false;
		}

		public void DrawFlush()
		{
			if (m_HighLowCached)
			{
				CleanupHighLowCached();
			}
			if (m_HorizontalCached)
			{
				CleanupHorizontalCached();
			}
			m_Empty = true;
		}
	}
}
