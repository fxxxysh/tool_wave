using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Contains the horizontal and vertical layout properties for text.")]
	public class TextLayoutBase : SubClassBase, ITextLayoutBase
	{
		private AlignmentText m_AlignmentVertical;

		private AlignmentText m_AlignmentHorizontal;

		DrawStringFormat ITextLayoutBase.StringFormat
		{
			get
			{
				return StringFormat;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		[ParenthesizePropertyName(true)]
		public AlignmentText AlignmentVertical
		{
			get
			{
				return m_AlignmentVertical;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		[ParenthesizePropertyName(true)]
		public AlignmentText AlignmentHorizontal
		{
			get
			{
				return m_AlignmentHorizontal;
			}
		}

		protected virtual DrawStringFormat StringFormat
		{
			get
			{
				DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
				genericTypographic.Alignment = AlignmentHorizontal.Style;
				genericTypographic.LineAlignment = AlignmentVertical.Style;
				return genericTypographic;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Text Layout";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.TextLayoutBaseEditorPlugIn";
		}

		void ITextLayoutBase.Draw(GraphicsAPI graphics, Font font, Brush brush, string s, Rectangle r)
		{
			Draw(graphics, font, brush, s, r);
		}

		Size ITextLayoutBase.GetRequiredSize(string s, Font font, GraphicsAPI graphics)
		{
			return GetRequiredSize(s, font, graphics);
		}

		Size ITextLayoutBase.GetRequiredSize(string s, Font font, int width, GraphicsAPI graphics)
		{
			return GetRequiredSize(s, font, width, graphics);
		}

		Rectangle ITextLayoutBase.GetRectangle(Rectangle bounds, Font font, GraphicsAPI graphics)
		{
			return GetRectangle(bounds, font, graphics);
		}

		Rectangle ITextLayoutBase.GetRectangle(string s, Point pt, Font font, GraphicsAPI graphics)
		{
			return GetRectangle(s, pt, font, graphics);
		}

		Point ITextLayoutBase.GetMarginsAlignment(Font font, GraphicsAPI graphics)
		{
			return GetMarginsAlignment(font, graphics);
		}

		public TextLayoutBase()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_AlignmentVertical = new AlignmentText();
			base.AddSubClass(AlignmentVertical);
			m_AlignmentHorizontal = new AlignmentText();
			base.AddSubClass(AlignmentHorizontal);
		}

		private bool ShouldSerializeAlignmentVertical()
		{
			return ((ISubClassBase)AlignmentVertical).ShouldSerialize();
		}

		private void ResetAlignmentVertical()
		{
			((ISubClassBase)AlignmentVertical).ResetToDefault();
		}

		private bool ShouldSerializeAlignmentHorizontal()
		{
			return ((ISubClassBase)AlignmentHorizontal).ShouldSerialize();
		}

		private void ResetAlignmentHorizontal()
		{
			((ISubClassBase)AlignmentHorizontal).ResetToDefault();
		}

		protected Point GetMarginsAlignment(Font font, GraphicsAPI graphics)
		{
			Size size = graphics.MeasureString("0", font, true);
			int x = (AlignmentHorizontal.Style != StringAlignment.Center) ? ((int)Math.Ceiling((double)size.Width * AlignmentHorizontal.Margin)) : 0;
			int y = (AlignmentVertical.Style != StringAlignment.Center) ? ((int)Math.Ceiling((double)size.Height * AlignmentVertical.Margin)) : 0;
			return new Point(x, y);
		}

		protected Size GetRequiredSize(string s, Font font, GraphicsAPI graphics)
		{
			Point marginsAlignment = GetMarginsAlignment(font, graphics);
			Size size = graphics.MeasureString(s, font, true);
			return new Size(size.Width + marginsAlignment.X + 1, size.Height + marginsAlignment.Y + 1);
		}

		protected virtual Size GetRequiredSize(string s, Font font, int width, GraphicsAPI graphics)
		{
			Point marginsAlignment = GetMarginsAlignment(font, graphics);
			Size size = graphics.MeasureString(s, font, true, width);
			return new Size(size.Width + marginsAlignment.X + 1, size.Height + marginsAlignment.Y + 1);
		}

		protected Rectangle GetRectangle(Rectangle bounds, Font font, GraphicsAPI graphics)
		{
			int num = bounds.Left;
			int num2 = bounds.Top;
			int num3 = bounds.Right;
			int num4 = bounds.Bottom;
			Point marginsAlignment = GetMarginsAlignment(font, graphics);
			if (AlignmentHorizontal.Style == StringAlignment.Near)
			{
				num += marginsAlignment.X;
			}
			else if (AlignmentHorizontal.Style == StringAlignment.Far)
			{
				num3 -= marginsAlignment.X;
			}
			if (AlignmentVertical.Style == StringAlignment.Near)
			{
				num2 += marginsAlignment.Y;
			}
			else if (AlignmentVertical.Style == StringAlignment.Far)
			{
				num4 -= marginsAlignment.Y;
			}
			return iRectangle.FromLTRB(num, num2, num3, num4);
		}

		protected Rectangle GetRectangle(string s, Point pt, Font font, GraphicsAPI graphics)
		{
			Point marginsAlignment = GetMarginsAlignment(font, graphics);
			Size size = graphics.MeasureString(s, font, true);
			size = new Size(size.Width + 1, size.Height + 1);
			int left = (AlignmentHorizontal.Style != 0) ? ((AlignmentHorizontal.Style != StringAlignment.Far) ? (pt.X - size.Width / 2) : (pt.X + marginsAlignment.X)) : (pt.X - marginsAlignment.X - size.Width);
			int top = (AlignmentVertical.Style != 0) ? ((AlignmentVertical.Style != StringAlignment.Far) ? (pt.Y - size.Height / 2) : (pt.Y + marginsAlignment.Y)) : (pt.Y - marginsAlignment.Y - size.Height);
			return iRectangle.FromLTWH(left, top, size.Width, size.Height);
		}

		protected void Draw(GraphicsAPI graphics, Font font, Brush brush, string s, Rectangle r)
		{
			Point marginsAlignment = GetMarginsAlignment(font, graphics);
			if (AlignmentHorizontal.Style == StringAlignment.Near)
			{
				r.Offset(marginsAlignment.X, 0);
			}
			else if (AlignmentHorizontal.Style == StringAlignment.Far)
			{
				r.Offset(-marginsAlignment.X, 0);
			}
			if (AlignmentVertical.Style == StringAlignment.Near)
			{
				r.Offset(0, marginsAlignment.Y);
			}
			else if (AlignmentVertical.Style == StringAlignment.Far)
			{
				r.Offset(0, -marginsAlignment.Y);
			}
			graphics.DrawString(s, font, brush, r, StringFormat);
		}
	}
}
