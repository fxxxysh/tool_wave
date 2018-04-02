using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Components
{
	[Serializable]
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	public class ColorDialog : Component
	{
		private Color m_Color;

		private Form m_Form;

		public Color Color
		{
			get
			{
				return m_Color;
			}
			set
			{
				m_Color = value;
			}
		}

		public DialogResult ShowDialog()
		{
			return ShowDialog(null, m_Color);
		}

		public DialogResult ShowDialog(Color color)
		{
			return ShowDialog(null, color);
		}

		public DialogResult ShowDialog(IWin32Window owner)
		{
			return ShowDialog(owner, m_Color);
		}

		public DialogResult ShowDialog(IWin32Window owner, Color color)
		{
			m_Form = new Form();
			try
			{
				m_Form.FormBorderStyle = FormBorderStyle.FixedDialog;
				m_Form.MinimizeBox = false;
				m_Form.MaximizeBox = false;
				m_Form.Text = "Color";
				m_Form.Icon = null;
				m_Form.StartPosition = FormStartPosition.CenterScreen;
				m_Form.ShowInTaskbar = false;
				ColorSelector colorSelector = new ColorSelector();
				colorSelector.Color = color;
				colorSelector.ColorChangedDoubleClick += AColorSelector_ColorChangedDoubleClick;
				colorSelector.Location = new Point(0, 0);
				Button button = new Button();
				button.Text = "OK";
				button.Width = 70;
				Button button2 = new Button();
				button2.Text = "Cancel";
				button2.Width = 70;
				m_Form.Controls.Add(colorSelector);
				m_Form.Controls.Add(button);
				m_Form.Controls.Add(button2);
				m_Form.AcceptButton = button;
				m_Form.CancelButton = button2;
				button.Click += OkButton_Click;
				button2.Click += CancelButton_Click;
				m_Form.ClientSize = new Size(colorSelector.Width, colorSelector.Height + 2 * button.Height);
				button.Location = new Point(10, colorSelector.Height + button.Height / 2);
				button2.Location = new Point(button.Right + 10, colorSelector.Height + button.Height / 2);
				DialogResult dialogResult = m_Form.ShowDialog(owner);
				if (dialogResult == DialogResult.OK)
				{
					m_Color = colorSelector.Color;
				}
				return dialogResult;
			}
			finally
			{
				m_Form.Dispose();
			}
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			m_Form.DialogResult = DialogResult.OK;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			m_Form.DialogResult = DialogResult.Cancel;
		}

		private void AColorSelector_ColorChangedDoubleClick(object sender, EventArgs e)
		{
			m_Color = (sender as ColorSelector).Color;
			m_Form.DialogResult = DialogResult.OK;
		}
	}
}
