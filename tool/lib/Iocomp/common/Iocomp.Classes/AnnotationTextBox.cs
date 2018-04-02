using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace Iocomp.Classes
{
	[Serializable]
	public sealed class AnnotationTextBox : AnnotationShape
	{
		private string m_Text;

		private bool m_FixedSize;

		private Font m_DrawFont;

		private TextLayoutBase m_TextLayout;

		[Category("Iocomp")]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TextLayoutBase TextLayout
		{
			get
			{
				return m_TextLayout;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool FixedSize
		{
			get
			{
				return m_FixedSize;
			}
			set
			{
				base.PropertyUpdateDefault("FixedSize", value);
				if (FixedSize != value)
				{
					m_FixedSize = value;
					base.DoPropertyChange(this, "FixedSize");
				}
				if (m_FixedSize)
				{
					base.GrabHandle1.Enabled = false;
					base.GrabHandle5.Enabled = false;
				}
				else
				{
					base.GrabHandle1.Enabled = true;
					base.GrabHandle5.Enabled = true;
				}
			}
		}

		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Editor("System.Windows.Forms.Design.StringArrayEditor,System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
		public string[] TextLines
		{
			get
			{
				return Text.Split('\n');
			}
			set
			{
				base.PropertyUpdateDefault("TextLines", value);
				StringBuilder stringBuilder = new StringBuilder(value.Length);
				for (int i = 0; i < value.Length; i++)
				{
					if (i < value.Length - 1)
					{
						stringBuilder.Append(value[i] + "\n");
					}
					else
					{
						stringBuilder.Append(value[i]);
					}
				}
				Text = stringBuilder.ToString();
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Annotation TextBox";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AnnotationTextBoxEditorPlugIn";
		}

		public AnnotationTextBox()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_TextLayout = new TextLayoutBase();
			base.AddSubClass(TextLayout);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.GrabHandle0.Enabled = false;
			base.GrabHandle1.Enabled = false;
			base.GrabHandle2.Enabled = false;
			base.GrabHandle3.Enabled = false;
			base.GrabHandle4.Enabled = false;
			base.GrabHandle5.Enabled = false;
			base.GrabHandle6.Enabled = false;
			base.GrabHandle7.Enabled = false;
			ForeColor = Color.Empty;
			Font = null;
			Text = "Text Box";
			FixedSize = false;
			TextLines = new string[1]
			{
				"Text Box"
			};
			TextLines[0] = Text;
			TextLayout.AlignmentHorizontal.Style = StringAlignment.Center;
			TextLayout.AlignmentHorizontal.Margin = 0.5;
			TextLayout.AlignmentVertical.Style = StringAlignment.Center;
			TextLayout.AlignmentVertical.Margin = 0.5;
		}

		private bool ShouldSerializeTextLayout()
		{
			return ((ISubClassBase)TextLayout).ShouldSerialize();
		}

		private void ResetTextLayout()
		{
			((ISubClassBase)TextLayout).ResetToDefault();
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

		private bool ShouldSerializeFixedSize()
		{
			return base.PropertyShouldSerialize("FixedSize");
		}

		private void ResetFixedSize()
		{
			base.PropertyReset("FixedSize");
		}

		private bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetText()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeTextLines()
		{
			return base.PropertyShouldSerialize("TextLines");
		}

		private void ResetTextLines()
		{
			base.PropertyReset("TextLines");
		}

		protected override void DrawOutline(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.DrawRectangle(p.Graphics.Pen(base.OutlineColor, base.DashStyle), rect);
		}

		protected override void DrawFillHatch(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.FillRectangle(p.Graphics.Brush(base.HatchStyle, base.HatchForeColor, base.HatchBackColor), rect);
		}

		protected override void DrawFillGradient(PaintArgs p, Rectangle rect, Point[] points)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(rect);
			p.Graphics.FillGradientPath(rect, graphicsPath, base.GradientStartColor, base.GradientStopColor, base.ModeAngle, 1f, false);
		}

		protected override void DrawFillSolid(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.FillRectangle(p.Graphics.Brush(base.FillColor), rect);
		}

		protected override void DrawCustom(PaintArgs p)
		{
			int num = Scale.ConvertHeightUnitsToPixels(Height);
			int height = Font.Height;
			float num2 = FixedSize ? Font.Size : ((float)num / (float)height * Font.Size);
			if (!(num2 <= 0f))
			{
				Font font;
				if (Font.Size != num2)
				{
					if (m_DrawFont == null || m_DrawFont.Size != num2)
					{
						m_DrawFont = new Font(Font.Name, num2, Font.Style);
					}
					font = m_DrawFont;
				}
				else
				{
					font = Font;
				}
				Size requiredSize = ((ITextLayoutBase)TextLayout).GetRequiredSize(Text, font, p.Graphics);
				Rectangle r = new Rectangle(Scale.ConvertUnitsToPixelsX(X) - requiredSize.Width / 2, Scale.ConvertUnitsToPixelsY(Y) - requiredSize.Height / 2, requiredSize.Width + 1, requiredSize.Height + 1);
				base.ClickRegion = ToClickRegion(r);
				base.UpdateGrabHandles(r);
				if (r.Height != 0 && r.Width != 0)
				{
					if (base.FillStyle != AnnotationFillStyle.Clear)
					{
						base.DrawFill(p, r, null);
					}
					Rectangle r2 = new Rectangle(r.Left, r.Top, r.Width - 1, r.Height - 1);
					if (r2.Height != 0 && r2.Width != 0)
					{
						if (base.OutlineStyle != AnnotationOutlineStyle.Clear)
						{
							DrawOutline(p, r2, null);
						}
						((ITextLayoutBase)TextLayout).Draw(p.Graphics, font, p.Graphics.Brush(ForeColor), Text, r);
					}
				}
			}
		}

		public override string ToString()
		{
			return "Annotation TextBox";
		}
	}
}
