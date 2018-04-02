using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ScaleRangeLinearEditorPlugIn : PlugInStandard
	{
		private FocusLabel label1;

		private FocusLabel label3;

		private EditBox MinTextBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ReverseCheckBox;

		private FocusLabel label2;

		private EditBox SpanTextBox;

		private EditBox MaxTextBox;

		private DoubleEditButton SpanDoubleEditButton;

		private DoubleEditButton MaxDoubleEditButton;

		private DoubleEditButton MinDoubleEditButton;

		private DoubleEditButton MinLowerLimitDoubleEditButton;

		private DoubleEditButton SpanLowerLimitDoubleEditButton;

		private GroupBox LimitGroupBox;

		private DoubleEditButton MaxUpperLimitDoubleEditButton;

		private DoubleEditButton SpanUpperLimitDoubleEditButton;

		private FocusLabel focusLabel1;

		private FocusLabel focusLabel2;

		private FocusLabel focusLabel3;

		private FocusLabel focusLabel4;

		private FocusLabel focusLabel5;

		private FocusLabel focusLabel6;

		private FocusLabel focusLabel7;

		private EditBox LimitMinLowerActualEditBox;

		private EditBox LimitMaxUpperActualEditBox;

		private EditBox LimitSpanLowerActualEditBox;

		private EditBox LimitSpanUpperActualEditBox;

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

		private Iocomp.Design.Plugin.EditorControls.CheckBox LimitsEnforcedCheckBox;

		private GroupBox groupBox1;

		private EditBox SplitStartTextBox;

		private FocusLabel label8;

		private EditBox SplitPercentEditBox;

		private FocusLabel focusLabel9;

		private Container components;

		public ScaleRangeLinearEditorPlugIn()
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
			SpanDoubleEditButton = new DoubleEditButton();
			MaxDoubleEditButton = new DoubleEditButton();
			MinDoubleEditButton = new DoubleEditButton();
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
			LimitsEnforcedCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			SpanUpperLimitDoubleEditButton = new DoubleEditButton();
			LimitSpanUpperValueEditBox = new EditBox();
			LimitSpanUpperEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			MaxUpperLimitDoubleEditButton = new DoubleEditButton();
			LimitMaxUpperValueEditBox = new EditBox();
			LimitMaxUpperEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			MinLowerLimitDoubleEditButton = new DoubleEditButton();
			LimitMinLowerValueEditBox = new EditBox();
			SpanLowerLimitDoubleEditButton = new DoubleEditButton();
			LimitSpanLowerValueEditBox = new EditBox();
			LimitSpanLowerEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			LimitMinLowerEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			focusLabel8 = new FocusLabel();
			ScaleTypeComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			groupBox1 = new GroupBox();
			SplitPercentEditBox = new EditBox();
			focusLabel9 = new FocusLabel();
			SplitStartTextBox = new EditBox();
			label8 = new FocusLabel();
			LimitGroupBox.SuspendLayout();
			groupBox1.SuspendLayout();
			base.SuspendLayout();
			label1.LoadingBegin();
			label1.FocusControl = MinTextBox;
			label1.Location = new Point(47, 42);
			label1.Name = "label1";
			label1.Size = new Size(25, 15);
			label1.Text = "Min";
			label1.LoadingEnd();
			MinTextBox.LoadingBegin();
			MinTextBox.Location = new Point(72, 40);
			MinTextBox.Name = "MinTextBox";
			MinTextBox.PropertyName = "Min";
			MinTextBox.Size = new Size(144, 20);
			MinTextBox.TabIndex = 0;
			MinTextBox.TextAlign = HorizontalAlignment.Center;
			MinTextBox.LoadingEnd();
			label3.LoadingBegin();
			label3.FocusControl = MaxTextBox;
			label3.Location = new Point(44, 66);
			label3.Name = "label3";
			label3.Size = new Size(28, 15);
			label3.Text = "Max";
			label3.LoadingEnd();
			MaxTextBox.LoadingBegin();
			MaxTextBox.Location = new Point(72, 64);
			MaxTextBox.Name = "MaxTextBox";
			MaxTextBox.PropertyName = "Max";
			MaxTextBox.ReadOnly = true;
			MaxTextBox.Size = new Size(144, 20);
			MaxTextBox.TabIndex = 2;
			MaxTextBox.TextAlign = HorizontalAlignment.Center;
			MaxTextBox.LoadingEnd();
			SpanTextBox.LoadingBegin();
			SpanTextBox.Location = new Point(72, 88);
			SpanTextBox.Name = "SpanTextBox";
			SpanTextBox.PropertyName = "Span";
			SpanTextBox.Size = new Size(144, 20);
			SpanTextBox.TabIndex = 4;
			SpanTextBox.TextAlign = HorizontalAlignment.Center;
			SpanTextBox.LoadingEnd();
			ReverseCheckBox.Location = new Point(72, 112);
			ReverseCheckBox.Name = "ReverseCheckBox";
			ReverseCheckBox.PropertyName = "Reverse";
			ReverseCheckBox.Size = new Size(72, 24);
			ReverseCheckBox.TabIndex = 6;
			ReverseCheckBox.Text = "Reverse";
			label2.LoadingBegin();
			label2.FocusControl = SpanTextBox;
			label2.Location = new Point(39, 90);
			label2.Name = "label2";
			label2.Size = new Size(33, 15);
			label2.Text = "Span";
			label2.LoadingEnd();
			SpanDoubleEditButton.EditBox = SpanTextBox;
			SpanDoubleEditButton.Location = new Point(216, 86);
			SpanDoubleEditButton.Name = "SpanDoubleEditButton";
			SpanDoubleEditButton.TabIndex = 5;
			MaxDoubleEditButton.EditBox = MaxTextBox;
			MaxDoubleEditButton.Location = new Point(216, 62);
			MaxDoubleEditButton.Name = "MaxDoubleEditButton";
			MaxDoubleEditButton.TabIndex = 3;
			MinDoubleEditButton.EditBox = MinTextBox;
			MinDoubleEditButton.Location = new Point(216, 38);
			MinDoubleEditButton.Name = "MinDoubleEditButton";
			MinDoubleEditButton.TabIndex = 1;
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
			LimitGroupBox.Controls.Add(LimitsEnforcedCheckBox);
			LimitGroupBox.Controls.Add(SpanUpperLimitDoubleEditButton);
			LimitGroupBox.Controls.Add(LimitSpanUpperValueEditBox);
			LimitGroupBox.Controls.Add(LimitSpanUpperEnabledCheckBox);
			LimitGroupBox.Controls.Add(MaxUpperLimitDoubleEditButton);
			LimitGroupBox.Controls.Add(LimitMaxUpperValueEditBox);
			LimitGroupBox.Controls.Add(LimitMaxUpperEnabledCheckBox);
			LimitGroupBox.Controls.Add(MinLowerLimitDoubleEditButton);
			LimitGroupBox.Controls.Add(LimitMinLowerValueEditBox);
			LimitGroupBox.Controls.Add(SpanLowerLimitDoubleEditButton);
			LimitGroupBox.Controls.Add(LimitSpanLowerValueEditBox);
			LimitGroupBox.Controls.Add(LimitSpanLowerEnabledCheckBox);
			LimitGroupBox.Controls.Add(LimitMinLowerEnabledCheckBox);
			LimitGroupBox.Location = new Point(248, 32);
			LimitGroupBox.Name = "LimitGroupBox";
			LimitGroupBox.Size = new Size(320, 224);
			LimitGroupBox.TabIndex = 9;
			LimitGroupBox.TabStop = false;
			LimitGroupBox.Text = "Limit";
			focusLabel7.LoadingBegin();
			focusLabel7.Location = new Point(6, 123);
			focusLabel7.Name = "focusLabel7";
			focusLabel7.Size = new Size(66, 15);
			focusLabel7.Text = "Span Upper";
			focusLabel7.LoadingEnd();
			focusLabel6.LoadingBegin();
			focusLabel6.Location = new Point(6, 99);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(66, 15);
			focusLabel6.Text = "Span Lower";
			focusLabel6.LoadingEnd();
			focusLabel5.LoadingBegin();
			focusLabel5.Location = new Point(14, 75);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(61, 15);
			focusLabel5.Text = "Max Upper";
			focusLabel5.LoadingEnd();
			focusLabel4.LoadingBegin();
			focusLabel4.Location = new Point(14, 51);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(58, 15);
			focusLabel4.Text = "Min Lower";
			focusLabel4.LoadingEnd();
			focusLabel3.LoadingBegin();
			focusLabel3.Location = new Point(62, 24);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(48, 15);
			focusLabel3.Text = "Enabled";
			focusLabel3.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.Location = new Point(130, 24);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(36, 15);
			focusLabel2.Text = "Value";
			focusLabel2.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.Location = new Point(246, 24);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(38, 15);
			focusLabel1.Text = "Actual";
			focusLabel1.LoadingEnd();
			LimitMinLowerActualEditBox.LoadingBegin();
			LimitMinLowerActualEditBox.Location = new Point(216, 48);
			LimitMinLowerActualEditBox.Name = "LimitMinLowerActualEditBox";
			LimitMinLowerActualEditBox.PropertyName = "LimitMinLowerActual";
			LimitMinLowerActualEditBox.ReadOnly = true;
			LimitMinLowerActualEditBox.Size = new Size(96, 20);
			LimitMinLowerActualEditBox.TabIndex = 3;
			LimitMinLowerActualEditBox.TextAlign = HorizontalAlignment.Center;
			LimitMinLowerActualEditBox.LoadingEnd();
			LimitMaxUpperActualEditBox.LoadingBegin();
			LimitMaxUpperActualEditBox.Location = new Point(216, 72);
			LimitMaxUpperActualEditBox.Name = "LimitMaxUpperActualEditBox";
			LimitMaxUpperActualEditBox.PropertyName = "LimitMaxUpperActual";
			LimitMaxUpperActualEditBox.ReadOnly = true;
			LimitMaxUpperActualEditBox.Size = new Size(96, 20);
			LimitMaxUpperActualEditBox.TabIndex = 7;
			LimitMaxUpperActualEditBox.TextAlign = HorizontalAlignment.Center;
			LimitMaxUpperActualEditBox.LoadingEnd();
			LimitSpanLowerActualEditBox.LoadingBegin();
			LimitSpanLowerActualEditBox.Location = new Point(216, 96);
			LimitSpanLowerActualEditBox.Name = "LimitSpanLowerActualEditBox";
			LimitSpanLowerActualEditBox.PropertyName = "LimitSpanLowerActual";
			LimitSpanLowerActualEditBox.ReadOnly = true;
			LimitSpanLowerActualEditBox.Size = new Size(96, 20);
			LimitSpanLowerActualEditBox.TabIndex = 11;
			LimitSpanLowerActualEditBox.TextAlign = HorizontalAlignment.Center;
			LimitSpanLowerActualEditBox.LoadingEnd();
			LimitSpanUpperActualEditBox.LoadingBegin();
			LimitSpanUpperActualEditBox.Location = new Point(216, 120);
			LimitSpanUpperActualEditBox.Name = "LimitSpanUpperActualEditBox";
			LimitSpanUpperActualEditBox.PropertyName = "LimitSpanUpperActual";
			LimitSpanUpperActualEditBox.ReadOnly = true;
			LimitSpanUpperActualEditBox.Size = new Size(96, 20);
			LimitSpanUpperActualEditBox.TabIndex = 15;
			LimitSpanUpperActualEditBox.TextAlign = HorizontalAlignment.Center;
			LimitSpanUpperActualEditBox.LoadingEnd();
			LimitsEnforcedCheckBox.Location = new Point(80, 168);
			LimitsEnforcedCheckBox.Name = "LimitsEnforcedCheckBox";
			LimitsEnforcedCheckBox.PropertyName = "LimitsEnforced";
			LimitsEnforcedCheckBox.ReadOnly = true;
			LimitsEnforcedCheckBox.TabIndex = 16;
			LimitsEnforcedCheckBox.Text = "Limits Enforced";
			SpanUpperLimitDoubleEditButton.EditBox = LimitSpanUpperValueEditBox;
			SpanUpperLimitDoubleEditButton.Location = new Point(184, 118);
			SpanUpperLimitDoubleEditButton.Name = "SpanUpperLimitDoubleEditButton";
			SpanUpperLimitDoubleEditButton.TabIndex = 14;
			LimitSpanUpperValueEditBox.LoadingBegin();
			LimitSpanUpperValueEditBox.Location = new Point(104, 120);
			LimitSpanUpperValueEditBox.Name = "LimitSpanUpperValueEditBox";
			LimitSpanUpperValueEditBox.PropertyName = "LimitSpanUpperValue";
			LimitSpanUpperValueEditBox.Size = new Size(80, 20);
			LimitSpanUpperValueEditBox.TabIndex = 13;
			LimitSpanUpperValueEditBox.TextAlign = HorizontalAlignment.Center;
			LimitSpanUpperValueEditBox.LoadingEnd();
			LimitSpanUpperEnabledCheckBox.Location = new Point(80, 120);
			LimitSpanUpperEnabledCheckBox.Name = "LimitSpanUpperEnabledCheckBox";
			LimitSpanUpperEnabledCheckBox.PropertyName = "LimitSpanUpperEnabled";
			LimitSpanUpperEnabledCheckBox.Size = new Size(24, 24);
			LimitSpanUpperEnabledCheckBox.TabIndex = 12;
			MaxUpperLimitDoubleEditButton.EditBox = LimitMaxUpperValueEditBox;
			MaxUpperLimitDoubleEditButton.Location = new Point(184, 70);
			MaxUpperLimitDoubleEditButton.Name = "MaxUpperLimitDoubleEditButton";
			MaxUpperLimitDoubleEditButton.TabIndex = 6;
			LimitMaxUpperValueEditBox.LoadingBegin();
			LimitMaxUpperValueEditBox.Location = new Point(104, 72);
			LimitMaxUpperValueEditBox.Name = "LimitMaxUpperValueEditBox";
			LimitMaxUpperValueEditBox.PropertyName = "LimitMaxUpperValue";
			LimitMaxUpperValueEditBox.Size = new Size(80, 20);
			LimitMaxUpperValueEditBox.TabIndex = 5;
			LimitMaxUpperValueEditBox.TextAlign = HorizontalAlignment.Center;
			LimitMaxUpperValueEditBox.LoadingEnd();
			LimitMaxUpperEnabledCheckBox.Location = new Point(80, 72);
			LimitMaxUpperEnabledCheckBox.Name = "LimitMaxUpperEnabledCheckBox";
			LimitMaxUpperEnabledCheckBox.PropertyName = "LimitMaxUpperEnabled";
			LimitMaxUpperEnabledCheckBox.Size = new Size(24, 24);
			LimitMaxUpperEnabledCheckBox.TabIndex = 4;
			MinLowerLimitDoubleEditButton.EditBox = LimitMinLowerValueEditBox;
			MinLowerLimitDoubleEditButton.Location = new Point(184, 46);
			MinLowerLimitDoubleEditButton.Name = "MinLowerLimitDoubleEditButton";
			MinLowerLimitDoubleEditButton.TabIndex = 2;
			LimitMinLowerValueEditBox.LoadingBegin();
			LimitMinLowerValueEditBox.Location = new Point(104, 48);
			LimitMinLowerValueEditBox.Name = "LimitMinLowerValueEditBox";
			LimitMinLowerValueEditBox.PropertyName = "LimitMinLowerValue";
			LimitMinLowerValueEditBox.Size = new Size(80, 20);
			LimitMinLowerValueEditBox.TabIndex = 1;
			LimitMinLowerValueEditBox.TextAlign = HorizontalAlignment.Center;
			LimitMinLowerValueEditBox.LoadingEnd();
			SpanLowerLimitDoubleEditButton.EditBox = LimitSpanLowerValueEditBox;
			SpanLowerLimitDoubleEditButton.Location = new Point(184, 94);
			SpanLowerLimitDoubleEditButton.Name = "SpanLowerLimitDoubleEditButton";
			SpanLowerLimitDoubleEditButton.TabIndex = 10;
			LimitSpanLowerValueEditBox.LoadingBegin();
			LimitSpanLowerValueEditBox.Location = new Point(104, 96);
			LimitSpanLowerValueEditBox.Name = "LimitSpanLowerValueEditBox";
			LimitSpanLowerValueEditBox.PropertyName = "LimitSpanLowerValue";
			LimitSpanLowerValueEditBox.Size = new Size(80, 20);
			LimitSpanLowerValueEditBox.TabIndex = 9;
			LimitSpanLowerValueEditBox.TextAlign = HorizontalAlignment.Center;
			LimitSpanLowerValueEditBox.LoadingEnd();
			LimitSpanLowerEnabledCheckBox.Location = new Point(80, 96);
			LimitSpanLowerEnabledCheckBox.Name = "LimitSpanLowerEnabledCheckBox";
			LimitSpanLowerEnabledCheckBox.PropertyName = "LimitSpanLowerEnabled";
			LimitSpanLowerEnabledCheckBox.Size = new Size(24, 24);
			LimitSpanLowerEnabledCheckBox.TabIndex = 8;
			LimitMinLowerEnabledCheckBox.Location = new Point(80, 48);
			LimitMinLowerEnabledCheckBox.Name = "LimitMinLowerEnabledCheckBox";
			LimitMinLowerEnabledCheckBox.PropertyName = "LimitMinLowerEnabled";
			LimitMinLowerEnabledCheckBox.Size = new Size(24, 24);
			LimitMinLowerEnabledCheckBox.TabIndex = 0;
			focusLabel8.LoadingBegin();
			focusLabel8.FocusControl = ScaleTypeComboBox;
			focusLabel8.Location = new Point(10, 146);
			focusLabel8.Name = "focusLabel8";
			focusLabel8.Size = new Size(62, 15);
			focusLabel8.Text = "Scale Type";
			focusLabel8.LoadingEnd();
			ScaleTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ScaleTypeComboBox.Location = new Point(72, 144);
			ScaleTypeComboBox.Name = "ScaleTypeComboBox";
			ScaleTypeComboBox.PropertyName = "ScaleType";
			ScaleTypeComboBox.Size = new Size(112, 21);
			ScaleTypeComboBox.TabIndex = 7;
			groupBox1.Controls.Add(SplitPercentEditBox);
			groupBox1.Controls.Add(focusLabel9);
			groupBox1.Controls.Add(SplitStartTextBox);
			groupBox1.Controls.Add(label8);
			groupBox1.Location = new Point(72, 184);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(152, 72);
			groupBox1.TabIndex = 8;
			groupBox1.TabStop = false;
			groupBox1.Text = "Split";
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
			base.Controls.Add(focusLabel8);
			base.Controls.Add(ScaleTypeComboBox);
			base.Controls.Add(LimitGroupBox);
			base.Controls.Add(SpanDoubleEditButton);
			base.Controls.Add(MaxDoubleEditButton);
			base.Controls.Add(MinDoubleEditButton);
			base.Controls.Add(MaxTextBox);
			base.Controls.Add(label2);
			base.Controls.Add(ReverseCheckBox);
			base.Controls.Add(SpanTextBox);
			base.Controls.Add(MinTextBox);
			base.Controls.Add(label3);
			base.Controls.Add(label1);
			base.Name = "ScaleRangeLinearEditorPlugIn";
			base.Size = new Size(800, 304);
			base.Title = "Scale Range Editor";
			LimitGroupBox.ResumeLayout(false);
			groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
