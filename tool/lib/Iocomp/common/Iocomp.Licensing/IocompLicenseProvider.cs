using Iocomp.Classes;
using Microsoft.Win32;
using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace Iocomp.Licensing
{
	public abstract class IocompLicenseProvider : LicenseProvider
	{
		private class IocompLicense : License
		{
			private IocompLicenseProvider m_Owner;

			private string m_LicenseKey;

			public override string LicenseKey => m_LicenseKey;

			public IocompLicense(IocompLicenseProvider owner, string licensekey)
			{
				m_Owner = owner;
				m_LicenseKey = licensekey;
			}

			public override void Dispose()
			{
				m_Owner = null;
				m_LicenseKey = null;
			}
		}

		private static DateTime m_LastEvalPopUpDateTime = DateTime.Now - new TimeSpan(1, 0, 0);

		private static Timer m_Timer;

		private static Form m_EvaluationForm;

		private static ArrayList m_DynamicLicenseKeys;

		private static readonly object licenseManagerLock = new object();

		public static void AddLicenseKey(Type type, string value)
		{
			if (m_DynamicLicenseKeys == null)
			{
				m_DynamicLicenseKeys = new ArrayList();
			}
			DynamicLicenseKey dynamicLicenseKey = new DynamicLicenseKey();
			dynamicLicenseKey.Type = type;
			dynamicLicenseKey.KeyString = value;
			m_DynamicLicenseKeys.Add(dynamicLicenseKey);
		}

		~IocompLicenseProvider()
		{
			if (m_Timer != null)
			{
				m_Timer.Enabled = false;
				m_Timer = null;
			}
			if (m_EvaluationForm != null)
			{
				m_EvaluationForm.Hide();
				m_EvaluationForm.Dispose();
			}
		}

		public override License GetLicense(LicenseContext context, Type type, object instance, bool allowExceptions)
		{
			bool flag = false;
			flag = true;
			IocompLicense iocompLicense = null;
			string text = null;
			RegistryKey registryKey = null;
			Type type2 = type;
			if (!flag)
			{
				registryKey = Registry.LocalMachine.OpenSubKey("Software\\Iocomp\\.Net Licenses V3");
				if (registryKey == null)
				{
					registryKey = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Iocomp\\.Net Licenses V3");
				}
				do
				{
					if (!(type2 != typeof(Component)) && !(type2.Name == "OPCData"))
					{
						break;
					}
					if (m_DynamicLicenseKeys != null)
					{
						int num = 0;
						while (num < m_DynamicLicenseKeys.Count)
						{
							if (!((m_DynamicLicenseKeys[num] as DynamicLicenseKey).Type == type))
							{
								num++;
								continue;
							}
							text = (m_DynamicLicenseKeys[num] as DynamicLicenseKey).KeyString;
							break;
						}
					}
					if (text == null && registryKey != null)
					{
						text = (string)registryKey.GetValue(type2.FullName);
					}
					try
					{
						if (text == null)
						{
							text = GetSavedLicenseKeySpecial(type2, null);
						}
					}
					catch (Exception)
					{
						text = null;
						iocompLicense = null;
					}
					if (text != null && LicenseKeyValid(type, text))
					{
						iocompLicense = new IocompLicense(this, text);
						break;
					}
					type2 = type2.BaseType;
				}
				while (!(type2 == (Type)null) && !(type2 != typeof(object)));
			}
			if (iocompLicense == null)
			{
				if (DateTime.Now > DateTime.Now)
				{
					if (m_Timer == null)
					{
						m_Timer = new Timer();
						m_Timer.Interval = 200;
						m_Timer.Tick += m_Timer_Tick;
						m_Timer.Enabled = true;
					}
					m_LastEvalPopUpDateTime = DateTime.Now;
				}
				iocompLicense = new IocompLicense(this, "Evaluation");
			}
			if (context != null && iocompLicense != null)
			{
				context.SetSavedLicenseKey(type, iocompLicense.LicenseKey);
			}
			return iocompLicense;
		}

		private void m_Timer_Tick(object sender, EventArgs e)
		{
			m_Timer.Stop();
			m_Timer.Interval = 600000;
			m_Timer.Start();
			if (m_EvaluationForm == null)
			{
				m_EvaluationForm = new EvaluationForm();
			}
			m_EvaluationForm.Show();
			m_EvaluationForm.Show();
		}

		protected virtual bool LicenseKeyValid(Type type, string licensekey)
		{
			return false;
		}

		public string GetSavedLicenseKeySpecial(Type type, Assembly resourceAssembly)
		{
			LicenseContext licenseContext = new CustomLicenseContext();
			return licenseContext.GetSavedLicenseKey(type, resourceAssembly);
		}
	}
}
