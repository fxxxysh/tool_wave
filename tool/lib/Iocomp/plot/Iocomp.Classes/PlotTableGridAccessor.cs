namespace Iocomp.Classes
{
	public class PlotTableGridAccessor
	{
		private PlotTableBaseCollection m_Collection;

		public PlotTableGrid this[int index]
		{
			get
			{
				return m_Collection[index] as PlotTableGrid;
			}
		}

		public PlotTableGrid this[string name]
		{
			get
			{
				return m_Collection[name] as PlotTableGrid;
			}
		}

		public PlotTableGridAccessor(PlotTableBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
