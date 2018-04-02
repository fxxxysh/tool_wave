namespace Iocomp.Classes
{
	public class PlotLimitLineYAccessor
	{
		private PlotLimitBaseCollection m_Collection;

		public PlotLimitLineY this[int index]
		{
			get
			{
				return m_Collection[index] as PlotLimitLineY;
			}
		}

		public PlotLimitLineY this[string name]
		{
			get
			{
				return m_Collection[name] as PlotLimitLineY;
			}
		}

		public PlotLimitLineYAccessor(PlotLimitBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
