
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {

        // GET: Movies
      
        
        public ActionResult CMovie()
        {
            
            return View();

        }

       
        public ActionResult Movie()
        {
            return View();

        }


        
        public ActionResult Top10(string num)
        {
          
            ViewBag.num = num;
            return View();
            
        }

        public ActionResult Genre()
        {

            return View();

        }
 
      
        public ActionResult MoviesPerGaner(string ganer)
        {
            
            return View();
        }
    }

}