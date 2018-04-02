using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotChannelSweepIntervalSpecificEditorPlugIn : PlugInStandard
	{
		private GroupBox groupBox3;

		private Iocomp.Design.Plugin.EditorControls.CheckBox SweepYDefaultNullCheckBox;

		private EditBox SweepYDefaultValueTextBox;

		private FocusLabel focusLabel12;

		private GroupBox groupBox2;

		private EditBox SweepXIntervalTextBox;

		private FocusLabel focusLabel9;

		private EditBox SweepXStartTextBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown SweepLeadingBreakCountUpDown;

		private FocusLabel focusLabel10;

		private EditBox SweepCountTextBox;

		private FocusLabel focusLabel7;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ClearOnRetraceCheckBox;

		private Container components;

		public PlotChannelSweepIntervalSpecificEditorPlugIn()
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
			groupBox3 = new GroupBox();
			SweepYDefaultNullCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			SweepYDefaultValueTextBox = new EditBox();
			focusLabel12 = new FocusLabel();
			groupBox2 = new GroupBox();
			SweepXIntervalTextBox = new EditBox();
			focusLabel9 = new FocusLabel();
			SweepXStartTextBox = new EditBox();
			focusLabel8 = new FocusLabel();
			SweepLeadingBreakCountUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			focusLabel10 = new FocusLabel();
			SweepCountTextBox = new EditBox();
			focusLabel7 = new FocusLabel();
			ClearOnRetraceCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			groupBox3.SuspendLayout();
			groupBox2.SuspendLayout();
			base.SuspendLayout();
			groupBox3.Controls.Add(SweepYDefaultNullCheckBox);
			groupBox3.Controls.Add(SweepYDefaultValueTextBox);
			groupBox3.Controls.Add(focusLabel12);
			groupBox3.Location = new Point(168, 128);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(128, 80);
			groupBox3.TabIndex = 4;
			groupBox3.TabStop = false;
			groupBox3.Text = "Y-Default";
			SweepYDefaultNullCheckBox.Location = new Point(48, 48);
			SweepYDefaultNullCheckBox.Name = "SweepYDefaultNullCheckBox";
			SweepYDefaultNullCheckBox.PropertyName = "SweepYDefaultNull";
			SweepYDefaultNullCheckBox.Size = new Size(48, 24);
			SweepYDefaultNullCheckBox.TabIndex = 1;
			SweepYDefaultNullCheckBox.Text = "Null";
			SweepYDefaultValueTextBox.LoadingBegin();
			SweepYDefaultValueTextBox.Location = new Point(48, 24);
			SweepYDefaultValueTextBox.Name = "SweepYDefaultValueTextBox";
			SweepYDefaultValueTextBox.PropertyName = "SweepYDefaultValue";
			SweepYDefaultValueTextBox.Size = new Size(64, 20);
			SweepYDefaultValueTextBox.TabIndex = 0;
			SweepYDefaultValueTextBox.LoadingEnd();
			focusLabel12.LoadingBegin();
			focusLabel12.FocusControl = SweepYDefaultValueTextBox;
			focusLabel12.Location = new Point(12, 26);
			focusLabel12.Name = "focusLabel12";
			focusLabel12.Size = new Size(36, 15);
			focusLabel12.Text = "Value";
			focusLabel12.LoadingEnd();
			groupBox2.Controls.Add(SweepXIntervalTextBox);
			groupBox2.Controls.Add(focusLabel9);
			groupBox2.Controls.Add(SweepXStartTextBox);
			groupBox2.Controls.Add(focusLabel8);
			groupBox2.Location = new Point(24, 128);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(128, 80);
			groupBox2.TabIndex = 3;
			groupBox2.TabStop = false;
			groupBox2.Text = "X";
			SweepXIntervalTextBox.LoadingBegin();
			SweepXIntervalTextBox.Location = new Point(48, 48);
			SweepXIntervalTextBox.Name = "SweepXIntervalTextBox";
			SweepXIntervalTextBox.PropertyName = "SweepXInterval";
			SweepXIntervalTextBox.Size = new Size(64, 20);
			SweepXIntervalTextBox.TabIndex = 1;
			SweepXIntervalTextBox.LoadingEnd();
			focusLabel9.LoadingBegin();
			focusLabel9.FocusControl = SweepXIntervalTextBox;
			focusLabel9.Location = new Point(4, 50);
			focusLabel9.Name = "focusLabel9";
			focusLabel9.Size = new Size(44, 15);
			focusLabel9.Text = "Interval";
			focusLabel9.LoadingEnd();
			SweepXStartTextBox.LoadingBegin();
			SweepXStartTextBox.Location = new Point(48, 24);
			SweepXStartTextBox.Name = "SweepXStartTextBox";
			SweepXStartTextBox.PropertyName = "SweepXStart";
			SweepXStartTextBox.Size = new Size(64, 20);
			SweepXStartTextBox.TabIndex = 0;
			SweepXStartTextBox.LoadingEnd();
			focusLabel8.LoadingBegin();
			focusLabel8.FocusControl = SweepXStartTextBox;
			focusLabel8.Location = new Point(17, 26);
			focusLabel8.Name = "focusLabel8";
			focusLabel8.Size = new Size(31, 15);
			focusLabel8.Text = "Start";
			focusLabel8.LoadingEnd();
			SweepLeadingBreakCountUpDown.Location = new Point(128, 64);
			SweepLeadingBreakCountUpDown.Name = "SweepLeadingBreakCountUpDown";
			SweepLeadingBreakCountUpDown.PropertyName = "SweepLeadingBreakCount";
			SweepLeadingBreakCountUpDown.Size = new Size(64, 20);
			SweepLeadingBreakCountUpDown.TabIndex = 1;
			SweepLeadingBreakCountUpDown.TextAlign = HorizontalAlignment.Center;
			focusLabel10.LoadingBegin();
			focusLabel10.FocusControl = SweepLeadingBreakCountUpDown;
			focusLabel10.Location = new Point(17, 65);
			focusLabel10.Name = "focusLabel10";
			focusLabel10.Size = new Size(111, 15);
			focusLabel10.Text = "Leading Break Count";
			focusLabel10.LoadingEnd();
			SweepCountTextBox.LoadingBegin();
			SweepCountTextBox.Location = new Point(128, 32);
			SweepCountTextBox.Name = "SweepCountTextBox";
			SweepCountTextBox.PropertyName = "SweepCount";
			SweepCountTextBox.Size = new Size(64, 20);
			SweepCountTextBox.TabIndex = 0;
			SweepCountTextBox.LoadingEnd();
			focusLabel7.LoadingBegin();
			focusLabel7.FocusControl = SweepCountTextBox;
			focusLabel7.Location = new Point(91, 34);
			focusLabel7.Name = "focusLabel7";
			focusLabel7.Size = new Size(37, 15);
			focusLabel7.Text = "Count";
			focusLabel7.LoadingEnd();
			ClearOnRetraceCheckBox.Location = new Point(128, 88);
			ClearOnRetraceCheckBox.Name = "ClearOnRetraceCheckBox";
			ClearOnRetraceCheckBox.PropertyName = "ClearOnRetrace";
			ClearOnRetraceCheckBox.Size = new Size(156, 24);
			ClearOnRetraceCheckBox.TabIndex = 2;
			ClearOnRetraceCheckBox.Text = "Clear On Retrace";
			base.Controls.Add(ClearOnRetraceCheckBox);
			base.Controls.Add(groupBox3);
			base.Controls.Add(groupBox2);
			base.Controls.Add(SweepLeadingBreakCountUpDown);
			base.Controls.Add(focusLabel10);
			base.Controls.Add(SweepCountTextBox);
			base.Controls.Add(focusLabel7);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelSweepIntervalSpecificEditorPlugIn";
			base.Size = new Size(728, 328);
			groupBox3.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
