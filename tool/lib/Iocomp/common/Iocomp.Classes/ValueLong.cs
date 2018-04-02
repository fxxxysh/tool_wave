using Iocomp.Delegates;
using Iocomp.Design;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(ValueLongTypeConverter))]
	public sealed class ValueLong : Value, IConvertible, IComparable
	{
		private long m_Value;

		private long m_Max;

		private long m_Min;

		private long m_ValueOld;

		[Description("Value specified as a long.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		public long AsLong
		{
			get
			{
				return m_Value;
			}
			set
			{
				base.PropertyUpdateDefault("AsLong", value);
				long num;
				if (AsLong != value)
				{
					ValueLongEventArgs valueLongEventArgs = null;
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
						valueLongEventArgs = new ValueLongEventArgs(m_Value, num, false, base.EventSource);
						OnBeforeChangeEvent(valueLongEventArgs);
						if (!valueLongEventArgs.Cancel)
						{
							num = valueLongEventArgs.ValueNew;
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
				if (AsLong != num)
				{
					m_Value = num;
					base.DoPropertyChange(this, "AsLong");
					if (base.ShouldTriggerEvents)
					{
						ValueLongEventArgs valueLongEventArgs = new ValueLongEventArgs(m_Value, m_Value, false, base.EventSource);
						OnChangedEvent(valueLongEventArgs);
					}
				}
			}
		}

		private bool ShouldEnforceMinMax
		{
			get
			{
				if (Max == 0 && Min == 0)
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the maximum value allowed.")]
		public long Max
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
					if (ShouldEnforceMinMax && AsLong > m_Max)
					{
						AsLong = m_Max;
					}
					base.DoPropertyChange(this, "Max");
				}
			}
		}

		[Description("Specifies the minimum value allowed.")]
		[RefreshProperties(RefreshProperties.All)]
		public long Min
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
					if (ShouldEnforceMinMax && AsLong < m_Min)
					{
						AsLong = m_Min;
					}
					base.DoPropertyChange(this, "Min");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Value specified as a Integer.")]
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
				AsLong = value;
			}
		}

		[Description("Value specified as a hexadecimal string.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		public string AsStringHex
		{
			get
			{
				return Convert2.ToString(m_Value, 16).ToUpper(CultureInfo.CurrentCulture);
			}
			set
			{
				base.PropertyUpdateDefault("AsStringHex", value);
				AsLong = Convert.ToInt64(value, 16);
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Value specified as a binary string.")]
		public string AsStringBinary
		{
			get
			{
				return Convert2.ToString(m_Value, 2).ToUpper(CultureInfo.CurrentCulture);
			}
			set
			{
				base.PropertyUpdateDefault("AsStringBinary", value);
				AsLong = Convert.ToInt64(value, 2);
			}
		}

		[Description("Value specified as a string.")]
		[RefreshProperties(RefreshProperties.All)]
		public override string AsString
		{
			get
			{
				return Convert2.ToString(m_Value);
			}
			set
			{
				base.PropertyUpdateDefault("AsString", value);
				AsLong = Convert.ToInt64(value, CultureInfo.CurrentCulture);
			}
		}

		[Browsable(false)]
		public event ValueLongEventHandler Changing;

		[Browsable(false)]
		public event ValueLongEventHandler Changed;

		[Browsable(false)]
		public event ValueLongEventHandler UserChangeFinished;

		protected override string GetPlugInTitle()
		{
			return "Value Long";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ValueLongEditorPlugIn";
		}

		public ValueLong()
		{
			base.DoCreate();
		}

		public ValueLong(string value)
		{
			base.DoCreate();
			AsString = value;
		}

		public ValueLong(long value)
		{
			base.DoCreate();
			AsLong = value;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			AsLong = 0L;
			AsString = AsString;
			AsInteger = AsInteger;
			AsStringBinary = AsStringBinary;
			AsStringHex = AsStringHex;
			Max = 0L;
			Min = 0L;
		}

		public void BeginUserUpdate()
		{
			m_ValueOld = AsLong;
		}

		public void EndUserUpdate()
		{
			ValueLongEventArgs valueLongEventArgs = null;
			if (m_ValueOld != AsLong && base.ShouldTriggerEvents)
			{
				valueLongEventArgs = new ValueLongEventArgs(m_ValueOld, AsLong, false, base.EventSource);
				OnUserChangeFinished(valueLongEventArgs);
			}
		}

		private bool ShouldSerializeAsLong()
		{
			return base.PropertyShouldSerialize("AsLong");
		}

		private void ResetAsLong()
		{
			base.PropertyReset("AsLong");
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

		private bool ShouldSerializeAsInteger()
		{
			return base.PropertyShouldSerialize("AsInteger");
		}

		private void ResetAsInteger()
		{
			base.PropertyReset("AsInteger");
		}

		private bool ShouldSerializeAsStringHex()
		{
			return base.PropertyShouldSerialize("AsStringHex");
		}

		private void ResetAsStringHex()
		{
			base.PropertyReset("AsStringHex");
		}

		private bool ShouldSerializeAsStringBinary()
		{
			return base.PropertyShouldSerialize("AsStringBinary");
		}

		private void ResetAsStringBinary()
		{
			base.PropertyReset("AsStringBinary");
		}

		private bool ShouldSerializeAsString()
		{
			return base.PropertyShouldSerialize("AsString");
		}

		private void ResetAsString()
		{
			base.PropertyReset("AsString");
		}

		private void OnBeforeChangeEvent(ValueLongEventArgs e)
		{
			if (this.Changing != null)
			{
				this.Changing(this, e);
			}
		}

		private void OnChangedEvent(ValueLongEventArgs e)
		{
			if (this.Changed != null)
			{
				this.Changed(this, e);
			}
		}

		private void OnUserChangeFinished(ValueLongEventArgs e)
		{
			if (this.UserChangeFinished != null)
			{
				this.UserChangeFinished(this, e);
			}
		}

		public static implicit operator ValueLong(int value)
		{
			ValueLong valueLong = new ValueLong();
			valueLong.AsInteger = value;
			return valueLong;
		}

		public static implicit operator ValueLong(long value)
		{
			ValueLong valueLong = new ValueLong();
			valueLong.AsLong = value;
			return valueLong;
		}

		public static implicit operator ValueLong(string value)
		{
			ValueLong valueLong = new ValueLong();
			valueLong.AsString = value;
			return valueLong;
		}

		public static implicit operator int(ValueLong value)
		{
			return value.AsInteger;
		}

		public static implicit operator long(ValueLong value)
		{
			return value.AsLong;
		}

		public static implicit operator string(ValueLong value)
		{
			return value.AsString;
		}

		public override int GetHashCode()
		{
			return m_Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ValueLong))
			{
				return false;
			}
			return ((IComparable)this).CompareTo(obj) == 0;
		}

		public static bool operator ==(ValueLong v1, ValueLong v2)
		{
			if ((object)v1 == null ^ (object)v2 == null)
			{
				return false;
			}
			if ((object)v1 == null & (object)v2 == null)
			{
				return true;
			}
			return v1.AsLong == v2.AsLong;
		}

		public static bool operator !=(ValueLong v1, ValueLong v2)
		{
			return !(v1 == v2);
		}

		public static bool operator <(ValueLong v1, ValueLong v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) < 0;
		}

		public static bool operator >(ValueLong v1, ValueLong v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) > 0;
		}

		int IComparable.CompareTo(object obj)
		{
			long value;
			if (obj is long)
			{
				value = (long)obj;
				goto IL_0032;
			}
			if (obj is ValueLong)
			{
				value = (obj as ValueLong).AsLong;
				goto IL_0032;
			}
			throw new ArgumentException("CompareTo object not supported");
			IL_0032:
			return m_Value.CompareTo(value);
		}

		TypeCode IConvertible.GetTypeCode()
		{
			return TypeCode.Int64;
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
