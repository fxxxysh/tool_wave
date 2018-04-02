using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Label Base.")]
	public abstract class PlotLabelBase : PlotLayoutFill
	{
		private string m_Text;

		private PlotAutoRotation m_TextRotation;

		private int m_ImageIndex;

		private ImageList m_ImageList;

		private bool m_ImageTransparent;

		private TextLayoutFull m_TextLayout;

		private ITextLayoutFull I_TextLayout;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Editor("System.Windows.Forms.Design.StringArrayEditor,System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
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

		[Description("Specifies the text for the label.")]
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public TextLayoutFull TextLayout
		{
			get
			{
				return m_TextLayout;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ImageList ImageList
		{
			get
			{
				if (m_ImageList == null && base.Plot != null)
				{
					return base.Plot.ImageListCommon;
				}
				return m_ImageList;
			}
			set
			{
				base.PropertyUpdateDefault("ImageList", value);
				if (!GPFunctions.Equals(ImageList, value))
				{
					m_ImageList = value;
					base.DoPropertyChange(this, "ImageList");
				}
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int ImageIndex
		{
			get
			{
				return m_ImageIndex;
			}
			set
			{
				base.PropertyUpdateDefault("ImageIndex", value);
				if (ImageIndex != value)
				{
					m_ImageIndex = value;
					base.DoPropertyChange(this, "ImageIndex");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public bool ImageTransparent
		{
			get
			{
				return m_ImageTransparent;
			}
			set
			{
				base.PropertyUpdateDefault("ImageTransparent", value);
				if (ImageTransparent != value)
				{
					m_ImageTransparent = value;
					base.DoPropertyChange(this, "ImageTransparent");
				}
			}
		}

		protected TextRotation ActualTextRotation
		{
			get
			{
				if (TextRotation == PlotAutoRotation.Auto)
				{
					if (base.DockVertical)
					{
						return Iocomp.Types.TextRotation.X000;
					}
					if (base.DockLeft)
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

		protected bool TextHorizontal
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

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_TextLayout = new TextLayoutFull();
			base.AddSubClass(TextLayout);
			I_TextLayout = TextLayout;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			DockSide = AlignmentQuadSide.Top;
			base.DockAutoSizeAlignment = PlotDockAutoSizeAlignment.None;
			Text = "Label";
			TextRotation = PlotAutoRotation.Auto;
			TextLayout.Trimming = StringTrimming.None;
			TextLayout.LineLimit = false;
			TextLayout.MeasureTrailingSpaces = false;
			TextLayout.NoWrap = false;
			TextLayout.NoClip = false;
			TextLayout.AlignmentHorizontal.Style = StringAlignment.Center;
			TextLayout.AlignmentHorizontal.Margin = 0.5;
			TextLayout.AlignmentVertical.Style = StringAlignment.Center;
			TextLayout.AlignmentVertical.Margin = 0.5;
			ImageIndex = -1;
			ImageList = null;
			ImageTransparent = true;
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

		private bool ShouldSerializeTextLayout()
		{
			return ((ISubClassBase)TextLayout).ShouldSerialize();
		}

		private void ResetTextLayout()
		{
			((ISubClassBase)TextLayout).ResetToDefault();
		}

		private bool ShouldSerializeImageIndex()
		{
			return base.PropertyShouldSerialize("ImageIndex");
		}

		private void ResetImageIndex()
		{
			base.PropertyReset("ImageIndex");
		}

		private bool ShouldSerializeImageTransparent()
		{
			return base.PropertyShouldSerialize("ImageTransparent");
		}

		private void ResetImageTransparent()
		{
			base.PropertyReset("ImageTransparent");
		}

		protected Image GetImage()
		{
			if (ImageList != null && ImageIndex >= 0 && ImageIndex < ImageList.Images.Count)
			{
				return ImageList.Images[ImageIndex];
			}
			return null;
		}
	}
}
