using Iocomp.Types;

namespace Iocomp.Interfaces
{
	public interface IScaleTickMid : IScaleTickLabel, IScaleTickBase
	{
		AlignmentStyle Alignment
		{
			get;
			set;
		}
	}
}
