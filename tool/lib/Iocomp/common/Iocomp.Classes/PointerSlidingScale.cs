using Iocomp.Design;
using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("")]
	[TypeConverter(typeof(CollectionItemConverter))]
	public sealed class PointerSlidingScale : SubClassBase, IPointerSlidingScale
	{
		private ValueDouble m_Value;

		private PointerStyleSlidingScale m_Style;

		private Color m_LineColor;

		private int m_LineWidth;

		private int m_Size;

		int IPointerSlidingScale.SpaceLeft
		{
			get
			{
				return SpaceLeft;
			}
		}

		int IPointerSlidingScale.SpaceRight
		{
			get
			{
				return SpaceRight;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[RefreshProperties(RefreshProperties.All)]
		public ValueDouble Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				m_Value.AsDouble = value.AsDouble;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public PointerStyleSlidingScale Style
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color LineColor
		{
			get
			{
				return m_LineColor;
			}
			set
			{
				base.PropertyUpdateDefault("LineColor", value);
				if (LineColor != value)
				{
					m_LineColor = value;
					base.DoPropertyChange(this, "LineColor");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int LineWidth
		{
			get
			{
				return m_LineWidth;
			}
			set
			{
				base.PropertyUpdateDefault("LineWidth", value);
				if (LineWidth != value)
				{
					m_LineWidth = value;
					base.DoPropertyChange(this, "LineWidth");
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

		private int SpaceLeft
		{
			get
			{
				if (!Visible)
				{
					return 0;
				}
				if (Style == PointerStyleSlidingScale.DualArrow)
				{
					return Size;
				}
				if (Style == PointerStyleSlidingScale.Arrow)
				{
					return Size;
				}
				if (Style == PointerStyleSlidingScale.Pointer)
				{
					return Size * 2;
				}
				return 0;
			}
		}

		private int SpaceRight
		{
			get
			{
				if (!Visible)
				{
					return 0;
				}
				if (Style == PointerStyleSlidingScale.DualArrow)
				{
					return Size;
				}
				return 0;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Pointer";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PointerSlidingScaleEditorPlugIn";
		}

		void IPointerSlidingScale.Draw(PaintArgs p, int referenceY)
		{
			Draw(p, referenceY);
		}

		public PointerSlidingScale()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Value = new ValueDouble();
			base.AddSubClass(Value);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Visible = true;
			Style = PointerStyleSlidingScale.DualArrow;
			Color = Color.Yellow;
			Size = 10;
			LineColor = Color.Blue;
			LineWidth = 2;
		}

		private bool ShouldSerializeValue()
		{
			return ((ISubClassBase)Value).ShouldSerialize();
		}

		private void ResetValue()
		{
			((ISubClassBase)Value).ResetToDefault();
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private bool ShouldSerializeSize()
		{
			return base.PropertyShouldSerialize("Size");
		}

		private void ResetSize()
		{
			base.PropertyReset("Size");
		}

		private bool ShouldSerializeLineColor()
		{
			return base.PropertyShouldSerialize("LineColor");
		}

		private void ResetLineColor()
		{
			base.PropertyReset("LineColor");
		}

		private bool ShouldSerializeLineWidth()
		{
			return base.PropertyShouldSerialize("LineWidth");
		}

		private void ResetLineWidth()
		{
			base.PropertyReset("LineWidth");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private void Draw(PaintArgs p, int referenceY)
		{
			if (Visible)
			{
				if (Style == PointerStyleSlidingScale.DualArrow)
				{
					Rectangle r = new Rectangle(p.Left, referenceY - Size / 2, Size, Size);
					Point[] trianglePoints = Shapes.GetTrianglePoints(r, Direction.Right);
					p.Graphics.FillPolygon(p.Graphics.Brush(Color), trianglePoints);
					r = new Rectangle(p.Right - Size, referenceY - Size / 2, Size, Size);
					trianglePoints = Shapes.GetTrianglePoints(r, Direction.Left);
					p.Graphics.FillPolygon(p.Graphics.Brush(Color), trianglePoints);
					p.Graphics.DrawLine(p.Graphics.Pen(LineColor, (float)LineWidth), p.Left + Size, referenceY, p.Right - Size, referenceY);
				}
				else if (Style == PointerStyleSlidingScale.Arrow)
				{
					Rectangle r = new Rectangle(p.Left, referenceY - Size / 2, Size, Size);
					Point[] trianglePoints = Shapes.GetTrianglePoints(r, Direction.Right);
					p.Graphics.FillPolygon(p.Graphics.Brush(Color), trianglePoints);
				}
				else if (Style == PointerStyleSlidingScale.Pointer)
				{
					Rectangle r = new Rectangle(p.Left, referenceY - Size / 2, 2 * Size, Size);
					Point[] trianglePoints = Shapes.GetPointerPoints(r, Direction.Right);
					p.Graphics.FillPolygon(p.Graphics.Brush(Color), trianglePoints);
				}
				else if (Style == PointerStyleSlidingScale.Line)
				{
					p.Graphics.DrawLine(p.Graphics.Pen(LineColor, (float)LineWidth), p.Left, referenceY, p.Right, referenceY);
				}
			}
		}

		public override string ToString()
		{
			return "Pointer-" + Color.ToString();
		}
	}
}
