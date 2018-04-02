namespace Iocomp.Classes
{
	public class PlotLimitBandXAccessor
	{
		private PlotLimitBaseCollection m_Collection;

		public PlotLimitBandX this[int index]
		{
			get
			{
				return m_Collection[index] as PlotLimitBandX;
			}
		}

		public PlotLimitBandX this[string name]
		{
			get
			{
				return m_Collection[name] as PlotLimitBandX;
			}
		}

		public PlotLimitBandXAccessor(PlotLimitBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
