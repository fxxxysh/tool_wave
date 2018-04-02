using Iocomp.Classes;
using Iocomp.Design.Components;
using Iocomp.Interfaces;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	public abstract class PlugInCollection : PlugInStandard, IPlugInMaster
	{
		private CollectionNavigatorPanel m_Navigator;

		private PlugInStandard[] m_PlugInPool;

		private TabControl[] m_ClassTabControls;

		private bool m_SelectLast;

		public PlugInStandard[] PlugInPool => m_PlugInPool;

		public CollectionNavigatorPanel Navigator => m_Navigator;

		protected abstract Type[] Types
		{
			get;
		}

		int IPlugInMaster.TabPageBorderSize
		{
			get
			{
				return base.Master.TabPageBorderSize;
			}
		}

		int IPlugInMaster.TabPageDockMargin
		{
			get
			{
				return base.Master.TabPageDockMargin;
			}
		}

		int IPlugInMaster.TabHeight
		{
			get
			{
				return base.Master.TabHeight;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && m_PlugInPool != null)
			{
				PlugInStandard[] plugInPool = m_PlugInPool;
				foreach (PlugInStandard plugInStandard in plugInPool)
				{
					plugInStandard.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		protected abstract PlugInStandard[] CreatePlugInPool();

		protected abstract PlugInStandard GetClassPlugIn(object value);

		protected abstract int GetPlugInIndex(object value);

		private void TabPage_Resize(object sender, EventArgs e)
		{
			for (int i = 0; i < m_ClassTabControls.Length; i++)
			{
				m_ClassTabControls[i].Size = new Size(base.TabPage.Width - Navigator.Width, base.TabPage.Height);
			}
		}

		public override void DoTabs(TabControl tabControl, bool first, int offsetLeft, int offsetRight, int offsetTop, int offsetBottom, float scaleRatio, IPlugInMaster master, PlugInStandardCollection classPlugIns)
		{
			classPlugIns.Add(this);
			base.Master = master;
			base.TabControl = tabControl;
			base.TabPage = new TabPage();
			base.TabPage.Text = base.TabName;
			base.TabPage.SizeChanged += TabPage_SizeChanged;
			base.TabControl.Controls.Add(base.TabPage);
			m_Navigator = new CollectionNavigatorPanel();
			Navigator.Dock = DockStyle.Left;
			Navigator.SelectedIndexChanged += Navigator_SelectedIndexChanged;
			Navigator.ItemMoved += Navigator_ItemMoved;
			Navigator.ItemAdd += Navigator_ItemAdd;
			Navigator.ItemRemove += Navigator_ItemRemove;
			Navigator.Types = Types;
			Navigator.DoLayout();
			base.Master.UpdateExtents(Navigator.Width + offsetLeft + offsetRight, Navigator.Height + offsetTop + offsetBottom);
			base.TabPage.Controls.Add(Navigator);
			Navigator.DoLayout();
			base.TabPage.Resize += TabPage_Resize;
			offsetLeft += base.Master.TabPageBorderSize + Navigator.Width;
			offsetRight += base.Master.TabPageBorderSize;
			offsetTop += base.Master.TabPageBorderSize + base.Master.TabHeight;
			offsetBottom += base.Master.TabPageBorderSize;
			m_PlugInPool = CreatePlugInPool();
			m_ClassTabControls = new TabControl[m_PlugInPool.Length];
			for (int i = 0; i < m_PlugInPool.Length; i++)
			{
				m_ClassTabControls[i] = new TabControl();
				m_ClassTabControls[i].Left = Navigator.Right;
				m_ClassTabControls[i].Width = 700;
				m_ClassTabControls[i].Height = 400;
				base.TabPage.Controls.Add(m_ClassTabControls[i]);
			}
			for (int j = 0; j < m_PlugInPool.Length; j++)
			{
				PlugInStandard plugInStandard = m_PlugInPool[j];
				plugInStandard.TabName = "General";
				plugInStandard.DoTabs(m_ClassTabControls[j], true, offsetLeft, offsetRight, offsetTop, offsetBottom, scaleRatio, master, plugInStandard.ClassPlugIns);
			}
			for (int k = 0; k < m_ClassTabControls.Length; k++)
			{
				m_ClassTabControls[k].Visible = false;
			}
		}

		public override void SetSubPlugInsValue()
		{
		}

		public override void UploadDisplay()
		{
			Iocomp.Classes.CollectionBase collectionBase = base.WorkingInstance as Iocomp.Classes.CollectionBase;
			Navigator.AllowEdit = ((ICollectionBase)collectionBase).AllowEdit;
			Navigator.BeginUpdate();
			int selectedIndex = Navigator.SelectedIndex;
			object selectedObject = Navigator.SelectedObject;
			Navigator.Items.Clear();
			for (int i = 0; i < collectionBase.Count; i++)
			{
				object item = ((IList)collectionBase)[i];
				Navigator.Items.Add(item);
			}
			if (m_SelectLast)
			{
				Navigator.SelectLast();
				m_SelectLast = false;
			}
			else if (selectedObject != null)
			{
				int num = Navigator.Items.IndexOf(selectedObject);
				if (num != -1)
				{
					Navigator.SelectedIndex = num;
				}
				else
				{
					Navigator.SelectLast();
				}
			}
			if (Navigator.Items.Count == 0)
			{
				TabControl[] classTabControls = m_ClassTabControls;
				foreach (TabControl tabControl in classTabControls)
				{
					tabControl.Visible = false;
				}
			}
			else if (Navigator.SelectedIndex == -1)
			{
				Navigator.SelectFirst();
			}
			Navigator.EndUpdate();
		}

		public override void TransferAmbient()
		{
			Iocomp.Classes.CollectionBase collectionBase = base.Source as Iocomp.Classes.CollectionBase;
			Iocomp.Classes.CollectionBase collectionBase2 = base.Destination as Iocomp.Classes.CollectionBase;
			collectionBase2.Clear();
			for (int i = 0; i < collectionBase.Count; i++)
			{
				object obj = ((IList)collectionBase)[i];
				object obj2 = ((ICollectionBase)collectionBase2).CreateInstance(obj.GetType());
				(obj2 as ISubClassBase).ControlBase = (base.Master as IControlBase);
				PlugInStandard classPlugIn = GetClassPlugIn(obj);
				classPlugIn.Source = obj;
				classPlugIn.Destination = obj2;
				classPlugIn.TransferAmbient();
			}
		}

		public override bool GetIsDirty()
		{
			try
			{
				Iocomp.Classes.CollectionBase collectionBase = base.OriginalInstance as Iocomp.Classes.CollectionBase;
				Iocomp.Classes.CollectionBase collectionBase2 = base.WorkingInstance as Iocomp.Classes.CollectionBase;
				if (collectionBase.Count != collectionBase2.Count)
				{
					return true;
				}
				for (int i = 0; i < collectionBase2.Count; i++)
				{
					object obj = ((IList)collectionBase)[i];
					object obj2 = ((IList)collectionBase2)[i];
					if (obj.GetType() != obj2.GetType())
					{
						return true;
					}
					PlugInStandard classPlugIn = GetClassPlugIn(obj2);
					classPlugIn.WorkingInstance = obj2;
					classPlugIn.OriginalInstance = obj;
					classPlugIn.UploadDisplay();
					if (classPlugIn.GetIsDirty())
					{
						return true;
					}
				}
				return false;
			}
			finally
			{
				if (Navigator.SelectedObject != null)
				{
					PlugInStandard classPlugIn = GetClassPlugIn(Navigator.SelectedObject);
					classPlugIn.WorkingInstance = Navigator.SelectedObject;
					classPlugIn.UploadDisplay();
				}
			}
		}

		private void Navigator_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Navigator.SelectedObject == null)
			{
				TabControl[] classTabControls = m_ClassTabControls;
				foreach (TabControl tabControl in classTabControls)
				{
					tabControl.Visible = false;
				}
			}
			else
			{
				for (int j = 0; j < m_ClassTabControls.Length; j++)
				{
					m_ClassTabControls[j].Visible = (j == GetPlugInIndex(Navigator.SelectedObject));
				}
				PlugInStandard classPlugIn = GetClassPlugIn(Navigator.SelectedObject);
				classPlugIn.WorkingInstance = Navigator.SelectedObject;
				classPlugIn.UploadDisplay();
			}
		}

		private void Navigator_ItemAdd(object sender, TypeEventArgs e)
		{
			m_SelectLast = true;
			Iocomp.Classes.CollectionBase collectionBase = base.WorkingInstance as Iocomp.Classes.CollectionBase;
			object value = Activator.CreateInstance(e.Type);
			((IList)collectionBase).Add(value);
			base.Master.ForceDirtyUpdate(null);
		}

		private void Navigator_ItemRemove(object sender, EventArgs e)
		{
			Iocomp.Classes.CollectionBase collectionBase = base.WorkingInstance as Iocomp.Classes.CollectionBase;
			collectionBase.RemoveAt(Navigator.SelectedIndex);
			base.Master.ForceDirtyUpdate(null);
		}

		private void Navigator_ItemMoved(object sender, ObjectMoveIndexEventArgs e)
		{
			Iocomp.Classes.CollectionBase collectionBase = base.WorkingInstance as Iocomp.Classes.CollectionBase;
			object value = ((IList)collectionBase)[e.OldIndex];
			((IList)collectionBase).RemoveAt(e.OldIndex);
			((IList)collectionBase).Insert(e.NewIndex, value);
			base.Master.ForceDirtyUpdate(null);
		}

		void IPlugInMaster.ForceDirtyUpdate(PlugInStandard value)
		{
			base.Master.ForceDirtyUpdate(this);
		}

		void IPlugInMaster.ForceApplyButtonEnabled(PlugInStandard value)
		{
			base.Master.ForceApplyButtonEnabled(this);
		}

		void IPlugInMaster.UpdateExtents(PlugInStandard value)
		{
			base.Master.UpdateExtents(value);
		}

		void IPlugInMaster.UpdateExtents(int width, int height)
		{
			base.Master.UpdateExtents(width, height);
		}

		private void TabPage_SizeChanged(object sender, EventArgs e)
		{
			if (m_Navigator != null)
			{
				m_Navigator.Height = base.TabPage.Height;
				m_Navigator.DoLayout();
			}
		}
	}
}
