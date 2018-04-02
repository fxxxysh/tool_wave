using Iocomp.Delegates;
using Iocomp.Design;
using System;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(ValueDoubleTypeConverter))]
	public sealed class ValueDouble : Value, IConvertible, IComparable
	{
		private double m_Value;

		private double m_Max;

		private double m_Min;

		private double m_ValueOld;

		[Description("Value specified as a double.")]
		[RefreshProperties(RefreshProperties.All)]
		public double AsDouble
		{
			get
			{
				return m_Value;
			}
			set
			{
				base.PropertyUpdateDefault("AsDouble", value);
				double num;
				if (AsDouble != value)
				{
					ValueDoubleEventArgs valueDoubleEventArgs = null;
					num = value;
					if (ShouldEnforceMinMax)
					{
						if (num > Max)
						{
							num = Max;
						}
						if (num < Min)
						{
							num = Min;
						}
					}
					if (base.ShouldTriggerEvents)
					{
						valueDoubleEventArgs = new ValueDoubleEventArgs(m_Value, num, false, base.EventSource);
						OnBeforeChangeEvent(valueDoubleEventArgs);
						if (!valueDoubleEventArgs.Cancel)
						{
							num = valueDoubleEventArgs.ValueNew;
							if (ShouldEnforceMinMax)
							{
								if (num > Max)
								{
									num = Max;
								}
								if (num < Min)
								{
									num = Min;
								}
							}
							goto IL_00a2;
						}
						return;
					}
					goto IL_00a2;
				}
				return;
				IL_00a2:
				if (AsDouble != num)
				{
					m_Value = num;
					base.DoPropertyChange(this, "AsDouble");
					if (base.ShouldTriggerEvents)
					{
						ValueDoubleEventArgs valueDoubleEventArgs = new ValueDoubleEventArgs(m_Value, m_Value, false, base.EventSource);
						OnChangedEvent(valueDoubleEventArgs);
					}
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the maximum value allowed.")]
		public double Max
		{
			get
			{
				return m_Max;
			}
			set
			{
				base.PropertyUpdateDefault("Max", value);
				if (Max != value)
				{
					m_Max = value;
					if (ShouldEnforceMinMax && AsDouble > m_Max)
					{
						AsDouble = m_Max;
					}
					base.DoPropertyChange(this, "Max");
				}
			}
		}

		[Description("Specifies the minimum value allowed.")]
		[RefreshProperties(RefreshProperties.All)]
		public double Min
		{
			get
			{
				return m_Min;
			}
			set
			{
				base.PropertyUpdateDefault("Min", value);
				if (Min != value)
				{
					m_Min = value;
					if (ShouldEnforceMinMax && AsDouble < m_Min)
					{
						AsDouble = m_Min;
					}
					base.DoPropertyChange(this, "Min");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Value specified as a string.")]
		public override string AsString
		{
			get
			{
				return Convert2.ToString(m_Value);
			}
			set
			{
				base.PropertyUpdateDefault("AsString", value);
				AsDouble = Convert2.ToDouble(value);
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Value specified as a integer.")]
		[RefreshProperties(RefreshProperties.All)]
		public int AsInteger
		{
			get
			{
				return (int)m_Value;
			}
			set
			{
				base.PropertyUpdateDefault("AsInteger", value);
				AsDouble = (double)value;
			}
		}

		[Description("Value specified as a integer.")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DateTime AsDateTime
		{
			get
			{
				return Math2.DoubleToDateTime(m_Value);
			}
			set
			{
				base.PropertyUpdateDefault("AsDateTime", value);
				AsDouble = Math2.DateTimeToDouble(value);
			}
		}

		private bool ShouldEnforceMinMax
		{
			get
			{
				if (Max == 0.0 && Min == 0.0)
				{
					return false;
				}
				if (ComponentBase != null && ComponentBase.Creating)
				{
					return false;
				}
				if (ComponentBase != null && ComponentBase.Loading)
				{
					return false;
				}
				return true;
			}
		}

		[Browsable(false)]
		public event ValueDoubleEventHandler Changing;

		[Browsable(false)]
		public event ValueDoubleEventHandler Changed;

		public event ValueDoubleEventHandler UserChangeFinished;

		protected override string GetPlugInTitle()
		{
			return "Value Double";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ValueDoubleEditorPlugIn";
		}

		public ValueDouble()
		{
			base.DoCreate();
		}

		public ValueDouble(string value)
		{
			base.DoCreate();
			AsString = value;
		}

		public ValueDouble(double value)
		{
			base.DoCreate();
			AsDouble = value;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			AsDouble = 0.0;
			AsInteger = AsInteger;
			AsString = AsString;
			AsDateTime = AsDateTime;
			Max = 0.0;
			Min = 0.0;
		}

		public void BeginUserUpdate()
		{
			m_ValueOld = AsDouble;
		}

		public void EndUserUpdate()
		{
			ValueDoubleEventArgs valueDoubleEventArgs = null;
			if (m_ValueOld != AsDouble && base.ShouldTriggerEvents)
			{
				valueDoubleEventArgs = new ValueDoubleEventArgs(m_ValueOld, AsDouble, false, base.EventSource);
				OnUserChangeFinished(valueDoubleEventArgs);
			}
		}

		private bool ShouldSerializeAsDouble()
		{
			return base.PropertyShouldSerialize("AsDouble");
		}

		private void ResetAsDouble()
		{
			base.PropertyReset("AsDouble");
		}

		private bool ShouldSerializeMax()
		{
			return base.PropertyShouldSerialize("Max");
		}

		private void ResetMax()
		{
			base.PropertyReset("Max");
		}

		private bool ShouldSerializeMin()
		{
			return base.PropertyShouldSerialize("Min");
		}

		private void ResetMin()
		{
			base.PropertyReset("Min");
		}

		private bool ShouldSerializeAsString()
		{
			return base.PropertyShouldSerialize("AsString");
		}

		private void ResetAsString()
		{
			base.PropertyReset("AsString");
		}

		private bool ShouldSerializeAsInteger()
		{
			return base.PropertyShouldSerialize("AsInteger");
		}

		private void ResetAsInteger()
		{
			base.PropertyReset("AsInteger");
		}

		private bool ShouldSerializeAsDateTime()
		{
			return base.PropertyShouldSerialize("AsDateTime");
		}

		private void ResetAsDateTime()
		{
			base.PropertyReset("AsDateTime");
		}

		private void OnBeforeChangeEvent(ValueDoubleEventArgs e)
		{
			if (this.Changing != null)
			{
				this.Changing(this, e);
			}
		}

		private void OnChangedEvent(ValueDoubleEventArgs e)
		{
			if (this.Changed != null)
			{
				this.Changed(this, e);
			}
		}

		private void OnUserChangeFinished(ValueDoubleEventArgs e)
		{
			if (this.UserChangeFinished != null)
			{
				this.UserChangeFinished(this, e);
			}
		}

		public static implicit operator ValueDouble(double value)
		{
			ValueDouble valueDouble = new ValueDouble();
			valueDouble.AsDouble = value;
			return valueDouble;
		}

		public static implicit operator ValueDouble(int value)
		{
			ValueDouble valueDouble = new ValueDouble();
			valueDouble.AsInteger = value;
			return valueDouble;
		}

		public static implicit operator ValueDouble(string value)
		{
			ValueDouble valueDouble = new ValueDouble();
			valueDouble.AsString = value;
			return valueDouble;
		}

		public static implicit operator ValueDouble(DateTime value)
		{
			ValueDouble valueDouble = new ValueDouble();
			valueDouble.AsDateTime = value;
			return valueDouble;
		}

		public static implicit operator double(ValueDouble value)
		{
			return value.AsDouble;
		}

		public static implicit operator int(ValueDouble value)
		{
			return value.AsInteger;
		}

		public static implicit operator string(ValueDouble value)
		{
			return value.AsString;
		}

		public static implicit operator DateTime(ValueDouble value)
		{
			return value.AsDateTime;
		}

		public override int GetHashCode()
		{
			return m_Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ValueDouble))
			{
				return false;
			}
			return ((IComparable)this).CompareTo(obj) == 0;
		}

		public static bool operator ==(ValueDouble v1, ValueDouble v2)
		{
			if ((object)v1 == null ^ (object)v2 == null)
			{
				return false;
			}
			if ((object)v1 == null & (object)v2 == null)
			{
				return true;
			}
			return v1.AsDouble == v2.AsDouble;
		}

		public static bool operator !=(ValueDouble v1, ValueDouble v2)
		{
			return !(v1 == v2);
		}

		public static bool operator <(ValueDouble v1, ValueDouble v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) < 0;
		}

		public static bool operator >(ValueDouble v1, ValueDouble v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) > 0;
		}

		int IComparable.CompareTo(object obj)
		{
			double value;
			if (obj is double)
			{
				value = (double)obj;
				goto IL_0032;
			}
			if (obj is ValueDouble)
			{
				value = (obj as ValueDouble).AsDouble;
				goto IL_0032;
			}
			throw new ArgumentException("CompareTo object not supported");
			IL_0032:
			return m_Value.CompareTo(value);
		}

		TypeCode IConvertible.GetTypeCode()
		{
			return TypeCode.Double;
		}

		object IConvertible.ToType(Type conversionType, IFormatProvider provider)
		{
			return Convert.ChangeType(m_Value, conversionType, provider);
		}

		string IConvertible.ToString(IFormatProvider provider)
		{
			return Convert.ToString(m_Value, provider);
		}

		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return Convert.ToUInt64(m_Value, provider);
		}

		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			return Convert.ToSByte(m_Value, provider);
		}

		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return Convert.ToDouble(m_Value, provider);
		}

		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			return Convert.ToDateTime(m_Value, provider);
		}

		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return Convert.ToSingle(m_Value, provider);
		}

		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			return Convert.ToBoolean(m_Value, provider);
		}

		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return Convert.ToInt32(m_Value, provider);
		}

		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			return Convert.ToUInt16(m_Value, provider);
		}

		short IConvertible.ToInt16(IFormatProvider provider)
		{
			return Convert.ToInt16(m_Value, provider);
		}

		byte IConvertible.ToByte(IFormatProvider provider)
		{
			return Convert.ToByte(m_Value, provider);
		}

		char IConvertible.ToChar(IFormatProvider provider)
		{
			return Convert.ToChar(m_Value, provider);
		}

		long IConvertible.ToInt64(IFormatProvider provider)
		{
			return Convert.ToInt64(m_Value, provider);
		}

		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			return Convert.ToDecimal(m_Value, provider);
		}

		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			return Convert.ToUInt32(m_Value, provider);
		}
	}
}
