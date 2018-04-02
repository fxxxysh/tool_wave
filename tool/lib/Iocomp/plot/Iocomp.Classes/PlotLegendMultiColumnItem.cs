using Iocomp.Design;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(CollectionItemConverter))]
	public sealed class PlotLegendMultiColumnItem : SubClassBase, IPlotLegendMultiColumnItem
	{
		private string m_TitleText;

		private bool m_TitleVisible;

		private Color m_TitleForeColor;

		private PlotFill m_TitleFill;

		private IPlotFill I_TitleFill;

		private TextLayoutHorizontal m_TitleLayout;

		private ITextLayoutHorizontal I_TitleLayout;

		private PlotLegendMultiColumnItemType m_DataType;

		private Color m_DataForeColor;

		private PlotFill m_DataFill;

		private IPlotFill I_DataFill;

		private TextLayoutHorizontal m_DataLayout;

		private ITextLayoutHorizontal I_DataLayout;

		private SizeStyle m_WidthStyle;

		private double m_Width;

		public Font m_DrawTitleFont;

		public Font m_DrawDataFont;

		public int m_DrawPixelsMarginOuter;

		public int m_DrawPixelsMarkerMinWidth;

		public int m_DrawPixelsTextWidth;

		public int m_DrawPixelsHeightTitle;

		public int m_DrawPixelsHeightData;

		public int m_DrawPixelsMargin;

		Font IPlotLegendMultiColumnItem.DrawTitleFont
		{
			get
			{
				return m_DrawTitleFont;
			}
			set
			{
				m_DrawTitleFont = value;
			}
		}

		Font IPlotLegendMultiColumnItem.DrawDataFont
		{
			get
			{
				return m_DrawDataFont;
			}
			set
			{
				m_DrawDataFont = value;
			}
		}

		int IPlotLegendMultiColumnItem.DrawPixelsMarginOuter
		{
			get
			{
				return m_DrawPixelsMarginOuter;
			}
			set
			{
				m_DrawPixelsMarginOuter = value;
			}
		}

		int IPlotLegendMultiColumnItem.DrawPixelsMarkerMinWidth
		{
			get
			{
				return m_DrawPixelsMarkerMinWidth;
			}
			set
			{
				m_DrawPixelsMarkerMinWidth = value;
			}
		}

		int IPlotLegendMultiColumnItem.DrawPixelsTextWidth
		{
			get
			{
				return m_DrawPixelsTextWidth;
			}
			set
			{
				m_DrawPixelsTextWidth = value;
			}
		}

		int IPlotLegendMultiColumnItem.DrawPixelsHeightTitle
		{
			get
			{
				return m_DrawPixelsHeightTitle;
			}
			set
			{
				m_DrawPixelsHeightTitle = value;
			}
		}

		int IPlotLegendMultiColumnItem.DrawPixelsHeightData
		{
			get
			{
				return m_DrawPixelsHeightData;
			}
			set
			{
				m_DrawPixelsHeightData = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill DataFill
		{
			get
			{
				return m_DataFill;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[RefreshProperties(RefreshProperties.All)]
		public PlotFill TitleFill
		{
			get
			{
				return m_TitleFill;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Controls the layout attrbitutes for the column title.")]
		public TextLayoutHorizontal TitleLayout
		{
			get
			{
				return m_TitleLayout;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Controls the layout attrbitutes for the column data.")]
		public TextLayoutHorizontal DataLayout
		{
			get
			{
				return m_DataLayout;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public PlotLegendMultiColumnItemType DataType
		{
			get
			{
				return m_DataType;
			}
			set
			{
				base.PropertyUpdateDefault("DataType", value);
				if (DataType != value)
				{
					m_DataType = value;
					base.DoPropertyChange(this, "DataType");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public string TitleText
		{
			get
			{
				return m_TitleText;
			}
			set
			{
				base.PropertyUpdateDefault("TitleText", value);
				if (TitleText != value)
				{
					m_TitleText = value;
					base.DoPropertyChange(this, "TitleText");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public bool TitleVisible
		{
			get
			{
				return m_TitleVisible;
			}
			set
			{
				base.PropertyUpdateDefault("TitleVisible", value);
				if (TitleVisible != value)
				{
					m_TitleVisible = value;
					base.DoPropertyChange(this, "TitleVisible");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public SizeStyle WidthStyle
		{
			get
			{
				return m_WidthStyle;
			}
			set
			{
				base.PropertyUpdateDefault("WidthStyle", value);
				if (WidthStyle != value)
				{
					m_WidthStyle = value;
					base.DoPropertyChange(this, "WidthStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public double Width
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

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color TitleForeColor
		{
			get
			{
				if (m_TitleForeColor == Color.Empty && base.AmbientOwner != null)
				{
					return base.AmbientOwner.ForeColor;
				}
				return m_TitleForeColor;
			}
			set
			{
				base.PropertyUpdateDefault("TitleForeColor", value);
				if (TitleForeColor != value)
				{
					m_TitleForeColor = value;
					base.DoPropertyChange(this, "TitleForeColor");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Category("Iocomp")]
		public Color DataForeColor
		{
			get
			{
				if (m_DataForeColor == Color.Empty && base.AmbientOwner != null)
				{
					return base.AmbientOwner.ForeColor;
				}
				return m_DataForeColor;
			}
			set
			{
				base.PropertyUpdateDefault("DataForeColor", value);
				if (DataForeColor != value)
				{
					m_DataForeColor = value;
					base.DoPropertyChange(this, "DataForeColor");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Plot Legend Multi-Column Item";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLegendMultiColumnEditorPlugIn";
		}

		void IPlotLegendMultiColumnItem.Calculate(PaintArgs p, PlotObjectCollection channels)
		{
			Calculate(p, channels);
		}

		void IPlotLegendMultiColumnItem.Draw(PaintArgs p, PlotObjectCollection channels, Rectangle r)
		{
			Draw(p, channels, r);
		}

		public PlotLegendMultiColumnItem()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_DataFill = new PlotFill();
			base.AddSubClass(DataFill);
			I_DataFill = DataFill;
			m_TitleFill = new PlotFill();
			base.AddSubClass(TitleFill);
			I_TitleFill = TitleFill;
			m_DataLayout = new TextLayoutHorizontal();
			base.AddSubClass(DataLayout);
			I_DataLayout = DataLayout;
			m_TitleLayout = new TextLayoutHorizontal();
			base.AddSubClass(TitleLayout);
			I_TitleLayout = TitleLayout;
		}

		protected override void SetDefaults()
		{
			DataType = PlotLegendMultiColumnItemType.XLast;
			TitleText = "Untitled";
			TitleVisible = true;
			TitleForeColor = Color.Empty;
			WidthStyle = SizeStyle.Auto;
			Width = 3.0;
			DataForeColor = Color.Empty;
			DataFill.Visible = false;
			TitleFill.Visible = false;
		}

		private bool ShouldSerializeDataFill()
		{
			return ((ISubClassBase)DataFill).ShouldSerialize();
		}

		private void ResetDataFill()
		{
			((ISubClassBase)DataFill).ResetToDefault();
		}

		private bool ShouldSerializeTitleFill()
		{
			return ((ISubClassBase)TitleFill).ShouldSerialize();
		}

		private void ResetTitleFill()
		{
			((ISubClassBase)TitleFill).ResetToDefault();
		}

		private bool ShouldSerializeTitleLayout()
		{
			return ((ISubClassBase)TitleLayout).ShouldSerialize();
		}

		private void ResetTitleLayout()
		{
			((ISubClassBase)TitleLayout).ResetToDefault();
		}

		private bool ShouldSerializeDataLayout()
		{
			return ((ISubClassBase)DataLayout).ShouldSerialize();
		}

		private void ResetDataLayout()
		{
			((ISubClassBase)DataLayout).ResetToDefault();
		}

		private bool ShouldSerializeDataType()
		{
			return base.PropertyShouldSerialize("DataType");
		}

		private void ResetDataType()
		{
			base.PropertyReset("DataType");
		}

		private bool ShouldSerializeTitleText()
		{
			return base.PropertyShouldSerialize("TitleText");
		}

		private void ResetTitleText()
		{
			base.PropertyReset("TitleText");
		}

		private bool ShouldSerializeTitleVisible()
		{
			return base.PropertyShouldSerialize("TitleVisible");
		}

		private void ResetTitleVisible()
		{
			base.PropertyReset("TitleVisible");
		}

		private bool ShouldSerializeWidthStyle()
		{
			return base.PropertyShouldSerialize("WidthStyle");
		}

		private void ResetWidthStyle()
		{
			base.PropertyReset("WidthStyle");
		}

		private bool ShouldSerializeWidth()
		{
			return base.PropertyShouldSerialize("Width");
		}

		private void ResetWidth()
		{
			base.PropertyReset("Width");
		}

		private bool ShouldSerializeTitleForeColor()
		{
			return base.PropertyShouldSerialize("TitleForeColor");
		}

		private void ResetTitleForeColor()
		{
			base.PropertyReset("TitleForeColor");
		}

		private bool ShouldSerializeDataForeColor()
		{
			return base.PropertyShouldSerialize("DataForeColor");
		}

		private void ResetDataForeColor()
		{
			base.PropertyReset("DataForeColor");
		}

		public override string ToString()
		{
			return TitleText;
		}

		private void Calculate(PaintArgs p, PlotObjectCollection channels)
		{
			m_DrawPixelsTextWidth = 0;
			m_DrawPixelsHeightTitle = 0;
			m_DrawPixelsHeightData = 0;
			if (TitleVisible)
			{
				m_DrawPixelsHeightTitle = p.Graphics.MeasureString(TitleText, m_DrawDataFont).Height;
			}
			if (m_WidthStyle == SizeStyle.FixedCharacters)
			{
				m_DrawPixelsTextWidth = (int)Math.Ceiling((double)p.Graphics.MeasureString(m_DrawTitleFont).Width * Width);
			}
			else if (m_WidthStyle == SizeStyle.FixedPixels)
			{
				m_DrawPixelsTextWidth = (int)Math.Ceiling(Width);
			}
			else if (m_WidthStyle == SizeStyle.Auto)
			{
				m_DrawPixelsTextWidth = (int)Math.Ceiling((double)p.Graphics.MeasureString(m_DrawTitleFont).Width * Width);
				if (TitleVisible)
				{
					m_DrawPixelsTextWidth = Math.Max(m_DrawPixelsTextWidth, I_TitleLayout.GetRequiredSize(TitleText, m_DrawTitleFont, p.Graphics).Width);
				}
			}
			string s = "";
			foreach (PlotChannelBase channel in channels)
			{
				if (DataType == PlotLegendMultiColumnItemType.Marker)
				{
					m_DrawPixelsTextWidth = Math.Max(m_DrawPixelsTextWidth, m_DrawPixelsMarkerMinWidth);
					m_DrawPixelsHeightData = m_DrawPixelsMarkerMinWidth;
					break;
				}
				if (DataType == PlotLegendMultiColumnItemType.ChannelTitle)
				{
					s = channel.DisplayDescription;
				}
				else if (DataType == PlotLegendMultiColumnItemType.DataPointCount)
				{
					s = channel.Count.ToString();
				}
				else if (DataType == PlotLegendMultiColumnItemType.XFirst)
				{
					s = channel.GetXValueText(channel.XFirst);
				}
				else if (DataType == PlotLegendMultiColumnItemType.XLast)
				{
					s = channel.GetXValueText(channel.XLast);
				}
				else if (DataType == PlotLegendMultiColumnItemType.XMax)
				{
					s = channel.GetXValueText(channel.XMax);
				}
				else if (DataType == PlotLegendMultiColumnItemType.XMean)
				{
					s = channel.GetXValueText(channel.XMean);
				}
				else if (DataType == PlotLegendMultiColumnItemType.XMin)
				{
					s = channel.GetXValueText(channel.XMin);
				}
				else if (DataType == PlotLegendMultiColumnItemType.XStandardDeviation)
				{
					s = channel.GetXValueText(channel.XStandardDeviation);
				}
				else if (DataType == PlotLegendMultiColumnItemType.YFirst)
				{
					s = channel.GetYValueText(channel.YFirst);
				}
				else if (DataType == PlotLegendMultiColumnItemType.YLast)
				{
					s = channel.GetYValueText(channel.YLast);
				}
				else if (DataType == PlotLegendMultiColumnItemType.YMax)
				{
					s = channel.GetYValueText(channel.YMax);
				}
				else if (DataType == PlotLegendMultiColumnItemType.YMean)
				{
					s = channel.GetYValueText(channel.YMean);
				}
				else if (DataType == PlotLegendMultiColumnItemType.YMin)
				{
					s = channel.GetYValueText(channel.YMin);
				}
				else if (DataType == PlotLegendMultiColumnItemType.YStandardDeviation)
				{
					s = channel.GetYValueText(channel.YStandardDeviation);
				}
				Size requiredSize = I_DataLayout.GetRequiredSize(s, m_DrawDataFont, p.Graphics);
				if (m_WidthStyle == SizeStyle.Auto)
				{
					m_DrawPixelsTextWidth = Math.Max(m_DrawPixelsTextWidth, requiredSize.Width);
				}
				m_DrawPixelsHeightData = requiredSize.Height;
			}
		}

		private void Draw(PaintArgs p, PlotObjectCollection channels, Rectangle r)
		{
			Rectangle r2 = new Rectangle(r.Left, r.Top, r.Width, m_DrawPixelsHeightTitle + 2 * m_DrawPixelsMarginOuter);
			Rectangle r3 = new Rectangle(r.Left, r2.Bottom, r.Width, r.Height - r2.Height);
			I_TitleFill.Draw(p, r2);
			I_DataFill.Draw(p, r3);
			string s = "";
			int num = 0;
			int x = r3.Left + m_DrawPixelsMarginOuter;
			int num2 = m_DrawPixelsHeightData + 2 * m_DrawPixelsMarginOuter;
			int width = r3.Width - 2 * m_DrawPixelsMarginOuter;
			if (TitleVisible)
			{
				Rectangle r4 = new Rectangle(x, r2.Top + m_DrawPixelsMarginOuter, width, m_DrawPixelsHeightTitle);
				I_TitleLayout.Draw(p.Graphics, m_DrawTitleFont, p.Graphics.Brush(TitleForeColor), TitleText, r4);
			}
			foreach (PlotChannelBase channel in channels)
			{
				Rectangle r4 = new Rectangle(x, r3.Top + num * num2 + m_DrawPixelsMarginOuter, width, m_DrawPixelsHeightData);
				if (DataType == PlotLegendMultiColumnItemType.Marker)
				{
					((IPlotChannelBase)channel).DrawLegendMarker(p, r4);
					num++;
				}
				else
				{
					if (DataType == PlotLegendMultiColumnItemType.ChannelTitle)
					{
						s = channel.DisplayDescription;
					}
					else if (DataType == PlotLegendMultiColumnItemType.DataPointCount)
					{
						s = channel.Count.ToString();
					}
					else if (DataType == PlotLegendMultiColumnItemType.XFirst)
					{
						s = channel.GetXValueText(channel.XFirst);
					}
					else if (DataType == PlotLegendMultiColumnItemType.XLast)
					{
						s = channel.GetXValueText(channel.XLast);
					}
					else if (DataType == PlotLegendMultiColumnItemType.XMax)
					{
						s = channel.GetXValueText(channel.XMax);
					}
					else if (DataType == PlotLegendMultiColumnItemType.XMean)
					{
						s = channel.GetXValueText(channel.XMean);
					}
					else if (DataType == PlotLegendMultiColumnItemType.XMin)
					{
						s = channel.GetXValueText(channel.XMin);
					}
					else if (DataType == PlotLegendMultiColumnItemType.XStandardDeviation)
					{
						s = channel.GetXValueText(channel.XStandardDeviation);
					}
					else if (DataType == PlotLegendMultiColumnItemType.YFirst)
					{
						s = channel.GetYValueText(channel.YFirst);
					}
					else if (DataType == PlotLegendMultiColumnItemType.YLast)
					{
						s = channel.GetYValueText(channel.YLast);
					}
					else if (DataType == PlotLegendMultiColumnItemType.YMax)
					{
						s = channel.GetYValueText(channel.YMax);
					}
					else if (DataType == PlotLegendMultiColumnItemType.YMean)
					{
						s = channel.GetYValueText(channel.YMean);
					}
					else if (DataType == PlotLegendMultiColumnItemType.YMin)
					{
						s = channel.GetYValueText(channel.YMin);
					}
					else if (DataType == PlotLegendMultiColumnItemType.YStandardDeviation)
					{
						s = channel.GetYValueText(channel.YStandardDeviation);
					}
					I_DataLayout.Draw(p.Graphics, m_DrawDataFont, p.Graphics.Brush(DataForeColor), s, r4);
					num++;
				}
			}
		}
	}
}
