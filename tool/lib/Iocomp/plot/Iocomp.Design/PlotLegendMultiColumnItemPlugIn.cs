using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotLegendMultiColumnItemPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private FocusLabel label8;

		private EditBox WidthTextBox;

		private ColorPicker DataForeColorPicker;

		private FocusLabel label11;

		private ColorPicker TitleForeColorPicker;

		private FocusLabel focusLabel1;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.ComboBox WidthStyleComboBox;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DataTypeComboBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private EditMultiLine TitleTextEditMultiLine;

		private Container components;

		public PlotLegendMultiColumnItemPlugIn()
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

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Title Fill", false);
			base.AddSubPlugIn(new TextLayoutHorizontalEditorPlugIn(), "Title Layout", false);
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Data Fill", false);
			base.AddSubPlugIn(new TextLayoutHorizontalEditorPlugIn(), "Data Layout", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotLegendMultiColumnItem).TitleFill;
			base.SubPlugIns[1].Value = (base.Value as PlotLegendMultiColumnItem).TitleLayout;
			base.SubPlugIns[2].Value = (base.Value as PlotLegendMultiColumnItem).DataFill;
			base.SubPlugIns[3].Value = (base.Value as PlotLegendMultiColumnItem).DataLayout;
		}

		private void InitializeComponent()
		{
			label2 = new FocusLabel();
			WidthTextBox = new EditBox();
			DataForeColorPicker = new ColorPicker();
			label8 = new FocusLabel();
			TitleTextEditMultiLine = new EditMultiLine();
			label11 = new FocusLabel();
			TitleForeColorPicker = new ColorPicker();
			focusLabel1 = new FocusLabel();
			WidthStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel3 = new FocusLabel();
			DataTypeComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel2 = new FocusLabel();
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			label2.LoadingBegin();
			label2.FocusControl = WidthTextBox;
			label2.Location = new Point(93, 130);
			label2.Name = "label2";
			label2.Size = new Size(35, 15);
			label2.Text = "Width";
			label2.LoadingEnd();
			WidthTextBox.LoadingBegin();
			WidthTextBox.Location = new Point(128, 128);
			WidthTextBox.Name = "WidthTextBox";
			WidthTextBox.PropertyName = "Width";
			WidthTextBox.Size = new Size(48, 20);
			WidthTextBox.TabIndex = 4;
			WidthTextBox.LoadingEnd();
			DataForeColorPicker.Location = new Point(128, 184);
			DataForeColorPicker.Name = "DataForeColorPicker";
			DataForeColorPicker.PropertyName = "DataForeColor";
			DataForeColorPicker.Size = new Size(48, 21);
			DataForeColorPicker.Style = ColorPickerStyle.ColorBox;
			DataForeColorPicker.TabIndex = 6;
			label8.LoadingBegin();
			label8.FocusControl = DataForeColorPicker;
			label8.Location = new Point(43, 187);
			label8.Name = "label8";
			label8.Size = new Size(85, 15);
			label8.Text = "Data Fore Color";
			label8.LoadingEnd();
			TitleTextEditMultiLine.EditFont = null;
			TitleTextEditMultiLine.Location = new Point(128, 40);
			TitleTextEditMultiLine.Name = "TitleTextEditMultiLine";
			TitleTextEditMultiLine.PropertyName = "TitleText";
			TitleTextEditMultiLine.Size = new Size(142, 20);
			TitleTextEditMultiLine.TabIndex = 0;
			label11.LoadingBegin();
			label11.FocusControl = TitleTextEditMultiLine;
			label11.Location = new Point(76, 43);
			label11.Name = "label11";
			label11.Size = new Size(52, 15);
			label11.Text = "Title Text";
			label11.LoadingEnd();
			TitleForeColorPicker.Location = new Point(128, 160);
			TitleForeColorPicker.Name = "TitleForeColorPicker";
			TitleForeColorPicker.PropertyName = "TitleForeColor";
			TitleForeColorPicker.Size = new Size(48, 21);
			TitleForeColorPicker.Style = ColorPickerStyle.ColorBox;
			TitleForeColorPicker.TabIndex = 5;
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = TitleForeColorPicker;
			focusLabel1.Location = new Point(46, 163);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(82, 15);
			focusLabel1.Text = "Title Fore Color";
			focusLabel1.LoadingEnd();
			WidthStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			WidthStyleComboBox.Location = new Point(128, 104);
			WidthStyleComboBox.MaxDropDownItems = 20;
			WidthStyleComboBox.Name = "WidthStyleComboBox";
			WidthStyleComboBox.PropertyName = "WidthStyle";
			WidthStyleComboBox.Size = new Size(136, 21);
			WidthStyleComboBox.TabIndex = 3;
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = WidthStyleComboBox;
			focusLabel3.Location = new Point(66, 106);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(62, 15);
			focusLabel3.Text = "Width Style";
			focusLabel3.LoadingEnd();
			DataTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			DataTypeComboBox.Location = new Point(128, 72);
			DataTypeComboBox.MaxDropDownItems = 20;
			DataTypeComboBox.Name = "DataTypeComboBox";
			DataTypeComboBox.PropertyName = "DataType";
			DataTypeComboBox.Size = new Size(142, 21);
			DataTypeComboBox.TabIndex = 2;
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = DataTypeComboBox;
			focusLabel2.Location = new Point(71, 74);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(57, 15);
			focusLabel2.Text = "Data Type";
			focusLabel2.LoadingEnd();
			VisibleCheckBox.Location = new Point(288, 40);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "TitleVisible";
			VisibleCheckBox.Size = new Size(144, 24);
			VisibleCheckBox.TabIndex = 1;
			VisibleCheckBox.Text = "Title Visible";
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(DataTypeComboBox);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(WidthStyleComboBox);
			base.Controls.Add(focusLabel3);
			base.Controls.Add(TitleForeColorPicker);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(TitleTextEditMultiLine);
			base.Controls.Add(label11);
			base.Controls.Add(DataForeColorPicker);
			base.Controls.Add(label8);
			base.Controls.Add(WidthTextBox);
			base.Controls.Add(label2);
			base.Name = "PlotLegendMultiColumnItemPlugIn";
			base.Size = new Size(560, 264);
			base.ResumeLayout(false);
		}
	}
}
