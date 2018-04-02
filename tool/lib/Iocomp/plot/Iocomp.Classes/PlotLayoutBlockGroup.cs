using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Base Class for all Plot Layout objects.")]
	public class PlotLayoutBlockGroup : PlotLayoutBlockBase
	{
		private PlotLayoutBlockItemCollection m_ListLeft;

		private PlotLayoutBlockItemCollection m_ListRight;

		private PlotLayoutBlockItemCollection m_ListTop;

		private PlotLayoutBlockItemCollection m_ListBottom;

		public PlotLayoutDataView DataView;

		public Rectangle InnerRectangleScreen;

		public Rectangle InnerRectangleLayout;

		public int DepthLeftScreen;

		public int DepthLeftLayout;

		public int DepthRightScreen;

		public int DepthRightLayout;

		public int DepthTopScreen;

		public int DepthTopLayout;

		public int DepthBottomScreen;

		public int DepthBottomLayout;

		public int DepthWidthScreen;

		public int DepthWidthLayout;

		public int DepthHeightScreen;

		public int DepthHeightLayout;

		public int OverlapLeftStart;

		public int OverlapLeftStop;

		public int OverlapRightStart;

		public int OverlapRightStop;

		public int OverlapTopStart;

		public int OverlapTopStop;

		public int OverlapBottomStart;

		public int OverlapBottomStop;

		public int DataViewHeightScreen;

		public int DataViewHeightLayout;

		public PlotLayoutBlockItemCollection ListLeft => m_ListLeft;

		public PlotLayoutBlockItemCollection ListRight => m_ListRight;

		public PlotLayoutBlockItemCollection ListTop => m_ListTop;

		public PlotLayoutBlockItemCollection ListBottom => m_ListBottom;

		public PlotLayoutBlockGroup()
		{
			m_ListLeft = new PlotLayoutBlockItemCollection();
			m_ListRight = new PlotLayoutBlockItemCollection();
			m_ListTop = new PlotLayoutBlockItemCollection();
			m_ListBottom = new PlotLayoutBlockItemCollection();
		}

		public void Add(PlotLayoutBlockItem value)
		{
			PlotLayoutDockableDataView plotLayoutDockableDataView = value.Object as PlotLayoutDockableDataView;
			if (plotLayoutDockableDataView != null)
			{
				if (plotLayoutDockableDataView.DockLeft)
				{
					ListLeft.Add(value);
					value.List = ListLeft;
				}
				else if (plotLayoutDockableDataView.DockRight)
				{
					ListRight.Add(value);
					value.List = ListRight;
				}
				else if (plotLayoutDockableDataView.DockTop)
				{
					ListTop.Add(value);
					value.List = ListTop;
				}
				else if (plotLayoutDockableDataView.DockBottom)
				{
					ListBottom.Add(value);
					value.List = ListBottom;
				}
			}
		}

		public void SortDockOrders()
		{
			ListLeft.SortDockOrder();
			ListRight.SortDockOrder();
			ListTop.SortDockOrder();
			ListBottom.SortDockOrder();
		}

		public void Clear()
		{
			ListLeft.Clear();
			ListLeft.UniqueDockOrders.Clear();
			ListRight.Clear();
			ListRight.UniqueDockOrders.Clear();
			ListTop.Clear();
			ListTop.UniqueDockOrders.Clear();
			ListBottom.Clear();
			ListBottom.UniqueDockOrders.Clear();
		}

		public void Calculate(PaintArgs p)
		{
			ListLeft.Calculate(p);
			ListRight.Calculate(p);
			ListTop.Calculate(p);
			ListBottom.Calculate(p);
			DepthLeftScreen = ListLeft.TotalDepthScreen;
			DepthLeftLayout = ListLeft.TotalDepthLayout;
			DepthLeftScreen = Math.Max(DepthLeftScreen, ListTop.MaxOverlapStart);
			DepthLeftScreen = Math.Max(DepthLeftScreen, ListBottom.MaxOverlapStart);
			DepthRightScreen = ListRight.TotalDepthScreen;
			DepthRightLayout = ListRight.TotalDepthLayout;
			DepthRightScreen = Math.Max(DepthRightScreen, ListTop.MaxOverlapStop);
			DepthRightScreen = Math.Max(DepthRightScreen, ListBottom.MaxOverlapStop);
			DepthTopScreen = ListTop.TotalDepthScreen;
			DepthTopLayout = ListTop.TotalDepthLayout;
			DepthTopScreen = Math.Max(DepthTopScreen, ListLeft.MaxOverlapStop);
			DepthTopScreen = Math.Max(DepthTopScreen, ListRight.MaxOverlapStop);
			DepthBottomScreen = ListBottom.TotalDepthScreen;
			DepthBottomLayout = ListBottom.TotalDepthLayout;
			DepthBottomScreen = Math.Max(DepthBottomScreen, ListLeft.MaxOverlapStart);
			DepthBottomScreen = Math.Max(DepthBottomScreen, ListRight.MaxOverlapStart);
			DepthWidthScreen = DepthLeftScreen + DepthRightScreen;
			DepthWidthLayout = DepthLeftLayout + DepthRightLayout;
			DepthHeightScreen = DepthTopScreen + DepthBottomScreen;
			DepthHeightLayout = DepthTopLayout + DepthBottomLayout;
		}

		public void CalculateAndSetAllDockObjectBounds()
		{
			int num = InnerRectangleScreen.Left;
			int num2 = InnerRectangleLayout.Left;
			int height = InnerRectangleScreen.Height;
			int height2 = InnerRectangleLayout.Height;
			int maxDepthScreen;
			int maxDepthLayout;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder in ListLeft.UniqueDockOrders)
			{
				maxDepthScreen = uniqueDockOrder.MaxDepthScreen;
				maxDepthLayout = uniqueDockOrder.MaxDepthLayout;
				int num3 = num - uniqueDockOrder.MaxDockMargin;
				int num4 = num2;
				int left = num3 - maxDepthScreen;
				int left2 = num4 - maxDepthLayout;
				foreach (PlotLayoutBlockItem item in uniqueDockOrder.Items)
				{
					PlotLayoutDockableDataView plotLayoutDockableDataView = item.Object as PlotLayoutDockableDataView;
					if (plotLayoutDockableDataView != null)
					{
						int num5 = (int)((double)InnerRectangleScreen.Bottom - plotLayoutDockableDataView.DockPercentStart * (double)height);
						int bottom = (int)((double)InnerRectangleLayout.Bottom - plotLayoutDockableDataView.DockPercentStart * (double)height2);
						num5 -= plotLayoutDockableDataView.TextOverlapPixelsStart + plotLayoutDockableDataView.StackingPixelsStart;
						int num6 = (int)((double)InnerRectangleScreen.Bottom - plotLayoutDockableDataView.DockPercentStop * (double)height);
						int top = (int)((double)InnerRectangleLayout.Bottom - plotLayoutDockableDataView.DockPercentStop * (double)height2);
						num6 += plotLayoutDockableDataView.TextOverlapPixelsStop + plotLayoutDockableDataView.StackingPixelsStop;
						item.BoundsScreen = iRectangle.FromLTRB(left, num6, num3, num5);
						item.BoundsLayout = iRectangle.FromLTRB(left2, top, num4, bottom);
						PlotAxis plotAxis = item.Object as PlotAxis;
						if (plotAxis != null)
						{
							item.BoundsClip = iRectangle.FromLTRB(left, num6 - plotAxis.ScaleTextOverlapPixels, num3, num5 + plotAxis.ScaleTextOverlapPixels);
						}
						else
						{
							item.BoundsClip = item.BoundsScreen;
						}
					}
				}
				num -= maxDepthScreen + uniqueDockOrder.MaxDockMargin;
				num2 -= maxDepthLayout;
			}
			num = InnerRectangleScreen.Right;
			num2 = InnerRectangleLayout.Right;
			height = InnerRectangleScreen.Height;
			height2 = InnerRectangleLayout.Height;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder2 in ListRight.UniqueDockOrders)
			{
				maxDepthScreen = uniqueDockOrder2.MaxDepthScreen;
				maxDepthLayout = uniqueDockOrder2.MaxDepthLayout;
				int left = num + uniqueDockOrder2.MaxDockMargin;
				int left2 = num2;
				int num3 = left + maxDepthScreen;
				int num4 = left2 + maxDepthLayout;
				foreach (PlotLayoutBlockItem item2 in uniqueDockOrder2.Items)
				{
					PlotLayoutDockableDataView plotLayoutDockableDataView = item2.Object as PlotLayoutDockableDataView;
					if (plotLayoutDockableDataView != null)
					{
						int num5 = (int)((double)InnerRectangleScreen.Bottom - plotLayoutDockableDataView.DockPercentStart * (double)height);
						int bottom = (int)((double)InnerRectangleLayout.Bottom - plotLayoutDockableDataView.DockPercentStart * (double)height2);
						num5 -= plotLayoutDockableDataView.TextOverlapPixelsStart + plotLayoutDockableDataView.StackingPixelsStart;
						int num6 = (int)((double)InnerRectangleScreen.Bottom - plotLayoutDockableDataView.DockPercentStop * (double)height);
						int top = (int)((double)InnerRectangleLayout.Bottom - plotLayoutDockableDataView.DockPercentStop * (double)height2);
						num6 += plotLayoutDockableDataView.TextOverlapPixelsStop + plotLayoutDockableDataView.StackingPixelsStop;
						item2.BoundsScreen = iRectangle.FromLTRB(left, num6, num3, num5);
						item2.BoundsLayout = iRectangle.FromLTRB(left2, top, num4, bottom);
						PlotAxis plotAxis = item2.Object as PlotAxis;
						if (plotAxis != null)
						{
							item2.BoundsClip = iRectangle.FromLTRB(left, num6 - plotAxis.ScaleTextOverlapPixels, num3, num5 + plotAxis.ScaleTextOverlapPixels);
						}
						else
						{
							item2.BoundsClip = item2.BoundsScreen;
						}
					}
				}
				num += maxDepthScreen + uniqueDockOrder2.MaxDockMargin;
				num2 += maxDepthLayout;
			}
			num = InnerRectangleScreen.Top;
			num2 = InnerRectangleLayout.Top;
			maxDepthScreen = InnerRectangleScreen.Width;
			maxDepthLayout = InnerRectangleLayout.Width;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder3 in ListTop.UniqueDockOrders)
			{
				height = uniqueDockOrder3.MaxDepthScreen;
				height2 = uniqueDockOrder3.MaxDepthLayout;
				int num5 = num - uniqueDockOrder3.MaxDockMargin;
				int bottom = num2;
				int num6 = num5 - height;
				int top = bottom - height2;
				foreach (PlotLayoutBlockItem item3 in uniqueDockOrder3.Items)
				{
					PlotLayoutDockableDataView plotLayoutDockableDataView = item3.Object as PlotLayoutDockableDataView;
					if (plotLayoutDockableDataView != null)
					{
						int left = (int)((double)InnerRectangleScreen.Left + plotLayoutDockableDataView.DockPercentStart * (double)maxDepthScreen);
						int left2 = (int)((double)InnerRectangleLayout.Left + plotLayoutDockableDataView.DockPercentStart * (double)maxDepthLayout);
						left += plotLayoutDockableDataView.TextOverlapPixelsStart + plotLayoutDockableDataView.StackingPixelsStart;
						int num3 = (int)((double)InnerRectangleScreen.Left + plotLayoutDockableDataView.DockPercentStop * (double)maxDepthScreen);
						int num4 = (int)((double)InnerRectangleLayout.Left + plotLayoutDockableDataView.DockPercentStop * (double)maxDepthLayout);
						num3 -= plotLayoutDockableDataView.TextOverlapPixelsStop + plotLayoutDockableDataView.StackingPixelsStop;
						item3.BoundsScreen = iRectangle.FromLTRB(left, num6, num3, num5);
						item3.BoundsLayout = iRectangle.FromLTRB(left2, top, num4, bottom);
						PlotAxis plotAxis = item3.Object as PlotAxis;
						if (plotAxis != null)
						{
							item3.BoundsClip = iRectangle.FromLTRB(left - plotAxis.ScaleTextOverlapPixels, num6, num3 + plotAxis.ScaleTextOverlapPixels, num5);
						}
						else
						{
							item3.BoundsClip = item3.BoundsScreen;
						}
					}
				}
				num -= height + uniqueDockOrder3.MaxDockMargin;
				num2 -= height2;
			}
			num = InnerRectangleScreen.Bottom;
			num2 = InnerRectangleLayout.Bottom;
			maxDepthScreen = InnerRectangleScreen.Width;
			maxDepthLayout = InnerRectangleLayout.Width;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder4 in ListBottom.UniqueDockOrders)
			{
				height = uniqueDockOrder4.MaxDepthScreen;
				height2 = uniqueDockOrder4.MaxDepthLayout;
				int num6 = num + uniqueDockOrder4.MaxDockMargin;
				int top = num2;
				int num5 = num6 + height;
				int bottom = top + height2;
				foreach (PlotLayoutBlockItem item4 in uniqueDockOrder4.Items)
				{
					PlotLayoutDockableDataView plotLayoutDockableDataView = item4.Object as PlotLayoutDockableDataView;
					if (plotLayoutDockableDataView != null)
					{
						int left = (int)((double)InnerRectangleScreen.Left + plotLayoutDockableDataView.DockPercentStart * (double)maxDepthScreen);
						int left2 = (int)((double)InnerRectangleLayout.Left + plotLayoutDockableDataView.DockPercentStart * (double)maxDepthLayout);
						left += plotLayoutDockableDataView.TextOverlapPixelsStart + plotLayoutDockableDataView.StackingPixelsStart;
						int num3 = (int)((double)InnerRectangleScreen.Left + plotLayoutDockableDataView.DockPercentStop * (double)maxDepthScreen);
						int num4 = (int)((double)InnerRectangleLayout.Left + plotLayoutDockableDataView.DockPercentStop * (double)maxDepthLayout);
						num3 -= plotLayoutDockableDataView.TextOverlapPixelsStop + plotLayoutDockableDataView.StackingPixelsStop;
						item4.BoundsScreen = iRectangle.FromLTRB(left, num6, num3, num5);
						item4.BoundsLayout = iRectangle.FromLTRB(left2, top, num4, bottom);
						PlotAxis plotAxis = item4.Object as PlotAxis;
						if (plotAxis != null)
						{
							item4.BoundsClip = iRectangle.FromLTRB(left - plotAxis.ScaleTextOverlapPixels, num6, num3 + plotAxis.ScaleTextOverlapPixels, num5);
						}
						else
						{
							item4.BoundsClip = item4.BoundsScreen;
						}
					}
				}
				num += height + uniqueDockOrder4.MaxDockMargin;
				num2 += height2;
			}
			int val = 2147483647;
			int val2 = -2147483648;
			int val3 = 2147483647;
			int val4 = -2147483648;
			if (base.Object != null)
			{
				val = Math.Min(val, ListLeft.GetMinBoundsScreenTop());
				val = Math.Min(val, ListRight.GetMinBoundsScreenTop());
				val2 = Math.Max(val2, ListLeft.GetMaxBoundsScreenBottom());
				val2 = Math.Max(val2, ListRight.GetMaxBoundsScreenBottom());
				val3 = Math.Min(val3, ListTop.GetMinBoundsScreenLeft());
				val3 = Math.Min(val3, ListBottom.GetMinBoundsScreenLeft());
				val4 = Math.Max(val4, ListTop.GetMaxBoundsScreenRight());
				val4 = Math.Max(val4, ListBottom.GetMaxBoundsScreenRight());
				if (val == 2147483647)
				{
					val = InnerRectangleScreen.Top;
				}
				if (val2 == -2147483648)
				{
					val2 = InnerRectangleScreen.Bottom;
				}
				if (val3 == 2147483647)
				{
					val3 = InnerRectangleScreen.Left;
				}
				if (val4 == -2147483648)
				{
					val4 = InnerRectangleScreen.Right;
				}
				InnerRectangleScreen = Rectangle.FromLTRB(val3, val, val4, val2);
			}
		}

		public void TransferBoundsToLayoutObjects()
		{
			PlotLayoutDataView plotLayoutDataView = base.Object as PlotLayoutDataView;
			plotLayoutDataView.Bounds = base.BoundsScreen;
			plotLayoutDataView.BoundsClip = InnerRectangleScreen;
		}
	}
}
