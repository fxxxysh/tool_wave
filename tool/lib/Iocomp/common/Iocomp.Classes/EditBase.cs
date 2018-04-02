using Iocomp.Design;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Iocomp's ancestor class for all edit controls.")]
	[DesignerCategory("code")]
	[DesignerSerializer(typeof(LoadBeginEndSerializerEditBase), typeof(CodeDomSerializer))]
	[Editor(typeof(UITypeEditorGeneric), typeof(UITypeEditor))]
	[ToolboxItem(false)]
	public abstract class EditBase : TextBox, IControlBase, IComponentBase, IAmbientOwner, IPropertyDefaults, ISupportUITypeEditor
	{
		protected License m_License;

		private ArrayList m_DefaultArray;

		private bool m_GettingDefault;

		private bool m_Loading;

		private bool m_Creating;

		private bool m_SettingDefaults;

		private bool m_UserGenerated;

		private bool m_OPCUpdateActive;

		private bool m_UpdateOnLostFocus;

		private SubClassBaseCollection m_SubClassList;

		private bool m_DefaultReadBack;

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
				return Color.Empty;
			}
		}

		Color IAmbientOwner.CustomColor1
		{
			get
			{
				return Color.Empty;
			}
		}

		Color IAmbientOwner.CustomColor2
		{
			get
			{
				return Color.Empty;
			}
		}

		Color IAmbientOwner.CustomColor3
		{
			get
			{
				return Color.Empty;
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

		bool IControlBase.FreezeAutoSize
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		Control IControlBase.Control
		{
			get
			{
				return this;
			}
		}

		Control IControlBase._Parent
		{
			get
			{
				return base.Parent;
			}
		}

		protected override Size DefaultSize => GetDefaultSize();

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[DefaultValue(HorizontalAlignment.Center)]
		public new Size Size
		{
			get
			{
				return base.Size;
			}
			set
			{
				base.Size = value;
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

		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(HorizontalAlignment.Center)]
		[Description("")]
		public new HorizontalAlignment TextAlign
		{
			get
			{
				return base.TextAlign;
			}
			set
			{
				base.TextAlign = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[RefreshProperties(RefreshProperties.All)]
		public new Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				if (!GPFunctions.Equals(base.Font, value))
				{
					base.Font = value;
					DoPropertyChange(this, "Font");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				if (base.ForeColor != value)
				{
					base.ForeColor = value;
				}
			}
		}

		[Browsable(false)]
		[RefreshProperties(RefreshProperties.All)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				if (base.BackColor != value)
				{
					base.BackColor = value;
				}
			}
		}

		[Category("Iocomp")]
		[DefaultValue(true)]
		[Description("determines if the value is updated when the control looses focus.")]
		[RefreshProperties(RefreshProperties.All)]
		public bool UpdateOnLostFocus
		{
			get
			{
				return m_UpdateOnLostFocus;
			}
			set
			{
				PropertyUpdateDefault("UpdateOnLostFocus", value);
				if (UpdateOnLostFocus != value)
				{
					m_UpdateOnLostFocus = value;
					DoPropertyChange(this, "UpdateOnLostFocus");
				}
			}
		}

		[Browsable(false)]
		public EventSource EventSource
		{
			get
			{
				if (m_UserGenerated)
				{
					return EventSource.User;
				}
				if (m_OPCUpdateActive)
				{
					return EventSource.Opc;
				}
				return EventSource.Code;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool OPCUpdateActive
		{
			get
			{
				return m_OPCUpdateActive;
			}
			set
			{
				m_OPCUpdateActive = value;
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
		public bool SettingDefaults
		{
			get
			{
				return m_SettingDefaults;
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
		public bool UserGenerated
		{
			get
			{
				return m_UserGenerated;
			}
		}

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
		}

		void IControlBase.DoAutoSize()
		{
			DoAutoSize();
		}

		void IControlBase.DoAutoSizeSpecialOffset(int specialOffset)
		{
			DoAutoSizeSpecialOffset(specialOffset);
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
				TextAlign = HorizontalAlignment.Center;
				base.WordWrap = false;
				UpdateOnLostFocus = true;
				CreateObjects();
			}
			finally
			{
				m_Creating = false;
			}
			m_SettingDefaults = true;
			try
			{
				SetDefaults();
			}
			finally
			{
				m_SettingDefaults = false;
			}
			UpdateText();
		}

		protected virtual Size GetDefaultSize()
		{
			return new Size(50, 50);
		}

		protected override void Dispose(bool disposing)
		{
			if (m_License != null)
			{
				m_License.Dispose();
				m_License = null;
			}
			base.Dispose(disposing);
		}

		protected virtual void CreateObjects()
		{
		}

		protected virtual void Loaded()
		{
		}

		protected virtual void SetDefaults()
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

		private void ResetSize()
		{
			Size = DefaultSize;
		}

		protected void AddSubClass(ISubClassBase value)
		{
			if (m_SubClassList == null)
			{
				m_SubClassList = new SubClassBaseCollection();
			}
			m_SubClassList.Add(value);
			value.ControlBase = this;
			value.ComponentBase = this;
			value.AmbientOwner = this;
		}

		private bool ShouldSerializeUpdateOnLostFocus()
		{
			return PropertyShouldSerialize("UpdateOnLostFocus");
		}

		private void ResetUpdateOnLostFocus()
		{
			PropertyReset("UpdateOnLostFocus");
		}

		protected abstract void UpdateText();

		protected abstract void UpdateValue();

		protected void TextRelatedPropertyChangedHandler(object sender, string propertyName)
		{
			UpdateText();
		}

		protected void DoPropertyChange(object sender, string propertyName)
		{
			if (!Creating && !SettingDefaults)
			{
				PropertyChangedHook(sender, propertyName);
			}
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

		protected virtual void PropertyChangedHook(object sender, string propertyName)
		{
		}

		protected void DoAutoSize()
		{
		}

		protected void DoAutoSizeSpecialOffset(int specialOffset)
		{
		}

		protected void ForceDesignerChange()
		{
			IComponentChangeService componentChangeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
			componentChangeService?.OnComponentChanged(this, null, null, null);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			if (UpdateOnLostFocus)
			{
				UpdateValue();
			}
		}

		public void LoadingBegin()
		{
			m_Loading = true;
		}

		public void LoadingEnd()
		{
			m_Loading = false;
			Loaded();
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

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			try
			{
				m_UserGenerated = true;
				InternalOnKeyDown(e);
			}
			finally
			{
				m_UserGenerated = false;
			}
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			try
			{
				m_UserGenerated = true;
				InternalOnKeyUp(e);
			}
			finally
			{
				m_UserGenerated = false;
			}
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			try
			{
				m_UserGenerated = true;
				InternalOnKeyPress(e);
			}
			finally
			{
				m_UserGenerated = false;
			}
		}

		public void ShowEditorCustom(bool designTimeStyle, bool modal)
		{
			UITypeEditorGeneric uITypeEditorGeneric = (UITypeEditorGeneric)TypeDescriptor.GetEditor(this, typeof(UITypeEditor));
			uITypeEditorGeneric?.EditValue(this, designTimeStyle, modal);
		}

		bool IControlBase.Focus()
		{
			return base.Focus();
		}
	}
}
