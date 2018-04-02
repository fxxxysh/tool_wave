using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotLegendMultiColumnCellFormattingPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private FontButton TitleFontButton;

		private FontButton DataFontButton;

		private GroupBox groupBox1;

		private EditBox MarginOuterTextBox;

		private Container components;

		public PlotLegendMultiColumnCellFormattingPlugIn()
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
			MarginOuterTextBox = new EditBox();
			TitleFontButton = new FontButton();
			DataFontButton = new FontButton();
			groupBox1 = new GroupBox();
			groupBox1.SuspendLayout();
			base.SuspendLayout();
			label2.LoadingBegin();
			label2.FocusControl = MarginOuterTextBox;
			label2.Location = new Point(193, 122);
			label2.Name = "label2";
			label2.Size = new Size(71, 15);
			label2.Text = "Margin Outer";
			label2.LoadingEnd();
			MarginOuterTextBox.LoadingBegin();
			MarginOuterTextBox.Location = new Point(264, 120);
			MarginOuterTextBox.Name = "MarginOuterTextBox";
			MarginOuterTextBox.PropertyName = "MarginOuter";
			MarginOuterTextBox.Size = new Size(48, 20);
			MarginOuterTextBox.TabIndex = 1;
			MarginOuterTextBox.LoadingEnd();
			TitleFontButton.Location = new Point(32, 24);
			TitleFontButton.Name = "TitleFontButton";
			TitleFontButton.PropertyName = "TitleFont";
			TitleFontButton.Size = new Size(80, 25);
			TitleFontButton.TabIndex = 0;
			TitleFontButton.Text = "Titles";
			DataFontButton.Location = new Point(32, 72);
			DataFontButton.Name = "DataFontButton";
			DataFontButton.PropertyName = "DataFont";
			DataFontButton.Size = new Size(80, 25);
			DataFontButton.TabIndex = 1;
			DataFontButton.Text = "Data";
			groupBox1.Controls.Add(TitleFontButton);
			groupBox1.Controls.Add(DataFontButton);
			groupBox1.Location = new Point(32, 72);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(136, 112);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Font";
			base.Controls.Add(groupBox1);
			base.Controls.Add(MarginOuterTextBox);
			base.Controls.Add(label2);
			base.Name = "PlotLegendMultiColumnCellFormattingPlugIn";
			base.Size = new Size(560, 264);
			groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
