namespace Iocomp.Classes
{
	public class PropertyData
	{
		private string m_Name;

		private object m_Value;

		public string Name
		{
			get
			{
				return m_Name;
			}
			set
			{
				m_Name = value;
			}
		}

		public object Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				m_Value = value;
			}
		}
	}
}
