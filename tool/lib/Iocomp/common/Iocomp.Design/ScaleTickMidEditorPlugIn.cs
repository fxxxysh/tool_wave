using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ScaleTickMidEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.NumericUpDown ThicknessNumericUpDown;

		private FocusLabel label10;

		private FocusLabel label7;

		private GroupBox groupBox1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox TextVisibleCheckBox;

		private FocusLabel label6;

		private Iocomp.Design.Plugin.EditorControls.ComboBox AlignmentComboBox;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LengthNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown TextMarginNumericUpDown;

		private FocusLabel label9;

		private FocusLabel label8;

		private FontButton FontButton;

		private ColorPicker ForeColorPicker;

		private ColorPicker ColorPicker;

		private Container components;

		public ScaleTickMidEditorPlugIn()
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
			ThicknessNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label10 = new FocusLabel();
			label7 = new FocusLabel();
			LengthNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			groupBox1 = new GroupBox();
			TextMarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			TextVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			label6 = new FocusLabel();
			AlignmentComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label1 = new FocusLabel();
			FontButton = new FontButton();
			ForeColorPicker = new ColorPicker();
			ColorPicker = new ColorPicker();
			label9 = new FocusLabel();
			label8 = new FocusLabel();
			((ISupportInitialize)ThicknessNumericUpDown).BeginInit();
			((ISupportInitialize)LengthNumericUpDown).BeginInit();
			groupBox1.SuspendLayout();
			((ISupportInitialize)TextMarginNumericUpDown).BeginInit();
			base.SuspendLayout();
			ThicknessNumericUpDown.Location = new Point(88, 88);
			ThicknessNumericUpDown.Name = "ThicknessNumericUpDown";
			ThicknessNumericUpDown.PropertyName = "Thickness";
			ThicknessNumericUpDown.Size = new Size(57, 20);
			ThicknessNumericUpDown.TabIndex = 2;
			ThicknessNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label10.LoadingBegin();
			label10.FocusControl = ThicknessNumericUpDown;
			label10.Location = new Point(31, 89);
			label10.Name = "label10";
			label10.Size = new Size(57, 15);
			label10.Text = "Thickness";
			label10.LoadingEnd();
			label7.LoadingBegin();
			label7.FocusControl = LengthNumericUpDown;
			label7.Location = new Point(47, 65);
			label7.Name = "label7";
			label7.Size = new Size(41, 15);
			label7.Text = "Length";
			label7.LoadingEnd();
			LengthNumericUpDown.Location = new Point(88, 64);
			LengthNumericUpDown.Name = "LengthNumericUpDown";
			LengthNumericUpDown.PropertyName = "Length";
			LengthNumericUpDown.Size = new Size(57, 20);
			LengthNumericUpDown.TabIndex = 1;
			LengthNumericUpDown.TextAlign = HorizontalAlignment.Center;
			groupBox1.Controls.Add(TextMarginNumericUpDown);
			groupBox1.Controls.Add(TextVisibleCheckBox);
			groupBox1.Controls.Add(label6);
			groupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			groupBox1.Location = new Point(248, 27);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(120, 72);
			groupBox1.TabIndex = 5;
			groupBox1.TabStop = false;
			groupBox1.Text = "Text";
			TextMarginNumericUpDown.Location = new Point(64, 16);
			TextMarginNumericUpDown.Name = "TextMarginNumericUpDown";
			TextMarginNumericUpDown.PropertyName = "TextMargin";
			TextMarginNumericUpDown.Size = new Size(48, 20);
			TextMarginNumericUpDown.TabIndex = 0;
			TextMarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			TextVisibleCheckBox.Location = new Point(24, 40);
			TextVisibleCheckBox.Name = "TextVisibleCheckBox";
			TextVisibleCheckBox.PropertyName = "TextVisible";
			TextVisibleCheckBox.Size = new Size(62, 24);
			TextVisibleCheckBox.TabIndex = 1;
			TextVisibleCheckBox.Text = "Visible";
			label6.LoadingBegin();
			label6.FocusControl = TextMarginNumericUpDown;
			label6.Location = new Point(23, 17);
			label6.Name = "label6";
			label6.Size = new Size(41, 15);
			label6.Text = "Margin";
			label6.LoadingEnd();
			AlignmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			AlignmentComboBox.Location = new Point(88, 32);
			AlignmentComboBox.Name = "AlignmentComboBox";
			AlignmentComboBox.PropertyName = "Alignment";
			AlignmentComboBox.Size = new Size(144, 21);
			AlignmentComboBox.TabIndex = 0;
			label1.LoadingBegin();
			label1.FocusControl = AlignmentComboBox;
			label1.Location = new Point(31, 34);
			label1.Name = "label1";
			label1.Size = new Size(57, 15);
			label1.Text = "Alignment";
			label1.LoadingEnd();
			FontButton.Location = new Point(272, 112);
			FontButton.Name = "FontButton";
			FontButton.PropertyName = "Font";
			FontButton.TabIndex = 6;
			ForeColorPicker.Location = new Point(88, 152);
			ForeColorPicker.Name = "ForeColorPicker";
			ForeColorPicker.PropertyName = "ForeColor";
			ForeColorPicker.Size = new Size(144, 21);
			ForeColorPicker.TabIndex = 4;
			ColorPicker.Location = new Point(88, 128);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(144, 21);
			ColorPicker.TabIndex = 3;
			label9.LoadingBegin();
			label9.FocusControl = ColorPicker;
			label9.Location = new Point(54, 131);
			label9.Name = "label9";
			label9.Size = new Size(34, 15);
			label9.Text = "Color";
			label9.LoadingEnd();
			label8.LoadingBegin();
			label8.FocusControl = ForeColorPicker;
			label8.Location = new Point(29, 155);
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
			base.Controls.Add(label1);
			base.Controls.Add(AlignmentComboBox);
			base.Controls.Add(ThicknessNumericUpDown);
			base.Controls.Add(label10);
			base.Controls.Add(label7);
			base.Controls.Add(groupBox1);
			base.Name = "ScaleTickMidEditorPlugIn";
			base.Size = new Size(600, 304);
			base.Title = "Tick-Mid Editor";
			((ISupportInitialize)ThicknessNumericUpDown).EndInit();
			((ISupportInitialize)LengthNumericUpDown).EndInit();
			groupBox1.ResumeLayout(false);
			((ISupportInitialize)TextMarginNumericUpDown).EndInit();
			base.ResumeLayout(false);
		}
	}
}
