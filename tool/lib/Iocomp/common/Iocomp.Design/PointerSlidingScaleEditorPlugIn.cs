using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PointerSlidingScaleEditorPlugIn : PlugInStandard
	{
		private FocusLabel label4;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private FocusLabel label6;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown SizeNumericUpDown;

		private FocusLabel label2;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LineWidthNumericUpDown;

		private FocusLabel label9;

		private ColorPicker ColorPicker;

		private ColorPicker LineColorPicker;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private Container components;

		public PointerSlidingScaleEditorPlugIn()
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
			ColorPicker = new ColorPicker();
			label4 = new FocusLabel();
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label6 = new FocusLabel();
			SizeNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label2 = new FocusLabel();
			LineColorPicker = new ColorPicker();
			label1 = new FocusLabel();
			LineWidthNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label9 = new FocusLabel();
			NameTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			base.SuspendLayout();
			ColorPicker.Location = new Point(72, 192);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(144, 21);
			ColorPicker.TabIndex = 6;
			label4.LoadingBegin();
			label4.FocusControl = ColorPicker;
			label4.Location = new Point(38, 195);
			label4.Name = "label4";
			label4.Size = new Size(34, 15);
			label4.Text = "Color";
			label4.LoadingEnd();
			VisibleCheckBox.Location = new Point(72, 16);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(72, 80);
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(121, 21);
			StyleComboBox.TabIndex = 2;
			label6.LoadingBegin();
			label6.FocusControl = StyleComboBox;
			label6.Location = new Point(40, 82);
			label6.Name = "label6";
			label6.Size = new Size(32, 15);
			label6.Text = "Style";
			label6.LoadingEnd();
			SizeNumericUpDown.Location = new Point(72, 112);
			SizeNumericUpDown.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				-2147483648
			});
			SizeNumericUpDown.Name = "SizeNumericUpDown";
			SizeNumericUpDown.PropertyName = "Size";
			SizeNumericUpDown.Size = new Size(48, 20);
			SizeNumericUpDown.TabIndex = 3;
			SizeNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label2.LoadingBegin();
			label2.FocusControl = SizeNumericUpDown;
			label2.Location = new Point(43, 113);
			label2.Name = "label2";
			label2.Size = new Size(29, 15);
			label2.Text = "Size";
			label2.LoadingEnd();
			LineColorPicker.Location = new Point(72, 168);
			LineColorPicker.Name = "LineColorPicker";
			LineColorPicker.PropertyName = "LineColor";
			LineColorPicker.Size = new Size(144, 21);
			LineColorPicker.TabIndex = 5;
			label1.LoadingBegin();
			label1.FocusControl = LineColorPicker;
			label1.Location = new Point(14, 171);
			label1.Name = "label1";
			label1.Size = new Size(58, 15);
			label1.Text = "Line Color";
			label1.LoadingEnd();
			LineWidthNumericUpDown.Location = new Point(72, 136);
			LineWidthNumericUpDown.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				-2147483648
			});
			LineWidthNumericUpDown.Name = "LineWidthNumericUpDown";
			LineWidthNumericUpDown.PropertyName = "LineWidth";
			LineWidthNumericUpDown.Size = new Size(48, 20);
			LineWidthNumericUpDown.TabIndex = 4;
			LineWidthNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label9.LoadingBegin();
			label9.FocusControl = LineWidthNumericUpDown;
			label9.Location = new Point(13, 137);
			label9.Name = "label9";
			label9.Size = new Size(59, 15);
			label9.Text = "Line Width";
			label9.LoadingEnd();
			NameTextBox.LoadingBegin();
			NameTextBox.Location = new Point(72, 48);
			NameTextBox.Name = "NameTextBox";
			NameTextBox.PropertyName = "Value";
			NameTextBox.Size = new Size(136, 20);
			NameTextBox.TabIndex = 1;
			NameTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = NameTextBox;
			focusLabel1.Location = new Point(36, 50);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(36, 15);
			focusLabel1.Text = "Value";
			focusLabel1.LoadingEnd();
			base.Controls.Add(NameTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(LineWidthNumericUpDown);
			base.Controls.Add(label9);
			base.Controls.Add(LineColorPicker);
			base.Controls.Add(label1);
			base.Controls.Add(SizeNumericUpDown);
			base.Controls.Add(label2);
			base.Controls.Add(StyleComboBox);
			base.Controls.Add(label6);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label4);
			base.Name = "PointerSlidingScaleEditorPlugIn";
			base.Size = new Size(248, 256);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new ValueDoubleEditorPlugIn(), "Value", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PointerSlidingScale).Value;
		}
	}
}
