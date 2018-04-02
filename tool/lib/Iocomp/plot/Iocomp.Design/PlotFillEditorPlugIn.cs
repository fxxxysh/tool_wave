using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotFillEditorPlugIn : PlugInStandard
	{
		private CheckBox VisibleCheckBox;

		private Container components;

		public PlotFillEditorPlugIn()
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
			VisibleCheckBox = new CheckBox();
			base.SuspendLayout();
			VisibleCheckBox.Location = new Point(80, 32);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			base.Controls.Add(VisibleCheckBox);
			base.Name = "PlotFillEditorPlugIn";
			base.Size = new Size(424, 288);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Pen", false);
			base.AddSubPlugIn(new PlotBrushEditorPlugIn(), "Brush", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotFill).Pen;
			base.SubPlugIns[1].Value = (base.Value as PlotFill).Brush;
		}
	}
}
