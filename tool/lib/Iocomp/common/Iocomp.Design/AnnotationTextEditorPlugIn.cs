using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class AnnotationTextEditorPlugIn : PlugInStandard
	{
		private FocusLabel label1;

		private CheckBox CanMoveCheckBox;

		private CheckBox CanSizeCheckBox;

		private FocusLabel label7;

		private EditBox WidthTextBox;

		private EditBox HeightTextBox;

		private EditBox XTextBox;

		private FocusLabel label8;

		private EditBox YTextBox;

		private FocusLabel label9;

		private CheckBox EnabledCheckBox;

		private CheckBox VisibleCheckBox;

		private EditBox RotationTextBox;

		private FocusLabel focusLabel1;

		private CheckBox FixedSizeCheckBox;

		private FocusLabel focusLabel2;

		private EditMultiLine TextEditMultiLine;

		private FontButton FontButton;

		private FocusLabel focusLabel11;

		private ColorPicker ForeColorPicker;

		private Container components;

		public AnnotationTextEditorPlugIn()
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
			CanMoveCheckBox = new CheckBox();
			CanSizeCheckBox = new CheckBox();
			label7 = new FocusLabel();
			WidthTextBox = new EditBox();
			XTextBox = new EditBox();
			label8 = new FocusLabel();
			YTextBox = new EditBox();
			label9 = new FocusLabel();
			EnabledCheckBox = new CheckBox();
			VisibleCheckBox = new CheckBox();
			RotationTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			FixedSizeCheckBox = new CheckBox();
			focusLabel2 = new FocusLabel();
			TextEditMultiLine = new EditMultiLine();
			FontButton = new FontButton();
			focusLabel11 = new FocusLabel();
			ForeColorPicker = new ColorPicker();
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
			FixedSizeCheckBox.Location = new Point(432, 8);
			FixedSizeCheckBox.Name = "FixedSizeCheckBox";
			FixedSizeCheckBox.PropertyName = "FixedSize";
			FixedSizeCheckBox.Size = new Size(80, 24);
			FixedSizeCheckBox.TabIndex = 4;
			FixedSizeCheckBox.Text = "Fixed Size";
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = TextEditMultiLine;
			focusLabel2.Location = new Point(147, 51);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(29, 15);
			focusLabel2.Text = "Text";
			focusLabel2.LoadingEnd();
			TextEditMultiLine.EditFont = null;
			TextEditMultiLine.Location = new Point(176, 48);
			TextEditMultiLine.Name = "TextEditMultiLine";
			TextEditMultiLine.PropertyName = "Text";
			TextEditMultiLine.Size = new Size(320, 20);
			TextEditMultiLine.TabIndex = 10;
			FontButton.Location = new Point(176, 80);
			FontButton.Name = "FontButton";
			FontButton.PropertyName = "Font";
			FontButton.Size = new Size(72, 23);
			FontButton.TabIndex = 11;
			focusLabel11.LoadingBegin();
			focusLabel11.FocusControl = ForeColorPicker;
			focusLabel11.Location = new Point(261, 83);
			focusLabel11.Name = "focusLabel11";
			focusLabel11.Size = new Size(59, 15);
			focusLabel11.Text = "Fore Color";
			focusLabel11.LoadingEnd();
			ForeColorPicker.Location = new Point(320, 80);
			ForeColorPicker.Name = "ForeColorPicker";
			ForeColorPicker.PropertyName = "ForeColor";
			ForeColorPicker.Size = new Size(49, 21);
			ForeColorPicker.Style = ColorPickerStyle.ColorBox;
			ForeColorPicker.TabIndex = 12;
			base.Controls.Add(FontButton);
			base.Controls.Add(focusLabel11);
			base.Controls.Add(ForeColorPicker);
			base.Controls.Add(TextEditMultiLine);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(FixedSizeCheckBox);
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
			base.Name = "AnnotationTextEditorPlugIn";
			base.Size = new Size(528, 272);
			base.ResumeLayout(false);
		}
	}
}
