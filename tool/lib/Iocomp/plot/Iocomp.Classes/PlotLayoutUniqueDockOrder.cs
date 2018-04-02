using System;

namespace Iocomp.Classes
{
	public class PlotLayoutUniqueDockOrder
	{
		private PlotLayoutBlockItemCollection m_Items;

		public int DockOrder;

		public int MaxDepthScreen;

		public int MaxDepthLayout;

		public int MaxDockMargin;

		public int OverlapStart;

		public int OverlapStop;

		public int TotalStackingPixels;

		public PlotLayoutBlockItemCollection Items => m_Items;

		public PlotLayoutUniqueDockOrder()
		{
			m_Items = new PlotLayoutBlockItemCollection();
		}

		public void CalcualteDimensions(PaintArgs p)
		{
			TotalStackingPixels = 0;
			MaxDepthScreen = 0;
			MaxDepthLayout = 0;
			MaxDockMargin = -10000;
			OverlapStart = 0;
			PlotLayoutBase plotLayoutBase = null;
			PlotLayoutBase plotLayoutBase2 = null;
			for (int i = 0; i < Items.Count; i++)
			{
				PlotLayoutBase @object = Items[i].Object;
				MaxDepthLayout = Math.Max(MaxDepthLayout, 21);
				@object.TextOverlapPixelsStart = 0;
				@object.TextOverlapPixelsStop = 0;
				@object.StackingPixelsStart = 0;
				@object.StackingPixelsStop = 0;
				if (@object.Visible)
				{
					MaxDepthScreen = Math.Max(MaxDepthScreen, @object.DockDepthPixels);
					MaxDockMargin = Math.Max(MaxDockMargin, @object.DockMargin);
					if (plotLayoutBase == null)
					{
						plotLayoutBase = @object;
					}
					plotLayoutBase2 = @object;
				}
			}
			if (MaxDockMargin == -10000)
			{
				MaxDockMargin = 0;
			}
			foreach (PlotLayoutBlockItem item in Items)
			{
				PlotAxis plotAxis = item.Object as PlotAxis;
				if (plotAxis != null)
				{
					bool flag = plotLayoutBase != plotLayoutBase2;
					if (plotAxis.DockForceStacking)
					{
						flag = true;
					}
					if (flag)
					{
						int num;
						if (plotAxis.DockVertical)
						{
							num = (int)Math.Round((double)p.Graphics.MeasureString("0", plotAxis.ScaleDisplay.TickMajor.Font).Height * plotAxis.DockStackingEndsMargin);
						}
						num = (int)Math.Round((double)p.Graphics.MeasureString("0", plotAxis.ScaleDisplay.TickMajor.Font).Width * plotAxis.DockStackingEndsMargin);
						if (plotAxis == plotLayoutBase && !plotAxis.DockForceStacking)
						{
							plotAxis.TextOverlapPixelsStop = plotAxis.ScaleDisplay.TextOverlapPixels;
							plotAxis.StackingPixelsStop = num;
							TotalStackingPixels += plotAxis.ScaleDisplay.TextOverlapPixels + num;
						}
						else if (plotAxis == plotLayoutBase2 && !plotAxis.DockForceStacking)
						{
							plotAxis.TextOverlapPixelsStart = plotAxis.ScaleDisplay.TextOverlapPixels;
							plotAxis.StackingPixelsStart = num;
							TotalStackingPixels += plotAxis.ScaleDisplay.TextOverlapPixels + num;
						}
						else
						{
							plotAxis.TextOverlapPixelsStart = plotAxis.ScaleDisplay.TextOverlapPixels;
							plotAxis.TextOverlapPixelsStop = plotAxis.ScaleDisplay.TextOverlapPixels;
							plotAxis.StackingPixelsStart = num;
							plotAxis.StackingPixelsStop = num;
							TotalStackingPixels += 2 * plotAxis.ScaleDisplay.TextOverlapPixels + 2 * num;
						}
					}
				}
			}
			if (plotLayoutBase != null)
			{
				PlotAxis plotAxis = plotLayoutBase as PlotAxis;
				if (plotAxis != null)
				{
					OverlapStart = plotAxis.ScaleDisplay.TextOverlapPixels;
				}
			}
			if (plotLayoutBase2 != null)
			{
				PlotAxis plotAxis = plotLayoutBase2 as PlotAxis;
				if (plotAxis != null)
				{
					OverlapStop = plotAxis.ScaleDisplay.TextOverlapPixels;
				}
			}
		}

		public int GetMinBoundsScreenTop()
		{
			int num = 2147483647;
			foreach (PlotLayoutBlockItem item in Items)
			{
				num = Math.Min(num, item.BoundsScreen.Top);
			}
			return num;
		}

		public int GetMaxBoundsScreenBottom()
		{
			int num = -2147483648;
			foreach (PlotLayoutBlockItem item in Items)
			{
				num = Math.Max(num, item.BoundsScreen.Bottom);
			}
			return num;
		}

		public int GetMinBoundsScreenLeft()
		{
			int num = 2147483647;
			foreach (PlotLayoutBlockItem item in Items)
			{
				num = Math.Min(num, item.BoundsScreen.Left);
			}
			return num;
		}

		public int GetMaxBoundsScreenRight()
		{
			int num = -2147483648;
			foreach (PlotLayoutBlockItem item in Items)
			{
				num = Math.Max(num, item.BoundsScreen.Right);
			}
			return num;
		}
	}
}
