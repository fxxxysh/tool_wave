using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public sealed class ValueDoubleEditorPlugIn : PlugInStandard
	{
		private Container components;

		private FocusLabel label1;

		private CheckBox EventsEnabledCheckBox;

		private FocusLabel label2;

		private FocusLabel label3;

		private EditBox MinTextBox;

		private EditBox ValueTextBox;

		private EditBox MaxTextBox;

		public ValueDoubleEditorPlugIn()
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
			ValueTextBox = new EditBox();
			label1 = new FocusLabel();
			EventsEnabledCheckBox = new CheckBox();
			label2 = new FocusLabel();
			MinTextBox = new EditBox();
			label3 = new FocusLabel();
			MaxTextBox = new EditBox();
			base.SuspendLayout();
			ValueTextBox.LoadingBegin();
			ValueTextBox.Location = new Point(40, 16);
			ValueTextBox.Name = "ValueTextBox";
			ValueTextBox.PropertyName = "AsDouble";
			ValueTextBox.Size = new Size(144, 20);
			ValueTextBox.TabIndex = 0;
			ValueTextBox.LoadingEnd();
			label1.LoadingBegin();
			label1.FocusControl = ValueTextBox;
			label1.Location = new Point(4, 18);
			label1.Name = "label1";
			label1.Size = new Size(36, 15);
			label1.Text = "Value";
			label1.LoadingEnd();
			EventsEnabledCheckBox.Location = new Point(40, 160);
			EventsEnabledCheckBox.Name = "EventsEnabledCheckBox";
			EventsEnabledCheckBox.PropertyName = "EventsEnabled";
			EventsEnabledCheckBox.Size = new Size(112, 24);
			EventsEnabledCheckBox.TabIndex = 3;
			EventsEnabledCheckBox.Text = "Events Enabled";
			label2.LoadingBegin();
			label2.FocusControl = MinTextBox;
			label2.Location = new Point(15, 74);
			label2.Name = "label2";
			label2.Size = new Size(25, 15);
			label2.Text = "Min";
			label2.LoadingEnd();
			MinTextBox.LoadingBegin();
			MinTextBox.Location = new Point(40, 72);
			MinTextBox.Name = "MinTextBox";
			MinTextBox.PropertyName = "Min";
			MinTextBox.Size = new Size(144, 20);
			MinTextBox.TabIndex = 1;
			MinTextBox.LoadingEnd();
			label3.LoadingBegin();
			label3.FocusControl = MaxTextBox;
			label3.Location = new Point(12, 98);
			label3.Name = "label3";
			label3.Size = new Size(28, 15);
			label3.Text = "Max";
			label3.LoadingEnd();
			MaxTextBox.LoadingBegin();
			MaxTextBox.Location = new Point(40, 96);
			MaxTextBox.Name = "MaxTextBox";
			MaxTextBox.PropertyName = "Max";
			MaxTextBox.Size = new Size(144, 20);
			MaxTextBox.TabIndex = 2;
			MaxTextBox.LoadingEnd();
			base.Controls.Add(MaxTextBox);
			base.Controls.Add(MinTextBox);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(EventsEnabledCheckBox);
			base.Controls.Add(ValueTextBox);
			base.Controls.Add(label1);
			base.Name = "ValueDoubleEditorPlugIn";
			base.Size = new Size(440, 232);
			base.Title = "Value Double Editor";
			base.ResumeLayout(false);
		}
	}
}
