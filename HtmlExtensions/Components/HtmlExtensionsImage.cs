using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HtmlExtensions
{
    public static class HtmlExtensionsImage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="src">Image source</param>
        /// <param name="altText">Alt text</param>
        /// <param name="htmlAttributes">new object { data_action = "start-animation" }</param>
        /// <returns></returns>
        public static MvcHtmlString Image(this HtmlHelper htmlHelper,
            string src,
            string altText,
            object htmlAttributes = null)
        {
            return Image(htmlHelper, src, altText, string.Empty, string.Empty, htmlAttributes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="src">Image source</param>
        /// <param name="altText">Alt text</param>
        /// <param name="cssClass">Class values such as bootstrap</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString Image(this HtmlHelper htmlHelper,
            string src,
            string altText,
            string cssClass,
            object htmlAttributes = null)
        {
            return Image(htmlHelper, src, altText, cssClass, string.Empty, htmlAttributes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="src">Image source</param>
        /// <param name="altText">Alt text</param>
        /// <param name="cssClass">Class values such as bootstrap</param>
        /// <param name="name">Name of tag creates also Id</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString Image(this HtmlHelper htmlHelper,
            string src,
            string altText,
            string cssClass, 
            string name,
            object htmlAttributes = null)
        {
            var tb = new TagBuilder("img");
            tb.MergeAttribute("src", src);
            if (!string.IsNullOrEmpty(altText))
                tb.MergeAttribute("alt", altText);

            if (!string.IsNullOrEmpty(cssClass))
            {
                tb.AddCssClass(cssClass);
            }


            if (!string.IsNullOrEmpty(name))
            {
                name = TagBuilder.CreateSanitizedId(name);
                tb.GenerateId(name);
                tb.MergeAttribute("name", name);
            }

            if(htmlAttributes!=null)
            {
                tb.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            }

            return MvcHtmlString.Create(tb.ToString(TagRenderMode.SelfClosing));
        }
    }
}