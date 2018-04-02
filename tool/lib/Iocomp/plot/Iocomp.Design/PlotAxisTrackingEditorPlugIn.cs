using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotAxisTrackingEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel7;

		private FocusLabel focusLabel1;

		private Iocomp.Design.Plugin.EditorControls.ComboBox AlignFirstStyleComboBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private EditBox ScrollCompressMaxTextBox;

		private FocusLabel focusLabel2;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ExpandStyleComboBox;

		private FocusLabel focusLabel4;

		private EditBox SpanMinEditBox;

		private EditBox MinMarginEditBox;

		private FocusLabel focusLabel5;

		private EditBox MaxMarginEditBox;

		private FocusLabel focusLabel6;

		private Container components;

		public PlotAxisTrackingEditorPlugIn()
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
			StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel7 = new FocusLabel();
			AlignFirstStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel1 = new FocusLabel();
			EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			ScrollCompressMaxTextBox = new EditBox();
			focusLabel2 = new FocusLabel();
			ExpandStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel3 = new FocusLabel();
			SpanMinEditBox = new EditBox();
			focusLabel4 = new FocusLabel();
			MinMarginEditBox = new EditBox();
			focusLabel5 = new FocusLabel();
			MaxMarginEditBox = new EditBox();
			focusLabel6 = new FocusLabel();
			base.SuspendLayout();
			StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			StyleComboBox.Location = new Point(96, 72);
			StyleComboBox.MaxDropDownItems = 20;
			StyleComboBox.Name = "StyleComboBox";
			StyleComboBox.PropertyName = "Style";
			StyleComboBox.Size = new Size(136, 21);
			StyleComboBox.TabIndex = 1;
			focusLabel7.LoadingBegin();
			focusLabel7.FocusControl = StyleComboBox;
			focusLabel7.Location = new Point(64, 74);
			focusLabel7.Name = "focusLabel7";
			focusLabel7.Size = new Size(32, 15);
			focusLabel7.Text = "Style";
			focusLabel7.LoadingEnd();
			AlignFirstStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			AlignFirstStyleComboBox.Location = new Point(352, 184);
			AlignFirstStyleComboBox.MaxDropDownItems = 20;
			AlignFirstStyleComboBox.Name = "AlignFirstStyleComboBox";
			AlignFirstStyleComboBox.PropertyName = "AlignFirstStyle";
			AlignFirstStyleComboBox.Size = new Size(136, 21);
			AlignFirstStyleComboBox.TabIndex = 6;
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = AlignFirstStyleComboBox;
			focusLabel1.Location = new Point(268, 186);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(84, 15);
			focusLabel1.Text = "Align First Style";
			focusLabel1.LoadingEnd();
			EnabledCheckBox.Location = new Point(96, 40);
			EnabledCheckBox.Name = "EnabledCheckBox";
			EnabledCheckBox.PropertyName = "Enabled";
			EnabledCheckBox.Size = new Size(72, 24);
			EnabledCheckBox.TabIndex = 0;
			EnabledCheckBox.Text = "Enabled";
			ScrollCompressMaxTextBox.LoadingBegin();
			ScrollCompressMaxTextBox.Location = new Point(352, 208);
			ScrollCompressMaxTextBox.Name = "ScrollCompressMaxTextBox";
			ScrollCompressMaxTextBox.PropertyName = "ScrollCompressMax";
			ScrollCompressMaxTextBox.Size = new Size(136, 20);
			ScrollCompressMaxTextBox.TabIndex = 7;
			ScrollCompressMaxTextBox.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = ScrollCompressMaxTextBox;
			focusLabel2.Location = new Point(240, 210);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(112, 15);
			focusLabel2.Text = "Scroll Compress Max";
			focusLabel2.LoadingEnd();
			ExpandStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ExpandStyleComboBox.Location = new Point(96, 96);
			ExpandStyleComboBox.MaxDropDownItems = 20;
			ExpandStyleComboBox.Name = "ExpandStyleComboBox";
			ExpandStyleComboBox.PropertyName = "ExpandStyle";
			ExpandStyleComboBox.Size = new Size(136, 21);
			ExpandStyleComboBox.TabIndex = 2;
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = ExpandStyleComboBox;
			focusLabel3.Location = new Point(24, 98);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(72, 15);
			focusLabel3.Text = "Expand Style";
			focusLabel3.LoadingEnd();
			SpanMinEditBox.LoadingBegin();
			SpanMinEditBox.Location = new Point(96, 144);
			SpanMinEditBox.Name = "SpanMinEditBox";
			SpanMinEditBox.PropertyName = "SpanMin";
			SpanMinEditBox.Size = new Size(136, 20);
			SpanMinEditBox.TabIndex = 3;
			SpanMinEditBox.LoadingEnd();
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = SpanMinEditBox;
			focusLabel4.Location = new Point(42, 146);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(54, 15);
			focusLabel4.Text = "Span Min";
			focusLabel4.LoadingEnd();
			MinMarginEditBox.LoadingBegin();
			MinMarginEditBox.Location = new Point(96, 208);
			MinMarginEditBox.Name = "MinMarginEditBox";
			MinMarginEditBox.PropertyName = "MinMargin";
			MinMarginEditBox.Size = new Size(136, 20);
			MinMarginEditBox.TabIndex = 5;
			MinMarginEditBox.LoadingEnd();
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = MinMarginEditBox;
			focusLabel5.Location = new Point(34, 210);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(62, 15);
			focusLabel5.Text = "Min Margin";
			focusLabel5.LoadingEnd();
			MaxMarginEditBox.LoadingBegin();
			MaxMarginEditBox.Location = new Point(96, 184);
			MaxMarginEditBox.Name = "MaxMarginEditBox";
			MaxMarginEditBox.PropertyName = "MaxMargin";
			MaxMarginEditBox.Size = new Size(136, 20);
			MaxMarginEditBox.TabIndex = 4;
			MaxMarginEditBox.LoadingEnd();
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = MaxMarginEditBox;
			focusLabel6.Location = new Point(31, 186);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(65, 15);
			focusLabel6.Text = "Max Margin";
			focusLabel6.LoadingEnd();
			base.Controls.Add(MaxMarginEditBox);
			base.Controls.Add(focusLabel6);
			base.Controls.Add(MinMarginEditBox);
			base.Controls.Add(focusLabel5);
			base.Controls.Add(SpanMinEditBox);
			base.Controls.Add(focusLabel4);
			base.Controls.Add(ExpandStyleComboBox);
			base.Controls.Add(focusLabel3);
			base.Controls.Add(ScrollCompressMaxTextBox);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(EnabledCheckBox);
			base.Controls.Add(AlignFirstStyleComboBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(StyleComboBox);
			base.Controls.Add(focusLabel7);
			base.Location = new Point(10, 20);
			base.Name = "PlotAxisTrackingEditorPlugIn";
			base.Size = new Size(504, 336);
			base.ResumeLayout(false);
		}
	}
}
