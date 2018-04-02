using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Contains properties to control the user interface characteristics.")]
	public class UIControl : SubClassBase
	{
		private bool m_KeyboardEnabled;

		private bool m_MouseWheelEnabled;

		private bool m_FocusRectangleShow;

		[RefreshProperties(RefreshProperties.All)]
		[Description("Determines if user keyboard control is enabled.")]
		public bool KeyboardEnabled
		{
			get
			{
				return m_KeyboardEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("KeyboardEnabled", value);
				if (KeyboardEnabled != value)
				{
					m_KeyboardEnabled = value;
					base.DoPropertyChange(this, "KeyboardEnabled");
				}
			}
		}

		[Description("Determines if the user can manipulate the control with the mouse wheel.")]
		[RefreshProperties(RefreshProperties.All)]
		public bool MouseWheelEnabled
		{
			get
			{
				return m_MouseWheelEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("MouseWheelEnabled", value);
				if (MouseWheelEnabled != value)
				{
					m_MouseWheelEnabled = value;
					base.DoPropertyChange(this, "MouseWheelEnabled");
				}
			}
		}

		[Description("Determines if the focus rectangle is drawn when the control has the keyboard focus.")]
		[RefreshProperties(RefreshProperties.All)]
		public bool FocusRectangleShow
		{
			get
			{
				return m_FocusRectangleShow;
			}
			set
			{
				base.PropertyUpdateDefault("FocusRectangleShow", value);
				if (FocusRectangleShow != value)
				{
					m_FocusRectangleShow = value;
					base.DoPropertyChange(this, "FocusRectangleShow");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "UI Control";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.UIControlEditorPlugIn";
		}

		public UIControl()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeKeyboardEnabled()
		{
			return base.PropertyShouldSerialize("KeyboardEnabled");
		}

		private void ResetKeyboardEnabled()
		{
			base.PropertyReset("KeyboardEnabled");
		}

		private bool ShouldSerializeMouseWheelEnabled()
		{
			return base.PropertyShouldSerialize("MouseWheelEnabled");
		}

		private void ResetMouseWheelEnabled()
		{
			base.PropertyReset("MouseWheelEnabled");
		}

		private bool ShouldSerializeFocusRectangleShow()
		{
			return base.PropertyShouldSerialize("FocusRectangleShow");
		}

		private void ResetFocusRectangleShow()
		{
			base.PropertyReset("FocusRectangleShow");
		}
	}
}
