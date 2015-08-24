using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFestivalManager.Data
{
    internal class NumberRangeValueTypeConverter : ValueTypeConverter<float>
    {
        public NumberRangeValueTypeConverter()
            : base("float")
        {
        }

        public override float ConvertToObject(string value)
        {
            return float.Parse(value);
        }
        public override string ConvertToString(float value)
        {
            return value.ToString();
        }
    }
}
