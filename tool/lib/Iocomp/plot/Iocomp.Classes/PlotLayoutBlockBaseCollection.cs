using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLayoutBlockBaseCollection : IEnumerable
	{
		private ArrayList m_List;

		public int Count => m_List.Count;

		public PlotLayoutBlockBase this[int index]
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

		public PlotLayoutBlockBaseCollection()
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

		public int Add(PlotLayoutBlockBase value)
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

		public int IndexOf(PlotLayoutBlockItem value)
		{
			return m_List.IndexOf(value);
		}
	}
}
