using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Axis Grid Lines.")]
	public class PlotAxisGridLines : SubClassBase, IPlotAxisGridLines
	{
		private PlotPen m_Major;

		private IPlotPen I_Major;

		private PlotPen m_Mid;

		private IPlotPen I_Mid;

		private PlotPen m_Minor;

		private IPlotPen I_Minor;

		private bool m_ShowOnTop;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool Visible
		{
			get
			{
				return VisibleInternal;
			}
			set
			{
				VisibleInternal = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public new Color Color
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.Color = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotPen Major
		{
			get
			{
				return m_Major;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotPen Mid
		{
			get
			{
				return m_Mid;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotPen Minor
		{
			get
			{
				return m_Minor;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ShowOnTop
		{
			get
			{
				return m_ShowOnTop;
			}
			set
			{
				base.PropertyUpdateDefault("ShowOnTop", value);
				if (ShowOnTop != value)
				{
					m_ShowOnTop = value;
					base.DoPropertyChange(this, "ShowOnTop");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Axis Grid Lines";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotAxisGridLinesEditorPlugIn";
		}

		void IPlotAxisGridLines.DrawMajors(PaintArgs p, Plot plot, PlotAxis axis)
		{
			Draw(p, plot, axis, true);
		}

		void IPlotAxisGridLines.DrawMinors(PaintArgs p, Plot plot, PlotAxis axis)
		{
			Draw(p, plot, axis, false);
		}

		public PlotAxisGridLines()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Major = new PlotPen();
			base.AddSubClass(Major);
			I_Major = Major;
			m_Mid = new PlotPen();
			base.AddSubClass(Mid);
			I_Mid = Mid;
			m_Minor = new PlotPen();
			base.AddSubClass(Minor);
			I_Minor = Minor;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Visible = true;
			Color = Color.Empty;
			Major.Visible = true;
			Major.Style = PlotPenStyle.Solid;
			Major.Color = Color.Empty;
			Major.Thickness = 1.0;
			Mid.Visible = false;
			Mid.Style = PlotPenStyle.Solid;
			Mid.Color = Color.Empty;
			Mid.Thickness = 1.0;
			Minor.Visible = false;
			Minor.Style = PlotPenStyle.Solid;
			Minor.Color = Color.Empty;
			Minor.Thickness = 1.0;
			ShowOnTop = false;
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeMajor()
		{
			return ((ISubClassBase)Major).ShouldSerialize();
		}

		private void ResetMajor()
		{
			((ISubClassBase)Major).ResetToDefault();
		}

		private bool ShouldSerializeMid()
		{
			return ((ISubClassBase)Mid).ShouldSerialize();
		}

		private void ResetMid()
		{
			((ISubClassBase)Mid).ResetToDefault();
		}

		private bool ShouldSerializeMinor()
		{
			return ((ISubClassBase)Minor).ShouldSerialize();
		}

		private void ResetMinor()
		{
			((ISubClassBase)Minor).ResetToDefault();
		}

		private bool ShouldSerializeShowOnTop()
		{
			return base.PropertyShouldSerialize("ShowOnTop");
		}

		private void ResetShowOnTop()
		{
			base.PropertyReset("ShowOnTop");
		}

		private void DrawLine(PaintArgs p, PlotAxis axis, Rectangle r, Pen pen, int APixels)
		{
			if (axis.DockHorizontal)
			{
				p.Graphics.DrawLine(pen, r.Left, APixels, r.Right, APixels);
			}
			else
			{
				p.Graphics.DrawLine(pen, APixels, r.Top, APixels, r.Bottom);
			}
		}

		private void DrawToDataView(PaintArgs p, PlotAxis axis, Rectangle r, bool drawMajors)
		{
			p.Graphics.SetClip(r);
			if (Major.Visible && drawMajors)
			{
				Pen pen = I_Major.GetPen(p);
				foreach (ScaleTickBase tick in axis.ScaleDisplay.TickList)
				{
					if (tick is ScaleTickMajor)
					{
						DrawLine(p, axis, r, pen, axis.ScaleDisplay.ValueToPixels(tick.Value));
					}
				}
			}
			if (Mid.Visible && drawMajors)
			{
				Pen pen = I_Mid.GetPen(p);
				foreach (ScaleTickBase tick2 in axis.ScaleDisplay.TickList)
				{
					if (tick2 is ScaleTickMid)
					{
						DrawLine(p, axis, r, pen, axis.ScaleDisplay.ValueToPixels(tick2.Value));
					}
				}
			}
			if (Minor.Visible && !drawMajors)
			{
				Pen pen = I_Minor.GetPen(p);
				foreach (ScaleTickBase tick3 in axis.ScaleDisplay.TickList)
				{
					if (tick3 is ScaleTickMinor)
					{
						DrawLine(p, axis, r, pen, axis.ScaleDisplay.ValueToPixels(tick3.Value));
					}
				}
			}
		}

		private void Draw(PaintArgs p, Plot plot, PlotAxis axis, bool drawMajors)
		{
			if (Visible && plot != null)
			{
				string dockDataViewName = axis.DockDataViewName;
				PlotDataView plotDataView = plot.DataViews[dockDataViewName];
				if (plotDataView != null)
				{
					p.Graphics.SetClip(plotDataView.BoundsClip);
					DrawToDataView(p, axis, plotDataView.BoundsClip, drawMajors);
					foreach (PlotDataView dataView in plot.DataViews)
					{
						if (dataView != plotDataView)
						{
							if (axis.DockVertical)
							{
								if (PlotBase.GetNamesMatch(dataView.GridLinesMirrorVertical, dockDataViewName))
								{
									DrawToDataView(p, axis, dataView.BoundsClip, drawMajors);
								}
							}
							else if (PlotBase.GetNamesMatch(dataView.GridLinesMirrorHorizontal, dockDataViewName))
							{
								DrawToDataView(p, axis, dataView.BoundsClip, drawMajors);
							}
						}
					}
				}
			}
		}
	}
}
