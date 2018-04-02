using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Base Class for all Plot Layout objects.")]
	public abstract class PlotLayoutBase : PlotObject, IPlotLayout
	{
		private int m_DockOrder;

		private AlignmentQuadSide m_DockSide;

		private int m_DockMargin;

		private Rectangle m_BoundsAlignment;

		private int m_DockDepthPixels;

		private int m_TextOverlapPixelsStart;

		private int m_TextOverlapPixelsStop;

		private int m_StackingPixelsStart;

		private int m_StackingPixelsStop;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int DockOrder
		{
			get
			{
				return m_DockOrder;
			}
			set
			{
				base.PropertyUpdateDefault("DockOrder", value);
				if (DockOrder != value)
				{
					m_DockOrder = value;
					base.DoPropertyChange(this, "DockOrder");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public virtual AlignmentQuadSide DockSide
		{
			get
			{
				return m_DockSide;
			}
			set
			{
				base.PropertyUpdateDefault("DockSide", value);
				if (DockSide != value)
				{
					m_DockSide = value;
					base.DoPropertyChange(this, "DockSide");
					OnDockSideChanged();
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public virtual int DockMargin
		{
			get
			{
				return m_DockMargin;
			}
			set
			{
				base.PropertyUpdateDefault("DockMargin", value);
				if (DockMargin != value)
				{
					m_DockMargin = value;
					base.DoPropertyChange(this, "DockMargin");
				}
			}
		}

		public bool DockLeft => m_DockSide == AlignmentQuadSide.Left;

		public bool DockRight => m_DockSide == AlignmentQuadSide.Right;

		public bool DockTop => m_DockSide == AlignmentQuadSide.Top;

		public bool DockBottom => m_DockSide == AlignmentQuadSide.Bottom;

		public bool DockVertical
		{
			get
			{
				if (!DockTop)
				{
					return DockBottom;
				}
				return true;
			}
		}

		public bool DockHorizontal
		{
			get
			{
				if (!DockLeft)
				{
					return DockRight;
				}
				return true;
			}
		}

		public Orientation DockOrientation
		{
			get
			{
				if (DockVertical)
				{
					return Orientation.Vertical;
				}
				return Orientation.Horizontal;
			}
		}

		[Browsable(false)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int DockDepthPixels
		{
			get
			{
				return m_DockDepthPixels;
			}
			set
			{
				m_DockDepthPixels = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Browsable(false)]
		public int TextOverlapPixelsStart
		{
			get
			{
				return m_TextOverlapPixelsStart;
			}
			set
			{
				m_TextOverlapPixelsStart = value;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int TextOverlapPixelsStop
		{
			get
			{
				return m_TextOverlapPixelsStop;
			}
			set
			{
				m_TextOverlapPixelsStop = value;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int StackingPixelsStart
		{
			get
			{
				return m_StackingPixelsStart;
			}
			set
			{
				m_StackingPixelsStart = value;
			}
		}

		[Browsable(false)]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		public int StackingPixelsStop
		{
			get
			{
				return m_StackingPixelsStop;
			}
			set
			{
				m_StackingPixelsStop = value;
			}
		}

		protected Rectangle BoundsAlignment
		{
			get
			{
				return m_BoundsAlignment;
			}
			set
			{
				m_BoundsAlignment = value;
			}
		}

		public abstract bool DocksToDataView
		{
			get;
		}

		public abstract bool DocksToPlot
		{
			get;
		}

		public static int BlockSize => 21;

		void IPlotLayout.CalculateDepthPixels(PaintArgs p)
		{
			CalculateDepthPixels(p);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			DockOrder = -1;
			DockSide = AlignmentQuadSide.Left;
			DockMargin = 3;
		}

		private bool ShouldSerializeDockOrder()
		{
			return base.PropertyShouldSerialize("DockOrder");
		}

		private void ResetDockOrder()
		{
			base.PropertyReset("DockOrder");
		}

		private bool ShouldSerializeDockSide()
		{
			return base.PropertyShouldSerialize("DockSide");
		}

		private void ResetDockSide()
		{
			base.PropertyReset("DockSide");
		}

		private bool ShouldSerializeDockMargin()
		{
			return base.PropertyShouldSerialize("DockMargin");
		}

		private void ResetDockMargin()
		{
			base.PropertyReset("DockMargin");
		}

		protected virtual void OnDockSideChanged()
		{
		}

		protected abstract void CalculateDepthPixels(PaintArgs p);

		protected override bool InternalHitTest(MouseEventArgs e)
		{
			if (!Visible)
			{
				return false;
			}
			if (!base.Enabled)
			{
				return false;
			}
			return base.Bounds.Contains(e.X, e.Y);
		}
	}
}
