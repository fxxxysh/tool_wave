using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class ScaleTickMinorEditorPlugIn : PlugInStandard
	{
		private FocusLabel label9;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LengthNumericUpDown;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.ComboBox AlignmentComboBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown ThicknessNumericUpDown;

		private FocusLabel label10;

		private FocusLabel label7;

		private ColorPicker ColorPicker;

		private Container components;

		public ScaleTickMinorEditorPlugIn()
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
			label9 = new FocusLabel();
			ColorPicker = new ColorPicker();
			LengthNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label1 = new FocusLabel();
			AlignmentComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			ThicknessNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label10 = new FocusLabel();
			label7 = new FocusLabel();
			base.SuspendLayout();
			label9.LoadingBegin();
			label9.FocusControl = ColorPicker;
			label9.Location = new Point(30, 99);
			label9.Name = "label9";
			label9.Size = new Size(34, 15);
			label9.Text = "Color";
			label9.LoadingEnd();
			ColorPicker.Location = new Point(64, 96);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(144, 21);
			ColorPicker.TabIndex = 3;
			LengthNumericUpDown.Location = new Point(64, 40);
			LengthNumericUpDown.Name = "LengthNumericUpDown";
			LengthNumericUpDown.PropertyName = "Length";
			LengthNumericUpDown.Size = new Size(57, 20);
			LengthNumericUpDown.TabIndex = 1;
			LengthNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label1.LoadingBegin();
			label1.FocusControl = AlignmentComboBox;
			label1.Location = new Point(7, 10);
			label1.Name = "label1";
			label1.Size = new Size(57, 15);
			label1.Text = "Alignment";
			label1.LoadingEnd();
			AlignmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			AlignmentComboBox.Location = new Point(64, 8);
			AlignmentComboBox.Name = "AlignmentComboBox";
			AlignmentComboBox.PropertyName = "Alignment";
			AlignmentComboBox.Size = new Size(144, 21);
			AlignmentComboBox.TabIndex = 0;
			ThicknessNumericUpDown.Location = new Point(64, 64);
			ThicknessNumericUpDown.Name = "ThicknessNumericUpDown";
			ThicknessNumericUpDown.PropertyName = "Thickness";
			ThicknessNumericUpDown.Size = new Size(57, 20);
			ThicknessNumericUpDown.TabIndex = 2;
			ThicknessNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label10.LoadingBegin();
			label10.FocusControl = ThicknessNumericUpDown;
			label10.Location = new Point(7, 65);
			label10.Name = "label10";
			label10.Size = new Size(57, 15);
			label10.Text = "Thickness";
			label10.LoadingEnd();
			label7.LoadingBegin();
			label7.FocusControl = LengthNumericUpDown;
			label7.Location = new Point(23, 41);
			label7.Name = "label7";
			label7.Size = new Size(41, 15);
			label7.Text = "Length";
			label7.LoadingEnd();
			base.Controls.Add(LengthNumericUpDown);
			base.Controls.Add(AlignmentComboBox);
			base.Controls.Add(ThicknessNumericUpDown);
			base.Controls.Add(label10);
			base.Controls.Add(label7);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label1);
			base.Controls.Add(label9);
			base.Name = "ScaleTickMinorEditorPlugIn";
			base.Size = new Size(584, 232);
			base.Title = "Tick-Minor Editor";
			base.ResumeLayout(false);
		}
	}
}
