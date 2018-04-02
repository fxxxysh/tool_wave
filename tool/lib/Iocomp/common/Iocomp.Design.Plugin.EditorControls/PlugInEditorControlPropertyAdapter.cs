using Iocomp.Classes;
using Iocomp.Interfaces;
using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace Iocomp.Design.Plugin.EditorControls
{
	[Description("Plug-In Editor Control Property Adapter.")]
	public class PlugInEditorControlPropertyAdapter
	{
		private string m_PropertyName;

		private ArrayList m_PropertyInfoCache;

		public string PropertyName
		{
			get
			{
				return m_PropertyName;
			}
			set
			{
				if (m_PropertyName != value)
				{
					value = ((value != null) ? value.Trim() : Const.EmptyString);
					m_PropertyName = value;
				}
			}
		}

		public PlugInEditorControlPropertyAdapter()
		{
			PropertyName = "";
			m_PropertyInfoCache = new ArrayList();
		}

		private PropertyInfo GetPropertyInfo(object value)
		{
			PropertyInfoCacheObject propertyInfoCacheObject = null;
			if (!(value is Iocomp.Classes.CollectionBase))
			{
				for (int i = 0; i < m_PropertyInfoCache.Count; i++)
				{
					propertyInfoCacheObject = (m_PropertyInfoCache[i] as PropertyInfoCacheObject);
					if (propertyInfoCacheObject.Object == value)
					{
						return propertyInfoCacheObject.PropertyInfo;
					}
				}
			}
			propertyInfoCacheObject = new PropertyInfoCacheObject();
			if (propertyInfoCacheObject == null)
			{
				return null;
			}
			propertyInfoCacheObject.Object = value;
			if (propertyInfoCacheObject.Object == null)
			{
				return null;
			}
			propertyInfoCacheObject.PropertyInfo = value.GetType().GetProperty(PropertyName);
			m_PropertyInfoCache.Add(propertyInfoCacheObject);
			return propertyInfoCacheObject.PropertyInfo;
		}

		public object GetDisplayValue(object value)
		{
			if (PropertyName == Const.EmptyString)
			{
				return null;
			}
			PropertyInfo propertyInfo = GetPropertyInfo(value);
			if (propertyInfo == (PropertyInfo)null)
			{
				return null;
			}
			return propertyInfo.GetValue(value, null);
		}

		public bool GetIsEnum(object value)
		{
			if (PropertyName == Const.EmptyString)
			{
				return false;
			}
			PropertyInfo property = value.GetType().GetProperty(PropertyName);
			if (property == (PropertyInfo)null)
			{
				return false;
			}
			if (property.PropertyType.IsEnum)
			{
				return true;
			}
			return false;
		}

		public void LoadEnums(object value, ComboBox comboBox)
		{
			if (!(PropertyName == Const.EmptyString))
			{
				PropertyInfo property = value.GetType().GetProperty(PropertyName);
				if (!(property == (PropertyInfo)null) && property.PropertyType.IsEnum)
				{
					comboBox.Items.Clear();
					string[] names = Enum.GetNames(property.PropertyType);
					for (int i = 0; i < names.Length; i++)
					{
						comboBox.Items.Add(names[i]);
					}
				}
			}
		}

		public void SetEnumIndex(object source, object value, ComboBox comboBox)
		{
			if (!(PropertyName == Const.EmptyString))
			{
				PropertyInfo property = source.GetType().GetProperty(PropertyName);
				if (!(property == (PropertyInfo)null) && property.PropertyType.IsEnum)
				{
					string[] names = Enum.GetNames(property.PropertyType);
					int num = 0;
					while (true)
					{
						if (num < names.Length)
						{
							if (!(value.ToString() == names[num]))
							{
								num++;
								continue;
							}
							break;
						}
						return;
					}
					comboBox.SelectedIndex = num;
				}
			}
		}

		public object GetAmbientValue(object value)
		{
			if (PropertyName == Const.EmptyString)
			{
				return null;
			}
			PropertyInfo property = value.GetType().GetProperty(PropertyName);
			if (property == (PropertyInfo)null)
			{
				return null;
			}
			IPropertyDefaults propertyDefaults = value as IPropertyDefaults;
			if (propertyDefaults != null)
			{
				propertyDefaults.DefaultReadBack = true;
				try
				{
					return property.GetValue(value, null);
				}
				finally
				{
					propertyDefaults.DefaultReadBack = false;
				}
			}
			return property.GetValue(value, null);
		}

		public void TransferAmbient(object source, object destination)
		{
			if (!(PropertyName == Const.EmptyString))
			{
				PropertyInfo property = source.GetType().GetProperty(PropertyName);
				PropertyInfo property2 = destination.GetType().GetProperty(PropertyName);
				if (!(property == (PropertyInfo)null) && !(property2 == (PropertyInfo)null))
				{
					IPropertyDefaults propertyDefaults = source as IPropertyDefaults;
					if (propertyDefaults != null)
					{
						propertyDefaults.DefaultReadBack = true;
					}
					try
					{
						if (property2.CanWrite)
						{
							property2.SetValue(destination, property.GetValue(source, null), null);
						}
					}
					finally
					{
						if (propertyDefaults != null)
						{
							propertyDefaults.DefaultReadBack = false;
						}
					}
				}
			}
		}

		public void SetValue(object desObject, object value)
		{
			if (!(PropertyName == Const.EmptyString))
			{
				PropertyInfo propertyInfo = GetPropertyInfo(desObject);
				if (!(propertyInfo == (PropertyInfo)null) && propertyInfo.CanWrite)
				{
					propertyInfo.SetValue(desObject, value, null);
				}
			}
		}
	}
}
