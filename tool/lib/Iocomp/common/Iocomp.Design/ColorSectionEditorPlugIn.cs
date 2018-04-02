using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ColorSectionEditorPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private FocusLabel label4;

		private EditBox StartTextBox;

		private EditBox StopTextBox;

		private CheckBox VisibleCheckBox;

		private FocusLabel label1;

		private ColorPicker ColorPicker;

		private Container components;

		public ColorSectionEditorPlugIn()
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
			StartTextBox = new EditBox();
			label2 = new FocusLabel();
			ColorPicker = new ColorPicker();
			label4 = new FocusLabel();
			StopTextBox = new EditBox();
			VisibleCheckBox = new CheckBox();
			label1 = new FocusLabel();
			base.SuspendLayout();
			StartTextBox.LoadingBegin();
			StartTextBox.Location = new Point(72, 72);
			StartTextBox.Name = "StartTextBox";
			StartTextBox.PropertyName = "Start";
			StartTextBox.Size = new Size(48, 20);
			StartTextBox.TabIndex = 2;
			StartTextBox.LoadingEnd();
			label2.LoadingBegin();
			label2.FocusControl = StartTextBox;
			label2.Location = new Point(41, 74);
			label2.Name = "label2";
			label2.Size = new Size(31, 15);
			label2.Text = "Start";
			label2.LoadingEnd();
			ColorPicker.Location = new Point(72, 40);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(144, 21);
			ColorPicker.TabIndex = 1;
			label4.LoadingBegin();
			label4.FocusControl = ColorPicker;
			label4.Location = new Point(38, 43);
			label4.Name = "label4";
			label4.Size = new Size(34, 15);
			label4.Text = "Color";
			label4.LoadingEnd();
			StopTextBox.LoadingBegin();
			StopTextBox.Location = new Point(72, 96);
			StopTextBox.Name = "StopTextBox";
			StopTextBox.PropertyName = "Stop";
			StopTextBox.Size = new Size(48, 20);
			StopTextBox.TabIndex = 3;
			StopTextBox.LoadingEnd();
			VisibleCheckBox.Location = new Point(72, 8);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			label1.LoadingBegin();
			label1.FocusControl = StopTextBox;
			label1.Location = new Point(42, 98);
			label1.Name = "label1";
			label1.Size = new Size(30, 15);
			label1.Text = "Stop";
			label1.LoadingEnd();
			base.Controls.Add(label1);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(StopTextBox);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(StartTextBox);
			base.Controls.Add(label2);
			base.Controls.Add(label4);
			base.Name = "ColorSectionEditorPlugIn";
			base.Size = new Size(232, 328);
			base.ResumeLayout(false);
		}
	}
}
