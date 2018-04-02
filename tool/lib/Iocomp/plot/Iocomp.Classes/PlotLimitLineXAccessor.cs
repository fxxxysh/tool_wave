namespace Iocomp.Classes
{
	public class PlotLimitLineXAccessor
	{
		private PlotLimitBaseCollection m_Collection;

		public PlotLimitLineX this[int index]
		{
			get
			{
				return m_Collection[index] as PlotLimitLineX;
			}
		}

		public PlotLimitLineX this[string name]
		{
			get
			{
				return m_Collection[name] as PlotLimitLineX;
			}
		}

		public PlotLimitLineXAccessor(PlotLimitBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
