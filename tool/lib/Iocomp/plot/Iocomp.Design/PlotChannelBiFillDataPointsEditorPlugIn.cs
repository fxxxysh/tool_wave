using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotChannelBiFillDataPointsEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox DataPointMoveStyleComboBox;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanMoveDataPointsCheckBox;

		private Container components;

		public PlotChannelBiFillDataPointsEditorPlugIn()
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
			focusLabel6 = new FocusLabel();
			UserCanMoveDataPointsCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			DataPointMoveStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			DataPointMoveStyleComboBox.Location = new Point(104, 72);
			DataPointMoveStyleComboBox.MaxDropDownItems = 20;
			DataPointMoveStyleComboBox.Name = "DataPointMoveStyleComboBox";
			DataPointMoveStyleComboBox.PropertyName = "DataPointsMoveStyle";
			DataPointMoveStyleComboBox.Size = new Size(80, 21);
			DataPointMoveStyleComboBox.TabIndex = 1;
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = DataPointMoveStyleComboBox;
			focusLabel6.Location = new Point(43, 74);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(61, 15);
			focusLabel6.Text = "Move Style";
			focusLabel6.LoadingEnd();
			UserCanMoveDataPointsCheckBox.Location = new Point(24, 40);
			UserCanMoveDataPointsCheckBox.Name = "UserCanMoveDataPointsCheckBox";
			UserCanMoveDataPointsCheckBox.PropertyName = "UserCanMoveDataPoints";
			UserCanMoveDataPointsCheckBox.Size = new Size(176, 24);
			UserCanMoveDataPointsCheckBox.TabIndex = 0;
			UserCanMoveDataPointsCheckBox.Text = "User Can Move";
			base.Controls.Add(DataPointMoveStyleComboBox);
			base.Controls.Add(focusLabel6);
			base.Controls.Add(UserCanMoveDataPointsCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelBiFillDataPointsEditorPlugIn";
			base.Size = new Size(592, 288);
			base.ResumeLayout(false);
		}
	}
}
