namespace Iocomp.Classes
{
	public class PlotAnnotationEllipseAccessor
	{
		private PlotAnnotationBaseCollection m_Collection;

		public PlotAnnotationEllipse this[int index]
		{
			get
			{
				return m_Collection[index] as PlotAnnotationEllipse;
			}
		}

		public PlotAnnotationEllipse this[string name]
		{
			get
			{
				return m_Collection[name] as PlotAnnotationEllipse;
			}
		}

		public PlotAnnotationEllipseAccessor(PlotAnnotationBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
