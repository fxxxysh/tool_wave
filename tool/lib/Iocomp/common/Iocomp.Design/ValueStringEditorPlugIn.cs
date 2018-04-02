using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public sealed class ValueStringEditorPlugIn : PlugInStandard
	{
		private EditBox StringTextBox;

		private FocusLabel label1;

		private CheckBox EventsEnabledCheckBox;

		private Container components;

		public ValueStringEditorPlugIn()
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
			StringTextBox = new EditBox();
			label1 = new FocusLabel();
			EventsEnabledCheckBox = new CheckBox();
			base.SuspendLayout();
			StringTextBox.LoadingBegin();
			StringTextBox.Location = new Point(56, 32);
			StringTextBox.Name = "StringTextBox";
			StringTextBox.PropertyName = "AsString";
			StringTextBox.Size = new Size(320, 20);
			StringTextBox.TabIndex = 0;
			StringTextBox.LoadingEnd();
			label1.LoadingBegin();
			label1.FocusControl = StringTextBox;
			label1.Location = new Point(20, 34);
			label1.Name = "label1";
			label1.Size = new Size(36, 15);
			label1.Text = "Value";
			label1.LoadingEnd();
			EventsEnabledCheckBox.Location = new Point(56, 64);
			EventsEnabledCheckBox.Name = "EventsEnabledCheckBox";
			EventsEnabledCheckBox.PropertyName = "EventsEnabled";
			EventsEnabledCheckBox.Size = new Size(120, 24);
			EventsEnabledCheckBox.TabIndex = 1;
			EventsEnabledCheckBox.Text = "Events Enabled";
			base.Controls.Add(EventsEnabledCheckBox);
			base.Controls.Add(StringTextBox);
			base.Controls.Add(label1);
			base.Name = "ValueStringEditorPlugIn";
			base.Size = new Size(408, 112);
			base.Title = "Value String Editor";
			base.ResumeLayout(false);
		}
	}
}
