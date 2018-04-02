using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Limit Base.")]
	public abstract class PlotLimitBase : PlotXYAxisReferenceBase
	{
		private bool m_UserCanMove;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public new Color Color
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.Color = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool UserCanMove
		{
			get
			{
				return m_UserCanMove;
			}
			set
			{
				base.PropertyUpdateDefault("UserCanMove", value);
				if (UserCanMove != value)
				{
					m_UserCanMove = value;
					base.DoPropertyChange(this, "UserCanMove");
				}
			}
		}

		private Color SolidColor => Color;

		private Color HatchForeColor => Color;

		private Color HatchBackColor
		{
			get
			{
				if (ControlBase != null)
				{
					return ControlBase.BackColor;
				}
				return Color.Empty;
			}
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			Color = Color.Red;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.ClippingStyle = PlotClippingStyle.DataView;
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeUserCanMove()
		{
			return base.PropertyShouldSerialize("UserCanMove");
		}

		private void ResetUserCanMove()
		{
			base.PropertyReset("UserCanMove");
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (shouldFocus)
			{
				base.Focus();
			}
		}
	}
}
