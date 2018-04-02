using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Description("Contains the properties that control the text's shadow.")]
	public sealed class ScaleDiscreetMarker : SubClassBase, IScaleDiscreetMarker
	{
		private int m_Size;

		private MarkerStyleLabel m_Style;

		private BevelStyle m_BevelStyle;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public MarkerStyleLabel Style
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public BevelStyle BevelStyle
		{
			get
			{
				return m_BevelStyle;
			}
			set
			{
				base.PropertyUpdateDefault("BevelStyle", value);
				if (BevelStyle != value)
				{
					m_BevelStyle = value;
					base.DoPropertyChange(this, "BevelStyle");
				}
			}
		}

		[Description("")]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int Size
		{
			get
			{
				return m_Size;
			}
			set
			{
				base.PropertyUpdateDefault("Size", value);
				if (Size != value)
				{
					m_Size = value;
					base.DoPropertyChange(this, "Size");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Scale Marker";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleDiscreetMarkerEditorPlugIn";
		}

		void IScaleDiscreetMarker.Draw(PaintArgs p, Point centerPoint, Color backColor)
		{
			Draw(p, centerPoint, backColor);
		}

		public ScaleDiscreetMarker()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private bool ShouldSerializeBevelStyle()
		{
			return base.PropertyShouldSerialize("BevelStyle");
		}

		private void ResetBevelStyle()
		{
			base.PropertyReset("BevelStyle");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeSize()
		{
			return base.PropertyShouldSerialize("Size");
		}

		private void ResetSize()
		{
			base.PropertyReset("Size");
		}

		private void Draw(PaintArgs p, Point centerPoint, Color backColor)
		{
			if (Style != MarkerStyleLabel.None)
			{
				Rectangle rectangle;
				if (Style == MarkerStyleLabel.Circle)
				{
					p.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
					rectangle = new Rectangle(centerPoint.X - Size, centerPoint.Y - Size, 2 * Size, 2 * Size);
					BorderSpecial.DrawEllipse(p, rectangle, BevelStyle, 1f, backColor);
					rectangle.Inflate(-2, -2);
					p.Graphics.FillEllipse(p.Graphics.Brush(Color), rectangle);
					rectangle.Inflate(2, 2);
					p.Graphics.SmoothingMode = SmoothingMode.Default;
				}
				else if (Style == MarkerStyleLabel.Square)
				{
					rectangle = new Rectangle(centerPoint.X - Size, centerPoint.Y - Size, 2 * Size, 2 * Size);
					p.Graphics.FillRectangle(p.Graphics.Brush(Color), rectangle);
					BorderSpecial.DrawRectangle(p, rectangle, BevelStyle, 2, backColor);
				}
				else if (Style == MarkerStyleLabel.Line)
				{
					rectangle = new Rectangle(centerPoint.X - Size, centerPoint.Y - 1, 2 * Size, 2);
					if (BevelStyle == BevelStyle.Raised)
					{
						BorderSimple.Draw(p, rectangle, BorderStyleSimple.RaisedInner, backColor);
					}
					else if (BevelStyle == BevelStyle.Sunken)
					{
						BorderSimple.Draw(p, rectangle, BorderStyleSimple.SunkenInner, backColor);
					}
				}
			}
		}
	}
}
