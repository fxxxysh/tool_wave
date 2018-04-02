using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLayoutUniqueDockOrderCollection : IEnumerable
	{
		private ArrayList m_List;

		public int Count => m_List.Count;

		public PlotLayoutUniqueDockOrder this[int index]
		{
			get
			{
				return m_List[index] as PlotLayoutUniqueDockOrder;
			}
			set
			{
				m_List[index] = value;
			}
		}

		public PlotLayoutUniqueDockOrderCollection()
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

		public int Add(PlotLayoutUniqueDockOrder value)
		{
			return m_List.Add(value);
		}

		public void Clear()
		{
			m_List.Clear();
		}

		public void Sort(IComparer comparer)
		{
			m_List.Sort(comparer);
		}

		public void Sort()
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PlotLayoutUniqueDockOrder plotLayoutUniqueDockOrder = (PlotLayoutUniqueDockOrder)enumerator.Current;
					plotLayoutUniqueDockOrder.Items.SortDockPercentStart();
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

		public int IndexOf(PlotLayoutUniqueDockOrder value)
		{
			return m_List.IndexOf(value);
		}

		public void CalcualteDimensions(PaintArgs p)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					PlotLayoutUniqueDockOrder plotLayoutUniqueDockOrder = (PlotLayoutUniqueDockOrder)enumerator.Current;
					plotLayoutUniqueDockOrder.CalcualteDimensions(p);
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
