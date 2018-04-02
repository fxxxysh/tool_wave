namespace Iocomp.Classes
{
	public class PlotLabelBasicAccessor
	{
		private PlotLabelBaseCollection m_Collection;

		public PlotLabelBasic this[int index]
		{
			get
			{
				return m_Collection[index] as PlotLabelBasic;
			}
		}

		public PlotLabelBasic this[string name]
		{
			get
			{
				return m_Collection[name] as PlotLabelBasic;
			}
		}

		public PlotLabelBasicAccessor(PlotLabelBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
