using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotAnnotationImageEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox checkBox1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanSizeCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanMoveCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel7;

		private EditBox YAxisNameTextBox;

		private FocusLabel focusLabel5;

		private EditBox XAxisNameTextBox;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel focusLabel4;

		private EditBox RotationTextBox;

		private FocusLabel focusLabel1;

		private EditBox YTextBox;

		private FocusLabel label9;

		private EditBox XTextBox;

		private FocusLabel label8;

		private EditBox HeightTextBox;

		private EditBox WidthTextBox;

		private FocusLabel label7;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown ImageIndexUpDown;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ClippingStyleComboBox;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotAnnotationImageEditorPlugIn()
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
			EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			checkBox1 = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			UserCanSizeCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			UserCanMoveCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			NameTextBox = new EditBox();
			focusLabel7 = new FocusLabel();
			YAxisNameTextBox = new EditBox();
			focusLabel5 = new FocusLabel();
			XAxisNameTextBox = new EditBox();
			focusLabel6 = new FocusLabel();
			LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			focusLabel4 = new FocusLabel();
			RotationTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			YTextBox = new EditBox();
			label9 = new FocusLabel();
			XTextBox = new EditBox();
			label8 = new FocusLabel();
			HeightTextBox = new EditBox();
			WidthTextBox = new EditBox();
			label7 = new FocusLabel();
			label1 = new FocusLabel();
			ImageIndexUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			focusLabel2 = new FocusLabel();
			ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			ClippingStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel3 = new FocusLabel();
			CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			EnabledCheckBox.Location = new Point(16, 35);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(72, 24);
			EnabledCheckBox.TabIndex = 1;
			EnabledCheckBox.Text = "Enabled";
			VisibleCheckBox.Location = new Point(16, 11);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			checkBox1.Location = new Point(304, 176);
			checkBox1.Name = "checkBox1";
			checkBox1.PropertyName = "FixedSize";
			checkBox1.Size = new Size(88, 24);
			checkBox1.TabIndex = 14;
			checkBox1.Text = "Fixed Size";
			UserCanEditCheckBox.Location = new Point(16, 107);
			UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			UserCanEditCheckBox.PropertyName = "UserCanEdit";
			UserCanEditCheckBox.Size = new Size(96, 24);
			UserCanEditCheckBox.TabIndex = 4;
			UserCanEditCheckBox.Text = "User Can Edit";
			UserCanSizeCheckBox.Location = new Point(16, 83);
			UserCanSizeCheckBox.Name = "UserCanSizeCheckBox";
			UserCanSizeCheckBox.PropertyName = "UserCanSize";
			UserCanSizeCheckBox.TabIndex = 3;
			UserCanSizeCheckBox.Text = "User Can Size";
			UserCanMoveCheckBox.Location = new Point(16, 59);
			UserCanMoveCheckBox.Name = "UserCanMoveCheckBox";
			UserCanMoveCheckBox.PropertyName = "UserCanMove";
			UserCanMoveCheckBox.TabIndex = 2;
			UserCanMoveCheckBox.Text = "User Can Move";
			NameTextBox.LoadingBegin();
			NameTextBox.Location = new Point(232, 16);
			NameTextBox.Name = "NameTextBox";
			NameTextBox.PropertyName = "Name";
			NameTextBox.Size = new Size(144, 20);
			NameTextBox.TabIndex = 7;
			NameTextBox.LoadingEnd();
			focusLabel7.LoadingBegin();
			focusLabel7.FocusControl = NameTextBox;
			focusLabel7.Location = new Point(195, 18);
			focusLabel7.Name = "focusLabel7";
			focusLabel7.Size = new Size(37, 15);
			focusLabel7.Text = "Name";
			focusLabel7.LoadingEnd();
			YAxisNameTextBox.LoadingBegin();
			YAxisNameTextBox.Location = new Point(232, 64);
			YAxisNameTextBox.Name = "YAxisNameTextBox";
			YAxisNameTextBox.PropertyName = "YAxisName";
			YAxisNameTextBox.Size = new Size(144, 20);
			YAxisNameTextBox.TabIndex = 9;
			YAxisNameTextBox.LoadingEnd();
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = YAxisNameTextBox;
			focusLabel5.Location = new Point(160, 66);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(72, 15);
			focusLabel5.Text = "Y-Axis Name";
			focusLabel5.LoadingEnd();
			XAxisNameTextBox.LoadingBegin();
			XAxisNameTextBox.Location = new Point(232, 40);
			XAxisNameTextBox.Name = "XAxisNameTextBox";
			XAxisNameTextBox.PropertyName = "XAxisName";
			XAxisNameTextBox.Size = new Size(144, 20);
			XAxisNameTextBox.TabIndex = 8;
			XAxisNameTextBox.LoadingEnd();
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = XAxisNameTextBox;
			focusLabel6.Location = new Point(160, 42);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(72, 15);
			focusLabel6.Text = "X-Axis Name";
			focusLabel6.LoadingEnd();
			LayerNumericUpDown.Location = new Point(320, 88);
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
			LayerNumericUpDown.TabIndex = 11;
			LayerNumericUpDown.TextAlign = HorizontalAlignment.Center;
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = LayerNumericUpDown;
			focusLabel4.Location = new Point(285, 89);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(35, 15);
			focusLabel4.Text = "Layer";
			focusLabel4.LoadingEnd();
			RotationTextBox.LoadingBegin();
			RotationTextBox.Location = new Point(232, 88);
			RotationTextBox.Name = "RotationTextBox";
			RotationTextBox.PropertyName = "Rotation";
			RotationTextBox.Size = new Size(48, 20);
			RotationTextBox.TabIndex = 10;
			RotationTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = RotationTextBox;
			focusLabel1.Location = new Point(183, 90);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(49, 15);
			focusLabel1.Text = "Rotation";
			focusLabel1.LoadingEnd();
			YTextBox.LoadingBegin();
			YTextBox.Location = new Point(432, 40);
			YTextBox.Name = "YTextBox";
			YTextBox.PropertyName = "Y";
			YTextBox.Size = new Size(112, 20);
			YTextBox.TabIndex = 16;
			YTextBox.LoadingEnd();
			label9.LoadingBegin();
			label9.FocusControl = YTextBox;
			label9.Location = new Point(417, 42);
			label9.Name = "label9";
			label9.Size = new Size(15, 15);
			label9.Text = "Y";
			label9.LoadingEnd();
			XTextBox.LoadingBegin();
			XTextBox.Location = new Point(432, 16);
			XTextBox.Name = "XTextBox";
			XTextBox.PropertyName = "X";
			XTextBox.Size = new Size(112, 20);
			XTextBox.TabIndex = 15;
			XTextBox.LoadingEnd();
			label8.LoadingBegin();
			label8.FocusControl = XTextBox;
			label8.Location = new Point(417, 18);
			label8.Name = "label8";
			label8.Size = new Size(15, 15);
			label8.Text = "X";
			label8.LoadingEnd();
			HeightTextBox.LoadingBegin();
			HeightTextBox.Location = new Point(432, 88);
			HeightTextBox.Name = "HeightTextBox";
			HeightTextBox.PropertyName = "Height";
			HeightTextBox.Size = new Size(112, 20);
			HeightTextBox.TabIndex = 18;
			HeightTextBox.LoadingEnd();
			WidthTextBox.LoadingBegin();
			WidthTextBox.Location = new Point(432, 64);
			WidthTextBox.Name = "WidthTextBox";
			WidthTextBox.PropertyName = "Width";
			WidthTextBox.Size = new Size(112, 20);
			WidthTextBox.TabIndex = 17;
			WidthTextBox.LoadingEnd();
			label7.LoadingBegin();
			label7.FocusControl = WidthTextBox;
			label7.Location = new Point(396, 66);
			label7.Name = "label7";
			label7.Size = new Size(36, 15);
			label7.Text = "Width";
			label7.LoadingEnd();
			label1.LoadingBegin();
			label1.FocusControl = HeightTextBox;
			label1.Location = new Point(393, 90);
			label1.Name = "label1";
			label1.Size = new Size(39, 15);
			label1.Text = "Height";
			label1.LoadingEnd();
			ImageIndexUpDown.Location = new Point(232, 176);
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
			ImageIndexUpDown.TabIndex = 13;
			ImageIndexUpDown.TextAlign = HorizontalAlignment.Center;
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = ImageIndexUpDown;
			focusLabel2.Location = new Point(164, 177);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(68, 15);
			focusLabel2.Text = "Image Index";
			focusLabel2.LoadingEnd();
			ContextMenuEnabledCheckBox.Location = new Point(16, 132);
			ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			ContextMenuEnabledCheckBox.Size = new Size(144, 24);
			ContextMenuEnabledCheckBox.TabIndex = 5;
			ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			ClippingStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ClippingStyleComboBox.Location = new Point(232, 112);
			ClippingStyleComboBox.MaxDropDownItems = 20;
			ClippingStyleComboBox.Name = "ClippingStyleComboBox";
			ClippingStyleComboBox.PropertyName = "ClippingStyle";
			ClippingStyleComboBox.Size = new Size(80, 21);
			ClippingStyleComboBox.TabIndex = 12;
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = ClippingStyleComboBox;
			focusLabel3.Location = new Point(157, 114);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(75, 15);
			focusLabel3.Text = "Clipping Style";
			focusLabel3.LoadingEnd();
			CanFocusCheckBox.Location = new Point(16, 157);
			CanFocusCheckBox.Name = "CanFocusCheckBox";
			CanFocusCheckBox.PropertyName = "CanFocus";
			CanFocusCheckBox.Size = new Size(144, 24);
			CanFocusCheckBox.TabIndex = 6;
			CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(CanFocusCheckBox);
			base.Controls.Add(ClippingStyleComboBox);
			base.Controls.Add(focusLabel3);
			base.Controls.Add(ContextMenuEnabledCheckBox);
			base.Controls.Add(ImageIndexUpDown);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(NameTextBox);
			base.Controls.Add(focusLabel7);
			base.Controls.Add(YAxisNameTextBox);
			base.Controls.Add(focusLabel5);
			base.Controls.Add(XAxisNameTextBox);
			base.Controls.Add(focusLabel6);
			base.Controls.Add(LayerNumericUpDown);
			base.Controls.Add(focusLabel4);
			base.Controls.Add(RotationTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(YTextBox);
			base.Controls.Add(label9);
			base.Controls.Add(XTextBox);
			base.Controls.Add(label8);
			base.Controls.Add(HeightTextBox);
			base.Controls.Add(WidthTextBox);
			base.Controls.Add(label7);
			base.Controls.Add(label1);
			base.Controls.Add(UserCanEditCheckBox);
			base.Controls.Add(UserCanSizeCheckBox);
			base.Controls.Add(UserCanMoveCheckBox);
			base.Controls.Add(checkBox1);
			base.Controls.Add(EnabledCheckBox);
			base.Controls.Add(VisibleCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotAnnotationImageEditorPlugIn";
			base.Size = new Size(616, 272);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotAnnotationUnitTypesEditorPlugIn(), "Unit Types", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = base.Value;
		}
	}
}
