using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ScaleRangeAngularEditorPlugIn : PlugInStandard
	{
		private FocusLabel label1;

		private FocusLabel label3;

		private EditBox MinTextBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ReverseCheckBox;

		private FocusLabel label2;

		private EditBox SpanTextBox;

		private EditBox MaxTextBox;

		private GroupBox groupBox1;

		private EditBox AngleMaxTextBox;

		private FocusLabel label6;

		private FocusLabel label5;

		private EditBox AngleSpanTextBox;

		private EditBox AngleMinTextBox;

		private FocusLabel label4;

		private GroupBox LimitGroupBox;

		private FocusLabel focusLabel7;

		private FocusLabel focusLabel6;

		private FocusLabel focusLabel5;

		private FocusLabel focusLabel4;

		private FocusLabel focusLabel3;

		private FocusLabel focusLabel2;

		private FocusLabel focusLabel1;

		private EditBox LimitMinLowerActualEditBox;

		private EditBox LimitMaxUpperActualEditBox;

		private EditBox LimitSpanLowerActualEditBox;

		private EditBox LimitSpanUpperActualEditBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox checkBox1;

		private EditBox LimitSpanUpperValueEditBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LimitSpanUpperEnabledCheckBox;

		private EditBox LimitMaxUpperValueEditBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LimitMaxUpperEnabledCheckBox;

		private EditBox LimitMinLowerValueEditBox;

		private EditBox LimitSpanLowerValueEditBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LimitSpanLowerEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LimitMinLowerEnabledCheckBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ScaleTypeComboBox;

		private GroupBox groupBox2;

		private EditBox SplitPercentEditBox;

		private FocusLabel focusLabel9;

		private EditBox SplitStartTextBox;

		private FocusLabel label8;

		private Container components;

		public ScaleRangeAngularEditorPlugIn()
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
			label1 = new FocusLabel();
			MinTextBox = new EditBox();
			label3 = new FocusLabel();
			MaxTextBox = new EditBox();
			SpanTextBox = new EditBox();
			ReverseCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			label2 = new FocusLabel();
			groupBox1 = new GroupBox();
			AngleMaxTextBox = new EditBox();
			AngleSpanTextBox = new EditBox();
			AngleMinTextBox = new EditBox();
			label4 = new FocusLabel();
			label6 = new FocusLabel();
			label5 = new FocusLabel();
			LimitGroupBox = new GroupBox();
			focusLabel7 = new FocusLabel();
			focusLabel6 = new FocusLabel();
			focusLabel5 = new FocusLabel();
			focusLabel4 = new FocusLabel();
			focusLabel3 = new FocusLabel();
			focusLabel2 = new FocusLabel();
			focusLabel1 = new FocusLabel();
			LimitMinLowerActualEditBox = new EditBox();
			LimitMaxUpperActualEditBox = new EditBox();
			LimitSpanLowerActualEditBox = new EditBox();
			LimitSpanUpperActualEditBox = new EditBox();
			checkBox1 = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LimitSpanUpperValueEditBox = new EditBox();
			LimitSpanUpperEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LimitMaxUpperValueEditBox = new EditBox();
			LimitMaxUpperEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LimitMinLowerValueEditBox = new EditBox();
			LimitSpanLowerValueEditBox = new EditBox();
			LimitSpanLowerEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LimitMinLowerEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			focusLabel8 = new FocusLabel();
			ScaleTypeComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			groupBox2 = new GroupBox();
			SplitPercentEditBox = new EditBox();
			focusLabel9 = new FocusLabel();
			SplitStartTextBox = new EditBox();
			label8 = new FocusLabel();
			groupBox1.SuspendLayout();
			LimitGroupBox.SuspendLayout();
			groupBox2.SuspendLayout();
			base.SuspendLayout();
			label1.LoadingBegin();
			label1.FocusControl = MinTextBox;
			label1.Location = new Point(39, 50);
			label1.Name = "label1";
			label1.Size = new Size(25, 15);
			label1.Text = "Min";
			label1.LoadingEnd();
			MinTextBox.LoadingBegin();
			MinTextBox.Location = new Point(64, 48);
			MinTextBox.Name = "MinTextBox";
			MinTextBox.PropertyName = "Min";
			MinTextBox.Size = new Size(144, 20);
			MinTextBox.TabIndex = 0;
			MinTextBox.TextAlign = HorizontalAlignment.Center;
			MinTextBox.LoadingEnd();
			label3.LoadingBegin();
			label3.FocusControl = MaxTextBox;
			label3.Location = new Point(36, 74);
			label3.Name = "label3";
			label3.Size = new Size(28, 15);
			label3.Text = "Max";
			label3.LoadingEnd();
			MaxTextBox.LoadingBegin();
			MaxTextBox.Location = new Point(64, 72);
			MaxTextBox.Name = "MaxTextBox";
			MaxTextBox.PropertyName = "Max";
			MaxTextBox.ReadOnly = true;
			MaxTextBox.Size = new Size(144, 20);
			MaxTextBox.TabIndex = 1;
			MaxTextBox.TextAlign = HorizontalAlignment.Center;
			MaxTextBox.LoadingEnd();
			SpanTextBox.LoadingBegin();
			SpanTextBox.Location = new Point(64, 96);
			SpanTextBox.Name = "SpanTextBox";
			SpanTextBox.PropertyName = "Span";
			SpanTextBox.Size = new Size(144, 20);
			SpanTextBox.TabIndex = 2;
			SpanTextBox.TextAlign = HorizontalAlignment.Center;
			SpanTextBox.LoadingEnd();
			ReverseCheckBox.Location = new Point(64, 120);
			ReverseCheckBox.Name = "ReverseCheckBox";
			ReverseCheckBox.PropertyName = "Reverse";
			ReverseCheckBox.Size = new Size(72, 24);
			ReverseCheckBox.TabIndex = 3;
			ReverseCheckBox.Text = "Reverse";
			label2.LoadingBegin();
			label2.FocusControl = SpanTextBox;
			label2.Location = new Point(31, 98);
			label2.Name = "label2";
			label2.Size = new Size(33, 15);
			label2.Text = "Span";
			label2.LoadingEnd();
			groupBox1.Controls.Add(AngleMaxTextBox);
			groupBox1.Controls.Add(AngleSpanTextBox);
			groupBox1.Controls.Add(AngleMinTextBox);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(label5);
			groupBox1.Location = new Point(220, 23);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(120, 104);
			groupBox1.TabIndex = 6;
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
			LimitGroupBox.Controls.Add(focusLabel7);
			LimitGroupBox.Controls.Add(focusLabel6);
			LimitGroupBox.Controls.Add(focusLabel5);
			LimitGroupBox.Controls.Add(focusLabel4);
			LimitGroupBox.Controls.Add(focusLabel3);
			LimitGroupBox.Controls.Add(focusLabel2);
			LimitGroupBox.Controls.Add(focusLabel1);
			LimitGroupBox.Controls.Add(LimitMinLowerActualEditBox);
			LimitGroupBox.Controls.Add(LimitMaxUpperActualEditBox);
			LimitGroupBox.Controls.Add(LimitSpanLowerActualEditBox);
			LimitGroupBox.Controls.Add(LimitSpanUpperActualEditBox);
			LimitGroupBox.Controls.Add(checkBox1);
			LimitGroupBox.Controls.Add(LimitSpanUpperValueEditBox);
			LimitGroupBox.Controls.Add(LimitSpanUpperEnabledCheckBox);
			LimitGroupBox.Controls.Add(LimitMaxUpperValueEditBox);
			LimitGroupBox.Controls.Add(LimitMaxUpperEnabledCheckBox);
			LimitGroupBox.Controls.Add(LimitMinLowerValueEditBox);
			LimitGroupBox.Controls.Add(LimitSpanLowerValueEditBox);
			LimitGroupBox.Controls.Add(LimitSpanLowerEnabledCheckBox);
			LimitGroupBox.Controls.Add(LimitMinLowerEnabledCheckBox);
			LimitGroupBox.Location = new Point(352, 23);
			LimitGroupBox.Name = "LimitGroupBox";
			LimitGroupBox.Size = new Size(328, 248);
			LimitGroupBox.TabIndex = 7;
			LimitGroupBox.TabStop = false;
			LimitGroupBox.Text = "Limit";
			focusLabel7.LoadingBegin();
			focusLabel7.Location = new Point(14, 123);
			focusLabel7.Name = "focusLabel7";
			focusLabel7.Size = new Size(66, 15);
			focusLabel7.Text = "Span Upper";
			focusLabel7.LoadingEnd();
			focusLabel6.LoadingBegin();
			focusLabel6.Location = new Point(14, 99);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(66, 15);
			focusLabel6.Text = "Span Lower";
			focusLabel6.LoadingEnd();
			focusLabel5.LoadingBegin();
			focusLabel5.Location = new Point(22, 75);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(61, 15);
			focusLabel5.Text = "Max Upper";
			focusLabel5.LoadingEnd();
			focusLabel4.LoadingBegin();
			focusLabel4.Location = new Point(22, 51);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(58, 15);
			focusLabel4.Text = "Min Lower";
			focusLabel4.LoadingEnd();
			focusLabel3.LoadingBegin();
			focusLabel3.Location = new Point(70, 24);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(48, 15);
			focusLabel3.Text = "Enabled";
			focusLabel3.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.Location = new Point(158, 24);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(36, 15);
			focusLabel2.Text = "Value";
			focusLabel2.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.Location = new Point(254, 26);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(38, 15);
			focusLabel1.Text = "Actual";
			focusLabel1.LoadingEnd();
			LimitMinLowerActualEditBox.LoadingBegin();
			LimitMinLowerActualEditBox.Location = new Point(224, 48);
			LimitMinLowerActualEditBox.Name = "LimitMinLowerActualEditBox";
			LimitMinLowerActualEditBox.PropertyName = "LimitMinLowerActual";
			LimitMinLowerActualEditBox.ReadOnly = true;
			LimitMinLowerActualEditBox.Size = new Size(88, 20);
			LimitMinLowerActualEditBox.TabIndex = 2;
			LimitMinLowerActualEditBox.TextAlign = HorizontalAlignment.Center;
			LimitMinLowerActualEditBox.LoadingEnd();
			LimitMaxUpperActualEditBox.LoadingBegin();
			LimitMaxUpperActualEditBox.Location = new Point(224, 72);
			LimitMaxUpperActualEditBox.Name = "LimitMaxUpperActualEditBox";
			LimitMaxUpperActualEditBox.PropertyName = "LimitMaxUpperActual";
			LimitMaxUpperActualEditBox.ReadOnly = true;
			LimitMaxUpperActualEditBox.Size = new Size(88, 20);
			LimitMaxUpperActualEditBox.TabIndex = 5;
			LimitMaxUpperActualEditBox.TextAlign = HorizontalAlignment.Center;
			LimitMaxUpperActualEditBox.LoadingEnd();
			LimitSpanLowerActualEditBox.LoadingBegin();
			LimitSpanLowerActualEditBox.Location = new Point(224, 96);
			LimitSpanLowerActualEditBox.Name = "LimitSpanLowerActualEditBox";
			LimitSpanLowerActualEditBox.PropertyName = "LimitSpanLowerActual";
			LimitSpanLowerActualEditBox.ReadOnly = true;
			LimitSpanLowerActualEditBox.Size = new Size(88, 20);
			LimitSpanLowerActualEditBox.TabIndex = 8;
			LimitSpanLowerActualEditBox.TextAlign = HorizontalAlignment.Center;
			LimitSpanLowerActualEditBox.LoadingEnd();
			LimitSpanUpperActualEditBox.LoadingBegin();
			LimitSpanUpperActualEditBox.Location = new Point(224, 120);
			LimitSpanUpperActualEditBox.Name = "LimitSpanUpperActualEditBox";
			LimitSpanUpperActualEditBox.PropertyName = "LimitSpanUpperActual";
			LimitSpanUpperActualEditBox.ReadOnly = true;
			LimitSpanUpperActualEditBox.Size = new Size(88, 20);
			LimitSpanUpperActualEditBox.TabIndex = 11;
			LimitSpanUpperActualEditBox.TextAlign = HorizontalAlignment.Center;
			LimitSpanUpperActualEditBox.LoadingEnd();
			checkBox1.Location = new Point(88, 152);
			checkBox1.Name = "checkBox1";
			checkBox1.PropertyName = "LimitsEnforced";
			checkBox1.ReadOnly = true;
			checkBox1.TabIndex = 12;
			checkBox1.Text = "Limits Enforced";
			LimitSpanUpperValueEditBox.LoadingBegin();
			LimitSpanUpperValueEditBox.Location = new Point(128, 120);
			LimitSpanUpperValueEditBox.Name = "LimitSpanUpperValueEditBox";
			LimitSpanUpperValueEditBox.PropertyName = "LimitSpanUpperValue";
			LimitSpanUpperValueEditBox.Size = new Size(88, 20);
			LimitSpanUpperValueEditBox.TabIndex = 10;
			LimitSpanUpperValueEditBox.TextAlign = HorizontalAlignment.Center;
			LimitSpanUpperValueEditBox.LoadingEnd();
			LimitSpanUpperEnabledCheckBox.Location = new Point(88, 120);
			LimitSpanUpperEnabledCheckBox.Name = "LimitSpanUpperEnabledCheckBox";
			LimitSpanUpperEnabledCheckBox.PropertyName = "LimitSpanUpperEnabled";
			LimitSpanUpperEnabledCheckBox.Size = new Size(24, 24);
			LimitSpanUpperEnabledCheckBox.TabIndex = 9;
			LimitMaxUpperValueEditBox.LoadingBegin();
			LimitMaxUpperValueEditBox.Location = new Point(128, 72);
			LimitMaxUpperValueEditBox.Name = "LimitMaxUpperValueEditBox";
			LimitMaxUpperValueEditBox.PropertyName = "LimitMaxUpperValue";
			LimitMaxUpperValueEditBox.Size = new Size(88, 20);
			LimitMaxUpperValueEditBox.TabIndex = 4;
			LimitMaxUpperValueEditBox.TextAlign = HorizontalAlignment.Center;
			LimitMaxUpperValueEditBox.LoadingEnd();
			LimitMaxUpperEnabledCheckBox.Location = new Point(88, 72);
			LimitMaxUpperEnabledCheckBox.Name = "LimitMaxUpperEnabledCheckBox";
			LimitMaxUpperEnabledCheckBox.PropertyName = "LimitMaxUpperEnabled";
			LimitMaxUpperEnabledCheckBox.Size = new Size(24, 24);
			LimitMaxUpperEnabledCheckBox.TabIndex = 3;
			LimitMinLowerValueEditBox.LoadingBegin();
			LimitMinLowerValueEditBox.Location = new Point(128, 48);
			LimitMinLowerValueEditBox.Name = "LimitMinLowerValueEditBox";
			LimitMinLowerValueEditBox.PropertyName = "LimitMinLowerValue";
			LimitMinLowerValueEditBox.Size = new Size(88, 20);
			LimitMinLowerValueEditBox.TabIndex = 1;
			LimitMinLowerValueEditBox.TextAlign = HorizontalAlignment.Center;
			LimitMinLowerValueEditBox.LoadingEnd();
			LimitSpanLowerValueEditBox.LoadingBegin();
			LimitSpanLowerValueEditBox.Location = new Point(128, 96);
			LimitSpanLowerValueEditBox.Name = "LimitSpanLowerValueEditBox";
			LimitSpanLowerValueEditBox.PropertyName = "LimitSpanLowerValue";
			LimitSpanLowerValueEditBox.Size = new Size(88, 20);
			LimitSpanLowerValueEditBox.TabIndex = 7;
			LimitSpanLowerValueEditBox.TextAlign = HorizontalAlignment.Center;
			LimitSpanLowerValueEditBox.LoadingEnd();
			LimitSpanLowerEnabledCheckBox.Location = new Point(88, 96);
			LimitSpanLowerEnabledCheckBox.Name = "LimitSpanLowerEnabledCheckBox";
			LimitSpanLowerEnabledCheckBox.PropertyName = "LimitSpanLowerEnabled";
			LimitSpanLowerEnabledCheckBox.Size = new Size(24, 24);
			LimitSpanLowerEnabledCheckBox.TabIndex = 6;
			LimitMinLowerEnabledCheckBox.Location = new Point(88, 48);
			LimitMinLowerEnabledCheckBox.Name = "LimitMinLowerEnabledCheckBox";
			LimitMinLowerEnabledCheckBox.PropertyName = "LimitMinLowerEnabled";
			LimitMinLowerEnabledCheckBox.Size = new Size(24, 24);
			LimitMinLowerEnabledCheckBox.TabIndex = 0;
			focusLabel8.LoadingBegin();
			focusLabel8.FocusControl = ScaleTypeComboBox;
			focusLabel8.Location = new Point(2, 154);
			focusLabel8.Name = "focusLabel8";
			focusLabel8.Size = new Size(62, 15);
			focusLabel8.Text = "Scale Type";
			focusLabel8.LoadingEnd();
			ScaleTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ScaleTypeComboBox.Location = new Point(64, 152);
			ScaleTypeComboBox.Name = "ScaleTypeComboBox";
			ScaleTypeComboBox.PropertyName = "ScaleType";
			ScaleTypeComboBox.Size = new Size(112, 21);
			ScaleTypeComboBox.TabIndex = 4;
			groupBox2.Controls.Add(SplitPercentEditBox);
			groupBox2.Controls.Add(focusLabel9);
			groupBox2.Controls.Add(SplitStartTextBox);
			groupBox2.Controls.Add(label8);
			groupBox2.Location = new Point(64, 184);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(152, 72);
			groupBox2.TabIndex = 5;
			groupBox2.TabStop = false;
			groupBox2.Text = "Split";
			SplitPercentEditBox.LoadingBegin();
			SplitPercentEditBox.Location = new Point(56, 40);
			SplitPercentEditBox.Name = "SplitPercentEditBox";
			SplitPercentEditBox.PropertyName = "SplitPercent";
			SplitPercentEditBox.Size = new Size(80, 20);
			SplitPercentEditBox.TabIndex = 1;
			SplitPercentEditBox.LoadingEnd();
			focusLabel9.LoadingBegin();
			focusLabel9.FocusControl = SplitPercentEditBox;
			focusLabel9.Location = new Point(11, 42);
			focusLabel9.Name = "focusLabel9";
			focusLabel9.Size = new Size(45, 15);
			focusLabel9.Text = "Percent";
			focusLabel9.LoadingEnd();
			SplitStartTextBox.LoadingBegin();
			SplitStartTextBox.Location = new Point(56, 16);
			SplitStartTextBox.Name = "SplitStartTextBox";
			SplitStartTextBox.PropertyName = "SplitStart";
			SplitStartTextBox.Size = new Size(80, 20);
			SplitStartTextBox.TabIndex = 0;
			SplitStartTextBox.LoadingEnd();
			label8.LoadingBegin();
			label8.FocusControl = SplitStartTextBox;
			label8.Location = new Point(25, 18);
			label8.Name = "label8";
			label8.Size = new Size(31, 15);
			label8.Text = "Start";
			label8.LoadingEnd();
			base.Controls.Add(groupBox1);
			base.Controls.Add(groupBox2);
			base.Controls.Add(focusLabel8);
			base.Controls.Add(ScaleTypeComboBox);
			base.Controls.Add(LimitGroupBox);
			base.Controls.Add(MaxTextBox);
			base.Controls.Add(label2);
			base.Controls.Add(ReverseCheckBox);
			base.Controls.Add(SpanTextBox);
			base.Controls.Add(MinTextBox);
			base.Controls.Add(label3);
			base.Controls.Add(label1);
			base.Name = "ScaleRangeAngularEditorPlugIn";
			base.Size = new Size(704, 320);
			base.Title = "Scale Range Editor";
			groupBox1.ResumeLayout(false);
			LimitGroupBox.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
