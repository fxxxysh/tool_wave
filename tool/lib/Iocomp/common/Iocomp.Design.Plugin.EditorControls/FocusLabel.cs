using Iocomp.Classes;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[DefaultEvent("")]
	[Description("PlugIn Editor Focus Label")]
	[ToolboxItem(false)]
	[Designer(typeof(FocusLabelDesigner))]
	[DesignerCategory("code")]
	public class FocusLabel : DesignControlBase
	{
		private TextLayoutFull m_TextLayout;

		private Control m_FocusControl;

		private int m_NewLocationX;

		private int m_NewLocationY;

		private string m_Text;

		private AlignmentQuadSide m_FocusControlAlignment;

		private bool m_RecursionBlock;

		protected override Size DefaultSize => new Size(100, 23);

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Iocomp")]
		[Description("")]
		public TextLayoutFull TextLayout
		{
			get
			{
				return m_TextLayout;
			}
		}

		[ParenthesizePropertyName(true)]
		[Category("Iocomp")]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
		[DefaultValue(null)]
		[TypeConverter(typeof(FocusControlConverter))]
		public Control FocusControl
		{
			get
			{
				return m_FocusControl;
			}
			set
			{
				if (m_FocusControl != value)
				{
					if (m_FocusControl != null)
					{
						m_FocusControl.LocationChanged -= m_FocusControl_LocationChanged;
						m_FocusControl.SizeChanged -= m_FocusControl_LocationChanged;
					}
					m_FocusControl = value;
					if (FocusControl != null)
					{
						m_FocusControl.LocationChanged += m_FocusControl_LocationChanged;
						m_FocusControl.SizeChanged += m_FocusControl_LocationChanged;
						Align();
					}
				}
				base.UIInvalidate(this);
			}
		}

		[Category("Iocomp")]
		[ParenthesizePropertyName(true)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the text for the label.")]
		public new string Text
		{
			get
			{
				return m_Text;
			}
			set
			{
				value = value.Replace(":", "");
				base.PropertyUpdateDefault("Text", value);
				if (m_Text != value)
				{
					m_Text = value;
					base.DoPropertyChange(this, "Text");
					OnTextChanged(EventArgs.Empty);
				}
			}
		}

		[Description("Specifies the side of the FocusControl that the label will align to.")]
		[RefreshProperties(RefreshProperties.All)]
		public AlignmentQuadSide FocusControlAlignment
		{
			get
			{
				return m_FocusControlAlignment;
			}
			set
			{
				base.PropertyUpdateDefault("FocusControlAlignment", value);
				if (m_FocusControlAlignment != value)
				{
					m_FocusControlAlignment = value;
					Align();
					base.DoPropertyChange(this, "FocusControlAlignment");
				}
			}
		}

		public FocusLabel()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			m_TextLayout = new TextLayoutFull();
			base.AddSubClass(TextLayout);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				FocusControl = null;
			}
			base.Dispose(disposing);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.Rotation = RotationQuad.X000;
			Text = "";
			base.AutoSize = true;
			FocusControlAlignment = AlignmentQuadSide.Left;
			base.TabStop = false;
			TextLayout.Trimming = StringTrimming.None;
			TextLayout.LineLimit = false;
			TextLayout.MeasureTrailingSpaces = false;
			TextLayout.NoWrap = false;
			TextLayout.NoClip = false;
			TextLayout.AlignmentHorizontal.Style = StringAlignment.Far;
			TextLayout.AlignmentHorizontal.Margin = 0.5;
			TextLayout.AlignmentVertical.Style = StringAlignment.Center;
			TextLayout.AlignmentVertical.Margin = 0.5;
		}

		public override void LoadingEnd()
		{
			base.LoadingEnd();
			Align();
		}

		protected override Size CalculateAutoSize(int innerWidth, int innerHeight)
		{
			Graphics graphics = base.CreateGraphics();
			Size requiredSize = ((ITextLayoutBase)TextLayout).GetRequiredSize(Text, base.Font, new GraphicsAPI(graphics));
			graphics.Dispose();
			return new Size(requiredSize.Width, requiredSize.Height);
		}

		protected override void PropertyChangedHook(object sender, string propertyName)
		{
			if (sender == this && propertyName == "Text")
			{
				base.DoAutoSize();
			}
			base.PropertyChangedHook(sender, propertyName);
		}

		protected override Point CalculateAutoSizeLocation(Size NewSize)
		{
			int x = (TextLayout.AlignmentHorizontal.Style != 0) ? ((TextLayout.AlignmentHorizontal.Style != StringAlignment.Center) ? (base.Location.X + base.Size.Width - NewSize.Width) : (base.Location.X + base.Size.Width / 2 - NewSize.Width / 2)) : base.Location.X;
			int y = (TextLayout.AlignmentVertical.Style != 0) ? ((TextLayout.AlignmentVertical.Style != StringAlignment.Center) ? (base.Location.Y + base.Size.Height - NewSize.Height) : (base.Location.Y + base.Size.Height / 2 - NewSize.Height / 2)) : base.Location.Y;
			return new Point(x, y);
		}

		private bool ShouldSerializeTextLayout()
		{
			return ((ISubClassBase)TextLayout).ShouldSerialize();
		}

		private void ResetTextLayout()
		{
			((ISubClassBase)TextLayout).ResetToDefault();
		}

		public bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		public new void ResetText()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeFocusControlAlignment()
		{
			return base.PropertyShouldSerialize("FocusControlAlignment");
		}

		private void ResetFocusControlAlignment()
		{
			base.PropertyReset("FocusControlAlignment");
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e)
		{
			if (FocusControl != null)
			{
				FocusControl.Focus();
			}
		}

		public void Align()
		{
			if (FocusControlAlignment == AlignmentQuadSide.Left)
			{
				AlignLeft();
			}
			else if (FocusControlAlignment == AlignmentQuadSide.Top)
			{
				AlignTop();
			}
			else if (FocusControlAlignment == AlignmentQuadSide.Right)
			{
				AlignRight();
			}
			else
			{
				AlignBottom();
			}
		}

		public void AlignLeft()
		{
			if (FocusControl != null)
			{
				m_FocusControlAlignment = AlignmentQuadSide.Left;
				int num = 0;
				if (FocusControl is TextBox)
				{
					num = -1;
				}
				if (FocusControl is ComboBox)
				{
					num = -1;
				}
				if (FocusControl is NumericUpDown)
				{
					num = -2;
				}
				m_NewLocationX = FocusControl.Location.X - base.Width;
				m_NewLocationY = FocusControl.Location.Y + FocusControl.Height / 2 - base.Height / 2 + num;
				base.Location = new Point(m_NewLocationX, m_NewLocationY);
			}
		}

		public void AlignRight()
		{
			if (FocusControl != null)
			{
				m_FocusControlAlignment = AlignmentQuadSide.Right;
				int num = 0;
				if (FocusControl is TextBox)
				{
					num = -1;
				}
				if (FocusControl is ComboBox)
				{
					num = -1;
				}
				if (FocusControl is NumericUpDown)
				{
					num = -2;
				}
				m_NewLocationX = FocusControl.Location.X + FocusControl.Width;
				m_NewLocationY = FocusControl.Location.Y + FocusControl.Height / 2 - base.Height / 2 + num;
				base.Location = new Point(m_NewLocationX, m_NewLocationY);
			}
		}

		public void AlignTop()
		{
			if (FocusControl != null)
			{
				m_FocusControlAlignment = AlignmentQuadSide.Top;
				m_NewLocationX = FocusControl.Location.X;
				m_NewLocationY = FocusControl.Top - base.Height;
				base.Location = new Point(m_NewLocationX, m_NewLocationY);
			}
		}

		public void AlignBottom()
		{
			if (FocusControl != null)
			{
				m_FocusControlAlignment = AlignmentQuadSide.Bottom;
				m_NewLocationX = FocusControl.Location.X;
				m_NewLocationY = FocusControl.Bottom;
				base.Location = new Point(m_NewLocationX, m_NewLocationY);
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			if (!m_RecursionBlock)
			{
				m_RecursionBlock = true;
				try
				{
					base.OnSizeChanged(e);
					Align();
				}
				finally
				{
					m_RecursionBlock = false;
				}
			}
		}

		protected override void OnLocationChanged(EventArgs e)
		{
			if (!m_RecursionBlock)
			{
				m_RecursionBlock = true;
				try
				{
					base.OnLocationChanged(e);
					Align();
				}
				finally
				{
					m_RecursionBlock = false;
				}
			}
		}

		private void m_FocusControl_LocationChanged(object sender, EventArgs e)
		{
			Align();
		}

		protected override void DoPaint(PaintArgs p)
		{
			((ITextLayoutBase)TextLayout).Draw(p.Graphics, base.Font, p.Graphics.Brush(base.ForeColor), Text, p.DrawRectangle);
		}
	}
}
