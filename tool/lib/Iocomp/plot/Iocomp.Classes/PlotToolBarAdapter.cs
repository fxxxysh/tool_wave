using Iocomp.Delegates;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot ToolBar Adapter.")]
	public class PlotToolBarAdapter
	{
		private Plot m_Plot;

		private PlotAxisMouseMode m_AxisMouseMode;

		private PlotDataViewMouseMode m_DataViewMouseMode;

		private bool m_DefaultSavePathUsed;

		[Description("")]
		public Plot Plot
		{
			get
			{
				return m_Plot;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotAxisMouseMode AxisMouseMode
		{
			get
			{
				return m_AxisMouseMode;
			}
			set
			{
				if (m_AxisMouseMode != value)
				{
					m_AxisMouseMode = value;
					OnChange();
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotDataViewMouseMode DataViewMouseMode
		{
			get
			{
				return m_DataViewMouseMode;
			}
			set
			{
				if (m_DataViewMouseMode != value)
				{
					m_DataViewMouseMode = value;
					OnChange();
				}
			}
		}

		[Description("")]
		public bool AxesTrackingAnyEnabled
		{
			get
			{
				if (Plot == null)
				{
					return true;
				}
				foreach (PlotAxis xAxis in Plot.XAxes)
				{
					if (xAxis.Tracking.Enabled)
					{
						return true;
					}
				}
				foreach (PlotAxis yAxis in Plot.YAxes)
				{
					if (yAxis.Tracking.Enabled)
					{
						return true;
					}
				}
				return false;
			}
		}

		[Description("")]
		public bool AxesTrackingAnyDisabled
		{
			get
			{
				if (Plot == null)
				{
					return true;
				}
				foreach (PlotAxis xAxis in Plot.XAxes)
				{
					if (!xAxis.Tracking.Enabled)
					{
						return true;
					}
				}
				foreach (PlotAxis yAxis in Plot.YAxes)
				{
					if (!yAxis.Tracking.Enabled)
					{
						return true;
					}
				}
				return false;
			}
		}

		public event SaveDialogEventHandler SaveDialogSetup;

		[Description("")]
		public event EventHandler Changed;

		public PlotToolBarAdapter(Plot plot)
		{
			m_Plot = plot;
		}

		private void OnChange()
		{
			if (this.Changed != null)
			{
				this.Changed(this, EventArgs.Empty);
			}
		}

		[Description("")]
		public void DoButtonClickEdit()
		{
			Plot.ShowEditorCustom(false, true);
		}

		[Description("")]
		public void DoButtonClickTrackingResumeAll()
		{
			foreach (PlotAxis xAxis in Plot.XAxes)
			{
				xAxis.Tracking.Enabled = true;
			}
			foreach (PlotAxis yAxis in Plot.YAxes)
			{
				yAxis.Tracking.Enabled = true;
			}
			if (DataViewMouseMode != 0)
			{
				DoButtonClickSelect();
			}
			Plot.ClearSubFocus();
			Plot.UIInvalidate(this);
		}

		[Description("")]
		public void DoButtonClickTrackingResumeSelected()
		{
			foreach (PlotAxis xAxis in Plot.XAxes)
			{
				if (xAxis.DockDataView != null && (xAxis.Focused || xAxis.DockDataView.Focused))
				{
					xAxis.Tracking.Enabled = true;
				}
			}
			foreach (PlotAxis yAxis in Plot.YAxes)
			{
				if (yAxis.DockDataView != null && (yAxis.Focused || yAxis.DockDataView.Focused))
				{
					yAxis.Tracking.Enabled = true;
				}
			}
			if (DataViewMouseMode != 0)
			{
				DoButtonClickSelect();
			}
			Plot.UIInvalidate(this);
		}

		[Description("")]
		public void DoButtonClickCopyPicture()
		{
			Clipboard.SetDataObject(Plot.SnapShot, true);
		}

		[Description("")]
		public void DoButtonClickCopyData()
		{
			MemoryStream memoryStream = new MemoryStream();
			Plot.SaveDataToStream(memoryStream, out StreamWriter streamWriter);
			streamWriter.Flush();
			memoryStream.Seek(0L, SeekOrigin.Begin);
			StreamReader streamReader = new StreamReader(memoryStream);
			string data = streamReader.ReadToEnd();
			Clipboard.SetDataObject(data, true);
			streamReader.Close();
		}

		[Description("")]
		public void DoButtonClickCopy()
		{
			if (Plot.CopyToClipboardFormat == PlotCopyToClipboardFormat.Picture)
			{
				DoButtonClickCopyPicture();
			}
			else
			{
				DoButtonClickCopyData();
			}
		}

		[Description("")]
		public void DoButtonClickTrackingPause()
		{
			foreach (PlotAxis xAxis in Plot.XAxes)
			{
				xAxis.Tracking.Enabled = false;
			}
			foreach (PlotAxis yAxis in Plot.YAxes)
			{
				yAxis.Tracking.Enabled = false;
			}
		}

		private void DoZoomInOut(double factor)
		{
			bool flag = false;
			foreach (PlotAxis xAxis in Plot.XAxes)
			{
				if (xAxis.DockDataView != null && (xAxis.Focused || xAxis.DockDataView.Focused))
				{
					flag = true;
					xAxis.Zoom(factor);
				}
			}
			foreach (PlotAxis yAxis in Plot.YAxes)
			{
				if (yAxis.DockDataView != null && (yAxis.Focused || yAxis.DockDataView.Focused))
				{
					flag = true;
					yAxis.Zoom(factor);
				}
			}
			if (!flag)
			{
				foreach (PlotAxis xAxis2 in Plot.XAxes)
				{
					if (xAxis2.DockDataView != null && xAxis2.Visible)
					{
						xAxis2.Zoom(factor);
					}
				}
				foreach (PlotAxis yAxis2 in Plot.YAxes)
				{
					if (yAxis2.DockDataView != null && yAxis2.Visible)
					{
						yAxis2.Zoom(factor);
					}
				}
			}
			Plot.UIInvalidate(this);
		}

		[Description("")]
		public void DoButtonClickZoomOut()
		{
			DoZoomInOut(2.0);
		}

		[Description("")]
		public void DoButtonClickZoomIn()
		{
			DoZoomInOut(0.5);
		}

		[Description("")]
		public void ForceChange()
		{
			OnChange();
		}

		[Description("")]
		public void DoButtonClickAxesScroll()
		{
			AxisMouseMode = PlotAxisMouseMode.Scroll;
		}

		[Description("")]
		public void DoButtonClickAxesZoom()
		{
			AxisMouseMode = PlotAxisMouseMode.Zoom;
		}

		[Description("")]
		public void DoButtonClickZoomBox()
		{
			if (DataViewMouseMode == PlotDataViewMouseMode.ZoomBox)
			{
				DataCursorsOff();
				DataViewMouseMode = PlotDataViewMouseMode.Select;
			}
			else
			{
				DataCursorsOff();
				DataViewMouseMode = PlotDataViewMouseMode.ZoomBox;
			}
		}

		[Description("")]
		public void DoButtonClickDataCursor()
		{
			if (DataViewMouseMode == PlotDataViewMouseMode.DataCursor)
			{
				DataCursorsOff();
				DataViewMouseMode = PlotDataViewMouseMode.Select;
			}
			else
			{
				DataCursorsOn();
				DataViewMouseMode = PlotDataViewMouseMode.DataCursor;
			}
			Plot.UIInvalidate(this);
		}

		[Description("")]
		public void DoButtonClickSelect()
		{
			if (DataViewMouseMode == PlotDataViewMouseMode.Select)
			{
				DataCursorsOff();
				DataViewMouseMode = PlotDataViewMouseMode.ZoomBox;
			}
			else
			{
				DataCursorsOff();
				DataViewMouseMode = PlotDataViewMouseMode.Select;
			}
		}

		[Description("")]
		public void DoButtonClickPrint()
		{
			Plot.PrintAdapter.Print();
		}

		[Description("")]
		public void DoButtonClickPrintPreview()
		{
			Plot.PrintAdapter.PrintPreview();
		}

		[Description("")]
		public void DoButtonClickPrintPageSetup()
		{
			Plot.PrintAdapter.PrintPageSetup();
		}

		private void DataCursorsOn()
		{
			foreach (PlotDataCursorBase dataCursor in Plot.DataCursors)
			{
				dataCursor.Visible = true;
			}
		}

		private void DataCursorsOff()
		{
			foreach (PlotDataCursorBase dataCursor in Plot.DataCursors)
			{
				dataCursor.Visible = false;
			}
		}

		private void OnSaveDialogSetup(SaveFileDialog saveFileDialog)
		{
			if (this.SaveDialogSetup != null)
			{
				this.SaveDialogSetup(this, new SaveDialogEventArgs(saveFileDialog));
			}
		}

		[Description("")]
		public void DoButtonClickSave()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Save Plot as";
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.CheckPathExists = true;
			saveFileDialog.AddExtension = true;
			saveFileDialog.ShowHelp = true;
			if (!m_DefaultSavePathUsed && Plot.DefaultSaveImagePath != "")
			{
				saveFileDialog.InitialDirectory = Plot.DefaultSaveImagePath;
				m_DefaultSavePathUsed = true;
			}
			saveFileDialog.Filter = "Bitmap File(*.bmp)|*.bmp|GIF File(*.gif)|*.gif|JPEG File(*.jpg)|*.jpg|PNG File(*.png)|*.png|TIFF File(*.tif)|*.tif|EMF File(*.emf)|*.emf|All Data(*.dat)|*.dat";
			saveFileDialog.FilterIndex = 4;
			OnSaveDialogSetup(saveFileDialog);
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				string fileName = saveFileDialog.FileName;
				if (saveFileDialog.FilterIndex == 1)
				{
					Plot.SnapShot.Save(fileName, ImageFormat.Bmp);
				}
				else if (saveFileDialog.FilterIndex == 2)
				{
					Plot.SnapShot.Save(fileName, ImageFormat.Gif);
				}
				else if (saveFileDialog.FilterIndex == 3)
				{
					Plot.SnapShot.Save(fileName, ImageFormat.Jpeg);
				}
				else if (saveFileDialog.FilterIndex == 4)
				{
					Plot.SnapShot.Save(fileName, ImageFormat.Png);
				}
				else if (saveFileDialog.FilterIndex == 5)
				{
					Plot.SnapShot.Save(fileName, ImageFormat.Tiff);
				}
				else if (saveFileDialog.FilterIndex == 6)
				{
					Plot.GetMetaFile().Save(fileName);
				}
				else if (saveFileDialog.FilterIndex == 7)
				{
					Plot.SaveDataToFile(fileName);
				}
			}
		}
	}
}
