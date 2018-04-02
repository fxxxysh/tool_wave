using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotChannelBubbleSpecificEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox RequireConsecutiveDataCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox RadiusStyleComboBox;

		private FocusLabel focusLabel7;

		private EditBox RadiusTextBox;

		private FocusLabel focusLabel6;

		private Container components;

		public PlotChannelBubbleSpecificEditorPlugIn()
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
			RequireConsecutiveDataCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			RadiusStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel7 = new FocusLabel();
			RadiusTextBox = new EditBox();
			focusLabel6 = new FocusLabel();
			base.SuspendLayout();
			RequireConsecutiveDataCheckBox.Location = new Point(88, 32);
			RequireConsecutiveDataCheckBox.Name = "RequireConsecutiveDataCheckBox";
			RequireConsecutiveDataCheckBox.PropertyName = "RequireConsecutiveData";
			RequireConsecutiveDataCheckBox.Size = new Size(168, 24);
			RequireConsecutiveDataCheckBox.TabIndex = 0;
			RequireConsecutiveDataCheckBox.Text = "Require Consecutive Data";
			RadiusStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			RadiusStyleComboBox.Location = new Point(88, 88);
			RadiusStyleComboBox.MaxDropDownItems = 20;
			RadiusStyleComboBox.Name = "RadiusStyleComboBox";
			RadiusStyleComboBox.PropertyName = "RadiusStyle";
			RadiusStyleComboBox.Size = new Size(80, 21);
			RadiusStyleComboBox.TabIndex = 2;
			focusLabel7.LoadingBegin();
			focusLabel7.FocusControl = RadiusStyleComboBox;
			focusLabel7.Location = new Point(19, 90);
			focusLabel7.Name = "focusLabel7";
			focusLabel7.Size = new Size(69, 15);
			focusLabel7.Text = "Radius Style";
			focusLabel7.LoadingEnd();
			RadiusTextBox.LoadingBegin();
			RadiusTextBox.Location = new Point(88, 64);
			RadiusTextBox.Name = "RadiusTextBox";
			RadiusTextBox.PropertyName = "Radius";
			RadiusTextBox.Size = new Size(80, 20);
			RadiusTextBox.TabIndex = 1;
			RadiusTextBox.LoadingEnd();
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = RadiusTextBox;
			focusLabel6.Location = new Point(46, 66);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(42, 15);
			focusLabel6.Text = "Radius";
			focusLabel6.LoadingEnd();
			base.Controls.Add(RequireConsecutiveDataCheckBox);
			base.Controls.Add(RadiusStyleComboBox);
			base.Controls.Add(focusLabel7);
			base.Controls.Add(RadiusTextBox);
			base.Controls.Add(focusLabel6);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelBubbleSpecificEditorPlugIn";
			base.Size = new Size(480, 248);
			base.ResumeLayout(false);
		}
	}
}
