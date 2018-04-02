namespace Iocomp.Classes
{
	public class PlotChannelImageAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelImage this[int index]
		{
			get
			{
				return m_Collection[index] as PlotChannelImage;
			}
		}

		public PlotChannelImage this[string name]
		{
			get
			{
				return m_Collection[name] as PlotChannelImage;
			}
		}

		public PlotChannelImageAccessor(PlotChannelBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
