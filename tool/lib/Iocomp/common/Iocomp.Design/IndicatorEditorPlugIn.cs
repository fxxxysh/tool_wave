using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class IndicatorEditorPlugIn : PlugInStandard
	{
		private GroupBox groupBox1;

		private FocusLabel label4;

		private FocusLabel label2;

		private ColorPicker ColorActiveColorPicker;

		private ColorPicker ColorInactiveColorPicker;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ColorInactiveAutoCheckBox;

		private Container components;

		public IndicatorEditorPlugIn()
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
			groupBox1 = new GroupBox();
			label2 = new FocusLabel();
			ColorInactiveColorPicker = new ColorPicker();
			label4 = new FocusLabel();
			ColorActiveColorPicker = new ColorPicker();
			ColorInactiveAutoCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			groupBox1.SuspendLayout();
			base.SuspendLayout();
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(ColorInactiveColorPicker);
			groupBox1.Controls.Add(ColorActiveColorPicker);
			groupBox1.Controls.Add(ColorInactiveAutoCheckBox);
			groupBox1.Location = new Point(5, 0);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(219, 96);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Color";
			label2.LoadingBegin();
			label2.FocusControl = ColorInactiveColorPicker;
			label2.Location = new Point(11, 43);
			label2.Name = "label2";
			label2.Size = new Size(45, 15);
			label2.Text = "Inactive";
			label2.LoadingEnd();
			ColorInactiveColorPicker.Location = new Point(56, 40);
			ColorInactiveColorPicker.Name = "ColorInactiveColorPicker";
			ColorInactiveColorPicker.PropertyName = "ColorInactive";
			ColorInactiveColorPicker.Size = new Size(144, 21);
			ColorInactiveColorPicker.TabIndex = 1;
			label4.LoadingBegin();
			label4.FocusControl = ColorActiveColorPicker;
			label4.Location = new Point(18, 19);
			label4.Name = "label4";
			label4.Size = new Size(38, 15);
			label4.Text = "Active";
			label4.LoadingEnd();
			ColorActiveColorPicker.Location = new Point(56, 16);
			ColorActiveColorPicker.Name = "ColorActiveColorPicker";
			ColorActiveColorPicker.PropertyName = "ColorActive";
			ColorActiveColorPicker.Size = new Size(144, 21);
			ColorActiveColorPicker.TabIndex = 0;
			ColorInactiveAutoCheckBox.Location = new Point(56, 64);
			ColorInactiveAutoCheckBox.Name = "ColorInactiveAutoCheckBox";
			ColorInactiveAutoCheckBox.PropertyName = "ColorInactiveAuto";
			ColorInactiveAutoCheckBox.Size = new Size(120, 24);
			ColorInactiveAutoCheckBox.TabIndex = 2;
			ColorInactiveAutoCheckBox.Text = "Inactive Auto";
			base.Controls.Add(groupBox1);
			base.Name = "IndicatorEditorPlugIn";
			base.Size = new Size(456, 104);
			base.Title = "Indicator Editor";
			groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
