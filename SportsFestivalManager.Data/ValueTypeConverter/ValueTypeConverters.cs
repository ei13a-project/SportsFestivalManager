using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFestivalManager.Data
{
    public class ValueTypeConverters : IEnumerable<IValueTypeConverter>
    {
        public static ValueTypeConverters Instance { get; } = new ValueTypeConverters();

        private readonly ConcurrentBag<IValueTypeConverter> _coverters;

        private ValueTypeConverters()
        {
            _coverters = new ConcurrentBag<IValueTypeConverter>();
        }

        public IValueTypeConverter GetConverter(string name)
        {
            return GetConverter(x => x.Name == name);
        }
        public IValueTypeConverter GetConverter<TValue>()
        {
            return GetConverter(typeof(TValue));
        }
        public IValueTypeConverter GetConverter(Type valueType)
        {
            return GetConverter(x => x.ValueType == valueType);
        }
        internal IValueTypeConverter GetConverter(Func<IValueTypeConverter, bool> condition)
        {
            return _coverters.FirstOrDefault(condition);
        }

        internal void Add(IValueTypeConverter converter)
        {
            _coverters.Add(converter);
        }

        public IEnumerator<IValueTypeConverter> GetEnumerator()
        {
            return _coverters.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
