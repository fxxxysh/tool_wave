namespace Iocomp.Classes
{
	public class PlotChannelTraceXYAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelTraceXY this[int index]
		{
			get
			{
				return m_Collection[index] as PlotChannelTraceXY;
			}
		}

		public PlotChannelTraceXY this[string name]
		{
			get
			{
				return m_Collection[name] as PlotChannelTraceXY;
			}
		}

		public PlotChannelTraceXYAccessor(PlotChannelBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
