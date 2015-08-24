using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFestivalManager.Data
{
    internal class StringValueTypeConverter : ValueTypeConverter<string>
    {
        public StringValueTypeConverter()
            : base("string")
        {
        }

        public override string ConvertToObject(string value)
        {
            return value;
        }
        public override string ConvertToString(string value)
        {
            return value;
        }
    }
}
