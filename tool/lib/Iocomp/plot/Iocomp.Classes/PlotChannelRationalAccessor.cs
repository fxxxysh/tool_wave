namespace Iocomp.Classes
{
	public class PlotChannelRationalAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelRational this[int index]
		{
			get
			{
				return m_Collection[index] as PlotChannelRational;
			}
		}

		public PlotChannelRational this[string name]
		{
			get
			{
				return m_Collection[name] as PlotChannelRational;
			}
		}

		public PlotChannelRationalAccessor(PlotChannelBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
