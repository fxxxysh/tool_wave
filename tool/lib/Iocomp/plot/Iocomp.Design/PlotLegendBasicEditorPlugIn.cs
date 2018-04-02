using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotLegendBasicEditorPlugIn : PlugInStandard
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

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private EditBox MarginOuterTextBox;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private EditBox SpacingEditBox;

		private FocusLabel focusLabel3;

		private EditBox TitleMarginEditBox;

		private FocusLabel focusLabel4;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel15;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotLegendBasicEditorPlugIn()
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
			ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label1 = new FocusLabel();
			MarginOuterTextBox = new EditBox();
			focusLabel2 = new FocusLabel();
			UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			SpacingEditBox = new EditBox();
			focusLabel3 = new FocusLabel();
			TitleMarginEditBox = new EditBox();
			focusLabel4 = new FocusLabel();
			TitleTextBox = new EditMultiLine();
			focusLabel15 = new FocusLabel();
			CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			VisibleCheckBox.Location = new Point(288, 11);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 9;
			VisibleCheckBox.Text = "Visible";
			EnabledCheckBox.Location = new Point(288, 35);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(80, 24);
			EnabledCheckBox.TabIndex = 10;
			EnabledCheckBox.Text = "Enabled";
			NameTextBox.LoadingBegin();
			NameTextBox.Location = new Point(104, 16);
			NameTextBox.Name = "NameTextBox";
			NameTextBox.PropertyName = "Name";
			NameTextBox.Size = new Size(144, 20);
			NameTextBox.TabIndex = 0;
			NameTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = NameTextBox;
			focusLabel1.Location = new Point(67, 18);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(37, 15);
			focusLabel1.Text = "Name";
			focusLabel1.LoadingEnd();
			ColorPicker.Location = new Point(104, 80);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(48, 21);
			ColorPicker.Style = ColorPickerStyle.ColorBox;
			ColorPicker.TabIndex = 2;
			label8.LoadingBegin();
			label8.FocusControl = ColorPicker;
			label8.Location = new Point(70, 83);
			label8.Name = "label8";
			label8.Size = new Size(34, 15);
			label8.Text = "Color";
			label8.LoadingEnd();
			FontButton.Location = new Point(176, 144);
			FontButton.Name = "FontButton";
			FontButton.PropertyName = "Font";
			FontButton.Size = new Size(72, 23);
			FontButton.TabIndex = 6;
			focusLabel11.LoadingBegin();
			focusLabel11.FocusControl = ForeColorPicker;
			focusLabel11.Location = new Point(45, 147);
			focusLabel11.Name = "focusLabel11";
			focusLabel11.Size = new Size(59, 15);
			focusLabel11.Text = "Fore Color";
			focusLabel11.LoadingEnd();
			ForeColorPicker.Location = new Point(104, 144);
			ForeColorPicker.Name = "ForeColorPicker";
			ForeColorPicker.PropertyName = "ForeColor";
			ForeColorPicker.Size = new Size(49, 21);
			ForeColorPicker.Style = ColorPickerStyle.ColorBox;
			ForeColorPicker.TabIndex = 5;
			ContextMenuEnabledCheckBox.Location = new Point(288, 59);
			ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			ContextMenuEnabledCheckBox.Size = new Size(152, 24);
			ContextMenuEnabledCheckBox.TabIndex = 11;
			ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			LayerNumericUpDown.Location = new Point(192, 80);
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
			LayerNumericUpDown.TabIndex = 3;
			LayerNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label1.LoadingBegin();
			label1.FocusControl = LayerNumericUpDown;
			label1.Location = new Point(157, 81);
			label1.Name = "label1";
			label1.Size = new Size(35, 15);
			label1.Text = "Layer";
			label1.LoadingEnd();
			MarginOuterTextBox.LoadingBegin();
			MarginOuterTextBox.Location = new Point(104, 112);
			MarginOuterTextBox.Name = "MarginOuterTextBox";
			MarginOuterTextBox.PropertyName = "MarginOuter";
			MarginOuterTextBox.Size = new Size(88, 20);
			MarginOuterTextBox.TabIndex = 4;
			MarginOuterTextBox.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = MarginOuterTextBox;
			focusLabel2.Location = new Point(32, 114);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(72, 15);
			focusLabel2.Text = "Margin Outer";
			focusLabel2.LoadingEnd();
			UserCanEditCheckBox.Location = new Point(288, 83);
			UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			UserCanEditCheckBox.PropertyName = "UserCanEdit";
			UserCanEditCheckBox.Size = new Size(96, 24);
			UserCanEditCheckBox.TabIndex = 12;
			UserCanEditCheckBox.Text = "User Can Edit";
			SpacingEditBox.LoadingBegin();
			SpacingEditBox.Location = new Point(104, 184);
			SpacingEditBox.Name = "SpacingEditBox";
			SpacingEditBox.PropertyName = "Spacing";
			SpacingEditBox.Size = new Size(88, 20);
			SpacingEditBox.TabIndex = 7;
			SpacingEditBox.LoadingEnd();
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = SpacingEditBox;
			focusLabel3.Location = new Point(57, 186);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(47, 15);
			focusLabel3.Text = "Spacing";
			focusLabel3.LoadingEnd();
			TitleMarginEditBox.LoadingBegin();
			TitleMarginEditBox.Location = new Point(104, 208);
			TitleMarginEditBox.Name = "TitleMarginEditBox";
			TitleMarginEditBox.PropertyName = "TitleMargin";
			TitleMarginEditBox.Size = new Size(88, 20);
			TitleMarginEditBox.TabIndex = 8;
			TitleMarginEditBox.LoadingEnd();
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = TitleMarginEditBox;
			focusLabel4.Location = new Point(39, 210);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(65, 15);
			focusLabel4.Text = "Title Margin";
			focusLabel4.LoadingEnd();
			TitleTextBox.EditFont = null;
			TitleTextBox.Location = new Point(104, 48);
			TitleTextBox.Name = "TitleTextBox";
			TitleTextBox.PropertyName = "TitleText";
			TitleTextBox.Size = new Size(144, 20);
			TitleTextBox.TabIndex = 1;
			focusLabel15.LoadingBegin();
			focusLabel15.FocusControl = TitleTextBox;
			focusLabel15.Location = new Point(51, 51);
			focusLabel15.Name = "focusLabel15";
			focusLabel15.Size = new Size(53, 15);
			focusLabel15.Text = "Title Text";
			focusLabel15.LoadingEnd();
			CanFocusCheckBox.Location = new Point(288, 107);
			CanFocusCheckBox.Name = "CanFocusCheckBox";
			CanFocusCheckBox.PropertyName = "CanFocus";
			CanFocusCheckBox.Size = new Size(80, 24);
			CanFocusCheckBox.TabIndex = 13;
			CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(CanFocusCheckBox);
			base.Controls.Add(TitleTextBox);
			base.Controls.Add(focusLabel15);
			base.Controls.Add(TitleMarginEditBox);
			base.Controls.Add(focusLabel4);
			base.Controls.Add(SpacingEditBox);
			base.Controls.Add(focusLabel3);
			base.Controls.Add(UserCanEditCheckBox);
			base.Controls.Add(MarginOuterTextBox);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(LayerNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(ContextMenuEnabledCheckBox);
			base.Controls.Add(focusLabel11);
			base.Controls.Add(ForeColorPicker);
			base.Controls.Add(FontButton);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label8);
			base.Controls.Add(NameTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotLegendBasicEditorPlugIn";
			base.Size = new Size(456, 256);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill", false);
			base.AddSubPlugIn(new PlotLegendWrappingEditorPlugIn(), "Wrapping", false);
			base.AddSubPlugIn(new PlotLayoutDockableAllEditorPlugIn(), "Dock", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotLegendBasic).Fill;
			base.SubPlugIns[1].Value = (base.Value as PlotLegendBasic).Wrapping;
			base.SubPlugIns[2].Value = base.Value;
		}
	}
}
