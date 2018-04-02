using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public sealed class IndicatorLedEditorPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private FocusLabel label1;

		private GroupBox groupBox2;

		private FocusLabel label6;

		private FocusLabel label7;

		private ColorPicker ColorActiveColorPicker;

		private GroupBox groupBox3;

		private FocusLabel label8;

		private FocusLabel label9;

		private ColorPicker TextColorActiveColorPicker;

		private Iocomp.Design.Plugin.EditorControls.ComboBox Style3DComboBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private EditMultiLine TextEditMultiLine;

		private FocusLabel label11;

		private ColorPicker ColorInactiveColorPicker;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ColorInactiveAutoCheckBox;

		private ColorPicker TextColorInactiveColorPicker;

		private Container components;

		public IndicatorLedEditorPlugIn()
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

		private void InitializeComponent()
		{
			label2 = new FocusLabel();
			StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label1 = new FocusLabel();
			Style3DComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			groupBox2 = new GroupBox();
			label6 = new FocusLabel();
			ColorInactiveColorPicker = new ColorPicker();
			label7 = new FocusLabel();
			ColorActiveColorPicker = new ColorPicker();
			ColorInactiveAutoCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			groupBox3 = new GroupBox();
			label8 = new FocusLabel();
			TextColorInactiveColorPicker = new ColorPicker();
			label9 = new FocusLabel();
			TextColorActiveColorPicker = new ColorPicker();
			TextEditMultiLine = new EditMultiLine();
			label11 = new FocusLabel();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			base.SuspendLayout();
			label2.LoadingBegin();
			label2.FocusControl = StyleComboBox;
			label2.Location = new Point(40, 10);
			label2.Name = "label2";
			label2.Size = new Size(32, 15);
			label2.Text = "Style";
			label2.LoadingEnd();
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(72, 8);
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(121, 21);
			StyleComboBox.TabIndex = 0;
			label1.LoadingBegin();
			label1.FocusControl = Style3DComboBox;
			label1.Location = new Point(26, 34);
			label1.Name = "label1";
			label1.Size = new Size(46, 15);
			label1.Text = "Style3D";
			label1.LoadingEnd();
			Style3DComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			Style3DComboBox.Location = new Point(72, 32);
			Style3DComboBox.Name = "Style3DComboBox";
			Style3DComboBox.PropertyName = "Style3D";
			Style3DComboBox.Size = new Size(121, 21);
			Style3DComboBox.TabIndex = 1;
			groupBox2.Controls.Add(label6);
			groupBox2.Controls.Add(label7);
			groupBox2.Controls.Add(ColorInactiveColorPicker);
			groupBox2.Controls.Add(ColorActiveColorPicker);
			groupBox2.Controls.Add(ColorInactiveAutoCheckBox);
			groupBox2.Location = new Point(16, 72);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(216, 104);
			groupBox2.TabIndex = 3;
			groupBox2.TabStop = false;
			groupBox2.Text = "Color";
			label6.LoadingBegin();
			label6.FocusControl = ColorInactiveColorPicker;
			label6.Location = new Point(11, 49);
			label6.Name = "label6";
			label6.Size = new Size(45, 15);
			label6.Text = "Inactive";
			label6.LoadingEnd();
			ColorInactiveColorPicker.Location = new Point(56, 46);
			ColorInactiveColorPicker.Name = "ColorInactiveColorPicker";
			ColorInactiveColorPicker.PropertyName = "ColorInactive";
			ColorInactiveColorPicker.Size = new Size(144, 21);
			ColorInactiveColorPicker.TabIndex = 1;
			label7.LoadingBegin();
			label7.FocusControl = ColorActiveColorPicker;
			label7.Location = new Point(18, 23);
			label7.Name = "label7";
			label7.Size = new Size(38, 15);
			label7.Text = "Active";
			label7.LoadingEnd();
			ColorActiveColorPicker.Location = new Point(56, 20);
			ColorActiveColorPicker.Name = "ColorActiveColorPicker";
			ColorActiveColorPicker.PropertyName = "ColorActive";
			ColorActiveColorPicker.Size = new Size(144, 21);
			ColorActiveColorPicker.TabIndex = 0;
			ColorInactiveAutoCheckBox.Location = new Point(56, 72);
			ColorInactiveAutoCheckBox.Name = "ColorInactiveAutoCheckBox";
			ColorInactiveAutoCheckBox.PropertyName = "ColorInactiveAuto";
			ColorInactiveAutoCheckBox.Size = new Size(120, 24);
			ColorInactiveAutoCheckBox.TabIndex = 2;
			ColorInactiveAutoCheckBox.Text = "Inactive Auto";
			groupBox3.Controls.Add(label8);
			groupBox3.Controls.Add(label9);
			groupBox3.Controls.Add(TextColorInactiveColorPicker);
			groupBox3.Controls.Add(TextColorActiveColorPicker);
			groupBox3.Location = new Point(264, 72);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(248, 72);
			groupBox3.TabIndex = 4;
			groupBox3.TabStop = false;
			groupBox3.Text = "Text";
			label8.LoadingBegin();
			label8.FocusControl = TextColorInactiveColorPicker;
			label8.Location = new Point(13, 49);
			label8.Name = "label8";
			label8.Size = new Size(75, 15);
			label8.Text = "Color Inactive";
			label8.LoadingEnd();
			TextColorInactiveColorPicker.Location = new Point(88, 46);
			TextColorInactiveColorPicker.Name = "TextColorInactiveColorPicker";
			TextColorInactiveColorPicker.PropertyName = "TextColorInactive";
			TextColorInactiveColorPicker.Size = new Size(144, 21);
			TextColorInactiveColorPicker.TabIndex = 1;
			label9.LoadingBegin();
			label9.FocusControl = TextColorActiveColorPicker;
			label9.Location = new Point(21, 23);
			label9.Name = "label9";
			label9.Size = new Size(67, 15);
			label9.Text = "Color Active";
			label9.LoadingEnd();
			TextColorActiveColorPicker.Location = new Point(88, 20);
			TextColorActiveColorPicker.Name = "TextColorActiveColorPicker";
			TextColorActiveColorPicker.PropertyName = "TextColorActive";
			TextColorActiveColorPicker.Size = new Size(144, 21);
			TextColorActiveColorPicker.TabIndex = 0;
			TextEditMultiLine.EditFont = null;
			TextEditMultiLine.Location = new Point(264, 8);
			TextEditMultiLine.Name = "TextEditMultiLine";
			TextEditMultiLine.PropertyName = "Text";
			TextEditMultiLine.Size = new Size(176, 20);
			TextEditMultiLine.TabIndex = 2;
			label11.LoadingBegin();
			label11.FocusControl = TextEditMultiLine;
			label11.Location = new Point(235, 11);
			label11.Name = "label11";
			label11.Size = new Size(29, 15);
			label11.Text = "Text";
			label11.LoadingEnd();
			base.Controls.Add(label11);
			base.Controls.Add(TextEditMultiLine);
			base.Controls.Add(groupBox3);
			base.Controls.Add(groupBox2);
			base.Controls.Add(StyleComboBox);
			base.Controls.Add(Style3DComboBox);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Location = new Point(10, 20);
			base.Name = "IndicatorLedEditorPlugIn";
			base.Size = new Size(536, 192);
			base.Title = "Indicator Editor";
			groupBox2.ResumeLayout(false);
			groupBox3.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new BevelThickEditorPlugIn(), "Bezel", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as IndicatorLed).Bezel;
		}
	}
}
