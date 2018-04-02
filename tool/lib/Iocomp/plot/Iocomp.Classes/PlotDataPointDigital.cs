namespace Iocomp.Classes
{
	public class PlotDataPointDigital : PlotDataPointBase
	{
		private bool m_Y;

		public bool Y
		{
			get
			{
				return m_Y;
			}
			set
			{
				if (m_Y != value)
				{
					m_Y = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public PlotDataPointDigital(PlotChannelBase channel)
			: base(channel)
		{
		}
	}
}
