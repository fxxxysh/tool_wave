using Iocomp.Instrumentation.Plotting;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotFileIOEditorPlugIn : PlugInStandard
	{
		private GroupBox ConfigurationGroupBox;

		private GroupBox DataGroupBox;

		private Button SaveConfigurationButton;

		private Button LoadConfigurationButton;

		private Button LoadDataButton;

		private Button SaveDataButton;

		private Container components;

		public PlotFileIOEditorPlugIn()
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
			ConfigurationGroupBox = new GroupBox();
			LoadConfigurationButton = new Button();
			SaveConfigurationButton = new Button();
			DataGroupBox = new GroupBox();
			LoadDataButton = new Button();
			SaveDataButton = new Button();
			ConfigurationGroupBox.SuspendLayout();
			DataGroupBox.SuspendLayout();
			base.SuspendLayout();
			ConfigurationGroupBox.Controls.Add(LoadConfigurationButton);
			ConfigurationGroupBox.Controls.Add(SaveConfigurationButton);
			ConfigurationGroupBox.Location = new Point(48, 32);
			ConfigurationGroupBox.Name = "ConfigurationGroupBox";
			ConfigurationGroupBox.Size = new Size(152, 120);
			ConfigurationGroupBox.TabIndex = 0;
			ConfigurationGroupBox.TabStop = false;
			ConfigurationGroupBox.Text = "Properties (Configuration)";
			LoadConfigurationButton.Location = new Point(40, 72);
			LoadConfigurationButton.Name = "LoadConfigurationButton";
			LoadConfigurationButton.Size = new Size(80, 23);
			LoadConfigurationButton.TabIndex = 1;
			LoadConfigurationButton.Text = "Load";
			LoadConfigurationButton.Click += LoadConfigurationButton_Click;
			SaveConfigurationButton.Location = new Point(40, 24);
			SaveConfigurationButton.Name = "SaveConfigurationButton";
			SaveConfigurationButton.Size = new Size(80, 23);
			SaveConfigurationButton.TabIndex = 0;
			SaveConfigurationButton.Text = "Save";
			SaveConfigurationButton.Click += SaveConfigurationButton_Click;
			DataGroupBox.Controls.Add(LoadDataButton);
			DataGroupBox.Controls.Add(SaveDataButton);
			DataGroupBox.Location = new Point(216, 32);
			DataGroupBox.Name = "DataGroupBox";
			DataGroupBox.Size = new Size(152, 120);
			DataGroupBox.TabIndex = 1;
			DataGroupBox.TabStop = false;
			DataGroupBox.Text = "Data (All Channels)";
			LoadDataButton.Location = new Point(40, 69);
			LoadDataButton.Name = "LoadDataButton";
			LoadDataButton.Size = new Size(80, 23);
			LoadDataButton.TabIndex = 1;
			LoadDataButton.Text = "Load";
			LoadDataButton.Click += LoadDataButton_Click;
			SaveDataButton.Location = new Point(40, 24);
			SaveDataButton.Name = "SaveDataButton";
			SaveDataButton.Size = new Size(80, 23);
			SaveDataButton.TabIndex = 0;
			SaveDataButton.Text = "Save";
			SaveDataButton.Click += SaveDataButton_Click;
			base.Controls.Add(DataGroupBox);
			base.Controls.Add(ConfigurationGroupBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotFileIOEditorPlugIn";
			base.Size = new Size(544, 256);
			ConfigurationGroupBox.ResumeLayout(false);
			DataGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private void SaveConfigurationButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Save Configuration";
			saveFileDialog.AddExtension = true;
			saveFileDialog.CheckPathExists = true;
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.ShowHelp = true;
			saveFileDialog.InitialDirectory = Application.StartupPath;
			saveFileDialog.FileName = "Untitled.cfg";
			saveFileDialog.DefaultExt = "cfg";
			saveFileDialog.Filter = "Configuration(*.cfg)|*.cfg|All Files(*.*)|*.*";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				(base.WorkingInstance as Plot).SavePropertiesToFile(saveFileDialog.FileName);
			}
		}

		private void LoadConfigurationButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Load Configuration";
			openFileDialog.AddExtension = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.CheckFileExists = true;
			openFileDialog.Multiselect = false;
			openFileDialog.ShowHelp = true;
			openFileDialog.ValidateNames = true;
			openFileDialog.InitialDirectory = Application.StartupPath;
			openFileDialog.FileName = "";
			openFileDialog.DefaultExt = "cfg";
			openFileDialog.Filter = "Configuration(*.cfg)|*.cfg|All Files(*.*)|*.*";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				(base.WorkingInstance as Plot).LoadPropertiesFromFile(openFileDialog.FileName);
			}
		}

		private void SaveDataButton_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Save Data";
			saveFileDialog.AddExtension = true;
			saveFileDialog.CheckPathExists = true;
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.InitialDirectory = Application.StartupPath;
			saveFileDialog.ShowHelp = true;
			saveFileDialog.FileName = "Untitled.dat";
			saveFileDialog.DefaultExt = "dat";
			saveFileDialog.Filter = "Data(*.dat)|*.dat|All Files(*.*)|*.*";
			saveFileDialog.FilterIndex = 1;
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				(base.WorkingInstance as Plot).SaveDataToFile(saveFileDialog.FileName);
			}
		}

		private void LoadDataButton_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Load Data";
			openFileDialog.AddExtension = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.CheckFileExists = true;
			openFileDialog.Multiselect = false;
			openFileDialog.ShowHelp = true;
			openFileDialog.ValidateNames = true;
			openFileDialog.InitialDirectory = Application.StartupPath;
			openFileDialog.FileName = "";
			openFileDialog.DefaultExt = "dat";
			openFileDialog.Filter = "Data(*.dat)|*.dat|All Files(*.*)|*.*";
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				(base.WorkingInstance as Plot).LoadDataFromFile(openFileDialog.FileName);
			}
		}
	}
}
