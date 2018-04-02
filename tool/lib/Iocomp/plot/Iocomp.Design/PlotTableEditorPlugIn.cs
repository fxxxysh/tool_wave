using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotTableEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private Container components;

		public PlotTableEditorPlugIn()
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
			VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			NameTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			ColorPicker = new ColorPicker();
			label8 = new FocusLabel();
			ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label1 = new FocusLabel();
			base.SuspendLayout();
			VisibleCheckBox.Location = new Point(272, 16);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			EnabledCheckBox.Location = new Point(272, 40);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(80, 24);
			EnabledCheckBox.TabIndex = 2;
			EnabledCheckBox.Text = "Enabled";
			NameTextBox.LoadingBegin();
			NameTextBox.Location = new Point(104, 16);
			NameTextBox.Name = "NameTextBox";
			NameTextBox.PropertyName = "Name";
			NameTextBox.Size = new Size(144, 20);
			NameTextBox.TabIndex = 9;
			NameTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = NameTextBox;
			focusLabel1.Location = new Point(69, 15);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(35, 21);
			focusLabel1.Text = "Name";
			focusLabel1.LoadingEnd();
			ColorPicker.Location = new Point(104, 48);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(48, 21);
			ColorPicker.Style = ColorPickerStyle.ColorBox;
			ColorPicker.TabIndex = 33;
			label8.LoadingBegin();
			label8.FocusControl = ColorPicker;
			label8.Location = new Point(72, 48);
			label8.Name = "label8";
			label8.Size = new Size(32, 21);
			label8.Text = "Color";
			label8.LoadingEnd();
			ContextMenuEnabledCheckBox.Location = new Point(272, 64);
			ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			ContextMenuEnabledCheckBox.Size = new Size(152, 24);
			ContextMenuEnabledCheckBox.TabIndex = 36;
			ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			LayerNumericUpDown.Location = new Point(192, 48);
			LayerNumericUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			LayerNumericUpDown.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			LayerNumericUpDown.Name = "LayerNumericUpDown";
			LayerNumericUpDown.PropertyName = "Layer";
			LayerNumericUpDown.Size = new Size(56, 20);
			LayerNumericUpDown.TabIndex = 103;
			LayerNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label1.LoadingBegin();
			label1.FocusControl = LayerNumericUpDown;
			label1.Location = new Point(159, 49);
			label1.Name = "label1";
			label1.Size = new Size(33, 14);
			label1.Text = "Layer";
			label1.LoadingEnd();
			base.Controls.Add(LayerNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(ContextMenuEnabledCheckBox);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label8);
			base.Controls.Add(NameTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotTableEditorPlugIn";
			base.Size = new Size(456, 208);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.SubPlugIns.Add(new PlotFillEditorPlugIn());
			base.SubPlugIns[base.SubPlugIns.Count - 1].TabName = "Fill";
			base.SubPlugIns.Add(new PlotLayoutDockableAllEditorPlugIn());
			base.SubPlugIns[base.SubPlugIns.Count - 1].TabName = "Dock";
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotTableGrid).Fill;
			base.SubPlugIns[1].Value = base.Value;
		}
	}
}
