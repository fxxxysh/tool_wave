using Iocomp.Delegates;
using Iocomp.Design;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Serializable]
	[Editor(typeof(UITypeEditorGeneric), typeof(UITypeEditor))]
	[Description("Iocomp's ancestor for all sub class objects.")]
	[Category("Iocomp")]
	[ToolboxItem(false)]
	[TypeConverter(typeof(SubClassTypeConverter))]
	public abstract class SubClassBase : ISubClassBase, IUIInput, IAmbientOwner, IPropertyDefaults, ISupportUITypeEditor
	{
		private IControlBase m_ControlBase;

		private IComponentBase m_ComponentBase;

		private CollectionBase m_Collection;

		private bool m_Creating;

		private bool m_CreationComplete;

		private ArrayList m_DefaultArray;

		private SubClassBaseCollection m_SubClassList;

		private bool m_DefaultReadBack;

		private bool m_GettingDefault;

		private bool m_SettingDefaults;

		private UIInputCollection m_UICollection;

		private Rectangle m_Bounds;

		private bool m_IsMouseDown;

		private bool m_IsMouseActive;

		private bool m_IsKeyDown;

		private bool m_IsKeyActive;

		private bool m_VisibleInternal;

		private bool m_EnabledInternal;

		private Font m_Font;

		private Color m_ForeColor;

		private Color m_BackColor;

		private Color m_CustomColor1;

		private Color m_CustomColor2;

		private Color m_CustomColor3;

		private Color m_Color;

		private IAmbientOwner I_AmbientOwner;

		private AmbientColorSouce m_ColorAmbientSource;

		private bool m_FreezePropertyChange;

		Font IAmbientOwner.Font
		{
			get
			{
				return Font;
			}
		}

		Color IAmbientOwner.ForeColor
		{
			get
			{
				return ForeColor;
			}
		}

		Color IAmbientOwner.BackColor
		{
			get
			{
				return BackColor;
			}
		}

		Color IAmbientOwner.Color
		{
			get
			{
				return Color;
			}
		}

		Color IAmbientOwner.CustomColor1
		{
			get
			{
				return CustomColor1;
			}
		}

		Color IAmbientOwner.CustomColor2
		{
			get
			{
				return CustomColor2;
			}
		}

		Color IAmbientOwner.CustomColor3
		{
			get
			{
				return CustomColor3;
			}
		}

		IControlBase ISubClassBase.ControlBase
		{
			get
			{
				return ControlBase;
			}
			set
			{
				ControlBase = value;
			}
		}

		IComponentBase ISubClassBase.ComponentBase
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

		CollectionBase ISubClassBase.Collection
		{
			get
			{
				return m_Collection;
			}
			set
			{
				m_Collection = value;
			}
		}

		IAmbientOwner ISubClassBase.AmbientOwner
		{
			get
			{
				return I_AmbientOwner;
			}
			set
			{
				I_AmbientOwner = value;
			}
		}

		SubClassBaseCollection ISubClassBase.SubClassList
		{
			get
			{
				return SubClassList;
			}
		}

		bool ISubClassBase.SettingDefaults
		{
			get
			{
				return SettingDefaults;
			}
			set
			{
				SettingDefaults = value;
			}
		}

		bool ISubClassBase.FreezePropertyChange
		{
			get
			{
				return FreezePropertyChange;
			}
			set
			{
				FreezePropertyChange = value;
			}
		}

		AmbientColorSouce ISubClassBase.ColorAmbientSource
		{
			get
			{
				return ColorAmbientSource;
			}
			set
			{
				ColorAmbientSource = value;
			}
		}

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

		UIInputCollection IUIInput.UICollection
		{
			get
			{
				return m_UICollection;
			}
			set
			{
				m_UICollection = value;
			}
		}

		bool IUIInput.Visible
		{
			get
			{
				return VisibleInternal;
			}
			set
			{
				VisibleInternal = value;
			}
		}

		bool IUIInput.HitVisible
		{
			get
			{
				return HitVisibleInternal;
			}
		}

		bool IUIInput.Enabled
		{
			get
			{
				return EnabledInternal;
			}
			set
			{
				EnabledInternal = value;
			}
		}

		bool IUIInput.Focused
		{
			get
			{
				return Focused;
			}
		}

		bool IUIInput.IsMouseDown
		{
			get
			{
				return IsMouseDown;
			}
			set
			{
				IsMouseDown = value;
			}
		}

		bool IUIInput.IsMouseActive
		{
			get
			{
				return IsMouseActive;
			}
			set
			{
				IsMouseActive = value;
			}
		}

		bool IUIInput.IsKeyDown
		{
			get
			{
				return IsKeyDown;
			}
			set
			{
				IsKeyDown = value;
			}
		}

		bool IUIInput.IsKeyActive
		{
			get
			{
				return IsKeyActive;
			}
			set
			{
				IsKeyActive = value;
			}
		}

		Rectangle IUIInput.Bounds
		{
			get
			{
				return Bounds;
			}
			set
			{
				Bounds = value;
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

		protected IAmbientOwner AmbientOwner => I_AmbientOwner;

		[Browsable(false)]
		public bool Creating
		{
			get
			{
				return m_Creating;
			}
		}

		protected bool SettingDefaults
		{
			get
			{
				return m_SettingDefaults;
			}
			set
			{
				m_SettingDefaults = value;
				if (m_SubClassList != null)
				{
					foreach (SubClassBase subClass in m_SubClassList)
					{
						((ISubClassBase)subClass).SettingDefaults = value;
					}
				}
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
				m_DefaultReadBack = value;
				if (m_SubClassList != null)
				{
					foreach (IPropertyDefaults subClass in m_SubClassList)
					{
						subClass.DefaultReadBack = value;
					}
				}
			}
		}

		protected virtual IControlBase ControlBase
		{
			get
			{
				return m_ControlBase;
			}
			set
			{
				if (m_ControlBase != value)
				{
					m_ControlBase = value;
					if (m_SubClassList != null)
					{
						foreach (SubClassBase subClass in m_SubClassList)
						{
							((ISubClassBase)subClass).ControlBase = ControlBase;
						}
					}
				}
			}
		}

		protected virtual IComponentBase ComponentBase
		{
			get
			{
				return m_ComponentBase;
			}
			set
			{
				if (m_ComponentBase != value)
				{
					m_ComponentBase = value;
					if (m_SubClassList != null)
					{
						foreach (SubClassBase subClass in m_SubClassList)
						{
							((ISubClassBase)subClass).ComponentBase = ComponentBase;
						}
					}
				}
			}
		}

		protected CollectionBase Collection => m_Collection;

		protected bool Designing
		{
			get
			{
				if (ComponentBase != null)
				{
					return ComponentBase.Designing;
				}
				return false;
			}
		}

		protected virtual bool VisibleInternal
		{
			get
			{
				return m_VisibleInternal;
			}
			set
			{
				PropertyUpdateDefault("Visible", value);
				if (VisibleInternal != value)
				{
					m_VisibleInternal = value;
					if (!m_VisibleInternal && UICollection != null)
					{
						UICollection.FocusDisabled(this);
					}
					DoPropertyChange(this, "Visible");
				}
			}
		}

		protected virtual bool HitVisibleInternal => m_VisibleInternal;

		protected bool EnabledInternal
		{
			get
			{
				return m_EnabledInternal;
			}
			set
			{
				PropertyUpdateDefault("Enabled", value);
				if (EnabledInternal != value)
				{
					m_EnabledInternal = value;
					if (!m_EnabledInternal && UICollection != null)
					{
						UICollection.FocusDisabled(this);
					}
					DoPropertyChange(this, "Enabled");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		protected Font Font
		{
			get
			{
				if (GettingDefault)
				{
					return m_Font;
				}
				if (m_Font == null && AmbientOwner != null)
				{
					return AmbientOwner.Font;
				}
				return m_Font;
			}
			set
			{
				PropertyUpdateDefault("Font", value);
				if (!GPFunctions.Equals(Font, value))
				{
					m_Font = value;
					DoPropertyChange(this, "Font");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		protected Color ForeColor
		{
			get
			{
				if (GettingDefault)
				{
					return m_ForeColor;
				}
				if (m_ForeColor == Color.Empty && AmbientOwner != null)
				{
					return AmbientOwner.ForeColor;
				}
				return m_ForeColor;
			}
			set
			{
				PropertyUpdateDefault("ForeColor", value);
				if (ForeColor != value)
				{
					m_ForeColor = value;
					DoPropertyChange(this, "ForeColor");
				}
			}
		}

		[Category("Iocomp")]
		[Description("")]
		protected Color BackColor
		{
			get
			{
				if (GettingDefault)
				{
					return m_BackColor;
				}
				if (m_BackColor == Color.Empty && AmbientOwner != null)
				{
					return AmbientOwner.BackColor;
				}
				return m_BackColor;
			}
			set
			{
				PropertyUpdateDefault("BackColor", value);
				if (BackColor != value)
				{
					m_BackColor = value;
					DoPropertyChange(this, "BackColor");
				}
			}
		}

		protected Color CustomColor1
		{
			get
			{
				if (GettingDefault)
				{
					return m_CustomColor1;
				}
				if (m_CustomColor1 == Color.Empty && AmbientOwner != null)
				{
					return AmbientOwner.CustomColor1;
				}
				return m_CustomColor1;
			}
			set
			{
				PropertyUpdateDefault("CustomColor1", value);
				if (CustomColor1 != value)
				{
					m_CustomColor1 = value;
					DoPropertyChange(this, "CustomColor1");
				}
			}
		}

		protected Color CustomColor2
		{
			get
			{
				if (GettingDefault)
				{
					return m_CustomColor2;
				}
				if (m_CustomColor2 == Color.Empty && AmbientOwner != null)
				{
					return AmbientOwner.CustomColor2;
				}
				return m_CustomColor2;
			}
			set
			{
				PropertyUpdateDefault("CustomColor2", value);
				if (CustomColor2 != value)
				{
					m_CustomColor2 = value;
					DoPropertyChange(this, "CustomColor2");
				}
			}
		}

		protected Color CustomColor3
		{
			get
			{
				if (GettingDefault)
				{
					return m_CustomColor3;
				}
				if (m_CustomColor3 == Color.Empty && AmbientOwner != null)
				{
					return AmbientOwner.CustomColor3;
				}
				return m_CustomColor3;
			}
			set
			{
				PropertyUpdateDefault("CustomColor3", value);
				if (CustomColor3 != value)
				{
					m_CustomColor3 = value;
					DoPropertyChange(this, "CustomColor3");
				}
			}
		}

		protected Color Color
		{
			get
			{
				if (GettingDefault)
				{
					return m_Color;
				}
				if (m_Color == Color.Empty && AmbientOwner != null)
				{
					if (ColorAmbientSource == AmbientColorSouce.Color)
					{
						return AmbientOwner.Color;
					}
					if (ColorAmbientSource == AmbientColorSouce.ForeColor)
					{
						return AmbientOwner.ForeColor;
					}
					if (ColorAmbientSource == AmbientColorSouce.BackColor)
					{
						return AmbientOwner.BackColor;
					}
					if (ColorAmbientSource == AmbientColorSouce.CustomColor1)
					{
						return AmbientOwner.CustomColor1;
					}
					if (ColorAmbientSource == AmbientColorSouce.CustomColor2)
					{
						return AmbientOwner.CustomColor2;
					}
					if (ColorAmbientSource == AmbientColorSouce.CustomColor3)
					{
						return AmbientOwner.CustomColor3;
					}
				}
				return m_Color;
			}
			set
			{
				PropertyUpdateDefault("Color", value);
				if (Color != value)
				{
					m_Color = value;
					DoPropertyChange(this, "Color");
				}
			}
		}

		protected AmbientColorSouce ColorAmbientSource
		{
			get
			{
				return m_ColorAmbientSource;
			}
			set
			{
				m_ColorAmbientSource = value;
			}
		}

		protected bool FreezePropertyChange
		{
			get
			{
				return m_FreezePropertyChange;
			}
			set
			{
				m_FreezePropertyChange = value;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rectangle Bounds
		{
			get
			{
				return m_Bounds;
			}
			set
			{
				if (m_Bounds != value)
				{
					m_Bounds = value;
					OnBoundsChanged(m_Bounds);
				}
			}
		}

		protected bool Focused
		{
			get
			{
				if (UICollection == null)
				{
					return false;
				}
				return UICollection.GetIsFocused(this);
			}
		}

		protected Cursor Cursor
		{
			get
			{
				if (UICollection == null)
				{
					return Cursors.Default;
				}
				return UICollection.Cursor;
			}
		}

		protected UIInputCollection UICollection
		{
			get
			{
				return m_UICollection;
			}
			set
			{
				m_UICollection = value;
			}
		}

		protected bool IsMouseDown
		{
			get
			{
				return m_IsMouseDown;
			}
			set
			{
				m_IsMouseDown = value;
			}
		}

		protected bool IsMouseActive
		{
			get
			{
				return m_IsMouseActive;
			}
			set
			{
				m_IsMouseActive = value;
			}
		}

		protected bool IsKeyDown
		{
			get
			{
				return m_IsKeyDown;
			}
			set
			{
				m_IsKeyDown = value;
			}
		}

		protected bool IsKeyActive
		{
			get
			{
				return m_IsKeyActive;
			}
			set
			{
				m_IsKeyActive = value;
			}
		}

		protected bool IsMouseOrKeyActive
		{
			get
			{
				if (!m_IsMouseActive)
				{
					return m_IsKeyActive;
				}
				return true;
			}
		}

		protected virtual bool HitTestEnabled => true;

		protected virtual bool CanFocusInternal => true;

		protected SubClassBaseCollection SubClassList => m_SubClassList;

		[Browsable(false)]
		public event PropertyChangeEventHandler PropertyChanged;

		[Browsable(false)]
		public event BoundsChangeEventHandler BoundsChanged;

		public event GetMouseCursorEventHandler GetMouseCursor;

		public event MouseEventHandler MouseLeft;

		public event MouseEventHandler MouseRight;

		public event MouseEventHandler MouseMove;

		public event MouseEventHandler MouseUp;

		public event MouseEventHandler Click;

		public event MouseEventHandler DoubleClick;

		public event MouseEventHandler MouseWheel;

		public event KeyEventHandler KeyDown;

		public event KeyEventHandler KeyUp;

		public event KeyPressEventHandler KeyPress;

		public event EventHandler LostFocus;

		public event EventHandler GotFocus;

		string ISupportUITypeEditor.GetPlugInTitle()
		{
			return GetPlugInTitle();
		}

		string ISupportUITypeEditor.GetPlugInClassName()
		{
			return GetPlugInClassName();
		}

		void ISubClassBase.ResetToDefault()
		{
			ResetToDefault();
		}

		void ISubClassBase.ResetClone(ISubClassBase clone)
		{
			ResetClone(clone);
		}

		bool ISubClassBase.ShouldSerialize()
		{
			return ShouldSerialize();
		}

		bool IUIInput.HitTest(MouseEventArgs e)
		{
			return InternalHitTest(e);
		}

		void IUIInput.MouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			InternalOnMouseLeft(e, shouldFocus);
			OnMouseLeft(e);
		}

		void IUIInput.MouseRight(MouseEventArgs e)
		{
			InternalOnMouseRight(e);
			OnMouseRight(e);
		}

		void IUIInput.MouseMove(MouseEventArgs e)
		{
			InternalOnMouseMove(e);
			OnMouseMove(e);
		}

		void IUIInput.MouseUp(MouseEventArgs e)
		{
			InternalOnMouseUp(e);
			OnMouseUp(e);
		}

		void IUIInput.Click(MouseEventArgs e)
		{
			InternalOnClick(e);
			OnClick(e);
		}

		void IUIInput.DoubleClick(MouseEventArgs e)
		{
			InternalOnDoubleClick(e);
			OnDoubleClick(e);
		}

		void IUIInput.MouseWheel(MouseEventArgs e)
		{
			InternalOnMouseWheel(e);
			OnMouseWheel(e);
		}

		void IUIInput.KeyDown(KeyEventArgs e)
		{
			InternalOnKeyDown(e);
			OnKeyDown(e);
		}

		void IUIInput.KeyUp(KeyEventArgs e)
		{
			InternalOnKeyUp(e);
			OnKeyUp(e);
		}

		void IUIInput.KeyPress(KeyPressEventArgs e)
		{
			InternalOnKeyPress(e);
			OnKeyPress(e);
		}

		void IUIInput.LostFocus(LostFocusEventArgs e)
		{
			InternalOnLostFocus(e);
			OnLostFocus(e);
		}

		void IUIInput.GotFocus(EventArgs e)
		{
			InternalOnGotFocus(e);
			OnGotFocus(e);
		}

		Cursor IUIInput.GetMouseCursor(MouseEventArgs e)
		{
			Cursor cursor = InternalGetMouseCursor(e);
			if (this.GetMouseCursor != null)
			{
				GetMouseCursorEventArgs getMouseCursorEventArgs = new GetMouseCursorEventArgs(cursor);
				this.GetMouseCursor(this, getMouseCursorEventArgs);
				return getMouseCursorEventArgs.Cursor;
			}
			return cursor;
		}

		private void OnMouseLeft(MouseEventArgs e)
		{
			if (this.MouseLeft != null)
			{
				this.MouseLeft(this, e);
			}
		}

		private void OnMouseRight(MouseEventArgs e)
		{
			if (this.MouseRight != null)
			{
				this.MouseRight(this, e);
			}
		}

		private void OnMouseMove(MouseEventArgs e)
		{
			if (this.MouseMove != null)
			{
				this.MouseMove(this, e);
			}
		}

		private void OnMouseUp(MouseEventArgs e)
		{
			if (this.MouseUp != null)
			{
				this.MouseUp(this, e);
			}
		}

		private void OnClick(MouseEventArgs e)
		{
			if (this.Click != null)
			{
				this.Click(this, e);
			}
		}

		private void OnDoubleClick(MouseEventArgs e)
		{
			if (this.DoubleClick != null)
			{
				this.DoubleClick(this, e);
			}
		}

		private void OnMouseWheel(MouseEventArgs e)
		{
			if (this.MouseWheel != null)
			{
				this.MouseWheel(this, e);
			}
		}

		private void OnKeyDown(KeyEventArgs e)
		{
			if (this.KeyDown != null)
			{
				this.KeyDown(this, e);
			}
		}

		private void OnKeyUp(KeyEventArgs e)
		{
			if (this.KeyUp != null)
			{
				this.KeyUp(this, e);
			}
		}

		private void OnKeyPress(KeyPressEventArgs e)
		{
			if (this.KeyPress != null)
			{
				this.KeyPress(this, e);
			}
		}

		private void OnLostFocus(EventArgs e)
		{
			if (this.LostFocus != null)
			{
				this.LostFocus(this, e);
			}
		}

		private void OnGotFocus(EventArgs e)
		{
			if (this.GotFocus != null)
			{
				this.GotFocus(this, e);
			}
		}

		protected void DoCreate()
		{
			if (!m_CreationComplete)
			{
				ColorAmbientSource = AmbientColorSouce.Color;
				m_Creating = true;
				try
				{
					CreateObjects();
				}
				finally
				{
					m_Creating = false;
				}
				SettingDefaults = true;
				try
				{
					SetDefaults();
				}
				finally
				{
					SettingDefaults = false;
				}
				AfterCreate();
				m_CreationComplete = true;
			}
		}

		protected virtual void CreateObjects()
		{
		}

		protected virtual void SetDefaults()
		{
			VisibleInternal = true;
			EnabledInternal = true;
		}

		protected virtual void AfterCreate()
		{
		}

		protected void AddSubClass(ISubClassBase value)
		{
			if (m_SubClassList == null)
			{
				m_SubClassList = new SubClassBaseCollection();
			}
			m_SubClassList.Add(value);
			value.AmbientOwner = this;
		}

		protected void RemoveSubClass(ISubClassBase value)
		{
			if (m_SubClassList == null)
			{
				m_SubClassList = new SubClassBaseCollection();
			}
			m_SubClassList.Remove(value);
			value.AmbientOwner = null;
		}

		protected void PropertyUpdateDefault(string name, object value)
		{
			bool flag = SettingDefaults;
			if (Creating)
			{
				flag = true;
			}
			if (ComponentBase != null && ComponentBase.SettingDefaults)
			{
				flag = true;
			}
			if (flag)
			{
				if (m_DefaultArray == null)
				{
					m_DefaultArray = new ArrayList();
				}
				foreach (PropertyData item in m_DefaultArray)
				{
					if (item.Name == name)
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

		protected bool ShouldSerialize()
		{
			bool result = false;
			if (m_DefaultArray != null)
			{
				foreach (PropertyData item in m_DefaultArray)
				{
					if (PropertyShouldSerialize(item.Name))
					{
						result = true;
					}
				}
			}
			if (m_SubClassList != null)
			{
				{
					foreach (SubClassBase subClass in m_SubClassList)
					{
						if (((ISubClassBase)subClass).ShouldSerialize())
						{
							return true;
						}
					}
					return result;
				}
			}
			return result;
		}

		protected void ResetToDefault()
		{
			if (m_DefaultArray != null)
			{
				foreach (PropertyData item in m_DefaultArray)
				{
					PropertyInfo property = base.GetType().GetProperty(item.Name);
					if (property != (PropertyInfo)null)
					{
						property.SetValue(this, item.Value, null);
					}
				}
			}
			if (m_SubClassList != null)
			{
				foreach (SubClassBase subClass in m_SubClassList)
				{
					((ISubClassBase)subClass).ResetToDefault();
				}
			}
			if (ComponentBase != null)
			{
				ComponentBase.ForceDesignerChange();
			}
		}

		protected void ResetClone(ISubClassBase clone)
		{
			if (m_DefaultArray != null)
			{
				foreach (PropertyData item in m_DefaultArray)
				{
					PropertyInfo property = clone.GetType().GetProperty(item.Name);
					if (property != (PropertyInfo)null)
					{
						property.SetValue(clone, item.Value, null);
					}
				}
			}
			if (m_SubClassList != null)
			{
				for (int i = 0; i < m_SubClassList.Count; i++)
				{
					ISubClassBase subClassBase = m_SubClassList[i];
					ISubClassBase clone2 = clone.SubClassList[i];
					subClassBase.ResetClone(clone2);
				}
			}
		}

		protected void PropertyReset(string name)
		{
			if (m_DefaultArray != null)
			{
				foreach (PropertyData item in m_DefaultArray)
				{
					if (item.Name == name)
					{
						PropertyInfo property = base.GetType().GetProperty(name);
						if (property != (PropertyInfo)null)
						{
							property.SetValue(this, item.Value, null);
						}
						if (ComponentBase != null)
						{
							ComponentBase.ForceDesignerChange();
						}
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
					if (item.Name == name)
					{
						PropertyInfo property = base.GetType().GetProperty(name);
						if (!(property == (PropertyInfo)null))
						{
							if (item.Value == null)
							{
								return property.GetValue(this, null) != null;
							}
							return !item.Value.Equals(property.GetValue(this, null));
						}
					}
				}
				return false;
			}
			finally
			{
				m_GettingDefault = false;
			}
		}

		protected void ThrowStreamingSafeException(string value)
		{
			if (ComponentBase != null)
			{
				if (ComponentBase.Loading)
				{
					return;
				}
				throw new Exception(value);
			}
			throw new Exception(value);
		}

		protected bool NeedToSquashEvent()
		{
			if (FreezePropertyChange)
			{
				return true;
			}
			if (ComponentBase != null && ComponentBase.Creating)
			{
				return true;
			}
			return false;
		}

		protected void DoAutoSizeSpecialOffset(int specialOffset)
		{
			if (ControlBase != null)
			{
				ControlBase.DoAutoSizeSpecialOffset(specialOffset);
			}
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
			if (!NeedToSquashEvent())
			{
				if (ComponentBase != null)
				{
					ComponentBase.DoPropertyChange(sender, propertyName);
				}
				if (this.PropertyChanged != null)
				{
					OnPropertyChanged(sender, propertyName);
				}
			}
		}

		protected virtual string GetPlugInTitle()
		{
			return Const.EmptyString;
		}

		protected virtual string GetPlugInClassName()
		{
			return Const.EmptyString;
		}

		public void ShowEditorCustom(bool designTimeStyle, bool modal)
		{
			UITypeEditorGeneric uITypeEditorGeneric = (UITypeEditorGeneric)TypeDescriptor.GetEditor(this, typeof(UITypeEditor));
			uITypeEditorGeneric?.EditValue(this, designTimeStyle, modal);
		}

		protected virtual void OnBoundsChanged(Rectangle r)
		{
			if (this.BoundsChanged != null)
			{
				this.BoundsChanged(this, new BoundsEventArgs(r));
			}
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

		public void Focus()
		{
			if (CanFocusInternal && UICollection != null)
			{
				UICollection.SetFocus(this);
			}
		}

		protected virtual bool InternalHitTest(MouseEventArgs e)
		{
			if (!HitTestEnabled)
			{
				return false;
			}
			return Bounds.Contains(e.X, e.Y);
		}

		protected virtual Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			return Cursors.Default;
		}

		protected virtual void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
		}

		protected virtual void InternalOnMouseRight(MouseEventArgs e)
		{
		}

		protected virtual void InternalOnMouseMove(MouseEventArgs e)
		{
		}

		protected virtual void InternalOnMouseUp(MouseEventArgs e)
		{
		}

		protected virtual void InternalOnClick(EventArgs e)
		{
		}

		protected virtual void InternalOnDoubleClick(MouseEventArgs e)
		{
		}

		protected virtual void InternalOnMouseWheel(MouseEventArgs e)
		{
		}

		protected virtual void InternalOnKeyDown(KeyEventArgs e)
		{
		}

		protected virtual void InternalOnKeyUp(KeyEventArgs e)
		{
		}

		protected virtual void InternalOnKeyPress(KeyPressEventArgs e)
		{
		}

		protected virtual void InternalOnLostFocus(LostFocusEventArgs e)
		{
		}

		protected virtual void InternalOnGotFocus(EventArgs e)
		{
		}
	}
}
