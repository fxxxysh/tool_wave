using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Basic legend used to display a list of channels")]
	public class PlotLegendBasic : PlotLegendBase
	{
		private double m_TitleMargin;

		private double m_Spacing;

		private PlotLegendWrapping m_Wrapping;

		private iRectangle m_Rect;

		private int m_MarginOuterPixels;

		private int m_MarkerSize;

		private int m_MarkerWidthPixels;

		private int m_TitleMarginPixels;

		private int m_LengthPixels;

		private int m_SpacingPixels;

		private int m_MaxElementCount;

		private int m_MaxElementWidth;

		private int m_WrapCount;

		private int m_WrapMarginPixels;

		[Category("Iocomp")]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotLegendWrapping Wrapping
		{
			get
			{
				return m_Wrapping;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double TitleMargin
		{
			get
			{
				return m_TitleMargin;
			}
			set
			{
				base.PropertyUpdateDefault("TitleMargin", value);
				if (TitleMargin != value)
				{
					m_TitleMargin = value;
					base.DoPropertyChange(this, "TitleMargin");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double Spacing
		{
			get
			{
				return m_Spacing;
			}
			set
			{
				base.PropertyUpdateDefault("Spacing", value);
				if (Spacing != value)
				{
					m_Spacing = value;
					base.DoPropertyChange(this, "Spacing");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Legend Basic";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLegendBasicEditorPlugIn";
		}

		public PlotLegendBasic()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Wrapping = new PlotLegendWrapping();
			base.AddSubClass(Wrapping);
			m_Rect = new iRectangle();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Basic";
			TitleMargin = 1.0;
			Spacing = 0.5;
		}

		private bool ShouldSerializeTracking()
		{
			return ((ISubClassBase)Wrapping).ShouldSerialize();
		}

		private void ResetTracking()
		{
			((ISubClassBase)Wrapping).ResetToDefault();
		}

		private bool ShouldSerializeTitleMargin()
		{
			return base.PropertyShouldSerialize("TitleMargin");
		}

		private void ResetTitleMargin()
		{
			base.PropertyReset("TitleMargin");
		}

		private bool ShouldSerializeSpacing()
		{
			return base.PropertyShouldSerialize("Spacing");
		}

		private void ResetSpacing()
		{
			base.PropertyReset("Spacing");
		}

		protected override void CalculateDepthPixels(PaintArgs p)
		{
			base.UpdateChannelList();
			m_MarginOuterPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(base.Font).Height * base.MarginOuter);
			m_MarkerSize = p.Graphics.MeasureString(base.Font).Height;
			m_TitleMarginPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(base.Font).Width * TitleMargin);
			m_WrapMarginPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(base.Font).Width * Wrapping.Margin);
			m_MarkerWidthPixels = m_MarkerSize;
			int num = 0;
			foreach (PlotChannelBase channel in base.Channels)
			{
				num = (int)Math.Ceiling((double)Math.Max(num, p.Graphics.MeasureString(channel.DisplayDescription, base.Font).Width));
			}
			m_SpacingPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(base.Font).Width * Spacing);
			m_MaxElementWidth = m_MarkerWidthPixels + m_TitleMarginPixels + num;
			if (base.DockHorizontal)
			{
				m_MaxElementCount = (base.Bounds.Height + m_SpacingPixels - m_MarginOuterPixels) / (m_MarkerSize + m_SpacingPixels);
				if (m_MaxElementCount == 0)
				{
					m_MaxElementCount = 1;
				}
				if (m_MaxElementCount > base.Channels.Count)
				{
					m_MaxElementCount = base.Channels.Count;
				}
				if (Wrapping.Enabled)
				{
					m_WrapCount = (int)Math.Ceiling((double)base.Channels.Count / (double)m_MaxElementCount);
				}
				else
				{
					m_WrapCount = 1;
				}
				m_LengthPixels = m_MaxElementCount * m_MarkerSize + (m_MaxElementCount - 1) * m_SpacingPixels;
				base.DockDepthPixels = m_MaxElementWidth * m_WrapCount + (m_WrapCount - 1) * m_WrapMarginPixels;
			}
			else
			{
				m_MaxElementCount = (base.Bounds.Width + m_SpacingPixels - m_MarginOuterPixels) / (m_MaxElementWidth + m_SpacingPixels);
				if (m_MaxElementCount == 0)
				{
					m_MaxElementCount = 1;
				}
				if (m_MaxElementCount > base.Channels.Count)
				{
					m_MaxElementCount = base.Channels.Count;
				}
				if (Wrapping.Enabled)
				{
					m_WrapCount = (int)Math.Ceiling((double)base.Channels.Count / (double)m_MaxElementCount);
				}
				else
				{
					m_WrapCount = 1;
				}
				m_LengthPixels = m_MaxElementWidth + (m_MaxElementCount - 1) * (m_MaxElementWidth + m_SpacingPixels);
				base.DockDepthPixels = m_MarkerSize + (m_WrapCount - 1) * (m_MarkerSize + m_WrapMarginPixels);
			}
			m_LengthPixels += 2 * m_MarginOuterPixels;
			base.DockDepthPixels += 2 * m_MarginOuterPixels;
		}

		protected override void DrawCalculations(PaintArgs p)
		{
			base.CalculateBoundsAlignment(m_LengthPixels);
		}

		protected override void Draw(PaintArgs p)
		{
			base.I_Fill.Draw(p, base.BoundsAlignment);
			DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
			genericTypographic.Alignment = StringAlignment.Near;
			genericTypographic.LineAlignment = StringAlignment.Near;
			Brush brush = p.Graphics.Brush(base.ForeColor);
			m_Rect.Rectangle = base.BoundsAlignment;
			Size size;
			Rectangle rectangle;
			if (base.DockHorizontal)
			{
				int num = base.BoundsAlignment.Top + m_MarginOuterPixels;
				int num2 = base.BoundsAlignment.Left + m_MarginOuterPixels;
				m_Rect.Top = num;
				m_Rect.Height = m_MarkerSize;
				m_Rect.Width = m_MarkerWidthPixels;
				for (int i = 0; i < base.Channels.Count; i++)
				{
					PlotChannelBase plotChannelBase = base.Channels[i] as PlotChannelBase;
					if (plotChannelBase != null)
					{
						string displayDescription = plotChannelBase.DisplayDescription;
						size = p.Graphics.MeasureString(displayDescription, base.Font);
						int num3 = i / m_MaxElementCount;
						int num4 = i % m_MaxElementCount;
						m_Rect.Top = num + num4 * (m_SpacingPixels + m_MarkerSize);
						m_Rect.Left = num2 + num3 * (m_MaxElementWidth + m_WrapMarginPixels);
						rectangle = new Rectangle(m_Rect.Left - m_MarginOuterPixels, m_Rect.Top, m_MarginOuterPixels + m_MarkerWidthPixels + m_TitleMarginPixels + size.Width, size.Height);
						rectangle.Inflate(1, 1);
						plotChannelBase.LegendRectangle = rectangle;
						if (plotChannelBase.Focused && !rectangle.IsEmpty)
						{
							p.Graphics.DrawFocusRectangle(rectangle, base.BackColor);
						}
						((IPlotChannelBase)plotChannelBase).DrawLegendMarker(p, m_Rect.Rectangle);
						m_Rect.Left = num2 + num3 * (m_MaxElementWidth + m_WrapMarginPixels) + m_MarkerWidthPixels + m_TitleMarginPixels;
						p.Graphics.DrawString(displayDescription, base.Font, brush, (float)m_Rect.Left, (float)m_Rect.Top, genericTypographic);
					}
				}
			}
			else
			{
				int num = base.BoundsAlignment.Top + m_MarginOuterPixels;
				int num2 = base.BoundsAlignment.Left + m_MarginOuterPixels;
				m_Rect.Top = num;
				m_Rect.Left = num2;
				m_Rect.Height = m_MarkerSize;
				m_Rect.Width = m_MarkerWidthPixels;
				for (int j = 0; j < base.Channels.Count; j++)
				{
					PlotChannelBase plotChannelBase = base.Channels[j] as PlotChannelBase;
					string displayDescription = plotChannelBase.DisplayDescription;
					size = p.Graphics.MeasureString(displayDescription, base.Font);
					int num3 = j / m_MaxElementCount;
					int num4 = j % m_MaxElementCount;
					m_Rect.Top = num + num3 * (m_WrapMarginPixels + m_MarkerSize);
					m_Rect.Left = num2 + num4 * (m_MaxElementWidth + m_SpacingPixels);
					rectangle = new Rectangle(m_Rect.Left - m_MarginOuterPixels, m_Rect.Top, m_MarginOuterPixels + m_MarkerWidthPixels + m_TitleMarginPixels + size.Width, size.Height);
					rectangle.Inflate(1, 1);
					plotChannelBase.LegendRectangle = rectangle;
					if (plotChannelBase.Focused && !rectangle.IsEmpty)
					{
						p.Graphics.DrawFocusRectangle(rectangle, base.BackColor);
					}
					((IPlotChannelBase)plotChannelBase).DrawLegendMarker(p, m_Rect.Rectangle);
					m_Rect.Left = num2 + num4 * (m_MaxElementWidth + m_SpacingPixels) + m_MarkerWidthPixels + m_TitleMarginPixels;
					p.Graphics.DrawString(displayDescription, base.Font, brush, (float)m_Rect.Left, (float)m_Rect.Top, genericTypographic);
				}
			}
		}
	}
}
