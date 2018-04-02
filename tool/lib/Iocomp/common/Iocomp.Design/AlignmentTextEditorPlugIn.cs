using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class AlignmentTextEditorPlugIn : PlugInStandard
	{
		private FocusLabel label3;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private EditBox MarginTextBox;

		private Container components;

		public AlignmentTextEditorPlugIn()
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
			label3 = new FocusLabel();
			MarginTextBox = new EditBox();
			StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label2 = new FocusLabel();
			base.SuspendLayout();
			label3.LoadingBegin();
			label3.FocusControl = MarginTextBox;
			label3.Location = new Point(31, 50);
			label3.Name = "label3";
			label3.Size = new Size(41, 15);
			label3.Text = "Margin";
			label3.LoadingEnd();
			MarginTextBox.LoadingBegin();
			MarginTextBox.Location = new Point(72, 48);
			MarginTextBox.Name = "MarginTextBox";
			MarginTextBox.PropertyName = "Margin";
			MarginTextBox.Size = new Size(40, 20);
			MarginTextBox.TabIndex = 1;
			MarginTextBox.LoadingEnd();
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(72, 16);
			StyleComboBox.MaxDropDownItems = 20;
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(144, 21);
			StyleComboBox.TabIndex = 0;
			label2.LoadingBegin();
			label2.FocusControl = StyleComboBox;
			label2.Location = new Point(40, 18);
			label2.Name = "label2";
			label2.Size = new Size(32, 15);
			label2.Text = "Style";
			label2.LoadingEnd();
			base.Controls.Add(MarginTextBox);
			base.Controls.Add(label2);
			base.Controls.Add(StyleComboBox);
			base.Controls.Add(label3);
			base.Name = "AlignmentTextEditorPlugIn";
			base.Size = new Size(328, 88);
			base.Title = "Alignment Editor";
			base.ResumeLayout(false);
		}
	}
}
