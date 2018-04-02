using Iocomp.Types;
using System.Drawing;

namespace Iocomp.Classes
{
	public class iColors
	{
		private static Color m_FaceColorLight;

		private static Color m_FaceColorDark;

		private static Color m_FaceColorFlat;

		public static Color FaceColorLight
		{
			get
			{
				return m_FaceColorLight;
			}
			set
			{
				m_FaceColorLight = value;
			}
		}

		public static Color FaceColorDark
		{
			get
			{
				return m_FaceColorDark;
			}
			set
			{
				m_FaceColorDark = value;
			}
		}

		public static Color FaceColorFlat
		{
			get
			{
				return m_FaceColorFlat;
			}
			set
			{
				m_FaceColorFlat = value;
			}
		}

		private static Color Lighten(Color color, float multiplier)
		{
			int a = color.A;
			int num = (int)((float)(int)color.R + (float)(255 - color.R) * multiplier);
			int num2 = (int)((float)(int)color.G + (float)(255 - color.G) * multiplier);
			int num3 = (int)((float)(int)color.B + (float)(255 - color.B) * multiplier);
			if (num > 255)
			{
				num = 255;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num < 0)
			{
				num = 0;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			return Color.FromArgb(a, num, num2, num3);
		}

		private static Color Darken(Color color, float multiplier)
		{
			int a = color.A;
			int num = (int)((float)(int)color.R - (float)(int)color.R * multiplier);
			int num2 = (int)((float)(int)color.G - (float)(int)color.G * multiplier);
			int num3 = (int)((float)(int)color.B - (float)(int)color.B * multiplier);
			if (num > 255)
			{
				num = 255;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num < 0)
			{
				num = 0;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			return Color.FromArgb(a, num, num2, num3);
		}

		private static Color ColorOffset(Color color, int value)
		{
			int a = color.A;
			int num = color.R + value;
			int num2 = color.G + value;
			int num3 = color.B + value;
			if (num > 255)
			{
				num = 255;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			if (num3 > 255)
			{
				num3 = 255;
			}
			if (num < 0)
			{
				num = 0;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			return Color.FromArgb(a, num, num2, num3);
		}

		public static Color Lighten1(Color color)
		{
			return Lighten(color, 0.15f);
		}

		public static Color Lighten2(Color color)
		{
			return Lighten(color, 0.25f);
		}

		public static Color Lighten3(Color color)
		{
			return Lighten(color, 0.5f);
		}

		public static Color Lighten4(Color color)
		{
			return Lighten(color, 0.75f);
		}

		public static Color Darken1(Color color)
		{
			return Darken(color, 0.15f);
		}

		public static Color Darken2(Color color)
		{
			return Darken(color, 0.25f);
		}

		public static Color Darken3(Color color)
		{
			return Darken(color, 0.5f);
		}

		public static Color Darken4(Color color)
		{
			return Darken(color, 0.75f);
		}

		public static Color ToCornerHighlight(Color color)
		{
			return Lighten(color, 0.6f);
		}

		public static Color ToCornerShadow(Color color)
		{
			return Darken(color, 0.05f);
		}

		public static Color ToBright(Color color)
		{
			return ColorOffset(color, 128);
		}

		public static Color ToDim(Color color)
		{
			return ColorOffset(color, -128);
		}

		public static Color ToOffColor(Color color)
		{
			return ToDim(color);
		}

		public static Color ToFaceColor(FaceReference side, RotationQuad rotation, bool invert)
		{
			if (side == FaceReference.Flat)
			{
				return FaceColorFlat;
			}
			if (invert)
			{
				switch (side)
				{
				case FaceReference.Left:
					side = FaceReference.Right;
					break;
				case FaceReference.Top:
					side = FaceReference.Bottom;
					break;
				case FaceReference.Right:
					side = FaceReference.Left;
					break;
				case FaceReference.Bottom:
					side = FaceReference.Top;
					break;
				}
			}
			switch (rotation)
			{
			case RotationQuad.X000:
				switch (side)
				{
				case FaceReference.Left:
					return FaceColorLight;
				case FaceReference.Top:
					return FaceColorLight;
				case FaceReference.Right:
					return FaceColorDark;
				case FaceReference.Bottom:
					return FaceColorDark;
				}
				break;
			case RotationQuad.X090:
				switch (side)
				{
				case FaceReference.Left:
					return FaceColorLight;
				case FaceReference.Top:
					return FaceColorDark;
				case FaceReference.Right:
					return FaceColorDark;
				case FaceReference.Bottom:
					return FaceColorLight;
				}
				break;
			case RotationQuad.X180:
				switch (side)
				{
				case FaceReference.Left:
					return FaceColorDark;
				case FaceReference.Top:
					return FaceColorDark;
				case FaceReference.Right:
					return FaceColorLight;
				case FaceReference.Bottom:
					return FaceColorLight;
				}
				break;
			default:
				switch (side)
				{
				case FaceReference.Left:
					return FaceColorDark;
				case FaceReference.Top:
					return FaceColorLight;
				case FaceReference.Right:
					return FaceColorLight;
				case FaceReference.Bottom:
					return FaceColorDark;
				}
				break;
			}
			return Color.Black;
		}
	}
}
