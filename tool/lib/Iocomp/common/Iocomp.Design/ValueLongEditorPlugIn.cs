using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public sealed class ValueLongEditorPlugIn : PlugInStandard
	{
		private Container components;

		private FocusLabel label1;

		private CheckBox EventsEnabledCheckBox;

		private FocusLabel label2;

		private FocusLabel label3;

		private EditBox MinTextBox;

		private EditBox ValueTextBox;

		private EditBox AsHexTextBox;

		private FocusLabel label4;

		private EditBox AsBinaryTextBox;

		private FocusLabel focusLabel1;

		private EditBox MaxTextBox;

		public ValueLongEditorPlugIn()
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
			ValueTextBox = new EditBox();
			label1 = new FocusLabel();
			EventsEnabledCheckBox = new CheckBox();
			label2 = new FocusLabel();
			MinTextBox = new EditBox();
			label3 = new FocusLabel();
			MaxTextBox = new EditBox();
			AsHexTextBox = new EditBox();
			label4 = new FocusLabel();
			AsBinaryTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			base.SuspendLayout();
			ValueTextBox.LoadingBegin();
			ValueTextBox.Location = new Point(64, 8);
			ValueTextBox.Name = "ValueTextBox";
			ValueTextBox.PropertyName = "AsLong";
			ValueTextBox.Size = new Size(208, 20);
			ValueTextBox.TabIndex = 0;
			ValueTextBox.LoadingEnd();
			label1.LoadingBegin();
			label1.FocusControl = ValueTextBox;
			label1.Location = new Point(28, 10);
			label1.Name = "label1";
			label1.Size = new Size(36, 15);
			label1.Text = "Value";
			label1.LoadingEnd();
			EventsEnabledCheckBox.Location = new Point(64, 152);
			EventsEnabledCheckBox.Name = "EventsEnabledCheckBox";
			EventsEnabledCheckBox.PropertyName = "EventsEnabled";
			EventsEnabledCheckBox.Size = new Size(112, 24);
			EventsEnabledCheckBox.TabIndex = 5;
			EventsEnabledCheckBox.Text = "Events Enabled";
			label2.LoadingBegin();
			label2.FocusControl = MinTextBox;
			label2.Location = new Point(39, 90);
			label2.Name = "label2";
			label2.Size = new Size(25, 15);
			label2.Text = "Min";
			label2.LoadingEnd();
			MinTextBox.LoadingBegin();
			MinTextBox.Location = new Point(64, 88);
			MinTextBox.Name = "MinTextBox";
			MinTextBox.PropertyName = "Min";
			MinTextBox.Size = new Size(104, 20);
			MinTextBox.TabIndex = 3;
			MinTextBox.LoadingEnd();
			label3.LoadingBegin();
			label3.FocusControl = MaxTextBox;
			label3.Location = new Point(36, 114);
			label3.Name = "label3";
			label3.Size = new Size(28, 15);
			label3.Text = "Max";
			label3.LoadingEnd();
			MaxTextBox.LoadingBegin();
			MaxTextBox.Location = new Point(64, 112);
			MaxTextBox.Name = "MaxTextBox";
			MaxTextBox.PropertyName = "Max";
			MaxTextBox.Size = new Size(104, 20);
			MaxTextBox.TabIndex = 4;
			MaxTextBox.LoadingEnd();
			AsHexTextBox.LoadingBegin();
			AsHexTextBox.Location = new Point(64, 32);
			AsHexTextBox.LongFormat = EditBoxLongFormat.Hex;
			AsHexTextBox.Name = "AsHexTextBox";
			AsHexTextBox.PropertyName = "AsLong";
			AsHexTextBox.Size = new Size(208, 20);
			AsHexTextBox.TabIndex = 1;
			AsHexTextBox.LoadingEnd();
			label4.LoadingBegin();
			label4.FocusControl = AsHexTextBox;
			label4.Location = new Point(21, 34);
			label4.Name = "label4";
			label4.Size = new Size(43, 15);
			label4.Text = "As Hex";
			label4.LoadingEnd();
			AsBinaryTextBox.LoadingBegin();
			AsBinaryTextBox.Location = new Point(64, 56);
			AsBinaryTextBox.LongFormat = EditBoxLongFormat.Binary;
			AsBinaryTextBox.Name = "AsBinaryTextBox";
			AsBinaryTextBox.PropertyName = "AsLong";
			AsBinaryTextBox.Size = new Size(208, 20);
			AsBinaryTextBox.TabIndex = 2;
			AsBinaryTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = AsBinaryTextBox;
			focusLabel1.Location = new Point(9, 58);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(55, 15);
			focusLabel1.Text = "As Binary";
			focusLabel1.LoadingEnd();
			base.Controls.Add(AsBinaryTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(AsHexTextBox);
			base.Controls.Add(label4);
			base.Controls.Add(MaxTextBox);
			base.Controls.Add(MinTextBox);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(EventsEnabledCheckBox);
			base.Controls.Add(ValueTextBox);
			base.Controls.Add(label1);
			base.Name = "ValueLongEditorPlugIn";
			base.Size = new Size(400, 216);
			base.Title = "Value Long Editor";
			base.ResumeLayout(false);
		}
	}
}
