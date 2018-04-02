using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Legend used to display a color gradient for an Image type channel")]
	public class PlotLegendChannelImage : PlotLegendBase
	{
		private string m_ChannelName;

		private int m_MarginOuterPixels;

		private int m_LengthPixels;

		private int m_GradientWidth;

		private int m_GradientMinHeight;

		private bool m_TicksVisible;

		private int m_TicksLength;

		private int m_TicksMargin;

		private double m_TicksLabelMargin;

		private bool m_TicksShowFirstAndLastOnly;

		private ArrayList m_Ticks;

		private Size m_MaxSizeTickLabels;

		private int m_TicksLabelMarginPixels;

		private TextFormatDouble m_TextFormat;

		private Color[] m_Colors;

		private float[] m_Positions;

		private int m_EndsMargin;

		private PlotChannelImage m_CachedChannel;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public TextFormatDouble TextFormat
		{
			get
			{
				return m_TextFormat;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int GradientWidth
		{
			get
			{
				return m_GradientWidth;
			}
			set
			{
				base.PropertyUpdateDefault("GradientWidth", value);
				if (GradientWidth != value)
				{
					m_GradientWidth = value;
					base.DoPropertyChange(this, "GradientWidth");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int GradientMinHeight
		{
			get
			{
				return m_GradientMinHeight;
			}
			set
			{
				base.PropertyUpdateDefault("GradientMinHeight", value);
				if (GradientMinHeight != value)
				{
					m_GradientMinHeight = value;
					base.DoPropertyChange(this, "GradientMinHeight");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool TicksVisible
		{
			get
			{
				return m_TicksVisible;
			}
			set
			{
				base.PropertyUpdateDefault("TicksVisible", value);
				if (TicksVisible != value)
				{
					m_TicksVisible = value;
					base.DoPropertyChange(this, "TicksVisible");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool TicksShowFirstAndLastOnly
		{
			get
			{
				return m_TicksShowFirstAndLastOnly;
			}
			set
			{
				base.PropertyUpdateDefault("TicksShowFirstAndLastOnly", value);
				if (TicksShowFirstAndLastOnly != value)
				{
					m_TicksShowFirstAndLastOnly = value;
					base.DoPropertyChange(this, "TicksShowFirstAndLastOnly");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int TicksLength
		{
			get
			{
				return m_TicksLength;
			}
			set
			{
				base.PropertyUpdateDefault("TicksLength", value);
				if (TicksLength != value)
				{
					m_TicksLength = value;
					base.DoPropertyChange(this, "TicksLength");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int TicksMargin
		{
			get
			{
				return m_TicksMargin;
			}
			set
			{
				base.PropertyUpdateDefault("TicksMargin", value);
				if (TicksMargin != value)
				{
					m_TicksMargin = value;
					base.DoPropertyChange(this, "TicksMargin");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double TicksLabelMargin
		{
			get
			{
				return m_TicksLabelMargin;
			}
			set
			{
				base.PropertyUpdateDefault("TicksLabelMargin", value);
				if (TicksLabelMargin != value)
				{
					m_TicksLabelMargin = value;
					base.DoPropertyChange(this, "TicksLabelMargin");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string ChannelName
		{
			get
			{
				if (m_ChannelName == null)
				{
					return Const.EmptyString;
				}
				return m_ChannelName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("ChannelName", value);
				if (ChannelName != value)
				{
					m_ChannelName = value;
					m_CachedChannel = null;
					m_CachedChannel = Channel;
					base.DoPropertyChange(this, "ChannelName");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		public PlotChannelImage Channel
		{
			get
			{
				if (m_CachedChannel != null)
				{
					return m_CachedChannel;
				}
				if (base.Plot == null)
				{
					return null;
				}
				m_CachedChannel = base.Plot.Channels.Image[ChannelName];
				return m_CachedChannel;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Legend Channel Image";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLegendChannelImageEditorPlugIn";
		}

		public PlotLegendChannelImage()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_TextFormat = new TextFormatDouble();
			base.AddSubClass(TextFormat);
			m_Ticks = new ArrayList();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "ChannelImage";
			base.DockAutoSizeAlignment = PlotDockAutoSizeAlignment.None;
			GradientWidth = 15;
			GradientMinHeight = 75;
			TicksVisible = true;
			TicksLength = 7;
			TicksMargin = 7;
			TicksLabelMargin = 0.5;
		}

		private bool ShouldSerializeTextFormat()
		{
			return ((ISubClassBase)TextFormat).ShouldSerialize();
		}

		private void ResetTextFormat()
		{
			((ISubClassBase)TextFormat).ResetToDefault();
		}

		private bool ShouldSerializeGradientWidth()
		{
			return base.PropertyShouldSerialize("GradientWidth");
		}

		private void ResetGradientWidth()
		{
			base.PropertyReset("GradientWidth");
		}

		private bool ShouldSerializeGradientMinHeight()
		{
			return base.PropertyShouldSerialize("GradientMinHeight");
		}

		private void ResetGradientMinHeight()
		{
			base.PropertyReset("GradientMinHeight");
		}

		private bool ShouldSerializeTicksVisible()
		{
			return base.PropertyShouldSerialize("TicksVisible");
		}

		private void ResetTicksVisible()
		{
			base.PropertyReset("TicksVisible");
		}

		private bool ShouldSerializeTicksShowFirstAndLastOnly()
		{
			return base.PropertyShouldSerialize("TicksShowFirstAndLastOnly");
		}

		private void ResetTicksShowFirstAndLastOnly()
		{
			base.PropertyReset("TicksShowFirstAndLastOnly");
		}

		private bool ShouldSerializeTicksLength()
		{
			return base.PropertyShouldSerialize("TicksLength");
		}

		private void ResetTicksLength()
		{
			base.PropertyReset("TicksLength");
		}

		private bool ShouldSerializeTicksMargin()
		{
			return base.PropertyShouldSerialize("TicksMargin");
		}

		private void ResetTicksMargin()
		{
			base.PropertyReset("TicksMargin");
		}

		private bool ShouldSerializeTicksLabelMargin()
		{
			return base.PropertyShouldSerialize("TicksLabelMargin");
		}

		private void ResetTicksLabelMargin()
		{
			base.PropertyReset("TicksLabelMargin");
		}

		private bool ShouldSerializeChannelName()
		{
			return base.PropertyShouldSerialize("ChannelName");
		}

		private void ResetChannelName()
		{
			base.PropertyReset("ChannelName");
		}

		public override void ObjectRenamed(PlotObject value, string oldName)
		{
			base.ObjectRenamed(value, oldName);
			if (value is PlotChannelBase && oldName == m_ChannelName)
			{
				m_ChannelName = value.Name;
			}
		}

		public override void ObjectRemoved(PlotObject value)
		{
			base.ObjectRemoved(value);
			if (value == m_CachedChannel)
			{
				m_CachedChannel = null;
			}
		}

		public override void ObjectAdded(PlotObject value)
		{
			base.ObjectAdded(value);
			if (value is PlotChannelImage && value.Name == m_ChannelName)
			{
				m_CachedChannel = (value as PlotChannelImage);
			}
		}

		protected override void PopulateContextMenu(ContextMenu menu)
		{
			base.PopulateContextMenu(menu);
			base.AddMenuItem(menu, "Edit Channel", MenuItemEditChannel_Click, false);
		}

		private void MenuItemEditChannel_Click(object sender, EventArgs e)
		{
			Channel.ShowEditorCustom(false, true);
		}

		private void GenerateTicks(PaintArgs p, PlotChannelImage channel)
		{
			m_Ticks.Clear();
			m_MaxSizeTickLabels = Size.Empty;
			double num = channel.IntensityGradient.Span / (double)(m_Positions.Length - 1);
			for (int i = 0; i < m_Positions.Length; i++)
			{
				double value = channel.IntensityGradient.Min + (double)i * num;
				string text = m_TextFormat.GetText(value);
				m_MaxSizeTickLabels = Math2.Max(m_MaxSizeTickLabels, p.Graphics.MeasureString(text, base.Font));
				m_Ticks.Add(text);
			}
		}

		protected override void CalculateDepthPixels(PaintArgs p)
		{
			m_MarginOuterPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(base.Font).Height * base.MarginOuter);
			m_TicksLabelMarginPixels = (int)((double)p.Graphics.MeasureString(base.Font).Width * TicksLabelMargin);
			m_LengthPixels = 100;
			PlotChannelImage channel = Channel;
			if (channel != null)
			{
				m_Colors = channel.IntensityGradient.Colors;
				m_Positions = channel.IntensityGradient.Positions;
				GenerateTicks(p, channel);
				m_EndsMargin = m_MarginOuterPixels + (int)Math.Ceiling((double)m_MaxSizeTickLabels.Height / 2.0);
				if (base.DockHorizontal)
				{
					m_LengthPixels += 2 * m_EndsMargin + GradientMinHeight;
				}
				else
				{
					m_LengthPixels += 2 * m_EndsMargin + GradientMinHeight;
				}
				base.DockDepthPixels = GradientWidth;
				if (TicksVisible)
				{
					base.DockDepthPixels += TicksMargin + TicksLength + m_TicksLabelMarginPixels + m_MaxSizeTickLabels.Width;
				}
				base.DockDepthPixels += 2 * m_MarginOuterPixels;
			}
		}

		protected override void DrawCalculations(PaintArgs p)
		{
			base.CalculateBoundsAlignment(m_LengthPixels);
		}

		private Bitmap GetGradientBitmap(int length, bool swapped)
		{
			Bitmap bitmap;
			Rectangle rect;
			LinearGradientBrush linearGradientBrush;
			if (!swapped)
			{
				bitmap = new Bitmap(GradientWidth, length);
				rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
				linearGradientBrush = new LinearGradientBrush(rect, Color.Orange, Color.Yellow, LinearGradientMode.Vertical);
			}
			else
			{
				bitmap = new Bitmap(length, GradientWidth);
				rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
				linearGradientBrush = new LinearGradientBrush(rect, Color.Orange, Color.Yellow, LinearGradientMode.Horizontal);
			}
			ColorBlend colorBlend = new ColorBlend();
			colorBlend.Colors = m_Colors;
			colorBlend.Positions = m_Positions;
			linearGradientBrush.InterpolationColors = colorBlend;
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.FillRectangle(linearGradientBrush, rect);
			graphics.Dispose();
			linearGradientBrush.Dispose();
			return bitmap;
		}

		private Bitmap GetStepBitmap(int length, bool swapped)
		{
			Bitmap bitmap = swapped ? new Bitmap(length, GradientWidth) : new Bitmap(GradientWidth, length);
			Graphics graphics = Graphics.FromImage(bitmap);
			for (int i = 0; i < m_Colors.Length - 1; i++)
			{
				int num = (int)(m_Positions[i] * (float)length);
				int num2 = (int)(m_Positions[i + 1] * (float)length);
				Rectangle rect = swapped ? Rectangle.FromLTRB(num, 0, num2, GradientWidth - 1) : Rectangle.FromLTRB(0, num, GradientWidth - 1, num2);
				SolidBrush solidBrush = new SolidBrush(m_Colors[i]);
				graphics.FillRectangle(solidBrush, rect);
				solidBrush.Dispose();
			}
			graphics.Dispose();
			return bitmap;
		}

		protected override void Draw(PaintArgs p)
		{
			base.I_Fill.Draw(p, base.BoundsAlignment);
			PlotChannelImage channel = Channel;
			if (channel != null)
			{
				Rectangle r = base.BoundsAlignment;
				r.Inflate(-m_MarginOuterPixels, -m_MarginOuterPixels);
				if (!base.DockVertical)
				{
					r.Inflate(0, -m_EndsMargin);
				}
				else
				{
					r.Inflate(-m_EndsMargin, 0);
				}
				int num = 0;
				int num2 = 0;
				bool dockVertical = base.DockVertical;
				int left = r.Left;
				int right = r.Right;
				int top = r.Top;
				int bottom = r.Bottom;
				int width = r.Width;
				int height = r.Height;
				bool stepsEnabled = channel.IntensityGradient.StepsEnabled;
				int num3 = dockVertical ? width : height;
				Bitmap image = (!stepsEnabled) ? GetGradientBitmap(num3, dockVertical) : GetStepBitmap(num3, dockVertical);
				if (base.DockRight)
				{
					p.Graphics.DrawImage(image, left, top);
				}
				else if (base.DockLeft)
				{
					p.Graphics.DrawImage(image, right - GradientWidth, top);
				}
				else if (base.DockTop)
				{
					p.Graphics.DrawImage(image, left, bottom - GradientWidth);
				}
				else if (base.DockBottom)
				{
					p.Graphics.DrawImage(image, left, top);
				}
				if (TicksVisible)
				{
					if (base.DockRight)
					{
						num = left + GradientWidth + TicksMargin;
					}
					else if (base.DockLeft)
					{
						num = right - GradientWidth - TicksMargin;
					}
					else if (base.DockTop)
					{
						num = bottom - GradientWidth - TicksMargin;
					}
					else if (base.DockBottom)
					{
						num = top + GradientWidth + TicksMargin;
					}
					if (base.DockRight)
					{
						num2 = num + TicksLength + m_TicksLabelMarginPixels;
					}
					else if (base.DockLeft)
					{
						num2 = num - TicksLength - m_TicksLabelMarginPixels;
					}
					else if (base.DockTop)
					{
						num2 = num - TicksLength - m_TicksLabelMarginPixels;
					}
					else if (base.DockBottom)
					{
						num2 = num + TicksLength + m_TicksLabelMarginPixels;
					}
					Size maxSizeTickLabels = m_MaxSizeTickLabels;
					DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
					genericTypographic.LineAlignment = StringAlignment.Center;
					genericTypographic.Alignment = StringAlignment.Far;
					Pen pen = p.Graphics.Pen(base.ForeColor);
					for (int i = 0; i < m_Positions.Length; i++)
					{
						string s = (string)m_Ticks[i];
						int num4 = dockVertical ? (left + (int)(m_Positions[i] * (float)num3)) : (top + (int)(m_Positions[i] * (float)num3));
						if (base.DockRight)
						{
							p.Graphics.DrawLine(pen, num, num4, num + TicksLength, num4);
						}
						else if (base.DockLeft)
						{
							p.Graphics.DrawLine(pen, num, num4, num - TicksLength, num4);
						}
						else if (base.DockTop)
						{
							p.Graphics.DrawLine(pen, num4, num, num4, num - TicksLength);
						}
						else if (base.DockBottom)
						{
							p.Graphics.DrawLine(pen, num4, num, num4, num + TicksLength);
						}
						if (base.DockRight)
						{
							r = new Rectangle(num2, num4 - maxSizeTickLabels.Height / 2, maxSizeTickLabels.Width, maxSizeTickLabels.Height);
						}
						else if (base.DockLeft)
						{
							r = new Rectangle(num2 - maxSizeTickLabels.Width, num4 - maxSizeTickLabels.Height / 2, maxSizeTickLabels.Width, maxSizeTickLabels.Height);
						}
						else if (base.DockTop)
						{
							r = new Rectangle(num4 - maxSizeTickLabels.Height / 2, num2 - maxSizeTickLabels.Width, maxSizeTickLabels.Height, maxSizeTickLabels.Width);
						}
						else if (base.DockBottom)
						{
							r = new Rectangle(num4 - maxSizeTickLabels.Height / 2, num2, maxSizeTickLabels.Height, maxSizeTickLabels.Width);
						}
						if (base.DockRight)
						{
							p.Graphics.DrawRotatedText(s, base.Font, base.ForeColor, r, TextRotation.X000, genericTypographic);
						}
						else if (base.DockLeft)
						{
							p.Graphics.DrawRotatedText(s, base.Font, base.ForeColor, r, TextRotation.X000, genericTypographic);
						}
						else if (base.DockTop)
						{
							p.Graphics.DrawRotatedText(s, base.Font, base.ForeColor, r, TextRotation.X090, genericTypographic);
						}
						else if (base.DockBottom)
						{
							p.Graphics.DrawRotatedText(s, base.Font, base.ForeColor, r, TextRotation.X090, genericTypographic);
						}
						if (TicksShowFirstAndLastOnly && i == 0)
						{
							i = m_Positions.Length - 2;
						}
					}
				}
			}
		}
	}
}
