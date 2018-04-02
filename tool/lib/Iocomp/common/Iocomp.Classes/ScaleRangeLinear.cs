using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("ScaleDisplayLinear")]
	public sealed class ScaleRangeLinear : ScaleRange, IScaleRangeLinear
	{
		private int m_PixelsMin;

		private int m_PixelsMax;

		private int m_PixelsSpan;

		private int m_PixelsCenter;

		protected override string GetPlugInTitle()
		{
			return "Scale Range";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleRangeLinearEditorPlugIn";
		}

		void IScaleRangeLinear.SetBounds(int pixelsMin, int pixelsMax)
		{
			SetBounds(pixelsMin, pixelsMax);
		}

		public ScaleRangeLinear()
		{
			base.DoCreate();
		}

		private void SetBounds(int pixelsMin, int pixelsMax)
		{
			m_PixelsMin = pixelsMin;
			m_PixelsMax = pixelsMax;
			m_PixelsCenter = (pixelsMax + pixelsMin) / 2;
			m_PixelsSpan = pixelsMax - pixelsMin;
		}

		[Description("")]
		public int ValueToPixels(double value, bool clamped)
		{
			if (clamped)
			{
				if (value < base.Min)
				{
					value = base.Min;
				}
				else if (value > base.Max)
				{
					value = base.Max;
				}
			}
			return ValueToPixels(value);
		}

		[Description("")]
		public int ValueToPixels(double value)
		{
			double num2;
			if (base.ScaleType == ScaleType.Linear)
			{
				double num = (value - base.Min) / base.Span;
				num2 = ((!base.Reverse) ? ((double)m_PixelsMin + num * (double)m_PixelsSpan) : ((double)m_PixelsMax - num * (double)m_PixelsSpan));
			}
			else if (base.ScaleType == ScaleType.Log10)
			{
				if (value < 1E-300)
				{
					value = 1E-300;
				}
				double num = (Math.Log10(value) - Math.Log10(base.Min)) / (Math.Log10(base.Max) - Math.Log10(base.Min));
				num2 = ((!base.Reverse) ? ((double)m_PixelsMin + num * (double)m_PixelsSpan) : ((double)m_PixelsMax - num * (double)m_PixelsSpan));
			}
			else
			{
				double num3 = (double)m_PixelsSpan * base.SplitPercent;
				double num4 = (double)m_PixelsSpan * (1.0 - base.SplitPercent);
				double num5 = (double)m_PixelsMin + num3;
				if (value <= base.SplitStart)
				{
					double num6 = base.SplitStart - base.Min;
					double num = (value - base.Min) / num6;
					num2 = ((!base.Reverse) ? ((double)m_PixelsMin + num * num3) : ((double)m_PixelsMax - num * num3));
				}
				else
				{
					if (value < 1E-300)
					{
						value = 1E-300;
					}
					num4 = (double)m_PixelsSpan * (1.0 - base.SplitPercent);
					double num = (Math.Log10(value) - Math.Log10(base.SplitStart)) / (Math.Log10(base.Max) - Math.Log10(base.SplitStart));
					num2 = ((!base.Reverse) ? (num5 + num * num4) : (num5 - num * num4));
				}
			}
			if (double.IsNaN(num2))
			{
				num2 = (double)((m_PixelsMax + m_PixelsMin) / 2);
			}
			if (num2 > 32768.0)
			{
				return 32768;
			}
			if (num2 < -32768.0)
			{
				return -32768;
			}
			return (int)Math.Round(num2);
		}

		[Description("")]
		public double PixelsToValue(int value)
		{
			if (m_PixelsSpan == 0)
			{
				return base.Mid;
			}
			double num = (!base.Reverse) ? ((double)(value - m_PixelsMin) / (double)m_PixelsSpan) : ((double)(m_PixelsMax - value) / (double)m_PixelsSpan);
			if (base.ScaleType == ScaleType.Linear)
			{
				return num * base.Span + base.Min;
			}
			double num2 = Math.Log10(base.Min);
			return Math.Pow(10.0, num * (Math.Log10(base.Max) - num2) + num2);
		}

		[Description("")]
		public double PixelSpanToValue(int value)
		{
			if (m_PixelsSpan == 0)
			{
				return base.Mid;
			}
			double num = (double)value / (double)Math.Abs(m_PixelsSpan);
			if (base.ScaleType == ScaleType.Linear)
			{
				return num * base.Span;
			}
			double num2 = Math.Log10(base.Min);
			return Math.Pow(10.0, num * (Math.Log10(base.Max) - num2));
		}

		[Description("")]
		public double PixelSpanToPercent(int value)
		{
			if (m_PixelsSpan == 0)
			{
				return 0.5;
			}
			return (double)value / (double)m_PixelsSpan;
		}

		[Description("")]
		public double ValueToPercent(double value, bool clamped)
		{
			if (clamped)
			{
				if (value < base.Min)
				{
					value = base.Min;
				}
				else if (value > base.Max)
				{
					value = base.Max;
				}
			}
			return base.ValueToPercent(value);
		}

		[Description("")]
		public int PercentToPixels(double value, bool clamped)
		{
			return ValueToPixels(base.PercentToValue(value), clamped);
		}

		[Description("")]
		public double PercentToValue(double value, bool clamped)
		{
			if (clamped)
			{
				if (value < base.Min)
				{
					value = base.Min;
				}
				else if (value > base.Max)
				{
					value = base.Max;
				}
			}
			return base.PercentToValue(value);
		}

		[Description("")]
		public double PixelsToPercent(int value)
		{
			return base.ValueToPercent(PixelsToValue(value));
		}

		[Description("")]
		public int ValueToSpanPixels(double value)
		{
			return Math.Abs(ValueToPixels(base.Min + value) - ValueToPixels(base.Min));
		}

		[Description("")]
		public int PercentToSpanPixels(double value)
		{
			return Math.Abs(PercentToPixels(value, false) - PercentToPixels(0.0, false));
		}
	}
}
