using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Iocomp.Classes
{
	[Description("Plot Log File Adapter.")]
	public class PlotLogFileAdapter : SubClassBase, IPlotLogFileAdapter
	{
		private string m_FileName;

		private int m_BufferSize;

		private bool m_Active;

		private Plot m_Plot;

		private int m_BufferIndex;

		private int m_BufferCount;

		private bool m_Append;

		private bool m_AppendFileMustExist;

		private bool m_AllowFileOverwrite;

		[Description("")]
		public string FileName
		{
			get
			{
				return m_FileName;
			}
			set
			{
				base.PropertyUpdateDefault("FileName", value);
				if (FileName != value)
				{
					if (Active)
					{
						throw new Exception("FileName can not be changed while logging is active");
					}
					m_FileName = value;
					base.DoPropertyChange(this, "FileName");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int BufferSize
		{
			get
			{
				return m_BufferSize;
			}
			set
			{
				base.PropertyUpdateDefault("BufferSize", value);
				if (BufferSize != value)
				{
					m_BufferSize = value;
					base.DoPropertyChange(this, "BufferSize");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool Append
		{
			get
			{
				return m_Append;
			}
			set
			{
				base.PropertyUpdateDefault("Append", value);
				if (Append != value)
				{
					m_Append = value;
					base.DoPropertyChange(this, "Append");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool AppendFileMustExist
		{
			get
			{
				return m_AppendFileMustExist;
			}
			set
			{
				base.PropertyUpdateDefault("AppendFileMustExist", value);
				if (AppendFileMustExist != value)
				{
					m_AppendFileMustExist = value;
					base.DoPropertyChange(this, "AppendFileMustExist");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool AllowFileOverwrite
		{
			get
			{
				return m_AllowFileOverwrite;
			}
			set
			{
				base.PropertyUpdateDefault("AllowFileOverwrite", value);
				if (AllowFileOverwrite != value)
				{
					m_AllowFileOverwrite = value;
					base.DoPropertyChange(this, "AllowFileOverwrite");
				}
			}
		}

		[Description("")]
		public bool Active
		{
			get
			{
				return m_Active;
			}
		}

		[Description("")]
		public int BufferIndex
		{
			get
			{
				return m_BufferIndex;
			}
		}

		[Description("")]
		public int BufferCount
		{
			get
			{
				return m_BufferCount;
			}
		}

		private Plot Plot => m_Plot;

		public event EventHandler Activated;

		public event EventHandler Deactivated;

		protected override string GetPlugInTitle()
		{
			return "Log File";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLogFileAdapterEditorPlugIn";
		}

		void IPlotLogFileAdapter.IncrementBufferCount()
		{
			IncrementBufferCount();
		}

		public PlotLogFileAdapter()
		{
			base.DoCreate();
		}

		public PlotLogFileAdapter(Plot value)
		{
			m_Plot = value;
			base.DoCreate();
		}

		private bool ShouldSerializeFileName()
		{
			return base.PropertyShouldSerialize("FileName");
		}

		private void ResetFileName()
		{
			base.PropertyReset("FileName");
		}

		private bool ShouldSerializeBufferSize()
		{
			return base.PropertyShouldSerialize("BufferSize");
		}

		private void ResetBufferSize()
		{
			base.PropertyReset("BufferSize");
		}

		private bool ShouldSerializeAppend()
		{
			return base.PropertyShouldSerialize("Append");
		}

		private void ResetAppend()
		{
			base.PropertyReset("Append");
		}

		private bool ShouldSerializeAppendFileMustExist()
		{
			return base.PropertyShouldSerialize("AppendFileMustExist");
		}

		private void ResetAppendFileMustExist()
		{
			base.PropertyReset("AppendFileMustExist");
		}

		private bool ShouldSerializeAllowFileOverwrite()
		{
			return base.PropertyShouldSerialize("AllowFileOverwrite");
		}

		private void ResetAllowFileOverwrite()
		{
			base.PropertyReset("AllowFileOverwrite");
		}

		private void IncrementBufferCount()
		{
			m_BufferCount++;
			if (m_BufferCount >= BufferSize)
			{
				Flush();
			}
		}

		private void OnActivated()
		{
			if (this.Activated != null)
			{
				this.Activated(this, EventArgs.Empty);
			}
		}

		private void OnDeactivated()
		{
			if (this.Deactivated != null)
			{
				this.Deactivated(this, EventArgs.Empty);
			}
		}

		private void Flush()
		{
			if (m_BufferCount != 0)
			{
				string fileDeliminatorCharacter = Plot.FileDeliminatorCharacter;
				FileStream fileStream = File.Open(FileName, FileMode.Append, FileAccess.Write, FileShare.None);
				try
				{
					StreamWriter streamWriter = new StreamWriter(fileStream);
					try
					{
						StringBuilder stringBuilder = new StringBuilder();
						for (int i = 0; i < BufferCount; i++)
						{
							stringBuilder.Length = 0;
							stringBuilder.Append(Plot.Channels[0].GetX(BufferIndex + i).ToString());
							stringBuilder.Append(fileDeliminatorCharacter);
							for (int j = 0; j < Plot.Channels.Count; j++)
							{
								stringBuilder.Append(Plot.Channels[j].GetY(BufferIndex + i).ToString());
								if (j != Plot.Channels.LastIndex)
								{
									stringBuilder.Append(fileDeliminatorCharacter);
								}
							}
							streamWriter.WriteLine(stringBuilder.ToString());
						}
					}
					finally
					{
						streamWriter.Close();
					}
				}
				finally
				{
					fileStream.Close();
				}
				m_BufferIndex += BufferCount;
				m_BufferCount = 0;
			}
		}

		private void LogFinalSetup()
		{
			m_BufferIndex = Plot.Channels[0].Count;
			m_BufferCount = 0;
			m_Active = true;
			OnActivated();
		}

		private void CheckChannelsForSynchronization()
		{
			PlotChannelBase plotChannelBase = Plot.Channels[0];
			int num = 1;
			while (true)
			{
				if (num < Plot.Channels.Count)
				{
					if (plotChannelBase.Count == Plot.Channels[num].Count)
					{
						num++;
						continue;
					}
					break;
				}
				return;
			}
			throw new Exception("Log Activate Error: Channels not Synchronized (Data-Point Counts Differ).");
		}

		public void Activate()
		{
			if (Active)
			{
				throw new Exception("Log Activate Error: Log is already active.");
			}
			if (Plot.Channels.Count == 0)
			{
				throw new Exception("Log Activate Error: No Channels.");
			}
			CheckChannelsForSynchronization();
			if (FileName == null)
			{
				throw new Exception("Log Activate Error: File Name not defined");
			}
			if (FileName == Const.EmptyString)
			{
				throw new Exception("Log Activate Error: File Name not defined");
			}
			string fileDeliminatorCharacter = Plot.FileDeliminatorCharacter;
			bool flag = File.Exists(FileName);
			FileStream fileStream;
			if (!Append)
			{
				if (flag && !AllowFileOverwrite)
				{
					throw new Exception("Log Activate Error: " + FileName + " already exists! Can not overwrite.");
				}
			}
			else
			{
				if (!flag && AppendFileMustExist)
				{
					throw new Exception("Log Activate Error: Can not append, " + FileName + " does not exist.");
				}
				if (flag)
				{
					fileStream = File.Open(FileName, FileMode.Append, FileAccess.Write, FileShare.None);
					fileStream.Close();
					LogFinalSetup();
					return;
				}
			}
			fileStream = File.Open(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
			try
			{
				StreamWriter streamWriter = new StreamWriter(fileStream);
				try
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append("(X)");
					stringBuilder.Append(fileDeliminatorCharacter);
					for (int i = 0; i < Plot.Channels.Count; i++)
					{
						stringBuilder.Append(Plot.Channels[i].DisplayDescription);
						stringBuilder.Append("(Y)");
						if (i != Plot.Channels.LastIndex)
						{
							stringBuilder.Append(fileDeliminatorCharacter);
						}
					}
					streamWriter.WriteLine(stringBuilder.ToString());
				}
				finally
				{
					streamWriter.Close();
				}
			}
			finally
			{
				fileStream.Close();
			}
			LogFinalSetup();
		}

		public void Deactivate()
		{
			if (!Active)
			{
				throw new Exception("Log Deactivate Error: Log is not active.");
			}
			Flush();
			m_Active = false;
			OnDeactivated();
		}
	}
}
