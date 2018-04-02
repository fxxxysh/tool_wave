using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PercentLegendColumnEditorPlugIn : PlugInStandard
	{
		private Container components;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private FocusLabel label6;

		private FocusLabel label1;

		private EditBox MarginTextBox;

		private EditBox WidthMinTextBox;

		public PercentLegendColumnEditorPlugIn()
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
			MarginTextBox = new EditBox();
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			label6 = new FocusLabel();
			WidthMinTextBox = new EditBox();
			label1 = new FocusLabel();
			base.SuspendLayout();
			MarginTextBox.LoadingBegin();
			MarginTextBox.Location = new Point(64, 40);
			MarginTextBox.Name = "MarginTextBox";
			MarginTextBox.PropertyName = "Margin";
			MarginTextBox.Size = new Size(48, 20);
			MarginTextBox.TabIndex = 1;
			MarginTextBox.TextAlign = HorizontalAlignment.Center;
			MarginTextBox.LoadingEnd();
			VisibleCheckBox.Location = new Point(64, 0);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(78, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visble";
			label6.LoadingBegin();
			label6.FocusControl = MarginTextBox;
			label6.Location = new Point(23, 42);
			label6.Name = "label6";
			label6.Size = new Size(41, 15);
			label6.Text = "Margin";
			label6.LoadingEnd();
			WidthMinTextBox.LoadingBegin();
			WidthMinTextBox.Location = new Point(64, 64);
			WidthMinTextBox.Name = "WidthMinTextBox";
			WidthMinTextBox.PropertyName = "WidthMin";
			WidthMinTextBox.Size = new Size(48, 20);
			WidthMinTextBox.TabIndex = 2;
			WidthMinTextBox.TextAlign = HorizontalAlignment.Center;
			WidthMinTextBox.LoadingEnd();
			label1.LoadingBegin();
			label1.FocusControl = WidthMinTextBox;
			label1.Location = new Point(8, 66);
			label1.Name = "label1";
			label1.Size = new Size(56, 15);
			label1.Text = "Width Min";
			label1.LoadingEnd();
			base.Controls.Add(label1);
			base.Controls.Add(WidthMinTextBox);
			base.Controls.Add(MarginTextBox);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(label6);
			base.Name = "PercentLegendColumnEditorPlugIn";
			base.Size = new Size(296, 104);
			base.Title = "Column Editor";
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new TextFormatDoubleEditorPlugIn(), "Format", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PercentLegendColumn).Format;
		}
	}
}
