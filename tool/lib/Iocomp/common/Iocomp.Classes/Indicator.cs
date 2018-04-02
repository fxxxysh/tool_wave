using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Contains the properties that control the appearance for the indicator.")]
	public class Indicator : SubClassBase
	{
		private Color m_ColorActive;

		private Color m_ColorInactive;

		private bool m_ColorInactiveAuto;

		[Description("Specifies the indicator color when the switch value is true.")]
		[RefreshProperties(RefreshProperties.All)]
		public Color ColorActive
		{
			get
			{
				return m_ColorActive;
			}
			set
			{
				base.PropertyUpdateDefault("ColorActive", value);
				if (ColorActive != value)
				{
					m_ColorActive = value;
					base.DoPropertyChange(this, "ColorActive");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the indicator color when the switch value is false.")]
		public Color ColorInactive
		{
			get
			{
				return m_ColorInactive;
			}
			set
			{
				base.PropertyUpdateDefault("ColorInactive", value);
				if (ColorInactive != value)
				{
					m_ColorInactive = value;
					base.DoPropertyChange(this, "ColorInactive");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Indicates if the inactive color is automatically calculated.")]
		public bool ColorInactiveAuto
		{
			get
			{
				return m_ColorInactiveAuto;
			}
			set
			{
				base.PropertyUpdateDefault("ColorInactiveAuto", value);
				if (ColorInactiveAuto != value)
				{
					m_ColorInactiveAuto = value;
					base.DoPropertyChange(this, "ColorInactiveAuto");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Indicator";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.IndicatorEditorPlugIn";
		}

		public Indicator()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeColorActive()
		{
			return base.PropertyShouldSerialize("ColorActive");
		}

		private void ResetColorActive()
		{
			base.PropertyReset("ColorActive");
		}

		private bool ShouldSerializeColorInactive()
		{
			return base.PropertyShouldSerialize("ColorInactive");
		}

		private void ResetColorInactive()
		{
			base.PropertyReset("ColorInactive");
		}

		private bool ShouldSerializeColorInactiveAuto()
		{
			return base.PropertyShouldSerialize("ColorInactiveAuto");
		}

		private void ResetColorInactiveAuto()
		{
			base.PropertyReset("ColorInactiveAuto");
		}

		public Color GetStateColor(bool value)
		{
			if (value)
			{
				return ColorActive;
			}
			if (ColorInactiveAuto)
			{
				return iColors.ToOffColor(ColorActive);
			}
			return ColorInactive;
		}
	}
}
