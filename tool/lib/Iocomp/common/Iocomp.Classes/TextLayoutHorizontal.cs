using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Description("Contains the horizontal and vertical layout properties for text.")]
	public sealed class TextLayoutHorizontal : SubClassBase, ITextLayoutHorizontal
	{
		private AlignmentText m_Alignment;

		private StringTrimming m_Trimming;

		private bool m_LineLimit;

		private bool m_MeasureTrailingSpaces;

		private bool m_NoWrap;

		private bool m_NoClip;

		private bool m_Flipped;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[ParenthesizePropertyName(true)]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public AlignmentText Alignment
		{
			get
			{
				return m_Alignment;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool Flipped
		{
			get
			{
				return m_Flipped;
			}
			set
			{
				base.PropertyUpdateDefault("Flipped", value);
				if (Flipped != value)
				{
					m_Flipped = value;
					base.DoPropertyChange(this, "Flipped");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public StringTrimming Trimming
		{
			get
			{
				return m_Trimming;
			}
			set
			{
				base.PropertyUpdateDefault("Trimming", value);
				if (Trimming != value)
				{
					m_Trimming = value;
					base.DoPropertyChange(this, "Trimming");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool LineLimit
		{
			get
			{
				return m_LineLimit;
			}
			set
			{
				base.PropertyUpdateDefault("LineLimit", value);
				if (LineLimit != value)
				{
					m_LineLimit = value;
					base.DoPropertyChange(this, "LineLimit");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the line boundary measurement spaceIf true, the boundary will include the space at the end of each lineIf false, the boundary will exclude the space at the end of each line.")]
		public bool MeasureTrailingSpaces
		{
			get
			{
				return m_MeasureTrailingSpaces;
			}
			set
			{
				base.PropertyUpdateDefault("MeasureTrailingSpaces", value);
				if (MeasureTrailingSpaces != value)
				{
					m_MeasureTrailingSpaces = value;
					base.DoPropertyChange(this, "MeasureTrailingSpaces");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Disables wrapping of text.")]
		public bool NoWrap
		{
			get
			{
				return m_NoWrap;
			}
			set
			{
				base.PropertyUpdateDefault("NoWrap", value);
				if (NoWrap != value)
				{
					m_NoWrap = value;
					base.DoPropertyChange(this, "NoWrap");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the text clipping behavior.If true, the overhanging unwrapped text reaching outside the formatting rectangle are allowed to show.If false, the overhanging text will be clipped.")]
		public bool NoClip
		{
			get
			{
				return m_NoClip;
			}
			set
			{
				base.PropertyUpdateDefault("NoClip", value);
				if (NoClip != value)
				{
					m_NoClip = value;
					base.DoPropertyChange(this, "NoClip");
				}
			}
		}

		private DrawStringFormat StringFormat
		{
			get
			{
				StringFormatFlags stringFormatFlags = (StringFormatFlags)0;
				if (m_LineLimit)
				{
					stringFormatFlags |= StringFormatFlags.LineLimit;
				}
				if (m_MeasureTrailingSpaces)
				{
					stringFormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
				}
				if (m_NoWrap)
				{
					stringFormatFlags |= StringFormatFlags.NoWrap;
				}
				if (m_NoClip)
				{
					stringFormatFlags |= StringFormatFlags.NoClip;
				}
				DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
				genericTypographic.Alignment = Alignment.Style;
				genericTypographic.Trimming = m_Trimming;
				genericTypographic.FormatFlags = stringFormatFlags;
				return genericTypographic;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Text Layout";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.TextLayoutHorizontalEditorPlugIn";
		}

		void ITextLayoutHorizontal.Draw(GraphicsAPI graphics, Font font, Brush brush, string s, Rectangle r)
		{
			Draw(graphics, font, brush, s, r);
		}

		Point ITextLayoutHorizontal.GetMarginOffsets(Font font, GraphicsAPI graphics)
		{
			return GetMarginOffsets(font, graphics);
		}

		Size ITextLayoutHorizontal.GetRequiredSize(string s, Font font, GraphicsAPI graphics)
		{
			return GetRequiredSize(s, font, graphics);
		}

		public TextLayoutHorizontal()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Alignment = new AlignmentText();
			base.AddSubClass(Alignment);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Trimming = StringTrimming.Character;
			LineLimit = false;
			MeasureTrailingSpaces = false;
			NoWrap = false;
			NoClip = false;
			Flipped = false;
		}

		private bool ShouldSerializeAlignment()
		{
			return ((ISubClassBase)Alignment).ShouldSerialize();
		}

		private void ResetAlignment()
		{
			((ISubClassBase)Alignment).ResetToDefault();
		}

		private bool ShouldSerializeFlipped()
		{
			return base.PropertyShouldSerialize("Flipped");
		}

		private void ResetFlipped()
		{
			base.PropertyReset("Flipped");
		}

		private bool ShouldSerializeTrimming()
		{
			return base.PropertyShouldSerialize("Trimming");
		}

		private void ResetTrimming()
		{
			base.PropertyReset("Trimming");
		}

		private bool ShouldSerializeLineLimit()
		{
			return base.PropertyShouldSerialize("LineLimit");
		}

		private void ResetLineLimit()
		{
			base.PropertyReset("LineLimit");
		}

		private bool ShouldSerializeMeasureTrailingSpaces()
		{
			return base.PropertyShouldSerialize("MeasureTrailingSpaces");
		}

		private void ResetMeasureTrailingSpaces()
		{
			base.PropertyReset("MeasureTrailingSpaces");
		}

		private bool ShouldSerializeNoWrap()
		{
			return base.PropertyShouldSerialize("NoWrap");
		}

		private void ResetNoWrap()
		{
			base.PropertyReset("NoWrap");
		}

		private bool ShouldSerializeNoClip()
		{
			return base.PropertyShouldSerialize("NoClip");
		}

		private void ResetNoClip()
		{
			base.PropertyReset("NoClip");
		}

		private Point GetMarginOffsets(Font font, GraphicsAPI graphics)
		{
			int x = (int)Math.Ceiling((double)graphics.MeasureString("0", font, true).Width * Alignment.Margin);
			return new Point(x, 0);
		}

		private Size GetRequiredSize(string s, Font font, GraphicsAPI graphics)
		{
			Point marginOffsets = GetMarginOffsets(font, graphics);
			Size size = graphics.MeasureString(s, font, true);
			return new Size(size.Width + marginOffsets.X, size.Height + marginOffsets.Y);
		}

		private void Draw(GraphicsAPI graphics, Font font, Brush brush, string s, Rectangle r)
		{
			Point point = new Point((r.Left + r.Right) / 2, (r.Top + r.Bottom) / 2);
			DrawStringFormat stringFormat = StringFormat;
			Point marginOffsets = GetMarginOffsets(font, graphics);
			if (Alignment.Style == StringAlignment.Near)
			{
				r.Offset(marginOffsets.X, 0);
			}
			else if (Alignment.Style == StringAlignment.Far)
			{
				r.Offset(-marginOffsets.X, 0);
			}
			GraphicsState gstate = graphics.Save();
			graphics.TranslateTransform((float)point.X, (float)point.Y);
			if (Flipped)
			{
				graphics.ScaleTransform(-1f, -1f);
			}
			graphics.TranslateTransform((float)(-point.X), (float)(-point.Y));
			graphics.DrawString(s, font, brush, r, stringFormat);
			graphics.Restore(gstate);
		}
	}
}
