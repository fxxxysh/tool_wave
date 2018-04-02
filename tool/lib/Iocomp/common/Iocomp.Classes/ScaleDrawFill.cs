using Iocomp.Interfaces;
using System.Drawing;

namespace Iocomp.Classes
{
	public sealed class ScaleDrawFill
	{
		private Rectangle m_Rectangle;

		private ScaleRangeLinear m_Range;

		public Rectangle Rectangle
		{
			get
			{
				return m_Rectangle;
			}
			set
			{
				m_Rectangle = value;
			}
		}

		public ScaleRangeLinear Range
		{
			get
			{
				return m_Range;
			}
			set
			{
				m_Range = value;
			}
		}

		public void OffsetEnds(int value)
		{
			m_Rectangle.Inflate(0, -value);
		}

		public Rectangle GetFillRectangle(double position)
		{
			((IScaleRangeLinear)Range).SetBounds(m_Rectangle.Bottom, m_Rectangle.Top);
			int num = ((IScaleRangeLinear)Range).ValueToPixels(position, false);
			if (!Range.Reverse)
			{
				return iRectangle.FromLTRB(m_Rectangle.Left, num, m_Rectangle.Right, m_Rectangle.Bottom);
			}
			return iRectangle.FromLTRB(m_Rectangle.Left, m_Rectangle.Top, m_Rectangle.Right, num);
		}

		public Rectangle GetNonFillRectangle(double position)
		{
			((IScaleRangeLinear)Range).SetBounds(m_Rectangle.Bottom, m_Rectangle.Top);
			int num = ((IScaleRangeLinear)Range).ValueToPixels(position, false);
			if (!Range.Reverse)
			{
				return iRectangle.FromLTRB(m_Rectangle.Left, m_Rectangle.Top, m_Rectangle.Right, num);
			}
			return iRectangle.FromLTRB(m_Rectangle.Left, num, m_Rectangle.Right, m_Rectangle.Bottom);
		}
	}
}
