using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class AnnotationArcEditorPlugIn : PlugInStandard
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

		private GroupBox groupBox2;

		private ColorPicker OutlineColorPicker;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox OutlineStyleComboBox;

		private FocusLabel focusLabel5;

		private EditBox StartAngleTextBox;

		private FocusLabel focusLabel2;

		private EditBox SweepAngleTextBox;

		private FocusLabel focusLabel3;

		private Container components;

		public AnnotationArcEditorPlugIn()
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
			groupBox2 = new GroupBox();
			OutlineColorPicker = new ColorPicker();
			focusLabel4 = new FocusLabel();
			OutlineStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel5 = new FocusLabel();
			StartAngleTextBox = new EditBox();
			focusLabel2 = new FocusLabel();
			SweepAngleTextBox = new EditBox();
			focusLabel3 = new FocusLabel();
			groupBox2.SuspendLayout();
			base.SuspendLayout();
			label1.LoadingBegin();
			label1.FocusControl = HeightTextBox;
			label1.Location = new Point(49, 122);
			label1.Name = "label1";
			label1.Size = new Size(39, 15);
			label1.Text = "Height";
			label1.LoadingEnd();
			HeightTextBox.LoadingBegin();
			HeightTextBox.Location = new Point(88, 120);
			HeightTextBox.Name = "HeightTextBox";
			HeightTextBox.PropertyName = "Height";
			HeightTextBox.Size = new Size(48, 20);
			HeightTextBox.TabIndex = 7;
			HeightTextBox.LoadingEnd();
			CanMoveCheckBox.Location = new Point(272, 8);
			CanMoveCheckBox.Name = "CanMoveCheckBox";
			CanMoveCheckBox.PropertyName = "CanMove";
			CanMoveCheckBox.Size = new Size(80, 24);
			CanMoveCheckBox.TabIndex = 2;
			CanMoveCheckBox.Text = "Can Move";
			CanSizeCheckBox.Location = new Point(368, 8);
			CanSizeCheckBox.Name = "CanSizeCheckBox";
			CanSizeCheckBox.PropertyName = "CanSize";
			CanSizeCheckBox.Size = new Size(72, 24);
			CanSizeCheckBox.TabIndex = 3;
			CanSizeCheckBox.Text = "Can Size";
			label7.LoadingBegin();
			label7.FocusControl = WidthTextBox;
			label7.Location = new Point(52, 98);
			label7.Name = "label7";
			label7.Size = new Size(36, 15);
			label7.Text = "Width";
			label7.LoadingEnd();
			WidthTextBox.LoadingBegin();
			WidthTextBox.Location = new Point(88, 96);
			WidthTextBox.Name = "WidthTextBox";
			WidthTextBox.PropertyName = "Width";
			WidthTextBox.Size = new Size(48, 20);
			WidthTextBox.TabIndex = 6;
			WidthTextBox.LoadingEnd();
			XTextBox.LoadingBegin();
			XTextBox.Location = new Point(88, 48);
			XTextBox.Name = "XTextBox";
			XTextBox.PropertyName = "X";
			XTextBox.Size = new Size(48, 20);
			XTextBox.TabIndex = 4;
			XTextBox.LoadingEnd();
			label8.LoadingBegin();
			label8.FocusControl = XTextBox;
			label8.Location = new Point(73, 50);
			label8.Name = "label8";
			label8.Size = new Size(15, 15);
			label8.Text = "X";
			label8.LoadingEnd();
			YTextBox.LoadingBegin();
			YTextBox.Location = new Point(88, 72);
			YTextBox.Name = "YTextBox";
			YTextBox.PropertyName = "Y";
			YTextBox.Size = new Size(48, 20);
			YTextBox.TabIndex = 5;
			YTextBox.LoadingEnd();
			label9.LoadingBegin();
			label9.FocusControl = YTextBox;
			label9.Location = new Point(73, 74);
			label9.Name = "label9";
			label9.Size = new Size(15, 15);
			label9.Text = "Y";
			label9.LoadingEnd();
			EnabledCheckBox.Location = new Point(176, 8);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(72, 24);
			EnabledCheckBox.TabIndex = 1;
			EnabledCheckBox.Text = "Enabled";
			VisibleCheckBox.Location = new Point(88, 8);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			RotationTextBox.LoadingBegin();
			RotationTextBox.Location = new Point(88, 144);
			RotationTextBox.Name = "RotationTextBox";
			RotationTextBox.PropertyName = "Rotation";
			RotationTextBox.Size = new Size(48, 20);
			RotationTextBox.TabIndex = 8;
			RotationTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = RotationTextBox;
			focusLabel1.Location = new Point(39, 146);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(49, 15);
			focusLabel1.Text = "Rotation";
			focusLabel1.LoadingEnd();
			groupBox2.Controls.Add(OutlineColorPicker);
			groupBox2.Controls.Add(focusLabel4);
			groupBox2.Controls.Add(OutlineStyleComboBox);
			groupBox2.Controls.Add(focusLabel5);
			groupBox2.Location = new Point(152, 42);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(224, 88);
			groupBox2.TabIndex = 11;
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
			StartAngleTextBox.LoadingBegin();
			StartAngleTextBox.Location = new Point(88, 168);
			StartAngleTextBox.Name = "StartAngleTextBox";
			StartAngleTextBox.PropertyName = "StartAngle";
			StartAngleTextBox.Size = new Size(48, 20);
			StartAngleTextBox.TabIndex = 9;
			StartAngleTextBox.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = StartAngleTextBox;
			focusLabel2.Location = new Point(26, 170);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(62, 15);
			focusLabel2.Text = "Start Angle";
			focusLabel2.LoadingEnd();
			SweepAngleTextBox.LoadingBegin();
			SweepAngleTextBox.Location = new Point(88, 192);
			SweepAngleTextBox.Name = "SweepAngleTextBox";
			SweepAngleTextBox.PropertyName = "SweepAngle";
			SweepAngleTextBox.Size = new Size(48, 20);
			SweepAngleTextBox.TabIndex = 10;
			SweepAngleTextBox.LoadingEnd();
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = SweepAngleTextBox;
			focusLabel3.Location = new Point(16, 194);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(72, 15);
			focusLabel3.Text = "Sweep Angle";
			focusLabel3.LoadingEnd();
			base.Controls.Add(SweepAngleTextBox);
			base.Controls.Add(focusLabel3);
			base.Controls.Add(StartAngleTextBox);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(groupBox2);
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
			base.Location = new Point(10, 20);
			base.Name = "AnnotationArcEditorPlugIn";
			base.Size = new Size(528, 272);
			groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
