namespace Iocomp.Classes
{
	public class PlotChannelDifferentialAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelDifferential this[int index]
		{
			get
			{
				return m_Collection[index] as PlotChannelDifferential;
			}
		}

		public PlotChannelDifferential this[string name]
		{
			get
			{
				return m_Collection[name] as PlotChannelDifferential;
			}
		}

		public PlotChannelDifferentialAccessor(PlotChannelBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
