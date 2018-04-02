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
	[Description("PlugIn Editor NumericUpDown")]
	[Designer(typeof(NumericUpDownDesigner))]
	public class NumericUpDown : System.Windows.Forms.NumericUpDown, IPlugInEditorControl
	{
		private PlugInEditorControlPropertyAdapter m_PropertyAdapter;

		private IPlugInStandard m_PlugInForm;

		private object m_UploadSource;

		private bool m_IsValid;

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

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string AsString
		{
			get
			{
				return Convert2.ToString(base.Value);
			}
			set
			{
				Text = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int AsInteger
		{
			get
			{
				return Convert.ToInt32(base.Value, CultureInfo.CurrentCulture);
			}
			set
			{
				Text = Convert.ToString(value, CultureInfo.CurrentCulture);
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public long AsLong
		{
			get
			{
				return Convert.ToInt64(base.Value, CultureInfo.CurrentCulture);
			}
			set
			{
				Text = Convert.ToString(value, CultureInfo.CurrentCulture);
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double AsDouble
		{
			get
			{
				return Convert.ToDouble(base.Value, CultureInfo.CurrentCulture);
			}
			set
			{
				Text = Convert.ToString(value, CultureInfo.CurrentCulture);
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

		public NumericUpDown()
		{
			m_PropertyAdapter = new PlugInEditorControlPropertyAdapter();
			(base.Controls[1] as TextBox).AcceptsReturn = true;
			(base.Controls[1] as TextBox).WordWrap = true;
			base.Leave += NumericUpDown_Leave;
			(base.Controls[1] as TextBox).KeyPress += NumericUpDown_KeyPress;
			IsValid = true;
			base.ValueChanged += NumericUpDown_ValueChanged;
		}

		private void ReadOnlyIsValidUpdate()
		{
			if (ReadOnly || !IsValid)
			{
				if (base.DesignMode)
				{
					BackColor = SystemColors.Control;
				}
				else
				{
					base.Enabled = false;
				}
			}
			else if (base.DesignMode)
			{
				BackColor = SystemColors.Window;
			}
			else
			{
				base.Enabled = true;
			}
			if (!IsValid)
			{
				base.ValueChanged -= NumericUpDown_ValueChanged;
				base.Value = 0m;
			}
		}

		private void NumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (!m_BlockEvents)
			{
				DownloadDisplay(m_UploadSource);
				if (PlugInForm != null)
				{
					PlugInForm.ForceDirtyUpdate();
				}
			}
		}

		private void NumericUpDown_Leave(object sender, EventArgs e)
		{
			if (GetIsDisplayDirty(m_UploadSource))
			{
				NumericUpDown_ValueChanged(null, null);
			}
		}

		private void NumericUpDown_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				e.Handled = true;
				(base.Controls[1] as TextBox).SelectAll();
				if (GetIsDisplayDirty(m_UploadSource))
				{
					NumericUpDown_ValueChanged(null, null);
				}
			}
		}

		public void UploadDisplay(object source)
		{
			m_UploadSource = source;
			object displayValue = PropertyAdapter.GetDisplayValue(source);
			bool flag = displayValue != null && true;
			if (flag)
			{
				m_BlockEvents = true;
				if (displayValue is int)
				{
					AsInteger = (int)displayValue;
				}
				else if (displayValue is long)
				{
					AsLong = (long)displayValue;
				}
				else if (displayValue is double)
				{
					AsDouble = (double)displayValue;
				}
				else if (displayValue is ValueInteger)
				{
					AsInteger = (displayValue as ValueInteger).AsInteger;
				}
				else if (displayValue is ValueLong)
				{
					AsLong = (displayValue as ValueInteger).AsLong;
				}
				else if (displayValue is ValueDouble)
				{
					AsDouble = (displayValue as ValueDouble).AsDouble;
				}
				else
				{
					flag = false;
				}
				m_BlockEvents = false;
			}
			IsValid = flag;
		}

		private void DownloadDisplay(object target)
		{
			if (IsValid)
			{
				object displayValue = PropertyAdapter.GetDisplayValue(target);
				if (displayValue != null)
				{
					if (displayValue is int)
					{
						PropertyAdapter.SetValue(target, (int)base.Value);
					}
					else if (displayValue is long)
					{
						PropertyAdapter.SetValue(target, (long)base.Value);
					}
					else if (displayValue is double)
					{
						PropertyAdapter.SetValue(target, (double)base.Value);
					}
					else if (displayValue is ValueInteger)
					{
						PropertyAdapter.SetValue(target, new ValueInteger((int)base.Value));
					}
					else if (displayValue is ValueLong)
					{
						PropertyAdapter.SetValue(target, new ValueLong((long)base.Value));
					}
					else if (displayValue is ValueDouble)
					{
						PropertyAdapter.SetValue(target, new ValueDouble((double)base.Value));
					}
				}
			}
		}

		private bool GetIsDisplayDirty(object original)
		{
			object displayValue = PropertyAdapter.GetDisplayValue(original);
			if (displayValue == null)
			{
				return false;
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
			return false;
		}
	}
}
