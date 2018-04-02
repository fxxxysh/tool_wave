using Iocomp.Delegates;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Print Adapter.")]
	public class PlotPrintAdapter : SubClassBase
	{
		private PlotBase m_PlotBase;

		private PrintDocument m_PrintDocument;

		private PageSetupDialog m_PrintPageSetupDialog;

		private PrintPreviewDialog m_PrintPreviewDialog;

		private PrintDialog m_PrintDialog;

		private bool m_ShowPrintDialog;

		private PlotPrintSizingStyle m_SizingStyle;

		private string m_DocumentName;

		private PrintOrientation m_Orientation;

		private int m_PageIndex;

		private PlotBase PlotBase => m_PlotBase;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		[Browsable(false)]
		public PrintDocument PrintDocument
		{
			get
			{
				return m_PrintDocument;
			}
		}

		[Browsable(false)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PrintDialog PrintDialog
		{
			get
			{
				return m_PrintDialog;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string DocumentName
		{
			get
			{
				return m_DocumentName;
			}
			set
			{
				base.PropertyUpdateDefault("DocumentName", value);
				if (DocumentName != value)
				{
					m_DocumentName = value;
					if (PlotBase != null && !PlotBase.Designing)
					{
						m_PrintDocument.DocumentName = value;
					}
					base.DoPropertyChange(this, "DocumentName");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PrintOrientation Orientation
		{
			get
			{
				return m_Orientation;
			}
			set
			{
				base.PropertyUpdateDefault("Orientation", value);
				if (Orientation != value)
				{
					m_Orientation = value;
					if (PlotBase != null && !PlotBase.Designing)
					{
						if (Orientation == PrintOrientation.Landscape)
						{
							m_PrintDocument.DefaultPageSettings.Landscape = true;
						}
						else
						{
							m_PrintDocument.DefaultPageSettings.Landscape = false;
						}
					}
					base.DoPropertyChange(this, "Orientation");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ShowPrintDialog
		{
			get
			{
				return m_ShowPrintDialog;
			}
			set
			{
				base.PropertyUpdateDefault("ShowPrintDialog", value);
				if (ShowPrintDialog != value)
				{
					m_ShowPrintDialog = value;
					base.DoPropertyChange(this, "ShowPrintDialog");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotPrintSizingStyle SizingStyle
		{
			get
			{
				return m_SizingStyle;
			}
			set
			{
				base.PropertyUpdateDefault("SizingStyle", value);
				if (SizingStyle != value)
				{
					m_SizingStyle = value;
					base.DoPropertyChange(this, "SizingStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double MarginLeft
		{
			get
			{
				return (double)m_PrintDocument.DefaultPageSettings.Margins.Left / 100.0;
			}
			set
			{
				base.PropertyUpdateDefault("MarginLeft", value);
				if (MarginLeft != value)
				{
					m_PrintDocument.DefaultPageSettings.Margins.Left = (int)(value * 100.0);
					base.DoPropertyChange(this, "MarginLeft");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double MarginRight
		{
			get
			{
				return (double)m_PrintDocument.DefaultPageSettings.Margins.Right / 100.0;
			}
			set
			{
				base.PropertyUpdateDefault("MarginRight", value);
				if (MarginRight != value)
				{
					m_PrintDocument.DefaultPageSettings.Margins.Right = (int)(value * 100.0);
					base.DoPropertyChange(this, "MarginRight");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double MarginTop
		{
			get
			{
				return (double)m_PrintDocument.DefaultPageSettings.Margins.Top / 100.0;
			}
			set
			{
				base.PropertyUpdateDefault("MarginTop", value);
				if (MarginTop != value)
				{
					m_PrintDocument.DefaultPageSettings.Margins.Top = (int)(value * 100.0);
					base.DoPropertyChange(this, "MarginTop");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double MarginBottom
		{
			get
			{
				return (double)m_PrintDocument.DefaultPageSettings.Margins.Bottom / 100.0;
			}
			set
			{
				base.PropertyUpdateDefault("MarginBottom", value);
				if (MarginBottom != value)
				{
					m_PrintDocument.DefaultPageSettings.Margins.Bottom = (int)(value * 100.0);
					base.DoPropertyChange(this, "MarginBottom");
				}
			}
		}

		public event Iocomp.Delegates.PrintEventHandler PrintBefore;

		public event Iocomp.Delegates.PrintEventHandler PrintAfter;

		public event Iocomp.Delegates.PrintPageEventHandler PrintPage;

		protected override string GetPlugInTitle()
		{
			return "Plot Print Adapter";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotPrintAdapterEditorPlugIn";
		}

		public PlotPrintAdapter()
		{
			base.DoCreate();
		}

		public PlotPrintAdapter(PlotBase value)
		{
			m_PlotBase = value;
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_PrintDocument = new PrintDocument();
			m_PrintDocument.PrintPage += PrintPageHandler;
			m_PrintDocument.BeginPrint += m_PrintDocument_BeginPrint;
			m_PrintDocument.EndPrint += m_PrintDocument_EndPrint;
			m_PrintPreviewDialog = new PrintPreviewDialog();
			m_PrintPreviewDialog.Document = m_PrintDocument;
			m_PrintPageSetupDialog = new PageSetupDialog();
			m_PrintPageSetupDialog.Document = m_PrintDocument;
			m_PrintDialog = new PrintDialog();
			m_PrintDialog.Document = m_PrintDocument;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			ShowPrintDialog = true;
			SizingStyle = PlotPrintSizingStyle.Proportional;
			DocumentName = "Document";
			Orientation = PrintOrientation.Portrait;
			MarginLeft = 1.0;
			MarginRight = 1.0;
			MarginTop = 1.0;
			MarginBottom = 1.0;
		}

		private bool ShouldSerializeDocumentName()
		{
			return base.PropertyShouldSerialize("DocumentName");
		}

		private void ResetDocumentName()
		{
			base.PropertyReset("DocumentName");
		}

		private bool ShouldSerializeOrientation()
		{
			return base.PropertyShouldSerialize("Orientation");
		}

		private void ResetOrientation()
		{
			base.PropertyReset("Orientation");
		}

		private bool ShouldSerializeShowPrintDialog()
		{
			return base.PropertyShouldSerialize("ShowPrintDialog");
		}

		private void ResetShowPrintDialog()
		{
			base.PropertyReset("ShowPrintDialog");
		}

		private bool ShouldSerializeSizingStyle()
		{
			return base.PropertyShouldSerialize("SizingStyle");
		}

		private void ResetSizingStyle()
		{
			base.PropertyReset("SizingStyle");
		}

		private bool ShouldSerializeMarginLeft()
		{
			return base.PropertyShouldSerialize("MarginLeft");
		}

		private void ResetMarginLeft()
		{
			base.PropertyReset("MarginLeft");
		}

		private bool ShouldSerializeMarginRight()
		{
			return base.PropertyShouldSerialize("MarginRight");
		}

		private void ResetMarginRight()
		{
			base.PropertyReset("MarginRight");
		}

		private bool ShouldSerializeMarginTop()
		{
			return base.PropertyShouldSerialize("MarginTop");
		}

		private void ResetMarginTop()
		{
			base.PropertyReset("MarginTop");
		}

		private bool ShouldSerializeMarginBottom()
		{
			return base.PropertyShouldSerialize("MarginBottom");
		}

		private void ResetMarginBottom()
		{
			base.PropertyReset("MarginBottom");
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public DialogResult Print()
		{
			try
			{
				if (!m_PrintDialog.PrinterSettings.IsValid)
				{
					MessageBox.Show("Printer Not Valid or Installed", "Print Error");
					return DialogResult.Cancel;
				}
				if (ShowPrintDialog)
				{
					if (m_PrintDialog.ShowDialog() == DialogResult.OK)
					{
						m_PrintDocument.Print();
						return DialogResult.OK;
					}
					return DialogResult.Cancel;
				}
				m_PrintDocument.Print();
			}
			catch
			{
				MessageBox.Show("Printing Error", "Print Error");
			}
			return DialogResult.OK;
		}

		[Description("")]
		public void PrintPreview()
		{
			if (!m_PrintDialog.PrinterSettings.IsValid)
			{
				MessageBox.Show("Printer Not Valid or Installed", "Print Preview Error");
			}
			else
			{
				if (PrinterSettings.InstalledPrinters.Count == 0)
				{
					m_PrintDialog.ShowDialog();
				}
				if (PrinterSettings.InstalledPrinters.Count != 0)
				{
					m_PrintPreviewDialog.ShowDialog();
				}
			}
		}

		[Description("")]
		public void PrintPageSetup()
		{
			if (!m_PrintDialog.PrinterSettings.IsValid)
			{
				MessageBox.Show("Printer Not Valid or Installed", "Print Page Setup Error");
			}
			else
			{
				m_PrintPageSetupDialog.ShowDialog();
			}
		}

		private void PrintPageHandler(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			PrintPageEventArgs printPageEventArgs = new PrintPageEventArgs(m_PrintDocument, m_PageIndex);
			if (this.PrintPage != null)
			{
				this.PrintPage(this, printPageEventArgs);
			}
			e.HasMorePages = printPageEventArgs.HasMorePages;
			Metafile metaFile = PlotBase.GetMetaFile();
			GraphicsUnit srcUnit = GraphicsUnit.Pixel;
			Rectangle srcRect = Rectangle.Truncate(metaFile.GetBounds(ref srcUnit));
			Rectangle destRect = default(Rectangle);
			if (SizingStyle == PlotPrintSizingStyle.Stretch)
			{
				destRect = e.MarginBounds;
			}
			else if (SizingStyle == PlotPrintSizingStyle.None)
			{
				destRect = new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top, srcRect.Width, srcRect.Height);
			}
			else
			{
				double num = Math.Min((double)e.MarginBounds.Width / (double)srcRect.Width, (double)e.MarginBounds.Height / (double)srcRect.Height);
				destRect = new Rectangle(e.MarginBounds.Left, e.MarginBounds.Top, (int)((double)srcRect.Width * num), (int)((double)srcRect.Height * num));
			}
			e.Graphics.DrawImage(metaFile, destRect, srcRect, srcUnit);
			m_PageIndex++;
		}

		private void m_PrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			if (this.PrintBefore != null)
			{
				this.PrintBefore(this, new PrintEventArgs(m_PrintDocument));
			}
			m_PageIndex = 1;
		}

		private void m_PrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			if (this.PrintAfter != null)
			{
				this.PrintAfter(this, new PrintEventArgs(m_PrintDocument));
			}
		}
	}
}
