using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotDataCursorWindowEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown SizeNumericUpDown;

		private FocusLabel label1;

		private Container components;

		public PlotDataCursorWindowEditorPlugIn()
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
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			SizeNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label1 = new FocusLabel();
			base.SuspendLayout();
			VisibleCheckBox.Location = new Point(120, 56);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(152, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			SizeNumericUpDown.Location = new Point(120, 88);
			SizeNumericUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			SizeNumericUpDown.Name = "SizeNumericUpDown";
			SizeNumericUpDown.PropertyName = "Size";
			SizeNumericUpDown.Size = new Size(56, 20);
			SizeNumericUpDown.TabIndex = 1;
			SizeNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label1.LoadingBegin();
			label1.FocusControl = SizeNumericUpDown;
			label1.Location = new Point(91, 89);
			label1.Name = "label1";
			label1.Size = new Size(29, 15);
			label1.Text = "Size";
			label1.LoadingEnd();
			base.Controls.Add(SizeNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(VisibleCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotDataCursorWindowEditorPlugIn";
			base.Size = new Size(504, 336);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Line", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotDataCursorWindow).Line;
		}
	}
}
