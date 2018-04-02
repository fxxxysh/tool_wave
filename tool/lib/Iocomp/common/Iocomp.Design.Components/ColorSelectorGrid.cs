using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Components
{
	[Description("Color Selector Grid")]
	[Designer(typeof(ColorSelectorGridDesigner))]
	[DefaultEvent("")]
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	public class ColorSelectorGrid : Control
	{
		private Color m_Color;

		private int m_ColorFocusIndex;

		private bool m_MouseDown;

		private Color[] m_ColorArray = new Color[64]
		{
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 192, 192),
			Color.FromArgb(255, 224, 192),
			Color.FromArgb(255, 255, 192),
			Color.FromArgb(192, 255, 192),
			Color.FromArgb(192, 255, 255),
			Color.FromArgb(192, 192, 255),
			Color.FromArgb(255, 192, 255),
			Color.FromArgb(224, 224, 224),
			Color.FromArgb(255, 128, 128),
			Color.FromArgb(255, 192, 128),
			Color.FromArgb(255, 255, 128),
			Color.FromArgb(128, 255, 128),
			Color.FromArgb(128, 255, 255),
			Color.FromArgb(128, 128, 255),
			Color.FromArgb(255, 128, 255),
			Color.FromArgb(192, 192, 192),
			Color.FromArgb(255, 0, 0),
			Color.FromArgb(255, 128, 0),
			Color.FromArgb(255, 255, 0),
			Color.FromArgb(0, 255, 0),
			Color.FromArgb(0, 255, 255),
			Color.FromArgb(0, 0, 255),
			Color.FromArgb(255, 0, 255),
			Color.FromArgb(128, 128, 128),
			Color.FromArgb(192, 0, 0),
			Color.FromArgb(192, 64, 0),
			Color.FromArgb(192, 192, 0),
			Color.FromArgb(0, 192, 0),
			Color.FromArgb(0, 192, 192),
			Color.FromArgb(0, 0, 192),
			Color.FromArgb(192, 0, 192),
			Color.FromArgb(64, 64, 64),
			Color.FromArgb(128, 0, 0),
			Color.FromArgb(128, 64, 0),
			Color.FromArgb(128, 128, 0),
			Color.FromArgb(0, 128, 0),
			Color.FromArgb(0, 128, 128),
			Color.FromArgb(0, 0, 128),
			Color.FromArgb(128, 0, 128),
			Color.FromArgb(0, 0, 0),
			Color.FromArgb(64, 0, 0),
			Color.FromArgb(128, 64, 64),
			Color.FromArgb(64, 64, 0),
			Color.FromArgb(0, 64, 0),
			Color.FromArgb(0, 64, 64),
			Color.FromArgb(0, 0, 64),
			Color.FromArgb(64, 0, 64),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255)
		};

		protected override Size DefaultSize => new Size(194, 198);

		public Color Color
		{
			get
			{
				return m_Color;
			}
			set
			{
				if (m_Color != value)
				{
					m_Color = value;
					m_ColorFocusIndex = GetColorBoxIndex(m_Color);
					base.Invalidate();
					OnColorChanged();
				}
			}
		}

		public event EventHandler ColorChanged;

		public event EventHandler ColorChangedDoubleClick;

		public ColorSelectorGrid()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			base.UpdateStyles();
			m_ColorFocusIndex = -1;
		}

		private int GetColorBoxIndex(Color color)
		{
			for (int i = 0; i < m_ColorArray.Length; i++)
			{
				if (color.ToArgb() == m_ColorArray[i].ToArgb())
				{
					return i;
				}
			}
			return -1;
		}

		private int GetColorBoxIndex(int x, int y)
		{
			for (int i = 0; i < m_ColorArray.Length; i++)
			{
				if (GetColorBoxRect(i).Contains(x, y))
				{
					return i;
				}
			}
			return -1;
		}

		private Rectangle GetColorBoxRect(int index)
		{
			int num = (int)((long)index / 8L);
			int num2 = (int)((long)index % 8L);
			return new Rectangle(3 + num2 * 24, 5 + num * 24, 21, 21);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			base.Focus();
			m_MouseDown = true;
			int colorBoxIndex = GetColorBoxIndex(e.X, e.Y);
			if (colorBoxIndex != -1)
			{
				m_ColorFocusIndex = colorBoxIndex;
				base.Invalidate();
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (m_MouseDown)
			{
				int colorBoxIndex = GetColorBoxIndex(e.X, e.Y);
				if (colorBoxIndex != -1)
				{
					m_ColorFocusIndex = colorBoxIndex;
					base.Invalidate();
				}
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			m_MouseDown = false;
			int colorBoxIndex = GetColorBoxIndex(e.X, e.Y);
			if (colorBoxIndex != -1 && m_ColorFocusIndex == colorBoxIndex)
			{
				Color = m_ColorArray[colorBoxIndex];
			}
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick(e);
			Point point = base.PointToClient(Control.MousePosition);
			int colorBoxIndex = GetColorBoxIndex(point.X, point.Y);
			if (colorBoxIndex != -1)
			{
				OnColorChangedDoubleClick();
			}
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			m_MouseDown = false;
		}

		private void OnColorChanged()
		{
			if (this.ColorChanged != null)
			{
				this.ColorChanged(this, EventArgs.Empty);
			}
		}

		private void OnColorChangedDoubleClick()
		{
			if (this.ColorChangedDoubleClick != null)
			{
				this.ColorChangedDoubleClick(this, EventArgs.Empty);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			for (int i = 0; i < m_ColorArray.Length; i++)
			{
				Rectangle colorBoxRect = GetColorBoxRect(i);
				Brush brush = new SolidBrush(m_ColorArray[i]);
				e.Graphics.FillRectangle(brush, colorBoxRect);
				brush.Dispose();
				ControlPaint.DrawBorder3D(e.Graphics, colorBoxRect, Border3DStyle.Sunken);
				if (i == m_ColorFocusIndex)
				{
					colorBoxRect.Inflate(1, 2);
					ControlPaint.DrawFocusRectangle(e.Graphics, colorBoxRect, Color.White, BackColor);
				}
			}
			base.OnPaint(e);
		}
	}
}
