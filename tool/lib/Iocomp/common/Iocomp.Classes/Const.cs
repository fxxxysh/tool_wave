namespace Iocomp.Classes
{
	public sealed class Const
	{
		private static string m_EmptyString;

		public static string EmptyString => m_EmptyString;

		static Const()
		{
			m_EmptyString = string.Empty;
		}
	}
}
