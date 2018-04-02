using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ScaleDisplayDiscreetLinearEditorPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DirectionComboBox;

		private FocusLabel label5;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginNumericUpDown;

		private GroupBox groupBox1;

		private FocusLabel label3;

		private FontButton TextInactiveFontButton;

		private GroupBox groupBox2;

		private FocusLabel label4;

		private FontButton TextActiveFontButton;

		private Iocomp.Design.Plugin.EditorControls.ComboBox TextAlignmentComboBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown TextMarginNumericUpDown;

		private ColorPicker TextInactiveForeColorPicker;

		private ColorPicker TextActiveForeColorPicker;

		private Container components;

		public ScaleDisplayDiscreetLinearEditorPlugIn()
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
			label2 = new FocusLabel();
			DirectionComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label5 = new FocusLabel();
			MarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			groupBox1 = new GroupBox();
			label3 = new FocusLabel();
			TextInactiveForeColorPicker = new ColorPicker();
			TextInactiveFontButton = new FontButton();
			groupBox2 = new GroupBox();
			label4 = new FocusLabel();
			TextActiveForeColorPicker = new ColorPicker();
			TextActiveFontButton = new FontButton();
			TextAlignmentComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			label8 = new FocusLabel();
			TextMarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			((ISupportInitialize)MarginNumericUpDown).BeginInit();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			((ISupportInitialize)TextMarginNumericUpDown).BeginInit();
			base.SuspendLayout();
			label2.LoadingBegin();
			label2.FocusControl = DirectionComboBox;
			label2.Location = new Point(45, 74);
			label2.Name = "label2";
			label2.Size = new Size(51, 15);
			label2.Text = "Direction";
			label2.LoadingEnd();
			DirectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			DirectionComboBox.Location = new Point(96, 72);
			DirectionComboBox.Name = "DirectionComboBox";
			DirectionComboBox.PropertyName = "Direction";
			DirectionComboBox.Size = new Size(121, 21);
			DirectionComboBox.TabIndex = 2;
			label5.LoadingBegin();
			label5.FocusControl = MarginNumericUpDown;
			label5.Location = new Point(55, 105);
			label5.Name = "label5";
			label5.Size = new Size(41, 15);
			label5.Text = "Margin";
			label5.LoadingEnd();
			MarginNumericUpDown.Location = new Point(96, 104);
			MarginNumericUpDown.Maximum = new decimal(new int[4]
			{
				0,
				0,
				-2147483648,
				0
			});
			MarginNumericUpDown.Minimum = new decimal(new int[4]
			{
				2,
				0,
				0,
				0
			});
			MarginNumericUpDown.Name = "MarginNumericUpDown";
			MarginNumericUpDown.PropertyName = "Margin";
			MarginNumericUpDown.Size = new Size(48, 20);
			MarginNumericUpDown.TabIndex = 3;
			MarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(TextInactiveForeColorPicker);
			groupBox1.Controls.Add(TextInactiveFontButton);
			groupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			groupBox1.Location = new Point(232, 96);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(224, 80);
			groupBox1.TabIndex = 5;
			groupBox1.TabStop = false;
			groupBox1.Text = "Text Inactive";
			label3.LoadingBegin();
			label3.FocusControl = TextInactiveForeColorPicker;
			label3.Location = new Point(16, 51);
			label3.Name = "label3";
			label3.Size = new Size(56, 15);
			label3.Text = "ForeColor";
			label3.LoadingEnd();
			TextInactiveForeColorPicker.Location = new Point(72, 48);
			TextInactiveForeColorPicker.Name = "TextInactiveForeColorPicker";
			TextInactiveForeColorPicker.PropertyName = "TextInactiveForeColor";
			TextInactiveForeColorPicker.Size = new Size(144, 21);
			TextInactiveForeColorPicker.TabIndex = 1;
			TextInactiveFontButton.Location = new Point(72, 16);
			TextInactiveFontButton.Name = "TextInactiveFontButton";
			TextInactiveFontButton.PropertyName = "TextInactiveFont";
			TextInactiveFontButton.Size = new Size(72, 23);
			TextInactiveFontButton.TabIndex = 0;
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(TextActiveForeColorPicker);
			groupBox2.Controls.Add(TextActiveFontButton);
			groupBox2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			groupBox2.Location = new Point(232, 8);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(224, 80);
			groupBox2.TabIndex = 4;
			groupBox2.TabStop = false;
			groupBox2.Text = "Text Active";
			label4.LoadingBegin();
			label4.FocusControl = TextActiveForeColorPicker;
			label4.Location = new Point(16, 51);
			label4.Name = "label4";
			label4.Size = new Size(56, 15);
			label4.Text = "ForeColor";
			label4.LoadingEnd();
			TextActiveForeColorPicker.Location = new Point(72, 48);
			TextActiveForeColorPicker.Name = "TextActiveForeColorPicker";
			TextActiveForeColorPicker.PropertyName = "TextActiveForeColor";
			TextActiveForeColorPicker.Size = new Size(144, 21);
			TextActiveForeColorPicker.TabIndex = 1;
			TextActiveFontButton.Location = new Point(72, 16);
			TextActiveFontButton.Name = "TextActiveFontButton";
			TextActiveFontButton.PropertyName = "TextActiveFont";
			TextActiveFontButton.Size = new Size(72, 23);
			TextActiveFontButton.TabIndex = 0;
			TextAlignmentComboBox.Location = new Point(0, 0);
			TextAlignmentComboBox.Name = "TextAlignmentComboBox";
			TextAlignmentComboBox.TabIndex = 0;
			VisibleCheckBox.Location = new Point(96, 8);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(62, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visble";
			label8.LoadingBegin();
			label8.FocusControl = TextMarginNumericUpDown;
			label8.Location = new Point(30, 41);
			label8.Name = "label8";
			label8.Size = new Size(66, 15);
			label8.Text = "Text Margin";
			label8.LoadingEnd();
			TextMarginNumericUpDown.Location = new Point(96, 40);
			TextMarginNumericUpDown.Name = "TextMarginNumericUpDown";
			TextMarginNumericUpDown.PropertyName = "TextMargin";
			TextMarginNumericUpDown.Size = new Size(48, 20);
			TextMarginNumericUpDown.TabIndex = 1;
			TextMarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			base.Controls.Add(label8);
			base.Controls.Add(TextMarginNumericUpDown);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(label5);
			base.Controls.Add(MarginNumericUpDown);
			base.Controls.Add(groupBox1);
			base.Controls.Add(groupBox2);
			base.Controls.Add(DirectionComboBox);
			base.Controls.Add(label2);
			base.Name = "ScaleDisplayDiscreetLinearEditorPlugIn";
			base.Size = new Size(488, 200);
			base.Title = "Scale Display Editor";
			((ISupportInitialize)MarginNumericUpDown).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			((ISupportInitialize)TextMarginNumericUpDown).EndInit();
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new ScaleDiscreetMarkerEditorPlugIn(), "Markers", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as ScaleDisplayDiscreetLinear).Markers;
		}
	}
}
