using Iocomp.Design;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public abstract class PlotLayoutBlockBase : IDrawLayoutControl, IUIInput
	{
		private UIInputCollection m_UICollection;

		public PlotLayoutBase Object;

		private Color m_BackColor;

		public Rectangle BoundsScreen;

		public Rectangle BoundsLayout;

		public Rectangle BoundsClip;

		public PlotLayoutBlockItemCollection List;

		public Color BackColor
		{
			get
			{
				return m_BackColor;
			}
			set
			{
				if (m_BackColor != value)
				{
					m_BackColor = value;
					if (UICollection != null)
					{
						UICollection.UIInvalidate(this);
					}
				}
			}
		}

		public bool Visible
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		public bool HitVisible => true;

		public bool Enabled
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		public bool Focused => false;

		public bool ContextMenuEnabled
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		public bool IsMouseDown
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsMouseActive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsKeyDown
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsKeyActive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Rectangle Bounds
		{
			get
			{
				if (this is PlotLayoutBlockGroup)
				{
					return (this as PlotLayoutBlockGroup).InnerRectangleLayout;
				}
				return BoundsLayout;
			}
			set
			{
			}
		}

		public UIInputCollection UICollection
		{
			get
			{
				return m_UICollection;
			}
			set
			{
				m_UICollection = value;
			}
		}

		public PlotLayoutBlockBase()
		{
			BackColor = SystemColors.Control;
			Visible = true;
		}

		public bool HitTest(MouseEventArgs e)
		{
			return Bounds.Contains(e.X, e.Y);
		}

		public Cursor GetMouseCursor(MouseEventArgs e)
		{
			return null;
		}

		public void MouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			BackColor = Color.Yellow;
			PlotLayoutViewer.DragControl.Source = this;
			PlotLayoutViewer.DragControl.Destination = null;
			UICollection.StartDrag();
		}

		public void MouseMove(MouseEventArgs e)
		{
			if (UICollection.DragActive)
			{
				PlotLayoutViewer.DragControl.MousePoint = new Point(e.X, e.Y);
				PlotLayoutViewer.DragControl.Destination = this;
			}
		}

		public void MouseUp(MouseEventArgs e)
		{
			BackColor = SystemColors.Control;
			PlotLayoutViewer.DragControl.CompleteDrag();
			PlotLayoutViewer.DragControl.Source = null;
			PlotLayoutViewer.DragControl.Destination = null;
		}

		public void MouseRight(MouseEventArgs e)
		{
		}

		public void Click(MouseEventArgs e)
		{
		}

		public void DoubleClick(MouseEventArgs e)
		{
		}

		public void MouseWheel(MouseEventArgs e)
		{
		}

		public void KeyDown(KeyEventArgs e)
		{
		}

		public void KeyUp(KeyEventArgs e)
		{
		}

		public void KeyPress(KeyPressEventArgs e)
		{
		}

		public void LostFocus(LostFocusEventArgs e)
		{
		}

		public void GotFocus(EventArgs e)
		{
		}

		public void Draw(PaintArgs p, Font font, Color foreColor, Color backColor)
		{
			if (Object != null && Visible)
			{
				string s = Object.ToString();
				Rectangle rectangle = (!(this is PlotLayoutBlockGroup)) ? BoundsLayout : (this as PlotLayoutBlockGroup).InnerRectangleLayout;
				DrawStringFormat genericDefault = DrawStringFormat.GenericDefault;
				genericDefault.Alignment = StringAlignment.Center;
				genericDefault.LineAlignment = StringAlignment.Center;
				p.Graphics.FillRectangle(p.Graphics.Brush(BackColor), rectangle);
				BorderSimple.Draw(p, rectangle, BorderStyleSimple.Raised, backColor);
				TextRotation rotation = (!(Object is PlotDataView)) ? ((!Object.DockLeft) ? (Object.DockRight ? TextRotation.X090 : TextRotation.X000) : TextRotation.X270) : TextRotation.X000;
				p.Graphics.DrawRotatedText(s, font, foreColor, rectangle, rotation, genericDefault);
			}
		}
	}
}
