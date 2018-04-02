using Iocomp.Interfaces;
using System;
using System.Collections;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public sealed class UpdateRateTimer
	{
		private static Timer m_Timer;

		private static ArrayList m_ControlList;

		static UpdateRateTimer()
		{
			m_ControlList = new ArrayList();
		}

		public static void AddControl(IUpdateRate update)
		{
			m_ControlList.Add(update);
			if (m_Timer == null)
			{
				m_Timer = new Timer();
				m_Timer.Interval = 100;
				m_Timer.Enabled = true;
				m_Timer.Tick += m_Timer_Tick;
			}
		}

		public static void RemoveControl(IUpdateRate update)
		{
			m_ControlList.Remove(update);
			if (m_ControlList.Count == 0)
			{
				m_Timer.Enabled = false;
				m_Timer.Dispose();
				m_Timer = null;
			}
		}

		public static bool NeedsUpdate(IUpdateRate update)
		{
			if (update.FrameRate == 0.0)
			{
				return false;
			}
			if (update.Active)
			{
				return false;
			}
			if (!update.Needed)
			{
				return false;
			}
			DateTime now = DateTime.Now;
			if (Math2.DateTimeToDouble(now) > Math2.DateTimeToDouble(update.LastRepaintTime) + 1.0 / update.FrameRate * 1.0 / 86400.0)
			{
				return true;
			}
			return false;
		}

		private static void m_Timer_Tick(object sender, EventArgs e)
		{
			foreach (IUpdateRate control in m_ControlList)
			{
				if (NeedsUpdate(control))
				{
					control.InvalidateControl();
				}
			}
		}
	}
}
