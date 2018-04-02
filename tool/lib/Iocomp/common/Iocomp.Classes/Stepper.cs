using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Timers;

namespace Iocomp.Classes
{
	[Description("Contains the properties that control the stepper.")]
	public sealed class Stepper : SubClassBase, IStepper
	{
		private ValueDouble m_Value;

		private Timer m_Timer;

		private int m_RepeaterInterval;

		private int m_RepeaterInitialDelay;

		private bool m_Reversed;

		private double m_StepSize;

		private bool m_RepeaterEnabled;

		private DirectionState m_StepState;

		[Description("Indicates the value to be stepped up or down.")]
		[RefreshProperties(RefreshProperties.All)]
		public ValueDouble Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				m_Value.AsDouble = value.AsDouble;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the time interval for the auto repeat.")]
		public int RepeaterInterval
		{
			get
			{
				return m_RepeaterInterval;
			}
			set
			{
				base.PropertyUpdateDefault("RepeaterInterval", value);
				if (RepeaterInterval != value)
				{
					m_RepeaterInterval = value;
					base.DoPropertyChange(this, "RepeaterInterval");
				}
			}
		}

		[Description("Specifies the initial delay time before the value is stepped during the auto repeat mode.")]
		[RefreshProperties(RefreshProperties.All)]
		public int RepeaterInitialDelay
		{
			get
			{
				return m_RepeaterInitialDelay;
			}
			set
			{
				base.PropertyUpdateDefault("RepeaterInitialDelay", value);
				if (RepeaterInitialDelay != value)
				{
					m_RepeaterInitialDelay = value;
					base.DoPropertyChange(this, "RepeaterInitialDelay");
				}
			}
		}

		[Description("Indicates the direction of the stepper.")]
		[RefreshProperties(RefreshProperties.All)]
		public bool Reversed
		{
			get
			{
				return m_Reversed;
			}
			set
			{
				base.PropertyUpdateDefault("Reversed", value);
				if (Reversed != value)
				{
					m_Reversed = value;
					base.DoPropertyChange(this, "Reversed");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the amount to increment or decrement the value.")]
		public double StepSize
		{
			get
			{
				return m_StepSize;
			}
			set
			{
				base.PropertyUpdateDefault("StepSize", value);
				if (StepSize != value)
				{
					m_StepSize = value;
					base.DoPropertyChange(this, "StepSize");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Indicates if the auto reaper is on or off.")]
		public bool RepeaterEnabled
		{
			get
			{
				return m_RepeaterEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("RepeaterEnabled", value);
				if (RepeaterEnabled != value)
				{
					m_RepeaterEnabled = value;
					base.DoPropertyChange(this, "RepeaterEnabled");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Stepper";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.StepperEditorPlugIn";
		}

		void IStepper.StopStep(DirectionState stepState)
		{
			StopStep(stepState);
		}

		void IStepper.StartStep(DirectionState stepState)
		{
			StartStep(stepState);
		}

		public Stepper()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Value = new ValueDouble();
			base.AddSubClass(Value);
			m_Timer = new Timer();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
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

		private bool ShouldSerializeValue()
		{
			return ((ISubClassBase)Value).ShouldSerialize();
		}

		private void ResetValue()
		{
			((ISubClassBase)Value).ResetToDefault();
		}

		private bool ShouldSerializeRepeaterInterval()
		{
			return base.PropertyShouldSerialize("RepeaterInterval");
		}

		private void ResetRepeaterInterval()
		{
			base.PropertyReset("RepeaterInterval");
		}

		private bool ShouldSerializeRepeaterInitialDelay()
		{
			return base.PropertyShouldSerialize("RepeaterInitialDelay");
		}

		private void ResetRepeaterInitialDelay()
		{
			base.PropertyReset("RepeaterInitialDelay");
		}

		private bool ShouldSerializeReversed()
		{
			return base.PropertyShouldSerialize("Reversed");
		}

		private void ResetReversed()
		{
			base.PropertyReset("Reversed");
		}

		private bool ShouldSerializeStepSize()
		{
			return base.PropertyShouldSerialize("StepSize");
		}

		private void ResetStepSize()
		{
			base.PropertyReset("StepSize");
		}

		private bool ShouldSerializeRepeaterEnabled()
		{
			return base.PropertyShouldSerialize("RepeaterEnabled");
		}

		private void ResetRepeaterEnabled()
		{
			base.PropertyReset("RepeaterEnabled");
		}

		private void StartStep(DirectionState stepState)
		{
			m_StepState = stepState;
			if (stepState != 0 && RepeaterEnabled)
			{
				m_Timer.Interval = (double)RepeaterInitialDelay;
				m_Timer.Enabled = true;
			}
		}

		private void StopStep(DirectionState stepState)
		{
			if (stepState == m_StepState)
			{
				StepIt();
			}
			if (RepeaterEnabled)
			{
				m_Timer.Enabled = false;
			}
		}

		private void TimerElapsed(object sender, ElapsedEventArgs e)
		{
			m_Timer.Interval = (double)RepeaterInterval;
			StepIt();
		}

		private void StepIt()
		{
			Value.BeginUserUpdate();
			if (Reversed)
			{
				if (m_StepState == DirectionState.Increment)
				{
					Value.AsDouble -= m_StepSize;
				}
				else if (m_StepState == DirectionState.Decrement)
				{
					Value.AsDouble += m_StepSize;
				}
			}
			else if (m_StepState == DirectionState.Increment)
			{
				Value.AsDouble += m_StepSize;
			}
			else if (m_StepState == DirectionState.Decrement)
			{
				Value.AsDouble -= m_StepSize;
			}
			Value.EndUserUpdate();
		}
	}
}
