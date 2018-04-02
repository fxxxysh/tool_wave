using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class AnnotationTextBoxEditorPlugIn : PlugInStandard
	{
		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanMoveCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanSizeCheckBox;

		private FocusLabel label7;

		private EditBox WidthTextBox;

		private EditBox HeightTextBox;

		private EditBox XTextBox;

		private FocusLabel label8;

		private EditBox YTextBox;

		private FocusLabel label9;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private EditBox RotationTextBox;

		private FocusLabel focusLabel1;

		private GroupBox groupBox1;

		private Iocomp.Design.Plugin.EditorControls.ComboBox FillStyleComboBox;

		private FocusLabel focusLabel2;

		private ColorPicker FillColorPicker;

		private FocusLabel focusLabel3;

		private GroupBox groupBox2;

		private ColorPicker OutlineColorPicker;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox OutlineStyleComboBox;

		private FocusLabel focusLabel5;

		private GroupBox groupBox3;

		private ColorPicker HatchBackColorPicker;

		private FocusLabel focusLabel6;

		private ColorPicker HatchForeColorPicker;

		private FocusLabel focusLabel7;

		private GroupBox groupBox4;

		private ColorPicker GradientStartColorPicker;

		private FocusLabel focusLabel8;

		private ColorPicker GradientStopColorPicker;

		private FocusLabel focusLabel9;

		private Iocomp.Design.Plugin.EditorControls.CheckBox FixedSizeCheckBox;

		private EditMultiLine TextEditMultiLine;

		private FocusLabel focusLabel10;

		private FontButton FontButton;

		private FocusLabel focusLabel11;

		private ColorPicker ForeColorPicker;

		private Container components;

		public AnnotationTextBoxEditorPlugIn()
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
			label1 = new FocusLabel();
			HeightTextBox = new EditBox();
			CanMoveCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			CanSizeCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			label7 = new FocusLabel();
			WidthTextBox = new EditBox();
			XTextBox = new EditBox();
			label8 = new FocusLabel();
			YTextBox = new EditBox();
			label9 = new FocusLabel();
			EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			RotationTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			groupBox1 = new GroupBox();
			FillColorPicker = new ColorPicker();
			focusLabel3 = new FocusLabel();
			FillStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel2 = new FocusLabel();
			groupBox2 = new GroupBox();
			OutlineColorPicker = new ColorPicker();
			focusLabel4 = new FocusLabel();
			OutlineStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel5 = new FocusLabel();
			groupBox3 = new GroupBox();
			HatchForeColorPicker = new ColorPicker();
			focusLabel7 = new FocusLabel();
			HatchBackColorPicker = new ColorPicker();
			focusLabel6 = new FocusLabel();
			groupBox4 = new GroupBox();
			GradientStartColorPicker = new ColorPicker();
			focusLabel8 = new FocusLabel();
			GradientStopColorPicker = new ColorPicker();
			focusLabel9 = new FocusLabel();
			FixedSizeCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			TextEditMultiLine = new EditMultiLine();
			focusLabel10 = new FocusLabel();
			FontButton = new FontButton();
			focusLabel11 = new FocusLabel();
			ForeColorPicker = new ColorPicker();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox4.SuspendLayout();
			base.SuspendLayout();
			label1.LoadingBegin();
			label1.FocusControl = HeightTextBox;
			label1.Location = new Point(25, 122);
			label1.Name = "label1";
			label1.Size = new Size(39, 15);
			label1.Text = "Height";
			label1.LoadingEnd();
			HeightTextBox.LoadingBegin();
			HeightTextBox.Location = new Point(64, 120);
			HeightTextBox.Name = "HeightTextBox";
			HeightTextBox.PropertyName = "Height";
			HeightTextBox.Size = new Size(48, 20);
			HeightTextBox.TabIndex = 8;
			HeightTextBox.LoadingEnd();
			CanMoveCheckBox.Location = new Point(248, 8);
			CanMoveCheckBox.Name = "CanMoveCheckBox";
			CanMoveCheckBox.PropertyName = "CanMove";
			CanMoveCheckBox.Size = new Size(80, 24);
			CanMoveCheckBox.TabIndex = 2;
			CanMoveCheckBox.Text = "Can Move";
			CanSizeCheckBox.Location = new Point(344, 8);
			CanSizeCheckBox.Name = "CanSizeCheckBox";
			CanSizeCheckBox.PropertyName = "CanSize";
			CanSizeCheckBox.Size = new Size(72, 24);
			CanSizeCheckBox.TabIndex = 3;
			CanSizeCheckBox.Text = "Can Size";
			label7.LoadingBegin();
			label7.FocusControl = WidthTextBox;
			label7.Location = new Point(28, 98);
			label7.Name = "label7";
			label7.Size = new Size(36, 15);
			label7.Text = "Width";
			label7.LoadingEnd();
			WidthTextBox.LoadingBegin();
			WidthTextBox.Location = new Point(64, 96);
			WidthTextBox.Name = "WidthTextBox";
			WidthTextBox.PropertyName = "Width";
			WidthTextBox.Size = new Size(48, 20);
			WidthTextBox.TabIndex = 7;
			WidthTextBox.LoadingEnd();
			XTextBox.LoadingBegin();
			XTextBox.Location = new Point(64, 48);
			XTextBox.Name = "XTextBox";
			XTextBox.PropertyName = "X";
			XTextBox.Size = new Size(48, 20);
			XTextBox.TabIndex = 5;
			XTextBox.LoadingEnd();
			label8.LoadingBegin();
			label8.FocusControl = XTextBox;
			label8.Location = new Point(49, 50);
			label8.Name = "label8";
			label8.Size = new Size(15, 15);
			label8.Text = "X";
			label8.LoadingEnd();
			YTextBox.LoadingBegin();
			YTextBox.Location = new Point(64, 72);
			YTextBox.Name = "YTextBox";
			YTextBox.PropertyName = "Y";
			YTextBox.Size = new Size(48, 20);
			YTextBox.TabIndex = 6;
			YTextBox.LoadingEnd();
			label9.LoadingBegin();
			label9.FocusControl = YTextBox;
			label9.Location = new Point(49, 74);
			label9.Name = "label9";
			label9.Size = new Size(15, 15);
			label9.Text = "Y";
			label9.LoadingEnd();
			EnabledCheckBox.Location = new Point(152, 8);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(72, 24);
			EnabledCheckBox.TabIndex = 1;
			EnabledCheckBox.Text = "Enabled";
			VisibleCheckBox.Location = new Point(64, 8);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			RotationTextBox.LoadingBegin();
			RotationTextBox.Location = new Point(64, 144);
			RotationTextBox.Name = "RotationTextBox";
			RotationTextBox.PropertyName = "Rotation";
			RotationTextBox.Size = new Size(48, 20);
			RotationTextBox.TabIndex = 9;
			RotationTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = RotationTextBox;
			focusLabel1.Location = new Point(15, 146);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(49, 15);
			focusLabel1.Text = "Rotation";
			focusLabel1.LoadingEnd();
			groupBox1.Controls.Add(FillColorPicker);
			groupBox1.Controls.Add(focusLabel3);
			groupBox1.Controls.Add(FillStyleComboBox);
			groupBox1.Controls.Add(focusLabel2);
			groupBox1.Location = new Point(136, 136);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(224, 88);
			groupBox1.TabIndex = 11;
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
			groupBox2.Controls.Add(OutlineColorPicker);
			groupBox2.Controls.Add(focusLabel4);
			groupBox2.Controls.Add(OutlineStyleComboBox);
			groupBox2.Controls.Add(focusLabel5);
			groupBox2.Location = new Point(136, 40);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(224, 88);
			groupBox2.TabIndex = 10;
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
			groupBox3.Controls.Add(HatchForeColorPicker);
			groupBox3.Controls.Add(focusLabel7);
			groupBox3.Controls.Add(HatchBackColorPicker);
			groupBox3.Controls.Add(focusLabel6);
			groupBox3.Location = new Point(368, 136);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(136, 88);
			groupBox3.TabIndex = 13;
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
			groupBox4.Controls.Add(GradientStartColorPicker);
			groupBox4.Controls.Add(focusLabel8);
			groupBox4.Controls.Add(GradientStopColorPicker);
			groupBox4.Controls.Add(focusLabel9);
			groupBox4.Location = new Point(368, 40);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new Size(136, 88);
			groupBox4.TabIndex = 12;
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
			FixedSizeCheckBox.Location = new Point(432, 8);
			FixedSizeCheckBox.Name = "FixedSizeCheckBox";
			FixedSizeCheckBox.PropertyName = "FixedSize";
			FixedSizeCheckBox.Size = new Size(80, 24);
			FixedSizeCheckBox.TabIndex = 4;
			FixedSizeCheckBox.Text = "Fixed Size";
			TextEditMultiLine.EditFont = null;
			TextEditMultiLine.Location = new Point(64, 240);
			TextEditMultiLine.Name = "TextEditMultiLine";
			TextEditMultiLine.PropertyName = "Text";
			TextEditMultiLine.Size = new Size(440, 20);
			TextEditMultiLine.TabIndex = 14;
			focusLabel10.LoadingBegin();
			focusLabel10.FocusControl = TextEditMultiLine;
			focusLabel10.Location = new Point(35, 243);
			focusLabel10.Name = "focusLabel10";
			focusLabel10.Size = new Size(29, 15);
			focusLabel10.Text = "Text";
			focusLabel10.LoadingEnd();
			FontButton.Location = new Point(64, 272);
			FontButton.Name = "FontButton";
			FontButton.PropertyName = "Font";
			FontButton.Size = new Size(72, 23);
			FontButton.TabIndex = 15;
			focusLabel11.LoadingBegin();
			focusLabel11.FocusControl = ForeColorPicker;
			focusLabel11.Location = new Point(157, 275);
			focusLabel11.Name = "focusLabel11";
			focusLabel11.Size = new Size(59, 15);
			focusLabel11.Text = "Fore Color";
			focusLabel11.LoadingEnd();
			ForeColorPicker.Location = new Point(216, 272);
			ForeColorPicker.Name = "ForeColorPicker";
			ForeColorPicker.PropertyName = "ForeColor";
			ForeColorPicker.Size = new Size(49, 21);
			ForeColorPicker.Style = ColorPickerStyle.ColorBox;
			ForeColorPicker.TabIndex = 16;
			base.Controls.Add(FontButton);
			base.Controls.Add(focusLabel11);
			base.Controls.Add(ForeColorPicker);
			base.Controls.Add(TextEditMultiLine);
			base.Controls.Add(focusLabel10);
			base.Controls.Add(FixedSizeCheckBox);
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
			base.Name = "AnnotationTextBoxEditorPlugIn";
			base.Size = new Size(528, 304);
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new TextLayoutBaseEditorPlugIn(), "Text Layout", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as AnnotationTextBox).TextLayout;
		}
	}
}
