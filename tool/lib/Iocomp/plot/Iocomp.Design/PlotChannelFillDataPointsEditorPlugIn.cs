using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotChannelFillDataPointsEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox DataPointMoveStyleComboBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanMoveDataPointsCheckBox;

		private Container components;

		public PlotChannelFillDataPointsEditorPlugIn()
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
			DataPointMoveStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel8 = new FocusLabel();
			UserCanMoveDataPointsCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			DataPointMoveStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			DataPointMoveStyleComboBox.Location = new Point(160, 72);
			DataPointMoveStyleComboBox.MaxDropDownItems = 20;
			DataPointMoveStyleComboBox.Name = "DataPointMoveStyleComboBox";
			DataPointMoveStyleComboBox.PropertyName = "DataPointsMoveStyle";
			DataPointMoveStyleComboBox.Size = new Size(80, 21);
			DataPointMoveStyleComboBox.TabIndex = 1;
			focusLabel8.LoadingBegin();
			focusLabel8.FocusControl = DataPointMoveStyleComboBox;
			focusLabel8.Location = new Point(43, 74);
			focusLabel8.Name = "focusLabel8";
			focusLabel8.Size = new Size(117, 15);
			focusLabel8.Text = "Data-Point Move Style";
			focusLabel8.LoadingEnd();
			UserCanMoveDataPointsCheckBox.Location = new Point(24, 40);
			UserCanMoveDataPointsCheckBox.Name = "UserCanMoveDataPointsCheckBox";
			UserCanMoveDataPointsCheckBox.PropertyName = "UserCanMoveDataPoints";
			UserCanMoveDataPointsCheckBox.Size = new Size(176, 24);
			UserCanMoveDataPointsCheckBox.TabIndex = 0;
			UserCanMoveDataPointsCheckBox.Text = "User Can Move Data-Points";
			base.Controls.Add(DataPointMoveStyleComboBox);
			base.Controls.Add(focusLabel8);
			base.Controls.Add(UserCanMoveDataPointsCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelFillDataPointsEditorPlugIn";
			base.Size = new Size(552, 264);
			base.ResumeLayout(false);
		}
	}
}
