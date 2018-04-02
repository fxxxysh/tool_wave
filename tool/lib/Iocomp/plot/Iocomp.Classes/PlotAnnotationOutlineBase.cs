using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public abstract class PlotAnnotationOutlineBase : PlotAnnotationBase
	{
		private PlotPen m_Pen;

		protected IPlotPen I_Pen;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotPen Pen
		{
			get
			{
				return m_Pen;
			}
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Pen = new PlotPen();
			base.AddSubClass(Pen);
			I_Pen = Pen;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Pen.Color = Color.Empty;
			Pen.Thickness = 1.0;
			Pen.Style = PlotPenStyle.Solid;
			Pen.Visible = true;
		}

		private bool ShouldSerializePen()
		{
			return ((ISubClassBase)Pen).ShouldSerialize();
		}

		private void ResetPen()
		{
			((ISubClassBase)Pen).ResetToDefault();
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (!Pen.Visible)
			{
				base.CanDraw = false;
			}
		}
	}
}
