using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Serializable]
	public class PlotAnnotationPolygon : PlotAnnotationFillBase
	{
		private PointDoubleCollection m_Points;

		private PointDoubleCollection m_PointsCached;

		protected override IComponentBase ComponentBase
		{
			get
			{
				return base.ComponentBase;
			}
			set
			{
				base.ComponentBase = value;
				((ICollectionBase)m_Points).ComponentBase = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Iocomp")]
		[Description("")]
		public PointDoubleCollection Points
		{
			get
			{
				return m_Points;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("Iocomp")]
		[Description("")]
		public override double X
		{
			get
			{
				if (m_Points.Count == 0)
				{
					return 0.0;
				}
				double num = m_Points[0].X;
				double num2 = m_Points[0].X;
				for (int i = 1; i < m_Points.Count; i++)
				{
					num = Math.Max(num, m_Points[i].X);
					num2 = Math.Min(num2, m_Points[i].X);
				}
				return (num + num2) / 2.0;
			}
			set
			{
				double num = value - X;
				for (int i = 0; i < m_Points.Count; i++)
				{
					m_Points[i].X += num;
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("Iocomp")]
		[Description("")]
		public override double Y
		{
			get
			{
				if (m_Points.Count == 0)
				{
					return 0.0;
				}
				double num = m_Points[0].Y;
				double num2 = m_Points[0].Y;
				for (int i = 1; i < m_Points.Count; i++)
				{
					num = Math.Max(num, m_Points[i].Y);
					num2 = Math.Min(num2, m_Points[i].Y);
				}
				return (num + num2) / 2.0;
			}
			set
			{
				double num = value - Y;
				for (int i = 0; i < m_Points.Count; i++)
				{
					m_Points[i].Y += num;
				}
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		public override double Height
		{
			get
			{
				if (m_Points.Count == 0)
				{
					return 0.0;
				}
				double num = m_Points[0].Y;
				double num2 = m_Points[0].Y;
				for (int i = 1; i < m_Points.Count; i++)
				{
					num = Math.Max(num, m_Points[i].Y);
					num2 = Math.Min(num2, m_Points[i].Y);
				}
				return num - num2;
			}
			set
			{
				double y = Y;
				double num = value / Height;
				for (int i = 0; i < m_Points.Count; i++)
				{
					m_Points[i].Y = (m_Points[i].Y - y) * num + y;
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		public override double Width
		{
			get
			{
				if (m_Points.Count == 0)
				{
					return 0.0;
				}
				double num = m_Points[0].X;
				double num2 = m_Points[0].X;
				for (int i = 1; i < m_Points.Count; i++)
				{
					num = Math.Max(num, m_Points[i].X);
					num2 = Math.Min(num2, m_Points[i].X);
				}
				return num - num2;
			}
			set
			{
				double x = X;
				double num = value / Width;
				for (int i = 0; i < m_Points.Count; i++)
				{
					m_Points[i].X = (m_Points[i].X - x) * num + x;
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Annotation Polygon";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotAnnotationPolygonEditorPlugIn";
		}

		public PlotAnnotationPolygon()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Points = new PointDoubleCollection(ComponentBase);
			Points.Changed += Points_Changed;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Polygon";
		}

		private bool ShouldSerializePoints()
		{
			return Points.Count != 0;
		}

		private void ResetPoints()
		{
			Points.Clear();
		}

		private bool ShouldSerializeX()
		{
			return false;
		}

		private void ResetX()
		{
		}

		private bool ShouldSerializeY()
		{
			return false;
		}

		private void ResetY()
		{
		}

		private bool ShouldSerializeHeight()
		{
			return false;
		}

		private void ResetHeight()
		{
		}

		private bool ShouldSerializeWidth()
		{
			return false;
		}

		private void ResetWidth()
		{
		}

		protected override void SetXAndWidth(double x, double width)
		{
			double left = base.Left;
			double num = width / Width;
			double num2 = x - X;
			for (int i = 0; i < m_Points.Count; i++)
			{
				m_Points[i].X = (m_Points[i].X - left) * num + left + num2;
			}
		}

		protected override void SetYAndHeight(double y, double height)
		{
			double top = base.Top;
			double num = height / Height;
			double num2 = y - Y;
			for (int i = 0; i < m_Points.Count; i++)
			{
				m_Points[i].Y = (m_Points[i].Y - top) * num + top + num2;
			}
		}

		protected override void DragX(double original, double delta)
		{
			for (int i = 0; i < m_Points.Count; i++)
			{
				m_Points[i].X = m_PointsCached[i].X + delta;
			}
		}

		protected override void DragY(double original, double delta)
		{
			for (int i = 0; i < m_Points.Count; i++)
			{
				m_Points[i].Y = m_PointsCached[i].Y + delta;
			}
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			base.InternalOnMouseLeft(e, shouldFocus);
			m_PointsCached = new PointDoubleCollection(null);
			for (int i = 0; i < m_Points.Count; i++)
			{
				PointDouble pointDouble = new PointDouble();
				pointDouble.X = m_Points[i].X;
				pointDouble.Y = m_Points[i].Y;
				m_PointsCached.Add(pointDouble);
			}
		}

		private void Points_Changed(object sender, EventArgs e)
		{
			base.DoPropertyChange(this, "PointsChanged");
		}

		protected override void DrawCustom(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			if (m_Points.Count >= 2)
			{
				Point[] array = new Point[m_Points.Count];
				for (int i = 0; i < m_Points.Count; i++)
				{
					if (!base.XYSwapped)
					{
						array[i] = new Point(base.GetXPixels(m_Points[i].X), base.GetYPixels(m_Points[i].Y));
					}
					else
					{
						array[i] = new Point(base.GetYPixels(m_Points[i].Y), base.GetXPixels(m_Points[i].X));
					}
				}
				Rectangle rectangle = iRectangle.FromLTRB(base.XYSwapped, base.XMinPixels, base.YMinPixels, base.XMaxPixels, base.YMaxPixels);
				if (!base.BoundsClip.IntersectsWith(rectangle))
				{
					base.ClickRegion = null;
				}
				else
				{
					base.ClickRegion = new Region(rectangle);
					base.UpdateGrabHandles(rectangle);
					base.I_Fill.Draw(p, array, rectangle);
				}
			}
		}
	}
}
