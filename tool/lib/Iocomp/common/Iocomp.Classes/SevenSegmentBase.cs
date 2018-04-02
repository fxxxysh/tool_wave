using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[DesignerCategory("code")]
	public abstract class SevenSegmentBase : ControlBase, ISevenSegmentBase
	{
		private Segment7 m_Segment;

		private int m_DigitSpacing;

		private Outline m_Outline;

		ISegment7 ISevenSegmentBase.Segment
		{
			get
			{
				return Segment;
			}
		}

		IOutline ISevenSegmentBase.Outline
		{
			get
			{
				return Outline;
			}
		}

		protected override int SpecialOffset => Outline.Thickness;

		[Description("Seven Segment properties")]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public Segment7 Segment
		{
			get
			{
				return m_Segment;
			}
		}

		[Description("Outline properties")]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public Outline Outline
		{
			get
			{
				return m_Outline;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public int DigitSpacing
		{
			get
			{
				return m_DigitSpacing;
			}
			set
			{
				base.PropertyUpdateDefault("DigitSpacing", value);
				if (DigitSpacing != value)
				{
					m_DigitSpacing = value;
					base.DoPropertyChange(this, "DigitSpacing");
				}
			}
		}

		protected override void CreateObjects()
		{
			m_Segment = new Segment7();
			base.AddSubClass(Segment);
			m_Outline = new Outline();
			base.AddSubClass(Outline);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			DigitSpacing = 6;
			base.Border.Margin = 0;
			base.Border.Style = BorderStyleControl.Raised;
			base.Border.ThicknessDesired = 3;
			Segment.ColorOffAuto = true;
			Segment.ColorOn = Color.Lime;
			Segment.ColorOff = iColors.ToOffColor(Color.Lime);
			Segment.Size = 1;
			Segment.Separation = 1;
			Segment.ShowOffSegments = true;
			Outline.Thickness = 3;
			Outline.Color = Color.Black;
		}

		private bool ShouldSerializeSegment()
		{
			return ((ISubClassBase)Segment).ShouldSerialize();
		}

		private void ResetSegment()
		{
			((ISubClassBase)Segment).ResetToDefault();
		}

		private bool ShouldSerializeOutline()
		{
			return ((ISubClassBase)Outline).ShouldSerialize();
		}

		private void ResetOutline()
		{
			((ISubClassBase)Outline).ResetToDefault();
		}

		private bool ShouldSerializeDigitSpacing()
		{
			return base.PropertyShouldSerialize("DigitSpacing");
		}

		private void ResetDigitSpacing()
		{
			base.PropertyReset("DigitSpacing");
		}
	}
}
