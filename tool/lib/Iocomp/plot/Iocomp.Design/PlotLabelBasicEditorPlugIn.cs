using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotLabelBasicEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

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

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown ImageIndexUpDown;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ImageTransparentCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotLabelBasicEditorPlugIn()
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
			EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			NameTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
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
			ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label1 = new FocusLabel();
			UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			ImageIndexUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			focusLabel3 = new FocusLabel();
			ImageTransparentCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			VisibleCheckBox.Location = new Point(344, 4);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 10;
			VisibleCheckBox.Text = "Visible";
			EnabledCheckBox.Location = new Point(344, 28);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(80, 24);
			EnabledCheckBox.TabIndex = 11;
			EnabledCheckBox.Text = "Enabled";
			NameTextBox.LoadingBegin();
			NameTextBox.Location = new Point(112, 8);
			NameTextBox.Name = "NameTextBox";
			NameTextBox.PropertyName = "Name";
			NameTextBox.Size = new Size(144, 20);
			NameTextBox.TabIndex = 0;
			NameTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = NameTextBox;
			focusLabel1.Location = new Point(75, 10);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(37, 15);
			focusLabel1.Text = "Name";
			focusLabel1.LoadingEnd();
			ColorPicker.Location = new Point(112, 112);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(48, 21);
			ColorPicker.Style = ColorPickerStyle.ColorBox;
			ColorPicker.TabIndex = 4;
			label8.LoadingBegin();
			label8.FocusControl = ColorPicker;
			label8.Location = new Point(78, 115);
			label8.Name = "label8";
			label8.Size = new Size(34, 15);
			label8.Text = "Color";
			label8.LoadingEnd();
			FontButton.Location = new Point(176, 208);
			FontButton.Name = "FontButton";
			FontButton.PropertyName = "Font";
			FontButton.Size = new Size(72, 23);
			FontButton.TabIndex = 9;
			focusLabel11.LoadingBegin();
			focusLabel11.FocusControl = ForeColorPicker;
			focusLabel11.Location = new Point(53, 211);
			focusLabel11.Name = "focusLabel11";
			focusLabel11.Size = new Size(59, 15);
			focusLabel11.Text = "Fore Color";
			focusLabel11.LoadingEnd();
			ForeColorPicker.Location = new Point(112, 208);
			ForeColorPicker.Name = "ForeColorPicker";
			ForeColorPicker.PropertyName = "ForeColor";
			ForeColorPicker.Size = new Size(49, 21);
			ForeColorPicker.Style = ColorPickerStyle.ColorBox;
			ForeColorPicker.TabIndex = 8;
			TextEditMultiLine.EditFont = null;
			TextEditMultiLine.Location = new Point(112, 40);
			TextEditMultiLine.Name = "TextEditMultiLine";
			TextEditMultiLine.PropertyName = "Text";
			TextEditMultiLine.Size = new Size(208, 20);
			TextEditMultiLine.TabIndex = 1;
			focusLabel10.LoadingBegin();
			focusLabel10.FocusControl = TextEditMultiLine;
			focusLabel10.Location = new Point(83, 43);
			focusLabel10.Name = "focusLabel10";
			focusLabel10.Size = new Size(29, 15);
			focusLabel10.Text = "Text";
			focusLabel10.LoadingEnd();
			TextRotationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			TextRotationComboBox.Location = new Point(112, 176);
			TextRotationComboBox.Name = "TextRotationComboBox";
			TextRotationComboBox.PropertyName = "TextRotation";
			TextRotationComboBox.Size = new Size(121, 21);
			TextRotationComboBox.TabIndex = 7;
			label11.LoadingBegin();
			label11.FocusControl = TextRotationComboBox;
			label11.Location = new Point(63, 178);
			label11.Name = "label11";
			label11.Size = new Size(49, 15);
			label11.Text = "Rotation";
			label11.LoadingEnd();
			MarginOuterTextBox.LoadingBegin();
			MarginOuterTextBox.Location = new Point(112, 144);
			MarginOuterTextBox.Name = "MarginOuterTextBox";
			MarginOuterTextBox.PropertyName = "MarginOuter";
			MarginOuterTextBox.Size = new Size(88, 20);
			MarginOuterTextBox.TabIndex = 6;
			MarginOuterTextBox.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = MarginOuterTextBox;
			focusLabel2.Location = new Point(40, 146);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(72, 15);
			focusLabel2.Text = "Margin Outer";
			focusLabel2.LoadingEnd();
			ContextMenuEnabledCheckBox.Location = new Point(344, 52);
			ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			ContextMenuEnabledCheckBox.Size = new Size(144, 24);
			ContextMenuEnabledCheckBox.TabIndex = 12;
			ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			LayerNumericUpDown.Location = new Point(200, 112);
			LayerNumericUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			LayerNumericUpDown.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			LayerNumericUpDown.Name = "LayerNumericUpDown";
			LayerNumericUpDown.PropertyName = "Layer";
			LayerNumericUpDown.Size = new Size(56, 20);
			LayerNumericUpDown.TabIndex = 5;
			LayerNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label1.LoadingBegin();
			label1.FocusControl = LayerNumericUpDown;
			label1.Location = new Point(165, 113);
			label1.Name = "label1";
			label1.Size = new Size(35, 15);
			label1.Text = "Layer";
			label1.LoadingEnd();
			UserCanEditCheckBox.Location = new Point(344, 76);
			UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			UserCanEditCheckBox.PropertyName = "UserCanEdit";
			UserCanEditCheckBox.Size = new Size(96, 24);
			UserCanEditCheckBox.TabIndex = 13;
			UserCanEditCheckBox.Text = "User Can Edit";
			ImageIndexUpDown.Location = new Point(112, 72);
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
			ImageIndexUpDown.TabIndex = 2;
			ImageIndexUpDown.TextAlign = HorizontalAlignment.Center;
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = ImageIndexUpDown;
			focusLabel3.Location = new Point(44, 73);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(68, 15);
			focusLabel3.Text = "Image Index";
			focusLabel3.LoadingEnd();
			ImageTransparentCheckBox.Location = new Point(174, 70);
			ImageTransparentCheckBox.Name = "ImageTransparentCheckBox";
			ImageTransparentCheckBox.PropertyName = "ImageTransparent";
			ImageTransparentCheckBox.Size = new Size(128, 24);
			ImageTransparentCheckBox.TabIndex = 3;
			ImageTransparentCheckBox.Text = "Image Transparent";
			CanFocusCheckBox.Location = new Point(344, 100);
			CanFocusCheckBox.Name = "CanFocusCheckBox";
			CanFocusCheckBox.PropertyName = "CanFocus";
			CanFocusCheckBox.Size = new Size(80, 24);
			CanFocusCheckBox.TabIndex = 14;
			CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(CanFocusCheckBox);
			base.Controls.Add(ImageTransparentCheckBox);
			base.Controls.Add(ImageIndexUpDown);
			base.Controls.Add(focusLabel3);
			base.Controls.Add(UserCanEditCheckBox);
			base.Controls.Add(LayerNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(ContextMenuEnabledCheckBox);
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
			base.Controls.Add(NameTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotLabelBasicEditorPlugIn";
			base.Size = new Size(504, 256);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new TextLayoutFullEditorPlugin(), "Text Layout", false);
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill", false);
			base.AddSubPlugIn(new PlotLayoutDockableAllEditorPlugIn(), "Dock", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotLabelBasic).TextLayout;
			base.SubPlugIns[1].Value = (base.Value as PlotLabelBasic).Fill;
			base.SubPlugIns[2].Value = base.Value;
		}
	}
}
