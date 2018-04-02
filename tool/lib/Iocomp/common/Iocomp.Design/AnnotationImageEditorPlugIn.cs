using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class AnnotationImageEditorPlugIn : PlugInStandard
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

		private FocusLabel focusLabel5;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown ImageIndexUpDown;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.CheckBox FixedSizeCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ImageListStyleComboBox;

		private Container components;

		public AnnotationImageEditorPlugIn()
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
			ImageIndexUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			focusLabel4 = new FocusLabel();
			ImageListStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel5 = new FocusLabel();
			FixedSizeCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			groupBox2.SuspendLayout();
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
			groupBox2.Controls.Add(ImageIndexUpDown);
			groupBox2.Controls.Add(focusLabel4);
			groupBox2.Controls.Add(ImageListStyleComboBox);
			groupBox2.Controls.Add(focusLabel5);
			groupBox2.Location = new Point(128, 42);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(264, 88);
			groupBox2.TabIndex = 10;
			groupBox2.TabStop = false;
			groupBox2.Text = "Image";
			ImageIndexUpDown.Location = new Point(64, 56);
			ImageIndexUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			ImageIndexUpDown.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				-2147483648
			});
			ImageIndexUpDown.Name = "ImageIndexUpDown";
			ImageIndexUpDown.PropertyName = "ImageIndex";
			ImageIndexUpDown.Size = new Size(56, 20);
			ImageIndexUpDown.TabIndex = 1;
			ImageIndexUpDown.TextAlign = HorizontalAlignment.Center;
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = ImageIndexUpDown;
			focusLabel4.Location = new Point(30, 57);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(34, 15);
			focusLabel4.Text = "Index";
			focusLabel4.LoadingEnd();
			ImageListStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ImageListStyleComboBox.Location = new Point(64, 24);
			ImageListStyleComboBox.Name = "ImageListStyleComboBox";
			ImageListStyleComboBox.PropertyName = "ImageListStyle";
			ImageListStyleComboBox.Size = new Size(144, 21);
			ImageListStyleComboBox.TabIndex = 0;
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = ImageListStyleComboBox;
			focusLabel5.Location = new Point(12, 26);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(52, 15);
			focusLabel5.Text = "List Style";
			focusLabel5.LoadingEnd();
			FixedSizeCheckBox.Location = new Point(432, 8);
			FixedSizeCheckBox.Name = "FixedSizeCheckBox";
			FixedSizeCheckBox.PropertyName = "FixedSize";
			FixedSizeCheckBox.Size = new Size(96, 24);
			FixedSizeCheckBox.TabIndex = 4;
			FixedSizeCheckBox.Text = "Fixed Size";
			base.Controls.Add(FixedSizeCheckBox);
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
			base.Name = "AnnotationImageEditorPlugIn";
			base.Size = new Size(528, 272);
			groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
