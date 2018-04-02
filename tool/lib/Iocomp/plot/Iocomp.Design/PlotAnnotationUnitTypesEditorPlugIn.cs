using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotAnnotationUnitTypesEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox UnitTypeHeightComboBox;

		private FocusLabel focusLabel13;

		private Iocomp.Design.Plugin.EditorControls.ComboBox UnitTypeWidthComboBox;

		private FocusLabel focusLabel12;

		private Iocomp.Design.Plugin.EditorControls.ComboBox UnitTypeYComboBox;

		private FocusLabel focusLabel11;

		private Iocomp.Design.Plugin.EditorControls.ComboBox UnitTypeXComboBox;

		private FocusLabel focusLabel10;

		private Iocomp.Design.Plugin.EditorControls.ComboBox UnitTypeSizeComboBox;

		private FocusLabel focusLabel9;

		private Iocomp.Design.Plugin.EditorControls.ComboBox UnitTypeLocationComboBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.ComboBox UnitTypeAllComboBox;

		private FocusLabel focusLabel3;

		private GroupBox groupBox1;

		private Iocomp.Design.Plugin.EditorControls.ComboBox comboBox1;

		private FocusLabel focusLabel1;

		private Iocomp.Design.Plugin.EditorControls.ComboBox comboBox2;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.ComboBox comboBox3;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox comboBox4;

		private FocusLabel focusLabel5;

		private Iocomp.Design.Plugin.EditorControls.ComboBox comboBox5;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.ComboBox comboBox6;

		private FocusLabel focusLabel7;

		private Iocomp.Design.Plugin.EditorControls.ComboBox comboBox7;

		private FocusLabel focusLabel14;

		private Label label1;

		private Container components;

		public PlotAnnotationUnitTypesEditorPlugIn()
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
			UnitTypeHeightComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel13 = new FocusLabel();
			UnitTypeWidthComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel12 = new FocusLabel();
			UnitTypeYComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel11 = new FocusLabel();
			UnitTypeXComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel10 = new FocusLabel();
			UnitTypeSizeComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel9 = new FocusLabel();
			UnitTypeLocationComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel8 = new FocusLabel();
			UnitTypeAllComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel3 = new FocusLabel();
			groupBox1 = new GroupBox();
			comboBox7 = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel14 = new FocusLabel();
			comboBox6 = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel7 = new FocusLabel();
			comboBox5 = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel6 = new FocusLabel();
			comboBox4 = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel5 = new FocusLabel();
			comboBox3 = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel4 = new FocusLabel();
			comboBox2 = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel2 = new FocusLabel();
			comboBox1 = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			focusLabel1 = new FocusLabel();
			label1 = new Label();
			groupBox1.SuspendLayout();
			base.SuspendLayout();
			UnitTypeHeightComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			UnitTypeHeightComboBox.Location = new Point(192, 120);
			UnitTypeHeightComboBox.MaxDropDownItems = 20;
			UnitTypeHeightComboBox.Name = "UnitTypeHeightComboBox";
			UnitTypeHeightComboBox.PropertyName = "UnitTypeHeight";
			UnitTypeHeightComboBox.Size = new Size(80, 21);
			UnitTypeHeightComboBox.TabIndex = 6;
			focusLabel13.LoadingBegin();
			focusLabel13.FocusControl = UnitTypeHeightComboBox;
			focusLabel13.Location = new Point(153, 122);
			focusLabel13.Name = "focusLabel13";
			focusLabel13.Size = new Size(39, 15);
			focusLabel13.Text = "Height";
			focusLabel13.LoadingEnd();
			UnitTypeWidthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			UnitTypeWidthComboBox.Location = new Point(192, 96);
			UnitTypeWidthComboBox.MaxDropDownItems = 20;
			UnitTypeWidthComboBox.Name = "UnitTypeWidthComboBox";
			UnitTypeWidthComboBox.PropertyName = "UnitTypeWidth";
			UnitTypeWidthComboBox.Size = new Size(80, 21);
			UnitTypeWidthComboBox.TabIndex = 5;
			focusLabel12.LoadingBegin();
			focusLabel12.FocusControl = UnitTypeWidthComboBox;
			focusLabel12.Location = new Point(156, 98);
			focusLabel12.Name = "focusLabel12";
			focusLabel12.Size = new Size(36, 15);
			focusLabel12.Text = "Width";
			focusLabel12.LoadingEnd();
			UnitTypeYComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			UnitTypeYComboBox.Location = new Point(56, 120);
			UnitTypeYComboBox.MaxDropDownItems = 20;
			UnitTypeYComboBox.Name = "UnitTypeYComboBox";
			UnitTypeYComboBox.PropertyName = "UnitTypeY";
			UnitTypeYComboBox.Size = new Size(80, 21);
			UnitTypeYComboBox.TabIndex = 3;
			focusLabel11.LoadingBegin();
			focusLabel11.FocusControl = UnitTypeYComboBox;
			focusLabel11.Location = new Point(41, 122);
			focusLabel11.Name = "focusLabel11";
			focusLabel11.Size = new Size(15, 15);
			focusLabel11.Text = "Y";
			focusLabel11.LoadingEnd();
			UnitTypeXComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			UnitTypeXComboBox.Location = new Point(56, 96);
			UnitTypeXComboBox.MaxDropDownItems = 20;
			UnitTypeXComboBox.Name = "UnitTypeXComboBox";
			UnitTypeXComboBox.PropertyName = "UnitTypeX";
			UnitTypeXComboBox.Size = new Size(80, 21);
			UnitTypeXComboBox.TabIndex = 2;
			focusLabel10.LoadingBegin();
			focusLabel10.FocusControl = UnitTypeXComboBox;
			focusLabel10.Location = new Point(41, 98);
			focusLabel10.Name = "focusLabel10";
			focusLabel10.Size = new Size(15, 15);
			focusLabel10.Text = "X";
			focusLabel10.LoadingEnd();
			UnitTypeSizeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			UnitTypeSizeComboBox.Location = new Point(192, 64);
			UnitTypeSizeComboBox.MaxDropDownItems = 20;
			UnitTypeSizeComboBox.Name = "UnitTypeSizeComboBox";
			UnitTypeSizeComboBox.PropertyName = "UnitTypeSize";
			UnitTypeSizeComboBox.Size = new Size(80, 21);
			UnitTypeSizeComboBox.TabIndex = 4;
			focusLabel9.LoadingBegin();
			focusLabel9.FocusControl = UnitTypeSizeComboBox;
			focusLabel9.Location = new Point(163, 66);
			focusLabel9.Name = "focusLabel9";
			focusLabel9.Size = new Size(29, 15);
			focusLabel9.Text = "Size";
			focusLabel9.LoadingEnd();
			UnitTypeLocationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			UnitTypeLocationComboBox.Location = new Point(56, 64);
			UnitTypeLocationComboBox.MaxDropDownItems = 20;
			UnitTypeLocationComboBox.Name = "UnitTypeLocationComboBox";
			UnitTypeLocationComboBox.PropertyName = "UnitTypeLocation";
			UnitTypeLocationComboBox.Size = new Size(80, 21);
			UnitTypeLocationComboBox.TabIndex = 1;
			focusLabel8.LoadingBegin();
			focusLabel8.FocusControl = UnitTypeLocationComboBox;
			focusLabel8.Location = new Point(7, 66);
			focusLabel8.Name = "focusLabel8";
			focusLabel8.Size = new Size(49, 15);
			focusLabel8.Text = "Location";
			focusLabel8.LoadingEnd();
			UnitTypeAllComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			UnitTypeAllComboBox.Location = new Point(56, 32);
			UnitTypeAllComboBox.MaxDropDownItems = 20;
			UnitTypeAllComboBox.Name = "UnitTypeAllComboBox";
			UnitTypeAllComboBox.PropertyName = "UnitTypeAll";
			UnitTypeAllComboBox.Size = new Size(80, 21);
			UnitTypeAllComboBox.TabIndex = 0;
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = UnitTypeAllComboBox;
			focusLabel3.Location = new Point(36, 34);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(20, 15);
			focusLabel3.Text = "All";
			focusLabel3.LoadingEnd();
			groupBox1.Controls.Add(comboBox7);
			groupBox1.Controls.Add(focusLabel14);
			groupBox1.Controls.Add(comboBox6);
			groupBox1.Controls.Add(focusLabel7);
			groupBox1.Controls.Add(comboBox5);
			groupBox1.Controls.Add(focusLabel6);
			groupBox1.Controls.Add(comboBox4);
			groupBox1.Controls.Add(focusLabel5);
			groupBox1.Controls.Add(comboBox3);
			groupBox1.Controls.Add(focusLabel4);
			groupBox1.Controls.Add(comboBox2);
			groupBox1.Controls.Add(focusLabel2);
			groupBox1.Controls.Add(comboBox1);
			groupBox1.Controls.Add(focusLabel1);
			groupBox1.Location = new Point(296, 8);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(296, 152);
			groupBox1.TabIndex = 7;
			groupBox1.TabStop = false;
			groupBox1.Text = "Actual";
			comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox7.Location = new Point(200, 112);
			comboBox7.MaxDropDownItems = 20;
			comboBox7.Name = "comboBox7";
			comboBox7.PropertyName = "ActualUnitTypeHeight";
			comboBox7.ReadOnly = true;
			comboBox7.Size = new Size(80, 21);
			comboBox7.TabIndex = 6;
			focusLabel14.LoadingBegin();
			focusLabel14.AutoSize = false;
			focusLabel14.FocusControl = comboBox7;
			focusLabel14.Location = new Point(161, 114);
			focusLabel14.Name = "focusLabel14";
			focusLabel14.Size = new Size(39, 15);
			focusLabel14.Text = "Height";
			focusLabel14.LoadingEnd();
			comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox6.Location = new Point(200, 88);
			comboBox6.MaxDropDownItems = 20;
			comboBox6.Name = "comboBox6";
			comboBox6.PropertyName = "ActualUnitTypeWidth";
			comboBox6.ReadOnly = true;
			comboBox6.Size = new Size(80, 21);
			comboBox6.TabIndex = 5;
			focusLabel7.LoadingBegin();
			focusLabel7.FocusControl = comboBox6;
			focusLabel7.Location = new Point(164, 90);
			focusLabel7.Name = "focusLabel7";
			focusLabel7.Size = new Size(36, 15);
			focusLabel7.Text = "Width";
			focusLabel7.LoadingEnd();
			comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox5.Location = new Point(64, 112);
			comboBox5.MaxDropDownItems = 20;
			comboBox5.Name = "comboBox5";
			comboBox5.PropertyName = "ActualUnitTypeY";
			comboBox5.ReadOnly = true;
			comboBox5.Size = new Size(80, 21);
			comboBox5.TabIndex = 3;
			focusLabel6.LoadingBegin();
			focusLabel6.FocusControl = comboBox5;
			focusLabel6.Location = new Point(49, 114);
			focusLabel6.Name = "focusLabel6";
			focusLabel6.Size = new Size(15, 15);
			focusLabel6.Text = "Y";
			focusLabel6.LoadingEnd();
			comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox4.Location = new Point(64, 88);
			comboBox4.MaxDropDownItems = 20;
			comboBox4.Name = "comboBox4";
			comboBox4.PropertyName = "ActualUnitTypeX";
			comboBox4.ReadOnly = true;
			comboBox4.Size = new Size(80, 21);
			comboBox4.TabIndex = 2;
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = comboBox4;
			focusLabel5.Location = new Point(49, 90);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(15, 15);
			focusLabel5.Text = "X";
			focusLabel5.LoadingEnd();
			comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox3.Location = new Point(200, 56);
			comboBox3.MaxDropDownItems = 20;
			comboBox3.Name = "comboBox3";
			comboBox3.PropertyName = "ActualUnitTypeSize";
			comboBox3.ReadOnly = true;
			comboBox3.Size = new Size(80, 21);
			comboBox3.TabIndex = 4;
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = comboBox3;
			focusLabel4.Location = new Point(171, 58);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(29, 15);
			focusLabel4.Text = "Size";
			focusLabel4.LoadingEnd();
			comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox2.Location = new Point(64, 56);
			comboBox2.MaxDropDownItems = 20;
			comboBox2.Name = "comboBox2";
			comboBox2.PropertyName = "ActualUnitTypeLocation";
			comboBox2.ReadOnly = true;
			comboBox2.Size = new Size(80, 21);
			comboBox2.TabIndex = 1;
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = comboBox2;
			focusLabel2.Location = new Point(15, 58);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(49, 15);
			focusLabel2.Text = "Location";
			focusLabel2.LoadingEnd();
			comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBox1.Location = new Point(64, 24);
			comboBox1.MaxDropDownItems = 20;
			comboBox1.Name = "comboBox1";
			comboBox1.PropertyName = "ActualUnitTypeAll";
			comboBox1.ReadOnly = true;
			comboBox1.Size = new Size(80, 21);
			comboBox1.TabIndex = 0;
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = comboBox1;
			focusLabel1.Location = new Point(44, 26);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(20, 15);
			focusLabel1.Text = "All";
			focusLabel1.LoadingEnd();
			label1.Location = new Point(8, 168);
			label1.Name = "label1";
			label1.Size = new Size(296, 64);
			label1.TabIndex = 8;
			label1.Text = "Notes: For Line && Polygon Annotations, use the All setting only! Pixel option is typically used on the Size, Width, and Height settings only! Percent settings are in units of 0.0 - 1.0";
			base.Controls.Add(label1);
			base.Controls.Add(groupBox1);
			base.Controls.Add(UnitTypeHeightComboBox);
			base.Controls.Add(focusLabel13);
			base.Controls.Add(UnitTypeWidthComboBox);
			base.Controls.Add(focusLabel12);
			base.Controls.Add(UnitTypeYComboBox);
			base.Controls.Add(focusLabel11);
			base.Controls.Add(UnitTypeXComboBox);
			base.Controls.Add(focusLabel10);
			base.Controls.Add(UnitTypeSizeComboBox);
			base.Controls.Add(focusLabel9);
			base.Controls.Add(UnitTypeLocationComboBox);
			base.Controls.Add(focusLabel8);
			base.Controls.Add(UnitTypeAllComboBox);
			base.Controls.Add(focusLabel3);
			base.Location = new Point(10, 20);
			base.Name = "PlotAnnotationUnitTypesEditorPlugIn";
			base.Size = new Size(608, 240);
			groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
