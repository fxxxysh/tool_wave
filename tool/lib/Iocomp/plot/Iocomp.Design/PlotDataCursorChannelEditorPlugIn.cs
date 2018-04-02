using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotDataCursorChannelEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private FocusLabel focusLabel4;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private FocusLabel XReferenceLabel;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private EditBox ChannelNameTextBox;

		private EditBox Pointer1PositionTextBox;

		private EditBox Pointer2PositionTextBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel focusLabel7;

		private Iocomp.Design.Plugin.EditorControls.CheckBox SnapToPointCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown HitRegionSizeUpDown;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ClippingStyleComboBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox MasterControlCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotDataCursorChannelEditorPlugIn()
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
			NameTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			ChannelNameTextBox = new EditBox();
			focusLabel4 = new FocusLabel();
			ColorPicker = new ColorPicker();
			label8 = new FocusLabel();
			Pointer1PositionTextBox = new EditBox();
			XReferenceLabel = new FocusLabel();
			TitleTextBox = new EditMultiLine();
			focusLabel2 = new FocusLabel();
			EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			Pointer2PositionTextBox = new EditBox();
			focusLabel3 = new FocusLabel();
			LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label1 = new FocusLabel();
			UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel7 = new FocusLabel();
			SnapToPointCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			HitRegionSizeUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			focusLabel6 = new FocusLabel();
			ClippingStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel8 = new FocusLabel();
			MasterControlCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			VisibleCheckBox.Location = new Point(272, 3);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 7;
			VisibleCheckBox.Text = "Visible";
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
			ChannelNameTextBox.LoadingBegin();
			ChannelNameTextBox.Location = new Point(104, 136);
			ChannelNameTextBox.Name = "ChannelNameTextBox";
			ChannelNameTextBox.PropertyName = "ChannelName";
			ChannelNameTextBox.Size = new Size(144, 20);
			ChannelNameTextBox.TabIndex = 4;
			ChannelNameTextBox.LoadingEnd();
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = ChannelNameTextBox;
			focusLabel4.Location = new Point(23, 138);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(81, 15);
			focusLabel4.Text = "Channel Name";
			focusLabel4.LoadingEnd();
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
			Pointer1PositionTextBox.LoadingBegin();
			Pointer1PositionTextBox.Location = new Point(104, 80);
			Pointer1PositionTextBox.Name = "Pointer1PositionTextBox";
			Pointer1PositionTextBox.PropertyName = "Pointer1Position";
			Pointer1PositionTextBox.Size = new Size(144, 20);
			Pointer1PositionTextBox.TabIndex = 2;
			Pointer1PositionTextBox.LoadingEnd();
			XReferenceLabel.LoadingBegin();
			XReferenceLabel.FocusControl = Pointer1PositionTextBox;
			XReferenceLabel.Location = new Point(10, 82);
			XReferenceLabel.Name = "XReferenceLabel";
			XReferenceLabel.Size = new Size(94, 15);
			XReferenceLabel.Text = "Pointer 1 Position";
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
			EnabledCheckBox.Location = new Point(272, 27);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(80, 24);
			EnabledCheckBox.TabIndex = 8;
			EnabledCheckBox.Text = "Enabled";
			ContextMenuEnabledCheckBox.Location = new Point(384, 27);
			ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			ContextMenuEnabledCheckBox.Size = new Size(152, 24);
			ContextMenuEnabledCheckBox.TabIndex = 9;
			ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			Pointer2PositionTextBox.LoadingBegin();
			Pointer2PositionTextBox.Location = new Point(104, 104);
			Pointer2PositionTextBox.Name = "Pointer2PositionTextBox";
			Pointer2PositionTextBox.PropertyName = "Pointer2Position";
			Pointer2PositionTextBox.Size = new Size(144, 20);
			Pointer2PositionTextBox.TabIndex = 3;
			Pointer2PositionTextBox.LoadingEnd();
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = Pointer2PositionTextBox;
			focusLabel3.Location = new Point(10, 106);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(94, 15);
			focusLabel3.Text = "Pointer 2 Position";
			focusLabel3.LoadingEnd();
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
			UserCanEditCheckBox.Location = new Point(272, 51);
			UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			UserCanEditCheckBox.PropertyName = "UserCanEdit";
			UserCanEditCheckBox.Size = new Size(96, 24);
			UserCanEditCheckBox.TabIndex = 10;
			UserCanEditCheckBox.Text = "User Can Edit";
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(288, 136);
			StyleComboBox.MaxDropDownItems = 20;
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(120, 21);
			StyleComboBox.TabIndex = 14;
			focusLabel7.LoadingBegin();
			focusLabel7.FocusControl = StyleComboBox;
			focusLabel7.Location = new Point(256, 138);
			focusLabel7.Name = "focusLabel7";
			focusLabel7.Size = new Size(32, 15);
			focusLabel7.Text = "Style";
			focusLabel7.LoadingEnd();
			SnapToPointCheckBox.Location = new Point(272, 79);
			SnapToPointCheckBox.Name = "SnapToPointCheckBox";
			SnapToPointCheckBox.PropertyName = "SnapToPoint";
			SnapToPointCheckBox.Size = new Size(96, 24);
			SnapToPointCheckBox.TabIndex = 12;
			SnapToPointCheckBox.Text = "Snap To Point";
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
			HitRegionSizeUpDown.TabIndex = 16;
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
			ClippingStyleComboBox.TabIndex = 15;
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
			CanFocusCheckBox.Location = new Point(384, 51);
			CanFocusCheckBox.Name = "CanFocusCheckBox";
			CanFocusCheckBox.PropertyName = "CanFocus";
			CanFocusCheckBox.Size = new Size(144, 24);
			CanFocusCheckBox.TabIndex = 11;
			CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(CanFocusCheckBox);
			base.Controls.Add(MasterControlCheckBox);
			base.Controls.Add(ClippingStyleComboBox);
			base.Controls.Add(focusLabel8);
			base.Controls.Add(HitRegionSizeUpDown);
			base.Controls.Add(focusLabel6);
			base.Controls.Add(SnapToPointCheckBox);
			base.Controls.Add(StyleComboBox);
			base.Controls.Add(focusLabel7);
			base.Controls.Add(UserCanEditCheckBox);
			base.Controls.Add(LayerNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(Pointer2PositionTextBox);
			base.Controls.Add(focusLabel3);
			base.Controls.Add(ContextMenuEnabledCheckBox);
			base.Controls.Add(TitleTextBox);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(EnabledCheckBox);
			base.Controls.Add(Pointer1PositionTextBox);
			base.Controls.Add(XReferenceLabel);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label8);
			base.Controls.Add(ChannelNameTextBox);
			base.Controls.Add(focusLabel4);
			base.Controls.Add(NameTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(VisibleCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotDataCursorChannelEditorPlugIn";
			base.Size = new Size(520, 256);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Line", false);
			base.AddSubPlugIn(new PlotDataCursorHintEditorPlugIn(), "Hint", false);
			base.AddSubPlugIn(new PlotDataCursorWindowEditorPlugIn(), "Window", false);
			base.AddSubPlugIn(new PlotDataCursorMultipleStyleMenuItemsEditorPlugIn(), "Style Menu-Items", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotDataCursorChannel).Line;
			base.SubPlugIns[1].Value = (base.Value as PlotDataCursorChannel).Hint;
			base.SubPlugIns[2].Value = (base.Value as PlotDataCursorChannel).Window;
			base.SubPlugIns[3].Value = (base.Value as PlotDataCursorChannel).StyleMenuItems;
		}
	}
}
