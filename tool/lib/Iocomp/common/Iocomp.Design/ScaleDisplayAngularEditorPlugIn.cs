using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class ScaleDisplayAngularEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private GroupBox groupBox2;

		private FocusLabel label5;

		private EditBox TextWidthMinValueTextBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox TextWidthMinAutoCheckBox;

		private GroupBox groupBox1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox StartRefEnabledCheckBox;

		private FocusLabel label8;

		private EditBox StartRefValueTextBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox TextAlignmentComboBox;

		private FocusLabel label2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LineInnerVisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LineOuterVisibleCheckBox;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginNumericUpDown;

		private FocusLabel focusLabel1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LineThicknessUpDown;

		private Container components;

		public ScaleDisplayAngularEditorPlugIn()
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
			groupBox2 = new GroupBox();
			TextAlignmentComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label2 = new FocusLabel();
			TextWidthMinAutoCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			label5 = new FocusLabel();
			TextWidthMinValueTextBox = new EditBox();
			groupBox1 = new GroupBox();
			StartRefEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			StartRefValueTextBox = new EditBox();
			label8 = new FocusLabel();
			LineInnerVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LineOuterVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			label1 = new FocusLabel();
			MarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			focusLabel1 = new FocusLabel();
			LineThicknessUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			((ISupportInitialize)MarginNumericUpDown).BeginInit();
			((ISupportInitialize)LineThicknessUpDown).BeginInit();
			base.SuspendLayout();
			VisibleCheckBox.Location = new Point(24, 8);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(64, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			groupBox2.Controls.Add(TextAlignmentComboBox);
			groupBox2.Controls.Add(label2);
			groupBox2.Controls.Add(TextWidthMinAutoCheckBox);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(TextWidthMinValueTextBox);
			groupBox2.Location = new Point(240, 0);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(256, 88);
			groupBox2.TabIndex = 5;
			groupBox2.TabStop = false;
			groupBox2.Text = "Text";
			TextAlignmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			TextAlignmentComboBox.Location = new Point(104, 24);
			TextAlignmentComboBox.Name = "TextAlignmentComboBox";
			TextAlignmentComboBox.PropertyName = "TextAlignment";
			TextAlignmentComboBox.Size = new Size(121, 21);
			TextAlignmentComboBox.TabIndex = 0;
			label2.LoadingBegin();
			label2.FocusControl = TextAlignmentComboBox;
			label2.Location = new Point(47, 26);
			label2.Name = "label2";
			label2.Size = new Size(57, 15);
			label2.Text = "Alignment";
			label2.LoadingEnd();
			TextWidthMinAutoCheckBox.Location = new Point(144, 56);
			TextWidthMinAutoCheckBox.Name = "TextWidthMinAutoCheckBox";
			TextWidthMinAutoCheckBox.PropertyName = "TextWidthMinAuto";
			TextWidthMinAutoCheckBox.TabIndex = 2;
			TextWidthMinAutoCheckBox.Text = "Width Min Auto";
			label5.LoadingBegin();
			label5.FocusControl = TextWidthMinValueTextBox;
			label5.Location = new Point(16, 58);
			label5.Name = "label5";
			label5.Size = new Size(88, 15);
			label5.Text = "Width Min Value";
			label5.LoadingEnd();
			TextWidthMinValueTextBox.LoadingBegin();
			TextWidthMinValueTextBox.Location = new Point(104, 56);
			TextWidthMinValueTextBox.Name = "TextWidthMinValueTextBox";
			TextWidthMinValueTextBox.PropertyName = "TextWidthMinValue";
			TextWidthMinValueTextBox.Size = new Size(32, 20);
			TextWidthMinValueTextBox.TabIndex = 1;
			TextWidthMinValueTextBox.LoadingEnd();
			groupBox1.Controls.Add(StartRefEnabledCheckBox);
			groupBox1.Controls.Add(StartRefValueTextBox);
			groupBox1.Controls.Add(label8);
			groupBox1.Location = new Point(240, 96);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(256, 56);
			groupBox1.TabIndex = 6;
			groupBox1.TabStop = false;
			groupBox1.Text = "Start Ref";
			StartRefEnabledCheckBox.Location = new Point(144, 20);
			StartRefEnabledCheckBox.Name = "StartRefEnabledCheckBox";
			StartRefEnabledCheckBox.PropertyName = "StartRefEnabled";
			StartRefEnabledCheckBox.Size = new Size(72, 24);
			StartRefEnabledCheckBox.TabIndex = 1;
			StartRefEnabledCheckBox.Text = "Enabled";
			StartRefValueTextBox.LoadingBegin();
			StartRefValueTextBox.Location = new Point(64, 20);
			StartRefValueTextBox.Name = "StartRefValueTextBox";
			StartRefValueTextBox.PropertyName = "StartRefValue";
			StartRefValueTextBox.Size = new Size(72, 20);
			StartRefValueTextBox.TabIndex = 0;
			StartRefValueTextBox.LoadingEnd();
			label8.LoadingBegin();
			label8.FocusControl = StartRefValueTextBox;
			label8.Location = new Point(28, 22);
			label8.Name = "label8";
			label8.Size = new Size(36, 15);
			label8.Text = "Value";
			label8.LoadingEnd();
			LineInnerVisibleCheckBox.Location = new Point(24, 32);
			LineInnerVisibleCheckBox.Name = "LineInnerVisibleCheckBox";
			LineInnerVisibleCheckBox.PropertyName = "LineInnerVisible";
			LineInnerVisibleCheckBox.Size = new Size(128, 24);
			LineInnerVisibleCheckBox.TabIndex = 1;
			LineInnerVisibleCheckBox.Text = "Line Inner Visible";
			LineOuterVisibleCheckBox.Location = new Point(24, 56);
			LineOuterVisibleCheckBox.Name = "LineOuterVisibleCheckBox";
			LineOuterVisibleCheckBox.PropertyName = "LineOuterVisible";
			LineOuterVisibleCheckBox.Size = new Size(128, 24);
			LineOuterVisibleCheckBox.TabIndex = 2;
			LineOuterVisibleCheckBox.Text = "Line Outer Visible";
			label1.LoadingBegin();
			label1.FocusControl = MarginNumericUpDown;
			label1.Location = new Point(63, 121);
			label1.Name = "label1";
			label1.Size = new Size(41, 15);
			label1.Text = "Margin";
			label1.LoadingEnd();
			MarginNumericUpDown.Location = new Point(104, 120);
			MarginNumericUpDown.Name = "MarginNumericUpDown";
			MarginNumericUpDown.PropertyName = "Margin";
			MarginNumericUpDown.Size = new Size(48, 20);
			MarginNumericUpDown.TabIndex = 4;
			MarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = LineThicknessUpDown;
			focusLabel1.Location = new Point(24, 89);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(80, 15);
			focusLabel1.Text = "Line Thickness";
			focusLabel1.LoadingEnd();
			LineThicknessUpDown.Location = new Point(104, 88);
			LineThicknessUpDown.Name = "LineThicknessUpDown";
			LineThicknessUpDown.PropertyName = "LineThickness";
			LineThicknessUpDown.Size = new Size(48, 20);
			LineThicknessUpDown.TabIndex = 3;
			LineThicknessUpDown.TextAlign = HorizontalAlignment.Center;
			base.Controls.Add(focusLabel1);
			base.Controls.Add(LineThicknessUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(MarginNumericUpDown);
			base.Controls.Add(LineOuterVisibleCheckBox);
			base.Controls.Add(LineInnerVisibleCheckBox);
			base.Controls.Add(groupBox1);
			base.Controls.Add(groupBox2);
			base.Controls.Add(VisibleCheckBox);
			base.Name = "ScaleDisplayAngularEditorPlugIn";
			base.Size = new Size(536, 192);
			base.Title = "Scale Display Editor";
			groupBox2.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			((ISupportInitialize)MarginNumericUpDown).EndInit();
			((ISupportInitialize)LineThicknessUpDown).EndInit();
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new ScaleDisplayGeneratorEditorPlugIn(), "Generator", false);
			base.AddSubPlugIn(new TextFormatDoubleAllEditorPlugIn(), "Text Formatting", false);
			base.AddSubPlugIn(new ScaleTickMajorEditorPlugIn(), "Tick-Major", false);
			base.AddSubPlugIn(new ScaleTickMinorEditorPlugIn(), "Tick-Minor", false);
			base.AddSubPlugIn(new ScaleTickMidEditorPlugIn(), "Tick-Mid", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as ScaleDisplayAngular);
			base.SubPlugIns[1].Value = (base.Value as ScaleDisplayAngular).TextFormatting;
			base.SubPlugIns[2].Value = (base.Value as ScaleDisplayAngular).TickMajor;
			base.SubPlugIns[3].Value = (base.Value as ScaleDisplayAngular).TickMinor;
			base.SubPlugIns[4].Value = (base.Value as ScaleDisplayAngular).TickMid;
		}
	}
}
