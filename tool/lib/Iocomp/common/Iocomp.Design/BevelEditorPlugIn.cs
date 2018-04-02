using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class BevelEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ThicknessComboBox;

		private FocusLabel label4;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginEdgeNumericUpDown;

		private Container components;

		public BevelEditorPlugIn()
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
			label1 = new FocusLabel();
			ThicknessComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label4 = new FocusLabel();
			MarginEdgeNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			base.SuspendLayout();
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(96, 56);
			StyleComboBox.MaxDropDownItems = 20;
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(144, 21);
			StyleComboBox.TabIndex = 1;
			label2.LoadingBegin();
			label2.FocusControl = StyleComboBox;
			label2.Location = new Point(64, 58);
			label2.Name = "label2";
			label2.Size = new Size(32, 15);
			label2.Text = "Style";
			label2.LoadingEnd();
			VisibleCheckBox.Location = new Point(96, 24);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			label1.LoadingBegin();
			label1.FocusControl = ThicknessComboBox;
			label1.Location = new Point(39, 82);
			label1.Name = "label1";
			label1.Size = new Size(57, 15);
			label1.Text = "Thickness";
			label1.LoadingEnd();
			ThicknessComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ThicknessComboBox.Location = new Point(96, 80);
			ThicknessComboBox.MaxDropDownItems = 20;
			ThicknessComboBox.Name = "ThicknessComboBox";
			ThicknessComboBox.PropertyName = "Thickness";
			ThicknessComboBox.Size = new Size(48, 21);
			ThicknessComboBox.TabIndex = 2;
			label4.LoadingBegin();
			label4.FocusControl = MarginEdgeNumericUpDown;
			label4.Location = new Point(26, 105);
			label4.Name = "label4";
			label4.Size = new Size(70, 15);
			label4.Text = "Margin Edge";
			label4.LoadingEnd();
			MarginEdgeNumericUpDown.Location = new Point(96, 104);
			MarginEdgeNumericUpDown.Name = "MarginEdgeNumericUpDown";
			MarginEdgeNumericUpDown.PropertyName = "MarginEdge";
			MarginEdgeNumericUpDown.Size = new Size(48, 20);
			MarginEdgeNumericUpDown.TabIndex = 3;
			MarginEdgeNumericUpDown.TextAlign = HorizontalAlignment.Center;
			base.Controls.Add(MarginEdgeNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(ThicknessComboBox);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(label2);
			base.Controls.Add(StyleComboBox);
			base.Controls.Add(label4);
			base.Name = "BevelEditorPlugIn";
			base.Size = new Size(392, 176);
			base.Title = "Bevel Editor";
			base.ResumeLayout(false);
		}
	}
}
