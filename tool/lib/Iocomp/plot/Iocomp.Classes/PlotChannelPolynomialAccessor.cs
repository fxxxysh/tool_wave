namespace Iocomp.Classes
{
	public class PlotChannelPolynomialAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelPolynomial this[int index]
		{
			get
			{
				return m_Collection[index] as PlotChannelPolynomial;
			}
		}

		public PlotChannelPolynomial this[string name]
		{
			get
			{
				return m_Collection[name] as PlotChannelPolynomial;
			}
		}

		public PlotChannelPolynomialAccessor(PlotChannelBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
