using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ScaleGeneratorFixedEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox MidIncludedCheckBox;

		private FocusLabel label3;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MinorCountNumericUpDown;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MajorCountNumericUpDown;

		private Container components;

		public ScaleGeneratorFixedEditorPlugIn()
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
			MidIncludedCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			MinorCountNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label3 = new FocusLabel();
			label1 = new FocusLabel();
			MajorCountNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			base.SuspendLayout();
			MidIncludedCheckBox.Location = new Point(88, 8);
			MidIncludedCheckBox.Name = "MidIncludedCheckBox";
			MidIncludedCheckBox.PropertyName = "MidIncluded";
			MidIncludedCheckBox.Size = new Size(92, 24);
			MidIncludedCheckBox.TabIndex = 0;
			MidIncludedCheckBox.Text = "Mid Included";
			MinorCountNumericUpDown.Location = new Point(88, 48);
			MinorCountNumericUpDown.Name = "MinorCountNumericUpDown";
			MinorCountNumericUpDown.PropertyName = "MinorCount";
			MinorCountNumericUpDown.Size = new Size(56, 20);
			MinorCountNumericUpDown.TabIndex = 1;
			MinorCountNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label3.LoadingBegin();
			label3.FocusControl = MinorCountNumericUpDown;
			label3.Location = new Point(21, 49);
			label3.Name = "label3";
			label3.Size = new Size(67, 15);
			label3.Text = "Minor Count";
			label3.LoadingEnd();
			label1.LoadingBegin();
			label1.FocusControl = MajorCountNumericUpDown;
			label1.Location = new Point(21, 73);
			label1.Name = "label1";
			label1.Size = new Size(67, 15);
			label1.Text = "Major Count";
			label1.LoadingEnd();
			MajorCountNumericUpDown.Location = new Point(88, 72);
			MajorCountNumericUpDown.Minimum = new decimal(new int[4]
			{
				2,
				0,
				0,
				0
			});
			MajorCountNumericUpDown.Name = "MajorCountNumericUpDown";
			MajorCountNumericUpDown.PropertyName = "MajorCount";
			MajorCountNumericUpDown.Size = new Size(56, 20);
			MajorCountNumericUpDown.TabIndex = 2;
			MajorCountNumericUpDown.TextAlign = HorizontalAlignment.Center;
			base.Controls.Add(MajorCountNumericUpDown);
			base.Controls.Add(MinorCountNumericUpDown);
			base.Controls.Add(MidIncludedCheckBox);
			base.Controls.Add(label1);
			base.Controls.Add(label3);
			base.Name = "ScaleGeneratorFixedEditorPlugIn";
			base.Size = new Size(536, 296);
			base.Title = "Generator Fixed Editor";
			base.ResumeLayout(false);
		}
	}
}
