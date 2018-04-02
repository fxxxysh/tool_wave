namespace Iocomp.Classes
{
	public class PlotTableChannelAccessor
	{
		private PlotTableBaseCollection m_Collection;

		public PlotTableChannel this[int index]
		{
			get
			{
				return m_Collection[index] as PlotTableChannel;
			}
		}

		public PlotTableChannel this[string name]
		{
			get
			{
				return m_Collection[name] as PlotTableChannel;
			}
		}

		public PlotTableChannelAccessor(PlotTableBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
