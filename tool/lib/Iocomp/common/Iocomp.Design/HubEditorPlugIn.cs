using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class HubEditorPlugIn : PlugInStandard
	{
		private FocusLabel label4;

		private FocusLabel label2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown SizeNumericUpDown;

		private ColorPicker ColorPicker;

		private Container components;

		public HubEditorPlugIn()
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
			label4 = new FocusLabel();
			ColorPicker = new ColorPicker();
			label2 = new FocusLabel();
			SizeNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			label4.LoadingBegin();
			label4.FocusControl = ColorPicker;
			label4.Location = new Point(38, 99);
			label4.Name = "label4";
			label4.Size = new Size(34, 15);
			label4.Text = "Color";
			label4.LoadingEnd();
			ColorPicker.Location = new Point(72, 96);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(144, 21);
			ColorPicker.TabIndex = 2;
			label2.LoadingBegin();
			label2.FocusControl = SizeNumericUpDown;
			label2.Location = new Point(43, 65);
			label2.Name = "label2";
			label2.Size = new Size(29, 15);
			label2.Text = "Size";
			label2.LoadingEnd();
			SizeNumericUpDown.Location = new Point(72, 64);
			SizeNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			SizeNumericUpDown.Name = "SizeNumericUpDown";
			SizeNumericUpDown.PropertyName = "Size";
			SizeNumericUpDown.Size = new Size(48, 20);
			SizeNumericUpDown.TabIndex = 1;
			SizeNumericUpDown.TextAlign = HorizontalAlignment.Center;
			VisibleCheckBox.Location = new Point(72, 32);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(64, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			base.Controls.Add(SizeNumericUpDown);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(label2);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label4);
			base.Name = "HubEditorPlugIn";
			base.Size = new Size(400, 256);
			base.Title = "Hub Editor";
			base.ResumeLayout(false);
		}
	}
}
