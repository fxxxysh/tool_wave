using Iocomp.Types;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Ancestor to all Value type objects.")]
	public abstract class Value : SubClassBase
	{
		private bool m_EventsEnabled;

		protected EventSource EventSource
		{
			get
			{
				if (ControlBase != null)
				{
					return ControlBase.EventSource;
				}
				return EventSource.Code;
			}
		}

		protected bool ShouldTriggerEvents
		{
			get
			{
				if (ComponentBase != null && ComponentBase.Creating)
				{
					return false;
				}
				if (ComponentBase != null && ComponentBase.Loading)
				{
					return false;
				}
				if (!EventsEnabled)
				{
					return false;
				}
				return true;
			}
		}

		[Description("Determines if events are triggered when the value is chaged")]
		[RefreshProperties(RefreshProperties.All)]
		public bool EventsEnabled
		{
			get
			{
				return m_EventsEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("EventsEnabled", value);
				if (EventsEnabled != value)
				{
					m_EventsEnabled = value;
					base.DoPropertyChange(this, "EventsEnabled");
				}
			}
		}

		public virtual string AsString
		{
			get
			{
				return "";
			}
			set
			{
			}
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			EventsEnabled = true;
		}

		private bool ShouldSerializeEventsEnabled()
		{
			return base.PropertyShouldSerialize("EventsEnabled");
		}

		private void ResetEventsEnabled()
		{
			base.PropertyReset("EventsEnabled");
		}
	}
}
