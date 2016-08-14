using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HtmlExtensions.Models
{
    public class Player
    {
        public string Name { get; set; }
        [Display(Name = "Manschaft")]
        public string Team { get; set; }
        public bool IsActive { get; set; }
    }
}