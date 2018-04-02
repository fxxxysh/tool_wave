using Iocomp.Design;
using Iocomp.Interfaces;
using Iocomp.Types;
using System.Drawing;

namespace Iocomp.Classes
{
	public class PlotLayoutViewerDragControl
	{
		public PlotLayoutBlockBase m_Source;

		public PlotLayoutBlockBase m_Destination;

		private bool m_Visible;

		private Rectangle m_Bounds;

		private ControlBase m_ControlBase;

		public PlotDragType SourceType;

		public PlotDragType DestinationType;

		public PlotDragSide DestinationSide;

		public Rectangle DestinationRect;

		public PlotDragDockOrderOffset DestinationDockOrderOffset;

		public Point MousePoint;

		public bool Visible
		{
			get
			{
				return m_Visible;
			}
			set
			{
				if (m_Visible != value)
				{
					m_Visible = value;
					m_ControlBase.UIInvalidate(this);
				}
			}
		}

		public Rectangle Bounds
		{
			get
			{
				return m_Bounds;
			}
			set
			{
				if (m_Bounds != value)
				{
					m_Bounds = value;
					m_ControlBase.UIInvalidate(this);
				}
			}
		}

		public PlotLayoutBlockBase Source
		{
			get
			{
				return m_Source;
			}
			set
			{
				if (m_Source != value)
				{
					m_Source = value;
					if (Source != null)
					{
						if (m_Source.Object is PlotDataView)
						{
							SourceType = PlotDragType.Group;
						}
						else
						{
							SourceType = PlotDragType.Item;
						}
					}
				}
				Update();
			}
		}

		public PlotLayoutBlockBase Destination
		{
			get
			{
				return m_Destination;
			}
			set
			{
				if (m_Destination != value)
				{
					if (m_Destination != null && m_Destination != m_Source)
					{
						m_Destination.BackColor = SystemColors.Control;
					}
					m_Destination = value;
					if (m_Destination != null)
					{
						if (m_Destination.Object == null || m_Destination.Object is PlotDataView)
						{
							DestinationType = PlotDragType.Group;
						}
						else
						{
							DestinationType = PlotDragType.Item;
						}
					}
				}
				Update();
			}
		}

		public PlotLayoutViewerDragControl(ControlBase controlBase)
		{
			m_ControlBase = controlBase;
		}

		public void UpdateDestinationSide()
		{
			Rectangle rectangle;
			if (DestinationType == PlotDragType.Group)
			{
				PlotLayoutBlockGroup plotLayoutBlockGroup = Destination as PlotLayoutBlockGroup;
				rectangle = plotLayoutBlockGroup.InnerRectangleLayout;
				Point[] array = new Point[3];
				Point point = new Point((rectangle.Left + rectangle.Right) / 2, (rectangle.Top + rectangle.Bottom) / 2);
				array[0] = new Point(rectangle.Left, rectangle.Top);
				array[1] = point;
				array[2] = new Point(rectangle.Left, rectangle.Bottom);
				if (HitTest.Contains(MousePoint, array))
				{
					DestinationRect = new Rectangle(rectangle.Left - 10, rectangle.Top, 21, rectangle.Height);
					DestinationSide = PlotDragSide.Left;
					Destination.List = plotLayoutBlockGroup.ListLeft;
					DestinationDockOrderOffset = PlotDragDockOrderOffset.Lower;
				}
				else
				{
					array[0] = new Point(rectangle.Right, rectangle.Top);
					array[1] = point;
					array[2] = new Point(rectangle.Right, rectangle.Bottom);
					if (HitTest.Contains(MousePoint, array))
					{
						DestinationRect = new Rectangle(rectangle.Right - 10, rectangle.Top, 21, rectangle.Height);
						DestinationSide = PlotDragSide.Right;
						Destination.List = plotLayoutBlockGroup.ListRight;
						DestinationDockOrderOffset = PlotDragDockOrderOffset.Lower;
					}
					else
					{
						array[0] = new Point(rectangle.Left, rectangle.Top);
						array[1] = point;
						array[2] = new Point(rectangle.Right, rectangle.Top);
						if (HitTest.Contains(MousePoint, array))
						{
							DestinationRect = new Rectangle(rectangle.Left, rectangle.Top - 10, rectangle.Width, 21);
							DestinationSide = PlotDragSide.Top;
							Destination.List = plotLayoutBlockGroup.ListTop;
							DestinationDockOrderOffset = PlotDragDockOrderOffset.Lower;
						}
						else
						{
							DestinationRect = new Rectangle(rectangle.Left, rectangle.Bottom - 10, rectangle.Width, 21);
							DestinationSide = PlotDragSide.Bottom;
							Destination.List = plotLayoutBlockGroup.ListBottom;
							DestinationDockOrderOffset = PlotDragDockOrderOffset.Lower;
						}
					}
				}
			}
			else
			{
				rectangle = Destination.BoundsLayout;
				iRectangle iRectangle = new iRectangle(rectangle);
				if (Destination.Object == null || Destination.Object.DockHorizontal)
				{
					iRectangle.Width /= 3;
					if (iRectangle.Rectangle.Contains(MousePoint))
					{
						rectangle.Offset(-10, 0);
						DestinationRect = rectangle;
						DestinationSide = PlotDragSide.Left;
						if (Destination.Object.DockLeft)
						{
							DestinationDockOrderOffset = PlotDragDockOrderOffset.Higher;
						}
						else
						{
							DestinationDockOrderOffset = PlotDragDockOrderOffset.Lower;
						}
					}
					else
					{
						iRectangle.OffsetX(7);
						if (iRectangle.Rectangle.Contains(MousePoint))
						{
							DestinationRect = rectangle;
							DestinationSide = PlotDragSide.Stack;
							DestinationDockOrderOffset = PlotDragDockOrderOffset.Same;
						}
						else
						{
							rectangle.Offset(10, 0);
							DestinationRect = rectangle;
							DestinationSide = PlotDragSide.Right;
							if (Destination.Object == null || Destination.Object.DockLeft)
							{
								DestinationDockOrderOffset = PlotDragDockOrderOffset.Lower;
							}
							else
							{
								DestinationDockOrderOffset = PlotDragDockOrderOffset.Higher;
							}
						}
					}
				}
				else
				{
					iRectangle.Height /= 3;
					if (iRectangle.Rectangle.Contains(MousePoint))
					{
						rectangle.Offset(0, -10);
						DestinationRect = rectangle;
						DestinationSide = PlotDragSide.Top;
						if (Destination.Object.DockTop)
						{
							DestinationDockOrderOffset = PlotDragDockOrderOffset.Higher;
						}
						else
						{
							DestinationDockOrderOffset = PlotDragDockOrderOffset.Lower;
						}
					}
					else
					{
						iRectangle.OffsetY(7);
						if (iRectangle.Rectangle.Contains(MousePoint))
						{
							DestinationRect = rectangle;
							DestinationSide = PlotDragSide.Stack;
							DestinationDockOrderOffset = PlotDragDockOrderOffset.Same;
						}
						else
						{
							rectangle.Offset(0, 10);
							DestinationRect = rectangle;
							DestinationSide = PlotDragSide.Bottom;
							if (Destination.Object.DockTop)
							{
								DestinationDockOrderOffset = PlotDragDockOrderOffset.Lower;
							}
							else
							{
								DestinationDockOrderOffset = PlotDragDockOrderOffset.Higher;
							}
						}
					}
				}
			}
		}

		public void Update()
		{
			bool flag = true;
			if (Source == null)
			{
				flag = false;
			}
			if (Destination == null)
			{
				flag = false;
			}
			if (Source == Destination)
			{
				flag = false;
			}
			if (Source != null && Destination != null)
			{
				if (Source.Object is PlotDataView && !(Destination.Object is PlotDataView))
				{
					flag = false;
				}
				if (Source.Object is PlotAxis)
				{
					if (Destination.Object == null)
					{
						flag = false;
					}
					else if (Destination.Object is PlotLayoutDockableAll && !(Destination.Object as PlotLayoutDockableAll).DocksToDataView)
					{
						flag = false;
					}
				}
			}
			if (!flag)
			{
				Visible = false;
			}
			else
			{
				Visible = true;
				UpdateDestinationSide();
				if (DestinationType == PlotDragType.Group)
				{
					Rectangle innerRectangleLayout = (Destination as PlotLayoutBlockGroup).InnerRectangleLayout;
				}
				else
				{
					Rectangle boundsLayout = Destination.BoundsLayout;
				}
				Bounds = DestinationRect;
				Destination.BackColor = Color.Wheat;
			}
		}

		public void FixupStacking(PlotLayoutBlockItemCollection list, int targetIndex)
		{
			PlotLayoutBlockItemCollection plotLayoutBlockItemCollection = new PlotLayoutBlockItemCollection();
			foreach (PlotLayoutBlockItem item in list)
			{
				if (item.Object.DockOrder == targetIndex)
				{
					plotLayoutBlockItemCollection.Add(item);
				}
			}
			plotLayoutBlockItemCollection.SortDockPercentStart();
			for (int i = 0; i < plotLayoutBlockItemCollection.Count; i++)
			{
				PlotLayoutBlockItem plotLayoutBlockItem2 = plotLayoutBlockItemCollection[i];
				PlotLayoutDockableDataView plotLayoutDockableDataView = plotLayoutBlockItem2.Object as PlotLayoutDockableDataView;
				if (plotLayoutDockableDataView != null)
				{
					plotLayoutDockableDataView.DockPercentStart = (double)i * 1.0 / (double)plotLayoutBlockItemCollection.Count;
					plotLayoutDockableDataView.DockPercentStop = plotLayoutDockableDataView.DockPercentStart + 1.0 / (double)plotLayoutBlockItemCollection.Count;
				}
			}
		}

		public void DropDockableAllOnDockableAll()
		{
			PlotLayoutDockableDataView plotLayoutDockableDataView = Source.Object as PlotLayoutDockableDataView;
			PlotLayoutDockableDataView plotLayoutDockableDataView2 = Destination.Object as PlotLayoutDockableDataView;
			int dockOrder = plotLayoutDockableDataView.DockOrder;
			bool flag = plotLayoutDockableDataView.DockDataViewName == plotLayoutDockableDataView2.DockDataViewName && plotLayoutDockableDataView.DockOrder == plotLayoutDockableDataView2.DockOrder && plotLayoutDockableDataView.DockSide == plotLayoutDockableDataView2.DockSide;
			plotLayoutDockableDataView.DockDataViewName = plotLayoutDockableDataView2.DockDataViewName;
			plotLayoutDockableDataView.DockSide = plotLayoutDockableDataView2.DockSide;
			if (DestinationDockOrderOffset == PlotDragDockOrderOffset.Higher)
			{
				if (Destination.List != null)
				{
					Source.List.Remove(Source);
					FixupStacking(Source.List, dockOrder);
					int num = Destination.Object.DockOrder + 1;
					foreach (PlotLayoutBlockItem item in Destination.List)
					{
						if (item.Object.DockOrder >= num)
						{
							item.Object.DockOrder++;
						}
					}
					plotLayoutDockableDataView.DockOrder = num;
					plotLayoutDockableDataView.DockPercentStart = 0.0;
					plotLayoutDockableDataView.DockPercentStop = 1.0;
				}
			}
			else if (DestinationDockOrderOffset == PlotDragDockOrderOffset.Lower)
			{
				if (Destination.List != null)
				{
					Source.List.Remove(Source);
					FixupStacking(Source.List, dockOrder);
					int num = Destination.Object.DockOrder;
					foreach (PlotLayoutBlockItem item2 in Destination.List)
					{
						if (item2.Object.DockOrder >= num)
						{
							item2.Object.DockOrder++;
						}
					}
					plotLayoutDockableDataView.DockOrder = num;
					plotLayoutDockableDataView.DockPercentStart = 0.0;
					plotLayoutDockableDataView.DockPercentStop = 1.0;
				}
			}
			else if (DestinationDockOrderOffset == PlotDragDockOrderOffset.Same)
			{
				if (!flag)
				{
					plotLayoutDockableDataView.DockOrder = plotLayoutDockableDataView2.DockOrder;
					Source.List.Remove(Source);
					Destination.List.Add(Source as PlotLayoutBlockItem);
					FixupStacking(Destination.List, plotLayoutDockableDataView2.DockOrder);
					FixupStacking(Source.List, dockOrder);
				}
				else
				{
					double dockPercentStart = plotLayoutDockableDataView.DockPercentStart;
					double dockPercentStop = plotLayoutDockableDataView.DockPercentStop;
					plotLayoutDockableDataView.DockPercentStart = plotLayoutDockableDataView2.DockPercentStart;
					plotLayoutDockableDataView.DockPercentStop = plotLayoutDockableDataView2.DockPercentStop;
					plotLayoutDockableDataView2.DockPercentStart = dockPercentStart;
					plotLayoutDockableDataView2.DockPercentStop = dockPercentStop;
				}
			}
		}

		public void DropDockableDataViewOnDataView()
		{
			PlotLayoutDockableDataView plotLayoutDockableDataView = Source.Object as PlotLayoutDockableDataView;
			PlotLayoutDataView plotLayoutDataView = Destination.Object as PlotLayoutDataView;
			int dockOrder = plotLayoutDockableDataView.DockOrder;
			plotLayoutDockableDataView.DockDataViewName = plotLayoutDataView.Name;
			if (DestinationSide == PlotDragSide.Left)
			{
				plotLayoutDockableDataView.DockSide = AlignmentQuadSide.Left;
			}
			else if (DestinationSide == PlotDragSide.Right)
			{
				plotLayoutDockableDataView.DockSide = AlignmentQuadSide.Right;
			}
			else if (DestinationSide == PlotDragSide.Top)
			{
				plotLayoutDockableDataView.DockSide = AlignmentQuadSide.Top;
			}
			else if (DestinationSide == PlotDragSide.Bottom)
			{
				plotLayoutDockableDataView.DockSide = AlignmentQuadSide.Bottom;
			}
			Source.List.Remove(Source);
			FixupStacking(Source.List, dockOrder);
			if (Destination.List != null)
			{
				if (Destination.List.Count != 0)
				{
					plotLayoutDockableDataView.DockOrder = Destination.List[0].Object.DockOrder - 1;
				}
				else
				{
					plotLayoutDockableDataView.DockOrder = 0;
				}
				plotLayoutDockableDataView.DockPercentStart = 0.0;
				plotLayoutDockableDataView.DockPercentStop = 1.0;
			}
		}

		public void DropDockableAllOnPlotDockGroup()
		{
			PlotLayoutDockableAll plotLayoutDockableAll = Source.Object as PlotLayoutDockableAll;
			plotLayoutDockableAll.DockDataViewName = "";
			PlotLayoutBlockItemCollection plotLayoutBlockItemCollection;
			if (DestinationSide == PlotDragSide.Left)
			{
				plotLayoutDockableAll.DockSide = AlignmentQuadSide.Left;
				plotLayoutBlockItemCollection = (Destination as PlotLayoutBlockGroup).ListLeft;
			}
			else if (DestinationSide == PlotDragSide.Right)
			{
				plotLayoutDockableAll.DockSide = AlignmentQuadSide.Right;
				plotLayoutBlockItemCollection = (Destination as PlotLayoutBlockGroup).ListRight;
			}
			else if (DestinationSide == PlotDragSide.Top)
			{
				plotLayoutDockableAll.DockSide = AlignmentQuadSide.Top;
				plotLayoutBlockItemCollection = (Destination as PlotLayoutBlockGroup).ListTop;
			}
			else
			{
				plotLayoutDockableAll.DockSide = AlignmentQuadSide.Bottom;
				plotLayoutBlockItemCollection = (Destination as PlotLayoutBlockGroup).ListBottom;
			}
			Source.List.Remove(Source);
			FixupStacking(Source.List, plotLayoutDockableAll.DockOrder);
			if (Destination.List != null)
			{
				if (plotLayoutBlockItemCollection.Count != 0)
				{
					plotLayoutDockableAll.DockOrder = plotLayoutBlockItemCollection[0].Object.DockOrder - 1;
				}
				else
				{
					plotLayoutDockableAll.DockOrder = 0;
				}
				plotLayoutDockableAll.DockPercentStart = 0.0;
				plotLayoutDockableAll.DockPercentStop = 1.0;
			}
		}

		public void DropDataViewOnDataView()
		{
			PlotLayoutDataView plotLayoutDataView = Source.Object as PlotLayoutDataView;
			PlotLayoutDataView plotLayoutDataView2 = Destination.Object as PlotLayoutDataView;
			if (DestinationSide == PlotDragSide.Top || DestinationSide == PlotDragSide.Bottom)
			{
				plotLayoutDataView.StackingGroupIndex = plotLayoutDataView2.StackingGroupIndex;
				if (DestinationSide == PlotDragSide.Top)
				{
					foreach (PlotLayoutBlockGroup item in plotLayoutDataView2.StackingGroup.Items)
					{
						if (item.Object.DockOrder > plotLayoutDataView2.DockOrder)
						{
							item.Object.DockOrder++;
						}
					}
					plotLayoutDataView.DockOrder = plotLayoutDataView2.DockOrder + 1;
				}
				else
				{
					foreach (PlotLayoutBlockGroup item2 in plotLayoutDataView2.StackingGroup.Items)
					{
						if (item2.Object.DockOrder < plotLayoutDataView2.DockOrder)
						{
							item2.Object.DockOrder--;
						}
					}
					plotLayoutDataView.DockOrder = plotLayoutDataView2.DockOrder - 1;
				}
			}
			else
			{
				plotLayoutDataView.StackingGroupIndex = plotLayoutDataView2.StackingGroupIndex;
				if (DestinationSide == PlotDragSide.Left)
				{
					foreach (PlotLayoutDataView dataView in ((IPlotObject)plotLayoutDataView2).Plot.DataViews)
					{
						if (dataView.StackingGroupIndex < plotLayoutDataView2.StackingGroupIndex)
						{
							dataView.StackingGroupIndex--;
						}
					}
					plotLayoutDataView.DockOrder = 0;
					plotLayoutDataView.StackingGroupIndex = plotLayoutDataView2.StackingGroupIndex - 1;
				}
				else
				{
					foreach (PlotLayoutDataView dataView2 in ((IPlotObject)plotLayoutDataView2).Plot.DataViews)
					{
						if (dataView2.StackingGroupIndex > plotLayoutDataView2.StackingGroupIndex)
						{
							dataView2.StackingGroupIndex++;
						}
					}
					plotLayoutDataView.DockOrder = 0;
					plotLayoutDataView.StackingGroupIndex = plotLayoutDataView2.StackingGroupIndex + 1;
				}
			}
		}

		public void CompleteDrag()
		{
			if (Visible)
			{
				PlotLayoutAxis plotLayoutAxis = Source.Object as PlotLayoutAxis;
				PlotLayoutAxis plotLayoutAxis2 = Destination.Object as PlotLayoutAxis;
				PlotLayoutDockableAll plotLayoutDockableAll = Source.Object as PlotLayoutDockableAll;
				PlotLayoutDockableAll plotLayoutDockableAll2 = Destination.Object as PlotLayoutDockableAll;
				PlotLayoutDockableDataView plotLayoutDockableDataView = Source.Object as PlotLayoutDockableDataView;
				PlotLayoutDockableDataView plotLayoutDockableDataView2 = Destination.Object as PlotLayoutDockableDataView;
				PlotLayoutDataView plotLayoutDataView = Source.Object as PlotLayoutDataView;
				PlotLayoutDataView plotLayoutDataView2 = Destination.Object as PlotLayoutDataView;
				if (plotLayoutDataView != null && plotLayoutDataView2 != null)
				{
					DropDataViewOnDataView();
				}
				else if (plotLayoutDockableDataView != null)
				{
					if (plotLayoutDockableDataView != null && plotLayoutDockableDataView2 != null)
					{
						DropDockableAllOnDockableAll();
					}
					else if (plotLayoutDockableDataView != null && plotLayoutDataView2 != null)
					{
						DropDockableDataViewOnDataView();
					}
					else if (plotLayoutDockableAll != null && Destination.Object == null)
					{
						DropDockableAllOnPlotDockGroup();
					}
					if (plotLayoutAxis != null && plotLayoutAxis2 != null)
					{
						plotLayoutAxis.DockStyle = plotLayoutAxis2.DockStyle;
					}
					else if (plotLayoutDockableAll != null && plotLayoutDockableAll2 != null)
					{
						plotLayoutDockableAll.DockStyle = plotLayoutDockableAll2.DockStyle;
					}
					else if (plotLayoutDockableAll != null && plotLayoutAxis2 != null)
					{
						plotLayoutDockableAll.DockStyle = PlotDockStyleAll.DataView;
					}
					else if (plotLayoutDockableAll != null && plotLayoutDataView2 != null)
					{
						plotLayoutDockableAll.DockStyle = PlotDockStyleAll.DataView;
					}
					else if (plotLayoutAxis != null && plotLayoutDataView2 != null)
					{
						plotLayoutAxis.DockStyle = PlotDockStyleAxis.DataView;
					}
					else if (plotLayoutDockableAll != null && Destination.Object == null)
					{
						plotLayoutDockableAll.DockStyle = PlotDockStyleAll.Plot;
					}
				}
				(m_ControlBase as PlotLayoutViewer).MakeDirty();
			}
		}

		public void Draw(PaintArgs p, Font font, Color foreColor, Color backColor)
		{
			if (Source != null && Visible)
			{
				string s = Source.Object.ToString();
				Rectangle bounds = Bounds;
				DrawStringFormat genericDefault = DrawStringFormat.GenericDefault;
				genericDefault.Alignment = StringAlignment.Center;
				genericDefault.LineAlignment = StringAlignment.Center;
				p.Graphics.FillRectangle(p.Graphics.Brush(backColor), bounds);
				BorderSimple.Draw(p, bounds, BorderStyleSimple.Raised, backColor);
				TextRotation rotation = (Destination.Object == null || Destination.Object is PlotDataView) ? ((DestinationSide != 0) ? ((DestinationSide == PlotDragSide.Right) ? TextRotation.X090 : TextRotation.X000) : TextRotation.X270) : ((!Destination.Object.DockLeft) ? (Destination.Object.DockRight ? TextRotation.X090 : TextRotation.X000) : TextRotation.X270);
				p.Graphics.DrawRotatedText(s, font, foreColor, bounds, rotation, genericDefault);
			}
		}
	}
}
