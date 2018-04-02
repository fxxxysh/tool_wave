using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public sealed class ScaleGeneratorAutoEditorPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox MidIncludedCheckBox;

		private FocusLabel label3;

		private EditBox DesiredIncrementTextBox;

		private EditBox MinTextSpacingTextBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MinorCountNumericUpDown;

		private DoubleEditButton DesiredIncrementDoubleEditButton;

		private Iocomp.Design.Plugin.EditorControls.CheckBox FixedMinMaxMajorsCheckBox;

		private Container components;

		public ScaleGeneratorAutoEditorPlugIn()
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
			DesiredIncrementTextBox = new EditBox();
			label2 = new FocusLabel();
			MinTextSpacingTextBox = new EditBox();
			label1 = new FocusLabel();
			MidIncludedCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			MinorCountNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label3 = new FocusLabel();
			DesiredIncrementDoubleEditButton = new DoubleEditButton();
			FixedMinMaxMajorsCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			((ISupportInitialize)MinorCountNumericUpDown).BeginInit();
			base.SuspendLayout();
			DesiredIncrementTextBox.LoadingBegin();
			DesiredIncrementTextBox.Location = new Point(120, 104);
			DesiredIncrementTextBox.Name = "DesiredIncrementTextBox";
			DesiredIncrementTextBox.PropertyName = "DesiredIncrement";
			DesiredIncrementTextBox.Size = new Size(104, 20);
			DesiredIncrementTextBox.TabIndex = 4;
			DesiredIncrementTextBox.TextAlign = HorizontalAlignment.Center;
			DesiredIncrementTextBox.LoadingEnd();
			label2.LoadingBegin();
			label2.FocusControl = DesiredIncrementTextBox;
			label2.Location = new Point(23, 106);
			label2.Name = "label2";
			label2.Size = new Size(97, 15);
			label2.Text = "Desired Increment";
			label2.LoadingEnd();
			MinTextSpacingTextBox.LoadingBegin();
			MinTextSpacingTextBox.Location = new Point(120, 80);
			MinTextSpacingTextBox.Name = "MinTextSpacingTextBox";
			MinTextSpacingTextBox.PropertyName = "MinTextSpacing";
			MinTextSpacingTextBox.Size = new Size(56, 20);
			MinTextSpacingTextBox.TabIndex = 3;
			MinTextSpacingTextBox.TextAlign = HorizontalAlignment.Center;
			MinTextSpacingTextBox.LoadingEnd();
			label1.LoadingBegin();
			label1.FocusControl = MinTextSpacingTextBox;
			label1.Location = new Point(28, 82);
			label1.Name = "label1";
			label1.Size = new Size(92, 15);
			label1.Text = "Min Text Spacing";
			label1.LoadingEnd();
			MidIncludedCheckBox.Location = new Point(120, 0);
			MidIncludedCheckBox.Name = "MidIncludedCheckBox";
			MidIncludedCheckBox.PropertyName = "MidIncluded";
			MidIncludedCheckBox.Size = new Size(92, 24);
			MidIncludedCheckBox.TabIndex = 0;
			MidIncludedCheckBox.Text = "Mid Included";
			MinorCountNumericUpDown.Location = new Point(120, 56);
			MinorCountNumericUpDown.Name = "MinorCountNumericUpDown";
			MinorCountNumericUpDown.PropertyName = "MinorCount";
			MinorCountNumericUpDown.Size = new Size(56, 20);
			MinorCountNumericUpDown.TabIndex = 2;
			MinorCountNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label3.LoadingBegin();
			label3.FocusControl = MinorCountNumericUpDown;
			label3.Location = new Point(53, 57);
			label3.Name = "label3";
			label3.Size = new Size(67, 15);
			label3.Text = "Minor Count";
			label3.LoadingEnd();
			DesiredIncrementDoubleEditButton.EditBox = DesiredIncrementTextBox;
			DesiredIncrementDoubleEditButton.Location = new Point(224, 102);
			DesiredIncrementDoubleEditButton.Name = "DesiredIncrementDoubleEditButton";
			DesiredIncrementDoubleEditButton.TabIndex = 5;
			FixedMinMaxMajorsCheckBox.Location = new Point(120, 24);
			FixedMinMaxMajorsCheckBox.Name = "FixedMinMaxMajorsCheckBox";
			FixedMinMaxMajorsCheckBox.PropertyName = "FixedMinMaxMajors";
			FixedMinMaxMajorsCheckBox.Size = new Size(144, 24);
			FixedMinMaxMajorsCheckBox.TabIndex = 0;
			FixedMinMaxMajorsCheckBox.Text = "Fixed Min/Max Majors";
			base.Controls.Add(FixedMinMaxMajorsCheckBox);
			base.Controls.Add(DesiredIncrementDoubleEditButton);
			base.Controls.Add(MinorCountNumericUpDown);
			base.Controls.Add(MidIncludedCheckBox);
			base.Controls.Add(MinTextSpacingTextBox);
			base.Controls.Add(DesiredIncrementTextBox);
			base.Controls.Add(label3);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Name = "ScaleGeneratorAutoEditorPlugIn";
			base.Size = new Size(496, 160);
			base.Title = "Generator Auto Editor";
			((ISupportInitialize)MinorCountNumericUpDown).EndInit();
			base.ResumeLayout(false);
		}
	}
}
