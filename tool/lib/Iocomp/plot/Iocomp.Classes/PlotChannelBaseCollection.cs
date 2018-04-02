using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using System;
using System.Collections;
using System.Drawing;

namespace Iocomp.Classes
{
	public class PlotChannelBaseCollection : PlotObjectCollectionBase
	{
		private PlotColorTable m_ColorTable;

		private PlotChannelBarAccessor m_Bar;

		private PlotChannelBiFillAccessor m_BiFill;

		private PlotChannelBubbleAccessor m_Bubble;

		private PlotChannelCubicSplineAccessor m_CubicSpline;

		private PlotChannelDifferentialAccessor m_Differential;

		private PlotChannelDigitalAccessor m_Digital;

		private PlotChannelFillAccessor m_Fill;

		private PlotChannelImageAccessor m_Image;

		private PlotChannelPolynomialAccessor m_Polynomial;

		private PlotChannelRationalAccessor m_Rational;

		private PlotChannelSweepIntervalAccessor m_SweepInterval;

		private PlotChannelTraceAccessor m_Trace;

		private PlotChannelTraceXYAccessor m_TraceXY;

		public PlotChannelBase this[int index]
		{
			get
			{
				return base.List[index] as PlotChannelBase;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public PlotChannelBase this[string name]
		{
			get
			{
				return base.GetPlotObjectByName(name) as PlotChannelBase;
			}
		}

		public PlotColorTable ColorTable => m_ColorTable;

		public PlotChannelBarAccessor Bar => m_Bar;

		public PlotChannelBiFillAccessor BiFill => m_BiFill;

		public PlotChannelBubbleAccessor Bubble => m_Bubble;

		public PlotChannelCubicSplineAccessor CubicSpline => m_CubicSpline;

		public PlotChannelDifferentialAccessor Differential => m_Differential;

		public PlotChannelDigitalAccessor Digital => m_Digital;

		public PlotChannelFillAccessor Fill => m_Fill;

		public PlotChannelImageAccessor Image => m_Image;

		public PlotChannelPolynomialAccessor Polynomial => m_Polynomial;

		public PlotChannelRationalAccessor Rational => m_Rational;

		public PlotChannelSweepIntervalAccessor SweepInterval => m_SweepInterval;

		public PlotChannelTraceAccessor Trace => m_Trace;

		public PlotChannelTraceXYAccessor TraceXY => m_TraceXY;

		protected override string GetPlugInTitle()
		{
			return "Channel Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelBaseCollectionEditorPlugIn";
		}

		public PlotChannelBaseCollection()
			: base(null)
		{
			Initialize();
		}

		public PlotChannelBaseCollection(IComponentBase componentBase)
			: base(componentBase)
		{
			Initialize();
		}

		private void Initialize()
		{
			base.AllowEdit = true;
			base.BaseName = "Channel";
			m_Bar = new PlotChannelBarAccessor(this);
			m_BiFill = new PlotChannelBiFillAccessor(this);
			m_Bubble = new PlotChannelBubbleAccessor(this);
			m_CubicSpline = new PlotChannelCubicSplineAccessor(this);
			m_Differential = new PlotChannelDifferentialAccessor(this);
			m_Digital = new PlotChannelDigitalAccessor(this);
			m_Fill = new PlotChannelFillAccessor(this);
			m_Image = new PlotChannelImageAccessor(this);
			m_Polynomial = new PlotChannelPolynomialAccessor(this);
			m_Rational = new PlotChannelRationalAccessor(this);
			m_SweepInterval = new PlotChannelSweepIntervalAccessor(this);
			m_Trace = new PlotChannelTraceAccessor(this);
			m_TraceXY = new PlotChannelTraceXYAccessor(this);
			m_ColorTable = new PlotColorTable();
			m_ColorTable.RefreshTable += m_ColorTable_RefreshTable;
		}

		public void CopyTo(PlotChannelBase[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(PlotChannelBase value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, PlotChannelBase value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(PlotChannelBase value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(PlotChannelBase value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(PlotChannelBase value)
		{
			return base.List.Contains(value);
		}

		public override void Reset()
		{
			base.Clear();
			Add(new PlotChannelTrace());
		}

		protected override void SetupObjectBeforeAmbientControlBaseConnection(object value)
		{
			base.SetupObjectBeforeAmbientControlBaseConnection(value);
			PlotChannelBase plotChannelBase = value as PlotChannelBase;
			Plot plot = base.ComponentBase as Plot;
			if (plotChannelBase.Color == Color.Empty)
			{
				plotChannelBase.Color = ColorTable.NextColor();
			}
			if (plot != null)
			{
				if (plotChannelBase.XAxisName == "" && plot.XAxes.Count != 0)
				{
					plotChannelBase.XAxisName = plot.XAxes[0].Name;
				}
				if (plotChannelBase.YAxisName == "" && plot.YAxes.Count != 0)
				{
					plotChannelBase.YAxisName = plot.YAxes[0].Name;
				}
				if (plotChannelBase.LegendName == "" && plot.Legends.Count != 0)
				{
					plotChannelBase.LegendName = plot.Legends[0].Name;
				}
			}
		}

		private void m_ColorTable_RefreshTable(object sender, EventArgs e)
		{
			foreach (PlotChannelBase item in this)
			{
				ColorTable.AddUsedColor(item.Color);
			}
		}
	}
}
