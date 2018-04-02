using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotFillGridEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private GroupBox GridShowGroupBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox GridShowLeftCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox GridShowRightCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox GridShowTopCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox GridShowBottomCheckBox;

		private Container components;

		public PlotFillGridEditorPlugIn()
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
			GridShowGroupBox = new GroupBox();
			GridShowBottomCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			GridShowTopCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			GridShowRightCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			GridShowLeftCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			GridShowGroupBox.SuspendLayout();
			base.SuspendLayout();
			VisibleCheckBox.Location = new Point(80, 32);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			GridShowGroupBox.Controls.Add(GridShowBottomCheckBox);
			GridShowGroupBox.Controls.Add(GridShowTopCheckBox);
			GridShowGroupBox.Controls.Add(GridShowRightCheckBox);
			GridShowGroupBox.Controls.Add(GridShowLeftCheckBox);
			GridShowGroupBox.Location = new Point(112, 72);
			GridShowGroupBox.Name = "GridShowGroupBox";
			GridShowGroupBox.Size = new Size(96, 128);
			GridShowGroupBox.TabIndex = 1;
			GridShowGroupBox.TabStop = false;
			GridShowGroupBox.Text = "Grid Show";
			GridShowBottomCheckBox.Location = new Point(16, 96);
			GridShowBottomCheckBox.Name = "GridShowBottomCheckBox";
			GridShowBottomCheckBox.PropertyName = "GridShowBottom";
			GridShowBottomCheckBox.Size = new Size(72, 24);
			GridShowBottomCheckBox.TabIndex = 3;
			GridShowBottomCheckBox.Text = "Bottom";
			GridShowTopCheckBox.Location = new Point(16, 72);
			GridShowTopCheckBox.Name = "GridShowTopCheckBox";
			GridShowTopCheckBox.PropertyName = "GridShowTop";
			GridShowTopCheckBox.Size = new Size(72, 24);
			GridShowTopCheckBox.TabIndex = 2;
			GridShowTopCheckBox.Text = "Top";
			GridShowRightCheckBox.Location = new Point(16, 48);
			GridShowRightCheckBox.Name = "GridShowRightCheckBox";
			GridShowRightCheckBox.PropertyName = "GridShowRight";
			GridShowRightCheckBox.Size = new Size(72, 24);
			GridShowRightCheckBox.TabIndex = 1;
			GridShowRightCheckBox.Text = "Right";
			GridShowLeftCheckBox.Location = new Point(16, 24);
			GridShowLeftCheckBox.Name = "GridShowLeftCheckBox";
			GridShowLeftCheckBox.PropertyName = "GridShowLeft";
			GridShowLeftCheckBox.Size = new Size(72, 24);
			GridShowLeftCheckBox.TabIndex = 0;
			GridShowLeftCheckBox.Text = "Left";
			base.Controls.Add(GridShowGroupBox);
			base.Controls.Add(VisibleCheckBox);
			base.Name = "PlotFillGridEditorPlugIn";
			base.Size = new Size(424, 288);
			GridShowGroupBox.ResumeLayout(false);
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
