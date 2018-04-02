using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	public class PlugInStandard : UserControl, IPlugInStandard
	{
		private IPlugInMaster m_Master;

		private object m_Value;

		private PlugInStandardCollection m_SubPlugIns;

		private PlugInStandardCollection m_ClassPlugIns;

		private Iocomp.Classes.ControlCollection m_AllControls;

		private string m_TabName;

		private string m_Title;

		private TabControl m_TabControl;

		private TabPage m_TabPage;

		private bool m_BlockChange;

		private bool m_SameLevel;

		private int m_MarginLeft;

		private int m_MarginRight;

		private int m_MarginTop;

		private int m_MarginBottom;

		private object m_Source;

		private object m_Destination;

		private object m_WorkingInstance;

		private object m_OriginalInstance;

		[Browsable(false)]
		public object Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				m_Value = value;
				SetSubPlugInsValue();
			}
		}

		[Browsable(false)]
		public object Source
		{
			get
			{
				return m_Source;
			}
			set
			{
				Value = value;
				SetSource();
			}
		}

		[Browsable(false)]
		public object Destination
		{
			get
			{
				return m_Destination;
			}
			set
			{
				Value = value;
				SetDestination();
			}
		}

		[Browsable(false)]
		public object WorkingInstance
		{
			get
			{
				return m_WorkingInstance;
			}
			set
			{
				Value = value;
				SetWorkingInstance();
			}
		}

		[Browsable(false)]
		public object OriginalInstance
		{
			get
			{
				return m_OriginalInstance;
			}
			set
			{
				Value = value;
				SetOriginalInstance();
			}
		}

		[Browsable(false)]
		public int MarginLeft
		{
			get
			{
				return m_MarginLeft;
			}
		}

		[Browsable(false)]
		public int MarginRight
		{
			get
			{
				return m_MarginRight;
			}
		}

		[Browsable(false)]
		public int MarginTop
		{
			get
			{
				return m_MarginTop;
			}
		}

		[Browsable(false)]
		public int MarginBottom
		{
			get
			{
				return m_MarginBottom;
			}
		}

		[Browsable(false)]
		public string TabName
		{
			get
			{
				return m_TabName;
			}
			set
			{
				m_TabName = value;
			}
		}

		public string Title
		{
			get
			{
				return m_Title;
			}
			set
			{
				m_Title = value;
			}
		}

		protected IPlugInMaster Master
		{
			get
			{
				return m_Master;
			}
			set
			{
				m_Master = value;
			}
		}

		[Browsable(false)]
		public TabControl TabControl
		{
			get
			{
				return m_TabControl;
			}
			set
			{
				m_TabControl = value;
			}
		}

		[Browsable(false)]
		public TabPage TabPage
		{
			get
			{
				return m_TabPage;
			}
			set
			{
				m_TabPage = value;
			}
		}

		[Browsable(false)]
		public bool BlockChange
		{
			get
			{
				return m_BlockChange;
			}
			set
			{
				m_BlockChange = value;
			}
		}

		[Browsable(false)]
		public bool SameLevel
		{
			get
			{
				return m_SameLevel;
			}
			set
			{
				m_SameLevel = value;
			}
		}

		[Browsable(false)]
		public PlugInStandardCollection SubPlugIns
		{
			get
			{
				if (m_SubPlugIns == null)
				{
					m_SubPlugIns = new PlugInStandardCollection();
				}
				return m_SubPlugIns;
			}
		}

		[Browsable(false)]
		public PlugInStandardCollection ClassPlugIns
		{
			get
			{
				if (m_ClassPlugIns == null)
				{
					m_ClassPlugIns = new PlugInStandardCollection();
				}
				return m_ClassPlugIns;
			}
		}

		[Browsable(false)]
		public Iocomp.Classes.ControlCollection AllControls
		{
			get
			{
				if (m_AllControls == null)
				{
					m_AllControls = new Iocomp.Classes.ControlCollection();
				}
				return m_AllControls;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				foreach (PlugInStandard classPlugIn in ClassPlugIns)
				{
					if (classPlugIn != this)
					{
						classPlugIn.Dispose();
					}
				}
			}
			base.Dispose(disposing);
		}

		public void AddSubPlugIn(PlugInStandard plugIn, string tabName, bool sameLevel)
		{
			SubPlugIns.Add(plugIn);
			plugIn.TabName = tabName;
			plugIn.SameLevel = sameLevel;
		}

		private void SetSource()
		{
			m_Source = Value;
			foreach (PlugInStandard classPlugIn in ClassPlugIns)
			{
				if (classPlugIn != this)
				{
					classPlugIn.SetSource();
				}
			}
		}

		private void SetDestination()
		{
			m_Destination = Value;
			foreach (PlugInStandard classPlugIn in ClassPlugIns)
			{
				if (classPlugIn != this)
				{
					classPlugIn.SetDestination();
				}
			}
		}

		private void SetWorkingInstance()
		{
			m_WorkingInstance = Value;
			foreach (PlugInStandard classPlugIn in ClassPlugIns)
			{
				if (classPlugIn != this)
				{
					classPlugIn.SetWorkingInstance();
				}
			}
		}

		private void SetOriginalInstance()
		{
			m_OriginalInstance = Value;
			foreach (PlugInStandard classPlugIn in ClassPlugIns)
			{
				if (classPlugIn != this)
				{
					classPlugIn.SetOriginalInstance();
				}
			}
		}

		public virtual void UploadDisplay()
		{
			for (int i = 0; i < AllControls.Count; i++)
			{
				if (AllControls[i] is IPlugInEditorControl)
				{
					(AllControls[i] as IPlugInEditorControl).UploadDisplay(WorkingInstance);
				}
			}
			for (int j = 0; j < ClassPlugIns.Count; j++)
			{
				if (ClassPlugIns[j] != this)
				{
					ClassPlugIns[j].UploadDisplay();
				}
			}
		}

		public virtual void TransferAmbient()
		{
			for (int i = 0; i < AllControls.Count; i++)
			{
				IPlugInEditorControl plugInEditorControl = AllControls[i] as IPlugInEditorControl;
				plugInEditorControl?.TransferAmbient(Source, Destination);
			}
			foreach (PlugInStandard classPlugIn in ClassPlugIns)
			{
				if (classPlugIn != this)
				{
					classPlugIn.TransferAmbient();
				}
			}
		}

		public virtual bool GetIsDirty()
		{
			for (int i = 0; i < AllControls.Count; i++)
			{
				IPlugInEditorControl plugInEditorControl = AllControls[i] as IPlugInEditorControl;
				if (plugInEditorControl != null && plugInEditorControl.GetIsDisplayDirty(OriginalInstance))
				{
					return true;
				}
			}
			foreach (PlugInStandard classPlugIn in ClassPlugIns)
			{
				if (classPlugIn != this && classPlugIn.GetIsDirty())
				{
					return true;
				}
			}
			return false;
		}

		public void ForceDirtyUpdate()
		{
			Master.ForceDirtyUpdate(this);
		}

		public void ForceApplyButtonEnabled()
		{
			Master.ForceApplyButtonEnabled(this);
		}

		public virtual void CreateSubPlugIns()
		{
		}

		public virtual void SetSubPlugInsValue()
		{
		}

		private void ConnectEditorControls()
		{
			for (int i = 0; i < AllControls.Count; i++)
			{
				IPlugInEditorControl plugInEditorControl = AllControls[i] as IPlugInEditorControl;
				if (plugInEditorControl != null)
				{
					plugInEditorControl.PlugInForm = this;
				}
			}
		}

		private void FixupSize(int MarginLeft, int MarginTop)
		{
			int num = 999;
			int num2 = 999;
			int num3 = 0;
			int num4 = 0;
			foreach (Control control4 in base.Controls)
			{
				num = Math.Min(num, control4.Left);
				num2 = Math.Min(num2, control4.Top);
				num3 = Math.Max(num3, control4.Right);
				num4 = Math.Max(num4, control4.Bottom);
			}
			foreach (Control control5 in base.Controls)
			{
				if (!(control5 is FocusLabel))
				{
					control5.Left = control5.Left - num + MarginLeft;
					control5.Top = control5.Top - num2 + MarginTop;
				}
			}
			foreach (Control control6 in base.Controls)
			{
				if (control6 is FocusLabel)
				{
					(control6 as FocusLabel).AutoSize = false;
					(control6 as FocusLabel).AutoSize = true;
					(control6 as FocusLabel).Align();
				}
			}
			base.Width = num3 - num;
			base.Height = num4 - num2;
		}

		public void FixupAlign()
		{
			Dock = DockStyle.Fill;
			foreach (Control allControl in AllControls)
			{
				if (allControl is FocusLabel)
				{
					(allControl as FocusLabel).Align();
				}
			}
			foreach (PlugInStandard classPlugIn in ClassPlugIns)
			{
				if (classPlugIn != this)
				{
					classPlugIn.FixupAlign();
				}
			}
		}

		public void PopulateAllControls(ControlCollection controls)
		{
			foreach (Control control in controls)
			{
				if (control.Controls.Count != 0 && !(control is EditMultiLine) && !(control is Iocomp.Design.Plugin.EditorControls.NumericUpDown))
				{
					PopulateAllControls(control.Controls);
				}
				AllControls.Add(control);
			}
		}

		protected virtual void CreatePlugInTab(int offsetLeft, int offsetRight, int offsetTop, int offsetBottom)
		{
			if (base.Controls.Count != 0)
			{
				TabPage = new TabPage();
				TabPage.Text = TabName;
				TabControl.Controls.Add(TabPage);
				TabPage.Controls.Add(this);
				base.Location = new Point(Master.TabPageDockMargin, Master.TabPageDockMargin);
				m_MarginLeft = offsetLeft + Master.TabPageDockMargin;
				m_MarginRight = offsetRight + Master.TabPageDockMargin;
				m_MarginTop = offsetTop + Master.TabPageDockMargin;
				m_MarginBottom = offsetBottom + Master.TabPageDockMargin;
				Master.UpdateExtents(this);
				Dock = DockStyle.Fill;
				FixupSize(Master.TabPageDockMargin, Master.TabPageDockMargin);
				if (this is AboutPlugIn)
				{
					Dock = DockStyle.Fill;
				}
			}
		}

		public virtual void DoTabs(TabControl tabControl, bool first, int offsetLeft, int offsetRight, int offsetTop, int offsetBottom, float scaleRatio, IPlugInMaster master, PlugInStandardCollection classPlugIns)
		{
			m_Master = master;
			PopulateAllControls(base.Controls);
			if (!(this is AboutPlugIn))
			{
				classPlugIns.Add(this);
				ConnectEditorControls();
			}
			base.Scale(new SizeF(scaleRatio, scaleRatio));
			FixupSize(0, 0);
			CreateSubPlugIns();
			bool flag = false;
			int num = 0;
			while (num < SubPlugIns.Count)
			{
				if (!SubPlugIns[num].SameLevel)
				{
					num++;
					continue;
				}
				flag = true;
				break;
			}
			if (flag)
			{
				TabPage = new TabPage();
				TabPage.Text = TabName;
				tabControl.Controls.Add(TabPage);
				TabControl = new TabControl();
				TabControl.Dock = DockStyle.Fill;
				TabPage.Controls.Add(TabControl);
				int offsetLeft2 = offsetLeft;
				int offsetRight2 = offsetRight;
				int offsetTop2 = offsetTop;
				int offsetBottom2 = offsetBottom;
				offsetLeft += Master.TabPageBorderSize;
				offsetRight += Master.TabPageBorderSize;
				offsetTop += Master.TabPageBorderSize + Master.TabHeight;
				offsetBottom += Master.TabPageBorderSize;
				TabName = "General";
				CreatePlugInTab(offsetLeft, offsetRight, offsetTop, offsetBottom);
				for (int i = 0; i < SubPlugIns.Count; i++)
				{
					if (SubPlugIns[i].SameLevel)
					{
						SubPlugIns[i].DoTabs(TabControl, false, offsetLeft, offsetRight, offsetTop, offsetBottom, scaleRatio, master, classPlugIns);
					}
				}
				for (int j = 0; j < SubPlugIns.Count; j++)
				{
					if (!SubPlugIns[j].SameLevel)
					{
						SubPlugIns[j].DoTabs(tabControl, false, offsetLeft2, offsetRight2, offsetTop2, offsetBottom2, scaleRatio, master, classPlugIns);
					}
				}
			}
			else if (first || SubPlugIns.Count == 0)
			{
				TabControl = tabControl;
				CreatePlugInTab(offsetLeft, offsetRight, offsetTop, offsetBottom);
				for (int k = 0; k < SubPlugIns.Count; k++)
				{
					SubPlugIns[k].DoTabs(tabControl, false, offsetLeft, offsetRight, offsetTop, offsetBottom, scaleRatio, master, classPlugIns);
				}
			}
			else
			{
				TabPage = new TabPage();
				TabPage.Text = TabName;
				tabControl.Controls.Add(TabPage);
				TabControl = new TabControl();
				TabControl.Dock = DockStyle.Fill;
				TabPage.Controls.Add(TabControl);
				offsetLeft += Master.TabPageBorderSize;
				offsetRight += Master.TabPageBorderSize;
				offsetTop += Master.TabPageBorderSize + Master.TabHeight;
				offsetBottom += Master.TabPageBorderSize;
				TabName = "General";
				CreatePlugInTab(offsetLeft, offsetRight, offsetTop, offsetBottom);
				for (int l = 0; l < SubPlugIns.Count; l++)
				{
					SubPlugIns[l].DoTabs(TabControl, false, offsetLeft, offsetRight, offsetTop, offsetBottom, scaleRatio, master, classPlugIns);
				}
			}
		}
	}
}
