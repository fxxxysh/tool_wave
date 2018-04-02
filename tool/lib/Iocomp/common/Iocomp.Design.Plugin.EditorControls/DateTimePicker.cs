using Iocomp.Classes;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[DefaultEvent("")]
	[ToolboxItem(false)]
	[Description("PlugIn Editor DateTimePicker")]
	[DesignerCategory("code")]
	[Designer(typeof(DateTimePickerDesigner))]
	public class DateTimePicker : System.Windows.Forms.DateTimePicker, IPlugInEditorControl
	{
		private PlugInEditorControlPropertyAdapter m_PropertyAdapter;

		private IPlugInStandard m_PlugInForm;

		private object m_UploadSource;

		private bool m_ReadOnly;

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
				return m_ReadOnly;
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
		public bool ReadOnly
		{
			get
			{
				return m_ReadOnly;
			}
			set
			{
				m_ReadOnly = value;
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

		public DateTimePicker()
		{
			m_PropertyAdapter = new PlugInEditorControlPropertyAdapter();
			IsValid = true;
			base.ValueChanged += DateTimePicker_ValueChanged;
		}

		private void ReadOnlyIsValidUpdate()
		{
			if (ReadOnly || !IsValid)
			{
				if (!base.DesignMode)
				{
					base.Enabled = false;
				}
			}
			else if (!base.DesignMode)
			{
				base.Enabled = true;
			}
			if (!IsValid)
			{
				base.ValueChanged -= DateTimePicker_ValueChanged;
				base.Value = new DateTime(1777, 7, 7, 1, 1, 1, 1);
			}
		}

		private void DateTimePicker_ValueChanged(object sender, EventArgs e)
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

		public void UploadDisplay(object source)
		{
			m_UploadSource = source;
			object displayValue = PropertyAdapter.GetDisplayValue(source);
			bool flag = displayValue != null && true;
			if (flag)
			{
				m_BlockEvents = true;
				if (displayValue is ValueDateTime)
				{
					base.Value = (displayValue as ValueDateTime).AsDateTime;
				}
				else if (displayValue is DateTime)
				{
					base.Value = (DateTime)displayValue;
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
					if (displayValue is ValueDateTime)
					{
						PropertyAdapter.SetValue(target, new ValueDateTime(base.Value));
					}
					else if (displayValue is DateTime)
					{
						PropertyAdapter.SetValue(target, base.Value);
					}
				}
			}
		}

		private bool GetIsDisplayDirty(DateTime original)
		{
			if (base.Format != DateTimePickerFormat.Long && base.Format != DateTimePickerFormat.Short)
			{
				if (base.Format == DateTimePickerFormat.Time)
				{
					if (base.Value.Hour == original.Hour && base.Value.Minute == original.Minute)
					{
						return base.Value.Second != original.Second;
					}
					return true;
				}
				return !DateTime.Equals(base.Value, original);
			}
			if (base.Value.Year == original.Year && base.Value.Month == original.Month)
			{
				return base.Value.Day != original.Day;
			}
			return true;
		}

		private bool GetIsDisplayDirty(object original)
		{
			object displayValue = PropertyAdapter.GetDisplayValue(original);
			if (displayValue == null)
			{
				return false;
			}
			if (displayValue is ValueDateTime)
			{
				return GetIsDisplayDirty((displayValue as ValueDateTime).AsDateTime);
			}
			if (displayValue is DateTime)
			{
				return GetIsDisplayDirty((DateTime)displayValue);
			}
			return false;
		}
	}
}
