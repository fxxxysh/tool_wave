using Iocomp.Design.Components;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[Designer(typeof(ColorPickerDesigner))]
	[Description("PlugIn Editor Color Picker")]
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	[DefaultEvent("")]
	public class ColorPicker : Control, IPlugInEditorControl
	{
		private int m_BorderWidth;

		private int m_ButtonWidth;

		private Rectangle m_ButtonRect;

		private bool m_MouseDown;

		private ColorPickerStyle m_Style;

		private PlugInEditorControlPropertyAdapter m_PropertyAdapter;

		private IPlugInStandard m_PlugInForm;

		private object m_UploadSource;

		private Color m_Color;

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

		protected override Size DefaultSize => new Size(141, 21);

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

		[DefaultValue(typeof(Color), "Empty")]
		public Color Color
		{
			get
			{
				return m_Color;
			}
			set
			{
				if (m_Color != value)
				{
					m_Color = value;
					base.Invalidate();
					OnColorChanged();
				}
			}
		}

		[DefaultValue(typeof(SystemColors), "Window")]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		[DefaultValue(ColorPickerStyle.ColorBoxAndText)]
		public ColorPickerStyle Style
		{
			get
			{
				return m_Style;
			}
			set
			{
				if (m_Style != value)
				{
					m_Style = value;
					base.Invalidate();
				}
			}
		}

		public event EventHandler ColorChanged;

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

		public ColorPicker()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			base.UpdateStyles();
			m_Style = ColorPickerStyle.ColorBoxAndText;
			m_PropertyAdapter = new PlugInEditorControlPropertyAdapter();
			BackColor = SystemColors.Window;
			IsValid = true;
			ColorChanged += ColorPicker_ColorChanged;
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
					BackColor = SystemColors.Control;
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
				ColorChanged -= ColorPicker_ColorChanged;
				Color = Color.Empty;
			}
		}

		private void OnColorChanged()
		{
			if (!m_BlockEvents && this.ColorChanged != null)
			{
				this.ColorChanged(this, EventArgs.Empty);
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			base.Focus();
			if (m_ButtonRect.Contains(e.X, e.Y))
			{
				m_MouseDown = true;
			}
			base.Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (m_MouseDown)
			{
				m_MouseDown = false;
				if (m_ButtonRect.Contains(e.X, e.Y))
				{
					ShowDialog();
				}
				base.Invalidate();
			}
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			if (e.KeyChar == ' ')
			{
				ShowDialog();
				e.Handled = true;
			}
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			base.Invalidate();
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			m_MouseDown = false;
			base.Invalidate();
		}

		protected void DrawButton(PaintEventArgs e)
		{
			StringFormat genericDefault = StringFormat.GenericDefault;
			genericDefault.LineAlignment = StringAlignment.Center;
			genericDefault.Alignment = StringAlignment.Center;
			m_ButtonRect = new Rectangle(base.Width - m_BorderWidth - m_ButtonWidth, m_BorderWidth, m_ButtonWidth, base.Height - 2 * m_BorderWidth);
			Brush brush = new SolidBrush(SystemColors.Control);
			e.Graphics.FillRectangle(brush, m_ButtonRect);
			brush.Dispose();
			brush = ((!base.Enabled) ? new SolidBrush(SystemColors.GrayText) : new SolidBrush(ForeColor));
			e.Graphics.DrawString("...", Font, brush, m_ButtonRect, genericDefault);
			brush.Dispose();
			if (m_MouseDown)
			{
				ControlPaint.DrawBorder3D(e.Graphics, m_ButtonRect, Border3DStyle.Sunken);
			}
			else
			{
				ControlPaint.DrawBorder3D(e.Graphics, m_ButtonRect, Border3DStyle.Raised);
			}
			if (Focused)
			{
				Rectangle buttonRect = m_ButtonRect;
				buttonRect.Inflate(-2, -2);
				ControlPaint.DrawFocusRectangle(e.Graphics, buttonRect, Color.White, BackColor);
			}
		}

		protected void DrawColorBoxAndText(PaintEventArgs e)
		{
			m_BorderWidth = 2;
			m_ButtonWidth = (int)e.Graphics.MeasureString("....", Font).Width + 1;
			int num = base.Height - 2 * m_BorderWidth;
			Rectangle rect = new Rectangle(m_BorderWidth + 2, 2 * m_BorderWidth, 20, num - 2 * m_BorderWidth - 1);
			Brush brush = new SolidBrush(Color);
			e.Graphics.FillRectangle(brush, rect);
			brush.Dispose();
			if (base.Enabled)
			{
				e.Graphics.DrawRectangle(Pens.Black, rect);
			}
			else
			{
				e.Graphics.DrawRectangle(SystemPens.GrayText, rect);
			}
			DrawButton(e);
			int num2 = rect.Right + 2;
			Rectangle r = new Rectangle(num2, m_BorderWidth, m_ButtonRect.Left - num2, num);
			StringFormat genericDefault = StringFormat.GenericDefault;
			genericDefault.LineAlignment = StringAlignment.Center;
			genericDefault.Alignment = StringAlignment.Near;
			genericDefault.Trimming = StringTrimming.EllipsisCharacter;
			genericDefault.FormatFlags = StringFormatFlags.NoWrap;
			string s = (!(Color == Color.Empty)) ? ((!Color.IsKnownColor) ? string.Format(CultureInfo.CurrentCulture, "{0}, {1}, {2}", new object[3]
			{
				Color.R,
				Color.G,
				Color.B
			}) : Color.ToKnownColor().ToString()) : "Empty (Reset)";
			brush = ((!base.Enabled) ? new SolidBrush(SystemColors.GrayText) : new SolidBrush(ForeColor));
			e.Graphics.DrawString(s, Font, brush, r, genericDefault);
			brush.Dispose();
			ControlPaint.DrawBorder3D(e.Graphics, base.ClientRectangle, Border3DStyle.Sunken);
			base.OnPaint(e);
		}

		protected void DrawColorBox(PaintEventArgs e)
		{
			m_BorderWidth = 0;
			m_ButtonWidth = base.Height;
			DrawButton(e);
			int height = base.Height;
			Rectangle rect = new Rectangle(0, 0, base.Width - m_ButtonRect.Width - 1, base.Height - 1);
			Brush brush = new SolidBrush(Color);
			e.Graphics.FillRectangle(brush, rect);
			brush.Dispose();
			if (base.Enabled)
			{
				e.Graphics.DrawRectangle(Pens.Black, rect);
			}
			else
			{
				e.Graphics.DrawRectangle(SystemPens.GrayText, rect);
			}
			base.OnPaint(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (m_Style == ColorPickerStyle.ColorBoxAndText)
			{
				DrawColorBoxAndText(e);
			}
			else
			{
				DrawColorBox(e);
			}
			base.OnPaint(e);
		}

		private void ShowDialog()
		{
			Iocomp.Design.Components.ColorDialog colorDialog = new Iocomp.Design.Components.ColorDialog();
			if (colorDialog.ShowDialog(Color) == DialogResult.OK)
			{
				Color = colorDialog.Color;
			}
			colorDialog.Dispose();
		}

		private void ColorPicker_ColorChanged(object sender, EventArgs e)
		{
			DownloadDisplay(m_UploadSource);
			if (PlugInForm != null)
			{
				PlugInForm.ForceDirtyUpdate();
			}
		}

		public void UploadDisplay(object source)
		{
			m_UploadSource = source;
			object displayValue = PropertyAdapter.GetDisplayValue(source);
			bool flag = displayValue != null && true;
			if (flag)
			{
				if (displayValue is Color)
				{
					m_BlockEvents = true;
					Color = (Color)displayValue;
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
				if (displayValue != null && displayValue is Color)
				{
					PropertyAdapter.SetValue(target, Color);
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
			if (displayValue is Color)
			{
				return (Color)displayValue != Color;
			}
			return false;
		}
	}
}
