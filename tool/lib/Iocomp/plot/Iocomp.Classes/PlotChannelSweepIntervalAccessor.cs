namespace Iocomp.Classes
{
	public class PlotChannelSweepIntervalAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelSweepInterval this[int index]
		{
			get
			{
				return m_Collection[index] as PlotChannelSweepInterval;
			}
		}

		public PlotChannelSweepInterval this[string name]
		{
			get
			{
				return m_Collection[name] as PlotChannelSweepInterval;
			}
		}

		public PlotChannelSweepIntervalAccessor(PlotChannelBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
