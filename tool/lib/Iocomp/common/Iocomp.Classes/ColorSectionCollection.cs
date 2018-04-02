using Iocomp.Interfaces;
using System;
using System.Collections;
using System.Drawing;

namespace Iocomp.Classes
{
	public class ColorSectionCollection : CollectionBase
	{
		public ColorSection this[int index]
		{
			get
			{
				return base.List[index] as ColorSection;
			}
			set
			{
				base.List[index] = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Color Section Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ColorSectionCollectionEditorPlugIn";
		}

		public ColorSectionCollection()
			: base(null)
		{
		}

		public ColorSectionCollection(IComponentBase componentBase)
			: base(componentBase)
		{
		}

		public void CopyTo(ColorSection[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(ColorSection value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, ColorSection value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(ColorSection value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(ColorSection value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(ColorSection value)
		{
			return base.List.Contains(value);
		}

		public override void Reset()
		{
			base.Clear();
			Add(new ColorSection(Color.Lime, 0.0, 50.0));
			Add(new ColorSection(Color.Yellow, 50.0, 75.0));
			Add(new ColorSection(Color.Red, 75.0, 100.0));
		}

		public Color GetColor(double value, Color defaultColor)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (this[i].Visible && value >= this[i].Start && value < this[i].Stop)
				{
					return this[i].Color;
				}
			}
			return defaultColor;
		}
	}
}
