using Iocomp.Design;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(CollectionItemConverter))]
	public sealed class GradientColor : SubClassBase
	{
		private Color m_Color;

		private double m_Position;

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public new Color Color
		{
			get
			{
				return m_Color;
			}
			set
			{
				base.PropertyUpdateDefault("Color", value);
				if (Color != value)
				{
					m_Color = value;
					base.DoPropertyChange(this, "Color");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public double Position
		{
			get
			{
				return m_Position;
			}
			set
			{
				if (value < 0.0)
				{
					value = 0.0;
				}
				if (value > 1.0)
				{
					value = 1.0;
				}
				base.PropertyUpdateDefault("Position", value);
				if (Position != value)
				{
					m_Position = value;
					base.DoPropertyChange(this, "Position");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Gradient Color";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.GradientColorEditorPlugIn";
		}

		public GradientColor()
		{
			base.DoCreate();
		}

		public GradientColor(Color color, double position)
		{
			base.DoCreate();
			m_Color = color;
			m_Position = position;
		}

		protected override void SetDefaults()
		{
			Color = Color.Orange;
			Position = 0.0;
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializePosition()
		{
			return base.PropertyShouldSerialize("Position");
		}

		private void ResetPosition()
		{
			base.PropertyReset("Position");
		}

		public override string ToString()
		{
			return Color.ToString() + ", " + Position.ToString(CultureInfo.CurrentCulture);
		}
	}
}
