namespace Iocomp.Classes
{
	public class PlotAnnotationRectangleAccessor
	{
		private PlotAnnotationBaseCollection m_Collection;

		public PlotAnnotationRectangle this[int index]
		{
			get
			{
				return m_Collection[index] as PlotAnnotationRectangle;
			}
		}

		public PlotAnnotationRectangle this[string name]
		{
			get
			{
				return m_Collection[name] as PlotAnnotationRectangle;
			}
		}

		public PlotAnnotationRectangleAccessor(PlotAnnotationBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
