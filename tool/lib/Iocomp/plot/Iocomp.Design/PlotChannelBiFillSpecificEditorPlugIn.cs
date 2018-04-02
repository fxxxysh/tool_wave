using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotChannelBiFillSpecificEditorPlugIn : PlugInStandard
	{
		private EditBox ReferenceTextBox;

		private FocusLabel focusLabel6;

		private Container components;

		public PlotChannelBiFillSpecificEditorPlugIn()
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
			ReferenceTextBox = new EditBox();
			focusLabel6 = new FocusLabel();
			base.SuspendLayout();
			ReferenceTextBox.LoadingBegin();
			ReferenceTextBox.Location = new Point(96, 32);
			ReferenceTextBox.Name = "ReferenceTextBox";
			ReferenceTextBox.PropertyName = "Reference";
			ReferenceTextBox.Size = new Size(56, 20);
			ReferenceTextBox.TabIndex = 0;
			ReferenceTextBox.LoadingEnd();
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = ReferenceTextBox;
			focusLabel6.Location = new Point(38, 34);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(58, 15);
			focusLabel6.Text = "Reference";
			focusLabel6.LoadingEnd();
			base.Controls.Add(ReferenceTextBox);
			base.Controls.Add(focusLabel6);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelBiFillSpecificEditorPlugIn";
			base.Size = new Size(728, 328);
			base.ResumeLayout(false);
		}
	}
}
