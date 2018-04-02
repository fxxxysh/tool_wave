using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotDataCursorChannelsEditorPlugIn : PlugInStandard
	{
		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private FocusLabel XReferenceLabel;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel2;

		private EditBox PositionXTextBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private EditBox YAxisNameTextBox;

		private FocusLabel focusLabel5;

		private EditBox XAxisNameTextBox;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown HitRegionSizeUpDown;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ClippingStyleComboBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox MasterControlCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox SnapToPointCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotDataCursorChannelsEditorPlugIn()
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
			NameTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			ColorPicker = new ColorPicker();
			label8 = new FocusLabel();
			PositionXTextBox = new EditBox();
			XReferenceLabel = new FocusLabel();
			TitleTextBox = new EditMultiLine();
			focusLabel2 = new FocusLabel();
			LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label1 = new FocusLabel();
			YAxisNameTextBox = new EditBox();
			focusLabel5 = new FocusLabel();
			XAxisNameTextBox = new EditBox();
			focusLabel4 = new FocusLabel();
			HitRegionSizeUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			focusLabel6 = new FocusLabel();
			ClippingStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel8 = new FocusLabel();
			MasterControlCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			SnapToPointCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			NameTextBox.LoadingBegin();
			NameTextBox.Location = new Point(104, 8);
			NameTextBox.Name = "NameTextBox";
			NameTextBox.PropertyName = "Name";
			NameTextBox.Size = new Size(144, 20);
			NameTextBox.TabIndex = 0;
			NameTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = NameTextBox;
			focusLabel1.Location = new Point(67, 10);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(37, 15);
			focusLabel1.Text = "Name";
			focusLabel1.LoadingEnd();
			ColorPicker.Location = new Point(104, 200);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(48, 21);
			ColorPicker.Style = ColorPickerStyle.ColorBox;
			ColorPicker.TabIndex = 5;
			label8.LoadingBegin();
			label8.FocusControl = ColorPicker;
			label8.Location = new Point(70, 203);
			label8.Name = "label8";
			label8.Size = new Size(34, 15);
			label8.Text = "Color";
			label8.LoadingEnd();
			PositionXTextBox.LoadingBegin();
			PositionXTextBox.Location = new Point(104, 80);
			PositionXTextBox.Name = "PositionXTextBox";
			PositionXTextBox.PropertyName = "PositionX";
			PositionXTextBox.Size = new Size(144, 20);
			PositionXTextBox.TabIndex = 2;
			PositionXTextBox.LoadingEnd();
			XReferenceLabel.LoadingBegin();
			XReferenceLabel.FocusControl = PositionXTextBox;
			XReferenceLabel.Location = new Point(46, 82);
			XReferenceLabel.Name = "XReferenceLabel";
			XReferenceLabel.Size = new Size(58, 15);
			XReferenceLabel.Text = "Position-X";
			XReferenceLabel.LoadingEnd();
			TitleTextBox.EditFont = null;
			TitleTextBox.Location = new Point(104, 40);
			TitleTextBox.Name = "TitleTextBox";
			TitleTextBox.PropertyName = "TitleText";
			TitleTextBox.Size = new Size(144, 20);
			TitleTextBox.TabIndex = 1;
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = TitleTextBox;
			focusLabel2.Location = new Point(51, 43);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(53, 15);
			focusLabel2.Text = "Title Text";
			focusLabel2.LoadingEnd();
			LayerNumericUpDown.Location = new Point(192, 200);
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
			LayerNumericUpDown.TabIndex = 6;
			LayerNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label1.LoadingBegin();
			label1.FocusControl = LayerNumericUpDown;
			label1.Location = new Point(157, 201);
			label1.Name = "label1";
			label1.Size = new Size(35, 15);
			label1.Text = "Layer";
			label1.LoadingEnd();
			YAxisNameTextBox.LoadingBegin();
			YAxisNameTextBox.Location = new Point(104, 160);
			YAxisNameTextBox.Name = "YAxisNameTextBox";
			YAxisNameTextBox.PropertyName = "YAxisName";
			YAxisNameTextBox.Size = new Size(144, 20);
			YAxisNameTextBox.TabIndex = 4;
			YAxisNameTextBox.LoadingEnd();
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = YAxisNameTextBox;
			focusLabel5.Location = new Point(32, 162);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(72, 15);
			focusLabel5.Text = "Y-Axis Name";
			focusLabel5.LoadingEnd();
			XAxisNameTextBox.LoadingBegin();
			XAxisNameTextBox.Location = new Point(104, 136);
			XAxisNameTextBox.Name = "XAxisNameTextBox";
			XAxisNameTextBox.PropertyName = "XAxisName";
			XAxisNameTextBox.Size = new Size(144, 20);
			XAxisNameTextBox.TabIndex = 3;
			XAxisNameTextBox.LoadingEnd();
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = XAxisNameTextBox;
			focusLabel4.Location = new Point(32, 138);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(72, 15);
			focusLabel4.Text = "X-Axis Name";
			focusLabel4.LoadingEnd();
			HitRegionSizeUpDown.Location = new Point(352, 200);
			HitRegionSizeUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			HitRegionSizeUpDown.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			HitRegionSizeUpDown.Name = "HitRegionSizeUpDown";
			HitRegionSizeUpDown.PropertyName = "HitRegionSize";
			HitRegionSizeUpDown.Size = new Size(56, 20);
			HitRegionSizeUpDown.TabIndex = 15;
			HitRegionSizeUpDown.TextAlign = HorizontalAlignment.Center;
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = HitRegionSizeUpDown;
			focusLabel6.Location = new Point(269, 201);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(83, 15);
			focusLabel6.Text = "Hit Region Size";
			focusLabel6.LoadingEnd();
			ClippingStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ClippingStyleComboBox.Location = new Point(328, 160);
			ClippingStyleComboBox.MaxDropDownItems = 20;
			ClippingStyleComboBox.Name = "ClippingStyleComboBox";
			ClippingStyleComboBox.PropertyName = "ClippingStyle";
			ClippingStyleComboBox.Size = new Size(80, 21);
			ClippingStyleComboBox.TabIndex = 14;
			focusLabel8.LoadingBegin();
			focusLabel8.FocusControl = ClippingStyleComboBox;
			focusLabel8.Location = new Point(253, 162);
			focusLabel8.Name = "focusLabel8";
			focusLabel8.Size = new Size(75, 15);
			focusLabel8.Text = "Clipping Style";
			focusLabel8.LoadingEnd();
			MasterControlCheckBox.Location = new Point(272, 103);
			MasterControlCheckBox.Name = "MasterControlCheckBox";
			MasterControlCheckBox.PropertyName = "MasterControl";
			MasterControlCheckBox.Size = new Size(136, 24);
			MasterControlCheckBox.TabIndex = 13;
			MasterControlCheckBox.Text = "Master Control";
			SnapToPointCheckBox.Location = new Point(272, 79);
			SnapToPointCheckBox.Name = "SnapToPointCheckBox";
			SnapToPointCheckBox.PropertyName = "SnapToPoint";
			SnapToPointCheckBox.Size = new Size(96, 24);
			SnapToPointCheckBox.TabIndex = 12;
			SnapToPointCheckBox.Text = "Snap To Point";
			UserCanEditCheckBox.Location = new Point(272, 51);
			UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			UserCanEditCheckBox.PropertyName = "UserCanEdit";
			UserCanEditCheckBox.Size = new Size(96, 24);
			UserCanEditCheckBox.TabIndex = 10;
			UserCanEditCheckBox.Text = "User Can Edit";
			ContextMenuEnabledCheckBox.Location = new Point(384, 27);
			ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			ContextMenuEnabledCheckBox.Size = new Size(152, 24);
			ContextMenuEnabledCheckBox.TabIndex = 9;
			ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			EnabledCheckBox.Location = new Point(272, 27);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(80, 24);
			EnabledCheckBox.TabIndex = 8;
			EnabledCheckBox.Text = "Enabled";
			VisibleCheckBox.Location = new Point(272, 3);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 7;
			VisibleCheckBox.Text = "Visible";
			CanFocusCheckBox.Location = new Point(384, 51);
			CanFocusCheckBox.Name = "CanFocusCheckBox";
			CanFocusCheckBox.PropertyName = "CanFocus";
			CanFocusCheckBox.Size = new Size(144, 24);
			CanFocusCheckBox.TabIndex = 11;
			CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(CanFocusCheckBox);
			base.Controls.Add(MasterControlCheckBox);
			base.Controls.Add(SnapToPointCheckBox);
			base.Controls.Add(UserCanEditCheckBox);
			base.Controls.Add(ContextMenuEnabledCheckBox);
			base.Controls.Add(EnabledCheckBox);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(ClippingStyleComboBox);
			base.Controls.Add(focusLabel8);
			base.Controls.Add(HitRegionSizeUpDown);
			base.Controls.Add(focusLabel6);
			base.Controls.Add(YAxisNameTextBox);
			base.Controls.Add(focusLabel5);
			base.Controls.Add(XAxisNameTextBox);
			base.Controls.Add(focusLabel4);
			base.Controls.Add(LayerNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(TitleTextBox);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(PositionXTextBox);
			base.Controls.Add(XReferenceLabel);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label8);
			base.Controls.Add(NameTextBox);
			base.Controls.Add(focusLabel1);
			base.Location = new Point(10, 20);
			base.Name = "PlotDataCursorChannelsEditorPlugIn";
			base.Size = new Size(600, 256);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Line", false);
			base.AddSubPlugIn(new PlotDataCursorHintEditorPlugIn(), "Hint", false);
			base.AddSubPlugIn(new PlotDataCursorWindowEditorPlugIn(), "Window", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotDataCursorChannels).Line;
			base.SubPlugIns[1].Value = (base.Value as PlotDataCursorChannels).Hint;
			base.SubPlugIns[2].Value = (base.Value as PlotDataCursorChannels).Window;
		}
	}
}
