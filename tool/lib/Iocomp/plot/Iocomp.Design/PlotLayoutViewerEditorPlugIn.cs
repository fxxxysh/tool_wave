using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotLayoutViewerEditorPlugIn : PlugInStandard
	{
		private PlotLayoutViewer plotLayoutViewer;

		private Container components;

		public PlotLayoutViewerEditorPlugIn()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			plotLayoutViewer = new PlotLayoutViewer();
			base.SuspendLayout();
			plotLayoutViewer.LoadingBegin();
			plotLayoutViewer.BackColor = Color.Black;
			plotLayoutViewer.Border.Margin = 7;
			plotLayoutViewer.Dock = DockStyle.Fill;
			plotLayoutViewer.Location = new Point(0, 0);
			plotLayoutViewer.Name = "plotLayoutViewer";
			plotLayoutViewer.Size = new Size(600, 272);
			plotLayoutViewer.TabIndex = 393;
			plotLayoutViewer.LoadingEnd();
			base.Controls.Add(plotLayoutViewer);
			base.Location = new Point(10, 20);
			base.Name = "PlotLayoutViewerEditorPlugIn";
			base.Size = new Size(600, 272);
			base.ResumeLayout(false);
		}
	}
}
