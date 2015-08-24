using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsFestivalManager.Data
{
    public interface IValueTypeConverter
    {
        string Name { get; }
        Type ValueType { get; }

        string ConvertToString(object value);
        object ConvertToObject(string value);
    }
}
