using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Data-View.")]
	public class PlotDataView : PlotLayoutDataView
	{
		private PlotFillGrid m_FillInside;

		private PlotFill m_FillOutside;

		private string m_GridLinesMirrorVertical;

		private string m_GridLinesMirrorHorizontal;

		private bool m_AxesControlEnabled;

		private PlotDataViewAxesControlStyle m_AxesControlMouseStyle;

		private PlotDataViewAxesControlStyle m_AxesControlWheelStyle;

		private PlotDataViewAxesControlStyle m_AxesControlKeyboardStyle;

		private Cursor m_CursorSelectMode;

		private Cursor m_CursorZoomBoxMode;

		private Cursor m_CursorDataCursorMode;

		private int m_ZoomBoxStartX;

		private int m_ZoomBoxStartY;

		private int m_ZoomBoxStopX;

		private int m_ZoomBoxStopY;

		private PlotLayoutBaseCollection m_ZoomBoxAxes;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotFillGrid FillInside
		{
			get
			{
				return m_FillInside;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill FillOutside
		{
			get
			{
				return m_FillOutside;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public new Color Color
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.Color = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string GridLinesMirrorVertical
		{
			get
			{
				return m_GridLinesMirrorVertical;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				value = value.Trim();
				base.PropertyUpdateDefault("GridLinesMirrorVertical", value);
				if (GridLinesMirrorVertical != value)
				{
					m_GridLinesMirrorVertical = value;
					base.DoPropertyChange(this, "GridLinesMirrorVertical");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string GridLinesMirrorHorizontal
		{
			get
			{
				return m_GridLinesMirrorHorizontal;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				value = value.Trim();
				base.PropertyUpdateDefault("GridLinesMirrorHorizontal", value);
				if (GridLinesMirrorHorizontal != value)
				{
					m_GridLinesMirrorHorizontal = value;
					base.DoPropertyChange(this, "GridLinesMirrorHorizontal");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool AxesControlEnabled
		{
			get
			{
				return m_AxesControlEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("AxesControlEnabled", value);
				if (AxesControlEnabled != value)
				{
					m_AxesControlEnabled = value;
					base.DoPropertyChange(this, "AxesControlEnabled");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotDataViewAxesControlStyle AxesControlMouseStyle
		{
			get
			{
				return m_AxesControlMouseStyle;
			}
			set
			{
				base.PropertyUpdateDefault("AxesControlMouseStyle", value);
				if (AxesControlMouseStyle != value)
				{
					m_AxesControlMouseStyle = value;
					base.DoPropertyChange(this, "AxesControlMouseStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotDataViewAxesControlStyle AxesControlWheelStyle
		{
			get
			{
				return m_AxesControlWheelStyle;
			}
			set
			{
				base.PropertyUpdateDefault("AxesControlWheelStyle", value);
				if (AxesControlWheelStyle != value)
				{
					m_AxesControlWheelStyle = value;
					base.DoPropertyChange(this, "AxesControlWheelStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotDataViewAxesControlStyle AxesControlKeyboardStyle
		{
			get
			{
				return m_AxesControlKeyboardStyle;
			}
			set
			{
				base.PropertyUpdateDefault("AxesControlKeyboardStyle", value);
				if (AxesControlKeyboardStyle != value)
				{
					m_AxesControlKeyboardStyle = value;
					base.DoPropertyChange(this, "AxesControlKeyboardStyle");
				}
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		public Cursor CursorSelectMode
		{
			get
			{
				return m_CursorSelectMode;
			}
			set
			{
				m_CursorSelectMode = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Cursor CursorZoomBoxMode
		{
			get
			{
				return m_CursorZoomBoxMode;
			}
			set
			{
				m_CursorZoomBoxMode = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Cursor CursorDataCursorMode
		{
			get
			{
				return m_CursorDataCursorMode;
			}
			set
			{
				m_CursorDataCursorMode = value;
			}
		}

		[Description("")]
		[Browsable(false)]
		public PlotDataViewMouseMode MouseMode
		{
			get
			{
				if (base.Plot == null)
				{
					return PlotDataViewMouseMode.Select;
				}
				return base.Plot.ToolBarAdapter.DataViewMouseMode;
			}
		}

		private Color SolidColor => Color;

		private Color HatchForeColor => Color;

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

		protected bool AllowAxesControlMouse
		{
			get
			{
				if (!AxesControlEnabled)
				{
					return false;
				}
				if (AxesControlMouseStyle == PlotDataViewAxesControlStyle.None)
				{
					return false;
				}
				return true;
			}
		}

		protected bool AllowAxesControlMouseX
		{
			get
			{
				if (!AxesControlEnabled)
				{
					return false;
				}
				if (AxesControlMouseStyle == PlotDataViewAxesControlStyle.XAxes)
				{
					return true;
				}
				if (AxesControlMouseStyle == PlotDataViewAxesControlStyle.Both)
				{
					return true;
				}
				return false;
			}
		}

		protected bool AllowAxesControlMouseY
		{
			get
			{
				if (!AxesControlEnabled)
				{
					return false;
				}
				if (AxesControlMouseStyle == PlotDataViewAxesControlStyle.YAxes)
				{
					return true;
				}
				if (AxesControlMouseStyle == PlotDataViewAxesControlStyle.Both)
				{
					return true;
				}
				return false;
			}
		}

		protected bool AllowAxesControlWheel
		{
			get
			{
				if (!AxesControlEnabled)
				{
					return false;
				}
				if (AxesControlWheelStyle == PlotDataViewAxesControlStyle.None)
				{
					return false;
				}
				return true;
			}
		}

		protected bool AllowAxesControlWheelX
		{
			get
			{
				if (!AxesControlEnabled)
				{
					return false;
				}
				if (AxesControlWheelStyle == PlotDataViewAxesControlStyle.XAxes)
				{
					return true;
				}
				if (AxesControlWheelStyle == PlotDataViewAxesControlStyle.Both)
				{
					return true;
				}
				return false;
			}
		}

		protected bool AllowAxesControlWheelY
		{
			get
			{
				if (!AxesControlEnabled)
				{
					return false;
				}
				if (AxesControlWheelStyle == PlotDataViewAxesControlStyle.YAxes)
				{
					return true;
				}
				if (AxesControlWheelStyle == PlotDataViewAxesControlStyle.Both)
				{
					return true;
				}
				return false;
			}
		}

		protected bool AllowAxesControlKeyboard
		{
			get
			{
				if (!AxesControlEnabled)
				{
					return false;
				}
				if (AxesControlKeyboardStyle == PlotDataViewAxesControlStyle.None)
				{
					return false;
				}
				return true;
			}
		}

		protected bool AllowAxesControlKeyboardX
		{
			get
			{
				if (!AxesControlEnabled)
				{
					return false;
				}
				if (AxesControlKeyboardStyle == PlotDataViewAxesControlStyle.XAxes)
				{
					return true;
				}
				if (AxesControlKeyboardStyle == PlotDataViewAxesControlStyle.Both)
				{
					return true;
				}
				return false;
			}
		}

		protected bool AllowAxesControlKeyboardY
		{
			get
			{
				if (!AxesControlEnabled)
				{
					return false;
				}
				if (AxesControlKeyboardStyle == PlotDataViewAxesControlStyle.YAxes)
				{
					return true;
				}
				if (AxesControlKeyboardStyle == PlotDataViewAxesControlStyle.Both)
				{
					return true;
				}
				return false;
			}
		}

		public event PlotDataViewZoomBoxEventHandler BeforeZoomBox;

		protected override string GetPlugInTitle()
		{
			return "Data-View";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotDataViewEditorPlugIn";
		}

		public PlotDataView()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_ZoomBoxAxes = new PlotLayoutBaseCollection();
			m_FillInside = new PlotFillGrid();
			base.AddSubClass(FillInside);
			m_FillOutside = new PlotFill();
			base.AddSubClass(FillOutside);
			((ISubClassBase)FillInside.Pen).ColorAmbientSource = AmbientColorSouce.CustomColor1;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Color = Color.Empty;
			GridLinesMirrorVertical = "";
			GridLinesMirrorHorizontal = "";
			FillInside.Brush.Visible = false;
			FillInside.Brush.Style = PlotBrushStyle.Solid;
			FillInside.Brush.SolidColor = Color.Empty;
			FillInside.Brush.GradientStartColor = Color.Blue;
			FillInside.Brush.GradientStopColor = Color.Aqua;
			FillInside.Brush.HatchForeColor = Color.Empty;
			FillInside.Brush.HatchBackColor = Color.Empty;
			FillInside.Pen.Visible = true;
			FillInside.Pen.Style = PlotPenStyle.Solid;
			FillInside.Pen.Color = Color.Empty;
			FillInside.Pen.Thickness = 1.0;
			FillOutside.Brush.Visible = false;
			FillOutside.Brush.Style = PlotBrushStyle.Solid;
			FillOutside.Brush.SolidColor = Color.Empty;
			FillOutside.Brush.GradientStartColor = Color.Blue;
			FillOutside.Brush.GradientStopColor = Color.Aqua;
			FillOutside.Brush.HatchForeColor = Color.Empty;
			FillOutside.Brush.HatchBackColor = Color.Empty;
			FillOutside.Pen.Visible = false;
			FillOutside.Pen.Style = PlotPenStyle.Solid;
			FillOutside.Pen.Color = Color.Empty;
			FillOutside.Pen.Thickness = 1.0;
			AxesControlEnabled = true;
			AxesControlMouseStyle = PlotDataViewAxesControlStyle.Both;
			AxesControlWheelStyle = PlotDataViewAxesControlStyle.XAxes;
			AxesControlKeyboardStyle = PlotDataViewAxesControlStyle.Both;
			CursorSelectMode = Cursors.SizeAll;
			CursorZoomBoxMode = Cursors.PanSE;
			CursorDataCursorMode = Cursors.SizeAll;
		}

		private bool ShouldSerializeFillInside()
		{
			return ((ISubClassBase)FillInside).ShouldSerialize();
		}

		private void ResetFillInside()
		{
			((ISubClassBase)FillInside).ResetToDefault();
		}

		private bool ShouldSerializeFillOutside()
		{
			return ((ISubClassBase)FillOutside).ShouldSerialize();
		}

		private void ResetFillOutside()
		{
			((ISubClassBase)FillOutside).ResetToDefault();
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeGridLinesMirrorVertical()
		{
			return base.PropertyShouldSerialize("GridLinesMirrorVertical");
		}

		private void ResetGridLinesMirrorVertical()
		{
			base.PropertyReset("GridLinesMirrorVertical");
		}

		private bool ShouldSerializeGridLinesMirrorHorizontal()
		{
			return base.PropertyShouldSerialize("GridLinesMirrorHorizontal");
		}

		private void ResetGridLinesMirrorHorizontal()
		{
			base.PropertyReset("GridLinesMirrorHorizontal");
		}

		private bool ShouldSerializeAxesControlEnabled()
		{
			return base.PropertyShouldSerialize("AxesControlEnabled");
		}

		private void ResetAxesControlEnabled()
		{
			base.PropertyReset("AxesControlEnabled");
		}

		private bool ShouldSerializeAxesControlMouseStyle()
		{
			return base.PropertyShouldSerialize("AxesControlMouseStyle");
		}

		private void ResetAxesControlMouseStyle()
		{
			base.PropertyReset("AxesControlMouseStyle");
		}

		private bool ShouldSerializeAxesControlWheelStyle()
		{
			return base.PropertyShouldSerialize("AxesControlWheelStyle");
		}

		private void ResetAxesControlWheelStyle()
		{
			base.PropertyReset("AxesControlWheelStyle");
		}

		private bool ShouldSerializeAxesControlKeyboardStyle()
		{
			return base.PropertyShouldSerialize("AxesControlKeyboardStyle");
		}

		private void ResetAxesControlKeyboardStyle()
		{
			base.PropertyReset("AxesControlKeyboardStyle");
		}

		protected virtual void DisableAllTracking()
		{
			if (base.Plot != null)
			{
				foreach (PlotAxis xAxis in base.Plot.XAxes)
				{
					if (base.IsDocked(xAxis))
					{
						xAxis.Tracking.Enabled = false;
					}
				}
				foreach (PlotAxis yAxis in base.Plot.YAxes)
				{
					if (base.IsDocked(yAxis))
					{
						yAxis.Tracking.Enabled = false;
					}
				}
			}
		}

		protected override Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			if (base.Plot == null)
			{
				return Cursors.Default;
			}
			if (base.Plot.ToolBarAdapter.DataViewMouseMode == PlotDataViewMouseMode.Select)
			{
				return CursorSelectMode;
			}
			if (base.Plot.ToolBarAdapter.DataViewMouseMode == PlotDataViewMouseMode.ZoomBox)
			{
				return CursorZoomBoxMode;
			}
			if (base.Plot.ToolBarAdapter.DataViewMouseMode == PlotDataViewMouseMode.DataCursor)
			{
				return CursorDataCursorMode;
			}
			return Cursors.Default;
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (base.Plot != null)
			{
				if (shouldFocus)
				{
					base.Focus();
				}
				if (MouseMode == PlotDataViewMouseMode.ZoomBox)
				{
					base.IsMouseActive = true;
					m_ZoomBoxStartX = e.X;
					m_ZoomBoxStartY = e.Y;
					m_ZoomBoxStopX = e.X;
					m_ZoomBoxStopY = e.Y;
					DisableAllTracking();
					m_ZoomBoxAxes.Clear();
					foreach (PlotAxis xAxis in base.Plot.XAxes)
					{
						if (xAxis.Visible && base.IsDocked(xAxis) && xAxis.ValueVisible(xAxis.GetMouseValue(e)))
						{
							m_ZoomBoxAxes.Add(xAxis);
						}
					}
					foreach (PlotAxis yAxis in base.Plot.YAxes)
					{
						if (yAxis.Visible && base.IsDocked(yAxis) && yAxis.ValueVisible(yAxis.GetMouseValue(e)))
						{
							m_ZoomBoxAxes.Add(yAxis);
						}
					}
				}
				else if (AllowAxesControlMouse)
				{
					base.IsMouseActive = true;
					if (AllowAxesControlMouseX)
					{
						foreach (PlotAxis xAxis2 in base.Plot.XAxes)
						{
							if (xAxis2.Visible && base.IsDocked(xAxis2))
							{
								((IUIInput)xAxis2).MouseLeft(e, false);
							}
						}
					}
					if (AllowAxesControlMouseY)
					{
						foreach (PlotAxis yAxis2 in base.Plot.YAxes)
						{
							if (yAxis2.Visible && base.IsDocked(yAxis2))
							{
								((IUIInput)yAxis2).MouseLeft(e, false);
							}
						}
					}
				}
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			if (base.Plot != null && base.IsMouseActive)
			{
				if (MouseMode == PlotDataViewMouseMode.ZoomBox)
				{
					m_ZoomBoxStopX = e.X;
					m_ZoomBoxStopY = e.Y;
					base.Plot.UIInvalidate(this);
				}
				else
				{
					foreach (PlotAxis xAxis in base.Plot.XAxes)
					{
						if (xAxis.Visible && base.IsDocked(xAxis))
						{
							((IUIInput)xAxis).MouseMove(e);
						}
					}
					foreach (PlotAxis yAxis in base.Plot.YAxes)
					{
						if (yAxis.Visible && base.IsDocked(yAxis))
						{
							((IUIInput)yAxis).MouseMove(e);
						}
					}
				}
			}
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			if (base.Plot != null)
			{
				if (MouseMode == PlotDataViewMouseMode.ZoomBox)
				{
					if (base.IsMouseActive && Math2.Delta(m_ZoomBoxStartX, m_ZoomBoxStopX) >= 3 && Math2.Delta(m_ZoomBoxStartY, m_ZoomBoxStopY) >= 3)
					{
						Rectangle r = iRectangle.FromLTRB(m_ZoomBoxStartX, m_ZoomBoxStartY, m_ZoomBoxStopX, m_ZoomBoxStopY);
						if (this.BeforeZoomBox != null)
						{
							PlotDataViewZoomBoxEventArgs plotDataViewZoomBoxEventArgs = new PlotDataViewZoomBoxEventArgs(this, r);
							this.BeforeZoomBox(this, plotDataViewZoomBoxEventArgs);
							if (plotDataViewZoomBoxEventArgs.Cancel)
							{
								return;
							}
						}
						DisableAllTracking();
						foreach (PlotAxis zoomBoxAxis in m_ZoomBoxAxes)
						{
							zoomBoxAxis.Zoom(r);
						}
					}
				}
				else
				{
					base.IsMouseActive = false;
					foreach (PlotAxis xAxis in base.Plot.XAxes)
					{
						if (xAxis.Visible && base.IsDocked(xAxis))
						{
							((IUIInput)xAxis).MouseUp(e);
						}
					}
					foreach (PlotAxis yAxis in base.Plot.YAxes)
					{
						if (yAxis.Visible && base.IsDocked(yAxis))
						{
							((IUIInput)yAxis).MouseUp(e);
						}
					}
				}
			}
		}

		protected override void InternalOnMouseWheel(MouseEventArgs e)
		{
			if (MouseMode != PlotDataViewMouseMode.ZoomBox && AllowAxesControlWheel)
			{
				if (AllowAxesControlWheelX)
				{
					foreach (PlotAxis xAxis in base.Plot.XAxes)
					{
						if (xAxis.Visible && base.IsDocked(xAxis))
						{
							((IUIInput)xAxis).MouseWheel(e);
						}
					}
				}
				if (AllowAxesControlWheelY)
				{
					foreach (PlotAxis yAxis in base.Plot.YAxes)
					{
						if (yAxis.Visible && base.IsDocked(yAxis))
						{
							((IUIInput)yAxis).MouseWheel(e);
						}
					}
				}
			}
		}

		protected override void InternalOnKeyDown(KeyEventArgs e)
		{
			if (MouseMode != PlotDataViewMouseMode.ZoomBox && AllowAxesControlKeyboard)
			{
				if (AllowAxesControlKeyboardX)
				{
					foreach (PlotAxis xAxis in base.Plot.XAxes)
					{
						if (xAxis.Visible && base.IsDocked(xAxis))
						{
							((IUIInput)xAxis).KeyDown(e);
						}
					}
				}
				if (AllowAxesControlKeyboardY)
				{
					foreach (PlotAxis yAxis in base.Plot.YAxes)
					{
						if (yAxis.Visible && base.IsDocked(yAxis))
						{
							((IUIInput)yAxis).KeyDown(e);
						}
					}
				}
			}
		}

		protected override void DrawBackgroundLayer1(PaintArgs p)
		{
			((IPlotFill)FillOutside).Draw(p, base.Bounds);
			((IPlotFill)FillInside).Draw(p, base.BoundsClip);
		}

		protected override void Draw(PaintArgs p)
		{
		}

		protected override void DrawFocusRectangles(PaintArgs p)
		{
			if (base.Focused)
			{
				p.Graphics.DrawFocusRectangle(base.Bounds, base.BackColor);
			}
			if (MouseMode == PlotDataViewMouseMode.ZoomBox && base.IsMouseActive)
			{
				p.Graphics.DrawFocusRectangle(iRectangle.FromLTRB(m_ZoomBoxStartX, m_ZoomBoxStartY, m_ZoomBoxStopX, m_ZoomBoxStopY), base.BackColor);
			}
		}
	}
}
