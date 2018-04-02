using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Table Base.")]
	public abstract class PlotTableBase : PlotLayoutFill
	{
		private int m_DataColCount;

		private int m_DataRowCount;

		private SizeStyle m_ColWidthStyle;

		private double m_ColWidthValue;

		private double m_ColOuterMargin;

		private SizeStyle m_RowHeightStyle;

		private double m_RowHeightValue;

		private double m_RowOuterMargin;

		private bool m_ColTitlesVisible;

		private bool m_RowTitlesVisible;

		private PlotTableCellsFormatting m_CellsFormatting;

		private PlotPen m_GridOutline;

		protected IPlotPen I_GridOutline;

		private int m_MarginOuterPixels;

		private int m_LengthPixels;

		private Size m_CellOuterMargin;

		private ITextLayoutFull I_TextLayoutDat;

		private ITextLayoutFull I_TextLayoutCol;

		private ITextLayoutFull I_TextLayoutRow;

		private Array m_Cells;

		private ArrayList m_ColWidths;

		private ArrayList m_RowHeights;

		private bool m_IgnoreCellChanges;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotTableCellsFormatting CellsFormatting
		{
			get
			{
				return m_CellsFormatting;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotPen GridOutline
		{
			get
			{
				return m_GridOutline;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ColTitlesVisible
		{
			get
			{
				return m_ColTitlesVisible;
			}
			set
			{
				base.PropertyUpdateDefault("ColTitlesVisible", value);
				if (ColTitlesVisible != value)
				{
					m_ColTitlesVisible = value;
					RegenerateArray();
					base.DoPropertyChange(this, "ColTitlesVisible");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool RowTitlesVisible
		{
			get
			{
				return m_RowTitlesVisible;
			}
			set
			{
				base.PropertyUpdateDefault("RowTitlesVisible", value);
				if (RowTitlesVisible != value)
				{
					m_RowTitlesVisible = value;
					RegenerateArray();
					base.DoPropertyChange(this, "RowTitlesVisible");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PlotTableCell this[int col, int row]
		{
			get
			{
				return (PlotTableCell)m_Cells.GetValue(col, row);
			}
		}

		protected int DataColCount
		{
			get
			{
				return m_DataColCount;
			}
			set
			{
				base.PropertyUpdateDefault("DataColCount", value);
				if (DataColCount != value)
				{
					m_DataColCount = value;
					RegenerateArray();
					base.DoPropertyChange(this, "DataColCount");
				}
			}
		}

		protected int DataRowCount
		{
			get
			{
				return m_DataRowCount;
			}
			set
			{
				base.PropertyUpdateDefault("DataRowCount", value);
				if (DataRowCount != value)
				{
					m_DataRowCount = value;
					RegenerateArray();
					base.DoPropertyChange(this, "DataRowCount");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public SizeStyle ColWidthStyle
		{
			get
			{
				return m_ColWidthStyle;
			}
			set
			{
				base.PropertyUpdateDefault("ColWidthStyle", value);
				if (ColWidthStyle != value)
				{
					m_ColWidthStyle = value;
					base.DoPropertyChange(this, "ColWidthStyle");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double ColWidthValue
		{
			get
			{
				return m_ColWidthValue;
			}
			set
			{
				base.PropertyUpdateDefault("ColWidthValue", value);
				if (ColWidthValue != value)
				{
					m_ColWidthValue = value;
					base.DoPropertyChange(this, "ColWidthValue");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double ColOuterMargin
		{
			get
			{
				return m_ColOuterMargin;
			}
			set
			{
				base.PropertyUpdateDefault("ColOuterMargin", value);
				if (ColOuterMargin != value)
				{
					m_ColOuterMargin = value;
					base.DoPropertyChange(this, "ColOuterMargin");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public SizeStyle RowHeightStyle
		{
			get
			{
				return m_RowHeightStyle;
			}
			set
			{
				base.PropertyUpdateDefault("RowHeightStyle", value);
				if (RowHeightStyle != value)
				{
					m_RowHeightStyle = value;
					base.DoPropertyChange(this, "RowHeightStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double RowHeightValue
		{
			get
			{
				return m_RowHeightValue;
			}
			set
			{
				base.PropertyUpdateDefault("RowHeightValue", value);
				if (RowHeightValue != value)
				{
					m_RowHeightValue = value;
					base.DoPropertyChange(this, "RowHeightValue");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double RowOuterMargin
		{
			get
			{
				return m_RowOuterMargin;
			}
			set
			{
				base.PropertyUpdateDefault("RowOuterMargin", value);
				if (RowOuterMargin != value)
				{
					m_RowOuterMargin = value;
					base.DoPropertyChange(this, "RowOuterMargin");
				}
			}
		}

		public int ActualColCount => DataColCount + 1;

		public int ActualRowCount => DataRowCount + 1;

		protected int MarginOuterPixels => m_MarginOuterPixels;

		protected int LengthPixels => m_LengthPixels;

		protected bool IgnoreCellChanges
		{
			get
			{
				return m_IgnoreCellChanges;
			}
			set
			{
				m_IgnoreCellChanges = value;
			}
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_CellsFormatting = new PlotTableCellsFormatting();
			base.AddSubClass(CellsFormatting);
			m_GridOutline = new PlotPen();
			base.AddSubClass(GridOutline);
			I_GridOutline = GridOutline;
			I_TextLayoutDat = CellsFormatting.Data.TextLayout;
			I_TextLayoutCol = CellsFormatting.ColTitles.TextLayout;
			I_TextLayoutRow = CellsFormatting.RowTitles.TextLayout;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			DockSide = AlignmentQuadSide.Right;
			DataColCount = 5;
			DataRowCount = 1;
			ColWidthStyle = SizeStyle.Auto;
			ColWidthValue = 6.0;
			ColOuterMargin = 1.0;
			RowHeightStyle = SizeStyle.Auto;
			RowHeightValue = 2.0;
			RowOuterMargin = 0.25;
			ColTitlesVisible = false;
			RowTitlesVisible = false;
			GridOutline.Color = Color.Empty;
			GridOutline.Thickness = 1.0;
			GridOutline.Style = PlotPenStyle.Solid;
			GridOutline.Visible = true;
		}

		private bool ShouldSerializeCellsFormatting()
		{
			return ((ISubClassBase)CellsFormatting).ShouldSerialize();
		}

		private void ResetCellsFormatting()
		{
			((ISubClassBase)CellsFormatting).ResetToDefault();
		}

		private bool ShouldSerializeGridOutline()
		{
			return ((ISubClassBase)GridOutline).ShouldSerialize();
		}

		private void ResetGridOutline()
		{
			((ISubClassBase)GridOutline).ResetToDefault();
		}

		private bool ShouldSerializeColTitlesVisible()
		{
			return base.PropertyShouldSerialize("ColTitlesVisible");
		}

		private void ResetColTitlesVisible()
		{
			base.PropertyReset("ColTitlesVisible");
		}

		private bool ShouldSerializeRowTitlesVisible()
		{
			return base.PropertyShouldSerialize("RowTitlesVisible");
		}

		private void ResetRowTitlesVisible()
		{
			base.PropertyReset("RowTitlesVisible");
		}

		private bool ShouldSerializeColWidthStyle()
		{
			return base.PropertyShouldSerialize("ColWidthStyle");
		}

		private void ResetColWidthStyle()
		{
			base.PropertyReset("ColWidthStyle");
		}

		private bool ShouldSerializeColWidthValue()
		{
			return base.PropertyShouldSerialize("ColWidthValue");
		}

		private void ResetColWidthValue()
		{
			base.PropertyReset("ColWidthValue");
		}

		private bool ShouldSerializeColOuterMargin()
		{
			return base.PropertyShouldSerialize("ColOuterMargin");
		}

		private void ResetColOuterMargin()
		{
			base.PropertyReset("ColOuterMargin");
		}

		private bool ShouldSerializeRowHeightStyle()
		{
			return base.PropertyShouldSerialize("RowHeightStyle");
		}

		private void ResetRowHeightStyle()
		{
			base.PropertyReset("RowHeightStyle");
		}

		private bool ShouldSerializeRowHeightValue()
		{
			return base.PropertyShouldSerialize("RowHeightValue");
		}

		private void ResetRowHeightValue()
		{
			base.PropertyReset("RowHeightValue");
		}

		private bool ShouldSerializeRowOuterMargin()
		{
			return base.PropertyShouldSerialize("RowOuterMargin");
		}

		private void ResetRowOuterMargin()
		{
			base.PropertyReset("RowOuterMargin");
		}

		private void RegenerateArray()
		{
			Array cells = m_Cells;
			m_Cells = Array.CreateInstance(typeof(PlotTableCell), ActualColCount, ActualRowCount);
			m_ColWidths = new ArrayList();
			for (int i = 0; i < ActualColCount; i++)
			{
				m_ColWidths.Add(0);
			}
			m_RowHeights = new ArrayList();
			for (int j = 0; j < ActualRowCount; j++)
			{
				m_RowHeights.Add(0);
			}
			for (int k = 0; k < ActualRowCount; k++)
			{
				for (int l = 0; l < ActualColCount; l++)
				{
					bool flag = true;
					if (cells == null)
					{
						flag = false;
					}
					if (cells != null && l > cells.GetUpperBound(0))
					{
						flag = false;
					}
					if (cells != null && k > cells.GetUpperBound(1))
					{
						flag = false;
					}
					object obj = (!flag) ? ((l != 0) ? ((k != 0) ? new PlotTableCell(this, CellsFormatting.Data) : new PlotTableCell(this, CellsFormatting.ColTitles)) : new PlotTableCell(this, CellsFormatting.RowTitles)) : cells.GetValue(l, k);
					m_Cells.SetValue(obj, l, k);
					if (k == 0)
					{
						(obj as PlotTableCell).Text = "C" + l.ToString();
					}
					else if (l == 0)
					{
						(obj as PlotTableCell).Text = "R" + k.ToString();
					}
					else
					{
						(obj as PlotTableCell).Text = "0";
					}
				}
			}
		}

		[Browsable(false)]
		public void DoCellChange()
		{
			if (!IgnoreCellChanges && base.Plot != null)
			{
				base.Plot.CodeInvalidate(this);
			}
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (shouldFocus)
			{
				base.Focus();
			}
		}

		private Size GetMaxTextSize(PaintArgs p, string[] strings, ITextLayoutFull textLayout, Font font)
		{
			Size size = Size.Empty;
			for (int i = 0; i < strings.Length; i++)
			{
				size = Math2.Max(size, textLayout.GetRequiredSize(strings[i], font, p.Graphics));
			}
			return size;
		}

		protected override void CalculateDepthPixels(PaintArgs p)
		{
			m_MarginOuterPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(base.Font).Height * base.MarginOuter);
			Size size = p.Graphics.MeasureString(CellsFormatting.Data.Font);
			Size size2 = p.Graphics.MeasureString(CellsFormatting.ColTitles.Font);
			Size size3 = p.Graphics.MeasureString(CellsFormatting.RowTitles.Font);
			if (!ColTitlesVisible)
			{
				size2 = new Size(0, 0);
			}
			if (!RowTitlesVisible)
			{
				size3 = new Size(0, 0);
			}
			Size size4 = size;
			size4 = Math2.Max(size4, size2);
			size4 = Math2.Max(size4, size3);
			m_CellOuterMargin = new Size((int)((double)size4.Width * ColOuterMargin), (int)((double)size4.Height * RowOuterMargin));
			int fixedWidth = (ColWidthStyle != SizeStyle.FixedPixels) ? ((ColWidthStyle != SizeStyle.FixedCharacters) ? (-1) : ((int)((double)size4.Width * ColWidthValue))) : ((int)ColWidthValue);
			int fixedHeight = (RowHeightStyle != SizeStyle.FixedPixels) ? ((RowHeightStyle != SizeStyle.FixedCharacters) ? (-1) : ((int)((double)size4.Height * RowHeightValue))) : ((int)RowHeightValue);
			for (int i = 0; i < ActualColCount; i++)
			{
				for (int j = 0; j < ActualRowCount; j++)
				{
					PlotTableCell plotTableCell = this[i, j];
					if (i == 0 && j == 0)
					{
						((IPlotTableCell)plotTableCell).UpdateRequiredSize(p, false, m_CellOuterMargin, fixedWidth, fixedHeight);
					}
					else if (j == 0)
					{
						((IPlotTableCell)plotTableCell).UpdateRequiredSize(p, ColTitlesVisible, m_CellOuterMargin, fixedWidth, fixedHeight);
					}
					else if (i == 0)
					{
						((IPlotTableCell)plotTableCell).UpdateRequiredSize(p, RowTitlesVisible, m_CellOuterMargin, fixedWidth, fixedHeight);
					}
					else
					{
						((IPlotTableCell)plotTableCell).UpdateRequiredSize(p, true, m_CellOuterMargin, fixedWidth, fixedHeight);
					}
				}
			}
			for (int k = 0; k < ActualColCount; k++)
			{
				m_ColWidths[k] = 0;
			}
			for (int l = 0; l < ActualRowCount; l++)
			{
				m_RowHeights[l] = 0;
			}
			for (int m = 0; m < ActualColCount; m++)
			{
				for (int n = 0; n < ActualRowCount; n++)
				{
					PlotTableCell plotTableCell = this[m, n];
					if (plotTableCell.RequiredSize.Width > (int)m_ColWidths[m])
					{
						m_ColWidths[m] = plotTableCell.RequiredSize.Width;
					}
					if (plotTableCell.RequiredSize.Height > (int)m_RowHeights[n])
					{
						m_RowHeights[n] = plotTableCell.RequiredSize.Height;
					}
				}
			}
			int num = 2 * m_MarginOuterPixels;
			int num2 = 2 * m_MarginOuterPixels;
			for (int num3 = 0; num3 < ActualColCount; num3++)
			{
				num += (int)m_ColWidths[num3];
			}
			for (int num4 = 0; num4 < ActualRowCount; num4++)
			{
				num2 += (int)m_RowHeights[num4];
			}
			Size size5 = new Size(num, num2);
			if (base.DockHorizontal)
			{
				base.DockDepthPixels = size5.Width;
				m_LengthPixels = size5.Height;
			}
			else
			{
				base.DockDepthPixels = size5.Height;
				m_LengthPixels = size5.Width;
			}
		}

		protected override void DrawCalculations(PaintArgs p)
		{
			base.CalculateBoundsAlignment(m_LengthPixels);
		}

		protected override void Draw(PaintArgs p)
		{
			base.I_Fill.Draw(p, base.BoundsAlignment);
			Rectangle boundsAlignment = base.BoundsAlignment;
			boundsAlignment.Inflate(-MarginOuterPixels, -MarginOuterPixels);
			Rectangle r = boundsAlignment;
			Rectangle r2 = new Rectangle(boundsAlignment.Left, boundsAlignment.Top, boundsAlignment.Width, (int)m_RowHeights[0]);
			Rectangle r3 = new Rectangle(boundsAlignment.Left, boundsAlignment.Top, (int)m_ColWidths[0], boundsAlignment.Height);
			if (RowTitlesVisible)
			{
				r.Offset((int)m_ColWidths[0], 0);
				r2.Offset((int)m_ColWidths[0], 0);
			}
			if (ColTitlesVisible)
			{
				r.Offset(0, (int)m_RowHeights[0]);
				r3.Offset(0, (int)m_RowHeights[0]);
			}
			r.Intersect(boundsAlignment);
			r2.Intersect(boundsAlignment);
			r3.Intersect(boundsAlignment);
			((IPlotTableCellFormat)CellsFormatting.Data).Draw(p, r);
			if (ColTitlesVisible)
			{
				((IPlotTableCellFormat)CellsFormatting.ColTitles).Draw(p, r2);
			}
			if (RowTitlesVisible)
			{
				((IPlotTableCellFormat)CellsFormatting.RowTitles).Draw(p, r3);
			}
			int num = boundsAlignment.Top;
			for (int i = 0; i < ActualRowCount; i++)
			{
				int num2 = (int)m_RowHeights[i];
				int num3 = boundsAlignment.Left;
				for (int j = 0; j < ActualColCount; j++)
				{
					PlotTableCell plotTableCell = this[j, i];
					int num4 = (int)m_ColWidths[j];
					plotTableCell.Bounds = new Rectangle(num3, num, num4, num2);
					((IPlotTableCell)plotTableCell).Draw(p, GridOutline.Visible, ((IPlotPen)GridOutline).GetPen(p));
					num3 += num4;
				}
				num += num2;
			}
		}

		protected override void DrawFocusRectangles(PaintArgs p)
		{
			if (base.Focused)
			{
				Rectangle boundsAlignment = base.BoundsAlignment;
				boundsAlignment.Inflate(2, 2);
				p.Graphics.DrawFocusRectangle(boundsAlignment, base.BackColor);
			}
		}
	}
}
