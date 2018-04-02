using Iocomp.Classes;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[ToolboxItem(false)]
	[Description("PlugIn Editor CheckBox")]
	[DefaultEvent("")]
	[DesignerCategory("code")]
	[Designer(typeof(CheckBoxDesigner))]
	public class CheckBox : System.Windows.Forms.CheckBox, IPlugInEditorControl
	{
		private PlugInEditorControlPropertyAdapter m_PropertyAdapter;

		private IPlugInStandard m_PlugInForm;

		private object m_UploadSource;

		private bool m_IsValid;

		private bool m_ReadOnly;

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

		[ParenthesizePropertyName(true)]
		public new string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

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

		[ParenthesizePropertyName(true)]
		[DefaultValue("")]
		public string PropertyName
		{
			get
			{
				return m_PropertyAdapter.PropertyName;
			}
			set
			{
				if (m_PropertyAdapter.PropertyName != value)
				{
					m_PropertyAdapter.PropertyName = value;
					if (PropertyName != null && PropertyName != Const.EmptyString && Text == base.Name)
					{
						Text = PropertyName;
					}
				}
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

		public CheckBox()
		{
			IsValid = true;
			m_PropertyAdapter = new PlugInEditorControlPropertyAdapter();
			base.CheckedChanged += CheckBox_CheckedChanged;
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
				base.CheckedChanged -= CheckBox_CheckedChanged;
				Text = "Error";
				base.Checked = false;
			}
		}

		private void CheckBox_CheckedChanged(object sender, EventArgs e)
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
				if (displayValue is ValueBoolean)
				{
					base.Checked = (displayValue as ValueBoolean).AsBoolean;
				}
				else if (displayValue is bool)
				{
					base.Checked = (bool)displayValue;
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
					if (displayValue is ValueBoolean)
					{
						PropertyAdapter.SetValue(target, new ValueBoolean(base.Checked));
					}
					else if (displayValue is bool)
					{
						PropertyAdapter.SetValue(target, base.Checked);
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
			if (displayValue is ValueBoolean)
			{
				return (displayValue as ValueBoolean).AsBoolean != base.Checked;
			}
			if (displayValue is bool)
			{
				return (bool)displayValue != base.Checked;
			}
			return false;
		}
	}
}
