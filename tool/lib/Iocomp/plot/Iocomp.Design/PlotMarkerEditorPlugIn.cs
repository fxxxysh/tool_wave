using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotMarkerEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown SizeNumericUpDown;

		private EditMultiLine TextEditMultiLine;

		private FocusLabel focusLabel10;

		private FontButton FontButton;

		private FocusLabel focusLabel11;

		private ColorPicker ForeColorPicker;

		private Container components;

		public PlotMarkerEditorPlugIn()
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
			SizeNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			TextEditMultiLine = new EditMultiLine();
			focusLabel10 = new FocusLabel();
			FontButton = new FontButton();
			focusLabel11 = new FocusLabel();
			ForeColorPicker = new ColorPicker();
			base.SuspendLayout();
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(104, 112);
			StyleComboBox.MaxDropDownItems = 20;
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(144, 21);
			StyleComboBox.TabIndex = 2;
			label2.LoadingBegin();
			label2.FocusControl = StyleComboBox;
			label2.Location = new Point(72, 114);
			label2.Name = "label2";
			label2.Size = new Size(32, 15);
			label2.Text = "Style";
			label2.LoadingEnd();
			label1.LoadingBegin();
			label1.FocusControl = SizeNumericUpDown;
			label1.Location = new Point(75, 81);
			label1.Name = "label1";
			label1.Size = new Size(29, 15);
			label1.Text = "Size";
			label1.LoadingEnd();
			SizeNumericUpDown.Location = new Point(104, 80);
			SizeNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			SizeNumericUpDown.Name = "SizeNumericUpDown";
			SizeNumericUpDown.PropertyName = "Size";
			SizeNumericUpDown.Size = new Size(56, 20);
			SizeNumericUpDown.TabIndex = 1;
			SizeNumericUpDown.TextAlign = HorizontalAlignment.Center;
			VisibleCheckBox.Location = new Point(104, 48);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			TextEditMultiLine.EditFont = null;
			TextEditMultiLine.Location = new Point(104, 144);
			TextEditMultiLine.Name = "TextEditMultiLine";
			TextEditMultiLine.PropertyName = "Text";
			TextEditMultiLine.Size = new Size(144, 20);
			TextEditMultiLine.TabIndex = 3;
			focusLabel10.LoadingBegin();
			focusLabel10.FocusControl = TextEditMultiLine;
			focusLabel10.Location = new Point(75, 147);
			focusLabel10.Name = "focusLabel10";
			focusLabel10.Size = new Size(29, 15);
			focusLabel10.Text = "Text";
			focusLabel10.LoadingEnd();
			FontButton.Location = new Point(104, 176);
			FontButton.Name = "FontButton";
			FontButton.PropertyName = "Font";
			FontButton.Size = new Size(72, 23);
			FontButton.TabIndex = 4;
			focusLabel11.LoadingBegin();
			focusLabel11.FocusControl = ForeColorPicker;
			focusLabel11.Location = new Point(181, 179);
			focusLabel11.Name = "focusLabel11";
			focusLabel11.Size = new Size(59, 15);
			focusLabel11.Text = "Fore Color";
			focusLabel11.LoadingEnd();
			ForeColorPicker.Location = new Point(240, 176);
			ForeColorPicker.Name = "ForeColorPicker";
			ForeColorPicker.PropertyName = "ForeColor";
			ForeColorPicker.Size = new Size(49, 21);
			ForeColorPicker.Style = ColorPickerStyle.ColorBox;
			ForeColorPicker.TabIndex = 5;
			base.Controls.Add(focusLabel11);
			base.Controls.Add(ForeColorPicker);
			base.Controls.Add(FontButton);
			base.Controls.Add(TextEditMultiLine);
			base.Controls.Add(focusLabel10);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(SizeNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Controls.Add(StyleComboBox);
			base.Name = "PlotMarkerEditorPlugIn";
			base.Size = new Size(424, 288);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotMarker).Fill;
		}
	}
}
