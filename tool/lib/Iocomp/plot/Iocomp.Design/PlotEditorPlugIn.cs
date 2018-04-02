using Iocomp.Design.Plugin.EditorControls;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotEditorPlugIn : PlugInStandard
	{
		private FocusLabel label4;

		private ColorPicker ForeColorPicker;

		private FocusLabel label3;

		private ColorPicker BackColorPicker;

		private Iocomp.Design.Plugin.EditorControls.CheckBox AutoSizeCheckBox;

		private FontButton FontButton;

		private Iocomp.Design.Plugin.EditorControls.ComboBox RotationComboBox;

		private FocusLabel focusLabel1;

		private ColorPicker DefaultGridLineColorPicker;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenusEnabledCheckBox;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.ComboBox FileDeliminatorComboBox;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.ComboBox CopyToClipboardFormatComboBox;

		private FocusLabel focusLabel4;

		private EditBox UpdateFrameRateTextBox;

		private FocusLabel focusLabel5;

		private FocusLabel RotationLabel;

		private FocusLabel label2;

		private EditBox DefaultSaveImagePathTextBox;

		private Button DefaultSaveImagePathEditButton;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.ComboBox XValueTextDateTimeFormatComboBox;

		private Container components;

		public PlotEditorPlugIn()
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
			label4 = new FocusLabel();
			ForeColorPicker = new ColorPicker();
			label3 = new FocusLabel();
			BackColorPicker = new ColorPicker();
			AutoSizeCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			FontButton = new FontButton();
			RotationLabel = new FocusLabel();
			RotationComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel1 = new FocusLabel();
			DefaultGridLineColorPicker = new ColorPicker();
			ContextMenusEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			focusLabel2 = new FocusLabel();
			FileDeliminatorComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel3 = new FocusLabel();
			CopyToClipboardFormatComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel4 = new FocusLabel();
			UpdateFrameRateTextBox = new EditBox();
			focusLabel5 = new FocusLabel();
			DefaultSaveImagePathTextBox = new EditBox();
			label2 = new FocusLabel();
			DefaultSaveImagePathEditButton = new Button();
			focusLabel6 = new FocusLabel();
			XValueTextDateTimeFormatComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			base.SuspendLayout();
			label4.LoadingBegin();
			label4.FocusControl = ForeColorPicker;
			label4.Location = new Point(69, 123);
			label4.Name = "label4";
			label4.Size = new Size(59, 15);
			label4.Text = "Fore Color";
			label4.LoadingEnd();
			ForeColorPicker.Location = new Point(128, 120);
			ForeColorPicker.Name = "ForeColorPicker";
			ForeColorPicker.PropertyName = "ForeColor";
			ForeColorPicker.Size = new Size(136, 21);
			ForeColorPicker.TabIndex = 5;
			label3.LoadingBegin();
			label3.FocusControl = BackColorPicker;
			label3.Location = new Point(67, 147);
			label3.Name = "label3";
			label3.Size = new Size(61, 15);
			label3.Text = "Back Color";
			label3.LoadingEnd();
			BackColorPicker.Location = new Point(128, 144);
			BackColorPicker.Name = "BackColorPicker";
			BackColorPicker.PropertyName = "BackColor";
			BackColorPicker.Size = new Size(136, 21);
			BackColorPicker.TabIndex = 7;
			AutoSizeCheckBox.Location = new Point(280, 176);
			AutoSizeCheckBox.Name = "AutoSizeCheckBox";
			AutoSizeCheckBox.PropertyName = "AutoSize";
			AutoSizeCheckBox.TabIndex = 9;
			AutoSizeCheckBox.Text = "Auto Size";
			FontButton.Location = new Point(280, 120);
			FontButton.Name = "FontButton";
			FontButton.PropertyName = "Font";
			FontButton.TabIndex = 6;
			RotationLabel.LoadingBegin();
			RotationLabel.FocusControl = RotationComboBox;
			RotationLabel.Location = new Point(79, 178);
			RotationLabel.Name = "RotationLabel";
			RotationLabel.Size = new Size(49, 15);
			RotationLabel.Text = "Rotation";
			RotationLabel.LoadingEnd();
			RotationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			RotationComboBox.Location = new Point(128, 176);
			RotationComboBox.Name = "RotationComboBox";
			RotationComboBox.PropertyName = "Rotation";
			RotationComboBox.Size = new Size(136, 21);
			RotationComboBox.TabIndex = 8;
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = DefaultGridLineColorPicker;
			focusLabel1.Location = new Point(8, 91);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(120, 15);
			focusLabel1.Text = "Default Grid-Line Color";
			focusLabel1.LoadingEnd();
			DefaultGridLineColorPicker.Location = new Point(128, 88);
			DefaultGridLineColorPicker.Name = "DefaultGridLineColorPicker";
			DefaultGridLineColorPicker.PropertyName = "DefaultGridLineColor";
			DefaultGridLineColorPicker.Size = new Size(136, 21);
			DefaultGridLineColorPicker.TabIndex = 4;
			ContextMenusEnabledCheckBox.Location = new Point(64, 16);
			ContextMenusEnabledCheckBox.Name = "ContextMenusEnabledCheckBox";
			ContextMenusEnabledCheckBox.PropertyName = "ContextMenusEnabled";
			ContextMenusEnabledCheckBox.Size = new Size(168, 24);
			ContextMenusEnabledCheckBox.TabIndex = 0;
			ContextMenusEnabledCheckBox.Text = "Context Menus Enabled";
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = FileDeliminatorComboBox;
			focusLabel2.Location = new Point(412, 18);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(84, 15);
			focusLabel2.Text = "File Deliminator";
			focusLabel2.LoadingEnd();
			FileDeliminatorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			FileDeliminatorComboBox.Location = new Point(496, 16);
			FileDeliminatorComboBox.Name = "FileDeliminatorComboBox";
			FileDeliminatorComboBox.PropertyName = "FileDeliminator";
			FileDeliminatorComboBox.Size = new Size(136, 21);
			FileDeliminatorComboBox.TabIndex = 1;
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = CopyToClipboardFormatComboBox;
			focusLabel3.Location = new Point(359, 50);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(137, 15);
			focusLabel3.Text = "Copy To Clipboard Format";
			focusLabel3.LoadingEnd();
			CopyToClipboardFormatComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			CopyToClipboardFormatComboBox.Location = new Point(496, 48);
			CopyToClipboardFormatComboBox.Name = "CopyToClipboardFormatComboBox";
			CopyToClipboardFormatComboBox.PropertyName = "CopyToClipboardFormat";
			CopyToClipboardFormatComboBox.Size = new Size(136, 21);
			CopyToClipboardFormatComboBox.TabIndex = 2;
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = UpdateFrameRateTextBox;
			focusLabel4.FocusControlAlignment = AlignmentQuadSide.Right;
			focusLabel4.Location = new Point(168, 210);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(60, 15);
			focusLabel4.Text = "(Max = 50)";
			focusLabel4.LoadingEnd();
			UpdateFrameRateTextBox.LoadingBegin();
			UpdateFrameRateTextBox.Location = new Point(128, 208);
			UpdateFrameRateTextBox.Name = "UpdateFrameRateTextBox";
			UpdateFrameRateTextBox.PropertyName = "UpdateFrameRate";
			UpdateFrameRateTextBox.Size = new Size(40, 20);
			UpdateFrameRateTextBox.TabIndex = 10;
			UpdateFrameRateTextBox.LoadingEnd();
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = UpdateFrameRateTextBox;
			focusLabel5.Location = new Point(24, 210);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(104, 15);
			focusLabel5.Text = "Update Frame Rate";
			focusLabel5.LoadingEnd();
			DefaultSaveImagePathTextBox.LoadingBegin();
			DefaultSaveImagePathTextBox.Location = new Point(128, 248);
			DefaultSaveImagePathTextBox.Name = "DefaultSaveImagePathTextBox";
			DefaultSaveImagePathTextBox.PropertyName = "DefaultSaveImagePath";
			DefaultSaveImagePathTextBox.Size = new Size(384, 20);
			DefaultSaveImagePathTextBox.TabIndex = 11;
			DefaultSaveImagePathTextBox.LoadingEnd();
			label2.LoadingBegin();
			label2.FocusControl = DefaultSaveImagePathTextBox;
			label2.Location = new Point(0, 250);
			label2.Name = "label2";
			label2.Size = new Size(128, 15);
			label2.Text = "Default Save Image Path";
			label2.LoadingEnd();
			DefaultSaveImagePathEditButton.Location = new Point(512, 248);
			DefaultSaveImagePathEditButton.Name = "DefaultSaveImagePathEditButton";
			DefaultSaveImagePathEditButton.Size = new Size(24, 21);
			DefaultSaveImagePathEditButton.TabIndex = 12;
			DefaultSaveImagePathEditButton.Text = "...";
			DefaultSaveImagePathEditButton.Click += DefaultSaveImagePathEditButton_Click;
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = XValueTextDateTimeFormatComboBox;
			focusLabel6.Location = new Point(335, 74);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(161, 15);
			focusLabel6.Text = "X-Value Text Date/Time Format";
			focusLabel6.LoadingEnd();
			XValueTextDateTimeFormatComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			XValueTextDateTimeFormatComboBox.Location = new Point(496, 72);
			XValueTextDateTimeFormatComboBox.Name = "XValueTextDateTimeFormatComboBox";
			XValueTextDateTimeFormatComboBox.PropertyName = "XValueTextDateTimeFormat";
			XValueTextDateTimeFormatComboBox.Size = new Size(136, 21);
			XValueTextDateTimeFormatComboBox.TabIndex = 3;
			base.Controls.Add(focusLabel6);
			base.Controls.Add(XValueTextDateTimeFormatComboBox);
			base.Controls.Add(DefaultSaveImagePathEditButton);
			base.Controls.Add(DefaultSaveImagePathTextBox);
			base.Controls.Add(label2);
			base.Controls.Add(focusLabel4);
			base.Controls.Add(UpdateFrameRateTextBox);
			base.Controls.Add(focusLabel5);
			base.Controls.Add(focusLabel3);
			base.Controls.Add(CopyToClipboardFormatComboBox);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(FileDeliminatorComboBox);
			base.Controls.Add(ContextMenusEnabledCheckBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(DefaultGridLineColorPicker);
			base.Controls.Add(label4);
			base.Controls.Add(ForeColorPicker);
			base.Controls.Add(label3);
			base.Controls.Add(BackColorPicker);
			base.Controls.Add(AutoSizeCheckBox);
			base.Controls.Add(FontButton);
			base.Controls.Add(RotationLabel);
			base.Controls.Add(RotationComboBox);
			base.Name = "PlotEditorPlugIn";
			base.Size = new Size(752, 296);
			base.Title = "Plot Editor";
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotPrintAdapterEditorPlugIn(), "Print", true);
			base.AddSubPlugIn(new PlotLogFileAdapterEditorPlugIn(), "Log File", true);
			base.AddSubPlugIn(new PlotFileIOEditorPlugIn(), "File I/O", true);
			base.AddSubPlugIn(new PlotLayoutViewerEditorPlugIn(), "Layout", false);
			base.AddSubPlugIn(new PlotChannelBaseCollectionEditorPlugIn(), "Channels", false);
			base.AddSubPlugIn(new PlotXAxisCollectionEditorPlugIn(), "X-Axes", false);
			base.AddSubPlugIn(new PlotYAxisCollectionEditorPlugIn(), "Y-Axes", false);
			base.AddSubPlugIn(new PlotDataViewCollectionEditorPlugIn(), "Data-Views", false);
			base.AddSubPlugIn(new PlotLimitBaseCollectionEditorPlugIn(), "Limits", false);
			base.AddSubPlugIn(new PlotDataCursorBaseCollectionEditorPlugIn(), "Data-Cursors", false);
			base.AddSubPlugIn(new PlotLabelBaseCollectionEditorPlugIn(), "Labels", false);
			base.AddSubPlugIn(new PlotLegendBaseCollectionEditorPlugIn(), "Legends", false);
			base.AddSubPlugIn(new PlotTableBaseCollectionEditorPlugIn(), "Tables", false);
			base.AddSubPlugIn(new PlotAnnotationBaseCollectionEditorPlugIn(), "Annotations", false);
			base.AddSubPlugIn(new PlotBrushEditorPlugIn(), "Background", true);
			base.AddSubPlugIn(new BorderControlEditorPlugIn(), "Border", true);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as Plot).PrintAdapter;
			base.SubPlugIns[1].Value = (base.Value as Plot).LogFile;
			base.SubPlugIns[2].Value = base.Value;
			base.SubPlugIns[3].Value = base.Value;
			base.SubPlugIns[4].Value = (base.Value as Plot).Channels;
			base.SubPlugIns[5].Value = (base.Value as Plot).XAxes;
			base.SubPlugIns[6].Value = (base.Value as Plot).YAxes;
			base.SubPlugIns[7].Value = (base.Value as Plot).DataViews;
			base.SubPlugIns[8].Value = (base.Value as Plot).Limits;
			base.SubPlugIns[9].Value = (base.Value as Plot).DataCursors;
			base.SubPlugIns[10].Value = (base.Value as Plot).Labels;
			base.SubPlugIns[11].Value = (base.Value as Plot).Legends;
			base.SubPlugIns[12].Value = (base.Value as Plot).Tables;
			base.SubPlugIns[13].Value = (base.Value as Plot).Annotations;
			base.SubPlugIns[14].Value = (base.Value as Plot).Background;
			base.SubPlugIns[15].Value = (base.Value as Plot).Border;
		}

		private void DefaultSaveImagePathEditButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.SelectedPath = DefaultSaveImagePathTextBox.AsString;
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				DefaultSaveImagePathTextBox.AsString = folderBrowserDialog.SelectedPath;
				DefaultSaveImagePathTextBox.ForceUpdate();
			}
		}
	}
}
