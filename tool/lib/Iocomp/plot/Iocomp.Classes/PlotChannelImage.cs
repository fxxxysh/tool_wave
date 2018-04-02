using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace Iocomp.Classes
{
	[Description("Plot Channel Image")]
	public class PlotChannelImage : PlotChannelXYBase
	{
		private Bitmap m_Image;

		private bool m_ImageXAutoSetup;

		private bool m_ImageXAutoSetupComplete;

		private int m_ImageXSpanSamples;

		private double m_ImageXSpan;

		private double m_ImageXMin;

		private bool m_ImageYAutoSetup;

		private bool m_ImageYAutoSetupComplete;

		private int m_ImageYSpanSamples;

		private double m_ImageYSpan;

		private double m_ImageYMin;

		private PlotColorLookupGradient m_IntensityGradient;

		private bool m_FirstDrawComplete;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotColorLookupGradient IntensityGradient
		{
			get
			{
				return m_IntensityGradient;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ImageXAutoSetup
		{
			get
			{
				return m_ImageXAutoSetup;
			}
			set
			{
				base.PropertyUpdateDefault("ImageXAutoSetup", value);
				if (ImageXAutoSetup != value)
				{
					m_ImageXAutoSetup = value;
					base.DoPropertyChange(this, "ImageXAutoSetup");
					if (!ImageXAutoSetup)
					{
						m_ImageXAutoSetupComplete = false;
					}
					if (!base.Designing && ImageXAutoSetup && !m_ImageXAutoSetupComplete && m_FirstDrawComplete && base.XAxis != null)
					{
						ImageXSamples = base.XAxis.ScaleDisplay.PixelsSpan;
						ImageXSpanSamples = base.XAxis.ScaleDisplay.PixelsSpan;
						ImageXMin = base.XAxis.Min;
						ImageXSpan = base.XAxis.Span;
						m_ImageXAutoSetupComplete = true;
					}
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int ImageXSamples
		{
			get
			{
				return m_Image.Width;
			}
			set
			{
				if (value < 1)
				{
					value = 1;
				}
				base.PropertyUpdateDefault("ImageXSamples", value);
				if (ImageXSamples != value)
				{
					Bitmap image = m_Image;
					m_Image = new Bitmap(value, ImageYSamples);
					if (image != null)
					{
						Graphics graphics = Graphics.FromImage(m_Image);
						Rectangle rectangle = (m_Image.Width <= image.Width) ? new Rectangle(0, 0, m_Image.Width, m_Image.Height) : new Rectangle(0, 0, image.Width, image.Height);
						graphics.DrawImage(image, rectangle, rectangle, GraphicsUnit.Pixel);
						graphics.Dispose();
						image.Dispose();
					}
					base.DoPropertyChange(this, "ImageXSamples");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int ImageXSpanSamples
		{
			get
			{
				return m_ImageXSpanSamples;
			}
			set
			{
				base.PropertyUpdateDefault("ImageXSpanSamples", value);
				if (ImageXSpanSamples != value)
				{
					m_ImageXSpanSamples = value;
					base.DoPropertyChange(this, "ImageXSpanSamples");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double ImageXSpan
		{
			get
			{
				return m_ImageXSpan;
			}
			set
			{
				base.PropertyUpdateDefault("ImageXSpan", value);
				if (ImageXSpan != value)
				{
					m_ImageXSpan = value;
					base.DoPropertyChange(this, "ImageXSpan");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double ImageXMin
		{
			get
			{
				return m_ImageXMin;
			}
			set
			{
				base.PropertyUpdateDefault("ImageXMin", value);
				if (ImageXMin != value)
				{
					m_ImageXMin = value;
					base.DoPropertyChange(this, "ImageXMin");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ImageYAutoSetup
		{
			get
			{
				return m_ImageYAutoSetup;
			}
			set
			{
				base.PropertyUpdateDefault("ImageYAutoSetup", value);
				if (ImageYAutoSetup != value)
				{
					m_ImageYAutoSetup = value;
					base.DoPropertyChange(this, "ImageYAutoSetup");
					if (!ImageYAutoSetup)
					{
						m_ImageYAutoSetupComplete = false;
					}
					if (!base.Designing && ImageYAutoSetup && !m_ImageYAutoSetupComplete && m_FirstDrawComplete && base.YAxis != null)
					{
						ImageYSamples = base.YAxis.ScaleDisplay.PixelsSpan;
						ImageYSpanSamples = base.YAxis.ScaleDisplay.PixelsSpan;
						ImageYMin = base.YAxis.Min;
						ImageYSpan = base.YAxis.Span;
						m_ImageYAutoSetupComplete = true;
					}
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int ImageYSamples
		{
			get
			{
				return m_Image.Height;
			}
			set
			{
				if (value < 1)
				{
					value = 1;
				}
				base.PropertyUpdateDefault("ImageYSamples", value);
				if (ImageYSamples != value)
				{
					Bitmap image = m_Image;
					m_Image = new Bitmap(ImageXSamples, value);
					if (image != null)
					{
						Graphics graphics = Graphics.FromImage(m_Image);
						if (m_Image.Height > image.Height)
						{
							Rectangle rectangle = new Rectangle(0, 0, image.Width, image.Height);
							graphics.DrawImage(image, rectangle, rectangle, GraphicsUnit.Pixel);
						}
						else
						{
							Rectangle rectangle = new Rectangle(0, image.Height - m_Image.Height, m_Image.Width, m_Image.Height);
							Rectangle destRect = new Rectangle(0, 0, m_Image.Width, m_Image.Height);
							graphics.DrawImage(image, destRect, rectangle, GraphicsUnit.Pixel);
						}
						graphics.Dispose();
						image.Dispose();
					}
					base.DoPropertyChange(this, "ImageYSamples");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int ImageYSpanSamples
		{
			get
			{
				return m_ImageYSpanSamples;
			}
			set
			{
				base.PropertyUpdateDefault("ImageYSpanSamples", value);
				if (ImageYSpanSamples != value)
				{
					m_ImageYSpanSamples = value;
					base.DoPropertyChange(this, "ImageYSpanSamples");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double ImageYSpan
		{
			get
			{
				return m_ImageYSpan;
			}
			set
			{
				base.PropertyUpdateDefault("ImageYSpan", value);
				if (ImageYSpan != value)
				{
					m_ImageYSpan = value;
					base.DoPropertyChange(this, "ImageYSpan");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double ImageYMin
		{
			get
			{
				return m_ImageYMin;
			}
			set
			{
				base.PropertyUpdateDefault("ImageYMin", value);
				if (ImageYMin != value)
				{
					m_ImageYMin = value;
					base.DoPropertyChange(this, "ImageYMin");
				}
			}
		}

		private int ImagePixelLeft => 0;

		private int ImagePixelRight => m_Image.Width - 1;

		private int ImagePixelTop => 0;

		private int ImagePixelBottom => m_Image.Height - 1;

		private int ImagePixelWidth => m_Image.Width;

		private int ImagePixelHeight => m_Image.Height;

		public double ImageXMax => ImageXMin + (double)(ImageXSamples - 1) / (double)ImageXSpanSamples * ImageXSpan;

		public double ImageYMax => ImageYMin + (double)(ImageYSamples - 1) / (double)ImageYSpanSamples * ImageYSpan;

		protected override string GetPlugInTitle()
		{
			return "Channel Image";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelImageEditorPlugIn";
		}

		public PlotChannelImage()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Image = new Bitmap(1, 1);
			m_IntensityGradient = new PlotColorLookupGradient();
			base.AddSubClass(IntensityGradient);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Image";
			ImageXSamples = 100;
			ImageYSamples = 256;
			ImageXAutoSetup = false;
			ImageXSpanSamples = 100;
			ImageXSpan = 100.0;
			ImageXMin = 0.0;
			ImageYAutoSetup = false;
			ImageYSpanSamples = 100;
			ImageYSpan = 100.0;
			ImageYMin = 0.0;
			base.SendXAxisTrackingData = true;
			base.SendYAxisTrackingData = true;
			IntensityGradient.Min = 0.0;
			IntensityGradient.Max = 256.0;
			IntensityGradient.StepsCount = 10;
		}

		private bool ShouldSerializeIntensityGradient()
		{
			return ((ISubClassBase)IntensityGradient).ShouldSerialize();
		}

		private void ResetIntensityGradient()
		{
			((ISubClassBase)IntensityGradient).ResetToDefault();
		}

		private bool ShouldSerializeImageXAutoSetup()
		{
			return base.PropertyShouldSerialize("ImageXAutoSetup");
		}

		private void ResetImageXAutoSetup()
		{
			base.PropertyReset("ImageXAutoSetup");
		}

		private bool ShouldSerializeImageXSamples()
		{
			return base.PropertyShouldSerialize("ImageXSamples");
		}

		private void ResetImageXSamples()
		{
			base.PropertyReset("ImageXSamples");
		}

		private bool ShouldSerializeImageXSpanSamples()
		{
			return base.PropertyShouldSerialize("ImageXSpanSamples");
		}

		private void ResetImageXSpanSamples()
		{
			base.PropertyReset("ImageXSpanSamples");
		}

		private bool ShouldSerializeImageXSpan()
		{
			return base.PropertyShouldSerialize("ImageXSpan");
		}

		private void ResetImageXSpan()
		{
			base.PropertyReset("ImageXSpan");
		}

		private bool ShouldSerializeImageXMin()
		{
			return base.PropertyShouldSerialize("ImageXMin");
		}

		private void ResetImageXMin()
		{
			base.PropertyReset("ImageXMin");
		}

		private bool ShouldSerializeImageYAutoSetup()
		{
			return base.PropertyShouldSerialize("ImageYAutoSetup");
		}

		private void ResetImageYAutoSetup()
		{
			base.PropertyReset("ImageYAutoSetup");
		}

		private bool ShouldSerializeImageYSamples()
		{
			return base.PropertyShouldSerialize("ImageYSamples");
		}

		private void ResetImageYSamples()
		{
			base.PropertyReset("ImageYSamples");
		}

		private bool ShouldSerializeImageYSpanSamples()
		{
			return base.PropertyShouldSerialize("ImageYSpanSamples");
		}

		private void ResetImageYSpanSamples()
		{
			base.PropertyReset("ImageYSpanSamples");
		}

		private bool ShouldSerializeImageYSpan()
		{
			return base.PropertyShouldSerialize("ImageYSpan");
		}

		private void ResetImageYSpan()
		{
			base.PropertyReset("ImageYSpan");
		}

		private bool ShouldSerializeImageYMin()
		{
			return base.PropertyShouldSerialize("ImageYMin");
		}

		private void ResetImageYMin()
		{
			base.PropertyReset("ImageYMin");
		}

		public Color GetPointColor(int x, int y)
		{
			if (x > ImageXSamples - 1)
			{
				throw new Exception("X index out of bounds.");
			}
			if (y > ImageYSamples - 1)
			{
				throw new Exception("Y index out of bounds.");
			}
			return m_Image.GetPixel(x, y);
		}

		public void SetPointColor(int x, int y, Color value)
		{
			if (x > ImageXSamples - 1)
			{
				throw new Exception("X index out of bounds.");
			}
			if (y > ImageYSamples - 1)
			{
				throw new Exception("Y index out of bounds.");
			}
			m_Image.SetPixel(x, y, value);
		}

		public int ValueToImageSampleX(double value)
		{
			if (ImageXSpan == 0.0)
			{
				return 0;
			}
			return (int)Math.Round((value - ImageXMin) / ImageXSpan * (double)ImageXSpanSamples);
		}

		public int ValueToImageSampleY(double value)
		{
			if (ImageYSpan == 0.0)
			{
				return 0;
			}
			return (int)Math.Round((value - ImageYMin) / ImageYSpan * (double)ImageYSpanSamples);
		}

		public double ImageSampleToValueX(int value)
		{
			return (double)value / (double)ImageXSpanSamples * ImageXSpan + ImageXMin;
		}

		public double ImageSampleToValueY(int value)
		{
			return (double)value / (double)ImageYSpanSamples * ImageYSpan + ImageYMin;
		}

		protected override PlotDataPointBase CreateDataPoint()
		{
			return null;
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue, double intensity)
		{
			int num = ValueToImageSampleX(x);
			int num2 = ValueToImageSampleY(y);
			if (num > ImageXSamples - 1)
			{
				throw new Exception("X out of bounds.");
			}
			if (num2 > ImageYSamples - 1)
			{
				throw new Exception("Y out of bounds.");
			}
			Color color = (!nullValue) ? IntensityGradient.GetColor(intensity) : Color.Empty;
			m_Image.SetPixel(num, num2, color);
			base.m_Data.UpdateMinMaxMean(x, y, emptyValue, nullValue);
			if (base.SendXAxisTrackingData)
			{
				PlotXAxis xAxis = base.XAxis;
				xAxis?.Tracking.NewData(x);
			}
			if (!nullValue && !emptyValue && base.SendYAxisTrackingData)
			{
				PlotYAxis yAxis = base.YAxis;
				yAxis?.Tracking.NewData(y);
			}
			DoDataChange();
			return -1;
		}

		public int Add(double x, double y, double intensity)
		{
			return AddXY(x, y, false, false, intensity);
		}

		public int Add(int x, int y, double intensity)
		{
			return AddXY(ImageSampleToValueX(x), ImageSampleToValueY(y), false, false, intensity);
		}

		public void AddIntensityArray(double y, double startX, double span, Array intensityArray)
		{
			if (intensityArray.Rank != 1)
			{
				throw new Exception("Array must be one-dimensional.");
			}
			Type elementType = intensityArray.GetType().GetElementType();
			int lowerBound = intensityArray.GetLowerBound(0);
			int upperBound = intensityArray.GetUpperBound(0);
			int num = upperBound - lowerBound + 1;
			if (num < 1)
			{
				throw new Exception("Intensity Array must have one or more elements.");
			}
			if (num == 1)
			{
				if (elementType == typeof(double))
				{
					AddXY(startX, y, false, false, (double)intensityArray.GetValue(lowerBound));
					return;
				}
				if (elementType == typeof(float))
				{
					AddXY(startX, y, false, false, (double)(float)intensityArray.GetValue(lowerBound));
					return;
				}
				if (elementType == typeof(int))
				{
					AddXY(startX, y, false, false, (double)(int)intensityArray.GetValue(lowerBound));
					return;
				}
				throw new Exception("Array data type must be of type double, float, or int.");
			}
			if (elementType == typeof(double))
			{
				for (int i = lowerBound; i <= upperBound; i++)
				{
					AddXY(startX + (double)(i - lowerBound) * span / (double)(num - 1), y, false, false, (double)intensityArray.GetValue(i));
				}
				return;
			}
			if (elementType == typeof(float))
			{
				for (int j = lowerBound; j <= upperBound; j++)
				{
					AddXY(startX + (double)(j - lowerBound) * span / (double)(num - 1), y, false, false, (double)(float)intensityArray.GetValue(j));
				}
				return;
			}
			if (elementType == typeof(int))
			{
				for (int k = lowerBound; k <= upperBound; k++)
				{
					AddXY(startX + (double)(k - lowerBound) * span / (double)(num - 1), y, false, false, (double)(int)intensityArray.GetValue(k));
				}
				return;
			}
			throw new Exception("Array data type must be of type double, float, or int.");
		}

		public override int AddXY(double x, double y)
		{
			return AddXY(x, y, false, false, 0.0);
		}

		public override int AddEmpty(double x)
		{
			return -1;
		}

		public override int AddNull(double x)
		{
			return -1;
		}

		public override double GetX(int index)
		{
			return -1.0;
		}

		public override double GetY(int index)
		{
			return -1.0;
		}

		public double GetIntensity(int index)
		{
			return -1.0;
		}

		public override bool GetNull(int index)
		{
			return false;
		}

		public override bool GetEmpty(int index)
		{
			return false;
		}

		public override void SetX(int index, double value)
		{
		}

		public override void SetY(int index, double value)
		{
		}

		public void SetIntensity(int index, double value)
		{
		}

		public override void SetNull(int index, bool value)
		{
		}

		public override void SetEmpty(int index, bool value)
		{
		}

		public override void Clear()
		{
			Bitmap image = m_Image;
			m_Image = new Bitmap(ImageXSamples, ImageYSamples);
			image?.Dispose();
			base.m_Data.ClearMinMeanMax();
			DoDataChange();
		}

		protected override void LoadDesignTimeData(PlotXAxis xAxis, PlotYAxis yAxis, Random random, double yMin, double ySpan)
		{
			for (int i = 0; i < ImageXSamples; i++)
			{
				for (int j = 0; j < ImageYSamples; j++)
				{
					Add(i, j, random.NextDouble() * (IntensityGradient.Max - IntensityGradient.Min) + IntensityGradient.Min);
				}
			}
		}

		public override void SaveDataToStream(Stream value, out StreamWriter streamWriter)
		{
			streamWriter = new StreamWriter(value);
			streamWriter.WriteLine("No Data Saved : Not supported on Image channel Type");
		}

		public override void LoadDataFromStream(Stream stream)
		{
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (m_Image == null)
			{
				base.CanDraw = false;
			}
		}

		public void DeleteDataByLines(int numberOfLines)
		{
			if (numberOfLines >= 1)
			{
				if (numberOfLines > ImageYSamples)
				{
					throw new Exception("Number of lines deleted must less than or equal to the ImageYSamples value.");
				}
				int height = ImageYSamples - numberOfLines;
				Bitmap image = m_Image;
				m_Image = new Bitmap(ImageXSamples, ImageYSamples);
				if (image != null)
				{
					Graphics graphics = Graphics.FromImage(m_Image);
					Rectangle srcRect = new Rectangle(0, numberOfLines, image.Width, height);
					Rectangle destRect = new Rectangle(0, 0, image.Width, height);
					graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
					graphics.Dispose();
					image.Dispose();
				}
				m_ImageYMin += (double)numberOfLines / (double)ImageYSpanSamples * ImageYSpan;
			}
		}

		public void SlideImage(double yOffset)
		{
			int num = (int)Math.Round(yOffset / ImageYSpan * (double)ImageYSpanSamples);
			if (num >= 1)
			{
				if (num > ImageYSamples)
				{
					m_Image = new Bitmap(ImageXSamples, ImageYSamples);
				}
				else
				{
					Bitmap image = m_Image;
					m_Image = new Bitmap(ImageXSamples, ImageYSamples);
					if (image != null)
					{
						Graphics graphics = Graphics.FromImage(m_Image);
						Rectangle srcRect = new Rectangle(0, num, image.Width, ImageYSamples - num);
						Rectangle destRect = new Rectangle(0, 0, image.Width, ImageYSamples - num);
						graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
						graphics.Dispose();
						image.Dispose();
					}
					m_ImageYMin += yOffset;
				}
			}
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			m_FirstDrawComplete = true;
			if (!base.Designing && ImageXAutoSetup && !m_ImageXAutoSetupComplete)
			{
				ImageXSamples = xAxis.ScaleDisplay.PixelsSpan;
				ImageXSpanSamples = xAxis.ScaleDisplay.PixelsSpan;
				ImageXMin = xAxis.Min;
				ImageXSpan = xAxis.Span;
				m_ImageXAutoSetupComplete = true;
			}
			if (!base.Designing && ImageYAutoSetup && !m_ImageYAutoSetupComplete)
			{
				ImageYSamples = yAxis.ScaleDisplay.PixelsSpan;
				ImageYSpanSamples = yAxis.ScaleDisplay.PixelsSpan;
				ImageYMin = yAxis.Min;
				ImageYSpan = yAxis.Span;
				m_ImageXAutoSetupComplete = true;
			}
			if (!(xAxis.Min > ImageXMax) && !(xAxis.Max < ImageXMin) && !(yAxis.Min > ImageYMax) && !(yAxis.Max < ImageYMin))
			{
				double num = xAxis.Min;
				double num2 = xAxis.Max;
				double num3 = yAxis.Min;
				double num4 = yAxis.Max;
				if (num < ImageXMin)
				{
					num = ImageXMin;
				}
				if (num2 > ImageXMax)
				{
					num2 = ImageXMax;
				}
				if (num3 < ImageYMin)
				{
					num3 = ImageYMin;
				}
				if (num4 > ImageYMax)
				{
					num4 = ImageYMax;
				}
				Rectangle rectangle = iRectangle.FromLTRB(base.XYSwapped, xAxis.ValueToPixels(num), yAxis.ValueToPixels(num3), xAxis.ValueToPixels(num2), yAxis.ValueToPixels(num4));
				Point[] array = new Point[3];
				if (!base.XYSwapped)
				{
					if (!xAxis.Reverse && !yAxis.Reverse)
					{
						array[0] = new Point(rectangle.Left, rectangle.Bottom);
						array[1] = new Point(rectangle.Right, rectangle.Bottom);
						array[2] = new Point(rectangle.Left, rectangle.Top);
					}
					else if (!xAxis.Reverse && yAxis.Reverse)
					{
						array[0] = new Point(rectangle.Left, rectangle.Top);
						array[1] = new Point(rectangle.Right, rectangle.Top);
						array[2] = new Point(rectangle.Left, rectangle.Bottom);
					}
					else if (xAxis.Reverse && !yAxis.Reverse)
					{
						array[0] = new Point(rectangle.Right, rectangle.Bottom);
						array[1] = new Point(rectangle.Left, rectangle.Bottom);
						array[2] = new Point(rectangle.Right, rectangle.Top);
					}
					else
					{
						array[0] = new Point(rectangle.Right, rectangle.Top);
						array[1] = new Point(rectangle.Left, rectangle.Top);
						array[2] = new Point(rectangle.Right, rectangle.Bottom);
					}
				}
				else if (!xAxis.Reverse && !yAxis.Reverse)
				{
					array[0] = new Point(rectangle.Left, rectangle.Bottom);
					array[1] = new Point(rectangle.Left, rectangle.Top);
					array[2] = new Point(rectangle.Right, rectangle.Bottom);
				}
				else if (!xAxis.Reverse && yAxis.Reverse)
				{
					array[0] = new Point(rectangle.Right, rectangle.Bottom);
					array[1] = new Point(rectangle.Right, rectangle.Top);
					array[2] = new Point(rectangle.Left, rectangle.Bottom);
				}
				else if (xAxis.Reverse && !yAxis.Reverse)
				{
					array[0] = new Point(rectangle.Left, rectangle.Top);
					array[1] = new Point(rectangle.Left, rectangle.Bottom);
					array[2] = new Point(rectangle.Right, rectangle.Top);
				}
				else
				{
					array[0] = new Point(rectangle.Right, rectangle.Top);
					array[1] = new Point(rectangle.Right, rectangle.Bottom);
					array[2] = new Point(rectangle.Left, rectangle.Top);
				}
				int left = ValueToImageSampleX(num);
				int right = ValueToImageSampleX(num2);
				int top = ValueToImageSampleY(num4);
				int bottom = ValueToImageSampleY(num3);
				Rectangle srcRect = iRectangle.FromLTRB(left, top, right, bottom);
				srcRect = new Rectangle(srcRect.Left, srcRect.Top, srcRect.Width, srcRect.Height);
				p.Graphics.DrawImage(m_Image, array, srcRect, GraphicsUnit.Pixel);
			}
		}
	}
}
