using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class SlidingScaleBackgroundEditorPlugIn : PlugInStandard
	{
		private FocusLabel label4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private ColorPicker ColorPicker;

		private Container components;

		public SlidingScaleBackgroundEditorPlugIn()
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
			label4 = new FocusLabel();
			ColorPicker = new ColorPicker();
			StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label2 = new FocusLabel();
			base.SuspendLayout();
			label4.LoadingBegin();
			label4.FocusControl = ColorPicker;
			label4.Location = new Point(14, 19);
			label4.Name = "label4";
			label4.Size = new Size(34, 15);
			label4.Text = "Color";
			label4.LoadingEnd();
			ColorPicker.Location = new Point(48, 16);
			ColorPicker.Name = "ColorPicker";
			ColorPicker.PropertyName = "Color";
			ColorPicker.Size = new Size(144, 21);
			ColorPicker.TabIndex = 0;
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(248, 16);
			StyleComboBox.MaxDropDownItems = 20;
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(144, 21);
			StyleComboBox.TabIndex = 1;
			label2.LoadingBegin();
			label2.FocusControl = StyleComboBox;
			label2.Location = new Point(216, 18);
			label2.Name = "label2";
			label2.Size = new Size(32, 15);
			label2.Text = "Style";
			label2.LoadingEnd();
			base.Controls.Add(label2);
			base.Controls.Add(StyleComboBox);
			base.Controls.Add(ColorPicker);
			base.Controls.Add(label4);
			base.Name = "SlidingScaleBackgroundEditorPlugIn";
			base.Size = new Size(456, 80);
			base.Title = "Scale Background Editor";
			base.ResumeLayout(false);
		}
	}
}
