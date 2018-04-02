using Iocomp.Classes;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	public class UITypeEditorGeneric : UITypeEditor, IPlugInMaster, IControlBase
	{
		private PlugInStandard m_MainPlugIn;

		private string m_MainPlugInTitle;

		private string m_MainPlugInTabName;

		private PlugInStandard m_AboutPlugIn;

		private Form m_MainForm;

		private int m_MaxWidth;

		private int m_MaxHeight;

		private int m_TabPageBorderSize;

		private int m_TabPageDockMargin;

		private int m_TabHeight;

		private float m_ScaleRatio;

		private PlugInControlPanel m_ControlPanel;

		private IForceDesignerChange I_IForceDesignerChange;

		private object m_OriginalInstance;

		private object m_WorkingInstance;

		private object m_RestoreInstance;

		private object m_ResetInstance;

		private IControlBase I_ControlBase;

		private ITypeDescriptorContext m_Context;

		private IServiceProvider m_Provider;

		private Control m_SurrogateParent;

		public int TabPageBorderSize => m_TabPageBorderSize;

		public int TabPageDockMargin => m_TabPageDockMargin;

		public int TabHeight => m_TabHeight;

		public PlugInStandard MainPlugIn => m_MainPlugIn;

		public string MainPlugInTitle => m_MainPlugInTitle;

		public string MainPlugInTabName => m_MainPlugInTabName;

		public object OriginalInstance => m_OriginalInstance;

		private Form MainForm
		{
			get
			{
				return m_MainForm;
			}
			set
			{
				m_MainForm = value;
			}
		}

		public IForceDesignerChange IForceDesignerChange
		{
			get
			{
				return I_IForceDesignerChange;
			}
			set
			{
				I_IForceDesignerChange = value;
			}
		}

		public Size Size
		{
			get
			{
				if (I_ControlBase != null)
				{
					return I_ControlBase.Size;
				}
				return Size.Empty;
			}
			set
			{
			}
		}

		public Color BackColor
		{
			get
			{
				if (I_ControlBase != null)
				{
					return I_ControlBase.BackColor;
				}
				return Color.Empty;
			}
			set
			{
			}
		}

		public Font Font
		{
			get
			{
				if (I_ControlBase != null)
				{
					return I_ControlBase.Font;
				}
				return null;
			}
			set
			{
			}
		}

		public Color ForeColor
		{
			get
			{
				if (I_ControlBase != null)
				{
					return I_ControlBase.ForeColor;
				}
				return Color.Empty;
			}
			set
			{
			}
		}

		public Control _Parent
		{
			get
			{
				if (I_ControlBase != null)
				{
					return I_ControlBase._Parent;
				}
				return null;
			}
		}

		public Control Control
		{
			get
			{
				if (I_ControlBase != null)
				{
					return I_ControlBase.Control;
				}
				return null;
			}
		}

		public Cursor Cursor
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public EventSource EventSource => EventSource.Code;

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

		public bool DefaultReadBack
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Loading => false;

		public bool Creating => false;

		public bool SettingDefaults => false;

		public bool Designing => true;

		public bool Focused => false;

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

		public event UITypeEditorEventHandler CreateMainPlugIn;

		void IPlugInMaster.ForceDirtyUpdate(PlugInStandard value)
		{
			MainPlugIn.UploadDisplay();
			UpdateControlPanel();
		}

		void IPlugInMaster.ForceApplyButtonEnabled(PlugInStandard value)
		{
			if (m_ControlPanel != null)
			{
				m_ControlPanel.ApplyButton.Enabled = true;
			}
		}

		public void UpdateExtents(int width, int height)
		{
			m_MaxWidth = Math.Max(m_MaxWidth, width);
			m_MaxHeight = Math.Max(m_MaxHeight, height);
		}

		public void UpdateExtents(PlugInStandard plugIn)
		{
			int width = plugIn.Width + plugIn.MarginLeft + plugIn.MarginRight;
			int height = plugIn.Height + plugIn.MarginTop + plugIn.MarginBottom;
			UpdateExtents(width, height);
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			if (context == null)
			{
				return base.GetEditStyle(context);
			}
			if (context.Instance == null)
			{
				return base.GetEditStyle(context);
			}
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			m_Context = context;
			m_Provider = provider;
			return Edit(value, true, true, true);
		}

		public object EditValue(object value, bool designTimeStyle, bool modal)
		{
			m_Context = null;
			m_Provider = null;
			return Edit(value, designTimeStyle, modal, false);
		}

		private object Edit(object value, bool designTimeStyle, bool modal, bool showAbout)
		{
			m_OriginalInstance = value;
			if (!modal && !designTimeStyle && MainPlugIn != null && MainForm != null)
			{
				MainForm.Show();
				MainForm.BringToFront();
				return value;
			}
			if (MainPlugIn != null)
			{
				MainPlugIn.Dispose();
				m_MainPlugIn = null;
			}
			if (MainForm != null)
			{
				MainForm.Dispose();
				m_MainForm = null;
			}
			CreatePlugInInternal();
			if (m_MainPlugIn == null)
			{
				return value;
			}
			if (designTimeStyle)
			{
				SetupDesignTime(showAbout);
			}
			else
			{
				SetupRuntime(showAbout);
			}
			if (m_Provider != null && m_Context != null)
			{
				IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)m_Provider.GetService(typeof(IWindowsFormsEditorService));
				if (windowsFormsEditorService != null)
				{
					windowsFormsEditorService.ShowDialog(MainForm);
					m_Context.OnComponentChanged();
					MainPlugIn.Dispose();
					m_MainPlugIn = null;
					goto IL_015d;
				}
				return base.EditValue(m_Context, m_Provider, m_OriginalInstance);
			}
			if (modal || designTimeStyle)
			{
				MainForm.ShowDialog();
				MainPlugIn.Dispose();
				MainForm.Dispose();
				m_MainPlugIn = null;
				m_MainForm = null;
			}
			else
			{
				MainForm.TopMost = true;
				MainForm.Show();
				MainForm.BringToFront();
			}
			goto IL_015d;
			IL_015d:
			return value;
		}

		private void SetupDesignTime(bool showAbout)
		{
			MainForm = new Form();
			MainForm.Text = MainPlugInTitle;
			MainForm.FormBorderStyle = FormBorderStyle.FixedDialog;
			MainForm.StartPosition = FormStartPosition.CenterScreen;
			MainForm.ShowInTaskbar = false;
			MainForm.MaximizeBox = false;
			MainForm.MinimizeBox = false;
			m_ScaleRatio = (float)((int)Math.Ceiling((double)MainForm.Font.GetHeight()) / MainForm.AutoScaleBaseSize.Height);
			MainForm.AutoScaleMode = AutoScaleMode.None;
			m_ControlPanel = new PlugInControlPanel();
			m_ControlPanel.Dock = DockStyle.Bottom;
			m_ControlPanel.OKButton.Click += ControlPanel_OkButtonClick;
			m_ControlPanel.CancelButton.Click += ControlPanel_CancelButtonClick;
			m_ControlPanel.ApplyButton.Click += ControlPanel_ApplyButtonClick;
			m_ControlPanel.ResetButton.Click += ResetButton_Click;
			m_ControlPanel.RestoreButton.Click += RestoreButton_Click;
			UpdateExtents(m_ControlPanel.RequiredWidthMin, 0);
			MainForm.Controls.Add(m_ControlPanel);
			m_WorkingInstance = Activator.CreateInstance(m_OriginalInstance.GetType());
			m_RestoreInstance = Activator.CreateInstance(m_OriginalInstance.GetType());
			m_ResetInstance = Activator.CreateInstance(m_OriginalInstance.GetType());
			if (m_OriginalInstance is SubClassBase)
			{
				(m_OriginalInstance as ISubClassBase).ResetClone(m_ResetInstance as SubClassBase);
			}
			if (m_ResetInstance is IComponentBase)
			{
				(m_ResetInstance as IComponentBase).SetComponentDefaults();
			}
			if (m_ResetInstance is CollectionBase)
			{
				(m_ResetInstance as CollectionBase).Reset();
			}
			if (m_OriginalInstance is IControlBase)
			{
				I_ControlBase = (m_OriginalInstance as IControlBase);
				m_SurrogateParent = new System.Windows.Forms.Label();
				if (I_ControlBase._Parent != null)
				{
					m_SurrogateParent.BackColor = I_ControlBase._Parent.BackColor;
					m_SurrogateParent.ForeColor = I_ControlBase._Parent.ForeColor;
					m_SurrogateParent.Font = I_ControlBase._Parent.Font;
				}
				(m_WorkingInstance as Control).Parent = m_SurrogateParent;
				(m_ResetInstance as Control).Parent = m_SurrogateParent;
				(m_RestoreInstance as Control).Parent = m_SurrogateParent;
			}
			else if (m_OriginalInstance is ISubClassBase)
			{
				I_ControlBase = (m_OriginalInstance as ISubClassBase).ControlBase;
				(m_WorkingInstance as ISubClassBase).ControlBase = this;
				(m_ResetInstance as ISubClassBase).ControlBase = this;
				(m_RestoreInstance as ISubClassBase).ControlBase = this;
				(m_WorkingInstance as ISubClassBase).AmbientOwner = (m_OriginalInstance as ISubClassBase).AmbientOwner;
				(m_ResetInstance as ISubClassBase).AmbientOwner = (m_OriginalInstance as ISubClassBase).AmbientOwner;
				(m_RestoreInstance as ISubClassBase).AmbientOwner = (m_OriginalInstance as ISubClassBase).AmbientOwner;
			}
			else if (m_OriginalInstance is ICollectionBase)
			{
				(m_WorkingInstance as ICollectionBase).ComponentBase = (m_OriginalInstance as ICollectionBase).ComponentBase;
				(m_ResetInstance as ICollectionBase).ComponentBase = (m_OriginalInstance as ICollectionBase).ComponentBase;
				(m_RestoreInstance as ICollectionBase).ComponentBase = (m_OriginalInstance as ICollectionBase).ComponentBase;
			}
			TabControl tabControl = new TabControl();
			MainForm.Controls.Add(tabControl);
			tabControl.Dock = DockStyle.Fill;
			if (m_OriginalInstance is SubClassBase)
			{
				MainPlugIn.TabName = "General";
			}
			else
			{
				MainPlugIn.TabName = "Control";
			}
			MainPlugIn.TabControl = tabControl;
			TabPage tabPage = new TabPage();
			tabPage.Text = "About";
			tabControl.Controls.Add(tabPage);
			m_TabPageBorderSize = 4;
			m_TabPageDockMargin = 8;
			m_TabHeight = tabControl.Height - tabControl.DisplayRectangle.Height - 8;
			tabControl.Controls.Remove(tabPage);
			tabPage.Dispose();
			int tabPageBorderSize = TabPageBorderSize;
			int tabPageBorderSize2 = TabPageBorderSize;
			int offsetTop = TabHeight + TabPageBorderSize;
			int tabPageBorderSize3 = TabPageBorderSize;
			MainPlugIn.DoTabs(tabControl, true, tabPageBorderSize, tabPageBorderSize2, offsetTop, tabPageBorderSize3, m_ScaleRatio, this, MainPlugIn.ClassPlugIns);
			if (showAbout)
			{
				m_AboutPlugIn = new AboutPlugIn();
				m_AboutPlugIn.TabName = "About";
				m_AboutPlugIn.DoTabs(tabControl, true, tabPageBorderSize, tabPageBorderSize2, offsetTop, tabPageBorderSize3, m_ScaleRatio, this, MainPlugIn.SubPlugIns);
			}
			MainPlugIn.WorkingInstance = m_WorkingInstance;
			MainPlugIn.OriginalInstance = m_OriginalInstance;
			TransferAmbient(m_OriginalInstance, m_WorkingInstance);
			TransferAmbient(m_OriginalInstance, m_RestoreInstance);
			MainPlugIn.UploadDisplay();
			MainForm.ClientSize = new Size(m_MaxWidth, m_MaxHeight + m_ControlPanel.Height);
			tabControl.Dock = DockStyle.None;
			tabControl.Height = m_MaxHeight;
			tabControl.Width = m_MaxWidth;
			MainPlugIn.FixupAlign();
			m_ControlPanel.Dock = DockStyle.None;
			m_ControlPanel.Width = MainForm.ClientSize.Width;
			m_ControlPanel.Top = MainForm.ClientSize.Height - m_ControlPanel.Height;
			m_ControlPanel.DoLayout();
			UpdateControlPanel();
		}

		private void SetupRuntime(bool showAbout)
		{
			MainForm = new Form();
			MainForm.Text = MainPlugInTitle;
			MainForm.FormBorderStyle = FormBorderStyle.FixedDialog;
			MainForm.StartPosition = FormStartPosition.CenterScreen;
			MainForm.ShowInTaskbar = false;
			MainForm.MaximizeBox = false;
			MainForm.MinimizeBox = false;
			m_ScaleRatio = (float)((int)Math.Ceiling((double)MainForm.Font.GetHeight()) / MainForm.AutoScaleBaseSize.Height);
			MainForm.AutoScaleMode = AutoScaleMode.None;
			TabControl tabControl = new TabControl();
			MainForm.Controls.Add(tabControl);
			tabControl.Dock = DockStyle.Fill;
			MainPlugIn.TabName = MainPlugInTabName;
			MainPlugIn.TabControl = tabControl;
			TabPage tabPage = new TabPage();
			tabPage.Text = "About";
			tabControl.Controls.Add(tabPage);
			m_TabPageBorderSize = 4;
			m_TabPageDockMargin = 8;
			m_TabHeight = tabControl.Height - tabControl.DisplayRectangle.Height - 8;
			tabControl.Controls.Remove(tabPage);
			tabPage.Dispose();
			int tabPageBorderSize = TabPageBorderSize;
			int tabPageBorderSize2 = TabPageBorderSize;
			int offsetTop = TabHeight + TabPageBorderSize;
			int tabPageBorderSize3 = TabPageBorderSize;
			MainPlugIn.DoTabs(tabControl, true, tabPageBorderSize, tabPageBorderSize2, offsetTop, tabPageBorderSize3, m_ScaleRatio, this, MainPlugIn.ClassPlugIns);
			if (showAbout)
			{
				m_AboutPlugIn = new AboutPlugIn();
				m_AboutPlugIn.TabName = "About";
				m_AboutPlugIn.DoTabs(tabControl, true, tabPageBorderSize, tabPageBorderSize2, offsetTop, tabPageBorderSize3, m_ScaleRatio, this, MainPlugIn.SubPlugIns);
			}
			MainPlugIn.OriginalInstance = m_OriginalInstance;
			MainPlugIn.WorkingInstance = m_OriginalInstance;
			MainPlugIn.UploadDisplay();
			MainForm.ClientSize = new Size(m_MaxWidth, m_MaxHeight);
			tabControl.Dock = DockStyle.None;
			tabControl.Height = m_MaxHeight;
			tabControl.Width = m_MaxWidth;
			MainPlugIn.FixupAlign();
		}

		private void UpdateControlPanel()
		{
			if (m_ControlPanel != null)
			{
				if (MainPlugIn.GetIsDirty())
				{
					m_ControlPanel.OKButton.Enabled = true;
					m_ControlPanel.CancelButton.Enabled = true;
					m_ControlPanel.ApplyButton.Enabled = true;
				}
				else
				{
					m_ControlPanel.OKButton.Enabled = true;
					m_ControlPanel.CancelButton.Enabled = true;
					m_ControlPanel.ApplyButton.Enabled = false;
				}
			}
		}

		private void TransferAmbient(object source, object destination)
		{
			MainPlugIn.Source = source;
			MainPlugIn.Destination = destination;
			MainPlugIn.TransferAmbient();
		}

		private void DownloadToOriginal()
		{
			if (I_ControlBase != null)
			{
				I_ControlBase.FreezeAutoSize = true;
			}
			try
			{
				TransferAmbient(m_WorkingInstance, m_OriginalInstance);
			}
			finally
			{
				if (I_ControlBase != null)
				{
					I_ControlBase.FreezeAutoSize = false;
				}
			}
			if (I_IForceDesignerChange != null)
			{
				I_IForceDesignerChange.ForceChange();
			}
		}

		private void ControlPanel_OkButtonClick(object sender, EventArgs e)
		{
			DownloadToOriginal();
			MainForm.DialogResult = DialogResult.OK;
		}

		private void ControlPanel_ApplyButtonClick(object sender, EventArgs e)
		{
			DownloadToOriginal();
			UpdateControlPanel();
		}

		private void ControlPanel_CancelButtonClick(object sender, EventArgs e)
		{
			MainForm.DialogResult = DialogResult.Cancel;
		}

		private void ResetButton_Click(object sender, EventArgs e)
		{
			TransferAmbient(m_ResetInstance, m_WorkingInstance);
			MainPlugIn.UploadDisplay();
			UpdateControlPanel();
		}

		private void RestoreButton_Click(object sender, EventArgs e)
		{
			TransferAmbient(m_RestoreInstance, m_WorkingInstance);
			MainPlugIn.UploadDisplay();
			UpdateControlPanel();
		}

		private object CreatePlugInByFullName(string fullName)
		{
			object result = null;
			if (fullName != string.Empty)
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (Assembly assembly in assemblies)
				{
					if (!(assembly is AssemblyBuilder))
					{
						Type[] types = assembly.GetTypes();
						bool flag = false;
						Type[] array = types;
						foreach (Type type in array)
						{
							if (type.FullName == fullName)
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							result = (PlugInStandard)Activator.CreateInstance(assembly.FullName, fullName).Unwrap();
							break;
						}
					}
				}
			}
			return result;
		}

		private void CreatePlugInInternal()
		{
			if (this.CreateMainPlugIn != null)
			{
				UITypeEditorEventArgs uITypeEditorEventArgs = new UITypeEditorEventArgs(this);
				this.CreateMainPlugIn(this, uITypeEditorEventArgs);
				m_MainPlugIn = uITypeEditorEventArgs.MainPlugIn;
				m_MainPlugInTitle = uITypeEditorEventArgs.MainPlugInTitle;
				m_MainPlugInTabName = uITypeEditorEventArgs.MainPlugInTabName;
			}
			else if (m_OriginalInstance is ISupportUITypeEditor)
			{
				m_MainPlugInTitle = (m_OriginalInstance as ISupportUITypeEditor).GetPlugInTitle() + " Editor";
				string plugInClassName = (m_OriginalInstance as ISupportUITypeEditor).GetPlugInClassName();
				m_MainPlugIn = (CreatePlugInByFullName(plugInClassName) as PlugInStandard);
			}
			if (m_OriginalInstance is SubClassBase)
			{
				m_MainPlugInTabName = "General";
			}
			else
			{
				m_MainPlugInTabName = "Control";
			}
		}

		public void DoPropertyChange(object sender, string propertyName)
		{
		}

		public void ForceDesignerChange()
		{
		}

		public void DoAutoSize()
		{
		}

		public void DoAutoSizeSpecialOffset(int specialOffset)
		{
		}

		public void LoadingBegin()
		{
		}

		public void LoadingEnd()
		{
		}

		public bool Focus()
		{
			return false;
		}

		public void SetComponentDefaults()
		{
		}

		public void ShowEditorCustom(bool designTimeStyle, bool modal)
		{
		}
	}
}
