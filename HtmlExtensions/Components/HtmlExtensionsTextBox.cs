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

        public static MvcHtmlString FormFieldTextBoxFor<TModel, TValue>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            HmlExtensionsCommon.InputTypes type = HmlExtensionsCommon.InputTypes.text,
            object htmlAttributes = null
            )
        {
            RouteValueDictionary rvd;
            var tb = new TagBuilder("label");

            // set label text from its name or data attribute value
            var modelName = ExpressionHelpers.MemberName(expression);
            tb.SetInnerText(modelName);
            tb.AddCssClass("form-inline");

            rvd = new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            rvd.Add("type", type.ToString());
            var input = InputExtensions.TextBoxFor(htmlHelper, expression, rvd);

            // Join label and textbox tags
            var htmlString = MvcHtmlString.Create(tb.ToString() + input.ToString());

            return htmlString;
        }
    }
}