using Iocomp.Delegates;
using Iocomp.Design;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(ValueIntegerTypeConverter))]
	public sealed class ValueInteger : Value, IConvertible, IComparable
	{
		private int m_Value;

		private int m_Max;

		private int m_Min;

		private int m_ValueOld;

		[RefreshProperties(RefreshProperties.All)]
		[Description("Value specified as a long.")]
		public int AsInteger
		{
			get
			{
				return m_Value;
			}
			set
			{
				base.PropertyUpdateDefault("AsInteger", value);
				int num;
				if (AsInteger != value)
				{
					ValueIntegerEventArgs valueIntegerEventArgs = null;
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
						valueIntegerEventArgs = new ValueIntegerEventArgs(m_Value, num, false, base.EventSource);
						OnBeforeChangeEvent(valueIntegerEventArgs);
						if (!valueIntegerEventArgs.Cancel)
						{
							num = valueIntegerEventArgs.ValueNew;
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
				if (AsInteger != num)
				{
					m_Value = num;
					base.DoPropertyChange(this, "AsInteger");
					if (base.ShouldTriggerEvents)
					{
						ValueIntegerEventArgs valueIntegerEventArgs = new ValueIntegerEventArgs(m_Value, m_Value, false, base.EventSource);
						OnChangedEvent(valueIntegerEventArgs);
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

		[Description("Specifies the maximum value allowed.")]
		[RefreshProperties(RefreshProperties.All)]
		public int Max
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
					if (ShouldEnforceMinMax && AsInteger > m_Max)
					{
						AsInteger = m_Max;
					}
					base.DoPropertyChange(this, "Max");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the minimum value allowed.")]
		public int Min
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
					if (ShouldEnforceMinMax && AsInteger < m_Min)
					{
						AsInteger = m_Min;
					}
					base.DoPropertyChange(this, "Min");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("Value specified as a Integer.")]
		public long AsLong
		{
			get
			{
				return m_Value;
			}
			set
			{
				base.PropertyUpdateDefault("AsLong", value);
				AsInteger = (int)value;
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
				AsLong = Convert.ToInt64(value, CultureInfo.CurrentCulture);
			}
		}

		[Browsable(false)]
		public event ValueIntegerEventHandler Changing;

		[Browsable(false)]
		public event ValueIntegerEventHandler Changed;

		[Browsable(false)]
		public event ValueIntegerEventHandler UserChangeFinished;

		protected override string GetPlugInTitle()
		{
			return "Value Integer";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ValueIntegerEditorPlugIn";
		}

		public ValueInteger()
		{
			base.DoCreate();
		}

		public ValueInteger(string value)
		{
			base.DoCreate();
			AsString = value;
		}

		public ValueInteger(int value)
		{
			base.DoCreate();
			AsInteger = value;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			AsString = "0";
			AsInteger = AsInteger;
			AsLong = AsLong;
			Max = 0;
			Min = 0;
		}

		public void BeginUserUpdate()
		{
			m_ValueOld = AsInteger;
		}

		public void EndUserUpdate()
		{
			ValueIntegerEventArgs valueIntegerEventArgs = null;
			if (m_ValueOld != AsInteger && base.ShouldTriggerEvents)
			{
				valueIntegerEventArgs = new ValueIntegerEventArgs(m_ValueOld, AsInteger, false, base.EventSource);
				OnUserChangeFinished(valueIntegerEventArgs);
			}
		}

		private bool ShouldSerializeAsInteger()
		{
			return base.PropertyShouldSerialize("AsInteger");
		}

		private void ResetAsInteger()
		{
			base.PropertyReset("AsInteger");
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

		private bool ShouldSerializeAsLong()
		{
			return base.PropertyShouldSerialize("AsLong");
		}

		private void ResetAsLong()
		{
			base.PropertyReset("AsLong");
		}

		private bool ShouldSerializeAsString()
		{
			return base.PropertyShouldSerialize("AsString");
		}

		private void ResetAsString()
		{
			base.PropertyReset("AsString");
		}

		private void OnBeforeChangeEvent(ValueIntegerEventArgs e)
		{
			if (this.Changing != null)
			{
				this.Changing(this, e);
			}
		}

		private void OnChangedEvent(ValueIntegerEventArgs e)
		{
			if (this.Changed != null)
			{
				this.Changed(this, e);
			}
		}

		private void OnUserChangeFinished(ValueIntegerEventArgs e)
		{
			if (this.UserChangeFinished != null)
			{
				this.UserChangeFinished(this, e);
			}
		}

		public static implicit operator ValueInteger(int value)
		{
			ValueInteger valueInteger = new ValueInteger();
			valueInteger.AsInteger = value;
			return valueInteger;
		}

		public static implicit operator ValueInteger(long value)
		{
			ValueInteger valueInteger = new ValueInteger();
			valueInteger.AsLong = value;
			return valueInteger;
		}

		public static implicit operator ValueInteger(string value)
		{
			ValueInteger valueInteger = new ValueInteger();
			valueInteger.AsString = value;
			return valueInteger;
		}

		public static implicit operator int(ValueInteger value)
		{
			return value.AsInteger;
		}

		public static implicit operator long(ValueInteger value)
		{
			return value.AsLong;
		}

		public static implicit operator string(ValueInteger value)
		{
			return value.AsString;
		}

		public override int GetHashCode()
		{
			return m_Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ValueInteger))
			{
				return false;
			}
			return ((IComparable)this).CompareTo(obj) == 0;
		}

		public static bool operator ==(ValueInteger v1, ValueInteger v2)
		{
			if ((object)v1 == null ^ (object)v2 == null)
			{
				return false;
			}
			if ((object)v1 == null & (object)v2 == null)
			{
				return true;
			}
			return v1.AsInteger == v2.AsInteger;
		}

		public static bool operator !=(ValueInteger v1, ValueInteger v2)
		{
			return !(v1 == v2);
		}

		public static bool operator <(ValueInteger v1, ValueInteger v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) < 0;
		}

		public static bool operator >(ValueInteger v1, ValueInteger v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) > 0;
		}

		int IComparable.CompareTo(object obj)
		{
			int value;
			if (obj is int)
			{
				value = (int)obj;
				goto IL_0032;
			}
			if (obj is ValueInteger)
			{
				value = (obj as ValueInteger).AsInteger;
				goto IL_0032;
			}
			throw new ArgumentException("CompareTo object not supported");
			IL_0032:
			return m_Value.CompareTo(value);
		}

		TypeCode IConvertible.GetTypeCode()
		{
			return TypeCode.Int32;
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
