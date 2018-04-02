using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	public class DoubleEditForm : Form
	{
		private FocusLabel focusLabel1;

		private FocusLabel focusLabel2;

		private FocusLabel focusLabel3;

		private FocusLabel focusLabel4;

		private Container components;

		private System.Windows.Forms.NumericUpDown MilisecondsUpDown;

		private System.Windows.Forms.NumericUpDown SecondsUpDown;

		private System.Windows.Forms.NumericUpDown MinutesUpDown;

		private System.Windows.Forms.NumericUpDown HoursUpDown;

		private FocusLabel focusLabel5;

		private System.Windows.Forms.NumericUpDown DaysUpDown;

		private Button button2;

		private Button button3;

		private Button ZeroAllButton;

		private double m_Value;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				m_Value = value;
				if (m_Value > DateTime.MaxValue.ToOADate())
				{
					m_Value = DateTime.MaxValue.ToOADate();
				}
				if (m_Value < DateTime.MinValue.ToOADate())
				{
					m_Value = DateTime.MinValue.ToOADate();
				}
				MilisecondsUpDown.ValueChanged -= UpDown_ValueChanged;
				SecondsUpDown.ValueChanged -= UpDown_ValueChanged;
				MinutesUpDown.ValueChanged -= UpDown_ValueChanged;
				HoursUpDown.ValueChanged -= UpDown_ValueChanged;
				DaysUpDown.ValueChanged -= UpDown_ValueChanged;
				DateTime dateTime = DateTime.FromOADate(m_Value);
				MilisecondsUpDown.Value = dateTime.Millisecond;
				SecondsUpDown.Value = dateTime.Second;
				MinutesUpDown.Value = dateTime.Minute;
				HoursUpDown.Value = dateTime.Hour;
				DaysUpDown.Value = (int)m_Value;
				MilisecondsUpDown.ValueChanged += UpDown_ValueChanged;
				SecondsUpDown.ValueChanged += UpDown_ValueChanged;
				MinutesUpDown.ValueChanged += UpDown_ValueChanged;
				HoursUpDown.ValueChanged += UpDown_ValueChanged;
				DaysUpDown.ValueChanged += UpDown_ValueChanged;
			}
		}

		public DoubleEditForm()
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
			MilisecondsUpDown = new System.Windows.Forms.NumericUpDown();
			focusLabel1 = new FocusLabel();
			focusLabel2 = new FocusLabel();
			SecondsUpDown = new System.Windows.Forms.NumericUpDown();
			focusLabel3 = new FocusLabel();
			MinutesUpDown = new System.Windows.Forms.NumericUpDown();
			focusLabel4 = new FocusLabel();
			HoursUpDown = new System.Windows.Forms.NumericUpDown();
			ZeroAllButton = new Button();
			focusLabel5 = new FocusLabel();
			DaysUpDown = new System.Windows.Forms.NumericUpDown();
			button2 = new Button();
			button3 = new Button();
			base.SuspendLayout();
			MilisecondsUpDown.Location = new Point(72, 48);
			MilisecondsUpDown.Maximum = new decimal(new int[4]
			{
				999,
				0,
				0,
				0
			});
			MilisecondsUpDown.Name = "MilisecondsUpDown";
			MilisecondsUpDown.Size = new Size(64, 20);
			MilisecondsUpDown.TabIndex = 0;
			MilisecondsUpDown.Leave += UpDownLeave;
			focusLabel1.LoadingBegin();
			focusLabel1.FocusControl = MilisecondsUpDown;
			focusLabel1.Location = new Point(9, 51);
			focusLabel1.Name = "focusLabel1";
			focusLabel1.Size = new Size(63, 14);
			focusLabel1.Text = "Miliseconds";
			focusLabel1.LoadingEnd();
			focusLabel2.LoadingBegin();
			focusLabel2.FocusControl = SecondsUpDown;
			focusLabel2.Location = new Point(24, 75);
			focusLabel2.Name = "focusLabel2";
			focusLabel2.Size = new Size(48, 14);
			focusLabel2.Text = "Seconds";
			focusLabel2.LoadingEnd();
			SecondsUpDown.Location = new Point(72, 72);
			SecondsUpDown.Maximum = new decimal(new int[4]
			{
				59,
				0,
				0,
				0
			});
			SecondsUpDown.Name = "SecondsUpDown";
			SecondsUpDown.Size = new Size(64, 20);
			SecondsUpDown.TabIndex = 3;
			SecondsUpDown.Leave += UpDownLeave;
			focusLabel3.LoadingBegin();
			focusLabel3.FocusControl = MinutesUpDown;
			focusLabel3.Location = new Point(28, 99);
			focusLabel3.Name = "focusLabel3";
			focusLabel3.Size = new Size(44, 14);
			focusLabel3.Text = "Minutes";
			focusLabel3.LoadingEnd();
			MinutesUpDown.Location = new Point(72, 96);
			MinutesUpDown.Maximum = new decimal(new int[4]
			{
				59,
				0,
				0,
				0
			});
			MinutesUpDown.Name = "MinutesUpDown";
			MinutesUpDown.Size = new Size(64, 20);
			MinutesUpDown.TabIndex = 6;
			MinutesUpDown.Leave += UpDownLeave;
			focusLabel4.LoadingBegin();
			focusLabel4.FocusControl = HoursUpDown;
			focusLabel4.Location = new Point(37, 123);
			focusLabel4.Name = "focusLabel4";
			focusLabel4.Size = new Size(35, 14);
			focusLabel4.Text = "Hours";
			focusLabel4.LoadingEnd();
			HoursUpDown.Location = new Point(72, 120);
			HoursUpDown.Maximum = new decimal(new int[4]
			{
				23,
				0,
				0,
				0
			});
			HoursUpDown.Name = "HoursUpDown";
			HoursUpDown.Size = new Size(64, 20);
			HoursUpDown.TabIndex = 9;
			HoursUpDown.Leave += UpDownLeave;
			ZeroAllButton.Location = new Point(72, 16);
			ZeroAllButton.Name = "ZeroAllButton";
			ZeroAllButton.Size = new Size(64, 23);
			ZeroAllButton.TabIndex = 11;
			ZeroAllButton.Text = "Zero All";
			ZeroAllButton.Click += ZeroAllButton_Click;
			focusLabel5.LoadingBegin();
			focusLabel5.FocusControl = DaysUpDown;
			focusLabel5.Location = new Point(41, 147);
			focusLabel5.Name = "focusLabel5";
			focusLabel5.Size = new Size(31, 14);
			focusLabel5.Text = "Days";
			focusLabel5.LoadingEnd();
			DaysUpDown.Location = new Point(72, 144);
			DaysUpDown.Maximum = new decimal(new int[4]
			{
				-1304428544,
				434162106,
				542,
				0
			});
			DaysUpDown.Name = "DaysUpDown";
			DaysUpDown.Size = new Size(64, 20);
			DaysUpDown.TabIndex = 13;
			DaysUpDown.Leave += UpDownLeave;
			button2.DialogResult = DialogResult.OK;
			button2.Location = new Point(16, 184);
			button2.Name = "button2";
			button2.TabIndex = 18;
			button2.Text = "OK";
			button3.DialogResult = DialogResult.Cancel;
			button3.Location = new Point(104, 184);
			button3.Name = "button3";
			button3.TabIndex = 19;
			button3.Text = "Cancel";
			AutoScaleBaseSize = new Size(5, 13);
			base.ClientSize = new Size(194, 224);
			base.Controls.Add(button3);
			base.Controls.Add(button2);
			base.Controls.Add(focusLabel5);
			base.Controls.Add(DaysUpDown);
			base.Controls.Add(ZeroAllButton);
			base.Controls.Add(focusLabel4);
			base.Controls.Add(HoursUpDown);
			base.Controls.Add(focusLabel3);
			base.Controls.Add(MinutesUpDown);
			base.Controls.Add(focusLabel2);
			base.Controls.Add(SecondsUpDown);
			base.Controls.Add(focusLabel1);
			base.Controls.Add(MilisecondsUpDown);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Name = "DoubleEditForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			Text = "Time Span";
			base.ResumeLayout(false);
		}

		private void UpDown_ValueChanged(object sender, EventArgs e)
		{
			double num = new DateTime(2000, 1, 1, (int)HoursUpDown.Value, (int)MinutesUpDown.Value, (int)SecondsUpDown.Value, (int)MilisecondsUpDown.Value).ToOADate();
			num -= (double)(int)num;
			m_Value = num + (double)(int)DaysUpDown.Value;
		}

		private void ZeroAllButton_Click(object sender, EventArgs e)
		{
			MilisecondsUpDown.ValueChanged -= UpDown_ValueChanged;
			SecondsUpDown.ValueChanged -= UpDown_ValueChanged;
			MinutesUpDown.ValueChanged -= UpDown_ValueChanged;
			HoursUpDown.ValueChanged -= UpDown_ValueChanged;
			DaysUpDown.ValueChanged -= UpDown_ValueChanged;
			MilisecondsUpDown.Value = 0m;
			SecondsUpDown.Value = 0m;
			MinutesUpDown.Value = 0m;
			HoursUpDown.Value = 0m;
			DaysUpDown.Value = 0m;
			m_Value = 0.0;
			MilisecondsUpDown.ValueChanged += UpDown_ValueChanged;
			SecondsUpDown.ValueChanged += UpDown_ValueChanged;
			MinutesUpDown.ValueChanged += UpDown_ValueChanged;
			HoursUpDown.ValueChanged += UpDown_ValueChanged;
			DaysUpDown.ValueChanged += UpDown_ValueChanged;
		}

		private void UpDownLeave(object sender, EventArgs e)
		{
			UpDown_ValueChanged(null, null);
		}
	}
}
