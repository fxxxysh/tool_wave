using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public sealed class AnnotationLine : AnnotationOutline
	{
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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
			return "Iocomp.Design.AnnotationLineEditorPlugIn";
		}

		public AnnotationLine()
		{
			base.DoCreate();
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

		protected override void DrawOutline(PaintArgs p, Rectangle rect, Point[] points)
		{
			Point pt = new Point(Scale.ConvertUnitsToPixelsX(Point1X), Scale.ConvertUnitsToPixelsY(Point1Y));
			Point pt2 = new Point(Scale.ConvertUnitsToPixelsX(Point2X), Scale.ConvertUnitsToPixelsY(Point2Y));
			p.Graphics.DrawLine(p.Graphics.Pen(base.OutlineColor, base.DashStyle), pt, pt2);
		}

		protected override void DrawCustom(PaintArgs p)
		{
			Rectangle r = new Rectangle(Scale.ConvertUnitsToPixelsX(base.Left), Scale.ConvertUnitsToPixelsY(base.Top), Scale.ConvertWidthUnitsToPixels(Width), Scale.ConvertHeightUnitsToPixels(Height));
			base.ClickRegion = ToClickRegion(r);
			base.UpdateGrabHandles(r);
			if (base.OutlineStyle != AnnotationOutlineStyle.Clear)
			{
				DrawOutline(p, r, null);
			}
		}

		public override string ToString()
		{
			return "Annotation Line";
		}
	}
}
