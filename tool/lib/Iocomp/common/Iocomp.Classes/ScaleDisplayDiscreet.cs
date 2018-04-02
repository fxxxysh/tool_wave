using Iocomp.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Controls the scale display layout properties.")]
	public abstract class ScaleDisplayDiscreet : SubClassBase, IScaleDisplayDiscreet
	{
		private Font m_TextActiveFont;

		private Font m_TextInactiveFont;

		private Color m_TextActiveForeColor;

		private Color m_TextInactiveForeColor;

		private int m_TextMargin;

		private ScaleDiscreetMarker m_Markers;

		private int m_Margin;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Markers properties")]
		public ScaleDiscreetMarker Markers
		{
			get
			{
				return m_Markers;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool Visible
		{
			get
			{
				return VisibleInternal;
			}
			set
			{
				VisibleInternal = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int Margin
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int TextMargin
		{
			get
			{
				return m_TextMargin;
			}
			set
			{
				base.PropertyUpdateDefault("TextMargin", value);
				if (TextMargin != value)
				{
					m_TextMargin = value;
					base.DoPropertyChange(this, "TextMargin");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public Font TextActiveFont
		{
			get
			{
				if (base.GettingDefault)
				{
					return m_TextActiveFont;
				}
				if (m_TextActiveFont == null && ControlBase != null)
				{
					return ControlBase.Font;
				}
				return m_TextActiveFont;
			}
			set
			{
				base.PropertyUpdateDefault("TextActiveFont", value);
				if (!GPFunctions.Equals(TextActiveFont, value))
				{
					m_TextActiveFont = value;
					base.DoPropertyChange(this, "TextActiveFont");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Font TextInactiveFont
		{
			get
			{
				if (base.GettingDefault)
				{
					return m_TextInactiveFont;
				}
				if (m_TextInactiveFont == null && ControlBase != null)
				{
					return ControlBase.Font;
				}
				return m_TextInactiveFont;
			}
			set
			{
				base.PropertyUpdateDefault("TextInactiveFont", value);
				if (!GPFunctions.Equals(TextInactiveFont, value))
				{
					m_TextInactiveFont = value;
					base.DoPropertyChange(this, "TextInactiveFont");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public Color TextActiveForeColor
		{
			get
			{
				if (base.GettingDefault)
				{
					return m_TextActiveForeColor;
				}
				if (m_TextActiveForeColor == Color.Empty && ControlBase != null)
				{
					return ControlBase.ForeColor;
				}
				return m_TextActiveForeColor;
			}
			set
			{
				base.PropertyUpdateDefault("TextActiveForeColor", value);
				if (TextActiveForeColor != value)
				{
					m_TextActiveForeColor = value;
					base.DoPropertyChange(this, "TextActiveForeColor");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color TextInactiveForeColor
		{
			get
			{
				if (base.GettingDefault)
				{
					return m_TextInactiveForeColor;
				}
				if (m_TextInactiveForeColor == Color.Empty && ControlBase != null)
				{
					return ControlBase.ForeColor;
				}
				return m_TextInactiveForeColor;
			}
			set
			{
				base.PropertyUpdateDefault("TextInactiveForeColor", value);
				if (TextInactiveForeColor != value)
				{
					m_TextInactiveForeColor = value;
					base.DoPropertyChange(this, "TextInactiveForeColor");
				}
			}
		}

		void IScaleDisplayDiscreet.Calculate(PaintArgs p, ScaleDiscreetItemCollection items, Point centerPoint, int activeIndex, int pointerExtent)
		{
			Calculate(p, items, centerPoint, activeIndex, pointerExtent);
		}

		void IScaleDisplayDiscreet.Draw(PaintArgs p, ScaleDiscreetItemCollection items, Point centerPoint, int activeIndex, Color backColor)
		{
			Draw(p, items, centerPoint, activeIndex, backColor);
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Markers = new ScaleDiscreetMarker();
			base.AddSubClass(Markers);
		}

		private bool ShouldSerializeMarkers()
		{
			return ((ISubClassBase)Markers).ShouldSerialize();
		}

		private void ResetMarkers()
		{
			((ISubClassBase)Markers).ResetToDefault();
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeMargin()
		{
			return base.PropertyShouldSerialize("Margin");
		}

		private void ResetMargin()
		{
			base.PropertyReset("Margin");
		}

		private bool ShouldSerializeTextMargin()
		{
			return base.PropertyShouldSerialize("TextMargin");
		}

		private void ResetTextMargin()
		{
			base.PropertyReset("TextMargin");
		}

		private bool ShouldSerializeTextActiveFont()
		{
			return base.PropertyShouldSerialize("TextActiveFont");
		}

		private void ResetTextActiveFont()
		{
			base.PropertyReset("TextActiveFont");
		}

		private bool ShouldSerializeTextInactiveFont()
		{
			return base.PropertyShouldSerialize("TextInactiveFont");
		}

		private void ResetTextInactiveFont()
		{
			base.PropertyReset("TextInactiveFont");
		}

		private bool ShouldSerializeTextActiveForeColor()
		{
			return base.PropertyShouldSerialize("TextActiveForeColor");
		}

		private void ResetTextActiveForeColor()
		{
			base.PropertyReset("TextActiveForeColor");
		}

		private bool ShouldSerializeTextInactiveForeColor()
		{
			return base.PropertyShouldSerialize("TextInactiveForeColor");
		}

		private void ResetTextInactiveForeColor()
		{
			base.PropertyReset("TextInactiveForeColor");
		}

		protected abstract void Calculate(PaintArgs p, ScaleDiscreetItemCollection items, Point centerPoint, int activeIndex, int pointerExtent);

		protected abstract void Draw(PaintArgs p, ScaleDiscreetItemCollection items, Point centerPoint, int activeIndex, Color backColor);
	}
}
