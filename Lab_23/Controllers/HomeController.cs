using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_23.Models;

namespace Lab_23.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Lab23DB ORM = new Lab23DB();
            ViewBag.Items = ORM.Items.ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}