using System.Collections;

namespace Iocomp.Classes
{
	public class PlotObjectCollection : IEnumerable
	{
		private ArrayList m_List;

		public int Count => m_List.Count;

		public PlotObject this[int index]
		{
			get
			{
				return m_List[index] as PlotObject;
			}
			set
			{
				m_List[index] = value;
			}
		}

		public PlotObjectCollection()
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

		public int Add(PlotObject value)
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

		public int IndexOf(PlotObject value)
		{
			return m_List.IndexOf(value);
		}
	}
}
