using System.Collections;

namespace Iocomp.Classes
{
	public class PlotDataCursorDisplayCollection : IEnumerable
	{
		private ArrayList m_List;

		public int Count => m_List.Count;

		public PlotDataCursorDisplay this[int index]
		{
			get
			{
				return m_List[index] as PlotDataCursorDisplay;
			}
			set
			{
				m_List[index] = value;
			}
		}

		public PlotDataCursorDisplayCollection()
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

		public int Add(PlotDataCursorDisplay value)
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

		public int IndexOf(PlotDataCursorDisplay value)
		{
			return m_List.IndexOf(value);
		}
	}
}
