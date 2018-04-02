using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class UIControlEditorPlugIn : PlugInStandard
	{
		private CheckBox KeyboardEnabledCheckBox;

		private CheckBox FocusRectangleShowCheckBox;

		private Container components;

		public UIControlEditorPlugIn()
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
			KeyboardEnabledCheckBox = new CheckBox();
			FocusRectangleShowCheckBox = new CheckBox();
			base.SuspendLayout();
			KeyboardEnabledCheckBox.Location = new Point(32, 16);
			KeyboardEnabledCheckBox.Name = "KeyboardEnabledCheckBox";
			KeyboardEnabledCheckBox.PropertyName = "KeyboardEnabled";
			KeyboardEnabledCheckBox.Size = new Size(120, 24);
			KeyboardEnabledCheckBox.TabIndex = 0;
			KeyboardEnabledCheckBox.Text = "Keyboard Enabled";
			FocusRectangleShowCheckBox.Location = new Point(32, 40);
			FocusRectangleShowCheckBox.Name = "FocusRectangleShowCheckBox";
			FocusRectangleShowCheckBox.PropertyName = "FocusRectangleShow";
			FocusRectangleShowCheckBox.Size = new Size(144, 24);
			FocusRectangleShowCheckBox.TabIndex = 1;
			FocusRectangleShowCheckBox.Text = "Focus Rectangle Show";
			base.Controls.Add(FocusRectangleShowCheckBox);
			base.Controls.Add(KeyboardEnabledCheckBox);
			base.Name = "UIControlEditorPlugIn";
			base.Size = new Size(304, 136);
			base.Title = "UI Control Editor";
			base.ResumeLayout(false);
		}
	}
}
