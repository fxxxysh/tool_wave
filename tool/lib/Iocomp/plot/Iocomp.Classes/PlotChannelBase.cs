using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Base Class for all Plot Channels.")]
	public abstract class PlotChannelBase : PlotXYAxisReferenceBase, IPlotChannelBase, IOPCDataDoubleReceiver
	{
		private bool m_VisibleInLegend;

		private string m_LegendName;

		private bool m_SendXAxisTrackingData;

		private bool m_SendYAxisTrackingData;

		protected string m_DeliminatorChar;

		public Rectangle m_LegendRectangle;

		protected PlotChannelDataCollection m_Data;

		protected PlotChannelDataCollection m_DataOriginal;

		private bool m_DataPointInitializing;

		private bool m_DesignTimeDataLoaded;

		private PlotLegendBase m_CachedLegend;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool VisibleInLegend
		{
			get
			{
				return m_VisibleInLegend;
			}
			set
			{
				base.PropertyUpdateDefault("VisibleInLegend", value);
				if (VisibleInLegend != value)
				{
					m_VisibleInLegend = value;
					base.DoPropertyChange(this, "VisibleInLegend");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool SendXAxisTrackingData
		{
			get
			{
				return m_SendXAxisTrackingData;
			}
			set
			{
				base.PropertyUpdateDefault("SendXAxisTrackingData", value);
				if (SendXAxisTrackingData != value)
				{
					m_SendXAxisTrackingData = value;
					base.DoPropertyChange(this, "SendXAxisTrackingData");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool SendYAxisTrackingData
		{
			get
			{
				return m_SendYAxisTrackingData;
			}
			set
			{
				base.PropertyUpdateDefault("SendYAxisTrackingData", value);
				if (SendYAxisTrackingData != value)
				{
					m_SendYAxisTrackingData = value;
					base.DoPropertyChange(this, "SendYAxisTrackingData");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int RingBufferCount
		{
			get
			{
				return m_Data.RingBufferCount;
			}
			set
			{
				base.PropertyUpdateDefault("RingBufferCount", value);
				if (RingBufferCount != value)
				{
					m_Data.RingBufferCount = value;
					base.DoPropertyChange(this, "RingBufferCount");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string LegendName
		{
			get
			{
				if (m_LegendName == null)
				{
					return Const.EmptyString;
				}
				return m_LegendName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("LegendName", value);
				if (LegendName != value)
				{
					m_LegendName = value;
					m_CachedLegend = null;
					m_CachedLegend = Legend;
					base.DoPropertyChange(this, "LegendName");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double OPCLink
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PlotLegendBase Legend
		{
			get
			{
				if (m_CachedLegend != null)
				{
					return m_CachedLegend;
				}
				if (base.Plot == null)
				{
					return null;
				}
				m_CachedLegend = base.Plot.Legends[LegendName];
				return m_CachedLegend;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Rectangle LegendRectangle
		{
			get
			{
				return m_LegendRectangle;
			}
			set
			{
				m_LegendRectangle = value;
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		public PlotChannelDataCollection DataCollection
		{
			get
			{
				return m_Data;
			}
		}

		protected override bool HitVisibleInternal
		{
			get
			{
				if (!Visible)
				{
					return VisibleInLegend;
				}
				return true;
			}
		}

		public virtual double YMinScale => m_Data.YMin;

		public virtual double YMaxScale => m_Data.YMax;

		public double XMin => m_Data.XMin;

		public double XMax => m_Data.XMax;

		public double XMean => m_Data.XMean;

		public double XStandardDeviation => m_Data.XStandardDeviation;

		public double YMin => m_Data.YMin;

		public double YMax => m_Data.YMax;

		public double YMean => m_Data.YMean;

		public double YStandardDeviation => m_Data.YStandardDeviation;

		public virtual int IndexDrawStart
		{
			get
			{
				if (m_Data.Count == 0)
				{
					return -1;
				}
				return 0;
			}
		}

		public virtual int IndexDrawStop
		{
			get
			{
				if (m_Data.Count == 0)
				{
					return -1;
				}
				return m_Data.Count - 1;
			}
		}

		public virtual int Count => m_Data.Count;

		public int IndexLast
		{
			get
			{
				if (m_Data.Count == 0)
				{
					return -1;
				}
				return m_Data.Count - 1;
			}
		}

		public int IndexFirst
		{
			get
			{
				if (m_Data.Count == 0)
				{
					return -1;
				}
				return 0;
			}
		}

		public bool Empty
		{
			get
			{
				if (m_Data.Count == 0)
				{
					return true;
				}
				return false;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public virtual int Capacity
		{
			get
			{
				return m_Data.Capacity;
			}
			set
			{
				base.PropertyUpdateDefault("Capacity", value);
				m_Data.Capacity = value;
			}
		}

		public double XFirst
		{
			get
			{
				if (Empty)
				{
					return 0.0;
				}
				return GetX(0);
			}
		}

		public double XLast
		{
			get
			{
				if (Empty)
				{
					return 0.0;
				}
				return GetX(Count - 1);
			}
		}

		public double YFirst
		{
			get
			{
				if (Empty)
				{
					return 0.0;
				}
				return GetY(0);
			}
		}

		public double YLast
		{
			get
			{
				if (Empty)
				{
					return 0.0;
				}
				return GetY(Count - 1);
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

		protected bool DataPointInitializing
		{
			get
			{
				return m_DataPointInitializing;
			}
			set
			{
				m_DataPointInitializing = value;
			}
		}

		void IPlotChannelBase.DrawLegendMarker(PaintArgs p, Rectangle r)
		{
			DrawLegendMarker(p, r);
		}

		PlotDataPointBase IPlotChannelBase.CreateDataPoint()
		{
			return CreateDataPoint();
		}

		void IOPCDataDoubleReceiver.NewOPCData(double data, DateTime timeStamp)
		{
			NewOPCData(data, timeStamp);
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Data = new PlotChannelDataCollection(this);
			m_DataOriginal = m_Data;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Color = Color.Empty;
			VisibleInLegend = true;
			Capacity = 128;
			SendXAxisTrackingData = true;
			SendYAxisTrackingData = true;
			RingBufferCount = 0;
			LegendName = "Legend 1";
			m_Data.ClearMinMeanMax();
		}

		[Browsable(false)]
		public virtual void DoDataChange()
		{
			if (!DataPointInitializing && base.Plot != null)
			{
				base.Plot.CodeInvalidate(this);
			}
		}

		private bool ShouldSerializeVisibleInLegend()
		{
			return base.PropertyShouldSerialize("VisibleInLegend");
		}

		private void ResetVisibleInLegend()
		{
			base.PropertyReset("VisibleInLegend");
		}

		private bool ShouldSerializeSendXAxisTrackingData()
		{
			return base.PropertyShouldSerialize("SendXAxisTrackingData");
		}

		private void ResetSendXAxisTrackingData()
		{
			base.PropertyReset("SendXAxisTrackingData");
		}

		private bool ShouldSerializeSendYAxisTrackingData()
		{
			return base.PropertyShouldSerialize("SendYAxisTrackingData");
		}

		private void ResetSendYAxisTrackingData()
		{
			base.PropertyReset("SendYAxisTrackingData");
		}

		private bool ShouldSerializeRingBufferCount()
		{
			return base.PropertyShouldSerialize("RingBufferCount");
		}

		private void ResetRingBufferCount()
		{
			base.PropertyReset("RingBufferCount");
		}

		private bool ShouldSerializeLegendName()
		{
			return base.PropertyShouldSerialize("LegendName");
		}

		private void ResetLegendName()
		{
			base.PropertyReset("LegendName");
		}

		public virtual void NewOPCData(double data, DateTime timeStamp)
		{
			AddXY(DateTime.Now.ToOADate(), data);
		}

		public override void ObjectRenamed(PlotObject value, string oldName)
		{
			base.ObjectRenamed(value, oldName);
			if (value is PlotLegendBase && oldName == m_LegendName)
			{
				m_LegendName = value.Name;
			}
		}

		public override void ObjectRemoved(PlotObject value)
		{
			base.ObjectRemoved(value);
			if (value == m_CachedLegend)
			{
				m_CachedLegend = null;
			}
		}

		public override void ObjectAdded(PlotObject value)
		{
			base.ObjectAdded(value);
			if (value is PlotLegendBase && value.Name == m_LegendName)
			{
				m_CachedLegend = (value as PlotLegendBase);
			}
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		[Description("")]
		public bool GetInViewMinMaxX(out double minX, out double maxX)
		{
			minX = double.PositiveInfinity;
			maxX = double.NegativeInfinity;
			if (IndexDrawStop == -1)
			{
				return false;
			}
			if (IndexDrawStart == -1)
			{
				return false;
			}
			for (int i = IndexDrawStart; i <= IndexDrawStop; i++)
			{
				minX = Math.Min(minX, GetX(i));
				maxX = Math.Max(maxX, GetX(i));
			}
			return true;
		}

		[Description("")]
		public bool GetInViewMinMaxY(out double minY, out double maxY)
		{
			minY = double.PositiveInfinity;
			maxY = double.NegativeInfinity;
			if (IndexDrawStop == -1)
			{
				return false;
			}
			if (IndexDrawStart == -1)
			{
				return false;
			}
			if (Count == 0)
			{
				return false;
			}
			for (int i = IndexDrawStart; i <= IndexDrawStop; i++)
			{
				if (!GetEmpty(i) && !GetNull(i))
				{
					minY = Math.Min(minY, GetY(i));
					maxY = Math.Max(maxY, GetY(i));
				}
			}
			return true;
		}

		public void ShareDataCollection(PlotChannelDataCollection value)
		{
			if (value == null)
			{
				throw new Exception("The shared Data Collection must not be null");
			}
			m_Data = value;
		}

		public void UnShareDataCollection()
		{
			m_Data = m_DataOriginal;
		}

		private bool ShouldSerializeCapacity()
		{
			return base.PropertyShouldSerialize("Capacity");
		}

		private void ResetCapacity()
		{
			base.PropertyReset("Capacity");
		}

		public virtual void Clear()
		{
			m_Data.Clear();
			m_Data.ClearMinMeanMax();
			DoDataChange();
		}

		protected abstract PlotDataPointBase CreateDataPoint();

		public abstract int AddXY(double x, double y);

		public abstract int AddNull(double x);

		public abstract int AddEmpty(double x);

		public abstract double GetX(int index);

		public abstract double GetY(int index);

		public abstract bool GetNull(int index);

		public abstract bool GetEmpty(int index);

		public abstract void SetX(int index, double value);

		public abstract void SetY(int index, double value);

		public abstract void SetNull(int index, bool value);

		public abstract void SetEmpty(int index, bool value);

		public abstract int CalculateXValueNearestIndex(double value);

		public int AddXY(DateTime x, double y)
		{
			return AddXY(Math2.DateTimeToDouble(x), y);
		}

		public int AddNull(DateTime x)
		{
			return AddNull(Math2.DateTimeToDouble(x));
		}

		public int AddEmpty(DateTime x)
		{
			return AddEmpty(Math2.DateTimeToDouble(x));
		}

		public void RemoveAt(int index)
		{
			m_Data.RemoveAt(index);
		}

		public void RemoveRange(int index, int count)
		{
			m_Data.RemoveRange(index, count);
		}

		public virtual double GetYValueAxisValue(double yValue)
		{
			return yValue;
		}

		public virtual string GetXValueText(double value)
		{
			if (base.XAxis != null)
			{
				return base.XAxis.TextFormatting.GetText(value);
			}
			return "X-Axis Null";
		}

		public virtual string GetYValueText(double value)
		{
			if (base.YAxis != null)
			{
				return base.YAxis.TextFormatting.GetText(value);
			}
			return "Y-Axis Null";
		}

		public string GetXValueTextSpecial(int index)
		{
			if (base.Plot == null)
			{
				return GetX(index).ToString();
			}
			if (base.Plot.XValueTextDateTimeFormat == PlotXValueTextDateTimeFormat.TimeStamp)
			{
				if (base.XAxis != null)
				{
					if (base.XAxis.TextFormatting.Style != TextFormatDoubleStyle.DateTime && base.XAxis.TextFormatting.Style != TextFormatDoubleStyle.DateTimeUTC)
					{
						return GetX(index).ToString();
					}
					return DateTime.FromOADate(GetX(index)).ToString();
				}
				return GetX(index).ToString();
			}
			return GetX(index).ToString();
		}

		[Description("")]
		public void UpdateCalculatedStatistics()
		{
			m_Data.ClearMinMeanMax();
			for (int i = 0; i < Count; i++)
			{
				m_Data.UpdateMinMaxMean(GetX(i), GetY(i), GetEmpty(i), GetNull(i));
			}
			m_Data.UpdateStandardDeviations();
		}

		public abstract PlotChannelInterpolationResult GetYInterpolated(double xValue, out double yValue);

		public void AddDataArray(Array value)
		{
			if (value.Rank != 2)
			{
				throw new Exception("Array must be two-dimensional.");
			}
			if (value.GetUpperBound(0) != 1 && value.GetUpperBound(1) != 1)
			{
				throw new Exception("One of the Array dimension bounds must be 2 (X & Y columns).");
			}
			Type elementType = value.GetType().GetElementType();
			if (value.GetUpperBound(0) == 1)
			{
				int lowerBound = value.GetLowerBound(0);
				int upperBound = value.GetUpperBound(0);
				int lowerBound2 = value.GetLowerBound(1);
				int upperBound2 = value.GetUpperBound(1);
				if (elementType == typeof(double))
				{
					for (int i = lowerBound2; i <= upperBound2; i++)
					{
						AddXY((double)value.GetValue(lowerBound, i), (double)value.GetValue(upperBound, i));
					}
				}
				else if (elementType == typeof(float))
				{
					for (int j = lowerBound2; j <= upperBound2; j++)
					{
						AddXY((double)(float)value.GetValue(lowerBound, j), (double)(float)value.GetValue(upperBound, j));
					}
				}
				else if (elementType == typeof(int))
				{
					for (int k = lowerBound2; k <= upperBound2; k++)
					{
						AddXY((double)(int)value.GetValue(lowerBound, k), (double)(int)value.GetValue(upperBound, k));
					}
				}
			}
			else
			{
				int lowerBound = value.GetLowerBound(1);
				int upperBound = value.GetUpperBound(1);
				int lowerBound2 = value.GetLowerBound(0);
				int upperBound2 = value.GetUpperBound(0);
				if (elementType == typeof(double))
				{
					for (int l = lowerBound2; l <= upperBound2; l++)
					{
						AddXY((double)value.GetValue(l, lowerBound), (double)value.GetValue(l, upperBound));
					}
				}
				else if (elementType == typeof(float))
				{
					for (int m = lowerBound2; m <= upperBound2; m++)
					{
						AddXY((double)(float)value.GetValue(m, lowerBound), (double)(float)value.GetValue(m, upperBound));
					}
				}
				else if (elementType == typeof(int))
				{
					for (int n = lowerBound2; n <= upperBound2; n++)
					{
						AddXY((double)(int)value.GetValue(n, lowerBound), (double)(int)value.GetValue(n, upperBound));
					}
				}
			}
		}

		public void AddDataArray(double startX, double interval, Array yArray)
		{
			if (yArray.Rank != 1)
			{
				throw new Exception("Array must be one-dimensional.");
			}
			Type elementType = yArray.GetType().GetElementType();
			int lowerBound = yArray.GetLowerBound(0);
			int upperBound = yArray.GetUpperBound(0);
			if (elementType == typeof(double))
			{
				for (int i = lowerBound; i <= upperBound; i++)
				{
					AddXY(startX + (double)(i - lowerBound) * interval, (double)yArray.GetValue(i));
				}
				return;
			}
			if (elementType == typeof(float))
			{
				for (int j = lowerBound; j <= upperBound; j++)
				{
					AddXY(startX + (double)(j - lowerBound) * interval, (double)(float)yArray.GetValue(j));
				}
				return;
			}
			if (elementType == typeof(int))
			{
				for (int k = lowerBound; k <= upperBound; k++)
				{
					AddXY(startX + (double)(k - lowerBound) * interval, (double)(int)yArray.GetValue(k));
				}
				return;
			}
			throw new Exception("Array data type must be of type double, float, or int.");
		}

		public void AddDataArray(DateTime startX, double interval, Array yArray)
		{
			AddDataArray(Math2.DateTimeToDouble(startX), interval, yArray);
		}

		public void AddDataArray(DateTime startX, TimeSpan interval, Array yArray)
		{
			AddDataArray(Math2.DateTimeToDouble(startX), Math2.TimeSpanToDouble(interval), yArray);
		}

		public void AddDataArray(double interval, Array yArray)
		{
			if (Count == 0)
			{
				AddDataArray(0.0, interval, yArray);
			}
			else
			{
				AddDataArray(XLast + interval, interval, yArray);
			}
		}

		public void AddDataArray(Array xArray, Array yArray)
		{
			if (xArray.Rank != 1)
			{
				throw new Exception("X-Array must be one-dimension.");
			}
			if (yArray.Rank != 1)
			{
				throw new Exception("Y-Array must be one-dimension.");
			}
			Type elementType = xArray.GetType().GetElementType();
			Type elementType2 = yArray.GetType().GetElementType();
			if (elementType != elementType2)
			{
				throw new Exception("Array data types must match.");
			}
			int lowerBound = xArray.GetLowerBound(0);
			int upperBound = xArray.GetUpperBound(0);
			int lowerBound2 = yArray.GetLowerBound(0);
			int upperBound2 = yArray.GetUpperBound(0);
			if (lowerBound != lowerBound2)
			{
				throw new Exception("Array lower bounds must match.");
			}
			if (upperBound != upperBound2)
			{
				throw new Exception("Array upper bounds must match.");
			}
			if (elementType == typeof(double))
			{
				for (int i = lowerBound; i <= upperBound; i++)
				{
					AddXY((double)xArray.GetValue(i), (double)yArray.GetValue(i));
				}
				return;
			}
			if (elementType == typeof(float))
			{
				for (int j = lowerBound; j <= upperBound; j++)
				{
					AddXY((double)(float)xArray.GetValue(j), (double)(float)yArray.GetValue(j));
				}
				return;
			}
			if (elementType == typeof(int))
			{
				for (int k = lowerBound; k <= upperBound; k++)
				{
					AddXY((double)(int)xArray.GetValue(k), (double)(int)yArray.GetValue(k));
				}
				return;
			}
			throw new Exception("Array data type must be of type double, float, or int.");
		}

		public virtual void LoadDataFromStream(Stream stream)
		{
			if (base.Plot == null)
			{
				throw new Exception("Plot not assigned.");
			}
			m_DeliminatorChar = base.Plot.FileDeliminatorCharacter;
			Clear();
			StreamReader streamReader = new StreamReader(stream);
			try
			{
				while (streamReader.Peek() != -1)
				{
					string stringline = streamReader.ReadLine();
					ReadDataPointFromStreamReader(streamReader, stringline);
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

		public void SaveDataToFile(string filename)
		{
			FileStream fileStream = File.Create(filename);
			SaveDataToStream(fileStream, out StreamWriter streamWriter);
			streamWriter.Close();
			fileStream.Close();
		}

		public virtual void SaveDataToStream(Stream value, out StreamWriter streamWriter)
		{
			if (base.Plot == null)
			{
				throw new Exception("Plot not assigned.");
			}
			m_DeliminatorChar = base.Plot.FileDeliminatorCharacter;
			streamWriter = new StreamWriter(value);
			for (int i = 0; i < Count; i++)
			{
				if (!GetEmpty(i))
				{
					WriteDataPointToStreamWriter(streamWriter, i);
				}
			}
		}

		protected virtual void WriteDataPointToStreamWriter(StreamWriter streamWriter, int index)
		{
			if (GetNull(index))
			{
				streamWriter.WriteLine(GetXValueTextSpecial(index) + m_DeliminatorChar + "null");
			}
			else
			{
				streamWriter.WriteLine(GetXValueTextSpecial(index) + m_DeliminatorChar + GetY(index));
			}
		}

		protected virtual void ReadDataPointFromStreamReader(StreamReader streamReader, string stringline)
		{
			string[] array = stringline.Split(m_DeliminatorChar.ToCharArray());
			if (array.Length != 2)
			{
				throw new Exception("Invalid File Format");
			}
			double num;
			double x = (!double.TryParse(array[0], NumberStyles.Any, null, out num)) ? Convert.ToDateTime(array[0]).ToOADate() : num;
			if (array[1].ToUpper().CompareTo("NULL") == 0)
			{
				AddNull(x);
			}
			else
			{
				AddXY(x, Convert.ToDouble(array[1]));
			}
		}

		public bool GetValid(int index)
		{
			if (!GetEmpty(index))
			{
				return !GetNull(index);
			}
			return false;
		}

		protected virtual void DrawLegendMarker(PaintArgs p, Rectangle r)
		{
			p.Graphics.FillRectangle(p.Graphics.Brush(Color), r);
		}

		protected abstract void LoadDesignTimeData(PlotXAxis xAxis, PlotYAxis yAxis, Random random, double yMin, double ySpan);

		public void LoadSampleData()
		{
			Clear();
			int num = ((IList)base.Collection).IndexOf((object)this);
			double num2 = base.YAxis.Span / (double)base.Collection.Count;
			double num3 = num2 * (double)num;
			Random random = new Random((int)DateTime.Now.Ticks);
			bool sendXAxisTrackingData = SendXAxisTrackingData;
			bool sendYAxisTrackingData = SendYAxisTrackingData;
			SendXAxisTrackingData = false;
			SendYAxisTrackingData = false;
			LoadDesignTimeData(base.XAxis, base.YAxis, random, num3 + num2 * 0.125, num2 * 0.75);
			SendXAxisTrackingData = sendXAxisTrackingData;
			SendYAxisTrackingData = sendYAxisTrackingData;
		}

		protected override bool InternalHitTest(MouseEventArgs e)
		{
			return LegendRectangle.Contains(e.X, e.Y);
		}

		protected override Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			return Cursors.Hand;
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (shouldFocus)
			{
				base.Focus();
			}
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (base.Designing && !m_DesignTimeDataLoaded && Count == 0 && base.Collection != null && base.XAxis != null && base.YAxis != null)
			{
				m_DesignTimeDataLoaded = true;
				Clear();
				int num = ((IList)base.Collection).IndexOf((object)this);
				double num2 = base.YAxis.Span / (double)base.Collection.Count;
				double num3 = num2 * (double)num;
				Random random = new Random(num);
				bool sendXAxisTrackingData = SendXAxisTrackingData;
				bool sendYAxisTrackingData = SendYAxisTrackingData;
				SendXAxisTrackingData = false;
				SendYAxisTrackingData = false;
				LoadDesignTimeData(base.XAxis, base.YAxis, random, num3 + num2 * 0.125, num2 * 0.75);
				SendXAxisTrackingData = sendXAxisTrackingData;
				SendYAxisTrackingData = sendYAxisTrackingData;
			}
			if (base.YAxis != null && base.YAxis.Bounds.Height < 1)
			{
				base.CanDraw = false;
			}
		}

		protected virtual void DrawMarkers(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis, PlotMarker markers)
		{
			if (markers.Visible)
			{
				Brush brush = ((IPlotBrush)markers.Fill.Brush).GetBrush(p, Rectangle.Empty);
				Pen pen = ((IPlotPen)markers.Fill.Pen).GetPen(p);
				for (int i = IndexDrawStart; i <= IndexDrawStop; i++)
				{
					if (!GetNull(i) && !GetEmpty(i))
					{
						int num = xAxis.ScaleDisplay.ValueToPixels(GetX(i));
						int num2 = yAxis.ScaleDisplay.ValueToPixels(GetY(i));
						if (base.XYSwapped)
						{
							((IPlotMarker)markers).Draw(p, num2, num, brush, pen);
						}
						else
						{
							((IPlotMarker)markers).Draw(p, num, num2, brush, pen);
						}
					}
				}
			}
		}
	}
}
