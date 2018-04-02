using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;

namespace Iocomp.Classes
{
	public sealed class ScaleRangeAngular : ScaleRange, IScaleRangeAngular
	{
		private double m_AngleMin;

		private double m_AngleSpan;

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public double AngleMin
		{
			get
			{
				return m_AngleMin;
			}
			set
			{
				base.PropertyUpdateDefault("AngleMin", value);
				if (AngleMin != value)
				{
					m_AngleMin = value;
					base.DoPropertyChange(this, "AngleMin");
				}
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public double AngleMax
		{
			get
			{
				return Math2.AngleNormalized((m_AngleMin - m_AngleSpan) % 360.0);
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public double AngleSpan
		{
			get
			{
				return m_AngleSpan;
			}
			set
			{
				base.PropertyUpdateDefault("AngleSpan", value);
				if (value < 0.0)
				{
					base.ThrowStreamingSafeException("AngleSpan value must be 0 or greater.");
				}
				if (value < 0.0)
				{
					value = 0.0;
				}
				if (value > 360.0)
				{
					base.ThrowStreamingSafeException("AngleSpan value must be 360 or less.");
				}
				if (value > 360.0)
				{
					value = 360.0;
				}
				if (AngleSpan != value)
				{
					m_AngleSpan = value;
					base.DoPropertyChange(this, "AngleSpan");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Scale Range";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleRangeAngularEditorPlugIn";
		}

		public ScaleRangeAngular()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeAngleMin()
		{
			return base.PropertyShouldSerialize("AngleMin");
		}

		private void ResetAngleMin()
		{
			base.PropertyReset("AngleMin");
		}

		private bool ShouldSerializeAngleSpan()
		{
			return base.PropertyShouldSerialize("AngleSpan");
		}

		private void ResetAngleSpan()
		{
			base.PropertyReset("AngleSpan");
		}

		[Description("")]
		public double ValueToAngle(double value)
		{
			double num;
			if (base.ScaleType == ScaleType.Linear)
			{
				num = (value - base.Min) / base.Span;
			}
			else if (base.ScaleType == ScaleType.Log10)
			{
				num = (Math.Log10(value) - Math.Log10(base.Min)) / (Math.Log10(base.Max) - Math.Log10(base.Min));
				if (double.IsNaN(num))
				{
					num = 1.0;
				}
			}
			else
			{
				if (value < base.SplitStart)
				{
					num = (value - base.Min) / base.SplitStart * base.SplitPercent;
				}
				else
				{
					num = (Math.Log10(value) - Math.Log10(base.SplitStart)) / (Math.Log10(base.Max) - Math.Log10(base.SplitStart));
					num /= 2.0;
					num += base.SplitPercent;
				}
				if (double.IsNaN(num))
				{
					num = 1.0;
				}
			}
			if (!base.Reverse)
			{
				return 360.0 - (AngleMin - num * AngleSpan);
			}
			return 360.0 - (AngleMax + num * AngleSpan);
		}

		[Description("")]
		public double AngleToValue(double value)
		{
			double num = 360.0 - value;
			double num2 = base.Reverse ? (num - AngleMax) : (AngleMin - num);
			if (num2 < (0.0 - (360.0 - AngleSpan)) / 2.0)
			{
				num2 += 360.0;
			}
			return num2 / AngleSpan * base.Span + base.Min;
		}

		[Description("")]
		public double PercentToAngle(double value)
		{
			return ValueToAngle(base.PercentToValue(value));
		}

		[Description("")]
		public double ValueToSpanAngle(double value)
		{
			return ValueToAngle(value) - ValueToAngle(0.0);
		}

		[Description("")]
		public double PercentToSpanAngle(double value)
		{
			return PercentToAngle(value) - PercentToAngle(0.0);
		}
	}
}
