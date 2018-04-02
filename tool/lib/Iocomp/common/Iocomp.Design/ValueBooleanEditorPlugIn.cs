using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public sealed class ValueBooleanEditorPlugIn : PlugInStandard
	{
		private Container components;

		private CheckBox EventsEnabledCheckBox;

		private CheckBox AsBooleanCheckBox;

		public ValueBooleanEditorPlugIn()
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
			EventsEnabledCheckBox = new CheckBox();
			AsBooleanCheckBox = new CheckBox();
			base.SuspendLayout();
			EventsEnabledCheckBox.Location = new Point(24, 48);
			EventsEnabledCheckBox.Name = "EventsEnabledCheckBox";
			EventsEnabledCheckBox.PropertyName = "EventsEnabled";
			EventsEnabledCheckBox.Size = new Size(120, 24);
			EventsEnabledCheckBox.TabIndex = 1;
			EventsEnabledCheckBox.Text = "Events Enabled";
			AsBooleanCheckBox.Location = new Point(24, 16);
			AsBooleanCheckBox.Name = "AsBooleanCheckBox";
			AsBooleanCheckBox.PropertyName = "AsBoolean";
			AsBooleanCheckBox.TabIndex = 0;
			AsBooleanCheckBox.Text = "Value";
			base.Controls.Add(AsBooleanCheckBox);
			base.Controls.Add(EventsEnabledCheckBox);
			base.Name = "ValueBooleanEditorPlugIn";
			base.Size = new Size(408, 112);
			base.Title = "Value Boolean Editor";
			base.ResumeLayout(false);
		}
	}
}
