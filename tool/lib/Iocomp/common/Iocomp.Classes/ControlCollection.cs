using System.Collections;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public class ControlCollection : IEnumerable
	{
		private ArrayList m_List;

		public int Count => m_List.Count;

		public Control this[int index]
		{
			get
			{
				return m_List[index] as Control;
			}
			set
			{
				m_List[index] = value;
			}
		}

		public ControlCollection()
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

		public int Add(Control value)
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

		public int IndexOf(Control value)
		{
			return m_List.IndexOf(value);
		}
	}
}
