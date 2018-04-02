using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class ScaleDiscreetMarkerEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private FocusLabel label1;

		private FocusLabel label4;

		private FocusLabel label5;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown SizeNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.ComboBox BevelStyleComboBox;

		private ColorPicker ColorPicker;

		private Container components;

		public ScaleDiscreetMarkerEditorPlugIn()
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
			ColorPicker = new ColorPicker();
			label4 = new FocusLabel();
			label5 = new FocusLabel();
			BevelStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			base.SuspendLayout();
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(56, 24);
			StyleComboBox.MaxDropDownItems = 20;
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(144, 21);
			StyleComboBox.TabIndex = 0;
			label2.LoadingBegin();
			label2.FocusControl = StyleComboBox;
			label2.Location = new Point(24, 26);
			label2.Name = "label2";
			label2.Size = new Size(32, 15);
			label2.Text = "Style";
			label2.LoadingEnd();
			label1.LoadingBegin();
			label1.FocusControl = SizeNumericUpDown;
			label1.Location = new Point(27, 65);
			label1.Name = "label1";
			label1.Size = new Size(29, 15);
			label1.Text = "Size";
			label1.LoadingEnd();
			SizeNumericUpDown.Location = new Point(56, 64);
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
			ColorPicker.Location = new Point(56, 104);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(144, 21);
			ColorPicker.TabIndex = 2;
			label4.LoadingBegin();
			label4.FocusControl = ColorPicker;
			label4.Location = new Point(22, 107);
			label4.Name = "label4";
			label4.Size = new Size(34, 15);
			label4.Text = "Color";
			label4.LoadingEnd();
			label5.LoadingBegin();
			label5.FocusControl = BevelStyleComboBox;
			label5.Location = new Point(249, 26);
			label5.Name = "label5";
			label5.Size = new Size(63, 15);
			label5.Text = "Bevel Style";
			label5.LoadingEnd();
			BevelStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			BevelStyleComboBox.Location = new Point(312, 24);
			BevelStyleComboBox.MaxDropDownItems = 20;
			BevelStyleComboBox.Name = "BevelStyleComboBox";
			BevelStyleComboBox.PropertyName = "BevelStyle";
			BevelStyleComboBox.Size = new Size(144, 21);
			BevelStyleComboBox.TabIndex = 3;
			base.Controls.Add(label5);
			base.Controls.Add(BevelStyleComboBox);
			base.Controls.Add(label4);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(SizeNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Controls.Add(StyleComboBox);
			base.Name = "ScaleDiscreetMarkerEditorPlugIn";
			base.Size = new Size(608, 256);
			base.Title = "Markers Editor";
			base.ResumeLayout(false);
		}
	}
}
