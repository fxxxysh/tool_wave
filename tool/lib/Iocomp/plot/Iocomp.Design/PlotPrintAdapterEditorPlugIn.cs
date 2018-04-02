using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotPrintAdapterEditorPlugIn : PlugInStandard
	{
		private FocusLabel label3;

		private EditBox DocumentNameTextBox;

		private GroupBox MarginGroupBox;

		private EditBox MarginLeftEditBox;

		private EditBox MarginTopEditBox;

		private EditBox MarginRightEditBox;

		private EditBox MarginBottomEditBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ShowPrintDialogCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox SizingStyleComboBox;

		private FocusLabel focusLabel1;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.ComboBox OrientationComboBox;

		private Container components;

		public PlotPrintAdapterEditorPlugIn()
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
			DocumentNameTextBox = new EditBox();
			label3 = new FocusLabel();
			MarginGroupBox = new GroupBox();
			MarginBottomEditBox = new EditBox();
			MarginRightEditBox = new EditBox();
			MarginTopEditBox = new EditBox();
			MarginLeftEditBox = new EditBox();
			ShowPrintDialogCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			SizingStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel1 = new FocusLabel();
			focusLabel2 = new FocusLabel();
			OrientationComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			MarginGroupBox.SuspendLayout();
			base.SuspendLayout();
			DocumentNameTextBox.LoadingBegin();
			DocumentNameTextBox.Location = new Point(104, 112);
			DocumentNameTextBox.Name = "DocumentNameTextBox";
			DocumentNameTextBox.PropertyName = "DocumentName";
			DocumentNameTextBox.Size = new Size(189, 20);
			DocumentNameTextBox.TabIndex = 3;
			DocumentNameTextBox.LoadingEnd();
			label3.LoadingBegin();
			label3.FocusControl = DocumentNameTextBox;
			label3.Location = new Point(14, 114);
			label3.Name = "label3";
			label3.Size = new Size(90, 15);
			label3.Text = "Document Name";
			label3.LoadingEnd();
			MarginGroupBox.Controls.Add(MarginBottomEditBox);
			MarginGroupBox.Controls.Add(MarginRightEditBox);
			MarginGroupBox.Controls.Add(MarginTopEditBox);
			MarginGroupBox.Controls.Add(MarginLeftEditBox);
			MarginGroupBox.Location = new Point(104, 144);
			MarginGroupBox.Name = "MarginGroupBox";
			MarginGroupBox.Size = new Size(192, 120);
			MarginGroupBox.TabIndex = 4;
			MarginGroupBox.TabStop = false;
			MarginGroupBox.Text = "Margin";
			MarginBottomEditBox.LoadingBegin();
			MarginBottomEditBox.Location = new Point(72, 88);
			MarginBottomEditBox.Name = "MarginBottomEditBox";
			MarginBottomEditBox.PropertyName = "MarginBottom";
			MarginBottomEditBox.Size = new Size(48, 20);
			MarginBottomEditBox.TabIndex = 3;
			MarginBottomEditBox.TextAlign = HorizontalAlignment.Center;
			MarginBottomEditBox.LoadingEnd();
			MarginRightEditBox.LoadingBegin();
			MarginRightEditBox.Location = new Point(120, 56);
			MarginRightEditBox.Name = "MarginRightEditBox";
			MarginRightEditBox.PropertyName = "MarginRight";
			MarginRightEditBox.Size = new Size(48, 20);
			MarginRightEditBox.TabIndex = 2;
			MarginRightEditBox.TextAlign = HorizontalAlignment.Center;
			MarginRightEditBox.LoadingEnd();
			MarginTopEditBox.LoadingBegin();
			MarginTopEditBox.Location = new Point(72, 24);
			MarginTopEditBox.Name = "MarginTopEditBox";
			MarginTopEditBox.PropertyName = "MarginTop";
			MarginTopEditBox.Size = new Size(48, 20);
			MarginTopEditBox.TabIndex = 0;
			MarginTopEditBox.TextAlign = HorizontalAlignment.Center;
			MarginTopEditBox.LoadingEnd();
			MarginLeftEditBox.LoadingBegin();
			MarginLeftEditBox.Location = new Point(24, 56);
			MarginLeftEditBox.Name = "MarginLeftEditBox";
			MarginLeftEditBox.PropertyName = "MarginLeft";
			MarginLeftEditBox.Size = new Size(48, 20);
			MarginLeftEditBox.TabIndex = 1;
			MarginLeftEditBox.TextAlign = HorizontalAlignment.Center;
			MarginLeftEditBox.LoadingEnd();
			ShowPrintDialogCheckBox.Location = new Point(104, 24);
			ShowPrintDialogCheckBox.Name = "ShowPrintDialogCheckBox";
			ShowPrintDialogCheckBox.PropertyName = "ShowPrintDialog";
			ShowPrintDialogCheckBox.Size = new Size(136, 24);
			ShowPrintDialogCheckBox.TabIndex = 0;
			ShowPrintDialogCheckBox.Text = "Show Print Dialog";
			SizingStyleComboBox.Location = new Point(104, 80);
			SizingStyleComboBox.Name = "SizingStyleComboBox";
			SizingStyleComboBox.PropertyName = "SizingStyle";
			SizingStyleComboBox.Size = new Size(121, 21);
			SizingStyleComboBox.TabIndex = 2;
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = SizingStyleComboBox;
			focusLabel1.Location = new Point(39, 82);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(65, 15);
			focusLabel1.Text = "Sizing Style";
			focusLabel1.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = OrientationComboBox;
			focusLabel2.Location = new Point(43, 58);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(61, 15);
			focusLabel2.Text = "Orientation";
			focusLabel2.LoadingEnd();
			OrientationComboBox.Location = new Point(104, 56);
			OrientationComboBox.Name = "OrientationComboBox";
			OrientationComboBox.PropertyName = "Orientation";
			OrientationComboBox.Size = new Size(121, 21);
			OrientationComboBox.TabIndex = 1;
			base.Controls.Add(focusLabel2);
			base.Controls.Add(OrientationComboBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(SizingStyleComboBox);
			base.Controls.Add(ShowPrintDialogCheckBox);
			base.Controls.Add(MarginGroupBox);
			base.Controls.Add(DocumentNameTextBox);
			base.Controls.Add(label3);
			base.Name = "PlotPrintAdapterEditorPlugIn";
			base.Size = new Size(424, 288);
			MarginGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
