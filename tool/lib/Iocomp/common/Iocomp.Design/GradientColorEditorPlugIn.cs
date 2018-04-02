using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class GradientColorEditorPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private EditBox PositionTextBox;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private Label label1;

		private Label label3;

		private Label label4;

		private Label label6;

		private Label label7;

		private Container components;

		public GradientColorEditorPlugIn()
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
			PositionTextBox = new EditBox();
			ColorPicker = new ColorPicker();
			label8 = new FocusLabel();
			label1 = new Label();
			label3 = new Label();
			label4 = new Label();
			label6 = new Label();
			label7 = new Label();
			base.SuspendLayout();
			label2.LoadingBegin();
			label2.FocusControl = PositionTextBox;
			label2.Location = new Point(113, 42);
			label2.Name = "label2";
			label2.Size = new Size(47, 15);
			label2.Text = "Position";
			label2.LoadingEnd();
			PositionTextBox.LoadingBegin();
			PositionTextBox.Location = new Point(160, 40);
			PositionTextBox.Name = "PositionTextBox";
			PositionTextBox.PropertyName = "Position";
			PositionTextBox.Size = new Size(104, 20);
			PositionTextBox.TabIndex = 1;
			PositionTextBox.LoadingEnd();
			ColorPicker.Location = new Point(48, 40);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(48, 21);
			ColorPicker.Style = ColorPickerStyle.ColorBox;
			ColorPicker.TabIndex = 0;
			label8.LoadingBegin();
			label8.FocusControl = ColorPicker;
			label8.Location = new Point(14, 43);
			label8.Name = "label8";
			label8.Size = new Size(34, 15);
			label8.Text = "Color";
			label8.LoadingEnd();
			label1.AutoSize = true;
			label1.Location = new Point(24, 110);
			label1.Name = "label1";
			label1.Size = new Size(155, 16);
			label1.TabIndex = 3;
			label1.Text = "- First item position must be 0.";
			label3.AutoSize = true;
			label3.Location = new Point(24, 154);
			label3.Name = "label3";
			label3.Size = new Size(155, 16);
			label3.TabIndex = 5;
			label3.Text = "- Last item position must be 1.";
			label4.AutoSize = true;
			label4.Location = new Point(24, 88);
			label4.Name = "label4";
			label4.Size = new Size(112, 16);
			label4.TabIndex = 2;
			label4.Text = "- Minimum of 2 items.";
			label6.Location = new Point(24, 176);
			label6.Name = "label6";
			label6.Size = new Size(296, 32);
			label6.TabIndex = 6;
			label6.Text = "- If any of the previous requirements are not satisfied, orange && yellow will be used.";
			label7.AutoSize = true;
			label7.Location = new Point(24, 132);
			label7.Name = "label7";
			label7.Size = new Size(191, 16);
			label7.TabIndex = 4;
			label7.Text = "- Item position's must be incremental.";
			base.Controls.Add(label7);
			base.Controls.Add(label6);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(label1);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label8);
			base.Controls.Add(PositionTextBox);
			base.Controls.Add(label2);
			base.Name = "GradientColorEditorPlugIn";
			base.Size = new Size(560, 240);
			base.ResumeLayout(false);
		}
	}
}
