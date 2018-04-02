using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLayoutBlockItemCollection : IEnumerable
	{
		private ArrayList m_List;

		private PlotLayoutUniqueDockOrderCollection m_UniqueDockOrders;

		public int TotalDepthScreen;

		public int TotalDepthLayout;

		public int MaxOverlapStart;

		public int MaxOverlapStop;

		public int Count => m_List.Count;

		public PlotLayoutBlockItem this[int index]
		{
			get
			{
				return m_List[index] as PlotLayoutBlockItem;
			}
			set
			{
				m_List[index] = value;
			}
		}

		public PlotLayoutUniqueDockOrderCollection UniqueDockOrders => m_UniqueDockOrders;

		public PlotLayoutBlockItemCollection()
		{
			m_List = new ArrayList();
			m_UniqueDockOrders = new PlotLayoutUniqueDockOrderCollection();
		}

		public IEnumerator GetEnumerator()
		{
			return m_List.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public int Add(PlotLayoutBlockItem value)
		{
			return m_List.Add(value);
		}

		public void Remove(object value)
		{
			m_List.Remove(value);
		}

		public void Clear()
		{
			m_List.Clear();
		}

		private void Sort(IComparer comparer)
		{
			m_List.Sort(comparer);
		}

		public void SortDockOrder()
		{
			m_List.Sort(PlotLayoutManager.BlockItemDockOrderSorter);
			if (Count != 0)
			{
				while (this[0].Object.DockOrder == -1)
				{
					this[0].Object.DockOrder = this[Count - 1].Object.DockOrder + 1;
					m_List.Sort(PlotLayoutManager.BlockItemDockOrderSorter);
				}
			}
		}

		public void SortDockPercentStart()
		{
			m_List.Sort(PlotLayoutManager.BlockItemDockPercentStartSorter);
		}

		public int IndexOf(PlotLayoutBlockItem value)
		{
			return m_List.IndexOf(value);
		}

		private void CalculateUniqueDockOrders(PaintArgs p)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PlotLayoutBlockItem plotLayoutBlockItem = (PlotLayoutBlockItem)enumerator.Current;
					if (UniqueDockOrders.Count == 0)
					{
						PlotLayoutUniqueDockOrder plotLayoutUniqueDockOrder = new PlotLayoutUniqueDockOrder();
						plotLayoutUniqueDockOrder.DockOrder = plotLayoutBlockItem.Object.DockOrder;
						plotLayoutUniqueDockOrder.Items.Add(plotLayoutBlockItem);
						UniqueDockOrders.Add(plotLayoutUniqueDockOrder);
					}
					else
					{
						PlotLayoutUniqueDockOrder plotLayoutUniqueDockOrder = UniqueDockOrders[UniqueDockOrders.Count - 1];
						if (plotLayoutUniqueDockOrder.DockOrder == plotLayoutBlockItem.Object.DockOrder)
						{
							plotLayoutUniqueDockOrder.Items.Add(plotLayoutBlockItem);
						}
						else
						{
							plotLayoutUniqueDockOrder = new PlotLayoutUniqueDockOrder();
							plotLayoutUniqueDockOrder.DockOrder = plotLayoutBlockItem.Object.DockOrder;
							plotLayoutUniqueDockOrder.Items.Add(plotLayoutBlockItem);
							UniqueDockOrders.Add(plotLayoutUniqueDockOrder);
						}
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
			UniqueDockOrders.Sort();
			UniqueDockOrders.CalcualteDimensions(p);
		}

		public void Calculate(PaintArgs p)
		{
			CalculateUniqueDockOrders(p);
			TotalDepthScreen = 0;
			TotalDepthLayout = 0;
			MaxOverlapStart = 0;
			MaxOverlapStop = 0;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder in UniqueDockOrders)
			{
				TotalDepthScreen += uniqueDockOrder.MaxDepthScreen + uniqueDockOrder.MaxDockMargin;
				TotalDepthLayout += uniqueDockOrder.MaxDepthLayout;
				MaxOverlapStart = Math.Max(MaxOverlapStart, uniqueDockOrder.OverlapStart);
				MaxOverlapStop = Math.Max(MaxOverlapStop, uniqueDockOrder.OverlapStop);
			}
		}

		public int GetMinBoundsScreenTop()
		{
			int num = 2147483647;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder in UniqueDockOrders)
			{
				num = Math.Min(num, uniqueDockOrder.GetMinBoundsScreenTop());
			}
			return num;
		}

		public int GetMaxBoundsScreenBottom()
		{
			int num = -2147483648;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder in UniqueDockOrders)
			{
				num = Math.Max(num, uniqueDockOrder.GetMaxBoundsScreenBottom());
			}
			return num;
		}

		public int GetMinBoundsScreenLeft()
		{
			int num = 2147483647;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder in UniqueDockOrders)
			{
				num = Math.Min(num, uniqueDockOrder.GetMinBoundsScreenLeft());
			}
			return num;
		}

		public int GetMaxBoundsScreenRight()
		{
			int num = -2147483648;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder in UniqueDockOrders)
			{
				num = Math.Max(num, uniqueDockOrder.GetMaxBoundsScreenRight());
			}
			return num;
		}

		public void TransferBoundsToLayoutObjects()
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PlotLayoutBlockItem plotLayoutBlockItem = (PlotLayoutBlockItem)enumerator.Current;
					plotLayoutBlockItem.TransferBoundsToLayoutObjects();
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
