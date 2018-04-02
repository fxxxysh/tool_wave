namespace Iocomp.Classes
{
	public class PlotLegendChannelImageAccessor
	{
		private PlotLegendBaseCollection m_Collection;

		public PlotLegendChannelImage this[int index]
		{
			get
			{
				return m_Collection[index] as PlotLegendChannelImage;
			}
		}

		public PlotLegendChannelImage this[string name]
		{
			get
			{
				return m_Collection[name] as PlotLegendChannelImage;
			}
		}

		public PlotLegendChannelImageAccessor(PlotLegendBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
