using Iocomp.Delegates;
using Iocomp.Design;
using Iocomp.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(CollectionItemConverter))]
	public sealed class PercentItem : SubClassBase
	{
		private ValueDouble m_Value;

		private string m_Title;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public ValueDouble Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				m_Value.AsDouble = value.AsDouble;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string Title
		{
			get
			{
				return m_Title;
			}
			set
			{
				base.PropertyUpdateDefault("Title", value);
				if (Title != value)
				{
					m_Title = value;
					base.DoPropertyChange(this, "Title");
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

		[Category("Iocomp")]
		public event ValueDoubleEventHandler ValueChanged;

		[Category("Iocomp")]
		public event ValueDoubleEventHandler ValueBeforeChange;

		protected override string GetPlugInTitle()
		{
			return "Percent Item";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PercentItemEditorPlugIn";
		}

		public PercentItem()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			m_Value = new ValueDouble();
			base.AddSubClass(Value);
			Value.Changing += OnValueBeforeChange;
			Value.Changed += OnValueChanged;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			Value.AsDouble = 100.0;
			Title = "Untitled";
			Color = Color.Red;
		}

		private bool ShouldSerializeValue()
		{
			return ((ISubClassBase)Value).ShouldSerialize();
		}

		private void ResetValue()
		{
			((ISubClassBase)Value).ResetToDefault();
		}

		private bool ShouldSerializeTitle()
		{
			return base.PropertyShouldSerialize("Title");
		}

		private void ResetTitle()
		{
			base.PropertyReset("Title");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private void OnValueChanged(object sender, ValueDoubleEventArgs e)
		{
			if (this.ValueChanged != null)
			{
				this.ValueChanged(this, e);
			}
		}

		private void OnValueBeforeChange(object sender, ValueDoubleEventArgs e)
		{
			if (this.ValueBeforeChange != null)
			{
				this.ValueBeforeChange(this, e);
			}
		}

		public override string ToString()
		{
			return Title;
		}
	}
}
