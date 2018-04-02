using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PercentItemEditorPlugIn : PlugInStandard
	{
		private EditBox TitleTextBox;

		private FocusLabel label2;

		private EditBox ValueTextBox;

		private FocusLabel label1;

		private FocusLabel label4;

		private ColorPicker ColorPicker;

		private Container components;

		public PercentItemEditorPlugIn()
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
			TitleTextBox = new EditBox();
			label2 = new FocusLabel();
			ValueTextBox = new EditBox();
			label1 = new FocusLabel();
			ColorPicker = new ColorPicker();
			label4 = new FocusLabel();
			base.SuspendLayout();
			TitleTextBox.LoadingBegin();
			TitleTextBox.Location = new Point(80, 24);
			TitleTextBox.Name = "TitleTextBox";
			TitleTextBox.PropertyName = "Title";
			TitleTextBox.Size = new Size(144, 20);
			TitleTextBox.TabIndex = 0;
			TitleTextBox.LoadingEnd();
			label2.LoadingBegin();
			label2.FocusControl = TitleTextBox;
			label2.Location = new Point(52, 26);
			label2.Name = "label2";
			label2.Size = new Size(28, 15);
			label2.Text = "Title";
			label2.LoadingEnd();
			ValueTextBox.LoadingBegin();
			ValueTextBox.Location = new Point(80, 56);
			ValueTextBox.Name = "ValueTextBox";
			ValueTextBox.PropertyName = "Value";
			ValueTextBox.Size = new Size(144, 20);
			ValueTextBox.TabIndex = 1;
			ValueTextBox.LoadingEnd();
			label1.LoadingBegin();
			label1.FocusControl = ValueTextBox;
			label1.Location = new Point(44, 58);
			label1.Name = "label1";
			label1.Size = new Size(36, 15);
			label1.Text = "Value";
			label1.LoadingEnd();
			ColorPicker.Location = new Point(80, 88);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(144, 21);
			ColorPicker.TabIndex = 2;
			label4.LoadingBegin();
			label4.FocusControl = ColorPicker;
			label4.Location = new Point(46, 91);
			label4.Name = "label4";
			label4.Size = new Size(34, 15);
			label4.Text = "Color";
			label4.LoadingEnd();
			base.Controls.Add(TitleTextBox);
			base.Controls.Add(label2);
			base.Controls.Add(ValueTextBox);
			base.Controls.Add(label1);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label4);
			base.Name = "PercentItemEditorPlugIn";
			base.Size = new Size(376, 176);
			base.ResumeLayout(false);
		}
	}
}
