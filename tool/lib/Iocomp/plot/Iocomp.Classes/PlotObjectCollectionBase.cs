using Iocomp.Delegates;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Classes
{
	public abstract class PlotObjectCollectionBase : CollectionBase, IPlotObjectCollectionBase
	{
		private string m_BaseName;

		private bool m_InitialSetup;

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		public string BaseName
		{
			get
			{
				return m_BaseName;
			}
			set
			{
				m_BaseName = value;
			}
		}

		public bool InitialSetup => m_InitialSetup;

		[Browsable(false)]
		public event PlotObjectRenamedEventHandler ObjectRenamed;

		void IPlotObjectCollectionBase.HandleObjectRenamed(PlotObject value, string oldName)
		{
			HandleObjectRenamed(value, oldName);
		}

		void IPlotObjectCollectionBase.NotifyAllObjectRenamed(PlotObject value, string oldName)
		{
			NotifyAllObjectRenamed(value, oldName);
		}

		void IPlotObjectCollectionBase.NotifyAllObjectRemoved(PlotObject value)
		{
			NotifyAllObjectRemoved(value);
		}

		void IPlotObjectCollectionBase.NotifyAllObjectAdded(PlotObject value)
		{
			NotifyAllObjectAdded(value);
		}

		public PlotObjectCollectionBase()
			: base(null)
		{
			base.AllowEdit = true;
		}

		public PlotObjectCollectionBase(IComponentBase componentBase)
			: base(componentBase)
		{
			base.AllowEdit = true;
		}

		private void HandleObjectRenamed(PlotObject value, string oldName)
		{
			if (this.ObjectRenamed != null)
			{
				this.ObjectRenamed(value, new PlotObjectRenamedEventArgs(value, oldName));
			}
		}

		private void NotifyAllObjectRenamed(PlotObject value, string oldName)
		{
			foreach (PlotObject item in this)
			{
				item.ObjectRenamed(value, oldName);
			}
		}

		private void NotifyAllObjectRemoved(PlotObject value)
		{
			foreach (PlotObject item in this)
			{
				item.ObjectRemoved(value);
			}
		}

		private void NotifyAllObjectAdded(PlotObject value)
		{
			foreach (PlotObject item in this)
			{
				item.ObjectAdded(value);
			}
		}

		public void Sort(IComparer comparer)
		{
			base.InnerList.Sort(comparer);
		}

		protected PlotObject GetPlotObjectByName(string name)
		{
			if (name == null)
			{
				return null;
			}
			foreach (PlotObject item in this)
			{
				if (item.Name != null && item.Name.ToUpper() == name.ToUpper())
				{
					return item;
				}
			}
			return null;
		}

		protected override void SetupObjectBeforeAmbientControlBaseConnection(object value)
		{
			base.SetupObjectBeforeAmbientControlBaseConnection(value);
			PlotObject plotObject = value as PlotObject;
			if (BaseName != null && plotObject.Name == Const.EmptyString)
			{
				m_InitialSetup = true;
				int num = 0;
				foreach (PlotObject item in this)
				{
					if (item.Name.ToUpper().StartsWith(BaseName.ToUpper()))
					{
						string s = item.Name.Substring(BaseName.Length);
						if (double.TryParse(s, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, CultureInfo.InvariantCulture, out double num2) && (int)num2 > num)
						{
							num = (int)num2;
						}
					}
				}
				plotObject.Name = BaseName + " " + Convert2.ToString(num + 1);
				plotObject.TitleText = (value as PlotObject).Name;
			}
			else
			{
				m_InitialSetup = false;
			}
		}

		protected override void OnInsertComplete(int index, object value)
		{
			(value as IPlotObject).Plot = (base.ComponentBase as Plot);
			base.OnInsertComplete(index, value);
		}

		protected override void OnRemoveComplete(int index, object value)
		{
			(value as IPlotObject).Plot = null;
			base.OnRemoveComplete(index, value);
		}

		protected override void OnSetComplete(int index, object oldValue, object newValue)
		{
			if (oldValue != null)
			{
				(oldValue as IPlotObject).Plot = null;
			}
			if (newValue != null)
			{
				(newValue as IPlotObject).Plot = (base.ComponentBase as Plot);
			}
			base.OnSetComplete(index, oldValue, newValue);
		}
	}
}
