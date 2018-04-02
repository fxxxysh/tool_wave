using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotDataViewEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private GroupBox groupBox1;

		private FocusLabel focusLabel2;

		private FocusLabel focusLabel3;

		private EditBox GridLinesMirrorHorizontalTextBox;

		private EditBox GridLinesMirrorVerticalTextBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private GroupBox groupBox2;

		private Iocomp.Design.Plugin.EditorControls.ComboBox AxesControlMouseStyleComboBox;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.CheckBox AxesControlEnabledCheckBox;

		private FocusLabel focusLabel5;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.ComboBox AxesControlWheelStyleComboBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox AxesControlKeyboardStyleComboBox;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel15;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotDataViewEditorPlugIn()
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
			groupBox1 = new GroupBox();
			GridLinesMirrorHorizontalTextBox = new EditBox();
			focusLabel3 = new FocusLabel();
			GridLinesMirrorVerticalTextBox = new EditBox();
			focusLabel2 = new FocusLabel();
			ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label1 = new FocusLabel();
			UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			groupBox2 = new GroupBox();
			focusLabel6 = new FocusLabel();
			AxesControlKeyboardStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel5 = new FocusLabel();
			AxesControlWheelStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel4 = new FocusLabel();
			AxesControlMouseStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			AxesControlEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			TitleTextBox = new EditMultiLine();
			focusLabel15 = new FocusLabel();
			CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			base.SuspendLayout();
			VisibleCheckBox.Location = new Point(248, 3);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 4;
			VisibleCheckBox.Text = "Visible";
			EnabledCheckBox.Location = new Point(248, 27);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(80, 24);
			EnabledCheckBox.TabIndex = 5;
			EnabledCheckBox.Text = "Enabled";
			NameTextBox.LoadingBegin();
			NameTextBox.Location = new Point(80, 8);
			NameTextBox.Name = "NameTextBox";
			NameTextBox.PropertyName = "Name";
			NameTextBox.Size = new Size(144, 20);
			NameTextBox.TabIndex = 0;
			NameTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = NameTextBox;
			focusLabel1.Location = new Point(43, 10);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(37, 15);
			focusLabel1.Text = "Name";
			focusLabel1.LoadingEnd();
			ColorPicker.Location = new Point(80, 72);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(48, 21);
			ColorPicker.Style = ColorPickerStyle.ColorBox;
			ColorPicker.TabIndex = 2;
			label8.LoadingBegin();
			label8.FocusControl = ColorPicker;
			label8.Location = new Point(46, 75);
			label8.Name = "label8";
			label8.Size = new Size(34, 15);
			label8.Text = "Color";
			label8.LoadingEnd();
			groupBox1.Controls.Add(GridLinesMirrorHorizontalTextBox);
			groupBox1.Controls.Add(focusLabel3);
			groupBox1.Controls.Add(GridLinesMirrorVerticalTextBox);
			groupBox1.Controls.Add(focusLabel2);
			groupBox1.Location = new Point(16, 112);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(200, 136);
			groupBox1.TabIndex = 9;
			groupBox1.TabStop = false;
			groupBox1.Text = "Grid-Lines Mirror (DataView-Name)";
			GridLinesMirrorHorizontalTextBox.LoadingBegin();
			GridLinesMirrorHorizontalTextBox.Location = new Point(72, 56);
			GridLinesMirrorHorizontalTextBox.Name = "GridLinesMirrorHorizontalTextBox";
			GridLinesMirrorHorizontalTextBox.PropertyName = "GridLinesMirrorHorizontal";
			GridLinesMirrorHorizontalTextBox.Size = new Size(112, 20);
			GridLinesMirrorHorizontalTextBox.TabIndex = 1;
			GridLinesMirrorHorizontalTextBox.LoadingEnd();
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = GridLinesMirrorHorizontalTextBox;
			focusLabel3.Location = new Point(15, 58);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(57, 15);
			focusLabel3.Text = "Horizontal";
			focusLabel3.LoadingEnd();
			GridLinesMirrorVerticalTextBox.LoadingBegin();
			GridLinesMirrorVerticalTextBox.Location = new Point(72, 32);
			GridLinesMirrorVerticalTextBox.Name = "GridLinesMirrorVerticalTextBox";
			GridLinesMirrorVerticalTextBox.PropertyName = "GridLinesMirrorVertical";
			GridLinesMirrorVerticalTextBox.Size = new Size(112, 20);
			GridLinesMirrorVerticalTextBox.TabIndex = 0;
			GridLinesMirrorVerticalTextBox.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = GridLinesMirrorVerticalTextBox;
			focusLabel2.Location = new Point(28, 34);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(44, 15);
			focusLabel2.Text = "Vertical";
			focusLabel2.LoadingEnd();
			ContextMenuEnabledCheckBox.Location = new Point(352, 27);
			ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			ContextMenuEnabledCheckBox.Size = new Size(152, 24);
			ContextMenuEnabledCheckBox.TabIndex = 7;
			ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			LayerNumericUpDown.Location = new Point(168, 72);
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
			label1.Location = new Point(133, 73);
			label1.Name = "label1";
			label1.Size = new Size(35, 15);
			label1.Text = "Layer";
			label1.LoadingEnd();
			UserCanEditCheckBox.Location = new Point(248, 51);
			UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			UserCanEditCheckBox.PropertyName = "UserCanEdit";
			UserCanEditCheckBox.Size = new Size(96, 24);
			UserCanEditCheckBox.TabIndex = 6;
			UserCanEditCheckBox.Text = "User Can Edit";
			groupBox2.Controls.Add(focusLabel6);
			groupBox2.Controls.Add(AxesControlKeyboardStyleComboBox);
			groupBox2.Controls.Add(focusLabel5);
			groupBox2.Controls.Add(AxesControlWheelStyleComboBox);
			groupBox2.Controls.Add(focusLabel4);
			groupBox2.Controls.Add(AxesControlMouseStyleComboBox);
			groupBox2.Controls.Add(AxesControlEnabledCheckBox);
			groupBox2.Location = new Point(232, 112);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(200, 136);
			groupBox2.TabIndex = 10;
			groupBox2.TabStop = false;
			groupBox2.Text = "Axes Control";
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = AxesControlKeyboardStyleComboBox;
			focusLabel6.Location = new Point(6, 106);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(82, 15);
			focusLabel6.Text = "Keyboard Style";
			focusLabel6.LoadingEnd();
			AxesControlKeyboardStyleComboBox.Location = new Point(88, 104);
			AxesControlKeyboardStyleComboBox.Name = "AxesControlKeyboardStyleComboBox";
			AxesControlKeyboardStyleComboBox.PropertyName = "AxesControlKeyboardStyle";
			AxesControlKeyboardStyleComboBox.Size = new Size(96, 21);
			AxesControlKeyboardStyleComboBox.TabIndex = 3;
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = AxesControlWheelStyleComboBox;
			focusLabel5.Location = new Point(22, 82);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(66, 15);
			focusLabel5.Text = "Wheel Style";
			focusLabel5.LoadingEnd();
			AxesControlWheelStyleComboBox.Location = new Point(88, 80);
			AxesControlWheelStyleComboBox.Name = "AxesControlWheelStyleComboBox";
			AxesControlWheelStyleComboBox.PropertyName = "AxesControlWheelStyle";
			AxesControlWheelStyleComboBox.Size = new Size(96, 21);
			AxesControlWheelStyleComboBox.TabIndex = 2;
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = AxesControlMouseStyleComboBox;
			focusLabel4.Location = new Point(20, 58);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(68, 15);
			focusLabel4.Text = "Mouse Style";
			focusLabel4.LoadingEnd();
			AxesControlMouseStyleComboBox.Location = new Point(88, 56);
			AxesControlMouseStyleComboBox.Name = "AxesControlMouseStyleComboBox";
			AxesControlMouseStyleComboBox.PropertyName = "AxesControlMouseStyle";
			AxesControlMouseStyleComboBox.Size = new Size(96, 21);
			AxesControlMouseStyleComboBox.TabIndex = 1;
			AxesControlEnabledCheckBox.Location = new Point(16, 24);
			AxesControlEnabledCheckBox.Name = "AxesControlEnabledCheckBox";
			AxesControlEnabledCheckBox.PropertyName = "AxesControlEnabled";
			AxesControlEnabledCheckBox.TabIndex = 0;
			AxesControlEnabledCheckBox.Text = "Enabled";
			TitleTextBox.EditFont = null;
			TitleTextBox.Location = new Point(80, 40);
			TitleTextBox.Name = "TitleTextBox";
			TitleTextBox.PropertyName = "TitleText";
			TitleTextBox.Size = new Size(144, 20);
			TitleTextBox.TabIndex = 1;
			focusLabel15.LoadingBegin();
			focusLabel15.FocusControl = TitleTextBox;
			focusLabel15.Location = new Point(27, 43);
			focusLabel15.Name = "focusLabel15";
			focusLabel15.Size = new Size(53, 15);
			focusLabel15.Text = "Title Text";
			focusLabel15.LoadingEnd();
			CanFocusCheckBox.Location = new Point(352, 51);
			CanFocusCheckBox.Name = "CanFocusCheckBox";
			CanFocusCheckBox.PropertyName = "CanFocus";
			CanFocusCheckBox.Size = new Size(144, 24);
			CanFocusCheckBox.TabIndex = 8;
			CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(CanFocusCheckBox);
			base.Controls.Add(TitleTextBox);
			base.Controls.Add(focusLabel15);
			base.Controls.Add(groupBox2);
			base.Controls.Add(UserCanEditCheckBox);
			base.Controls.Add(LayerNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(ContextMenuEnabledCheckBox);
			base.Controls.Add(groupBox1);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label8);
			base.Controls.Add(NameTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotDataViewEditorPlugIn";
			base.Size = new Size(656, 280);
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotFillGridEditorPlugIn(), "Fill-Inside", false);
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill-Outside", false);
			base.AddSubPlugIn(new PlotLayoutDataViewEditorPlugIn(), "Dock", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotDataView).FillInside;
			base.SubPlugIns[1].Value = (base.Value as PlotDataView).FillOutside;
			base.SubPlugIns[2].Value = base.Value;
		}
	}
}
