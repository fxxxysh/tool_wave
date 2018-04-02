using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class BevelThickEditorPlugIn : PlugInStandard
	{
		private FocusLabel label3;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown ThicknessNumericUpDown;

		private FocusLabel label4;

		private EditBox ActualThicknessTextBox;

		private ColorPicker ColorPicker;

		private Container components;

		public BevelThickEditorPlugIn()
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
			label3 = new FocusLabel();
			ActualThicknessTextBox = new EditBox();
			StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label2 = new FocusLabel();
			label1 = new FocusLabel();
			ThicknessNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			ColorPicker = new ColorPicker();
			label4 = new FocusLabel();
			base.SuspendLayout();
			label3.LoadingBegin();
			label3.FocusControl = ActualThicknessTextBox;
			label3.Location = new Point(13, 82);
			label3.Name = "label3";
			label3.Size = new Size(91, 15);
			label3.Text = "Actual Thickness";
			label3.LoadingEnd();
			ActualThicknessTextBox.LoadingBegin();
			ActualThicknessTextBox.Location = new Point(104, 80);
			ActualThicknessTextBox.Name = "ActualThicknessTextBox";
			ActualThicknessTextBox.PropertyName = "ActualThickness";
			ActualThicknessTextBox.ReadOnly = true;
			ActualThicknessTextBox.Size = new Size(40, 20);
			ActualThicknessTextBox.TabIndex = 2;
			ActualThicknessTextBox.TextAlign = HorizontalAlignment.Center;
			ActualThicknessTextBox.LoadingEnd();
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(104, 32);
			StyleComboBox.MaxDropDownItems = 20;
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(144, 21);
			StyleComboBox.TabIndex = 0;
			label2.LoadingBegin();
			label2.FocusControl = StyleComboBox;
			label2.Location = new Point(72, 34);
			label2.Name = "label2";
			label2.Size = new Size(32, 15);
			label2.Text = "Style";
			label2.LoadingEnd();
			label1.LoadingBegin();
			label1.FocusControl = ThicknessNumericUpDown;
			label1.Location = new Point(47, 57);
			label1.Name = "label1";
			label1.Size = new Size(57, 15);
			label1.Text = "Thickness";
			label1.LoadingEnd();
			ThicknessNumericUpDown.Location = new Point(104, 56);
			ThicknessNumericUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			ThicknessNumericUpDown.Name = "ThicknessNumericUpDown";
			ThicknessNumericUpDown.PropertyName = "Thickness";
			ThicknessNumericUpDown.Size = new Size(56, 20);
			ThicknessNumericUpDown.TabIndex = 1;
			ThicknessNumericUpDown.TextAlign = HorizontalAlignment.Center;
			ColorPicker.Location = new Point(104, 112);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(144, 21);
			ColorPicker.TabIndex = 3;
			label4.LoadingBegin();
			label4.FocusControl = ColorPicker;
			label4.Location = new Point(70, 115);
			label4.Name = "label4";
			label4.Size = new Size(34, 15);
			label4.Text = "Color";
			label4.LoadingEnd();
			base.Controls.Add(ActualThicknessTextBox);
			base.Controls.Add(label4);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(ThicknessNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Controls.Add(StyleComboBox);
			base.Controls.Add(label3);
			base.Name = "BevelThickEditorPlugIn";
			base.Size = new Size(424, 288);
			base.Title = "Bevel Editor";
			base.ResumeLayout(false);
		}
	}
}
