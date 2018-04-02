namespace Iocomp.Classes
{
	public class PlotChannelFillAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelFill this[int index]
		{
			get
			{
				return m_Collection[index] as PlotChannelFill;
			}
		}

		public PlotChannelFill this[string name]
		{
			get
			{
				return m_Collection[name] as PlotChannelFill;
			}
		}

		public PlotChannelFillAccessor(PlotChannelBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
