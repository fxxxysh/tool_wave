using Iocomp.Delegates;
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
using System.Drawing.Imaging;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Serializable]
	[Description("Iocomp's ancestor class for all controls.")]
	[DesignerCategory("code")]
	[DesignerSerializer(typeof(LoadBeginEndSerializerControlBase), typeof(CodeDomSerializer))]
	[Editor(typeof(UITypeEditorGeneric), typeof(UITypeEditor))]
	public abstract class DesignControlBase : Control, IControlBase, IComponentBase, IPropertyDefaults, ISupportUITypeEditor
	{
		protected License m_License;

		private bool m_Loading;

		private bool m_Creating;

		private bool m_SettingDefaults;

		private bool m_AutoSizing;

		private bool m_ManualSizeFixing;

		private bool m_AfterCreating;

		private bool m_MouseDown;

		private bool m_KeyDown;

		private int m_MouseDownX;

		private int m_MouseDownY;

		private MouseEventArgs m_LastMouseDownEventArgs;

		private BorderControl m_Border;

		private bool m_GettingDefault;

		private bool m_DefaultReadBack;

		private ArrayList m_DefaultArray;

		private RotationQuad m_Rotation;

		private bool m_Rotating;

		private bool m_SettingBoundsCore;

		private bool m_AutoSize;

		private Color m_BackColor;

		private Color m_ForeColor;

		private bool m_SnapShotTransparent;

		private SubClassBaseCollection m_SubClassList;

		private bool m_FreezeAutoSize;

		private int m_FreezeAutoSizeOffsetTotal;

		bool IControlBase.FreezeAutoSize
		{
			get
			{
				return FreezeAutoSize;
			}
			set
			{
				FreezeAutoSize = value;
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

		protected override Size DefaultSize => GetDefaultSize();

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
		public bool AutoSizing
		{
			get
			{
				return m_AutoSizing;
			}
		}

		protected bool ManualSizeFixing => m_ManualSizeFixing;

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

		[Browsable(false)]
		public bool SettingDefaults
		{
			get
			{
				return m_SettingDefaults;
			}
		}

		[Browsable(false)]
		public bool Rotating
		{
			get
			{
				return m_Rotating;
			}
		}

		[Browsable(false)]
		[Category("Iocomp")]
		public EventSource EventSource
		{
			get
			{
				return EventSource.Code;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool OPCUpdateActive
		{
			get
			{
				return false;
			}
			set
			{
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

		protected bool FreezeAutoSize
		{
			get
			{
				return m_FreezeAutoSize;
			}
			set
			{
				m_Loading = value;
				if (m_FreezeAutoSize != value)
				{
					m_FreezeAutoSize = value;
					if (m_FreezeAutoSize)
					{
						m_FreezeAutoSizeOffsetTotal = 0;
					}
					else
					{
						DoAutoSize(m_FreezeAutoSizeOffsetTotal);
					}
				}
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		protected int InnerOffset => Border.Offset + SpecialOffset;

		[Category("Iocomp")]
		[Description("Specifies the rotation of the title and bevel.")]
		[RefreshProperties(RefreshProperties.All)]
		public RotationQuad Rotation
		{
			get
			{
				return m_Rotation;
			}
			set
			{
				PropertyUpdateDefault("Rotation", value);
				if (m_Rotation != value)
				{
					m_Rotating = true;
					try
					{
						RotationQuad rotation = m_Rotation;
						m_Rotation = value;
						if (!Loading && !Creating && NeedsSizeSwap(rotation))
						{
							Size = new Size(base.Height, base.Width);
						}
						DoPropertyChange(this, "Rotation");
					}
					finally
					{
						m_Rotating = false;
					}
				}
			}
		}

		[Description("Determines if the control will adjust its size or orientation in response to specific properties change.")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public new bool AutoSize
		{
			get
			{
				return m_AutoSize;
			}
			set
			{
				PropertyUpdateDefault("AutoSize", value);
				if (m_AutoSize != value)
				{
					m_AutoSize = value;
					if (m_AutoSize)
					{
						DoAutoSize();
					}
					DoPropertyChange(this, "AutoSize");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
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
		public new Color ForeColor
		{
			get
			{
				if (GettingDefault)
				{
					return m_ForeColor;
				}
				if (m_ForeColor == Color.Empty && base.Parent != null)
				{
					return base.Parent.ForeColor;
				}
				return m_ForeColor;
			}
			set
			{
				PropertyUpdateDefault("ForeColor", value);
				if (ForeColor != value)
				{
					base.ForeColor = value;
					m_ForeColor = value;
					DoPropertyChange(this, "ForeColor");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		public new Color BackColor
		{
			get
			{
				if (GettingDefault)
				{
					return m_BackColor;
				}
				if (m_BackColor == Color.Empty && base.Parent != null)
				{
					return base.Parent.BackColor;
				}
				return m_BackColor;
			}
			set
			{
				PropertyUpdateDefault("BackColor", value);
				if (BackColor != value)
				{
					base.BackColor = value;
					m_BackColor = value;
					DoPropertyChange(this, "BackColor");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public BorderControl Border
		{
			get
			{
				return m_Border;
			}
		}

		protected Rectangle InnerRectangle
		{
			get
			{
				Rectangle clientRectangle = base.ClientRectangle;
				clientRectangle.Inflate(-InnerOffset, -InnerOffset);
				return clientRectangle;
			}
		}

		[Browsable(false)]
		public Image SnapShot
		{
			get
			{
				Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
				Bitmap bitmap = new Bitmap(base.Width, base.Height, PixelFormat.Format32bppArgb);
				Graphics graphics = Graphics.FromImage(bitmap);
				PaintEventArgs paintEventArgs = new PaintEventArgs(graphics, rectangle);
				if (!SnapShotTransparent)
				{
					Brush brush = new SolidBrush(BackColor);
					paintEventArgs.Graphics.FillRectangle(brush, rectangle);
					brush.Dispose();
				}
				OnPaint(paintEventArgs);
				graphics.Dispose();
				return bitmap;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		public bool SnapShotTransparent
		{
			get
			{
				return m_SnapShotTransparent;
			}
			set
			{
				PropertyUpdateDefault("SnapShotTransparent", value);
				if (SnapShotTransparent != value)
				{
					m_SnapShotTransparent = value;
					DoPropertyChange(this, "SnapShotTransparent");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		protected bool IsMouseDown
		{
			get
			{
				return m_MouseDown;
			}
			set
			{
				if (m_MouseDown != value)
				{
					m_MouseDown = value;
					m_KeyDown = false;
					UIInvalidate(this);
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		protected bool IsKeyDown
		{
			get
			{
				return m_KeyDown;
			}
			set
			{
				if (m_KeyDown != value)
				{
					m_KeyDown = value;
					m_MouseDown = false;
					UIInvalidate(this);
				}
			}
		}

		protected bool IsDown
		{
			get
			{
				if (!m_KeyDown)
				{
					return m_MouseDown;
				}
				return true;
			}
		}

		protected int MouseDownX
		{
			get
			{
				return m_MouseDownX;
			}
			set
			{
				if (m_MouseDownX != value)
				{
					m_MouseDownX = value;
					UIInvalidate(this);
				}
			}
		}

		protected int MouseDownY
		{
			get
			{
				return m_MouseDownY;
			}
			set
			{
				if (m_MouseDownY != value)
				{
					m_MouseDownY = value;
					UIInvalidate(this);
				}
			}
		}

		protected virtual int SpecialOffset => 0;

		[Browsable(false)]
		public event PropertyChangeEventHandler PropertyChanged;

		string ISupportUITypeEditor.GetPlugInTitle()
		{
			return GetPlugInTitle();
		}

		string ISupportUITypeEditor.GetPlugInClassName()
		{
			return GetPlugInClassName();
		}

		void IComponentBase.ForceDesignerChange()
		{
			ForceDesignerChange();
		}

		void IComponentBase.SetComponentDefaults()
		{
			SetComponentDefaults();
		}

		void IControlBase.DoAutoSize()
		{
			DoAutoSize(0);
		}

		void IControlBase.DoAutoSizeSpecialOffset(int specialOffset)
		{
			DoAutoSize(specialOffset);
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
				AutoSize = true;
				base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
				ModifyStyle();
				base.UpdateStyles();
				m_Border = new BorderControl();
				AddSubClass(Border);
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
					foreach (ISubClassBase subClass in m_SubClassList)
					{
						subClass.SettingDefaults = true;
					}
				}
				SetDefaults();
				Size = GetDefaultSize();
				if (m_SubClassList != null)
				{
					foreach (ISubClassBase subClass2 in m_SubClassList)
					{
						subClass2.SettingDefaults = false;
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
			Rotation = RotationQuad.X000;
			Border.Style = BorderStyleControl.None;
			Border.Margin = 0;
			Border.ThicknessDesired = 2;
			Border.Color = Color.Empty;
			BackColor = Color.Empty;
			ForeColor = Color.Empty;
			AutoSize = true;
			SnapShotTransparent = false;
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

		private bool ShouldSerializeSecondHandColor()
		{
			return PropertyShouldSerialize("SecondHandColor");
		}

		private void ResetSecondHandColor()
		{
			PropertyReset("SecondHandColor");
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
		}

		protected virtual bool NeedsSizeSwap(RotationQuad value)
		{
			if (value == m_Rotation)
			{
				return false;
			}
			bool flag = m_Rotation == RotationQuad.X000 || m_Rotation == RotationQuad.X180;
			bool flag2 = value == RotationQuad.X000 || value == RotationQuad.X180;
			return flag != flag2;
		}

		protected bool NeedsSizeSwap()
		{
			if (Rotation == RotationQuad.X090)
			{
				return true;
			}
			if (Rotation == RotationQuad.X270)
			{
				return true;
			}
			return false;
		}

		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			bool flag = NeedsSizeSwap();
			m_SettingBoundsCore = true;
			try
			{
				if (flag)
				{
					InternalSetBoundsCore(x, y, height, width, specified);
				}
				else
				{
					InternalSetBoundsCore(x, y, width, height, specified);
				}
				if (!AutoSizing && !Loading)
				{
					if (flag)
					{
						ManualSizeFixupInternal(height - 2 * InnerOffset, width - 2 * InnerOffset);
					}
					else
					{
						ManualSizeFixupInternal(width - 2 * InnerOffset, height - 2 * InnerOffset);
					}
				}
			}
			finally
			{
				m_SettingBoundsCore = false;
			}
		}

		protected virtual void InternalSetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			if (NeedsSizeSwap())
			{
				base.SetBoundsCore(x, y, height, width, specified);
			}
			else
			{
				base.SetBoundsCore(x, y, width, height, specified);
			}
		}

		private void ManualSizeFixupInternal(int innerWidth, int innerHeight)
		{
			m_ManualSizeFixing = true;
			ManualSizeFixup(innerWidth, innerHeight);
			m_ManualSizeFixing = false;
		}

		protected virtual void ManualSizeFixup(int innerWidth, int innerHeight)
		{
		}

		protected virtual Size CalculateAutoSize(int innerWidth, int innerHeight)
		{
			return Size.Empty;
		}

		protected virtual Point CalculateAutoSizeLocation(Size newSize)
		{
			return new Point(0, 0);
		}

		protected void DoAutoSize()
		{
			DoAutoSize(0);
		}

		protected void DoAutoSize(object sender, string propertyName)
		{
			DoAutoSize(0);
		}

		protected void DoAutoSizeSpecialOffset(int specialOffset)
		{
			DoAutoSize(specialOffset);
		}

		protected virtual void DoAutoSize(int specialOffset)
		{
			if (!Loading && !Creating && !AfterCreating && !SettingDefaults)
			{
				if (FreezeAutoSize)
				{
					m_FreezeAutoSizeOffsetTotal += specialOffset;
				}
				else
				{
					bool flag = NeedsSizeSwap();
					if (!AutoSize)
					{
						if (flag)
						{
							ManualSizeFixupInternal(base.Height - 2 * InnerOffset, base.Width - 2 * InnerOffset);
						}
						else
						{
							ManualSizeFixupInternal(base.Width - 2 * InnerOffset, base.Height - 2 * InnerOffset);
						}
					}
					else if (!m_SettingBoundsCore && !AutoSizing)
					{
						m_AutoSizing = true;
						try
						{
							int num;
							int num2;
							if (flag)
							{
								num = base.Height - 2 * InnerOffset;
								num2 = base.Width - 2 * InnerOffset;
							}
							else
							{
								num = base.Width - 2 * InnerOffset;
								num2 = base.Height - 2 * InnerOffset;
							}
							Size size = CalculateAutoSize(num, num2);
							num = ((size.Width != 0) ? (size.Width + 2 * InnerOffset) : (num + 2 * InnerOffset + 2 * specialOffset));
							num2 = ((size.Height != 0) ? (size.Height + 2 * InnerOffset) : (num2 + 2 * InnerOffset + 2 * specialOffset));
							size = ((!flag) ? new Size(num, num2) : new Size(num2, num));
							Point location = CalculateAutoSizeLocation(size);
							Size = size;
							if (!location.IsEmpty)
							{
								base.Location = location;
							}
						}
						finally
						{
							m_AutoSizing = false;
						}
						ForceDesignerChange();
					}
				}
			}
		}

		private bool ShouldSerializeRotation()
		{
			return PropertyShouldSerialize("Rotation");
		}

		private void ResetRotation()
		{
			PropertyReset("Rotation");
		}

		private bool ShouldSerializeAutoSize()
		{
			return PropertyShouldSerialize("AutoSize");
		}

		private void ResetAutoSize()
		{
			PropertyReset("AutoSize");
		}

		private void ResetSize()
		{
			if (NeedsSizeSwap(RotationQuad.X000))
			{
				Size = new Size(DefaultSize.Height, DefaultSize.Width);
			}
			else
			{
				Size = DefaultSize;
			}
		}

		protected override void OnParentFontChanged(EventArgs e)
		{
			base.OnParentFontChanged(e);
			DoPropertyChange(this, "Font");
		}

		public bool ShouldSerializeForeColor()
		{
			return PropertyShouldSerialize("ForeColor");
		}

		public override void ResetForeColor()
		{
			PropertyReset("ForeColor");
		}

		public bool ShouldSerializeBackColor()
		{
			return PropertyShouldSerialize("BackColor");
		}

		public override void ResetBackColor()
		{
			PropertyReset("BackColor");
		}

		private bool ShouldSerializeBorder()
		{
			return ((ISubClassBase)Border).ShouldSerialize();
		}

		private void ResetBorder()
		{
			((ISubClassBase)Border).ResetToDefault();
		}

		private bool ShouldSerializeSnapShotTransparent()
		{
			return PropertyShouldSerialize("SnapShotTransparent");
		}

		private void ResetSnapShotTransparent()
		{
			PropertyReset("SnapShotTransparent");
		}

		protected void ForceDesignerChange()
		{
			IComponentChangeService componentChangeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
			componentChangeService?.OnComponentChanged(this, null, null, null);
			base.Invalidate();
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

		protected virtual void InternalOnMouseLeft(MouseEventArgs e)
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

		protected virtual void InternalOnDoubleClick(MouseEventArgs e)
		{
		}

		protected virtual void InternalOnMouseWheel(MouseEventArgs e)
		{
		}

		protected virtual void InternalOnLostFocus(EventArgs e)
		{
		}

		protected virtual void InternalOnGotFocus(EventArgs e)
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

		protected MouseEventArgs GetRotatedMouseEventArgs(MouseEventArgs e)
		{
			Point point = new Point(e.X, e.Y);
			Rectangle rectangle = InnerRectangle;
			rectangle = new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width - 1, rectangle.Height - 1);
			Point point2 = (Rotation != RotationQuad.X090) ? ((Rotation != RotationQuad.X180) ? ((Rotation != RotationQuad.X270) ? point : new Point(rectangle.Bottom - point.Y, point.X)) : new Point(rectangle.Right - point.X, rectangle.Bottom - point.Y)) : new Point(point.Y, rectangle.Right - point.X);
			return new MouseEventArgs(e.Button, e.Clicks, point2.X, point2.Y, e.Delta);
		}

		public MouseEventArgs GetInternalMouseEventArgs(MouseEventArgs e)
		{
			return GetRotatedMouseEventArgs(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			m_LastMouseDownEventArgs = e;
			if (e.Button == MouseButtons.Right)
			{
				e = GetRotatedMouseEventArgs(e);
				m_MouseDownX = e.X;
				m_MouseDownY = e.Y;
				InternalOnMouseRight(e);
			}
			else if (e.Button == MouseButtons.Left)
			{
				e = GetRotatedMouseEventArgs(e);
				m_MouseDownX = e.X;
				m_MouseDownY = e.Y;
				InternalOnMouseLeft(e);
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			e = GetRotatedMouseEventArgs(e);
			InternalOnMouseMove(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			e = GetRotatedMouseEventArgs(e);
			InternalOnMouseUp(e);
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			e = GetRotatedMouseEventArgs(e);
			InternalOnMouseWheel(e);
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick(e);
			InternalOnDoubleClick(m_LastMouseDownEventArgs);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			InternalOnKeyDown(e);
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			InternalOnKeyUp(e);
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			InternalOnKeyPress(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			m_MouseDown = false;
			m_KeyDown = false;
			UIInvalidate(this);
			InternalOnLostFocus(e);
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			UIInvalidate(this);
			InternalOnGotFocus(e);
		}

		protected virtual void DoPaint(PaintArgs p)
		{
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
				CodeInvalidate(this);
				if (this.PropertyChanged != null)
				{
					OnPropertyChanged(sender, propertyName);
				}
			}
		}

		public void InvalidateControl()
		{
			base.Invalidate();
		}

		[Browsable(false)]
		public void UIInvalidate(object sender)
		{
			InvalidateControl();
		}

		[Browsable(false)]
		public void CodeInvalidate(object sender)
		{
			InvalidateControl();
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

		protected override void OnPaint(PaintEventArgs p)
		{
			PaintAll(p);
			base.OnPaint(p);
		}

		protected void PaintAll(PaintEventArgs p)
		{
			Rectangle innerRectangle = InnerRectangle;
			PaintArgs paintArgs = new PaintArgs(p.Graphics, innerRectangle, BackColor);
			if (innerRectangle.Width != 0 && innerRectangle.Height != 0)
			{
				paintArgs.Rotate(Rotation);
				try
				{
					DoPaint(paintArgs);
				}
				catch (Exception ex)
				{
					Font font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular);
					p.Graphics.ResetClip();
					p.Graphics.FillRectangle(new SolidBrush(Color.White), base.ClientRectangle);
					p.Graphics.DrawString(ex.Message, font, new SolidBrush(Color.Black), base.ClientRectangle);
					if (ex.GetType().Name == "Exception")
					{
						throw new Exception(ex.Message);
					}
					if (!(ex.GetType().Name == "SystemException"))
					{
						goto end_IL_004a;
					}
					throw new SystemException(ex.Message);
					end_IL_004a:;
				}
			}
			p.Graphics.ResetTransform();
			p.Graphics.ResetClip();
			paintArgs.Rotation = RotationQuad.X000;
			((IBorderControl)m_Border).Draw(paintArgs, base.ClientRectangle);
			paintArgs.CleanUp();
		}

		bool IControlBase.Focus()
		{
			return base.Focus();
		}
	}
}
