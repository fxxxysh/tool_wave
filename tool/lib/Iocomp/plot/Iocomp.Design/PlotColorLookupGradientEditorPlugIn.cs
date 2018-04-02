using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotColorLookupGradientEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel1;

		private EditBox MinTextBox;

		private EditBox MaxTextBox;

		private FocusLabel focusLabel2;

		private GroupBox StepsGroupBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown StepsCountNumericUpDown;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.CheckBox StepsEnabledCheckBox;

		private FocusLabel label8;

		private ColorPicker ColorStartPicker;

		private ColorPicker ColorStopPicker;

		private FocusLabel focusLabel4;

		private Label label1;

		private Container components;

		public PlotColorLookupGradientEditorPlugIn()
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
			MinTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			MaxTextBox = new EditBox();
			focusLabel2 = new FocusLabel();
			StepsGroupBox = new GroupBox();
			StepsEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			StepsCountNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			focusLabel3 = new FocusLabel();
			ColorStartPicker = new ColorPicker();
			label8 = new FocusLabel();
			ColorStopPicker = new ColorPicker();
			focusLabel4 = new FocusLabel();
			label1 = new Label();
			StepsGroupBox.SuspendLayout();
			base.SuspendLayout();
			MinTextBox.LoadingBegin();
			MinTextBox.Location = new Point(104, 8);
			MinTextBox.Name = "MinTextBox";
			MinTextBox.PropertyName = "Min";
			MinTextBox.Size = new Size(96, 20);
			MinTextBox.TabIndex = 0;
			MinTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = MinTextBox;
			focusLabel1.Location = new Point(79, 10);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(25, 15);
			focusLabel1.Text = "Min";
			focusLabel1.LoadingEnd();
			MaxTextBox.LoadingBegin();
			MaxTextBox.Location = new Point(104, 32);
			MaxTextBox.Name = "MaxTextBox";
			MaxTextBox.PropertyName = "Max";
			MaxTextBox.Size = new Size(96, 20);
			MaxTextBox.TabIndex = 1;
			MaxTextBox.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = MaxTextBox;
			focusLabel2.Location = new Point(76, 34);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(28, 15);
			focusLabel2.Text = "Max";
			focusLabel2.LoadingEnd();
			StepsGroupBox.Controls.Add(StepsEnabledCheckBox);
			StepsGroupBox.Controls.Add(StepsCountNumericUpDown);
			StepsGroupBox.Controls.Add(focusLabel3);
			StepsGroupBox.Location = new Point(104, 136);
			StepsGroupBox.Name = "StepsGroupBox";
			StepsGroupBox.Size = new Size(216, 64);
			StepsGroupBox.TabIndex = 5;
			StepsGroupBox.TabStop = false;
			StepsGroupBox.Text = "Steps";
			StepsEnabledCheckBox.Location = new Point(128, 24);
			StepsEnabledCheckBox.Name = "StepsEnabledCheckBox";
			StepsEnabledCheckBox.PropertyName = "StepsEnabled";
			StepsEnabledCheckBox.Size = new Size(80, 24);
			StepsEnabledCheckBox.TabIndex = 1;
			StepsEnabledCheckBox.Text = "Enabled";
			StepsCountNumericUpDown.Location = new Point(56, 26);
			StepsCountNumericUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			StepsCountNumericUpDown.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			StepsCountNumericUpDown.Name = "StepsCountNumericUpDown";
			StepsCountNumericUpDown.PropertyName = "StepsCount";
			StepsCountNumericUpDown.Size = new Size(56, 20);
			StepsCountNumericUpDown.TabIndex = 0;
			StepsCountNumericUpDown.TextAlign = HorizontalAlignment.Center;
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = StepsCountNumericUpDown;
			focusLabel3.Location = new Point(19, 27);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(37, 15);
			focusLabel3.Text = "Count";
			focusLabel3.LoadingEnd();
			ColorStartPicker.Location = new Point(104, 72);
			ColorStartPicker.Name = "ColorStartPicker";
			ColorStartPicker.PropertyName = "ColorStart";
			ColorStartPicker.Size = new Size(48, 21);
			ColorStartPicker.Style = ColorPickerStyle.ColorBox;
			ColorStartPicker.TabIndex = 2;
			label8.LoadingBegin();
			label8.FocusControl = ColorStartPicker;
			label8.Location = new Point(44, 75);
			label8.Name = "label8";
			label8.Size = new Size(60, 15);
			label8.Text = "Color Start";
			label8.LoadingEnd();
			ColorStopPicker.Location = new Point(104, 96);
			ColorStopPicker.Name = "ColorStopPicker";
			ColorStopPicker.PropertyName = "ColorStop";
			ColorStopPicker.Size = new Size(48, 21);
			ColorStopPicker.Style = ColorPickerStyle.ColorBox;
			ColorStopPicker.TabIndex = 4;
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = ColorStopPicker;
			focusLabel4.Location = new Point(45, 99);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(59, 15);
			focusLabel4.Text = "Color Stop";
			focusLabel4.LoadingEnd();
			label1.Location = new Point(160, 72);
			label1.Name = "label1";
			label1.Size = new Size(312, 40);
			label1.TabIndex = 3;
			label1.Text = "These Colors are ignored if 2 or more colors are added to the Gradient Colors collection. (See Gradient Colors Tab)";
			base.Controls.Add(label1);
			base.Controls.Add(ColorStopPicker);
			base.Controls.Add(focusLabel4);
			base.Controls.Add(ColorStartPicker);
			base.Controls.Add(label8);
			base.Controls.Add(StepsGroupBox);
			base.Controls.Add(MaxTextBox);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(MinTextBox);
			base.Controls.Add(focusLabel1);
			base.Location = new Point(10, 20);
			base.Name = "PlotColorLookupGradientEditorPlugIn";
			base.Size = new Size(496, 272);
			base.Tag = "";
			base.Title = "Plot Axis Editor";
			StepsGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new GradientColorCollectionEditorPlugIn(), "Gradient Colors", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotColorLookupGradient).GradientColors;
		}
	}
}
