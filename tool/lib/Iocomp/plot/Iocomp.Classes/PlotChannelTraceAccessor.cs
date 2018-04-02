namespace Iocomp.Classes
{
	public class PlotChannelTraceAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelTrace this[int index]
		{
			get
			{
				return m_Collection[index] as PlotChannelTrace;
			}
		}

		public PlotChannelTrace this[string name]
		{
			get
			{
				return m_Collection[name] as PlotChannelTrace;
			}
		}

		public PlotChannelTraceAccessor(PlotChannelBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
