namespace Iocomp.Classes
{
	public class PlotLegendBasicAccessor
	{
		private PlotLegendBaseCollection m_Collection;

		public PlotLegendBasic this[int index]
		{
			get
			{
				return m_Collection[index] as PlotLegendBasic;
			}
		}

		public PlotLegendBasic this[string name]
		{
			get
			{
				return m_Collection[name] as PlotLegendBasic;
			}
		}

		public PlotLegendBasicAccessor(PlotLegendBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
