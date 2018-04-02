using Iocomp.Interfaces;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Table Cells Formatting")]
	public class PlotTableCellsFormatting : SubClassBase
	{
		private PlotTableCellFormat m_ColTitles;

		private PlotTableCellFormat m_RowTitles;

		private PlotTableCellFormat m_Data;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotTableCellFormat ColTitles
		{
			get
			{
				return m_ColTitles;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotTableCellFormat RowTitles
		{
			get
			{
				return m_RowTitles;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotTableCellFormat Data
		{
			get
			{
				return m_Data;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Table Cells Formatting";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotTableCellsFormattingEditorPlugIn";
		}

		public PlotTableCellsFormatting()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_ColTitles = new PlotTableCellFormat();
			base.AddSubClass(ColTitles);
			m_RowTitles = new PlotTableCellFormat();
			base.AddSubClass(RowTitles);
			m_Data = new PlotTableCellFormat();
			base.AddSubClass(Data);
		}

		private bool ShouldSerializeColTitles()
		{
			return ((ISubClassBase)ColTitles).ShouldSerialize();
		}

		private void ResetColTitles()
		{
			((ISubClassBase)ColTitles).ResetToDefault();
		}

		private bool ShouldSerializeRowTitles()
		{
			return ((ISubClassBase)RowTitles).ShouldSerialize();
		}

		private void ResetRowTitles()
		{
			((ISubClassBase)RowTitles).ResetToDefault();
		}

		private bool ShouldSerializeData()
		{
			return ((ISubClassBase)Data).ShouldSerialize();
		}

		private void ResetData()
		{
			((ISubClassBase)Data).ResetToDefault();
		}
	}
}
