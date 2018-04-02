using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Iocomp.Classes
{
	[Description("Plot Title.")]
	public class PlotTitle : SubClassBase, IPlotTitle
	{
		private string m_Text;

		private PlotAutoRotation m_TextRotation;

		private double m_MarginSpacing;

		private double m_MarginOuter;

		private AlignmentQuadSide m_DockSide;

		private int m_MarginOuterPixels;

		private int m_RequiredDepthPixels;

		private int m_TitleDepthPixels;

		private int m_SpacingPixels;

		private TextLayoutFull m_TextLayout;

		private ITextLayoutFull I_TextLayout;

		private PlotFill m_Fill;

		private IPlotFill I_Fill;

		AlignmentQuadSide IPlotTitle.DockSide
		{
			get
			{
				return DockSide;
			}
			set
			{
				DockSide = value;
			}
		}

		int IPlotTitle.RequiredDepthPixels
		{
			get
			{
				return RequiredDepthPixels;
			}
		}

		int IPlotTitle.TitleDepthPixels
		{
			get
			{
				return TitleDepthPixels;
			}
		}

		int IPlotTitle.SpacingPixels
		{
			get
			{
				return SpacingPixels;
			}
		}

		protected Color SolidColor => Color;

		protected Color HatchForeColor => Color;

		protected Color HatchBackColor => Color;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public TextLayoutFull TextLayout
		{
			get
			{
				return m_TextLayout;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill Fill
		{
			get
			{
				return m_Fill;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Editor("System.Windows.Forms.Design.StringArrayEditor,System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string[] TextLines
		{
			get
			{
				return Text.Split('\n');
			}
			set
			{
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the text for the label.")]
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
		public PlotAutoRotation TextRotation
		{
			get
			{
				return m_TextRotation;
			}
			set
			{
				base.PropertyUpdateDefault("TextRotation", value);
				if (TextRotation != value)
				{
					m_TextRotation = value;
					base.DoPropertyChange(this, "TextRotation");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public new Color Color
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.Color = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double MarginOuter
		{
			get
			{
				return m_MarginOuter;
			}
			set
			{
				base.PropertyUpdateDefault("MarginOuter", value);
				if (MarginOuter != value)
				{
					m_MarginOuter = value;
					base.DoPropertyChange(this, "MarginOuter");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double MarginSpacing
		{
			get
			{
				return m_MarginSpacing;
			}
			set
			{
				base.PropertyUpdateDefault("MarginSpacing", value);
				if (MarginSpacing != value)
				{
					m_MarginSpacing = value;
					base.DoPropertyChange(this, "MarginSpacing");
				}
			}
		}

		private AlignmentQuadSide DockSide
		{
			get
			{
				return m_DockSide;
			}
			set
			{
				m_DockSide = value;
			}
		}

		private int RequiredDepthPixels => m_RequiredDepthPixels;

		private int TitleDepthPixels => m_TitleDepthPixels;

		private int SpacingPixels => m_SpacingPixels;

		private bool DockLeft => m_DockSide == AlignmentQuadSide.Left;

		private bool DockRight => m_DockSide == AlignmentQuadSide.Right;

		private bool DockTop => m_DockSide == AlignmentQuadSide.Top;

		private bool DockBottom => m_DockSide == AlignmentQuadSide.Bottom;

		private bool DockVertical
		{
			get
			{
				if (!DockTop)
				{
					return DockBottom;
				}
				return true;
			}
		}

		private bool DockHorizontal
		{
			get
			{
				if (!DockLeft)
				{
					return DockRight;
				}
				return true;
			}
		}

		private TextRotation ActualTextRotation
		{
			get
			{
				if (TextRotation == PlotAutoRotation.Auto)
				{
					if (DockVertical)
					{
						return Iocomp.Types.TextRotation.X000;
					}
					if (DockLeft)
					{
						return Iocomp.Types.TextRotation.X270;
					}
					return Iocomp.Types.TextRotation.X090;
				}
				if (TextRotation == PlotAutoRotation.X000)
				{
					return Iocomp.Types.TextRotation.X000;
				}
				if (TextRotation == PlotAutoRotation.X090)
				{
					return Iocomp.Types.TextRotation.X090;
				}
				if (TextRotation == PlotAutoRotation.X180)
				{
					return Iocomp.Types.TextRotation.X180;
				}
				return Iocomp.Types.TextRotation.X270;
			}
		}

		private bool TextHorizontal
		{
			get
			{
				if (ActualTextRotation != 0)
				{
					return ActualTextRotation == Iocomp.Types.TextRotation.X180;
				}
				return true;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Title";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotTitleEditorPlugIn";
		}

		void IPlotTitle.Draw(PaintArgs p, Rectangle bounds)
		{
			Draw(p, bounds);
		}

		void IPlotTitle.CalculateDrawingData(PaintArgs p, int spanPixels)
		{
			CalculateDrawingData(p, spanPixels);
		}

		public PlotTitle()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_TextLayout = new TextLayoutFull();
			base.AddSubClass(TextLayout);
			I_TextLayout = TextLayout;
			m_Fill = new PlotFill();
			base.AddSubClass(Fill);
			I_Fill = Fill;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Text = "Title";
			TextRotation = PlotAutoRotation.Auto;
			MarginSpacing = 0.0;
			MarginOuter = 0.5;
			Color = Color.Empty;
			ForeColor = Color.Empty;
			Fill.Visible = false;
			Fill.Brush.Visible = true;
			Fill.Brush.Style = PlotBrushStyle.Solid;
			Fill.Brush.SolidColor = Color.Empty;
			Fill.Brush.GradientStartColor = Color.Blue;
			Fill.Brush.GradientStopColor = Color.Aqua;
			Fill.Brush.HatchForeColor = Color.Empty;
			Fill.Brush.HatchBackColor = Color.Empty;
			Fill.Pen.Visible = true;
			Fill.Pen.Color = Color.Empty;
			Fill.Pen.Thickness = 1.0;
			Fill.Pen.Style = PlotPenStyle.Solid;
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeTextLayout()
		{
			return ((ISubClassBase)TextLayout).ShouldSerialize();
		}

		private void ResetTextLayout()
		{
			((ISubClassBase)TextLayout).ResetToDefault();
		}

		private bool ShouldSerializeFill()
		{
			return ((ISubClassBase)Fill).ShouldSerialize();
		}

		private void ResetFill()
		{
			((ISubClassBase)Fill).ResetToDefault();
		}

		private bool ShouldSerializeTextLines()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetTextLines()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetText()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeTextRotation()
		{
			return base.PropertyShouldSerialize("TextRotation");
		}

		private void ResetTextRotation()
		{
			base.PropertyReset("TextRotation");
		}

		private bool ShouldSerializeForeColor()
		{
			return base.PropertyShouldSerialize("ForeColor");
		}

		private void ResetForeColor()
		{
			base.PropertyReset("ForeColor");
		}

		private bool ShouldSerializeFont()
		{
			return base.PropertyShouldSerialize("Font");
		}

		private void ResetFont()
		{
			base.PropertyReset("Font");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeMarginOuter()
		{
			return base.PropertyShouldSerialize("MarginOuter");
		}

		private void ResetMarginOuter()
		{
			base.PropertyReset("MarginOuter");
		}

		private bool ShouldSerializeMarginSpacing()
		{
			return base.PropertyShouldSerialize("MarginSpacing");
		}

		private void ResetMarginSpacing()
		{
			base.PropertyReset("MarginSpacing");
		}

		private void CalculateDrawingData(PaintArgs p, int spanPixels)
		{
			m_MarginOuterPixels = 0;
			m_SpacingPixels = 0;
			m_RequiredDepthPixels = 0;
			m_TitleDepthPixels = 0;
			if (Visible)
			{
				m_MarginOuterPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(Font).Height * MarginOuter);
				m_SpacingPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(Font).Height * MarginSpacing);
				Size size = (!DockVertical) ? ((!TextHorizontal) ? ((ITextLayoutBase)TextLayout).GetRequiredSize(Text, Font, spanPixels - 2 * m_MarginOuterPixels, p.Graphics) : ((ITextLayoutBase)TextLayout).GetRequiredSize(Text, Font, 0, p.Graphics)) : ((!TextHorizontal) ? ((ITextLayoutBase)TextLayout).GetRequiredSize(Text, Font, 0, p.Graphics) : ((ITextLayoutBase)TextLayout).GetRequiredSize(Text, Font, spanPixels - 2 * m_MarginOuterPixels, p.Graphics));
				if (!((!DockVertical) ? TextHorizontal : (!TextHorizontal)))
				{
					m_RequiredDepthPixels = size.Height + 2 * m_MarginOuterPixels;
				}
				else
				{
					m_RequiredDepthPixels = size.Width + 2 * m_MarginOuterPixels;
				}
				m_TitleDepthPixels = m_RequiredDepthPixels;
			}
		}

		private void Draw(PaintArgs p, Rectangle bounds)
		{
			if (Visible)
			{
				I_Fill.Draw(p, bounds);
				Rectangle rectangle = ((ITextLayoutBase)TextLayout).GetRectangle(bounds, Font, p.Graphics);
				rectangle.Inflate(-m_MarginOuterPixels, -m_MarginOuterPixels);
				p.Graphics.DrawRotatedText(Text, Font, ForeColor, rectangle, ActualTextRotation, ((ITextLayoutBase)TextLayout).StringFormat);
			}
		}
	}
}
