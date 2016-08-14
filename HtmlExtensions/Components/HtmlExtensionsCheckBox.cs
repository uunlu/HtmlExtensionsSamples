using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace HtmlExtensions
{
    public static class HtmlExtensionsCheckBox
    {
        /// <summary>
        /// Custom checkbox
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <param name="text"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString CustomCheckBoxFor<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> expression,
            string text,
            object htmlAttributes = null
            )
        {
            return CustomCheckBoxFor(htmlHelper, expression, text, null, false, htmlAttributes);
        }

        /// <summary>
        /// Custom checkbox
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <param name="text"></param>
        /// <param name="title"></param>
        /// <param name="isAutoFocus"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString CustomCheckBoxFor<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> expression,
            string text,
            string title,
            bool isAutoFocus,
            object htmlAttributes = null
            )
        {

            var rvd = new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            if (string.IsNullOrWhiteSpace(title))
            {
                title = text;
            }

            rvd.Add("title", title);

            if (isAutoFocus)
            {
                rvd.Add("autofocus", "autofocus");
            }

            var tb = new TagBuilder("div");
            tb.AddCssClass("checkbox");
            var tbLbl = new TagBuilder("label");

            var checkBoxHtml = InputExtensions.CheckBoxFor(htmlHelper, expression, rvd);
            tbLbl.InnerHtml = checkBoxHtml.ToString() + " " + text;
            tb.InnerHtml = tbLbl.ToString();

            return MvcHtmlString.Create(tb.ToString());
        }
    }
}