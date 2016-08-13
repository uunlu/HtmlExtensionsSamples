using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlExtensions
{
    public static class HmlExtensionsCommon
    {
        public enum ButtonTypes
        {
            submit, 
            button,
            reset
        }

        public static void AddName(TagBuilder tb, 
            string name, 
            string id)
        {
           if(!string.IsNullOrWhiteSpace(name))
            {
                name = TagBuilder.CreateSanitizedId(name);

                if(string.IsNullOrWhiteSpace(id))
                {
                    tb.GenerateId(name);
                }
                else
                {
                    id = TagBuilder.CreateSanitizedId(id);
                    tb.MergeAttribute("id", id);
                }

                tb.MergeAttribute("name", name);
            }

            tb.MergeAttribute("name", name);
        }
    }
}