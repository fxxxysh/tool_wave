using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Data Cursor Multiple Style Menu Items")]
	public class PlotDataCursorMultipleStyleMenuItems : SubClassBase
	{
		private bool m_ShowValueXY;

		private bool m_ShowValueX;

		private bool m_ShowValueY;

		private bool m_ShowDeltaX;

		private bool m_ShowDeltaY;

		private bool m_ShowInverseDeltaX;

		private bool m_ShowInverseDeltaY;

		private string m_CaptionValueXY;

		private string m_CaptionValueX;

		private string m_CaptionValueY;

		private string m_CaptionDeltaX;

		private string m_CaptionDeltaY;

		private string m_CaptionInverseDeltaX;

		private string m_CaptionInverseDeltaY;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ShowValueXY
		{
			get
			{
				return m_ShowValueXY;
			}
			set
			{
				base.PropertyUpdateDefault("ShowValueXY", value);
				if (ShowValueXY != value)
				{
					m_ShowValueXY = value;
					base.DoPropertyChange(this, "ShowValueXY");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ShowValueX
		{
			get
			{
				return m_ShowValueX;
			}
			set
			{
				base.PropertyUpdateDefault("ShowValueX", value);
				if (ShowValueX != value)
				{
					m_ShowValueX = value;
					base.DoPropertyChange(this, "ShowValueX");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ShowValueY
		{
			get
			{
				return m_ShowValueY;
			}
			set
			{
				base.PropertyUpdateDefault("ShowValueY", value);
				if (ShowValueY != value)
				{
					m_ShowValueY = value;
					base.DoPropertyChange(this, "ShowValueY");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ShowDeltaX
		{
			get
			{
				return m_ShowDeltaX;
			}
			set
			{
				base.PropertyUpdateDefault("ShowDeltaX", value);
				if (ShowDeltaX != value)
				{
					m_ShowDeltaX = value;
					base.DoPropertyChange(this, "ShowDeltaX");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ShowDeltaY
		{
			get
			{
				return m_ShowDeltaY;
			}
			set
			{
				base.PropertyUpdateDefault("ShowDeltaY", value);
				if (ShowDeltaY != value)
				{
					m_ShowDeltaY = value;
					base.DoPropertyChange(this, "ShowDeltaY");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ShowInverseDeltaX
		{
			get
			{
				return m_ShowInverseDeltaX;
			}
			set
			{
				base.PropertyUpdateDefault("ShowInverseDeltaX", value);
				if (ShowInverseDeltaX != value)
				{
					m_ShowInverseDeltaX = value;
					base.DoPropertyChange(this, "ShowInverseDeltaX");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ShowInverseDeltaY
		{
			get
			{
				return m_ShowInverseDeltaY;
			}
			set
			{
				base.PropertyUpdateDefault("ShowInverseDeltaY", value);
				if (ShowInverseDeltaY != value)
				{
					m_ShowInverseDeltaY = value;
					base.DoPropertyChange(this, "ShowInverseDeltaY");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string CaptionValueXY
		{
			get
			{
				return m_CaptionValueXY;
			}
			set
			{
				base.PropertyUpdateDefault("CaptionValueXY", value);
				if (CaptionValueXY != value)
				{
					m_CaptionValueXY = value;
					base.DoPropertyChange(this, "CaptionValueXY");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string CaptionValueX
		{
			get
			{
				return m_CaptionValueX;
			}
			set
			{
				base.PropertyUpdateDefault("CaptionValueX", value);
				if (CaptionValueX != value)
				{
					m_CaptionValueX = value;
					base.DoPropertyChange(this, "CaptionValueX");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string CaptionValueY
		{
			get
			{
				return m_CaptionValueY;
			}
			set
			{
				base.PropertyUpdateDefault("CaptionValueY", value);
				if (CaptionValueY != value)
				{
					m_CaptionValueY = value;
					base.DoPropertyChange(this, "CaptionValueY");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string CaptionDeltaX
		{
			get
			{
				return m_CaptionDeltaX;
			}
			set
			{
				base.PropertyUpdateDefault("CaptionDeltaX", value);
				if (CaptionDeltaX != value)
				{
					m_CaptionDeltaX = value;
					base.DoPropertyChange(this, "CaptionDeltaX");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string CaptionDeltaY
		{
			get
			{
				return m_CaptionDeltaY;
			}
			set
			{
				base.PropertyUpdateDefault("CaptionDeltaY", value);
				if (CaptionDeltaY != value)
				{
					m_CaptionDeltaY = value;
					base.DoPropertyChange(this, "CaptionDeltaY");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string CaptionInverseDeltaX
		{
			get
			{
				return m_CaptionInverseDeltaX;
			}
			set
			{
				base.PropertyUpdateDefault("CaptionInverseDeltaX", value);
				if (CaptionInverseDeltaX != value)
				{
					m_CaptionInverseDeltaX = value;
					base.DoPropertyChange(this, "CaptionInverseDeltaX");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string CaptionInverseDeltaY
		{
			get
			{
				return m_CaptionInverseDeltaY;
			}
			set
			{
				base.PropertyUpdateDefault("CaptionInverseDeltaY", value);
				if (CaptionInverseDeltaY != value)
				{
					m_CaptionInverseDeltaY = value;
					base.DoPropertyChange(this, "CaptionInverseDeltaY");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Data-Cursor Style Menu Items";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotDataCursorMultipleStyleMenuItemsEditorPlugIn";
		}

		public PlotDataCursorMultipleStyleMenuItems()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			ShowValueXY = true;
			ShowValueX = true;
			ShowValueY = true;
			ShowDeltaX = true;
			ShowDeltaY = true;
			ShowInverseDeltaX = true;
			ShowInverseDeltaY = false;
			CaptionValueXY = "Value-XY";
			CaptionValueX = "Value-X";
			CaptionValueY = "Value-Y";
			CaptionDeltaX = "Period";
			CaptionDeltaY = "Peak-Peak";
			CaptionInverseDeltaX = "Frequency";
			CaptionInverseDeltaY = "Inverse Delta-Y";
		}

		private bool ShouldSerializeShowValueXY()
		{
			return base.PropertyShouldSerialize("ShowValueXY");
		}

		private void ResetShowValueXY()
		{
			base.PropertyReset("ShowValueXY");
		}

		private bool ShouldSerializeShowValueX()
		{
			return base.PropertyShouldSerialize("ShowValueX");
		}

		private void ResetShowValueX()
		{
			base.PropertyReset("ShowValueX");
		}

		private bool ShouldSerializeShowValueY()
		{
			return base.PropertyShouldSerialize("ShowValueY");
		}

		private void ResetShowValueY()
		{
			base.PropertyReset("ShowValueY");
		}

		private bool ShouldSerializeShowDeltaX()
		{
			return base.PropertyShouldSerialize("ShowDeltaX");
		}

		private void ResetShowDeltaX()
		{
			base.PropertyReset("ShowDeltaX");
		}

		private bool ShouldSerializeShowDeltaY()
		{
			return base.PropertyShouldSerialize("ShowDeltaY");
		}

		private void ResetShowDeltaY()
		{
			base.PropertyReset("ShowDeltaY");
		}

		private bool ShouldSerializeShowInverseDeltaX()
		{
			return base.PropertyShouldSerialize("ShowInverseDeltaX");
		}

		private void ResetShowInverseDeltaX()
		{
			base.PropertyReset("ShowInverseDeltaX");
		}

		private bool ShouldSerializeShowInverseDeltaY()
		{
			return base.PropertyShouldSerialize("ShowInverseDeltaY");
		}

		private void ResetShowInverseDeltaY()
		{
			base.PropertyReset("ShowInverseDeltaY");
		}

		private bool ShouldSerializeCaptionValueXY()
		{
			return base.PropertyShouldSerialize("CaptionValueXY");
		}

		private void ResetCaptionValueXY()
		{
			base.PropertyReset("CaptionValueXY");
		}

		private bool ShouldSerializeCaptionValueX()
		{
			return base.PropertyShouldSerialize("CaptionValueX");
		}

		private void ResetCaptionValueX()
		{
			base.PropertyReset("CaptionValueX");
		}

		private bool ShouldSerializeCaptionValueY()
		{
			return base.PropertyShouldSerialize("CaptionValueY");
		}

		private void ResetCaptionValueY()
		{
			base.PropertyReset("CaptionValueY");
		}

		private bool ShouldSerializeCaptionDeltaX()
		{
			return base.PropertyShouldSerialize("CaptionDeltaX");
		}

		private void ResetCaptionDeltaX()
		{
			base.PropertyReset("CaptionDeltaX");
		}

		private bool ShouldSerializeCaptionDeltaY()
		{
			return base.PropertyShouldSerialize("CaptionDeltaY");
		}

		private void ResetCaptionDeltaY()
		{
			base.PropertyReset("CaptionDeltaY");
		}

		private bool ShouldSerializeCaptionInverseDeltaX()
		{
			return base.PropertyShouldSerialize("CaptionInverseDeltaX");
		}

		private void ResetCaptionInverseDeltaX()
		{
			base.PropertyReset("CaptionInverseDeltaX");
		}

		private bool ShouldSerializeCaptionInverseDeltaY()
		{
			return base.PropertyShouldSerialize("CaptionInverseDeltaY");
		}

		private void ResetCaptionInverseDeltaY()
		{
			base.PropertyReset("CaptionInverseDeltaY");
		}
	}
}
