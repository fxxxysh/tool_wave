using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ScaleDiscreetItemEditorPlugIn : PlugInStandard
	{
		private EditBox TitleTextBox;

		private FocusLabel label2;

		private Container components;

		public ScaleDiscreetItemEditorPlugIn()
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
			base.SuspendLayout();
			TitleTextBox.LoadingBegin();
			TitleTextBox.Location = new Point(72, 48);
			TitleTextBox.Name = "TitleTextBox";
			TitleTextBox.PropertyName = "Text";
			TitleTextBox.Size = new Size(144, 20);
			TitleTextBox.TabIndex = 0;
			TitleTextBox.LoadingEnd();
			label2.LoadingBegin();
			label2.FocusControl = TitleTextBox;
			label2.Location = new Point(43, 50);
			label2.Name = "label2";
			label2.Size = new Size(29, 15);
			label2.Text = "Text";
			label2.LoadingEnd();
			base.Controls.Add(TitleTextBox);
			base.Controls.Add(label2);
			base.Name = "ScaleDiscreetItemEditorPlugIn";
			base.Size = new Size(224, 112);
			base.ResumeLayout(false);
		}
	}
}
