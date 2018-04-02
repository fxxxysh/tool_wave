using Iocomp.Design;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Serializable]
	[TypeConverter(typeof(AnnotationBaseConverter))]
	public abstract class AnnotationBase : SubClassBase, IAnnotationBase
	{
		private double m_Rotation;

		private bool m_CanMove;

		private bool m_CanSize;

		private Region m_ClickRegion;

		private GrabHandle[] m_GrabHandles;

		private double m_MouseDownUnitsX;

		private double m_MouseDownUnitsY;

		private double m_MouseDownOriginalX;

		private double m_MouseDownOriginalY;

		private double m_MouseDownOriginalWidth;

		private double m_MouseDownOriginalHeight;

		private EditMode m_MouseDownEditMode;

		private ScaleAnnotation m_Scale;

		private double m_Width;

		private double m_Height;

		private double m_X;

		private double m_Y;

		ScaleAnnotation IAnnotationBase.Scale
		{
			get
			{
				return Scale;
			}
			set
			{
				Scale = value;
			}
		}

		protected Region ClickRegion
		{
			get
			{
				return m_ClickRegion;
			}
			set
			{
				if (m_ClickRegion != value)
				{
					if (m_ClickRegion != null)
					{
						m_ClickRegion.Dispose();
					}
					m_ClickRegion = value;
				}
			}
		}

		[Category("Iocomp")]
		public double Left
		{
			get
			{
				return X - Width / 2.0;
			}
		}

		[Category("Iocomp")]
		public double Top
		{
			get
			{
				return Y + Height / 2.0;
			}
		}

		[Category("Iocomp")]
		public double Right
		{
			get
			{
				return X + Width / 2.0;
			}
		}

		[Category("Iocomp")]
		public double Bottom
		{
			get
			{
				return Y - Height / 2.0;
			}
		}

		protected GrabHandle GrabHandle0 => m_GrabHandles[0];

		protected GrabHandle GrabHandle1 => m_GrabHandles[1];

		protected GrabHandle GrabHandle2 => m_GrabHandles[2];

		protected GrabHandle GrabHandle3 => m_GrabHandles[3];

		protected GrabHandle GrabHandle4 => m_GrabHandles[4];

		protected GrabHandle GrabHandle5 => m_GrabHandles[5];

		protected GrabHandle GrabHandle6 => m_GrabHandles[6];

		protected GrabHandle GrabHandle7 => m_GrabHandles[7];

		[Category("Iocomp")]
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

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool Enabled
		{
			get
			{
				return base.EnabledInternal;
			}
			set
			{
				base.EnabledInternal = value;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Rotation
		{
			get
			{
				return m_Rotation;
			}
			set
			{
				base.PropertyUpdateDefault("Rotation", value);
				if (Rotation != value)
				{
					m_Rotation = value;
					base.DoPropertyChange(this, "Rotation");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public bool CanMove
		{
			get
			{
				return m_CanMove;
			}
			set
			{
				base.PropertyUpdateDefault("CanMove", value);
				if (CanMove != value)
				{
					m_CanMove = value;
					base.DoPropertyChange(this, "CanMove");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public bool CanSize
		{
			get
			{
				return m_CanSize;
			}
			set
			{
				base.PropertyUpdateDefault("CanSize", value);
				if (CanSize != value)
				{
					m_CanSize = value;
					base.DoPropertyChange(this, "CanSize");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public virtual double Width
		{
			get
			{
				return m_Width;
			}
			set
			{
				base.PropertyUpdateDefault("Width", value);
				if (Width != value)
				{
					m_Width = value;
					base.DoPropertyChange(this, "Width");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public virtual double Height
		{
			get
			{
				return m_Height;
			}
			set
			{
				base.PropertyUpdateDefault("Height", value);
				if (Height != value)
				{
					m_Height = value;
					base.DoPropertyChange(this, "Height");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public virtual double X
		{
			get
			{
				return m_X;
			}
			set
			{
				base.PropertyUpdateDefault("X", value);
				if (X != value)
				{
					m_X = value;
					base.DoPropertyChange(this, "X");
				}
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public virtual double Y
		{
			get
			{
				return m_Y;
			}
			set
			{
				base.PropertyUpdateDefault("Y", value);
				if (Y != value)
				{
					m_Y = value;
					base.DoPropertyChange(this, "Y");
				}
			}
		}

		protected virtual ScaleAnnotation Scale
		{
			get
			{
				return m_Scale;
			}
			set
			{
				m_Scale = value;
			}
		}

		void IAnnotationBase.Draw(PaintArgs p, Color grabHandleDisabledColor)
		{
			Draw(p, grabHandleDisabledColor);
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_GrabHandles = new GrabHandle[8];
			for (int i = 0; i < m_GrabHandles.Length; i++)
			{
				m_GrabHandles[i] = new GrabHandle();
				m_GrabHandles[i].Rectangle = Rectangle.Empty;
				m_GrabHandles[i].Enabled = true;
			}
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Rotation = 0.0;
			CanMove = false;
			CanSize = false;
			Width = 10.0;
			Height = 10.0;
			Visible = true;
			Enabled = true;
			X = 0.0;
			Y = 0.0;
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeEnabled()
		{
			return base.PropertyShouldSerialize("Enabled");
		}

		private void ResetEnabled()
		{
			base.PropertyReset("Enabled");
		}

		private bool ShouldSerializeRotation()
		{
			return base.PropertyShouldSerialize("Rotation");
		}

		private void ResetRotation()
		{
			base.PropertyReset("Rotation");
		}

		private bool ShouldSerializeCanMove()
		{
			return base.PropertyShouldSerialize("CanMove");
		}

		private void ResetCanMove()
		{
			base.PropertyReset("CanMove");
		}

		private bool ShouldSerializeCanSize()
		{
			return base.PropertyShouldSerialize("CanSize");
		}

		private void ResetCanSize()
		{
			base.PropertyReset("CanSize");
		}

		private bool ShouldSerializeWidth()
		{
			return base.PropertyShouldSerialize("Width");
		}

		private void ResetWidth()
		{
			base.PropertyReset("Width");
		}

		private bool ShouldSerializeHeight()
		{
			return base.PropertyShouldSerialize("Height");
		}

		private void ResetHeight()
		{
			base.PropertyReset("Height");
		}

		private bool ShouldSerializeX()
		{
			return base.PropertyShouldSerialize("X");
		}

		private void ResetX()
		{
			base.PropertyReset("X");
		}

		private bool ShouldSerializeY()
		{
			return base.PropertyShouldSerialize("Y");
		}

		private void ResetY()
		{
			base.PropertyReset("Y");
		}

		protected virtual void SetXAndWidth(double x, double width)
		{
			X = x;
			Width = width;
		}

		protected virtual void SetYAndHeight(double y, double height)
		{
			Y = y;
			Height = height;
		}

		protected virtual void DragX(double original, double delta)
		{
			X = original + delta;
		}

		protected virtual void DragY(double original, double delta)
		{
			Y = original + delta;
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			base.InternalOnMouseLeft(e, shouldFocus);
			if (Scale != null && Enabled)
			{
				m_MouseDownEditMode = GetEditMode(e);
				ControlBase.Cursor = GetCursor(m_MouseDownEditMode);
				m_MouseDownUnitsX = Scale.ConvertPixelsToUnitsX(e.X);
				m_MouseDownUnitsY = Scale.ConvertPixelsToUnitsY(e.Y);
				m_MouseDownOriginalX = X;
				m_MouseDownOriginalY = Y;
				m_MouseDownOriginalHeight = Height;
				m_MouseDownOriginalWidth = Width;
				base.IsMouseActive = true;
				if (shouldFocus)
				{
					base.Focus();
				}
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			double num;
			double num2;
			double num3;
			if (base.IsMouseActive)
			{
				num = Scale.ConvertPixelsToUnitsX(e.X) - m_MouseDownUnitsX;
				num2 = Scale.ConvertPixelsToUnitsY(e.Y) - m_MouseDownUnitsY;
				if (m_MouseDownEditMode == EditMode.Move)
				{
					DragX(m_MouseDownOriginalX, num);
					DragY(m_MouseDownOriginalY, num2);
				}
				else if (m_MouseDownEditMode != 0)
				{
					if (m_MouseDownEditMode != EditMode.Size0 && m_MouseDownEditMode != EditMode.Size6 && m_MouseDownEditMode != EditMode.Size7)
					{
						goto IL_00bb;
					}
					num3 = m_MouseDownOriginalWidth - num;
					if (!(num3 < 0.0))
					{
						SetXAndWidth(m_MouseDownOriginalX + num / 2.0, num3);
						goto IL_00bb;
					}
					return;
				}
			}
			else if (base.Focused)
			{
				ControlBase.Cursor = GetCursor(GetEditMode(e));
			}
			goto IL_01bb;
			IL_0105:
			if (m_MouseDownEditMode != EditMode.Size0 && m_MouseDownEditMode != EditMode.Size1 && m_MouseDownEditMode != EditMode.Size2)
			{
				goto IL_014f;
			}
			double num4 = m_MouseDownOriginalHeight + num2;
			if (!(num4 < 0.0))
			{
				SetYAndHeight(m_MouseDownOriginalY + num2 / 2.0, num4);
				goto IL_014f;
			}
			return;
			IL_01bb:
			base.InternalOnMouseMove(e);
			return;
			IL_014f:
			if (m_MouseDownEditMode != EditMode.Size4 && m_MouseDownEditMode != EditMode.Size5 && m_MouseDownEditMode != EditMode.Size6)
			{
				goto IL_01bb;
			}
			num4 = m_MouseDownOriginalHeight - num2;
			if (!(num4 < 0.0))
			{
				SetYAndHeight(m_MouseDownOriginalY + num2 / 2.0, num4);
				goto IL_01bb;
			}
			return;
			IL_00bb:
			if (m_MouseDownEditMode != EditMode.Size2 && m_MouseDownEditMode != EditMode.Size3 && m_MouseDownEditMode != EditMode.Size4)
			{
				goto IL_0105;
			}
			num3 = m_MouseDownOriginalWidth + num;
			if (!(num3 < 0.0))
			{
				SetXAndWidth(m_MouseDownOriginalX + num / 2.0, num3);
				goto IL_0105;
			}
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			base.InternalOnMouseUp(e);
			if (base.IsMouseActive)
			{
				base.Bounds.Contains(e.X, e.Y);
			}
		}

		protected override bool InternalHitTest(MouseEventArgs e)
		{
			if (m_ClickRegion == null)
			{
				return false;
			}
			if (base.Focused)
			{
				for (int i = 0; i < m_GrabHandles.Length; i++)
				{
					if (m_GrabHandles[i].Rectangle.Contains(e.X, e.Y))
					{
						return true;
					}
				}
			}
			return m_ClickRegion.IsVisible((float)e.X, (float)e.Y);
		}

		protected EditMode GetEditMode(MouseEventArgs e)
		{
			if (CanSize && GrabHandle0.Enabled && GrabHandle0.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size0;
			}
			if (CanSize && GrabHandle1.Enabled && GrabHandle1.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size1;
			}
			if (CanSize && GrabHandle2.Enabled && GrabHandle2.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size2;
			}
			if (CanSize && GrabHandle3.Enabled && GrabHandle3.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size3;
			}
			if (CanSize && GrabHandle4.Enabled && GrabHandle4.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size4;
			}
			if (CanSize && GrabHandle5.Enabled && GrabHandle5.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size5;
			}
			if (CanSize && GrabHandle6.Enabled && GrabHandle6.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size6;
			}
			if (CanSize && GrabHandle7.Enabled && GrabHandle7.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size7;
			}
			if (CanMove)
			{
				return EditMode.Move;
			}
			return EditMode.None;
		}

		protected Cursor GetCursor(EditMode editMode)
		{
			switch (editMode)
			{
			case EditMode.Size0:
				return Cursors.SizeNWSE;
			case EditMode.Size1:
				return Cursors.SizeNS;
			case EditMode.Size2:
				return Cursors.SizeNESW;
			case EditMode.Size3:
				return Cursors.SizeWE;
			case EditMode.Size4:
				return Cursors.SizeNWSE;
			case EditMode.Size5:
				return Cursors.SizeNS;
			case EditMode.Size6:
				return Cursors.SizeNESW;
			case EditMode.Size7:
				return Cursors.SizeWE;
			case EditMode.Move:
				return Cursors.SizeAll;
			default:
				return Cursors.Default;
			}
		}

		protected void UpdateGrabHandles(Rectangle r)
		{
			double centerX = (double)(r.Left + r.Right) / 2.0;
			double centerY = (double)(r.Top + r.Bottom) / 2.0;
			double num = (double)r.Width / 2.0;
			double num2 = (double)r.Height / 2.0;
			double num3 = Math.Atan2(num2, num) * 360.0 / 6.2831853071795862;
			double radius = Math.Sqrt(num * num + num2 * num2);
			GrabHandle0.Rectangle = CalcGrabRect(Math2.ToRotatedPoint(180.0 + num3 + Rotation, radius, centerX, centerY));
			GrabHandle1.Rectangle = CalcGrabRect(Math2.ToRotatedPoint(270.0 + Rotation, num2, centerX, centerY));
			GrabHandle2.Rectangle = CalcGrabRect(Math2.ToRotatedPoint(0.0 - num3 + Rotation, radius, centerX, centerY));
			GrabHandle3.Rectangle = CalcGrabRect(Math2.ToRotatedPoint(0.0 + Rotation, num, centerX, centerY));
			GrabHandle4.Rectangle = CalcGrabRect(Math2.ToRotatedPoint(0.0 + num3 + Rotation, radius, centerX, centerY));
			GrabHandle5.Rectangle = CalcGrabRect(Math2.ToRotatedPoint(90.0 + Rotation, num2, centerX, centerY));
			GrabHandle6.Rectangle = CalcGrabRect(Math2.ToRotatedPoint(180.0 - num3 + Rotation, radius, centerX, centerY));
			GrabHandle7.Rectangle = CalcGrabRect(Math2.ToRotatedPoint(180.0 + Rotation, num, centerX, centerY));
		}

		private Rectangle CalcGrabRect(Point point)
		{
			return new Rectangle(point.X - 2, point.Y - 2, 5, 5);
		}

		protected void DrawGrabHandles(PaintArgs p, Color grabHandleDisabledColor)
		{
			if (base.Focused && (ControlBase == null || ControlBase.Focused))
			{
				Color color = Color.White;
				if (ControlBase != null)
				{
					color = ControlBase.BackColor;
				}
				Color color2 = Color.FromArgb(255, color.R ^ 0xFF, color.G ^ 0xFF, color.B ^ 0xFF);
				for (int i = 0; i < m_GrabHandles.Length; i++)
				{
					Color color3 = (CanSize && m_GrabHandles[i].Enabled) ? color2 : grabHandleDisabledColor;
					p.Graphics.FillRectangle(p.Graphics.Brush(color3), m_GrabHandles[i].Rectangle);
				}
			}
		}

		protected void Draw(PaintArgs p, Color grabHandleDisabledColor)
		{
			if (Visible)
			{
				Point point = new Point(p.Left + Scale.ConvertUnitsToPixelsX(X), p.Top + Scale.ConvertUnitsToPixelsY(Y));
				GraphicsState gstate = p.Graphics.Save();
				p.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				p.Graphics.TranslateTransform((float)point.X, (float)point.Y);
				p.Graphics.RotateTransform((float)Rotation);
				p.Graphics.TranslateTransform((float)(-point.X), (float)(-point.Y));
				DrawCustom(p);
				p.Graphics.Restore(gstate);
				DrawGrabHandles(p, grabHandleDisabledColor);
			}
		}

		protected abstract void DrawCustom(PaintArgs p);

		protected virtual Region ToClickRegion(Rectangle r)
		{
			return new Region(r);
		}
	}
}
