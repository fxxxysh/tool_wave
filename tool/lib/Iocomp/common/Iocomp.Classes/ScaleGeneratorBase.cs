using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;

namespace Iocomp.Classes
{
	public abstract class ScaleGeneratorBase : SubClassBase, IScaleGeneratorBase
	{
		private IScaleDisplay m_Display;

		private bool m_MidIncluded;

		private int m_MinorCount;

		private double m_MinorStepSize;

		double IScaleGeneratorBase.MinorStepSize
		{
			get
			{
				return MinorStepSize;
			}
		}

		IScaleDisplay IScaleGeneratorBase.Display
		{
			get
			{
				return Display;
			}
			set
			{
				Display = value;
			}
		}

		protected IScaleDisplay Display
		{
			get
			{
				return m_Display;
			}
			set
			{
				m_Display = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool MidIncluded
		{
			get
			{
				return m_MidIncluded;
			}
			set
			{
				base.PropertyUpdateDefault("MidIncluded", value);
				if (MidIncluded != value)
				{
					m_MidIncluded = value;
					base.DoPropertyChange(this, "MidIncluded");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int MinorCount
		{
			get
			{
				return m_MinorCount;
			}
			set
			{
				base.PropertyUpdateDefault("MinorCount", value);
				if (value < 0)
				{
					base.ThrowStreamingSafeException("MinorCount value must be 0 or greater.");
				}
				if (value < 0)
				{
					value = 0;
				}
				if (MinorCount != value)
				{
					m_MinorCount = value;
					base.DoPropertyChange(this, "MinorCount");
				}
			}
		}

		private double MinorStepSize => m_MinorStepSize;

		void IScaleGeneratorBase.Generate(PaintArgs p, ScaleTickInfo tickInfo)
		{
			Generate(p, tickInfo);
		}

		void IScaleGeneratorBase.InitializeTickInfo(ScaleTickInfo tickInfo)
		{
			InitializeTickInfo(tickInfo);
		}

		private bool ShouldSerializeMidIncluded()
		{
			return base.PropertyShouldSerialize("MidIncluded");
		}

		private void ResetMidIncluded()
		{
			base.PropertyReset("MidIncluded");
		}

		private bool ShouldSerializeMinorCount()
		{
			return base.PropertyShouldSerialize("MinorCount");
		}

		private void ResetMinorCount()
		{
			base.PropertyReset("MinorCount");
		}

		protected double GetStartValue(ScaleTickInfo tickInfo)
		{
			double num = (!Display.StartRefEnabled) ? tickInfo.StartStandard : Display.StartRefValue;
			if (num < tickInfo.Min)
			{
				double num2 = Math.Round((tickInfo.Min - num) / tickInfo.MajorStepSize);
				num += num2 * tickInfo.MajorStepSize;
			}
			else if (num > tickInfo.Min)
			{
				double num2 = Math.Round((num - tickInfo.Min) / tickInfo.MajorStepSize);
				num -= (num2 + 1.0) * tickInfo.MajorStepSize;
			}
			if (num >= tickInfo.Min)
			{
				num -= tickInfo.MajorStepSize;
			}
			return num;
		}

		protected double GetStopValue(ScaleTickInfo tickInfo)
		{
			return tickInfo.Max + tickInfo.MajorStepSize;
		}

		private int GetMinorCount()
		{
			if (MidIncluded)
			{
				if (MinorCount % 2 == 0)
				{
					return MinorCount + 1;
				}
				return MinorCount;
			}
			return MinorCount;
		}

		private bool CanAdd(IScaleDisplay display, double value)
		{
			if (display.SlidingScale)
			{
				return true;
			}
			if (display.GetValueOnScale(value))
			{
				return true;
			}
			return false;
		}

		protected virtual void CalculateMajorTicks(ScaleTickInfo tickInfo)
		{
		}

		protected virtual void InitializeTickInfo(ScaleTickInfo tickInfo)
		{
			tickInfo.MinorCount = GetMinorCount();
			tickInfo.MidIncluded = MidIncluded;
		}

		protected void GenerateLog10(PaintArgs p, ScaleTickInfo tickInfo)
		{
			int num = (int)Math.Log10(tickInfo.Span);
			int num2 = 1;
			int num3;
			if (num / num2 > tickInfo.MaxTicks)
			{
				if (num / num2 > tickInfo.MaxTicks)
				{
					num2 = 1;
				}
				if (num / num2 > tickInfo.MaxTicks)
				{
					num2 = 2;
				}
				if (num / num2 > tickInfo.MaxTicks)
				{
					num2 = 5;
				}
				if (num / num2 > tickInfo.MaxTicks)
				{
					num2 = 10;
				}
				if (num / num2 > tickInfo.MaxTicks)
				{
					num2 = 20;
				}
				if (num / num2 > tickInfo.MaxTicks)
				{
					num2 = 50;
				}
				if (num / num2 > tickInfo.MaxTicks)
				{
					num2 = 100;
				}
				if (num / num2 > tickInfo.MaxTicks)
				{
					num2 = 200;
				}
				if (num / num2 > tickInfo.MaxTicks)
				{
					num2 = 200;
				}
				num3 = (int)Math.Log10(tickInfo.Min);
			}
			else
			{
				num3 = (int)Math.Log10(tickInfo.Min);
			}
			tickInfo.MajorStepSize = Math.Pow(10.0, (double)num2);
			tickInfo.MinorStepSize = tickInfo.MajorStepSize / (double)(tickInfo.MinorCount + 1);
			m_MinorStepSize = tickInfo.MinorStepSize;
			double num4 = Math.Pow(10.0, (double)num3);
			double num5 = GetStopValue(tickInfo);
			if (!Display.SlidingScale)
			{
				num5 = Display.Range.Max;
			}
			while (true)
			{
				if (Math2.InRangeDelta(num4, tickInfo.Min, tickInfo.Max) && num4 > 0.0)
				{
					tickInfo.Display.AddTickMajor(num4, false);
				}
				if (!(num4 >= num5))
				{
					tickInfo.MinorStepSize = num4 * 10.0 / (double)(tickInfo.MinorCount + 1);
					for (int i = 1; i <= 9; i++)
					{
						double num6 = num4 * (double)i;
						if (num6 > num5)
						{
							return;
						}
						if (Math2.InRangeDelta(num4, tickInfo.Min, tickInfo.Max) && num4 > 0.0)
						{
							if (tickInfo.MidIncluded && i == tickInfo.MinorCount / 2)
							{
								tickInfo.Display.AddTickMid(num6, false);
							}
							else
							{
								tickInfo.Display.AddTickMinor(num6, false);
							}
						}
					}
					num3++;
					num4 = Math.Pow(10.0, (double)num3);
					continue;
				}
				break;
			}
		}

		protected virtual void Generate(PaintArgs p, ScaleTickInfo tickInfo)
		{
			if (tickInfo.ScaleType == ScaleType.Log10)
			{
				GenerateLog10(p, tickInfo);
			}
			else
			{
				if (tickInfo.ScaleType == ScaleType.Linear)
				{
					CalculateMajorTicks(tickInfo);
				}
				m_MinorStepSize = tickInfo.MinorStepSize;
				tickInfo.Display.MajorIncrement = tickInfo.MajorStepSize;
				tickInfo.Display.MinorIncrement = tickInfo.MinorStepSize;
				double num = GetStartValue(tickInfo);
				double stopValue = GetStopValue(tickInfo);
				if (tickInfo.MinorStepSize != 0.0 && num != num + tickInfo.MinorStepSize)
				{
					while (true)
					{
						if (Math2.InRangeDelta(num, tickInfo.Min - tickInfo.Max * 0.0001, tickInfo.Max + tickInfo.Max * 0.0001))
						{
							tickInfo.Display.AddTickMajor(num, false);
						}
						if (!(num >= stopValue))
						{
							for (int i = 0; i < tickInfo.MinorCount; i++)
							{
								num += tickInfo.MinorStepSize;
								if (Math2.InRangeDelta(num, tickInfo.Min, tickInfo.Max))
								{
									if (tickInfo.MidIncluded && i == tickInfo.MinorCount / 2)
									{
										tickInfo.Display.AddTickMid(num, false);
									}
									else
									{
										tickInfo.Display.AddTickMinor(num, false);
									}
								}
							}
							num += tickInfo.MinorStepSize;
							continue;
						}
						break;
					}
				}
				else
				{
					ScaleTickMajor scaleTickMajor = tickInfo.Display.AddTickMajor(Display.Range.Mid, false);
					scaleTickMajor.Value = Display.Range.Mid;
					scaleTickMajor.Text = "Out of Range";
				}
			}
		}
	}
}
