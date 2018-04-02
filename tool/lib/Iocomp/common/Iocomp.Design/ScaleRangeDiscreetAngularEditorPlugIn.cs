using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ScaleRangeDiscreetAngularEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox ReverseCheckBox;

		private GroupBox groupBox1;

		private EditBox AngleMaxTextBox;

		private FocusLabel label6;

		private FocusLabel label5;

		private EditBox AngleSpanTextBox;

		private EditBox AngleMinTextBox;

		private FocusLabel label4;

		private Container components;

		public ScaleRangeDiscreetAngularEditorPlugIn()
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
			ReverseCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			groupBox1 = new GroupBox();
			AngleMaxTextBox = new EditBox();
			AngleSpanTextBox = new EditBox();
			AngleMinTextBox = new EditBox();
			label4 = new FocusLabel();
			label6 = new FocusLabel();
			label5 = new FocusLabel();
			groupBox1.SuspendLayout();
			base.SuspendLayout();
			ReverseCheckBox.Location = new Point(80, 120);
			ReverseCheckBox.Name = "ReverseCheckBox";
			ReverseCheckBox.PropertyName = "Reverse";
			ReverseCheckBox.Size = new Size(72, 24);
			ReverseCheckBox.TabIndex = 1;
			ReverseCheckBox.Text = "Reverse";
			groupBox1.Controls.Add(AngleMaxTextBox);
			groupBox1.Controls.Add(AngleSpanTextBox);
			groupBox1.Controls.Add(AngleMinTextBox);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(label5);
			groupBox1.Location = new Point(32, 8);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(120, 104);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Angle";
			AngleMaxTextBox.LoadingBegin();
			AngleMaxTextBox.Location = new Point(48, 48);
			AngleMaxTextBox.Name = "AngleMaxTextBox";
			AngleMaxTextBox.PropertyName = "AngleMax";
			AngleMaxTextBox.ReadOnly = true;
			AngleMaxTextBox.Size = new Size(56, 20);
			AngleMaxTextBox.TabIndex = 1;
			AngleMaxTextBox.TextAlign = HorizontalAlignment.Center;
			AngleMaxTextBox.LoadingEnd();
			AngleSpanTextBox.LoadingBegin();
			AngleSpanTextBox.Location = new Point(48, 72);
			AngleSpanTextBox.Name = "AngleSpanTextBox";
			AngleSpanTextBox.PropertyName = "AngleSpan";
			AngleSpanTextBox.Size = new Size(56, 20);
			AngleSpanTextBox.TabIndex = 2;
			AngleSpanTextBox.TextAlign = HorizontalAlignment.Center;
			AngleSpanTextBox.LoadingEnd();
			AngleMinTextBox.LoadingBegin();
			AngleMinTextBox.Location = new Point(48, 24);
			AngleMinTextBox.Name = "AngleMinTextBox";
			AngleMinTextBox.PropertyName = "AngleMin";
			AngleMinTextBox.Size = new Size(56, 20);
			AngleMinTextBox.TabIndex = 0;
			AngleMinTextBox.TextAlign = HorizontalAlignment.Center;
			AngleMinTextBox.LoadingEnd();
			label4.LoadingBegin();
			label4.FocusControl = AngleMinTextBox;
			label4.Location = new Point(23, 26);
			label4.Name = "label4";
			label4.Size = new Size(25, 15);
			label4.Text = "Min";
			label4.LoadingEnd();
			label6.LoadingBegin();
			label6.FocusControl = AngleMaxTextBox;
			label6.Location = new Point(20, 50);
			label6.Name = "label6";
			label6.Size = new Size(28, 15);
			label6.Text = "Max";
			label6.LoadingEnd();
			label5.LoadingBegin();
			label5.FocusControl = AngleSpanTextBox;
			label5.Location = new Point(15, 74);
			label5.Name = "label5";
			label5.Size = new Size(33, 15);
			label5.Text = "Span";
			label5.LoadingEnd();
			base.Controls.Add(groupBox1);
			base.Controls.Add(ReverseCheckBox);
			base.Name = "ScaleRangeDiscreetAngularEditorPlugIn";
			base.Size = new Size(296, 152);
			base.Title = "Scale Range Editor";
			groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
