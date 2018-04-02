using System;
using System.Collections;
using System.Drawing;

namespace Iocomp.Classes
{
	public class PlotLayoutStackingGroupCollection : IEnumerable
	{
		private ArrayList m_List;

		public int MaxDepthTopScreen;

		public int MaxDepthTopLayout;

		public int MaxDepthBottomScreen;

		public int MaxDepthBottomLayout;

		public Rectangle BoundsScreen;

		public Rectangle BoundsLayout;

		public int Count => m_List.Count;

		public PlotLayoutStackingGroup this[int index]
		{
			get
			{
				return m_List[index] as PlotLayoutStackingGroup;
			}
			set
			{
				m_List[index] = value;
			}
		}

		public PlotLayoutStackingGroupCollection()
		{
			m_List = new ArrayList();
		}

		public IEnumerator GetEnumerator()
		{
			return m_List.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public PlotLayoutStackingGroup GetStackingGroup(PlotLayoutDataView dataView)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PlotLayoutStackingGroup plotLayoutStackingGroup = (PlotLayoutStackingGroup)enumerator.Current;
					if (plotLayoutStackingGroup.Index == dataView.StackingGroupIndex)
					{
						return plotLayoutStackingGroup;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return null;
		}

		public int Add(PlotLayoutStackingGroup value)
		{
			return m_List.Add(value);
		}

		public void Clear()
		{
			m_List.Clear();
		}

		private void Sort(IComparer comparer)
		{
			m_List.Sort(comparer);
		}

		public void SortStackingIndex()
		{
			m_List.Sort(PlotLayoutManager.StackingGroupSorter);
		}

		public void SortDataViewsDockOrder()
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PlotLayoutStackingGroup plotLayoutStackingGroup = (PlotLayoutStackingGroup)enumerator.Current;
					plotLayoutStackingGroup.SortDataViewsDockOrder();
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		public int IndexOf(PlotLayoutStackingGroup value)
		{
			return m_List.IndexOf(value);
		}

		public virtual void Calculate()
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PlotLayoutStackingGroup plotLayoutStackingGroup = (PlotLayoutStackingGroup)enumerator.Current;
					plotLayoutStackingGroup.Calculate();
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		public virtual void SetDataViewWidthsAndReferences()
		{
			MaxDepthTopScreen = 0;
			MaxDepthTopLayout = 0;
			MaxDepthBottomScreen = 0;
			MaxDepthBottomLayout = 0;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			if (Count != 0)
			{
				int num6 = 0;
				for (int i = 0; i < Count; i++)
				{
					PlotLayoutStackingGroup plotLayoutStackingGroup = this[i];
					num2 += plotLayoutStackingGroup.MaxDepthWidthLayout;
					MaxDepthTopLayout = Math.Max(MaxDepthTopLayout, plotLayoutStackingGroup.MaxDepthTopLayout);
					MaxDepthBottomLayout = Math.Max(MaxDepthBottomLayout, plotLayoutStackingGroup.MaxDepthBottomLayout);
					num4 += plotLayoutStackingGroup.OuterMarginLayout * 2;
					if (plotLayoutStackingGroup.DataViewVisibleCount != 0)
					{
						num += plotLayoutStackingGroup.MaxDepthWidthScreen;
						MaxDepthTopScreen = Math.Max(MaxDepthTopScreen, plotLayoutStackingGroup.MaxDepthTopScreen);
						MaxDepthBottomScreen = Math.Max(MaxDepthBottomScreen, plotLayoutStackingGroup.MaxDepthBottomScreen);
						num3 += plotLayoutStackingGroup.OuterMarginScreen * 2;
						num5++;
					}
				}
				if (num5 != 0)
				{
					num6 = (num5 - 1) * PlotLayoutStackingGroup.DockMarginScreen;
					int num7 = BoundsScreen.Width - num - num3 - num6;
					int num8 = BoundsLayout.Width - num2 - num4;
					int num9 = num7 / num5;
					int num10 = num8 / Count;
					int num11 = num7 - num9 * num5;
					int num12 = num8 - num10 * Count;
					{
						IEnumerator enumerator = GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								PlotLayoutStackingGroup plotLayoutStackingGroup2 = (PlotLayoutStackingGroup)enumerator.Current;
								if (plotLayoutStackingGroup2.DataViewVisibleCount != 0)
								{
									if (num11 > 0)
									{
										plotLayoutStackingGroup2.DataViewWidthScreen = num9 + 1;
										num11--;
									}
									else
									{
										plotLayoutStackingGroup2.DataViewWidthScreen = num9;
									}
								}
								if (num12 > 0)
								{
									plotLayoutStackingGroup2.DataViewWidthLayout = num10 + 1;
									num12--;
								}
								else
								{
									plotLayoutStackingGroup2.DataViewWidthLayout = num10;
								}
							}
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
					{
						IEnumerator enumerator2 = GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								PlotLayoutStackingGroup plotLayoutStackingGroup3 = (PlotLayoutStackingGroup)enumerator2.Current;
								if (plotLayoutStackingGroup3.DataViewVisibleCount != 0)
								{
									plotLayoutStackingGroup3.DataViewReferenceTopScreen = BoundsScreen.Top + MaxDepthTopScreen + plotLayoutStackingGroup3.OuterMarginScreen;
									plotLayoutStackingGroup3.DataViewReferenceBottomScreen = BoundsScreen.Bottom - MaxDepthBottomScreen - plotLayoutStackingGroup3.OuterMarginScreen;
								}
								plotLayoutStackingGroup3.DataViewReferenceTopLayout = BoundsLayout.Top + MaxDepthTopLayout + plotLayoutStackingGroup3.OuterMarginLayout;
								plotLayoutStackingGroup3.DataViewReferenceBottomLayout = BoundsLayout.Bottom - MaxDepthBottomLayout - plotLayoutStackingGroup3.OuterMarginLayout;
							}
						}
						finally
						{
							IDisposable disposable2 = enumerator2 as IDisposable;
							if (disposable2 != null)
							{
								disposable2.Dispose();
							}
						}
					}
				}
			}
		}

		public virtual void CalculateEachStackingGroupBounds()
		{
			int num = BoundsScreen.Left;
			int num2 = BoundsLayout.Left;
			for (int i = 0; i < Count; i++)
			{
				PlotLayoutStackingGroup plotLayoutStackingGroup = this[i];
				int maxDepthLeftScreen = plotLayoutStackingGroup.MaxDepthLeftScreen;
				int maxDepthLeftLayout = plotLayoutStackingGroup.MaxDepthLeftLayout;
				int dataViewWidthScreen = plotLayoutStackingGroup.DataViewWidthScreen;
				int dataViewWidthLayout = plotLayoutStackingGroup.DataViewWidthLayout;
				int maxDepthRightScreen = plotLayoutStackingGroup.MaxDepthRightScreen;
				int maxDepthRightLayout = plotLayoutStackingGroup.MaxDepthRightLayout;
				int num3 = maxDepthLeftScreen + dataViewWidthScreen + maxDepthRightScreen + plotLayoutStackingGroup.OuterMarginScreen * 2;
				int num4 = maxDepthLeftLayout + dataViewWidthLayout + maxDepthRightLayout + plotLayoutStackingGroup.OuterMarginLayout * 2;
				plotLayoutStackingGroup.BoundsScreen = new Rectangle(num, BoundsScreen.Top, num3, BoundsScreen.Height);
				plotLayoutStackingGroup.BoundsLayout = new Rectangle(num2, BoundsLayout.Top, num4, BoundsLayout.Height);
				num += num3 + PlotLayoutStackingGroup.DockMarginScreen;
				num2 += num4;
				plotLayoutStackingGroup.DataViewReferenceLeftScreen = plotLayoutStackingGroup.BoundsScreen.Left + plotLayoutStackingGroup.MaxDepthLeftScreen + plotLayoutStackingGroup.OuterMarginScreen;
				plotLayoutStackingGroup.DataViewReferenceRightScreen = plotLayoutStackingGroup.BoundsScreen.Right - plotLayoutStackingGroup.MaxDepthRightScreen - plotLayoutStackingGroup.OuterMarginScreen;
				plotLayoutStackingGroup.DataViewReferenceLeftLayout = plotLayoutStackingGroup.BoundsLayout.Left + plotLayoutStackingGroup.MaxDepthLeftLayout + plotLayoutStackingGroup.OuterMarginLayout;
				plotLayoutStackingGroup.DataViewReferenceRightLayout = plotLayoutStackingGroup.BoundsLayout.Right - plotLayoutStackingGroup.MaxDepthRightLayout - plotLayoutStackingGroup.OuterMarginLayout;
			}
		}

		public virtual void PerformDataViewHeightCalculations()
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PlotLayoutStackingGroup plotLayoutStackingGroup = (PlotLayoutStackingGroup)enumerator.Current;
					plotLayoutStackingGroup.PerformDataViewHeightCalculations();
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		public virtual void PerformDataViewBoundsCalculations()
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PlotLayoutStackingGroup plotLayoutStackingGroup = (PlotLayoutStackingGroup)enumerator.Current;
					plotLayoutStackingGroup.PerformDataViewBoundsCalculations();
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}
	}
}
