using Iocomp.Design.Plugin.EditorControls;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotChannelDigitalSpecificEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox TerminatedCheckBox;

		private GroupBox groupBox1;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ReferenceStyleComboBox;

		private FocusLabel focusLabel9;

		private EditBox ReferenceHighTextBox;

		private EditBox ReferenceLowTextBox;

		private FocusLabel focusLabel7;

		private FocusLabel focusLabel6;

		private FocusLabel focusLabel1;

		private FocusLabel focusLabel2;

		private Container components;

		public PlotChannelDigitalSpecificEditorPlugIn()
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
			TerminatedCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			groupBox1 = new GroupBox();
			focusLabel2 = new FocusLabel();
			ReferenceHighTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			ReferenceLowTextBox = new EditBox();
			ReferenceStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel9 = new FocusLabel();
			focusLabel7 = new FocusLabel();
			focusLabel6 = new FocusLabel();
			groupBox1.SuspendLayout();
			base.SuspendLayout();
			TerminatedCheckBox.Location = new Point(32, 16);
			TerminatedCheckBox.Name = "TerminatedCheckBox";
			TerminatedCheckBox.PropertyName = "Terminated";
			TerminatedCheckBox.Size = new Size(96, 24);
			TerminatedCheckBox.TabIndex = 0;
			TerminatedCheckBox.Text = "Terminated";
			groupBox1.Controls.Add(focusLabel2);
			groupBox1.Controls.Add(focusLabel1);
			groupBox1.Controls.Add(ReferenceStyleComboBox);
			groupBox1.Controls.Add(focusLabel9);
			groupBox1.Controls.Add(ReferenceHighTextBox);
			groupBox1.Controls.Add(ReferenceLowTextBox);
			groupBox1.Controls.Add(focusLabel7);
			groupBox1.Controls.Add(focusLabel6);
			groupBox1.Location = new Point(32, 56);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(344, 104);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "Reference";
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = ReferenceHighTextBox;
			focusLabel2.FocusControlAlignment = AlignmentQuadSide.Right;
			focusLabel2.Location = new Point(104, 74);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(182, 15);
			focusLabel2.Text = "Use 0.0 to 1.0 when Style = Percent";
			focusLabel2.LoadingEnd();
			ReferenceHighTextBox.LoadingBegin();
			ReferenceHighTextBox.Location = new Point(48, 72);
			ReferenceHighTextBox.Name = "ReferenceHighTextBox";
			ReferenceHighTextBox.PropertyName = "ReferenceHigh";
			ReferenceHighTextBox.Size = new Size(56, 20);
			ReferenceHighTextBox.TabIndex = 2;
			ReferenceHighTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = ReferenceLowTextBox;
			focusLabel1.FocusControlAlignment = AlignmentQuadSide.Right;
			focusLabel1.Location = new Point(104, 50);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(182, 15);
			focusLabel1.Text = "Use 0.0 to 1.0 when Style = Percent";
			focusLabel1.LoadingEnd();
			ReferenceLowTextBox.LoadingBegin();
			ReferenceLowTextBox.Location = new Point(48, 48);
			ReferenceLowTextBox.Name = "ReferenceLowTextBox";
			ReferenceLowTextBox.PropertyName = "ReferenceLow";
			ReferenceLowTextBox.Size = new Size(56, 20);
			ReferenceLowTextBox.TabIndex = 1;
			ReferenceLowTextBox.LoadingEnd();
			ReferenceStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ReferenceStyleComboBox.Location = new Point(48, 24);
			ReferenceStyleComboBox.MaxDropDownItems = 20;
			ReferenceStyleComboBox.Name = "ReferenceStyleComboBox";
			ReferenceStyleComboBox.PropertyName = "ReferenceStyle";
			ReferenceStyleComboBox.Size = new Size(64, 21);
			ReferenceStyleComboBox.TabIndex = 0;
			focusLabel9.LoadingBegin();
			focusLabel9.FocusControl = ReferenceStyleComboBox;
			focusLabel9.Location = new Point(16, 26);
			focusLabel9.Name = "focusLabel9";
			focusLabel9.Size = new Size(32, 15);
			focusLabel9.Text = "Style";
			focusLabel9.LoadingEnd();
			focusLabel7.LoadingBegin();
			focusLabel7.FocusControl = ReferenceHighTextBox;
			focusLabel7.Location = new Point(18, 74);
			focusLabel7.Name = "focusLabel7";
			focusLabel7.Size = new Size(30, 15);
			focusLabel7.Text = "High";
			focusLabel7.LoadingEnd();
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = ReferenceLowTextBox;
			focusLabel6.Location = new Point(20, 50);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(28, 15);
			focusLabel6.Text = "Low";
			focusLabel6.LoadingEnd();
			base.Controls.Add(TerminatedCheckBox);
			base.Controls.Add(groupBox1);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelDigitalSpecificEditorPlugIn";
			base.Size = new Size(728, 328);
			groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
