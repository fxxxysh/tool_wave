using Iocomp.Classes;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[ToolboxItem(false)]
	[DefaultEvent("")]
	[DesignerCategory("code")]
	[Designer(typeof(EditBoxDesigner))]
	[Description("PlugIn Editor EditBox")]
	public class EditBox : EditBase, IPlugInEditorControl
	{
		private ValueString m_Value;

		private EditBoxDataStyle m_DataStyle;

		private EditBoxLongFormat m_LongFormat;

		private PlugInEditorControlPropertyAdapter m_PropertyAdapter;

		private IPlugInStandard m_PlugInForm;

		private object m_UploadSource;

		private bool m_IsValid;

		private bool m_SentForceApplyButtonEnabled;

		private bool m_SentForceDirtyUpdate;

		private bool m_BlockEvents;

		IPlugInStandard IPlugInEditorControl.PlugInForm
		{
			get
			{
				return m_PlugInForm;
			}
			set
			{
				m_PlugInForm = value;
			}
		}

		bool IPlugInEditorControl.IsReadOnly
		{
			get
			{
				return ReadOnly;
			}
		}

		bool IPlugInEditorControl.IsValid
		{
			get
			{
				return m_IsValid;
			}
		}

		private EditBoxDataStyle DataStyle
		{
			get
			{
				return m_DataStyle;
			}
			set
			{
				m_DataStyle = value;
			}
		}

		private PlugInEditorControlPropertyAdapter PropertyAdapter => m_PropertyAdapter;

		private IPlugInStandard PlugInForm => m_PlugInForm;

		private bool IsValid
		{
			get
			{
				return m_IsValid;
			}
			set
			{
				m_IsValid = value;
				ReadOnlyIsValidUpdate();
			}
		}

		[DefaultValue(false)]
		public new bool ReadOnly
		{
			get
			{
				return base.ReadOnly;
			}
			set
			{
				base.ReadOnly = value;
				ReadOnlyIsValidUpdate();
			}
		}

		[DefaultValue("")]
		[ParenthesizePropertyName(true)]
		public string PropertyName
		{
			get
			{
				return m_PropertyAdapter.PropertyName;
			}
			set
			{
				m_PropertyAdapter.PropertyName = value;
			}
		}

		[DefaultValue(HorizontalAlignment.Left)]
		public new HorizontalAlignment TextAlign
		{
			get
			{
				return base.TextAlign;
			}
			set
			{
				base.TextAlign = value;
			}
		}

		[DefaultValue(false)]
		public new bool WordWrap
		{
			get
			{
				return base.WordWrap;
			}
			set
			{
				base.WordWrap = value;
			}
		}

		[Description("")]
		[DefaultValue(EditBoxLongFormat.Int)]
		[Category("Iocomp")]
		public EditBoxLongFormat LongFormat
		{
			get
			{
				return m_LongFormat;
			}
			set
			{
				m_LongFormat = value;
			}
		}

		protected override Size DefaultSize => new Size(100, 20);

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string AsString
		{
			get
			{
				return Value.AsString;
			}
			set
			{
				Value.AsString = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int AsInteger
		{
			get
			{
				if (Value.AsString.Length == 0)
				{
					return 0;
				}
				return Convert.ToInt32(Value.AsString, CultureInfo.CurrentCulture);
			}
			set
			{
				Value.AsString = Convert2.ToString(value);
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public long AsLong
		{
			get
			{
				if (Value.AsString.Length == 0)
				{
					return 0L;
				}
				if (LongFormat == EditBoxLongFormat.Int)
				{
					return Convert.ToInt64(Value.AsString, CultureInfo.CurrentCulture);
				}
				if (LongFormat == EditBoxLongFormat.Hex)
				{
					return Convert.ToInt64(Value.AsString, 16);
				}
				return Convert.ToInt64(Value.AsString, 2);
			}
			set
			{
				if (LongFormat == EditBoxLongFormat.Int)
				{
					Value.AsString = Convert2.ToString(value);
				}
				else if (LongFormat == EditBoxLongFormat.Hex)
				{
					Value.AsString = Convert2.ToString(value, 16).ToUpper(CultureInfo.CurrentCulture);
				}
				else
				{
					Value.AsString = Convert2.ToString(value, 2).ToUpper(CultureInfo.CurrentCulture);
				}
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double AsDouble
		{
			get
			{
				if (Value.AsString.Length == 0)
				{
					return 0.0;
				}
				double num = Convert.ToDouble(Value.AsString, CultureInfo.CurrentCulture);
				if (double.IsNaN(num))
				{
					num = 0.0;
				}
				return num;
			}
			set
			{
				Value.AsString = Convert2.ToString(value);
			}
		}

		public int Length => Value.AsString.Length;

		public ValueString Value => m_Value;

		[Category("Iocomp")]
		public event EventHandler Changed;

		[Category("Iocomp")]
		public event EventHandler ForcedUpdate;

		void IPlugInEditorControl.UploadDisplay(object source)
		{
			UploadDisplay(source);
		}

		void IPlugInEditorControl.TransferAmbient(object source, object destination)
		{
			m_PropertyAdapter.TransferAmbient(source, destination);
		}

		bool IPlugInEditorControl.GetIsDisplayDirty(object original)
		{
			return GetIsDisplayDirty(original);
		}

		public EditBox()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			m_Value = new ValueString();
			base.AddSubClass(Value);
			m_PropertyAdapter = new PlugInEditorControlPropertyAdapter();
			Value.Changed += OnValueChanged;
			base.TextChanged += EditBox_TextChanged;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			IsValid = true;
			TextAlign = HorizontalAlignment.Left;
			WordWrap = false;
			Value.AsString = "";
		}

		private void ReadOnlyIsValidUpdate()
		{
			if (ReadOnly || !IsValid)
			{
				if (base.DesignMode)
				{
					base.BackColor = SystemColors.Control;
				}
			}
			else if (base.DesignMode)
			{
				base.BackColor = SystemColors.Window;
			}
			if (!IsValid)
			{
				Value.Changed -= Value_Changed;
				base.TextChanged -= EditBox_TextChanged;
				Value.AsString = "Error";
			}
		}

		protected override void PropertyChangedHook(object sender, string propertyName)
		{
			if (sender == Value)
			{
				UpdateText();
			}
			base.PropertyChangedHook(sender, propertyName);
		}

		private void OnChanged()
		{
			if (this.Changed != null)
			{
				this.Changed(this, EventArgs.Empty);
			}
		}

		public void ForceUpdate()
		{
			DownloadDisplay(m_UploadSource);
			if (PlugInForm != null)
			{
				PlugInForm.ForceDirtyUpdate();
			}
			if (this.ForcedUpdate != null)
			{
				this.ForcedUpdate(this, EventArgs.Empty);
			}
		}

		protected override void UpdateValue()
		{
			Value.AsString = base.Text;
			if (m_SentForceApplyButtonEnabled && !m_SentForceDirtyUpdate)
			{
				ForceUpdate();
			}
			base.SelectAll();
		}

		protected override void UpdateText()
		{
			base.Text = Value.AsString;
			base.SelectAll();
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			m_SentForceApplyButtonEnabled = false;
		}

		protected override void InternalOnKeyPress(KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				m_SentForceDirtyUpdate = false;
				UpdateValue();
				e.Handled = true;
			}
			else if (e.KeyChar == '\u001b')
			{
				m_SentForceDirtyUpdate = false;
				UpdateText();
				e.Handled = true;
			}
			else if (DataStyle == EditBoxDataStyle.Double || DataStyle == EditBoxDataStyle.ValueDouble)
			{
				if (char.IsNumber(e.KeyChar))
				{
					e.Handled = false;
				}
				else if (char.ToUpper(e.KeyChar) == 'E')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '-')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '\b')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '.')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == ',')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '\u0003')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '\u0016')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '\u0018')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '\u001a')
				{
					e.Handled = false;
				}
				else
				{
					e.Handled = true;
				}
			}
			else if (DataStyle == EditBoxDataStyle.Int || DataStyle == EditBoxDataStyle.ValueInteger)
			{
				if (char.IsNumber(e.KeyChar))
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '-')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '\b')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '\u0003')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '\u0016')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '\u0018')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '\u001a')
				{
					e.Handled = false;
				}
				else
				{
					e.Handled = true;
				}
			}
			else if (DataStyle == EditBoxDataStyle.Long || DataStyle == EditBoxDataStyle.ValueLong)
			{
				if (LongFormat == EditBoxLongFormat.Int)
				{
					if (char.IsNumber(e.KeyChar))
					{
						e.Handled = false;
					}
					else if (e.KeyChar == '-')
					{
						e.Handled = false;
					}
					else if (e.KeyChar == '\b')
					{
						e.Handled = false;
					}
					else if (e.KeyChar == '\u0003')
					{
						e.Handled = false;
					}
					else if (e.KeyChar == '\u0016')
					{
						e.Handled = false;
					}
					else if (e.KeyChar == '\u0018')
					{
						e.Handled = false;
					}
					else if (e.KeyChar == '\u001a')
					{
						e.Handled = false;
					}
					else
					{
						e.Handled = true;
					}
				}
				else if (LongFormat == EditBoxLongFormat.Hex)
				{
					if (char.IsNumber(e.KeyChar))
					{
						e.Handled = false;
					}
					else if (char.ToUpper(e.KeyChar) == 'A')
					{
						e.Handled = false;
					}
					else if (char.ToUpper(e.KeyChar) == 'B')
					{
						e.Handled = false;
					}
					else if (char.ToUpper(e.KeyChar) == 'C')
					{
						e.Handled = false;
					}
					else if (char.ToUpper(e.KeyChar) == 'D')
					{
						e.Handled = false;
					}
					else if (char.ToUpper(e.KeyChar) == 'E')
					{
						e.Handled = false;
					}
					else if (char.ToUpper(e.KeyChar) == 'F')
					{
						e.Handled = false;
					}
					else if (char.ToUpper(e.KeyChar) == '\b')
					{
						e.Handled = false;
					}
					else if (e.KeyChar == '\u0003')
					{
						e.Handled = false;
					}
					else if (e.KeyChar == '\u0016')
					{
						e.Handled = false;
					}
					else if (e.KeyChar == '\u0018')
					{
						e.Handled = false;
					}
					else if (e.KeyChar == '\u001a')
					{
						e.Handled = false;
					}
					else
					{
						e.Handled = true;
					}
				}
				else if (e.KeyChar == '0')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '1')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '\b')
				{
					e.Handled = false;
				}
				else
				{
					e.Handled = true;
				}
			}
			else
			{
				e.Handled = false;
			}
		}

		private void OnValueChanged(object sender, ValueStringEventArgs e)
		{
			OnChanged();
		}

		private void EditBox_TextChanged(object sender, EventArgs e)
		{
			if (!m_BlockEvents)
			{
				if (PlugInForm != null)
				{
					PlugInForm.ForceApplyButtonEnabled();
				}
				m_SentForceApplyButtonEnabled = true;
			}
		}

		private void Value_Changed(object sender, ValueStringEventArgs e)
		{
			if (!m_BlockEvents)
			{
				ForceUpdate();
				m_SentForceDirtyUpdate = true;
			}
		}

		public void UploadDisplay(object source)
		{
			m_UploadSource = source;
			object displayValue = PropertyAdapter.GetDisplayValue(source);
			bool isValid = true;
			DataStyle = EditBoxDataStyle.None;
			if (displayValue == null)
			{
				DataStyle = EditBoxDataStyle.String;
			}
			else if (displayValue is int)
			{
				DataStyle = EditBoxDataStyle.Int;
			}
			else if (displayValue is long)
			{
				DataStyle = EditBoxDataStyle.Long;
			}
			else if (displayValue is double)
			{
				DataStyle = EditBoxDataStyle.Double;
			}
			else if (displayValue is string)
			{
				DataStyle = EditBoxDataStyle.String;
			}
			else if (displayValue is ValueDouble)
			{
				DataStyle = EditBoxDataStyle.ValueDouble;
			}
			else if (displayValue is ValueInteger)
			{
				DataStyle = EditBoxDataStyle.ValueInteger;
			}
			else if (displayValue is ValueLong)
			{
				DataStyle = EditBoxDataStyle.ValueLong;
			}
			else if (displayValue is ValueString)
			{
				DataStyle = EditBoxDataStyle.ValueString;
			}
			else
			{
				isValid = false;
			}
			if (DataStyle != 0)
			{
				m_BlockEvents = true;
				if (DataStyle == EditBoxDataStyle.Int)
				{
					AsInteger = (int)displayValue;
				}
				else if (DataStyle == EditBoxDataStyle.Long)
				{
					AsLong = (long)displayValue;
				}
				else if (DataStyle == EditBoxDataStyle.Double)
				{
					AsDouble = (double)displayValue;
				}
				else if (DataStyle == EditBoxDataStyle.String)
				{
					AsString = (string)displayValue;
				}
				else if (DataStyle == EditBoxDataStyle.ValueDouble)
				{
					AsString = (displayValue as ValueDouble).AsString;
				}
				else if (DataStyle == EditBoxDataStyle.ValueInteger)
				{
					AsString = (displayValue as ValueInteger).AsString;
				}
				else if (DataStyle == EditBoxDataStyle.ValueString)
				{
					AsString = (displayValue as ValueString).AsString;
				}
				else if (DataStyle == EditBoxDataStyle.ValueLong)
				{
					if (LongFormat == EditBoxLongFormat.Int)
					{
						AsString = (displayValue as ValueLong).AsString;
					}
					else if (LongFormat == EditBoxLongFormat.Hex)
					{
						AsString = (displayValue as ValueLong).AsStringHex;
					}
					else
					{
						AsString = (displayValue as ValueLong).AsStringBinary;
					}
				}
				m_BlockEvents = false;
			}
			IsValid = isValid;
		}

		private void DownloadDisplay(object target)
		{
			if (IsValid)
			{
				object displayValue = PropertyAdapter.GetDisplayValue(target);
				try
				{
					if (displayValue == null && AsString != string.Empty)
					{
						PropertyAdapter.SetValue(target, AsString);
					}
					else if (displayValue is int)
					{
						PropertyAdapter.SetValue(target, AsInteger);
					}
					else if (displayValue is long)
					{
						PropertyAdapter.SetValue(target, AsLong);
					}
					else if (displayValue is double)
					{
						PropertyAdapter.SetValue(target, AsDouble);
					}
					else if (displayValue is string)
					{
						PropertyAdapter.SetValue(target, AsString);
					}
					else if (displayValue is ValueInteger)
					{
						PropertyAdapter.SetValue(target, new ValueInteger(AsInteger));
					}
					else if (displayValue is ValueLong)
					{
						PropertyAdapter.SetValue(target, new ValueLong(AsLong));
					}
					else if (displayValue is ValueDouble)
					{
						PropertyAdapter.SetValue(target, new ValueDouble(AsDouble));
					}
					else if (displayValue is ValueString)
					{
						PropertyAdapter.SetValue(target, new ValueString(AsString));
					}
				}
				catch
				{
				}
			}
		}

		private bool GetIsDisplayDirty(object original)
		{
			object displayValue = PropertyAdapter.GetDisplayValue(original);
			if (displayValue == null)
			{
				return AsString != string.Empty;
			}
			if (displayValue is int)
			{
				return (int)displayValue != AsInteger;
			}
			if (displayValue is long)
			{
				return (long)displayValue != AsLong;
			}
			if (displayValue is double)
			{
				return (double)displayValue != AsDouble;
			}
			if (displayValue is string)
			{
				return (string)displayValue != AsString;
			}
			if (displayValue is ValueInteger)
			{
				return (displayValue as ValueInteger).AsInteger != AsInteger;
			}
			if (displayValue is ValueLong)
			{
				return (displayValue as ValueLong).AsLong != AsLong;
			}
			if (displayValue is ValueDouble)
			{
				return (displayValue as ValueDouble).AsDouble != AsDouble;
			}
			if (displayValue is ValueString)
			{
				return (displayValue as ValueString).AsString != AsString;
			}
			return false;
		}
	}
}
