using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotChannelSweepIntervalEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleInLegendCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private EditBox XAxisNameTextBox;

		private FocusLabel focusLabel4;

		private EditBox YAxisNameTextBox;

		private FocusLabel focusLabel5;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox SendXAxisTrackingDataCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox SendYAxisTrackingDataCheckBox;

		private EditBox LegendNameTextBox;

		private FocusLabel focusLabel6;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ClippingStyleComboBox;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotChannelSweepIntervalEditorPlugIn()
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
			VisibleInLegendCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			NameTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			XAxisNameTextBox = new EditBox();
			focusLabel4 = new FocusLabel();
			YAxisNameTextBox = new EditBox();
			focusLabel5 = new FocusLabel();
			ColorPicker = new ColorPicker();
			label8 = new FocusLabel();
			SendXAxisTrackingDataCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			SendYAxisTrackingDataCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LegendNameTextBox = new EditBox();
			focusLabel6 = new FocusLabel();
			TitleTextBox = new EditMultiLine();
			focusLabel2 = new FocusLabel();
			ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label1 = new FocusLabel();
			UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			ClippingStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel3 = new FocusLabel();
			CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			VisibleInLegendCheckBox.Location = new Point(368, 3);
			VisibleInLegendCheckBox.Name = "VisibleInLegendCheckBox";
			VisibleInLegendCheckBox.PropertyName = "VisibleInLegend";
			VisibleInLegendCheckBox.Size = new Size(112, 24);
			VisibleInLegendCheckBox.TabIndex = 13;
			VisibleInLegendCheckBox.Text = "Visible In Legend";
			VisibleCheckBox.Location = new Point(264, 3);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 10;
			VisibleCheckBox.Text = "Visible";
			EnabledCheckBox.Location = new Point(264, 27);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(80, 24);
			EnabledCheckBox.TabIndex = 11;
			EnabledCheckBox.Text = "Enabled";
			NameTextBox.LoadingBegin();
			NameTextBox.Location = new Point(96, 8);
			NameTextBox.Name = "NameTextBox";
			NameTextBox.PropertyName = "Name";
			NameTextBox.Size = new Size(144, 20);
			NameTextBox.TabIndex = 0;
			NameTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = NameTextBox;
			focusLabel1.Location = new Point(59, 10);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(37, 15);
			focusLabel1.Text = "Name";
			focusLabel1.LoadingEnd();
			XAxisNameTextBox.LoadingBegin();
			XAxisNameTextBox.Location = new Point(96, 136);
			XAxisNameTextBox.Name = "XAxisNameTextBox";
			XAxisNameTextBox.PropertyName = "XAxisName";
			XAxisNameTextBox.Size = new Size(144, 20);
			XAxisNameTextBox.TabIndex = 2;
			XAxisNameTextBox.LoadingEnd();
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = XAxisNameTextBox;
			focusLabel4.Location = new Point(24, 138);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(72, 15);
			focusLabel4.Text = "X-Axis Name";
			focusLabel4.LoadingEnd();
			YAxisNameTextBox.LoadingBegin();
			YAxisNameTextBox.Location = new Point(96, 160);
			YAxisNameTextBox.Name = "YAxisNameTextBox";
			YAxisNameTextBox.PropertyName = "YAxisName";
			YAxisNameTextBox.Size = new Size(144, 20);
			YAxisNameTextBox.TabIndex = 4;
			YAxisNameTextBox.LoadingEnd();
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = YAxisNameTextBox;
			focusLabel5.Location = new Point(24, 162);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(72, 15);
			focusLabel5.Text = "Y-Axis Name";
			focusLabel5.LoadingEnd();
			ColorPicker.Location = new Point(96, 224);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(48, 21);
			ColorPicker.Style = ColorPickerStyle.ColorBox;
			ColorPicker.TabIndex = 7;
			label8.LoadingBegin();
			label8.FocusControl = ColorPicker;
			label8.Location = new Point(62, 227);
			label8.Name = "label8";
			label8.Size = new Size(34, 15);
			label8.Text = "Color";
			label8.LoadingEnd();
			SendXAxisTrackingDataCheckBox.Location = new Point(248, 136);
			SendXAxisTrackingDataCheckBox.Name = "SendXAxisTrackingDataCheckBox";
			SendXAxisTrackingDataCheckBox.PropertyName = "SendXAxisTrackingData";
			SendXAxisTrackingDataCheckBox.Size = new Size(168, 24);
			SendXAxisTrackingDataCheckBox.TabIndex = 3;
			SendXAxisTrackingDataCheckBox.Text = "Send X-Axis Tracking Data";
			SendYAxisTrackingDataCheckBox.Location = new Point(248, 160);
			SendYAxisTrackingDataCheckBox.Name = "SendYAxisTrackingDataCheckBox";
			SendYAxisTrackingDataCheckBox.PropertyName = "SendYAxisTrackingData";
			SendYAxisTrackingDataCheckBox.Size = new Size(168, 24);
			SendYAxisTrackingDataCheckBox.TabIndex = 5;
			SendYAxisTrackingDataCheckBox.Text = "Send Y-Axis Tracking Data";
			LegendNameTextBox.LoadingBegin();
			LegendNameTextBox.Location = new Point(96, 192);
			LegendNameTextBox.Name = "LegendNameTextBox";
			LegendNameTextBox.PropertyName = "LegendName";
			LegendNameTextBox.Size = new Size(144, 20);
			LegendNameTextBox.TabIndex = 6;
			LegendNameTextBox.LoadingEnd();
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = LegendNameTextBox;
			focusLabel6.Location = new Point(20, 194);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(76, 15);
			focusLabel6.Text = "Legend Name";
			focusLabel6.LoadingEnd();
			TitleTextBox.EditFont = null;
			TitleTextBox.Location = new Point(96, 40);
			TitleTextBox.Name = "TitleTextBox";
			TitleTextBox.PropertyName = "TitleText";
			TitleTextBox.Size = new Size(144, 20);
			TitleTextBox.TabIndex = 1;
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = TitleTextBox;
			focusLabel2.Location = new Point(43, 43);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(53, 15);
			focusLabel2.Text = "Title Text";
			focusLabel2.LoadingEnd();
			ContextMenuEnabledCheckBox.Location = new Point(368, 27);
			ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			ContextMenuEnabledCheckBox.Size = new Size(144, 24);
			ContextMenuEnabledCheckBox.TabIndex = 14;
			ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			LayerNumericUpDown.Location = new Point(184, 224);
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
			LayerNumericUpDown.TabIndex = 8;
			LayerNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label1.LoadingBegin();
			label1.FocusControl = LayerNumericUpDown;
			label1.Location = new Point(149, 225);
			label1.Name = "label1";
			label1.Size = new Size(35, 15);
			label1.Text = "Layer";
			label1.LoadingEnd();
			UserCanEditCheckBox.Location = new Point(264, 51);
			UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			UserCanEditCheckBox.PropertyName = "UserCanEdit";
			UserCanEditCheckBox.Size = new Size(96, 24);
			UserCanEditCheckBox.TabIndex = 12;
			UserCanEditCheckBox.Text = "User Can Edit";
			ClippingStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ClippingStyleComboBox.Location = new Point(328, 224);
			ClippingStyleComboBox.MaxDropDownItems = 20;
			ClippingStyleComboBox.Name = "ClippingStyleComboBox";
			ClippingStyleComboBox.PropertyName = "ClippingStyle";
			ClippingStyleComboBox.Size = new Size(80, 21);
			ClippingStyleComboBox.TabIndex = 9;
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = ClippingStyleComboBox;
			focusLabel3.Location = new Point(253, 226);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(75, 15);
			focusLabel3.Text = "Clipping Style";
			focusLabel3.LoadingEnd();
			CanFocusCheckBox.Location = new Point(368, 51);
			CanFocusCheckBox.Name = "CanFocusCheckBox";
			CanFocusCheckBox.PropertyName = "CanFocus";
			CanFocusCheckBox.Size = new Size(144, 24);
			CanFocusCheckBox.TabIndex = 15;
			CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(CanFocusCheckBox);
			base.Controls.Add(ClippingStyleComboBox);
			base.Controls.Add(focusLabel3);
			base.Controls.Add(UserCanEditCheckBox);
			base.Controls.Add(LayerNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(ContextMenuEnabledCheckBox);
			base.Controls.Add(TitleTextBox);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(LegendNameTextBox);
			base.Controls.Add(focusLabel6);
			base.Controls.Add(SendYAxisTrackingDataCheckBox);
			base.Controls.Add(SendXAxisTrackingDataCheckBox);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label8);
			base.Controls.Add(YAxisNameTextBox);
			base.Controls.Add(focusLabel5);
			base.Controls.Add(XAxisNameTextBox);
			base.Controls.Add(focusLabel4);
			base.Controls.Add(NameTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(VisibleInLegendCheckBox);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelSweepIntervalEditorPlugIn";
			base.Size = new Size(584, 280);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotChannelSweepIntervalDataPointsEditorPlugIn(), "Data-Points", false);
			base.AddSubPlugIn(new PlotChannelSweepIntervalSpecificEditorPlugIn(), "Sweep", false);
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Trace", false);
			base.AddSubPlugIn(new PlotMarkerEditorPlugIn(), "Markers", false);
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Retrace Line", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = base.Value;
			base.SubPlugIns[1].Value = base.Value;
			base.SubPlugIns[2].Value = (base.Value as PlotChannelSweepInterval).Trace;
			base.SubPlugIns[3].Value = (base.Value as PlotChannelSweepInterval).Markers;
			base.SubPlugIns[4].Value = (base.Value as PlotChannelSweepInterval).RetraceLine;
		}
	}
}