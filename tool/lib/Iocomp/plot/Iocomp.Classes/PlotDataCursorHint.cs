using Iocomp.Interfaces;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Data Cursor Hint")]
	public class PlotDataCursorHint : SubClassBase, IPlotDataCursorHint
	{
		private PlotDataCursorBase m_DataCursor;

		private double m_Position;

		private bool m_HideOnRelease;

		private bool m_Hide;

		private PlotFill m_Fill;

		private IPlotFill I_Fill;

		private string m_Text;

		private Region m_HitRegion;

		private bool m_MouseActive;

		private double m_MouseDownPosition;

		private double m_MouseDownActual;

		private PlotAxis m_AxisPosition;

		Region IPlotDataCursorHint.HitRegion
		{
			get
			{
				return m_HitRegion;
			}
			set
			{
				m_HitRegion = value;
			}
		}

		bool IPlotDataCursorHint.MouseActive
		{
			get
			{
				return m_MouseActive;
			}
			set
			{
				m_MouseActive = value;
			}
		}

		double IPlotDataCursorHint.MouseDownPosition
		{
			get
			{
				return m_MouseDownPosition;
			}
			set
			{
				m_MouseDownPosition = value;
			}
		}

		double IPlotDataCursorHint.MouseDownActual
		{
			get
			{
				return m_MouseDownActual;
			}
			set
			{
				m_MouseDownActual = value;
			}
		}

		PlotAxis IPlotDataCursorHint.AxisPosition
		{
			get
			{
				return m_AxisPosition;
			}
			set
			{
				m_AxisPosition = value;
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
				base.EnabledInternal = value;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("")]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double Position
		{
			get
			{
				return m_Position;
			}
			set
			{
				base.PropertyUpdateDefault("Position", value);
				value = Math2.Clamp(value, 0.02, 0.98);
				if (Position != value)
				{
					m_Position = value;
					base.DoPropertyChange(this, "Position");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool HideOnRelease
		{
			get
			{
				return m_HideOnRelease;
			}
			set
			{
				base.PropertyUpdateDefault("HideOnRelease", value);
				if (HideOnRelease != value)
				{
					m_HideOnRelease = value;
					base.DoPropertyChange(this, "HideOnRelease");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		public bool Hide
		{
			get
			{
				return m_Hide;
			}
			set
			{
				base.PropertyUpdateDefault("Hide", value);
				if (Hide != value)
				{
					m_Hide = value;
					base.DoPropertyChange(this, "Hide");
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
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		public string Text
		{
			get
			{
				return m_Text;
			}
			set
			{
				m_Text = value;
			}
		}

		private PlotXAxis XAxis
		{
			get
			{
				if (DataCursor == null)
				{
					return null;
				}
				return DataCursor.XAxis;
			}
		}

		private PlotYAxis YAxis
		{
			get
			{
				if (DataCursor == null)
				{
					return null;
				}
				return DataCursor.YAxis;
			}
		}

		private PlotDataCursorBase DataCursor => m_DataCursor;

		private Region HitRegion
		{
			get
			{
				return m_HitRegion;
			}
			set
			{
				m_HitRegion = value;
			}
		}

		private PlotAxis AxisPosition
		{
			get
			{
				return m_AxisPosition;
			}
			set
			{
				m_AxisPosition = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Data-Cursor Hint";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotDataCursorHintEditorPlugIn";
		}

		void IPlotDataCursorHint.Draw(PaintArgs p, PlotDataCursorDisplay display)
		{
			Draw(p, display);
		}

		public PlotDataCursorHint()
		{
			base.DoCreate();
		}

		public PlotDataCursorHint(PlotDataCursorBase value)
		{
			m_DataCursor = value;
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
			Enabled = true;
			ForeColor = SystemColors.InfoText;
			Font = null;
			Position = 0.5;
			HideOnRelease = false;
			Fill.Brush.SolidColor = SystemColors.Info;
			Fill.Pen.Color = SystemColors.InfoText;
		}

		private bool ShouldSerializeFill()
		{
			return ((ISubClassBase)Fill).ShouldSerialize();
		}

		private void ResetFill()
		{
			((ISubClassBase)Fill).ResetToDefault();
		}

		private bool ShouldSerializeEnabled()
		{
			return base.PropertyShouldSerialize("Enabled");
		}

		private void ResetEnabled()
		{
			base.PropertyReset("Enabled");
		}

		private bool ShouldSerializeForeColor()
		{
			return base.PropertyShouldSerialize("ForeColor");
		}

		private void ResetForeColor()
		{
			base.PropertyReset("ForeColor");
		}

		private bool ShouldSerializeFont()
		{
			return base.PropertyShouldSerialize("Font");
		}

		private void ResetFont()
		{
			base.PropertyReset("Font");
		}

		private bool ShouldSerializePosition()
		{
			return base.PropertyShouldSerialize("Position");
		}

		private void ResetPosition()
		{
			base.PropertyReset("Position");
		}

		private bool ShouldSerializeHideOnRelease()
		{
			return base.PropertyShouldSerialize("HideOnRelease");
		}

		private void ResetHideOnRelease()
		{
			base.PropertyReset("HideOnRelease");
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private void DrawHintBox(PaintArgs p, Rectangle r)
		{
			DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
			genericTypographic.Alignment = StringAlignment.Center;
			genericTypographic.LineAlignment = StringAlignment.Center;
			I_Fill.Draw(p, r);
			p.Graphics.DrawString(Text, Font, p.Graphics.Brush(ForeColor), r, genericTypographic);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(Rectangle.Intersect(DataCursor.BoundsClip, r));
			HitRegion = new Region(graphicsPath);
			if (DataCursor.Focused)
			{
				r.Inflate(-3, -3);
				p.Graphics.DrawFocusRectangle(r, Fill.Brush.SolidColor);
			}
		}

		private void Draw(PaintArgs p, PlotDataCursorDisplay display)
		{
			int num = 3;
			if (DataCursor.WindowShowing)
			{
				num += DataCursor.Window.Size;
			}
			if (HitRegion != null)
			{
				HitRegion.Dispose();
				HitRegion = null;
			}
			if (Visible && !Hide && DataCursor != null && XAxis != null && YAxis != null)
			{
				PlotDataCursorPointer pointer = DataCursor.Pointer1;
				PlotDataCursorPointer pointer2 = DataCursor.Pointer2;
				Pen pen = p.Graphics.Pen(DataCursor.Line.Color, DashStyle.Dash, (float)DataCursor.Line.Thickness);
				bool flag;
				int num2;
				if (pointer.Visible && pointer2.Visible && pointer.AxisPosition == pointer2.AxisPosition)
				{
					flag = true;
					AxisPosition = pointer.AxisRange;
					num2 = (pointer.PositionPixels + pointer2.PositionPixels) / 2;
				}
				else if (pointer.Visible && pointer2.Visible)
				{
					flag = false;
					if (pointer.AxisRange.DockHorizontal)
					{
						AxisPosition = pointer.AxisRange;
						num2 = pointer.PositionPixels;
					}
					else
					{
						AxisPosition = pointer2.AxisRange;
						num2 = pointer2.PositionPixels;
					}
				}
				else
				{
					flag = false;
					if (pointer.Visible)
					{
						AxisPosition = pointer.AxisRange;
						num2 = pointer.AxisPosition.PercentToPixels(display.XPosition);
					}
					else
					{
						AxisPosition = pointer2.AxisRange;
						num2 = pointer2.AxisPosition.PercentToPixels(display.YPosition);
					}
				}
				Orientation orientation = AxisPosition.DockHorizontal ? Orientation.Vertical : Orientation.Horizontal;
				Size size = p.Graphics.MeasureString(Text, Font);
				int width = size.Width;
				int height = size.Height;
				int num3 = width + 6;
				int num4 = height + 6;
				int num5 = AxisPosition.PercentToPixels(display.HintPosition);
				Rectangle r;
				if (orientation == Orientation.Vertical)
				{
					int num6 = width + num + 6;
					r = new Rectangle(num2 - num3 / 2, num5 - num4 / 2, num3, num4);
					if (!flag)
					{
						if (num2 + num6 > DataCursor.BoundsClip.Right)
						{
							r.Offset(-(num3 / 2 + num), 0);
						}
						else
						{
							r.Offset(num3 / 2 + num, 0);
						}
					}
					else
					{
						p.Graphics.DrawLine(pen, pointer.PositionPixels, num5, pointer2.PositionPixels, num5);
					}
				}
				else
				{
					int num6 = height + num + 6;
					r = new Rectangle(num5 - num3 / 2, num2 - num4 / 2, num3, num4);
					if (!flag)
					{
						if (num2 + num6 > DataCursor.BoundsClip.Bottom)
						{
							r.Offset(0, -(num4 / 2 + num));
						}
						else
						{
							r.Offset(0, num4 / 2 + num);
						}
					}
					else
					{
						p.Graphics.DrawLine(pen, num5, pointer.PositionPixels, num5, pointer2.PositionPixels);
					}
				}
				DrawHintBox(p, r);
			}
		}
	}
}
