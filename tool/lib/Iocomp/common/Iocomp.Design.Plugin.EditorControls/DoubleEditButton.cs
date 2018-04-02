using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[DefaultEvent("")]
	[Designer(typeof(DoubleEditButtonDesigner))]
	[ToolboxItem(false)]
	[Description("Double Edit Button")]
	[DesignerCategory("code")]
	public class DoubleEditButton : Button
	{
		private EditBox m_EditBox;

		private bool m_RecursionBlock;

		protected override Size DefaultSize => new Size(24, 23);

		public EditBox EditBox
		{
			get
			{
				return m_EditBox;
			}
			set
			{
				if (m_EditBox != value)
				{
					if (m_EditBox != null)
					{
						m_EditBox.LocationChanged -= m_EditBox_LocationChanged;
						m_EditBox.SizeChanged -= m_EditBox_LocationChanged;
						m_EditBox.EnabledChanged -= m_EditBox_EnabledChanged;
					}
					m_EditBox = value;
					if (m_EditBox != null)
					{
						m_EditBox.LocationChanged += m_EditBox_LocationChanged;
						m_EditBox.SizeChanged += m_EditBox_LocationChanged;
						m_EditBox.EnabledChanged += m_EditBox_EnabledChanged;
						Align();
					}
				}
			}
		}

		[DefaultValue("...")]
		[ParenthesizePropertyName(true)]
		public new string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		public DoubleEditButton()
		{
			Text = "...";
		}

		private void m_EditBox_LocationChanged(object sender, EventArgs e)
		{
			Align();
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			if (!m_RecursionBlock)
			{
				m_RecursionBlock = true;
				try
				{
					base.OnSizeChanged(e);
					Align();
				}
				finally
				{
					m_RecursionBlock = false;
				}
			}
		}

		protected override void OnLocationChanged(EventArgs e)
		{
			if (!m_RecursionBlock)
			{
				m_RecursionBlock = true;
				try
				{
					base.OnLocationChanged(e);
					Align();
				}
				finally
				{
					m_RecursionBlock = false;
				}
			}
		}

		public void Align()
		{
			if (EditBox != null)
			{
				int num = -1;
				int x = EditBox.Location.X + EditBox.Width;
				int y = EditBox.Location.Y + EditBox.Height / 2 - base.Height / 2 + num;
				base.Location = new Point(x, y);
			}
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			DoubleEditForm doubleEditForm = new DoubleEditForm();
			try
			{
				doubleEditForm.Value = m_EditBox.AsDouble;
				if (doubleEditForm.ShowDialog() == DialogResult.OK)
				{
					m_EditBox.AsDouble = doubleEditForm.Value;
					m_EditBox.ForceUpdate();
				}
			}
			finally
			{
				doubleEditForm.Dispose();
			}
		}

		private void m_EditBox_EnabledChanged(object sender, EventArgs e)
		{
			base.Enabled = m_EditBox.Enabled;
		}
	}
}
