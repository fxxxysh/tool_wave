namespace Iocomp.Classes
{
	public abstract class PlotDataPointYDouble : PlotDataPointBase
	{
		private double m_Y;

		public double Y
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

		public PlotDataPointYDouble(PlotChannelBase channel)
			: base(channel)
		{
		}
	}
}
