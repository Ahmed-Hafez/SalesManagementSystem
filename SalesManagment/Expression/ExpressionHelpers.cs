using System;
using System.Linq.Expressions;
using System.Reflection;

namespace SalesManagment
{
    /// <summary>
    /// A helpers for expressions
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Compiles an expression and gets the functions return value
        /// </summary>
        /// <typeparam name="T">The type of the return value</typeparam>
        /// <param name="lambdaExpression">The expression to compile</param>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambdaExpression)
        {
            return lambdaExpression.Compile().Invoke();
        }

        /// <summary>
        /// Sets the underlying properties to the given value 
        /// from an expression that contains the property
        /// </summary>
        /// <typeparam name="T">The type of value to set</typeparam>
        /// <param name="lambdaExpression">The expression</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lambdaExpression, T value)
        {
            // Converts lambda (() => this.someProperty) to this.someProperty
            var expression = (lambdaExpression as LambdaExpression).Body as MemberExpression;

            // Get the property information so we can set it
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            // Set the property value
            propertyInfo.SetValue(target, value);
        }

    }
}
