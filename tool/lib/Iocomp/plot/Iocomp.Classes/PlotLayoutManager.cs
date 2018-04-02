using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Layout Manager.")]
	public class PlotLayoutManager
	{
		private Rectangle m_Bounds;

		private Plot m_Plot;

		private bool m_ObjectsDirty;

		private Rectangle m_LayoutRectangle;

		private static PlotLayoutBlockItemDockOrderSorter m_BlockItemDockOrderSorter;

		private static PlotLayoutBlockItemDockPercentStartSorter m_BlockItemDockPercentStartSorter;

		private static PlotLayoutStackingGroupSorter m_StackingGroupSorter;

		private PlotLayoutBaseCollection m_LayoutObjects;

		private PlotLayoutBlockItemCollection m_BlockItems;

		private PlotLayoutStackingGroupCollection m_StackingGroups;

		private PlotLayoutBlockGroupCollection m_DataViewGroups;

		private PlotLayoutBlockGroup m_PlotDockGroup;

		private PlotLayoutBlockGroup m_LayoutGroupOrphan;

		private PlotLayoutBlockBaseCollection m_BlockObjects;

		private PlotLayoutBaseCollection m_ListDataViews;

		private bool m_LayoutDesign;

		private bool m_AutoInsertEnabled;

		public bool AutoInsertEnabled
		{
			get
			{
				return m_AutoInsertEnabled;
			}
			set
			{
				m_AutoInsertEnabled = value;
			}
		}

		private PlotLayoutBaseCollection ListDataViews => m_ListDataViews;

		private PlotLayoutBaseCollection LayoutObjects => m_LayoutObjects;

		private PlotLayoutBlockItemCollection BlockItems => m_BlockItems;

		private PlotLayoutStackingGroupCollection StackingGroups => m_StackingGroups;

		private PlotLayoutBlockGroupCollection DataViewGroups => m_DataViewGroups;

		public PlotLayoutBlockBaseCollection BlockObjects => m_BlockObjects;

		public static PlotLayoutBlockItemDockOrderSorter BlockItemDockOrderSorter => m_BlockItemDockOrderSorter;

		public static PlotLayoutBlockItemDockPercentStartSorter BlockItemDockPercentStartSorter => m_BlockItemDockPercentStartSorter;

		public static PlotLayoutStackingGroupSorter StackingGroupSorter => m_StackingGroupSorter;

		private Rectangle Bounds
		{
			get
			{
				return m_Bounds;
			}
			set
			{
				m_Bounds = value;
			}
		}

		public Rectangle LayoutRectangle
		{
			get
			{
				return m_LayoutRectangle;
			}
			set
			{
				m_LayoutRectangle = value;
			}
		}

		private Plot Plot
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

		private bool LayoutDesign
		{
			get
			{
				return m_LayoutDesign;
			}
			set
			{
				m_LayoutDesign = value;
			}
		}

		private PlotLayoutBlockGroup PlotDockGroup => m_PlotDockGroup;

		private PlotLayoutBlockGroup LayoutGroupOrphan => m_LayoutGroupOrphan;

		public event EventHandler BeforeLayout;

		public event EventHandler AfterLayout;

		static PlotLayoutManager()
		{
			m_BlockItemDockOrderSorter = new PlotLayoutBlockItemDockOrderSorter();
			m_BlockItemDockPercentStartSorter = new PlotLayoutBlockItemDockPercentStartSorter();
			m_StackingGroupSorter = new PlotLayoutStackingGroupSorter();
		}

		public PlotLayoutManager(Plot plot)
		{
			m_LayoutObjects = new PlotLayoutBaseCollection();
			m_BlockItems = new PlotLayoutBlockItemCollection();
			m_StackingGroups = new PlotLayoutStackingGroupCollection();
			m_DataViewGroups = new PlotLayoutBlockGroupCollection();
			m_ListDataViews = new PlotLayoutBaseCollection();
			m_PlotDockGroup = new PlotLayoutBlockGroup();
			m_LayoutGroupOrphan = new PlotLayoutBlockGroup();
			m_BlockObjects = new PlotLayoutBlockBaseCollection();
			plot.PlotObjectAdded += plot_PlotObjectAdded;
			plot.PlotObjectRemoved += plot_PlotObjectRemoved;
			AutoInsertEnabled = true;
			Plot = plot;
		}

		private void plot_PlotObjectAdded(object sender, ObjectEventArgs e)
		{
			m_ObjectsDirty = true;
		}

		private void plot_PlotObjectRemoved(object sender, ObjectEventArgs e)
		{
			m_ObjectsDirty = true;
		}

		private PlotLayoutBlockGroup GetBlockGroup(PlotLayoutDataView dataView)
		{
			foreach (PlotLayoutBlockGroup dataViewGroup in DataViewGroups)
			{
				if (dataViewGroup.Object == dataView)
				{
					return dataViewGroup;
				}
			}
			return null;
		}

		private void AssignGroups()
		{
			PlotDockGroup.Clear();
			LayoutGroupOrphan.Clear();
			StackingGroups.Clear();
			foreach (PlotLayoutBlockGroup dataViewGroup in DataViewGroups)
			{
				dataViewGroup.Clear();
				PlotLayoutStackingGroup plotLayoutStackingGroup = StackingGroups.GetStackingGroup(dataViewGroup.DataView);
				if (plotLayoutStackingGroup == null)
				{
					plotLayoutStackingGroup = new PlotLayoutStackingGroup();
					plotLayoutStackingGroup.Index = dataViewGroup.DataView.StackingGroupIndex;
					StackingGroups.Add(plotLayoutStackingGroup);
				}
				plotLayoutStackingGroup.Add(dataViewGroup);
			}
			foreach (PlotLayoutBlockItem blockItem in BlockItems)
			{
				if (blockItem.Object is PlotLayoutAxis)
				{
					PlotLayoutAxis plotLayoutAxis = blockItem.Object as PlotLayoutAxis;
					PlotLayoutBlockGroup blockGroup = GetBlockGroup(plotLayoutAxis.DockDataView);
					if (blockGroup != null)
					{
						blockGroup.Add(blockItem);
					}
					else
					{
						LayoutGroupOrphan.Add(blockItem);
					}
				}
				else if (blockItem.Object is PlotLayoutDockableAll)
				{
					PlotLayoutDockableAll plotLayoutDockableAll = blockItem.Object as PlotLayoutDockableAll;
					if (plotLayoutDockableAll.DockStyle == PlotDockStyleAll.Plot)
					{
						PlotDockGroup.Add(blockItem);
					}
					else
					{
						PlotLayoutBlockGroup blockGroup = GetBlockGroup(plotLayoutDockableAll.DockDataView);
						if (blockGroup != null)
						{
							blockGroup.Add(blockItem);
						}
						else
						{
							LayoutGroupOrphan.Add(blockItem);
						}
					}
				}
			}
		}

		private void Setup(PaintArgs p, Rectangle rScreen, Rectangle rLayout)
		{
			if (m_ObjectsDirty)
			{
				LayoutObjects.Clear();
				foreach (PlotLayoutBase xAxis in Plot.XAxes)
				{
					LayoutObjects.Add(xAxis);
				}
				foreach (PlotLayoutBase yAxis in Plot.YAxes)
				{
					LayoutObjects.Add(yAxis);
				}
				foreach (PlotLayoutBase legend in Plot.Legends)
				{
					LayoutObjects.Add(legend);
				}
				foreach (PlotLayoutBase table in Plot.Tables)
				{
					LayoutObjects.Add(table);
				}
				foreach (PlotLayoutBase label in Plot.Labels)
				{
					LayoutObjects.Add(label);
				}
				BlockItems.Clear();
				BlockObjects.Clear();
				BlockObjects.Add(PlotDockGroup);
				foreach (PlotLayoutBase layoutObject in LayoutObjects)
				{
					PlotLayoutBlockItem plotLayoutBlockItem = new PlotLayoutBlockItem();
					plotLayoutBlockItem.Object = layoutObject;
					BlockItems.Add(plotLayoutBlockItem);
					BlockObjects.Add(plotLayoutBlockItem);
				}
				DataViewGroups.Clear();
				foreach (PlotLayoutDataView dataView in Plot.DataViews)
				{
					PlotLayoutBlockGroup plotLayoutBlockGroup = new PlotLayoutBlockGroup();
					plotLayoutBlockGroup.Object = dataView;
					plotLayoutBlockGroup.DataView = dataView;
					DataViewGroups.Add(plotLayoutBlockGroup);
					BlockObjects.Add(plotLayoutBlockGroup);
				}
				m_ObjectsDirty = false;
			}
			foreach (PlotLayoutBase layoutObject2 in LayoutObjects)
			{
				layoutObject2.Bounds = rScreen;
				layoutObject2.BoundsClip = rScreen;
				layoutObject2.TextOverlapPixelsStart = 0;
				layoutObject2.TextOverlapPixelsStop = 0;
			}
			for (int i = 0; i < 2; i++)
			{
				AssignGroups();
				foreach (PlotLayoutDataView dataView2 in Plot.DataViews)
				{
					dataView2.Bounds = Rectangle.Empty;
					dataView2.BoundsClip = Rectangle.Empty;
					dataView2.DockDepthPixels = 0;
					dataView2.TextOverlapPixelsStart = 0;
					dataView2.TextOverlapPixelsStop = 0;
				}
				foreach (PlotLayoutBase layoutObject3 in LayoutObjects)
				{
					((IPlotLayout)layoutObject3).CalculateDepthPixels(p);
				}
				PlotDockGroup.SortDockOrders();
				DataViewGroups.SortDockOrders();
				StackingGroups.SortStackingIndex();
				StackingGroups.SortDataViewsDockOrder();
				PlotDockGroup.Calculate(p);
				DataViewGroups.Calculate(p);
				PlotDockGroup.InnerRectangleScreen = new Rectangle(rScreen.Left + PlotDockGroup.DepthLeftScreen, rScreen.Top + PlotDockGroup.DepthTopScreen, rScreen.Width - PlotDockGroup.DepthWidthScreen, rScreen.Height - PlotDockGroup.DepthHeightScreen);
				PlotDockGroup.InnerRectangleLayout = new Rectangle(rLayout.Left + PlotDockGroup.DepthLeftLayout, rLayout.Left + PlotDockGroup.DepthTopLayout, rLayout.Width - PlotDockGroup.DepthWidthLayout, rLayout.Height - PlotDockGroup.DepthHeightLayout);
				StackingGroups.BoundsScreen = PlotDockGroup.InnerRectangleScreen;
				StackingGroups.BoundsLayout = PlotDockGroup.InnerRectangleLayout;
				StackingGroups.Calculate();
				StackingGroups.SetDataViewWidthsAndReferences();
				StackingGroups.CalculateEachStackingGroupBounds();
				StackingGroups.PerformDataViewHeightCalculations();
				StackingGroups.PerformDataViewBoundsCalculations();
				PlotDockGroup.CalculateAndSetAllDockObjectBounds();
				DataViewGroups.CalculateAndSetAllDockObjectBounds();
				BlockItems.TransferBoundsToLayoutObjects();
				DataViewGroups.TransferBoundsToLayoutObjects();
			}
		}

		private void PerformStartStopFixup(PaintArgs p)
		{
			foreach (PlotLayoutBase layoutObject in LayoutObjects)
			{
				Rectangle rectangle;
				if (layoutObject is PlotLayoutDockableAll)
				{
					PlotLayoutDockableAll plotLayoutDockableAll = layoutObject as PlotLayoutDockableAll;
					if (plotLayoutDockableAll.DockStartStyle != 0)
					{
						PlotDataView dockStartDataView = plotLayoutDockableAll.DockStartDataView;
						if (dockStartDataView != null)
						{
							rectangle = ((plotLayoutDockableAll.DockStartStyle != PlotDockStartStopStyleDockableAll.DataViewOuter) ? dockStartDataView.BoundsClip : dockStartDataView.Bounds);
							if (plotLayoutDockableAll.DockVertical)
							{
								plotLayoutDockableAll.Bounds = Rectangle.FromLTRB(rectangle.Left, plotLayoutDockableAll.Bounds.Top, plotLayoutDockableAll.Bounds.Right, plotLayoutDockableAll.Bounds.Bottom);
							}
							else
							{
								plotLayoutDockableAll.Bounds = Rectangle.FromLTRB(plotLayoutDockableAll.Bounds.Left, plotLayoutDockableAll.Bounds.Top, plotLayoutDockableAll.Bounds.Right, rectangle.Bottom);
							}
						}
					}
					if (plotLayoutDockableAll.DockStopStyle != 0)
					{
						PlotDataView dockStartDataView = plotLayoutDockableAll.DockStopDataView;
						if (dockStartDataView != null)
						{
							rectangle = ((plotLayoutDockableAll.DockStopStyle != PlotDockStartStopStyleDockableAll.DataViewOuter) ? dockStartDataView.BoundsClip : dockStartDataView.Bounds);
							if (plotLayoutDockableAll.DockVertical)
							{
								plotLayoutDockableAll.Bounds = Rectangle.FromLTRB(plotLayoutDockableAll.Bounds.Left, plotLayoutDockableAll.Bounds.Top, rectangle.Right, plotLayoutDockableAll.Bounds.Bottom);
							}
							else
							{
								plotLayoutDockableAll.Bounds = Rectangle.FromLTRB(plotLayoutDockableAll.Bounds.Left, rectangle.Top, plotLayoutDockableAll.Bounds.Right, plotLayoutDockableAll.Bounds.Bottom);
							}
						}
					}
				}
				else if (layoutObject is PlotLayoutAxis)
				{
					PlotLayoutAxis plotLayoutAxis = layoutObject as PlotLayoutAxis;
					if (plotLayoutAxis.DockStartStyle != 0)
					{
						PlotLayoutAxis dockStartAxis = plotLayoutAxis.DockStartAxis;
						if (dockStartAxis != null)
						{
							rectangle = dockStartAxis.Bounds;
							if (dockStartAxis.DockVertical)
							{
								plotLayoutAxis.Bounds = Rectangle.FromLTRB(rectangle.Left, plotLayoutAxis.Bounds.Top, plotLayoutAxis.Bounds.Right, plotLayoutAxis.Bounds.Bottom);
							}
							else
							{
								plotLayoutAxis.Bounds = Rectangle.FromLTRB(plotLayoutAxis.Bounds.Left, plotLayoutAxis.Bounds.Top, plotLayoutAxis.Bounds.Right, rectangle.Bottom);
							}
						}
					}
					if (plotLayoutAxis.DockStopStyle != 0)
					{
						PlotLayoutAxis dockStartAxis = plotLayoutAxis.DockStopAxis;
						if (dockStartAxis != null)
						{
							rectangle = dockStartAxis.Bounds;
							if (dockStartAxis.DockVertical)
							{
								plotLayoutAxis.Bounds = Rectangle.FromLTRB(plotLayoutAxis.Bounds.Left, plotLayoutAxis.Bounds.Top, rectangle.Right, plotLayoutAxis.Bounds.Bottom);
							}
							else
							{
								plotLayoutAxis.Bounds = Rectangle.FromLTRB(plotLayoutAxis.Bounds.Left, rectangle.Top, plotLayoutAxis.Bounds.Right, plotLayoutAxis.Bounds.Bottom);
							}
						}
					}
				}
			}
		}

		public void DrawLayout(PaintArgs p, Font font, Color foreColor, Color backColor)
		{
			foreach (IDrawLayoutControl stackingGroup in StackingGroups)
			{
				stackingGroup.Draw(p, font, foreColor, backColor);
			}
			foreach (IDrawLayoutControl dataViewGroup in DataViewGroups)
			{
				dataViewGroup.Draw(p, font, foreColor, backColor);
			}
			foreach (IDrawLayoutControl blockItem in BlockItems)
			{
				blockItem.Draw(p, font, foreColor, backColor);
			}
		}

		public void Execute(PaintArgs p, bool layoutDesign, Rectangle rScreen, Rectangle rLayout)
		{
			if (Plot != null)
			{
				if (this.BeforeLayout != null)
				{
					this.BeforeLayout(Plot, EventArgs.Empty);
				}
				Setup(p, rScreen, m_LayoutRectangle);
				if (this.AfterLayout != null)
				{
					this.AfterLayout(Plot, EventArgs.Empty);
				}
				PerformStartStopFixup(p);
			}
		}
	}
}
