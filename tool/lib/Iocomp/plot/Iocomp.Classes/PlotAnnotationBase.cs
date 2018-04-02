using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public abstract class PlotAnnotationBase : PlotXYAxisReferenceBase
	{
		private bool m_UserCanMove;

		private bool m_UserCanSize;

		private double m_Rotation;

		private Region m_ClickRegion;

		private GrabHandle[] m_GrabHandles;

		private double m_MouseDownUnitsX;

		private double m_MouseDownUnitsY;

		private int m_MouseDownXPixels;

		private int m_MouseDownYPixels;

		private double m_MouseDownX;

		private double m_MouseDownY;

		private double m_MouseDownLeft;

		private double m_MouseDownTop;

		private double m_MouseDownRight;

		private double m_MouseDownBottom;

		private double m_MouseDownWidth;

		private double m_MouseDownHeight;

		private EditMode m_MouseDownEditMode;

		private double m_Width;

		private double m_Height;

		private double m_X;

		private double m_Y;

		private PlotUnitType m_UnitTypeAll;

		private PlotUnitType m_UnitTypeLocation;

		private PlotUnitType m_UnitTypeSize;

		private PlotUnitType m_UnitTypeX;

		private PlotUnitType m_UnitTypeY;

		private PlotUnitType m_UnitTypeWidth;

		private PlotUnitType m_UnitTypeHeight;

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public double Rotation
		{
			get
			{
				return m_Rotation;
			}
			set
			{
				base.PropertyUpdateDefault("Rotation", value);
				if (Rotation != value)
				{
					m_Rotation = value;
					base.DoPropertyChange(this, "Rotation");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public bool UserCanMove
		{
			get
			{
				return m_UserCanMove;
			}
			set
			{
				base.PropertyUpdateDefault("UserCanMove", value);
				if (UserCanMove != value)
				{
					m_UserCanMove = value;
					base.DoPropertyChange(this, "UserCanMove");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public bool UserCanSize
		{
			get
			{
				return m_UserCanSize;
			}
			set
			{
				base.PropertyUpdateDefault("UserCanSize", value);
				if (UserCanSize != value)
				{
					m_UserCanSize = value;
					base.DoPropertyChange(this, "UserCanSize");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public virtual double Width
		{
			get
			{
				return m_Width;
			}
			set
			{
				base.PropertyUpdateDefault("Width", value);
				if (Width != value)
				{
					m_Width = value;
					base.DoPropertyChange(this, "Width");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public virtual double Height
		{
			get
			{
				return m_Height;
			}
			set
			{
				base.PropertyUpdateDefault("Height", value);
				if (Height != value)
				{
					m_Height = value;
					base.DoPropertyChange(this, "Height");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public virtual double X
		{
			get
			{
				return m_X;
			}
			set
			{
				base.PropertyUpdateDefault("X", value);
				if (X != value)
				{
					m_X = value;
					base.DoPropertyChange(this, "X");
				}
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public virtual double Y
		{
			get
			{
				return m_Y;
			}
			set
			{
				base.PropertyUpdateDefault("Y", value);
				if (Y != value)
				{
					m_Y = value;
					base.DoPropertyChange(this, "Y");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public PlotUnitType UnitTypeAll
		{
			get
			{
				return m_UnitTypeAll;
			}
			set
			{
				base.PropertyUpdateDefault("UnitTypeAll", value);
				if (UnitTypeAll != value)
				{
					m_UnitTypeAll = value;
					base.DoPropertyChange(this, "UnitTypeAll");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public PlotUnitType UnitTypeLocation
		{
			get
			{
				return m_UnitTypeLocation;
			}
			set
			{
				base.PropertyUpdateDefault("UnitTypeLocation", value);
				if (UnitTypeLocation != value)
				{
					m_UnitTypeLocation = value;
					base.DoPropertyChange(this, "UnitTypeLocation");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public PlotUnitType UnitTypeSize
		{
			get
			{
				return m_UnitTypeSize;
			}
			set
			{
				base.PropertyUpdateDefault("UnitTypeSize", value);
				if (UnitTypeSize != value)
				{
					m_UnitTypeSize = value;
					base.DoPropertyChange(this, "UnitTypeSize");
				}
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotUnitType UnitTypeX
		{
			get
			{
				return m_UnitTypeX;
			}
			set
			{
				base.PropertyUpdateDefault("UnitTypeX", value);
				if (UnitTypeX != value)
				{
					m_UnitTypeX = value;
					base.DoPropertyChange(this, "UnitTypeX");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public PlotUnitType UnitTypeY
		{
			get
			{
				return m_UnitTypeY;
			}
			set
			{
				base.PropertyUpdateDefault("UnitTypeY", value);
				if (UnitTypeY != value)
				{
					m_UnitTypeY = value;
					base.DoPropertyChange(this, "UnitTypeY");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public PlotUnitType UnitTypeWidth
		{
			get
			{
				return m_UnitTypeWidth;
			}
			set
			{
				base.PropertyUpdateDefault("UnitTypeWidth", value);
				if (UnitTypeWidth != value)
				{
					m_UnitTypeWidth = value;
					base.DoPropertyChange(this, "UnitTypeWidth");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotUnitType UnitTypeHeight
		{
			get
			{
				return m_UnitTypeHeight;
			}
			set
			{
				base.PropertyUpdateDefault("UnitTypeHeight", value);
				if (UnitTypeHeight != value)
				{
					m_UnitTypeHeight = value;
					base.DoPropertyChange(this, "UnitTypeHeight");
				}
			}
		}

		private Color SolidColor => base.Color;

		private Color HatchForeColor => base.Color;

		private Color HatchBackColor
		{
			get
			{
				if (ControlBase != null)
				{
					return ControlBase.BackColor;
				}
				return Color.Empty;
			}
		}

		protected Region ClickRegion
		{
			get
			{
				return m_ClickRegion;
			}
			set
			{
				if (m_ClickRegion != value)
				{
					if (m_ClickRegion != null)
					{
						m_ClickRegion.Dispose();
					}
					m_ClickRegion = value;
				}
			}
		}

		private GrabHandle[] GrabHandles
		{
			get
			{
				if (m_GrabHandles != null)
				{
					return m_GrabHandles;
				}
				m_GrabHandles = new GrabHandle[8];
				for (int i = 0; i < m_GrabHandles.Length; i++)
				{
					m_GrabHandles[i] = new GrabHandle();
					m_GrabHandles[i].Rectangle = Rectangle.Empty;
					m_GrabHandles[i].Enabled = true;
				}
				return m_GrabHandles;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public double Left
		{
			get
			{
				return XValue - WidthValue / 2.0;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public double Top
		{
			get
			{
				return YValue + HeightValue / 2.0;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public double Right
		{
			get
			{
				return XValue + WidthValue / 2.0;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public double Bottom
		{
			get
			{
				return YValue - HeightValue / 2.0;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public double XMin
		{
			get
			{
				return X - Width / 2.0;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public double XMax
		{
			get
			{
				return X + Width / 2.0;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public double YMin
		{
			get
			{
				return Y - Height / 2.0;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public double YMax
		{
			get
			{
				return Y + Height / 2.0;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public PlotUnitType ActualUnitTypeAll
		{
			get
			{
				if (m_UnitTypeAll == PlotUnitType.Value)
				{
					return PlotUnitType.Value;
				}
				if (m_UnitTypeAll == PlotUnitType.Percent)
				{
					return PlotUnitType.Percent;
				}
				if (m_UnitTypeAll == PlotUnitType.Pixel)
				{
					return PlotUnitType.Pixel;
				}
				return PlotUnitType.Value;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public PlotUnitType ActualUnitTypeLocation
		{
			get
			{
				if (m_UnitTypeLocation == PlotUnitType.Value)
				{
					return PlotUnitType.Value;
				}
				if (m_UnitTypeLocation == PlotUnitType.Percent)
				{
					return PlotUnitType.Percent;
				}
				if (m_UnitTypeLocation == PlotUnitType.Pixel)
				{
					return PlotUnitType.Pixel;
				}
				return ActualUnitTypeAll;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public PlotUnitType ActualUnitTypeSize
		{
			get
			{
				if (m_UnitTypeSize == PlotUnitType.Value)
				{
					return PlotUnitType.Value;
				}
				if (m_UnitTypeSize == PlotUnitType.Percent)
				{
					return PlotUnitType.Percent;
				}
				if (m_UnitTypeSize == PlotUnitType.Pixel)
				{
					return PlotUnitType.Pixel;
				}
				return ActualUnitTypeAll;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public PlotUnitType ActualUnitTypeX
		{
			get
			{
				if (m_UnitTypeX == PlotUnitType.Value)
				{
					return PlotUnitType.Value;
				}
				if (m_UnitTypeX == PlotUnitType.Percent)
				{
					return PlotUnitType.Percent;
				}
				if (m_UnitTypeX == PlotUnitType.Pixel)
				{
					return PlotUnitType.Pixel;
				}
				return ActualUnitTypeLocation;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public PlotUnitType ActualUnitTypeY
		{
			get
			{
				if (m_UnitTypeY == PlotUnitType.Value)
				{
					return PlotUnitType.Value;
				}
				if (m_UnitTypeY == PlotUnitType.Percent)
				{
					return PlotUnitType.Percent;
				}
				if (m_UnitTypeY == PlotUnitType.Pixel)
				{
					return PlotUnitType.Pixel;
				}
				return ActualUnitTypeLocation;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public PlotUnitType ActualUnitTypeWidth
		{
			get
			{
				if (m_UnitTypeWidth == PlotUnitType.Value)
				{
					return PlotUnitType.Value;
				}
				if (m_UnitTypeWidth == PlotUnitType.Percent)
				{
					return PlotUnitType.Percent;
				}
				if (m_UnitTypeWidth == PlotUnitType.Pixel)
				{
					return PlotUnitType.Pixel;
				}
				return ActualUnitTypeSize;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public PlotUnitType ActualUnitTypeHeight
		{
			get
			{
				if (m_UnitTypeHeight == PlotUnitType.Value)
				{
					return PlotUnitType.Value;
				}
				if (m_UnitTypeHeight == PlotUnitType.Percent)
				{
					return PlotUnitType.Percent;
				}
				if (m_UnitTypeHeight == PlotUnitType.Pixel)
				{
					return PlotUnitType.Pixel;
				}
				return ActualUnitTypeSize;
			}
		}

		protected GrabHandle GrabHandle0 => GrabHandles[0];

		protected GrabHandle GrabHandle1 => GrabHandles[1];

		protected GrabHandle GrabHandle2 => GrabHandles[2];

		protected GrabHandle GrabHandle3 => GrabHandles[3];

		protected GrabHandle GrabHandle4 => GrabHandles[4];

		protected GrabHandle GrabHandle5 => GrabHandles[5];

		protected GrabHandle GrabHandle6 => GrabHandles[6];

		protected GrabHandle GrabHandle7 => GrabHandles[7];

		protected double XValue
		{
			get
			{
				if (ActualUnitTypeX == PlotUnitType.Percent)
				{
					return base.XAxis.PercentToValue(X);
				}
				if (ActualUnitTypeX == PlotUnitType.Pixel)
				{
					return base.XAxis.PixelsToValue((int)X);
				}
				return X;
			}
		}

		protected double YValue
		{
			get
			{
				if (ActualUnitTypeY == PlotUnitType.Percent)
				{
					return base.YAxis.PercentToValue(Y);
				}
				if (ActualUnitTypeY == PlotUnitType.Pixel)
				{
					return base.YAxis.PixelsToValue((int)Y);
				}
				return Y;
			}
		}

		protected double XPercent
		{
			get
			{
				if (ActualUnitTypeX == PlotUnitType.Value)
				{
					return base.XAxis.ValueToPercent(X);
				}
				if (ActualUnitTypeX == PlotUnitType.Pixel)
				{
					return base.XAxis.PixelsToPercent((int)X);
				}
				return X;
			}
		}

		protected double YPercent
		{
			get
			{
				if (ActualUnitTypeY == PlotUnitType.Value)
				{
					return base.YAxis.ValueToPercent(Y);
				}
				if (ActualUnitTypeY == PlotUnitType.Pixel)
				{
					return base.YAxis.PixelsToPercent((int)Y);
				}
				return Y;
			}
		}

		protected int XPixels
		{
			get
			{
				if (ActualUnitTypeX == PlotUnitType.Value)
				{
					return base.XAxis.ValueToPixels(X);
				}
				if (ActualUnitTypeX == PlotUnitType.Percent)
				{
					return base.XAxis.PercentToPixels(X);
				}
				return (int)X;
			}
		}

		protected int YPixels
		{
			get
			{
				if (ActualUnitTypeY == PlotUnitType.Value)
				{
					return base.YAxis.ValueToPixels(Y);
				}
				if (ActualUnitTypeY == PlotUnitType.Percent)
				{
					return base.YAxis.PercentToPixels(Y);
				}
				return (int)Y;
			}
		}

		protected double WidthValue
		{
			get
			{
				if (ActualUnitTypeWidth == PlotUnitType.Percent)
				{
					return base.XAxis.PercentSpanToValue(Width);
				}
				if (ActualUnitTypeWidth == PlotUnitType.Pixel)
				{
					return base.XAxis.PixelSpanToValue((int)Width);
				}
				return Width;
			}
		}

		protected double HeightValue
		{
			get
			{
				if (ActualUnitTypeHeight == PlotUnitType.Percent)
				{
					return base.YAxis.PercentSpanToValue(Height);
				}
				if (ActualUnitTypeHeight == PlotUnitType.Pixel)
				{
					return base.YAxis.PixelSpanToValue((int)Height);
				}
				return (double)(int)Height;
			}
		}

		protected double WidthPercent
		{
			get
			{
				if (ActualUnitTypeWidth == PlotUnitType.Value)
				{
					return base.XAxis.ValueSpanToPercent(Width);
				}
				if (ActualUnitTypeWidth == PlotUnitType.Pixel)
				{
					return base.XAxis.PixelSpanToPercent((int)Width);
				}
				return Width;
			}
		}

		protected double HeightPercent
		{
			get
			{
				if (ActualUnitTypeHeight == PlotUnitType.Value)
				{
					return base.YAxis.ValueSpanToPercent(Height);
				}
				if (ActualUnitTypeHeight == PlotUnitType.Pixel)
				{
					return base.YAxis.PixelSpanToPercent((int)Height);
				}
				return (double)(int)Height;
			}
		}

		protected int WidthPixels
		{
			get
			{
				if (ActualUnitTypeWidth == PlotUnitType.Value)
				{
					return base.XAxis.ValueToSpanPixels(Width);
				}
				if (ActualUnitTypeWidth == PlotUnitType.Percent)
				{
					return base.XAxis.PercentToSpanPixels(Width);
				}
				return (int)Width;
			}
		}

		protected int HeightPixels
		{
			get
			{
				if (ActualUnitTypeHeight == PlotUnitType.Value)
				{
					return base.YAxis.ValueToSpanPixels(Height);
				}
				if (ActualUnitTypeHeight == PlotUnitType.Percent)
				{
					return base.YAxis.PercentToSpanPixels(Height);
				}
				return (int)Height;
			}
		}

		protected int XMinPixels
		{
			get
			{
				if (ActualUnitTypeX == ActualUnitTypeWidth)
				{
					if (ActualUnitTypeX == PlotUnitType.Value)
					{
						return base.XAxis.ValueToPixels(XMin);
					}
					if (ActualUnitTypeX == PlotUnitType.Percent)
					{
						return base.XAxis.PercentToPixels(XMin);
					}
					return (int)XMin;
				}
				return XPixels - WidthPixels / 2;
			}
		}

		protected int XMaxPixels
		{
			get
			{
				if (ActualUnitTypeX == ActualUnitTypeWidth)
				{
					if (ActualUnitTypeX == PlotUnitType.Value)
					{
						return base.XAxis.ValueToPixels(XMax);
					}
					if (ActualUnitTypeX == PlotUnitType.Percent)
					{
						return base.XAxis.PercentToPixels(XMax);
					}
					return (int)XMax;
				}
				return XPixels + WidthPixels / 2;
			}
		}

		protected int YMinPixels
		{
			get
			{
				if (ActualUnitTypeY == ActualUnitTypeHeight)
				{
					if (ActualUnitTypeY == PlotUnitType.Value)
					{
						return base.YAxis.ValueToPixels(YMax);
					}
					if (ActualUnitTypeY == PlotUnitType.Percent)
					{
						return base.YAxis.PercentToPixels(YMax);
					}
					return (int)YMax;
				}
				return YPixels - HeightPixels / 2;
			}
		}

		protected int YMaxPixels
		{
			get
			{
				if (ActualUnitTypeY == ActualUnitTypeHeight)
				{
					if (ActualUnitTypeY == PlotUnitType.Value)
					{
						return base.YAxis.ValueToPixels(YMin);
					}
					if (ActualUnitTypeY == PlotUnitType.Percent)
					{
						return base.YAxis.PercentToPixels(YMin);
					}
					return (int)YMin;
				}
				return YPixels + HeightPixels / 2;
			}
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Visible = true;
			base.Enabled = false;
			Rotation = 0.0;
			UserCanMove = false;
			UserCanSize = false;
			Width = 10.0;
			Height = 10.0;
			base.Color = Color.Empty;
			X = 50.0;
			Y = 50.0;
			UnitTypeAll = PlotUnitType.Auto;
			UnitTypeLocation = PlotUnitType.Auto;
			UnitTypeSize = PlotUnitType.Auto;
			UnitTypeX = PlotUnitType.Auto;
			UnitTypeY = PlotUnitType.Auto;
			UnitTypeWidth = PlotUnitType.Auto;
			UnitTypeHeight = PlotUnitType.Auto;
		}

		private bool ShouldSerializeRotation()
		{
			return base.PropertyShouldSerialize("Rotation");
		}

		private void ResetRotation()
		{
			base.PropertyReset("Rotation");
		}

		private bool ShouldSerializeUserCanMove()
		{
			return base.PropertyShouldSerialize("UserCanMove");
		}

		private void ResetUserCanMove()
		{
			base.PropertyReset("UserCanMove");
		}

		private bool ShouldSerializeUserCanSize()
		{
			return base.PropertyShouldSerialize("UserCanSize");
		}

		private void ResetUserCanSize()
		{
			base.PropertyReset("UserCanSize");
		}

		private bool ShouldSerializeWidth()
		{
			return base.PropertyShouldSerialize("Width");
		}

		private void ResetWidth()
		{
			base.PropertyReset("Width");
		}

		private bool ShouldSerializeHeight()
		{
			return base.PropertyShouldSerialize("Height");
		}

		private void ResetHeight()
		{
			base.PropertyReset("Height");
		}

		private bool ShouldSerializeX()
		{
			return base.PropertyShouldSerialize("X");
		}

		private void ResetX()
		{
			base.PropertyReset("X");
		}

		private bool ShouldSerializeY()
		{
			return base.PropertyShouldSerialize("Y");
		}

		private void ResetY()
		{
			base.PropertyReset("Y");
		}

		private bool ShouldSerializeUnitTypeAll()
		{
			return base.PropertyShouldSerialize("UnitTypeAll");
		}

		private void ResetUnitTypeAll()
		{
			base.PropertyReset("UnitTypeAll");
		}

		private bool ShouldSerializeUnitTypeLocation()
		{
			return base.PropertyShouldSerialize("UnitTypeLocation");
		}

		private void ResetUnitTypeLocation()
		{
			base.PropertyReset("UnitTypeLocation");
		}

		private bool ShouldSerializeUnitTypeSize()
		{
			return base.PropertyShouldSerialize("UnitTypeSize");
		}

		private void ResetUnitTypeSize()
		{
			base.PropertyReset("UnitTypeSize");
		}

		private bool ShouldSerializeUnitTypeX()
		{
			return base.PropertyShouldSerialize("UnitTypeX");
		}

		private void ResetUnitTypeX()
		{
			base.PropertyReset("UnitTypeX");
		}

		private bool ShouldSerializeUnitTypeY()
		{
			return base.PropertyShouldSerialize("UnitTypeY");
		}

		private void ResetUnitTypeY()
		{
			base.PropertyReset("UnitTypeY");
		}

		private bool ShouldSerializeUnitTypeWidth()
		{
			return base.PropertyShouldSerialize("UnitTypeWidth");
		}

		private void ResetUnitTypeWidth()
		{
			base.PropertyReset("UnitTypeWidth");
		}

		private bool ShouldSerializeUnitTypeHeight()
		{
			return base.PropertyShouldSerialize("UnitTypeHeight");
		}

		private void ResetUnitTypeHeight()
		{
			base.PropertyReset("UnitTypeHeight");
		}

		protected int GetXPixels(double value)
		{
			if (ActualUnitTypeX == PlotUnitType.Value)
			{
				return base.XAxis.ValueToPixels(value);
			}
			if (ActualUnitTypeX == PlotUnitType.Percent)
			{
				return base.XAxis.PercentToPixels(value);
			}
			return (int)value;
		}

		protected int GetYPixels(double value)
		{
			if (ActualUnitTypeY == PlotUnitType.Value)
			{
				return base.YAxis.ValueToPixels(value);
			}
			if (ActualUnitTypeY == PlotUnitType.Percent)
			{
				return base.YAxis.PercentToPixels(value);
			}
			return (int)value;
		}

		protected double GetXFromValueUnits(double value)
		{
			if (ActualUnitTypeX == PlotUnitType.Percent)
			{
				return base.XAxis.ValueToPercent(value);
			}
			if (ActualUnitTypeX == PlotUnitType.Pixel)
			{
				return (double)base.XAxis.ValueToPixels(value);
			}
			return value;
		}

		protected double GetYFromValueUnits(double value)
		{
			if (ActualUnitTypeY == PlotUnitType.Percent)
			{
				return base.YAxis.ValueToPercent(value);
			}
			if (ActualUnitTypeY == PlotUnitType.Pixel)
			{
				return (double)base.YAxis.ValueToPixels(value);
			}
			return value;
		}

		protected double GetWidthFromValueUnits(double value)
		{
			if (ActualUnitTypeWidth == PlotUnitType.Percent)
			{
				return base.XAxis.ValueSpanToPercent(value);
			}
			if (ActualUnitTypeWidth == PlotUnitType.Pixel)
			{
				return (double)base.XAxis.ValueToSpanPixels(value);
			}
			return value;
		}

		protected double GetHeightFromValueUnits(double value)
		{
			if (ActualUnitTypeHeight == PlotUnitType.Percent)
			{
				return base.YAxis.ValueSpanToPercent(value);
			}
			if (ActualUnitTypeHeight == PlotUnitType.Pixel)
			{
				return (double)base.YAxis.ValueToSpanPixels(value);
			}
			return value;
		}

		protected double ConvertPixelsToX(int value)
		{
			if (ActualUnitTypeX == PlotUnitType.Value)
			{
				return base.XAxis.PixelsToValue(value);
			}
			if (ActualUnitTypeX == PlotUnitType.Percent)
			{
				return base.XAxis.PixelsToPercent(value);
			}
			return (double)value;
		}

		protected double ConvertPixelsToY(int value)
		{
			if (ActualUnitTypeY == PlotUnitType.Value)
			{
				return base.YAxis.PixelsToValue(value);
			}
			if (ActualUnitTypeY == PlotUnitType.Percent)
			{
				return base.YAxis.PixelsToPercent(value);
			}
			return (double)value;
		}

		protected double ConvertPixelsToWidth(int value)
		{
			if (ActualUnitTypeWidth == PlotUnitType.Value)
			{
				return base.XAxis.PixelsToValue(value);
			}
			if (ActualUnitTypeWidth == PlotUnitType.Percent)
			{
				return base.XAxis.PixelsToPercent(value);
			}
			return (double)value;
		}

		protected double ConvertPixelsToHeight(int value)
		{
			if (ActualUnitTypeHeight == PlotUnitType.Value)
			{
				return base.YAxis.PixelsToValue(value);
			}
			if (ActualUnitTypeHeight == PlotUnitType.Percent)
			{
				return base.YAxis.PixelsToPercent(value);
			}
			return (double)value;
		}

		protected virtual void SetXAndWidth(double x, double width)
		{
			X = x;
			Width = width;
		}

		protected virtual void SetYAndHeight(double y, double height)
		{
			Y = y;
			Height = height;
		}

		protected virtual void DragX(double original, double delta)
		{
			X = original + delta;
		}

		protected virtual void DragY(double original, double delta)
		{
			Y = original + delta;
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			base.InternalOnMouseLeft(e, shouldFocus);
			if (base.Enabled)
			{
				int num;
				int num2;
				if (base.XYSwapped)
				{
					num = e.Y;
					num2 = e.X;
				}
				else
				{
					num = e.X;
					num2 = e.Y;
				}
				m_MouseDownEditMode = GetEditMode(e);
				ControlBase.Cursor = GetCursor(m_MouseDownEditMode);
				m_MouseDownXPixels = num;
				m_MouseDownYPixels = num2;
				m_MouseDownUnitsX = ConvertPixelsToX(num);
				m_MouseDownUnitsY = ConvertPixelsToY(num2);
				m_MouseDownX = X;
				m_MouseDownY = Y;
				m_MouseDownLeft = Left;
				m_MouseDownTop = Top;
				m_MouseDownRight = Right;
				m_MouseDownBottom = Bottom;
				m_MouseDownHeight = HeightValue;
				m_MouseDownWidth = WidthValue;
				base.IsMouseActive = true;
				if (shouldFocus)
				{
					base.Focus();
				}
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			int num;
			int num2;
			if (base.XYSwapped)
			{
				num = e.Y;
				num2 = e.X;
			}
			else
			{
				num = e.X;
				num2 = e.Y;
			}
			bool flag2;
			bool flag3;
			bool flag4;
			int value;
			int value2;
			if (base.IsMouseActive)
			{
				if (m_MouseDownEditMode == EditMode.Move)
				{
					double delta = ConvertPixelsToX(num) - m_MouseDownUnitsX;
					double delta2 = ConvertPixelsToY(num2) - m_MouseDownUnitsY;
					DragX(m_MouseDownX, delta);
					DragY(m_MouseDownY, delta2);
				}
				else if (m_MouseDownEditMode != 0)
				{
					EditMode mouseDownEditMode = m_MouseDownEditMode;
					bool flag;
					if (!base.XYSwapped)
					{
						flag = (mouseDownEditMode == EditMode.Size6 || mouseDownEditMode == EditMode.Size7 || mouseDownEditMode == EditMode.Size0);
						flag2 = (mouseDownEditMode == EditMode.Size2 || mouseDownEditMode == EditMode.Size3 || mouseDownEditMode == EditMode.Size4);
						flag3 = (mouseDownEditMode == EditMode.Size0 || mouseDownEditMode == EditMode.Size1 || mouseDownEditMode == EditMode.Size2);
						flag4 = (mouseDownEditMode == EditMode.Size4 || mouseDownEditMode == EditMode.Size5 || mouseDownEditMode == EditMode.Size6);
					}
					else
					{
						flag = (mouseDownEditMode == EditMode.Size6 || mouseDownEditMode == EditMode.Size5 || mouseDownEditMode == EditMode.Size4);
						flag2 = (mouseDownEditMode == EditMode.Size0 || mouseDownEditMode == EditMode.Size1 || mouseDownEditMode == EditMode.Size2);
						flag3 = (mouseDownEditMode == EditMode.Size2 || mouseDownEditMode == EditMode.Size3 || mouseDownEditMode == EditMode.Size4);
						flag4 = (mouseDownEditMode == EditMode.Size0 || mouseDownEditMode == EditMode.Size7 || mouseDownEditMode == EditMode.Size6);
					}
					if (base.XAxis.ScaleRange.Reverse)
					{
						Math2.Switch(ref flag, ref flag2);
					}
					if (base.YAxis.ScaleRange.Reverse)
					{
						Math2.Switch(ref flag4, ref flag3);
					}
					value = num - m_MouseDownXPixels;
					value2 = num2 - m_MouseDownYPixels;
					if (flag)
					{
						double num3 = (!base.XAxis.ScaleRange.Reverse) ? (m_MouseDownWidth - base.XAxis.PixelSpanToValue(value)) : (m_MouseDownWidth + base.XAxis.PixelSpanToValue(value));
						if (!(num3 < 0.0))
						{
							double value3 = m_MouseDownRight - num3 / 2.0;
							SetXAndWidth(GetXFromValueUnits(value3), GetWidthFromValueUnits(num3));
							goto IL_01fd;
						}
						return;
					}
					goto IL_01fd;
				}
			}
			else if (base.Focused)
			{
				ControlBase.Cursor = GetCursor(GetEditMode(e));
			}
			goto IL_0393;
			IL_02f3:
			if (flag4)
			{
				double num4 = (!base.YAxis.ScaleRange.Reverse) ? (m_MouseDownHeight + base.YAxis.PixelSpanToValue(value2)) : (m_MouseDownHeight - base.YAxis.PixelSpanToValue(value2));
				if (!(num4 < 0.0))
				{
					double value4 = m_MouseDownTop - num4 / 2.0;
					SetYAndHeight(GetYFromValueUnits(value4), GetHeightFromValueUnits(num4));
					goto IL_0393;
				}
				return;
			}
			goto IL_0393;
			IL_0278:
			if (flag3)
			{
				double num4 = (!base.YAxis.ScaleRange.Reverse) ? (m_MouseDownHeight - base.YAxis.PixelSpanToValue(value2)) : (m_MouseDownHeight + base.YAxis.PixelSpanToValue(value2));
				if (!(num4 < 0.0))
				{
					double value4 = m_MouseDownBottom + num4 / 2.0;
					SetYAndHeight(GetYFromValueUnits(value4), GetHeightFromValueUnits(num4));
					goto IL_02f3;
				}
				return;
			}
			goto IL_02f3;
			IL_01fd:
			if (flag2)
			{
				double num3 = (!base.XAxis.ScaleRange.Reverse) ? (m_MouseDownWidth + base.XAxis.PixelSpanToValue(value)) : (m_MouseDownWidth - base.XAxis.PixelSpanToValue(value));
				if (!(num3 < 0.0))
				{
					double value3 = m_MouseDownLeft + num3 / 2.0;
					SetXAndWidth(GetXFromValueUnits(value3), GetWidthFromValueUnits(num3));
					goto IL_0278;
				}
				return;
			}
			goto IL_0278;
			IL_0393:
			base.InternalOnMouseMove(e);
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			base.InternalOnMouseUp(e);
			if (base.IsMouseActive)
			{
				base.Bounds.Contains(e.X, e.Y);
			}
		}

		protected override bool InternalHitTest(MouseEventArgs e)
		{
			if (m_ClickRegion == null)
			{
				return false;
			}
			if (base.Focused)
			{
				for (int i = 0; i < GrabHandles.Length; i++)
				{
					if (GrabHandles[i].Rectangle.Contains(e.X, e.Y))
					{
						return true;
					}
				}
			}
			return m_ClickRegion.IsVisible((float)e.X, (float)e.Y);
		}

		protected override Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			if (base.Plot == null)
			{
				return Cursors.Default;
			}
			return GetCursor(GetEditMode(e));
		}

		protected EditMode GetEditMode(MouseEventArgs e)
		{
			if (UserCanSize && GrabHandle0.Enabled && GrabHandle0.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size0;
			}
			if (UserCanSize && GrabHandle1.Enabled && GrabHandle1.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size1;
			}
			if (UserCanSize && GrabHandle2.Enabled && GrabHandle2.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size2;
			}
			if (UserCanSize && GrabHandle3.Enabled && GrabHandle3.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size3;
			}
			if (UserCanSize && GrabHandle4.Enabled && GrabHandle4.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size4;
			}
			if (UserCanSize && GrabHandle5.Enabled && GrabHandle5.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size5;
			}
			if (UserCanSize && GrabHandle6.Enabled && GrabHandle6.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size6;
			}
			if (UserCanSize && GrabHandle7.Enabled && GrabHandle7.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size7;
			}
			if (UserCanMove)
			{
				return EditMode.Move;
			}
			return EditMode.None;
		}

		protected Cursor GetCursor(EditMode editMode)
		{
			switch (editMode)
			{
			case EditMode.Size0:
				return Cursors.SizeNWSE;
			case EditMode.Size1:
				return Cursors.SizeNS;
			case EditMode.Size2:
				return Cursors.SizeNESW;
			case EditMode.Size3:
				return Cursors.SizeWE;
			case EditMode.Size4:
				return Cursors.SizeNWSE;
			case EditMode.Size5:
				return Cursors.SizeNS;
			case EditMode.Size6:
				return Cursors.SizeNESW;
			case EditMode.Size7:
				return Cursors.SizeWE;
			case EditMode.Move:
				return Cursors.SizeAll;
			default:
				return Cursors.Default;
			}
		}

		protected void UpdateGrabHandles(Rectangle r)
		{
			int num = (r.Left + r.Right) / 2;
			int num2 = (r.Top + r.Bottom) / 2;
			if (Rotation == 0.0)
			{
				GrabHandle0.Rectangle = CalcGrabRect(new Point(r.Left, r.Top));
				GrabHandle1.Rectangle = CalcGrabRect(new Point(num, r.Top));
				GrabHandle2.Rectangle = CalcGrabRect(new Point(r.Right, r.Top));
				GrabHandle3.Rectangle = CalcGrabRect(new Point(r.Right, num2));
				GrabHandle4.Rectangle = CalcGrabRect(new Point(r.Right, r.Bottom));
				GrabHandle5.Rectangle = CalcGrabRect(new Point(num, r.Bottom));
				GrabHandle6.Rectangle = CalcGrabRect(new Point(r.Left, r.Bottom));
				GrabHandle7.Rectangle = CalcGrabRect(new Point(r.Left, num2));
			}
			else
			{
				int num3 = r.Width / 2;
				int num4 = r.Height / 2;
				double num5 = Math.Atan2((double)num4, (double)num3) * 360.0 / 6.2831853071795862;
				double radius = Math.Sqrt((double)(num3 * num3 + num4 * num4));
				GrabHandle0.Rectangle = CalcGrabRect(Math2.ToRotatedPoint(180.0 + num5 + Rotation, radius, (double)num, (double)num2));
				GrabHandle1.Rectangle = CalcGrabRect(Math2.ToRotatedPoint(270.0 + Rotation, (double)num4, (double)num, (double)num2));
				GrabHandle2.Rectangle = CalcGrabRect(Math2.ToRotatedPoint(0.0 - num5 + Rotation, radius, (double)num, (double)num2));
				GrabHandle3.Rectangle = CalcGrabRect(Math2.ToRotatedPoint(0.0 + Rotation, (double)num3, (double)num, (double)num2));
				GrabHandle4.Rectangle = CalcGrabRect(Math2.ToRotatedPoint(0.0 + num5 + Rotation, radius, (double)num, (double)num2));
				GrabHandle5.Rectangle = CalcGrabRect(Math2.ToRotatedPoint(90.0 + Rotation, (double)num4, (double)num, (double)num2));
				GrabHandle6.Rectangle = CalcGrabRect(Math2.ToRotatedPoint(180.0 - num5 + Rotation, radius, (double)num, (double)num2));
				GrabHandle7.Rectangle = CalcGrabRect(Math2.ToRotatedPoint(180.0 + Rotation, (double)num3, (double)num, (double)num2));
			}
		}

		private Rectangle CalcGrabRect(Point point)
		{
			return new Rectangle(point.X - 2, point.Y - 2, 5, 5);
		}

		protected void DrawGrabHandles(PaintArgs p, Color grabHandleDisabledColor)
		{
			if (base.Focused && (ControlBase == null || ControlBase.Focused))
			{
				Color color = Color.White;
				if (ControlBase != null)
				{
					color = ControlBase.BackColor;
				}
				Color color2 = Color.FromArgb(255, color.R ^ 0xFF, color.G ^ 0xFF, color.B ^ 0xFF);
				for (int i = 0; i < GrabHandles.Length; i++)
				{
					Color color3 = (UserCanSize && GrabHandles[i].Enabled) ? color2 : grabHandleDisabledColor;
					p.Graphics.FillRectangle(p.Graphics.Brush(color3), GrabHandles[i].Rectangle);
					p.Graphics.DrawRectangle(p.Graphics.Pen(Color.Red), GrabHandles[i].Rectangle);
				}
			}
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			GrabHandle0.Rectangle = Rectangle.Empty;
			GrabHandle1.Rectangle = Rectangle.Empty;
			GrabHandle2.Rectangle = Rectangle.Empty;
			GrabHandle3.Rectangle = Rectangle.Empty;
			GrabHandle4.Rectangle = Rectangle.Empty;
			GrabHandle5.Rectangle = Rectangle.Empty;
			GrabHandle6.Rectangle = Rectangle.Empty;
			GrabHandle7.Rectangle = Rectangle.Empty;
			Point point = new Point(XPixels, YPixels);
			GraphicsState gstate = p.Graphics.Save();
			p.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			p.Graphics.TranslateTransform((float)point.X, (float)point.Y);
			p.Graphics.RotateTransform((float)Rotation);
			p.Graphics.TranslateTransform((float)(-point.X), (float)(-point.Y));
			DrawCustom(p, xAxis, yAxis);
			p.Graphics.Restore(gstate);
			if (ClickRegion != null)
			{
				Rectangle rectangle = Rectangle.Truncate(ClickRegion.GetBounds(p.Graphics.GraphicsMS));
				if (rectangle.Width <= 0)
				{
					rectangle = new Rectangle(rectangle.Left - 2, rectangle.Top, 4, rectangle.Height);
					ClickRegion = new Region(rectangle);
					base.Bounds = rectangle;
				}
				else if (rectangle.Height <= 0)
				{
					rectangle = new Rectangle(rectangle.Left, rectangle.Top - 2, rectangle.Width, 4);
					ClickRegion = new Region(rectangle);
					base.Bounds = rectangle;
				}
				else
				{
					base.Bounds = rectangle;
				}
			}
		}

		protected override void DrawFocusRectangles(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			if (ClickRegion != null)
			{
				DrawGrabHandles(p, base.Plot.DefaultGridLineColor);
			}
		}

		protected abstract void DrawCustom(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis);

		protected virtual Region ToClickRegion(Rectangle r)
		{
			return new Region(r);
		}
	}
}
