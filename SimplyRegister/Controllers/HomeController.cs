using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimplyRegister.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Let your customers register. Simply.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us:";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }




    }
}