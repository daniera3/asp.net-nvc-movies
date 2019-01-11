using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()//Shows homepage by calling the index view.
        {
            return View();
        }
    }
}