using Iocomp.Classes;
using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Iocomp.Instrumentation.Plotting
{
	[Description("PlotBase")]
	[DesignerCategory("code")]
	public abstract class PlotBase : ControlBase
	{
		private PlotLabelBaseCollection m_Labels;

		private PlotAnnotationBaseCollection m_Annotations;

		private PlotLegendBaseCollection m_Legends;

		private PlotTableBaseCollection m_Tables;

		private PlotBrush m_Background;

		protected IPlotBrush I_Background;

		private PlotFileDeliminator m_FileDeliminator;

		private bool m_ContextMenusEnabled;

		private ImageList m_ImageListAnnotations;

		private ImageList m_ImageListCommon;

		private PlotCopyToClipboardFormat m_CopyToClipboardFormat;

		private PlotXValueTextDateTimeFormat m_XValueTextDateTimeFormat;

		private string m_DefaultSaveImagePath;

		private PlotPrintAdapter m_PrintAdapter;

		protected UIInputCollection m_UICollection;

		protected PlotObjectCollection m_ObjectList;

		protected PlotSorterLayer m_SorterLayer;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Plot Print Adapter")]
		[Browsable(true)]
		public PlotPrintAdapter PrintAdapter
		{
			get
			{
				return m_PrintAdapter;
			}
		}

		[Description("Annotation ImageList")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
		public ImageList ImageListAnnotations
		{
			get
			{
				return m_ImageListAnnotations;
			}
			set
			{
				base.PropertyUpdateDefault("ImageListAnnotations", value);
				if (ImageListAnnotations != value)
				{
					m_ImageListAnnotations = value;
					base.DoPropertyChange(this, "ImageListAnnotations");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("Common ImageList")]
		public ImageList ImageListCommon
		{
			get
			{
				return m_ImageListCommon;
			}
			set
			{
				base.PropertyUpdateDefault("ImageListCommon", value);
				if (ImageListCommon != value)
				{
					m_ImageListCommon = value;
					base.DoPropertyChange(this, "ImageListCommon");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotBrush Background
		{
			get
			{
				return m_Background;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Iocomp")]
		[Description("")]
		public PlotLabelBaseCollection Labels
		{
			get
			{
				return m_Labels;
			}
		}

		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotAnnotationBaseCollection Annotations
		{
			get
			{
				return m_Annotations;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Iocomp")]
		[Description("")]
		public PlotLegendBaseCollection Legends
		{
			get
			{
				return m_Legends;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotTableBaseCollection Tables
		{
			get
			{
				return m_Tables;
			}
		}

		[Browsable(false)]
		public string FileDeliminatorCharacter
		{
			get
			{
				if (FileDeliminator == PlotFileDeliminator.Comma)
				{
					return ",";
				}
				return "\t";
			}
		}

		[Description("Annotation ImageList")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotFileDeliminator FileDeliminator
		{
			get
			{
				return m_FileDeliminator;
			}
			set
			{
				base.PropertyUpdateDefault("FileDeliminator", value);
				if (FileDeliminator != value)
				{
					m_FileDeliminator = value;
					base.DoPropertyChange(this, "FileDeliminator");
				}
			}
		}

		[Description("Copy To Clipboard Format")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotCopyToClipboardFormat CopyToClipboardFormat
		{
			get
			{
				return m_CopyToClipboardFormat;
			}
			set
			{
				base.PropertyUpdateDefault("CopyToClipboardFormat", value);
				if (CopyToClipboardFormat != value)
				{
					m_CopyToClipboardFormat = value;
					base.DoPropertyChange(this, "CopyToClipboardFormat");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("X-Value Text Date-Time Format")]
		public PlotXValueTextDateTimeFormat XValueTextDateTimeFormat
		{
			get
			{
				return m_XValueTextDateTimeFormat;
			}
			set
			{
				base.PropertyUpdateDefault("XValueTextDateTimeFormat", value);
				if (XValueTextDateTimeFormat != value)
				{
					m_XValueTextDateTimeFormat = value;
					base.DoPropertyChange(this, "XValueTextDateTimeFormat");
				}
			}
		}

		[Description("Specifies the initial default path for the save button on the toolbar.")]
		[RefreshProperties(RefreshProperties.All)]
		public string DefaultSaveImagePath
		{
			get
			{
				if (m_DefaultSaveImagePath == null)
				{
					return string.Empty;
				}
				return m_DefaultSaveImagePath;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				base.PropertyUpdateDefault("DefaultSaveImagePath", value);
				if (DefaultSaveImagePath != value)
				{
					m_DefaultSaveImagePath = value;
					base.DoPropertyChange(this, "DefaultSaveImagePath");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Common ImageList")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public Color DefaultGridLineColor
		{
			get
			{
				return base.CustomColor1;
			}
			set
			{
				base.PropertyUpdateDefault("DefaultGridLineColor", value);
				base.CustomColor1 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("Common ImageList")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ContextMenusEnabled
		{
			get
			{
				return m_ContextMenusEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("ContextMenusEnabled", value);
				if (ContextMenusEnabled != value)
				{
					m_ContextMenusEnabled = value;
					base.DoPropertyChange(this, "ContextMenusEnabled");
				}
			}
		}

		public event AddRemoveObjectEventHandler PlotObjectAdded;

		public event AddRemoveObjectEventHandler PlotObjectRemoved;

		public event PlotObjectRenamedEventHandler PlotObjectRenamed;

		protected override string GetPlugInTitle()
		{
			return "Plot";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotEditorPlugIn";
		}

		protected virtual void OnPlotObjectAdded(ObjectEventArgs e)
		{
			if (this.PlotObjectAdded != null)
			{
				this.PlotObjectAdded(this, new ObjectEventArgs(e.Object));
			}
		}

		protected virtual void OnPlotObjectRemoved(ObjectEventArgs e)
		{
			if (this.PlotObjectRemoved != null)
			{
				this.PlotObjectRemoved(this, new ObjectEventArgs(e.Object));
			}
		}

		protected virtual void OnPlotObjectRenamed(PlotObjectRenamedEventArgs e)
		{
			if (this.PlotObjectRenamed != null)
			{
				this.PlotObjectRenamed(this, e);
			}
		}

		protected override void CreateObjects()
		{
			m_UICollection = new UIInputCollection(this);
			m_PrintAdapter = new PlotPrintAdapter(this);
			base.AddSubClass(PrintAdapter);
			m_Background = new PlotBrush();
			base.AddSubClass(Background);
			I_Background = Background;
			m_Annotations = new PlotAnnotationBaseCollection(this);
			m_Labels = new PlotLabelBaseCollection(this);
			m_Legends = new PlotLegendBaseCollection(this);
			m_Tables = new PlotTableBaseCollection(this);
			m_ObjectList = new PlotObjectCollection();
			m_SorterLayer = new PlotSorterLayer();
		}

		protected override void SetComponentDefaults()
		{
			base.SetComponentDefaults();
			Labels.Reset();
			Legends.Reset();
			Tables.Reset();
			Annotations.Reset();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			ImageListAnnotations = null;
			ImageListCommon = null;
			CopyToClipboardFormat = PlotCopyToClipboardFormat.Picture;
			XValueTextDateTimeFormat = PlotXValueTextDateTimeFormat.Double;
			DefaultSaveImagePath = "";
			base.ForeColor = Color.White;
			base.BackColor = Color.Black;
			base.Border.Style = BorderStyleControl.Sunken;
			base.Border.Margin = 5;
			ContextMenusEnabled = true;
			DefaultGridLineColor = Color.Green;
			FileDeliminator = PlotFileDeliminator.Tab;
			Background.Visible = false;
			Background.Style = PlotBrushStyle.GradientVertical;
			Background.SolidColor = Color.Empty;
			Background.GradientStartColor = Color.Blue;
			Background.GradientStopColor = Color.Aqua;
			Background.HatchForeColor = Color.Empty;
			Background.HatchBackColor = Color.Empty;
		}

		private bool ShouldSerializePrintAdapter()
		{
			return ((ISubClassBase)PrintAdapter).ShouldSerialize();
		}

		private void ResetPrintAdapter()
		{
			((ISubClassBase)PrintAdapter).ResetToDefault();
		}

		private bool ShouldSerializeImageListAnnotations()
		{
			return base.PropertyShouldSerialize("ImageListAnnotations");
		}

		private void ResetImageListAnnotations()
		{
			base.PropertyReset("ImageListAnnotations");
		}

		private bool ShouldSerializeImageListCommon()
		{
			return base.PropertyShouldSerialize("ImageListCommon");
		}

		private void ResetImageListCommon()
		{
			base.PropertyReset("ImageListCommon");
		}

		private bool ShouldSerializeBackground()
		{
			return ((ISubClassBase)Background).ShouldSerialize();
		}

		private void ResetBackground()
		{
			((ISubClassBase)Background).ResetToDefault();
		}

		private bool ShouldSerializeLabels()
		{
			return Labels.Count != 0;
		}

		private bool ShouldSerializeAnnotations()
		{
			return Annotations.Count != 0;
		}

		private bool ShouldSerializeLegends()
		{
			return Legends.Count != 0;
		}

		private bool ShouldSerializeTables()
		{
			return Tables.Count != 0;
		}

		private bool ShouldSerializeFileDeliminator()
		{
			return base.PropertyShouldSerialize("FileDeliminator");
		}

		private void ResetFileDeliminator()
		{
			base.PropertyReset("FileDeliminator");
		}

		private bool ShouldSerializeCopyToClipboardFormat()
		{
			return base.PropertyShouldSerialize("CopyToClipboardFormat");
		}

		private void ResetCopyToClipboardFormat()
		{
			base.PropertyReset("CopyToClipboardFormat");
		}

		private bool ShouldSerializeXValueTextDateTimeFormat()
		{
			return base.PropertyShouldSerialize("XValueTextDateTimeFormat");
		}

		private void ResetXValueTextDateTimeFormat()
		{
			base.PropertyReset("XValueTextDateTimeFormat");
		}

		private bool ShouldSerializeDefaultSaveImagePath()
		{
			return base.PropertyShouldSerialize("DefaultSaveImagePath");
		}

		private void ResetDefaultSaveImagePath()
		{
			base.PropertyReset("DefaultSaveImagePath");
		}

		private bool ShouldSerializeDefaultGridLineColor()
		{
			return base.PropertyShouldSerialize("DefaultGridLineColor");
		}

		private void ResetDefaultGridLineColor()
		{
			base.PropertyReset("DefaultGridLineColor");
		}

		private bool ShouldSerializeContextMenusEnabled()
		{
			return base.PropertyShouldSerialize("ContextMenusEnabled");
		}

		private void ResetContextMenusEnabled()
		{
			base.PropertyReset("ContextMenusEnabled");
		}

		public static bool GetNamesMatch(string s1, string s2)
		{
			if (s1 == null)
			{
				return false;
			}
			if (s2 == null)
			{
				return false;
			}
			if (s1 == Const.EmptyString)
			{
				return false;
			}
			if (s2 == Const.EmptyString)
			{
				return false;
			}
			if (s1.Trim().ToUpper() == s2.Trim().ToUpper())
			{
				return true;
			}
			return false;
		}

		public void ClearSubFocus()
		{
			m_UICollection.ClearFocus();
		}

		public void ReCalcLayout()
		{
			Bitmap image = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(image);
			base.PaintAll(new PaintEventArgs(graphics, new Rectangle(0, 0, base.Width, base.Height)));
			graphics.Dispose();
		}

		public Metafile GetMetaFile()
		{
			Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
			Graphics graphics = base.CreateGraphics();
			IntPtr hdc = graphics.GetHdc();
			Metafile metafile = new Metafile(hdc, rectangle, MetafileFrameUnit.Pixel);
			graphics.ReleaseHdc(hdc);
			graphics.Dispose();
			graphics = Graphics.FromImage(metafile);
			Brush brush = new SolidBrush(base.BackColor);
			graphics.FillRectangle(brush, rectangle);
			brush.Dispose();
			base.PaintAll(new PaintEventArgs(graphics, rectangle));
			graphics.Dispose();
			return metafile;
		}
	}
}
