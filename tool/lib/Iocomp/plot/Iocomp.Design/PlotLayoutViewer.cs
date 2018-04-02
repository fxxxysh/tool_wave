using Iocomp.Classes;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("code")]
	[Description("Plot Layout Viewer")]
	public class PlotLayoutViewer : ControlBase, IPlugInEditorControl
	{
		private Plot m_Plot;

		private IPlugInStandard m_PlugInForm;

		private UIInputCollection m_UICollection;

		private bool m_IsDirty;

		public static PlotLayoutViewerDragControl m_DragControl;

		IPlugInStandard IPlugInEditorControl.PlugInForm
		{
			get
			{
				return m_PlugInForm;
			}
			set
			{
				m_PlugInForm = value;
			}
		}

		string IPlugInEditorControl.PropertyName
		{
			get
			{
				return "";
			}
			set
			{
			}
		}

		bool IPlugInEditorControl.IsValid
		{
			get
			{
				return true;
			}
		}

		bool IPlugInEditorControl.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		protected override Size DefaultSize => new Size(300, 150);

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Plot Plot
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

		public static PlotLayoutViewerDragControl DragControl => m_DragControl;

		void IPlugInEditorControl.UploadDisplay(object value)
		{
			m_Plot = (value as Plot);
			DoSetup();
			m_IsDirty = false;
		}

		void IPlugInEditorControl.TransferAmbient(object source, object destination)
		{
		}

		bool IPlugInEditorControl.GetIsDisplayDirty(object original)
		{
			return m_IsDirty;
		}

		public PlotLayoutViewer()
		{
			base.DoCreate();
			m_DragControl = new PlotLayoutViewerDragControl(this);
		}

		protected override void CreateObjects()
		{
			m_UICollection = new UIInputCollection(this);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.Border.Margin = 2;
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e)
		{
			m_UICollection.MouseLeft(e);
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			m_UICollection.MouseMove(e);
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			m_UICollection.MouseUp(e);
		}

		protected override void InternalOnMouseWheel(MouseEventArgs e)
		{
			m_UICollection.MouseWheel(e);
		}

		protected override void InternalOnKeyDown(KeyEventArgs e)
		{
			m_UICollection.KeyDown(e);
		}

		protected override void InternalOnKeyUp(KeyEventArgs e)
		{
			m_UICollection.KeyUp(e);
		}

		protected override void InternalOnLostFocus(EventArgs e)
		{
			m_UICollection.LostFocus(e);
		}

		protected override void InternalOnGotFocus(EventArgs e)
		{
			m_UICollection.GotFocus(e);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (Plot != null)
			{
				DoSetup();
			}
		}

		protected override void DoPaint(PaintArgs p)
		{
			Plot.LayoutManager.Execute(p, false, base.InnerRectangle, base.InnerRectangle);
			Plot.LayoutManager.DrawLayout(p, base.Font, SystemColors.ControlText, SystemColors.Control);
			DragControl.Draw(p, base.Font, SystemColors.ControlText, Color.FromArgb(200, Color.SteelBlue));
			DoSetup();
		}

		private void DoSetup()
		{
			m_UICollection.Clear();
			foreach (PlotLayoutBlockBase blockObject in Plot.LayoutManager.BlockObjects)
			{
				m_UICollection.Add(blockObject);
			}
			Plot.LayoutManager.LayoutRectangle = base.InnerRectangle;
		}

		public void MakeDirty()
		{
			m_IsDirty = true;
			m_PlugInForm.ForceDirtyUpdate();
		}
	}
}
