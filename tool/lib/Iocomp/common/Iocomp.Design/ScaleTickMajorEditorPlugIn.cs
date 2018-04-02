using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class ScaleTickMajorEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.NumericUpDown ThicknessNumericUpDown;

		private FocusLabel label10;

		private FocusLabel label7;

		private FocusLabel label6;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown TextMarginNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.CheckBox TextVisibleCheckBox;

		private GroupBox groupBox1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LengthNumericUpDown;

		private FocusLabel label9;

		private FocusLabel label8;

		private FontButton FontButton;

		private ColorPicker ForeColorPicker;

		private ColorPicker ColorPicker;

		private Container components;

		public ScaleTickMajorEditorPlugIn()
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
			groupBox1 = new GroupBox();
			TextVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			TextMarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label6 = new FocusLabel();
			ThicknessNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label10 = new FocusLabel();
			label7 = new FocusLabel();
			LengthNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			FontButton = new FontButton();
			ForeColorPicker = new ColorPicker();
			ColorPicker = new ColorPicker();
			label9 = new FocusLabel();
			label8 = new FocusLabel();
			groupBox1.SuspendLayout();
			((ISupportInitialize)TextMarginNumericUpDown).BeginInit();
			((ISupportInitialize)ThicknessNumericUpDown).BeginInit();
			((ISupportInitialize)LengthNumericUpDown).BeginInit();
			base.SuspendLayout();
			groupBox1.Controls.Add(TextVisibleCheckBox);
			groupBox1.Controls.Add(TextMarginNumericUpDown);
			groupBox1.Controls.Add(label6);
			groupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			groupBox1.Location = new Point(232, 24);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(120, 72);
			groupBox1.TabIndex = 4;
			groupBox1.TabStop = false;
			groupBox1.Text = "Text";
			TextVisibleCheckBox.Location = new Point(24, 40);
			TextVisibleCheckBox.Name = "TextVisibleCheckBox";
			TextVisibleCheckBox.PropertyName = "TextVisible";
			TextVisibleCheckBox.Size = new Size(62, 24);
			TextVisibleCheckBox.TabIndex = 1;
			TextVisibleCheckBox.Text = "Visible";
			TextMarginNumericUpDown.Location = new Point(64, 16);
			TextMarginNumericUpDown.Maximum = new decimal(new int[4]
			{
				0,
				0,
				-2147483648,
				0
			});
			TextMarginNumericUpDown.Name = "TextMarginNumericUpDown";
			TextMarginNumericUpDown.PropertyName = "TextMargin";
			TextMarginNumericUpDown.Size = new Size(48, 20);
			TextMarginNumericUpDown.TabIndex = 0;
			TextMarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label6.LoadingBegin();
			label6.FocusControl = TextMarginNumericUpDown;
			label6.Location = new Point(23, 17);
			label6.Name = "label6";
			label6.Size = new Size(41, 15);
			label6.Text = "Margin";
			label6.LoadingEnd();
			ThicknessNumericUpDown.Location = new Point(72, 56);
			ThicknessNumericUpDown.Name = "ThicknessNumericUpDown";
			ThicknessNumericUpDown.PropertyName = "Thickness";
			ThicknessNumericUpDown.Size = new Size(57, 20);
			ThicknessNumericUpDown.TabIndex = 1;
			ThicknessNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label10.LoadingBegin();
			label10.FocusControl = ThicknessNumericUpDown;
			label10.Location = new Point(15, 57);
			label10.Name = "label10";
			label10.Size = new Size(57, 15);
			label10.Text = "Thickness";
			label10.LoadingEnd();
			label7.LoadingBegin();
			label7.FocusControl = LengthNumericUpDown;
			label7.Location = new Point(31, 33);
			label7.Name = "label7";
			label7.Size = new Size(41, 15);
			label7.Text = "Length";
			label7.LoadingEnd();
			LengthNumericUpDown.Location = new Point(72, 32);
			LengthNumericUpDown.Name = "LengthNumericUpDown";
			LengthNumericUpDown.PropertyName = "Length";
			LengthNumericUpDown.Size = new Size(57, 20);
			LengthNumericUpDown.TabIndex = 0;
			LengthNumericUpDown.TextAlign = HorizontalAlignment.Center;
			FontButton.Location = new Point(256, 112);
			FontButton.Name = "FontButton";
			FontButton.PropertyName = "Font";
			FontButton.TabIndex = 5;
			ForeColorPicker.Location = new Point(72, 136);
			ForeColorPicker.Name = "ForeColorPicker";
			ForeColorPicker.PropertyName = "ForeColor";
			ForeColorPicker.Size = new Size(144, 21);
			ForeColorPicker.TabIndex = 3;
			ColorPicker.Location = new Point(72, 112);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(144, 21);
			ColorPicker.TabIndex = 2;
			label9.LoadingBegin();
			label9.FocusControl = ColorPicker;
			label9.Location = new Point(38, 115);
			label9.Name = "label9";
			label9.Size = new Size(34, 15);
			label9.Text = "Color";
			label9.LoadingEnd();
			label8.LoadingBegin();
			label8.FocusControl = ForeColorPicker;
			label8.Location = new Point(13, 139);
			label8.Name = "label8";
			label8.Size = new Size(59, 15);
			label8.Text = "Fore Color";
			label8.LoadingEnd();
			base.Controls.Add(ForeColorPicker);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label9);
			base.Controls.Add(label8);
			base.Controls.Add(FontButton);
			base.Controls.Add(LengthNumericUpDown);
			base.Controls.Add(ThicknessNumericUpDown);
			base.Controls.Add(label10);
			base.Controls.Add(label7);
			base.Controls.Add(groupBox1);
			base.Name = "ScaleTickMajorEditorPlugIn";
			base.Size = new Size(544, 232);
			base.Title = "Tick-Major Editor";
			groupBox1.ResumeLayout(false);
			((ISupportInitialize)TextMarginNumericUpDown).EndInit();
			((ISupportInitialize)ThicknessNumericUpDown).EndInit();
			((ISupportInitialize)LengthNumericUpDown).EndInit();
			base.ResumeLayout(false);
		}
	}
}
