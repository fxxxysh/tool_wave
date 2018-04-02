using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlugInControlPanel : UserControl
	{
		private Button m_ApplyButton;

		private Button m_CancelButton;

		private Button m_OKButton;

		private Button m_ResetButton;

		private Button m_RestoreButton;

		private Container components;

		public Button ApplyButton => m_ApplyButton;

		public Button CancelButton => m_CancelButton;

		public Button OKButton => m_OKButton;

		public Button ResetButton => m_ResetButton;

		public Button RestoreButton => m_RestoreButton;

		public int RequiredWidthMin => 10 + ApplyButton.Width + CancelButton.Width + OKButton.Width + ResetButton.Width + RestoreButton.Width + 20;

		public PlugInControlPanel()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			m_ApplyButton = new Button();
			m_CancelButton = new Button();
			m_OKButton = new Button();
			m_ResetButton = new Button();
			m_RestoreButton = new Button();
			base.SuspendLayout();
			m_ApplyButton.Location = new Point(344, 6);
			m_ApplyButton.Name = "m_ApplyButton";
			m_ApplyButton.Size = new Size(60, 22);
			m_ApplyButton.TabIndex = 4;
			m_ApplyButton.Text = "Apply";
			m_CancelButton.Location = new Point(264, 6);
			m_CancelButton.Name = "m_CancelButton";
			m_CancelButton.Size = new Size(60, 22);
			m_CancelButton.TabIndex = 3;
			m_CancelButton.Text = "Cancel";
			m_OKButton.Location = new Point(184, 6);
			m_OKButton.Name = "m_OKButton";
			m_OKButton.Size = new Size(60, 22);
			m_OKButton.TabIndex = 2;
			m_OKButton.Text = "OK";
			m_ResetButton.Location = new Point(8, 6);
			m_ResetButton.Name = "m_ResetButton";
			m_ResetButton.Size = new Size(60, 23);
			m_ResetButton.TabIndex = 0;
			m_ResetButton.Text = "Reset";
			m_RestoreButton.Location = new Point(88, 6);
			m_RestoreButton.Name = "m_RestoreButton";
			m_RestoreButton.Size = new Size(60, 23);
			m_RestoreButton.TabIndex = 1;
			m_RestoreButton.Text = "Restore";
			base.Controls.Add(m_RestoreButton);
			base.Controls.Add(m_ResetButton);
			base.Controls.Add(m_ApplyButton);
			base.Controls.Add(m_CancelButton);
			base.Controls.Add(m_OKButton);
			base.Name = "PlugInControlPanel";
			base.Size = new Size(418, 32);
			base.SizeChanged += UITypeEditorControlPanel_SizeChanged;
			base.ResumeLayout(false);
		}

		private void UITypeEditorControlPanel_SizeChanged(object sender, EventArgs e)
		{
			DoLayout();
		}

		public void DoLayout()
		{
			ApplyButton.Left = base.Width - 5 - ApplyButton.Width;
			CancelButton.Left = ApplyButton.Left - CancelButton.Width;
			OKButton.Left = CancelButton.Left - OKButton.Width;
			ResetButton.Left = 5;
			RestoreButton.Left = ResetButton.Right;
		}
	}
}
