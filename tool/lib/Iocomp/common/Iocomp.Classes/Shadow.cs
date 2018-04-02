using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Contains the properties that control the text's shadow.")]
	public sealed class Shadow : SubClassBase
	{
		private int m_Offset;

		private bool m_Stretched;

		private ShadowStyle m_Style;

		[Description("Indicates the color of the text shadow.")]
		[RefreshProperties(RefreshProperties.All)]
		public new Color Color
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.Color = value;
			}
		}

		[Description("Indicates the value to offset the text shadow in relation to the text in an X and Y orientation")]
		[RefreshProperties(RefreshProperties.All)]
		public int Offset
		{
			get
			{
				return m_Offset;
			}
			set
			{
				base.PropertyUpdateDefault("Offset", value);
				if (value < 0)
				{
					base.ThrowStreamingSafeException("Thickness value must be 2 or greater.");
				}
				if (value < 0)
				{
					value = 0;
				}
				if (Offset != value)
				{
					m_Offset = value;
					base.DoPropertyChange(this, "Offset");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the shadow style to be applied to the shadow text.")]
		public ShadowStyle Style
		{
			get
			{
				return m_Style;
			}
			set
			{
				base.PropertyUpdateDefault("Style", value);
				if (Style != value)
				{
					m_Style = value;
					base.DoPropertyChange(this, "Style");
				}
			}
		}

		[Description("Specifies if the shadow style will have a stretched appearance.")]
		[RefreshProperties(RefreshProperties.All)]
		public bool Stretched
		{
			get
			{
				return m_Stretched;
			}
			set
			{
				base.PropertyUpdateDefault("Stretched", value);
				if (Stretched != value)
				{
					m_Stretched = value;
					base.DoPropertyChange(this, "Stretched");
				}
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int ActualOffset
		{
			get
			{
				if (m_Style == ShadowStyle.None)
				{
					return 0;
				}
				return Offset;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Shadow";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ShadowEditorPlugIn";
		}

		public Shadow()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeOffset()
		{
			return base.PropertyShouldSerialize("Offset");
		}

		private void ResetOffset()
		{
			base.PropertyReset("Offset");
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private bool ShouldSerializeStretched()
		{
			return base.PropertyShouldSerialize("Stretched");
		}

		private void ResetStretched()
		{
			base.PropertyReset("Stretched");
		}
	}
}
