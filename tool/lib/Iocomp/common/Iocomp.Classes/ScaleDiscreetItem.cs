using Iocomp.Design;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(CollectionItemConverter))]
	public sealed class ScaleDiscreetItem : SubClassBase
	{
		private string m_Text;

		private Rectangle m_TextRectangle;

		private Point m_MarkerPoint;

		private Point m_LinePoint1;

		private Point m_LinePoint2;

		private Point m_LinePoint3;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string Text
		{
			get
			{
				return m_Text;
			}
			set
			{
				base.PropertyUpdateDefault("Text", value);
				if (Text != value)
				{
					m_Text = value;
					base.DoPropertyChange(this, "Text");
				}
			}
		}

		[Browsable(false)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rectangle TextRectangle
		{
			get
			{
				return m_TextRectangle;
			}
			set
			{
				m_TextRectangle = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Point MarkerPoint
		{
			get
			{
				return m_MarkerPoint;
			}
			set
			{
				m_MarkerPoint = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Point LinePoint1
		{
			get
			{
				return m_LinePoint1;
			}
			set
			{
				m_LinePoint1 = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Point LinePoint2
		{
			get
			{
				return m_LinePoint2;
			}
			set
			{
				m_LinePoint2 = value;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Point LinePoint3
		{
			get
			{
				return m_LinePoint3;
			}
			set
			{
				m_LinePoint3 = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Scale Item";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleDiscreetItemEditorPlugIn";
		}

		public ScaleDiscreetItem()
		{
			base.DoCreate();
		}

		public ScaleDiscreetItem(string text)
		{
			base.DoCreate();
			Text = text;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Text = "Untitled";
		}

		public override string ToString()
		{
			return Text;
		}

		private bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetText()
		{
			base.PropertyReset("Text");
		}
	}
}
