using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using static HtmlExtensions.HmlExtensionsCommon;

namespace HtmlExtensions
{
    public static class HtmlExtensionsImageBox
    {
        /// <summary>
        /// ImageBoxFor to add bootstrap img tag
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <param name="isResponsive"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ImageBoxFor<TModel, TValue>(
          this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TValue>> expression,
          bool isResponsive = true,
          object htmlAttributes = null
          )
        {
            return ImageBoxFor(htmlHelper, expression, null, null, isResponsive, ImageTypes.none, htmlAttributes);
        }

        /// <summary>
        /// ImageBoxFor to add bootstrap img tag
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <param name="cssClass"></param>
        /// <param name="alt"></param>
        /// <param name="isResponsive"></param>
        /// <param name="imgType"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ImageBoxFor<TModel, TValue>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            string cssClass,
            string alt,
            bool isResponsive = true,
            ImageTypes imgType = ImageTypes.none,
            object htmlAttributes = null
            )
        {
            var rvd = new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            
            var tb = new TagBuilder("img");
            tb.AddCssClass(cssClass);
            if (isResponsive)
                tb.AddCssClass("img-responsive");

            switch (imgType)
            {
                case ImageTypes.roundedCorners:
                    tb.AddCssClass("img-rounded");
                    break;
                case ImageTypes.circle:
                    tb.AddCssClass("img-circle");
                    break;
                case ImageTypes.thumbnail:
                    tb.AddCssClass("img-thumbnail");
                    break;
                case ImageTypes.none:
                    break;
                default:
                    break;
            }
            if (htmlAttributes != null)
            {
                tb.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            }

            // Get the model value
            var modelName = ExpressionHelpers.MemberName(expression);
            Func<TModel, TValue> method = expression.Compile();
            TValue value = method(htmlHelper.ViewData.Model);

            // Add model value to the image src
            tb.Attributes["src"]= value.ToString();

            return MvcHtmlString.Create(tb.ToString());
        }
    }
}