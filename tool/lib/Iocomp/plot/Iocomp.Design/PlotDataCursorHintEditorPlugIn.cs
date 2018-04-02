using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotDataCursorHintEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel2;

		private EditBox PositionTextBox;

		private CheckBox HideOnReleaseCheckBox;

		private FontButton FontButton;

		private FocusLabel focusLabel11;

		private ColorPicker ForeColorPicker;

		private CheckBox VisibleCheckBox;

		private Container components;

		public PlotDataCursorHintEditorPlugIn()
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
			HideOnReleaseCheckBox = new CheckBox();
			PositionTextBox = new EditBox();
			focusLabel2 = new FocusLabel();
			FontButton = new FontButton();
			focusLabel11 = new FocusLabel();
			ForeColorPicker = new ColorPicker();
			VisibleCheckBox = new CheckBox();
			base.SuspendLayout();
			HideOnReleaseCheckBox.Location = new Point(272, 88);
			HideOnReleaseCheckBox.Name = "HideOnReleaseCheckBox";
			HideOnReleaseCheckBox.PropertyName = "HideOnRelease";
			HideOnReleaseCheckBox.Size = new Size(152, 24);
			HideOnReleaseCheckBox.TabIndex = 2;
			HideOnReleaseCheckBox.Text = "Hide On Release";
			PositionTextBox.LoadingBegin();
			PositionTextBox.Location = new Point(120, 88);
			PositionTextBox.Name = "PositionTextBox";
			PositionTextBox.PropertyName = "Position";
			PositionTextBox.Size = new Size(136, 20);
			PositionTextBox.TabIndex = 1;
			PositionTextBox.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = PositionTextBox;
			focusLabel2.Location = new Point(73, 90);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(47, 15);
			focusLabel2.Text = "Position";
			focusLabel2.LoadingEnd();
			FontButton.Location = new Point(120, 152);
			FontButton.Name = "FontButton";
			FontButton.PropertyName = "Font";
			FontButton.Size = new Size(72, 23);
			FontButton.TabIndex = 4;
			focusLabel11.LoadingBegin();
			focusLabel11.FocusControl = ForeColorPicker;
			focusLabel11.Location = new Point(61, 123);
			focusLabel11.Name = "focusLabel11";
			focusLabel11.Size = new Size(59, 15);
			focusLabel11.Text = "Fore Color";
			focusLabel11.LoadingEnd();
			ForeColorPicker.Location = new Point(120, 120);
			ForeColorPicker.Name = "ForeColorPicker";
			ForeColorPicker.PropertyName = "ForeColor";
			ForeColorPicker.Size = new Size(49, 21);
			ForeColorPicker.Style = ColorPickerStyle.ColorBox;
			ForeColorPicker.TabIndex = 3;
			VisibleCheckBox.Location = new Point(120, 48);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(152, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			base.Controls.Add(VisibleCheckBox);
			base.Controls.Add(FontButton);
			base.Controls.Add(focusLabel11);
			base.Controls.Add(ForeColorPicker);
			base.Controls.Add(PositionTextBox);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(HideOnReleaseCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotDataCursorHintEditorPlugIn";
			base.Size = new Size(504, 336);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotDataCursorHint).Fill;
		}
	}
}
