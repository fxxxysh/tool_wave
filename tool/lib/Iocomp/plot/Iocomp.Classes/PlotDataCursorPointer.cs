using Iocomp.Interfaces;
using Iocomp.Types;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Description("Plot Data Cursor Pointer")]
	public class PlotDataCursorPointer : SubClassBase, IPlotDataCursorPointer
	{
		private bool m_Visible;

		private double m_Position;

		private int m_PositionPixels;

		private PlotAxisReference m_Style;

		private PlotDataCursorBase m_DataCursor;

		private Region m_HitRegion;

		private bool m_MouseActive;

		private double m_MouseDownPosition;

		private double m_MouseDownActual;

		private ArrayList m_PositionArray;

		Region IPlotDataCursorPointer.HitRegion
		{
			get
			{
				return m_HitRegion;
			}
			set
			{
				m_HitRegion = value;
			}
		}

		bool IPlotDataCursorPointer.MouseActive
		{
			get
			{
				return m_MouseActive;
			}
			set
			{
				m_MouseActive = value;
			}
		}

		double IPlotDataCursorPointer.MouseDownPosition
		{
			get
			{
				return m_MouseDownPosition;
			}
			set
			{
				m_MouseDownPosition = value;
			}
		}

		double IPlotDataCursorPointer.MouseDownActual
		{
			get
			{
				return m_MouseDownActual;
			}
			set
			{
				m_MouseDownActual = value;
			}
		}

		public bool Visible
		{
			get
			{
				return m_Visible;
			}
			set
			{
				m_Visible = value;
			}
		}

		public PlotAxisReference Style
		{
			get
			{
				return m_Style;
			}
			set
			{
				m_Style = value;
			}
		}

		public double Position
		{
			get
			{
				return m_Position;
			}
			set
			{
				if (m_Position != value)
				{
					m_Position = value;
					base.DoPropertyChange(this, "Position");
				}
			}
		}

		private PlotXAxis XAxis
		{
			get
			{
				if (DataCursor == null)
				{
					return null;
				}
				return DataCursor.XAxis;
			}
		}

		private PlotYAxis YAxis
		{
			get
			{
				if (DataCursor == null)
				{
					return null;
				}
				return DataCursor.YAxis;
			}
		}

		private PlotDataCursorBase DataCursor => m_DataCursor;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("Iocomp")]
		public PlotAxis AxisPosition
		{
			get
			{
				if (DataCursor == null)
				{
					return null;
				}
				if (Style == PlotAxisReference.XAxis)
				{
					return DataCursor.XAxis;
				}
				return DataCursor.YAxis;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PlotAxis AxisRange
		{
			get
			{
				if (DataCursor == null)
				{
					return null;
				}
				if (Style == PlotAxisReference.XAxis)
				{
					return DataCursor.YAxis;
				}
				return DataCursor.XAxis;
			}
		}

		public int PositionPixels => AxisPosition.PercentToPixels(Position);

		private Region HitRegion
		{
			get
			{
				return m_HitRegion;
			}
			set
			{
				m_HitRegion = value;
			}
		}

		void IPlotDataCursorPointer.Draw(PaintArgs p, Pen pen, PlotDataCursorDisplayCollection displays)
		{
			Draw(p, pen, displays);
		}

		public PlotDataCursorPointer()
		{
			base.DoCreate();
		}

		public PlotDataCursorPointer(PlotDataCursorBase value)
		{
			m_DataCursor = value;
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_PositionArray = new ArrayList();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Position = 0.5;
		}

		private void Draw(PaintArgs p, Pen pen, PlotDataCursorDisplayCollection displays)
		{
			if (HitRegion != null)
			{
				HitRegion.Dispose();
				HitRegion = null;
			}
			if (Visible && DataCursor != null && XAxis != null && YAxis != null)
			{
				bool swap = Style == PlotAxisReference.YAxis ^ DataCursor.XYSwapped;
				PlotAxis axisPosition = AxisPosition;
				PlotAxis axisRange = AxisRange;
				int positionPixels = PositionPixels;
				int dataViewPixelsMin = axisRange.DataViewPixelsMin;
				int dataViewPixelsMax = axisRange.DataViewPixelsMax;
				m_PositionArray.Clear();
				m_PositionArray.Add(dataViewPixelsMin);
				m_PositionArray.Add(dataViewPixelsMax);
				if (DataCursor.WindowShowing)
				{
					foreach (PlotDataCursorDisplay display in displays)
					{
						if (!display.DisableWindow)
						{
							if (Style == PlotAxisReference.XAxis)
							{
								m_PositionArray.Add(AxisRange.PercentToPixels(display.YPosition) - DataCursor.Window.Size);
								m_PositionArray.Add(AxisRange.PercentToPixels(display.YPosition) + DataCursor.Window.Size);
							}
							else
							{
								m_PositionArray.Add(AxisRange.PercentToPixels(display.XPosition) - DataCursor.Window.Size);
								m_PositionArray.Add(AxisRange.PercentToPixels(display.XPosition) + DataCursor.Window.Size);
							}
						}
					}
				}
				m_PositionArray.Sort();
				for (int i = 0; i < m_PositionArray.Count; i += 2)
				{
					Point pt = iDraw.Point(swap, positionPixels, (int)m_PositionArray[i]);
					Point pt2 = iDraw.Point(swap, positionPixels, (int)m_PositionArray[i + 1]);
					p.Graphics.DrawLine(pen, pt, pt2);
				}
				Rectangle b = iRectangle.FromLTRB(swap, positionPixels, dataViewPixelsMin, positionPixels, dataViewPixelsMax);
				b.Inflate(DataCursor.HitRegionSize, DataCursor.HitRegionSize);
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddRectangle(Rectangle.Intersect(DataCursor.BoundsClip, b));
				HitRegion = new Region(graphicsPath);
				m_PositionPixels = positionPixels;
			}
		}
	}
}
