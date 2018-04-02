using Iocomp.Design;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(CollectionItemConverter))]
	public class ColorSection : SubClassBase
	{
		private double m_Start;

		private double m_Stop;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Start
		{
			get
			{
				return m_Start;
			}
			set
			{
				base.PropertyUpdateDefault("Start", value);
				if (Start != value)
				{
					m_Start = value;
					base.DoPropertyChange(this, "Start");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Stop
		{
			get
			{
				return m_Stop;
			}
			set
			{
				base.PropertyUpdateDefault("Stop", value);
				if (Stop != value)
				{
					m_Stop = value;
					base.DoPropertyChange(this, "Stop");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public new Color Color
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.Color = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool Visible
		{
			get
			{
				return VisibleInternal;
			}
			set
			{
				VisibleInternal = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Color Section";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ColorSectionEditorPlugIn";
		}

		public ColorSection()
		{
			base.DoCreate();
		}

		public ColorSection(Color color, double start, double stop)
		{
			base.DoCreate();
			Color = color;
			Start = start;
			Stop = stop;
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			Start = 0.0;
			Stop = 50.0;
			Color = Color.Red;
			Visible = true;
		}

		private bool ShouldSerializeStart()
		{
			return base.PropertyShouldSerialize("Start");
		}

		private void ResetStart()
		{
			base.PropertyReset("Start");
		}

		private bool ShouldSerializeStop()
		{
			return base.PropertyShouldSerialize("Stop");
		}

		private void ResetStop()
		{
			base.PropertyReset("Stop");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		public override string ToString()
		{
			return "Section-" + Color.ToString();
		}
	}
}
