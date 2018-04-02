using System.ComponentModel;

namespace Iocomp.Classes
{
	public sealed class ScaleRangeDiscreetAngular : SubClassBase
	{
		private double m_AngleMin;

		private double m_AngleSpan;

		private bool m_Reverse;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
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
				return Math2.AngleNormalized(m_AngleMin - m_AngleSpan);
			}
		}

		[Category("Iocomp")]
		[Description("")]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies if the direction of the scale is reversed")]
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

		protected override string GetPlugInTitle()
		{
			return "Scale Range";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleRangeDiscreetAngularEditorPlugIn";
		}

		public ScaleRangeDiscreetAngular()
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

		private bool ShouldSerializeReverse()
		{
			return base.PropertyShouldSerialize("Reverse");
		}

		private void ResetReverse()
		{
			base.PropertyReset("Reverse");
		}

		public double ValueToAngle(int value, int count)
		{
			if (count < 2)
			{
				return AngleMin;
			}
			if (!Reverse)
			{
				return Math2.AngleNormalized(360.0 - (AngleMin - (double)value * AngleSpan / (double)(count - 1)));
			}
			return Math2.AngleNormalized(360.0 - (AngleMax + (double)value * AngleSpan / (double)(count - 1)));
		}
	}
}
