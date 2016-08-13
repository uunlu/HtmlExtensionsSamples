using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlExtensions
{
    public static class HmlExtensionsButton
    {
        public static MvcHtmlString CustomButton(this HtmlHelper htmlHelper,
        string innerHtml,
        object htmlAttributes = null)
        {
            return CustomButton(htmlHelper, innerHtml, null, null, null, false, false, HmlExtensionsCommon.ButtonTypes.submit, htmlAttributes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="innerHtml"></param>
        /// <param name="cssClass"></param>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static MvcHtmlString CustomButton(this HtmlHelper htmlHelper,
          string innerHtml,
          string cssClass,
          string name,
          string title,
          object htmlAttributes = null)
        {
            return CustomButton(htmlHelper,  innerHtml, cssClass, name, title, false, false, HmlExtensionsCommon.ButtonTypes.submit, htmlAttributes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="innerHtml"></param>
        /// <param name="cssClass"></param>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <param name="isFormNoValidate"></param>
        /// <param name="isAutoFocus"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString CustomButton(this HtmlHelper htmlHelper, 
            string innerHtml, 
            string cssClass, 
            string name,
            string title,
            bool isFormNoValidate,
            bool isAutoFocus,
            HmlExtensionsCommon.ButtonTypes buttonType = HmlExtensionsCommon.ButtonTypes.submit,
            object htmlAttributes=null)
        {
            var tb = new TagBuilder("button");

            if(!string.IsNullOrWhiteSpace(cssClass))
            {
                if(!cssClass.Contains("btn-"))
                {
                    cssClass = "btn-primary " + cssClass;
                }
            }else
            {
                cssClass = "btn-primary";
            }

            tb.AddCssClass(cssClass);
            tb.AddCssClass("btn");

            // Html5 Attributes
            if(!string.IsNullOrWhiteSpace(title))
            {
                tb.MergeAttribute("title", title);
            }

            if(isFormNoValidate)
            {
                tb.MergeAttribute("formnovalidate", "formnovalidate");
            }

            if (isAutoFocus)
            {
                tb.MergeAttribute("autofocus", "autofocus");
            }

            // Html anonymous object attributes
            tb.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            HmlExtensionsCommon.AddName(tb, name, "");

            tb.InnerHtml = innerHtml;

            switch (buttonType)
            {
                case HmlExtensionsCommon.ButtonTypes.submit:
                    tb.MergeAttribute("type", "submit");
                    break;
                case HmlExtensionsCommon.ButtonTypes.button:
                    tb.MergeAttribute("type", "button");
                    break;
                case HmlExtensionsCommon.ButtonTypes.reset:
                    tb.MergeAttribute("type", "reset");
                    break;
                default:
                    tb.MergeAttribute("type", "submit");
                    break;
            }


            return MvcHtmlString.Create(tb.ToString());
        }
    }
}