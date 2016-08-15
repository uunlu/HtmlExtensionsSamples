using HtmlExtensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlExtensions.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var player = new Player
            {
                Name = "Messi",
                Team = "FC Barcelona",
                Image = "http://gayguidebarcelona.es/wp-content/uploads/2015/08/90-La-Sagrada-Familia-Barcelona.jpg"
            };
            return View(player);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}