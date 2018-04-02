using Iocomp.Types;
using System;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Channel Consecutive")]
	public abstract class PlotChannelConsecutive : PlotChannelBase
	{
		private int m_IndexDrawStart;

		private int m_IndexDrawStop;

		private DateTime m_ElapsedStartTime;

		private bool m_RequireConsecutiveData;

		private OPCXValueType m_OPCXValueSource;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DateTime ElapsedStartTime
		{
			get
			{
				return m_ElapsedStartTime;
			}
			set
			{
				base.PropertyUpdateDefault("ElapsedStartTime", value);
				if (ElapsedStartTime != value)
				{
					m_ElapsedStartTime = value;
					base.DoPropertyChange(this, "ElapsedStartTime");
				}
			}
		}

		protected bool RequireConsecutiveData
		{
			get
			{
				return m_RequireConsecutiveData;
			}
			set
			{
				base.PropertyUpdateDefault("RequireConsecutiveData", value);
				if (RequireConsecutiveData != value)
				{
					m_RequireConsecutiveData = value;
					base.DoPropertyChange(this, "RequireConsecutiveData");
				}
			}
		}

		[Description("")]
		public DataDirection DataDirection
		{
			get
			{
				if (Count < 2)
				{
					return DataDirection.Increasing;
				}
				if (GetX(1) > GetX(0))
				{
					return DataDirection.Increasing;
				}
				return DataDirection.Decreasing;
			}
		}

		[Description("")]
		public int DrawPointCount
		{
			get
			{
				if (IndexDrawStop != -1 && IndexDrawStart != -1)
				{
					return Math.Abs(IndexDrawStop - IndexDrawStart + 1);
				}
				return 0;
			}
		}

		public override int IndexDrawStart
		{
			get
			{
				if (RequireConsecutiveData)
				{
					if (DataDirection == DataDirection.Increasing)
					{
						return m_IndexDrawStart;
					}
					return m_IndexDrawStop;
				}
				return base.IndexDrawStart;
			}
		}

		public override int IndexDrawStop
		{
			get
			{
				if (RequireConsecutiveData)
				{
					if (DataDirection == DataDirection.Increasing)
					{
						return m_IndexDrawStop;
					}
					return m_IndexDrawStart;
				}
				return base.IndexDrawStop;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public OPCXValueType OPCXValueSource
		{
			get
			{
				return m_OPCXValueSource;
			}
			set
			{
				base.PropertyUpdateDefault("OPCXValueSource", value);
				if (OPCXValueSource != value)
				{
					m_OPCXValueSource = value;
					base.DoPropertyChange(this, "OPCXValueSource");
				}
			}
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			m_IndexDrawStart = -1;
			m_IndexDrawStop = -1;
			RequireConsecutiveData = true;
			OPCXValueSource = OPCXValueType.OPCServerTimeStamp;
			ElapsedStartTime = DateTime.Now;
		}

		private bool ShouldSerializeOPCXValueSource()
		{
			return base.PropertyShouldSerialize("OPCXValueSource");
		}

		private void ResetOPCXValueSource()
		{
			base.PropertyReset("OPCXValueSource");
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override void NewOPCData(double data, DateTime timeStamp)
		{
			if (OPCXValueSource == OPCXValueType.OPCServerTimeStamp)
			{
				AddXY(timeStamp.ToOADate(), data);
			}
			else if (OPCXValueSource == OPCXValueType.SystemClock)
			{
				AddYNow(data);
			}
			else if (OPCXValueSource == OPCXValueType.SystemClockUTC)
			{
				AddYUTC(data);
			}
			else if (OPCXValueSource == OPCXValueType.ElapsedSeconds)
			{
				AddYElapsedSeconds(data);
			}
			else if (OPCXValueSource == OPCXValueType.ElapsedTime)
			{
				AddYElapsedTime(data);
			}
		}

		public int AddYNow(double y)
		{
			return AddXY(Math2.DateTimeToDouble(DateTime.Now), y);
		}

		public int AddYUTC(double y)
		{
			return AddXY(Math2.DateTimeToDouble(DateTime.UtcNow), y);
		}

		public int AddYElapsedTime(double y)
		{
			return AddXY(Math2.DateTimeToDouble(DateTime.Now) - Math2.DateTimeToDouble(ElapsedStartTime), y);
		}

		public int AddYElapsedSeconds(double y)
		{
			return AddXY((Math2.DateTimeToDouble(DateTime.Now) - Math2.DateTimeToDouble(ElapsedStartTime)) * 24.0 * 60.0 * 60.0, y);
		}

		public void ElapsedStartTimeReset()
		{
			ElapsedStartTime = DateTime.Now;
		}

		public DateTime GetXInDateTime(int index)
		{
			return Math2.DoubleToDateTime(GetX(index));
		}

		public bool ValidNextX(double nextX)
		{
			if (Count == 0)
			{
				return true;
			}
			if (Count == 1 && nextX == GetX(base.IndexLast))
			{
				return false;
			}
			if (Count == 1)
			{
				return true;
			}
			if (DataDirection == DataDirection.Increasing)
			{
				if (nextX > GetX(base.IndexLast))
				{
					return true;
				}
				return false;
			}
			if (nextX < GetX(base.IndexLast))
			{
				return true;
			}
			return false;
		}

		protected void CheckForValidNextX(double nextX)
		{
			if (ValidNextX(nextX))
			{
				return;
			}
			throw new Exception("X-Value is not continuous (Must be continuously increasing or decreasing).");
		}

		public virtual void UpdateDrawIndexes()
		{
			PlotXAxis xAxis = base.XAxis;
			m_IndexDrawStart = -1;
			m_IndexDrawStop = -1;
			if (xAxis != null && Count != 0 && !(base.XMax < xAxis.Min) && !(base.XMin > xAxis.Max))
			{
				double max = xAxis.ScaleRange.Max;
				double min = xAxis.ScaleRange.Min;
				if (Count == 1)
				{
					m_IndexDrawStart = 0;
					m_IndexDrawStop = 0;
				}
				else
				{
					if (DataDirection == DataDirection.Increasing)
					{
						m_IndexDrawStart = CalcIndexesIncrementing(min);
						m_IndexDrawStop = CalcIndexesIncrementing(max);
						if (GetX(m_IndexDrawStart) > min)
						{
							m_IndexDrawStart--;
						}
						if (GetX(m_IndexDrawStop) < max)
						{
							m_IndexDrawStop++;
						}
					}
					else
					{
						m_IndexDrawStop = CalcIndexesDecrementing(max);
						m_IndexDrawStart = CalcIndexesDecrementing(min);
						if (GetX(m_IndexDrawStart) > min)
						{
							m_IndexDrawStart++;
						}
						if (GetX(m_IndexDrawStop) < max)
						{
							m_IndexDrawStop--;
						}
					}
					if (m_IndexDrawStart < base.IndexFirst)
					{
						m_IndexDrawStart = base.IndexFirst;
					}
					if (m_IndexDrawStop < base.IndexFirst)
					{
						m_IndexDrawStop = base.IndexFirst;
					}
					if (m_IndexDrawStart > base.IndexLast)
					{
						m_IndexDrawStart = base.IndexLast;
					}
					if (m_IndexDrawStop > base.IndexLast)
					{
						m_IndexDrawStop = base.IndexLast;
					}
				}
			}
		}

		public override PlotChannelInterpolationResult GetYInterpolated(double targetX, out double yValue)
		{
			yValue = 0.0;
			if (Count == 0)
			{
				return PlotChannelInterpolationResult.NoData;
			}
			if (targetX < base.XMin)
			{
				return PlotChannelInterpolationResult.NoData;
			}
			if (targetX > base.XMax)
			{
				return PlotChannelInterpolationResult.NoData;
			}
			if (Count == 1 && GetX(0) != targetX)
			{
				return PlotChannelInterpolationResult.Void;
			}
			if (targetX < base.XFirst)
			{
				return PlotChannelInterpolationResult.Void;
			}
			if (targetX > base.XLast)
			{
				return PlotChannelInterpolationResult.Void;
			}
			if (Count == 1 && GetX(0) == targetX)
			{
				if (GetNull(0))
				{
					return PlotChannelInterpolationResult.Null;
				}
				if (GetEmpty(0))
				{
					return PlotChannelInterpolationResult.NoData;
				}
				yValue = GetY(0);
				return PlotChannelInterpolationResult.Valid;
			}
			int num = CalculateXValueNearestIndex(targetX);
			double x = GetX(num);
			if (num == -1)
			{
				return PlotChannelInterpolationResult.Invalid;
			}
			if (x == targetX)
			{
				if (GetNull(num))
				{
					return PlotChannelInterpolationResult.Null;
				}
				if (!GetEmpty(num))
				{
					yValue = GetY(num);
					return PlotChannelInterpolationResult.Valid;
				}
			}
			int num2;
			int num3;
			if (x <= targetX)
			{
				if (num >= base.IndexLast)
				{
					return PlotChannelInterpolationResult.Invalid;
				}
				num2 = num;
				num3 = num + 1;
				while (GetEmpty(num2))
				{
					num2--;
					if (num2 < base.IndexFirst)
					{
						return PlotChannelInterpolationResult.Void;
					}
				}
				if (GetNull(num2))
				{
					return PlotChannelInterpolationResult.Null;
				}
				while (GetEmpty(num3))
				{
					num3++;
					if (num3 > base.IndexLast)
					{
						return PlotChannelInterpolationResult.Void;
					}
				}
				if (GetNull(num3))
				{
					return PlotChannelInterpolationResult.Null;
				}
			}
			else
			{
				if (num == base.IndexFirst)
				{
					return PlotChannelInterpolationResult.Invalid;
				}
				num2 = num - 1;
				num3 = num;
				while (GetEmpty(num2))
				{
					num2--;
					if (num2 < base.IndexFirst)
					{
						return PlotChannelInterpolationResult.Void;
					}
				}
				if (GetNull(num2))
				{
					return PlotChannelInterpolationResult.Null;
				}
				while (GetEmpty(num3))
				{
					num3++;
					if (num3 > base.IndexLast)
					{
						return PlotChannelInterpolationResult.Void;
					}
				}
				if (GetNull(num3))
				{
					return PlotChannelInterpolationResult.Null;
				}
			}
			double x2 = GetX(num2);
			double y = GetY(num2);
			double x3 = GetX(num3);
			double y2 = GetY(num3);
			yValue = (targetX - x2) / (x3 - x2) * (y2 - y) + y;
			return PlotChannelInterpolationResult.Valid;
		}

		public override int CalculateXValueNearestIndex(double value)
		{
			int num = (DataDirection != 0) ? CalcIndexesDecrementing(value) : CalcIndexesIncrementing(value);
			double num2 = Math.Abs(value - GetX(num));
			if (num > 0)
			{
				double num3 = Math.Abs(value - GetX(num - 1));
				if (num3 < num2)
				{
					return num - 1;
				}
			}
			if (num < base.IndexLast)
			{
				double num3 = Math.Abs(value - GetX(num + 1));
				if (num3 < num2)
				{
					return num + 1;
				}
			}
			return num;
		}

		private int CalcIndexesIncrementing(double targetValue)
		{
			int num = -1;
			int num2 = base.IndexFirst;
			int num3 = base.IndexLast;
			if (GetX(base.IndexFirst) == targetValue)
			{
				return base.IndexFirst;
			}
			if (GetX(base.IndexLast) == targetValue)
			{
				return base.IndexLast;
			}
			while (num2 <= num3)
			{
				int num4 = (num2 + num3) / 2;
				double x = GetX(num4);
				num = num4;
				if (x == targetValue)
				{
					break;
				}
				if (x > targetValue)
				{
					num3 = num4 - 1;
				}
				else
				{
					num2 = num4 + 1;
				}
			}
			if (num < base.IndexFirst)
			{
				num = base.IndexFirst;
			}
			if (num > base.IndexLast)
			{
				num = base.IndexLast;
			}
			return num;
		}

		private int CalcIndexesDecrementing(double targetValue)
		{
			int num = -1;
			int num2 = base.IndexFirst;
			int num3 = base.IndexLast;
			if (GetX(base.IndexFirst) == targetValue)
			{
				return base.IndexFirst;
			}
			if (GetX(base.IndexLast) == targetValue)
			{
				return base.IndexLast;
			}
			while (num2 <= num3)
			{
				int num4 = (num2 + num3) / 2;
				double x = GetX(num4);
				num = num4;
				if (x == targetValue)
				{
					break;
				}
				if (x > targetValue)
				{
					num2 = num4 + 1;
				}
				else
				{
					num3 = num4 - 1;
				}
			}
			if (num < base.IndexFirst)
			{
				num = base.IndexFirst;
			}
			if (num > base.IndexLast)
			{
				num = base.IndexLast;
			}
			return num;
		}

		protected override void LoadDesignTimeData(PlotXAxis xAxis, PlotYAxis yAxis, Random random, double yMin, double ySpan)
		{
			for (double num = xAxis.Min; num < xAxis.Max; num += xAxis.Span / 20.0)
			{
				AddXY(num, yMin + random.NextDouble() * ySpan);
			}
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (RequireConsecutiveData)
			{
				UpdateDrawIndexes();
				if (DrawPointCount == 0)
				{
					base.CanDraw = false;
				}
			}
		}
	}
}
