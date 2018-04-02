using Iocomp.Types;
using System.ComponentModel;

namespace Iocomp.Classes
{
	public abstract class ScaleRange : SubClassBase
	{
		private double m_Min;

		private double m_Span;

		private bool m_Reverse;

		private ScaleType m_ScaleType;

		private double m_SplitStart;

		private double m_SplitPercent;

		private bool m_LimitMinLowerEnabled;

		private double m_LimitMinLowerValue;

		private bool m_LimitMaxUpperEnabled;

		private double m_LimitMaxUpperValue;

		private bool m_LimitSpanLowerEnabled;

		private double m_LimitSpanLowerValue;

		private bool m_LimitSpanUpperEnabled;

		private double m_LimitSpanUpperValue;

		public bool LimitsEnforced
		{
			get
			{
				bool flag = false;
				if (LimitMinLowerEnabled)
				{
					flag = true;
				}
				if (LimitMaxUpperEnabled)
				{
					flag = true;
				}
				if (LimitSpanLowerEnabled)
				{
					flag = true;
				}
				if (LimitSpanUpperEnabled)
				{
					flag = true;
				}
				if (!flag)
				{
					return false;
				}
				if (LimitMinLowerEnabled && LimitMaxUpperEnabled)
				{
					double num = LimitMaxUpperValue - LimitMinLowerValue;
					if (num <= 0.0)
					{
						return false;
					}
					if (num < LimitSpanLowerValue)
					{
						return false;
					}
				}
				else if (LimitSpanLowerEnabled && LimitSpanUpperEnabled && LimitSpanLowerValue > LimitSpanUpperValue)
				{
					return false;
				}
				return true;
			}
		}

		public double LimitSpanUpperActual
		{
			get
			{
				if (LimitSpanUpperEnforced)
				{
					if (LimitMinLowerEnabled && LimitMaxUpperEnabled)
					{
						return LimitMaxUpperActual - LimitMinLowerActual;
					}
					return LimitSpanUpperValue;
				}
				return 1E+300;
			}
		}

		[Description("Specifies the minimum value the scale will show.")]
		[RefreshProperties(RefreshProperties.All)]
		public double Min
		{
			get
			{
				if (ScaleType == ScaleType.Log10 && m_Min < 1E-300)
				{
					m_Min = 1.0;
				}
				return m_Min;
			}
			set
			{
				if (value > 1E+300)
				{
					value = 1E+300;
				}
				if (value < -1E+300)
				{
					value = -1E+300;
				}
				base.PropertyUpdateDefault("Min", value);
				if (LimitMinLowerEnforced && value < LimitMinLowerValue)
				{
					value = LimitMinLowerValue;
				}
				if (LimitMaxUpperEnforced && value + Span > LimitMaxUpperActual)
				{
					value = LimitMaxUpperActual - Span;
				}
				if (Min != value)
				{
					m_Min = value;
					base.DoPropertyChange(this, "Min");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the range of the scale.")]
		public double Span
		{
			get
			{
				if (m_Span < 1E-300)
				{
					m_Span = 1E-300;
				}
				return m_Span;
			}
			set
			{
				if (value > 1E+300)
				{
					value = 1E+300;
				}
				if (value < 1E-300)
				{
					value = 1E-300;
				}
				if (LimitSpanLowerEnabled && value < LimitSpanLowerValue)
				{
					value = LimitSpanLowerValue;
				}
				if (LimitSpanUpperEnabled && value > LimitSpanUpperValue)
				{
					value = LimitSpanUpperValue;
				}
				base.PropertyUpdateDefault("Span", value);
				if (Span != value)
				{
					m_Span = value;
					base.DoPropertyChange(this, "Span");
					if (LimitMaxUpperEnforced && Max > LimitMaxUpperValue)
					{
						Min = Max - Span;
					}
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Indicates the maximum value the scale will show.")]
		public double Max
		{
			get
			{
				if (ScaleType == ScaleType.Log10 && m_Min < 1E-300)
				{
					m_Min = 1.0;
				}
				if (m_Span < 1E-300)
				{
					m_Span = 1E-300;
				}
				return m_Min + m_Span;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Indicates the middle value of the scale.")]
		public double Mid
		{
			get
			{
				if (ScaleType == ScaleType.Log10 && m_Min < 1E-300)
				{
					m_Min = 1.0;
				}
				if (m_Span < 1E-300)
				{
					m_Span = 1E-300;
				}
				return m_Min + m_Span / 2.0;
			}
		}

		[Description("Specifies if the direction of the scale is reversed.")]
		[RefreshProperties(RefreshProperties.All)]
		public bool Reverse
		{
			get
			{
				return m_Reverse;
			}
			set
			{
				base.PropertyUpdateDefault("Reverse", value);
				if (Reverse != value)
				{
					m_Reverse = value;
					base.DoPropertyChange(this, "Reverse");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public ScaleType ScaleType
		{
			get
			{
				return m_ScaleType;
			}
			set
			{
				base.PropertyUpdateDefault("ScaleType", value);
				if (ScaleType != value)
				{
					m_ScaleType = value;
					base.DoPropertyChange(this, "ScaleType");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the value where the linear scale ends and the split scale starts.")]
		public double SplitStart
		{
			get
			{
				return m_SplitStart;
			}
			set
			{
				if (value > 1E+300)
				{
					value = 1E+300;
				}
				if (value <= 0.0)
				{
					value = 1.0;
				}
				base.PropertyUpdateDefault("SplitStart", value);
				if (SplitStart != value)
				{
					m_SplitStart = value;
					base.DoPropertyChange(this, "SplitStart");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the percent of the scale height or width, depending on the scale orientation that is reserved for the non-linear split.")]
		public double SplitPercent
		{
			get
			{
				return m_SplitPercent;
			}
			set
			{
				if (value > 1.0)
				{
					value = 1.0;
				}
				if (value < 0.0)
				{
					value = 0.0;
				}
				base.PropertyUpdateDefault("SplitPercent", value);
				if (SplitPercent != value)
				{
					m_SplitPercent = value;
					base.DoPropertyChange(this, "SplitPercent");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Determines if the Min property is limited on the lower end.")]
		public bool LimitMinLowerEnabled
		{
			get
			{
				return m_LimitMinLowerEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("LimitMinLowerEnabled", value);
				if (LimitMinLowerEnabled != value)
				{
					m_LimitMinLowerEnabled = value;
					base.DoPropertyChange(this, "LimitMinLowerEnabled");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Determines if the Max property is limited on the upper end.")]
		public bool LimitMaxUpperEnabled
		{
			get
			{
				return m_LimitMaxUpperEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("LimitMaxUpperEnabled", value);
				if (LimitMaxUpperEnabled != value)
				{
					m_LimitMaxUpperEnabled = value;
					base.DoPropertyChange(this, "LimitMaxUpperEnabled");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Determines if the Span property is limited on the lower end.")]
		public bool LimitSpanLowerEnabled
		{
			get
			{
				return m_LimitSpanLowerEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("LimitSpanLowerEnabled", value);
				if (LimitSpanLowerEnabled != value)
				{
					m_LimitSpanLowerEnabled = value;
					base.DoPropertyChange(this, "LimitSpanLowerEnabled");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Determines if the Span property is limited on the upper end.")]
		public bool LimitSpanUpperEnabled
		{
			get
			{
				return m_LimitSpanUpperEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("LimitSpanUpperEnabled", value);
				if (LimitSpanUpperEnabled != value)
				{
					m_LimitSpanUpperEnabled = value;
					base.DoPropertyChange(this, "LimitSpanUpperEnabled");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the value of the Min lower limit.")]
		public double LimitMinLowerValue
		{
			get
			{
				return m_LimitMinLowerValue;
			}
			set
			{
				base.PropertyUpdateDefault("LimitMinLowerValue", value);
				if (LimitMinLowerValue != value)
				{
					m_LimitMinLowerValue = value;
					base.DoPropertyChange(this, "LimitMinLowerValue");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the value of the Max upper limit.")]
		public double LimitMaxUpperValue
		{
			get
			{
				return m_LimitMaxUpperValue;
			}
			set
			{
				base.PropertyUpdateDefault("LimitMaxUpperValue", value);
				if (LimitMaxUpperValue != value)
				{
					m_LimitMaxUpperValue = value;
					base.DoPropertyChange(this, "LimitMaxUpperValue");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the value of the Span lower limit.")]
		public double LimitSpanLowerValue
		{
			get
			{
				return m_LimitSpanLowerValue;
			}
			set
			{
				if (value < 1E-300)
				{
					value = 1E-300;
				}
				base.PropertyUpdateDefault("LimitSpanLowerValue", value);
				if (LimitSpanLowerValue != value)
				{
					m_LimitSpanLowerValue = value;
					base.DoPropertyChange(this, "LimitSpanLowerValue");
				}
			}
		}

		[Description("Specifies the value of the Span upper limit.")]
		[RefreshProperties(RefreshProperties.All)]
		public double LimitSpanUpperValue
		{
			get
			{
				return m_LimitSpanUpperValue;
			}
			set
			{
				if (value < 1E-300)
				{
					value = 1E-300;
				}
				base.PropertyUpdateDefault("LimitSpanUpperValue", value);
				if (LimitSpanUpperValue != value)
				{
					m_LimitSpanUpperValue = value;
					base.DoPropertyChange(this, "LimitSpanUpperValue");
				}
			}
		}

		public double LimitMinLowerActual
		{
			get
			{
				if (LimitMinLowerEnabled)
				{
					return LimitMinLowerValue;
				}
				return -1E+300;
			}
		}

		public double LimitMaxUpperActual
		{
			get
			{
				if (LimitMaxUpperEnabled)
				{
					return LimitMaxUpperValue;
				}
				return 1E+300;
			}
		}

		public double LimitSpanLowerActual
		{
			get
			{
				if (LimitSpanLowerEnabled)
				{
					return LimitSpanLowerValue;
				}
				return 1E-300;
			}
		}

		private bool LimitMinLowerEnforced
		{
			get
			{
				if (!LimitsEnforced)
				{
					return false;
				}
				return LimitMinLowerEnabled;
			}
		}

		private bool LimitMaxUpperEnforced
		{
			get
			{
				if (!LimitsEnforced)
				{
					return false;
				}
				return LimitMaxUpperEnabled;
			}
		}

		private bool LimitSpanLowerEnforced
		{
			get
			{
				if (!LimitsEnforced)
				{
					return false;
				}
				return LimitSpanLowerEnabled;
			}
		}

		private bool LimitSpanUpperEnforced
		{
			get
			{
				if (!LimitsEnforced)
				{
					return false;
				}
				return LimitSpanUpperEnabled;
			}
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			ScaleType = ScaleType.Linear;
			SplitPercent = 0.5;
			SplitStart = 50.0;
			LimitMinLowerEnabled = false;
			LimitMinLowerValue = 0.0;
			LimitMaxUpperEnabled = false;
			LimitMaxUpperValue = 100.0;
			LimitSpanLowerEnabled = false;
			LimitSpanLowerValue = 1E-300;
			LimitSpanUpperEnabled = false;
			LimitSpanUpperValue = 1E+300;
		}

		[Description("")]
		public void AdjustSpanUsingMidReference(double desiredSpan)
		{
			if (desiredSpan != Span)
			{
				double min = Mid - desiredSpan / 2.0;
				if (NotLimited(min, desiredSpan))
				{
					SetMinSpanNotLimited(min, desiredSpan);
				}
				else
				{
					AdjustSpanWhenLimited(desiredSpan);
				}
			}
		}

		[Description("")]
		public void SetMinSpan(double newMin, double newSpan)
		{
			if (NotLimited(newMin, newSpan))
			{
				SetMinSpanNotLimited(newMin, newSpan);
			}
			else
			{
				Span = newSpan;
				Min = newMin;
			}
		}

		[Description("")]
		public void SetMinMax(double min, double max)
		{
			Span = max - min;
			Min = min;
		}

		[Description("")]
		public void SetMaxSpan(double max, double span)
		{
			Span = span;
			Min = max - span;
		}

		private bool ShouldSerializeMin()
		{
			return base.PropertyShouldSerialize("Min");
		}

		private void ResetMin()
		{
			base.PropertyReset("Min");
		}

		private bool ShouldSerializeSpan()
		{
			return base.PropertyShouldSerialize("Span");
		}

		private void ResetSpan()
		{
			base.PropertyReset("Span");
		}

		public void SetSpan(int hours, int minutes, int seconds, int milliseconds)
		{
			Span = (double)hours * 1.0 / 24.0 + (double)minutes * 1.0 / 1440.0 + (double)seconds * 1.0 / 86400.0 + (double)milliseconds * 1.0 / 86400000.0;
		}

		private bool ShouldSerializeReverse()
		{
			return base.PropertyShouldSerialize("Reverse");
		}

		private void ResetReverse()
		{
			base.PropertyReset("Reverse");
		}

		private bool ShouldSerializeScaleType()
		{
			return base.PropertyShouldSerialize("ScaleType");
		}

		private void ResetScaleType()
		{
			base.PropertyReset("ScaleType");
		}

		private bool ShouldSerializeSplitStart()
		{
			return base.PropertyShouldSerialize("SplitStart");
		}

		private void ResetSplitStart()
		{
			base.PropertyReset("SplitStart");
		}

		private bool ShouldSerializeSplitPercent()
		{
			return base.PropertyShouldSerialize("SplitPercent");
		}

		private void ResetSplitPercent()
		{
			base.PropertyReset("SplitPercent");
		}

		private bool ShouldSerializeLimitMinLowerEnabled()
		{
			return base.PropertyShouldSerialize("LimitMinLowerEnabled");
		}

		private void ResetLimitMinLowerEnabled()
		{
			base.PropertyReset("LimitMinLowerEnabled");
		}

		private bool ShouldSerializeLimitMaxUpperEnabled()
		{
			return base.PropertyShouldSerialize("LimitMaxUpperEnabled");
		}

		private void ResetLimitMaxUpperEnabled()
		{
			base.PropertyReset("LimitMaxUpperEnabled");
		}

		private bool ShouldSerializeLimitSpanLowerEnabled()
		{
			return base.PropertyShouldSerialize("LimitSpanLowerEnabled");
		}

		private void ResetLimitSpanLowerEnabled()
		{
			base.PropertyReset("LimitSpanLowerEnabled");
		}

		private bool ShouldSerializeLimitSpanUpperEnabled()
		{
			return base.PropertyShouldSerialize("LimitSpanUpperEnabled");
		}

		private void ResetLimitSpanUpperEnabled()
		{
			base.PropertyReset("LimitSpanUpperEnabled");
		}

		private bool ShouldSerializeLimitMinLowerValue()
		{
			return base.PropertyShouldSerialize("LimitMinLowerValue");
		}

		private void ResetLimitMinLowerValue()
		{
			base.PropertyReset("LimitMinLowerValue");
		}

		private bool ShouldSerializeLimitMaxUpperValue()
		{
			return base.PropertyShouldSerialize("LimitMaxUpperValue");
		}

		private void ResetLimitMaxUpperValue()
		{
			base.PropertyReset("LimitMaxUpperValue");
		}

		private bool ShouldSerializeLimitSpanLowerValue()
		{
			return base.PropertyShouldSerialize("LimitSpanLowerValue");
		}

		private void ResetLimitSpanLowerValue()
		{
			base.PropertyReset("LimitSpanLowerValue");
		}

		private bool ShouldSerializeLimitSpanUpperValue()
		{
			return base.PropertyShouldSerialize("LimitSpanUpperValue");
		}

		private void ResetLimitSpanUpperValue()
		{
			base.PropertyReset("LimitSpanUpperValue");
		}

		[Description("Converts a percent value to a scale value. Percent is in (0.0-1.0) form.")]
		public double PercentToValue(double percent)
		{
			return percent * Span + Min;
		}

		[Description("Converts a relative percent span to a range in axis value units. Percent is in (0.0-1.0) form.")]
		public double PercentSpanToValue(double percent)
		{
			return percent * Span;
		}

		[Description("Converts a scale value to a percent value. Percent is in (0.0-1.0) form.")]
		public double ValueToPercent(double value)
		{
			return (value - Min) / Span;
		}

		[Description("Converts a relative span in value units to a relative span in percent units. Percent is in (0.0-1.0) form.")]
		public double ValueSpanToPercent(double value)
		{
			return value / Span;
		}

		[Description("Returns a True or False to indicate if the value is on the Range (Min <= Value <= Max)")]
		public bool OnRange(double value)
		{
			if (value >= Min && value <= Max)
			{
				return true;
			}
			return false;
		}

		private void AdjustSpanWhenLimited(double desiredSpan)
		{
			double num = desiredSpan - Span;
			if (num != 0.0)
			{
				if (num < 0.0)
				{
					Span = desiredSpan;
				}
				else
				{
					double num2 = Min - num;
					double num3 = Max + num;
					double num4 = desiredSpan;
					if (num4 > LimitSpanUpperActual)
					{
						num4 = LimitSpanUpperActual;
					}
					if (num3 > LimitMaxUpperActual)
					{
						SetMinSpan(LimitMaxUpperActual - num4, num4);
					}
					else if (num2 < LimitMinLowerActual)
					{
						SetMinSpan(LimitMinLowerActual, num4);
					}
					else
					{
						SetMinSpan(num2, num4);
					}
				}
			}
		}

		private void SetMinSpanNotLimited(double min, double span)
		{
			if (Min == min && Span == span)
			{
				return;
			}
			base.PropertyUpdateDefault("Min", min);
			if (Min != min)
			{
				if (min > 1E+300)
				{
					min = 1E+300;
				}
				if (min < -1E+300)
				{
					min = -1E+300;
				}
				if (m_Min != min)
				{
					m_Min = min;
					base.DoPropertyChange(this, "Min");
				}
			}
			base.PropertyUpdateDefault("Span", span);
			if (Span != span)
			{
				if (span > 1E+300)
				{
					span = 1E+300;
				}
				if (span < 1E-300)
				{
					span = 1E-300;
				}
				if (m_Span != span)
				{
					m_Span = span;
					base.DoPropertyChange(this, "Span");
				}
			}
		}

		private bool NotLimited(double min, double span)
		{
			return NotLimited(min, min + span, span);
		}

		private bool NotLimited(double min, double max, double span)
		{
			if (LimitMinLowerEnabled && min < LimitMinLowerValue)
			{
				return false;
			}
			if (LimitMaxUpperEnabled && max > LimitMaxUpperValue)
			{
				return false;
			}
			if (LimitSpanLowerEnabled && span < LimitSpanLowerValue)
			{
				return false;
			}
			if (LimitSpanUpperEnabled && span > LimitSpanUpperValue)
			{
				return false;
			}
			return true;
		}
	}
}
