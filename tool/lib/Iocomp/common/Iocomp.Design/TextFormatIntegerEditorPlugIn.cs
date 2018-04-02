using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class TextFormatIntegerEditorPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown FixedLengthNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private Container components;

		public TextFormatIntegerEditorPlugIn()
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
			FixedLengthNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			label1 = new FocusLabel();
			base.SuspendLayout();
			label2.LoadingBegin();
			label2.FocusControl = StyleComboBox;
			label2.Location = new Point(64, 26);
			label2.Name = "label2";
			label2.Size = new Size(32, 15);
			label2.Text = "Style";
			label2.LoadingEnd();
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(96, 24);
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(121, 21);
			StyleComboBox.TabIndex = 0;
			FixedLengthNumericUpDown.Location = new Point(96, 56);
			FixedLengthNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			FixedLengthNumericUpDown.Name = "FixedLengthNumericUpDown";
			FixedLengthNumericUpDown.PropertyName = "FixedLength";
			FixedLengthNumericUpDown.Size = new Size(48, 20);
			FixedLengthNumericUpDown.TabIndex = 1;
			FixedLengthNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label1.LoadingBegin();
			label1.FocusControl = FixedLengthNumericUpDown;
			label1.Location = new Point(25, 57);
			label1.Name = "label1";
			label1.Size = new Size(71, 15);
			label1.Text = "Fixed Length";
			label1.LoadingEnd();
			base.Controls.Add(FixedLengthNumericUpDown);
			base.Controls.Add(StyleComboBox);
			base.Controls.Add(label1);
			base.Controls.Add(label2);
			base.Location = new Point(10, 20);
			base.Name = "TextFormatIntegerEditorPlugIn";
			base.Size = new Size(520, 144);
			base.Title = "Text Formatting Editor";
			base.ResumeLayout(false);
		}
	}
}
