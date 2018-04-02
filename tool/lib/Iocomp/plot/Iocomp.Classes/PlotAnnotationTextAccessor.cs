namespace Iocomp.Classes
{
	public class PlotAnnotationTextAccessor
	{
		private PlotAnnotationBaseCollection m_Collection;

		public PlotAnnotationText this[int index]
		{
			get
			{
				return m_Collection[index] as PlotAnnotationText;
			}
		}

		public PlotAnnotationText this[string name]
		{
			get
			{
				return m_Collection[name] as PlotAnnotationText;
			}
		}

		public PlotAnnotationTextAccessor(PlotAnnotationBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
