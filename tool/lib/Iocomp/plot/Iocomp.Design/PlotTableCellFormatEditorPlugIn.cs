using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotTableCellFormatEditorPlugIn : PlugInStandard
	{
		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private FontButton FontButton;

		private Container components;

		public PlotTableCellFormatEditorPlugIn()
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
			FontButton = new FontButton();
			base.SuspendLayout();
			ColorPicker.Location = new Point(80, 72);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "ForeColor";
			ColorPicker.Size = new Size(48, 21);
			ColorPicker.Style = ColorPickerStyle.ColorBox;
			ColorPicker.TabIndex = 0;
			label8.LoadingBegin();
			label8.FocusControl = ColorPicker;
			label8.Location = new Point(21, 75);
			label8.Name = "label8";
			label8.Size = new Size(59, 15);
			label8.Text = "Fore Color";
			label8.LoadingEnd();
			FontButton.Location = new Point(80, 112);
			FontButton.Name = "FontButton";
			FontButton.PropertyName = "Font";
			FontButton.TabIndex = 1;
			base.Controls.Add(FontButton);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label8);
			base.Name = "PlotTableCellFormatEditorPlugIn";
			base.Size = new Size(424, 288);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotBrushEditorPlugIn(), "Background", false);
			base.AddSubPlugIn(new TextLayoutFullEditorPlugin(), "Text Layout", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotTableCellFormat).Background;
			base.SubPlugIns[1].Value = (base.Value as PlotTableCellFormat).TextLayout;
		}
	}
}
