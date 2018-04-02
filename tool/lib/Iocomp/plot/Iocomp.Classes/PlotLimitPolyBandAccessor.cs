namespace Iocomp.Classes
{
	public class PlotLimitPolyBandAccessor
	{
		private PlotLimitBaseCollection m_Collection;

		public PlotLimitPolyBand this[int index]
		{
			get
			{
				return m_Collection[index] as PlotLimitPolyBand;
			}
		}

		public PlotLimitPolyBand this[string name]
		{
			get
			{
				return m_Collection[name] as PlotLimitPolyBand;
			}
		}

		public PlotLimitPolyBandAccessor(PlotLimitBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
