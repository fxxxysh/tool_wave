using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class StepperEditorPlugIn : PlugInStandard
	{
		private GroupBox groupBox2;

		private FocusLabel label10;

		private FocusLabel label12;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown RepeaterInitialDelayNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown RepeaterIntervalNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.CheckBox RepeaterEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ReversedCheckBox;

		private FocusLabel label1;

		private EditBox StepSizeTextBox;

		private Container components;

		public StepperEditorPlugIn()
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
			groupBox2 = new GroupBox();
			RepeaterEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			label10 = new FocusLabel();
			RepeaterIntervalNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			RepeaterInitialDelayNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label12 = new FocusLabel();
			ReversedCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			label1 = new FocusLabel();
			StepSizeTextBox = new EditBox();
			groupBox2.SuspendLayout();
			base.SuspendLayout();
			groupBox2.Controls.Add(RepeaterEnabledCheckBox);
			groupBox2.Controls.Add(label10);
			groupBox2.Controls.Add(RepeaterInitialDelayNumericUpDown);
			groupBox2.Controls.Add(label12);
			groupBox2.Controls.Add(RepeaterIntervalNumericUpDown);
			groupBox2.Location = new Point(0, 0);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(136, 104);
			groupBox2.TabIndex = 0;
			groupBox2.TabStop = false;
			groupBox2.Text = "Repeater";
			RepeaterEnabledCheckBox.Location = new Point(16, 16);
			RepeaterEnabledCheckBox.Name = "RepeaterEnabledCheckBox";
			RepeaterEnabledCheckBox.PropertyName = "RepeaterEnabled";
			RepeaterEnabledCheckBox.Size = new Size(80, 24);
			RepeaterEnabledCheckBox.TabIndex = 0;
			RepeaterEnabledCheckBox.Text = "Enabled";
			label10.LoadingBegin();
			label10.FocusControl = RepeaterIntervalNumericUpDown;
			label10.Location = new Point(36, 73);
			label10.Name = "label10";
			label10.Size = new Size(44, 15);
			label10.Text = "Interval";
			label10.LoadingEnd();
			RepeaterIntervalNumericUpDown.Increment = new decimal(new int[4]
			{
				50,
				0,
				0,
				0
			});
			RepeaterIntervalNumericUpDown.Location = new Point(80, 72);
			RepeaterIntervalNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000000,
				0,
				0,
				0
			});
			RepeaterIntervalNumericUpDown.Name = "RepeaterIntervalNumericUpDown";
			RepeaterIntervalNumericUpDown.PropertyName = "RepeaterInterval";
			RepeaterIntervalNumericUpDown.Size = new Size(48, 20);
			RepeaterIntervalNumericUpDown.TabIndex = 2;
			RepeaterIntervalNumericUpDown.TextAlign = HorizontalAlignment.Center;
			RepeaterInitialDelayNumericUpDown.Increment = new decimal(new int[4]
			{
				100,
				0,
				0,
				0
			});
			RepeaterInitialDelayNumericUpDown.Location = new Point(80, 48);
			RepeaterInitialDelayNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000000,
				0,
				0,
				0
			});
			RepeaterInitialDelayNumericUpDown.Name = "RepeaterInitialDelayNumericUpDown";
			RepeaterInitialDelayNumericUpDown.PropertyName = "RepeaterInitialDelay";
			RepeaterInitialDelayNumericUpDown.Size = new Size(48, 20);
			RepeaterInitialDelayNumericUpDown.TabIndex = 1;
			RepeaterInitialDelayNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label12.LoadingBegin();
			label12.FocusControl = RepeaterInitialDelayNumericUpDown;
			label12.Location = new Point(16, 49);
			label12.Name = "label12";
			label12.Size = new Size(64, 15);
			label12.Text = "Initial Delay";
			label12.LoadingEnd();
			ReversedCheckBox.Location = new Point(208, 40);
			ReversedCheckBox.Name = "ReversedCheckBox";
			ReversedCheckBox.PropertyName = "Reversed";
			ReversedCheckBox.Size = new Size(72, 24);
			ReversedCheckBox.TabIndex = 2;
			ReversedCheckBox.Text = "Reversed";
			label1.LoadingBegin();
			label1.FocusControl = StepSizeTextBox;
			label1.Location = new Point(153, 18);
			label1.Name = "label1";
			label1.Size = new Size(55, 15);
			label1.Text = "Step Size";
			label1.LoadingEnd();
			StepSizeTextBox.LoadingBegin();
			StepSizeTextBox.Location = new Point(208, 16);
			StepSizeTextBox.Name = "StepSizeTextBox";
			StepSizeTextBox.PropertyName = "StepSize";
			StepSizeTextBox.Size = new Size(48, 20);
			StepSizeTextBox.TabIndex = 1;
			StepSizeTextBox.TextAlign = HorizontalAlignment.Center;
			StepSizeTextBox.LoadingEnd();
			base.Controls.Add(label1);
			base.Controls.Add(StepSizeTextBox);
			base.Controls.Add(ReversedCheckBox);
			base.Controls.Add(groupBox2);
			base.Name = "StepperEditorPlugIn";
			base.Size = new Size(304, 120);
			base.Title = "Stepper Editor";
			groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new ValueDoubleEditorPlugIn(), "Value", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as Stepper).Value;
		}
	}
}
