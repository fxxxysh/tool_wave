using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Table Cell Format.")]
	public class PlotTableCellFormat : SubClassBase, IPlotTableCellFormat
	{
		private TextLayoutFull m_TextLayout;

		protected ITextLayoutFull I_TextLayout;

		private PlotBrush m_Background;

		protected IPlotBrush I_Background;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TextLayoutFull TextLayout
		{
			get
			{
				return m_TextLayout;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotBrush Background
		{
			get
			{
				return m_Background;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public new Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Table Cell Format";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotTableCellFormatEditorPlugIn";
		}

		void IPlotTableCellFormat.Draw(PaintArgs p, Rectangle r)
		{
			Draw(p, r);
		}

		public PlotTableCellFormat()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_TextLayout = new TextLayoutFull();
			base.AddSubClass(TextLayout);
			I_TextLayout = TextLayout;
			m_Background = new PlotBrush();
			base.AddSubClass(Background);
			I_Background = Background;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			ForeColor = Color.Empty;
			Font = null;
			TextLayout.Trimming = StringTrimming.None;
			TextLayout.LineLimit = false;
			TextLayout.MeasureTrailingSpaces = false;
			TextLayout.NoWrap = false;
			TextLayout.NoClip = false;
			TextLayout.AlignmentHorizontal.Style = StringAlignment.Center;
			TextLayout.AlignmentHorizontal.Margin = 0.0;
			TextLayout.AlignmentVertical.Style = StringAlignment.Center;
			TextLayout.AlignmentVertical.Margin = 0.0;
			Background.Visible = false;
			Background.Style = PlotBrushStyle.Solid;
			Background.SolidColor = Color.Empty;
			Background.GradientStartColor = Color.Blue;
			Background.GradientStopColor = Color.Aqua;
			Background.HatchForeColor = Color.Empty;
			Background.HatchBackColor = Color.Empty;
		}

		private bool ShouldSerializeTextLayout()
		{
			return ((ISubClassBase)TextLayout).ShouldSerialize();
		}

		private void ResetTextLayout()
		{
			((ISubClassBase)TextLayout).ResetToDefault();
		}

		private bool ShouldSerializeBackground()
		{
			return ((ISubClassBase)Background).ShouldSerialize();
		}

		private void ResetBackground()
		{
			((ISubClassBase)Background).ResetToDefault();
		}

		private bool ShouldSerializeFont()
		{
			return base.PropertyShouldSerialize("Font");
		}

		private void ResetFont()
		{
			base.PropertyReset("Font");
		}

		private bool ShouldSerializeForeColor()
		{
			return base.PropertyShouldSerialize("ForeColor");
		}

		private void ResetForeColor()
		{
			base.PropertyReset("ForeColor");
		}

		private void Draw(PaintArgs p, Rectangle r)
		{
			if (Background.Visible)
			{
				p.Graphics.FillRectangle(((IPlotBrush)Background).GetBrush(p, r), r);
			}
		}
	}
}
