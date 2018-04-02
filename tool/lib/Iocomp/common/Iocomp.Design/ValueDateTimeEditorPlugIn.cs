using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public sealed class ValueDateTimeEditorPlugIn : PlugInStandard
	{
		private GroupBox groupBox1;

		private FocusLabel label7;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.DateTimePicker DatePicker;

		private Iocomp.Design.Plugin.EditorControls.DateTimePicker TimePicker;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EventsEnabledCheckBox;

		private Container components;

		public ValueDateTimeEditorPlugIn()
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
			groupBox1 = new GroupBox();
			label7 = new FocusLabel();
			DatePicker = new Iocomp.Design.Plugin.EditorControls.DateTimePicker();
			label8 = new FocusLabel();
			TimePicker = new Iocomp.Design.Plugin.EditorControls.DateTimePicker();
			EventsEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			groupBox1.SuspendLayout();
			base.SuspendLayout();
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(DatePicker);
			groupBox1.Controls.Add(TimePicker);
			groupBox1.Location = new Point(16, 8);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(168, 88);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "As Date Time";
			label7.LoadingBegin();
			label7.FocusControl = DatePicker;
			label7.Location = new Point(25, 35);
			label7.Name = "label7";
			label7.Size = new Size(31, 15);
			label7.Text = "Date";
			label7.LoadingEnd();
			DatePicker.Format = DateTimePickerFormat.Short;
			DatePicker.Location = new Point(56, 32);
			DatePicker.Name = "DatePicker";
			DatePicker.PropertyName = "AsDateTime";
			DatePicker.Size = new Size(96, 20);
			DatePicker.TabIndex = 0;
			label8.LoadingBegin();
			label8.FocusControl = TimePicker;
			label8.Location = new Point(24, 59);
			label8.Name = "label8";
			label8.Size = new Size(32, 15);
			label8.Text = "Time";
			label8.LoadingEnd();
			TimePicker.Format = DateTimePickerFormat.Time;
			TimePicker.Location = new Point(56, 56);
			TimePicker.Name = "TimePicker";
			TimePicker.PropertyName = "AsDateTime";
			TimePicker.ShowUpDown = true;
			TimePicker.Size = new Size(96, 20);
			TimePicker.TabIndex = 1;
			EventsEnabledCheckBox.Location = new Point(16, 112);
			EventsEnabledCheckBox.Name = "EventsEnabledCheckBox";
			EventsEnabledCheckBox.PropertyName = "EventsEnabled";
			EventsEnabledCheckBox.Size = new Size(112, 24);
			EventsEnabledCheckBox.TabIndex = 1;
			EventsEnabledCheckBox.Text = "Events Enabled";
			base.Controls.Add(EventsEnabledCheckBox);
			base.Controls.Add(groupBox1);
			base.Name = "ValueDateTimeEditorPlugIn";
			base.Size = new Size(424, 248);
			base.Title = "Value Date-Time Editor";
			groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
