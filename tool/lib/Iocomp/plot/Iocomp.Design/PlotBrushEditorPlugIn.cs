using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotBrushEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private FocusLabel focusLabel1;

		private GroupBox GradientGroupBox;

		private FocusLabel focusLabel2;

		private GroupBox SolidGroupBox;

		private ColorPicker SolidColorPicker;

		private FocusLabel label8;

		private GroupBox HatchGroupBox;

		private FocusLabel focusLabel3;

		private FocusLabel focusLabel4;

		private ColorPicker GradientStartColorPicker;

		private ColorPicker GradientStopColorPicker;

		private ColorPicker HatchBackColorPicker;

		private ColorPicker HatchForeColorPicker;

		private Container components;

		public PlotBrushEditorPlugIn()
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
			StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label2 = new FocusLabel();
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			GradientGroupBox = new GroupBox();
			GradientStopColorPicker = new ColorPicker();
			focusLabel2 = new FocusLabel();
			GradientStartColorPicker = new ColorPicker();
			focusLabel1 = new FocusLabel();
			SolidGroupBox = new GroupBox();
			SolidColorPicker = new ColorPicker();
			label8 = new FocusLabel();
			HatchGroupBox = new GroupBox();
			HatchBackColorPicker = new ColorPicker();
			focusLabel3 = new FocusLabel();
			HatchForeColorPicker = new ColorPicker();
			focusLabel4 = new FocusLabel();
			GradientGroupBox.SuspendLayout();
			SolidGroupBox.SuspendLayout();
			HatchGroupBox.SuspendLayout();
			base.SuspendLayout();
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(48, 56);
			StyleComboBox.MaxDropDownItems = 20;
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(200, 21);
			StyleComboBox.TabIndex = 1;
			label2.LoadingBegin();
			label2.FocusControl = StyleComboBox;
			label2.Location = new Point(16, 58);
			label2.Name = "label2";
			label2.Size = new Size(32, 15);
			label2.Text = "Style";
			label2.LoadingEnd();
			VisibleCheckBox.Location = new Point(48, 24);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			GradientGroupBox.Controls.Add(GradientStopColorPicker);
			GradientGroupBox.Controls.Add(focusLabel2);
			GradientGroupBox.Controls.Add(GradientStartColorPicker);
			GradientGroupBox.Controls.Add(focusLabel1);
			GradientGroupBox.Location = new Point(136, 88);
			GradientGroupBox.Name = "GradientGroupBox";
			GradientGroupBox.Size = new Size(128, 100);
			GradientGroupBox.TabIndex = 3;
			GradientGroupBox.TabStop = false;
			GradientGroupBox.Text = "Gradient";
			GradientStopColorPicker.Location = new Point(64, 56);
			GradientStopColorPicker.Name = "GradientStopColorPicker";
			GradientStopColorPicker.PropertyName = "GradientStopColor";
			GradientStopColorPicker.Size = new Size(48, 21);
			GradientStopColorPicker.Style = ColorPickerStyle.ColorBox;
			GradientStopColorPicker.TabIndex = 1;
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = GradientStopColorPicker;
			focusLabel2.Location = new Point(5, 59);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(59, 15);
			focusLabel2.Text = "Stop Color";
			focusLabel2.LoadingEnd();
			GradientStartColorPicker.Location = new Point(64, 32);
			GradientStartColorPicker.Name = "GradientStartColorPicker";
			GradientStartColorPicker.PropertyName = "GradientStartColor";
			GradientStartColorPicker.Size = new Size(48, 21);
			GradientStartColorPicker.Style = ColorPickerStyle.ColorBox;
			GradientStartColorPicker.TabIndex = 0;
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = GradientStartColorPicker;
			focusLabel1.Location = new Point(4, 35);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(60, 15);
			focusLabel1.Text = "Start Color";
			focusLabel1.LoadingEnd();
			SolidGroupBox.Controls.Add(SolidColorPicker);
			SolidGroupBox.Controls.Add(label8);
			SolidGroupBox.Location = new Point(16, 88);
			SolidGroupBox.Name = "SolidGroupBox";
			SolidGroupBox.Size = new Size(112, 100);
			SolidGroupBox.TabIndex = 2;
			SolidGroupBox.TabStop = false;
			SolidGroupBox.Text = "Solid";
			SolidColorPicker.Location = new Point(48, 32);
			SolidColorPicker.Name = "SolidColorPicker";
			SolidColorPicker.PropertyName = "SolidColor";
			SolidColorPicker.Size = new Size(48, 21);
			SolidColorPicker.Style = ColorPickerStyle.ColorBox;
			SolidColorPicker.TabIndex = 0;
			label8.LoadingBegin();
			label8.FocusControl = SolidColorPicker;
			label8.Location = new Point(14, 35);
			label8.Name = "label8";
			label8.Size = new Size(34, 15);
			label8.Text = "Color";
			label8.LoadingEnd();
			HatchGroupBox.Controls.Add(HatchBackColorPicker);
			HatchGroupBox.Controls.Add(focusLabel3);
			HatchGroupBox.Controls.Add(HatchForeColorPicker);
			HatchGroupBox.Controls.Add(focusLabel4);
			HatchGroupBox.Location = new Point(272, 88);
			HatchGroupBox.Name = "HatchGroupBox";
			HatchGroupBox.Size = new Size(128, 100);
			HatchGroupBox.TabIndex = 4;
			HatchGroupBox.TabStop = false;
			HatchGroupBox.Text = "Hatch";
			HatchBackColorPicker.Location = new Point(64, 56);
			HatchBackColorPicker.Name = "HatchBackColorPicker";
			HatchBackColorPicker.PropertyName = "HatchBackColor";
			HatchBackColorPicker.Size = new Size(48, 21);
			HatchBackColorPicker.Style = ColorPickerStyle.ColorBox;
			HatchBackColorPicker.TabIndex = 1;
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = HatchBackColorPicker;
			focusLabel3.Location = new Point(3, 59);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(61, 15);
			focusLabel3.Text = "Back Color";
			focusLabel3.LoadingEnd();
			HatchForeColorPicker.Location = new Point(64, 32);
			HatchForeColorPicker.Name = "HatchForeColorPicker";
			HatchForeColorPicker.PropertyName = "HatchForeColor";
			HatchForeColorPicker.Size = new Size(48, 21);
			HatchForeColorPicker.Style = ColorPickerStyle.ColorBox;
			HatchForeColorPicker.TabIndex = 0;
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = HatchForeColorPicker;
			focusLabel4.Location = new Point(5, 35);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(59, 15);
			focusLabel4.Text = "Fore Color";
			focusLabel4.LoadingEnd();
			base.Controls.Add(HatchGroupBox);
			base.Controls.Add(SolidGroupBox);
			base.Controls.Add(GradientGroupBox);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(label2);
			base.Controls.Add(StyleComboBox);
			base.Name = "PlotBrushEditorPlugIn";
			base.Size = new Size(424, 288);
			GradientGroupBox.ResumeLayout(false);
			SolidGroupBox.ResumeLayout(false);
			HatchGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
