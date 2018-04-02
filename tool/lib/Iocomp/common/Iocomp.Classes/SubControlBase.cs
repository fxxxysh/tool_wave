using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public abstract class SubControlBase : SubClassBase, ISubControlBase
	{
		private int m_Left;

		private int m_Top;

		private int m_Width;

		private int m_Height;

		private BorderControl m_Border;

		private string m_Text;

		public int Left
		{
			get
			{
				return m_Left;
			}
			set
			{
				m_Left = value;
				base.DoPropertyChange(this, "Left");
			}
		}

		public int Top
		{
			get
			{
				return m_Top;
			}
			set
			{
				m_Top = value;
				base.DoPropertyChange(this, "Top");
			}
		}

		public int Width
		{
			get
			{
				return m_Width;
			}
			set
			{
				m_Width = value;
				base.DoPropertyChange(this, "Width");
			}
		}

		public int Height
		{
			get
			{
				return m_Height;
			}
			set
			{
				m_Height = value;
				base.DoPropertyChange(this, "Height");
			}
		}

		public int Right => m_Left + m_Width - 1;

		public int Bottom => m_Top + m_Height - 1;

		public int CenterX => m_Left + m_Width / 2;

		public int CenterY => m_Top + m_Height / 2;

		public new Rectangle Bounds
		{
			get
			{
				return new Rectangle(m_Left, m_Top, m_Width, m_Height);
			}
			set
			{
				m_Left = value.Left;
				m_Top = value.Top;
				m_Width = value.Width;
				m_Height = value.Height;
				base.DoPropertyChange(this, "Bounds");
			}
		}

		public Rectangle ClientRectangle => new Rectangle(0, 0, m_Width, m_Height);

		public Rectangle InnerRectangle => new Rectangle(0, 0, m_Width - 2 * Border.Offset, m_Height - 2 * Border.Offset);

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Iocomp")]
		[Description("")]
		public BorderControl Border
		{
			get
			{
				return m_Border;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

		public new bool Focused => base.Focused;

		public new Cursor Cursor => base.Cursor;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string Text
		{
			get
			{
				return m_Text;
			}
			set
			{
				base.PropertyUpdateDefault("Text", value);
				if (Text != value)
				{
					m_Text = value;
					base.DoPropertyChange(this, "Text");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public new Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public new Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		void ISubControlBase.OnPaint(PaintArgs p)
		{
			OnPaint(p);
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Border = new BorderControl();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Visible = true;
			Enabled = true;
		}

		private bool ShouldSerializeBorder()
		{
			return ((ISubClassBase)Border).ShouldSerialize();
		}

		private void ResetBorder()
		{
			((ISubClassBase)Border).ResetToDefault();
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

		private bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetText()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeBackColor()
		{
			return base.PropertyShouldSerialize("BackColor");
		}

		private void ResetBackColor()
		{
			base.PropertyReset("BackColor");
		}

		private bool ShouldSerializeFont()
		{
			return base.PropertyShouldSerialize("Font");
		}

		private void ResetFont()
		{
			base.PropertyReset("Font");
		}

		private bool ShouldSerializeForeColor()
		{
			return base.PropertyShouldSerialize("ForeColor");
		}

		private void ResetForeColor()
		{
			base.PropertyReset("ForeColor");
		}

		protected override bool InternalHitTest(MouseEventArgs e)
		{
			return Bounds.Contains(e.X, e.Y);
		}

		private void OnPaint(PaintArgs p)
		{
			if (Visible)
			{
				GraphicsState gstate = p.Graphics.Save();
				Rectangle drawRectangle = p.DrawRectangle;
				p.Graphics.SetClip(Bounds);
				p.Graphics.FillRectangle(p.Graphics.Brush(BackColor), Bounds);
				p.Graphics.TranslateTransform((float)(Left + Border.Offset), (float)(Top + Border.Offset));
				p.DrawRectangle = InnerRectangle;
				DoPaint(p);
				p.Rotation = RotationQuad.X000;
				p.Graphics.TranslateTransform((float)(-Border.Offset), (float)(-Border.Offset));
				((IBorderControl)Border).Draw(p, ClientRectangle);
				p.Graphics.Restore(gstate);
				p.DrawRectangle = drawRectangle;
				p.Graphics.ResetClip();
			}
		}

		protected abstract void DoPaint(PaintArgs p);
	}
}
