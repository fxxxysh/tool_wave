using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class TextLayoutHorizontalEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox TrimmingComboBox;

		private FocusLabel label5;

		private Iocomp.Design.Plugin.EditorControls.CheckBox FlippedCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LineLimitCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox NoClipCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox MeasureTrailingSpacesCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox NoWrapCheckBox;

		private Container components;

		public TextLayoutHorizontalEditorPlugIn()
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
			TrimmingComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			label5 = new FocusLabel();
			FlippedCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LineLimitCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			NoClipCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			MeasureTrailingSpacesCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			NoWrapCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			TrimmingComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			TrimmingComboBox.Location = new Point(224, 16);
			TrimmingComboBox.Name = "TrimmingComboBox";
			TrimmingComboBox.PropertyName = "Trimming";
			TrimmingComboBox.Size = new Size(120, 21);
			TrimmingComboBox.TabIndex = 5;
			label5.LoadingBegin();
			label5.FocusControl = TrimmingComboBox;
			label5.Location = new Point(171, 18);
			label5.Name = "label5";
			label5.Size = new Size(53, 15);
			label5.Text = "Trimming";
			label5.LoadingEnd();
			FlippedCheckBox.Location = new Point(16, 88);
			FlippedCheckBox.Name = "FlippedCheckBox";
			FlippedCheckBox.PropertyName = "Flipped";
			FlippedCheckBox.Size = new Size(80, 24);
			FlippedCheckBox.TabIndex = 3;
			FlippedCheckBox.Text = "Flipped";
			LineLimitCheckBox.Location = new Point(16, 16);
			LineLimitCheckBox.Name = "LineLimitCheckBox";
			LineLimitCheckBox.PropertyName = "LineLimit";
			LineLimitCheckBox.Size = new Size(80, 24);
			LineLimitCheckBox.TabIndex = 0;
			LineLimitCheckBox.Text = "Line Limit";
			NoClipCheckBox.Location = new Point(16, 40);
			NoClipCheckBox.Name = "NoClipCheckBox";
			NoClipCheckBox.PropertyName = "NoClip";
			NoClipCheckBox.Size = new Size(80, 24);
			NoClipCheckBox.TabIndex = 1;
			NoClipCheckBox.Text = "No Clip";
			MeasureTrailingSpacesCheckBox.Location = new Point(16, 112);
			MeasureTrailingSpacesCheckBox.Name = "MeasureTrailingSpacesCheckBox";
			MeasureTrailingSpacesCheckBox.PropertyName = "MeasureTrailingSpaces";
			MeasureTrailingSpacesCheckBox.Size = new Size(152, 24);
			MeasureTrailingSpacesCheckBox.TabIndex = 4;
			MeasureTrailingSpacesCheckBox.Text = "Measure Trailing Spaces";
			NoWrapCheckBox.Location = new Point(16, 64);
			NoWrapCheckBox.Name = "NoWrapCheckBox";
			NoWrapCheckBox.PropertyName = "NoWrap";
			NoWrapCheckBox.Size = new Size(80, 24);
			NoWrapCheckBox.TabIndex = 2;
			NoWrapCheckBox.Text = "No Wrap";
			base.Controls.Add(FlippedCheckBox);
			base.Controls.Add(LineLimitCheckBox);
			base.Controls.Add(NoClipCheckBox);
			base.Controls.Add(MeasureTrailingSpacesCheckBox);
			base.Controls.Add(NoWrapCheckBox);
			base.Controls.Add(label5);
			base.Controls.Add(TrimmingComboBox);
			base.Name = "TextLayoutHorizontalEditorPlugIn";
			base.Size = new Size(416, 176);
			base.Title = "Text Layout Editor";
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new AlignmentTextEditorPlugIn(), "Alignment", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as TextLayoutHorizontal).Alignment;
		}
	}
}
