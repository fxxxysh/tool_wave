using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Data Cursor Channel Base.")]
	public abstract class PlotDataCursorChannelBase : PlotDataCursorMultipleBase
	{
		private string m_ChannelName;

		private PlotChannelBase m_CachedChannel;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string ChannelName
		{
			get
			{
				if (m_ChannelName == null)
				{
					return Const.EmptyString;
				}
				return m_ChannelName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("ChannelName", value);
				if (ChannelName != value)
				{
					m_ChannelName = value;
					m_CachedChannel = null;
					m_CachedChannel = Channel;
					if (m_CachedChannel != null)
					{
						base.XAxisName = m_CachedChannel.XAxisName;
						base.YAxisName = m_CachedChannel.YAxisName;
						base.Color = m_CachedChannel.Color;
					}
					SetupPointers();
					base.DoPropertyChange(this, "ChannelName");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PlotChannelBase Channel
		{
			get
			{
				if (m_CachedChannel != null)
				{
					return m_CachedChannel;
				}
				if (base.Plot == null)
				{
					return null;
				}
				m_CachedChannel = base.Plot.Channels[ChannelName];
				return m_CachedChannel;
			}
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			ChannelName = "Channel 1";
		}

		private bool ShouldSerializeChannelName()
		{
			return base.PropertyShouldSerialize("ChannelName");
		}

		private void ResetChannelName()
		{
			base.PropertyReset("ChannelName");
		}

		public override void ObjectRenamed(PlotObject value, string oldName)
		{
			base.ObjectRenamed(value, oldName);
			if (value is PlotChannelBase && oldName == m_ChannelName)
			{
				m_ChannelName = value.Name;
			}
		}

		public override void ObjectRemoved(PlotObject value)
		{
			base.ObjectRemoved(value);
			if (value == m_CachedChannel)
			{
				m_CachedChannel = null;
			}
		}

		public override void ObjectAdded(PlotObject value)
		{
			base.ObjectAdded(value);
			if (value is PlotChannelBase && value.Name == m_ChannelName)
			{
				m_CachedChannel = (value as PlotChannelBase);
			}
		}

		protected override void DrawSetup(PaintArgs p)
		{
			base.DrawSetup(p);
			PlotChannelBase channel = Channel;
			if (channel != null)
			{
				base.XAxisName = channel.XAxisName;
				base.YAxisName = channel.YAxisName;
			}
		}
	}
}
