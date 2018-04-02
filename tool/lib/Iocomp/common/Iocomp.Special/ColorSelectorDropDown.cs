using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Special
{
	[ToolboxItem(false)]
	public class ColorSelectorDropDown : UserControl
	{
		private ListBox WebListBox;

		private ListBox SystemListBox;

		private TabControl TabControl1;

		private TabPage TabPageCustom;

		private TabPage TabPageWeb;

		private TabPage TabPageSystem;

		private Container components;

		private Color m_Color;

		private int m_CustomSelectedIndex;

		private int m_InitialActivePageindex;

		private string[] m_SystemColorNameArray = new string[26]
		{
			"ActiveBorder",
			"ActiveCaption",
			"ActiveCaptionText",
			"AppWorkspace",
			"Control",
			"ControlDark",
			"ControlDarkDark",
			"ControlLight",
			"ControlLightLight",
			"ControlText",
			"Desktop",
			"GrayText",
			"Highlight",
			"HighlightText",
			"HotTrack",
			"InactiveBorder",
			"InactiveCaption",
			"InactiveCaptionText",
			"Info",
			"InfoText",
			"Menu",
			"MenuText",
			"ScrollBar",
			"Window",
			"WindowFrame",
			"WindowText"
		};

		private string[] m_WebColorNameArray = new string[142]
		{
			"Empty",
			"Transparent",
			"Black",
			"DimGray",
			"Gray",
			"DarkGray",
			"Silver",
			"LightGray",
			"Gainsboro",
			"WhiteSmoke",
			"White",
			"RosyBrown",
			"IndianRed",
			"Brown",
			"Firebrick",
			"LightCoral",
			"Maroon",
			"DarkRed",
			"Red",
			"Snow",
			"MistyRose",
			"Salmon",
			"Tomato",
			"DarkSalmon",
			"Coral",
			"OrangeRed",
			"LightSalmon",
			"Sienna",
			"SeaShell",
			"Chocolate",
			"SaddleBrown",
			"SandyBrown",
			"PeachPuff",
			"Peru",
			"Linen",
			"Bisque",
			"DarkOrange",
			"BurlyWood",
			"Tan",
			"AntiqueWhite",
			"NavajoWhite",
			"BlanchedAlmond",
			"PapayaWhip",
			"Moccasin",
			"Orange",
			"Wheat",
			"OldLace",
			"FloralWhite",
			"DarkGoldenrod",
			"Goldenrod",
			"Cornsilk",
			"Gold",
			"Khaki",
			"LemonChiffon",
			"PaleGoldenrod",
			"DarkKhaki",
			"Beige",
			"LightGoldenrodYellow",
			"Olive",
			"Yellow",
			"LightYellow",
			"Ivory",
			"OliveDrab",
			"YellowGreen",
			"DarkOliveGreen",
			"GreenYellow",
			"Chartreuse",
			"LawnGreen",
			"DarkSeaGreen",
			"ForestGreen",
			"LimeGreen",
			"LightGreen",
			"PaleGreen",
			"DarkGreen",
			"Green",
			"Lime",
			"Honeydew",
			"SeaGreen",
			"MediumSeaGreen",
			"SpringGreen",
			"MintCream",
			"MediumSpringGreen",
			"MediumAquamarine",
			"Aquamarine",
			"Turquoise",
			"LightSeaGreen",
			"MediumTurquoise",
			"DarkSlateGray",
			"PaleTurquoise",
			"Teal",
			"DarkCyan",
			"Aqua",
			"Cyan",
			"LightCyan",
			"Azure",
			"DarkTurquoise",
			"CadetBlue",
			"PowderBlue",
			"LightBlue",
			"DeepSkyBlue",
			"SkyBlue",
			"LightSkyBlue",
			"SteelBlue",
			"AliceBlue",
			"DodgerBlue",
			"SlateGray",
			"LightSlateGray",
			"LightSteelBlue",
			"CornflowerBlue",
			"RoyalBlue",
			"MidnightBlue",
			"Lavender",
			"Navy",
			"DarkBlue",
			"MediumBlue",
			"Blue",
			"GhostWhite",
			"SlateBlue",
			"DarkSlateBlue",
			"MediumSlateBlue",
			"MediumPurple",
			"BlueViolet",
			"Indigo",
			"DarkOrchid",
			"DarkViolet",
			"MediumOrchid",
			"Thistle",
			"Plum",
			"Violet",
			"Purple",
			"DarkMagenta",
			"Magenta",
			"Fuchsia",
			"Orchid",
			"MediumVioletRed",
			"DeepPink",
			"HotPink",
			"LavenderBlush",
			"PaleVioletRed",
			"Crimson",
			"Pink",
			"LightPink"
		};

		private Color[] m_CustomColorArray = new Color[64]
		{
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 192, 192),
			Color.FromArgb(255, 224, 192),
			Color.FromArgb(255, 255, 192),
			Color.FromArgb(192, 255, 192),
			Color.FromArgb(192, 255, 255),
			Color.FromArgb(192, 192, 255),
			Color.FromArgb(255, 192, 255),
			Color.FromArgb(224, 244, 244),
			Color.FromArgb(255, 128, 128),
			Color.FromArgb(255, 192, 128),
			Color.FromArgb(255, 255, 128),
			Color.FromArgb(128, 255, 128),
			Color.FromArgb(128, 255, 255),
			Color.FromArgb(128, 128, 255),
			Color.FromArgb(255, 128, 255),
			Color.FromArgb(192, 192, 192),
			Color.FromArgb(255, 0, 0),
			Color.FromArgb(255, 128, 0),
			Color.FromArgb(255, 255, 0),
			Color.FromArgb(0, 255, 0),
			Color.FromArgb(0, 255, 255),
			Color.FromArgb(0, 0, 255),
			Color.FromArgb(255, 0, 255),
			Color.FromArgb(128, 128, 128),
			Color.FromArgb(192, 0, 0),
			Color.FromArgb(192, 64, 0),
			Color.FromArgb(192, 192, 0),
			Color.FromArgb(0, 192, 0),
			Color.FromArgb(0, 192, 192),
			Color.FromArgb(0, 0, 192),
			Color.FromArgb(192, 0, 192),
			Color.FromArgb(64, 64, 64),
			Color.FromArgb(128, 0, 0),
			Color.FromArgb(128, 64, 0),
			Color.FromArgb(128, 128, 0),
			Color.FromArgb(0, 128, 0),
			Color.FromArgb(0, 128, 128),
			Color.FromArgb(0, 0, 128),
			Color.FromArgb(128, 0, 128),
			Color.FromArgb(0, 0, 0),
			Color.FromArgb(64, 0, 0),
			Color.FromArgb(128, 64, 64),
			Color.FromArgb(64, 64, 0),
			Color.FromArgb(0, 64, 0),
			Color.FromArgb(0, 64, 64),
			Color.FromArgb(0, 0, 64),
			Color.FromArgb(64, 0, 64),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255)
		};

		public Color Color
		{
			get
			{
				return m_Color;
			}
			set
			{
				if (m_Color != value)
				{
					m_Color = value;
					UpdateSelections();
				}
			}
		}

		public event EventHandler Changed;

		public ColorSelectorDropDown()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			TabControl1.Location = new Point(1, 1);
			TabControl1.Size = new Size(base.Width - 2, base.Height - 2);
		}

		protected void UpdateSelections()
		{
			WebListBox.SelectedIndexChanged -= WebListBox_SelectedIndexChanged;
			SystemListBox.SelectedIndexChanged -= SystemListBox_SelectedIndexChanged;
			try
			{
				WebListBox.SelectedIndex = -1;
				SystemListBox.SelectedIndex = -1;
				m_CustomSelectedIndex = -1;
				m_InitialActivePageindex = 0;
				int num = 0;
				while (num < m_CustomColorArray.Length)
				{
					if (m_CustomColorArray[num].ToArgb() != Color.ToArgb())
					{
						num++;
						continue;
					}
					m_CustomSelectedIndex = num;
					m_InitialActivePageindex = 0;
					break;
				}
				Color left;
				if (Color.IsSystemColor)
				{
					for (int i = 0; i < SystemListBox.Items.Count; i++)
					{
						string name = SystemListBox.Items[i].ToString();
						left = Color.FromName(name);
						if (left == Color)
						{
							SystemListBox.SelectedIndex = i;
							m_InitialActivePageindex = 2;
							break;
						}
					}
				}
				int num2 = 0;
				while (true)
				{
					if (num2 < WebListBox.Items.Count)
					{
						string name = WebListBox.Items[num2].ToString();
						left = Color.FromName(name);
						if (left.ToArgb() != Color.ToArgb())
						{
							num2++;
							continue;
						}
						break;
					}
					return;
				}
				WebListBox.SelectedIndex = num2;
				m_InitialActivePageindex = 1;
			}
			finally
			{
				WebListBox.SelectedIndexChanged += WebListBox_SelectedIndexChanged;
				SystemListBox.SelectedIndexChanged += SystemListBox_SelectedIndexChanged;
			}
		}

		private void InitializeComponent()
		{
			TabControl1 = new TabControl();
			TabPageCustom = new TabPage();
			TabPageWeb = new TabPage();
			WebListBox = new ListBox();
			TabPageSystem = new TabPage();
			SystemListBox = new ListBox();
			TabControl1.SuspendLayout();
			TabPageWeb.SuspendLayout();
			TabPageSystem.SuspendLayout();
			base.SuspendLayout();
			TabControl1.Controls.Add(TabPageCustom);
			TabControl1.Controls.Add(TabPageWeb);
			TabControl1.Controls.Add(TabPageSystem);
			TabControl1.Location = new Point(0, 0);
			TabControl1.Name = "TabControl1";
			TabControl1.SelectedIndex = 0;
			TabControl1.Size = new Size(180, 200);
			TabControl1.TabIndex = 148;
			TabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
			TabPageCustom.Location = new Point(4, 22);
			TabPageCustom.Name = "TabPageCustom";
			TabPageCustom.Size = new Size(172, 174);
			TabPageCustom.TabIndex = 0;
			TabPageCustom.Text = "Custom";
			TabPageCustom.Paint += TabPageCustom_Paint;
			TabPageCustom.MouseDown += TabPageCustom_MouseDown;
			TabPageWeb.Controls.Add(WebListBox);
			TabPageWeb.Location = new Point(4, 22);
			TabPageWeb.Name = "TabPageWeb";
			TabPageWeb.Size = new Size(172, 174);
			TabPageWeb.TabIndex = 1;
			TabPageWeb.Text = "Web";
			TabPageWeb.Visible = false;
			WebListBox.BorderStyle = BorderStyle.FixedSingle;
			WebListBox.Dock = DockStyle.Fill;
			WebListBox.DrawMode = DrawMode.OwnerDrawFixed;
			WebListBox.IntegralHeight = false;
			WebListBox.ItemHeight = 14;
			WebListBox.Location = new Point(0, 0);
			WebListBox.Name = "WebListBox";
			WebListBox.Size = new Size(172, 174);
			WebListBox.TabIndex = 0;
			WebListBox.DrawItem += WebListBox_DrawItem;
			TabPageSystem.Controls.Add(SystemListBox);
			TabPageSystem.Location = new Point(4, 22);
			TabPageSystem.Name = "TabPageSystem";
			TabPageSystem.Size = new Size(172, 174);
			TabPageSystem.TabIndex = 2;
			TabPageSystem.Text = "System";
			TabPageSystem.Visible = false;
			SystemListBox.BorderStyle = BorderStyle.FixedSingle;
			SystemListBox.Dock = DockStyle.Fill;
			SystemListBox.DrawMode = DrawMode.OwnerDrawFixed;
			SystemListBox.IntegralHeight = false;
			SystemListBox.ItemHeight = 14;
			SystemListBox.Location = new Point(0, 0);
			SystemListBox.Name = "SystemListBox";
			SystemListBox.Size = new Size(172, 174);
			SystemListBox.TabIndex = 0;
			SystemListBox.DrawItem += WebListBox_DrawItem;
			BackColor = Color.Black;
			base.Controls.Add(TabControl1);
			base.Name = "ColorSelectorDropDown";
			base.Size = new Size(205, 226);
			base.Load += ColorSelectorDropdown_Load;
			TabControl1.ResumeLayout(false);
			TabPageWeb.ResumeLayout(false);
			TabPageSystem.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private void WebListBox_DrawItem(object sender, DrawItemEventArgs e)
		{
			string text = ((ListBox)sender).Items[e.Index].ToString();
			Color color = Color.FromName(text);
			if (text == "Empty")
			{
				text = "Empty (Reset)";
			}
			Brush brush = ((e.State & DrawItemState.Selected) != DrawItemState.Selected) ? SystemBrushes.WindowText : SystemBrushes.HighlightText;
			e.DrawBackground();
			Rectangle rect = new Rectangle(e.Bounds.Left + 2, e.Bounds.Top + 2, 21, e.Bounds.Height - 4 - 1);
			Rectangle r = new Rectangle(rect.Right + 2, e.Bounds.Top, e.Bounds.Width - 4 - rect.Width, e.Bounds.Height);
			e.Graphics.FillRectangle(new SolidBrush(color), rect);
			e.Graphics.DrawRectangle(Pens.Black, rect);
			e.Graphics.DrawString(text, WebListBox.Font, brush, r);
		}

		private void ColorSelectorDropdown_Load(object sender, EventArgs e)
		{
			SystemListBox.Items.Clear();
			WebListBox.Items.Clear();
			for (int i = 0; i < m_SystemColorNameArray.Length; i++)
			{
				SystemListBox.Items.Add(m_SystemColorNameArray[i]);
			}
			for (int j = 0; j < m_WebColorNameArray.Length; j++)
			{
				WebListBox.Items.Add(m_WebColorNameArray[j]);
			}
			UpdateSelections();
			TabControl1.SelectedIndex = m_InitialActivePageindex;
		}

		private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (TabControl1.SelectedIndex == 1)
			{
				WebListBox.Focus();
			}
			else if (TabControl1.SelectedIndex == 2)
			{
				SystemListBox.Focus();
			}
		}

		private Rectangle GetCustomRect(int index)
		{
			int num = (int)((long)index / 8L);
			int num2 = (int)((long)index % 8L);
			return new Rectangle(3 + num2 * 24, 5 + num * 24, 21, 21);
		}

		private void TabPageCustom_Paint(object sender, PaintEventArgs e)
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					int num = i * 8 + j;
					Rectangle customRect = GetCustomRect(num);
					Brush brush = new SolidBrush(m_CustomColorArray[num]);
					e.Graphics.FillRectangle(brush, customRect);
					brush.Dispose();
					ControlPaint.DrawBorder3D(e.Graphics, customRect, Border3DStyle.Sunken);
					if (m_CustomSelectedIndex == num)
					{
						customRect.Inflate(1, 2);
						ControlPaint.DrawFocusRectangle(e.Graphics, customRect, Color.White, TabPageCustom.BackColor);
					}
				}
			}
		}

		private void TabPageCustom_MouseDown(object sender, MouseEventArgs e)
		{
			for (int i = 0; i < 64; i++)
			{
				if (GetCustomRect(i).Contains(e.X, e.Y))
				{
					Color = m_CustomColorArray[i];
					TabPageCustom.Invalidate();
					OnColorChanged();
				}
			}
		}

		private void WebListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (WebListBox.SelectedIndex != -1)
			{
				string a = WebListBox.Items[WebListBox.SelectedIndex].ToString();
				if (a == "Empty")
				{
					Color = Color.Empty;
				}
				else
				{
					Color = Color.FromName(WebListBox.Items[WebListBox.SelectedIndex].ToString());
				}
				OnColorChanged();
			}
		}

		private void SystemListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SystemListBox.SelectedIndex != -1)
			{
				Color = Color.FromName(SystemListBox.Items[SystemListBox.SelectedIndex].ToString());
				OnColorChanged();
			}
		}

		private void OnColorChanged()
		{
			if (this.Changed != null)
			{
				this.Changed(this, new EventArgs());
			}
		}
	}
}
