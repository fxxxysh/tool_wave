using Iocomp.Delegates;
using Iocomp.Design;
using System;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(ValueStringTypeConverter))]
	public sealed class ValueString : Value, IConvertible, IComparable
	{
		private string m_Value;

		[Description("Value specified as a string.")]
		[RefreshProperties(RefreshProperties.All)]
		public override string AsString
		{
			get
			{
				return m_Value;
			}
			set
			{
				base.PropertyUpdateDefault("AsString", value);
				string text;
				if (!(AsString == value))
				{
					ValueStringEventArgs valueStringEventArgs = null;
					text = value;
					if (base.ShouldTriggerEvents)
					{
						valueStringEventArgs = new ValueStringEventArgs(m_Value, text, false, base.EventSource);
						OnBeforeChangeEvent(valueStringEventArgs);
						if (!valueStringEventArgs.Cancel)
						{
							text = valueStringEventArgs.ValueNew;
							goto IL_0052;
						}
						return;
					}
					goto IL_0052;
				}
				return;
				IL_0052:
				if (AsString != text)
				{
					m_Value = text;
					base.DoPropertyChange(this, "AsString");
					if (base.ShouldTriggerEvents)
					{
						ValueStringEventArgs valueStringEventArgs = new ValueStringEventArgs(m_Value, m_Value, false, base.EventSource);
						OnChangedEvent(valueStringEventArgs);
					}
				}
			}
		}

		[Browsable(false)]
		public event ValueStringEventHandler Changing;

		[Browsable(false)]
		public event ValueStringEventHandler Changed;

		protected override string GetPlugInTitle()
		{
			return "Value String";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ValueStringEditorPlugIn";
		}

		public ValueString()
		{
			base.DoCreate();
		}

		public ValueString(string value)
		{
			base.DoCreate();
			AsString = value;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			AsString = "";
		}

		private bool ShouldSerializeAsString()
		{
			return base.PropertyShouldSerialize("AsString");
		}

		private void ResetAsString()
		{
			base.PropertyReset("AsString");
		}

		private void OnBeforeChangeEvent(ValueStringEventArgs e)
		{
			if (this.Changing != null)
			{
				this.Changing(this, e);
			}
		}

		private void OnChangedEvent(ValueStringEventArgs e)
		{
			if (this.Changed != null)
			{
				this.Changed(this, e);
			}
		}

		public static implicit operator ValueString(string value)
		{
			ValueString valueString = new ValueString();
			valueString.AsString = value;
			return valueString;
		}

		public static implicit operator string(ValueString value)
		{
			return value.AsString;
		}

		public override int GetHashCode()
		{
			return m_Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ValueString))
			{
				return false;
			}
			return ((IComparable)this).CompareTo(obj) == 0;
		}

		public static bool operator ==(ValueString v1, ValueString v2)
		{
			if ((object)v1 == null ^ (object)v2 == null)
			{
				return false;
			}
			if ((object)v1 == null & (object)v2 == null)
			{
				return true;
			}
			return v1.AsString == v2.AsString;
		}

		public static bool operator !=(ValueString v1, ValueString v2)
		{
			return !(v1 == v2);
		}

		public static bool operator <(ValueString v1, ValueString v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) < 0;
		}

		public static bool operator >(ValueString v1, ValueString v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) > 0;
		}

		int IComparable.CompareTo(object obj)
		{
			string strB;
			if (obj is string)
			{
				strB = (string)obj;
				goto IL_0032;
			}
			if (obj is ValueString)
			{
				strB = (obj as ValueString).AsString;
				goto IL_0032;
			}
			throw new ArgumentException("CompareTo object not supported");
			IL_0032:
			return m_Value.CompareTo(strB);
		}

		TypeCode IConvertible.GetTypeCode()
		{
			return TypeCode.String;
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