using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotLayoutDataViewEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel1;

		private FocusLabel focusLabel3;

		private EditBox DockOrderTextBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DockSideComboBox;

		private FocusLabel label2;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown DockMarginUpDown;

		private FocusLabel focusLabel6;

		private EditBox DockDepthRatioTextBox;

		private EditBox StackingGroupIndexEditBox;

		private FocusLabel focusLabel2;

		private Container components;

		public PlotLayoutDataViewEditorPlugIn()
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
			DockOrderTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			DockDepthRatioTextBox = new EditBox();
			focusLabel3 = new FocusLabel();
			DockSideComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label2 = new FocusLabel();
			DockMarginUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			focusLabel6 = new FocusLabel();
			StackingGroupIndexEditBox = new EditBox();
			focusLabel2 = new FocusLabel();
			((ISupportInitialize)DockMarginUpDown).BeginInit();
			base.SuspendLayout();
			DockOrderTextBox.LoadingBegin();
			DockOrderTextBox.Location = new Point(120, 192);
			DockOrderTextBox.Name = "DockOrderTextBox";
			DockOrderTextBox.PropertyName = "DockOrder";
			DockOrderTextBox.ReadOnly = true;
			DockOrderTextBox.Size = new Size(136, 20);
			DockOrderTextBox.TabIndex = 3;
			DockOrderTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = DockOrderTextBox;
			focusLabel1.Location = new Point(84, 194);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(36, 15);
			focusLabel1.Text = "Order";
			focusLabel1.LoadingEnd();
			DockDepthRatioTextBox.LoadingBegin();
			DockDepthRatioTextBox.Location = new Point(120, 48);
			DockDepthRatioTextBox.Name = "DockDepthRatioTextBox";
			DockDepthRatioTextBox.PropertyName = "DockDepthRatio";
			DockDepthRatioTextBox.Size = new Size(136, 20);
			DockDepthRatioTextBox.TabIndex = 1;
			DockDepthRatioTextBox.LoadingEnd();
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = DockDepthRatioTextBox;
			focusLabel3.Location = new Point(54, 50);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(66, 15);
			focusLabel3.Text = "Depth Ratio";
			focusLabel3.LoadingEnd();
			DockSideComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			DockSideComboBox.Location = new Point(120, 168);
			DockSideComboBox.MaxDropDownItems = 20;
			DockSideComboBox.Name = "DockSideComboBox";
			DockSideComboBox.PropertyName = "DockSide";
			DockSideComboBox.ReadOnly = true;
			DockSideComboBox.Size = new Size(136, 21);
			DockSideComboBox.TabIndex = 2;
			label2.LoadingBegin();
			label2.FocusControl = DockSideComboBox;
			label2.Location = new Point(90, 170);
			label2.Name = "label2";
			label2.Size = new Size(30, 15);
			label2.Text = "Side";
			label2.LoadingEnd();
			DockMarginUpDown.Location = new Point(120, 16);
			DockMarginUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			DockMarginUpDown.Minimum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				-2147483648
			});
			DockMarginUpDown.Name = "DockMarginUpDown";
			DockMarginUpDown.PropertyName = "DockMargin";
			DockMarginUpDown.Size = new Size(48, 20);
			DockMarginUpDown.TabIndex = 0;
			DockMarginUpDown.TextAlign = HorizontalAlignment.Center;
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = DockMarginUpDown;
			focusLabel6.Location = new Point(79, 17);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(41, 15);
			focusLabel6.Text = "Margin";
			focusLabel6.LoadingEnd();
			StackingGroupIndexEditBox.LoadingBegin();
			StackingGroupIndexEditBox.Location = new Point(120, 216);
			StackingGroupIndexEditBox.Name = "StackingGroupIndexEditBox";
			StackingGroupIndexEditBox.PropertyName = "StackingGroupIndex";
			StackingGroupIndexEditBox.ReadOnly = true;
			StackingGroupIndexEditBox.Size = new Size(136, 20);
			StackingGroupIndexEditBox.TabIndex = 4;
			StackingGroupIndexEditBox.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = StackingGroupIndexEditBox;
			focusLabel2.Location = new Point(7, 218);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(113, 15);
			focusLabel2.Text = "Stacking Group Index";
			focusLabel2.LoadingEnd();
			base.Controls.Add(StackingGroupIndexEditBox);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(DockMarginUpDown);
			base.Controls.Add(focusLabel6);
			base.Controls.Add(DockSideComboBox);
			base.Controls.Add(label2);
			base.Controls.Add(DockDepthRatioTextBox);
			base.Controls.Add(focusLabel3);
			base.Controls.Add(DockOrderTextBox);
			base.Controls.Add(focusLabel1);
			base.Location = new Point(10, 20);
			base.Name = "PlotLayoutDataViewEditorPlugIn";
			base.Size = new Size(456, 248);
			((ISupportInitialize)DockMarginUpDown).EndInit();
			base.ResumeLayout(false);
		}
	}
}
