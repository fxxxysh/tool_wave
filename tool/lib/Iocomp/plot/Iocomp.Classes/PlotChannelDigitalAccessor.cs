namespace Iocomp.Classes
{
	public class PlotChannelDigitalAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelDigital this[int index]
		{
			get
			{
				return m_Collection[index] as PlotChannelDigital;
			}
		}

		public PlotChannelDigital this[string name]
		{
			get
			{
				return m_Collection[name] as PlotChannelDigital;
			}
		}

		public PlotChannelDigitalAccessor(PlotChannelBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
