using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class OutlineEditorPlugIn : PlugInStandard
	{
		private FocusLabel label4;

		private FocusLabel label2;

		private EditBox ThicknessTextBox;

		private ColorPicker ColorPicker;

		private Container components;

		public OutlineEditorPlugIn()
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
			ThicknessTextBox = new EditBox();
			base.SuspendLayout();
			label4.LoadingBegin();
			label4.FocusControl = ColorPicker;
			label4.Location = new Point(38, 59);
			label4.Name = "label4";
			label4.Size = new Size(34, 15);
			label4.Text = "Color";
			label4.LoadingEnd();
			ColorPicker.Location = new Point(72, 56);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(144, 21);
			ColorPicker.TabIndex = 1;
			label2.LoadingBegin();
			label2.FocusControl = ThicknessTextBox;
			label2.Location = new Point(15, 26);
			label2.Name = "label2";
			label2.Size = new Size(57, 15);
			label2.Text = "Thickness";
			label2.LoadingEnd();
			ThicknessTextBox.LoadingBegin();
			ThicknessTextBox.Location = new Point(72, 24);
			ThicknessTextBox.Name = "ThicknessTextBox";
			ThicknessTextBox.PropertyName = "Thickness";
			ThicknessTextBox.Size = new Size(32, 20);
			ThicknessTextBox.TabIndex = 0;
			ThicknessTextBox.LoadingEnd();
			base.Controls.Add(ThicknessTextBox);
			base.Controls.Add(label2);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label4);
			base.Name = "OutlineEditorPlugIn";
			base.Size = new Size(264, 120);
			base.Title = "Outline Editor";
			base.ResumeLayout(false);
		}
	}
}
