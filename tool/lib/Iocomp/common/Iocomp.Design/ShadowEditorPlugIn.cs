using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ShadowEditorPlugIn : PlugInStandard
	{
		private FocusLabel ColorLabel;

		private ColorPicker ColorPicker;

		private FocusLabel label2;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown OffsetNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.CheckBox StretchedcheckBox;

		private FocusLabel label3;

		private Container components;

		public ShadowEditorPlugIn()
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
			ColorLabel = new FocusLabel();
			ColorPicker = new ColorPicker();
			label2 = new FocusLabel();
			StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			OffsetNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			StretchedcheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			label3 = new FocusLabel();
			base.SuspendLayout();
			ColorLabel.LoadingBegin();
			ColorLabel.AutoSize = false;
			ColorLabel.FocusControl = ColorPicker;
			ColorLabel.Location = new Point(48, 138);
			ColorLabel.Name = "ColorLabel";
			ColorLabel.Size = new Size(40, 16);
			ColorLabel.Text = "Color";
			ColorLabel.LoadingEnd();
			ColorPicker.Location = new Point(88, 136);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(144, 21);
			ColorPicker.TabIndex = 3;
			label2.LoadingBegin();
			label2.AutoSize = false;
			label2.FocusControl = StyleComboBox;
			label2.Location = new Point(48, 25);
			label2.Name = "label2";
			label2.Size = new Size(40, 16);
			label2.Text = "Style";
			label2.LoadingEnd();
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(88, 24);
			StyleComboBox.MaxDropDownItems = 20;
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(144, 21);
			StyleComboBox.TabIndex = 0;
			OffsetNumericUpDown.Location = new Point(88, 56);
			OffsetNumericUpDown.Name = "OffsetNumericUpDown";
			OffsetNumericUpDown.PropertyName = "Offset";
			OffsetNumericUpDown.Size = new Size(48, 20);
			OffsetNumericUpDown.TabIndex = 1;
			OffsetNumericUpDown.TextAlign = HorizontalAlignment.Center;
			StretchedcheckBox.Location = new Point(88, 96);
			StretchedcheckBox.Name = "StretchedcheckBox";
			StretchedcheckBox.PropertyName = "Stretched";
			StretchedcheckBox.Size = new Size(80, 24);
			StretchedcheckBox.TabIndex = 2;
			StretchedcheckBox.Text = "Stretched";
			label3.LoadingBegin();
			label3.AutoSize = false;
			label3.FocusControl = OffsetNumericUpDown;
			label3.Location = new Point(50, 56);
			label3.Name = "label3";
			label3.Size = new Size(38, 16);
			label3.Text = "Offset";
			label3.LoadingEnd();
			base.Controls.Add(ColorLabel);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label2);
			base.Controls.Add(StyleComboBox);
			base.Controls.Add(OffsetNumericUpDown);
			base.Controls.Add(StretchedcheckBox);
			base.Controls.Add(label3);
			base.Location = new Point(10, 20);
			base.Name = "ShadowEditorPlugIn";
			base.Size = new Size(544, 248);
			base.Title = "Shadow Editor";
			base.ResumeLayout(false);
		}
	}
}
