using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFestivalManager.Data
{
    internal class NumberValueTypeConverter : ValueTypeConverter<int>
    {
        public NumberValueTypeConverter()
            : base("int")
        {
        }

        public override int ConvertToObject(string value)
        {
            return int.Parse(value);
        }
        public override string ConvertToString(int value)
        {
            return value.ToString();
        }
    }
}
