using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Controls the scale display layout properties.")]
	public abstract class ScaleDisplay : SubClassBase, IScaleDisplay
	{
		private ScaleGeneratorAuto m_GeneratorAuto;

		private ScaleGeneratorFixed m_GeneratorFixed;

		private ScaleTickMajor m_TickMajor;

		private ScaleTickMid m_TickMid;

		private ScaleTickMinor m_TickMinor;

		private ScaleRange m_Range;

		private ScaleGeneratorStyle m_GeneratorStyle;

		private double m_StartRefValue;

		private bool m_StartRefEnabled;

		private TextFormatDoubleAll m_TextFormatting;

		private double m_TextWidthMinValue;

		private int m_TextWidthMinPixels;

		private bool m_TextWidthMinAuto;

		private bool m_LineInnerVisible;

		private bool m_LineOuterVisible;

		private int m_LineThickness;

		private bool m_SlidingScale;

		private bool m_DegreeModeEnabled;

		private int m_EdgeRef;

		private ScaleTickInfo m_TickInfo;

		private bool m_Dirty;

		private int m_MaxTextWidth;

		private int m_MaxTextHeight;

		private Size m_MaxTextSize;

		private Size m_MaxTextAlignmentSize;

		private int m_MaxTickStackingDepth;

		private double m_MajorIncrement;

		private double m_MinorIncrement;

		bool IScaleDisplay.SlidingScale
		{
			get
			{
				return SlidingScale;
			}
			set
			{
				SlidingScale = value;
			}
		}

		bool IScaleDisplay.DegreeModeEnabled
		{
			get
			{
				return DegreeModeEnabled;
			}
			set
			{
				DegreeModeEnabled = value;
			}
		}

		int IScaleDisplay.EdgeRef
		{
			get
			{
				return EdgeRef;
			}
			set
			{
				EdgeRef = value;
			}
		}

		ScaleRange IScaleDisplay.Range
		{
			get
			{
				return Range;
			}
			set
			{
				Range = value;
			}
		}

		double IScaleDisplay.MajorIncrement
		{
			get
			{
				return m_MajorIncrement;
			}
			set
			{
				m_MajorIncrement = value;
			}
		}

		double IScaleDisplay.MinorIncrement
		{
			get
			{
				return m_MinorIncrement;
			}
			set
			{
				m_MinorIncrement = value;
			}
		}

		int IScaleDisplay.PixelsSpan
		{
			get
			{
				return PixelsSpan;
			}
		}

		protected bool Dirty
		{
			get
			{
				return m_Dirty;
			}
			set
			{
				m_Dirty = value;
			}
		}

		protected bool DegreeModeEnabled
		{
			get
			{
				return m_DegreeModeEnabled;
			}
			set
			{
				m_DegreeModeEnabled = value;
			}
		}

		protected bool SlidingScale
		{
			get
			{
				return m_SlidingScale;
			}
			set
			{
				m_SlidingScale = value;
			}
		}

		protected int EdgeRef
		{
			get
			{
				return m_EdgeRef;
			}
			set
			{
				m_EdgeRef = value;
			}
		}

		protected int MaxTextWidth
		{
			get
			{
				return m_MaxTextWidth;
			}
			set
			{
				m_MaxTextWidth = value;
			}
		}

		protected int MaxTextHeight
		{
			get
			{
				return m_MaxTextHeight;
			}
			set
			{
				m_MaxTextHeight = value;
			}
		}

		protected Size MaxTextSize
		{
			get
			{
				return m_MaxTextSize;
			}
			set
			{
				m_MaxTextSize = value;
			}
		}

		protected Size MaxTextAlignmentSize
		{
			get
			{
				return m_MaxTextAlignmentSize;
			}
			set
			{
				m_MaxTextAlignmentSize = value;
			}
		}

		protected int MaxTickStackingDepth
		{
			get
			{
				return m_MaxTickStackingDepth;
			}
			set
			{
				m_MaxTickStackingDepth = value;
			}
		}

		protected IScaleGeneratorBase Generator
		{
			get
			{
				if (GeneratorStyle == ScaleGeneratorStyle.Fixed)
				{
					return GeneratorFixed;
				}
				return GeneratorAuto;
			}
		}

		protected ScaleTickInfo TickInfo => m_TickInfo;

		[Description("")]
		[Browsable(false)]
		public ArrayList TickList
		{
			get
			{
				return m_TickInfo.TickList;
			}
		}

		[Description("GeneratorAuto properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ScaleGeneratorAuto GeneratorAuto
		{
			get
			{
				return m_GeneratorAuto;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("GeneratorAuto properties")]
		public ScaleGeneratorFixed GeneratorFixed
		{
			get
			{
				return m_GeneratorFixed;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Tick Major properties")]
		public ScaleTickMajor TickMajor
		{
			get
			{
				return m_TickMajor;
			}
		}

		[Description("Tick Mid properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ScaleTickMid TickMid
		{
			get
			{
				return m_TickMid;
			}
		}

		[Description("Tick Minor properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ScaleTickMinor TickMinor
		{
			get
			{
				return m_TickMinor;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Text Format properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TextFormatDoubleAll TextFormatting
		{
			get
			{
				return m_TextFormatting;
			}
			set
			{
				if (m_TextFormatting != null)
				{
					base.RemoveSubClass(m_TextFormatting);
				}
				m_TextFormatting = value;
				base.AddSubClass(m_TextFormatting);
			}
		}

		[Description("Scale Range properties")]
		[RefreshProperties(RefreshProperties.All)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ScaleRange ScaleRange
		{
			get
			{
				return m_Range;
			}
		}

		protected virtual ScaleRange Range
		{
			get
			{
				return m_Range;
			}
			set
			{
				if (Range != value)
				{
					m_Range = value;
					base.DoPropertyChange(this, "Range");
				}
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public ScaleGeneratorStyle GeneratorStyle
		{
			get
			{
				return m_GeneratorStyle;
			}
			set
			{
				base.PropertyUpdateDefault("GeneratorStyle", value);
				if (GeneratorStyle != value)
				{
					m_GeneratorStyle = value;
					base.DoPropertyChange(this, "GeneratorStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double StartRefValue
		{
			get
			{
				return m_StartRefValue;
			}
			set
			{
				base.PropertyUpdateDefault("StartRefValue", value);
				if (StartRefValue != value)
				{
					m_StartRefValue = value;
					base.DoPropertyChange(this, "StartRefValue");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool StartRefEnabled
		{
			get
			{
				return m_StartRefEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("StartRefEnabled", value);
				if (StartRefEnabled != value)
				{
					m_StartRefEnabled = value;
					base.DoPropertyChange(this, "StartRefEnabled");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double TextWidthMinValue
		{
			get
			{
				return m_TextWidthMinValue;
			}
			set
			{
				base.PropertyUpdateDefault("TextWidthMinValue", value);
				if (TextWidthMinValue != value)
				{
					m_TextWidthMinValue = value;
					base.DoPropertyChange(this, "TextWidthMinValue");
				}
			}
		}

		protected int TextWidthMinPixels
		{
			get
			{
				return m_TextWidthMinPixels;
			}
			set
			{
				m_TextWidthMinPixels = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool TextWidthMinAuto
		{
			get
			{
				return m_TextWidthMinAuto;
			}
			set
			{
				base.PropertyUpdateDefault("TextWidthMinAuto", value);
				if (TextWidthMinAuto != value)
				{
					m_TextWidthMinAuto = value;
					base.DoPropertyChange(this, "TextWidthMinAuto");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool LineInnerVisible
		{
			get
			{
				return m_LineInnerVisible;
			}
			set
			{
				base.PropertyUpdateDefault("LineInnerVisible", value);
				if (LineInnerVisible != value)
				{
					m_LineInnerVisible = value;
					base.DoPropertyChange(this, "LineInnerVisible");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool LineOuterVisible
		{
			get
			{
				return m_LineOuterVisible;
			}
			set
			{
				base.PropertyUpdateDefault("LineOuterVisible", value);
				if (LineOuterVisible != value)
				{
					m_LineOuterVisible = value;
					base.DoPropertyChange(this, "LineOuterVisible");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int LineThickness
		{
			get
			{
				return m_LineThickness;
			}
			set
			{
				base.PropertyUpdateDefault("LineThickness", value);
				if (LineThickness != value)
				{
					m_LineThickness = value;
					base.DoPropertyChange(this, "LineThickness");
				}
			}
		}

		[Browsable(false)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double MajorIncrement
		{
			get
			{
				return m_MajorIncrement;
			}
			set
			{
				m_MajorIncrement = value;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public double MinorIncrement
		{
			get
			{
				return m_MinorIncrement;
			}
			set
			{
				m_MinorIncrement = value;
			}
		}

		public abstract int PixelsSpan
		{
			get;
		}

		bool IScaleDisplay.GetValueOnScale(double value)
		{
			return GetValueOnScale(value);
		}

		void IScaleDisplay.Generate(PaintArgs p)
		{
			Generate(p);
		}

		void IScaleDisplay.Draw(PaintArgs p)
		{
			Draw(p);
		}

		void IScaleDisplay.DrawTickLabel(PaintArgs p, IScaleTickLabel tick, DrawStringFormat format)
		{
			DrawTickLabel(p, tick, format);
		}

		void IScaleDisplay.DrawTickLine(PaintArgs p, IScaleTickBase tick)
		{
			DrawTickLine(p, tick);
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_GeneratorAuto = new ScaleGeneratorAuto();
			base.AddSubClass(GeneratorAuto);
			m_GeneratorFixed = new ScaleGeneratorFixed();
			base.AddSubClass(GeneratorFixed);
			m_TickMajor = new ScaleTickMajor();
			base.AddSubClass(TickMajor);
			m_TickMid = new ScaleTickMid();
			base.AddSubClass(TickMid);
			m_TickMinor = new ScaleTickMinor();
			base.AddSubClass(TickMinor);
			TextFormatting = new TextFormatDoubleAll();
			((IScaleGeneratorBase)m_GeneratorAuto).Display = this;
			((IScaleGeneratorBase)m_GeneratorFixed).Display = this;
			m_TickInfo = new ScaleTickInfo(this);
			((ISubClassBase)TickMajor).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)TickMinor).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)TickMid).ColorAmbientSource = AmbientColorSouce.Color;
			m_MajorIncrement = 10.0;
			m_MinorIncrement = 1.0;
			base.ColorAmbientSource = AmbientColorSouce.ForeColor;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			LineThickness = 1;
		}

		private bool ShouldSerializeGeneratorAuto()
		{
			return ((ISubClassBase)GeneratorAuto).ShouldSerialize();
		}

		private void ResetGeneratorAuto()
		{
			((ISubClassBase)GeneratorAuto).ResetToDefault();
		}

		private bool ShouldSerializeGeneratorFixed()
		{
			return ((ISubClassBase)GeneratorFixed).ShouldSerialize();
		}

		private void ResetGeneratorFixed()
		{
			((ISubClassBase)GeneratorFixed).ResetToDefault();
		}

		private bool ShouldSerializeTickMajor()
		{
			return ((ISubClassBase)TickMajor).ShouldSerialize();
		}

		private void ResetTickMajor()
		{
			((ISubClassBase)TickMajor).ResetToDefault();
		}

		private bool ShouldSerializeTickMid()
		{
			return ((ISubClassBase)TickMid).ShouldSerialize();
		}

		private void ResetTickMid()
		{
			((ISubClassBase)TickMid).ResetToDefault();
		}

		private bool ShouldSerializeTickMinor()
		{
			return ((ISubClassBase)TickMinor).ShouldSerialize();
		}

		private void ResetTickMinor()
		{
			((ISubClassBase)TickMinor).ResetToDefault();
		}

		private bool ShouldSerializeTextFormatting()
		{
			return ((ISubClassBase)TextFormatting).ShouldSerialize();
		}

		private void ResetTextFormatting()
		{
			((ISubClassBase)TextFormatting).ResetToDefault();
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeGeneratorStyle()
		{
			return base.PropertyShouldSerialize("GeneratorStyle");
		}

		private void ResetGeneratorStyle()
		{
			base.PropertyReset("GeneratorStyle");
		}

		private bool ShouldSerializeStartRefValue()
		{
			return base.PropertyShouldSerialize("StartRefValue");
		}

		private void ResetStartRefValue()
		{
			base.PropertyReset("StartRefValue");
		}

		private bool ShouldSerializeStartRefEnabled()
		{
			return base.PropertyShouldSerialize("StartRefEnabled");
		}

		private void ResetStartRefEnabled()
		{
			base.PropertyReset("StartRefEnabled");
		}

		private bool ShouldSerializeTextWidthMinValue()
		{
			return base.PropertyShouldSerialize("TextWidthMinValue");
		}

		private void ResetTextWidthMinValue()
		{
			base.PropertyReset("TextWidthMinValue");
		}

		private bool ShouldSerializeTextWidthMinAuto()
		{
			return base.PropertyShouldSerialize("TextWidthMinAuto");
		}

		private void ResetTextWidthMinAuto()
		{
			base.PropertyReset("TextWidthMinAuto");
		}

		private bool ShouldSerializeLineInnerVisible()
		{
			return base.PropertyShouldSerialize("LineInnerVisible");
		}

		private void ResetLineInnerVisible()
		{
			base.PropertyReset("LineInnerVisible");
		}

		private bool ShouldSerializeLineOuterVisible()
		{
			return base.PropertyShouldSerialize("LineOuterVisible");
		}

		private void ResetLineOuterVisible()
		{
			base.PropertyReset("LineOuterVisible");
		}

		private bool ShouldSerializeLineThickness()
		{
			return base.PropertyShouldSerialize("LineThickness");
		}

		private void ResetLineThickness()
		{
			base.PropertyReset("LineThickness");
		}

		public ScaleTickMajor AddTickMajor(double value, bool permanent)
		{
			if (Range.ScaleType == ScaleType.Log10 && value <= 0.0)
			{
				return null;
			}
			if (Range.ScaleType == ScaleType.SplitLinearLog10 && value >= Range.SplitStart && value <= 0.0)
			{
				return null;
			}
			ScaleTickMajor scaleTickMajor = new ScaleTickMajor();
			scaleTickMajor.Value = value;
			scaleTickMajor.Color = TickMajor.Color;
			scaleTickMajor.ForeColor = TickMajor.ForeColor;
			scaleTickMajor.Font = TickMajor.Font;
			scaleTickMajor.Thickness = TickMajor.Thickness;
			scaleTickMajor.Length = TickMajor.Length;
			scaleTickMajor.TextVisible = TickMajor.TextVisible;
			scaleTickMajor.TextMargin = TickMajor.TextMargin;
			scaleTickMajor.Permanent = permanent;
			if (DegreeModeEnabled)
			{
				scaleTickMajor.Text = TextFormatting.GetText(Math2.AngleNormalized(scaleTickMajor.Value));
			}
			else
			{
				scaleTickMajor.Text = TextFormatting.GetText(scaleTickMajor.Value);
			}
			((ISubClassBase)scaleTickMajor).AmbientOwner = this;
			((IScaleTickBase)scaleTickMajor).Display = this;
			TickList.Add(scaleTickMajor);
			return scaleTickMajor;
		}

		public ScaleTickMajor AddTickMajor(double value, string text, bool permanent)
		{
			ScaleTickMajor scaleTickMajor = AddTickMajor(value, permanent);
			scaleTickMajor.Text = text;
			return scaleTickMajor;
		}

		public ScaleTickMid AddTickMid(double value, bool permanent)
		{
			if (Range.ScaleType != 0 && value <= 0.0)
			{
				return null;
			}
			ScaleTickMid scaleTickMid = new ScaleTickMid();
			scaleTickMid.Value = value;
			scaleTickMid.Color = TickMid.Color;
			scaleTickMid.ForeColor = TickMid.ForeColor;
			scaleTickMid.Font = TickMid.Font;
			scaleTickMid.Thickness = TickMid.Thickness;
			scaleTickMid.Length = TickMid.Length;
			scaleTickMid.TextVisible = TickMid.TextVisible;
			scaleTickMid.TextMargin = TickMid.TextMargin;
			scaleTickMid.Alignment = TickMid.Alignment;
			scaleTickMid.Permanent = permanent;
			if (DegreeModeEnabled)
			{
				scaleTickMid.Text = TextFormatting.GetText(Math2.AngleNormalized(scaleTickMid.Value));
			}
			else
			{
				scaleTickMid.Text = TextFormatting.GetText(scaleTickMid.Value);
			}
			((ISubClassBase)scaleTickMid).AmbientOwner = this;
			((IScaleTickBase)scaleTickMid).Display = this;
			TickList.Add(scaleTickMid);
			return scaleTickMid;
		}

		public ScaleTickMid AddTickMid(double value, string text, bool permanent)
		{
			ScaleTickMid scaleTickMid = AddTickMid(value, permanent);
			scaleTickMid.Text = text;
			return scaleTickMid;
		}

		public ScaleTickMinor AddTickMinor(double value, bool permanent)
		{
			if (Range.ScaleType != 0 && value <= 0.0)
			{
				return null;
			}
			ScaleTickMinor scaleTickMinor = new ScaleTickMinor();
			scaleTickMinor.Value = value;
			scaleTickMinor.Color = TickMinor.Color;
			scaleTickMinor.Thickness = TickMinor.Thickness;
			scaleTickMinor.Length = TickMinor.Length;
			scaleTickMinor.Alignment = TickMinor.Alignment;
			scaleTickMinor.Permanent = permanent;
			((ISubClassBase)scaleTickMinor).AmbientOwner = this;
			((IScaleTickBase)scaleTickMinor).Display = this;
			TickList.Add(scaleTickMinor);
			return scaleTickMinor;
		}

		protected void UpdateTextWidthMinPixels(PaintArgs p)
		{
			if (TextWidthMinAuto && !base.Designing)
			{
				TextWidthMinPixels = (int)Math.Max((double)TextWidthMinPixels, (double)p.Graphics.MeasureString(TickMajor.Font).Width * TextWidthMinValue);
			}
			else
			{
				TextWidthMinPixels = (int)((double)p.Graphics.MeasureString(TickMajor.Font).Width * TextWidthMinValue);
			}
		}

		protected void UpdateTicksTextSizeInfo(PaintArgs p)
		{
			for (int i = 0; i < TickList.Count; i++)
			{
				if (TickList[i] is IScaleTickLabel)
				{
					IScaleTickLabel scaleTickLabel = TickList[i] as IScaleTickLabel;
					scaleTickLabel.TextSize = p.Graphics.MeasureString(scaleTickLabel.Text, scaleTickLabel.Font, false);
				}
			}
			int num = (this is ScaleDisplayLinear) ? TextWidthMinPixels : 0;
			m_MaxTextWidth = 0;
			m_MaxTextHeight = 0;
			for (int j = 0; j < TickList.Count; j++)
			{
				if (TickList[j] is IScaleTickLabel)
				{
					IScaleTickLabel scaleTickLabel = TickList[j] as IScaleTickLabel;
					if (scaleTickLabel.TextVisible)
					{
						m_MaxTextWidth = Math.Max(m_MaxTextWidth, scaleTickLabel.TextSize.Width);
						m_MaxTextHeight = Math.Max(m_MaxTextHeight, scaleTickLabel.TextSize.Height);
						num = Math.Max(num, m_MaxTextWidth);
					}
				}
			}
			MaxTextSize = new Size(m_MaxTextWidth, m_MaxTextHeight);
			MaxTextAlignmentSize = new Size(num, m_MaxTextHeight);
			if (TickInfo.StackingDimension == StackingDimension.Height)
			{
				m_MaxTickStackingDepth = MaxTextSize.Height;
			}
			else
			{
				m_MaxTickStackingDepth = MaxTextSize.Width;
			}
			for (int k = 0; k < TickList.Count; k++)
			{
				if (TickList[k] is IScaleTickLabel)
				{
					IScaleTickLabel scaleTickLabel = TickList[k] as IScaleTickLabel;
					scaleTickLabel.TextMaxSize = MaxTextSize;
					scaleTickLabel.TextAlignmentSize = MaxTextAlignmentSize;
					scaleTickLabel.StackingDimension = TickInfo.StackingDimension;
				}
			}
		}

		public double ValueClamped(double value)
		{
			if (value <= ScaleRange.Min)
			{
				return ScaleRange.Min;
			}
			if (value >= ScaleRange.Max)
			{
				return ScaleRange.Max;
			}
			return value;
		}

		public void ClearAllNonPermanentTicks()
		{
			int num = 0;
			while (num < TickList.Count)
			{
				ScaleTickBase scaleTickBase = TickList[num] as ScaleTickBase;
				if (!scaleTickBase.Permanent)
				{
					TickList.Remove(scaleTickBase);
				}
				else
				{
					num++;
				}
			}
		}

		protected void CalcTicks(PaintArgs p)
		{
			Generator.Generate(p, TickInfo);
			UpdateTicksTextSizeInfo(p);
		}

		protected virtual void Generate(PaintArgs p)
		{
			ScaleInitializeTickInfo();
			UpdateTextWidthMinPixels(p);
			if (ScaleRange.Span > 1E+300 || ScaleRange.Span < 1E-300)
			{
				TickList.Clear();
				AddTickMajor(ScaleRange.Mid, "Out of Range", false);
			}
			else
			{
				ClearAllNonPermanentTicks();
				if (GeneratorStyle != ScaleGeneratorStyle.Custom)
				{
					if (Range.ScaleType == ScaleType.Linear || Range.ScaleType == ScaleType.Log10)
					{
						TickInfo.Painter = p;
						TickInfo.TextFormatting = TextFormatting;
						TickInfo.PixelSpanTotal = PixelsSpan;
						TickInfo.PixelSpanCalculation = TickInfo.PixelSpanTotal;
						TickInfo.ScaleType = Range.ScaleType;
						TickInfo.Span = Range.Span;
						TickInfo.Min = Range.Min;
						TickInfo.Max = Range.Max;
						Generator.InitializeTickInfo(TickInfo);
						TickInfo.MaxTicks = GetMaxTicks();
						CalcTicks(p);
					}
					else if (Range.ScaleType == ScaleType.SplitLinearLog10)
					{
						TickInfo.Painter = p;
						TickInfo.TextFormatting = TextFormatting;
						TickInfo.PixelSpanTotal = PixelsSpan;
						TickInfo.PixelSpanCalculation = (int)((double)TickInfo.PixelSpanTotal * Range.SplitPercent);
						TickInfo.ScaleType = ScaleType.Linear;
						TickInfo.Span = Range.SplitStart - Range.Min;
						TickInfo.Min = Range.Min;
						TickInfo.Max = TickInfo.Min + TickInfo.Span;
						Generator.InitializeTickInfo(TickInfo);
						TickInfo.MaxTicks = GetMaxTicks();
						CalcTicks(p);
						TickInfo.Painter = p;
						TickInfo.TextFormatting = TextFormatting;
						TickInfo.PixelSpanTotal = PixelsSpan;
						TickInfo.PixelSpanCalculation = (int)((double)TickInfo.PixelSpanTotal * (1.0 - Range.SplitPercent));
						TickInfo.ScaleType = ScaleType.Log10;
						TickInfo.Min = Range.SplitStart;
						TickInfo.Max = Range.Max;
						TickInfo.Span = TickInfo.Max - TickInfo.Min;
						Generator.InitializeTickInfo(TickInfo);
						TickInfo.MaxTicks = GetMaxTicks();
						if (!double.IsNaN(TickInfo.Min) && !double.IsNaN(TickInfo.Max) && !double.IsNaN(TickInfo.Span))
						{
							CalcTicks(p);
						}
					}
				}
				else
				{
					UpdateTicksTextSizeInfo(p);
				}
			}
			if (TextWidthMinAuto && !base.Designing)
			{
				TextWidthMinPixels = Math.Max(TextWidthMinPixels, MaxTextWidth);
			}
			UpdateScaleExtents(p);
		}

		private void Draw(PaintArgs p)
		{
			if (Visible)
			{
				DrawInternal(p, DrawStringFormat.GenericDefault);
			}
		}

		protected abstract Point GetTickPoint(IScaleTickBase tick);

		protected abstract Point[] GetTickLine(IScaleTickBase tick);

		protected abstract int GetMaxTicks();

		protected abstract void ScaleInitializeTickInfo();

		protected abstract bool GetValueOnScale(double value);

		protected abstract void UpdateScaleExtents(PaintArgs p);

		protected abstract void DrawInternal(PaintArgs p, DrawStringFormat stringFormat);

		protected abstract void DrawTickLine(PaintArgs p, IScaleTickBase tick);

		protected abstract void DrawTickLabel(PaintArgs p, IScaleTickLabel tick, DrawStringFormat format);
	}
}
