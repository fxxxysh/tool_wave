using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Data Cursor Base.")]
	public abstract class PlotDataCursorBase : PlotXYAxisReferenceBase, IPlotDataCursorBase
	{
		private PlotPen m_Line;

		protected IPlotPen I_Line;

		private PlotDataCursorHint m_Hint;

		protected IPlotDataCursorHint I_Hint;

		private PlotDataCursorWindow m_Window;

		protected IPlotDataCursorWindow I_Window;

		private PlotDataCursorPointer m_Pointer1;

		protected IPlotDataCursorPointer I_Pointer1;

		private PlotDataCursorPointer m_Pointer2;

		protected IPlotDataCursorPointer I_Pointer2;

		private PlotDataCursorDisplayCollection m_Displays;

		private bool m_WindowShowing;

		private bool m_YIsInterpolated;

		private bool m_SnapToPoint;

		private bool m_MasterControl;

		private int m_HitRegionSize;

		PlotDataCursorDisplayCollection IPlotDataCursorBase.Displays
		{
			get
			{
				return Displays;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotPen Line
		{
			get
			{
				return m_Line;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotDataCursorHint Hint
		{
			get
			{
				return m_Hint;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotDataCursorWindow Window
		{
			get
			{
				return m_Window;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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

		protected bool SnapToPoint
		{
			get
			{
				return m_SnapToPoint;
			}
			set
			{
				base.PropertyUpdateDefault("SnapToPoint", value);
				if (SnapToPoint != value)
				{
					m_SnapToPoint = value;
					base.DoPropertyChange(this, "SnapToPoint");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int HitRegionSize
		{
			get
			{
				return m_HitRegionSize;
			}
			set
			{
				base.PropertyUpdateDefault("HitRegionSize", value);
				if (HitRegionSize != value)
				{
					m_HitRegionSize = value;
					base.DoPropertyChange(this, "HitRegionSize");
				}
			}
		}

		[Description("")]
		public bool MasterControl
		{
			get
			{
				return m_MasterControl;
			}
			set
			{
				base.PropertyUpdateDefault("MasterControl", value);
				if (MasterControl != value)
				{
					m_MasterControl = value;
					base.DoPropertyChange(this, "MasterControl");
				}
			}
		}

		public PlotDataCursorDisplayCollection Displays => m_Displays;

		public PlotDataCursorPointer Pointer1 => m_Pointer1;

		public PlotDataCursorPointer Pointer2 => m_Pointer2;

		public bool WindowShowing => m_WindowShowing;

		protected bool YIsInterpolated
		{
			get
			{
				return m_YIsInterpolated;
			}
			set
			{
				m_YIsInterpolated = value;
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

		public event PlotDataCursorCustomizeHintTextEventHandler CustomizeHintText;

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Line = new PlotPen();
			base.AddSubClass(Line);
			I_Line = Line;
			m_Hint = new PlotDataCursorHint(this);
			base.AddSubClass(Hint);
			I_Hint = Hint;
			m_Window = new PlotDataCursorWindow(this);
			base.AddSubClass(Window);
			I_Window = Window;
			m_Pointer1 = new PlotDataCursorPointer(this);
			base.AddSubClass(Pointer1);
			I_Pointer1 = Pointer1;
			m_Pointer2 = new PlotDataCursorPointer(this);
			base.AddSubClass(Pointer2);
			I_Pointer2 = Pointer2;
			m_Displays = new PlotDataCursorDisplayCollection();
			((ISubClassBase)Line).ColorAmbientSource = AmbientColorSouce.Color;
			m_Pointer1.PropertyChanged += m_Pointer_PropertyChanged;
			m_Pointer2.PropertyChanged += m_Pointer_PropertyChanged;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Visible = false;
			Color = Color.Red;
			HitRegionSize = 5;
			base.ClippingStyle = PlotClippingStyle.DataView;
			MasterControl = false;
		}

		private bool ShouldSerializeLine()
		{
			return ((ISubClassBase)Line).ShouldSerialize();
		}

		private void ResetLine()
		{
			((ISubClassBase)Line).ResetToDefault();
		}

		private bool ShouldSerializeHint()
		{
			return ((ISubClassBase)Hint).ShouldSerialize();
		}

		private void ResetHint()
		{
			((ISubClassBase)Hint).ResetToDefault();
		}

		private bool ShouldSerializeWindow()
		{
			return ((ISubClassBase)Window).ShouldSerialize();
		}

		private void ResetWindow()
		{
			((ISubClassBase)Window).ResetToDefault();
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeHitRegionSize()
		{
			return base.PropertyShouldSerialize("HitRegionSize");
		}

		private void ResetHitRegionSize()
		{
			base.PropertyReset("HitRegionSize");
		}

		private bool ShouldSerializeMasterControl()
		{
			return base.PropertyShouldSerialize("MasterControl");
		}

		private void ResetMasterControl()
		{
			base.PropertyReset("MasterControl");
		}

		protected override bool InternalHitTest(MouseEventArgs e)
		{
			if (base.Plot == null)
			{
				return false;
			}
			if (base.Plot.ToolBarAdapter.DataViewMouseMode != PlotDataViewMouseMode.DataCursor)
			{
				return false;
			}
			if (I_Pointer1.HitRegion != null && I_Pointer1.HitRegion.IsVisible((float)e.X, (float)e.Y))
			{
				return true;
			}
			if (I_Pointer2.HitRegion != null && I_Pointer2.HitRegion.IsVisible((float)e.X, (float)e.Y))
			{
				return true;
			}
			if (I_Hint.HitRegion != null && I_Hint.HitRegion.IsVisible((float)e.X, (float)e.Y))
			{
				return true;
			}
			return false;
		}

		protected override Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			return Cursors.Hand;
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (base.XAxis != null && base.YAxis != null)
			{
				if (I_Hint.AxisPosition == null)
				{
					I_Hint.AxisPosition = base.YAxis;
				}
				I_Pointer1.MouseDownPosition = Pointer1.Position;
				I_Pointer2.MouseDownPosition = Pointer2.Position;
				I_Hint.MouseDownPosition = Hint.Position;
				I_Pointer1.MouseDownActual = Pointer1.AxisPosition.GetMousePercent(e.X, e.Y);
				I_Pointer2.MouseDownActual = Pointer2.AxisPosition.GetMousePercent(e.X, e.Y);
				I_Hint.MouseDownActual = I_Hint.AxisPosition.GetMousePercent(e.X, e.Y);
				if (shouldFocus)
				{
					base.Focus();
				}
				if (I_Hint.HitRegion != null && I_Hint.HitRegion.IsVisible((float)e.X, (float)e.Y))
				{
					I_Hint.MouseActive = true;
				}
				else
				{
					if (I_Pointer1.HitRegion != null && I_Pointer1.HitRegion.IsVisible((float)e.X, (float)e.Y))
					{
						I_Pointer1.MouseActive = true;
					}
					if (I_Pointer1.MouseActive && Pointer1.AxisPosition == Pointer2.AxisPosition)
					{
						return;
					}
					if (I_Pointer2.HitRegion != null && I_Pointer2.HitRegion.IsVisible((float)e.X, (float)e.Y))
					{
						I_Pointer2.MouseActive = true;
					}
				}
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			if (!I_Pointer1.MouseActive && !I_Pointer2.MouseActive && !I_Hint.MouseActive)
			{
				return;
			}
			double mousePercent = Pointer1.AxisPosition.GetMousePercent(e.X, e.Y);
			double mousePercent2 = Pointer2.AxisPosition.GetMousePercent(e.X, e.Y);
			double mousePercent3 = I_Hint.AxisPosition.GetMousePercent(e.X, e.Y);
			if (I_Pointer1.MouseActive)
			{
				base.XAxis.Tracking.Enabled = false;
				base.YAxis.Tracking.Enabled = false;
				Pointer1.Position = Math.Round(I_Pointer1.MouseDownPosition + (mousePercent - I_Pointer1.MouseDownActual), 4);
			}
			if (I_Pointer2.MouseActive)
			{
				base.XAxis.Tracking.Enabled = false;
				base.YAxis.Tracking.Enabled = false;
				Pointer2.Position = Math.Round(I_Pointer2.MouseDownPosition + (mousePercent2 - I_Pointer2.MouseDownActual), 4);
			}
			if (I_Hint.MouseActive)
			{
				Hint.Position = I_Hint.MouseDownPosition + (mousePercent3 - I_Hint.MouseDownActual);
			}
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			I_Pointer1.MouseActive = false;
			I_Pointer2.MouseActive = false;
			I_Hint.MouseActive = false;
			if (SnapToPoint)
			{
				DoSnapToPoint();
			}
		}

		protected override void PopulateContextMenu(ContextMenu menu)
		{
			base.PopulateContextMenu(menu);
			MenuItem menuItem = new MenuItem();
			menuItem.Text = "Hide";
			menuItem.Click += MenuItemHide_Click;
			menu.MenuItems.Add(menuItem);
		}

		private void MenuItemHide_Click(object sender, EventArgs e)
		{
			Visible = false;
		}

		protected abstract void SetupPointers();

		protected void SetupPointersValueXY()
		{
			Pointer1.Style = PlotAxisReference.XAxis;
			Pointer2.Style = PlotAxisReference.YAxis;
			Pointer1.Visible = true;
			Pointer2.Visible = true;
		}

		protected void SetupPointersValueX()
		{
			Pointer1.Style = PlotAxisReference.XAxis;
			Pointer2.Style = PlotAxisReference.YAxis;
			Pointer1.Visible = true;
			Pointer2.Visible = false;
		}

		protected void SetupPointersValueY()
		{
			Pointer1.Style = PlotAxisReference.XAxis;
			Pointer2.Style = PlotAxisReference.YAxis;
			Pointer1.Visible = false;
			Pointer2.Visible = true;
		}

		protected void SetupPointersDeltaX()
		{
			Pointer1.Style = PlotAxisReference.XAxis;
			Pointer2.Style = PlotAxisReference.XAxis;
			Pointer1.Visible = true;
			Pointer2.Visible = true;
			if (Pointer1.Position == Pointer2.Position)
			{
				Pointer1.Position = 0.45;
				Pointer2.Position = 0.55;
			}
		}

		protected void SetupPointersDeltaY()
		{
			Pointer1.Style = PlotAxisReference.YAxis;
			Pointer2.Style = PlotAxisReference.YAxis;
			Pointer1.Visible = true;
			Pointer2.Visible = true;
			if (Pointer1.Position == Pointer2.Position)
			{
				Pointer1.Position = 0.45;
				Pointer2.Position = 0.55;
			}
		}

		protected void SetupPointersInverseDeltaX()
		{
			Pointer1.Style = PlotAxisReference.XAxis;
			Pointer2.Style = PlotAxisReference.XAxis;
			Pointer1.Visible = true;
			Pointer2.Visible = true;
			if (Pointer1.Position == Pointer2.Position)
			{
				Pointer1.Position = 0.45;
				Pointer2.Position = 0.55;
			}
		}

		protected void SetupPointersInverseDeltaY()
		{
			Pointer1.Style = PlotAxisReference.YAxis;
			Pointer2.Style = PlotAxisReference.YAxis;
			Pointer1.Visible = true;
			Pointer2.Visible = true;
			if (Pointer1.Position == Pointer2.Position)
			{
				Pointer1.Position = 0.45;
				Pointer2.Position = 0.55;
			}
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (!Line.Visible)
			{
				base.CanDraw = false;
			}
		}

		protected abstract void HintUpdate(PaintArgs p, PlotDataCursorDisplay display);

		protected abstract void DoPointerLimits();

		protected abstract void UpdateDisplays();

		protected void SnapPointer1To(double xValue)
		{
			if (base.XAxis != null)
			{
				Pointer1.Position = base.XAxis.ValueToPercent(xValue);
			}
		}

		protected void SnapPointer2To(double xValue)
		{
			if (base.XAxis != null)
			{
				Pointer2.Position = base.XAxis.ValueToPercent(xValue);
			}
		}

		protected virtual void DoSnapToPoint()
		{
		}

		private void m_Pointer_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (base.Plot != null)
			{
				if (MasterControl && sender == m_Pointer1 && e.Name == "Position")
				{
					foreach (PlotDataCursorBase dataCursor in base.Plot.DataCursors)
					{
						if (dataCursor != this)
						{
							dataCursor.Pointer1.Position = (sender as PlotDataCursorPointer).Position;
						}
					}
				}
				if (MasterControl && sender == m_Pointer2 && e.Name == "Position")
				{
					foreach (PlotDataCursorBase dataCursor2 in base.Plot.DataCursors)
					{
						if (dataCursor2 != this)
						{
							dataCursor2.Pointer2.Position = (sender as PlotDataCursorPointer).Position;
						}
					}
				}
			}
		}

		protected override void DrawFocusRectangles(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			DoPointerLimits();
			if (Hint.HideOnRelease && !base.IsMouseDown)
			{
				Hint.Hide = true;
			}
			else
			{
				Hint.Hide = false;
			}
			m_WindowShowing = Window.Visible;
			if (!Pointer1.Visible)
			{
				m_WindowShowing = false;
			}
			if (Pointer1.AxisPosition == Pointer2.AxisPosition)
			{
				m_WindowShowing = false;
			}
			Pen pen = I_Line.GetPen(p);
			UpdateDisplays();
			I_Pointer1.Draw(p, pen, Displays);
			I_Pointer2.Draw(p, pen, Displays);
			foreach (PlotDataCursorDisplay display in Displays)
			{
				Point point = base.GetPoint(Pointer1.AxisPosition.PercentToValue(display.XPosition), Pointer2.AxisPosition.PercentToValue(display.YPosition));
				if (WindowShowing && !display.DisableWindow)
				{
					I_Window.Draw(p, point);
				}
				HintUpdate(p, display);
				if (this.CustomizeHintText != null)
				{
					PlotDataCursorCustomizeHintTextEventArgs plotDataCursorCustomizeHintTextEventArgs = new PlotDataCursorCustomizeHintTextEventArgs(this, Hint.Text);
					this.CustomizeHintText(this, plotDataCursorCustomizeHintTextEventArgs);
					Hint.Text = plotDataCursorCustomizeHintTextEventArgs.Text;
				}
				I_Hint.Draw(p, display);
			}
		}
	}
}
