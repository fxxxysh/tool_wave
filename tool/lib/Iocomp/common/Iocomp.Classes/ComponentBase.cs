using Iocomp.Delegates;
using Iocomp.Design;
using Iocomp.Interfaces;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Serializable]
	[DesignerCategory("code")]
	[Description("Iocomp's ancestor class for all components.")]
	[DesignerSerializer(typeof(LoadBeginEndSerializerComponentBase), typeof(CodeDomSerializer))]
	[Editor(typeof(UITypeEditorGeneric), typeof(UITypeEditor))]
	public abstract class ComponentBase : Component, IComponentBase, IPropertyDefaults, ISupportUITypeEditor
	{
		private bool m_Loading;

		private bool m_Creating;

		private bool m_SettingDefaults;

		private bool m_AfterCreating;

		private SubClassBaseCollection m_SubClassList;

		private ArrayList m_DefaultArray;

		private Form m_Form;

		private bool m_GettingDefault;

		private bool m_DefaultReadBack;

		bool IPropertyDefaults.DefaultReadBack
		{
			get
			{
				return DefaultReadBack;
			}
			set
			{
				DefaultReadBack = value;
			}
		}

		bool IComponentBase.SettingDefaults
		{
			get
			{
				return SettingDefaults;
			}
		}

		[Browsable(false)]
		public bool Designing
		{
			get
			{
				return base.DesignMode;
			}
		}

		[Browsable(false)]
		public bool Loading
		{
			get
			{
				return m_Loading;
			}
		}

		[Browsable(false)]
		public bool Creating
		{
			get
			{
				return m_Creating;
			}
		}

		[Browsable(false)]
		public bool AfterCreating
		{
			get
			{
				return m_AfterCreating;
			}
		}

		protected bool SettingDefaults => m_SettingDefaults;

		[Browsable(false)]
		public Form Form
		{
			get
			{
				if (m_Form != null)
				{
					return m_Form;
				}
				return base.Container as Form;
			}
		}

		protected bool GettingDefault
		{
			get
			{
				if (!m_GettingDefault)
				{
					return m_DefaultReadBack;
				}
				return true;
			}
		}

		private bool DefaultReadBack
		{
			get
			{
				return m_DefaultReadBack;
			}
			set
			{
				if (m_SubClassList != null)
				{
					foreach (IPropertyDefaults subClass in m_SubClassList)
					{
						subClass.DefaultReadBack = value;
					}
				}
			}
		}

		[Browsable(false)]
		public event PropertyChangeEventHandler PropertyChanged;

		void IComponentBase.ForceDesignerChange()
		{
			ForceDesignerChange();
		}

		string ISupportUITypeEditor.GetPlugInTitle()
		{
			return GetPlugInTitle();
		}

		string ISupportUITypeEditor.GetPlugInClassName()
		{
			return GetPlugInClassName();
		}

		void IComponentBase.SetComponentDefaults()
		{
			SetComponentDefaults();
		}

		void IComponentBase.DoPropertyChange(object sender, string propertyName)
		{
			DoPropertyChange(sender, propertyName);
		}

		protected void DoCreate()
		{
			m_Creating = true;
			m_DefaultReadBack = false;
			try
			{
				CreateObjects();
			}
			finally
			{
				m_Creating = false;
			}
			m_SettingDefaults = true;
			try
			{
				if (m_SubClassList != null)
				{
					foreach (SubClassBase subClass in m_SubClassList)
					{
						((ISubClassBase)subClass).SettingDefaults = true;
					}
				}
				SetDefaults();
				if (m_SubClassList != null)
				{
					foreach (SubClassBase subClass2 in m_SubClassList)
					{
						((ISubClassBase)subClass2).SettingDefaults = false;
					}
				}
			}
			finally
			{
				m_SettingDefaults = false;
			}
			m_AfterCreating = true;
			try
			{
				AfterCreate();
			}
			finally
			{
				m_AfterCreating = false;
			}
		}

		protected virtual void Loaded()
		{
		}

		protected virtual void ModifyStyle()
		{
		}

		protected virtual void CreateObjects()
		{
		}

		protected virtual void AfterCreate()
		{
		}

		protected virtual string GetPlugInTitle()
		{
			return Const.EmptyString;
		}

		protected virtual string GetPlugInClassName()
		{
			return Const.EmptyString;
		}

		protected virtual void SetDefaults()
		{
		}

		public virtual void LoadingBegin()
		{
			m_Loading = true;
		}

		public virtual void LoadingEnd()
		{
			m_Loading = false;
			Loaded();
		}

		public void SetForm(Form value)
		{
			m_Form = value;
		}

		protected void AddSubClass(ISubClassBase value)
		{
			if (m_SubClassList == null)
			{
				m_SubClassList = new SubClassBaseCollection();
			}
			m_SubClassList.Add(value);
			value.ComponentBase = this;
		}

		protected void ForceDesignerChange()
		{
			IComponentChangeService componentChangeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
			componentChangeService?.OnComponentChanged(this, null, null, null);
		}

		protected virtual void SetComponentDefaults()
		{
		}

		protected void ThrowStreamingSafeException(string value)
		{
			if (Loading)
			{
				return;
			}
			throw new Exception(value);
		}

		private void OnPropertyChanged(object sender, string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
			}
		}

		protected void DoPropertyChange(object sender, string propertyName)
		{
			if (!Creating && !SettingDefaults)
			{
				PropertyChangedHook(sender, propertyName);
				if (this.PropertyChanged != null)
				{
					OnPropertyChanged(sender, propertyName);
				}
			}
		}

		protected virtual void PropertyChangedHook(object sender, string propertyName)
		{
		}

		public void ShowEditorCustom(bool designTimeStyle, bool modal)
		{
			UITypeEditorGeneric uITypeEditorGeneric = (UITypeEditorGeneric)TypeDescriptor.GetEditor(this, typeof(UITypeEditor));
			uITypeEditorGeneric?.EditValue(this, designTimeStyle, modal);
		}

		protected void PropertyUpdateDefault(string name, object value)
		{
			if (SettingDefaults)
			{
				if (m_DefaultArray == null)
				{
					m_DefaultArray = new ArrayList();
				}
				foreach (PropertyData item in m_DefaultArray)
				{
					if (item.Name.ToUpper(CultureInfo.InvariantCulture) == name.ToUpper(CultureInfo.InvariantCulture))
					{
						item.Value = value;
						return;
					}
				}
				PropertyData propertyData2 = new PropertyData();
				propertyData2.Name = name;
				propertyData2.Value = value;
				m_DefaultArray.Add(propertyData2);
			}
		}

		protected void PropertyReset(string name)
		{
			if (m_DefaultArray != null)
			{
				foreach (PropertyData item in m_DefaultArray)
				{
					if (item.Name.ToUpper(CultureInfo.InvariantCulture) == name.ToUpper(CultureInfo.InvariantCulture))
					{
						PropertyInfo property = base.GetType().GetProperty(name);
						if (property != (PropertyInfo)null)
						{
							property.SetValue(this, item.Value, null);
						}
						ForceDesignerChange();
						break;
					}
				}
			}
		}

		protected bool PropertyShouldSerialize(string name)
		{
			if (m_DefaultArray == null)
			{
				return true;
			}
			m_GettingDefault = true;
			try
			{
				foreach (PropertyData item in m_DefaultArray)
				{
					if (item.Name.ToUpper(CultureInfo.InvariantCulture) == name.ToUpper(CultureInfo.InvariantCulture))
					{
						PropertyInfo property = base.GetType().GetProperty(name);
						if (!(property == (PropertyInfo)null))
						{
							if (item.Value == null)
							{
								return property.GetValue(this, null) != null;
							}
							if (item.Value.GetType() == typeof(string[]))
							{
								if ((property.GetValue(this, null) as string[]).Length > 1)
								{
									return true;
								}
								return (property.GetValue(this, null) as string[])[0].Length != 0;
							}
							return !item.Value.Equals(property.GetValue(this, null));
						}
					}
				}
				return true;
			}
			finally
			{
				m_GettingDefault = false;
			}
		}
	}
}
