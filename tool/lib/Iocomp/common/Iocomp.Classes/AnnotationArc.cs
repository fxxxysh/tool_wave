using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public sealed class AnnotationArc : AnnotationOutline
	{
		private double m_StartAngle;

		private double m_SweepAngle;

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public double StartAngle
		{
			get
			{
				return m_StartAngle;
			}
			set
			{
				base.PropertyUpdateDefault("StartAngle", value);
				if (StartAngle != value)
				{
					m_StartAngle = value;
					base.DoPropertyChange(this, "StartAngle");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public double SweepAngle
		{
			get
			{
				return m_SweepAngle;
			}
			set
			{
				base.PropertyUpdateDefault("SweepAngle", value);
				if (SweepAngle != value)
				{
					m_SweepAngle = value;
					base.DoPropertyChange(this, "SweepAngle");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Annotation Arc";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AnnotationArcEditorPlugIn";
		}

		public AnnotationArc()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			StartAngle = 0.0;
			SweepAngle = 90.0;
		}

		private bool ShouldSerializeStartAngle()
		{
			return base.PropertyShouldSerialize("StartAngle");
		}

		private void ResetStartAngle()
		{
			base.PropertyReset("StartAngle");
		}

		private bool ShouldSerializeSweepAngle()
		{
			return base.PropertyShouldSerialize("SweepAngle");
		}

		private void ResetSweepAngle()
		{
			base.PropertyReset("SweepAngle");
		}

		protected override void DrawOutline(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.DrawArc(p.Graphics.Pen(base.OutlineColor, base.DashStyle), rect, (float)StartAngle, (float)SweepAngle);
		}

		public override string ToString()
		{
			return "Annotation Arc";
		}
	}
}
