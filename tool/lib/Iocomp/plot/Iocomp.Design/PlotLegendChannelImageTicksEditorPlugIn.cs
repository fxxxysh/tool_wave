using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotLegendChannelImageTicksEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel1;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox TicksVisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown TicksLengthNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown TicksMarginNumericUpDown;

		private FocusLabel focusLabel2;

		private EditBox TicksLabelMarginTextBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox TicksShowFirstAndLastOnlyCheckBox;

		private Container components;

		public PlotLegendChannelImageTicksEditorPlugIn()
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
			TicksVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			TicksLabelMarginTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			TicksLengthNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label1 = new FocusLabel();
			TicksMarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			focusLabel2 = new FocusLabel();
			TicksShowFirstAndLastOnlyCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			TicksVisibleCheckBox.Location = new Point(192, 32);
			TicksVisibleCheckBox.Name = "TicksVisibleCheckBox";
			TicksVisibleCheckBox.PropertyName = "TicksVisible";
			TicksVisibleCheckBox.Size = new Size(72, 24);
			TicksVisibleCheckBox.TabIndex = 0;
			TicksVisibleCheckBox.Text = "Visible";
			TicksLabelMarginTextBox.LoadingBegin();
			TicksLabelMarginTextBox.Location = new Point(192, 136);
			TicksLabelMarginTextBox.Name = "TicksLabelMarginTextBox";
			TicksLabelMarginTextBox.PropertyName = "TicksLabelMargin";
			TicksLabelMarginTextBox.Size = new Size(56, 20);
			TicksLabelMarginTextBox.TabIndex = 4;
			TicksLabelMarginTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = TicksLabelMarginTextBox;
			focusLabel1.Location = new Point(121, 138);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(71, 15);
			focusLabel1.Text = "Label Margin";
			focusLabel1.LoadingEnd();
			TicksLengthNumericUpDown.Location = new Point(192, 112);
			TicksLengthNumericUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			TicksLengthNumericUpDown.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			TicksLengthNumericUpDown.Name = "TicksLengthNumericUpDown";
			TicksLengthNumericUpDown.PropertyName = "TicksLength";
			TicksLengthNumericUpDown.Size = new Size(56, 20);
			TicksLengthNumericUpDown.TabIndex = 3;
			TicksLengthNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label1.LoadingBegin();
			label1.FocusControl = TicksLengthNumericUpDown;
			label1.Location = new Point(151, 113);
			label1.Name = "label1";
			label1.Size = new Size(41, 15);
			label1.Text = "Length";
			label1.LoadingEnd();
			TicksMarginNumericUpDown.Location = new Point(192, 88);
			TicksMarginNumericUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			TicksMarginNumericUpDown.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			TicksMarginNumericUpDown.Name = "TicksMarginNumericUpDown";
			TicksMarginNumericUpDown.PropertyName = "TicksMargin";
			TicksMarginNumericUpDown.Size = new Size(56, 20);
			TicksMarginNumericUpDown.TabIndex = 2;
			TicksMarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = TicksMarginNumericUpDown;
			focusLabel2.Location = new Point(151, 89);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(41, 15);
			focusLabel2.Text = "Margin";
			focusLabel2.LoadingEnd();
			TicksShowFirstAndLastOnlyCheckBox.Location = new Point(192, 56);
			TicksShowFirstAndLastOnlyCheckBox.Name = "TicksShowFirstAndLastOnlyCheckBox";
			TicksShowFirstAndLastOnlyCheckBox.PropertyName = "TicksShowFirstAndLastOnly";
			TicksShowFirstAndLastOnlyCheckBox.Size = new Size(160, 24);
			TicksShowFirstAndLastOnlyCheckBox.TabIndex = 1;
			TicksShowFirstAndLastOnlyCheckBox.Text = "Show First && Last Only";
			base.Controls.Add(TicksShowFirstAndLastOnlyCheckBox);
			base.Controls.Add(TicksMarginNumericUpDown);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(TicksLengthNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(TicksLabelMarginTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(TicksVisibleCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotLegendChannelImageTicksEditorPlugIn";
			base.Size = new Size(456, 208);
			base.ResumeLayout(false);
		}
	}
}
