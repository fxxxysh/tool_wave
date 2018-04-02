using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class TextLayoutFullEditorPlugin : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox TrimmingComboBox;

		private FocusLabel label5;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LineLimitCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox NoClipCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox MeasureTrailingSpacesCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox NoWrapCheckBox;

		private Container components;

		public TextLayoutFullEditorPlugin()
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
			LineLimitCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			NoClipCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			MeasureTrailingSpacesCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			NoWrapCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			TrimmingComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			TrimmingComboBox.Location = new Point(216, 24);
			TrimmingComboBox.Name = "TrimmingComboBox";
			TrimmingComboBox.PropertyName = "Trimming";
			TrimmingComboBox.Size = new Size(120, 21);
			TrimmingComboBox.TabIndex = 4;
			label5.LoadingBegin();
			label5.FocusControl = TrimmingComboBox;
			label5.Location = new Point(163, 26);
			label5.Name = "label5";
			label5.Size = new Size(53, 15);
			label5.Text = "Trimming";
			label5.LoadingEnd();
			LineLimitCheckBox.Location = new Point(16, 24);
			LineLimitCheckBox.Name = "LineLimitCheckBox";
			LineLimitCheckBox.PropertyName = "LineLimit";
			LineLimitCheckBox.Size = new Size(80, 24);
			LineLimitCheckBox.TabIndex = 0;
			LineLimitCheckBox.Text = "Line Limit";
			NoClipCheckBox.Location = new Point(16, 48);
			NoClipCheckBox.Name = "NoClipCheckBox";
			NoClipCheckBox.PropertyName = "NoClip";
			NoClipCheckBox.Size = new Size(80, 24);
			NoClipCheckBox.TabIndex = 1;
			NoClipCheckBox.Text = "No Clip";
			MeasureTrailingSpacesCheckBox.Location = new Point(16, 96);
			MeasureTrailingSpacesCheckBox.Name = "MeasureTrailingSpacesCheckBox";
			MeasureTrailingSpacesCheckBox.PropertyName = "MeasureTrailingSpaces";
			MeasureTrailingSpacesCheckBox.Size = new Size(152, 24);
			MeasureTrailingSpacesCheckBox.TabIndex = 3;
			MeasureTrailingSpacesCheckBox.Text = "Measure Trailing Spaces";
			NoWrapCheckBox.Location = new Point(16, 72);
			NoWrapCheckBox.Name = "NoWrapCheckBox";
			NoWrapCheckBox.PropertyName = "NoWrap";
			NoWrapCheckBox.Size = new Size(80, 24);
			NoWrapCheckBox.TabIndex = 2;
			NoWrapCheckBox.Text = "No Wrap";
			base.Controls.Add(LineLimitCheckBox);
			base.Controls.Add(NoClipCheckBox);
			base.Controls.Add(MeasureTrailingSpacesCheckBox);
			base.Controls.Add(NoWrapCheckBox);
			base.Controls.Add(TrimmingComboBox);
			base.Controls.Add(label5);
			base.Name = "TextLayoutFullEditorPlugin";
			base.Size = new Size(392, 160);
			base.Title = "Text Layout Editor";
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new AlignmentTextEditorPlugIn(), "Alignment Horizontal", false);
			base.AddSubPlugIn(new AlignmentTextEditorPlugIn(), "Alignment Vertical", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as TextLayoutFull).AlignmentHorizontal;
			base.SubPlugIns[1].Value = (base.Value as TextLayoutFull).AlignmentVertical;
		}
	}
}
