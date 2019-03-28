using System;
using System.ComponentModel;

namespace SMAH1.Forms.Chart.Configuration
{
    class ChartConfigurationTypeConverterNameDescriptorProperty : PropertyDescriptor
    {
        private readonly PropertyDescriptor parent;

        public ChartConfigurationTypeConverterNameDescriptorProperty(
                PropertyDescriptor parent,
                string name,
                string description
            )
            : base(parent)
        {
            DisplayName = name;
            Description = description;
            this.parent = parent;
        }

        public override string DisplayName { get; }
        public override string Description { get; }

        #region Parent call
        public override bool ShouldSerializeValue(object component) { return parent.ShouldSerializeValue(component); }
        public override void SetValue(object component, object value) { parent.SetValue(component, value); }
        public override object GetValue(object component) { return parent.GetValue(component); }
        public override void ResetValue(object component) { parent.ResetValue(component); }
        public override bool CanResetValue(object component) { return parent.CanResetValue(component); }
        public override void AddValueChanged(object component, EventHandler handler) { parent.AddValueChanged(component, handler); }
        public override void RemoveValueChanged(object component, EventHandler handler) { parent.RemoveValueChanged(component, handler); }
        public override PropertyDescriptorCollection GetChildProperties(object instance, System.Attribute[] filter) { return parent.GetChildProperties(instance, filter); }

        public override bool IsReadOnly { get { return parent.IsReadOnly; } }
        public override bool SupportsChangeEvents { get { return parent.SupportsChangeEvents; } }
        public override Type PropertyType { get { return parent.PropertyType; } }
        public override TypeConverter Converter { get { return parent.Converter; } }
        public override Type ComponentType { get { return parent.ComponentType; } }
        public override string Name { get { return parent.Name; } }
        #endregion
    }
}
