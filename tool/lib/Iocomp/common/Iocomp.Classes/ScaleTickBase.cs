using Iocomp.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	public abstract class ScaleTickBase : SubClassBase, IScaleTickBase
	{
		private double m_Value;

		private int m_Thickness;

		private int m_Length;

		private bool m_Permanent;

		private IScaleDisplay m_Display;

		IScaleDisplay IScaleTickBase.Display
		{
			get
			{
				return Display;
			}
			set
			{
				Display = value;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Browsable(false)]
		public double Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				base.PropertyUpdateDefault("Value", value);
				if (Value != value)
				{
					m_Value = value;
					base.DoPropertyChange(this, "Value");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int Thickness
		{
			get
			{
				return m_Thickness;
			}
			set
			{
				base.PropertyUpdateDefault("Thickness", value);
				if (Thickness != value)
				{
					m_Thickness = value;
					base.DoPropertyChange(this, "Thickness");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int Length
		{
			get
			{
				return m_Length;
			}
			set
			{
				base.PropertyUpdateDefault("Length", value);
				if (Length != value)
				{
					m_Length = value;
					base.DoPropertyChange(this, "Length");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		[Browsable(false)]
		[RefreshProperties(RefreshProperties.All)]
		public bool Permanent
		{
			get
			{
				return m_Permanent;
			}
			set
			{
				base.PropertyUpdateDefault("Permanent", value);
				if (Permanent != value)
				{
					m_Permanent = value;
					base.DoPropertyChange(this, "Permanent");
				}
			}
		}

		protected IScaleDisplay Display
		{
			get
			{
				return m_Display;
			}
			set
			{
				m_Display = value;
			}
		}

		void IScaleTickBase.Draw(PaintArgs p, DrawStringFormat format, int majorLength)
		{
			Draw(p, format, majorLength);
		}

		int IScaleTickBase.GetScaleWidth()
		{
			return GetScaleWidth();
		}

		private bool ShouldSerializeValue()
		{
			return base.PropertyShouldSerialize("Value");
		}

		private void ResetValue()
		{
			base.PropertyReset("Value");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeThickness()
		{
			return base.PropertyShouldSerialize("Thickness");
		}

		private void ResetThickness()
		{
			base.PropertyReset("Thickness");
		}

		private bool ShouldSerializeLength()
		{
			return base.PropertyShouldSerialize("Length");
		}

		private void ResetLength()
		{
			base.PropertyReset("Length");
		}

		protected abstract void Draw(PaintArgs p, DrawStringFormat format, int majorLength);

		protected abstract int GetScaleWidth();
	}
}
