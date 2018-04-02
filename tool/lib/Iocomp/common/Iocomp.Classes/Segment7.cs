using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Contains the properties that control the appearance for the indicator.")]
	public sealed class Segment7 : SubClassBase, ISegment7
	{
		private Color m_ColorOn;

		private Color m_ColorOff;

		private bool m_ColorOffAuto;

		private int m_Size;

		private int m_Separation;

		private bool m_ShowOffSegments;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color ColorOn
		{
			get
			{
				return m_ColorOn;
			}
			set
			{
				base.PropertyUpdateDefault("ColorOn", value);
				if (ColorOn != value)
				{
					m_ColorOn = value;
					base.DoPropertyChange(this, "ColorOn");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color ColorOff
		{
			get
			{
				return m_ColorOff;
			}
			set
			{
				base.PropertyUpdateDefault("ColorOff", value);
				if (ColorOff != value)
				{
					m_ColorOff = value;
					base.DoPropertyChange(this, "ColorOff");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ColorOffAuto
		{
			get
			{
				return m_ColorOffAuto;
			}
			set
			{
				base.PropertyUpdateDefault("ColorOffAuto", value);
				if (ColorOffAuto != value)
				{
					m_ColorOffAuto = value;
					base.DoPropertyChange(this, "ColorOffAuto");
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int Separation
		{
			get
			{
				return m_Separation;
			}
			set
			{
				base.PropertyUpdateDefault("Separation", value);
				if (Separation != value)
				{
					m_Separation = value;
					base.DoPropertyChange(this, "Separation");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ShowOffSegments
		{
			get
			{
				return m_ShowOffSegments;
			}
			set
			{
				base.PropertyUpdateDefault("ShowOffSegments", value);
				if (ShowOffSegments != value)
				{
					m_ShowOffSegments = value;
					base.DoPropertyChange(this, "ShowOffSegments");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Segment-7";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.Segment7EditorPlugIn";
		}

		Size ISegment7.GetRequiredSize(Segment7Character character)
		{
			return GetRequiredSize(character);
		}

		void ISegment7.Draw(PaintArgs p, iRectangle r, Segment7Character character)
		{
			Draw(p, r, character);
		}

		public Segment7()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeColorOn()
		{
			return base.PropertyShouldSerialize("ColorOn");
		}

		private void ResetColorOn()
		{
			base.PropertyReset("ColorOn");
		}

		private bool ShouldSerializeColorOff()
		{
			return base.PropertyShouldSerialize("ColorOff");
		}

		private void ResetColorOff()
		{
			base.PropertyReset("ColorOff");
		}

		private bool ShouldSerializeColorOffAuto()
		{
			return base.PropertyShouldSerialize("ColorOffAuto");
		}

		private void ResetColorOffAuto()
		{
			base.PropertyReset("ColorOffAuto");
		}

		private bool ShouldSerializeSize()
		{
			return base.PropertyShouldSerialize("Size");
		}

		private void ResetSize()
		{
			base.PropertyReset("Size");
		}

		private bool ShouldSerializeSeparation()
		{
			return base.PropertyShouldSerialize("Separation");
		}

		private void ResetSeparation()
		{
			base.PropertyReset("Separation");
		}

		private bool ShouldSerializeShowOffSegments()
		{
			return base.PropertyShouldSerialize("ShowOffSegments");
		}

		private void ResetShowOffSegments()
		{
			base.PropertyReset("ShowOffSegments");
		}

		public Segment7Character ConvertChar(char value)
		{
			switch (value)
			{
			case '0':
				return Segment7Character.X0;
			case '1':
				return Segment7Character.X1;
			case '2':
				return Segment7Character.X2;
			case '3':
				return Segment7Character.X3;
			case '4':
				return Segment7Character.X4;
			case '5':
				return Segment7Character.X5;
			case '6':
				return Segment7Character.X6;
			case '7':
				return Segment7Character.X7;
			case '8':
				return Segment7Character.X8;
			case '9':
				return Segment7Character.X9;
			case 'A':
			case 'a':
				return Segment7Character.XA;
			case 'B':
			case 'b':
				return Segment7Character.XB;
			case 'C':
			case 'c':
				return Segment7Character.XC;
			case 'D':
			case 'd':
				return Segment7Character.XD;
			case 'E':
			case 'e':
				return Segment7Character.XE;
			case 'F':
			case 'f':
				return Segment7Character.XF;
			case '<':
				return Segment7Character.ArrowDown;
			case '>':
				return Segment7Character.ArrowUp;
			case ':':
				return Segment7Character.Colon;
			case ',':
				return Segment7Character.Comma;
			case '-':
				return Segment7Character.Minus;
			case '.':
				return Segment7Character.Period;
			case '+':
				return Segment7Character.Plus;
			case ';':
				return Segment7Character.SemiColon;
			case ' ':
				return Segment7Character.Space;
			default:
				return Segment7Character.Space;
			}
		}

		private void DrawSegmentA(PaintArgs p, iRectangle r, Color color)
		{
			Point[] points = new Point[4]
			{
				new Point(r.Left + Separation, r.Top),
				new Point(r.Right - Separation, r.Top),
				new Point(r.Right - Separation - Size * 2, r.Top + Size * 2),
				new Point(r.Left + Separation + Size * 2, r.Top + Size * 2)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(color), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(color), points);
		}

		private void DrawSegmentB(PaintArgs p, iRectangle r, Color color)
		{
			Point[] points = new Point[4]
			{
				new Point(r.Right, r.Top + Separation),
				new Point(r.Right, r.CenterY - Separation),
				new Point(r.Right - Size * 2, r.CenterY - Separation - Size * 2),
				new Point(r.Right - Size * 2, r.Top + Separation + Size * 2)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(color), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(color), points);
		}

		private void DrawSegmentC(PaintArgs p, iRectangle r, Color color)
		{
			Point[] points = new Point[4]
			{
				new Point(r.Right, r.CenterY + Separation),
				new Point(r.Right, r.Bottom - Separation),
				new Point(r.Right - Size * 2, r.Bottom - Separation - Size * 2),
				new Point(r.Right - Size * 2, r.CenterY + Separation + Size * 2)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(color), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(color), points);
		}

		private void DrawSegmentD(PaintArgs p, iRectangle r, Color color)
		{
			Point[] points = new Point[4]
			{
				new Point(r.Left + Separation, r.Bottom),
				new Point(r.Right - Separation, r.Bottom),
				new Point(r.Right - Separation - Size * 2, r.Bottom - Size * 2),
				new Point(r.Left + Separation + Size * 2, r.Bottom - Size * 2)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(color), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(color), points);
		}

		private void DrawSegmentE(PaintArgs p, iRectangle r, Color color)
		{
			Point[] points = new Point[4]
			{
				new Point(r.Left, r.CenterY + Separation),
				new Point(r.Left, r.Bottom - Separation),
				new Point(r.Left + Size * 2, r.Bottom - Separation - Size * 2),
				new Point(r.Left + Size * 2, r.CenterY + Separation + Size * 2)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(color), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(color), points);
		}

		private void DrawSegmentF(PaintArgs p, iRectangle r, Color color)
		{
			Point[] points = new Point[4]
			{
				new Point(r.Left, r.Top + Separation),
				new Point(r.Left, r.CenterY - Separation),
				new Point(r.Left + Size * 2, r.CenterY - Separation - Size * 2),
				new Point(r.Left + Size * 2, r.Top + Separation + Size * 2)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(color), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(color), points);
		}

		private void DrawSegmentG(PaintArgs p, iRectangle r, Color color)
		{
			Point[] points = new Point[6]
			{
				new Point(r.Left + Separation, r.CenterY),
				new Point(r.Left + Separation + Size, r.CenterY - Size),
				new Point(r.Right - Separation - Size, r.CenterY - Size),
				new Point(r.Right - Separation, r.CenterY),
				new Point(r.Right - Separation - Size, r.CenterY + Size),
				new Point(r.Left + Separation + Size, r.CenterY + Size)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(color), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(color), points);
		}

		private void DrawArrowUp(PaintArgs p, iRectangle r)
		{
			Point[] points = new Point[3]
			{
				new Point(r.Left, r.CenterY + r.WidthHalf),
				new Point(r.Right, r.CenterY + r.WidthHalf),
				new Point(r.CenterX, r.CenterY - r.WidthHalf)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(ColorOn), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(ColorOn), points);
		}

		private void DrawArrowDown(PaintArgs p, iRectangle r)
		{
			Point[] points = new Point[3]
			{
				new Point(r.Left, r.CenterY - r.WidthHalf),
				new Point(r.Right, r.CenterY - r.WidthHalf),
				new Point(r.CenterX, r.CenterY + r.WidthHalf)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(ColorOn), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(ColorOn), points);
		}

		private void DrawMinus(PaintArgs p, iRectangle r)
		{
			Point[] points = new Point[4]
			{
				new Point(r.Left, r.CenterY - Size),
				new Point(r.Right, r.CenterY - Size),
				new Point(r.Right, r.CenterY + Size),
				new Point(r.Left, r.CenterY + Size)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(ColorOn), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(ColorOn), points);
		}

		private void DrawPlus(PaintArgs p, iRectangle r)
		{
			Point[] points = new Point[12]
			{
				new Point(r.CenterX - Size, r.CenterY - r.WidthHalf),
				new Point(r.CenterX + Size, r.CenterY - r.WidthHalf),
				new Point(r.CenterX + Size, r.CenterY - Size),
				new Point(r.Right, r.CenterY - Size),
				new Point(r.Right, r.CenterY + Size),
				new Point(r.CenterX + Size, r.CenterY + Size),
				new Point(r.CenterX + Size, r.CenterY + r.WidthHalf),
				new Point(r.CenterX - Size, r.CenterY + r.WidthHalf),
				new Point(r.CenterX - Size, r.CenterY + Size),
				new Point(r.Left, r.CenterY + Size),
				new Point(r.Left, r.CenterY - Size),
				new Point(r.CenterX - Size, r.CenterY - Size)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(ColorOn), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(ColorOn), points);
		}

		private void DrawDot(PaintArgs p, iRectangle r, int yCenter)
		{
			Point[] points = new Point[4]
			{
				new Point(r.CenterX - Size, yCenter - Size),
				new Point(r.CenterX + Size, yCenter - Size),
				new Point(r.CenterX + Size, yCenter + Size),
				new Point(r.CenterX - Size, yCenter + Size)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(ColorOn), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(ColorOn), points);
		}

		private void DrawDotComma(PaintArgs p, iRectangle r, int yCenterDot)
		{
			Point[] points = new Point[6]
			{
				new Point(r.CenterX - Size, yCenterDot - Size),
				new Point(r.CenterX + Size, yCenterDot - Size),
				new Point(r.CenterX + Size, yCenterDot + 3 * Size),
				new Point(r.CenterX, yCenterDot + 3 * Size),
				new Point(r.CenterX, yCenterDot + Size),
				new Point(r.CenterX - Size, yCenterDot + Size)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(ColorOn), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(ColorOn), points);
		}

		private void DrawColon(PaintArgs p, iRectangle r)
		{
			DrawDot(p, r, p.CenterY - Size * 3);
			DrawDot(p, r, p.CenterY + Size * 3);
		}

		private void DrawPeriod(PaintArgs p, iRectangle r)
		{
			DrawDot(p, r, p.Bottom - Size);
		}

		private void DrawComma(PaintArgs p, iRectangle r)
		{
			DrawDotComma(p, r, p.Bottom - 3 * Size);
		}

		private void DrawSemiColon(PaintArgs p, iRectangle r)
		{
			DrawDot(p, r, p.CenterY - Size * 3);
			DrawDotComma(p, r, p.CenterY + Size * 3);
		}

		private Color GetOffColor()
		{
			if (m_ColorOffAuto)
			{
				return iColors.ToOffColor(m_ColorOn);
			}
			return m_ColorOff;
		}

		private void Draw(PaintArgs p, iRectangle r, Segment7Character character)
		{
			Color colorOn = ColorOn;
			Color offColor = GetOffColor();
			bool[] array;
			switch (character)
			{
			default:
				return;
			case Segment7Character.Space:
			{
				bool[] array2 = new bool[7];
				array = array2;
				break;
			}
			case Segment7Character.X0:
				array = new bool[7]
				{
					true,
					true,
					true,
					true,
					true,
					true,
					false
				};
				break;
			case Segment7Character.X1:
				array = new bool[7]
				{
					false,
					true,
					true,
					false,
					false,
					false,
					false
				};
				break;
			case Segment7Character.X2:
				array = new bool[7]
				{
					true,
					true,
					false,
					true,
					true,
					false,
					true
				};
				break;
			case Segment7Character.X3:
				array = new bool[7]
				{
					true,
					true,
					true,
					true,
					false,
					false,
					true
				};
				break;
			case Segment7Character.X4:
				array = new bool[7]
				{
					false,
					true,
					true,
					false,
					false,
					true,
					true
				};
				break;
			case Segment7Character.X5:
				array = new bool[7]
				{
					true,
					false,
					true,
					true,
					false,
					true,
					true
				};
				break;
			case Segment7Character.X6:
				array = new bool[7]
				{
					true,
					false,
					true,
					true,
					true,
					true,
					true
				};
				break;
			case Segment7Character.X7:
				array = new bool[7]
				{
					true,
					true,
					true,
					false,
					false,
					false,
					false
				};
				break;
			case Segment7Character.X8:
				array = new bool[7]
				{
					true,
					true,
					true,
					true,
					true,
					true,
					true
				};
				break;
			case Segment7Character.X9:
				array = new bool[7]
				{
					true,
					true,
					true,
					false,
					false,
					true,
					true
				};
				break;
			case Segment7Character.XA:
				array = new bool[7]
				{
					true,
					true,
					true,
					false,
					true,
					true,
					true
				};
				break;
			case Segment7Character.XB:
				array = new bool[7]
				{
					false,
					false,
					true,
					true,
					true,
					true,
					true
				};
				break;
			case Segment7Character.XC:
				array = new bool[7]
				{
					true,
					false,
					false,
					true,
					true,
					true,
					false
				};
				break;
			case Segment7Character.XD:
				array = new bool[7]
				{
					false,
					true,
					true,
					true,
					true,
					false,
					true
				};
				break;
			case Segment7Character.XE:
				array = new bool[7]
				{
					true,
					false,
					false,
					true,
					true,
					true,
					true
				};
				break;
			case Segment7Character.XF:
				array = new bool[7]
				{
					true,
					false,
					false,
					false,
					true,
					true,
					true
				};
				break;
			case Segment7Character.ArrowUp:
				DrawArrowUp(p, r);
				return;
			case Segment7Character.ArrowDown:
				DrawArrowDown(p, r);
				return;
			case Segment7Character.Colon:
				DrawColon(p, r);
				return;
			case Segment7Character.Comma:
				DrawComma(p, r);
				return;
			case Segment7Character.SemiColon:
				DrawSemiColon(p, r);
				return;
			case Segment7Character.Period:
				DrawPeriod(p, r);
				return;
			case Segment7Character.Minus:
				DrawMinus(p, r);
				return;
			case Segment7Character.Plus:
				DrawPlus(p, r);
				return;
			}
			if (array[0])
			{
				DrawSegmentA(p, r, colorOn);
			}
			else if (ShowOffSegments)
			{
				DrawSegmentA(p, r, offColor);
			}
			if (array[1])
			{
				DrawSegmentB(p, r, colorOn);
			}
			else if (ShowOffSegments)
			{
				DrawSegmentB(p, r, offColor);
			}
			if (array[2])
			{
				DrawSegmentC(p, r, colorOn);
			}
			else if (ShowOffSegments)
			{
				DrawSegmentC(p, r, offColor);
			}
			if (array[3])
			{
				DrawSegmentD(p, r, colorOn);
			}
			else if (ShowOffSegments)
			{
				DrawSegmentD(p, r, offColor);
			}
			if (array[4])
			{
				DrawSegmentE(p, r, colorOn);
			}
			else if (ShowOffSegments)
			{
				DrawSegmentE(p, r, offColor);
			}
			if (array[5])
			{
				DrawSegmentF(p, r, colorOn);
			}
			else if (ShowOffSegments)
			{
				DrawSegmentF(p, r, offColor);
			}
			if (array[6])
			{
				DrawSegmentG(p, r, colorOn);
			}
			else if (ShowOffSegments)
			{
				DrawSegmentG(p, r, offColor);
			}
		}

		private Size GetRequiredSize(Segment7Character character)
		{
			if (character != Segment7Character.Period && character != Segment7Character.Colon && character != Segment7Character.SemiColon && character != Segment7Character.Comma)
			{
				return new Size(10 * Size, 18 * Size);
			}
			return new Size(2 * Size, 18 * Size);
		}
	}
}
