using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Serializable]
	public sealed class AnnotationImage : AnnotationBase, IAnnotationImage
	{
		private ImageListStyle m_ImageListStyle;

		private int m_ImageIndex;

		private ImageList m_ImageListSmall;

		private ImageList m_ImageListLarge;

		private ImageList m_ImageListCustom;

		private bool m_FixedSize;

		private ImageList ImageListActive
		{
			get
			{
				if (ImageListStyle == ImageListStyle.ImageListLarge)
				{
					return m_ImageListLarge;
				}
				if (ImageListStyle == ImageListStyle.ImageListSmall)
				{
					return m_ImageListSmall;
				}
				return m_ImageListCustom;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public ImageListStyle ImageListStyle
		{
			get
			{
				return m_ImageListStyle;
			}
			set
			{
				base.PropertyUpdateDefault("ImageListStyle", value);
				if (ImageListStyle != value)
				{
					m_ImageListStyle = value;
					base.DoPropertyChange(this, "ImageListStyle");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public ImageList ImageListSmall
		{
			get
			{
				return m_ImageListSmall;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public ImageList ImageListLarge
		{
			get
			{
				return m_ImageListLarge;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public ImageList ImageListCustom
		{
			get
			{
				return m_ImageListCustom;
			}
			set
			{
				m_ImageListCustom = value;
			}
		}

		[Category("Iocomp")]
		[Description("Specifies the MotorBase style.")]
		[RefreshProperties(RefreshProperties.All)]
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
		[Description("")]
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
					base.GrabHandle0.Enabled = false;
					base.GrabHandle1.Enabled = false;
					base.GrabHandle2.Enabled = false;
					base.GrabHandle3.Enabled = false;
					base.GrabHandle4.Enabled = false;
					base.GrabHandle5.Enabled = false;
					base.GrabHandle6.Enabled = false;
					base.GrabHandle7.Enabled = false;
				}
				else
				{
					base.GrabHandle0.Enabled = true;
					base.GrabHandle1.Enabled = true;
					base.GrabHandle2.Enabled = true;
					base.GrabHandle3.Enabled = true;
					base.GrabHandle4.Enabled = true;
					base.GrabHandle5.Enabled = true;
					base.GrabHandle6.Enabled = true;
					base.GrabHandle7.Enabled = true;
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Annotation Image";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AnnotationImageEditorPlugIn";
		}

		void IAnnotationImage.SetImageListSmall(ImageList value)
		{
			m_ImageListSmall = value;
		}

		void IAnnotationImage.SetImageListLarge(ImageList value)
		{
			m_ImageListLarge = value;
		}

		public AnnotationImage()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			ImageListStyle = ImageListStyle.ImageListLarge;
			ImageIndex = -1;
			FixedSize = false;
		}

		private bool ShouldSerializeImageListStyle()
		{
			return base.PropertyShouldSerialize("ImageListStyle");
		}

		private void ResetImageListStyle()
		{
			base.PropertyReset("ImageListStyle");
		}

		private bool ShouldSerializeImageIndex()
		{
			return base.PropertyShouldSerialize("ImageIndex");
		}

		private void ResetImageIndex()
		{
			base.PropertyReset("ImageIndex");
		}

		private bool ShouldSerializeFixedSize()
		{
			return base.PropertyShouldSerialize("FixedSize");
		}

		private void ResetFixedSize()
		{
			base.PropertyReset("FixedSize");
		}

		protected override void DrawCustom(PaintArgs p)
		{
			float num = (float)Scale.ConvertHeightUnitsToPixels(Height);
			float num2 = (float)Scale.ConvertWidthUnitsToPixels(Width);
			if (ImageListActive != null && ImageIndex > -1 && ImageIndex < ImageListActive.Images.Count)
			{
				Image image = ImageListActive.Images[ImageIndex];
				float num3;
				float num4;
				if (!FixedSize)
				{
					num3 = num / (float)image.Height * (float)image.Height;
					num4 = num2 / (float)image.Width * (float)image.Width;
				}
				else
				{
					num3 = (float)image.Height;
					num4 = (float)image.Width;
				}
				Rectangle r = new Rectangle((int)((float)Scale.ConvertUnitsToPixelsX(X) - num4 / 2f), (int)((float)Scale.ConvertUnitsToPixelsY(Y) - num3 / 2f), (int)num4 + 1, (int)num3 + 1);
				base.ClickRegion = ToClickRegion(r);
				base.UpdateGrabHandles(r);
				p.Graphics.DrawImageTransparent(image, r);
			}
		}

		public override string ToString()
		{
			return "Annotation Image";
		}
	}
}