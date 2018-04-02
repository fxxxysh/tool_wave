using System;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public class SaveDialogEventArgs : EventArgs
	{
		private SaveFileDialog m_SaveDialog;

		public SaveFileDialog SaveDialog => m_SaveDialog;

		public SaveDialogEventArgs(SaveFileDialog value)
		{
			m_SaveDialog = value;
		}
	}
}
