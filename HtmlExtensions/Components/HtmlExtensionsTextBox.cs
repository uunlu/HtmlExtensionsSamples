using HtmlExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace HtmlExtensions
{
    public static class HtmlExtensionsTextBox
    {
        public static MvcHtmlString CustomTextBoxFor<TModel, TValue>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            HmlExtensionsCommon.InputTypes type = HmlExtensionsCommon.InputTypes.text,
            object htmlAttributes = null
            )
        {
            RouteValueDictionary rvd;

            rvd = new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            rvd.Add("type", type.ToString());

            return InputExtensions.TextBoxFor(htmlHelper, expression, rvd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">lambda expression for model</param>
        /// <param name="type">select input type e.g.: reset, submit...</param>
        /// <param name="htmlAttributes">Add custom attributes to textbox</param>
        /// <returns></returns>
        public static MvcHtmlString FormFieldTextBoxFor<TModel, TValue>(
          this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TValue>> expression,
          HmlExtensionsCommon.InputTypes type = HmlExtensionsCommon.InputTypes.text,
          object htmlAttributes = null
          )
        {
            return FormFieldTextBoxFor(htmlHelper, expression, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression">lambda expression for model</param>
        /// <param name="cssClassForLabel">custom CSS for label</param>
        /// <param name="type">select input type e.g.: reset, submit...</param>
        /// <param name="htmlAttributes">Add custom attributes to textbox</param>
        /// <returns></returns>
        public static MvcHtmlString FormFieldTextBoxFor<TModel, TValue>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            string cssClassForLabel,
            HmlExtensionsCommon.InputTypes type = HmlExtensionsCommon.InputTypes.text,
            object htmlAttributes = null
            )
        {
            RouteValueDictionary rvd;
            var tb = new TagBuilder("label");

            // set label text from its name or data attribute value
            var modelName = ExpressionHelpers.MemberName(expression);
            tb.SetInnerText(modelName);

            if (string.IsNullOrWhiteSpace(cssClassForLabel))
                tb.AddCssClass("form-inline");
            else
                tb.AddCssClass(cssClassForLabel);

            rvd = new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            rvd.Add("type", type.ToString());
            var input = InputExtensions.TextBoxFor(htmlHelper, expression, rvd);

            // Join label and textbox tags
            var htmlString = MvcHtmlString.Create(tb.ToString() + input.ToString());

            return htmlString;
        }
    }
}