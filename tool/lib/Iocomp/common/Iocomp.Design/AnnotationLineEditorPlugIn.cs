using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class AnnotationLineEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanSizeCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanMoveCheckBox;

		private GroupBox groupBox2;

		private ColorPicker OutlineColorPicker;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox OutlineStyleComboBox;

		private FocusLabel focusLabel5;

		private GroupBox Point1GroupBox;

		private EditBox Point1YTextBox;

		private FocusLabel label12;

		private EditBox Point1XTextBox;

		private FocusLabel label11;

		private GroupBox groupBox1;

		private EditBox Point2YTextBox;

		private FocusLabel focusLabel2;

		private EditBox Point2XTextBox;

		private FocusLabel focusLabel3;

		private EditBox RotationTextBox;

		private FocusLabel focusLabel1;

		private EditBox YTextBox;

		private FocusLabel label9;

		private EditBox XTextBox;

		private FocusLabel label8;

		private EditBox HeightTextBox;

		private EditBox WidthTextBox;

		private FocusLabel label7;

		private FocusLabel label1;

		private Container components;

		public AnnotationLineEditorPlugIn()
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
			EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			CanSizeCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			CanMoveCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			groupBox2 = new GroupBox();
			OutlineColorPicker = new ColorPicker();
			focusLabel4 = new FocusLabel();
			OutlineStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel5 = new FocusLabel();
			Point1GroupBox = new GroupBox();
			Point1YTextBox = new EditBox();
			label12 = new FocusLabel();
			Point1XTextBox = new EditBox();
			label11 = new FocusLabel();
			groupBox1 = new GroupBox();
			Point2YTextBox = new EditBox();
			focusLabel2 = new FocusLabel();
			Point2XTextBox = new EditBox();
			focusLabel3 = new FocusLabel();
			RotationTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			YTextBox = new EditBox();
			label9 = new FocusLabel();
			XTextBox = new EditBox();
			label8 = new FocusLabel();
			HeightTextBox = new EditBox();
			WidthTextBox = new EditBox();
			label7 = new FocusLabel();
			label1 = new FocusLabel();
			groupBox2.SuspendLayout();
			Point1GroupBox.SuspendLayout();
			groupBox1.SuspendLayout();
			base.SuspendLayout();
			EnabledCheckBox.Location = new Point(144, 16);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(72, 24);
			EnabledCheckBox.TabIndex = 1;
			EnabledCheckBox.Text = "Enabled";
			VisibleCheckBox.Location = new Point(56, 16);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			CanSizeCheckBox.Location = new Point(328, 16);
			CanSizeCheckBox.Name = "CanSizeCheckBox";
			CanSizeCheckBox.PropertyName = "CanSize";
			CanSizeCheckBox.Size = new Size(72, 24);
			CanSizeCheckBox.TabIndex = 3;
			CanSizeCheckBox.Text = "Can Size";
			CanMoveCheckBox.Location = new Point(240, 16);
			CanMoveCheckBox.Name = "CanMoveCheckBox";
			CanMoveCheckBox.PropertyName = "CanMove";
			CanMoveCheckBox.Size = new Size(80, 24);
			CanMoveCheckBox.TabIndex = 2;
			CanMoveCheckBox.Text = "Can Move";
			groupBox2.Controls.Add(OutlineColorPicker);
			groupBox2.Controls.Add(focusLabel4);
			groupBox2.Controls.Add(OutlineStyleComboBox);
			groupBox2.Controls.Add(focusLabel5);
			groupBox2.Location = new Point(296, 50);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(208, 124);
			groupBox2.TabIndex = 11;
			groupBox2.TabStop = false;
			groupBox2.Text = "Outline";
			OutlineColorPicker.Location = new Point(48, 72);
			OutlineColorPicker.Name = "OutlineColorPicker";
			OutlineColorPicker.PropertyName = "OutlineColor";
			OutlineColorPicker.Size = new Size(144, 21);
			OutlineColorPicker.TabIndex = 1;
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = OutlineColorPicker;
			focusLabel4.Location = new Point(14, 75);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(34, 15);
			focusLabel4.Text = "Color";
			focusLabel4.LoadingEnd();
			OutlineStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			OutlineStyleComboBox.Location = new Point(48, 40);
			OutlineStyleComboBox.Name = "OutlineStyleComboBox";
			OutlineStyleComboBox.PropertyName = "OutlineStyle";
			OutlineStyleComboBox.Size = new Size(144, 21);
			OutlineStyleComboBox.TabIndex = 0;
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = OutlineStyleComboBox;
			focusLabel5.Location = new Point(16, 42);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(32, 15);
			focusLabel5.Text = "Style";
			focusLabel5.LoadingEnd();
			Point1GroupBox.Controls.Add(Point1YTextBox);
			Point1GroupBox.Controls.Add(label12);
			Point1GroupBox.Controls.Add(Point1XTextBox);
			Point1GroupBox.Controls.Add(label11);
			Point1GroupBox.Location = new Point(120, 50);
			Point1GroupBox.Name = "Point1GroupBox";
			Point1GroupBox.Size = new Size(168, 56);
			Point1GroupBox.TabIndex = 9;
			Point1GroupBox.TabStop = false;
			Point1GroupBox.Text = "Point 1";
			Point1YTextBox.LoadingBegin();
			Point1YTextBox.Location = new Point(104, 24);
			Point1YTextBox.Name = "Point1YTextBox";
			Point1YTextBox.PropertyName = "Point1Y";
			Point1YTextBox.Size = new Size(48, 20);
			Point1YTextBox.TabIndex = 1;
			Point1YTextBox.LoadingEnd();
			label12.LoadingBegin();
			label12.FocusControl = Point1YTextBox;
			label12.Location = new Point(89, 26);
			label12.Name = "label12";
			label12.Size = new Size(15, 15);
			label12.Text = "Y";
			label12.LoadingEnd();
			Point1XTextBox.LoadingBegin();
			Point1XTextBox.Location = new Point(32, 24);
			Point1XTextBox.Name = "Point1XTextBox";
			Point1XTextBox.PropertyName = "Point1X";
			Point1XTextBox.Size = new Size(48, 20);
			Point1XTextBox.TabIndex = 0;
			Point1XTextBox.LoadingEnd();
			label11.LoadingBegin();
			label11.FocusControl = Point1XTextBox;
			label11.Location = new Point(17, 26);
			label11.Name = "label11";
			label11.Size = new Size(15, 15);
			label11.Text = "X";
			label11.LoadingEnd();
			groupBox1.Controls.Add(Point2YTextBox);
			groupBox1.Controls.Add(focusLabel2);
			groupBox1.Controls.Add(Point2XTextBox);
			groupBox1.Controls.Add(focusLabel3);
			groupBox1.Location = new Point(120, 118);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(168, 56);
			groupBox1.TabIndex = 10;
			groupBox1.TabStop = false;
			groupBox1.Text = "Point 2";
			Point2YTextBox.LoadingBegin();
			Point2YTextBox.Location = new Point(104, 24);
			Point2YTextBox.Name = "Point2YTextBox";
			Point2YTextBox.PropertyName = "Point2Y";
			Point2YTextBox.Size = new Size(48, 20);
			Point2YTextBox.TabIndex = 1;
			Point2YTextBox.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = Point2YTextBox;
			focusLabel2.Location = new Point(89, 26);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(15, 15);
			focusLabel2.Text = "Y";
			focusLabel2.LoadingEnd();
			Point2XTextBox.LoadingBegin();
			Point2XTextBox.Location = new Point(32, 24);
			Point2XTextBox.Name = "Point2XTextBox";
			Point2XTextBox.PropertyName = "Point2X";
			Point2XTextBox.Size = new Size(48, 20);
			Point2XTextBox.TabIndex = 0;
			Point2XTextBox.LoadingEnd();
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = Point2XTextBox;
			focusLabel3.Location = new Point(17, 26);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(15, 15);
			focusLabel3.Text = "X";
			focusLabel3.LoadingEnd();
			RotationTextBox.LoadingBegin();
			RotationTextBox.Location = new Point(56, 152);
			RotationTextBox.Name = "RotationTextBox";
			RotationTextBox.PropertyName = "Rotation";
			RotationTextBox.Size = new Size(48, 20);
			RotationTextBox.TabIndex = 8;
			RotationTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = RotationTextBox;
			focusLabel1.Location = new Point(7, 154);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(49, 15);
			focusLabel1.Text = "Rotation";
			focusLabel1.LoadingEnd();
			YTextBox.LoadingBegin();
			YTextBox.Location = new Point(56, 80);
			YTextBox.Name = "YTextBox";
			YTextBox.PropertyName = "Y";
			YTextBox.Size = new Size(48, 20);
			YTextBox.TabIndex = 5;
			YTextBox.LoadingEnd();
			label9.LoadingBegin();
			label9.FocusControl = YTextBox;
			label9.Location = new Point(41, 82);
			label9.Name = "label9";
			label9.Size = new Size(15, 15);
			label9.Text = "Y";
			label9.LoadingEnd();
			XTextBox.LoadingBegin();
			XTextBox.Location = new Point(56, 56);
			XTextBox.Name = "XTextBox";
			XTextBox.PropertyName = "X";
			XTextBox.Size = new Size(48, 20);
			XTextBox.TabIndex = 4;
			XTextBox.LoadingEnd();
			label8.LoadingBegin();
			label8.FocusControl = XTextBox;
			label8.Location = new Point(41, 58);
			label8.Name = "label8";
			label8.Size = new Size(15, 15);
			label8.Text = "X";
			label8.LoadingEnd();
			HeightTextBox.LoadingBegin();
			HeightTextBox.Location = new Point(56, 128);
			HeightTextBox.Name = "HeightTextBox";
			HeightTextBox.PropertyName = "Height";
			HeightTextBox.Size = new Size(48, 20);
			HeightTextBox.TabIndex = 7;
			HeightTextBox.LoadingEnd();
			WidthTextBox.LoadingBegin();
			WidthTextBox.Location = new Point(56, 104);
			WidthTextBox.Name = "WidthTextBox";
			WidthTextBox.PropertyName = "Width";
			WidthTextBox.Size = new Size(48, 20);
			WidthTextBox.TabIndex = 6;
			WidthTextBox.LoadingEnd();
			label7.LoadingBegin();
			label7.FocusControl = WidthTextBox;
			label7.Location = new Point(20, 106);
			label7.Name = "label7";
			label7.Size = new Size(36, 15);
			label7.Text = "Width";
			label7.LoadingEnd();
			label1.LoadingBegin();
			label1.FocusControl = HeightTextBox;
			label1.Location = new Point(17, 130);
			label1.Name = "label1";
			label1.Size = new Size(39, 15);
			label1.Text = "Height";
			label1.LoadingEnd();
			base.Controls.Add(RotationTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(YTextBox);
			base.Controls.Add(label9);
			base.Controls.Add(XTextBox);
			base.Controls.Add(label8);
			base.Controls.Add(HeightTextBox);
			base.Controls.Add(WidthTextBox);
			base.Controls.Add(label7);
			base.Controls.Add(label1);
			base.Controls.Add(groupBox1);
			base.Controls.Add(Point1GroupBox);
			base.Controls.Add(groupBox2);
			base.Controls.Add(EnabledCheckBox);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(CanSizeCheckBox);
			base.Controls.Add(CanMoveCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "AnnotationLineEditorPlugIn";
			base.Size = new Size(536, 208);
			groupBox2.ResumeLayout(false);
			Point1GroupBox.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
