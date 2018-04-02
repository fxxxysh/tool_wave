using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Controls the scale display linear layout properties.")]
	public sealed class ScaleDisplayLinear : ScaleDisplay, IScaleDisplayLinear, IScaleDisplay
	{
		private IScaleRangeLinear I_Range;

		private bool m_AntiAliasEnabled;

		private SideDirection m_Direction;

		private int m_Margin;

		private int m_MaxTickDisplayWidth;

		private StringAlignment m_TextAlignment;

		private TextRotation m_TextRotation;

		private int m_TextOverlapPixels;

		private StackingDimension m_TextStackingDimension;

		private Orientation m_Orientation;

		private int m_ClipLow;

		private int m_ClipHigh;

		private int m_PixelsHigh;

		private int m_PixelsLow;

		Orientation IScaleDisplayLinear.Orientation
		{
			get
			{
				return Orientation;
			}
			set
			{
				Orientation = value;
			}
		}

		int IScaleDisplayLinear.ClipHigh
		{
			get
			{
				return ClipHigh;
			}
		}

		int IScaleDisplayLinear.ClipLow
		{
			get
			{
				return ClipLow;
			}
		}

		int IScaleDisplayLinear.PixelsHigh
		{
			get
			{
				return PixelsHigh;
			}
		}

		int IScaleDisplayLinear.PixelsLow
		{
			get
			{
				return PixelsLow;
			}
		}

		int IScaleDisplayLinear.PixelsMin
		{
			get
			{
				return PixelsMin;
			}
		}

		int IScaleDisplayLinear.PixelsMax
		{
			get
			{
				return PixelsMax;
			}
		}

		int IScaleDisplayLinear.MaxDepth
		{
			get
			{
				return MaxDepth;
			}
		}

		protected override ScaleRange Range
		{
			get
			{
				return base.Range;
			}
			set
			{
				base.Range = value;
				I_Range = (value as IScaleRangeLinear);
			}
		}

		private Orientation Orientation
		{
			get
			{
				return m_Orientation;
			}
			set
			{
				if (m_Orientation != value)
				{
					m_Orientation = value;
					UpdateScaleRangeBounds();
				}
				UpdateTextStackingDimension();
			}
		}

		private int ClipHigh => m_ClipHigh;

		private int ClipLow => m_ClipLow;

		private int PixelsHigh
		{
			get
			{
				return m_PixelsHigh;
			}
			set
			{
				if (m_PixelsHigh != value)
				{
					m_PixelsHigh = value;
					base.Dirty = true;
					UpdateScaleRangeBounds();
				}
			}
		}

		private int PixelsLow
		{
			get
			{
				return m_PixelsLow;
			}
			set
			{
				if (m_PixelsLow != value)
				{
					m_PixelsLow = value;
					base.Dirty = true;
					UpdateScaleRangeBounds();
				}
			}
		}

		[Description("Returns the number of pixels the text overlaps the ends of the scale")]
		public int TextOverlapPixels
		{
			get
			{
				return m_TextOverlapPixels;
			}
		}

		[Description("Indicates whether the Width or the Height of scale text is used in stacking calcualtions")]
		[Browsable(false)]
		public StackingDimension TextStackingDimension
		{
			get
			{
				return m_TextStackingDimension;
			}
		}

		[Description("Returns the pixel value for the Min of the scale")]
		[Browsable(false)]
		public int PixelsMin
		{
			get
			{
				return ValueToPixels(base.ScaleRange.Min);
			}
		}

		[Browsable(false)]
		[Description("Returns the pixel value for the Max of the scale")]
		public int PixelsMax
		{
			get
			{
				return ValueToPixels(base.ScaleRange.Max);
			}
		}

		[Description("Returns the span distance of the scale in pixels")]
		[Browsable(false)]
		public override int PixelsSpan
		{
			get
			{
				return Math.Abs(PixelsMax - PixelsMin);
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool AntiAliasEnabled
		{
			get
			{
				return m_AntiAliasEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("AntiAliasEnabled", value);
				if (AntiAliasEnabled != value)
				{
					m_AntiAliasEnabled = value;
					base.DoPropertyChange(this, "AntiAliasEnabled");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public SideDirection Direction
		{
			get
			{
				return m_Direction;
			}
			set
			{
				base.PropertyUpdateDefault("Direction", value);
				if (Direction != value)
				{
					m_Direction = value;
					base.DoPropertyChange(this, "Direction");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int Margin
		{
			get
			{
				return m_Margin;
			}
			set
			{
				base.PropertyUpdateDefault("Margin", value);
				if (Margin != value)
				{
					m_Margin = value;
					base.DoPropertyChange(this, "Margin");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public TextRotation TextRotation
		{
			get
			{
				return m_TextRotation;
			}
			set
			{
				base.PropertyUpdateDefault("TextRotation", value);
				if (TextRotation != value)
				{
					m_TextRotation = value;
					base.DoPropertyChange(this, "TextRotation");
				}
				UpdateTextStackingDimension();
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public StringAlignment TextAlignment
		{
			get
			{
				return m_TextAlignment;
			}
			set
			{
				base.PropertyUpdateDefault("TextAlignment", value);
				if (TextAlignment != value)
				{
					m_TextAlignment = value;
					base.DoPropertyChange(this, "TextAlignment");
				}
			}
		}

		private int MaxDepth
		{
			get
			{
				if (!base.Visible)
				{
					return 0;
				}
				return m_MaxTickDisplayWidth;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Scale Display";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleDisplayLinearEditorPlugIn";
		}

		void IScaleDisplayLinear.DrawColorBar(PaintArgs p, double start, double stop, Color color)
		{
			DrawColorBar(p, start, stop, color);
		}

		void IScaleDisplayLinear.SetClipEnds(int value1, int value2)
		{
			SetClipEnds(value1, value2);
		}

		void IScaleDisplayLinear.SetBoundsEnds(int value1, int value2)
		{
			SetBoundsEnds(value1, value2);
		}

		void IScaleDisplayLinear.UpdateScaleBounds()
		{
			UpdateScaleBounds();
		}

		public ScaleDisplayLinear()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Orientation = Orientation.Vertical;
		}

		private void SetClipEnds(int value1, int value2)
		{
			if (value1 < value2)
			{
				m_ClipLow = value1;
				m_ClipHigh = value2;
			}
			else
			{
				m_ClipLow = value2;
				m_ClipHigh = value1;
			}
		}

		private void SetBoundsEnds(int value1, int value2)
		{
			if (value1 < value2)
			{
				m_PixelsLow = value1;
				m_PixelsHigh = value2;
			}
			else
			{
				m_PixelsLow = value2;
				m_PixelsHigh = value1;
			}
			UpdateScaleRangeBounds();
		}

		private void UpdateTextStackingDimension()
		{
			if (Orientation == Orientation.Vertical)
			{
				if (TextRotation == TextRotation.X000 || TextRotation == TextRotation.X180)
				{
					m_TextStackingDimension = StackingDimension.Height;
				}
				else
				{
					m_TextStackingDimension = StackingDimension.Width;
				}
			}
			else if (TextRotation == TextRotation.X000 || TextRotation == TextRotation.X180)
			{
				m_TextStackingDimension = StackingDimension.Width;
			}
			else
			{
				m_TextStackingDimension = StackingDimension.Height;
			}
		}

		private void UpdateScaleRangeBounds()
		{
			if (I_Range != null)
			{
				if (Orientation == Orientation.Vertical)
				{
					I_Range.SetBounds(PixelsHigh, PixelsLow);
				}
				else
				{
					I_Range.SetBounds(PixelsLow, PixelsHigh);
				}
			}
		}

		protected override bool GetValueOnScale(double value)
		{
			int num = ValueToPixels(value);
			if (num >= PixelsLow)
			{
				return num <= PixelsHigh;
			}
			return false;
		}

		[Description("Converts a absolute value in value units to a absolute value in pixel units.")]
		public int ValueToPixels(double value)
		{
			return I_Range.ValueToPixels(value);
		}

		[Description("Converts a absolute value in value units to a absolute value in percent units.")]
		public double ValueToPercent(double value)
		{
			return I_Range.ValueToPercent(value, false);
		}

		[Description("Converts a relative span in value units to a relative span in percent units.")]
		public double ValueSpanToPercent(double value)
		{
			return I_Range.ValueSpanToPercent(value);
		}

		[Description("Converts a absolute value in percent units to a absolute value in pixel units.")]
		public int PercentToPixels(double value)
		{
			return I_Range.PercentToPixels(value, false);
		}

		[Description("Converts a absolute value in percent units to a absolute value in value units.")]
		public double PercentToValue(double value)
		{
			return I_Range.PercentToValue(value, false);
		}

		[Description("Converts a relative span in percent units to a relative span in value units.")]
		public double PercentSpanToValue(double value)
		{
			return I_Range.PercentSpanToValue(value);
		}

		[Description("Converts a absolute value in pixel units to a absolute value in value units.")]
		public double PixelsToValue(int value)
		{
			return I_Range.PixelsToValue(value);
		}

		[Description("Converts a relative span in pixel units to a relative span in value units.")]
		public double PixelSpanToValue(int value)
		{
			return I_Range.PixelSpanToValue(value);
		}

		[Description("Converts a relative span in pixel units to a relative span in percent units.")]
		public double PixelSpanToPercent(int value)
		{
			return I_Range.PixelSpanToPercent(value);
		}

		[Description("Converts a absolute value in pixel units to a absolute value in percent units.")]
		public double PixelsToPercent(int value)
		{
			return I_Range.PixelsToPercent(value);
		}

		[Description("Converts a relative span in value units to a relative span in pixel units.")]
		public int ValueToSpanPixels(double value)
		{
			return I_Range.ValueToSpanPixels(value);
		}

		[Description("Converts a relative span in percent units to a relative span in pixel units.")]
		public int PercentToSpanPixels(double value)
		{
			return I_Range.PercentToSpanPixels(value);
		}

		private bool ShouldSerializeAntiAliasEnabled()
		{
			return base.PropertyShouldSerialize("AntiAliasEnabled");
		}

		private void ResetAntiAliasEnabled()
		{
			base.PropertyReset("AntiAliasEnabled");
		}

		private bool ShouldSerializeDirection()
		{
			return base.PropertyShouldSerialize("Direction");
		}

		private void ResetDirection()
		{
			base.PropertyReset("Direction");
		}

		private bool ShouldSerializeMargin()
		{
			return base.PropertyShouldSerialize("Margin");
		}

		private void ResetMargin()
		{
			base.PropertyReset("Margin");
		}

		private bool ShouldSerializeTextRotation()
		{
			return base.PropertyShouldSerialize("TextRotation");
		}

		private void ResetTextRotation()
		{
			base.PropertyReset("TextRotation");
		}

		private bool ShouldSerializeTextAlignment()
		{
			return base.PropertyShouldSerialize("TextAlignment");
		}

		private void ResetTextAlignment()
		{
			base.PropertyReset("TextAlignment");
		}

		private Point GetScalePoint(double value, AlignmentStyle alignment)
		{
			int num = 0;
			switch (alignment)
			{
			case AlignmentStyle.Center:
				num += base.TickMajor.Length / 2;
				break;
			case AlignmentStyle.Far:
				num += base.TickMajor.Length;
				break;
			}
			int num2 = ValueToPixels(value);
			int num3 = (Direction != 0) ? (base.EdgeRef - num) : (base.EdgeRef + num);
			if (Orientation == Orientation.Vertical)
			{
				return new Point(num3, num2);
			}
			return new Point(num2, num3);
		}

		protected override Point GetTickPoint(IScaleTickBase tick)
		{
			int num = 0;
			switch ((!(tick is ScaleTickMinor)) ? ((tick is ScaleTickMid) ? (tick as ScaleTickMid).Alignment : AlignmentStyle.Near) : (tick as ScaleTickMinor).Alignment)
			{
			case AlignmentStyle.Center:
				num += (base.TickMajor.Length - tick.Length) / 2;
				break;
			case AlignmentStyle.Far:
				num += base.TickMajor.Length - tick.Length;
				break;
			}
			int num2 = ValueToPixels(tick.Value);
			int num3 = (Direction != 0) ? (base.EdgeRef - num) : (base.EdgeRef + num);
			if (Orientation == Orientation.Vertical)
			{
				return new Point(num3, num2);
			}
			return new Point(num2, num3);
		}

		protected override Point[] GetTickLine(IScaleTickBase tick)
		{
			Point tickPoint = GetTickPoint(tick);
			int num = (Direction != 0) ? (-tick.Length) : tick.Length;
			Point point = (Orientation != Orientation.Vertical) ? new Point(tickPoint.X, tickPoint.Y + num) : new Point(tickPoint.X + num, tickPoint.Y);
			return new Point[2]
			{
				tickPoint,
				point
			};
		}

		private Rectangle GetTextRectangle(IScaleTickLabel tick)
		{
			int num;
			int num2;
			if (tick.StackingDimension == StackingDimension.Height)
			{
				num = tick.TextAlignmentSize.Width;
				num2 = tick.TextAlignmentSize.Height;
			}
			else
			{
				num = tick.TextAlignmentSize.Height;
				num2 = tick.TextAlignmentSize.Width;
			}
			int num3 = tick.Length + tick.TextMargin;
			Point tickPoint = GetTickPoint(tick);
			int num4 = (Direction != 0) ? (-(num + num3)) : num3;
			Point point = (Orientation != Orientation.Vertical) ? new Point(tickPoint.X - num2 / 2, tickPoint.Y + num4) : new Point(tickPoint.X + num4, tickPoint.Y - num2 / 2);
			return new Rectangle(point.X, point.Y, tick.TextAlignmentSize.Width, tick.TextAlignmentSize.Height);
		}

		private void DrawColorBar(PaintArgs p, double start, double stop, Color color)
		{
			start = base.ValueClamped(start);
			stop = base.ValueClamped(stop);
			int edgeRef = base.EdgeRef;
			int num = ValueToPixels(stop);
			int num2 = ValueToPixels(start);
			int length = base.TickMajor.Length;
			if (num2 < num)
			{
				Math2.Switch(ref num2, ref num);
			}
			if (Direction == SideDirection.LeftToRight)
			{
				Rectangle rect = new Rectangle(edgeRef, num, length, num2 - num);
				p.Graphics.FillRectangle(p.Graphics.Brush(color), rect);
			}
			else
			{
				Rectangle rect = new Rectangle(edgeRef - length, num, length, num2 - num);
				p.Graphics.FillRectangle(p.Graphics.Brush(color), rect);
			}
		}

		protected override void DrawTickLine(PaintArgs p, IScaleTickBase tick)
		{
			Point[] tickLine = GetTickLine(tick);
			p.Graphics.DrawLine(p.Graphics.Pen(tick.Color, (float)tick.Thickness), tickLine[0], tickLine[1]);
		}

		protected override void DrawTickLabel(PaintArgs p, IScaleTickLabel tick, DrawStringFormat format)
		{
			Rectangle textRectangle = GetTextRectangle(tick);
			p.Graphics.DrawScaleRotatedText(tick.Text, tick.Font, tick.ForeColor, textRectangle, TextRotation, format);
		}

		protected override void DrawInternal(PaintArgs p, DrawStringFormat stringFormat)
		{
			StringAlignment stringAlignment;
			StringAlignment stringAlignment2;
			if (Orientation == Orientation.Vertical)
			{
				if (Direction == SideDirection.LeftToRight)
				{
					stringAlignment = ((TextAlignment != 0) ? ((TextAlignment == StringAlignment.Center) ? StringAlignment.Center : StringAlignment.Far) : StringAlignment.Near);
					stringAlignment2 = StringAlignment.Center;
				}
				else
				{
					stringAlignment = ((TextAlignment != 0) ? ((TextAlignment == StringAlignment.Center) ? StringAlignment.Center : StringAlignment.Near) : StringAlignment.Far);
					stringAlignment2 = StringAlignment.Center;
				}
			}
			else if (Direction == SideDirection.LeftToRight)
			{
				stringAlignment2 = ((TextAlignment != 0) ? ((TextAlignment == StringAlignment.Center) ? StringAlignment.Center : StringAlignment.Far) : StringAlignment.Near);
				stringAlignment = StringAlignment.Center;
			}
			else
			{
				stringAlignment2 = ((TextAlignment != 0) ? ((TextAlignment == StringAlignment.Center) ? StringAlignment.Center : StringAlignment.Near) : StringAlignment.Far);
				stringAlignment = StringAlignment.Center;
			}
			if (TextRotation == TextRotation.X000 || TextRotation == TextRotation.X180)
			{
				stringFormat.Alignment = stringAlignment;
				stringFormat.LineAlignment = stringAlignment2;
			}
			else
			{
				stringFormat.Alignment = stringAlignment2;
				stringFormat.LineAlignment = stringAlignment;
			}
			foreach (IScaleTickBase tick in base.TickList)
			{
				tick.Draw(p, stringFormat, base.TickMajor.Length);
			}
			if (base.LineInnerVisible)
			{
				Point scalePoint = GetScalePoint(Range.Min, AlignmentStyle.Near);
				Point scalePoint2 = GetScalePoint(Range.Max, AlignmentStyle.Near);
				p.Graphics.DrawLine(p.Graphics.Pen(base.TickMajor.Color, (float)base.LineThickness), scalePoint, scalePoint2);
			}
			if (base.LineOuterVisible)
			{
				Point scalePoint = GetScalePoint(Range.Min, AlignmentStyle.Far);
				Point scalePoint2 = GetScalePoint(Range.Max, AlignmentStyle.Far);
				p.Graphics.DrawLine(p.Graphics.Pen(base.TickMajor.Color, (float)base.LineThickness), scalePoint, scalePoint2);
			}
		}

		private void AntiAliasAdust()
		{
			if (base.Generator.MinorStepSize != 0.0)
			{
				int num = (int)(base.ScaleRange.Span / base.Generator.MinorStepSize);
				if (num >= 1)
				{
					int num2 = PixelsSpan / num * num;
					int num3 = PixelsLow + PixelsHigh / 2;
					PixelsLow = num3 - num2 / 2;
					PixelsHigh = PixelsLow + num2;
				}
			}
		}

		private void UpdateScaleBounds()
		{
			m_TextOverlapPixels = (int)Math.Ceiling((double)base.MaxTickStackingDepth / 2.0);
			m_TextOverlapPixels = Math.Max(m_TextOverlapPixels, base.TextWidthMinPixels / 2);
			if (PixelsLow < ClipLow + m_TextOverlapPixels)
			{
				PixelsLow = ClipLow + m_TextOverlapPixels;
			}
			if (PixelsHigh > ClipHigh - m_TextOverlapPixels)
			{
				PixelsHigh = ClipHigh - m_TextOverlapPixels;
			}
		}

		protected override int GetMaxTicks()
		{
			Size size = base.TickInfo.Painter.Graphics.MeasureString(base.TickMajor.Font);
			double num;
			double num2;
			if (TextStackingDimension == StackingDimension.Height)
			{
				num = base.TickInfo.MinTextSpacing * (double)size.Height;
				string text = base.TextFormatting.GetText(base.ScaleRange.Min);
				num2 = (double)base.TickInfo.Painter.Graphics.MeasureString(text, base.TickMajor.Font).Height;
			}
			else
			{
				num = base.TickInfo.MinTextSpacing * (double)size.Width;
				num2 = (double)base.TextWidthMinPixels;
				string text = base.TextFormatting.GetText(base.ScaleRange.Min);
				num2 = Math.Max(num2, (double)base.TickInfo.Painter.Graphics.MeasureString(text, base.TickMajor.Font).Width);
				text = base.TextFormatting.GetText(base.ScaleRange.Max);
				num2 = Math.Max(num2, (double)base.TickInfo.Painter.Graphics.MeasureString(text, base.TickMajor.Font).Width);
			}
			base.TickInfo.LabelMaxWidth = (int)Math.Round(num2 + num);
			int num3 = (int)((double)base.TickInfo.PixelSpanCalculation / (double)base.TickInfo.LabelMaxWidth);
			if (num3 < 1)
			{
				return 1;
			}
			return num3;
		}

		protected override void UpdateScaleExtents(PaintArgs p)
		{
			m_MaxTickDisplayWidth = 0;
			for (int i = 0; i < base.TickList.Count; i++)
			{
				m_MaxTickDisplayWidth = Math.Max(m_MaxTickDisplayWidth, (base.TickList[i] as IScaleTickBase).GetScaleWidth());
			}
		}

		protected override void ScaleInitializeTickInfo()
		{
			base.TickInfo.StackingDimension = TextStackingDimension;
		}

		protected override void Generate(PaintArgs p)
		{
			base.Generate(p);
			base.Dirty = false;
			if (!base.SlidingScale)
			{
				if (AntiAliasEnabled)
				{
					AntiAliasAdust();
				}
				else
				{
					UpdateScaleBounds();
				}
				if (base.Dirty)
				{
					base.Generate(p);
				}
			}
		}
	}
}
