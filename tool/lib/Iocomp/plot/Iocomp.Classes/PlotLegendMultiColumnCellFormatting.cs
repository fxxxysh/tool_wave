using Iocomp.Design;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(CollectionItemConverter))]
	public sealed class PlotLegendMultiColumnCellFormatting : SubClassBase
	{
		private Font m_TitleFont;

		private Font m_DataFont;

		private double m_MarginOuter;

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Font TitleFont
		{
			get
			{
				if (m_TitleFont == null && base.AmbientOwner != null)
				{
					return base.AmbientOwner.Font;
				}
				return m_TitleFont;
			}
			set
			{
				if (!GPFunctions.Equals(TitleFont, value))
				{
					m_TitleFont = value;
					base.DoPropertyChange(this, "TitleFont");
				}
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public Font DataFont
		{
			get
			{
				if (m_DataFont == null && base.AmbientOwner != null)
				{
					return base.AmbientOwner.Font;
				}
				return m_DataFont;
			}
			set
			{
				if (!GPFunctions.Equals(DataFont, value))
				{
					m_DataFont = value;
					base.DoPropertyChange(this, "DataFont");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public double MarginOuter
		{
			get
			{
				return m_MarginOuter;
			}
			set
			{
				base.PropertyUpdateDefault("MarginOuter", value);
				if (MarginOuter != value)
				{
					m_MarginOuter = value;
					base.DoPropertyChange(this, "MarginOuter");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Plot Legend Multi-Column Item";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLegendMultiColumnEditorPlugIn";
		}

		public PlotLegendMultiColumnCellFormatting()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
		}

		protected override void SetDefaults()
		{
			MarginOuter = 0.2;
		}

		private bool ShouldSerializeTitleFont()
		{
			return base.PropertyShouldSerialize("TitleFont");
		}

		private void ResetTitleFont()
		{
			base.PropertyReset("TitleFont");
		}

		private bool ShouldSerializeDataFont()
		{
			return base.PropertyShouldSerialize("DataFont");
		}

		private void ResetDataFont()
		{
			base.PropertyReset("DataFont");
		}

		private bool ShouldSerializeMarginOuter()
		{
			return base.PropertyShouldSerialize("MarginOuter");
		}

		private void ResetMarginOuter()
		{
			base.PropertyReset("MarginOuter");
		}
	}
}
