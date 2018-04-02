using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotLogFileAdapterEditorPlugIn : PlugInStandard
	{
		private FocusLabel label3;

		private FocusLabel focusLabel1;

		private CheckBox AppendCheckBox;

		private CheckBox AppendFileMustExistCheckBox;

		private CheckBox AllowFileOverwriteCheckBox;

		private EditBox FileNameTextBox;

		private EditBox BufferSizeTextBox;

		private Container components;

		public PlotLogFileAdapterEditorPlugIn()
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
			AppendCheckBox = new CheckBox();
			AllowFileOverwriteCheckBox = new CheckBox();
			AppendFileMustExistCheckBox = new CheckBox();
			FileNameTextBox = new EditBox();
			label3 = new FocusLabel();
			BufferSizeTextBox = new EditBox();
			focusLabel1 = new FocusLabel();
			base.SuspendLayout();
			AppendCheckBox.Location = new Point(80, 96);
			AppendCheckBox.Name = "AppendCheckBox";
			AppendCheckBox.PropertyName = "Append";
			AppendCheckBox.Size = new Size(72, 24);
			AppendCheckBox.TabIndex = 2;
			AppendCheckBox.Text = "Append";
			AllowFileOverwriteCheckBox.Location = new Point(80, 144);
			AllowFileOverwriteCheckBox.Name = "AllowFileOverwriteCheckBox";
			AllowFileOverwriteCheckBox.PropertyName = "AllowFileOverwrite";
			AllowFileOverwriteCheckBox.Size = new Size(160, 24);
			AllowFileOverwriteCheckBox.TabIndex = 4;
			AllowFileOverwriteCheckBox.Text = "Allow File Overwrite";
			AppendFileMustExistCheckBox.Location = new Point(80, 120);
			AppendFileMustExistCheckBox.Name = "AppendFileMustExistCheckBox";
			AppendFileMustExistCheckBox.PropertyName = "AppendFileMustExist";
			AppendFileMustExistCheckBox.Size = new Size(160, 24);
			AppendFileMustExistCheckBox.TabIndex = 3;
			AppendFileMustExistCheckBox.Text = "Append File Must Exist";
			FileNameTextBox.LoadingBegin();
			FileNameTextBox.Location = new Point(80, 32);
			FileNameTextBox.Name = "FileNameTextBox";
			FileNameTextBox.PropertyName = "FileName";
			FileNameTextBox.Size = new Size(189, 20);
			FileNameTextBox.TabIndex = 0;
			FileNameTextBox.LoadingEnd();
			label3.LoadingBegin();
			label3.FocusControl = FileNameTextBox;
			label3.Location = new Point(22, 34);
			label3.Name = "label3";
			label3.Size = new Size(58, 15);
			label3.Text = "File Name";
			label3.LoadingEnd();
			BufferSizeTextBox.LoadingBegin();
			BufferSizeTextBox.Location = new Point(80, 64);
			BufferSizeTextBox.Name = "BufferSizeTextBox";
			BufferSizeTextBox.PropertyName = "BufferSize";
			BufferSizeTextBox.Size = new Size(80, 20);
			BufferSizeTextBox.TabIndex = 1;
			BufferSizeTextBox.LoadingEnd();
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = BufferSizeTextBox;
			focusLabel1.Location = new Point(19, 66);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(61, 15);
			focusLabel1.Text = "Buffer Size";
			focusLabel1.LoadingEnd();
			base.Controls.Add(BufferSizeTextBox);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(FileNameTextBox);
			base.Controls.Add(label3);
			base.Controls.Add(AppendFileMustExistCheckBox);
			base.Controls.Add(AllowFileOverwriteCheckBox);
			base.Controls.Add(AppendCheckBox);
			base.Name = "PlotLogFileAdapterEditorPlugIn";
			base.Size = new Size(424, 288);
			base.ResumeLayout(false);
		}
	}
}
