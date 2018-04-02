using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class AnimationEditorPlugIn : PlugInStandard
	{
		private FocusLabel label3;

		private FocusLabel label4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DirectionComboBox;

		private EditBox IntervalTextBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox OnCheckBox;

		private Container components;

		public AnimationEditorPlugIn()
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
			IntervalTextBox = new EditBox();
			label4 = new FocusLabel();
			DirectionComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			OnCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			label3.LoadingBegin();
			label3.FocusControl = IntervalTextBox;
			label3.Location = new Point(52, 74);
			label3.Name = "label3";
			label3.Size = new Size(44, 15);
			label3.Text = "Interval";
			label3.LoadingEnd();
			IntervalTextBox.LoadingBegin();
			IntervalTextBox.Location = new Point(96, 72);
			IntervalTextBox.Name = "IntervalTextBox";
			IntervalTextBox.PropertyName = "Interval";
			IntervalTextBox.Size = new Size(48, 20);
			IntervalTextBox.TabIndex = 2;
			IntervalTextBox.LoadingEnd();
			label4.LoadingBegin();
			label4.FocusControl = DirectionComboBox;
			label4.Location = new Point(45, 42);
			label4.Name = "label4";
			label4.Size = new Size(51, 15);
			label4.Text = "Direction";
			label4.LoadingEnd();
			DirectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			DirectionComboBox.Location = new Point(96, 40);
			DirectionComboBox.Name = "DirectionComboBox";
			DirectionComboBox.PropertyName = "Direction";
			DirectionComboBox.Size = new Size(120, 21);
			DirectionComboBox.TabIndex = 1;
			OnCheckBox.Location = new Point(96, 8);
			OnCheckBox.Name = "OnCheckBox";
			OnCheckBox.PropertyName = "On";
			OnCheckBox.Size = new Size(40, 24);
			OnCheckBox.TabIndex = 0;
			OnCheckBox.Text = "On";
			base.Controls.Add(OnCheckBox);
			base.Controls.Add(IntervalTextBox);
			base.Controls.Add(DirectionComboBox);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Location = new Point(10, 20);
			base.Name = "AnimationEditorPlugIn";
			base.Size = new Size(464, 200);
			base.Title = "Animation Editor";
			base.ResumeLayout(false);
		}
	}
}
