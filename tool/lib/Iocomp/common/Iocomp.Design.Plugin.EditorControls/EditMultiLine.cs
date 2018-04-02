using Iocomp.Classes;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[DefaultEvent("")]
	[ToolboxItem(false)]
	[Description("PlugIn Editor EditMultiLine")]
	[Designer(typeof(EditMultiLineDesigner))]
	[DesignerCategory("code")]
	public class EditMultiLine : Control, IPlugInEditorControl
	{
		private EditBox m_TextBox;

		private Button m_EditButton;

		private Button m_OkButton;

		private Button m_CancelButton;

		private Panel m_Panel;

		private TextBox m_MemoBox;

		private Form m_Form;

		private PlugInEditorControlPropertyAdapter m_PropertyAdapter;

		private IPlugInStandard m_PlugInForm;

		private object m_UploadSource;

		private bool m_ReadOnly;

		private bool m_IsValid;

		private bool m_BlockEvents;

		private Font m_EditFont;

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

		protected override Size DefaultSize => new Size(176, 96);

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

		public Font EditFont
		{
			get
			{
				return m_EditFont;
			}
			set
			{
				m_EditFont = value;
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

		[Browsable(true)]
		public override string Text
		{
			get
			{
				return m_TextBox.AsString;
			}
			set
			{
				m_TextBox.AsString = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(true)]
		public string AsString
		{
			get
			{
				return m_TextBox.AsString;
			}
			set
			{
				m_TextBox.AsString = value;
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

		public EditMultiLine()
		{
			m_PropertyAdapter = new PlugInEditorControlPropertyAdapter();
			m_EditButton = new Button();
			m_EditButton.Location = new Point(100, 0);
			m_EditButton.Name = "EditButton";
			m_EditButton.Size = new Size(22, 20);
			m_EditButton.TabIndex = 1;
			m_EditButton.Text = "...";
			m_TextBox = new EditBox();
			m_TextBox.Location = new Point(0, 0);
			m_TextBox.Name = "TextBox";
			m_TextBox.TabIndex = 0;
			base.Controls.Add(m_EditButton);
			base.Controls.Add(m_TextBox);
			base.Resize += EditMultiLine_Resize;
			m_EditButton.Click += EditButton_Click;
			m_TextBox.Changed += m_TextBox_Changed;
			m_TextBox.ForcedUpdate += m_TextBox_ForcedUpdate;
			m_TextBox.TextChanged += m_TextBox_TextChanged;
			IsValid = true;
			base.TabStop = false;
			EditMultiLine_Resize(this, null);
		}

		private void ReadOnlyIsValidUpdate()
		{
			if (ReadOnly || !IsValid)
			{
				if (base.DesignMode)
				{
					m_TextBox.BackColor = SystemColors.Control;
				}
				else
				{
					base.Enabled = false;
					m_TextBox.Enabled = false;
					m_EditButton.Enabled = false;
				}
			}
			else if (base.DesignMode)
			{
				m_TextBox.BackColor = SystemColors.Window;
			}
			else
			{
				base.Enabled = true;
				m_TextBox.Enabled = true;
				m_EditButton.Enabled = true;
			}
			if (!IsValid)
			{
				m_TextBox.ForcedUpdate -= m_TextBox_ForcedUpdate;
				m_TextBox.TextChanged -= m_TextBox_TextChanged;
				m_TextBox.AsString = "Error";
			}
		}

		private void OnChanged()
		{
			if (this.Changed != null)
			{
				this.Changed(this, EventArgs.Empty);
			}
		}

		private void EditMultiLine_Resize(object sender, EventArgs e)
		{
			m_EditButton.Dock = DockStyle.Right;
			m_TextBox.Dock = DockStyle.Fill;
			base.Height = m_TextBox.Height;
		}

		private void TextBox_Resize(object sender, EventArgs e)
		{
			m_EditButton.Width = (int)((double)m_TextBox.Height * 1.1);
			base.Height = m_TextBox.Height;
		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			m_Form = new Form();
			try
			{
				m_Form.FormBorderStyle = FormBorderStyle.Sizable;
				m_Form.MinimizeBox = false;
				m_Form.MaximizeBox = false;
				m_Form.Text = "Lines Editor";
				m_Form.Icon = null;
				m_Form.StartPosition = FormStartPosition.CenterScreen;
				m_Form.ShowInTaskbar = false;
				m_Form.ClientSize = new Size((int)(Font.GetHeight() * 20f + 45f), (int)(Font.GetHeight() * 15f + 45f));
				m_Form.MinimumSize = new Size(200, 150);
				m_Form.SizeGripStyle = SizeGripStyle.Show;
				m_Panel = new Panel();
				m_Panel.Height = 45;
				m_Panel.Dock = DockStyle.Bottom;
				m_MemoBox = new TextBox();
				m_MemoBox.ScrollBars = ScrollBars.Both;
				m_MemoBox.Multiline = true;
				m_MemoBox.WordWrap = false;
				m_MemoBox.Lines = m_TextBox.Lines;
				m_MemoBox.Font = EditFont;
				m_OkButton = new Button();
				m_OkButton.DialogResult = DialogResult.OK;
				m_OkButton.Text = "OK";
				m_OkButton.Width = 75;
				m_OkButton.Height = 27;
				m_CancelButton = new Button();
				m_CancelButton.DialogResult = DialogResult.Cancel;
				m_CancelButton.Text = "Cancel";
				m_CancelButton.Width = 75;
				m_CancelButton.Height = 27;
				m_Panel.Controls.Add(m_OkButton);
				m_Panel.Controls.Add(m_CancelButton);
				m_Form.Controls.Add(m_Panel);
				m_Form.Controls.Add(m_MemoBox);
				m_Form.Resize += m_Form_Resize;
				m_Form_Resize(this, e);
				if (m_Form.ShowDialog() == DialogResult.OK)
				{
					AsString = m_MemoBox.Text;
					if (!m_BlockEvents)
					{
						DownloadDisplay(m_UploadSource);
						if (PlugInForm != null)
						{
							PlugInForm.ForceApplyButtonEnabled();
						}
					}
				}
			}
			finally
			{
				m_Form.Dispose();
			}
		}

		private void m_Form_Resize(object sender, EventArgs e)
		{
			m_CancelButton.Location = new Point(m_Panel.Right - m_CancelButton.Width - 10, m_Panel.Height / 2 - m_CancelButton.Height / 2);
			m_OkButton.Location = new Point(m_CancelButton.Left - m_OkButton.Width - 5, m_Panel.Height / 2 - m_OkButton.Height / 2);
			m_MemoBox.Height = m_Form.ClientSize.Height - m_Panel.Height;
			m_MemoBox.Width = m_Form.ClientSize.Width;
		}

		private void m_TextBox_Changed(object sender, EventArgs e)
		{
			OnChanged();
		}

		private void m_TextBox_TextChanged(object sender, EventArgs e)
		{
			if (!m_BlockEvents && PlugInForm != null)
			{
				PlugInForm.ForceApplyButtonEnabled();
			}
		}

		private void m_TextBox_ForcedUpdate(object sender, EventArgs e)
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
			bool isValid = true;
			m_BlockEvents = true;
			if (displayValue == null)
			{
				m_TextBox.AsString = "";
			}
			else if (displayValue is ValueString)
			{
				m_TextBox.AsString = (displayValue as ValueString).AsString;
			}
			else if (displayValue is string)
			{
				m_TextBox.AsString = (string)displayValue;
			}
			else
			{
				isValid = false;
			}
			m_BlockEvents = false;
			IsValid = isValid;
		}

		private void DownloadDisplay(object target)
		{
			if (IsValid)
			{
				object displayValue = PropertyAdapter.GetDisplayValue(target);
				if (displayValue == null && AsString != string.Empty)
				{
					PropertyAdapter.SetValue(target, AsString);
				}
				else if (displayValue is ValueString)
				{
					PropertyAdapter.SetValue(target, new ValueString(AsString));
				}
				else if (displayValue is string)
				{
					PropertyAdapter.SetValue(target, AsString);
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
			if (displayValue is ValueString)
			{
				return (displayValue as ValueString).AsString != AsString;
			}
			if (displayValue is string)
			{
				return (string)displayValue != AsString;
			}
			return false;
		}
	}
}
