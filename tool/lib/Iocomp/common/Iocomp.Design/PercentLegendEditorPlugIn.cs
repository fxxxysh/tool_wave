using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PercentLegendEditorPlugIn : PlugInStandard
	{
		private FocusLabel label4;

		private CheckBox VisibleCheckBox;

		private FocusLabel label2;

		private FocusLabel label3;

		private EditBox MarginTextBox;

		private EditBox RowSpacingTextBox;

		private EditBox TitleMarginTextBox;

		private FocusLabel label1;

		private ColorPicker ForeColorPicker;

		private FontButton FontButton;

		private Container components;

		public PercentLegendEditorPlugIn()
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
			VisibleCheckBox = new CheckBox();
			label4 = new FocusLabel();
			ForeColorPicker = new ColorPicker();
			label2 = new FocusLabel();
			RowSpacingTextBox = new EditBox();
			label3 = new FocusLabel();
			MarginTextBox = new EditBox();
			FontButton = new FontButton();
			TitleMarginTextBox = new EditBox();
			label1 = new FocusLabel();
			base.SuspendLayout();
			VisibleCheckBox.Location = new Point(80, 0);
			VisibleCheckBox.Name = "VisibleCheckBox";
			VisibleCheckBox.PropertyName = "Visible";
			VisibleCheckBox.Size = new Size(64, 24);
			VisibleCheckBox.TabIndex = 0;
			VisibleCheckBox.Text = "Visible";
			label4.LoadingBegin();
			label4.FocusControl = ForeColorPicker;
			label4.Location = new Point(21, 123);
			label4.Name = "label4";
			label4.Size = new Size(59, 15);
			label4.Text = "Fore Color";
			label4.LoadingEnd();
			ForeColorPicker.Location = new Point(80, 120);
			ForeColorPicker.Name = "ForeColorPicker";
			ForeColorPicker.PropertyName = "ForeColor";
			ForeColorPicker.Size = new Size(144, 21);
			ForeColorPicker.TabIndex = 4;
			label2.LoadingBegin();
			label2.FocusControl = RowSpacingTextBox;
			label2.Location = new Point(8, 82);
			label2.Name = "label2";
			label2.Size = new Size(72, 15);
			label2.Text = "Row Spacing";
			label2.LoadingEnd();
			RowSpacingTextBox.LoadingBegin();
			RowSpacingTextBox.Location = new Point(80, 80);
			RowSpacingTextBox.Name = "RowSpacingTextBox";
			RowSpacingTextBox.PropertyName = "RowSpacing";
			RowSpacingTextBox.Size = new Size(48, 20);
			RowSpacingTextBox.TabIndex = 3;
			RowSpacingTextBox.LoadingEnd();
			label3.LoadingBegin();
			label3.FocusControl = MarginTextBox;
			label3.Location = new Point(39, 34);
			label3.Name = "label3";
			label3.Size = new Size(41, 15);
			label3.Text = "Margin";
			label3.LoadingEnd();
			MarginTextBox.LoadingBegin();
			MarginTextBox.Location = new Point(80, 32);
			MarginTextBox.Name = "MarginTextBox";
			MarginTextBox.PropertyName = "Margin";
			MarginTextBox.Size = new Size(48, 20);
			MarginTextBox.TabIndex = 1;
			MarginTextBox.LoadingEnd();
			FontButton.Location = new Point(280, 120);
			FontButton.Name = "FontButton";
			FontButton.PropertyName = "Font";
			FontButton.TabIndex = 5;
			TitleMarginTextBox.LoadingBegin();
			TitleMarginTextBox.Location = new Point(80, 56);
			TitleMarginTextBox.Name = "TitleMarginTextBox";
			TitleMarginTextBox.PropertyName = "TitleMargin";
			TitleMarginTextBox.Size = new Size(48, 20);
			TitleMarginTextBox.TabIndex = 2;
			TitleMarginTextBox.LoadingEnd();
			label1.LoadingBegin();
			label1.FocusControl = TitleMarginTextBox;
			label1.Location = new Point(15, 58);
			label1.Name = "label1";
			label1.Size = new Size(65, 15);
			label1.Text = "Title Margin";
			label1.LoadingEnd();
			base.Controls.Add(label1);
			base.Controls.Add(TitleMarginTextBox);
			base.Controls.Add(FontButton);
			base.Controls.Add(RowSpacingTextBox);
			base.Controls.Add(MarginTextBox);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label4);
			base.Controls.Add(ForeColorPicker);
			base.Controls.Add(VisibleCheckBox);
			base.Name = "PercentLegendEditorPlugIn";
			base.Size = new Size(496, 224);
			base.Title = "Legend Editor";
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PercentLegendColumnEditorPlugIn(), "Column Value", false);
			base.AddSubPlugIn(new PercentLegendColumnEditorPlugIn(), "Column Percent", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PercentLegend).ColumnValue;
			base.SubPlugIns[1].Value = (base.Value as PercentLegend).ColumnPercent;
		}
	}
}
