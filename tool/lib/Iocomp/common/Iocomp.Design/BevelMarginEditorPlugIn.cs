using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class BevelMarginEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ThicknessComboBox;

		private FocusLabel label4;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginEdgeNumericUpDown;

		private FocusLabel label3;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginNumericUpDown;

		private Container components;

		public BevelMarginEditorPlugIn()
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
			label3 = new FocusLabel();
			MarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			base.SuspendLayout();
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(96, 40);
			StyleComboBox.MaxDropDownItems = 20;
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(144, 21);
			StyleComboBox.TabIndex = 1;
			label2.LoadingBegin();
			label2.FocusControl = StyleComboBox;
			label2.Location = new Point(64, 42);
			label2.Name = "label2";
			label2.Size = new Size(32, 15);
			label2.Text = "Style";
			label2.LoadingEnd();
			VisibleCheckBox.Location = new Point(96, 8);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			label1.LoadingBegin();
			label1.FocusControl = ThicknessComboBox;
			label1.Location = new Point(39, 66);
			label1.Name = "label1";
			label1.Size = new Size(57, 15);
			label1.Text = "Thickness";
			label1.LoadingEnd();
			ThicknessComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ThicknessComboBox.Location = new Point(96, 64);
			ThicknessComboBox.MaxDropDownItems = 20;
			ThicknessComboBox.Name = "ThicknessComboBox";
			ThicknessComboBox.PropertyName = "Thickness";
			ThicknessComboBox.Size = new Size(48, 21);
			ThicknessComboBox.TabIndex = 2;
			label4.LoadingBegin();
			label4.FocusControl = MarginEdgeNumericUpDown;
			label4.Location = new Point(26, 113);
			label4.Name = "label4";
			label4.Size = new Size(70, 15);
			label4.Text = "Margin Edge";
			label4.LoadingEnd();
			MarginEdgeNumericUpDown.Location = new Point(96, 112);
			MarginEdgeNumericUpDown.Name = "MarginEdgeNumericUpDown";
			MarginEdgeNumericUpDown.PropertyName = "MarginEdge";
			MarginEdgeNumericUpDown.Size = new Size(48, 20);
			MarginEdgeNumericUpDown.TabIndex = 4;
			MarginEdgeNumericUpDown.TextAlign = HorizontalAlignment.Center;
			label3.LoadingBegin();
			label3.FocusControl = MarginNumericUpDown;
			label3.Location = new Point(55, 89);
			label3.Name = "label3";
			label3.Size = new Size(41, 15);
			label3.Text = "Margin";
			label3.LoadingEnd();
			MarginNumericUpDown.Location = new Point(96, 88);
			MarginNumericUpDown.Name = "MarginNumericUpDown";
			MarginNumericUpDown.PropertyName = "Margin";
			MarginNumericUpDown.Size = new Size(48, 20);
			MarginNumericUpDown.TabIndex = 3;
			MarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			base.Controls.Add(label3);
			base.Controls.Add(MarginNumericUpDown);
			base.Controls.Add(label4);
			base.Controls.Add(MarginEdgeNumericUpDown);
			base.Controls.Add(label1);
			base.Controls.Add(ThicknessComboBox);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(label2);
			base.Controls.Add(StyleComboBox);
			base.Name = "BevelMarginEditorPlugIn";
			base.Size = new Size(368, 240);
			base.Title = "Bevel Editor";
			base.ResumeLayout(false);
		}
	}
}
