using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Data Cursor Multiple Base.")]
	public abstract class PlotDataCursorMultipleBase : PlotDataCursorBase
	{
		private PlotDataCursorMultipleStyle m_Style;

		private PlotDataCursorMultipleStyleMenuItems m_StyleMenuItems;

		private PlotDataCursorDisplay m_Display;

		private double m_Pointer1ValueXY;

		private double m_Pointer2ValueXY;

		private double m_Pointer1ValueX;

		private double m_Pointer2ValueX;

		private double m_Pointer1ValueY;

		private double m_Pointer2ValueY;

		private double m_Pointer1DeltaX;

		private double m_Pointer2DeltaX;

		private double m_Pointer1DeltaY;

		private double m_Pointer2DeltaY;

		private double m_Pointer1InverseDeltaX;

		private double m_Pointer2InverseDeltaX;

		private double m_Pointer1InverseDeltaY;

		private double m_Pointer2InverseDeltaY;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotDataCursorMultipleStyleMenuItems StyleMenuItems
		{
			get
			{
				return m_StyleMenuItems;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Pointer1Position
		{
			get
			{
				return base.Pointer1.Position;
			}
			set
			{
				base.PropertyUpdateDefault("Pointer1Position", value);
				if (Pointer1Position != value)
				{
					base.Pointer1.Position = value;
					base.DoPropertyChange(this, "Pointer1Position");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Pointer2Position
		{
			get
			{
				return base.Pointer2.Position;
			}
			set
			{
				base.PropertyUpdateDefault("Pointer2Position", value);
				if (Pointer2Position != value)
				{
					base.Pointer2.Position = value;
					base.DoPropertyChange(this, "Pointer2Position");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotDataCursorMultipleStyle Style
		{
			get
			{
				return m_Style;
			}
			set
			{
				base.PropertyUpdateDefault("Style", value);
				if (Style != value)
				{
					if (Style == PlotDataCursorMultipleStyle.ValueXY)
					{
						m_Pointer1ValueXY = Pointer1Position;
						m_Pointer2ValueXY = Pointer2Position;
					}
					else if (Style == PlotDataCursorMultipleStyle.ValueX)
					{
						m_Pointer1ValueX = Pointer1Position;
						m_Pointer2ValueX = Pointer2Position;
					}
					else if (Style == PlotDataCursorMultipleStyle.ValueY)
					{
						m_Pointer1ValueY = Pointer1Position;
						m_Pointer2ValueY = Pointer2Position;
					}
					else if (Style == PlotDataCursorMultipleStyle.DeltaX)
					{
						m_Pointer1DeltaX = Pointer1Position;
						m_Pointer2DeltaX = Pointer2Position;
					}
					else if (Style == PlotDataCursorMultipleStyle.DeltaY)
					{
						m_Pointer1DeltaY = Pointer1Position;
						m_Pointer2DeltaY = Pointer2Position;
					}
					else if (Style == PlotDataCursorMultipleStyle.InverseDeltaX)
					{
						m_Pointer1InverseDeltaX = Pointer1Position;
						m_Pointer2InverseDeltaX = Pointer2Position;
					}
					else if (Style == PlotDataCursorMultipleStyle.InverseDeltaY)
					{
						m_Pointer1InverseDeltaY = Pointer1Position;
						m_Pointer2InverseDeltaY = Pointer2Position;
					}
					m_Style = value;
					if (Style == PlotDataCursorMultipleStyle.ValueXY)
					{
						Pointer1Position = m_Pointer1ValueXY;
						Pointer2Position = m_Pointer2ValueXY;
					}
					else if (Style == PlotDataCursorMultipleStyle.ValueX)
					{
						Pointer1Position = m_Pointer1ValueX;
						Pointer2Position = m_Pointer2ValueX;
					}
					else if (Style == PlotDataCursorMultipleStyle.ValueY)
					{
						Pointer1Position = m_Pointer1ValueY;
						Pointer2Position = m_Pointer2ValueY;
					}
					else if (Style == PlotDataCursorMultipleStyle.DeltaX)
					{
						Pointer1Position = m_Pointer1DeltaX;
						Pointer2Position = m_Pointer2DeltaX;
					}
					else if (Style == PlotDataCursorMultipleStyle.DeltaY)
					{
						Pointer1Position = m_Pointer1DeltaY;
						Pointer2Position = m_Pointer2DeltaY;
					}
					else if (Style == PlotDataCursorMultipleStyle.InverseDeltaX)
					{
						Pointer1Position = m_Pointer1InverseDeltaX;
						Pointer2Position = m_Pointer2InverseDeltaX;
					}
					else if (Style == PlotDataCursorMultipleStyle.InverseDeltaY)
					{
						Pointer1Position = m_Pointer1InverseDeltaY;
						Pointer2Position = m_Pointer2InverseDeltaY;
					}
					base.DoPropertyChange(this, "Style");
				}
				SetupPointers();
			}
		}

		protected PlotDataCursorDisplay Display => m_Display;

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Display = new PlotDataCursorDisplay();
			m_StyleMenuItems = new PlotDataCursorMultipleStyleMenuItems();
			base.AddSubClass(StyleMenuItems);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Pointer1Position = 0.5;
			Pointer2Position = 0.5;
			m_Pointer1ValueXY = 0.5;
			m_Pointer2ValueXY = 0.5;
			m_Pointer1ValueX = 0.5;
			m_Pointer2ValueX = 0.5;
			m_Pointer1ValueY = 0.5;
			m_Pointer2ValueY = 0.5;
			m_Pointer1DeltaX = 0.45;
			m_Pointer2DeltaX = 0.55;
			m_Pointer1DeltaY = 0.45;
			m_Pointer2DeltaY = 0.55;
			m_Pointer1InverseDeltaX = 0.45;
			m_Pointer2InverseDeltaX = 0.55;
			m_Pointer1InverseDeltaY = 0.45;
			m_Pointer2InverseDeltaY = 0.55;
			Style = PlotDataCursorMultipleStyle.ValueXY;
		}

		private bool ShouldSerializeStyleMenuItems()
		{
			return ((ISubClassBase)StyleMenuItems).ShouldSerialize();
		}

		private void ResetStyleMenuItems()
		{
			((ISubClassBase)StyleMenuItems).ResetToDefault();
		}

		private bool ShouldSerializePointer1Position()
		{
			return base.PropertyShouldSerialize("Pointer1Position");
		}

		private void ResetPointer1Position()
		{
			base.PropertyReset("Pointer1Position");
		}

		private bool ShouldSerializePointer2Position()
		{
			return base.PropertyShouldSerialize("Pointer2Position");
		}

		private void ResetPointer2Position()
		{
			base.PropertyReset("Pointer2Position");
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		protected override void PopulateContextMenu(ContextMenu menu)
		{
			base.PopulateContextMenu(menu);
			MenuItem menuItem = new MenuItem();
			menuItem.Text = "Style";
			menu.MenuItems.Add(menuItem);
			if (StyleMenuItems.ShowValueXY)
			{
				base.AddMenuItem(menuItem, StyleMenuItems.CaptionValueXY, MenuItemStyleXY_Click, Style == PlotDataCursorMultipleStyle.ValueXY);
			}
			if (StyleMenuItems.ShowValueX)
			{
				base.AddMenuItem(menuItem, StyleMenuItems.CaptionValueX, MenuItemStyleX_Click, Style == PlotDataCursorMultipleStyle.ValueX);
			}
			if (StyleMenuItems.ShowValueY)
			{
				base.AddMenuItem(menuItem, StyleMenuItems.CaptionValueY, MenuItemStyleY_Click, Style == PlotDataCursorMultipleStyle.ValueY);
			}
			if (StyleMenuItems.ShowDeltaX)
			{
				base.AddMenuItem(menuItem, StyleMenuItems.CaptionDeltaX, MenuItemStyleDeltaX_Click, Style == PlotDataCursorMultipleStyle.DeltaX);
			}
			if (StyleMenuItems.ShowDeltaY)
			{
				base.AddMenuItem(menuItem, StyleMenuItems.CaptionDeltaY, MenuItemStyleDeltaY_Click, Style == PlotDataCursorMultipleStyle.DeltaY);
			}
			if (StyleMenuItems.ShowInverseDeltaX)
			{
				base.AddMenuItem(menuItem, StyleMenuItems.CaptionInverseDeltaX, MenuItemStyleInverseDeltaX_Click, Style == PlotDataCursorMultipleStyle.InverseDeltaX);
			}
			if (StyleMenuItems.ShowInverseDeltaY)
			{
				base.AddMenuItem(menuItem, StyleMenuItems.CaptionInverseDeltaY, MenuItemStyleInverseDeltaY_Click, Style == PlotDataCursorMultipleStyle.InverseDeltaY);
			}
		}

		private void MenuItemStyleXY_Click(object sender, EventArgs e)
		{
			Style = PlotDataCursorMultipleStyle.ValueXY;
		}

		private void MenuItemStyleX_Click(object sender, EventArgs e)
		{
			Style = PlotDataCursorMultipleStyle.ValueX;
		}

		private void MenuItemStyleY_Click(object sender, EventArgs e)
		{
			Style = PlotDataCursorMultipleStyle.ValueY;
		}

		private void MenuItemStyleDeltaX_Click(object sender, EventArgs e)
		{
			Style = PlotDataCursorMultipleStyle.DeltaX;
		}

		private void MenuItemStyleDeltaY_Click(object sender, EventArgs e)
		{
			Style = PlotDataCursorMultipleStyle.DeltaY;
		}

		private void MenuItemStyleInverseDeltaX_Click(object sender, EventArgs e)
		{
			Style = PlotDataCursorMultipleStyle.InverseDeltaX;
		}

		private void MenuItemStyleInverseDeltaY_Click(object sender, EventArgs e)
		{
			Style = PlotDataCursorMultipleStyle.InverseDeltaY;
		}
	}
}
