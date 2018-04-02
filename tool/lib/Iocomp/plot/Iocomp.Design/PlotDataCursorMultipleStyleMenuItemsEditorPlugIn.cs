using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotDataCursorMultipleStyleMenuItemsEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel2;

		private EditBox CaptionValueXTextBox;

		private FocusLabel focusLabel1;

		private FocusLabel focusLabel3;

		private FocusLabel focusLabel4;

		private FocusLabel focusLabel5;

		private FocusLabel focusLabel6;

		private FocusLabel focusLabel7;

		private EditBox CaptionValueYEditBox;

		private EditBox CaptionValueXYEditBox;

		private EditBox CaptionDeltaXEditBox;

		private EditBox CaptionDeltaYEditBox;

		private EditBox CaptionInverseDeltaXEditBox;

		private EditBox CaptionInverseDeltaYEditBox;

		private CheckBox ShowValueYCheckBox;

		private CheckBox ShowValueXYCheckBox;

		private CheckBox ShowDeltaXCheckBox;

		private CheckBox ShowValueXCheckBox;

		private CheckBox ShowDeltaYCheckBox;

		private CheckBox ShowInverseDeltaXCheckBox;

		private CheckBox ShowInverseDeltaYCheckBox;

		private Container components;

		public PlotDataCursorMultipleStyleMenuItemsEditorPlugIn()
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
			ShowValueXCheckBox = new CheckBox();
			CaptionValueXTextBox = new EditBox();
			focusLabel2 = new FocusLabel();
			CaptionValueYEditBox = new EditBox();
			focusLabel1 = new FocusLabel();
			ShowValueYCheckBox = new CheckBox();
			CaptionValueXYEditBox = new EditBox();
			focusLabel3 = new FocusLabel();
			ShowValueXYCheckBox = new CheckBox();
			CaptionDeltaXEditBox = new EditBox();
			focusLabel4 = new FocusLabel();
			ShowDeltaXCheckBox = new CheckBox();
			CaptionDeltaYEditBox = new EditBox();
			focusLabel5 = new FocusLabel();
			ShowDeltaYCheckBox = new CheckBox();
			CaptionInverseDeltaXEditBox = new EditBox();
			focusLabel6 = new FocusLabel();
			ShowInverseDeltaXCheckBox = new CheckBox();
			CaptionInverseDeltaYEditBox = new EditBox();
			focusLabel7 = new FocusLabel();
			ShowInverseDeltaYCheckBox = new CheckBox();
			base.SuspendLayout();
			ShowValueXCheckBox.Location = new Point(288, 87);
			ShowValueXCheckBox.Name = "ShowValueXCheckBox";
			ShowValueXCheckBox.PropertyName = "ShowValueX";
			ShowValueXCheckBox.Size = new Size(60, 24);
			ShowValueXCheckBox.TabIndex = 1;
			ShowValueXCheckBox.Text = "Show";
			CaptionValueXTextBox.LoadingBegin();
			CaptionValueXTextBox.Location = new Point(144, 88);
			CaptionValueXTextBox.Name = "CaptionValueXTextBox";
			CaptionValueXTextBox.PropertyName = "CaptionValueX";
			CaptionValueXTextBox.Size = new Size(136, 20);
			CaptionValueXTextBox.TabIndex = 0;
			CaptionValueXTextBox.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = CaptionValueXTextBox;
			focusLabel2.Location = new Point(57, 90);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(87, 15);
			focusLabel2.Text = "Caption Value X";
			focusLabel2.LoadingEnd();
			CaptionValueYEditBox.LoadingBegin();
			CaptionValueYEditBox.Location = new Point(144, 112);
			CaptionValueYEditBox.Name = "CaptionValueYEditBox";
			CaptionValueYEditBox.PropertyName = "CaptionValueY";
			CaptionValueYEditBox.Size = new Size(136, 20);
			CaptionValueYEditBox.TabIndex = 2;
			CaptionValueYEditBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = CaptionValueYEditBox;
			focusLabel1.Location = new Point(57, 114);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(87, 15);
			focusLabel1.Text = "Caption Value Y";
			focusLabel1.LoadingEnd();
			ShowValueYCheckBox.Location = new Point(288, 112);
			ShowValueYCheckBox.Name = "ShowValueYCheckBox";
			ShowValueYCheckBox.PropertyName = "ShowValueY";
			ShowValueYCheckBox.Size = new Size(60, 24);
			ShowValueYCheckBox.TabIndex = 3;
			ShowValueYCheckBox.Text = "Show";
			CaptionValueXYEditBox.LoadingBegin();
			CaptionValueXYEditBox.Location = new Point(144, 136);
			CaptionValueXYEditBox.Name = "CaptionValueXYEditBox";
			CaptionValueXYEditBox.PropertyName = "CaptionValueXY";
			CaptionValueXYEditBox.Size = new Size(136, 20);
			CaptionValueXYEditBox.TabIndex = 4;
			CaptionValueXYEditBox.LoadingEnd();
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = CaptionValueXYEditBox;
			focusLabel3.Location = new Point(50, 138);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(94, 15);
			focusLabel3.Text = "Caption Value XY";
			focusLabel3.LoadingEnd();
			ShowValueXYCheckBox.Location = new Point(288, 136);
			ShowValueXYCheckBox.Name = "ShowValueXYCheckBox";
			ShowValueXYCheckBox.PropertyName = "ShowValueXY";
			ShowValueXYCheckBox.Size = new Size(60, 24);
			ShowValueXYCheckBox.TabIndex = 5;
			ShowValueXYCheckBox.Text = "Show";
			CaptionDeltaXEditBox.LoadingBegin();
			CaptionDeltaXEditBox.Location = new Point(144, 160);
			CaptionDeltaXEditBox.Name = "CaptionDeltaXEditBox";
			CaptionDeltaXEditBox.PropertyName = "CaptionDeltaX";
			CaptionDeltaXEditBox.Size = new Size(136, 20);
			CaptionDeltaXEditBox.TabIndex = 6;
			CaptionDeltaXEditBox.LoadingEnd();
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = CaptionDeltaXEditBox;
			focusLabel4.Location = new Point(60, 162);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(84, 15);
			focusLabel4.Text = "Caption Delta X";
			focusLabel4.LoadingEnd();
			ShowDeltaXCheckBox.Location = new Point(288, 160);
			ShowDeltaXCheckBox.Name = "ShowDeltaXCheckBox";
			ShowDeltaXCheckBox.PropertyName = "ShowDeltaX";
			ShowDeltaXCheckBox.Size = new Size(60, 24);
			ShowDeltaXCheckBox.TabIndex = 7;
			ShowDeltaXCheckBox.Text = "Show";
			CaptionDeltaYEditBox.LoadingBegin();
			CaptionDeltaYEditBox.Location = new Point(144, 184);
			CaptionDeltaYEditBox.Name = "CaptionDeltaYEditBox";
			CaptionDeltaYEditBox.PropertyName = "CaptionDeltaY";
			CaptionDeltaYEditBox.Size = new Size(136, 20);
			CaptionDeltaYEditBox.TabIndex = 8;
			CaptionDeltaYEditBox.LoadingEnd();
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = CaptionDeltaYEditBox;
			focusLabel5.Location = new Point(60, 186);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(84, 15);
			focusLabel5.Text = "Caption Delta Y";
			focusLabel5.LoadingEnd();
			ShowDeltaYCheckBox.Location = new Point(288, 184);
			ShowDeltaYCheckBox.Name = "ShowDeltaYCheckBox";
			ShowDeltaYCheckBox.PropertyName = "ShowDeltaY";
			ShowDeltaYCheckBox.Size = new Size(60, 24);
			ShowDeltaYCheckBox.TabIndex = 9;
			ShowDeltaYCheckBox.Text = "Show";
			CaptionInverseDeltaXEditBox.LoadingBegin();
			CaptionInverseDeltaXEditBox.Location = new Point(144, 208);
			CaptionInverseDeltaXEditBox.Name = "CaptionInverseDeltaXEditBox";
			CaptionInverseDeltaXEditBox.PropertyName = "CaptionInverseDeltaX";
			CaptionInverseDeltaXEditBox.Size = new Size(136, 20);
			CaptionInverseDeltaXEditBox.TabIndex = 10;
			CaptionInverseDeltaXEditBox.LoadingEnd();
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = CaptionInverseDeltaXEditBox;
			focusLabel6.Location = new Point(21, 210);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(123, 15);
			focusLabel6.Text = "Caption Inverse Delta X";
			focusLabel6.LoadingEnd();
			ShowInverseDeltaXCheckBox.Location = new Point(288, 208);
			ShowInverseDeltaXCheckBox.Name = "ShowInverseDeltaXCheckBox";
			ShowInverseDeltaXCheckBox.PropertyName = "ShowInverseDeltaX";
			ShowInverseDeltaXCheckBox.Size = new Size(60, 24);
			ShowInverseDeltaXCheckBox.TabIndex = 11;
			ShowInverseDeltaXCheckBox.Text = "Show";
			CaptionInverseDeltaYEditBox.LoadingBegin();
			CaptionInverseDeltaYEditBox.Location = new Point(144, 232);
			CaptionInverseDeltaYEditBox.Name = "CaptionInverseDeltaYEditBox";
			CaptionInverseDeltaYEditBox.PropertyName = "CaptionInverseDeltaY";
			CaptionInverseDeltaYEditBox.Size = new Size(136, 20);
			CaptionInverseDeltaYEditBox.TabIndex = 12;
			CaptionInverseDeltaYEditBox.LoadingEnd();
			focusLabel7.LoadingBegin();
			focusLabel7.FocusControl = CaptionInverseDeltaYEditBox;
			focusLabel7.Location = new Point(21, 234);
			focusLabel7.Name = "focusLabel7";
			focusLabel7.Size = new Size(123, 15);
			focusLabel7.Text = "Caption Inverse Delta Y";
			focusLabel7.LoadingEnd();
			ShowInverseDeltaYCheckBox.Location = new Point(288, 232);
			ShowInverseDeltaYCheckBox.Name = "ShowInverseDeltaYCheckBox";
			ShowInverseDeltaYCheckBox.PropertyName = "ShowInverseDeltaY";
			ShowInverseDeltaYCheckBox.Size = new Size(60, 24);
			ShowInverseDeltaYCheckBox.TabIndex = 13;
			ShowInverseDeltaYCheckBox.Text = "Show";
			base.Controls.Add(CaptionInverseDeltaYEditBox);
			base.Controls.Add(focusLabel7);
			base.Controls.Add(ShowInverseDeltaYCheckBox);
			base.Controls.Add(CaptionInverseDeltaXEditBox);
			base.Controls.Add(focusLabel6);
			base.Controls.Add(ShowInverseDeltaXCheckBox);
			base.Controls.Add(CaptionDeltaYEditBox);
			base.Controls.Add(focusLabel5);
			base.Controls.Add(ShowDeltaYCheckBox);
			base.Controls.Add(CaptionDeltaXEditBox);
			base.Controls.Add(focusLabel4);
			base.Controls.Add(ShowDeltaXCheckBox);
			base.Controls.Add(CaptionValueXYEditBox);
			base.Controls.Add(focusLabel3);
			base.Controls.Add(ShowValueXYCheckBox);
			base.Controls.Add(CaptionValueYEditBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(ShowValueYCheckBox);
			base.Controls.Add(CaptionValueXTextBox);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(ShowValueXCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotDataCursorMultipleStyleMenuItemsEditorPlugIn";
			base.Size = new Size(504, 336);
			base.ResumeLayout(false);
		}
	}
}
