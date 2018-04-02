using System;

namespace Iocomp.Design
{
	public class UITypeEditorEventArgs : EventArgs
	{
		private UITypeEditorGeneric m_Editor;

		private PlugInStandard m_MainPlugIn;

		private string m_MainPlugInTitle;

		private string m_MainPlugInTabName;

		public UITypeEditorGeneric Editor => m_Editor;

		public PlugInStandard MainPlugIn
		{
			get
			{
				return m_MainPlugIn;
			}
			set
			{
				m_MainPlugIn = value;
			}
		}

		public string MainPlugInTitle
		{
			get
			{
				return m_MainPlugInTitle;
			}
			set
			{
				m_MainPlugInTitle = value;
			}
		}

		public string MainPlugInTabName
		{
			get
			{
				return m_MainPlugInTabName;
			}
			set
			{
				m_MainPlugInTabName = value;
			}
		}

		public UITypeEditorEventArgs(UITypeEditorGeneric editor)
		{
			m_Editor = editor;
		}
	}
}
