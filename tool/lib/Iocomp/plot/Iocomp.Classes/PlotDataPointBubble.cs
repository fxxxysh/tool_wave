namespace Iocomp.Classes
{
	public class PlotDataPointBubble : PlotDataPointYDouble
	{
		private double m_Radius;

		public double Radius
		{
			get
			{
				return m_Radius;
			}
			set
			{
				if (m_Radius != value)
				{
					m_Radius = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public PlotDataPointBubble(PlotChannelBase channel)
			: base(channel)
		{
		}
	}
}
