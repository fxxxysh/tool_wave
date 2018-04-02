using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Crosshair Window")]
	public class PlotDataCursorWindow : SubClassBase, IPlotDataCursorWindow
	{
		private PlotPen m_Line;

		protected IPlotPen I_Line;

		private int m_Size;

		private PlotDataCursorBase m_DataCursor;

		private Region m_HitRegion;

		Region IPlotDataCursorWindow.HitRegion
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotPen Line
		{
			get
			{
				return m_Line;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int Size
		{
			get
			{
				return m_Size;
			}
			set
			{
				base.PropertyUpdateDefault("Size", value);
				if (Size != value)
				{
					m_Size = value;
					base.DoPropertyChange(this, "Size");
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

		protected override string GetPlugInTitle()
		{
			return "Data-Cursor Window";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotDataCursorWindowEditorPlugIn";
		}

		void IPlotDataCursorWindow.Draw(PaintArgs p, Point centerPoint)
		{
			Draw(p, centerPoint);
		}

		public PlotDataCursorWindow()
		{
			base.DoCreate();
		}

		public PlotDataCursorWindow(PlotDataCursorBase value)
		{
			m_DataCursor = value;
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Line = new PlotPen();
			base.AddSubClass(Line);
			I_Line = Line;
			((ISubClassBase)Line).ColorAmbientSource = AmbientColorSouce.Color;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Visible = true;
			Size = 4;
		}

		private bool ShouldSerializeLine()
		{
			return ((ISubClassBase)Line).ShouldSerialize();
		}

		private void ResetLine()
		{
			((ISubClassBase)Line).ResetToDefault();
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeSize()
		{
			return base.PropertyShouldSerialize("Size");
		}

		private void ResetSize()
		{
			base.PropertyReset("Size");
		}

		private void Draw(PaintArgs p, Point centerPoint)
		{
			if (HitRegion != null)
			{
				HitRegion.Dispose();
				HitRegion = null;
			}
			if (Visible && DataCursor != null && XAxis != null && YAxis != null && DataCursor.Pointer1.Visible && DataCursor.Pointer1.AxisPosition != DataCursor.Pointer2.AxisPosition)
			{
				Rectangle rect = iRectangle.FromLTRB(centerPoint.X - Size, centerPoint.Y - Size, centerPoint.X + Size, centerPoint.Y + Size);
				if (Line.Visible)
				{
					p.Graphics.DrawEllipse(I_Line.GetPen(p), rect);
				}
			}
		}
	}
}
