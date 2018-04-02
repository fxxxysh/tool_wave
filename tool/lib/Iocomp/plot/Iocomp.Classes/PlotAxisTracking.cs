using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Axis Tracking")]
	public class PlotAxisTracking : SubClassBase, IPlotObjectSubClass
	{
		private PlotTrackingStyle m_Style;

		private PlotTrackingAlignFirstStyle m_AlignFirstStyle;

		private PlotTrackingExpandStyle m_ExpandStyle;

		private bool m_AlignFirstDone;

		private double m_ScrollCompressMax;

		private double m_SpanMin;

		private double m_MinMargin;

		private double m_MaxMargin;

		private PlotAxis m_Axis;

		private bool m_ModeScroll;

		private bool m_ModeExpandMinMax;

		private bool m_ModeExpandCollapse;

		private PlotObjectCollection m_ChannelList;

		private double m_ResumeMin;

		private double m_ResumeSpan;

		private bool m_RestoreValuesOnResume;

		PlotObject IPlotObjectSubClass.Owner
		{
			get
			{
				return Axis;
			}
			set
			{
				Axis = (value as PlotAxis);
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool Enabled
		{
			get
			{
				return base.EnabledInternal;
			}
			set
			{
				if (base.EnabledInternal != value)
				{
					base.EnabledInternal = value;
					if (!base.EnabledInternal)
					{
						UpdateResumeValues();
					}
					else if (RestoreValuesOnResume)
					{
						ApplyResumeValues();
					}
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotTrackingStyle Style
		{
			get
			{
				return m_Style;
			}
			set
			{
				base.PropertyUpdateDefault("Style", value);
				m_ModeExpandCollapse = (value == PlotTrackingStyle.ExpandCollapse || value == PlotTrackingStyle.ExpandCollapseInView);
				m_ModeExpandMinMax = (value == PlotTrackingStyle.ExpandMin || value == PlotTrackingStyle.ExpandMax || value == PlotTrackingStyle.ExpandMinMax);
				m_ModeScroll = (value == PlotTrackingStyle.ScrollPage || value == PlotTrackingStyle.ScrollSmooth);
				if (Style != value)
				{
					m_Style = value;
					base.DoPropertyChange(this, "Style");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotTrackingAlignFirstStyle AlignFirstStyle
		{
			get
			{
				return m_AlignFirstStyle;
			}
			set
			{
				base.PropertyUpdateDefault("AlignFirstStyle", value);
				if (AlignFirstStyle != value)
				{
					m_AlignFirstStyle = value;
					base.DoPropertyChange(this, "AlignFirstStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotTrackingExpandStyle ExpandStyle
		{
			get
			{
				return m_ExpandStyle;
			}
			set
			{
				base.PropertyUpdateDefault("ExpandStyle", value);
				if (ExpandStyle != value)
				{
					m_ExpandStyle = value;
					base.DoPropertyChange(this, "ExpandStyle");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double ScrollCompressMax
		{
			get
			{
				return m_ScrollCompressMax;
			}
			set
			{
				base.PropertyUpdateDefault("ScrollCompressMax", value);
				if (ScrollCompressMax != value)
				{
					m_ScrollCompressMax = value;
					base.DoPropertyChange(this, "ScrollCompressMax");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double SpanMin
		{
			get
			{
				return m_SpanMin;
			}
			set
			{
				base.PropertyUpdateDefault("SpanMin", value);
				if (value < 0.0)
				{
					value = 0.0;
				}
				if (SpanMin != value)
				{
					m_SpanMin = value;
					base.DoPropertyChange(this, "SpanMin");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double MinMargin
		{
			get
			{
				return m_MinMargin;
			}
			set
			{
				base.PropertyUpdateDefault("MinMargin", value);
				if (MinMargin != value)
				{
					m_MinMargin = value;
					base.DoPropertyChange(this, "MinMargin");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double MaxMargin
		{
			get
			{
				return m_MaxMargin;
			}
			set
			{
				base.PropertyUpdateDefault("MaxMargin", value);
				if (MaxMargin != value)
				{
					m_MaxMargin = value;
					base.DoPropertyChange(this, "MaxMargin");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool RestoreValuesOnResume
		{
			get
			{
				return m_RestoreValuesOnResume;
			}
			set
			{
				base.PropertyUpdateDefault("RestoreValuesOnResume", value);
				if (RestoreValuesOnResume != value)
				{
					m_RestoreValuesOnResume = value;
					base.DoPropertyChange(this, "RestoreValuesOnResume");
				}
			}
		}

		private PlotAxis Axis
		{
			get
			{
				return m_Axis;
			}
			set
			{
				m_Axis = value;
			}
		}

		private bool ModeScroll => m_ModeScroll;

		private bool ModeExpandMinMax => m_ModeExpandMinMax;

		private bool ModeExpandCollapse => m_ModeExpandCollapse;

		[Description("")]
		public bool AlignFirstDone
		{
			get
			{
				return m_AlignFirstDone;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Axis Tracking";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotAxisTrackingEditorPlugIn";
		}

		public PlotAxisTracking()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_ChannelList = new PlotObjectCollection();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			SpanMin = 0.0;
			MinMargin = 0.0;
			MaxMargin = 0.0;
			AlignFirstReset();
		}

		private bool ShouldSerializeEnabled()
		{
			return base.PropertyShouldSerialize("Enabled");
		}

		private void ResetEnabled()
		{
			base.PropertyReset("Enabled");
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private bool ShouldSerializeAlignFirstStyle()
		{
			return base.PropertyShouldSerialize("AlignFirstStyle");
		}

		private void ResetAlignFirstStyle()
		{
			base.PropertyReset("AlignFirstStyle");
		}

		private bool ShouldSerializeExpandStyle()
		{
			return base.PropertyShouldSerialize("ExpandStyle");
		}

		private void ResetExpandStyle()
		{
			base.PropertyReset("ExpandStyle");
		}

		private bool ShouldSerializeScrollCompressMax()
		{
			return base.PropertyShouldSerialize("ScrollCompressMax");
		}

		private void ResetScrollCompressMax()
		{
			base.PropertyReset("ScrollCompressMax");
		}

		private bool ShouldSerializeSpanMin()
		{
			return base.PropertyShouldSerialize("SpanMin");
		}

		private void ResetSpanMin()
		{
			base.PropertyReset("SpanMin");
		}

		private bool ShouldSerializeMinMargin()
		{
			return base.PropertyShouldSerialize("MinMargin");
		}

		private void ResetMinMargin()
		{
			base.PropertyReset("MinMargin");
		}

		private bool ShouldSerializeMaxMargin()
		{
			return base.PropertyShouldSerialize("MaxMargin");
		}

		private void ResetMaxMargin()
		{
			base.PropertyReset("MaxMargin");
		}

		private bool ShouldSerializeRestoreValuesOnResume()
		{
			return base.PropertyShouldSerialize("RestoreValuesOnResume");
		}

		private void ResetRestoreValuesOnResume()
		{
			base.PropertyReset("RestoreValuesOnResume");
		}

		[Description("")]
		public void AlignFirstReset()
		{
			m_AlignFirstDone = false;
		}

		[Description("")]
		public virtual void UpdateResumeValues()
		{
			if (Axis != null)
			{
				m_ResumeMin = Axis.ScaleRange.Min;
				m_ResumeSpan = Axis.ScaleRange.Span;
			}
		}

		[Description("")]
		public virtual void ApplyResumeValues()
		{
			if (Axis != null)
			{
				Axis.ScaleRange.SetMinSpan(m_ResumeMin, m_ResumeSpan);
			}
		}

		private void UpdateChannelList(Plot plot)
		{
			m_ChannelList.Clear();
			foreach (PlotChannelBase channel in plot.Channels)
			{
				if (Axis is PlotXAxis)
				{
					if (PlotBase.GetNamesMatch(Axis.Name, channel.XAxisName))
					{
						m_ChannelList.Add(channel);
					}
				}
				else if (Axis is PlotYAxis && PlotBase.GetNamesMatch(Axis.Name, channel.YAxisName))
				{
					m_ChannelList.Add(channel);
				}
			}
		}

		[Description("")]
		public void ZoomToFitAll()
		{
			Plot plot = ((IPlotObject)Axis).Plot;
			if (plot != null)
			{
				UpdateChannelList(plot);
				double num = double.PositiveInfinity;
				double num2 = double.NegativeInfinity;
				foreach (PlotChannelBase channel in m_ChannelList)
				{
					if (channel.Count > 0)
					{
						double val;
						double val2;
						if (Axis is PlotXAxis)
						{
							val = channel.XMin;
							val2 = channel.XMax;
						}
						else
						{
							val = channel.YMinScale;
							val2 = channel.YMaxScale;
						}
						num = Math.Min(num, val);
						num2 = Math.Max(num2, val2);
					}
				}
				if (num != double.PositiveInfinity)
				{
					if (num2 == num)
					{
						Axis.ScaleRange.Min = num2 - Axis.ScaleRange.Span / 2.0;
					}
					else
					{
						double num4;
						double num5;
						if (num2 - num < SpanMin)
						{
							double num3 = (num2 + num) / 2.0;
							num4 = num3 + SpanMin / 2.0;
							num5 = num3 - SpanMin / 2.0;
						}
						else
						{
							num4 = num2;
							num5 = num;
						}
						Axis.ScaleRange.SetMinMax(num5 - MinMargin, num4 + MaxMargin);
					}
				}
			}
		}

		[Description("")]
		public void ZoomToFitInView()
		{
			Plot plot = ((IPlotObject)Axis).Plot;
			if (plot != null)
			{
				UpdateChannelList(plot);
				double num = double.PositiveInfinity;
				double num2 = double.NegativeInfinity;
				foreach (PlotChannelBase channel in m_ChannelList)
				{
					if (channel.Count > 1 && ((!(Axis is PlotXAxis)) ? channel.GetInViewMinMaxY(out double val, out double val2) : channel.GetInViewMinMaxX(out val, out val2)))
					{
						num = Math.Min(num, val);
						num2 = Math.Max(num2, val2);
					}
				}
				if (num != double.PositiveInfinity)
				{
					if (num2 == num)
					{
						Axis.ScaleRange.Min = num2 - Axis.ScaleRange.Span / 2.0;
					}
					else
					{
						double num4;
						double num5;
						if (num2 - num < SpanMin)
						{
							double num3 = (num2 + num) / 2.0;
							num4 = num3 + SpanMin / 2.0;
							num5 = num3 - SpanMin / 2.0;
						}
						else
						{
							num4 = num2;
							num5 = num;
						}
						Axis.ScaleRange.SetMinMax(num5 - MinMargin, num4 + MaxMargin);
					}
				}
			}
		}

		private void DoAlignFirst(double value)
		{
			m_AlignFirstDone = true;
			if (AlignFirstStyle == PlotTrackingAlignFirstStyle.Min)
			{
				Axis.ScaleRange.Min = value;
			}
			else if (AlignFirstStyle == PlotTrackingAlignFirstStyle.Max)
			{
				Axis.ScaleRange.Min = value + Axis.ScaleRange.Span;
			}
			else if (AlignFirstStyle == PlotTrackingAlignFirstStyle.Auto && !Axis.ScaleRange.OnRange(value))
			{
				Axis.ScaleRange.Min = value;
			}
		}

		[Description("")]
		public void ScrollNewPage(double value)
		{
			Axis.ScaleRange.Min = value;
		}

		[Description("")]
		public void AdjustToIncrement(double increment)
		{
			double min = Axis.ScaleRange.Min;
			double max = Axis.ScaleRange.Max;
			double num = min;
			double num2 = max;
			if (max % increment != 0.0)
			{
				num2 = (double)(int)(max / increment) * increment;
			}
			if (min % increment != 0.0)
			{
				num = (double)(int)(min / increment) * increment;
			}
			if (num2 < max)
			{
				num2 += increment;
			}
			if (num > min)
			{
				num -= increment;
			}
			if (min == num && max == num2)
			{
				return;
			}
			Axis.ScaleRange.SetMinMax(num, num2);
		}

		[Description("")]
		public virtual void NewData(double value)
		{
			double min;
			double max;
			double min2;
			double max2;
			double num;
			double majorIncrement;
			double minorIncrement;
			if (Enabled && Axis != null)
			{
				min = Axis.ScaleRange.Min;
				max = Axis.ScaleRange.Max;
				double span = Axis.ScaleRange.Span;
				min2 = min;
				max2 = max;
				num = span;
				majorIncrement = Axis.ScaleDisplay.MajorIncrement;
				minorIncrement = Axis.ScaleDisplay.MinorIncrement;
				bool flag = false;
				if (ExpandStyle != PlotTrackingExpandStyle.Minor && minorIncrement == 0.0)
				{
					flag = true;
				}
				if (ExpandStyle != PlotTrackingExpandStyle.Major && majorIncrement == 0.0)
				{
					flag = true;
				}
				if (flag)
				{
					Plot plot = ((IPlotObject)Axis).Plot;
					if (plot != null)
					{
						plot.ReCalcLayout();
						majorIncrement = Axis.ScaleDisplay.MajorIncrement;
						minorIncrement = Axis.ScaleDisplay.MinorIncrement;
						goto IL_00e5;
					}
					return;
				}
				goto IL_00e5;
			}
			return;
			IL_00e5:
			if (!AlignFirstDone)
			{
				if (AlignFirstStyle != PlotTrackingAlignFirstStyle.None)
				{
					DoAlignFirst(value);
					return;
				}
				m_AlignFirstDone = true;
			}
			if (ModeScroll)
			{
				if (ScrollCompressMax != 0.0)
				{
					double num2 = value + MaxMargin - Axis.ScaleRange.Min;
					if (Axis.ScaleRange.Span < num2)
					{
						num = Math.Min(ScrollCompressMax, num2);
					}
					if (num != Axis.ScaleRange.Span)
					{
						Axis.ScaleRange.Span = num;
						return;
					}
				}
				if (Style == PlotTrackingStyle.ScrollSmooth)
				{
					if (value > Axis.ScaleRange.Max - MaxMargin)
					{
						Axis.ScaleRange.Min = value - Axis.ScaleRange.Span + MaxMargin;
					}
					else if (value < Axis.ScaleRange.Min + MinMargin)
					{
						Axis.ScaleRange.Min = value - MinMargin;
					}
				}
				else if (Style == PlotTrackingStyle.ScrollPage && value > Axis.ScaleRange.Max - MaxMargin)
				{
					ScrollNewPage(value);
				}
			}
			else if (ModeExpandMinMax)
			{
				if ((Style == PlotTrackingStyle.ExpandMin || Style == PlotTrackingStyle.ExpandMinMax) && value < min + MinMargin)
				{
					min2 = value - MinMargin;
				}
				if ((Style == PlotTrackingStyle.ExpandMax || Style == PlotTrackingStyle.ExpandMinMax) && value > max - MaxMargin)
				{
					max2 = value + MaxMargin;
				}
				Axis.ScaleRange.SetMinMax(min2, max2);
				if (ExpandStyle == PlotTrackingExpandStyle.Major)
				{
					AdjustToIncrement(majorIncrement);
				}
				else if (ExpandStyle == PlotTrackingExpandStyle.Minor)
				{
					AdjustToIncrement(minorIncrement);
				}
			}
			else if (ModeExpandCollapse)
			{
				if (Style == PlotTrackingStyle.ExpandCollapse)
				{
					ZoomToFitAll();
				}
				if (Style == PlotTrackingStyle.ExpandCollapseInView)
				{
					ZoomToFitInView();
				}
				if (ExpandStyle == PlotTrackingExpandStyle.Major)
				{
					AdjustToIncrement(majorIncrement);
				}
				else if (ExpandStyle == PlotTrackingExpandStyle.Minor)
				{
					AdjustToIncrement(minorIncrement);
				}
			}
		}
	}
}
