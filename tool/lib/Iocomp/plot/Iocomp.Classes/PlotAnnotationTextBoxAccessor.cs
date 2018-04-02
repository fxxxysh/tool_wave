namespace Iocomp.Classes
{
	public class PlotAnnotationTextBoxAccessor
	{
		private PlotAnnotationBaseCollection m_Collection;

		public PlotAnnotationTextBox this[int index]
		{
			get
			{
				return m_Collection[index] as PlotAnnotationTextBox;
			}
		}

		public PlotAnnotationTextBox this[string name]
		{
			get
			{
				return m_Collection[name] as PlotAnnotationTextBox;
			}
		}

		public PlotAnnotationTextBoxAccessor(PlotAnnotationBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
