using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class BorderControlEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginNumericUpDown;

		private FocusLabel label3;

		private FocusLabel label4;

		private ColorPicker ColorPicker;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private GroupBox groupBox1;

		private FocusLabel label5;

		private FocusLabel label6;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown ThicknessDesiredNumericUpDown;

		private EditBox ThicknessActualTextBox;

		private Container components;

		public BorderControlEditorPlugIn()
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
			MarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label3 = new FocusLabel();
			label4 = new FocusLabel();
			ColorPicker = new ColorPicker();
			StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label2 = new FocusLabel();
			groupBox1 = new GroupBox();
			ThicknessActualTextBox = new EditBox();
			label5 = new FocusLabel();
			ThicknessDesiredNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label6 = new FocusLabel();
			groupBox1.SuspendLayout();
			base.SuspendLayout();
			MarginNumericUpDown.Location = new Point(88, 42);
			MarginNumericUpDown.Maximum = new decimal(new int[4]
			{
				0,
				0,
				-2147483648,
				0
			});
			MarginNumericUpDown.Name = "MarginNumericUpDown";
			MarginNumericUpDown.PropertyName = "Margin";
			MarginNumericUpDown.Size = new Size(48, 20);
			MarginNumericUpDown.TabIndex = 1;
			MarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label3.LoadingBegin();
			label3.FocusControl = MarginNumericUpDown;
			label3.Location = new Point(47, 43);
			label3.Name = "label3";
			label3.Size = new Size(41, 15);
			label3.Text = "Margin";
			label3.LoadingEnd();
			label4.LoadingBegin();
			label4.FocusControl = ColorPicker;
			label4.Location = new Point(14, 83);
			label4.Name = "label4";
			label4.Size = new Size(34, 15);
			label4.Text = "Color";
			label4.LoadingEnd();
			ColorPicker.Location = new Point(48, 80);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(144, 21);
			ColorPicker.TabIndex = 2;
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(48, 8);
			StyleComboBox.MaxDropDownItems = 20;
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(144, 21);
			StyleComboBox.TabIndex = 0;
			label2.LoadingBegin();
			label2.FocusControl = StyleComboBox;
			label2.Location = new Point(16, 10);
			label2.Name = "label2";
			label2.Size = new Size(32, 15);
			label2.Text = "Style";
			label2.LoadingEnd();
			groupBox1.Controls.Add(ThicknessActualTextBox);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(ThicknessDesiredNumericUpDown);
			groupBox1.Controls.Add(label6);
			groupBox1.Location = new Point(232, 2);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(128, 78);
			groupBox1.TabIndex = 3;
			groupBox1.TabStop = false;
			groupBox1.Text = "Thickness";
			ThicknessActualTextBox.LoadingBegin();
			ThicknessActualTextBox.Location = new Point(64, 48);
			ThicknessActualTextBox.Name = "ThicknessActualTextBox";
			ThicknessActualTextBox.PropertyName = "ThicknessActual";
			ThicknessActualTextBox.ReadOnly = true;
			ThicknessActualTextBox.Size = new Size(32, 20);
			ThicknessActualTextBox.TabIndex = 1;
			ThicknessActualTextBox.TextAlign = HorizontalAlignment.Center;
			ThicknessActualTextBox.LoadingEnd();
			label5.LoadingBegin();
			label5.FocusControl = ThicknessActualTextBox;
			label5.Location = new Point(26, 50);
			label5.Name = "label5";
			label5.Size = new Size(38, 15);
			label5.Text = "Actual";
			label5.LoadingEnd();
			ThicknessDesiredNumericUpDown.Location = new Point(64, 24);
			ThicknessDesiredNumericUpDown.Minimum = new decimal(new int[4]
			{
				2,
				0,
				0,
				0
			});
			ThicknessDesiredNumericUpDown.Name = "ThicknessDesiredNumericUpDown";
			ThicknessDesiredNumericUpDown.PropertyName = "ThicknessDesired";
			ThicknessDesiredNumericUpDown.Size = new Size(48, 20);
			ThicknessDesiredNumericUpDown.TabIndex = 0;
			ThicknessDesiredNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label6.LoadingBegin();
			label6.FocusControl = ThicknessDesiredNumericUpDown;
			label6.Location = new Point(19, 25);
			label6.Name = "label6";
			label6.Size = new Size(45, 15);
			label6.Text = "Desired";
			label6.LoadingEnd();
			base.Controls.Add(groupBox1);
			base.Controls.Add(StyleComboBox);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label4);
			base.Controls.Add(MarginNumericUpDown);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Name = "BorderControlEditorPlugIn";
			base.Size = new Size(384, 120);
			base.Title = "Border Editor";
			groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
