using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotTableChannelEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private FontButton FontButton;

		private FocusLabel focusLabel11;

		private ColorPicker ForeColorPicker;

		private EditBox MarginOuterTextBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private EditBox ChannelNameTextBox;

		private FocusLabel focusLabel13;

		private GroupBox RowHeightGoupBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox RowTitlesVisibleCheckBox;

		private EditBox RowOuterMarginEditBox;

		private FocusLabel focusLabel12;

		private EditBox RowHeightValueEditBox;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.ComboBox RowHeightStyleComboBox;

		private FocusLabel focusLabel7;

		private GroupBox ColWidthGroupBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ColTitlesVisibleCheckBox;

		private EditBox ColOuterMarginEditBox;

		private FocusLabel focusLabel10;

		private EditBox ColWidthValueTextBox;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ColWidthStyleComboBox;

		private FocusLabel focusLabel9;

		private FocusLabel focusLabel14;

		private GroupBox DataPointGroupBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DataPointRangeStyleComboBox;

		private FocusLabel focusLabel5;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown DataPointStartIndexNumericUpDown;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown DataPointCountNumericUpDown;

		private FocusLabel focusLabel2;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel15;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotTableChannelEditorPlugIn()
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
			ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label1 = new FocusLabel();
			FontButton = new FontButton();
			focusLabel11 = new FocusLabel();
			ForeColorPicker = new ColorPicker();
			MarginOuterTextBox = new EditBox();
			focusLabel8 = new FocusLabel();
			UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			ChannelNameTextBox = new EditBox();
			focusLabel13 = new FocusLabel();
			RowHeightGoupBox = new GroupBox();
			RowTitlesVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			RowOuterMarginEditBox = new EditBox();
			focusLabel12 = new FocusLabel();
			RowHeightValueEditBox = new EditBox();
			focusLabel6 = new FocusLabel();
			RowHeightStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel7 = new FocusLabel();
			ColWidthGroupBox = new GroupBox();
			ColTitlesVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			ColOuterMarginEditBox = new EditBox();
			focusLabel10 = new FocusLabel();
			ColWidthValueTextBox = new EditBox();
			focusLabel4 = new FocusLabel();
			ColWidthStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel9 = new FocusLabel();
			focusLabel14 = new FocusLabel();
			DataPointGroupBox = new GroupBox();
			DataPointRangeStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel5 = new FocusLabel();
			DataPointStartIndexNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			focusLabel3 = new FocusLabel();
			DataPointCountNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			focusLabel2 = new FocusLabel();
			TitleTextBox = new EditMultiLine();
			focusLabel15 = new FocusLabel();
			CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			RowHeightGoupBox.SuspendLayout();
			ColWidthGroupBox.SuspendLayout();
			DataPointGroupBox.SuspendLayout();
			base.SuspendLayout();
			VisibleCheckBox.Location = new Point(248, 11);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 5;
			VisibleCheckBox.Text = "Visible";
			EnabledCheckBox.Location = new Point(248, 35);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(80, 24);
			EnabledCheckBox.TabIndex = 6;
			EnabledCheckBox.Text = "Enabled";
			NameTextBox.LoadingBegin();
			NameTextBox.Location = new Point(88, 16);
			NameTextBox.Name = "NameTextBox";
			NameTextBox.PropertyName = "Name";
			NameTextBox.Size = new Size(144, 20);
			NameTextBox.TabIndex = 0;
			NameTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = NameTextBox;
			focusLabel1.Location = new Point(51, 18);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(37, 15);
			focusLabel1.Text = "Name";
			focusLabel1.LoadingEnd();
			ColorPicker.Location = new Point(88, 80);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(48, 21);
			ColorPicker.Style = ColorPickerStyle.ColorBox;
			ColorPicker.TabIndex = 2;
			label8.LoadingBegin();
			label8.FocusControl = ColorPicker;
			label8.Location = new Point(54, 83);
			label8.Name = "label8";
			label8.Size = new Size(34, 15);
			label8.Text = "Color";
			label8.LoadingEnd();
			ContextMenuEnabledCheckBox.Location = new Point(248, 59);
			ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			ContextMenuEnabledCheckBox.Size = new Size(144, 24);
			ContextMenuEnabledCheckBox.TabIndex = 7;
			ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			LayerNumericUpDown.Location = new Point(176, 80);
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
			label1.Location = new Point(141, 81);
			label1.Name = "label1";
			label1.Size = new Size(35, 15);
			label1.Text = "Layer";
			label1.LoadingEnd();
			FontButton.Location = new Point(472, 80);
			FontButton.Name = "FontButton";
			FontButton.PropertyName = "Font";
			FontButton.Size = new Size(72, 23);
			FontButton.TabIndex = 12;
			focusLabel11.LoadingBegin();
			focusLabel11.FocusControl = ForeColorPicker;
			focusLabel11.Location = new Point(413, 51);
			focusLabel11.Name = "focusLabel11";
			focusLabel11.Size = new Size(59, 15);
			focusLabel11.Text = "Fore Color";
			focusLabel11.LoadingEnd();
			ForeColorPicker.Location = new Point(472, 48);
			ForeColorPicker.Name = "ForeColorPicker";
			ForeColorPicker.PropertyName = "ForeColor";
			ForeColorPicker.Size = new Size(49, 21);
			ForeColorPicker.Style = ColorPickerStyle.ColorBox;
			ForeColorPicker.TabIndex = 11;
			MarginOuterTextBox.LoadingBegin();
			MarginOuterTextBox.Location = new Point(472, 16);
			MarginOuterTextBox.Name = "MarginOuterTextBox";
			MarginOuterTextBox.PropertyName = "MarginOuter";
			MarginOuterTextBox.Size = new Size(88, 20);
			MarginOuterTextBox.TabIndex = 10;
			MarginOuterTextBox.LoadingEnd();
			focusLabel8.LoadingBegin();
			focusLabel8.FocusControl = MarginOuterTextBox;
			focusLabel8.Location = new Point(400, 18);
			focusLabel8.Name = "focusLabel8";
			focusLabel8.Size = new Size(72, 15);
			focusLabel8.Text = "Margin Outer";
			focusLabel8.LoadingEnd();
			UserCanEditCheckBox.Location = new Point(248, 83);
			UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			UserCanEditCheckBox.PropertyName = "UserCanEdit";
			UserCanEditCheckBox.Size = new Size(96, 24);
			UserCanEditCheckBox.TabIndex = 8;
			UserCanEditCheckBox.Text = "User Can Edit";
			ChannelNameTextBox.LoadingBegin();
			ChannelNameTextBox.Location = new Point(88, 120);
			ChannelNameTextBox.Name = "ChannelNameTextBox";
			ChannelNameTextBox.PropertyName = "ChannelName";
			ChannelNameTextBox.Size = new Size(144, 20);
			ChannelNameTextBox.TabIndex = 4;
			ChannelNameTextBox.LoadingEnd();
			focusLabel13.LoadingBegin();
			focusLabel13.FocusControl = ChannelNameTextBox;
			focusLabel13.Location = new Point(7, 122);
			focusLabel13.Name = "focusLabel13";
			focusLabel13.Size = new Size(81, 15);
			focusLabel13.Text = "Channel Name";
			focusLabel13.LoadingEnd();
			RowHeightGoupBox.Controls.Add(RowTitlesVisibleCheckBox);
			RowHeightGoupBox.Controls.Add(RowOuterMarginEditBox);
			RowHeightGoupBox.Controls.Add(focusLabel12);
			RowHeightGoupBox.Controls.Add(RowHeightValueEditBox);
			RowHeightGoupBox.Controls.Add(focusLabel6);
			RowHeightGoupBox.Controls.Add(RowHeightStyleComboBox);
			RowHeightGoupBox.Controls.Add(focusLabel7);
			RowHeightGoupBox.Location = new Point(384, 152);
			RowHeightGoupBox.Name = "RowHeightGoupBox";
			RowHeightGoupBox.Size = new Size(184, 120);
			RowHeightGoupBox.TabIndex = 15;
			RowHeightGoupBox.TabStop = false;
			RowHeightGoupBox.Text = "Row ";
			RowTitlesVisibleCheckBox.Location = new Point(72, 16);
			RowTitlesVisibleCheckBox.Name = "RowTitlesVisibleCheckBox";
			RowTitlesVisibleCheckBox.PropertyName = "RowTitlesVisible";
			RowTitlesVisibleCheckBox.Size = new Size(92, 24);
			RowTitlesVisibleCheckBox.TabIndex = 0;
			RowTitlesVisibleCheckBox.Text = "Titles Visible";
			RowOuterMarginEditBox.LoadingBegin();
			RowOuterMarginEditBox.Location = new Point(72, 88);
			RowOuterMarginEditBox.Name = "RowOuterMarginEditBox";
			RowOuterMarginEditBox.PropertyName = "RowOuterMargin";
			RowOuterMarginEditBox.Size = new Size(104, 20);
			RowOuterMarginEditBox.TabIndex = 3;
			RowOuterMarginEditBox.LoadingEnd();
			focusLabel12.LoadingBegin();
			focusLabel12.FocusControl = RowOuterMarginEditBox;
			focusLabel12.Location = new Point(0, 90);
			focusLabel12.Name = "focusLabel12";
			focusLabel12.Size = new Size(72, 15);
			focusLabel12.Text = "Outer Margin";
			focusLabel12.LoadingEnd();
			RowHeightValueEditBox.LoadingBegin();
			RowHeightValueEditBox.Location = new Point(72, 64);
			RowHeightValueEditBox.Name = "RowHeightValueEditBox";
			RowHeightValueEditBox.PropertyName = "RowHeightValue";
			RowHeightValueEditBox.Size = new Size(104, 20);
			RowHeightValueEditBox.TabIndex = 2;
			RowHeightValueEditBox.LoadingEnd();
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = RowHeightValueEditBox;
			focusLabel6.Location = new Point(2, 66);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(70, 15);
			focusLabel6.Text = "Height Value";
			focusLabel6.LoadingEnd();
			RowHeightStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			RowHeightStyleComboBox.Location = new Point(72, 40);
			RowHeightStyleComboBox.MaxDropDownItems = 20;
			RowHeightStyleComboBox.Name = "RowHeightStyleComboBox";
			RowHeightStyleComboBox.PropertyName = "RowHeightStyle";
			RowHeightStyleComboBox.Size = new Size(104, 21);
			RowHeightStyleComboBox.TabIndex = 1;
			focusLabel7.LoadingBegin();
			focusLabel7.FocusControl = RowHeightStyleComboBox;
			focusLabel7.Location = new Point(5, 42);
			focusLabel7.Name = "focusLabel7";
			focusLabel7.Size = new Size(67, 15);
			focusLabel7.Text = "Height Style";
			focusLabel7.LoadingEnd();
			ColWidthGroupBox.Controls.Add(ColTitlesVisibleCheckBox);
			ColWidthGroupBox.Controls.Add(ColOuterMarginEditBox);
			ColWidthGroupBox.Controls.Add(focusLabel10);
			ColWidthGroupBox.Controls.Add(ColWidthValueTextBox);
			ColWidthGroupBox.Controls.Add(focusLabel4);
			ColWidthGroupBox.Controls.Add(ColWidthStyleComboBox);
			ColWidthGroupBox.Controls.Add(focusLabel9);
			ColWidthGroupBox.Controls.Add(focusLabel14);
			ColWidthGroupBox.Location = new Point(192, 152);
			ColWidthGroupBox.Name = "ColWidthGroupBox";
			ColWidthGroupBox.Size = new Size(184, 120);
			ColWidthGroupBox.TabIndex = 14;
			ColWidthGroupBox.TabStop = false;
			ColWidthGroupBox.Text = "Col";
			ColTitlesVisibleCheckBox.Location = new Point(72, 16);
			ColTitlesVisibleCheckBox.Name = "ColTitlesVisibleCheckBox";
			ColTitlesVisibleCheckBox.PropertyName = "ColTitlesVisible";
			ColTitlesVisibleCheckBox.Size = new Size(92, 24);
			ColTitlesVisibleCheckBox.TabIndex = 0;
			ColTitlesVisibleCheckBox.Text = "Titles Visible";
			ColOuterMarginEditBox.LoadingBegin();
			ColOuterMarginEditBox.Location = new Point(72, 88);
			ColOuterMarginEditBox.Name = "ColOuterMarginEditBox";
			ColOuterMarginEditBox.PropertyName = "ColOuterMargin";
			ColOuterMarginEditBox.Size = new Size(104, 20);
			ColOuterMarginEditBox.TabIndex = 3;
			ColOuterMarginEditBox.LoadingEnd();
			focusLabel10.LoadingBegin();
			focusLabel10.FocusControl = ColOuterMarginEditBox;
			focusLabel10.Location = new Point(0, 90);
			focusLabel10.Name = "focusLabel10";
			focusLabel10.Size = new Size(72, 15);
			focusLabel10.Text = "Outer Margin";
			focusLabel10.LoadingEnd();
			ColWidthValueTextBox.LoadingBegin();
			ColWidthValueTextBox.Location = new Point(72, 64);
			ColWidthValueTextBox.Name = "ColWidthValueTextBox";
			ColWidthValueTextBox.PropertyName = "ColWidthValue";
			ColWidthValueTextBox.Size = new Size(104, 20);
			ColWidthValueTextBox.TabIndex = 2;
			ColWidthValueTextBox.LoadingEnd();
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = ColWidthValueTextBox;
			focusLabel4.Location = new Point(5, 66);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(67, 15);
			focusLabel4.Text = "Width Value";
			focusLabel4.LoadingEnd();
			ColWidthStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ColWidthStyleComboBox.Location = new Point(72, 40);
			ColWidthStyleComboBox.MaxDropDownItems = 20;
			ColWidthStyleComboBox.Name = "ColWidthStyleComboBox";
			ColWidthStyleComboBox.PropertyName = "ColWidthStyle";
			ColWidthStyleComboBox.Size = new Size(104, 21);
			ColWidthStyleComboBox.TabIndex = 1;
			focusLabel9.LoadingBegin();
			focusLabel9.FocusControl = ColWidthStyleComboBox;
			focusLabel9.Location = new Point(9, 42);
			focusLabel9.Name = "focusLabel9";
			focusLabel9.Size = new Size(63, 15);
			focusLabel9.Text = "Width Style";
			focusLabel9.LoadingEnd();
			focusLabel14.LoadingBegin();
			focusLabel14.FocusControl = ColWidthValueTextBox;
			focusLabel14.Location = new Point(38, 66);
			focusLabel14.Name = "focusLabel14";
			focusLabel14.Size = new Size(34, 14);
			focusLabel14.Text = "Value";
			focusLabel14.LoadingEnd();
			DataPointGroupBox.Controls.Add(DataPointRangeStyleComboBox);
			DataPointGroupBox.Controls.Add(focusLabel5);
			DataPointGroupBox.Controls.Add(DataPointStartIndexNumericUpDown);
			DataPointGroupBox.Controls.Add(focusLabel3);
			DataPointGroupBox.Controls.Add(DataPointCountNumericUpDown);
			DataPointGroupBox.Controls.Add(focusLabel2);
			DataPointGroupBox.Location = new Point(8, 152);
			DataPointGroupBox.Name = "DataPointGroupBox";
			DataPointGroupBox.Size = new Size(176, 120);
			DataPointGroupBox.TabIndex = 13;
			DataPointGroupBox.TabStop = false;
			DataPointGroupBox.Text = "Data Point";
			DataPointRangeStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			DataPointRangeStyleComboBox.Location = new Point(72, 46);
			DataPointRangeStyleComboBox.MaxDropDownItems = 20;
			DataPointRangeStyleComboBox.Name = "DataPointRangeStyleComboBox";
			DataPointRangeStyleComboBox.PropertyName = "DataPointRangeStyle";
			DataPointRangeStyleComboBox.Size = new Size(96, 21);
			DataPointRangeStyleComboBox.TabIndex = 1;
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = DataPointRangeStyleComboBox;
			focusLabel5.Location = new Point(5, 48);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(67, 15);
			focusLabel5.Text = "Range Style";
			focusLabel5.LoadingEnd();
			DataPointStartIndexNumericUpDown.Location = new Point(72, 70);
			DataPointStartIndexNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			DataPointStartIndexNumericUpDown.Name = "DataPointStartIndexNumericUpDown";
			DataPointStartIndexNumericUpDown.PropertyName = "DataPointStartIndex";
			DataPointStartIndexNumericUpDown.Size = new Size(72, 20);
			DataPointStartIndexNumericUpDown.TabIndex = 2;
			DataPointStartIndexNumericUpDown.TextAlign = HorizontalAlignment.Center;
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = DataPointStartIndexNumericUpDown;
			focusLabel3.Location = new Point(11, 71);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(61, 15);
			focusLabel3.Text = "Start Index";
			focusLabel3.LoadingEnd();
			DataPointCountNumericUpDown.Location = new Point(72, 22);
			DataPointCountNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			DataPointCountNumericUpDown.Name = "DataPointCountNumericUpDown";
			DataPointCountNumericUpDown.PropertyName = "DataPointCount";
			DataPointCountNumericUpDown.Size = new Size(56, 20);
			DataPointCountNumericUpDown.TabIndex = 0;
			DataPointCountNumericUpDown.TextAlign = HorizontalAlignment.Center;
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = DataPointCountNumericUpDown;
			focusLabel2.Location = new Point(35, 23);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(37, 15);
			focusLabel2.Text = "Count";
			focusLabel2.LoadingEnd();
			TitleTextBox.EditFont = null;
			TitleTextBox.Location = new Point(88, 48);
			TitleTextBox.Name = "TitleTextBox";
			TitleTextBox.PropertyName = "TitleText";
			TitleTextBox.Size = new Size(144, 20);
			TitleTextBox.TabIndex = 1;
			focusLabel15.LoadingBegin();
			focusLabel15.FocusControl = TitleTextBox;
			focusLabel15.Location = new Point(35, 51);
			focusLabel15.Name = "focusLabel15";
			focusLabel15.Size = new Size(53, 15);
			focusLabel15.Text = "Title Text";
			focusLabel15.LoadingEnd();
			CanFocusCheckBox.Location = new Point(248, 107);
			CanFocusCheckBox.Name = "CanFocusCheckBox";
			CanFocusCheckBox.PropertyName = "CanFocus";
			CanFocusCheckBox.Size = new Size(80, 24);
			CanFocusCheckBox.TabIndex = 9;
			CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(CanFocusCheckBox);
			base.Controls.Add(TitleTextBox);
			base.Controls.Add(focusLabel15);
			base.Controls.Add(DataPointGroupBox);
			base.Controls.Add(RowHeightGoupBox);
			base.Controls.Add(ColWidthGroupBox);
			base.Controls.Add(ChannelNameTextBox);
			base.Controls.Add(focusLabel13);
			base.Controls.Add(UserCanEditCheckBox);
			base.Controls.Add(MarginOuterTextBox);
			base.Controls.Add(focusLabel8);
			base.Controls.Add(FontButton);
			base.Controls.Add(focusLabel11);
			base.Controls.Add(ForeColorPicker);
			base.Controls.Add(LayerNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(ContextMenuEnabledCheckBox);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label8);
			base.Controls.Add(NameTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotTableChannelEditorPlugIn";
			base.Size = new Size(632, 288);
			RowHeightGoupBox.ResumeLayout(false);
			ColWidthGroupBox.ResumeLayout(false);
			DataPointGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotTableCellsFormattingEditorPlugIn(), "Cell Formatting", false);
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Grid Outline", false);
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill", false);
			base.AddSubPlugIn(new PlotLayoutDockableAllEditorPlugIn(), "Dock", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotTableChannel).CellsFormatting;
			base.SubPlugIns[1].Value = (base.Value as PlotTableChannel).GridOutline;
			base.SubPlugIns[2].Value = (base.Value as PlotTableChannel).Fill;
			base.SubPlugIns[3].Value = base.Value;
		}
	}
}
