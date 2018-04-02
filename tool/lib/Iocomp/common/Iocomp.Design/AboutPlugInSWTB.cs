using Iocomp.Design.Plugin.EditorControls;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class AboutPlugInSWTB : PlugInStandard
	{
		private ImageList imageList1;

		private TextBox LicenseAgreementTextBox;

		private FocusLabel LicenseAgreementLabel;

		private FocusLabel VersionLabel;

		private FocusLabel CopyrightLabel;

		private FocusLabel ServicePackLabel;

		private PictureBox LogoPictureBox;

		private LinkLabel WebsiteLabel;

		private IContainer components;

		public AboutPlugInSWTB()
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
			ResourceManager resourceManager = new ResourceManager(typeof(AboutPlugInSWTB));
			LicenseAgreementTextBox = new TextBox();
			LicenseAgreementLabel = new FocusLabel();
			VersionLabel = new FocusLabel();
			CopyrightLabel = new FocusLabel();
			ServicePackLabel = new FocusLabel();
			LogoPictureBox = new PictureBox();
			imageList1 = new ImageList(components);
			WebsiteLabel = new LinkLabel();
			base.SuspendLayout();
			LicenseAgreementTextBox.Location = new Point(8, 88);
			LicenseAgreementTextBox.Multiline = true;
			LicenseAgreementTextBox.Name = "LicenseAgreementTextBox";
			LicenseAgreementTextBox.ReadOnly = true;
			LicenseAgreementTextBox.ScrollBars = ScrollBars.Vertical;
			LicenseAgreementTextBox.Size = new Size(424, 120);
			LicenseAgreementTextBox.TabIndex = 1;
			LicenseAgreementTextBox.Text = "PLEASE READ THE FOLLOWING LICENSE AGREEMENT. IT WILL BE NECESSARY FOR YOU TO AGREE TO BE BOUND BY THE TERMS OF THIS AGREEMENT BEFORE BEING PERMITTED TO CONTINUE TO INSTALL THE PRODUCT. THE PROCEDURE FOR ACCEPTING OR REJECTING THE LICENSE AGREEMENT IS SET OUT AFTER THE LICENSE AGREEMENT.\r\n\r\nIF YOU DO NOT ACCEPT THE TERMS OF THE LICENSE AGREEMENT FOR ANY SOFTWARE PRODUCT FOR WHICH YOU HAVE RECEIVED THE CD-KEY(S) WITH THIS CD-ROM OR OBTAINED THE CD-KEY(S) THROUGH AN AUTHORIZED SOURCE, THE INSTALLATION PROCESS WILL BE TERMINATED. YOU SHOULD PROMPTLY RETURN THE UNUSED SOFTWARE PRODUCT FOR A REFUND OF THE AMOUNT PAID FOR THE PARTICULAR PRODUCT WITHIN THIRTY (30) DAYS OF THE DATE OF PURCHASE\r\nLICENSE AGREEMENT FOR IOCOMP SOFTWARE:\r\nVERY IMPORTANT-CAREFULLY READ :\r\nThis Iocomp Software License Agreement (hereinafter \"LICENSE\") is a legal agreement between you (either an individual or a single entity) and Iocomp Software, Inc. (\"Iocomp\"), for the SOFTWARE or products identified on the disk or CD-ROM labels enclosed with this package and for which the CD-Keys(s) are either provided on the back of the enclosed CD case or obtained through Iocomp or an authorized distributor, which includes computer software and associated media and printed materials, and may include \"on-line\" or electronic documentation (\"SOFTWARE\"). By installing using the correct CD-Keys, copying or otherwise using the SOFTWARE, you agree to be bound by the terms of this LICENSE. If you do not agree to the terms of this LICENSE, promptly return the unused SOFTWARE to the place from which you obtained it for a full refund.\r\n\r\nSOFTWARE LICENSE\r\nThe SOFTWARE is protected by copyright laws and international copyright treaties, as well as other intellectual property laws and treaties. The SOFTWARE is licensed, not sold.\r\n\r\nI. LICENSE GRANT. This LICENSE grants you the following rights:\r\nA. You may use one copy of the Iocomp SOFTWARE identified above on a single computer. The SOFTWARE is in \"use\" on a computer when it is loaded into temporary memory (i.e. RAM) or installed into permanent memory (e.g. hard disk, CD-ROM, or other storage devise) of that computer. However, installation on a network server for the sole purpose of internal distribution to one or more other computer(s) shall not constitute \"use\" for which a separate license is required, provided you have a separate license for each computer to which the SOFTWARE is distributed.\r\nB. Solely with respect to electronic documents included with the SOFTWARE, you may make a copy (either in hardcopy or electronic form), provided that the number of copies made shall not exceed the number of licenses you own for that SOFTWARE, and further provided that such copies shall be used only for internal purposes and are not republished or distributed to any third party.\r\nC. You may use the trial versions and product tours, as described on the CD-ROM, of the software products included on this CD-ROM for the limited purposes of demonstrations, trials and design time evaluations and running a product tour.\r\n\r\nII. TITLE; COPYRIGHT. All title and copyrights in and to the SOFTWARE (including but not limited to any images, photographs, animation, video, audio, music, text and \"applets\" incorporated into the SOFTWARE), the accompanying printed materials, and any copies of the SOFTWARE are owned by IOCOMP or its suppliers. The SOFTWARE is protected by copyright laws and international treaty provisions. Therefore, you must treat the SOFTWARE like any other copyrighted material, except that you may either (A) make one copy of the SOFTWARE solely for backup or archival purposes or (B) install the SOFTWARE on a single computer provided you keep the original solely for backup or archival purposes. You may not copy the printed materials accompanying the SOFTWARE.\r\n\r\nIII. ADDITIONAL RIGHTS AND LIMITATIONS.\r\nA. Reverse Engineering, Decompilation, and Disassembly. You may not reverse engineer, decompile, or disassemble the SOFTWARE.\r\nB. No Separation of Components. The SOFTWARE is licensed as a single product and the software programs comprising the SOFTWARE may not be separated for use by more than one user at a time.\r\nC. Rental. You may not rent or lease the SOFTWARE.\r\nD. Software Transfer. You may NOT transfer any of your rights under this LICENSE.\r\nE. Termination. Without prejudice to any other rights, Iocomp may terminate this LICENSE if you fail to comply with the terms and conditions of this LICENSE. In such event, you must destroy all copies of the SOFTWARE.\r\n\r\nIV. REDISTRIBUTABLE COMPONENTS.\r\nA. Sample Code. In addition to the license granted in Section 1, Iocomp grants you the right to use and modify the source code versions of those portions of the SOFTWARE which are identified in the documentation as the Sample Code and located in the \\EXAMPLES(xx) subdirectory(s) of the SOFTWARE, either on disk, CD-ROM or electronic format (collectively \"SAMPLE CODE\") provided you comply with section 4.c. You may not distribute the EXAMPLE CODE, or any modified version of the EXAMPLE CODE, in source code form.\r\nB. Redistributable Code. In addition to the license granted in Section 1, Iocomp grants you a nonexclusive, royalty-free right to reproduce and distribute the object code version of those portions of the SOFTWAREdesignated in the SOFTWARE as (i) those portions of the SOFTWARE which are identified in the documentation as the VBX (\"VBX\") and/or OCX (\"OCX\") Controls; (ii) those portions of the SOFTWARE which are identified in the documentation as REDISTRIBUTABLE DLLs (\"DLLs\"); and (iii) SAMPLE CODE (collectively, \"REDISTRIBUTABLES\"), provided you comply with Section 4.c.\r\nC. Redistribution Requirements. If you redistribute the REDISTRIBUTABLES, you agree to (i) distribute the REDISTRIBUTABLES in object code form only in conjunction with and as part of your software application product which adds significant and primary functionality and which is designed, developed, and tested to operate in the Microsoft Windows and/or Windows NT environments; (ii) not use Iocomp's name, logo or trademarks to market your software application product; (iii) include a valid copyright notice on your SOFTWARE; (iv) indemnify, hold harmless, and defend Iocomp from and against any claims or lawsuits, including attorney's fees, that arise or result from the use and distribution of your software application product; and (v) not permit further distribution of the REDISTRIBUTABLES by your end user.\r\nD. OPC Runtime License. If you utilize the OPC (OLE for Process Control) features of the SOFTWARE, a DISTRIBUTION LICENSE must be obtained to distribute the REDISTRIBUTABLES. Installation of SOFTWARE on additional computers which utilize the OPC features of the SOFTWARE must have an OPC RUNTIME LICENSE. The OPC FEATURES included with your SOFTWARE LICENSE are for testing purposes only if you do not purchase an OPC Runtime License. Additional OPC RUNTIME LICENSES can be purchased from Iocomp Software or from an Iocomp Authorized Reseller. The OPC OEM Deployment License allows for unlimited distribution of a single application product using the OPC features of the SOFTWARE.\r\nE. OEM/1000 Development License.  If you allow development with the SOFTWARE COMPONENTS from within your software application product, you will need to obtain an OEM/1000 Development License.  The OEM/1000 Development License allows you to distribute up to 1000 copies of your software application product that enable development with our SOFTWARE COMPONENTS.  Development must be contained within your software application product.  Development is defined as the ability of your software application product to do ALL three of the following: i. Add and/or Remove our SOFTWARE COMPONENTS ii. modify our SOFTWARE COMPONENTS properties, methods, and/or events iii. Persist or Save/Load the properties of the SOFTWARE COMPONENTS.  \r\n\r\nV. U.S. GOVERNMENT RESTRICTED RIGHTS. The SOFTWARE and documentation are provided with RESTRICTED RIGHTS. Use, duplication, or disclosure by the Government is subject to restrictions as set forth in subparagraph (c) (1) (ii) of the Rights in Technical Data and Computer Software clause at DFARS 252.227-7013 or subparagraphs (c) (1) and (2) of the Commercial Computer Software - Restricted Rights at 48 CFR 52.227-19, as applicable. Manufacturer is Iocomp Software, Inc., 7081 Grand National Drive Suite 112, Orlando, FL 32819-8378.\r\n\r\nVI. EXPORT AND USE.  You are acknowledging that you are responsible for complying with all trade regulations and laws both foreign and domestic and agreeing that you will not use or otherwise export or re-export, directly or indirectly, this SOFTWARE or underlying information or technology except as authorized by United States law and the laws of the jurisdiction in which the SOFTWARE was obtained. In particular, but without limitation, the SOFTWARE may not be exported or re-exported, directly or indirectly, (i) into (or to a national or resident of) any U.S. embargoed country, including without limitation Afghanistan, Cuba, Iran, Iraq, Libya, North Korea, Sudan or Syria or (ii) to anyone on the U.S. Treasury Department's list of Specially Designated Nationals or the U.S. Department of Commerce's Table of Denial Orders or (iii) for any end-use that is prohibited by United States law and the laws of the jurisdiction in which the Technology was obtained. By downloading and/or using the SOFTWARE, you represent and warrant that you are not located in, under control of, or a national or resident of any such country or on any such list and that no U.S. federal agency has suspended, revoked, or denied your export privileges. \r\n\r\nLIMITED WARRANTY. \r\nLIMITED WARRANTY.  EXCEPT WITH RESPECT TO REDISTRIBUTABLES, WHICH ARE PROVIDED \"AS IS,\" WITHOUT WARRANTY OF ANY KIND, IOCOMP WARRANTS THAT THE SOFTWARE WILL PERFORM SUBSTANTIALLY IN ACCORDANCE WITH THE ACCOMPANYING WRITTEN MATERIALS FOR A PERIOD OF THIRTY (30) DAYS FROM THE DATE OF RECEIPT. SOME STATES AND JURISDICTIONS DO NOT ALLOW LIMITATIONS OF DURATION OF AN IMPLIED WARRANTY, SO THE ABOVE LIMITATION MAY NOT APPLY TO YOU. TO THE EXTENT ALLOWED BY APPLICABLE LAW, IMPLIED WARRANTIES ON THE SOFTWARE, IF ANY, ARE LIMITED TO THIRTY (30) DAYS.\r\n\r\nCUSTOMER REMEDIES. IOCOMP'S AND ITS SUPPLIERS' ENTIRE LIABILITY AND YOUR EXCLUSIVE REMEDY SHALL BE, AT IOCOMP'S OPTION, EITHER (A) RETURN OF THE PAID PRICE, OR (B) REPAIR OR REPLACEMENT OF THE SOFTWARE. PRODUCTS PURCHASED OTHER THAN DIRECTLY FROM IOCOMP SHALL BE RETURNED THROUGH THE RESELLER FROM WHICH IT WAS PURCHASED. THIS LIMITED WARRANTY IS VOID IF FAILURE OF THE SOFTWARE HAS RESULTED FROM ACCIDENT, ABUSE, OR MISAPPLICATION. ANY REPLACEMENT SOFTWARE WILL BE WARRANTED FOR THE REMAINDER OF THE ORIGINAL THIRTY (30) DAY PERIOD. OUTSIDE THE UNITED STATES, NEITHER THESE REMEDIES NOR ANY PRODUCT SUPPORT SERVICES OFFERED BY IOCOMP ARE AVAILABLE WITHOUT PROOF OF PURCHASE FROM AN AUTHORIZED INTERNATIONAL SOURCE.\r\n\r\nNO OTHER WARRANTIES. TO THE MAXIMUM EXTENT PERMITTED BY APPLICABLE LAW, IOCOMP AND ITS SUPPLIERS DISCLAIM ALL OTHER WARRANTIES, EITHER EXPRESS OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE, WITH REGARD TO THE SOFTWARE. THIS LIMITED WARRANTY GIVES YOU SPECIFIC LEGAL RIGHTS. YOU MAY HAVE OTHERS, WHICH VARY FROM STATE/JURISDICTION TO STATE/JURISDICTION.\r\nNO LIABILITIES FOR CONSEQUENTIAL DAMAGES. TO THE MAXIMUM EXTENT PERMITTED BY APPLICABLE LAW, IN NO EVENT SHALL IOCOMP OR ITS SUPPLIERS BE LIABLE FOR ANY SPECIAL, INCIDENTAL, INDIRECT, OR CONSEQUENTIAL DAMAGES WHATSOEVER (INCLUDING, WITHOUT LIMITATION, DAMAGES FOR LOSS OF BUSINESS PROFITS, BUSINESS INTERRUPTION, LOSS OF BUSINESS INFORMATION, OR ANY OTHER PECUNIARY LOSS) ARISING OUT OF THE USE OF OR INABILITY TO USE THE SOFTWARE, EVEN IF IOCOMP HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. BECAUSE SOME STATES AND JURISDICTIONS DO NOT ALLOW THE EXCLUSION OR LIMITATION OF LIABILITY FOR CONSEQUENTIAL OR INCIDENTAL DAMAGES, THE ABOVE LIMITATION MAY NOT APPLY TO YOU.\r\n\r\nLICENSEE ACKNOWLEDGES THAT IT HAS READ AND UNDERSTANDS THIS AGREEMENT AND AGREES TO BE BOUND BY ITS TERMS. LICENSEE FURTHER AGREES THAT THIS AGREEMENT IS THE COMPLETE AND EXCLUSIVE STATEMENT OF THE AGREEMENT BETWEEN LICENSEE AND LICENSOR, AND SUPERCEDES ANY PROPOSAL OR PRIOR AGREEMENT, ORAL OR WRITTEN, AND ANY OTHER COMMUNICATIONS RELATING TO THE SUBJECT MATER OF THIS AGREEMENT.";
			LicenseAgreementLabel.LoadingBegin();
			LicenseAgreementLabel.FocusControl = LicenseAgreementTextBox;
			LicenseAgreementLabel.FocusControlAlignment = AlignmentQuadSide.Top;
			LicenseAgreementLabel.Location = new Point(8, 73);
			LicenseAgreementLabel.Name = "LicenseAgreementLabel";
			LicenseAgreementLabel.Size = new Size(102, 15);
			LicenseAgreementLabel.Text = "License Agreement";
			LicenseAgreementLabel.LoadingEnd();
			VersionLabel.LoadingBegin();
			VersionLabel.AutoSize = false;
			VersionLabel.FocusControlAlignment = AlignmentQuadSide.Top;
			VersionLabel.Location = new Point(218, 5);
			VersionLabel.Name = "VersionLabel";
			VersionLabel.Size = new Size(50, 18);
			VersionLabel.Text = "Version 3";
			VersionLabel.LoadingEnd();
			CopyrightLabel.LoadingBegin();
			CopyrightLabel.AutoSize = false;
			CopyrightLabel.Location = new Point(216, 38);
			CopyrightLabel.Name = "CopyrightLabel";
			CopyrightLabel.Size = new Size(212, 14);
			CopyrightLabel.Text = "Copyright 1998-2006 Iocomp Software Inc.";
			CopyrightLabel.LoadingEnd();
			ServicePackLabel.LoadingBegin();
			ServicePackLabel.FocusControlAlignment = AlignmentQuadSide.Top;
			ServicePackLabel.Location = new Point(222, 22);
			ServicePackLabel.Name = "ServicePackLabel";
			ServicePackLabel.Size = new Size(81, 15);
			ServicePackLabel.Text = "Service Pack 2";
			ServicePackLabel.LoadingEnd();
			LogoPictureBox.BorderStyle = BorderStyle.FixedSingle;
			LogoPictureBox.Image = (Image)resourceManager.GetObject("LogoPictureBox.Image");
			LogoPictureBox.Location = new Point(9, 9);
			LogoPictureBox.Name = "LogoPictureBox";
			LogoPictureBox.Size = new Size(167, 55);
			LogoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			LogoPictureBox.TabIndex = 5;
			LogoPictureBox.TabStop = false;
			imageList1.ImageSize = new Size(169, 58);
			imageList1.ImageStream = (ImageListStreamer)resourceManager.GetObject("imageList1.ImageStream");
			imageList1.TransparentColor = Color.White;
			WebsiteLabel.AutoSize = true;
			WebsiteLabel.Location = new Point(216, 53);
			WebsiteLabel.Name = "WebsiteLabel";
			WebsiteLabel.Size = new Size(184, 16);
			WebsiteLabel.TabIndex = 0;
			WebsiteLabel.TabStop = true;
			WebsiteLabel.Text = "http://www.instrumentationopc.com/";
			WebsiteLabel.LinkClicked += WebsiteLabel_LinkClicked;
			base.Controls.Add(WebsiteLabel);
			base.Controls.Add(ServicePackLabel);
			base.Controls.Add(CopyrightLabel);
			base.Controls.Add(VersionLabel);
			base.Controls.Add(LicenseAgreementLabel);
			base.Controls.Add(LicenseAgreementTextBox);
			base.Controls.Add(LogoPictureBox);
			base.Name = "AboutPlugInSWTB";
			base.Size = new Size(440, 216);
			base.Resize += AboutPlugIn_Resize;
			base.ResumeLayout(false);
		}

		private void AboutPlugIn_Resize(object sender, EventArgs e)
		{
			int num = (int)((double)VersionLabel.Height * 0.1);
			LogoPictureBox.Location = new Point(0, 5);
			VersionLabel.Location = new Point(LogoPictureBox.Right + 10, 2);
			ServicePackLabel.Location = new Point(LogoPictureBox.Right + 10, VersionLabel.Bottom + num);
			CopyrightLabel.Location = new Point(LogoPictureBox.Right + 10, ServicePackLabel.Bottom + num);
			WebsiteLabel.Location = new Point(LogoPictureBox.Right + 10, CopyrightLabel.Bottom + num);
			LicenseAgreementTextBox.Location = new Point(0, LogoPictureBox.Bottom + LicenseAgreementLabel.Height + 2 * num);
			LicenseAgreementTextBox.Width = base.Width;
			LicenseAgreementTextBox.Height = base.Height - LicenseAgreementTextBox.Top;
		}

		private void WebsiteLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			WebsiteLabel.Links[WebsiteLabel.Links.IndexOf(e.Link)].Visited = true;
			Process.Start("http://www.instrumentationopc.com/");
		}
	}
}
