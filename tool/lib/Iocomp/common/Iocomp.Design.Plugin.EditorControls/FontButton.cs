using Iocomp.Classes;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[ToolboxItem(false)]
	[Description("PlugIn Editor Font Button")]
	[DefaultEvent("")]
	[DesignerCategory("code")]
	[Designer(typeof(FontButtonDesigner))]
	public class FontButton : Button, IPlugInEditorControl
	{
		private PlugInEditorControlPropertyAdapter m_PropertyAdapter;

		private IPlugInStandard m_PlugInForm;

		private object m_UploadSource;

		private Font m_Font;

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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Font Font
		{
			get
			{
				return m_Font;
			}
			set
			{
				if (!GPFunctions.Equals(Font, value))
				{
					m_Font = value;
					OnChanged();
				}
			}
		}

		[ParenthesizePropertyName(true)]
		[DefaultValue("Font")]
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

		public event EventHandler Changed;

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

		public FontButton()
		{
			Text = "Font";
			IsValid = true;
			m_PropertyAdapter = new PlugInEditorControlPropertyAdapter();
			Changed += FontButton_Changed;
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
				Changed -= FontButton_Changed;
				Font = null;
				Text = "Error";
			}
		}

		private void OnChanged()
		{
			if (this.Changed != null)
			{
				this.Changed(this, EventArgs.Empty);
			}
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			FontDialog fontDialog = new FontDialog();
			try
			{
				fontDialog.Font = Font;
				if (fontDialog.ShowDialog() == DialogResult.OK)
				{
					Font = fontDialog.Font;
				}
			}
			finally
			{
				fontDialog.Dispose();
			}
		}

		private void FontButton_Changed(object sender, EventArgs e)
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
				if (displayValue is Font)
				{
					m_BlockEvents = true;
					Font = (Font)displayValue;
					m_BlockEvents = false;
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
				if (displayValue != null && displayValue is Font)
				{
					PropertyAdapter.SetValue(target, Font);
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
			if (displayValue is Font)
			{
				return !GPFunctions.Equals((Font)displayValue, Font);
			}
			return false;
		}
	}
}
