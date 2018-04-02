using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotAxisEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private EditBox MaxTextBox;

		private FocusLabel label2;

		private EditBox SpanTextBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ReverseCheckBox;

		private EditBox MinTextBox;

		private FocusLabel label3;

		private FocusLabel focusLabel2;

		private DoubleEditButton MinDoubleEditButton;

		private DoubleEditButton MaxDoubleEditButton;

		private DoubleEditButton SpanDoubleEditButton;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private EditBox CursorScalerEditBox;

		private FocusLabel focusLabel3;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel4;

		private FocusLabel focusLabel5;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ScaleTypeComboBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ControlKeyToggleEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox MasterUICheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ClipToMinMaxCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox MasterUISlaveCheckBox;

		private Container components;

		public PlotAxisEditorPlugIn()
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
			ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label1 = new FocusLabel();
			MaxTextBox = new EditBox();
			label2 = new FocusLabel();
			SpanTextBox = new EditBox();
			ReverseCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			MinTextBox = new EditBox();
			label3 = new FocusLabel();
			focusLabel2 = new FocusLabel();
			MinDoubleEditButton = new DoubleEditButton();
			MaxDoubleEditButton = new DoubleEditButton();
			SpanDoubleEditButton = new DoubleEditButton();
			ColorPicker = new ColorPicker();
			label8 = new FocusLabel();
			UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			CursorScalerEditBox = new EditBox();
			focusLabel3 = new FocusLabel();
			TitleTextBox = new EditMultiLine();
			focusLabel4 = new FocusLabel();
			focusLabel5 = new FocusLabel();
			ScaleTypeComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			ControlKeyToggleEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			MasterUICheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			ClipToMinMaxCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			MasterUISlaveCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			((ISupportInitialize)LayerNumericUpDown).BeginInit();
			base.SuspendLayout();
			VisibleCheckBox.Location = new Point(288, 3);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 13;
			VisibleCheckBox.Text = "Visible";
			EnabledCheckBox.Location = new Point(288, 27);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(80, 24);
			EnabledCheckBox.TabIndex = 14;
			EnabledCheckBox.Text = "Enabled";
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
			ContextMenuEnabledCheckBox.Location = new Point(288, 51);
			ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			ContextMenuEnabledCheckBox.Size = new Size(152, 24);
			ContextMenuEnabledCheckBox.TabIndex = 15;
			ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			LayerNumericUpDown.Location = new Point(192, 64);
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
			label1.Location = new Point(157, 65);
			label1.Name = "label1";
			label1.Size = new Size(35, 15);
			label1.Text = "Layer";
			label1.LoadingEnd();
			MaxTextBox.LoadingBegin();
			MaxTextBox.Location = new Point(104, 128);
			MaxTextBox.Name = "MaxTextBox";
			MaxTextBox.PropertyName = "Max";
			MaxTextBox.ReadOnly = true;
			MaxTextBox.Size = new Size(144, 20);
			MaxTextBox.TabIndex = 6;
			MaxTextBox.TextAlign = HorizontalAlignment.Center;
			MaxTextBox.LoadingEnd();
			label2.LoadingBegin();
			label2.FocusControl = SpanTextBox;
			label2.Location = new Point(71, 154);
			label2.Name = "label2";
			label2.Size = new Size(33, 15);
			label2.Text = "Span";
			label2.LoadingEnd();
			SpanTextBox.LoadingBegin();
			SpanTextBox.Location = new Point(104, 152);
			SpanTextBox.Name = "SpanTextBox";
			SpanTextBox.PropertyName = "Span";
			SpanTextBox.Size = new Size(144, 20);
			SpanTextBox.TabIndex = 8;
			SpanTextBox.TextAlign = HorizontalAlignment.Center;
			SpanTextBox.LoadingEnd();
			ReverseCheckBox.Location = new Point(216, 184);
			ReverseCheckBox.Name = "ReverseCheckBox";
			ReverseCheckBox.PropertyName = "Reverse";
			ReverseCheckBox.Size = new Size(72, 24);
			ReverseCheckBox.TabIndex = 11;
			ReverseCheckBox.Text = "Reverse";
			MinTextBox.LoadingBegin();
			MinTextBox.Location = new Point(104, 104);
			MinTextBox.Name = "MinTextBox";
			MinTextBox.PropertyName = "Min";
			MinTextBox.Size = new Size(144, 20);
			MinTextBox.TabIndex = 4;
			MinTextBox.TextAlign = HorizontalAlignment.Center;
			MinTextBox.LoadingEnd();
			label3.LoadingBegin();
			label3.FocusControl = MaxTextBox;
			label3.Location = new Point(76, 130);
			label3.Name = "label3";
			label3.Size = new Size(28, 15);
			label3.Text = "Max";
			label3.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = MinTextBox;
			focusLabel2.Location = new Point(79, 106);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(25, 15);
			focusLabel2.Text = "Min";
			focusLabel2.LoadingEnd();
			MinDoubleEditButton.EditBox = MinTextBox;
			MinDoubleEditButton.Location = new Point(248, 102);
			MinDoubleEditButton.Name = "MinDoubleEditButton";
			MinDoubleEditButton.TabIndex = 5;
			MaxDoubleEditButton.EditBox = MaxTextBox;
			MaxDoubleEditButton.Location = new Point(248, 126);
			MaxDoubleEditButton.Name = "MaxDoubleEditButton";
			MaxDoubleEditButton.TabIndex = 7;
			SpanDoubleEditButton.EditBox = SpanTextBox;
			SpanDoubleEditButton.Location = new Point(248, 150);
			SpanDoubleEditButton.Name = "SpanDoubleEditButton";
			SpanDoubleEditButton.TabIndex = 9;
			ColorPicker.Location = new Point(104, 64);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(48, 21);
			ColorPicker.Style = ColorPickerStyle.ColorBox;
			ColorPicker.TabIndex = 2;
			label8.LoadingBegin();
			label8.FocusControl = ColorPicker;
			label8.Location = new Point(70, 67);
			label8.Name = "label8";
			label8.Size = new Size(34, 15);
			label8.Text = "Color";
			label8.LoadingEnd();
			UserCanEditCheckBox.Location = new Point(288, 75);
			UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			UserCanEditCheckBox.PropertyName = "UserCanEdit";
			UserCanEditCheckBox.Size = new Size(96, 24);
			UserCanEditCheckBox.TabIndex = 16;
			UserCanEditCheckBox.Text = "User Can Edit";
			CursorScalerEditBox.LoadingBegin();
			CursorScalerEditBox.Location = new Point(104, 224);
			CursorScalerEditBox.Name = "CursorScalerEditBox";
			CursorScalerEditBox.PropertyName = "CursorScaler";
			CursorScalerEditBox.Size = new Size(144, 20);
			CursorScalerEditBox.TabIndex = 12;
			CursorScalerEditBox.LoadingEnd();
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = CursorScalerEditBox;
			focusLabel3.Location = new Point(29, 226);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(75, 15);
			focusLabel3.Text = "Cursor Scaler";
			focusLabel3.LoadingEnd();
			TitleTextBox.EditFont = null;
			TitleTextBox.Location = new Point(104, 32);
			TitleTextBox.Name = "TitleTextBox";
			TitleTextBox.PropertyName = "TitleText";
			TitleTextBox.Size = new Size(144, 20);
			TitleTextBox.TabIndex = 1;
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = TitleTextBox;
			focusLabel4.Location = new Point(51, 35);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(53, 15);
			focusLabel4.Text = "Title Text";
			focusLabel4.LoadingEnd();
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = ScaleTypeComboBox;
			focusLabel5.Location = new Point(42, 186);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(62, 15);
			focusLabel5.Text = "Scale Type";
			focusLabel5.LoadingEnd();
			ScaleTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ScaleTypeComboBox.Location = new Point(104, 184);
			ScaleTypeComboBox.Name = "ScaleTypeComboBox";
			ScaleTypeComboBox.PropertyName = "ScaleType";
			ScaleTypeComboBox.Size = new Size(104, 21);
			ScaleTypeComboBox.TabIndex = 10;
			ControlKeyToggleEnabledCheckBox.Location = new Point(288, 123);
			ControlKeyToggleEnabledCheckBox.Name = "ControlKeyToggleEnabledCheckBox";
			ControlKeyToggleEnabledCheckBox.PropertyName = "ControlKeyToggleEnabled";
			ControlKeyToggleEnabledCheckBox.Size = new Size(208, 24);
			ControlKeyToggleEnabledCheckBox.TabIndex = 18;
			ControlKeyToggleEnabledCheckBox.Text = "Control-Key Toggle Enabled";
			CanFocusCheckBox.Location = new Point(288, 99);
			CanFocusCheckBox.Name = "CanFocusCheckBox";
			CanFocusCheckBox.PropertyName = "CanFocus";
			CanFocusCheckBox.Size = new Size(144, 24);
			CanFocusCheckBox.TabIndex = 17;
			CanFocusCheckBox.Text = "Can Focus";
			MasterUICheckBox.Location = new Point(288, 147);
			MasterUICheckBox.Name = "MasterUICheckBox";
			MasterUICheckBox.PropertyName = "MasterUI";
			MasterUICheckBox.Size = new Size(208, 24);
			MasterUICheckBox.TabIndex = 19;
			MasterUICheckBox.Text = "Master UI";
			ClipToMinMaxCheckBox.Location = new Point(288, 195);
			ClipToMinMaxCheckBox.Name = "ClipToMinMaxCheckBox";
			ClipToMinMaxCheckBox.PropertyName = "ClipToMinMax";
			ClipToMinMaxCheckBox.Size = new Size(208, 24);
			ClipToMinMaxCheckBox.TabIndex = 21;
			ClipToMinMaxCheckBox.Text = "Clip To Min-Max";
			MasterUISlaveCheckBox.Location = new Point(288, 171);
			MasterUISlaveCheckBox.Name = "MasterUISlaveCheckBox";
			MasterUISlaveCheckBox.PropertyName = "MasterUISlave";
			MasterUISlaveCheckBox.Size = new Size(208, 24);
			MasterUISlaveCheckBox.TabIndex = 20;
			MasterUISlaveCheckBox.Text = "Master UI Slave";
			base.Controls.Add(MasterUISlaveCheckBox);
			base.Controls.Add(ClipToMinMaxCheckBox);
			base.Controls.Add(MasterUICheckBox);
			base.Controls.Add(CanFocusCheckBox);
			base.Controls.Add(ControlKeyToggleEnabledCheckBox);
			base.Controls.Add(focusLabel5);
			base.Controls.Add(ScaleTypeComboBox);
			base.Controls.Add(TitleTextBox);
			base.Controls.Add(focusLabel4);
			base.Controls.Add(CursorScalerEditBox);
			base.Controls.Add(focusLabel3);
			base.Controls.Add(UserCanEditCheckBox);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label8);
			base.Controls.Add(SpanDoubleEditButton);
			base.Controls.Add(MaxDoubleEditButton);
			base.Controls.Add(MinDoubleEditButton);
			base.Controls.Add(MaxTextBox);
			base.Controls.Add(label2);
			base.Controls.Add(SpanTextBox);
			base.Controls.Add(ReverseCheckBox);
			base.Controls.Add(MinTextBox);
			base.Controls.Add(label3);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(LayerNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(ContextMenuEnabledCheckBox);
			base.Controls.Add(NameTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotAxisEditorPlugIn";
			base.Size = new Size(568, 272);
			base.Tag = "";
			base.Title = "Plot Axis Editor";
			((ISupportInitialize)LayerNumericUpDown).EndInit();
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotTitleEditorPlugIn(), "Title", false);
			base.AddSubPlugIn(new ScaleDisplayLinearEditorPlugIn(), "Scale Display", false);
			base.AddSubPlugIn(new ScaleRangeLinearEditorPlugIn(), "Scale Range", false);
			base.AddSubPlugIn(new PlotAxisGridLinesEditorPlugIn(), "Grid-Lines", false);
			base.AddSubPlugIn(new PlotAxisTrackingEditorPlugIn(), "Tracking", false);
			base.AddSubPlugIn(new PlotLayoutAxisEditorPlugIn(), "Dock", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotAxis).Title;
			base.SubPlugIns[1].Value = (base.Value as PlotAxis).ScaleDisplay;
			base.SubPlugIns[2].Value = (base.Value as PlotAxis).ScaleRange;
			base.SubPlugIns[3].Value = (base.Value as PlotAxis).GridLines;
			base.SubPlugIns[4].Value = (base.Value as PlotAxis).Tracking;
			base.SubPlugIns[5].Value = base.Value;
		}
	}
}
