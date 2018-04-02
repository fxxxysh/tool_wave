using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Base Class for Plot Axes")]
	public abstract class PlotAxis : PlotLayoutAxis
	{
		private ScaleDisplayLinear m_ScaleDisplay;

		private IScaleDisplayLinear I_Display;

		private ScaleRangeLinear m_ScaleRange;

		protected PlotAxisTracking m_Tracking;

		private PlotAxisGridLines m_GridLines;

		private IPlotAxisGridLines I_GridLines;

		private PlotTitle m_Title;

		private IPlotTitle I_Title;

		private double m_CursorScaler;

		private bool m_ControlKeyToggleEnabled;

		private bool m_MasterUI;

		private bool m_MasterUISlave;

		private bool m_ClipToMinMax;

		private static bool m_MasterUIBlock;

		private double m_MouseDownPos;

		private double m_MouseDownMin;

		private double m_MouseDownMax;

		private double m_MouseDownSpan;

		private int m_MouseDownPixels;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public new Color Color
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.PropertyUpdateDefault("Color", value);
				base.ForeColor = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		[Category("Iocomp")]
		public ScaleRangeLinear ScaleRange
		{
			get
			{
				return m_ScaleRange;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		[Category("Iocomp")]
		public ScaleDisplayLinear ScaleDisplay
		{
			get
			{
				return m_ScaleDisplay;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		[Category("Iocomp")]
		public PlotAxisTracking Tracking
		{
			get
			{
				return m_Tracking;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		[Category("Iocomp")]
		public PlotAxisGridLines GridLines
		{
			get
			{
				return m_GridLines;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Iocomp")]
		public PlotTitle Title
		{
			get
			{
				return m_Title;
			}
		}

		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		public TextFormatDoubleAll TextFormatting
		{
			get
			{
				return ScaleDisplay.TextFormatting;
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double Span
		{
			get
			{
				return ScaleRange.Span;
			}
			set
			{
				ScaleRange.Span = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double Min
		{
			get
			{
				return ScaleRange.Min;
			}
			set
			{
				ScaleRange.Min = value;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double Max
		{
			get
			{
				return ScaleRange.Max;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("Iocomp")]
		[Description("")]
		public double Mid
		{
			get
			{
				return ScaleRange.Mid;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public ScaleType ScaleType
		{
			get
			{
				return ScaleRange.ScaleType;
			}
			set
			{
				ScaleRange.ScaleType = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Reverse
		{
			get
			{
				return ScaleRange.Reverse;
			}
			set
			{
				ScaleRange.Reverse = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public override string TitleText
		{
			get
			{
				return Title.Text;
			}
			set
			{
				Title.Text = value;
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ControlKeyToggleEnabled
		{
			get
			{
				return m_ControlKeyToggleEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("ControlKeyToggleEnabled", value);
				if (ControlKeyToggleEnabled != value)
				{
					m_ControlKeyToggleEnabled = value;
					base.DoPropertyChange(this, "ControlKeyToggleEnabled");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public bool MasterUI
		{
			get
			{
				return m_MasterUI;
			}
			set
			{
				base.PropertyUpdateDefault("MasterUI", value);
				if (MasterUI != value)
				{
					m_MasterUI = value;
					base.DoPropertyChange(this, "MasterUI");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public bool MasterUISlave
		{
			get
			{
				return m_MasterUISlave;
			}
			set
			{
				base.PropertyUpdateDefault("MasterUISlave", value);
				if (MasterUISlave != value)
				{
					m_MasterUISlave = value;
					base.DoPropertyChange(this, "MasterUISlave");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public bool ClipToMinMax
		{
			get
			{
				return m_ClipToMinMax;
			}
			set
			{
				base.PropertyUpdateDefault("ClipToMinMax", value);
				if (ClipToMinMax != value)
				{
					m_ClipToMinMax = value;
					base.DoPropertyChange(this, "ClipToMinMax");
				}
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int DataViewPixelsMax
		{
			get
			{
				if (base.DockDataView == null)
				{
					return ScaleDisplay.PixelsMax;
				}
				if (base.DockVertical)
				{
					return base.DockDataView.BoundsClip.Right;
				}
				return base.DockDataView.BoundsClip.Bottom;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("Iocomp")]
		[Description("")]
		public int DataViewPixelsMin
		{
			get
			{
				if (base.DockDataView == null)
				{
					return ScaleDisplay.PixelsMin;
				}
				if (base.DockVertical)
				{
					return base.DockDataView.BoundsClip.Left;
				}
				return base.DockDataView.BoundsClip.Top;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double CursorScaler
		{
			get
			{
				return m_CursorScaler;
			}
			set
			{
				base.PropertyUpdateDefault("CursorScaler", value);
				if (CursorScaler != value)
				{
					m_CursorScaler = value;
					base.DoPropertyChange(this, "CursorScaler");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("Iocomp")]
		[Description("")]
		[Browsable(false)]
		public PlotAxisMouseMode MouseMode
		{
			get
			{
				if (base.Plot == null)
				{
					return PlotAxisMouseMode.Scroll;
				}
				PlotAxisMouseMode axisMouseMode = base.Plot.ToolBarAdapter.AxisMouseMode;
				if (ControlKeyToggleEnabled && Control.ModifierKeys == Keys.Control)
				{
					if (axisMouseMode == PlotAxisMouseMode.Scroll)
					{
						return PlotAxisMouseMode.Zoom;
					}
					return PlotAxisMouseMode.Scroll;
				}
				return axisMouseMode;
			}
		}

		[Description("Returns the number of pixels the text overlaps the ends of the scale")]
		[Category("Iocomp")]
		public int ScaleTextOverlapPixels
		{
			get
			{
				return ScaleDisplay.TextOverlapPixels;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public override int DockMargin
		{
			get
			{
				return ScaleDisplay.Margin;
			}
			set
			{
				base.DockMargin = value;
				ScaleDisplay.Margin = value;
			}
		}

		public override AlignmentQuadSide DockSide
		{
			get
			{
				return base.DockSide;
			}
			set
			{
				base.DockSide = value;
				if (DockSide == AlignmentQuadSide.Left)
				{
					ScaleDisplay.Direction = SideDirection.RightToLeft;
					I_Display.Orientation = Orientation.Vertical;
				}
				else if (DockSide == AlignmentQuadSide.Right)
				{
					ScaleDisplay.Direction = SideDirection.LeftToRight;
					I_Display.Orientation = Orientation.Vertical;
				}
				else if (DockSide == AlignmentQuadSide.Top)
				{
					ScaleDisplay.Direction = SideDirection.RightToLeft;
					I_Display.Orientation = Orientation.Horizontal;
				}
				else if (DockSide == AlignmentQuadSide.Bottom)
				{
					ScaleDisplay.Direction = SideDirection.LeftToRight;
					I_Display.Orientation = Orientation.Horizontal;
				}
			}
		}

		protected Color SolidColor
		{
			get
			{
				if (ControlBase != null)
				{
					return ControlBase.ForeColor;
				}
				return Color.Empty;
			}
		}

		protected Color HatchForeColor
		{
			get
			{
				if (ControlBase != null)
				{
					return ControlBase.ForeColor;
				}
				return Color.Empty;
			}
		}

		protected Color HatchBackColor
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

		protected override string GetPlugInTitle()
		{
			return "Plot Axis";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotAxisEditorPlugIn";
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_ScaleRange = new ScaleRangeLinear();
			base.AddSubClass(ScaleRange);
			m_ScaleDisplay = new ScaleDisplayLinear();
			base.AddSubClass(ScaleDisplay);
			I_Display = ScaleDisplay;
			m_Tracking = new PlotAxisTracking();
			base.AddSubClass(Tracking);
			m_GridLines = new PlotAxisGridLines();
			base.AddSubClass(GridLines);
			I_GridLines = GridLines;
			m_Title = new PlotTitle();
			base.AddSubClass(Title);
			I_Title = Title;
			m_MasterUIBlock = false;
			((IPlotObjectSubClass)Tracking).Owner = this;
			((IScaleDisplay)ScaleDisplay).Range = m_ScaleRange;
			((ISubClassBase)ScaleDisplay).ColorAmbientSource = AmbientColorSouce.ForeColor;
			((ISubClassBase)GridLines).ColorAmbientSource = AmbientColorSouce.CustomColor1;
			((ISubClassBase)GridLines.Major).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)GridLines.Mid).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)GridLines.Minor).ColorAmbientSource = AmbientColorSouce.Color;
			base.ColorAmbientSource = AmbientColorSouce.ForeColor;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Color = Color.Empty;
			CursorScaler = 1.0;
			ControlKeyToggleEnabled = true;
			MasterUI = false;
			MasterUISlave = true;
			ClipToMinMax = false;
			ScaleRange.Span = 100.0;
			ScaleRange.Min = 0.0;
			ScaleRange.Reverse = false;
			ScaleDisplay.GeneratorAuto.DesiredIncrement = 0.0;
			ScaleDisplay.GeneratorAuto.MinTextSpacing = 1.0;
			ScaleDisplay.GeneratorAuto.MinorCount = 4;
			ScaleDisplay.GeneratorAuto.MidIncluded = false;
			ScaleDisplay.GeneratorFixed.MinorCount = 4;
			ScaleDisplay.GeneratorFixed.MidIncluded = false;
			ScaleDisplay.GeneratorFixed.MajorCount = 6;
			ScaleDisplay.AntiAliasEnabled = false;
			ScaleDisplay.GeneratorStyle = ScaleGeneratorStyle.Auto;
			ScaleDisplay.Direction = SideDirection.LeftToRight;
			ScaleDisplay.Margin = 3;
			ScaleDisplay.StartRefValue = 0.0;
			ScaleDisplay.StartRefEnabled = false;
			ScaleDisplay.TextRotation = TextRotation.X000;
			ScaleDisplay.TextAlignment = StringAlignment.Near;
			ScaleDisplay.TextWidthMinValue = 6.0;
			ScaleDisplay.TextWidthMinAuto = false;
			ScaleDisplay.LineInnerVisible = true;
			ScaleDisplay.LineOuterVisible = false;
			ScaleDisplay.Visible = true;
			ScaleDisplay.TextFormatting.Precision = 1;
			ScaleDisplay.TextFormatting.PrecisionStyle = PrecisionStyle.FixedDecimalPoints;
			ScaleDisplay.TextFormatting.UnitsText = "";
			ScaleDisplay.TextFormatting.Style = TextFormatDoubleStyle.Number;
			ScaleDisplay.TextFormatting.DateTimeFormat = "hh:mm:ss";
			ScaleDisplay.TickMinor.Alignment = AlignmentStyle.Near;
			ScaleDisplay.TickMinor.Length = 3;
			ScaleDisplay.TickMinor.Color = Color.Empty;
			ScaleDisplay.TickMinor.Thickness = 1;
			ScaleDisplay.TickMid.Length = 5;
			ScaleDisplay.TickMid.Font = null;
			ScaleDisplay.TickMid.ForeColor = Color.Empty;
			ScaleDisplay.TickMid.TextVisible = true;
			ScaleDisplay.TickMid.TextMargin = 2;
			ScaleDisplay.TickMid.Alignment = AlignmentStyle.Near;
			ScaleDisplay.TickMid.Color = Color.Empty;
			ScaleDisplay.TickMid.Thickness = 1;
			ScaleDisplay.TickMajor.Length = 10;
			ScaleDisplay.TickMajor.Font = null;
			ScaleDisplay.TickMajor.ForeColor = Color.Empty;
			ScaleDisplay.TickMajor.TextVisible = true;
			ScaleDisplay.TickMajor.TextMargin = 2;
			ScaleDisplay.TickMajor.Color = Color.Empty;
			ScaleDisplay.TickMajor.Thickness = 1;
			Tracking.Enabled = true;
			Tracking.ExpandStyle = PlotTrackingExpandStyle.Minimum;
			Tracking.ScrollCompressMax = 0.0;
			Tracking.RestoreValuesOnResume = true;
			Title.Visible = false;
			Title.Color = Color.Empty;
			Title.Font = null;
			Title.ForeColor = Color.Empty;
			Title.MarginSpacing = 0.5;
			Title.MarginOuter = 0.0;
			Title.Text = "Label";
			Title.TextRotation = PlotAutoRotation.Auto;
			Title.TextLayout.Trimming = StringTrimming.None;
			Title.TextLayout.LineLimit = false;
			Title.TextLayout.MeasureTrailingSpaces = false;
			Title.TextLayout.NoWrap = false;
			Title.TextLayout.NoClip = false;
			Title.TextLayout.AlignmentHorizontal.Style = StringAlignment.Center;
			Title.TextLayout.AlignmentHorizontal.Margin = 0.5;
			Title.TextLayout.AlignmentVertical.Style = StringAlignment.Center;
			Title.TextLayout.AlignmentVertical.Margin = 0.5;
			Title.Fill.Visible = false;
			Title.Fill.Brush.Visible = true;
			Title.Fill.Brush.Style = PlotBrushStyle.Solid;
			Title.Fill.Brush.SolidColor = Color.Empty;
			Title.Fill.Brush.GradientStartColor = Color.Blue;
			Title.Fill.Brush.GradientStopColor = Color.Aqua;
			Title.Fill.Brush.HatchForeColor = Color.Empty;
			Title.Fill.Brush.HatchBackColor = Color.Empty;
			Title.Fill.Pen.Visible = true;
			Title.Fill.Pen.Color = Color.Empty;
			Title.Fill.Pen.Thickness = 1.0;
			Title.Fill.Pen.Style = PlotPenStyle.Solid;
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeScaleRange()
		{
			return ((ISubClassBase)ScaleRange).ShouldSerialize();
		}

		private void ResetScaleRange()
		{
			((ISubClassBase)ScaleRange).ResetToDefault();
		}

		private bool ShouldSerializeScaleDisplay()
		{
			return ((ISubClassBase)ScaleDisplay).ShouldSerialize();
		}

		private void ResetScaleDisplay()
		{
			((ISubClassBase)ScaleDisplay).ResetToDefault();
		}

		private bool ShouldSerializeTracking()
		{
			return ((ISubClassBase)Tracking).ShouldSerialize();
		}

		private void ResetTracking()
		{
			((ISubClassBase)Tracking).ResetToDefault();
		}

		private bool ShouldSerializeGridLines()
		{
			return ((ISubClassBase)GridLines).ShouldSerialize();
		}

		private void ResetGridLines()
		{
			((ISubClassBase)GridLines).ResetToDefault();
		}

		private bool ShouldSerializeTitle()
		{
			return ((ISubClassBase)Title).ShouldSerialize();
		}

		private void ResetTitle()
		{
			((ISubClassBase)Title).ResetToDefault();
		}

		private bool ShouldSerializeControlKeyToggleEnabled()
		{
			return base.PropertyShouldSerialize("ControlKeyToggleEnabled");
		}

		private void ResetControlKeyToggleEnabled()
		{
			base.PropertyReset("ControlKeyToggleEnabled");
		}

		private bool ShouldSerializeMasterUI()
		{
			return base.PropertyShouldSerialize("MasterUI");
		}

		private void ResetMasterUI()
		{
			base.PropertyReset("MasterUI");
		}

		private bool ShouldSerializeMasterUISlave()
		{
			return base.PropertyShouldSerialize("MasterUISlave");
		}

		private void ResetMasterUISlave()
		{
			base.PropertyReset("MasterUISlave");
		}

		private bool ShouldSerializeClipToMinMax()
		{
			return base.PropertyShouldSerialize("ClipToMinMax");
		}

		private void ResetClipToMinMax()
		{
			base.PropertyReset("ClipToMinMax");
		}

		private bool ShouldSerializeCursorScaler()
		{
			return base.PropertyShouldSerialize("CursorScaler");
		}

		private void ResetCursorScaler()
		{
			base.PropertyReset("CursorScaler");
		}

		private bool ShouldSerializeDockMargin()
		{
			return false;
		}

		private void ResetDockMargin()
		{
		}

		private bool ShouldSerializeDockSide()
		{
			return base.PropertyShouldSerialize("DockSide");
		}

		private void ResetDockSide()
		{
			base.PropertyReset("DockSide");
		}

		private void UpdateBounds()
		{
			if (DockSide == AlignmentQuadSide.Left)
			{
				I_Display.EdgeRef = base.Bounds.Right;
				I_Display.SetClipEnds(base.BoundsClip.Top, base.BoundsClip.Bottom);
				I_Display.SetBoundsEnds(base.Bounds.Top, base.Bounds.Bottom);
			}
			else if (DockSide == AlignmentQuadSide.Right)
			{
				I_Display.EdgeRef = base.Bounds.Left;
				I_Display.SetClipEnds(base.BoundsClip.Top, base.BoundsClip.Bottom);
				I_Display.SetBoundsEnds(base.Bounds.Top, base.Bounds.Bottom);
			}
			else if (DockSide == AlignmentQuadSide.Top)
			{
				I_Display.EdgeRef = base.Bounds.Bottom;
				I_Display.SetClipEnds(base.BoundsClip.Left, base.BoundsClip.Right);
				I_Display.SetBoundsEnds(base.Bounds.Left, base.Bounds.Right);
			}
			else if (DockSide == AlignmentQuadSide.Bottom)
			{
				I_Display.EdgeRef = base.Bounds.Top;
				I_Display.SetClipEnds(base.BoundsClip.Left, base.BoundsClip.Right);
				I_Display.SetBoundsEnds(base.Bounds.Left, base.Bounds.Right);
			}
		}

		protected override void OnBoundsChanged(Rectangle r)
		{
			base.OnBoundsChanged(r);
			UpdateBounds();
		}

		protected override void OnBoundsClipChanged(Rectangle r)
		{
			base.OnBoundsClipChanged(r);
			UpdateBounds();
		}

		protected override void OnDockSideChanged()
		{
			base.OnDockSideChanged();
			UpdateBounds();
		}

		protected void ZoomPercent(double refMin, double refSpan, double refMax, double percent)
		{
			if (ScaleRange.ScaleType != ScaleType.SplitLinearLog10)
			{
				if (ScaleType == ScaleType.Linear)
				{
					double num = refSpan * 1.0 / Math.Pow(10.0, percent);
					double num2 = (refMin + refMax) / 2.0;
					double num3 = num2 - num / 2.0;
					ScaleRange.AdjustSpanUsingMidReference(num);
				}
				else
				{
					double num3 = refMin * Math.Pow(10.0, percent);
					double num = refSpan / Math.Pow(10.0, percent);
					ScaleRange.SetMinMax(num3, num);
				}
			}
		}

		protected void ScrollPercent(double refMin, double refSpan, double refMax, double percent)
		{
			if (ScaleRange.ScaleType != ScaleType.SplitLinearLog10)
			{
				if (ScaleType == ScaleType.Linear)
				{
					ScaleRange.Min = m_MouseDownMin + ScaleRange.Span * percent;
				}
				else
				{
					double num = Math.Log10(refMax) - Math.Log10(refMin);
					double min = refMin * Math.Pow(10.0, percent * num);
					double max = refMax * Math.Pow(10.0, percent * num);
					ScaleRange.SetMinMax(min, max);
				}
			}
		}

		public virtual void Zoom(double factor)
		{
			if (ScaleRange.ScaleType != ScaleType.SplitLinearLog10)
			{
				Tracking.Enabled = false;
				if (factor <= 0.0)
				{
					throw new Exception("Zoom Factor must be greater than zero");
				}
				double num = ScaleRange.Span * factor;
				double mid = ScaleRange.Mid;
				double num2 = num / 2.0;
				ScaleRange.AdjustSpanUsingMidReference(num);
			}
		}

		public void Scroll(double factor)
		{
			if (ScaleRange.ScaleType != ScaleType.SplitLinearLog10)
			{
				Tracking.Enabled = false;
				ScaleRange.Min += ScaleRange.Span * factor;
			}
		}

		public double GetMouseValue(MouseEventArgs e)
		{
			return GetMouseValue(e.X, e.Y);
		}

		public double GetMouseValue(Point value)
		{
			return GetMouseValue(value.X, value.Y);
		}

		public double GetMouseValue(int x, int y)
		{
			if (base.DockHorizontal)
			{
				return ScaleDisplay.PixelsToValue(y);
			}
			return ScaleDisplay.PixelsToValue(x);
		}

		public double GetMousePercent(MouseEventArgs e)
		{
			return GetMousePercent(e.X, e.Y);
		}

		public double GetMousePercent(Point value)
		{
			return GetMousePercent(value.X, value.Y);
		}

		public double GetMousePercent(int x, int y)
		{
			if (base.DockHorizontal)
			{
				return ScaleDisplay.PixelsToPercent(y);
			}
			return ScaleDisplay.PixelsToPercent(x);
		}

		public void SetSpan(int hours, int minutes, int seconds, int milliseconds)
		{
			ScaleRange.SetSpan(hours, minutes, seconds, milliseconds);
		}

		public virtual void Zoom(Rectangle r)
		{
			if (base.DockHorizontal)
			{
				double min;
				double max;
				if (!ScaleRange.Reverse)
				{
					min = ScaleDisplay.PixelsToValue(r.Bottom);
					max = ScaleDisplay.PixelsToValue(r.Top);
				}
				else
				{
					min = ScaleDisplay.PixelsToValue(r.Top);
					max = ScaleDisplay.PixelsToValue(r.Bottom);
				}
				ScaleRange.SetMinMax(min, max);
			}
			else
			{
				double min;
				double max;
				if (!ScaleRange.Reverse)
				{
					min = ScaleDisplay.PixelsToValue(r.Left);
					max = ScaleDisplay.PixelsToValue(r.Right);
				}
				else
				{
					min = ScaleDisplay.PixelsToValue(r.Right);
					max = ScaleDisplay.PixelsToValue(r.Left);
				}
				ScaleRange.SetMinMax(min, max);
			}
		}

		protected override Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			if (base.Plot == null)
			{
				return Cursors.Default;
			}
			if (MouseMode == PlotAxisMouseMode.Scroll)
			{
				if (base.DockVertical)
				{
					return Cursors.Hand;
				}
				return Cursors.Hand;
			}
			if (MouseMode == PlotAxisMouseMode.Zoom)
			{
				if (base.DockVertical)
				{
					return Cursors.SizeWE;
				}
				return Cursors.SizeNS;
			}
			return Cursors.Default;
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (ScaleRange.ScaleType != ScaleType.SplitLinearLog10)
			{
				if (shouldFocus)
				{
					base.Focus();
				}
				base.IsMouseActive = true;
				if (base.DockVertical)
				{
					m_MouseDownPixels = e.X;
				}
				else
				{
					m_MouseDownPixels = e.Y;
				}
				m_MouseDownPos = ScaleDisplay.PixelsToValue(m_MouseDownPixels);
				m_MouseDownMin = ScaleRange.Min;
				m_MouseDownMax = ScaleRange.Max;
				m_MouseDownSpan = ScaleRange.Span;
				if (MasterUI && base.Plot != null && !m_MasterUIBlock)
				{
					m_MasterUIBlock = true;
					try
					{
						if (this is PlotXAxis)
						{
							for (int i = 0; i < base.Plot.XAxes.Count; i++)
							{
								if (base.Plot.XAxes[i] != this && (!base.Plot.XAxes[i].MasterUI || base.Plot.XAxes[i].MasterUISlave))
								{
									((IUIInput)base.Plot.XAxes[i]).MouseLeft(e, false);
								}
							}
						}
						else
						{
							for (int j = 0; j < base.Plot.YAxes.Count; j++)
							{
								if (base.Plot.YAxes[j] != this && (!base.Plot.YAxes[j].MasterUI || base.Plot.YAxes[j].MasterUISlave))
								{
									((IUIInput)base.Plot.YAxes[j]).MouseLeft(e, false);
								}
							}
						}
					}
					finally
					{
						m_MasterUIBlock = false;
					}
				}
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			if (base.IsMouseActive)
			{
				Tracking.Enabled = false;
				int num = (!base.DockVertical) ? e.Y : e.X;
				int pixelsSpan = ((IScaleDisplay)ScaleDisplay).PixelsSpan;
				int num2 = m_MouseDownPixels - num;
				if (base.DockHorizontal)
				{
					num2 = -num2;
				}
				if (ScaleRange.Reverse)
				{
					num2 = -num2;
				}
				ScaleDisplay.PixelsToValue(num);
				if (MouseMode == PlotAxisMouseMode.Scroll)
				{
					ScrollPercent(m_MouseDownMin, m_MouseDownSpan, m_MouseDownMax, (double)num2 / (double)pixelsSpan);
				}
				else
				{
					double percent = (!base.DockVertical) ? ((double)(m_MouseDownPixels - num) / (double)pixelsSpan) : ((double)(num - m_MouseDownPixels) / (double)pixelsSpan);
					ZoomPercent(m_MouseDownMin, m_MouseDownSpan, m_MouseDownMax, percent);
				}
				if (MasterUI && base.Plot != null && !m_MasterUIBlock)
				{
					m_MasterUIBlock = true;
					try
					{
						if (this is PlotXAxis)
						{
							for (int i = 0; i < base.Plot.XAxes.Count; i++)
							{
								if (base.Plot.XAxes[i] != this && (!base.Plot.XAxes[i].MasterUI || base.Plot.XAxes[i].MasterUISlave))
								{
									((IUIInput)base.Plot.XAxes[i]).MouseMove(e);
								}
							}
						}
						else
						{
							for (int j = 0; j < base.Plot.YAxes.Count; j++)
							{
								if (base.Plot.YAxes[j] != this && (!base.Plot.YAxes[j].MasterUI || base.Plot.YAxes[j].MasterUISlave))
								{
									((IUIInput)base.Plot.YAxes[j]).MouseMove(e);
								}
							}
						}
					}
					finally
					{
						m_MasterUIBlock = false;
					}
				}
			}
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			base.IsMouseActive = false;
			if (MasterUI && base.Plot != null && !m_MasterUIBlock)
			{
				m_MasterUIBlock = true;
				try
				{
					if (this is PlotXAxis)
					{
						for (int i = 0; i < base.Plot.XAxes.Count; i++)
						{
							if (base.Plot.XAxes[i] != this && (!base.Plot.XAxes[i].MasterUI || base.Plot.XAxes[i].MasterUISlave))
							{
								((IUIInput)base.Plot.XAxes[i]).MouseUp(e);
							}
						}
					}
					else
					{
						for (int j = 0; j < base.Plot.YAxes.Count; j++)
						{
							if (base.Plot.YAxes[j] != this && (!base.Plot.YAxes[j].MasterUI || base.Plot.YAxes[j].MasterUISlave))
							{
								((IUIInput)base.Plot.YAxes[j]).MouseUp(e);
							}
						}
					}
				}
				finally
				{
					m_MasterUIBlock = false;
				}
			}
		}

		protected override void PopulateContextMenu(ContextMenu menu)
		{
			base.PopulateContextMenu(menu);
			MenuItem menuItem = new MenuItem();
			menuItem.Text = "Tracking Enabled";
			menuItem.Click += MenuItemTracking_Click;
			menuItem.Checked = Tracking.Enabled;
			menu.MenuItems.Add(menuItem);
			menuItem = new MenuItem();
			menuItem.Text = "Update Resume Values";
			menuItem.Click += MenuItemUpdateResumeValues_Click;
			menuItem.Enabled = !Tracking.Enabled;
			menu.MenuItems.Add(menuItem);
			MenuItem menuItem2 = new MenuItem();
			menuItem2.Text = "Zoom To Fit";
			menu.MenuItems.Add(menuItem2);
			menuItem = new MenuItem();
			menuItem.Text = "All";
			menuItem.Click += MenuItemZoomToFitAll_Click;
			menuItem2.MenuItems.Add(menuItem);
			menuItem = new MenuItem();
			menuItem.Text = "In-View";
			menuItem.Click += MenuItemZoomToFitInView_Click;
			menuItem2.MenuItems.Add(menuItem);
		}

		protected override void InternalOnKeyDown(KeyEventArgs e)
		{
			double num = (e.KeyCode != Keys.Left) ? ((e.KeyCode != Keys.Down) ? ((e.KeyCode != Keys.Right) ? ((e.KeyCode != Keys.Up) ? ((e.KeyCode != Keys.Prior) ? ((e.KeyCode != Keys.Next) ? ((e.KeyCode != Keys.Home) ? ((e.KeyCode != Keys.End) ? 0.0 : 1.0) : -1.0) : -1.0) : 1.0) : 0.01) : 0.01) : -0.01) : -0.01;
			if (num != 0.0)
			{
				Scroll(num);
			}
			if (MasterUI && base.Plot != null && !m_MasterUIBlock)
			{
				m_MasterUIBlock = true;
				try
				{
					if (this is PlotXAxis)
					{
						for (int i = 0; i < base.Plot.XAxes.Count; i++)
						{
							if (base.Plot.XAxes[i] != this && (!base.Plot.XAxes[i].MasterUI || base.Plot.XAxes[i].MasterUISlave))
							{
								((IUIInput)base.Plot.XAxes[i]).KeyDown(e);
							}
						}
					}
					else
					{
						for (int j = 0; j < base.Plot.YAxes.Count; j++)
						{
							if (base.Plot.YAxes[j] != this && (!base.Plot.YAxes[j].MasterUI || base.Plot.YAxes[j].MasterUISlave))
							{
								((IUIInput)base.Plot.YAxes[j]).KeyDown(e);
							}
						}
					}
				}
				finally
				{
					m_MasterUIBlock = false;
				}
			}
		}

		protected override void InternalOnMouseWheel(MouseEventArgs e)
		{
			if (e.Delta != 0)
			{
				int num = e.Delta / Math.Abs(e.Delta);
				if (MouseMode == PlotAxisMouseMode.Scroll)
				{
					Scroll(0.01 * (double)num);
				}
				else
				{
					ZoomPercent(ScaleRange.Min, ScaleRange.Span, ScaleRange.Max, 0.01 * (double)num);
				}
				if (MasterUI && base.Plot != null && !m_MasterUIBlock)
				{
					m_MasterUIBlock = true;
					try
					{
						if (this is PlotXAxis)
						{
							for (int i = 0; i < base.Plot.XAxes.Count; i++)
							{
								if (base.Plot.XAxes[i] != this && (!base.Plot.XAxes[i].MasterUI || base.Plot.XAxes[i].MasterUISlave))
								{
									((IUIInput)base.Plot.XAxes[i]).MouseWheel(e);
								}
							}
						}
						else
						{
							for (int j = 0; j < base.Plot.YAxes.Count; j++)
							{
								if (base.Plot.YAxes[j] != this && (!base.Plot.YAxes[j].MasterUI || base.Plot.YAxes[j].MasterUISlave))
								{
									((IUIInput)base.Plot.YAxes[j]).MouseWheel(e);
								}
							}
						}
					}
					finally
					{
						m_MasterUIBlock = false;
					}
				}
			}
		}

		private void MenuItemTracking_Click(object sender, EventArgs e)
		{
			Tracking.Enabled = !Tracking.Enabled;
		}

		private void MenuItemUpdateResumeValues_Click(object sender, EventArgs e)
		{
			Tracking.UpdateResumeValues();
		}

		private void MenuItemZoomToFitAll_Click(object sender, EventArgs e)
		{
			Tracking.ZoomToFitAll();
		}

		private void MenuItemZoomToFitInView_Click(object sender, EventArgs e)
		{
			Tracking.ZoomToFitInView();
		}

		public int ValueToPixels(double value)
		{
			return ScaleDisplay.ValueToPixels(value);
		}

		public double ValueToPercent(double value)
		{
			return ScaleDisplay.ValueToPercent(value);
		}

		public double PercentToValue(double value)
		{
			return ScaleDisplay.PercentToValue(value);
		}

		public int PercentToPixels(double value)
		{
			return ScaleDisplay.PercentToPixels(value);
		}

		public double PixelsToValue(int value)
		{
			return ScaleDisplay.PixelsToValue(value);
		}

		public double PixelsToPercent(int value)
		{
			return ScaleDisplay.PixelsToPercent(value);
		}

		public int PercentToSpanPixels(double value)
		{
			return ScaleDisplay.PercentToSpanPixels(value);
		}

		public double PercentSpanToValue(double value)
		{
			return ScaleDisplay.PercentSpanToValue(value);
		}

		public double PixelSpanToValue(int value)
		{
			return ScaleDisplay.PixelSpanToValue(value);
		}

		public double PixelSpanToPercent(int value)
		{
			return ScaleDisplay.PixelSpanToPercent(value);
		}

		public double ValueSpanToPercent(double value)
		{
			return ScaleDisplay.ValueSpanToPercent(value);
		}

		public int ValueToSpanPixels(double value)
		{
			return ScaleDisplay.ValueToSpanPixels(value);
		}

		public bool ValueVisible(double value)
		{
			return ScaleRange.OnRange(value);
		}

		public abstract double PixelsToValue(MouseEventArgs e);

		protected override void CalculateDepthPixels(PaintArgs p)
		{
			if (I_Display.PixelsSpan == 0)
			{
				I_Display.EdgeRef = 0;
				I_Display.SetBoundsEnds(0, 1000);
				I_Display.SetClipEnds(0, 1000);
			}
			I_Display.Generate(p);
			int pixelsSpan = I_Display.PixelsSpan;
			I_Title.DockSide = DockSide;
			I_Title.CalculateDrawingData(p, pixelsSpan);
			base.DockDepthPixels = I_Display.MaxDepth + I_Title.TitleDepthPixels + I_Title.SpacingPixels;
		}

		protected override void DrawCalculations(PaintArgs p)
		{
			I_Display.Generate(p);
		}

		protected override void DrawBackgroundLayer1(PaintArgs p)
		{
			if (!GridLines.ShowOnTop)
			{
				I_GridLines.DrawMinors(p, base.Plot, this);
			}
		}

		protected override void DrawBackgroundLayer2(PaintArgs p)
		{
			if (!GridLines.ShowOnTop)
			{
				I_GridLines.DrawMajors(p, base.Plot, this);
			}
		}

		protected override void DrawForegroundLayer1(PaintArgs p)
		{
			if (GridLines.ShowOnTop)
			{
				I_GridLines.DrawMinors(p, base.Plot, this);
			}
		}

		protected override void DrawForegroundLayer2(PaintArgs p)
		{
			if (GridLines.ShowOnTop)
			{
				I_GridLines.DrawMajors(p, base.Plot, this);
			}
		}

		protected override void Draw(PaintArgs p)
		{
			Rectangle rectangle = base.BoundsClip;
			rectangle.Inflate(1, 1);
			if (ClipToMinMax)
			{
				if (base.DockVertical)
				{
					p.Graphics.SetClip(iRectangle.FromLTRB(ScaleDisplay.PixelsMin, rectangle.Top, ScaleDisplay.PixelsMax, rectangle.Bottom));
				}
				else
				{
					p.Graphics.SetClip(iRectangle.FromLTRB(rectangle.Left, ScaleDisplay.PixelsMin, rectangle.Right, ScaleDisplay.PixelsMax));
				}
			}
			else
			{
				p.Graphics.SetClip(rectangle);
			}
			I_Display.Draw(p);
			int left;
			int right;
			int top;
			int bottom;
			if (base.DockVertical)
			{
				left = base.BoundsClip.Left;
				right = base.BoundsClip.Right;
				top = base.Bounds.Top;
				bottom = base.Bounds.Bottom;
			}
			else
			{
				left = base.Bounds.Left;
				right = base.Bounds.Right;
				top = base.BoundsClip.Top;
				bottom = base.BoundsClip.Bottom;
			}
			if (base.DockBottom)
			{
				top = base.Bounds.Bottom - I_Title.TitleDepthPixels - 1;
			}
			else if (base.DockTop)
			{
				bottom = base.Bounds.Top + I_Title.TitleDepthPixels;
			}
			else if (base.DockLeft)
			{
				right = base.Bounds.Left + I_Title.TitleDepthPixels;
			}
			else
			{
				left = base.Bounds.Right - I_Title.TitleDepthPixels - 1;
			}
			rectangle = iRectangle.FromLTRB(left, top, right, bottom);
			if (base.DockBottom)
			{
				rectangle.Offset(0, DockMargin);
			}
			else if (base.DockTop)
			{
				rectangle.Offset(0, -DockMargin);
			}
			else if (base.DockLeft)
			{
				rectangle.Offset(-DockMargin, 0);
			}
			else
			{
				rectangle.Offset(DockMargin, 0);
			}
			I_Title.Draw(p, rectangle);
		}

		protected override void DrawFocusRectangles(PaintArgs p)
		{
			if (base.Focused)
			{
				p.Graphics.DrawFocusRectangle(base.BoundsClip, base.BackColor);
			}
		}
	}
}
