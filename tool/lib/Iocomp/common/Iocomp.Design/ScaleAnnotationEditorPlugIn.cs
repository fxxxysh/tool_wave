using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ScaleAnnotationEditorPlugIn : PlugInStandard
	{
		private EditBox SpanYTextBox;

		private EditBox SpanXTextBox;

		private GroupBox groupBox1;

		private GroupBox groupBox2;

		private FocusLabel label1;

		private FocusLabel label2;

		private FocusLabel label3;

		private FocusLabel label4;

		private EditBox OriginXTextBox;

		private EditBox OriginYTextBox;

		private Container components;

		public ScaleAnnotationEditorPlugIn()
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
			OriginXTextBox = new EditBox();
			OriginYTextBox = new EditBox();
			SpanYTextBox = new EditBox();
			SpanXTextBox = new EditBox();
			groupBox1 = new GroupBox();
			label2 = new FocusLabel();
			label1 = new FocusLabel();
			groupBox2 = new GroupBox();
			label3 = new FocusLabel();
			label4 = new FocusLabel();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			base.SuspendLayout();
			OriginXTextBox.LoadingBegin();
			OriginXTextBox.Location = new Point(24, 24);
			OriginXTextBox.Name = "OriginXTextBox";
			OriginXTextBox.PropertyName = "OriginX";
			OriginXTextBox.Size = new Size(48, 20);
			OriginXTextBox.TabIndex = 0;
			OriginXTextBox.TextAlign = HorizontalAlignment.Center;
			OriginXTextBox.LoadingEnd();
			OriginYTextBox.LoadingBegin();
			OriginYTextBox.Location = new Point(104, 24);
			OriginYTextBox.Name = "OriginYTextBox";
			OriginYTextBox.PropertyName = "OriginY";
			OriginYTextBox.Size = new Size(48, 20);
			OriginYTextBox.TabIndex = 1;
			OriginYTextBox.TextAlign = HorizontalAlignment.Center;
			OriginYTextBox.LoadingEnd();
			SpanYTextBox.LoadingBegin();
			SpanYTextBox.Location = new Point(104, 24);
			SpanYTextBox.Name = "SpanYTextBox";
			SpanYTextBox.PropertyName = "SpanY";
			SpanYTextBox.Size = new Size(48, 20);
			SpanYTextBox.TabIndex = 1;
			SpanYTextBox.TextAlign = HorizontalAlignment.Center;
			SpanYTextBox.LoadingEnd();
			SpanXTextBox.LoadingBegin();
			SpanXTextBox.Location = new Point(24, 24);
			SpanXTextBox.Name = "SpanXTextBox";
			SpanXTextBox.PropertyName = "SpanX";
			SpanXTextBox.Size = new Size(48, 20);
			SpanXTextBox.TabIndex = 0;
			SpanXTextBox.TextAlign = HorizontalAlignment.Center;
			SpanXTextBox.LoadingEnd();
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(OriginYTextBox);
			groupBox1.Controls.Add(OriginXTextBox);
			groupBox1.Location = new Point(104, 32);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(168, 56);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Origin";
			label2.LoadingBegin();
			label2.FocusControl = OriginYTextBox;
			label2.Location = new Point(89, 26);
			label2.Name = "label2";
			label2.Size = new Size(15, 15);
			label2.Text = "Y";
			label2.LoadingEnd();
			label1.LoadingBegin();
			label1.FocusControl = OriginXTextBox;
			label1.Location = new Point(9, 26);
			label1.Name = "label1";
			label1.Size = new Size(15, 15);
			label1.Text = "X";
			label1.LoadingEnd();
			groupBox2.Controls.Add(label3);
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(SpanXTextBox);
			groupBox2.Controls.Add(SpanYTextBox);
			groupBox2.Location = new Point(104, 96);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(168, 56);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Span";
			label3.LoadingBegin();
			label3.FocusControl = SpanYTextBox;
			label3.Location = new Point(89, 26);
			label3.Name = "label3";
			label3.Size = new Size(15, 15);
			label3.Text = "Y";
			label3.LoadingEnd();
			label4.LoadingBegin();
			label4.FocusControl = SpanXTextBox;
			label4.Location = new Point(9, 26);
			label4.Name = "label4";
			label4.Size = new Size(15, 15);
			label4.Text = "X";
			label4.LoadingEnd();
			base.Controls.Add(groupBox2);
			base.Controls.Add(groupBox1);
			base.Name = "ScaleAnnotationEditorPlugIn";
			base.Size = new Size(512, 328);
			base.Title = "Display Editor";
			groupBox1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
