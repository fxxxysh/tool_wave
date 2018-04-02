using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Marker.")]
	public class PlotMarker : SubClassBase, IPlotMarker
	{
		private PlotMarkerStyle m_Style;

		private PlotFill m_Fill;

		private IPlotFill I_Fill;

		private int m_Size;

		private string m_Text;

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

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotMarkerStyle Style
		{
			get
			{
				return m_Style;
			}
			set
			{
				base.PropertyUpdateDefault("Style", value);
				if (Style != value)
				{
					m_Style = value;
					base.DoPropertyChange(this, "Style");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int Size
		{
			get
			{
				return m_Size;
			}
			set
			{
				base.PropertyUpdateDefault("Size", value);
				if (Size != value)
				{
					m_Size = value;
					base.DoPropertyChange(this, "Size");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string Text
		{
			get
			{
				if (m_Text == null)
				{
					return Const.EmptyString;
				}
				return m_Text;
			}
			set
			{
				base.PropertyUpdateDefault("Text", value);
				if (Text != value)
				{
					m_Text = value;
					base.DoPropertyChange(this, "Text");
				}
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill Fill
		{
			get
			{
				return m_Fill;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Marker";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotMarkerEditorPlugIn";
		}

		void IPlotMarker.Draw(PaintArgs p, int x, int y, Brush brush, Pen pen)
		{
			Draw(p, x, y, brush, pen);
		}

		void IPlotMarker.Draw(PaintArgs p, int x, int y)
		{
			Draw(p, x, y);
		}

		void IPlotMarker.DrawLegend(PaintArgs p, Rectangle r)
		{
			DrawLegend(p, r);
		}

		public PlotMarker()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Fill = new PlotFill();
			base.AddSubClass(Fill);
			I_Fill = Fill;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Visible = true;
			Font = null;
			Style = PlotMarkerStyle.Circle;
			Size = 4;
			Text = "";
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeFont()
		{
			return base.PropertyShouldSerialize("Font");
		}

		private void ResetFont()
		{
			base.PropertyReset("Font");
		}

		private bool ShouldSerializeForeColor()
		{
			return base.PropertyShouldSerialize("ForeColor");
		}

		private void ResetForeColor()
		{
			base.PropertyReset("ForeColor");
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private bool ShouldSerializeSize()
		{
			return base.PropertyShouldSerialize("Size");
		}

		private void ResetSize()
		{
			base.PropertyReset("Size");
		}

		private bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetText()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeFill()
		{
			return ((ISubClassBase)Fill).ShouldSerialize();
		}

		private void ResetFill()
		{
			((ISubClassBase)Fill).ResetToDefault();
		}

		private void Draw(PaintArgs p, int x, int y)
		{
			Draw(p, x, y, null, null);
		}

		protected virtual void Draw(PaintArgs p, int x, int y, Brush brush, Pen pen)
		{
			Draw(p, x, y, brush, pen, Size);
		}

		protected virtual void DrawLegend(PaintArgs p, Rectangle r)
		{
			int num = r.Width / 3;
			if (num % 2 == 0)
			{
				num++;
			}
			if (Size < num)
			{
				num = Size;
			}
			Draw(p, (r.Left + r.Right) / 2, (r.Top + r.Bottom) / 2, null, null, num);
		}

		private void Draw(PaintArgs p, int x, int y, Brush brush, Pen pen, int size)
		{
			if (Visible && Fill.Visible && (Fill.Brush.Visible || Fill.Pen.Visible) && size >= 1)
			{
				Rectangle rectangle = new Rectangle(x - size, y - size, 2 * size, 2 * size);
				if (p.Graphics.ClipBounds.Contains(x, y))
				{
					if (brush == null && Fill.Brush.Visible)
					{
						brush = ((IPlotBrush)Fill.Brush).GetBrush(p, rectangle);
					}
					if (pen == null && Fill.Pen.Visible)
					{
						pen = ((IPlotPen)Fill.Pen).GetPen(p);
					}
					if (Style == PlotMarkerStyle.Circle)
					{
						if (Fill.Brush.Visible)
						{
							p.Graphics.FillEllipse(brush, rectangle);
						}
						if (Fill.Pen.Visible)
						{
							p.Graphics.DrawEllipse(pen, rectangle);
						}
					}
					else if (Style == PlotMarkerStyle.Square)
					{
						if (Fill.Brush.Visible)
						{
							p.Graphics.FillRectangle(brush, rectangle);
						}
						if (Fill.Pen.Visible)
						{
							p.Graphics.DrawRectangle(pen, rectangle);
						}
					}
					else if (Style == PlotMarkerStyle.Diamond)
					{
						Point[] points = new Point[4]
						{
							new Point(x, y - size),
							new Point(x + size, y),
							new Point(x, y + size),
							new Point(x - size, y)
						};
						if (Fill.Brush.Visible)
						{
							p.Graphics.FillPolygon(brush, points);
						}
						if (Fill.Pen.Visible)
						{
							p.Graphics.DrawPolygon(pen, points);
						}
					}
					else if (Style == PlotMarkerStyle.TriangleLeft)
					{
						Point[] points = new Point[3]
						{
							new Point(x, y),
							new Point(x + 2 * size, y - size),
							new Point(x + 2 * size, y + size)
						};
						if (Fill.Brush.Visible)
						{
							p.Graphics.FillPolygon(brush, points);
						}
						if (Fill.Pen.Visible)
						{
							p.Graphics.DrawPolygon(pen, points);
						}
					}
					else if (Style == PlotMarkerStyle.TriangleRight)
					{
						Point[] points = new Point[3]
						{
							new Point(x - 2 * size, y - size),
							new Point(x - 2 * size, y + size),
							new Point(x, y)
						};
						if (Fill.Brush.Visible)
						{
							p.Graphics.FillPolygon(brush, points);
						}
						if (Fill.Pen.Visible)
						{
							p.Graphics.DrawPolygon(pen, points);
						}
					}
					else if (Style == PlotMarkerStyle.TriangleUp)
					{
						Point[] points = new Point[3]
						{
							new Point(x, y),
							new Point(x + size, y + 2 * size),
							new Point(x - size, y + 2 * size)
						};
						if (Fill.Brush.Visible)
						{
							p.Graphics.FillPolygon(brush, points);
						}
						if (Fill.Pen.Visible)
						{
							p.Graphics.DrawPolygon(pen, points);
						}
					}
					else if (Style == PlotMarkerStyle.TriangleDown)
					{
						Point[] points = new Point[3]
						{
							new Point(x, y),
							new Point(x + size, y - 2 * size),
							new Point(x - size, y - 2 * size)
						};
						if (Fill.Brush.Visible)
						{
							p.Graphics.FillPolygon(brush, points);
						}
						if (Fill.Pen.Visible)
						{
							p.Graphics.DrawPolygon(pen, points);
						}
					}
					else if (Style == PlotMarkerStyle.Text)
					{
						DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
						genericTypographic.LineAlignment = StringAlignment.Center;
						genericTypographic.Alignment = StringAlignment.Center;
						p.Graphics.MeasureString(Text, Font);
						p.Graphics.DrawString(Text, Font, p.Graphics.Brush(ForeColor), (float)x, (float)y, genericTypographic);
					}
				}
			}
		}
	}
}
