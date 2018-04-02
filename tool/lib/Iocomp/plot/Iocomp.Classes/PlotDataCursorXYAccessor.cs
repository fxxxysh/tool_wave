namespace Iocomp.Classes
{
	public class PlotDataCursorXYAccessor
	{
		private PlotDataCursorBaseCollection m_Collection;

		public PlotDataCursorXY this[int index]
		{
			get
			{
				return m_Collection[index] as PlotDataCursorXY;
			}
		}

		public PlotDataCursorXY this[string name]
		{
			get
			{
				return m_Collection[name] as PlotDataCursorXY;
			}
		}

		public PlotDataCursorXYAccessor(PlotDataCursorBaseCollection value)
		{
			m_Collection = value;
		}
	}
}
