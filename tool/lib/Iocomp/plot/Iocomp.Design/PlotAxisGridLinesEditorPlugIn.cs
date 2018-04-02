using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotAxisGridLinesEditorPlugIn : PlugInStandard
	{
		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private CheckBox VisibleCheckBox;

		private CheckBox ShowOnTopCheckBox;

		private Container components;

		public PlotAxisGridLinesEditorPlugIn()
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
			ColorPicker = new ColorPicker();
			label8 = new FocusLabel();
			VisibleCheckBox = new CheckBox();
			ShowOnTopCheckBox = new CheckBox();
			base.SuspendLayout();
			ColorPicker.Location = new Point(80, 96);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(48, 21);
			ColorPicker.Style = ColorPickerStyle.ColorBox;
			ColorPicker.TabIndex = 1;
			label8.LoadingBegin();
			label8.FocusControl = ColorPicker;
			label8.Location = new Point(46, 99);
			label8.Name = "label8";
			label8.Size = new Size(34, 15);
			label8.Text = "Color";
			label8.LoadingEnd();
			VisibleCheckBox.Location = new Point(80, 32);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(72, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			ShowOnTopCheckBox.Location = new Point(80, 56);
			ShowOnTopCheckBox.Name = "ShowOnTopCheckBox";
			ShowOnTopCheckBox.PropertyName = "ShowOnTop";
			ShowOnTopCheckBox.TabIndex = 3;
			ShowOnTopCheckBox.Text = "Show On Top";
			base.Controls.Add(ShowOnTopCheckBox);
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label8);
			base.Name = "PlotAxisGridLinesEditorPlugIn";
			base.Size = new Size(424, 288);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Major", false);
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Mid", false);
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Minor", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotAxisGridLines).Major;
			base.SubPlugIns[1].Value = (base.Value as PlotAxisGridLines).Mid;
			base.SubPlugIns[2].Value = (base.Value as PlotAxisGridLines).Minor;
		}
	}
}
