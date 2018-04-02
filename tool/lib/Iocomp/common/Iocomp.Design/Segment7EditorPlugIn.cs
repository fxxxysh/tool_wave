using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class Segment7EditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.NumericUpDown SeperationNumericUpDown;

		private FocusLabel label6;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown SizeNumericUpDown;

		private GroupBox groupBox1;

		private ColorPicker ColorOnColorPicker;

		private FocusLabel label7;

		private ColorPicker ColorOffColorPicker;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ColorOffAutoCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ShowOffSegmentsCheckBox;

		private Container components;

		public Segment7EditorPlugIn()
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
			SeperationNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label6 = new FocusLabel();
			SizeNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label8 = new FocusLabel();
			groupBox1 = new GroupBox();
			ColorOffAutoCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			ColorOffColorPicker = new ColorPicker();
			label1 = new FocusLabel();
			ColorOnColorPicker = new ColorPicker();
			label7 = new FocusLabel();
			ShowOffSegmentsCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			groupBox1.SuspendLayout();
			base.SuspendLayout();
			SeperationNumericUpDown.Location = new Point(72, 64);
			SeperationNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			SeperationNumericUpDown.Name = "SeperationNumericUpDown";
			SeperationNumericUpDown.PropertyName = "Separation";
			SeperationNumericUpDown.Size = new Size(40, 20);
			SeperationNumericUpDown.TabIndex = 2;
			SeperationNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label6.LoadingBegin();
			label6.FocusControl = SeperationNumericUpDown;
			label6.Location = new Point(11, 65);
			label6.Name = "label6";
			label6.Size = new Size(61, 15);
			label6.Text = "Separation";
			label6.LoadingEnd();
			SizeNumericUpDown.Location = new Point(72, 40);
			SizeNumericUpDown.Name = "SizeNumericUpDown";
			SizeNumericUpDown.PropertyName = "Size";
			SizeNumericUpDown.Size = new Size(40, 20);
			SizeNumericUpDown.TabIndex = 1;
			SizeNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label8.LoadingBegin();
			label8.FocusControl = SizeNumericUpDown;
			label8.Location = new Point(43, 41);
			label8.Name = "label8";
			label8.Size = new Size(29, 15);
			label8.Text = "Size";
			label8.LoadingEnd();
			groupBox1.Controls.Add(ColorOffAutoCheckBox);
			groupBox1.Controls.Add(ColorOffColorPicker);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(ColorOnColorPicker);
			groupBox1.Controls.Add(label7);
			groupBox1.Location = new Point(168, 8);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(200, 104);
			groupBox1.TabIndex = 3;
			groupBox1.TabStop = false;
			groupBox1.Text = "Color";
			ColorOffAutoCheckBox.Location = new Point(32, 72);
			ColorOffAutoCheckBox.Name = "ColorOffAutoCheckBox";
			ColorOffAutoCheckBox.PropertyName = "ColorOffAuto";
			ColorOffAutoCheckBox.Size = new Size(80, 24);
			ColorOffAutoCheckBox.TabIndex = 2;
			ColorOffAutoCheckBox.Text = "Off Auto";
			ColorOffColorPicker.Location = new Point(32, 48);
			ColorOffColorPicker.Name = "ColorOffColorPicker";
			ColorOffColorPicker.PropertyName = "ColorOff";
			ColorOffColorPicker.Size = new Size(144, 21);
			ColorOffColorPicker.TabIndex = 1;
			label1.LoadingBegin();
			label1.FocusControl = ColorOffColorPicker;
			label1.Location = new Point(10, 51);
			label1.Name = "label1";
			label1.Size = new Size(22, 15);
			label1.Text = "Off";
			label1.LoadingEnd();
			ColorOnColorPicker.Location = new Point(32, 24);
			ColorOnColorPicker.Name = "ColorOnColorPicker";
			ColorOnColorPicker.PropertyName = "ColorOn";
			ColorOnColorPicker.Size = new Size(144, 21);
			ColorOnColorPicker.TabIndex = 0;
			label7.LoadingBegin();
			label7.FocusControl = ColorOnColorPicker;
			label7.Location = new Point(10, 27);
			label7.Name = "label7";
			label7.Size = new Size(22, 15);
			label7.Text = "On";
			label7.LoadingEnd();
			ShowOffSegmentsCheckBox.Location = new Point(16, 8);
			ShowOffSegmentsCheckBox.Name = "ShowOffSegmentsCheckBox";
			ShowOffSegmentsCheckBox.PropertyName = "ShowOffSegments";
			ShowOffSegmentsCheckBox.Size = new Size(128, 24);
			ShowOffSegmentsCheckBox.TabIndex = 0;
			ShowOffSegmentsCheckBox.Text = "Show Off Segments";
			base.Controls.Add(ShowOffSegmentsCheckBox);
			base.Controls.Add(groupBox1);
			base.Controls.Add(SizeNumericUpDown);
			base.Controls.Add(label8);
			base.Controls.Add(SeperationNumericUpDown);
			base.Controls.Add(label6);
			base.Location = new Point(10, 20);
			base.Name = "Segment7EditorPlugIn";
			base.Size = new Size(416, 208);
			base.Title = "Segments Editor";
			groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
