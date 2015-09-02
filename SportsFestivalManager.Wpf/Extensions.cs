using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace SportsFestivalManager.Wpf
{
    internal static class Extensions
    {
        public static PropertyInfo GetPropertyInfo(this LambdaExpression getPropertyExpression)
        {
            Action<object> throwIfNull = obj =>
            {
                if (obj == null)
                    throw new InvalidOperationException("Not supported expression. Expression musst be like: () => Property");
            };

            var memberExpression = null as MemberExpression;

            if (getPropertyExpression.Body is MemberExpression)
                memberExpression = getPropertyExpression.Body as MemberExpression;
            else if (getPropertyExpression.Body is UnaryExpression)
            {
                // If convertion is necessary, the expression looks like: () => Convert(Property)

                var convertExpression = getPropertyExpression.Body as UnaryExpression;
                throwIfNull(convertExpression);

                memberExpression = convertExpression.Operand as MemberExpression;
            }

            throwIfNull(memberExpression);

            var property = memberExpression.Member as PropertyInfo;
            throwIfNull(property);

            return property;
        }
        public static object GetDefault(this Type type)
        {
            return type.IsValueType
                ? Activator.CreateInstance(type)
                : null;
        }
    }
}
