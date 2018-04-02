using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public sealed class TextFormatDoubleAllEditorPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private FocusLabel label11;

		private Iocomp.Design.Plugin.EditorControls.ComboBox PrecisionStyleComboBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown PrecisionNumericUpDown;

		private FocusLabel label1;

		private EditMultiLine UnitsTextEditMultiLine;

		private FocusLabel label3;

		private FocusLabel label4;

		private EditMultiLine DateTimeFormatEditMultiLine;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private Container components;

		public TextFormatDoubleAllEditorPlugIn()
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
			PrecisionStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			UnitsTextEditMultiLine = new EditMultiLine();
			label11 = new FocusLabel();
			PrecisionNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label1 = new FocusLabel();
			DateTimeFormatEditMultiLine = new EditMultiLine();
			label3 = new FocusLabel();
			StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label4 = new FocusLabel();
			base.SuspendLayout();
			label2.LoadingBegin();
			label2.FocusControl = PrecisionStyleComboBox;
			label2.Location = new Point(120, 90);
			label2.Name = "label2";
			label2.Size = new Size(80, 15);
			label2.Text = "Precision Style";
			label2.LoadingEnd();
			PrecisionStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			PrecisionStyleComboBox.Location = new Point(200, 88);
			PrecisionStyleComboBox.Name = "PrecisionStyleComboBox";
			PrecisionStyleComboBox.PropertyName = "PrecisionStyle";
			PrecisionStyleComboBox.Size = new Size(144, 21);
			PrecisionStyleComboBox.TabIndex = 1;
			UnitsTextEditMultiLine.EditFont = null;
			UnitsTextEditMultiLine.Location = new Point(200, 184);
			UnitsTextEditMultiLine.Name = "UnitsTextEditMultiLine";
			UnitsTextEditMultiLine.PropertyName = "UnitsText";
			UnitsTextEditMultiLine.Size = new Size(142, 20);
			UnitsTextEditMultiLine.TabIndex = 4;
			label11.LoadingBegin();
			label11.FocusControl = UnitsTextEditMultiLine;
			label11.Location = new Point(143, 187);
			label11.Name = "label11";
			label11.Size = new Size(57, 15);
			label11.Text = "Units Text";
			label11.LoadingEnd();
			PrecisionNumericUpDown.Location = new Point(200, 116);
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
			PrecisionNumericUpDown.TabIndex = 2;
			PrecisionNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label1.LoadingBegin();
			label1.FocusControl = PrecisionNumericUpDown;
			label1.Location = new Point(147, 117);
			label1.Name = "label1";
			label1.Size = new Size(53, 15);
			label1.Text = "Precision";
			label1.LoadingEnd();
			DateTimeFormatEditMultiLine.EditFont = null;
			DateTimeFormatEditMultiLine.Location = new Point(200, 152);
			DateTimeFormatEditMultiLine.Name = "DateTimeFormatEditMultiLine";
			DateTimeFormatEditMultiLine.PropertyName = "DateTimeFormat";
			DateTimeFormatEditMultiLine.Size = new Size(142, 20);
			DateTimeFormatEditMultiLine.TabIndex = 3;
			label3.LoadingBegin();
			label3.FocusControl = DateTimeFormatEditMultiLine;
			label3.Location = new Point(104, 155);
			label3.Name = "label3";
			label3.Size = new Size(96, 15);
			label3.Text = "Date Time Format";
			label3.LoadingEnd();
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(200, 48);
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(144, 21);
			StyleComboBox.TabIndex = 0;
			label4.LoadingBegin();
			label4.FocusControl = StyleComboBox;
			label4.Location = new Point(168, 50);
			label4.Name = "label4";
			label4.Size = new Size(32, 15);
			label4.Text = "Style";
			label4.LoadingEnd();
			base.Controls.Add(StyleComboBox);
			base.Controls.Add(DateTimeFormatEditMultiLine);
			base.Controls.Add(label3);
			base.Controls.Add(PrecisionNumericUpDown);
			base.Controls.Add(UnitsTextEditMultiLine);
			base.Controls.Add(label11);
			base.Controls.Add(PrecisionStyleComboBox);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Controls.Add(label4);
			base.Location = new Point(10, 20);
			base.Name = "TextFormatDoubleAllEditorPlugIn";
			base.Size = new Size(392, 224);
			base.Title = "Text Formatting Editor";
			base.ResumeLayout(false);
		}
	}
}
