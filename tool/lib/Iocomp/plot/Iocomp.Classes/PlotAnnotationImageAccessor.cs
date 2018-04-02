namespace Iocomp.Classes
{
	public class PlotAnnotationImageAccessor
	{
		private PlotAnnotationBaseCollection m_Collection;

		public PlotAnnotationImage this[int index]
		{
			get
			{
				return m_Collection[index] as PlotAnnotationImage;
			}
		}

		public PlotAnnotationImage this[string name]
		{
			get
			{
				return m_Collection[name] as PlotAnnotationImage;
			}
		}

		public PlotAnnotationImageAccessor(PlotAnnotationBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
