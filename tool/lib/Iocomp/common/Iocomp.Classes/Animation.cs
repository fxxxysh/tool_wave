using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Timers;

namespace Iocomp.Classes
{
	[Description("Contains the properties that control the animation.")]
	public sealed class Animation : SubClassBase, IAnimation
	{
		private Timer m_Timer;

		private bool m_On;

		private int m_FrameNumber;

		private int m_FrameCount;

		private FrameDirection m_Direction;

		int IAnimation.FrameCount
		{
			get
			{
				return FrameCount;
			}
			set
			{
				FrameCount = value;
			}
		}

		int IAnimation.FrameNumber
		{
			get
			{
				return FrameNumber;
			}
			set
			{
				FrameNumber = value;
			}
		}

		[Description("Specifies the time interval for the animation.")]
		[RefreshProperties(RefreshProperties.All)]
		public double Interval
		{
			get
			{
				return m_Timer.Interval;
			}
			set
			{
				base.PropertyUpdateDefault("Interval", value);
				if (m_Timer.Interval != (double)(int)value)
				{
					m_Timer.Interval = (double)(int)value;
					base.DoPropertyChange(this, "Interval");
				}
			}
		}

		[Description("Specifies direction for the animation.")]
		[RefreshProperties(RefreshProperties.All)]
		public FrameDirection Direction
		{
			get
			{
				return m_Direction;
			}
			set
			{
				base.PropertyUpdateDefault("Direction", value);
				if (Direction != value)
				{
					m_Direction = value;
					base.DoPropertyChange(this, "Direction");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies if the animation is on or off.")]
		public bool On
		{
			get
			{
				return m_On;
			}
			set
			{
				base.PropertyUpdateDefault("On", value);
				if (On != value)
				{
					m_On = value;
					if (!base.Designing)
					{
						m_Timer.Enabled = value;
					}
					base.DoPropertyChange(this, "On");
				}
			}
		}

		private int FrameNumber
		{
			get
			{
				return m_FrameNumber;
			}
			set
			{
				if (value > FrameCount - 1)
				{
					value = 0;
				}
				if (value < 0)
				{
					value = FrameCount - 1;
				}
				if (FrameCount == 0)
				{
					value = -1;
				}
				if (FrameNumber != value)
				{
					m_FrameNumber = value;
					OnFrameChanged();
					base.DoPropertyChange(this, "FrameNumber");
				}
			}
		}

		private int FrameCount
		{
			get
			{
				return m_FrameCount;
			}
			set
			{
				if (FrameCount != value)
				{
					m_FrameCount = value;
					((IAnimation)this).FrameNumber = ((IAnimation)this).FrameNumber;
					base.DoPropertyChange(this, "FrameCount");
				}
			}
		}

		[Browsable(false)]
		public event EventHandler FrameChanged;

		protected override string GetPlugInTitle()
		{
			return "Animation";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AnimationEditorPlugIn";
		}

		public Animation()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Timer = new Timer();
			m_Timer.Elapsed += TimerElapsed;
			m_Timer.Enabled = false;
		}

		public void Dispose()
		{
			if (m_Timer != null)
			{
				m_Timer.Enabled = false;
				m_Timer.Dispose();
				m_Timer = null;
			}
		}

		private bool ShouldSerializeInterval()
		{
			return base.PropertyShouldSerialize("Interval");
		}

		private void ResetInterval()
		{
			base.PropertyReset("Interval");
		}

		private bool ShouldSerializeDirection()
		{
			return base.PropertyShouldSerialize("Direction");
		}

		private void ResetDirection()
		{
			base.PropertyReset("Direction");
		}

		private bool ShouldSerializeOn()
		{
			return base.PropertyShouldSerialize("On");
		}

		private void ResetOn()
		{
			base.PropertyReset("On");
		}

		private void TimerElapsed(object sender, ElapsedEventArgs e)
		{
			if (((IAnimation)this).Direction == FrameDirection.Forward)
			{
				((IAnimation)this).FrameNumber++;
			}
			else
			{
				((IAnimation)this).FrameNumber--;
			}
		}

		private void OnFrameChanged()
		{
			if (this.FrameChanged != null)
			{
				this.FrameChanged(this, EventArgs.Empty);
			}
		}

		public void GoFirst()
		{
			if (Direction == FrameDirection.Forward)
			{
				FrameNumber = 0;
			}
			else
			{
				FrameNumber = FrameCount - 1;
			}
		}

		public void GoLast()
		{
			if (Direction == FrameDirection.Forward)
			{
				FrameNumber = FrameCount - 1;
			}
			else
			{
				FrameNumber = 0;
			}
		}
	}
}
