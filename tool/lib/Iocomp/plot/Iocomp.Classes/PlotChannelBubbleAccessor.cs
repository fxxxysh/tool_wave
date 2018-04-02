namespace Iocomp.Classes
{
	public class PlotChannelBubbleAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelBubble this[int index]
		{
			get
			{
				return m_Collection[index] as PlotChannelBubble;
			}
		}

		public PlotChannelBubble this[string name]
		{
			get
			{
				return m_Collection[name] as PlotChannelBubble;
			}
		}

		public PlotChannelBubbleAccessor(PlotChannelBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
