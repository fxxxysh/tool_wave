using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotChannelImageSpecificEditorPlugIn : PlugInStandard
	{
		private GroupBox ImageXGroupBox;

		private FocusLabel focusLabel7;

		private GroupBox ImageYGroupBox;

		private FocusLabel focusLabel5;

		private FocusLabel focusLabel6;

		private EditBox ImageXSpanEditBox;

		private FocusLabel focusLabel2;

		private EditBox ImageXMinEditBox;

		private FocusLabel focusLabel1;

		private FocusLabel focusLabel8;

		private EditBox ImageYSpanEditBox;

		private FocusLabel focusLabel3;

		private EditBox ImageYMinEditBox;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ImageXAutoSetupCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ImageYAutoSetupCheckBox;

		private EditBox ImageXSpanSamplesEditBox;

		private EditBox ImageXSamplesTextBox;

		private EditBox ImageYSpanSamplesEditBox;

		private EditBox ImageYSamplesTextBox;

		private Container components;

		public PlotChannelImageSpecificEditorPlugIn()
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
			ImageXGroupBox = new GroupBox();
			ImageXAutoSetupCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			ImageXSpanSamplesEditBox = new EditBox();
			focusLabel6 = new FocusLabel();
			ImageXSpanEditBox = new EditBox();
			focusLabel2 = new FocusLabel();
			ImageXMinEditBox = new EditBox();
			focusLabel1 = new FocusLabel();
			ImageXSamplesTextBox = new EditBox();
			focusLabel7 = new FocusLabel();
			ImageYGroupBox = new GroupBox();
			ImageYAutoSetupCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			ImageYSpanSamplesEditBox = new EditBox();
			focusLabel8 = new FocusLabel();
			ImageYSpanEditBox = new EditBox();
			focusLabel3 = new FocusLabel();
			ImageYMinEditBox = new EditBox();
			focusLabel4 = new FocusLabel();
			ImageYSamplesTextBox = new EditBox();
			focusLabel5 = new FocusLabel();
			ImageXGroupBox.SuspendLayout();
			ImageYGroupBox.SuspendLayout();
			base.SuspendLayout();
			ImageXGroupBox.Controls.Add(ImageXAutoSetupCheckBox);
			ImageXGroupBox.Controls.Add(ImageXSpanSamplesEditBox);
			ImageXGroupBox.Controls.Add(focusLabel6);
			ImageXGroupBox.Controls.Add(ImageXSpanEditBox);
			ImageXGroupBox.Controls.Add(focusLabel2);
			ImageXGroupBox.Controls.Add(ImageXMinEditBox);
			ImageXGroupBox.Controls.Add(focusLabel1);
			ImageXGroupBox.Controls.Add(ImageXSamplesTextBox);
			ImageXGroupBox.Controls.Add(focusLabel7);
			ImageXGroupBox.Location = new Point(16, 16);
			ImageXGroupBox.Name = "ImageXGroupBox";
			ImageXGroupBox.Size = new Size(160, 168);
			ImageXGroupBox.TabIndex = 0;
			ImageXGroupBox.TabStop = false;
			ImageXGroupBox.Text = "X";
			ImageXAutoSetupCheckBox.Location = new Point(24, 24);
			ImageXAutoSetupCheckBox.Name = "ImageXAutoSetupCheckBox";
			ImageXAutoSetupCheckBox.PropertyName = "ImageXAutoSetup";
			ImageXAutoSetupCheckBox.TabIndex = 0;
			ImageXAutoSetupCheckBox.Text = "Auto Setup";
			ImageXSpanSamplesEditBox.LoadingBegin();
			ImageXSpanSamplesEditBox.Location = new Point(80, 88);
			ImageXSpanSamplesEditBox.Name = "ImageXSpanSamplesEditBox";
			ImageXSpanSamplesEditBox.PropertyName = "ImageXSpanSamples";
			ImageXSpanSamplesEditBox.Size = new Size(56, 20);
			ImageXSpanSamplesEditBox.TabIndex = 2;
			ImageXSpanSamplesEditBox.LoadingEnd();
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = ImageXSpanSamplesEditBox;
			focusLabel6.Location = new Point(1, 90);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(79, 15);
			focusLabel6.Text = "Span Samples";
			focusLabel6.LoadingEnd();
			ImageXSpanEditBox.LoadingBegin();
			ImageXSpanEditBox.Location = new Point(80, 112);
			ImageXSpanEditBox.Name = "ImageXSpanEditBox";
			ImageXSpanEditBox.PropertyName = "ImageXSpan";
			ImageXSpanEditBox.Size = new Size(56, 20);
			ImageXSpanEditBox.TabIndex = 3;
			ImageXSpanEditBox.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = ImageXSpanEditBox;
			focusLabel2.Location = new Point(47, 114);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(33, 15);
			focusLabel2.Text = "Span";
			focusLabel2.LoadingEnd();
			ImageXMinEditBox.LoadingBegin();
			ImageXMinEditBox.Location = new Point(80, 136);
			ImageXMinEditBox.Name = "ImageXMinEditBox";
			ImageXMinEditBox.PropertyName = "ImageXMin";
			ImageXMinEditBox.Size = new Size(56, 20);
			ImageXMinEditBox.TabIndex = 4;
			ImageXMinEditBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = ImageXMinEditBox;
			focusLabel1.Location = new Point(55, 138);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(25, 15);
			focusLabel1.Text = "Min";
			focusLabel1.LoadingEnd();
			ImageXSamplesTextBox.LoadingBegin();
			ImageXSamplesTextBox.Location = new Point(80, 56);
			ImageXSamplesTextBox.Name = "ImageXSamplesTextBox";
			ImageXSamplesTextBox.PropertyName = "ImageXSamples";
			ImageXSamplesTextBox.Size = new Size(56, 20);
			ImageXSamplesTextBox.TabIndex = 1;
			ImageXSamplesTextBox.LoadingEnd();
			focusLabel7.LoadingBegin();
			focusLabel7.FocusControl = ImageXSamplesTextBox;
			focusLabel7.Location = new Point(30, 58);
			focusLabel7.Name = "focusLabel7";
			focusLabel7.Size = new Size(50, 15);
			focusLabel7.Text = "Samples";
			focusLabel7.LoadingEnd();
			ImageYGroupBox.Controls.Add(ImageYAutoSetupCheckBox);
			ImageYGroupBox.Controls.Add(ImageYSpanSamplesEditBox);
			ImageYGroupBox.Controls.Add(focusLabel8);
			ImageYGroupBox.Controls.Add(ImageYSpanEditBox);
			ImageYGroupBox.Controls.Add(focusLabel3);
			ImageYGroupBox.Controls.Add(ImageYMinEditBox);
			ImageYGroupBox.Controls.Add(focusLabel4);
			ImageYGroupBox.Controls.Add(ImageYSamplesTextBox);
			ImageYGroupBox.Controls.Add(focusLabel5);
			ImageYGroupBox.Location = new Point(192, 16);
			ImageYGroupBox.Name = "ImageYGroupBox";
			ImageYGroupBox.Size = new Size(160, 168);
			ImageYGroupBox.TabIndex = 1;
			ImageYGroupBox.TabStop = false;
			ImageYGroupBox.Text = "Y";
			ImageYAutoSetupCheckBox.Location = new Point(24, 24);
			ImageYAutoSetupCheckBox.Name = "ImageYAutoSetupCheckBox";
			ImageYAutoSetupCheckBox.PropertyName = "ImageYAutoSetup";
			ImageYAutoSetupCheckBox.TabIndex = 0;
			ImageYAutoSetupCheckBox.Text = "Auto Setup";
			ImageYSpanSamplesEditBox.LoadingBegin();
			ImageYSpanSamplesEditBox.Location = new Point(80, 88);
			ImageYSpanSamplesEditBox.Name = "ImageYSpanSamplesEditBox";
			ImageYSpanSamplesEditBox.PropertyName = "ImageYSpanSamples";
			ImageYSpanSamplesEditBox.Size = new Size(56, 20);
			ImageYSpanSamplesEditBox.TabIndex = 2;
			ImageYSpanSamplesEditBox.LoadingEnd();
			focusLabel8.LoadingBegin();
			focusLabel8.FocusControl = ImageYSpanSamplesEditBox;
			focusLabel8.Location = new Point(1, 90);
			focusLabel8.Name = "focusLabel8";
			focusLabel8.Size = new Size(79, 15);
			focusLabel8.Text = "Span Samples";
			focusLabel8.LoadingEnd();
			ImageYSpanEditBox.LoadingBegin();
			ImageYSpanEditBox.Location = new Point(80, 112);
			ImageYSpanEditBox.Name = "ImageYSpanEditBox";
			ImageYSpanEditBox.PropertyName = "ImageYSpan";
			ImageYSpanEditBox.Size = new Size(56, 20);
			ImageYSpanEditBox.TabIndex = 3;
			ImageYSpanEditBox.LoadingEnd();
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = ImageYSpanEditBox;
			focusLabel3.Location = new Point(47, 114);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(33, 15);
			focusLabel3.Text = "Span";
			focusLabel3.LoadingEnd();
			ImageYMinEditBox.LoadingBegin();
			ImageYMinEditBox.Location = new Point(80, 136);
			ImageYMinEditBox.Name = "ImageYMinEditBox";
			ImageYMinEditBox.PropertyName = "ImageYMin";
			ImageYMinEditBox.Size = new Size(56, 20);
			ImageYMinEditBox.TabIndex = 4;
			ImageYMinEditBox.LoadingEnd();
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = ImageYMinEditBox;
			focusLabel4.Location = new Point(55, 138);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(25, 15);
			focusLabel4.Text = "Min";
			focusLabel4.LoadingEnd();
			ImageYSamplesTextBox.LoadingBegin();
			ImageYSamplesTextBox.Location = new Point(80, 56);
			ImageYSamplesTextBox.Name = "ImageYSamplesTextBox";
			ImageYSamplesTextBox.PropertyName = "ImageYSamples";
			ImageYSamplesTextBox.Size = new Size(56, 20);
			ImageYSamplesTextBox.TabIndex = 1;
			ImageYSamplesTextBox.LoadingEnd();
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = ImageYSamplesTextBox;
			focusLabel5.Location = new Point(30, 58);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(50, 15);
			focusLabel5.Text = "Samples";
			focusLabel5.LoadingEnd();
			base.Controls.Add(ImageYGroupBox);
			base.Controls.Add(ImageXGroupBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelImageSpecificEditorPlugIn";
			base.Size = new Size(400, 240);
			ImageXGroupBox.ResumeLayout(false);
			ImageYGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
