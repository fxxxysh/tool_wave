using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotLegendWrappingEditorPlugIn : PlugInStandard
	{
		private CheckBox EnabledCheckBox;

		private FocusLabel focusLabel4;

		private EditBox MarginEditBox;

		private Container components;

		public PlotLegendWrappingEditorPlugIn()
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
			EnabledCheckBox = new CheckBox();
			MarginEditBox = new EditBox();
			focusLabel4 = new FocusLabel();
			base.SuspendLayout();
			EnabledCheckBox.Location = new Point(96, 40);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(72, 24);
			EnabledCheckBox.TabIndex = 0;
			EnabledCheckBox.Text = "Enabled";
			MarginEditBox.LoadingBegin();
			MarginEditBox.Location = new Point(96, 80);
			MarginEditBox.Name = "MarginEditBox";
			MarginEditBox.PropertyName = "Margin";
			MarginEditBox.Size = new Size(136, 20);
			MarginEditBox.TabIndex = 3;
			MarginEditBox.LoadingEnd();
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = MarginEditBox;
			focusLabel4.Location = new Point(56, 82);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(40, 15);
			focusLabel4.Text = "Margin";
			focusLabel4.LoadingEnd();
			base.Controls.Add(MarginEditBox);
			base.Controls.Add(focusLabel4);
			base.Controls.Add(EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotLegendWrappingEditorPlugIn";
			base.Size = new Size(504, 336);
			base.ResumeLayout(false);
		}
	}
}
