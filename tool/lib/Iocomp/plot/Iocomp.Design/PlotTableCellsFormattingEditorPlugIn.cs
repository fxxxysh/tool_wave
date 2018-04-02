using Iocomp.Classes;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotTableCellsFormattingEditorPlugIn : PlugInStandard
	{
		private Container components;

		public PlotTableCellsFormattingEditorPlugIn()
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
			base.Name = "PlotTableCellsFormattingEditorPlugIn";
			base.Size = new Size(424, 288);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotTableCellFormatEditorPlugIn(), "Data", false);
			base.AddSubPlugIn(new PlotTableCellFormatEditorPlugIn(), "Col-Titles", false);
			base.AddSubPlugIn(new PlotTableCellFormatEditorPlugIn(), "Row-Titles", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotTableCellsFormatting).Data;
			base.SubPlugIns[1].Value = (base.Value as PlotTableCellsFormatting).ColTitles;
			base.SubPlugIns[2].Value = (base.Value as PlotTableCellsFormatting).RowTitles;
		}
	}
}
