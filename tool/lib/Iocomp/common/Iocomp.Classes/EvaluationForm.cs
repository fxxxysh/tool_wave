using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public class EvaluationForm : Form
	{
		private Label label2;

		private Label label3;

		private PictureBox LogoPictureBox;

		private Button OkButton;

		private Label label1;

		private Label label4;

		private Label label5;

		private LinkLabel HomeLinkLabel;

		private LinkLabel SupportLinkLabel;

		private Label label6;

		private LinkLabel SalesLinkLabel;

		private ImageList imageList1;

		private Label label7;

		private Label label8;

		private IContainer components;

		public EvaluationForm()
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
			components = new Container();
			ResourceManager resourceManager = new ResourceManager(typeof(EvaluationForm));
			label2 = new Label();
			label3 = new Label();
			HomeLinkLabel = new LinkLabel();
			LogoPictureBox = new PictureBox();
			OkButton = new Button();
			label1 = new Label();
			label4 = new Label();
			label5 = new Label();
			SupportLinkLabel = new LinkLabel();
			label6 = new Label();
			SalesLinkLabel = new LinkLabel();
			imageList1 = new ImageList(components);
			label7 = new Label();
			label8 = new Label();
			base.SuspendLayout();
			label2.AutoSize = true;
			label2.Location = new Point(8, 124);
			label2.Name = "label2";
			label2.Size = new Size(230, 16);
			label2.TabIndex = 1;
			label2.Text = "Copyright © 1998-2011 Iocomp Software Inc.";
			label3.AutoSize = true;
			label3.Location = new Point(8, 84);
			label3.Name = "label3";
			label3.Size = new Size(194, 16);
			label3.TabIndex = 2;
			label3.Text = "Iocomp Components Evaluation Copy";
			HomeLinkLabel.AutoSize = true;
			HomeLinkLabel.Location = new Point(264, 8);
			HomeLinkLabel.Name = "HomeLinkLabel";
			HomeLinkLabel.Size = new Size(93, 16);
			HomeLinkLabel.TabIndex = 3;
			HomeLinkLabel.TabStop = true;
			HomeLinkLabel.Text = "www.iocomp.com";
			HomeLinkLabel.LinkClicked += WebsiteLabel_LinkClicked;
			LogoPictureBox.BorderStyle = BorderStyle.FixedSingle;
			LogoPictureBox.Image = (Image)resourceManager.GetObject("LogoPictureBox.Image");
			LogoPictureBox.Location = new Point(8, 8);
			LogoPictureBox.Name = "LogoPictureBox";
			LogoPictureBox.Size = new Size(197, 67);
			LogoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			LogoPictureBox.TabIndex = 6;
			LogoPictureBox.TabStop = false;
			OkButton.BackColor = SystemColors.Control;
			OkButton.Location = new Point(318, 160);
			OkButton.Name = "OkButton";
			OkButton.TabIndex = 7;
			OkButton.Text = "&OK";
			OkButton.Click += OkButton_Click;
			label1.Location = new Point(8, 160);
			label1.Name = "label1";
			label1.Size = new Size(304, 72);
			label1.TabIndex = 8;
			label1.Text = "Warning: This computer program is protected by copyright law and international treaties. Unauthorized reproduction or distribution of this program, or any portion of it, may result in severe civil and criminal penalties, and will be prosecuted to the maximum extent possible under law.\r\n";
			label4.AutoSize = true;
			label4.Location = new Point(216, 8);
			label4.Name = "label4";
			label4.Size = new Size(44, 16);
			label4.TabIndex = 10;
			label4.Text = "Home : ";
			label4.TextAlign = ContentAlignment.MiddleRight;
			label5.AutoSize = true;
			label5.Location = new Point(208, 32);
			label5.Name = "label5";
			label5.Size = new Size(50, 16);
			label5.TabIndex = 11;
			label5.Text = "Support :";
			label5.TextAlign = ContentAlignment.MiddleRight;
			SupportLinkLabel.AutoSize = true;
			SupportLinkLabel.Location = new Point(264, 32);
			SupportLinkLabel.Name = "SupportLinkLabel";
			SupportLinkLabel.Size = new Size(134, 16);
			SupportLinkLabel.TabIndex = 12;
			SupportLinkLabel.TabStop = true;
			SupportLinkLabel.Text = "www.iocomp.com/support";
			SupportLinkLabel.LinkClicked += SupportLinkLabel_LinkClicked;
			label6.AutoSize = true;
			label6.Location = new Point(219, 56);
			label6.Name = "label6";
			label6.Size = new Size(39, 16);
			label6.TabIndex = 13;
			label6.Text = "Sales :";
			label6.TextAlign = ContentAlignment.MiddleRight;
			SalesLinkLabel.AutoSize = true;
			SalesLinkLabel.Location = new Point(264, 56);
			SalesLinkLabel.Name = "SalesLinkLabel";
			SalesLinkLabel.Size = new Size(123, 16);
			SalesLinkLabel.TabIndex = 14;
			SalesLinkLabel.TabStop = true;
			SalesLinkLabel.Text = "www.iocomp.com/order";
			SalesLinkLabel.LinkClicked += SalesLinkLabel1_LinkClicked;
			imageList1.ImageSize = new Size(197, 67);
			imageList1.ImageStream = (ImageListStreamer)resourceManager.GetObject("imageList1.ImageStream");
			imageList1.TransparentColor = Color.White;
			label7.BorderStyle = BorderStyle.Fixed3D;
			label7.Location = new Point(8, 144);
			label7.Name = "label7";
			label7.Size = new Size(384, 3);
			label7.TabIndex = 15;
			label7.Text = "label7";
			label8.AutoSize = true;
			label8.Location = new Point(8, 100);
			label8.Name = "label8";
			label8.Size = new Size(356, 16);
			label8.TabIndex = 16;
			label8.Text = "This software is a demo version and is not licensed for production use.";
			AutoScaleBaseSize = new Size(5, 13);
			BackColor = Color.DarkSeaGreen;
			base.ClientSize = new Size(402, 240);
			base.Controls.Add(label8);
			base.Controls.Add(label7);
			base.Controls.Add(SalesLinkLabel);
			base.Controls.Add(label6);
			base.Controls.Add(SupportLinkLabel);
			base.Controls.Add(label5);
			base.Controls.Add(label4);
			base.Controls.Add(label1);
			base.Controls.Add(OkButton);
			base.Controls.Add(LogoPictureBox);
			base.Controls.Add(HomeLinkLabel);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.FormBorderStyle = FormBorderStyle.Fixed3D;
			base.Icon = (Icon)resourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "EvaluationForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			Text = "Iocomp Evaluation";
			base.TopMost = true;
			base.Closing += EvaluationForm_Closing;
			base.ResumeLayout(false);
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			base.Hide();
		}

		private void EvaluationForm_Closing(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			base.Hide();
		}

		private void WebsiteLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			HomeLinkLabel.Links[HomeLinkLabel.Links.IndexOf(e.Link)].Visited = true;
			Process.Start("www.iocomp.com");
		}

		private void SupportLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			SupportLinkLabel.Links[SupportLinkLabel.Links.IndexOf(e.Link)].Visited = true;
			Process.Start("www.iocomp.com/support");
		}

		private void SalesLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			SalesLinkLabel.Links[SalesLinkLabel.Links.IndexOf(e.Link)].Visited = true;
			Process.Start("http://www.iocomp.com/shop/shopdisplaycategories.asp?id=13&cat=%2ENet+WinForms");
		}
	}
}
