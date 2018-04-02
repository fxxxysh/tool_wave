using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Controls the text alignment and positioning.")]
	public class AlignmentText : SubClassBase
	{
		private StringAlignment m_Style;

		private double m_Margin;

		[Description("Controls the style of the text alignment and positioning.")]
		[RefreshProperties(RefreshProperties.All)]
		public StringAlignment Style
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("Controls the margin spacing of the text.")]
		public double Margin
		{
			get
			{
				return m_Margin;
			}
			set
			{
				base.PropertyUpdateDefault("Margin", value);
				if (Margin != value)
				{
					m_Margin = value;
					base.DoPropertyChange(this, "Margin");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Alignment Text";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AlignmentTextEditorPlugIn";
		}

		public AlignmentText()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Style = StringAlignment.Center;
			Margin = 0.0;
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private bool ShouldSerializeMargin()
		{
			return base.PropertyShouldSerialize("Margin");
		}

		private void ResetMargin()
		{
			base.PropertyReset("Margin");
		}
	}
}
