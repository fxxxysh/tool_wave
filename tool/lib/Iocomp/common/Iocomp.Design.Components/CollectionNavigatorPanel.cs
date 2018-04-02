using Iocomp.Classes;
using Iocomp.Delegates;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ToolboxBitmaps;

namespace Iocomp.Design.Components
{
	[ToolboxItem(false)]
	public class CollectionNavigatorPanel : UserControl
	{
		private ListBox ItemListBox;

		private Button RemoveButton;

		private Button AddButton;

		private Button MoveUpButton;

		private Button MoveDownButton;

		private Container components;

		private Button AddClassButton;

		private ContextMenu ContextMenu1;

		private bool m_AllowEdit;

		private Type[] m_ClassTypes;

		public bool AllowEdit
		{
			get
			{
				return m_AllowEdit;
			}
			set
			{
				m_AllowEdit = value;
				AddButton.Visible = m_AllowEdit;
				RemoveButton.Visible = m_AllowEdit;
				OnSizeChanged(EventArgs.Empty);
			}
		}

		public Type[] Types
		{
			get
			{
				return m_ClassTypes;
			}
			set
			{
				m_ClassTypes = value;
				if (value.Length > 1)
				{
					AddClassButton.Visible = true;
					foreach (Type type in value)
					{
						MenuItem menuItem = new MenuItem(type.Name);
						menuItem.Click += AMenuItem_Click;
						ContextMenu1.MenuItems.Add(menuItem);
					}
				}
			}
		}

		public ListBox.ObjectCollection Items => ItemListBox.Items;

		public object SelectedObject
		{
			get
			{
				if (ItemListBox.SelectedIndex == -1)
				{
					return null;
				}
				return ItemListBox.Items[ItemListBox.SelectedIndex];
			}
			set
			{
				if (ItemListBox.Items.Count != 0)
				{
					ItemListBox.SelectedItem = value;
				}
			}
		}

		public int LastIndex => ItemListBox.Items.Count - 1;

		public bool Empty => ItemListBox.Items.Count == 0;

		public int SelectedIndex
		{
			get
			{
				return ItemListBox.SelectedIndex;
			}
			set
			{
				ItemListBox.SelectedIndex = value;
			}
		}

		public event EventHandler SelectedIndexChanged;

		public event ObjectMoveIndexEventHandler ItemMoved;

		public event TypeEventHandler ItemAdd;

		public event EventHandler ItemRemove;

		public CollectionNavigatorPanel()
		{
			InitializeComponent();
			AllowEdit = true;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			ItemListBox = new ListBox();
			RemoveButton = new Button();
			AddButton = new Button();
			MoveUpButton = new Button();
			MoveDownButton = new Button();
			AddClassButton = new Button();
			ContextMenu1 = new ContextMenu();
			base.SuspendLayout();
			ItemListBox.HorizontalScrollbar = true;
			ItemListBox.Location = new Point(5, 4);
			ItemListBox.Name = "ItemListBox";
			ItemListBox.Size = new Size(163, 121);
			ItemListBox.TabIndex = 0;
			ItemListBox.SelectedIndexChanged += ItemListBox_SelectedIndexChanged;
			RemoveButton.Enabled = false;
			RemoveButton.Location = new Point(104, 128);
			RemoveButton.Name = "RemoveButton";
			RemoveButton.Size = new Size(65, 23);
			RemoveButton.TabIndex = 5;
			RemoveButton.Text = "Remove";
			RemoveButton.Click += RemoveButton_Click;
			AddButton.Location = new Point(5, 128);
			AddButton.Name = "AddButton";
			AddButton.Size = new Size(65, 23);
			AddButton.TabIndex = 3;
			AddButton.Text = "Add";
			AddButton.Click += AddButton_Click;
			MoveUpButton.Location = new Point(168, 0);
			MoveUpButton.Name = "MoveUpButton";
			MoveUpButton.Size = new Size(23, 25);
			MoveUpButton.TabIndex = 1;
			MoveUpButton.Click += MoveUpButton_Click;
			MoveDownButton.Location = new Point(168, 40);
			MoveDownButton.Name = "MoveDownButton";
			MoveDownButton.Size = new Size(23, 25);
			MoveDownButton.TabIndex = 2;
			MoveDownButton.Click += MoveDownButton_Click;
			AddClassButton.Location = new Point(69, 128);
			AddClassButton.Name = "AddClassButton";
			AddClassButton.Size = new Size(16, 23);
			AddClassButton.TabIndex = 4;
			AddClassButton.Visible = false;
			AddClassButton.Click += AddClassButton_Click;
			base.Controls.Add(AddClassButton);
			base.Controls.Add(MoveDownButton);
			base.Controls.Add(MoveUpButton);
			base.Controls.Add(AddButton);
			base.Controls.Add(RemoveButton);
			base.Controls.Add(ItemListBox);
			base.Name = "CollectionNavigatorPanel";
			base.Size = new Size(195, 152);
			base.Load += CollectionNavigatorPanel_Load;
			base.ResumeLayout(false);
		}

		protected override void OnLocationChanged(EventArgs e)
		{
			base.OnLocationChanged(e);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
		}

		public void DoLayout()
		{
			if (AllowEdit)
			{
				ItemListBox.Height = base.Height - 10 - AddButton.Height - 5;
			}
			else
			{
				ItemListBox.Height = base.Height - 10;
			}
			ItemListBox.Location = new Point(5, 5);
			ItemListBox.Width = base.Width - 10 - 5 - MoveUpButton.Width;
			MoveUpButton.Left = ItemListBox.Right + 5;
			MoveDownButton.Left = MoveUpButton.Left;
			MoveUpButton.Top = ItemListBox.Top;
			MoveDownButton.Top = MoveUpButton.Bottom + 10;
			AddButton.Left = ItemListBox.Left;
			RemoveButton.Left = ItemListBox.Right - RemoveButton.Width;
			AddButton.Top = ItemListBox.Bottom + 5;
			RemoveButton.Top = AddButton.Top;
			AddClassButton.Left = AddButton.Right;
			AddClassButton.Top = AddButton.Top;
		}

		private void ItemListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateButtons();
			OnSelectedIndexChanged();
		}

		public void SelectFirst()
		{
			if (ItemListBox.Items.Count != 0)
			{
				ItemListBox.SelectedIndex = 0;
			}
		}

		public void SelectLast()
		{
			if (ItemListBox.Items.Count != 0)
			{
				ItemListBox.SelectedIndex = ItemListBox.Items.Count - 1;
			}
		}

		private void OnSelectedIndexChanged()
		{
			if (this.SelectedIndexChanged != null)
			{
				this.SelectedIndexChanged(this, EventArgs.Empty);
			}
		}

		private void OnItemMoved(object instance, int oldIndex, int newIndex)
		{
			if (this.ItemMoved != null)
			{
				this.ItemMoved(this, new ObjectMoveIndexEventArgs(instance, oldIndex, newIndex));
			}
		}

		private void OnItemAdd(Type value)
		{
			if (this.ItemAdd != null)
			{
				this.ItemAdd(this, new TypeEventArgs(value));
			}
		}

		private void OnItemRemove()
		{
			if (this.ItemRemove != null)
			{
				this.ItemRemove(this, EventArgs.Empty);
			}
		}

		public void BeginUpdate()
		{
			ItemListBox.BeginUpdate();
		}

		public void EndUpdate()
		{
			ItemListBox.EndUpdate();
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			OnItemRemove();
			UpdateButtons();
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			if (m_ClassTypes != null && m_ClassTypes.Length != 0)
			{
				OnItemAdd(m_ClassTypes[0]);
				UpdateButtons();
			}
		}

		private void AMenuItem_Click(object sender, EventArgs e)
		{
			if (m_ClassTypes != null && m_ClassTypes.Length != 0)
			{
				OnItemAdd(m_ClassTypes[(sender as MenuItem).Index]);
				UpdateButtons();
			}
		}

		private void AddClassButton_Click(object sender, EventArgs e)
		{
			ContextMenu1.Show(AddButton, new Point(0, AddButton.Height));
		}

		private void MoveUpButton_Click(object sender, EventArgs e)
		{
			int selectedIndex = ItemListBox.SelectedIndex;
			if (selectedIndex >= 1)
			{
				object obj = ItemListBox.Items[selectedIndex];
				ItemListBox.Items.RemoveAt(selectedIndex);
				int num = selectedIndex - 1;
				ItemListBox.Items.Insert(num, obj);
				ItemListBox.SelectedIndex = num;
				OnItemMoved(obj, selectedIndex, num);
				UpdateButtons();
			}
		}

		private void MoveDownButton_Click(object sender, EventArgs e)
		{
			int selectedIndex = ItemListBox.SelectedIndex;
			if (selectedIndex != ItemListBox.Items.Count - 1)
			{
				object obj = ItemListBox.Items[selectedIndex];
				ItemListBox.Items.RemoveAt(selectedIndex);
				int num = selectedIndex + 1;
				ItemListBox.Items.Insert(num, obj);
				ItemListBox.SelectedIndex = num;
				OnItemMoved(obj, selectedIndex, num);
				UpdateButtons();
			}
		}

		private void UpdateButtons()
		{
			RemoveButton.Enabled = true;
			MoveUpButton.Enabled = true;
			MoveDownButton.Enabled = true;
			if (ItemListBox.SelectedIndex == -1)
			{
				RemoveButton.Enabled = false;
			}
			if (ItemListBox.SelectedIndex == -1)
			{
				MoveUpButton.Enabled = false;
			}
			if (ItemListBox.SelectedIndex == -1)
			{
				MoveDownButton.Enabled = false;
			}
			if (ItemListBox.SelectedIndex == 0)
			{
				MoveUpButton.Enabled = false;
			}
			if (ItemListBox.SelectedIndex == ItemListBox.Items.Count - 1)
			{
				MoveDownButton.Enabled = false;
			}
		}

		private void CollectionNavigatorPanel_Load(object sender, EventArgs e)
		{
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(Access), "ARW08UP.ICO");
			if (manifestResourceStream != null)
			{
				Icon original = new Icon(manifestResourceStream);
				original = new Icon(original, new Size(16, 16));
				MoveUpButton.Image = original.ToBitmap();
			}
			manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(Access), "ARW08DN.ICO");
			if (manifestResourceStream != null)
			{
				Icon original = new Icon(manifestResourceStream);
				original = new Icon(original, new Size(16, 16));
				MoveDownButton.Image = original.ToBitmap();
			}
			manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(Access), "ARWHEAD.ICO");
			if (manifestResourceStream != null)
			{
				Icon original = new Icon(manifestResourceStream);
				original = new Icon(original, new Size(16, 16));
				AddClassButton.Image = original.ToBitmap();
			}
		}
	}
}
