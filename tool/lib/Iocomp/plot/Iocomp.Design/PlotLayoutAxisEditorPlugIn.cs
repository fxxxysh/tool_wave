using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotLayoutAxisEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel1;

		private EditBox DockOrderTextBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DockSideComboBox;

		private FocusLabel label2;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DockStyleComboBox;

		private FocusLabel focusLabel2;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown DockMarginUpDown;

		private EditBox DockDataViewNameTextBox;

		private GroupBox StopGroupBox;

		private FocusLabel focusLabel10;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DockStopStyleComboBox;

		private FocusLabel focusLabel11;

		private EditBox DockPercentStopTextBox;

		private FocusLabel focusLabel5;

		private GroupBox StartGroupBox;

		private FocusLabel focusLabel9;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DockStartStyleComboBox;

		private FocusLabel focusLabel8;

		private EditBox DockPercentStartTextBox;

		private FocusLabel focusLabel4;

		private EditBox DockStopAxisNameEditBox;

		private EditBox DockStartAxisNameEditBox;

		private EditBox DockStackingEndsMarginEditBox;

		private FocusLabel focusLabel7;

		private Iocomp.Design.Plugin.EditorControls.CheckBox DockForceStackingCheckBox;

		private Container components;

		public PlotLayoutAxisEditorPlugIn()
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
			DockOrderTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			DockSideComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label2 = new FocusLabel();
			DockDataViewNameTextBox = new EditBox();
			focusLabel3 = new FocusLabel();
			DockStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel2 = new FocusLabel();
			focusLabel6 = new FocusLabel();
			DockMarginUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			StopGroupBox = new GroupBox();
			DockStopAxisNameEditBox = new EditBox();
			focusLabel10 = new FocusLabel();
			DockStopStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel11 = new FocusLabel();
			DockPercentStopTextBox = new EditBox();
			focusLabel5 = new FocusLabel();
			StartGroupBox = new GroupBox();
			DockStartAxisNameEditBox = new EditBox();
			focusLabel9 = new FocusLabel();
			DockStartStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel8 = new FocusLabel();
			DockPercentStartTextBox = new EditBox();
			focusLabel4 = new FocusLabel();
			DockStackingEndsMarginEditBox = new EditBox();
			focusLabel7 = new FocusLabel();
			DockForceStackingCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			((ISupportInitialize)DockMarginUpDown).BeginInit();
			StopGroupBox.SuspendLayout();
			StartGroupBox.SuspendLayout();
			base.SuspendLayout();
			DockOrderTextBox.LoadingBegin();
			DockOrderTextBox.Location = new Point(64, 256);
			DockOrderTextBox.Name = "DockOrderTextBox";
			DockOrderTextBox.PropertyName = "DockOrder";
			DockOrderTextBox.ReadOnly = true;
			DockOrderTextBox.Size = new Size(136, 20);
			DockOrderTextBox.TabIndex = 8;
			DockOrderTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = DockOrderTextBox;
			focusLabel1.Location = new Point(28, 258);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(36, 15);
			focusLabel1.Text = "Order";
			focusLabel1.LoadingEnd();
			DockSideComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			DockSideComboBox.Location = new Point(64, 232);
			DockSideComboBox.MaxDropDownItems = 20;
			DockSideComboBox.Name = "DockSideComboBox";
			DockSideComboBox.PropertyName = "DockSide";
			DockSideComboBox.ReadOnly = true;
			DockSideComboBox.Size = new Size(136, 21);
			DockSideComboBox.TabIndex = 7;
			label2.LoadingBegin();
			label2.FocusControl = DockSideComboBox;
			label2.Location = new Point(34, 234);
			label2.Name = "label2";
			label2.Size = new Size(30, 15);
			label2.Text = "Side";
			label2.LoadingEnd();
			DockDataViewNameTextBox.LoadingBegin();
			DockDataViewNameTextBox.Location = new Point(304, 208);
			DockDataViewNameTextBox.Name = "DockDataViewNameTextBox";
			DockDataViewNameTextBox.PropertyName = "DockDataViewName";
			DockDataViewNameTextBox.ReadOnly = true;
			DockDataViewNameTextBox.Size = new Size(144, 20);
			DockDataViewNameTextBox.TabIndex = 6;
			DockDataViewNameTextBox.LoadingEnd();
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = DockDataViewNameTextBox;
			focusLabel3.Location = new Point(213, 210);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(91, 15);
			focusLabel3.Text = "Data-View Name";
			focusLabel3.LoadingEnd();
			DockStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			DockStyleComboBox.Location = new Point(64, 208);
			DockStyleComboBox.MaxDropDownItems = 20;
			DockStyleComboBox.Name = "DockStyleComboBox";
			DockStyleComboBox.PropertyName = "DockStyle";
			DockStyleComboBox.ReadOnly = true;
			DockStyleComboBox.Size = new Size(136, 21);
			DockStyleComboBox.TabIndex = 5;
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = DockStyleComboBox;
			focusLabel2.Location = new Point(32, 210);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(32, 15);
			focusLabel2.Text = "Style";
			focusLabel2.LoadingEnd();
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = DockMarginUpDown;
			focusLabel6.Location = new Point(103, 17);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(41, 15);
			focusLabel6.Text = "Margin";
			focusLabel6.LoadingEnd();
			DockMarginUpDown.Location = new Point(144, 16);
			DockMarginUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			DockMarginUpDown.Minimum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				-2147483648
			});
			DockMarginUpDown.Name = "DockMarginUpDown";
			DockMarginUpDown.PropertyName = "DockMargin";
			DockMarginUpDown.Size = new Size(56, 20);
			DockMarginUpDown.TabIndex = 0;
			DockMarginUpDown.TextAlign = HorizontalAlignment.Center;
			StopGroupBox.Controls.Add(DockStopAxisNameEditBox);
			StopGroupBox.Controls.Add(focusLabel10);
			StopGroupBox.Controls.Add(DockStopStyleComboBox);
			StopGroupBox.Controls.Add(focusLabel11);
			StopGroupBox.Controls.Add(DockPercentStopTextBox);
			StopGroupBox.Controls.Add(focusLabel5);
			StopGroupBox.Location = new Point(8, 144);
			StopGroupBox.Name = "StopGroupBox";
			StopGroupBox.Size = new Size(544, 48);
			StopGroupBox.TabIndex = 4;
			StopGroupBox.TabStop = false;
			StopGroupBox.Text = "Stop";
			DockStopAxisNameEditBox.LoadingBegin();
			DockStopAxisNameEditBox.Location = new Point(384, 16);
			DockStopAxisNameEditBox.Name = "DockStopAxisNameEditBox";
			DockStopAxisNameEditBox.PropertyName = "DockStopAxisName";
			DockStopAxisNameEditBox.Size = new Size(144, 20);
			DockStopAxisNameEditBox.TabIndex = 2;
			DockStopAxisNameEditBox.LoadingEnd();
			focusLabel10.LoadingBegin();
			focusLabel10.FocusControl = DockStopAxisNameEditBox;
			focusLabel10.Location = new Point(323, 18);
			focusLabel10.Name = "focusLabel10";
			focusLabel10.Size = new Size(61, 15);
			focusLabel10.Text = "Axis Name";
			focusLabel10.LoadingEnd();
			DockStopStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			DockStopStyleComboBox.Location = new Point(208, 16);
			DockStopStyleComboBox.MaxDropDownItems = 20;
			DockStopStyleComboBox.Name = "DockStopStyleComboBox";
			DockStopStyleComboBox.PropertyName = "DockStopStyle";
			DockStopStyleComboBox.Size = new Size(104, 21);
			DockStopStyleComboBox.TabIndex = 1;
			focusLabel11.LoadingBegin();
			focusLabel11.FocusControl = DockStopStyleComboBox;
			focusLabel11.Location = new Point(176, 18);
			focusLabel11.Name = "focusLabel11";
			focusLabel11.Size = new Size(32, 15);
			focusLabel11.Text = "Style";
			focusLabel11.LoadingEnd();
			DockPercentStopTextBox.LoadingBegin();
			DockPercentStopTextBox.Location = new Point(56, 16);
			DockPercentStopTextBox.Name = "DockPercentStopTextBox";
			DockPercentStopTextBox.PropertyName = "DockPercentStop";
			DockPercentStopTextBox.Size = new Size(112, 20);
			DockPercentStopTextBox.TabIndex = 0;
			DockPercentStopTextBox.LoadingEnd();
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = DockPercentStopTextBox;
			focusLabel5.Location = new Point(11, 18);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(45, 15);
			focusLabel5.Text = "Percent";
			focusLabel5.LoadingEnd();
			StartGroupBox.Controls.Add(DockStartAxisNameEditBox);
			StartGroupBox.Controls.Add(focusLabel9);
			StartGroupBox.Controls.Add(DockStartStyleComboBox);
			StartGroupBox.Controls.Add(focusLabel8);
			StartGroupBox.Controls.Add(DockPercentStartTextBox);
			StartGroupBox.Controls.Add(focusLabel4);
			StartGroupBox.Location = new Point(8, 88);
			StartGroupBox.Name = "StartGroupBox";
			StartGroupBox.Size = new Size(544, 48);
			StartGroupBox.TabIndex = 3;
			StartGroupBox.TabStop = false;
			StartGroupBox.Text = "Start";
			DockStartAxisNameEditBox.LoadingBegin();
			DockStartAxisNameEditBox.Location = new Point(384, 16);
			DockStartAxisNameEditBox.Name = "DockStartAxisNameEditBox";
			DockStartAxisNameEditBox.PropertyName = "DockStartAxisName";
			DockStartAxisNameEditBox.Size = new Size(144, 20);
			DockStartAxisNameEditBox.TabIndex = 2;
			DockStartAxisNameEditBox.LoadingEnd();
			focusLabel9.LoadingBegin();
			focusLabel9.FocusControl = DockStartAxisNameEditBox;
			focusLabel9.Location = new Point(323, 18);
			focusLabel9.Name = "focusLabel9";
			focusLabel9.Size = new Size(61, 15);
			focusLabel9.Text = "Axis Name";
			focusLabel9.LoadingEnd();
			DockStartStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			DockStartStyleComboBox.Location = new Point(208, 16);
			DockStartStyleComboBox.MaxDropDownItems = 20;
			DockStartStyleComboBox.Name = "DockStartStyleComboBox";
			DockStartStyleComboBox.PropertyName = "DockStartStyle";
			DockStartStyleComboBox.Size = new Size(104, 21);
			DockStartStyleComboBox.TabIndex = 1;
			focusLabel8.LoadingBegin();
			focusLabel8.FocusControl = DockStartStyleComboBox;
			focusLabel8.Location = new Point(176, 18);
			focusLabel8.Name = "focusLabel8";
			focusLabel8.Size = new Size(32, 15);
			focusLabel8.Text = "Style";
			focusLabel8.LoadingEnd();
			DockPercentStartTextBox.LoadingBegin();
			DockPercentStartTextBox.Location = new Point(56, 16);
			DockPercentStartTextBox.Name = "DockPercentStartTextBox";
			DockPercentStartTextBox.PropertyName = "DockPercentStart";
			DockPercentStartTextBox.Size = new Size(112, 20);
			DockPercentStartTextBox.TabIndex = 0;
			DockPercentStartTextBox.LoadingEnd();
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = DockPercentStartTextBox;
			focusLabel4.Location = new Point(11, 18);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(45, 15);
			focusLabel4.Text = "Percent";
			focusLabel4.LoadingEnd();
			DockStackingEndsMarginEditBox.LoadingBegin();
			DockStackingEndsMarginEditBox.Location = new Point(144, 48);
			DockStackingEndsMarginEditBox.Name = "DockStackingEndsMarginEditBox";
			DockStackingEndsMarginEditBox.PropertyName = "DockStackingEndsMargin";
			DockStackingEndsMarginEditBox.Size = new Size(56, 20);
			DockStackingEndsMarginEditBox.TabIndex = 1;
			DockStackingEndsMarginEditBox.LoadingEnd();
			focusLabel7.LoadingBegin();
			focusLabel7.FocusControl = DockStackingEndsMarginEditBox;
			focusLabel7.Location = new Point(30, 50);
			focusLabel7.Name = "focusLabel7";
			focusLabel7.Size = new Size(114, 15);
			focusLabel7.Text = "Stacking Ends Margin";
			focusLabel7.LoadingEnd();
			DockForceStackingCheckBox.Location = new Point(232, 48);
			DockForceStackingCheckBox.Name = "DockForceStackingCheckBox";
			DockForceStackingCheckBox.PropertyName = "DockForceStacking";
			DockForceStackingCheckBox.Size = new Size(112, 24);
			DockForceStackingCheckBox.TabIndex = 2;
			DockForceStackingCheckBox.Text = "Force Stacking";
			base.Controls.Add(DockForceStackingCheckBox);
			base.Controls.Add(DockStackingEndsMarginEditBox);
			base.Controls.Add(focusLabel7);
			base.Controls.Add(StopGroupBox);
			base.Controls.Add(StartGroupBox);
			base.Controls.Add(DockMarginUpDown);
			base.Controls.Add(focusLabel6);
			base.Controls.Add(DockStyleComboBox);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(DockDataViewNameTextBox);
			base.Controls.Add(focusLabel3);
			base.Controls.Add(DockSideComboBox);
			base.Controls.Add(label2);
			base.Controls.Add(DockOrderTextBox);
			base.Controls.Add(focusLabel1);
			base.Location = new Point(10, 20);
			base.Name = "PlotLayoutAxisEditorPlugIn";
			base.Size = new Size(824, 320);
			((ISupportInitialize)DockMarginUpDown).EndInit();
			StopGroupBox.ResumeLayout(false);
			StartGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
