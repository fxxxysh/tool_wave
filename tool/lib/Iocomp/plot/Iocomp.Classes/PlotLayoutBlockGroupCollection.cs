using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLayoutBlockGroupCollection : IEnumerable
	{
		private ArrayList m_List;

		public int Count => m_List.Count;

		public PlotLayoutBlockGroup this[int index]
		{
			get
			{
				return m_List[index] as PlotLayoutBlockGroup;
			}
			set
			{
				m_List[index] = value;
			}
		}

		public PlotLayoutBlockGroupCollection()
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

		public int Add(PlotLayoutBlockGroup value)
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

		public void SortDockOrders()
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PlotLayoutBlockGroup plotLayoutBlockGroup = (PlotLayoutBlockGroup)enumerator.Current;
					plotLayoutBlockGroup.SortDockOrders();
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

		public void SortDataViewsDockOrder()
		{
			Sort(PlotLayoutManager.BlockItemDockOrderSorter);
		}

		public int IndexOf(PlotLayoutBlockGroup value)
		{
			return m_List.IndexOf(value);
		}

		public virtual void Calculate(PaintArgs p)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PlotLayoutBlockGroup plotLayoutBlockGroup = (PlotLayoutBlockGroup)enumerator.Current;
					plotLayoutBlockGroup.Calculate(p);
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

		public void CalculateAndSetAllDockObjectBounds()
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PlotLayoutBlockGroup plotLayoutBlockGroup = (PlotLayoutBlockGroup)enumerator.Current;
					plotLayoutBlockGroup.CalculateAndSetAllDockObjectBounds();
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

		public void TransferBoundsToLayoutObjects()
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PlotLayoutBlockGroup plotLayoutBlockGroup = (PlotLayoutBlockGroup)enumerator.Current;
					plotLayoutBlockGroup.TransferBoundsToLayoutObjects();
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
