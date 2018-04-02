using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotLimitBandXEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private EditBox XAxisNameTextBox;

		private FocusLabel focusLabel4;

		private EditBox YAxisNameTextBox;

		private FocusLabel focusLabel5;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private FocusLabel XReferenceLabel;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private FocusLabel focusLabel3;

		private EditBox XStartTextBox;

		private EditBox XStopTextBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ClippingStyleComboBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanMoveCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown HitRegionSizeUpDown;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotLimitBandXEditorPlugIn()
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
			XAxisNameTextBox = new EditBox();
			focusLabel4 = new FocusLabel();
			YAxisNameTextBox = new EditBox();
			focusLabel5 = new FocusLabel();
			ColorPicker = new ColorPicker();
			label8 = new FocusLabel();
			XStartTextBox = new EditBox();
			XReferenceLabel = new FocusLabel();
			TitleTextBox = new EditMultiLine();
			focusLabel2 = new FocusLabel();
			EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			XStopTextBox = new EditBox();
			focusLabel3 = new FocusLabel();
			ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label1 = new FocusLabel();
			UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			ClippingStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel8 = new FocusLabel();
			UserCanMoveCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			HitRegionSizeUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			focusLabel6 = new FocusLabel();
			CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			VisibleCheckBox.Location = new Point(248, 3);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 6;
			VisibleCheckBox.Text = "Visible";
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
			XAxisNameTextBox.LoadingBegin();
			XAxisNameTextBox.Location = new Point(80, 136);
			XAxisNameTextBox.Name = "XAxisNameTextBox";
			XAxisNameTextBox.PropertyName = "XAxisName";
			XAxisNameTextBox.Size = new Size(144, 20);
			XAxisNameTextBox.TabIndex = 4;
			XAxisNameTextBox.LoadingEnd();
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = XAxisNameTextBox;
			focusLabel4.Location = new Point(8, 138);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(72, 15);
			focusLabel4.Text = "X-Axis Name";
			focusLabel4.LoadingEnd();
			YAxisNameTextBox.LoadingBegin();
			YAxisNameTextBox.Location = new Point(80, 160);
			YAxisNameTextBox.Name = "YAxisNameTextBox";
			YAxisNameTextBox.PropertyName = "YAxisName";
			YAxisNameTextBox.Size = new Size(144, 20);
			YAxisNameTextBox.TabIndex = 5;
			YAxisNameTextBox.LoadingEnd();
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = YAxisNameTextBox;
			focusLabel5.Location = new Point(8, 162);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(72, 15);
			focusLabel5.Text = "Y-Axis Name";
			focusLabel5.LoadingEnd();
			ColorPicker.Location = new Point(80, 200);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(48, 21);
			ColorPicker.Style = ColorPickerStyle.ColorBox;
			ColorPicker.TabIndex = 13;
			label8.LoadingBegin();
			label8.FocusControl = ColorPicker;
			label8.Location = new Point(46, 203);
			label8.Name = "label8";
			label8.Size = new Size(34, 15);
			label8.Text = "Color";
			label8.LoadingEnd();
			XStartTextBox.LoadingBegin();
			XStartTextBox.Location = new Point(80, 72);
			XStartTextBox.Name = "XStartTextBox";
			XStartTextBox.PropertyName = "XStart";
			XStartTextBox.Size = new Size(144, 20);
			XStartTextBox.TabIndex = 2;
			XStartTextBox.LoadingEnd();
			XReferenceLabel.LoadingBegin();
			XReferenceLabel.FocusControl = XStartTextBox;
			XReferenceLabel.Location = new Point(38, 74);
			XReferenceLabel.Name = "XReferenceLabel";
			XReferenceLabel.Size = new Size(42, 15);
			XReferenceLabel.Text = "X-Start";
			XReferenceLabel.LoadingEnd();
			TitleTextBox.EditFont = null;
			TitleTextBox.Location = new Point(80, 40);
			TitleTextBox.Name = "TitleTextBox";
			TitleTextBox.PropertyName = "TitleText";
			TitleTextBox.Size = new Size(144, 20);
			TitleTextBox.TabIndex = 1;
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = TitleTextBox;
			focusLabel2.Location = new Point(27, 43);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(53, 15);
			focusLabel2.Text = "Title Text";
			focusLabel2.LoadingEnd();
			EnabledCheckBox.Location = new Point(248, 27);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(80, 24);
			EnabledCheckBox.TabIndex = 7;
			EnabledCheckBox.Text = "Enabled";
			XStopTextBox.LoadingBegin();
			XStopTextBox.Location = new Point(80, 96);
			XStopTextBox.Name = "XStopTextBox";
			XStopTextBox.PropertyName = "XStop";
			XStopTextBox.Size = new Size(144, 20);
			XStopTextBox.TabIndex = 3;
			XStopTextBox.LoadingEnd();
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = XStopTextBox;
			focusLabel3.Location = new Point(39, 98);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(41, 15);
			focusLabel3.Text = "X-Stop";
			focusLabel3.LoadingEnd();
			ContextMenuEnabledCheckBox.Location = new Point(248, 51);
			ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			ContextMenuEnabledCheckBox.Size = new Size(152, 24);
			ContextMenuEnabledCheckBox.TabIndex = 8;
			ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			LayerNumericUpDown.Location = new Point(168, 200);
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
			LayerNumericUpDown.TabIndex = 14;
			LayerNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label1.LoadingBegin();
			label1.FocusControl = LayerNumericUpDown;
			label1.Location = new Point(133, 201);
			label1.Name = "label1";
			label1.Size = new Size(35, 15);
			label1.Text = "Layer";
			label1.LoadingEnd();
			UserCanEditCheckBox.Location = new Point(248, 76);
			UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			UserCanEditCheckBox.PropertyName = "UserCanEdit";
			UserCanEditCheckBox.Size = new Size(96, 24);
			UserCanEditCheckBox.TabIndex = 9;
			UserCanEditCheckBox.Text = "User Can Edit";
			ClippingStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ClippingStyleComboBox.Location = new Point(312, 200);
			ClippingStyleComboBox.MaxDropDownItems = 20;
			ClippingStyleComboBox.Name = "ClippingStyleComboBox";
			ClippingStyleComboBox.PropertyName = "ClippingStyle";
			ClippingStyleComboBox.Size = new Size(80, 21);
			ClippingStyleComboBox.TabIndex = 15;
			focusLabel8.LoadingBegin();
			focusLabel8.FocusControl = ClippingStyleComboBox;
			focusLabel8.Location = new Point(237, 202);
			focusLabel8.Name = "focusLabel8";
			focusLabel8.Size = new Size(75, 15);
			focusLabel8.Text = "Clipping Style";
			focusLabel8.LoadingEnd();
			UserCanMoveCheckBox.Location = new Point(248, 100);
			UserCanMoveCheckBox.Name = "UserCanMoveCheckBox";
			UserCanMoveCheckBox.PropertyName = "UserCanMove";
			UserCanMoveCheckBox.Size = new Size(120, 24);
			UserCanMoveCheckBox.TabIndex = 10;
			UserCanMoveCheckBox.Text = "User Can Move";
			HitRegionSizeUpDown.Location = new Point(336, 160);
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
			HitRegionSizeUpDown.TabIndex = 12;
			HitRegionSizeUpDown.TextAlign = HorizontalAlignment.Center;
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = HitRegionSizeUpDown;
			focusLabel6.Location = new Point(253, 161);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(83, 15);
			focusLabel6.Text = "Hit Region Size";
			focusLabel6.LoadingEnd();
			CanFocusCheckBox.Location = new Point(248, 124);
			CanFocusCheckBox.Name = "CanFocusCheckBox";
			CanFocusCheckBox.PropertyName = "CanFocus";
			CanFocusCheckBox.Size = new Size(80, 24);
			CanFocusCheckBox.TabIndex = 11;
			CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(CanFocusCheckBox);
			base.Controls.Add(HitRegionSizeUpDown);
			base.Controls.Add(focusLabel6);
			base.Controls.Add(UserCanMoveCheckBox);
			base.Controls.Add(ClippingStyleComboBox);
			base.Controls.Add(focusLabel8);
			base.Controls.Add(UserCanEditCheckBox);
			base.Controls.Add(LayerNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(ContextMenuEnabledCheckBox);
			base.Controls.Add(XStopTextBox);
			base.Controls.Add(focusLabel3);
			base.Controls.Add(TitleTextBox);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(EnabledCheckBox);
			base.Controls.Add(XStartTextBox);
			base.Controls.Add(XReferenceLabel);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label8);
			base.Controls.Add(YAxisNameTextBox);
			base.Controls.Add(focusLabel5);
			base.Controls.Add(XAxisNameTextBox);
			base.Controls.Add(focusLabel4);
			base.Controls.Add(NameTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(VisibleCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotLimitBandXEditorPlugIn";
			base.Size = new Size(456, 240);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotLimitBandX).Fill;
		}
	}
}
