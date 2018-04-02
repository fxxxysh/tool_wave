using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public sealed class TextFormatDoubleEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.NumericUpDown PrecisionNumericUpDown;

		private EditMultiLine UnitsTextEditMultiLine;

		private FocusLabel label11;

		private Iocomp.Design.Plugin.EditorControls.ComboBox PrecisionStyleComboBox;

		private FocusLabel label1;

		private FocusLabel label2;

		private Container components;

		public TextFormatDoubleEditorPlugIn()
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
			PrecisionNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			UnitsTextEditMultiLine = new EditMultiLine();
			label11 = new FocusLabel();
			PrecisionStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label1 = new FocusLabel();
			label2 = new FocusLabel();
			base.SuspendLayout();
			PrecisionNumericUpDown.Location = new Point(96, 80);
			PrecisionNumericUpDown.Maximum = new decimal(new int[4]
			{
				16,
				0,
				0,
				0
			});
			PrecisionNumericUpDown.Name = "PrecisionNumericUpDown";
			PrecisionNumericUpDown.PropertyName = "Precision";
			PrecisionNumericUpDown.Size = new Size(48, 20);
			PrecisionNumericUpDown.TabIndex = 1;
			PrecisionNumericUpDown.TextAlign = HorizontalAlignment.Center;
			UnitsTextEditMultiLine.EditFont = null;
			UnitsTextEditMultiLine.Location = new Point(288, 48);
			UnitsTextEditMultiLine.Name = "UnitsTextEditMultiLine";
			UnitsTextEditMultiLine.PropertyName = "UnitsText";
			UnitsTextEditMultiLine.Size = new Size(142, 20);
			UnitsTextEditMultiLine.TabIndex = 2;
			label11.LoadingBegin();
			label11.AutoSize = false;
			label11.FocusControl = UnitsTextEditMultiLine;
			label11.Location = new Point(224, 50);
			label11.Name = "label11";
			label11.Size = new Size(64, 16);
			label11.Text = "Units Text";
			label11.LoadingEnd();
			PrecisionStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			PrecisionStyleComboBox.Location = new Point(96, 48);
			PrecisionStyleComboBox.Name = "PrecisionStyleComboBox";
			PrecisionStyleComboBox.PropertyName = "PrecisionStyle";
			PrecisionStyleComboBox.Size = new Size(121, 21);
			PrecisionStyleComboBox.TabIndex = 0;
			label1.LoadingBegin();
			label1.AutoSize = false;
			label1.FocusControl = PrecisionNumericUpDown;
			label1.Location = new Point(40, 80);
			label1.Name = "label1";
			label1.Size = new Size(56, 16);
			label1.Text = "Precision";
			label1.LoadingEnd();
			label2.LoadingBegin();
			label2.AutoSize = false;
			label2.FocusControl = PrecisionStyleComboBox;
			label2.Location = new Point(8, 49);
			label2.Name = "label2";
			label2.Size = new Size(88, 16);
			label2.Text = "Precision Style";
			label2.LoadingEnd();
			base.Controls.Add(PrecisionNumericUpDown);
			base.Controls.Add(UnitsTextEditMultiLine);
			base.Controls.Add(label11);
			base.Controls.Add(PrecisionStyleComboBox);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Location = new Point(10, 20);
			base.Name = "TextFormatDoubleEditorPlugIn";
			base.Size = new Size(512, 224);
			base.Title = "Text Formatting Editor";
			base.ResumeLayout(false);
		}
	}
}
