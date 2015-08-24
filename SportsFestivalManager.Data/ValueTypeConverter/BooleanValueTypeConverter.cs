using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFestivalManager.Data
{
    internal class BooleanValueTypeConverter : ValueTypeConverter<bool>
    {
        public BooleanValueTypeConverter()
            : base("string")
        {
        }

        public override bool ConvertToObject(string value)
        {
            return bool.Parse(value);
        }
        public override string ConvertToString(bool value)
        {
            return value.ToString();
        }
    }
}
