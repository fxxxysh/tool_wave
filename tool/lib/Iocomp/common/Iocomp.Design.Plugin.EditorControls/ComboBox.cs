using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[Designer(typeof(ComboBoxDesigner))]
	[ToolboxItem(false)]
	[DefaultEvent("")]
	[DesignerCategory("code")]
	[Description("PlugIn Editor ComboBox")]
	public class ComboBox : System.Windows.Forms.ComboBox, IPlugInEditorControl
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

		public ComboBox()
		{
			m_PropertyAdapter = new PlugInEditorControlPropertyAdapter();
			IsValid = true;
			base.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
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
				base.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
				base.Items.Clear();
				base.Items.Add("Error");
				SelectedIndex = 0;
			}
		}

		private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
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
				if (PropertyAdapter.GetIsEnum(source))
				{
					base.DropDownStyle = ComboBoxStyle.DropDownList;
					if (base.Items.Count == 0)
					{
						PropertyAdapter.LoadEnums(source, this);
					}
					m_BlockEvents = true;
					PropertyAdapter.SetEnumIndex(source, displayValue, this);
					m_BlockEvents = false;
				}
				else if (displayValue is string)
				{
					base.DropDownStyle = ComboBoxStyle.DropDown;
					Text = (string)displayValue;
				}
				else
				{
					flag = false;
				}
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
					if (PropertyAdapter.GetIsEnum(target))
					{
						PropertyAdapter.SetValue(target, Enum.Parse(displayValue.GetType(), (string)base.Items[SelectedIndex]));
					}
					else if (displayValue is string)
					{
						PropertyAdapter.SetValue(target, Text);
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
			if (PropertyAdapter.GetIsEnum(original))
			{
				return (int)displayValue != SelectedIndex;
			}
			if (displayValue is string)
			{
				return (string)displayValue != Text;
			}
			return false;
		}
	}
}
