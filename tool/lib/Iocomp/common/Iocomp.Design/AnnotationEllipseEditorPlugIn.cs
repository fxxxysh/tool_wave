using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class AnnotationEllipseEditorPlugIn : PlugInStandard
	{
		private GroupBox groupBox3;

		private ColorPicker HatchForeColorPicker;

		private FocusLabel focusLabel7;

		private ColorPicker HatchBackColorPicker;

		private FocusLabel focusLabel6;

		private GroupBox groupBox2;

		private ColorPicker OutlineColorPicker;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox OutlineStyleComboBox;

		private FocusLabel focusLabel5;

		private GroupBox groupBox1;

		private ColorPicker FillColorPicker;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.ComboBox FillStyleComboBox;

		private FocusLabel focusLabel2;

		private EditBox RotationTextBox;

		private FocusLabel focusLabel1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private EditBox YTextBox;

		private FocusLabel label9;

		private EditBox XTextBox;

		private FocusLabel label8;

		private EditBox HeightTextBox;

		private EditBox WidthTextBox;

		private FocusLabel label7;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanSizeCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanMoveCheckBox;

		private FocusLabel label1;

		private GroupBox groupBox4;

		private ColorPicker GradientStartColorPicker;

		private FocusLabel focusLabel8;

		private ColorPicker GradientStopColorPicker;

		private FocusLabel focusLabel9;

		private Container components;

		public AnnotationEllipseEditorPlugIn()
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
			HatchForeColorPicker = new ColorPicker();
			focusLabel7 = new FocusLabel();
			HatchBackColorPicker = new ColorPicker();
			focusLabel6 = new FocusLabel();
			groupBox2 = new GroupBox();
			OutlineColorPicker = new ColorPicker();
			focusLabel4 = new FocusLabel();
			OutlineStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel5 = new FocusLabel();
			groupBox1 = new GroupBox();
			FillColorPicker = new ColorPicker();
			focusLabel3 = new FocusLabel();
			FillStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel2 = new FocusLabel();
			RotationTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			YTextBox = new EditBox();
			label9 = new FocusLabel();
			XTextBox = new EditBox();
			label8 = new FocusLabel();
			HeightTextBox = new EditBox();
			WidthTextBox = new EditBox();
			label7 = new FocusLabel();
			CanSizeCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			CanMoveCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			label1 = new FocusLabel();
			groupBox4 = new GroupBox();
			GradientStartColorPicker = new ColorPicker();
			focusLabel8 = new FocusLabel();
			GradientStopColorPicker = new ColorPicker();
			focusLabel9 = new FocusLabel();
			groupBox3.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			groupBox4.SuspendLayout();
			base.SuspendLayout();
			groupBox3.Controls.Add(HatchForeColorPicker);
			groupBox3.Controls.Add(focusLabel7);
			groupBox3.Controls.Add(HatchBackColorPicker);
			groupBox3.Controls.Add(focusLabel6);
			groupBox3.Location = new Point(368, 163);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(136, 88);
			groupBox3.TabIndex = 12;
			groupBox3.TabStop = false;
			groupBox3.Text = "Hatch";
			HatchForeColorPicker.Location = new Point(72, 24);
			HatchForeColorPicker.Name = "HatchForeColorPicker";
			HatchForeColorPicker.PropertyName = "HatchForeColor";
			HatchForeColorPicker.Size = new Size(48, 21);
			HatchForeColorPicker.Style = ColorPickerStyle.ColorBox;
			HatchForeColorPicker.TabIndex = 0;
			focusLabel7.LoadingBegin();
			focusLabel7.FocusControl = HatchForeColorPicker;
			focusLabel7.Location = new Point(13, 27);
			focusLabel7.Name = "focusLabel7";
			focusLabel7.Size = new Size(59, 15);
			focusLabel7.Text = "Fore Color";
			focusLabel7.LoadingEnd();
			HatchBackColorPicker.Location = new Point(72, 56);
			HatchBackColorPicker.Name = "HatchBackColorPicker";
			HatchBackColorPicker.PropertyName = "HatchBackColor";
			HatchBackColorPicker.Size = new Size(48, 21);
			HatchBackColorPicker.Style = ColorPickerStyle.ColorBox;
			HatchBackColorPicker.TabIndex = 1;
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = HatchBackColorPicker;
			focusLabel6.Location = new Point(11, 59);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(61, 15);
			focusLabel6.Text = "Back Color";
			focusLabel6.LoadingEnd();
			groupBox2.Controls.Add(OutlineColorPicker);
			groupBox2.Controls.Add(focusLabel4);
			groupBox2.Controls.Add(OutlineStyleComboBox);
			groupBox2.Controls.Add(focusLabel5);
			groupBox2.Location = new Point(136, 67);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(224, 88);
			groupBox2.TabIndex = 9;
			groupBox2.TabStop = false;
			groupBox2.Text = "Outline";
			OutlineColorPicker.Location = new Point(48, 56);
			OutlineColorPicker.Name = "OutlineColorPicker";
			OutlineColorPicker.PropertyName = "OutlineColor";
			OutlineColorPicker.Size = new Size(48, 21);
			OutlineColorPicker.Style = ColorPickerStyle.ColorBox;
			OutlineColorPicker.TabIndex = 1;
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = OutlineColorPicker;
			focusLabel4.Location = new Point(14, 59);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(34, 15);
			focusLabel4.Text = "Color";
			focusLabel4.LoadingEnd();
			OutlineStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			OutlineStyleComboBox.Location = new Point(48, 24);
			OutlineStyleComboBox.Name = "OutlineStyleComboBox";
			OutlineStyleComboBox.PropertyName = "OutlineStyle";
			OutlineStyleComboBox.Size = new Size(168, 21);
			OutlineStyleComboBox.TabIndex = 0;
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = OutlineStyleComboBox;
			focusLabel5.Location = new Point(16, 26);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(32, 15);
			focusLabel5.Text = "Style";
			focusLabel5.LoadingEnd();
			groupBox1.Controls.Add(FillColorPicker);
			groupBox1.Controls.Add(focusLabel3);
			groupBox1.Controls.Add(FillStyleComboBox);
			groupBox1.Controls.Add(focusLabel2);
			groupBox1.Location = new Point(136, 163);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(224, 88);
			groupBox1.TabIndex = 10;
			groupBox1.TabStop = false;
			groupBox1.Text = "Fill";
			FillColorPicker.Location = new Point(48, 56);
			FillColorPicker.Name = "FillColorPicker";
			FillColorPicker.PropertyName = "FillColor";
			FillColorPicker.Size = new Size(48, 21);
			FillColorPicker.Style = ColorPickerStyle.ColorBox;
			FillColorPicker.TabIndex = 1;
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = FillColorPicker;
			focusLabel3.Location = new Point(14, 59);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(34, 15);
			focusLabel3.Text = "Color";
			focusLabel3.LoadingEnd();
			FillStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			FillStyleComboBox.Location = new Point(48, 24);
			FillStyleComboBox.Name = "FillStyleComboBox";
			FillStyleComboBox.PropertyName = "FillStyle";
			FillStyleComboBox.Size = new Size(168, 21);
			FillStyleComboBox.TabIndex = 0;
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = FillStyleComboBox;
			focusLabel2.Location = new Point(16, 26);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(32, 15);
			focusLabel2.Text = "Style";
			focusLabel2.LoadingEnd();
			RotationTextBox.LoadingBegin();
			RotationTextBox.Location = new Point(72, 168);
			RotationTextBox.Name = "RotationTextBox";
			RotationTextBox.PropertyName = "Rotation";
			RotationTextBox.Size = new Size(48, 20);
			RotationTextBox.TabIndex = 8;
			RotationTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = RotationTextBox;
			focusLabel1.Location = new Point(23, 170);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(49, 15);
			focusLabel1.Text = "Rotation";
			focusLabel1.LoadingEnd();
			EnabledCheckBox.Location = new Point(160, 32);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(72, 24);
			EnabledCheckBox.TabIndex = 1;
			EnabledCheckBox.Text = "Enabled";
			VisibleCheckBox.Location = new Point(72, 32);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			YTextBox.LoadingBegin();
			YTextBox.Location = new Point(72, 96);
			YTextBox.Name = "YTextBox";
			YTextBox.PropertyName = "Y";
			YTextBox.Size = new Size(48, 20);
			YTextBox.TabIndex = 5;
			YTextBox.LoadingEnd();
			label9.LoadingBegin();
			label9.FocusControl = YTextBox;
			label9.Location = new Point(57, 98);
			label9.Name = "label9";
			label9.Size = new Size(15, 15);
			label9.Text = "Y";
			label9.LoadingEnd();
			XTextBox.LoadingBegin();
			XTextBox.Location = new Point(72, 72);
			XTextBox.Name = "XTextBox";
			XTextBox.PropertyName = "X";
			XTextBox.Size = new Size(48, 20);
			XTextBox.TabIndex = 4;
			XTextBox.LoadingEnd();
			label8.LoadingBegin();
			label8.FocusControl = XTextBox;
			label8.Location = new Point(57, 74);
			label8.Name = "label8";
			label8.Size = new Size(15, 15);
			label8.Text = "X";
			label8.LoadingEnd();
			HeightTextBox.LoadingBegin();
			HeightTextBox.Location = new Point(72, 144);
			HeightTextBox.Name = "HeightTextBox";
			HeightTextBox.PropertyName = "Height";
			HeightTextBox.Size = new Size(48, 20);
			HeightTextBox.TabIndex = 7;
			HeightTextBox.LoadingEnd();
			WidthTextBox.LoadingBegin();
			WidthTextBox.Location = new Point(72, 120);
			WidthTextBox.Name = "WidthTextBox";
			WidthTextBox.PropertyName = "Width";
			WidthTextBox.Size = new Size(48, 20);
			WidthTextBox.TabIndex = 6;
			WidthTextBox.LoadingEnd();
			label7.LoadingBegin();
			label7.FocusControl = WidthTextBox;
			label7.Location = new Point(36, 122);
			label7.Name = "label7";
			label7.Size = new Size(36, 15);
			label7.Text = "Width";
			label7.LoadingEnd();
			CanSizeCheckBox.Location = new Point(352, 32);
			CanSizeCheckBox.Name = "CanSizeCheckBox";
			CanSizeCheckBox.PropertyName = "CanSize";
			CanSizeCheckBox.Size = new Size(72, 24);
			CanSizeCheckBox.TabIndex = 3;
			CanSizeCheckBox.Text = "Can Size";
			CanMoveCheckBox.Location = new Point(256, 32);
			CanMoveCheckBox.Name = "CanMoveCheckBox";
			CanMoveCheckBox.PropertyName = "CanMove";
			CanMoveCheckBox.Size = new Size(80, 24);
			CanMoveCheckBox.TabIndex = 2;
			CanMoveCheckBox.Text = "Can Move";
			label1.LoadingBegin();
			label1.FocusControl = HeightTextBox;
			label1.Location = new Point(33, 146);
			label1.Name = "label1";
			label1.Size = new Size(39, 15);
			label1.Text = "Height";
			label1.LoadingEnd();
			groupBox4.Controls.Add(GradientStartColorPicker);
			groupBox4.Controls.Add(focusLabel8);
			groupBox4.Controls.Add(GradientStopColorPicker);
			groupBox4.Controls.Add(focusLabel9);
			groupBox4.Location = new Point(368, 67);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new Size(136, 88);
			groupBox4.TabIndex = 11;
			groupBox4.TabStop = false;
			groupBox4.Text = "Gradient";
			GradientStartColorPicker.Location = new Point(72, 24);
			GradientStartColorPicker.Name = "GradientStartColorPicker";
			GradientStartColorPicker.PropertyName = "GradientStartColor";
			GradientStartColorPicker.Size = new Size(48, 21);
			GradientStartColorPicker.Style = ColorPickerStyle.ColorBox;
			GradientStartColorPicker.TabIndex = 0;
			focusLabel8.LoadingBegin();
			focusLabel8.FocusControl = GradientStartColorPicker;
			focusLabel8.Location = new Point(12, 27);
			focusLabel8.Name = "focusLabel8";
			focusLabel8.Size = new Size(60, 15);
			focusLabel8.Text = "Start Color";
			focusLabel8.LoadingEnd();
			GradientStopColorPicker.Location = new Point(72, 56);
			GradientStopColorPicker.Name = "GradientStopColorPicker";
			GradientStopColorPicker.PropertyName = "GradientStopColor";
			GradientStopColorPicker.Size = new Size(48, 21);
			GradientStopColorPicker.Style = ColorPickerStyle.ColorBox;
			GradientStopColorPicker.TabIndex = 1;
			focusLabel9.LoadingBegin();
			focusLabel9.FocusControl = GradientStopColorPicker;
			focusLabel9.Location = new Point(13, 59);
			focusLabel9.Name = "focusLabel9";
			focusLabel9.Size = new Size(59, 15);
			focusLabel9.Text = "Stop Color";
			focusLabel9.LoadingEnd();
			base.Controls.Add(groupBox3);
			base.Controls.Add(groupBox2);
			base.Controls.Add(groupBox1);
			base.Controls.Add(RotationTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(EnabledCheckBox);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(YTextBox);
			base.Controls.Add(label9);
			base.Controls.Add(XTextBox);
			base.Controls.Add(label8);
			base.Controls.Add(HeightTextBox);
			base.Controls.Add(WidthTextBox);
			base.Controls.Add(label7);
			base.Controls.Add(CanSizeCheckBox);
			base.Controls.Add(CanMoveCheckBox);
			base.Controls.Add(label1);
			base.Controls.Add(groupBox4);
			base.Location = new Point(10, 20);
			base.Name = "AnnotationEllipseEditorPlugIn";
			base.Size = new Size(736, 416);
			groupBox3.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
