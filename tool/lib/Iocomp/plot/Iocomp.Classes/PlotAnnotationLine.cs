using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public class PlotAnnotationLine : PlotAnnotationOutlineBase
	{
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double Point1X
		{
			get
			{
				return X - Width / 2.0;
			}
			set
			{
				if (Point1X != value)
				{
					double point2X = Point2X;
					Width = point2X - value;
					X = (point2X + value) / 2.0;
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double Point2X
		{
			get
			{
				return X + Width / 2.0;
			}
			set
			{
				if (Point2X != value)
				{
					double point1X = Point1X;
					Width = value - point1X;
					X = (point1X + value) / 2.0;
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double Point1Y
		{
			get
			{
				return Y - Height / 2.0;
			}
			set
			{
				if (Point1Y != value)
				{
					double point2Y = Point2Y;
					Height = point2Y - value;
					Y = (point2Y + value) / 2.0;
				}
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		public double Point2Y
		{
			get
			{
				return Y + Height / 2.0;
			}
			set
			{
				if (Point2Y != value)
				{
					double point1Y = Point1Y;
					Height = value - point1Y;
					Y = (point1Y + value) / 2.0;
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Annotation Line";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotAnnotationLineEditorPlugIn";
		}

		public PlotAnnotationLine()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Line";
		}

		private bool ShouldSerializePoint1X()
		{
			if (!base.PropertyShouldSerialize("X"))
			{
				return base.PropertyShouldSerialize("Width");
			}
			return true;
		}

		private bool ShouldSerializePoint2X()
		{
			if (!base.PropertyShouldSerialize("X"))
			{
				return base.PropertyShouldSerialize("Width");
			}
			return true;
		}

		private bool ShouldSerializePoint1Y()
		{
			if (!base.PropertyShouldSerialize("Y"))
			{
				return base.PropertyShouldSerialize("Height");
			}
			return true;
		}

		private bool ShouldSerializePoint2Y()
		{
			if (!base.PropertyShouldSerialize("Y"))
			{
				return base.PropertyShouldSerialize("Height");
			}
			return true;
		}

		protected override void DrawCustom(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			Rectangle rectangle = iRectangle.FromLTRB(base.XYSwapped, base.XMinPixels, base.YMinPixels, base.XMaxPixels, base.YMaxPixels);
			if (!base.BoundsClip.IntersectsWith(rectangle))
			{
				base.ClickRegion = null;
			}
			else
			{
				base.ClickRegion = new Region(rectangle);
				base.UpdateGrabHandles(rectangle);
				if (!base.XYSwapped)
				{
					base.I_Pen.DrawLine(p, new Point(base.GetXPixels(Point1X), base.GetYPixels(Point1Y)), new Point(base.GetXPixels(Point2X), base.GetYPixels(Point2Y)));
				}
				else
				{
					base.I_Pen.DrawLine(p, new Point(base.GetYPixels(Point1Y), base.GetXPixels(Point1X)), new Point(base.GetYPixels(Point2Y), base.GetXPixels(Point2X)));
				}
			}
		}
	}
}
