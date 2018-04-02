using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ScaleDisplayDiscreetAngularEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private GroupBox groupBox2;

		private FocusLabel label4;

		private FontButton TextActiveFontButton;

		private GroupBox groupBox1;

		private FocusLabel label3;

		private FontButton TextInactiveFontButton;

		private FocusLabel label5;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginNumericUpDown;

		private GroupBox groupBox3;

		private FocusLabel label2;

		private Iocomp.Design.Plugin.EditorControls.ComboBox TextAlignmentComboBox;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown TextMarginNumericUpDown;

		private FocusLabel label6;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown CallOutLengthNumericUpDown;

		private ColorPicker TextActiveForeColorPicker;

		private ColorPicker TextInactiveForeColorPicker;

		private Container components;

		public ScaleDisplayDiscreetAngularEditorPlugIn()
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
			label4 = new FocusLabel();
			TextActiveForeColorPicker = new ColorPicker();
			TextActiveFontButton = new FontButton();
			groupBox1 = new GroupBox();
			label3 = new FocusLabel();
			TextInactiveForeColorPicker = new ColorPicker();
			TextInactiveFontButton = new FontButton();
			label5 = new FocusLabel();
			MarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			groupBox3 = new GroupBox();
			TextMarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label1 = new FocusLabel();
			TextAlignmentComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label2 = new FocusLabel();
			label6 = new FocusLabel();
			CallOutLengthNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			groupBox3.SuspendLayout();
			base.SuspendLayout();
			VisibleCheckBox.Location = new Point(24, 16);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(TextActiveForeColorPicker);
			groupBox2.Controls.Add(TextActiveFontButton);
			groupBox2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			groupBox2.Location = new Point(240, 16);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(224, 91);
			groupBox2.TabIndex = 4;
			groupBox2.TabStop = false;
			groupBox2.Text = "Text Active";
			label4.LoadingBegin();
			label4.FocusControl = TextActiveForeColorPicker;
			label4.Location = new Point(13, 51);
			label4.Name = "label4";
			label4.Size = new Size(59, 15);
			label4.Text = "Fore Color";
			label4.LoadingEnd();
			TextActiveForeColorPicker.Location = new Point(72, 48);
			TextActiveForeColorPicker.Name = "TextActiveForeColorPicker";
			TextActiveForeColorPicker.PropertyName = "TextActiveForeColor";
			TextActiveForeColorPicker.Size = new Size(144, 21);
			TextActiveForeColorPicker.TabIndex = 1;
			TextActiveFontButton.Location = new Point(72, 16);
			TextActiveFontButton.Name = "TextActiveFontButton";
			TextActiveFontButton.PropertyName = "TextActiveFont";
			TextActiveFontButton.TabIndex = 0;
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(TextInactiveForeColorPicker);
			groupBox1.Controls.Add(TextInactiveFontButton);
			groupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			groupBox1.Location = new Point(240, 120);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(224, 80);
			groupBox1.TabIndex = 5;
			groupBox1.TabStop = false;
			groupBox1.Text = "Text Inactive";
			label3.LoadingBegin();
			label3.FocusControl = TextInactiveForeColorPicker;
			label3.Location = new Point(13, 51);
			label3.Name = "label3";
			label3.Size = new Size(59, 15);
			label3.Text = "Fore Color";
			label3.LoadingEnd();
			TextInactiveForeColorPicker.Location = new Point(72, 48);
			TextInactiveForeColorPicker.Name = "TextInactiveForeColorPicker";
			TextInactiveForeColorPicker.PropertyName = "TextInactiveForeColor";
			TextInactiveForeColorPicker.Size = new Size(144, 21);
			TextInactiveForeColorPicker.TabIndex = 1;
			TextInactiveFontButton.Location = new Point(72, 16);
			TextInactiveFontButton.Name = "TextInactiveFontButton";
			TextInactiveFontButton.PropertyName = "TextInactiveFont";
			TextInactiveFontButton.TabIndex = 0;
			label5.LoadingBegin();
			label5.FocusControl = MarginNumericUpDown;
			label5.Location = new Point(63, 73);
			label5.Name = "label5";
			label5.Size = new Size(41, 15);
			label5.Text = "Margin";
			label5.LoadingEnd();
			MarginNumericUpDown.Location = new Point(104, 72);
			MarginNumericUpDown.Name = "MarginNumericUpDown";
			MarginNumericUpDown.PropertyName = "Margin";
			MarginNumericUpDown.Size = new Size(48, 20);
			MarginNumericUpDown.TabIndex = 2;
			MarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			groupBox3.Controls.Add(TextMarginNumericUpDown);
			groupBox3.Controls.Add(label1);
			groupBox3.Controls.Add(TextAlignmentComboBox);
			groupBox3.Controls.Add(label2);
			groupBox3.Location = new Point(24, 120);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(208, 80);
			groupBox3.TabIndex = 3;
			groupBox3.TabStop = false;
			groupBox3.Text = "Text";
			TextMarginNumericUpDown.Location = new Point(72, 40);
			TextMarginNumericUpDown.Name = "TextMarginNumericUpDown";
			TextMarginNumericUpDown.PropertyName = "TextMargin";
			TextMarginNumericUpDown.Size = new Size(48, 20);
			TextMarginNumericUpDown.TabIndex = 1;
			TextMarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label1.LoadingBegin();
			label1.FocusControl = TextMarginNumericUpDown;
			label1.Location = new Point(31, 41);
			label1.Name = "label1";
			label1.Size = new Size(41, 15);
			label1.Text = "Margin";
			label1.LoadingEnd();
			TextAlignmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			TextAlignmentComboBox.Location = new Point(72, 16);
			TextAlignmentComboBox.Name = "TextAlignmentComboBox";
			TextAlignmentComboBox.PropertyName = "TextAlignment";
			TextAlignmentComboBox.Size = new Size(121, 21);
			TextAlignmentComboBox.TabIndex = 0;
			label2.LoadingBegin();
			label2.FocusControl = TextAlignmentComboBox;
			label2.Location = new Point(15, 18);
			label2.Name = "label2";
			label2.Size = new Size(57, 15);
			label2.Text = "Alignment";
			label2.LoadingEnd();
			label6.LoadingBegin();
			label6.FocusControl = CallOutLengthNumericUpDown;
			label6.Location = new Point(20, 49);
			label6.Name = "label6";
			label6.Size = new Size(84, 15);
			label6.Text = "Call Out Length";
			label6.LoadingEnd();
			CallOutLengthNumericUpDown.Location = new Point(104, 48);
			CallOutLengthNumericUpDown.Name = "CallOutLengthNumericUpDown";
			CallOutLengthNumericUpDown.PropertyName = "CallOutLength";
			CallOutLengthNumericUpDown.Size = new Size(48, 20);
			CallOutLengthNumericUpDown.TabIndex = 1;
			CallOutLengthNumericUpDown.TextAlign = HorizontalAlignment.Center;
			base.Controls.Add(label6);
			base.Controls.Add(CallOutLengthNumericUpDown);
			base.Controls.Add(label5);
			base.Controls.Add(MarginNumericUpDown);
			base.Controls.Add(groupBox1);
			base.Controls.Add(groupBox2);
			base.Controls.Add(groupBox3);
			base.Controls.Add(VisibleCheckBox);
			base.Name = "ScaleDisplayDiscreetAngularEditorPlugIn";
			base.Size = new Size(512, 248);
			base.Title = "Scale Display Editor";
			groupBox2.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new ScaleDiscreetMarkerEditorPlugIn(), "Markers", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as ScaleDisplayDiscreetAngular).Markers;
		}
	}
}
