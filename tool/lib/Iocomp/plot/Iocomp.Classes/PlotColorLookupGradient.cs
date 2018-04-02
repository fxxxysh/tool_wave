using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Serializable]
	[Description("Plot Color Lookup Gradient.")]
	public class PlotColorLookupGradient : SubClassBase
	{
		private double m_Min;

		private double m_Max;

		private int m_StepsCount;

		private bool m_StepsEnabled;

		private GradientColorCollection m_GradientColors;

		private ColorBlend m_ColorBlend;

		private Color m_ColorStart;

		private Color m_ColorStop;

		private Bitmap m_Bitmap;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public GradientColorCollection GradientColors
		{
			get
			{
				return m_GradientColors;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double Min
		{
			get
			{
				return m_Min;
			}
			set
			{
				base.PropertyUpdateDefault("Min", value);
				if (Min != value)
				{
					m_Min = value;
					Regenerate();
					base.DoPropertyChange(this, "Min");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double Max
		{
			get
			{
				return m_Max;
			}
			set
			{
				base.PropertyUpdateDefault("Max", value);
				if (Max != value)
				{
					m_Max = value;
					Regenerate();
					base.DoPropertyChange(this, "Max");
				}
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double Span
		{
			get
			{
				return Max - Min;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		public Bitmap Bitmap
		{
			get
			{
				return m_Bitmap;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int StepsCount
		{
			get
			{
				return m_StepsCount;
			}
			set
			{
				if (value < 2)
				{
					value = 2;
				}
				base.PropertyUpdateDefault("StepsCount", value);
				if (StepsCount != value)
				{
					m_StepsCount = value;
					Regenerate();
					base.DoPropertyChange(this, "StepsCount");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool StepsEnabled
		{
			get
			{
				return m_StepsEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("StepsEnabled", value);
				if (StepsEnabled != value)
				{
					m_StepsEnabled = value;
					Regenerate();
					base.DoPropertyChange(this, "StepsEnabled");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color ColorStart
		{
			get
			{
				return m_ColorStart;
			}
			set
			{
				base.PropertyUpdateDefault("ColorStart", value);
				if (ColorStart != value)
				{
					m_ColorStart = value;
					Regenerate();
					base.DoPropertyChange(this, "ColorStart");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color ColorStop
		{
			get
			{
				return m_ColorStop;
			}
			set
			{
				base.PropertyUpdateDefault("ColorStop", value);
				if (ColorStop != value)
				{
					m_ColorStop = value;
					Regenerate();
					base.DoPropertyChange(this, "ColorStop");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color[] Colors
		{
			get
			{
				if (!StepsEnabled)
				{
					if (GradientColors.IsValid)
					{
						return GradientColors.Colors;
					}
					return new Color[2]
					{
						ColorStart,
						ColorStop
					};
				}
				Color[] array = new Color[StepsCount + 1];
				for (int i = 0; i < StepsCount + 1; i++)
				{
					if (i == StepsCount)
					{
						array[i] = Color.Empty;
					}
					else
					{
						array[i] = GetColor(i);
					}
				}
				return array;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public float[] Positions
		{
			get
			{
				if (!StepsEnabled)
				{
					if (GradientColors.IsValid)
					{
						return GradientColors.Positions;
					}
					return new float[2]
					{
						0f,
						1f
					};
				}
				float[] array = new float[StepsCount + 1];
				for (int i = 0; i < StepsCount + 1; i++)
				{
					array[i] = (float)((double)i * 1.0 / (double)StepsCount);
				}
				return array;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Color Lookup Gradient";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotColorLookupGradientEditorPlugIn";
		}

		public PlotColorLookupGradient()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_ColorBlend = new ColorBlend();
			m_GradientColors = new GradientColorCollection(ComponentBase);
			m_GradientColors.ObjectAdded += m_Colors_ObjectAdded;
			m_GradientColors.ObjectRemoved += m_Colors_ObjectRemoved;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Min = 0.0;
			Max = 100.0;
			StepsEnabled = false;
			StepsCount = 10;
			ColorStart = Color.Orange;
			ColorStop = Color.Yellow;
		}

		private bool ShouldSerializeColors()
		{
			return GradientColors.Count != 0;
		}

		private void ResetColors()
		{
			GradientColors.Clear();
		}

		private bool ShouldSerializeMin()
		{
			return base.PropertyShouldSerialize("Min");
		}

		private void ResetMin()
		{
			base.PropertyReset("Min");
		}

		private bool ShouldSerializeMax()
		{
			return base.PropertyShouldSerialize("Max");
		}

		private void ResetMax()
		{
			base.PropertyReset("Max");
		}

		private bool ShouldSerializeStepsCount()
		{
			return base.PropertyShouldSerialize("StepsCount");
		}

		private void ResetStepsCount()
		{
			base.PropertyReset("StepsCount");
		}

		private bool ShouldSerializeStepsEnabled()
		{
			return base.PropertyShouldSerialize("StepsEnabled");
		}

		private void ResetStepsEnabled()
		{
			base.PropertyReset("StepsEnabled");
		}

		private bool ShouldSerializeColorStart()
		{
			return base.PropertyShouldSerialize("ColorStart");
		}

		private void ResetColorStart()
		{
			base.PropertyReset("ColorStart");
		}

		private bool ShouldSerializeColorStop()
		{
			return base.PropertyShouldSerialize("ColorStop");
		}

		private void ResetColorStop()
		{
			base.PropertyReset("ColorStop");
		}

		public void Regenerate()
		{
			if (m_Bitmap != null)
			{
				m_Bitmap.Dispose();
				m_Bitmap = null;
			}
			if (!StepsEnabled)
			{
				m_Bitmap = new Bitmap(1, 256);
			}
			else
			{
				m_Bitmap = new Bitmap(1, StepsCount);
			}
			Rectangle rect = new Rectangle(0, 0, m_Bitmap.Width, m_Bitmap.Height);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, ColorStart, ColorStop, LinearGradientMode.Vertical);
			if (GradientColors.IsValid)
			{
				m_ColorBlend.Colors = GradientColors.Colors;
				m_ColorBlend.Positions = GradientColors.Positions;
				linearGradientBrush.InterpolationColors = m_ColorBlend;
			}
			Graphics graphics = Graphics.FromImage(m_Bitmap);
			graphics.FillRectangle(linearGradientBrush, rect);
			linearGradientBrush.Dispose();
			graphics.Dispose();
		}

		public Color GetColor(double value)
		{
			if (m_Bitmap == null)
			{
				return Color.Empty;
			}
			int num = (int)((value - Min) / (Max - Min) * (double)m_Bitmap.Height);
			if (num < 0)
			{
				num = 0;
			}
			if (num > m_Bitmap.Height - 1)
			{
				num = m_Bitmap.Height - 1;
			}
			return m_Bitmap.GetPixel(0, num);
		}

		public Color GetColor(int index)
		{
			if (index > m_Bitmap.Height - 1)
			{
				throw new Exception("Index out of bounds");
			}
			return m_Bitmap.GetPixel(0, index);
		}

		private void m_Colors_ObjectAdded(object sender, ObjectEventArgs e)
		{
			(e.Object as ISubClassBase).PropertyChanged += PlotColorLookupGradient_PropertyChanged;
		}

		private void m_Colors_ObjectRemoved(object sender, ObjectEventArgs e)
		{
			(e.Object as ISubClassBase).PropertyChanged -= PlotColorLookupGradient_PropertyChanged;
		}

		private void PlotColorLookupGradient_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			Regenerate();
		}
	}
}
