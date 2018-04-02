namespace Iocomp.Classes
{
	public class PlotAnnotationArcAccessor
	{
		private PlotAnnotationBaseCollection m_Collection;

		public PlotAnnotationArc this[int index]
		{
			get
			{
				return m_Collection[index] as PlotAnnotationArc;
			}
		}

		public PlotAnnotationArc this[string name]
		{
			get
			{
				return m_Collection[name] as PlotAnnotationArc;
			}
		}

		public PlotAnnotationArcAccessor(PlotAnnotationBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
