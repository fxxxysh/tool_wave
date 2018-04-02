using Iocomp.Delegates;
using Iocomp.Design;
using Iocomp.Interfaces;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;

namespace Iocomp.Classes
{
	[Editor(typeof(UITypeEditorGeneric), typeof(UITypeEditor))]
	public abstract class CollectionBase : System.Collections.CollectionBase, ICollectionBase, IAmbientOwner, ISupportUITypeEditor
	{
		private bool m_AllowEdit;

		private IComponentBase m_ComponentBase;

		private IAmbientOwner I_AmbientOwner;

		bool ICollectionBase.AllowEdit
		{
			get
			{
				return AllowEdit;
			}
		}

		IComponentBase ICollectionBase.ComponentBase
		{
			get
			{
				return ComponentBase;
			}
			set
			{
				ComponentBase = value;
			}
		}

		Font IAmbientOwner.Font
		{
			get
			{
				if (I_AmbientOwner != null)
				{
					return I_AmbientOwner.Font;
				}
				return null;
			}
		}

		Color IAmbientOwner.ForeColor
		{
			get
			{
				if (I_AmbientOwner != null)
				{
					return I_AmbientOwner.ForeColor;
				}
				return Color.Empty;
			}
		}

		Color IAmbientOwner.BackColor
		{
			get
			{
				if (I_AmbientOwner != null)
				{
					return I_AmbientOwner.BackColor;
				}
				return Color.Empty;
			}
		}

		Color IAmbientOwner.Color
		{
			get
			{
				if (I_AmbientOwner != null)
				{
					return I_AmbientOwner.Color;
				}
				return Color.Empty;
			}
		}

		Color IAmbientOwner.CustomColor1
		{
			get
			{
				if (I_AmbientOwner != null)
				{
					return I_AmbientOwner.CustomColor1;
				}
				return Color.Empty;
			}
		}

		Color IAmbientOwner.CustomColor2
		{
			get
			{
				if (I_AmbientOwner != null)
				{
					return I_AmbientOwner.CustomColor2;
				}
				return Color.Empty;
			}
		}

		Color IAmbientOwner.CustomColor3
		{
			get
			{
				if (I_AmbientOwner != null)
				{
					return I_AmbientOwner.CustomColor3;
				}
				return Color.Empty;
			}
		}

		protected bool AllowEdit
		{
			get
			{
				return m_AllowEdit;
			}
			set
			{
				m_AllowEdit = value;
			}
		}

		public int LastIndex => base.Count - 1;

		protected IComponentBase ComponentBase
		{
			get
			{
				return m_ComponentBase;
			}
			set
			{
				m_ComponentBase = value;
				I_AmbientOwner = (value as IAmbientOwner);
				foreach (ISubClassBase item in this)
				{
					if (item != null)
					{
						item.ComponentBase = ComponentBase;
						item.ControlBase = (ComponentBase as IControlBase);
					}
				}
			}
		}

		[Browsable(false)]
		public event EventHandler Changed;

		[Browsable(false)]
		public event AddRemoveObjectEventHandler ObjectAdded;

		[Browsable(false)]
		public event AddRemoveObjectEventHandler ObjectRemoved;

		object ICollectionBase.CreateInstance(Type type)
		{
			return CreateInstance(type);
		}

		string ISupportUITypeEditor.GetPlugInTitle()
		{
			return GetPlugInTitle();
		}

		string ISupportUITypeEditor.GetPlugInClassName()
		{
			return GetPlugInClassName();
		}

		protected object CreateInstance(Type type)
		{
			object obj = Activator.CreateInstance(type);
			base.List.Add(obj);
			return obj;
		}

		protected CollectionBase(IComponentBase componentBase)
		{
			ComponentBase = componentBase;
			AllowEdit = true;
		}

		public void Remove(int index)
		{
			base.List.RemoveAt(index);
		}

		protected virtual string GetPlugInTitle()
		{
			return Const.EmptyString;
		}

		protected virtual string GetPlugInClassName()
		{
			return Const.EmptyString;
		}

		protected virtual void SetupObjectBeforeAmbientControlBaseConnection(object value)
		{
		}

		public void ShowEditorCustom(bool designTimeStyle, bool modal)
		{
			UITypeEditorGeneric uITypeEditorGeneric = (UITypeEditorGeneric)TypeDescriptor.GetEditor(this, typeof(UITypeEditor));
			uITypeEditorGeneric?.EditValue(this, designTimeStyle, modal);
		}

		public void SavePropertiesToFile(string fileName)
		{
			InstanceIO.SavePropertiesToFile(this, fileName);
		}

		public void LoadPropertiesFromFile(string fileName)
		{
			InstanceIO.LoadPropertiesFromFile(this, fileName);
		}

		public void SavePropertiesToStream(StreamWriter streamWriter)
		{
			InstanceIO.SavePropertiesToStream(this, streamWriter);
		}

		public void LoadPropertiesFromStream(StreamReader streamReader)
		{
			InstanceIO.LoadPropertiesFromStream(this, streamReader);
		}

		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete(index, value);
			SetupObjectBeforeAmbientControlBaseConnection(value);
			OnObjectAdded(value);
			OnChanged();
		}

		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete(index, value);
			OnObjectRemoved(value);
			OnChanged();
		}

		protected override void OnSetComplete(int index, object oldValue, object newValue)
		{
			base.OnSetComplete(index, oldValue, newValue);
			OnObjectRemoved(oldValue);
			OnObjectAdded(newValue);
			OnChanged();
		}

		protected override void OnClear()
		{
			while (base.Count > 0)
			{
				base.RemoveAt(0);
			}
			OnChanged();
		}

		public virtual void Reset()
		{
			base.Clear();
		}

		protected virtual void OnChanged()
		{
			if (ComponentBase != null)
			{
				ComponentBase.DoPropertyChange(this, "Changed");
			}
			if (this.Changed != null)
			{
				this.Changed(this, EventArgs.Empty);
			}
		}

		protected virtual void OnObjectAdded(object value)
		{
			if (value is ISubClassBase)
			{
				(value as ISubClassBase).ComponentBase = ComponentBase;
			}
			if (value is ISubClassBase)
			{
				(value as ISubClassBase).ControlBase = (ComponentBase as IControlBase);
			}
			if (value is ISubClassBase)
			{
				(value as ISubClassBase).AmbientOwner = this;
			}
			if (value is ISubClassBase)
			{
				(value as ISubClassBase).Collection = this;
			}
			if (ComponentBase != null)
			{
				ComponentBase.DoPropertyChange(this, "Add");
			}
			if (this.ObjectAdded != null)
			{
				this.ObjectAdded(this, new ObjectEventArgs(value));
			}
		}

		protected virtual void OnObjectRemoved(object value)
		{
			if (value is ISubClassBase)
			{
				(value as ISubClassBase).ComponentBase = null;
			}
			if (value is ISubClassBase)
			{
				(value as ISubClassBase).ControlBase = null;
			}
			if (value is ISubClassBase)
			{
				(value as ISubClassBase).AmbientOwner = null;
			}
			if (value is ISubClassBase)
			{
				(value as ISubClassBase).Collection = null;
			}
			if (ComponentBase != null)
			{
				ComponentBase.DoPropertyChange(this, "Remove");
			}
			if (this.ObjectRemoved != null)
			{
				this.ObjectRemoved(this, new ObjectEventArgs(value));
			}
		}
	}
}
