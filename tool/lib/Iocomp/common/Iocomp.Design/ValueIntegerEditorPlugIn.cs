using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public sealed class ValueIntegerEditorPlugIn : PlugInStandard
	{
		private EditBox MaxTextBox;

		private EditBox MinTextBox;

		private FocusLabel label3;

		private FocusLabel label2;

		private CheckBox EventsEnabledCheckBox;

		private EditBox AsIntegerTextBox;

		private FocusLabel label1;

		private Container components;

		public ValueIntegerEditorPlugIn()
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
			MaxTextBox = new EditBox();
			MinTextBox = new EditBox();
			label3 = new FocusLabel();
			label2 = new FocusLabel();
			EventsEnabledCheckBox = new CheckBox();
			AsIntegerTextBox = new EditBox();
			label1 = new FocusLabel();
			base.SuspendLayout();
			MaxTextBox.LoadingBegin();
			MaxTextBox.Location = new Point(64, 56);
			MaxTextBox.Name = "MaxTextBox";
			MaxTextBox.PropertyName = "Max";
			MaxTextBox.TabIndex = 2;
			MaxTextBox.LoadingEnd();
			MinTextBox.LoadingBegin();
			MinTextBox.Location = new Point(64, 32);
			MinTextBox.Name = "MinTextBox";
			MinTextBox.PropertyName = "Min";
			MinTextBox.TabIndex = 1;
			MinTextBox.LoadingEnd();
			label3.LoadingBegin();
			label3.FocusControl = MaxTextBox;
			label3.Location = new Point(36, 58);
			label3.Name = "label3";
			label3.Size = new Size(28, 15);
			label3.Text = "Max";
			label3.LoadingEnd();
			label2.LoadingBegin();
			label2.FocusControl = MinTextBox;
			label2.Location = new Point(39, 34);
			label2.Name = "label2";
			label2.Size = new Size(25, 15);
			label2.Text = "Min";
			label2.LoadingEnd();
			EventsEnabledCheckBox.Location = new Point(64, 96);
			EventsEnabledCheckBox.Name = "EventsEnabledCheckBox";
			EventsEnabledCheckBox.PropertyName = "EventsEnabled";
			EventsEnabledCheckBox.Size = new Size(112, 24);
			EventsEnabledCheckBox.TabIndex = 3;
			EventsEnabledCheckBox.Text = "Events Enabled";
			AsIntegerTextBox.LoadingBegin();
			AsIntegerTextBox.Location = new Point(64, 0);
			AsIntegerTextBox.Name = "AsIntegerTextBox";
			AsIntegerTextBox.PropertyName = "AsInteger";
			AsIntegerTextBox.TabIndex = 0;
			AsIntegerTextBox.LoadingEnd();
			label1.LoadingBegin();
			label1.FocusControl = AsIntegerTextBox;
			label1.Location = new Point(28, 2);
			label1.Name = "label1";
			label1.Size = new Size(36, 15);
			label1.Text = "Value";
			label1.LoadingEnd();
			base.Controls.Add(MaxTextBox);
			base.Controls.Add(MinTextBox);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(EventsEnabledCheckBox);
			base.Controls.Add(AsIntegerTextBox);
			base.Controls.Add(label1);
			base.Name = "ValueIntegerEditorPlugIn";
			base.Size = new Size(352, 144);
			base.Title = "Value Integer Editor";
			base.ResumeLayout(false);
		}
	}
}
