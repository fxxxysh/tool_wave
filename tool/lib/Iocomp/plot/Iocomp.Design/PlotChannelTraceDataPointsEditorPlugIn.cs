using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotChannelTraceDataPointsEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanMoveDataPointsCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DataPointMoveStyleComboBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox DrawCustomDataPointAttributesCheckBox;

		private Container components;

		public PlotChannelTraceDataPointsEditorPlugIn()
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
			UserCanMoveDataPointsCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			DataPointMoveStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel8 = new FocusLabel();
			DrawCustomDataPointAttributesCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			UserCanMoveDataPointsCheckBox.Location = new Point(24, 40);
			UserCanMoveDataPointsCheckBox.Name = "UserCanMoveDataPointsCheckBox";
			UserCanMoveDataPointsCheckBox.PropertyName = "UserCanMoveDataPoints";
			UserCanMoveDataPointsCheckBox.Size = new Size(176, 24);
			UserCanMoveDataPointsCheckBox.TabIndex = 1;
			UserCanMoveDataPointsCheckBox.Text = "User Can Move";
			DataPointMoveStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			DataPointMoveStyleComboBox.Location = new Point(104, 72);
			DataPointMoveStyleComboBox.MaxDropDownItems = 20;
			DataPointMoveStyleComboBox.Name = "DataPointMoveStyleComboBox";
			DataPointMoveStyleComboBox.PropertyName = "DataPointsMoveStyle";
			DataPointMoveStyleComboBox.Size = new Size(80, 21);
			DataPointMoveStyleComboBox.TabIndex = 2;
			focusLabel8.LoadingBegin();
			focusLabel8.FocusControl = DataPointMoveStyleComboBox;
			focusLabel8.Location = new Point(43, 74);
			focusLabel8.Name = "focusLabel8";
			focusLabel8.Size = new Size(61, 15);
			focusLabel8.Text = "Move Style";
			focusLabel8.LoadingEnd();
			DrawCustomDataPointAttributesCheckBox.Location = new Point(24, 16);
			DrawCustomDataPointAttributesCheckBox.Name = "DrawCustomDataPointAttributesCheckBox";
			DrawCustomDataPointAttributesCheckBox.PropertyName = "DrawCustomDataPointAttributes";
			DrawCustomDataPointAttributesCheckBox.Size = new Size(200, 24);
			DrawCustomDataPointAttributesCheckBox.TabIndex = 0;
			DrawCustomDataPointAttributesCheckBox.Text = "Draw Custom Attributes";
			base.Controls.Add(DrawCustomDataPointAttributesCheckBox);
			base.Controls.Add(DataPointMoveStyleComboBox);
			base.Controls.Add(focusLabel8);
			base.Controls.Add(UserCanMoveDataPointsCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelTraceDataPointsEditorPlugIn";
			base.Size = new Size(664, 280);
			base.ResumeLayout(false);
		}
	}
}
