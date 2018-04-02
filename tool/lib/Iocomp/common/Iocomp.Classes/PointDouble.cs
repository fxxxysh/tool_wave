using Iocomp.Design;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(CollectionItemConverter))]
	public sealed class PointDouble : SubClassBase
	{
		private double m_X;

		private double m_Y;

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double X
		{
			get
			{
				return m_X;
			}
			set
			{
				base.PropertyUpdateDefault("X", value);
				if (X != value)
				{
					m_X = value;
					base.DoPropertyChange(this, "X");
				}
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Y
		{
			get
			{
				return m_Y;
			}
			set
			{
				base.PropertyUpdateDefault("Y", value);
				if (Y != value)
				{
					m_Y = value;
					base.DoPropertyChange(this, "Y");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Point Double";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PointDoubleEditorPlugIn";
		}

		public PointDouble()
		{
			base.DoCreate();
		}

		public PointDouble(double x, double y)
		{
			base.DoCreate();
			X = x;
			Y = y;
		}

		protected override void SetDefaults()
		{
			X = 0.0;
			Y = 0.0;
		}

		private bool ShouldSerializeX()
		{
			return base.PropertyShouldSerialize("X");
		}

		private void ResetX()
		{
			base.PropertyReset("X");
		}

		private bool ShouldSerializeY()
		{
			return base.PropertyShouldSerialize("Y");
		}

		private void ResetY()
		{
			base.PropertyReset("Y");
		}

		public override string ToString()
		{
			return X.ToString(CultureInfo.CurrentCulture) + ", " + Y.ToString(CultureInfo.CurrentCulture);
		}
	}
}
