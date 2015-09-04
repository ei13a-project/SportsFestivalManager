using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SportsFestivalManager.Wpf
{
    public class DataGridProperty : ViewModel
    {
        public object Value
        {
            get { return GetValue(() => Value); }
            set { SetValue(() => Value, value); }
        }
        public string PropertyName
        {
            get { return GetValue(() => PropertyName); }
        }
        public string DisplayName
        {
            get { return GetValue(() => DisplayName); }
        }
        public bool IsGroupable
        {
            get { return GetValue(() => IsGroupable); }
        }
        public bool IsGrouped
        {
            get { return GetValue(() => IsGrouped); }
            set { SetValue(() => IsGrouped, value); }
        }

        public DataGridProperty(string propertyName, string displayName, bool isGroupable)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            if (string.IsNullOrWhiteSpace(displayName))
                throw new ArgumentNullException(nameof(displayName));

            SetValue(() => PropertyName, propertyName);
            SetValue(() => DisplayName, displayName);
            SetValue(() => IsGroupable, isGroupable);
        }
    }
}
