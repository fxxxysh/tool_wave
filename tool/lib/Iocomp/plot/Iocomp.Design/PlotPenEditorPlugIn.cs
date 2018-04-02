using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotPenEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private FocusLabel label1;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private EditBox ThicknessTextBox;

		private Container components;

		public PlotPenEditorPlugIn()
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
			label1 = new FocusLabel();
			ThicknessTextBox = new EditBox();
			ColorPicker = new ColorPicker();
			label8 = new FocusLabel();
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(104, 112);
			StyleComboBox.MaxDropDownItems = 20;
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(144, 21);
			StyleComboBox.TabIndex = 3;
			label2.LoadingBegin();
			label2.FocusControl = StyleComboBox;
			label2.Location = new Point(72, 114);
			label2.Name = "label2";
			label2.Size = new Size(32, 15);
			label2.Text = "Style";
			label2.LoadingEnd();
			label1.LoadingBegin();
			label1.FocusControl = ThicknessTextBox;
			label1.Location = new Point(47, 82);
			label1.Name = "label1";
			label1.Size = new Size(57, 15);
			label1.Text = "Thickness";
			label1.LoadingEnd();
			ThicknessTextBox.LoadingBegin();
			ThicknessTextBox.Location = new Point(104, 80);
			ThicknessTextBox.Name = "ThicknessTextBox";
			ThicknessTextBox.PropertyName = "Thickness";
			ThicknessTextBox.Size = new Size(64, 20);
			ThicknessTextBox.TabIndex = 2;
			ThicknessTextBox.LoadingEnd();
			ColorPicker.Location = new Point(104, 48);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(48, 21);
			ColorPicker.Style = ColorPickerStyle.ColorBox;
			ColorPicker.TabIndex = 1;
			label8.LoadingBegin();
			label8.FocusControl = ColorPicker;
			label8.Location = new Point(70, 51);
			label8.Name = "label8";
			label8.Size = new Size(34, 15);
			label8.Text = "Color";
			label8.LoadingEnd();
			VisibleCheckBox.Location = new Point(104, 16);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			base.Controls.Add(ThicknessTextBox);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label8);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Controls.Add(StyleComboBox);
			base.Name = "PlotPenEditorPlugIn";
			base.Size = new Size(424, 288);
			base.ResumeLayout(false);
		}
	}
}
