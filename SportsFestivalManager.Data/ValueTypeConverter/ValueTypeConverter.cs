using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFestivalManager.Data
{
    public static class ValueTypeConverter
    {
        public static IValueTypeConverter String { get; }
        public static IValueTypeConverter Number { get; }
        public static IValueTypeConverter NumberRange { get; }
        public static IValueTypeConverter Boolean { get; }

        static ValueTypeConverter()
        {
            ValueTypeConverters.Instance.Add(String = new StringValueTypeConverter());
            ValueTypeConverters.Instance.Add(Number = new NumberValueTypeConverter());
            ValueTypeConverters.Instance.Add(NumberRange = new NumberRangeValueTypeConverter());
            ValueTypeConverters.Instance.Add(Boolean = new BooleanValueTypeConverter());
        }
    }

    internal abstract class ValueTypeConverter<TValue> : IValueTypeConverter
    {
        public string Name { get; }

        public Type ValueType
        {
            get  { return typeof(TValue); }
        }

        protected ValueTypeConverter(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public abstract TValue ConvertToObject(string value);
        public abstract string ConvertToString(TValue value);

        string IValueTypeConverter.ConvertToString(object value)
        {
            return ConvertToString((TValue)value);
        }
        object IValueTypeConverter.ConvertToObject(string value)
        {
            return ConvertToObject(value);
        }
    }
}
