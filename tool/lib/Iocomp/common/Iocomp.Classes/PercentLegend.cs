using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	public sealed class PercentLegend : SubClassBase, IPercentLegend
	{
		private const int m_ColorBarWidth = 15;

		private double m_Margin;

		private double m_TitleMargin;

		private double m_RowSpacing;

		private PercentLegendColumn m_ColumnValue;

		private PercentLegendColumn m_ColumnPercent;

		private Rectangle m_RectColorBar;

		private Rectangle m_RectTitle;

		private Rectangle m_RectValue;

		private Rectangle m_RectPercent;

		private int m_MarginPixels;

		private int m_RowHeightPixels;

		private int m_RowSpacingPixels;

		private int m_RowTotalHeightPixels;

		private int m_TotalHeight;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PercentLegendColumn ColumnValue
		{
			get
			{
				return m_ColumnValue;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PercentLegendColumn ColumnPercent
		{
			get
			{
				return m_ColumnPercent;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
		public new Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Margin
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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
		public double RowSpacing
		{
			get
			{
				return m_RowSpacing;
			}
			set
			{
				base.PropertyUpdateDefault("RowSpacing", value);
				if (RowSpacing != value)
				{
					m_RowSpacing = value;
					base.DoPropertyChange(this, "RowSpacing");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Legend";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PercentLegendEditorPlugIn";
		}

		Size IPercentLegend.GetRequiredSize(PaintArgs p, PercentItemCollection items)
		{
			return GetRequiredSize(p, items);
		}

		void IPercentLegend.Draw(PaintArgs p, PercentItemCollection items, Rectangle r)
		{
			Draw(p, items, r);
		}

		public PercentLegend()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_ColumnValue = new PercentLegendColumn();
			base.AddSubClass(ColumnValue);
			m_ColumnPercent = new PercentLegendColumn();
			base.AddSubClass(ColumnPercent);
		}

		private bool ShouldSerializeColumnValue()
		{
			return ((ISubClassBase)ColumnValue).ShouldSerialize();
		}

		private void ResetColumnValue()
		{
			((ISubClassBase)ColumnValue).ResetToDefault();
		}

		private bool ShouldSerializeColumnPercent()
		{
			return ((ISubClassBase)ColumnPercent).ShouldSerialize();
		}

		private void ResetColumnPercent()
		{
			((ISubClassBase)ColumnPercent).ResetToDefault();
		}

		private bool ShouldSerializeFont()
		{
			return base.PropertyShouldSerialize("Font");
		}

		private void ResetFont()
		{
			base.PropertyReset("Font");
		}

		private bool ShouldSerializeMargin()
		{
			return base.PropertyShouldSerialize("Margin");
		}

		private void ResetMargin()
		{
			base.PropertyReset("Margin");
		}

		private bool ShouldSerializeTitleMargin()
		{
			return base.PropertyShouldSerialize("TitleMargin");
		}

		private void ResetTitleMargin()
		{
			base.PropertyReset("TitleMargin");
		}

		private bool ShouldSerializeRowSpacing()
		{
			return base.PropertyShouldSerialize("RowSpacing");
		}

		private void ResetRowSpacing()
		{
			base.PropertyReset("RowSpacing");
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeForeColor()
		{
			return base.PropertyShouldSerialize("ForeColor");
		}

		private void ResetForeColor()
		{
			base.PropertyReset("ForeColor");
		}

		private void CalcRects(PaintArgs p, PercentItemCollection items)
		{
			int height = p.Graphics.MeasureString("0", Font).Height;
			int width = p.Graphics.MeasureString("0", Font, true).Width;
			m_MarginPixels = (int)((double)p.Graphics.MeasureString("0", Font, true).Width * Margin);
			m_RowHeightPixels = height;
			m_RowSpacingPixels = (int)((double)height * RowSpacing);
			m_RowTotalHeightPixels = m_RowHeightPixels + m_RowSpacingPixels;
			int num = (int)(TitleMargin * (double)width);
			int num2 = (int)(ColumnPercent.Margin * (double)width);
			int num3 = (int)(ColumnValue.Margin * (double)width);
			m_TotalHeight = m_RowHeightPixels * items.Count + m_RowSpacingPixels * (items.Count - 1);
			int width2 = 15;
			int requiredWidth = ((IPercentLegendColumn)ColumnValue).GetRequiredWidth(p, Font, items, true);
			int requiredWidth2 = ((IPercentLegendColumn)ColumnPercent).GetRequiredWidth(p, Font, items, false);
			int num4 = 0;
			foreach (PercentItem item in items)
			{
				num4 = Math.Max(p.Graphics.MeasureString(item.Title, Font, true).Width, num4);
			}
			m_RectColorBar = new Rectangle(m_MarginPixels, 0, width2, height);
			m_RectTitle = new Rectangle(m_RectColorBar.Right + num, 0, num4, height);
			m_RectValue = new Rectangle(m_RectTitle.Right + num3, 0, requiredWidth - num3, height);
			m_RectPercent = new Rectangle(m_RectValue.Right + num2, 0, requiredWidth2 - num2, height);
		}

		private Size GetRequiredSize(PaintArgs p, PercentItemCollection items)
		{
			if (!Visible)
			{
				return Size.Empty;
			}
			CalcRects(p, items);
			return new Size(m_RectPercent.Right, m_TotalHeight);
		}

		private void Draw(PaintArgs p, PercentItemCollection items, Rectangle r)
		{
			if (Visible)
			{
				CalcRects(p, items);
				int num = r.Top + (r.Height - m_TotalHeight) / 2;
				Brush brush = p.Graphics.Brush(ForeColor);
				DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
				genericTypographic.Alignment = StringAlignment.Near;
				DrawStringFormat genericTypographic2 = DrawStringFormat.GenericTypographic;
				genericTypographic2.Alignment = StringAlignment.Far;
				DrawStringFormat genericTypographic3 = DrawStringFormat.GenericTypographic;
				genericTypographic3.Alignment = StringAlignment.Far;
				m_RectColorBar.X = r.Left + m_RectColorBar.Left;
				m_RectTitle.X = r.Left + m_RectTitle.Left;
				m_RectValue.X = r.Left + m_RectValue.Left;
				m_RectPercent.X = r.Left + m_RectPercent.Left;
				foreach (PercentItem item in items)
				{
					m_RectColorBar.Y = num;
					m_RectTitle.Y = num;
					m_RectValue.Y = num;
					m_RectPercent.Y = num;
					string text = ColumnValue.Format.GetText(item.Value);
					string text2 = ColumnPercent.Format.GetText(items.GetItemPercent(item) * 100.0);
					p.Graphics.FillRectangle(new SolidBrush(item.Color), m_RectColorBar);
					p.Graphics.DrawString(item.Title, Font, brush, m_RectTitle, genericTypographic);
					if (ColumnValue.Visible)
					{
						p.Graphics.DrawString(text, Font, brush, m_RectValue, genericTypographic2);
					}
					if (ColumnPercent.Visible)
					{
						p.Graphics.DrawString(text2, Font, brush, m_RectPercent, genericTypographic3);
					}
					num += m_RowTotalHeightPixels;
				}
			}
		}
	}
}
