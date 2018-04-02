using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotChannelBarSpecificEditorPlugIn : PlugInStandard
	{
		private EditBox ReferenceTextBox;

		private FocusLabel focusLabel7;

		private EditBox WidthTextBox;

		private FocusLabel focusLabel6;

		private FocusLabel label4;

		private ComboBox WidthStyleComboBox;

		private Container components;

		public PlotChannelBarSpecificEditorPlugIn()
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
			focusLabel7 = new FocusLabel();
			WidthTextBox = new EditBox();
			focusLabel6 = new FocusLabel();
			label4 = new FocusLabel();
			WidthStyleComboBox = new ComboBox();
			base.SuspendLayout();
			ReferenceTextBox.LoadingBegin();
			ReferenceTextBox.Location = new Point(96, 32);
			ReferenceTextBox.Name = "ReferenceTextBox";
			ReferenceTextBox.PropertyName = "Reference";
			ReferenceTextBox.Size = new Size(56, 20);
			ReferenceTextBox.TabIndex = 0;
			ReferenceTextBox.LoadingEnd();
			focusLabel7.LoadingBegin();
			focusLabel7.FocusControl = ReferenceTextBox;
			focusLabel7.Location = new Point(38, 34);
			focusLabel7.Name = "focusLabel7";
			focusLabel7.Size = new Size(58, 15);
			focusLabel7.Text = "Reference";
			focusLabel7.LoadingEnd();
			WidthTextBox.LoadingBegin();
			WidthTextBox.Location = new Point(96, 56);
			WidthTextBox.Name = "WidthTextBox";
			WidthTextBox.PropertyName = "Width";
			WidthTextBox.Size = new Size(56, 20);
			WidthTextBox.TabIndex = 1;
			WidthTextBox.LoadingEnd();
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = WidthTextBox;
			focusLabel6.Location = new Point(60, 58);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(36, 15);
			focusLabel6.Text = "Width";
			focusLabel6.LoadingEnd();
			label4.LoadingBegin();
			label4.FocusControl = WidthStyleComboBox;
			label4.Location = new Point(169, 58);
			label4.Name = "label4";
			label4.Size = new Size(63, 15);
			label4.Text = "Width Style";
			label4.LoadingEnd();
			WidthStyleComboBox.Location = new Point(232, 56);
			WidthStyleComboBox.Name = "WidthStyleComboBox";
			WidthStyleComboBox.PropertyName = "WidthStyle";
			WidthStyleComboBox.Size = new Size(121, 21);
			WidthStyleComboBox.TabIndex = 2;
			base.Controls.Add(label4);
			base.Controls.Add(WidthStyleComboBox);
			base.Controls.Add(ReferenceTextBox);
			base.Controls.Add(focusLabel7);
			base.Controls.Add(WidthTextBox);
			base.Controls.Add(focusLabel6);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelBarSpecificEditorPlugIn";
			base.Size = new Size(728, 328);
			base.ResumeLayout(false);
		}
	}
}
