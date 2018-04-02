using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Color Table.")]
	public class PlotColorTable
	{
		private ArrayList m_List;

		public int Count => m_List.Count;

		public PlotColorTableEntry this[int index]
		{
			get
			{
				return m_List[index] as PlotColorTableEntry;
			}
		}

		[Browsable(false)]
		public event EventHandler RefreshTable;

		public PlotColorTable()
		{
			m_List = new ArrayList();
			AddColor(Color.Red);
			AddColor(Color.Blue);
			AddColor(Color.Lime);
			AddColor(Color.Yellow);
			AddColor(Color.Aqua);
			AddColor(Color.White);
		}

		public void AddColor(Color color)
		{
			m_List.Add(new PlotColorTableEntry(color));
		}

		public void AddUsedColor(Color color)
		{
			for (int i = 0; i < Count; i++)
			{
				if (this[i].Color.Equals(color))
				{
					this[i].Count++;
				}
			}
		}

		public void Clear()
		{
			m_List.Clear();
		}

		public void RemoveAt(int index)
		{
			m_List.RemoveAt(index);
		}

		private void PerformRefreshTable()
		{
			for (int i = 0; i < Count; i++)
			{
				this[i].Count = 0;
			}
			if (this.RefreshTable != null)
			{
				this.RefreshTable(this, EventArgs.Empty);
			}
		}

		public Color NextColor()
		{
			if (Count == 0)
			{
				return Color.Empty;
			}
			PerformRefreshTable();
			int num = 2147483647;
			foreach (PlotColorTableEntry item in m_List)
			{
				num = Math.Min(num, item.Count);
			}
			foreach (PlotColorTableEntry item2 in m_List)
			{
				if (item2.Count == num)
				{
					return item2.Color;
				}
			}
			return Color.Empty;
		}
	}
}
