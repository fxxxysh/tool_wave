using Iocomp.Interfaces;
using System;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("")]
	public sealed class ScaleAnnotation : SubClassBase, IScaleAnnotation
	{
		private double m_OriginX;

		private double m_OriginY;

		private double m_SpanX;

		private double m_SpanY;

		private int m_PixelLeft;

		private int m_PixelTop;

		private int m_PixelWidth;

		private int m_PixelHeight;

		int IScaleAnnotation.PixelLeft
		{
			get
			{
				return PixelLeft;
			}
			set
			{
				PixelLeft = value;
			}
		}

		int IScaleAnnotation.PixelTop
		{
			get
			{
				return PixelTop;
			}
			set
			{
				PixelTop = value;
			}
		}

		int IScaleAnnotation.PixelWidth
		{
			get
			{
				return PixelWidth;
			}
			set
			{
				PixelWidth = value;
			}
		}

		int IScaleAnnotation.PixelHeight
		{
			get
			{
				return PixelHeight;
			}
			set
			{
				PixelHeight = value;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public double OriginX
		{
			get
			{
				return m_OriginX;
			}
			set
			{
				base.PropertyUpdateDefault("OriginX", value);
				if (OriginX != value)
				{
					m_OriginX = value;
					base.DoPropertyChange(this, "OriginX");
				}
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double OriginY
		{
			get
			{
				return m_OriginY;
			}
			set
			{
				base.PropertyUpdateDefault("OriginY", value);
				if (OriginY != value)
				{
					m_OriginY = value;
					base.DoPropertyChange(this, "OriginY");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public double SpanX
		{
			get
			{
				return m_SpanX;
			}
			set
			{
				base.PropertyUpdateDefault("SpanX", value);
				if (SpanX != value)
				{
					m_SpanX = value;
					base.DoPropertyChange(this, "SpanX");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Category("Iocomp")]
		public double SpanY
		{
			get
			{
				return m_SpanY;
			}
			set
			{
				base.PropertyUpdateDefault("SpanY", value);
				if (SpanY != value)
				{
					m_SpanY = value;
					base.DoPropertyChange(this, "SpanY");
				}
			}
		}

		private int PixelLeft
		{
			get
			{
				return m_PixelLeft;
			}
			set
			{
				m_PixelLeft = value;
			}
		}

		private int PixelTop
		{
			get
			{
				return m_PixelTop;
			}
			set
			{
				m_PixelTop = value;
			}
		}

		private int PixelWidth
		{
			get
			{
				return m_PixelWidth;
			}
			set
			{
				m_PixelWidth = value;
			}
		}

		private int PixelHeight
		{
			get
			{
				return m_PixelHeight;
			}
			set
			{
				m_PixelHeight = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Scale";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleAnnotationEditorPlugIn";
		}

		public ScaleAnnotation()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeOriginX()
		{
			return base.PropertyShouldSerialize("OriginX");
		}

		private void ResetOriginX()
		{
			base.PropertyReset("OriginX");
		}

		private bool ShouldSerializeOriginY()
		{
			return base.PropertyShouldSerialize("OriginY");
		}

		private void ResetOriginY()
		{
			base.PropertyReset("OriginY");
		}

		private bool ShouldSerializeSpanX()
		{
			return base.PropertyShouldSerialize("SpanX");
		}

		private void ResetSpanX()
		{
			base.PropertyReset("SpanX");
		}

		private bool ShouldSerializeSpanY()
		{
			return base.PropertyShouldSerialize("SpanY");
		}

		private void ResetSpanY()
		{
			base.PropertyReset("SpanY");
		}

		public int ConvertUnitsToPixelsX(double value)
		{
			double num = (double)PixelLeft + value * (double)PixelWidth / SpanX - OriginX * (double)PixelWidth / SpanX + (double)((float)PixelWidth / 2f);
			if (num > 1E+30)
			{
				num = 1E+30;
			}
			if (num < -1E+30)
			{
				num = -1E+30;
			}
			return (int)num;
		}

		public int ConvertUnitsToPixelsY(double value)
		{
			double num = (double)PixelTop + (0.0 - value) * (double)PixelHeight / SpanY - OriginY * (double)PixelHeight / SpanY + (double)((float)PixelHeight / 2f);
			if (num > 1E+30)
			{
				num = 1E+30;
			}
			if (num < -1E+30)
			{
				num = -1E+30;
			}
			return (int)num;
		}

		public double ConvertPixelsToUnitsX(int value)
		{
			return (double)(value - PixelLeft) * SpanX / (double)PixelWidth + OriginX - SpanX / 2.0;
		}

		public double ConvertPixelsToUnitsY(int value)
		{
			return (double)(-(value - PixelTop)) * SpanY / (double)PixelHeight - OriginY + SpanY / 2.0;
		}

		public int ConvertHeightUnitsToPixels(double value)
		{
			return Math.Abs(ConvertUnitsToPixelsY(value) - ConvertUnitsToPixelsY(0.0));
		}

		public int ConvertWidthUnitsToPixels(double value)
		{
			return Math.Abs(ConvertUnitsToPixelsX(value) - ConvertUnitsToPixelsX(0.0));
		}
	}
}
