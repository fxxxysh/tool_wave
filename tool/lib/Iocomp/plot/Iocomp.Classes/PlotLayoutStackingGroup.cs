using Iocomp.Interfaces;
using System;
using System.Drawing;

namespace Iocomp.Classes
{
	public class PlotLayoutStackingGroup : IDrawLayoutControl
	{
		private static Color[] m_ColorTable;

		public static int DockMarginScreen;

		private int m_Index;

		private PlotLayoutBlockGroupCollection m_Items;

		public int DataViewVisibleCount;

		public Rectangle BoundsScreen;

		public Rectangle BoundsLayout;

		public int OuterMarginScreen;

		public int OuterMarginLayout;

		public double TotalDockDepthRatioScreen;

		public double TotalDockDepthRatioLayout;

		public int DataViewWidthScreen;

		public int DataViewWidthLayout;

		public int MaxDepthLeftScreen;

		public int MaxDepthLeftLayout;

		public int MaxDepthRightScreen;

		public int MaxDepthRightLayout;

		public int MaxDepthTopScreen;

		public int MaxDepthTopLayout;

		public int MaxDepthBottomScreen;

		public int MaxDepthBottomLayout;

		public int TotalDepthHeightScreen;

		public int TotalDepthHeightLayout;

		public int TotalInnerDepthHeightScreen;

		public int TotalInnerDepthHeightLayout;

		public int DataViewReferenceLeftScreen;

		public int DataViewReferenceLeftLayout;

		public int DataViewReferenceRightScreen;

		public int DataViewReferenceRightLayout;

		public int DataViewReferenceTopScreen;

		public int DataViewReferenceTopLayout;

		public int DataViewReferenceBottomScreen;

		public int DataViewReferenceBottomLayout;

		public int Index
		{
			get
			{
				return m_Index;
			}
			set
			{
				m_Index = value;
			}
		}

		public PlotLayoutBlockGroupCollection Items => m_Items;

		public int MaxDepthWidthScreen => MaxDepthLeftScreen + MaxDepthRightScreen;

		public int MaxDepthWidthLayout => MaxDepthLeftLayout + MaxDepthRightLayout;

		static PlotLayoutStackingGroup()
		{
			m_ColorTable = new Color[2];
			m_ColorTable[0] = Color.CornflowerBlue;
			m_ColorTable[1] = Color.DarkSeaGreen;
			DockMarginScreen = 10;
		}

		public PlotLayoutStackingGroup()
		{
			m_Items = new PlotLayoutBlockGroupCollection();
			OuterMarginScreen = 0;
			OuterMarginLayout = 5;
		}

		public void SortDataViewsDockOrder()
		{
			Items.SortDataViewsDockOrder();
		}

		public void Add(PlotLayoutBlockGroup value)
		{
			if (value.Object is PlotLayoutDataView)
			{
				PlotLayoutDataView plotLayoutDataView = value.Object as PlotLayoutDataView;
				Items.Add(value);
				plotLayoutDataView.StackingGroup = this;
			}
		}

		public void Calculate()
		{
			MaxDepthLeftScreen = 0;
			MaxDepthLeftLayout = 0;
			MaxDepthRightScreen = 0;
			MaxDepthRightLayout = 0;
			MaxDepthTopScreen = 0;
			MaxDepthTopLayout = 0;
			MaxDepthBottomScreen = 0;
			MaxDepthBottomLayout = 0;
			TotalDepthHeightScreen = 0;
			TotalDepthHeightLayout = 0;
			TotalInnerDepthHeightScreen = 0;
			TotalInnerDepthHeightLayout = 0;
			TotalDockDepthRatioScreen = 0.0;
			TotalDockDepthRatioLayout = 0.0;
			PlotLayoutBlockGroup plotLayoutBlockGroup = null;
			PlotLayoutBlockGroup plotLayoutBlockGroup2 = null;
			DataViewVisibleCount = 0;
			for (int i = 0; i < Items.Count; i++)
			{
				PlotLayoutBlockGroup plotLayoutBlockGroup3 = Items[i];
				PlotLayoutDataView plotLayoutDataView = plotLayoutBlockGroup3.Object as PlotLayoutDataView;
				if (plotLayoutDataView != null)
				{
					TotalDockDepthRatioLayout += plotLayoutDataView.DockDepthRatio;
					MaxDepthLeftLayout = Math.Max(MaxDepthLeftLayout, plotLayoutBlockGroup3.DepthLeftLayout);
					MaxDepthRightLayout = Math.Max(MaxDepthRightLayout, plotLayoutBlockGroup3.DepthRightLayout);
					TotalDepthHeightLayout += plotLayoutBlockGroup3.DepthHeightLayout;
					if (plotLayoutDataView.Visible)
					{
						TotalDockDepthRatioScreen += plotLayoutDataView.DockDepthRatio;
						if (plotLayoutBlockGroup == null)
						{
							plotLayoutBlockGroup = plotLayoutBlockGroup3;
						}
						plotLayoutBlockGroup2 = plotLayoutBlockGroup3;
						MaxDepthLeftScreen = Math.Max(MaxDepthLeftScreen, plotLayoutBlockGroup3.DepthLeftScreen);
						MaxDepthRightScreen = Math.Max(MaxDepthRightScreen, plotLayoutBlockGroup3.DepthRightScreen);
						TotalDepthHeightScreen += plotLayoutBlockGroup3.DepthHeightScreen;
						DataViewVisibleCount++;
					}
				}
			}
			if (plotLayoutBlockGroup != null)
			{
				MaxDepthBottomScreen = plotLayoutBlockGroup.DepthBottomScreen;
			}
			if (plotLayoutBlockGroup2 != null)
			{
				MaxDepthTopScreen = plotLayoutBlockGroup2.DepthTopScreen;
			}
			if (Items.Count != 0)
			{
				MaxDepthBottomLayout = Items[0].DepthBottomLayout;
				MaxDepthTopLayout = Items[Items.Count - 1].DepthTopLayout;
			}
			if (DataViewVisibleCount >= 2)
			{
				for (int j = 0; j < Items.Count; j++)
				{
					PlotLayoutBlockGroup plotLayoutBlockGroup3 = Items[j];
					PlotLayoutDataView plotLayoutDataView = plotLayoutBlockGroup3.Object as PlotLayoutDataView;
					if (plotLayoutDataView.Visible)
					{
						if (plotLayoutBlockGroup3 == plotLayoutBlockGroup)
						{
							TotalInnerDepthHeightScreen += plotLayoutBlockGroup3.DepthTopScreen;
						}
						else if (plotLayoutBlockGroup3 == plotLayoutBlockGroup2)
						{
							TotalInnerDepthHeightScreen += plotLayoutBlockGroup3.DepthBottomScreen;
						}
						else
						{
							TotalInnerDepthHeightScreen += plotLayoutBlockGroup3.DepthHeightScreen;
						}
					}
				}
			}
			if (Items.Count >= 2)
			{
				for (int k = 0; k < Items.Count; k++)
				{
					PlotLayoutBlockGroup plotLayoutBlockGroup3 = Items[k];
					PlotLayoutDataView plotLayoutDataView = plotLayoutBlockGroup3.Object as PlotLayoutDataView;
					if (k == 0)
					{
						TotalInnerDepthHeightLayout += plotLayoutBlockGroup3.DepthTopLayout;
					}
					else if (k == Items.Count - 1)
					{
						TotalInnerDepthHeightLayout += plotLayoutBlockGroup3.DepthBottomLayout;
					}
					else
					{
						TotalInnerDepthHeightLayout += plotLayoutBlockGroup3.DepthHeightLayout;
					}
				}
			}
		}

		public void PerformDataViewHeightCalculations()
		{
			int num = DataViewReferenceBottomScreen - DataViewReferenceTopScreen - TotalInnerDepthHeightScreen;
			int num2 = DataViewReferenceBottomLayout - DataViewReferenceTopLayout - TotalInnerDepthHeightLayout;
			foreach (PlotLayoutBlockGroup item in Items)
			{
				PlotLayoutDataView plotLayoutDataView = item.Object as PlotLayoutDataView;
				if (plotLayoutDataView != null)
				{
					double num3 = (TotalDockDepthRatioScreen == 0.0) ? ((DataViewVisibleCount == 0) ? 0.0 : (1.0 / (double)DataViewVisibleCount)) : (plotLayoutDataView.DockDepthRatio / TotalDockDepthRatioScreen);
					double num4 = (TotalDockDepthRatioLayout == 0.0) ? (1.0 / (double)Items.Count) : (plotLayoutDataView.DockDepthRatio / TotalDockDepthRatioLayout);
					if (plotLayoutDataView.Visible)
					{
						item.DataViewHeightScreen = (int)((double)num * num3);
					}
					item.DataViewHeightLayout = (int)((double)num2 * num4);
				}
			}
		}

		public void PerformDataViewBoundsCalculations()
		{
			int num = DataViewReferenceBottomScreen;
			int num2 = DataViewReferenceBottomLayout;
			for (int i = 0; i < Items.Count; i++)
			{
				PlotLayoutBlockGroup plotLayoutBlockGroup = Items[i];
				PlotLayoutDataView plotLayoutDataView = plotLayoutBlockGroup.Object as PlotLayoutDataView;
				if (plotLayoutDataView != null)
				{
					if (num2 != DataViewReferenceBottomLayout)
					{
						num2 -= plotLayoutBlockGroup.DepthBottomLayout;
					}
					int num3 = num2 - plotLayoutBlockGroup.DataViewHeightLayout;
					plotLayoutBlockGroup.InnerRectangleLayout = Rectangle.FromLTRB(DataViewReferenceLeftLayout, num3, DataViewReferenceRightLayout, num2);
					plotLayoutBlockGroup.BoundsLayout = Rectangle.FromLTRB(DataViewReferenceLeftLayout - plotLayoutBlockGroup.DepthLeftLayout, num3 - plotLayoutBlockGroup.DepthTopLayout, DataViewReferenceRightLayout + plotLayoutBlockGroup.DepthRightLayout, num2 + plotLayoutBlockGroup.DepthBottomLayout);
					num2 = num3 - plotLayoutBlockGroup.DepthTopLayout;
					if (plotLayoutDataView.Visible)
					{
						if (num != DataViewReferenceBottomScreen)
						{
							num -= plotLayoutBlockGroup.DepthBottomScreen;
						}
						int num4 = num - plotLayoutBlockGroup.DataViewHeightScreen;
						plotLayoutBlockGroup.InnerRectangleScreen = Rectangle.FromLTRB(DataViewReferenceLeftScreen, num4, DataViewReferenceRightScreen, num);
						plotLayoutBlockGroup.BoundsScreen = Rectangle.FromLTRB(DataViewReferenceLeftScreen - plotLayoutBlockGroup.DepthLeftScreen, num4 - plotLayoutBlockGroup.DepthTopScreen, DataViewReferenceRightScreen + plotLayoutBlockGroup.DepthRightScreen, num + plotLayoutBlockGroup.DepthBottomScreen);
						num = num4 - plotLayoutBlockGroup.DepthTopScreen;
					}
				}
			}
		}

		public void Draw(PaintArgs p, Font font, Color foreColor, Color backColor)
		{
			Rectangle boundsLayout = BoundsLayout;
			Color color = m_ColorTable[Math.Abs(Index % 2)];
			p.Graphics.FillRectangle(p.Graphics.Brush(color), boundsLayout);
		}
	}
}
