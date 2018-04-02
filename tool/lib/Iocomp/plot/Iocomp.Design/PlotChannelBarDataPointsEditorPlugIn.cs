using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotChannelBarDataPointsEditorPlugIn : PlugInStandard
	{
		private CheckBox DrawCustomDataPointAttributesCheckBox;

		private Container components;

		public PlotChannelBarDataPointsEditorPlugIn()
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
			DrawCustomDataPointAttributesCheckBox = new CheckBox();
			base.SuspendLayout();
			DrawCustomDataPointAttributesCheckBox.Location = new Point(24, 16);
			DrawCustomDataPointAttributesCheckBox.Name = "DrawCustomDataPointAttributesCheckBox";
			DrawCustomDataPointAttributesCheckBox.PropertyName = "DrawCustomDataPointAttributes";
			DrawCustomDataPointAttributesCheckBox.Size = new Size(200, 24);
			DrawCustomDataPointAttributesCheckBox.TabIndex = 0;
			DrawCustomDataPointAttributesCheckBox.Text = "Draw Custom Attributes";
			base.Controls.Add(DrawCustomDataPointAttributesCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelBarDataPointsEditorPlugIn";
			base.Size = new Size(736, 280);
			base.ResumeLayout(false);
		}
	}
}
