using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ScaleDisplayLinearEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox AntiAliasCheckBox;

		private GroupBox groupBox1;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox StartRefEnabledCheckBox;

		private EditBox StartRefValueTextBox;

		private GroupBox groupBox5;

		private Iocomp.Design.Plugin.EditorControls.ComboBox TextAlignmentComboBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox TextRotationComboBox;

		private FocusLabel label10;

		private FocusLabel label11;

		private FocusLabel label12;

		private Iocomp.Design.Plugin.EditorControls.CheckBox TextWidthMinAutoCheckBox;

		private EditBox TextWidthMinValueTextBox;

		private FocusLabel label5;

		private FocusLabel label2;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DirectionComboBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LineOuterVisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LineInnerVisibleCheckBox;

		private FocusLabel focusLabel1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LineThicknessUpDown;

		private Container components;

		public ScaleDisplayLinearEditorPlugIn()
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
			AntiAliasCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			groupBox1 = new GroupBox();
			StartRefValueTextBox = new EditBox();
			StartRefEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			label8 = new FocusLabel();
			groupBox5 = new GroupBox();
			label12 = new FocusLabel();
			TextWidthMinValueTextBox = new EditBox();
			TextWidthMinAutoCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			TextAlignmentComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			TextRotationComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label10 = new FocusLabel();
			label11 = new FocusLabel();
			label5 = new FocusLabel();
			MarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label2 = new FocusLabel();
			DirectionComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			LineOuterVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LineInnerVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			focusLabel1 = new FocusLabel();
			LineThicknessUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			groupBox1.SuspendLayout();
			groupBox5.SuspendLayout();
			((ISupportInitialize)MarginNumericUpDown).BeginInit();
			((ISupportInitialize)LineThicknessUpDown).BeginInit();
			base.SuspendLayout();
			VisibleCheckBox.Location = new Point(16, 20);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.TabIndex = 1;
			VisibleCheckBox.Text = "Visible";
			AntiAliasCheckBox.Location = new Point(16, 0);
			AntiAliasCheckBox.Name = "AntiAliasCheckBox";
			AntiAliasCheckBox.PropertyName = "AntiAliasEnabled";
			AntiAliasCheckBox.Size = new Size(120, 24);
			AntiAliasCheckBox.TabIndex = 0;
			AntiAliasCheckBox.Text = "Anti Alias Enabled";
			groupBox1.Controls.Add(StartRefValueTextBox);
			groupBox1.Controls.Add(StartRefEnabledCheckBox);
			groupBox1.Controls.Add(label8);
			groupBox1.Location = new Point(232, 128);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(264, 64);
			groupBox1.TabIndex = 8;
			groupBox1.TabStop = false;
			groupBox1.Text = "Start Ref";
			StartRefValueTextBox.LoadingBegin();
			StartRefValueTextBox.Location = new Point(64, 28);
			StartRefValueTextBox.Name = "StartRefValueTextBox";
			StartRefValueTextBox.PropertyName = "StartRefValue";
			StartRefValueTextBox.Size = new Size(80, 20);
			StartRefValueTextBox.TabIndex = 0;
			StartRefValueTextBox.LoadingEnd();
			StartRefEnabledCheckBox.Location = new Point(152, 26);
			StartRefEnabledCheckBox.Name = "StartRefEnabledCheckBox";
			StartRefEnabledCheckBox.PropertyName = "StartRefEnabled";
			StartRefEnabledCheckBox.Size = new Size(72, 24);
			StartRefEnabledCheckBox.TabIndex = 1;
			StartRefEnabledCheckBox.Text = "Enabled";
			label8.LoadingBegin();
			label8.FocusControl = StartRefValueTextBox;
			label8.Location = new Point(28, 30);
			label8.Name = "label8";
			label8.Size = new Size(36, 15);
			label8.Text = "Value";
			label8.LoadingEnd();
			groupBox5.Controls.Add(label12);
			groupBox5.Controls.Add(TextWidthMinAutoCheckBox);
			groupBox5.Controls.Add(TextWidthMinValueTextBox);
			groupBox5.Controls.Add(TextAlignmentComboBox);
			groupBox5.Controls.Add(TextRotationComboBox);
			groupBox5.Controls.Add(label10);
			groupBox5.Controls.Add(label11);
			groupBox5.Location = new Point(232, 8);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new Size(264, 112);
			groupBox5.TabIndex = 7;
			groupBox5.TabStop = false;
			groupBox5.Text = "Text";
			label12.LoadingBegin();
			label12.FocusControl = TextWidthMinValueTextBox;
			label12.Location = new Point(8, 82);
			label12.Name = "label12";
			label12.Size = new Size(88, 15);
			label12.Text = "Width Min Value";
			label12.LoadingEnd();
			TextWidthMinValueTextBox.LoadingBegin();
			TextWidthMinValueTextBox.Location = new Point(96, 80);
			TextWidthMinValueTextBox.Name = "TextWidthMinValueTextBox";
			TextWidthMinValueTextBox.PropertyName = "TextWidthMinValue";
			TextWidthMinValueTextBox.Size = new Size(40, 20);
			TextWidthMinValueTextBox.TabIndex = 2;
			TextWidthMinValueTextBox.LoadingEnd();
			TextWidthMinAutoCheckBox.Location = new Point(152, 80);
			TextWidthMinAutoCheckBox.Name = "TextWidthMinAutoCheckBox";
			TextWidthMinAutoCheckBox.PropertyName = "TextWidthMinAuto";
			TextWidthMinAutoCheckBox.TabIndex = 3;
			TextWidthMinAutoCheckBox.Text = "Width Min Auto";
			TextAlignmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			TextAlignmentComboBox.Location = new Point(96, 24);
			TextAlignmentComboBox.Name = "TextAlignmentComboBox";
			TextAlignmentComboBox.PropertyName = "TextAlignment";
			TextAlignmentComboBox.Size = new Size(121, 21);
			TextAlignmentComboBox.TabIndex = 0;
			TextRotationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			TextRotationComboBox.Location = new Point(96, 48);
			TextRotationComboBox.Name = "TextRotationComboBox";
			TextRotationComboBox.PropertyName = "TextRotation";
			TextRotationComboBox.Size = new Size(121, 21);
			TextRotationComboBox.TabIndex = 1;
			label10.LoadingBegin();
			label10.FocusControl = TextAlignmentComboBox;
			label10.Location = new Point(39, 26);
			label10.Name = "label10";
			label10.Size = new Size(57, 15);
			label10.Text = "Alignment";
			label10.LoadingEnd();
			label11.LoadingBegin();
			label11.FocusControl = TextRotationComboBox;
			label11.Location = new Point(47, 50);
			label11.Name = "label11";
			label11.Size = new Size(49, 15);
			label11.Text = "Rotation";
			label11.LoadingEnd();
			label5.LoadingBegin();
			label5.FocusControl = MarginNumericUpDown;
			label5.Location = new Point(55, 161);
			label5.Name = "label5";
			label5.Size = new Size(41, 15);
			label5.Text = "Margin";
			label5.LoadingEnd();
			MarginNumericUpDown.Location = new Point(96, 160);
			MarginNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			MarginNumericUpDown.Minimum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				-2147483648
			});
			MarginNumericUpDown.Name = "MarginNumericUpDown";
			MarginNumericUpDown.PropertyName = "Margin";
			MarginNumericUpDown.Size = new Size(48, 20);
			MarginNumericUpDown.TabIndex = 6;
			MarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label2.LoadingBegin();
			label2.FocusControl = DirectionComboBox;
			label2.Location = new Point(45, 130);
			label2.Name = "label2";
			label2.Size = new Size(51, 15);
			label2.Text = "Direction";
			label2.LoadingEnd();
			DirectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			DirectionComboBox.Location = new Point(96, 128);
			DirectionComboBox.Name = "DirectionComboBox";
			DirectionComboBox.PropertyName = "Direction";
			DirectionComboBox.Size = new Size(121, 21);
			DirectionComboBox.TabIndex = 5;
			LineOuterVisibleCheckBox.Location = new Point(16, 60);
			LineOuterVisibleCheckBox.Name = "LineOuterVisibleCheckBox";
			LineOuterVisibleCheckBox.PropertyName = "LineOuterVisible";
			LineOuterVisibleCheckBox.Size = new Size(120, 24);
			LineOuterVisibleCheckBox.TabIndex = 3;
			LineOuterVisibleCheckBox.Text = "Line Outer Visible";
			LineInnerVisibleCheckBox.Location = new Point(16, 40);
			LineInnerVisibleCheckBox.Name = "LineInnerVisibleCheckBox";
			LineInnerVisibleCheckBox.PropertyName = "LineInnerVisible";
			LineInnerVisibleCheckBox.Size = new Size(112, 24);
			LineInnerVisibleCheckBox.TabIndex = 2;
			LineInnerVisibleCheckBox.Text = "Line Inner Visible";
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = LineThicknessUpDown;
			focusLabel1.Location = new Point(16, 97);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(80, 15);
			focusLabel1.Text = "Line Thickness";
			focusLabel1.LoadingEnd();
			LineThicknessUpDown.Location = new Point(96, 96);
			LineThicknessUpDown.Name = "LineThicknessUpDown";
			LineThicknessUpDown.PropertyName = "LineThickness";
			LineThicknessUpDown.Size = new Size(48, 20);
			LineThicknessUpDown.TabIndex = 4;
			LineThicknessUpDown.TextAlign = HorizontalAlignment.Center;
			base.Controls.Add(focusLabel1);
			base.Controls.Add(LineThicknessUpDown);
			base.Controls.Add(LineOuterVisibleCheckBox);
			base.Controls.Add(LineInnerVisibleCheckBox);
			base.Controls.Add(label5);
			base.Controls.Add(MarginNumericUpDown);
			base.Controls.Add(label2);
			base.Controls.Add(DirectionComboBox);
			base.Controls.Add(groupBox5);
			base.Controls.Add(groupBox1);
			base.Controls.Add(AntiAliasCheckBox);
			base.Controls.Add(VisibleCheckBox);
			base.Name = "ScaleDisplayLinearEditorPlugIn";
			base.Size = new Size(616, 216);
			base.Title = "Scale Display Editor";
			groupBox1.ResumeLayout(false);
			groupBox5.ResumeLayout(false);
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
			base.SubPlugIns[0].Value = (base.Value as ScaleDisplayLinear);
			base.SubPlugIns[1].Value = (base.Value as ScaleDisplayLinear).TextFormatting;
			base.SubPlugIns[2].Value = (base.Value as ScaleDisplayLinear).TickMajor;
			base.SubPlugIns[3].Value = (base.Value as ScaleDisplayLinear).TickMinor;
			base.SubPlugIns[4].Value = (base.Value as ScaleDisplayLinear).TickMid;
		}
	}
}
