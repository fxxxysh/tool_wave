using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class ScaleDisplayGeneratorEditorPlugIn : PlugInStandard
	{
		private FocusLabel label4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox GeneratorStyleComboBox;

		private Container components;

		public ScaleDisplayGeneratorEditorPlugIn()
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
			label4 = new FocusLabel();
			GeneratorStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			base.SuspendLayout();
			label4.LoadingBegin();
			label4.FocusControl = GeneratorStyleComboBox;
			label4.Location = new Point(8, 26);
			label4.Name = "label4";
			label4.Size = new Size(32, 15);
			label4.Text = "Style";
			label4.LoadingEnd();
			GeneratorStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			GeneratorStyleComboBox.Location = new Point(40, 24);
			GeneratorStyleComboBox.Name = "GeneratorStyleComboBox";
			GeneratorStyleComboBox.PropertyName = "GeneratorStyle";
			GeneratorStyleComboBox.Size = new Size(121, 21);
			GeneratorStyleComboBox.TabIndex = 0;
			base.Controls.Add(label4);
			base.Controls.Add(GeneratorStyleComboBox);
			base.Name = "ScaleDisplayGeneratorEditorPlugIn";
			base.Size = new Size(616, 216);
			base.Title = "Scale Display Editor";
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new ScaleGeneratorAutoEditorPlugIn(), "Auto", false);
			base.AddSubPlugIn(new ScaleGeneratorFixedEditorPlugIn(), "Fixed", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as ScaleDisplay).GeneratorAuto;
			base.SubPlugIns[1].Value = (base.Value as ScaleDisplay).GeneratorFixed;
		}
	}
}
