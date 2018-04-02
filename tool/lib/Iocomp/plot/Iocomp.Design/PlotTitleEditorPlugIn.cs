using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotTitleEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private FontButton FontButton;

		private FocusLabel focusLabel11;

		private ColorPicker ForeColorPicker;

		private EditMultiLine TextEditMultiLine;

		private FocusLabel focusLabel10;

		private Iocomp.Design.Plugin.EditorControls.ComboBox TextRotationComboBox;

		private FocusLabel label11;

		private EditBox MarginOuterTextBox;

		private FocusLabel focusLabel2;

		private EditBox MarginSpacingTextBox;

		private FocusLabel focusLabel3;

		private Container components;

		public PlotTitleEditorPlugIn()
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
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			ColorPicker = new ColorPicker();
			label8 = new FocusLabel();
			FontButton = new FontButton();
			focusLabel11 = new FocusLabel();
			ForeColorPicker = new ColorPicker();
			TextEditMultiLine = new EditMultiLine();
			focusLabel10 = new FocusLabel();
			TextRotationComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label11 = new FocusLabel();
			MarginOuterTextBox = new EditBox();
			focusLabel2 = new FocusLabel();
			MarginSpacingTextBox = new EditBox();
			focusLabel3 = new FocusLabel();
			base.SuspendLayout();
			VisibleCheckBox.Location = new Point(112, 8);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			ColorPicker.Location = new Point(112, 72);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(48, 21);
			ColorPicker.Style = ColorPickerStyle.ColorBox;
			ColorPicker.TabIndex = 2;
			label8.LoadingBegin();
			label8.FocusControl = ColorPicker;
			label8.Location = new Point(78, 75);
			label8.Name = "label8";
			label8.Size = new Size(34, 15);
			label8.Text = "Color";
			label8.LoadingEnd();
			FontButton.Location = new Point(304, 72);
			FontButton.Name = "FontButton";
			FontButton.PropertyName = "Font";
			FontButton.Size = new Size(72, 23);
			FontButton.TabIndex = 4;
			focusLabel11.LoadingBegin();
			focusLabel11.FocusControl = ForeColorPicker;
			focusLabel11.Location = new Point(181, 75);
			focusLabel11.Name = "focusLabel11";
			focusLabel11.Size = new Size(59, 15);
			focusLabel11.Text = "Fore Color";
			focusLabel11.LoadingEnd();
			ForeColorPicker.Location = new Point(240, 72);
			ForeColorPicker.Name = "ForeColorPicker";
			ForeColorPicker.PropertyName = "ForeColor";
			ForeColorPicker.Size = new Size(49, 21);
			ForeColorPicker.Style = ColorPickerStyle.ColorBox;
			ForeColorPicker.TabIndex = 3;
			TextEditMultiLine.EditFont = null;
			TextEditMultiLine.Location = new Point(112, 40);
			TextEditMultiLine.Name = "TextEditMultiLine";
			TextEditMultiLine.PropertyName = "Text";
			TextEditMultiLine.Size = new Size(264, 20);
			TextEditMultiLine.TabIndex = 1;
			focusLabel10.LoadingBegin();
			focusLabel10.FocusControl = TextEditMultiLine;
			focusLabel10.Location = new Point(83, 43);
			focusLabel10.Name = "focusLabel10";
			focusLabel10.Size = new Size(29, 15);
			focusLabel10.Text = "Text";
			focusLabel10.LoadingEnd();
			TextRotationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			TextRotationComboBox.Location = new Point(112, 160);
			TextRotationComboBox.Name = "TextRotationComboBox";
			TextRotationComboBox.PropertyName = "TextRotation";
			TextRotationComboBox.Size = new Size(121, 21);
			TextRotationComboBox.TabIndex = 7;
			label11.LoadingBegin();
			label11.FocusControl = TextRotationComboBox;
			label11.Location = new Point(63, 162);
			label11.Name = "label11";
			label11.Size = new Size(49, 15);
			label11.Text = "Rotation";
			label11.LoadingEnd();
			MarginOuterTextBox.LoadingBegin();
			MarginOuterTextBox.Location = new Point(112, 128);
			MarginOuterTextBox.Name = "MarginOuterTextBox";
			MarginOuterTextBox.PropertyName = "MarginOuter";
			MarginOuterTextBox.Size = new Size(88, 20);
			MarginOuterTextBox.TabIndex = 6;
			MarginOuterTextBox.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = MarginOuterTextBox;
			focusLabel2.Location = new Point(40, 130);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(72, 15);
			focusLabel2.Text = "Margin Outer";
			focusLabel2.LoadingEnd();
			MarginSpacingTextBox.LoadingBegin();
			MarginSpacingTextBox.Location = new Point(112, 104);
			MarginSpacingTextBox.Name = "MarginSpacingTextBox";
			MarginSpacingTextBox.PropertyName = "MarginSpacing";
			MarginSpacingTextBox.Size = new Size(88, 20);
			MarginSpacingTextBox.TabIndex = 5;
			MarginSpacingTextBox.LoadingEnd();
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = MarginSpacingTextBox;
			focusLabel3.Location = new Point(28, 106);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(84, 15);
			focusLabel3.Text = "Margin Spacing";
			focusLabel3.LoadingEnd();
			base.Controls.Add(MarginSpacingTextBox);
			base.Controls.Add(focusLabel3);
			base.Controls.Add(MarginOuterTextBox);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(TextRotationComboBox);
			base.Controls.Add(label11);
			base.Controls.Add(FontButton);
			base.Controls.Add(focusLabel11);
			base.Controls.Add(ForeColorPicker);
			base.Controls.Add(TextEditMultiLine);
			base.Controls.Add(focusLabel10);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label8);
			base.Controls.Add(VisibleCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotTitleEditorPlugIn";
			base.Size = new Size(504, 240);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new TextLayoutFullEditorPlugin(), "Text Layout", false);
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotTitle).TextLayout;
			base.SubPlugIns[1].Value = (base.Value as PlotTitle).Fill;
		}
	}
}
