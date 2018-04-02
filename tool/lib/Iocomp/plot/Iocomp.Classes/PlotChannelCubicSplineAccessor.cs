namespace Iocomp.Classes
{
	public class PlotChannelCubicSplineAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelCubicSpline this[int index]
		{
			get
			{
				return m_Collection[index] as PlotChannelCubicSpline;
			}
		}

		public PlotChannelCubicSpline this[string name]
		{
			get
			{
				return m_Collection[name] as PlotChannelCubicSpline;
			}
		}

		public PlotChannelCubicSplineAccessor(PlotChannelBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
