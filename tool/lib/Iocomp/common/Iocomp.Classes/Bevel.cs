using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Controls the border layout properties.")]
	public class Bevel : SubClassBase, IBevel
	{
		private int m_MarginEdge;

		private BevelStyle m_Style;

		private BevelThickness m_Thickness;

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the bevel margin.")]
		public int MarginEdge
		{
			get
			{
				return m_MarginEdge;
			}
			set
			{
				base.PropertyUpdateDefault("MarginEdge", value);
				if (MarginEdge != value)
				{
					m_MarginEdge = value;
					base.DoPropertyChange(this, "MarginEdge");
				}
			}
		}

		[Description("Specifies the style of the bevel.")]
		[RefreshProperties(RefreshProperties.All)]
		public BevelStyle Style
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the style of the bevel.")]
		public BevelThickness Thickness
		{
			get
			{
				return m_Thickness;
			}
			set
			{
				base.PropertyUpdateDefault("Thickness", value);
				if (Thickness != value)
				{
					m_Thickness = value;
					base.DoPropertyChange(this, "Thickness");
				}
			}
		}

		[Description("Indicates if the bevel is visible or invisible.")]
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

		protected virtual int InternalMargin => 0;

		protected override string GetPlugInTitle()
		{
			return "Bevel";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.BevelEditorPlugIn";
		}

		void IBevel.DrawRange(PaintArgs p, Rectangle r, Color backColor, Orientation orientation)
		{
			DrawRange(p, r, backColor, orientation);
		}

		void IBevel.Draw(PaintArgs p, Rectangle r, Color backColor, Orientation orientation)
		{
			Draw(p, r, backColor, orientation);
		}

		public Bevel()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeMarginEdge()
		{
			return base.PropertyShouldSerialize("MarginEdge");
		}

		private void ResetMarginEdge()
		{
			base.PropertyReset("MarginEdge");
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private bool ShouldSerializeThickness()
		{
			return base.PropertyShouldSerialize("Thickness");
		}

		private void ResetThickness()
		{
			base.PropertyReset("Thickness");
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private int GetThicknessPixels()
		{
			if (Thickness == BevelThickness.X2)
			{
				return 2;
			}
			if (Thickness == BevelThickness.X3)
			{
				return 3;
			}
			return 4;
		}

		protected void DrawRange(PaintArgs p, Rectangle r, Color backColor, Orientation orientation)
		{
			int num = 1;
			int thicknessPixels = GetThicknessPixels();
			int num2 = (r.Height + num) / (thicknessPixels + num);
			iRectangle iRectangle = new iRectangle(r);
			for (int i = 0; i < num2; i++)
			{
				Draw(p, iRectangle.Rectangle, backColor, orientation);
				iRectangle.Top += thicknessPixels + num;
			}
		}

		protected void Draw(PaintArgs p, Rectangle r, Color backColor, Orientation orientation)
		{
			if (Visible && Style != 0)
			{
				bool invert = Style == BevelStyle.Sunken;
				iColors.FaceColorLight = iColors.Lighten4(backColor);
				iColors.FaceColorDark = iColors.Darken3(backColor);
				iColors.FaceColorFlat = backColor;
				if (orientation == Orientation.Horizontal)
				{
					int num = r.Top + InternalMargin;
					if (Thickness == BevelThickness.X2)
					{
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Top, p.Rotation, invert)), r.Left + MarginEdge, num, r.Right - MarginEdge, num);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Bottom, p.Rotation, invert)), r.Left + MarginEdge, num + 1, r.Right - MarginEdge, num + 1);
					}
					else if (Thickness == BevelThickness.X3)
					{
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Top, p.Rotation, invert)), r.Left + MarginEdge, num, r.Right - MarginEdge, num);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Flat, p.Rotation, invert)), r.Left + MarginEdge, num + 1, r.Right - MarginEdge, num + 1);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Bottom, p.Rotation, invert)), r.Left + MarginEdge, num + 2, r.Right - MarginEdge, num + 2);
					}
					else if (Thickness == BevelThickness.X4)
					{
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Top, p.Rotation, invert)), r.Left + MarginEdge, num, r.Right - MarginEdge, num);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Top, p.Rotation, invert)), r.Left + MarginEdge, num + 1, r.Right - MarginEdge, num + 1);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Bottom, p.Rotation, invert)), r.Left + MarginEdge, num + 2, r.Right - MarginEdge, num + 2);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Bottom, p.Rotation, invert)), r.Left + MarginEdge, num + 3, r.Right - MarginEdge, num + 3);
					}
				}
				else
				{
					int num = p.Left + InternalMargin;
					if (Thickness == BevelThickness.X2)
					{
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Left, p.Rotation, invert)), num, r.Top + MarginEdge, num, r.Bottom - MarginEdge);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Right, p.Rotation, invert)), num + 1, r.Top + MarginEdge, num + 1, r.Bottom - MarginEdge);
					}
					else if (Thickness == BevelThickness.X3)
					{
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Left, p.Rotation, invert)), num, r.Top + MarginEdge, num, r.Bottom - MarginEdge);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Flat, p.Rotation, invert)), num + 1, r.Top + MarginEdge, num + 1, r.Bottom - MarginEdge);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Right, p.Rotation, invert)), num + 2, r.Top + MarginEdge, num + 2, r.Bottom - MarginEdge);
					}
					else if (Thickness == BevelThickness.X4)
					{
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Left, p.Rotation, invert)), num, r.Top + MarginEdge, num, r.Bottom - MarginEdge);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Left, p.Rotation, invert)), num + 1, r.Top + MarginEdge, num + 1, r.Bottom - MarginEdge);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Right, p.Rotation, invert)), num + 2, r.Top + MarginEdge, num + 2, r.Bottom - MarginEdge);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Right, p.Rotation, invert)), num + 3, r.Top + MarginEdge, num + 3, r.Bottom - MarginEdge);
					}
				}
			}
		}
	}
}
