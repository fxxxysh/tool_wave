using Iocomp.Delegates;
using Iocomp.Design;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(CollectionItemConverter))]
	[Description("Base Class for all Plot objects.")]
	public abstract class PlotObject : SubClassBase, IPlotObject, IPlotDraw
	{
		private string m_Name;

		private string m_TitleText;

		private int m_Layer;

		private bool m_UserCanEdit;

		private bool m_CanFocus;

		private bool m_ContextMenuEnabled;

		private Plot m_Plot;

		private Rectangle m_BoundsClip;

		private string m_NameShort;

		private bool m_CanDraw;

		bool IPlotDraw.CanDraw
		{
			get
			{
				return m_CanDraw;
			}
		}

		Plot IPlotObject.Plot
		{
			get
			{
				return Plot;
			}
			set
			{
				Plot = value;
			}
		}

		protected Plot Plot
		{
			get
			{
				return m_Plot;
			}
			set
			{
				m_Plot = value;
			}
		}

		protected bool CanDraw
		{
			get
			{
				return m_CanDraw;
			}
			set
			{
				m_CanDraw = value;
			}
		}

		protected string NameShort
		{
			get
			{
				return m_NameShort;
			}
			set
			{
				m_NameShort = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Browsable(false)]
		public Rectangle BoundsClip
		{
			get
			{
				return m_BoundsClip;
			}
			set
			{
				if (m_BoundsClip != value)
				{
					m_BoundsClip = value;
					OnBoundsClipChanged(m_BoundsClip);
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public virtual bool Visible
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool Enabled
		{
			get
			{
				return base.EnabledInternal;
			}
			set
			{
				base.EnabledInternal = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ContextMenuEnabled
		{
			get
			{
				return m_ContextMenuEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("ContextMenuEnabled", value);
				if (ContextMenuEnabled != value)
				{
					m_ContextMenuEnabled = value;
					base.DoPropertyChange(this, "ContextMenuEnabled");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string Name
		{
			get
			{
				if (m_Name == null)
				{
					m_Name = Const.EmptyString;
				}
				return m_Name;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("Name", value);
				if (Name != value)
				{
					string name = m_Name;
					m_Name = value;
					base.DoPropertyChange(this, "Name");
					if (base.Collection is IPlotObjectCollectionBase)
					{
						(base.Collection as IPlotObjectCollectionBase).HandleObjectRenamed(this, name);
					}
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public virtual string TitleText
		{
			get
			{
				if (m_TitleText == null)
				{
					m_TitleText = Const.EmptyString;
				}
				return m_TitleText;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				value = value.Trim();
				base.PropertyUpdateDefault("TitleText", value);
				if (TitleText != value)
				{
					m_TitleText = value;
					base.DoPropertyChange(this, "TitleText");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int Layer
		{
			get
			{
				return m_Layer;
			}
			set
			{
				base.PropertyUpdateDefault("Layer", value);
				if (Layer != value)
				{
					m_Layer = value;
					base.DoPropertyChange(this, "Layer");
				}
			}
		}

		[Browsable(false)]
		[Description("")]
		public double LayerWithSubLevel
		{
			get
			{
				if (this is PlotDataView)
				{
					return (double)Layer + 0.0;
				}
				if (this is PlotAxis)
				{
					return (double)Layer + 0.01;
				}
				if (this is PlotLimitBase)
				{
					return (double)Layer + 0.02;
				}
				if (this is PlotChannelBase)
				{
					return (double)Layer + 0.03;
				}
				if (this is PlotAnnotationBase)
				{
					return (double)Layer + 0.04;
				}
				return (double)Layer + 0.0;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool UserCanEdit
		{
			get
			{
				return m_UserCanEdit;
			}
			set
			{
				base.PropertyUpdateDefault("UserCanEdit", value);
				if (UserCanEdit != value)
				{
					m_UserCanEdit = value;
					base.DoPropertyChange(this, "UserCanEdit");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool CanFocus
		{
			get
			{
				return m_CanFocus;
			}
			set
			{
				base.PropertyUpdateDefault("CanFocus", value);
				if (CanFocus != value)
				{
					m_CanFocus = value;
					base.DoPropertyChange(this, "CanFocus");
				}
			}
		}

		protected override bool CanFocusInternal => m_CanFocus;

		public new bool Focused => base.Focused;

		public string Description
		{
			get
			{
				if (TitleText != null && TitleText.Length != 0)
				{
					return TitleText + "-" + NameShort;
				}
				if (Name != null && Name.Length != 0)
				{
					return Name + "-" + NameShort;
				}
				return "<No Name>-" + NameShort;
			}
		}

		public string DisplayDescription
		{
			get
			{
				if (TitleText != null && TitleText.Length != 0)
				{
					return TitleText;
				}
				if (Name != null && Name.Length != 0)
				{
					return Name;
				}
				return "<No Name>";
			}
		}

		[Browsable(false)]
		[Description("")]
		public event BoundsChangeEventHandler BoundsClipChanged;

		void IPlotDraw.DrawSetup(PaintArgs p)
		{
			DrawSetup(p);
		}

		void IPlotDraw.DrawCalculations(PaintArgs p)
		{
			DrawCalculations(p);
		}

		void IPlotDraw.Draw(PaintArgs p)
		{
			DrawInternal(p);
		}

		void IPlotDraw.DrawBackgroundLayer1(PaintArgs p)
		{
			DrawBackgroundLayer1Internal(p);
		}

		void IPlotDraw.DrawBackgroundLayer2(PaintArgs p)
		{
			DrawBackgroundLayer2Internal(p);
		}

		void IPlotDraw.DrawForegroundLayer1(PaintArgs p)
		{
			DrawForegroundLayer1Internal(p);
		}

		void IPlotDraw.DrawForegroundLayer2(PaintArgs p)
		{
			DrawForegroundLayer2Internal(p);
		}

		void IPlotDraw.DrawFocusRectangles(PaintArgs p)
		{
			DrawFocusRectanglesInternal(p);
		}

		void IPlotDraw.UpdateCanDraw(PaintArgs p)
		{
			UpdateCanDrawInternal(p);
		}

		void IPlotDraw.UpdateBoundsClip(PaintArgs p)
		{
			UpdateBoundsClipInternal(p);
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Visible = true;
			Enabled = true;
			Layer = 100;
			UserCanEdit = true;
			CanFocus = true;
			ContextMenuEnabled = true;
			Name = "";
			TitleText = "";
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeEnabled()
		{
			return base.PropertyShouldSerialize("Enabled");
		}

		private void ResetEnabled()
		{
			base.PropertyReset("Enabled");
		}

		private bool ShouldSerializeContextMenuEnabled()
		{
			return base.PropertyShouldSerialize("ContextMenuEnabled");
		}

		private void ResetContextMenuEnabled()
		{
			base.PropertyReset("ContextMenuEnabled");
		}

		private bool ShouldSerializeName()
		{
			return base.PropertyShouldSerialize("Name");
		}

		private void ResetName()
		{
			base.PropertyReset("Name");
		}

		public virtual void ObjectRenamed(PlotObject value, string oldName)
		{
		}

		public virtual void ObjectRemoved(PlotObject value)
		{
		}

		public virtual void ObjectAdded(PlotObject value)
		{
		}

		private bool ShouldSerializeTitleText()
		{
			return base.PropertyShouldSerialize("TitleText");
		}

		private void ResetTitleText()
		{
			base.PropertyReset("TitleText");
		}

		private bool ShouldSerializeLayer()
		{
			return base.PropertyShouldSerialize("Layer");
		}

		private void ResetLayer()
		{
			base.PropertyReset("Layer");
		}

		private bool ShouldSerializeUserCanEdit()
		{
			return base.PropertyShouldSerialize("UserCanEdit");
		}

		private void ResetUserCanEdit()
		{
			base.PropertyReset("UserCanEdit");
		}

		private bool ShouldSerializeCanFocus()
		{
			return base.PropertyShouldSerialize("CanFocus");
		}

		private void ResetCanFocus()
		{
			base.PropertyReset("CanFocus");
		}

		public override string ToString()
		{
			return Description;
		}

		protected virtual void OnBoundsClipChanged(Rectangle r)
		{
			if (this.BoundsClipChanged != null)
			{
				this.BoundsClipChanged(this, new BoundsEventArgs(r));
			}
		}

		private void DrawInternal(PaintArgs p)
		{
			if (CanDraw)
			{
				Draw(p);
			}
		}

		private void DrawBackgroundLayer1Internal(PaintArgs p)
		{
			if (CanDraw)
			{
				DrawBackgroundLayer1(p);
			}
		}

		private void DrawBackgroundLayer2Internal(PaintArgs p)
		{
			if (CanDraw)
			{
				DrawBackgroundLayer2(p);
			}
		}

		private void DrawForegroundLayer1Internal(PaintArgs p)
		{
			if (CanDraw)
			{
				DrawForegroundLayer1(p);
			}
		}

		private void DrawForegroundLayer2Internal(PaintArgs p)
		{
			if (CanDraw)
			{
				DrawForegroundLayer2(p);
			}
		}

		private void DrawFocusRectanglesInternal(PaintArgs p)
		{
			if (CanDraw)
			{
				DrawFocusRectangles(p);
			}
		}

		private void UpdateCanDrawInternal(PaintArgs p)
		{
			CanDraw = true;
			UpdateCanDraw(p);
		}

		private void UpdateBoundsClipInternal(PaintArgs p)
		{
			UpdateBoundsClip(p);
		}

		protected virtual void DrawSetup(PaintArgs p)
		{
		}

		protected virtual void DrawCalculations(PaintArgs p)
		{
		}

		protected abstract void Draw(PaintArgs p);

		protected virtual void DrawBackgroundLayer1(PaintArgs p)
		{
		}

		protected virtual void DrawBackgroundLayer2(PaintArgs p)
		{
		}

		protected virtual void DrawForegroundLayer1(PaintArgs p)
		{
		}

		protected virtual void DrawForegroundLayer2(PaintArgs p)
		{
		}

		protected virtual void DrawFocusRectangles(PaintArgs p)
		{
		}

		protected virtual void UpdateBoundsClip(PaintArgs p)
		{
		}

		protected virtual void UpdateCanDraw(PaintArgs p)
		{
			if (!Visible)
			{
				CanDraw = false;
			}
		}

		protected virtual void PopulateContextMenu(ContextMenu menu)
		{
			if (UserCanEdit)
			{
				MenuItem item = new MenuItem("Edit", MenuItemEdit_Click);
				menu.MenuItems.Add(item);
			}
		}

		protected void AddMenuItem(Menu menu, string text, EventHandler eventhandler, bool isChecked)
		{
			MenuItem menuItem = new MenuItem();
			menuItem.Text = text;
			menuItem.Click += eventhandler;
			menuItem.Checked = isChecked;
			menu.MenuItems.Add(menuItem);
		}

		private void MenuItemEdit_Click(object sender, EventArgs e)
		{
			base.ShowEditorCustom(false, true);
		}

		protected override void InternalOnMouseRight(MouseEventArgs e)
		{
			base.Focus();
			if (ContextMenuEnabled)
			{
				ContextMenu contextMenu = new ContextMenu();
				PopulateContextMenu(contextMenu);
				contextMenu.Show(Plot, new Point(e.X + 10, e.Y + 10));
			}
		}
	}
}
