using Iocomp.Types;
using System.Drawing;

namespace Iocomp.Classes
{
	public class PaintArgs
	{
		private Color m_ControlBackColor;

		private GraphicsAPI m_Graphics;

		private int m_Left;

		private int m_Top;

		private int m_Width;

		private int m_Height;

		private int m_Right;

		private int m_Bottom;

		private int m_WidthHalf;

		private int m_HeightHalf;

		private Point m_CenterPoint;

		private Rectangle m_Rectangle;

		private Rectangle m_PenRectangle;

		private RotationQuad m_Rotation;

		public GraphicsAPI Graphics => m_Graphics;

		public RotationQuad Rotation
		{
			get
			{
				return m_Rotation;
			}
			set
			{
				m_Rotation = value;
			}
		}

		public Color ControlBackColor => m_ControlBackColor;

		public int Left => m_Left;

		public int Top => m_Top;

		public int Width => m_Width;

		public int Height => m_Height;

		public Size Size => new Size(m_Width, m_Height);

		public int Right => m_Right;

		public int Bottom => m_Bottom;

		public Point CenterPoint => m_CenterPoint;

		public int CenterX => m_CenterPoint.X;

		public int CenterY => m_CenterPoint.Y;

		public Rectangle DrawRectangle
		{
			get
			{
				return m_Rectangle;
			}
			set
			{
				m_Left = value.Left;
				m_Top = value.Top;
				m_Width = value.Width;
				m_Height = value.Height;
			}
		}

		public Rectangle PenRectangle => m_PenRectangle;

		public int WidthHalf => m_WidthHalf;

		public int HeightHalf => m_HeightHalf;

		public float RotationAngle
		{
			get
			{
				if (Rotation == RotationQuad.X000)
				{
					return 0f;
				}
				if (Rotation == RotationQuad.X090)
				{
					return 90f;
				}
				if (Rotation == RotationQuad.X180)
				{
					return 180f;
				}
				return 270f;
			}
		}

		public PaintArgs(Graphics graphics, Rectangle r, Color color)
		{
			m_ControlBackColor = color;
			m_Graphics = new GraphicsAPI(graphics);
			SetRectangle(r);
		}

		private void SetRectangle(Rectangle r)
		{
			m_Rectangle = r;
			m_Left = r.Left;
			m_Top = r.Top;
			m_Width = r.Width;
			m_Height = r.Height;
			m_Right = m_Left + m_Width - 1;
			m_Bottom = m_Top + m_Height - 1;
			m_CenterPoint = new Point(m_Left + m_Width / 2, m_Top + m_Height / 2);
			m_PenRectangle = new Rectangle(m_Left, m_Top, m_Width - 1, m_Height - 1);
			m_WidthHalf = m_Width / 2;
			m_HeightHalf = m_Height / 2;
		}

		public void CleanUp()
		{
			m_Graphics.CleanUp();
		}

		public void Rotate(RotationQuad rotation)
		{
			m_Rotation = Rotation;
			switch (rotation)
			{
			case RotationQuad.X090:
				Graphics.TranslateTransform((float)CenterX, (float)CenterY);
				Graphics.RotateTransform(90f);
				Graphics.TranslateTransform((float)(-CenterY), (float)(-CenterX + 1));
				SetRectangle(new Rectangle(Left, Top, Height, Width));
				break;
			case RotationQuad.X180:
				Graphics.TranslateTransform((float)CenterX, (float)CenterY);
				Graphics.RotateTransform(180f);
				Graphics.TranslateTransform((float)(-CenterX + 1), (float)(-CenterY + 1));
				break;
			case RotationQuad.X270:
				Graphics.TranslateTransform((float)CenterX, (float)CenterY);
				Graphics.RotateTransform(270f);
				Graphics.TranslateTransform((float)(-CenterY + 1), (float)(-CenterX));
				SetRectangle(new Rectangle(Left, Top, Height, Width));
				break;
			}
		}
	}
}
