using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Table Cell.")]
	public class PlotTableCell : IPlotTableCell
	{
		protected PlotTableBase m_Table;

		private Rectangle m_Bounds;

		private Rectangle m_BoundsText;

		private string m_Text;

		private Color m_ForeColor;

		private Font m_Font;

		private Size m_RequiredSize;

		private TextLayoutFull m_TextLayout;

		private bool m_Visible;

		private int m_ImageIndex;

		private ImageList m_ImageList;

		private bool m_ImageTransparent;

		private Size m_OuterMargin;

		private IAmbientOwner I_AmbientOwner;

		[Description("")]
		public Rectangle Bounds
		{
			get
			{
				return m_Bounds;
			}
			set
			{
				m_Bounds = value;
			}
		}

		[Description("")]
		public Rectangle BoundsText
		{
			get
			{
				return m_BoundsText;
			}
		}

		[Description("")]
		public Size RequiredSize
		{
			get
			{
				return m_RequiredSize;
			}
			set
			{
				m_RequiredSize = value;
			}
		}

		[Description("")]
		public TextLayoutFull TextLayout
		{
			get
			{
				return m_TextLayout;
			}
		}

		[Description("")]
		public bool Visible
		{
			get
			{
				return m_Visible;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string Text
		{
			get
			{
				if (m_Text == null)
				{
					m_Text = Const.EmptyString;
				}
				return m_Text;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				if (Text != value)
				{
					m_Text = value;
					m_Table.DoCellChange();
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Font Font
		{
			get
			{
				if (m_Font == null && I_AmbientOwner != null)
				{
					return I_AmbientOwner.Font;
				}
				return m_Font;
			}
			set
			{
				if (!GPFunctions.Equals(Font, value))
				{
					m_Font = value;
					m_Table.DoCellChange();
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public Color ForeColor
		{
			get
			{
				if (m_ForeColor == Color.Empty && I_AmbientOwner != null)
				{
					return I_AmbientOwner.ForeColor;
				}
				return m_ForeColor;
			}
			set
			{
				if (ForeColor != value)
				{
					m_ForeColor = value;
					m_Table.DoCellChange();
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public ImageList ImageList
		{
			get
			{
				Plot plot = null;
				if (m_Table != null)
				{
					plot = ((IPlotObject)m_Table).Plot;
				}
				if (m_ImageList == null && plot != null)
				{
					return plot.ImageListCommon;
				}
				return m_ImageList;
			}
			set
			{
				if (!GPFunctions.Equals(ImageList, value))
				{
					m_ImageList = value;
					m_Table.DoCellChange();
				}
			}
		}

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
				if (ImageIndex != value)
				{
					m_ImageIndex = value;
					m_Table.DoCellChange();
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ImageTransparent
		{
			get
			{
				return m_ImageTransparent;
			}
			set
			{
				if (ImageTransparent != value)
				{
					m_ImageTransparent = value;
					m_Table.DoCellChange();
				}
			}
		}

		void IPlotTableCell.Draw(PaintArgs p, bool showGrid, Pen gridPen)
		{
			Draw(p, showGrid, gridPen);
		}

		void IPlotTableCell.UpdateRequiredSize(PaintArgs p, bool visible, Size outerMargin, int fixedWidth, int fixedHeight)
		{
			UpdateRequiredSize(p, visible, outerMargin, fixedWidth, fixedHeight);
		}

		public PlotTableCell(PlotTableBase table, PlotTableCellFormat cellFormat)
		{
			m_Table = table;
			m_TextLayout = cellFormat.TextLayout;
			I_AmbientOwner = cellFormat;
			m_ImageIndex = -1;
		}

		protected Image GetImage()
		{
			if (ImageList != null && ImageIndex >= 0 && ImageIndex < ImageList.Images.Count)
			{
				return ImageList.Images[ImageIndex];
			}
			return null;
		}

		private void UpdateRequiredSize(PaintArgs p, bool visible, Size outerMargin, int fixedWidth, int fixedHeight)
		{
			m_Visible = visible;
			m_OuterMargin = outerMargin;
			if (!visible)
			{
				m_RequiredSize = Size.Empty;
			}
			else
			{
				Image image = GetImage();
				if (image == null)
				{
					m_RequiredSize = ((ITextLayoutBase)TextLayout).GetRequiredSize(Text, Font, p.Graphics);
				}
				else
				{
					m_RequiredSize = image.Size;
				}
				if (fixedWidth != -1)
				{
					m_RequiredSize = new Size(fixedWidth, m_RequiredSize.Height);
				}
				if (fixedHeight != -1)
				{
					m_RequiredSize = new Size(m_RequiredSize.Width, fixedHeight);
				}
				m_RequiredSize = new Size(m_RequiredSize.Width + 2 * m_OuterMargin.Width, m_RequiredSize.Height + 2 * m_OuterMargin.Height);
			}
		}

		private void Draw(PaintArgs p, bool showGrid, Pen gridPen)
		{
			if (Visible)
			{
				Region clip = p.Graphics.Clip;
				Image image = GetImage();
				m_BoundsText = Bounds;
				m_BoundsText.Inflate(-m_OuterMargin.Width, -m_OuterMargin.Height);
				p.Graphics.SetClip(Bounds);
				if (image == null)
				{
					((ITextLayoutBase)TextLayout).Draw(p.Graphics, Font, p.Graphics.Brush(ForeColor), Text, BoundsText);
				}
				else
				{
					Point point = new Point(BoundsText.Left, BoundsText.Top);
					Rectangle r = new Rectangle(point.X, point.Y, image.Width, image.Height);
					if (ImageTransparent)
					{
						p.Graphics.DrawImageTransparent(image, r);
					}
					else
					{
						p.Graphics.DrawImage(image, point.X, point.Y);
					}
				}
				p.Graphics.Clip = clip;
				if (showGrid)
				{
					p.Graphics.DrawRectangle(gridPen, Bounds);
				}
			}
		}
	}
}
