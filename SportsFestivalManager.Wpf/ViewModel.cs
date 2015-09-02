using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Dynamic;

namespace SportsFestivalManager.Wpf
{
    public class ViewModel : INotifyPropertyChanged
    {
        private readonly ConcurrentDictionary<string, object> _propertyValues;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            _propertyValues = new ConcurrentDictionary<string, object>();
        }

        protected virtual TProperty GetValue<TProperty>(Expression<Func<TProperty>> getPropertyExpression)
        {
            return (TProperty)GetValue(getPropertyExpression as LambdaExpression);
        }
        protected virtual bool SetValue<TProperty>(Expression<Func<TProperty>> getPropertyExpression, TProperty value)
        {
            return SetValue(getPropertyExpression as LambdaExpression, value);
        }
        protected virtual void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> getPropertyExpression)
        {
            var property = getPropertyExpression.GetPropertyInfo();
            OnPropertyChanged(property);
        }
        protected virtual void OnPropertyChanged(PropertyInfo property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property.Name));
        }
        
        private object GetValue(LambdaExpression getPropertyExpression)
        {
            var property = getPropertyExpression.GetPropertyInfo();
            return _propertyValues.GetOrAdd(property.Name, _ => property.PropertyType.GetDefault());
        }
        private bool SetValue(LambdaExpression getPropertyExpression, object value)
        {
            var changed = true;
            var property = getPropertyExpression.GetPropertyInfo();
            _propertyValues.AddOrUpdate(property.Name, value, (p, oldValue) =>
            {
                changed = oldValue != value;
                return value;
            });

            if (changed)
                OnPropertyChanged(property);

            return changed;
        }
    }
}
