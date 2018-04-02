using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PointDoubleEditorPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private EditBox XTextBox;

		private EditBox YTextBox;

		private FocusLabel focusLabel1;

		private Container components;

		public PointDoubleEditorPlugIn()
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
			XTextBox = new EditBox();
			YTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			base.SuspendLayout();
			label2.LoadingBegin();
			label2.FocusControl = XTextBox;
			label2.Location = new Point(57, 10);
			label2.Name = "label2";
			label2.Size = new Size(15, 15);
			label2.Text = "X";
			label2.LoadingEnd();
			XTextBox.LoadingBegin();
			XTextBox.Location = new Point(72, 8);
			XTextBox.Name = "XTextBox";
			XTextBox.PropertyName = "X";
			XTextBox.Size = new Size(104, 20);
			XTextBox.TabIndex = 0;
			XTextBox.LoadingEnd();
			YTextBox.LoadingBegin();
			YTextBox.Location = new Point(72, 32);
			YTextBox.Name = "YTextBox";
			YTextBox.PropertyName = "Y";
			YTextBox.Size = new Size(104, 20);
			YTextBox.TabIndex = 1;
			YTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = YTextBox;
			focusLabel1.Location = new Point(57, 34);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(15, 15);
			focusLabel1.Text = "Y";
			focusLabel1.LoadingEnd();
			base.Controls.Add(YTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(XTextBox);
			base.Controls.Add(label2);
			base.Name = "PointDoubleEditorPlugIn";
			base.Size = new Size(520, 152);
			base.ResumeLayout(false);
		}
	}
}
