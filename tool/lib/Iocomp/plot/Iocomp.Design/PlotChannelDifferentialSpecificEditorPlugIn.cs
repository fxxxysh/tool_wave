using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotChannelDifferentialSpecificEditorPlugIn : PlugInStandard
	{
		private CheckBox TerminatedCheckBox;

		private EditBox ReferenceTextBox;

		private FocusLabel focusLabel6;

		private Container components;

		public PlotChannelDifferentialSpecificEditorPlugIn()
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
			TerminatedCheckBox = new CheckBox();
			ReferenceTextBox = new EditBox();
			focusLabel6 = new FocusLabel();
			base.SuspendLayout();
			TerminatedCheckBox.Location = new Point(88, 16);
			TerminatedCheckBox.Name = "TerminatedCheckBox";
			TerminatedCheckBox.PropertyName = "Terminated";
			TerminatedCheckBox.Size = new Size(96, 24);
			TerminatedCheckBox.TabIndex = 0;
			TerminatedCheckBox.Text = "Terminated";
			ReferenceTextBox.LoadingBegin();
			ReferenceTextBox.Location = new Point(88, 48);
			ReferenceTextBox.Name = "ReferenceTextBox";
			ReferenceTextBox.PropertyName = "Reference";
			ReferenceTextBox.Size = new Size(56, 20);
			ReferenceTextBox.TabIndex = 1;
			ReferenceTextBox.LoadingEnd();
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = ReferenceTextBox;
			focusLabel6.Location = new Point(30, 50);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(58, 15);
			focusLabel6.Text = "Reference";
			focusLabel6.LoadingEnd();
			base.Controls.Add(TerminatedCheckBox);
			base.Controls.Add(ReferenceTextBox);
			base.Controls.Add(focusLabel6);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelDifferentialSpecificEditorPlugIn";
			base.Size = new Size(512, 200);
			base.ResumeLayout(false);
		}
	}
}
