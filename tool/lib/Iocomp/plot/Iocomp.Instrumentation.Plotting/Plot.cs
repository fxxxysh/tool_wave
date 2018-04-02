using Iocomp.Classes;
using Iocomp.Design;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ToolboxBitmaps;

namespace Iocomp.Instrumentation.Plotting
{
	[Designer(typeof(PlotDesigner))]
	[ToolboxBitmap(typeof(Access), "Plot.bmp")]
	[DesignerCategory("code")]
	[DefaultEvent("Click")]
	[Description("Plot")]
	[LicenseProvider(typeof(IocompLicenseProviderPlot))]
	public class Plot : PlotBase
	{
		private PlotChannelBaseCollection m_Channels;

		private PlotDataViewCollection m_DataViews;

		private PlotXAxisCollection m_XAxes;

		private PlotYAxisCollection m_YAxes;

		private PlotLimitBaseCollection m_Limits;

		private PlotDataCursorBaseCollection m_DataCursors;

		private PlotToolBarAdapter m_ToolBarAdapter;

		private PlotLogFileAdapter m_LogFileAdapter;

		private PlotLayoutManager m_LayoutManager;

		[Description("Plot ToolBar Adapter")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public PlotToolBarAdapter ToolBarAdapter
		{
			get
			{
				return m_ToolBarAdapter;
			}
		}

		[Description("Log File")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(false)]
		public PlotLogFileAdapter LogFile
		{
			get
			{
				return m_LogFileAdapter;
			}
		}

		[Description("Plot Layout Manager")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PlotLayoutManager LayoutManager
		{
			get
			{
				return m_LayoutManager;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotChannelBaseCollection Channels
		{
			get
			{
				return m_Channels;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotDataViewCollection DataViews
		{
			get
			{
				return m_DataViews;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Iocomp")]
		[Description("")]
		public PlotXAxisCollection XAxes
		{
			get
			{
				return m_XAxes;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Iocomp")]
		[Description("")]
		public PlotYAxisCollection YAxes
		{
			get
			{
				return m_YAxes;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotLimitBaseCollection Limits
		{
			get
			{
				return m_Limits;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		[Category("Iocomp")]
		public PlotDataCursorBaseCollection DataCursors
		{
			get
			{
				return m_DataCursors;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Plot";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotEditorPlugIn";
		}

		public Plot()
		{
			base.m_License = LicenseManager.Validate(typeof(Plot), this);
			base.DoCreate();
		}

		~Plot()
		{
			base.Dispose();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_ToolBarAdapter = new PlotToolBarAdapter(this);
			m_LogFileAdapter = new PlotLogFileAdapter(this);
			base.AddSubClass(LogFile);
			m_LayoutManager = new PlotLayoutManager(this);
			m_Channels = new PlotChannelBaseCollection(this);
			m_DataViews = new PlotDataViewCollection(this);
			m_XAxes = new PlotXAxisCollection(this);
			m_YAxes = new PlotYAxisCollection(this);
			m_Limits = new PlotLimitBaseCollection(this);
			m_DataCursors = new PlotDataCursorBaseCollection(this);
			Channels.ObjectAdded += m_Plot_ObjectAdded;
			Channels.ObjectRemoved += m_Plot_ObjectRemoved;
			Channels.ObjectRenamed += m_Plot_ObjectRenamed;
			DataViews.ObjectAdded += m_Plot_ObjectAdded;
			DataViews.ObjectRemoved += m_Plot_ObjectRemoved;
			DataViews.ObjectRenamed += m_Plot_ObjectRenamed;
			XAxes.ObjectAdded += m_Plot_ObjectAdded;
			XAxes.ObjectRemoved += m_Plot_ObjectRemoved;
			XAxes.ObjectRenamed += m_Plot_ObjectRenamed;
			YAxes.ObjectAdded += m_Plot_ObjectAdded;
			YAxes.ObjectRemoved += m_Plot_ObjectRemoved;
			YAxes.ObjectRenamed += m_Plot_ObjectRenamed;
			base.Labels.ObjectAdded += m_Plot_ObjectAdded;
			base.Labels.ObjectRemoved += m_Plot_ObjectRemoved;
			base.Labels.ObjectRenamed += m_Plot_ObjectRenamed;
			base.Legends.ObjectAdded += m_Plot_ObjectAdded;
			base.Legends.ObjectRemoved += m_Plot_ObjectRemoved;
			base.Legends.ObjectRenamed += m_Plot_ObjectRenamed;
			base.Tables.ObjectAdded += m_Plot_ObjectAdded;
			base.Tables.ObjectRemoved += m_Plot_ObjectRemoved;
			base.Tables.ObjectRenamed += m_Plot_ObjectRenamed;
			Limits.ObjectAdded += m_Plot_ObjectAdded;
			Limits.ObjectRemoved += m_Plot_ObjectRemoved;
			Limits.ObjectRenamed += m_Plot_ObjectRenamed;
			base.Annotations.ObjectAdded += m_Plot_ObjectAdded;
			base.Annotations.ObjectRemoved += m_Plot_ObjectRemoved;
			base.Annotations.ObjectRenamed += m_Plot_ObjectRenamed;
			DataCursors.ObjectAdded += m_Plot_ObjectAdded;
			DataCursors.ObjectRemoved += m_Plot_ObjectRemoved;
			DataCursors.ObjectRenamed += m_Plot_ObjectRenamed;
		}

		protected override void SetComponentDefaults()
		{
			DataViews.Reset();
			XAxes.Reset();
			YAxes.Reset();
			base.Labels.Reset();
			base.Legends.Reset();
			base.Tables.Reset();
			Limits.Reset();
			base.Annotations.Reset();
			DataCursors.Reset();
			Channels.Reset();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			LogFile.FileName = "";
			LogFile.BufferSize = 10;
			LogFile.Append = false;
			LogFile.AppendFileMustExist = false;
			LogFile.AllowFileOverwrite = true;
		}

		protected override Size GetDefaultSize()
		{
			return new Size(500, 250);
		}

		protected override void PropertyChangedHook(object sender, string propertyName)
		{
			base.PropertyChangedHook(sender, propertyName);
			if (sender is PlotAxisTracking && propertyName == "Enabled")
			{
				ToolBarAdapter.ForceChange();
			}
		}

		public override void LoadingBegin()
		{
			base.LoadingBegin();
			Channels.Clear();
			DataViews.Clear();
			XAxes.Clear();
			YAxes.Clear();
			base.Labels.Clear();
			base.Legends.Clear();
			Limits.Clear();
			base.Tables.Clear();
			base.Annotations.Clear();
			DataCursors.Clear();
		}

		private bool ShouldSerializeChannels()
		{
			return Channels.Count != 0;
		}

		private bool ShouldSerializeDataViews()
		{
			return DataViews.Count != 0;
		}

		private bool ShouldSerializeXAxes()
		{
			return XAxes.Count != 0;
		}

		private bool ShouldSerializeYAxes()
		{
			return YAxes.Count != 0;
		}

		private bool ShouldSerializeLimits()
		{
			return Limits.Count != 0;
		}

		private bool ShouldSerializeDataCursors()
		{
			return DataCursors.Count != 0;
		}

		private void m_Plot_ObjectAdded(object sender, ObjectEventArgs e)
		{
			if (e.Object is IUIInput)
			{
				base.m_UICollection.Add(e.Object as IUIInput);
			}
			((IPlotObjectCollectionBase)Channels).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)DataViews).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)XAxes).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)YAxes).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)base.Labels).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)Limits).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)base.Annotations).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)DataCursors).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)base.Legends).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)base.Tables).NotifyAllObjectAdded(e.Object as PlotObject);
			OnPlotObjectAdded(e);
		}

		private void m_Plot_ObjectRemoved(object sender, ObjectEventArgs e)
		{
			if (e.Object is IUIInput)
			{
				base.m_UICollection.Remove(e.Object as IUIInput);
			}
			((IPlotObjectCollectionBase)Channels).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)DataViews).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)XAxes).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)YAxes).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)base.Labels).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)Limits).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)base.Annotations).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)DataCursors).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)base.Legends).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)base.Tables).NotifyAllObjectRemoved(e.Object as PlotObject);
			OnPlotObjectRemoved(e);
		}

		private void m_Plot_ObjectRenamed(object sender, PlotObjectRenamedEventArgs e)
		{
			((IPlotObjectCollectionBase)Channels).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)DataViews).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)XAxes).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)YAxes).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)base.Labels).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)Limits).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)base.Annotations).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)DataCursors).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)base.Legends).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)base.Tables).NotifyAllObjectRenamed(e.Object, e.OldName);
			OnPlotObjectRenamed(e);
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e)
		{
			base.m_UICollection.MouseLeft(e);
		}

		protected override void InternalOnMouseRight(MouseEventArgs e)
		{
			if (base.ContextMenusEnabled)
			{
				base.m_UICollection.MouseRight(e);
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			base.m_UICollection.MouseMove(e);
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			base.m_UICollection.MouseUp(e);
		}

		protected override void InternalOnDoubleClick(MouseEventArgs e)
		{
			base.m_UICollection.DoubleClick(e);
		}

		protected override void InternalOnMouseWheel(MouseEventArgs e)
		{
			base.m_UICollection.MouseWheel(e);
		}

		protected override void InternalOnKeyDown(KeyEventArgs e)
		{
			base.m_UICollection.KeyDown(e);
		}

		protected override void InternalOnKeyUp(KeyEventArgs e)
		{
			base.m_UICollection.KeyUp(e);
		}

		protected override void InternalOnLostFocus(EventArgs e)
		{
			base.m_UICollection.LostFocus(e);
		}

		protected override void InternalOnGotFocus(EventArgs e)
		{
			base.m_UICollection.GotFocus(e);
		}

		protected override bool IsInputKey(Keys keyData)
		{
			switch (keyData)
			{
			case Keys.Left:
				return true;
			case Keys.Right:
				return true;
			case Keys.Down:
				return true;
			case Keys.Up:
				return true;
			default:
				return base.IsInputKey(keyData);
			}
		}

		public void AddNullDataSet(double x)
		{
			for (int i = 0; i < Channels.Count; i++)
			{
				Channels[i].AddNull(x);
			}
			if (LogFile.Active)
			{
				((IPlotLogFileAdapter)LogFile).IncrementBufferCount();
			}
		}

		public void AddDataArray(double x, Array yArray)
		{
			if (yArray.Rank != 1)
			{
				throw new Exception("Array must be one-dimensional.");
			}
			Type elementType = yArray.GetType().GetElementType();
			int lowerBound = yArray.GetLowerBound(0);
			int upperBound = yArray.GetUpperBound(0);
			int num = upperBound - lowerBound + 1;
			if (num > Channels.Count)
			{
				num = Channels.Count;
			}
			if (elementType == typeof(double))
			{
				for (int i = 0; i < num; i++)
				{
					Channels[i].AddXY(x, (double)yArray.GetValue(i + lowerBound));
				}
				goto IL_0135;
			}
			if (elementType == typeof(float))
			{
				for (int j = 0; j < num; j++)
				{
					Channels[j].AddXY(x, (double)(float)yArray.GetValue(j + lowerBound));
				}
				goto IL_0135;
			}
			if (elementType == typeof(int))
			{
				for (int k = 0; k < num; k++)
				{
					Channels[k].AddXY(x, (double)(int)yArray.GetValue(k + lowerBound));
				}
				goto IL_0135;
			}
			throw new Exception("Data type must be of type double, float, or int.");
			IL_0135:
			if (LogFile.Active)
			{
				((IPlotLogFileAdapter)LogFile).IncrementBufferCount();
			}
		}

		public void AddDataArray(double startX, double interval, Array yArray)
		{
			if (yArray.Rank != 2)
			{
				throw new Exception("Array must be two-dimensional.");
			}
			int lowerBound = yArray.GetLowerBound(0);
			int upperBound = yArray.GetUpperBound(0);
			int num = upperBound - lowerBound + 1;
			if (num > Channels.Count)
			{
				num = Channels.Count;
			}
			Type elementType = yArray.GetType().GetElementType();
			Array array;
			if (elementType == typeof(double))
			{
				array = Array.CreateInstance(typeof(double), num);
				goto IL_00d1;
			}
			if (elementType == typeof(float))
			{
				array = Array.CreateInstance(typeof(float), num);
				goto IL_00d1;
			}
			if (elementType == typeof(int))
			{
				array = Array.CreateInstance(typeof(int), num);
				goto IL_00d1;
			}
			throw new Exception("Array data type must be of type double, float, or int.");
			IL_00d1:
			int lowerBound2 = yArray.GetLowerBound(1);
			int upperBound2 = yArray.GetUpperBound(1);
			for (int i = lowerBound2; i <= upperBound2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					array.SetValue(yArray.GetValue(j + lowerBound, i), j);
				}
				AddDataArray(startX + interval * (double)i, array);
			}
		}

		public void LoadDataFromStream(Stream stream)
		{
			ClearAllData();
			int num = 0;
			bool flag = false;
			char c = base.FileDeliminatorCharacter[0];
			StreamReader streamReader = new StreamReader(stream);
			try
			{
				while (streamReader.Peek() != -1)
				{
					num++;
					string text = streamReader.ReadLine();
					if (num == 1)
					{
						string[] array = text.Split(c);
						string text2 = array[0];
						flag = (text2.ToUpper().Trim() == "(X)" && true);
						if (!flag && double.TryParse(text2, NumberStyles.Any, null, out double _))
						{
							goto IL_0080;
						}
						continue;
					}
					goto IL_0080;
					IL_0080:
					if (flag)
					{
						ReadLogDataLineFromStream(streamReader, text);
					}
					else
					{
						ReadXYDataLineFromStream(streamReader, text);
					}
				}
			}
			finally
			{
				streamReader.Close();
			}
		}

		public void LoadDataFromFile(string filename)
		{
			FileStream fileStream = File.OpenRead(filename);
			try
			{
				LoadDataFromStream(fileStream);
			}
			finally
			{
				fileStream.Close();
			}
		}

		protected virtual void ReadXYDataLineFromStream(StreamReader streamReader, string rowString)
		{
			string[] array = rowString.Split(base.FileDeliminatorCharacter[0]);
			if (array.Length % 2 != 0)
			{
				throw new Exception("Invalid File Format!");
			}
			for (int i = 0; i < array.Length; i += 2)
			{
				int num = i / 2;
				if (num > Channels.Count - 1)
				{
					break;
				}
				string text = array[i];
				string text2 = array[i + 1];
				if (!(text == string.Empty) || !(text2 == string.Empty))
				{
					double num2;
					double x = (!double.TryParse(text, NumberStyles.Any, null, out num2)) ? Convert.ToDateTime(text).ToOADate() : num2;
					if (text2.ToUpper().Trim() == "NULL")
					{
						Channels[num].AddNull(x);
					}
					else if (text2.ToUpper().Trim() == "EMPTY")
					{
						Channels[num].AddEmpty(x);
					}
					else
					{
						Channels[num].AddXY(x, Convert.ToDouble(text2));
					}
				}
			}
		}

		protected virtual void ReadLogDataLineFromStream(StreamReader streamReader, string rowString)
		{
			string[] array = rowString.Split(base.FileDeliminatorCharacter[0]);
			string text = array[0];
			double num;
			double x = (!double.TryParse(text, NumberStyles.Any, null, out num)) ? Convert.ToDateTime(text).ToOADate() : num;
			for (int i = 1; i < array.Length; i++)
			{
				int num2 = i - 1;
				if (num2 > Channels.Count - 1)
				{
					break;
				}
				string text2 = array[i];
				if (text2.ToUpper().Trim() == "NULL")
				{
					Channels[num2].AddNull(x);
				}
				else if (text2.ToUpper().Trim() == "EMPTY")
				{
					Channels[num2].AddEmpty(x);
				}
				else
				{
					Channels[num2].AddXY(x, Convert.ToDouble(text2));
				}
			}
		}

		public void SaveDataToStream(Stream value, out StreamWriter streamWriter)
		{
			int count = Channels.Count;
			int num = 0;
			string fileDeliminatorCharacter = base.FileDeliminatorCharacter;
			streamWriter = new StreamWriter(value);
			foreach (PlotChannelBase channel in Channels)
			{
				if (channel.Count > num)
				{
					num = channel.Count;
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
				string displayDescription = Channels[i].DisplayDescription;
				stringBuilder.Append(displayDescription);
				stringBuilder.Append("(X)");
				stringBuilder.Append(fileDeliminatorCharacter);
				stringBuilder.Append(displayDescription);
				stringBuilder.Append("(Y)");
				if (i != count - 1)
				{
					stringBuilder.Append(fileDeliminatorCharacter);
				}
			}
			streamWriter.WriteLine(stringBuilder.ToString());
			for (int j = 0; j < num; j++)
			{
				stringBuilder.Length = 0;
				for (int k = 0; k < count; k++)
				{
					string value2;
					string value3;
					if (j > Channels[k].Count - 1)
					{
						value2 = "";
						value3 = "";
					}
					else if (Channels[k].GetNull(j))
					{
						value2 = Channels[k].GetXValueTextSpecial(j);
						value3 = "Null";
					}
					else if (Channels[k].GetEmpty(j))
					{
						value2 = Channels[k].GetXValueTextSpecial(j);
						value3 = "Empty";
					}
					else
					{
						value2 = Channels[k].GetXValueTextSpecial(j);
						value3 = Channels[k].GetY(j).ToString();
					}
					if (k != 0)
					{
						stringBuilder.Append(fileDeliminatorCharacter);
					}
					stringBuilder.Append(value2);
					stringBuilder.Append(fileDeliminatorCharacter);
					stringBuilder.Append(value3);
				}
				streamWriter.WriteLine(stringBuilder.ToString());
			}
		}

		public void SaveDataToFile(string filename)
		{
			FileStream fileStream = File.Create(filename);
			SaveDataToStream(fileStream, out StreamWriter streamWriter);
			streamWriter.Close();
			fileStream.Close();
		}

		public void ClearAllData()
		{
			foreach (PlotChannelBase channel in Channels)
			{
				channel.Clear();
			}
			foreach (PlotAxis xAxis in XAxes)
			{
				xAxis.Tracking.AlignFirstReset();
			}
			foreach (PlotAxis yAxis in YAxes)
			{
				yAxis.Tracking.AlignFirstReset();
			}
		}

		public void ShowLayoutEditor(bool modal)
		{
			UITypeEditorGeneric uITypeEditorGeneric = (UITypeEditorGeneric)TypeDescriptor.GetEditor(this, typeof(UITypeEditor));
			if (uITypeEditorGeneric != null)
			{
				uITypeEditorGeneric.CreateMainPlugIn += CreateLayoutPlugIn;
				uITypeEditorGeneric.EditValue(this, false, modal);
				uITypeEditorGeneric.CreateMainPlugIn -= CreateLayoutPlugIn;
			}
		}

		private void CreateLayoutPlugIn(object sender, UITypeEditorEventArgs e)
		{
			e.MainPlugIn = new PlotLayoutViewerEditorPlugIn();
			e.MainPlugInTitle = "Plot";
			e.MainPlugInTabName = "Layout";
		}

		protected override void DoPaint(PaintArgs p)
		{
			base.m_ObjectList.Clear();
			foreach (PlotObject dataView in DataViews)
			{
				base.m_ObjectList.Add(dataView);
			}
			foreach (PlotObject label in base.Labels)
			{
				base.m_ObjectList.Add(label);
			}
			foreach (PlotObject legend in base.Legends)
			{
				base.m_ObjectList.Add(legend);
			}
			foreach (PlotObject table in base.Tables)
			{
				base.m_ObjectList.Add(table);
			}
			foreach (PlotObject xAxis in XAxes)
			{
				base.m_ObjectList.Add(xAxis);
			}
			foreach (PlotObject yAxis in YAxes)
			{
				base.m_ObjectList.Add(yAxis);
			}
			foreach (PlotObject annotation in base.Annotations)
			{
				base.m_ObjectList.Add(annotation);
			}
			foreach (PlotObject dataCursor in DataCursors)
			{
				base.m_ObjectList.Add(dataCursor);
			}
			foreach (PlotObject limit in Limits)
			{
				base.m_ObjectList.Add(limit);
			}
			foreach (PlotChannelBase channel in Channels)
			{
				channel.LegendRectangle = Rectangle.Empty;
				base.m_ObjectList.Add(channel);
			}
			base.m_ObjectList.Sort(base.m_SorterLayer);
			m_LayoutManager.Execute(p, false, p.DrawRectangle, p.DrawRectangle);
			GraphicsState gstate = p.Graphics.Save();
			p.Graphics.ResetTransform();
			if (base.Background.Visible)
			{
				p.Graphics.FillRectangle(base.I_Background.GetBrush(p, base.ClientRectangle), base.ClientRectangle);
			}
			p.Graphics.Restore(gstate);
			foreach (IPlotDraw @object in base.m_ObjectList)
			{
				@object.DrawSetup(p);
			}
			foreach (IPlotDraw object2 in base.m_ObjectList)
			{
				object2.UpdateCanDraw(p);
				object2.UpdateBoundsClip(p);
			}
			foreach (IPlotDraw object3 in base.m_ObjectList)
			{
				object3.DrawCalculations(p);
			}
			foreach (IPlotDraw object4 in base.m_ObjectList)
			{
				p.Graphics.ResetClip();
				object4.DrawBackgroundLayer1(p);
			}
			foreach (IPlotDraw object5 in base.m_ObjectList)
			{
				p.Graphics.ResetClip();
				object5.DrawBackgroundLayer2(p);
			}
			foreach (IPlotDraw object6 in base.m_ObjectList)
			{
				p.Graphics.ResetClip();
				object6.Draw(p);
			}
			foreach (IPlotDraw object7 in base.m_ObjectList)
			{
				p.Graphics.ResetClip();
				object7.DrawForegroundLayer1(p);
			}
			foreach (IPlotDraw object8 in base.m_ObjectList)
			{
				p.Graphics.ResetClip();
				object8.DrawForegroundLayer2(p);
			}
			foreach (IPlotDraw object9 in base.m_ObjectList)
			{
				p.Graphics.ResetClip();
				object9.DrawFocusRectangles(p);
			}
		}
	}
}
