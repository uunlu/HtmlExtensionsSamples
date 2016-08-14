using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace HtmlExtensions
{
    public static class ExpressionHelpers
    {
        public static string MemberName<T, V>(this Expression<Func<T, V>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException("Expression must be a member expression");

            string name = memberExpression.Member.Name;

            if(memberExpression.Member.GetCustomAttributes(true).Any())
            {
                var attr = memberExpression.Member.GetCustomAttributes(true).FirstOrDefault() as DisplayAttribute;
                name = attr.Name;
            }
           
            return name;
        }

        public static T GetAttribute<T>(this ICustomAttributeProvider provider)
            where T : Attribute
        {
            var attributes = provider.GetCustomAttributes(typeof(T), true);
            return attributes.Length > 0 ? attributes[0] as T : null;
        }

        public static bool IsRequired<T, V>(this Expression<Func<T, V>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException("Expression must be a member expression");

            return memberExpression.Member.GetAttribute<RequiredAttribute>() != null;
        }
    }
}